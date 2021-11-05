// Decompiled with JetBrains decompiler
// Type: EyeStepPackage.EyeStep
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EyeStepPackage
{
  public class EyeStep
  {
    private const int MOD_NOT_FIRST = 255;
    private const int N_X86_OPCODES = 919;
    public static Process current_proc;
    public static int handle;
    public static int base_module;
    public static int base_module_size;
    public static EyeStep.OP_INFO[] OP_TABLE = (EyeStep.OP_INFO[]) null;
    public const uint PRE_REPNE = 1;
    public const uint PRE_REPE = 2;
    public const uint PRE_66 = 4;
    public const uint PRE_67 = 8;
    public const uint PRE_LOCK = 16;
    public const uint PRE_SEG_CS = 32;
    public const uint PRE_SEG_SS = 64;
    public const uint PRE_SEG_DS = 128;
    public const uint PRE_SEG_ES = 256;
    public const uint PRE_SEG_FS = 512;
    public const uint PRE_SEG_GS = 1024;
    public const byte OP_LOCK = 240;
    public const byte OP_REPNE = 242;
    public const byte OP_REPE = 243;
    public const byte OP_66 = 102;
    public const byte OP_67 = 103;
    public const byte OP_SEG_CS = 46;
    public const byte OP_SEG_SS = 54;
    public const byte OP_SEG_DS = 62;
    public const byte OP_SEG_ES = 38;
    public const byte OP_SEG_FS = 100;
    public const byte OP_SEG_GS = 101;
    public const uint OP_NONE = 0;
    public const uint OP_SINGLE = 1;
    public const uint OP_SRC_DEST = 2;
    public const uint OP_EXTENDED = 4;
    public const uint OP_IMM8 = 16;
    public const uint OP_IMM16 = 32;
    public const uint OP_IMM32 = 64;
    public const uint OP_DISP8 = 128;
    public const uint OP_DISP16 = 256;
    public const uint OP_DISP32 = 512;
    public const uint OP_R8 = 1024;
    public const uint OP_R16 = 2048;
    public const uint OP_R32 = 4096;
    public const uint OP_R64 = 8192;
    public const uint OP_XMM = 16384;
    public const uint OP_MM = 32768;
    public const uint OP_ST = 65536;
    public const uint OP_SREG = 131072;
    public const uint OP_DR = 262144;
    public const uint OP_CR = 524288;
    public const byte R8_AL = 0;
    public const byte R8_CL = 1;
    public const byte R8_DL = 2;
    public const byte R8_BL = 3;
    public const byte R8_AH = 4;
    public const byte R8_CH = 5;
    public const byte R8_DH = 6;
    public const byte R8_BH = 7;
    public const byte R16_AX = 0;
    public const byte R16_CX = 1;
    public const byte R16_DX = 2;
    public const byte R16_BX = 3;
    public const byte R16_SP = 4;
    public const byte R16_BP = 5;
    public const byte R16_SI = 6;
    public const byte R16_DI = 7;
    public const byte R32_EAX = 0;
    public const byte R32_ECX = 1;
    public const byte R32_EDX = 2;
    public const byte R32_EBX = 3;
    public const byte R32_ESP = 4;
    public const byte R32_EBP = 5;
    public const byte R32_ESI = 6;
    public const byte R32_EDI = 7;
    public static byte[] multipliers = new byte[4]
    {
      (byte) 0,
      (byte) 2,
      (byte) 4,
      (byte) 8
    };

    private static int getm20(byte x) => (int) x % 32;

    private static int getm40(byte x) => (int) x % 64;

    private static int finalreg(byte x) => (int) x % 64 % 8;

    private static int longreg(byte x) => (int) x % 64 / 8;

    public static void init() => EyeStep.OP_TABLE = new EyeStep.OP_INFO[919]
    {
      new EyeStep.OP_INFO("00", "add", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Add"),
      new EyeStep.OP_INFO("01", "add", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Add"),
      new EyeStep.OP_INFO("02", "add", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Add"),
      new EyeStep.OP_INFO("03", "add", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Add"),
      new EyeStep.OP_INFO("04", "add", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Add"),
      new EyeStep.OP_INFO("05", "add", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Add"),
      new EyeStep.OP_INFO("06", "push", new OP_TYPES[1]
      {
        OP_TYPES.ES
      }, "Push Extra Segment onto the stack"),
      new EyeStep.OP_INFO("07", "pop", new OP_TYPES[1]
      {
        OP_TYPES.ES
      }, "Pop Extra Segment off of the stack"),
      new EyeStep.OP_INFO("08", "or", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("09", "or", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("0A", "or", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("0B", "or", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("0C", "or", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("0D", "or", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("0E", "push", new OP_TYPES[1]
      {
        OP_TYPES.CS
      }, "Push Code Segment onto the stack"),
      new EyeStep.OP_INFO("0F+00+m0", "sldt", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Store Local Descriptor Table Register"),
      new EyeStep.OP_INFO("0F+00+m1", "str", new OP_TYPES[1]
      {
        OP_TYPES.r_m16
      }, "Store Task Register"),
      new EyeStep.OP_INFO("0F+00+m2", "lldt", new OP_TYPES[1]
      {
        OP_TYPES.r_m16
      }, "Load Local Descriptor Table Register"),
      new EyeStep.OP_INFO("0F+00+m3", "ltr", new OP_TYPES[1]
      {
        OP_TYPES.r_m16
      }, "Load Task Register"),
      new EyeStep.OP_INFO("0F+00+m4", "verr", new OP_TYPES[1]
      {
        OP_TYPES.r_m16
      }, "Verify a Segment for Reading"),
      new EyeStep.OP_INFO("0F+00+m5", "verw", new OP_TYPES[1]
      {
        OP_TYPES.r_m16
      }, "Verify a Segment for Writing"),
      new EyeStep.OP_INFO("0F+01+C1", "vmcall", new OP_TYPES[0], "Call to VM Monitor"),
      new EyeStep.OP_INFO("0F+01+C2", "vmlaunch", new OP_TYPES[0], "Launch Virtual Machine"),
      new EyeStep.OP_INFO("0F+01+C3", "vmresume", new OP_TYPES[0], "Resume Virtual Machine"),
      new EyeStep.OP_INFO("0F+01+C4", "vmxoff", new OP_TYPES[0], "Leave VMX Operation"),
      new EyeStep.OP_INFO("0F+01+C8", "monitor", new OP_TYPES[0], "Set Up Monitor Address"),
      new EyeStep.OP_INFO("0F+01+C9", "mwait", new OP_TYPES[0], "Monitor Wait"),
      new EyeStep.OP_INFO("0F+01+CA", "clac", new OP_TYPES[0], "Clear AC flag in EFLAGS register"),
      new EyeStep.OP_INFO("0F+01+m0", "sgdt", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Store Global Descriptor Table Register"),
      new EyeStep.OP_INFO("0F+01+m1", "sidt", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Store Interrupt Descriptor Table Register"),
      new EyeStep.OP_INFO("0F+01+m2", "lgdt", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Load Global Descriptor Table Register"),
      new EyeStep.OP_INFO("0F+01+m3", "lidt", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Load Interrupt Descriptor Table Register"),
      new EyeStep.OP_INFO("0F+01+m4", "smsw", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Store Machine Status Word"),
      new EyeStep.OP_INFO("0F+01+m5", "smsw", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Store Machine Status Word"),
      new EyeStep.OP_INFO("0F+01+m6", "lmsw", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Load Machine Status Word"),
      new EyeStep.OP_INFO("0F+01+m7", "invplg", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Invalidate TLB Entry"),
      new EyeStep.OP_INFO("0F+02", "lar", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.m16
      }, "Load Access Rights Byte"),
      new EyeStep.OP_INFO("0F+03", "lsl", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.m16
      }, "Load Segment Limit"),
      new EyeStep.OP_INFO("0F+04", "ud", new OP_TYPES[0], "Undefined Instruction"),
      new EyeStep.OP_INFO("0F+05", "syscall", new OP_TYPES[0], "Fast System Call"),
      new EyeStep.OP_INFO("0F+06", "clts", new OP_TYPES[1]
      {
        OP_TYPES.CR0
      }, "Clear Task-Switched Flag in CR0"),
      new EyeStep.OP_INFO("0F+07", "sysret", new OP_TYPES[0], "Return form fast system call"),
      new EyeStep.OP_INFO("0F+08", "invd", new OP_TYPES[0], "Invalidate Internal Caches"),
      new EyeStep.OP_INFO("0F+09", "wbinvd", new OP_TYPES[0], "Write Back and Invalidate Cache"),
      new EyeStep.OP_INFO("0F+0B", "ud2", new OP_TYPES[0], "Undefined Instruction"),
      new EyeStep.OP_INFO("0F+0D", "nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "No Operation"),
      new EyeStep.OP_INFO("0F+10", "movups", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Move Unaligned Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+10", "movss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Move Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+10", "movupd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Move Unaligned Packed Double-FP Value"),
      new EyeStep.OP_INFO("F2+0F+10", "movsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Move Scalar Double-FP Value"),
      new EyeStep.OP_INFO("0F+11", "movups", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm
      }, "Move Unaligned Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+11", "movss", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m32,
        OP_TYPES.xmm
      }, "Move Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+11", "movupd", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm
      }, "Move Unaligned Packed Double-FP Value"),
      new EyeStep.OP_INFO("F2+0F+11", "movsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m64,
        OP_TYPES.xmm
      }, "Move Scalar Double-FP Value"),
      new EyeStep.OP_INFO("0F+12", "movhlps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm
      }, "Move Packed Single-FP Values High to Low"),
      new EyeStep.OP_INFO("0F+12", "movlps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Move Low Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+12", "movlpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Move Low Packed Double-FP Value"),
      new EyeStep.OP_INFO("66+0F+12", "movddup", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Move One Double-FP and Duplicate"),
      new EyeStep.OP_INFO("F2+0F+12", "movsldup", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Move Packed Single-FP Low and Duplicate"),
      new EyeStep.OP_INFO("0F+13", "movlps", new OP_TYPES[2]
      {
        OP_TYPES.m64,
        OP_TYPES.xmm
      }, "Move Low Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+13", "movlpd", new OP_TYPES[2]
      {
        OP_TYPES.m64,
        OP_TYPES.xmm
      }, "Move Low Packed Double-FP Value"),
      new EyeStep.OP_INFO("0F+14", "unpcklps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Unpack and Interleave Low Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+14", "unpcklpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack and Interleave Low Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+15", "unpckhps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Unpack and Interleave High Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+15", "unpckhpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack and Interleave High Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+16", "movlhps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm
      }, "Move Packed Single-FP Values Low to High"),
      new EyeStep.OP_INFO("0F+16", "movhps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Move High Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+16", "movhpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Move High Packed Double-FP Value"),
      new EyeStep.OP_INFO("F3+0F+16", "movshdup", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Move Packed Single-FP High and Duplicate"),
      new EyeStep.OP_INFO("0F+17", "movhps", new OP_TYPES[2]
      {
        OP_TYPES.m64,
        OP_TYPES.xmm
      }, "Move High Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+17", "movhpd", new OP_TYPES[2]
      {
        OP_TYPES.m64,
        OP_TYPES.xmm
      }, "Move High Packed Double-FP Value"),
      new EyeStep.OP_INFO("0F+18+m0", "prefetchnta", new OP_TYPES[1]
      {
        OP_TYPES.m8
      }, "Prefetch Data Into Caches"),
      new EyeStep.OP_INFO("0F+18+m1", "prefetcht0", new OP_TYPES[1]
      {
        OP_TYPES.m8
      }, "Prefetch Data Into Caches"),
      new EyeStep.OP_INFO("0F+18+m2", "prefetcht1", new OP_TYPES[1]
      {
        OP_TYPES.m8
      }, "Prefetch Data Into Caches"),
      new EyeStep.OP_INFO("0F+18+m3", "prefetcht2", new OP_TYPES[1]
      {
        OP_TYPES.m8
      }, "Prefetch Data Into Caches"),
      new EyeStep.OP_INFO("0F+18+m4", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+18+m5", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+18+m6", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+18+m7", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+19", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1A", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1B", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1C", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1D", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1E", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1F+m0", "nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "No Operation"),
      new EyeStep.OP_INFO("0F+1F+m1", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1F+m2", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1F+m3", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1F+m4", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1F+m5", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1F+m6", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+1F+m7", "hint_nop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Hintable NOP"),
      new EyeStep.OP_INFO("0F+20", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r_m32,
        OP_TYPES.CRn
      }, "Move to/from Control Registers"),
      new EyeStep.OP_INFO("0F+21", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r_m32,
        OP_TYPES.DRn
      }, "Move to/from Debug Registers"),
      new EyeStep.OP_INFO("0F+22", "mov", new OP_TYPES[2]
      {
        OP_TYPES.CRn,
        OP_TYPES.r_m32
      }, "Move to/from Control Registers"),
      new EyeStep.OP_INFO("0F+23", "mov", new OP_TYPES[2]
      {
        OP_TYPES.DRn,
        OP_TYPES.r_m32
      }, "Move to/from Debug Registers"),
      new EyeStep.OP_INFO("0F+28", "movaps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Move Aligned Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+28", "movapd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Move Aligned Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+29", "movaps", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm
      }, "Move Aligned Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+29", "movapd", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm
      }, "Move Aligned Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+2A", "cvtpi2ps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.mm_m64
      }, "Convert Packed DW Integers to Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+2A", "cvtpi2ss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.r_m32
      }, "Convert DW Integer to Scalar Single-FP Value"),
      new EyeStep.OP_INFO("66+0F+2A", "cvtpi2pd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.mm_m64
      }, "Convert Packed DW Integers to Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+2A", "cvtpi2sd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.r_m32
      }, "Convert DW Integer to Scalar Double-FP Value"),
      new EyeStep.OP_INFO("0F+2B", "movntps", new OP_TYPES[2]
      {
        OP_TYPES.m128,
        OP_TYPES.xmm
      }, "Store Packed Single-FP Values Using Non-Temporal Hint"),
      new EyeStep.OP_INFO("66+0F+2B", "movntpd", new OP_TYPES[2]
      {
        OP_TYPES.m128,
        OP_TYPES.xmm
      }, "Store Packed Double-FP Values Using Non-Temporal Hint"),
      new EyeStep.OP_INFO("0F+2C", "cvttps2pi", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.xmm_m64
      }, "Convert with Trunc. Packed Single-FP Values to DW Integers"),
      new EyeStep.OP_INFO("F3+0F+2C", "cvttss2si", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm_m32
      }, "Convert with Trunc. Scalar Single-FP Value to DW Integer"),
      new EyeStep.OP_INFO("66+0F+2C", "cvttpd2pi", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.xmm_m128
      }, "Convert with Trunc. Packed Double-FP Values to DW Integers"),
      new EyeStep.OP_INFO("F2+0F+2C", "cvttsd2si", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm_m64
      }, "Convert with Trunc. Scalar Double-FP Value to Signed DW Int"),
      new EyeStep.OP_INFO("0F+2D", "cvtps2pi", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.xmm_m64
      }, "Convert Packed Single-FP Values to DW Integers"),
      new EyeStep.OP_INFO("F3+0F+2D", "cvtss2si", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm_m32
      }, "Convert Scalar Single-FP Value to DW Integer"),
      new EyeStep.OP_INFO("66+0F+2D", "cvtpd2pi", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.xmm_m128
      }, "Convert Packed Double-FP Values to DW Integers"),
      new EyeStep.OP_INFO("F2+0F+2D", "cvtsd2si", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm_m64
      }, "Convert Scalar Double-FP Value to DW Integer"),
      new EyeStep.OP_INFO("0F+2E", "ucomiss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Unordered Compare Scalar Ordered Single-FP Values and Set EFLAGS"),
      new EyeStep.OP_INFO("66+0F+2E", "ucomisd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Unordered Compare Scalar Ordered Double-FP Values and Set EFLAGS"),
      new EyeStep.OP_INFO("0F+2F", "comiss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Compare Scalar Ordered Single-FP Values and Set EFLAGS"),
      new EyeStep.OP_INFO("66+0F+2F", "comisd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Compare Scalar Ordered Double-FP Values and Set EFLAGS"),
      new EyeStep.OP_INFO("0F+30", "wrmsr", new OP_TYPES[0], "Write to Model Specific Register"),
      new EyeStep.OP_INFO("0F+31", "rdtsc", new OP_TYPES[0], "Read Time-Stamp Counter"),
      new EyeStep.OP_INFO("0F+32", "rdmsr", new OP_TYPES[0], "Read from Model Specific Register"),
      new EyeStep.OP_INFO("0F+33", "rdpmc", new OP_TYPES[0], "Read Performance-Monitoring Counters"),
      new EyeStep.OP_INFO("0F+34", "sysenter", new OP_TYPES[0], "Fast System Call"),
      new EyeStep.OP_INFO("0F+35", "sysexit", new OP_TYPES[0], "Fast Return from Fast System Call"),
      new EyeStep.OP_INFO("0F+37", "getsec", new OP_TYPES[0], "GETSEC Leaf Functions"),
      new EyeStep.OP_INFO("0F+38+00", "pshufb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Shuffle Bytes"),
      new EyeStep.OP_INFO("66+0F+38+00", "pshufb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Shuffle Bytes"),
      new EyeStep.OP_INFO("0F+38+01", "phaddw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Horizontal Add"),
      new EyeStep.OP_INFO("66+0F+38+01", "phaddw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Horizontal Add"),
      new EyeStep.OP_INFO("0F+38+02", "phaddd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Horizontal Add"),
      new EyeStep.OP_INFO("66+0F+38+02", "phaddd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Horizontal Add"),
      new EyeStep.OP_INFO("0F+38+03", "phaddsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Horizontal Add and Saturate"),
      new EyeStep.OP_INFO("66+0F+38+03", "phaddsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Horizontal Add and Saturate"),
      new EyeStep.OP_INFO("0F+38+04", "pmaddubsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Multiply and Add Packed Signed and Unsigned Bytes"),
      new EyeStep.OP_INFO("66+0F+38+04", "pmaddubsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply and Add Packed Signed and Unsigned Bytes"),
      new EyeStep.OP_INFO("0F+38+05", "phsubw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Horizontal Subtract"),
      new EyeStep.OP_INFO("66+0F+38+05", "phsubw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Horizontal Subtract"),
      new EyeStep.OP_INFO("0F+38+06", "phsubd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Horizontal Subtract"),
      new EyeStep.OP_INFO("66+0F+38+06", "phsubd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Horizontal Subtract"),
      new EyeStep.OP_INFO("0F+38+07", "phsubsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Horizontal Subtract and Saturate"),
      new EyeStep.OP_INFO("66+0F+38+07", "phsubsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Horizontal Subtract and Saturate"),
      new EyeStep.OP_INFO("0F+38+08", "psignb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed SIGN"),
      new EyeStep.OP_INFO("66+0F+38+08", "psignb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed SIGN"),
      new EyeStep.OP_INFO("0F+38+09", "psignw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed SIGN"),
      new EyeStep.OP_INFO("66+0F+38+09", "psignw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed SIGN"),
      new EyeStep.OP_INFO("0F+38+0A", "psignd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed SIGN"),
      new EyeStep.OP_INFO("66+0F+38+0A", "psignd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed SIGN"),
      new EyeStep.OP_INFO("0F+38+0B", "pmulhrsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Multiply High with Round and Scale"),
      new EyeStep.OP_INFO("66+0F+38+0B", "pmulhrsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Multiply High with Round and Scale"),
      new EyeStep.OP_INFO("66+0F+38+10", "pblendvb", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm0
      }, "Variable Blend Packed Bytes"),
      new EyeStep.OP_INFO("66+0F+38+14", "blendvps", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm0
      }, "Variable Blend Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+38+15", "blendvpd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm0
      }, "Variable Blend Packed Double-FP Values"),
      new EyeStep.OP_INFO("66+0F+38+17", "ptest", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Logical Compare"),
      new EyeStep.OP_INFO("0F+38+1C", "pabsb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Absolute Value"),
      new EyeStep.OP_INFO("66+0F+38+1C", "pabsb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Absolute Value"),
      new EyeStep.OP_INFO("0F+38+1D", "pabsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Absolute Value"),
      new EyeStep.OP_INFO("66+0F+38+1D", "pabsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Absolute Value"),
      new EyeStep.OP_INFO("0F+38+1E", "pabsd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Absolute Value"),
      new EyeStep.OP_INFO("66+0F+38+1E", "pabsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Absolute Value"),
      new EyeStep.OP_INFO("66+0F+38+20", "pmovsxbw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Packed Move with Sign Extend"),
      new EyeStep.OP_INFO("66+0F+38+21", "pmovsxbd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m32
      }, "Packed Move with Sign Extend"),
      new EyeStep.OP_INFO("66+0F+38+22", "pmovsxbq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m16
      }, "Packed Move with Sign Extend"),
      new EyeStep.OP_INFO("66+0F+38+23", "pmovsxbd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Packed Move with Sign Extend"),
      new EyeStep.OP_INFO("66+0F+38+24", "pmovsxbq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m32
      }, "Packed Move with Sign Extend"),
      new EyeStep.OP_INFO("66+0F+38+25", "pmovsxdq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Packed Move with Sign Extend"),
      new EyeStep.OP_INFO("66+0F+38+28", "pmuldq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Signed Dword Integers"),
      new EyeStep.OP_INFO("66+0F+38+29", "pcmpeqq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Qword Data for Equal"),
      new EyeStep.OP_INFO("66+0F+38+2A", "movntdqa", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m128
      }, "Load Double Quadword Non-Temporal Aligned Hint"),
      new EyeStep.OP_INFO("66+0F+38+2B", "packusdw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Pack with Unsigned Saturation"),
      new EyeStep.OP_INFO("66+0F+38+30", "pmovzxbw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Packed Move with Zero Extend"),
      new EyeStep.OP_INFO("66+0F+38+31", "pmovzxbd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m32
      }, "Packed Move with Zero Extend"),
      new EyeStep.OP_INFO("66+0F+38+32", "pmovzxbq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m16
      }, "Packed Move with Zero Extend"),
      new EyeStep.OP_INFO("66+0F+38+33", "pmovzxbd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Packed Move with Zero Extend"),
      new EyeStep.OP_INFO("66+0F+38+34", "pmovzxbq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m32
      }, "Packed Move with Zero Extend"),
      new EyeStep.OP_INFO("66+0F+38+35", "pmovzxbq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64
      }, "Packed Move with Zero Extend"),
      new EyeStep.OP_INFO("66+0F+38+37", "pcmpgtq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Qword Data for Greater Than"),
      new EyeStep.OP_INFO("66+0F+38+38", "pminsb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Minimum of Packed Signed Byte Integers"),
      new EyeStep.OP_INFO("66+0F+38+39", "pminsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Minimum of Packed Signed Dword Integers"),
      new EyeStep.OP_INFO("66+0F+38+3A", "pminuw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Minimum of Packed Unsigned Word Integers"),
      new EyeStep.OP_INFO("66+0F+38+3B", "pminud", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Minimum of Packed Unsigned Dword Integers"),
      new EyeStep.OP_INFO("66+0F+38+3C", "pmaxsb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Maximum of Packed Signed Byte Integers"),
      new EyeStep.OP_INFO("66+0F+38+3D", "pmaxsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Maximum of Packed Signed Dword Integers"),
      new EyeStep.OP_INFO("66+0F+38+3E", "pmaxuw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Maximum of Packed Unsigned Word Integers"),
      new EyeStep.OP_INFO("66+0F+38+3F", "pmaxud", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Maximum of Packed Unsigned Dword Integers"),
      new EyeStep.OP_INFO("66+0F+38+40", "pmulld", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Signed Dword Integers and Store Low Result"),
      new EyeStep.OP_INFO("66+0F+38+41", "phminposuw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Horizontal Word Minimum"),
      new EyeStep.OP_INFO("66+0F+38+80", "invept", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.m128
      }, "Invalidate Translations Derived from EPT"),
      new EyeStep.OP_INFO("66+0F+38+81", "invvpid", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.m128
      }, "Invalidate Translations Based on VPID"),
      new EyeStep.OP_INFO("0F+38+F0", "movbe", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.m16_32
      }, "Move Data After Swapping Bytes"),
      new EyeStep.OP_INFO("F2+0F+38+F0", "crc32", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.r_m8
      }, "Accumulate CRC32 Value"),
      new EyeStep.OP_INFO("0F+38+F1", "movbe", new OP_TYPES[2]
      {
        OP_TYPES.m16_32,
        OP_TYPES.r16_32
      }, "Move Data After Swapping Bytes"),
      new EyeStep.OP_INFO("F2+0F+38+F1", "crc32", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.r_m16_32
      }, "Accumulate CRC32 Value"),
      new EyeStep.OP_INFO("66+0F+3A+08", "roundps", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Round Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+09", "roundpd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Round Packed Double-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+0A", "roundss", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32,
        OP_TYPES.imm8
      }, "Round Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+0B", "roundsd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64,
        OP_TYPES.imm8
      }, "Round Scalar Double-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+0C", "blendps", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Round Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+0D", "blendpd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Round Packed Double-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+0E", "pblendw", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Blend Packed Words"),
      new EyeStep.OP_INFO("0F+3A+0F", "palignr", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Packed Align Right"),
      new EyeStep.OP_INFO("66+0F+3A+0F", "palignr", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.xmm_m128
      }, "Packed Align Right"),
      new EyeStep.OP_INFO("66+0F+3A+14", "pextrb", new OP_TYPES[3]
      {
        OP_TYPES.m8,
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Extract Byte"),
      new EyeStep.OP_INFO("66+0F+3A+15", "pextrw", new OP_TYPES[3]
      {
        OP_TYPES.m16,
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Extract Word"),
      new EyeStep.OP_INFO("66+0F+3A+16", "pextrd", new OP_TYPES[3]
      {
        OP_TYPES.m32,
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Extract Dword/Qword"),
      new EyeStep.OP_INFO("66+0F+3A+17", "extractps", new OP_TYPES[3]
      {
        OP_TYPES.m64,
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Extract Packed Single-FP Value"),
      new EyeStep.OP_INFO("66+0F+3A+20", "pinsrb", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.m8,
        OP_TYPES.imm8
      }, "Insert Byte"),
      new EyeStep.OP_INFO("66+0F+3A+21", "insertps", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.m32,
        OP_TYPES.imm8
      }, "Insert Packed Single-FP Value"),
      new EyeStep.OP_INFO("66+0F+3A+22", "pinsrd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.m64,
        OP_TYPES.imm8
      }, "Insert Dword/Qword"),
      new EyeStep.OP_INFO("66+0F+3A+40", "dpps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Dot Product of Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+41", "dppd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Dot Product of Packed Double-FP Values"),
      new EyeStep.OP_INFO("66+0F+3A+42", "mpsadbw", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Compute Multiple Packed Sums of Absolute Difference"),
      new EyeStep.OP_INFO("66+0F+3A+60", "pcmpestrm", new OP_TYPES[3]
      {
        OP_TYPES.xmm0,
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Compare Explicit Length Strings, Return Mask"),
      new EyeStep.OP_INFO("66+0F+3A+61", "pcmpestri", new OP_TYPES[3]
      {
        OP_TYPES.ECX,
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Compare Explicit Length Strings, Return Index"),
      new EyeStep.OP_INFO("66+0F+3A+62", "pcmpistrm", new OP_TYPES[4]
      {
        OP_TYPES.xmm0,
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Packed Compare Implicit Length Strings, Return Mask"),
      new EyeStep.OP_INFO("66+0F+3A+63", "pcmpistri", new OP_TYPES[4]
      {
        OP_TYPES.ECX,
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Packed Compare Implicit Length Strings, Return Index"),
      new EyeStep.OP_INFO("0F+40", "cmovo", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - overflow (OF=1)"),
      new EyeStep.OP_INFO("0F+41", "cmovno", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - not overflow (OF=0)"),
      new EyeStep.OP_INFO("0F+42", "cmovb", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - below/not above or equal/carry (CF=1)"),
      new EyeStep.OP_INFO("0F+43", "cmovnb", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - onot below/above or equal/not carry (CF=0)"),
      new EyeStep.OP_INFO("0F+44", "cmove", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - zero/equal (ZF=1)"),
      new EyeStep.OP_INFO("0F+45", "cmovne", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - not zero/not equal (ZF=0)"),
      new EyeStep.OP_INFO("0F+46", "cmovbe", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - below or equal/not above (CF=1 OR ZF=1)"),
      new EyeStep.OP_INFO("0F+47", "cmova", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - not below or equal/above (CF=0 AND ZF=0)"),
      new EyeStep.OP_INFO("0F+48", "cmovs", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - sign (SF=1)"),
      new EyeStep.OP_INFO("0F+49", "cmovns", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - not sign (SF=0)"),
      new EyeStep.OP_INFO("0F+4A", "cmovp", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - parity/parity even (PF=1)"),
      new EyeStep.OP_INFO("0F+4B", "cmovnp", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - not parity/parity odd (PF=0)"),
      new EyeStep.OP_INFO("0F+4C", "cmovl", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - less/not greater (SF!=OF)"),
      new EyeStep.OP_INFO("0F+4D", "cmovge", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - not less/greater or equal (SF=OF)"),
      new EyeStep.OP_INFO("0F+4E", "cmovng", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - less or equal/not greater ((ZF=1) OR (SF!=OF))"),
      new EyeStep.OP_INFO("0F+4F", "cmovg", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Conditional Move - not less nor equal/greater ((ZF=0) AND (SF=OF))"),
      new EyeStep.OP_INFO("0F+50", "movmskps", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm
      }, "Extract Packed Single-FP Sign Mask"),
      new EyeStep.OP_INFO("66+0F+50", "movmskpd", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm
      }, "Extract Packed Double-FP Sign Mask"),
      new EyeStep.OP_INFO("66+0F+50", "movmskpd", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm
      }, "Extract Packed Double-FP Sign Mask"),
      new EyeStep.OP_INFO("0F+51", "sqrtps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compute Square Roots of Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+51", "sqrtss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Compute Square Root of Scalar Single-FP Value"),
      new EyeStep.OP_INFO("66+0F+51", "sqrtpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compute Square Roots of Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+51", "sqrtsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Compute Square Root of Scalar Double-FP Value"),
      new EyeStep.OP_INFO("0F+52", "rsqrtps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compute Recipr. of Square Roots of Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+52", "rsqrtss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Compute Recipr. of Square Root of Scalar Single-FP Value"),
      new EyeStep.OP_INFO("0F+53", "rcpps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compute Reciprocals of Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+53", "rcpss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Compute Reciprocal of Scalar Single-FP Values"),
      new EyeStep.OP_INFO("0F+54", "andps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical AND of Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+54", "andpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical AND of Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+55", "andnps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical AND NOT of Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+55", "andnpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical AND NOT of Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+56", "orps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical OR of Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+56", "orpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical OR of Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+57", "xorps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical XOR of Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+57", "xorpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical XOR of Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+58", "addps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+58", "addss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Add Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+58", "addpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+58", "addsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Add Scalar Double-FP Values"),
      new EyeStep.OP_INFO("0F+59", "mulps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+59", "mulss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Multiply Scalar Single-FP Value"),
      new EyeStep.OP_INFO("66+0F+59", "mulpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+59", "addsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Multiply Scalar Double-FP Values"),
      new EyeStep.OP_INFO("0F+5A", "cvtps2pd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert Packed Single-FP Values to Double-FP Values"),
      new EyeStep.OP_INFO("F3+0F+5A", "cvtpd2ps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert Packed Double-FP Values to Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+5A", "cvtss2sd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Convert Scalar Single-FP Value to Scalar Double-FP Value"),
      new EyeStep.OP_INFO("F2+0F+5A", "cvtsd2ss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Convert Scalar Double-FP Value to Scalar Single-FP Value"),
      new EyeStep.OP_INFO("0F+5B", "cvtdq2ps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert Packed DW Integers to Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+5B", "cvtps2dq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert Packed Single-FP Values to DW Integers"),
      new EyeStep.OP_INFO("F3+0F+5B", "cvttps2dq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert with Trunc. Packed Single-FP Values to DW Integers"),
      new EyeStep.OP_INFO("0F+5C", "subps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+5C", "subss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Subtract Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+5C", "subpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+5C", "subsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Subtract Scalar Double-FP Values"),
      new EyeStep.OP_INFO("0F+5D", "minps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Return Minimum Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+5D", "minss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Return Minimum Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+5D", "minpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Return Minimum Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+5D", "minsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Return Minimum Scalar Double-FP Values"),
      new EyeStep.OP_INFO("0F+5E", "divps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Divide Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+5E", "divss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Divide Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+5E", "divpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Divide Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+5E", "divsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Divide Scalar Double-FP Values"),
      new EyeStep.OP_INFO("0F+5F", "maxps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Return Maximum Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+5F", "maxss", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32
      }, "Return Maximum Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+5F", "maxpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Return Maximum Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+5F", "maxsd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Return Maximum Scalar Double-FP Values"),
      new EyeStep.OP_INFO("0F+60", "punpcklbw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Unpack Low Data"),
      new EyeStep.OP_INFO("66+0F+60", "punpcklbw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack Low Data"),
      new EyeStep.OP_INFO("0F+61", "punpcklbd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Unpack Low Data"),
      new EyeStep.OP_INFO("66+0F+61", "punpcklbd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack Low Data"),
      new EyeStep.OP_INFO("0F+62", "punpcklbq", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Unpack Low Data"),
      new EyeStep.OP_INFO("66+0F+62", "punpcklbq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack Low Data"),
      new EyeStep.OP_INFO("0F+63", "packsswb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Pack with Signed Saturation"),
      new EyeStep.OP_INFO("66+0F+63", "packsswb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Pack with Signed Saturation"),
      new EyeStep.OP_INFO("0F+64", "pcmpgtb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Compare Packed Signed Integers for Greater Than"),
      new EyeStep.OP_INFO("66+0F+64", "pcmpgtb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Signed Integers for Greater Than"),
      new EyeStep.OP_INFO("0F+65", "pcmpgtw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Compare Packed Signed Integers for Greater Than"),
      new EyeStep.OP_INFO("66+0F+65", "pcmpgtw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Signed Integers for Greater Than"),
      new EyeStep.OP_INFO("0F+66", "pcmpgtd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Compare Packed Signed Integers for Greater Than"),
      new EyeStep.OP_INFO("66+0F+66", "pcmpgtd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Signed Integers for Greater Than"),
      new EyeStep.OP_INFO("0F+67", "packuswb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Pack with Unsigned Saturation"),
      new EyeStep.OP_INFO("66+0F+67", "packuswb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Pack with Unsigned Saturation"),
      new EyeStep.OP_INFO("0F+68", "punpckhbw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Unpack High Data"),
      new EyeStep.OP_INFO("66+0F+68", "punpckhbw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack High Data"),
      new EyeStep.OP_INFO("0F+69", "punpckhwd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Unpack High Data"),
      new EyeStep.OP_INFO("66+0F+69", "punpckhwd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack High Data"),
      new EyeStep.OP_INFO("0F+6A", "punpckhdq", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Unpack High Data"),
      new EyeStep.OP_INFO("66+0F+6A", "punpckhdq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack High Data"),
      new EyeStep.OP_INFO("0F+6B", "packssdw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Pack with Signed Saturation"),
      new EyeStep.OP_INFO("66+0F+6B", "packssdw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Pack with Signed Saturation"),
      new EyeStep.OP_INFO("66+0F+6C", "punpcklqdq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack Low Data"),
      new EyeStep.OP_INFO("66+0F+6D", "punpckhqdq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Unpack High Data"),
      new EyeStep.OP_INFO("0F+6E", "movd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.r_m32
      }, "Move Doubleword"),
      new EyeStep.OP_INFO("66+0F+6E", "movd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.r_m32
      }, "Move Doubleword"),
      new EyeStep.OP_INFO("0F+6F", "movq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.mm_m64
      }, "Move Quadword"),
      new EyeStep.OP_INFO("66+0F+6F", "movdqa", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Move Aligned Double Quadword"),
      new EyeStep.OP_INFO("F3+0F+6F", "movdqu", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Move Unaligned Double Quadword"),
      new EyeStep.OP_INFO("0F+70", "pshufw", new OP_TYPES[2]
      {
        OP_TYPES.mm_m64,
        OP_TYPES.imm8
      }, "Shuffle Packed Words"),
      new EyeStep.OP_INFO("F3+0F+70", "pshuflw", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Shuffle Packed Low Words"),
      new EyeStep.OP_INFO("66+0F+70", "pshufhw", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Shuffle Packed High Words"),
      new EyeStep.OP_INFO("F2+0F+70", "pshufd", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Shuffle Packed Doublewords"),
      new EyeStep.OP_INFO("0F+71+m2", "psrlw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("66+0F+71+m2", "psrlw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("0F+71+m4", "psraw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("66+0F+71+m4", "psraw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("0F+71+m6", "psllw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("66+0F+71+m6", "psllw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("0F+72+m2", "psrld", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Double Quadword Right Logical"),
      new EyeStep.OP_INFO("66+0F+72+m2", "psrld", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Double Quadword Right Logical"),
      new EyeStep.OP_INFO("0F+72+m4", "psrad", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("66+0F+72+m4", "psrad", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("0F+72+m6", "pslld", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("66+0F+72+m6", "pslld", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("0F+73+m2", "psrld", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("66+0F+73+m2", "psrld", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("0F+73+m3", "psrad", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Double Quadword Right Logical"),
      new EyeStep.OP_INFO("66+0F+73+m6", "psrad", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("0F+73+m6", "pslld", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("66+0F+73+m7", "pslld", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Shift Double Quadword Left Logical"),
      new EyeStep.OP_INFO("0F+74", "pcmpeqb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Compare Packed Data for Equal"),
      new EyeStep.OP_INFO("66+0F+74", "pcmpeqb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Data for Equal"),
      new EyeStep.OP_INFO("0F+75", "pcmpeqw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Compare Packed Data for Equal"),
      new EyeStep.OP_INFO("66+0F+75", "pcmpeqw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Data for Equal"),
      new EyeStep.OP_INFO("0F+76", "pcmpeqd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Compare Packed Data for Equal"),
      new EyeStep.OP_INFO("66+0F+76", "pcmpeqd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compare Packed Data for Equal"),
      new EyeStep.OP_INFO("0F+77", "emms", new OP_TYPES[0], "Empty MMX Technology State"),
      new EyeStep.OP_INFO("0F+78", "vmread", new OP_TYPES[0], "Read Field from Virtual-Machine Control Structure"),
      new EyeStep.OP_INFO("0F+79", "vmwrite", new OP_TYPES[0], "Write Field to Virtual-Machine Control Structure"),
      new EyeStep.OP_INFO("66+0F+7C", "haddpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Double-FP Horizontal Add"),
      new EyeStep.OP_INFO("F2+0F+7C", "haddps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Single-FP Horizontal Add"),
      new EyeStep.OP_INFO("66+0F+7D", "hsubpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Double-FP Horizontal Subtract"),
      new EyeStep.OP_INFO("F2+0F+7D", "hsubps", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Single-FP Horizontal Subtract"),
      new EyeStep.OP_INFO("0F+7E", "movd", new OP_TYPES[2]
      {
        OP_TYPES.r_m32,
        OP_TYPES.mm
      }, "Move Doubleword"),
      new EyeStep.OP_INFO("66+0F+7E", "movd", new OP_TYPES[2]
      {
        OP_TYPES.r_m32,
        OP_TYPES.xmm
      }, "Move Doubleword"),
      new EyeStep.OP_INFO("F3+0F+7E", "movq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64
      }, "Move Quadword"),
      new EyeStep.OP_INFO("0F+7F", "movq", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m64,
        OP_TYPES.mm
      }, "Move Quadword"),
      new EyeStep.OP_INFO("66+0F+7F", "movdqa", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm
      }, "Move Aligned Double Quadword"),
      new EyeStep.OP_INFO("F3+0F+7F", "movdqu", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m128,
        OP_TYPES.xmm
      }, "Move Unaligned Double Quadword"),
      new EyeStep.OP_INFO("0F+80", "long jo", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if overflow (OF=1)"),
      new EyeStep.OP_INFO("0F+81", "long jno", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not overflow (OF=0)"),
      new EyeStep.OP_INFO("0F+82", "long jb", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if below/not above or equal/carry (CF=1)"),
      new EyeStep.OP_INFO("0F+83", "long jnb", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not below/above or equal/not carry (CF=0)"),
      new EyeStep.OP_INFO("0F+84", "long je", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if zero/equal (ZF=1)"),
      new EyeStep.OP_INFO("0F+85", "long jne", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not zero/not equal (ZF=0)"),
      new EyeStep.OP_INFO("0F+86", "long jna", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if below or equal/not above (CF=1 OR ZF=1)"),
      new EyeStep.OP_INFO("0F+87", "long ja", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not below or equal/above (CF=0 AND ZF=0)"),
      new EyeStep.OP_INFO("0F+88", "long js", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if sign (SF=1)"),
      new EyeStep.OP_INFO("0F+89", "long jns", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not sign (SF=0)"),
      new EyeStep.OP_INFO("0F+8A", "long jp", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if parity/parity even (PF=1)"),
      new EyeStep.OP_INFO("0F+8B", "long jnp", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not parity/parity odd (PF=0)"),
      new EyeStep.OP_INFO("0F+8C", "long jl", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if less/not greater (SF!=OF)"),
      new EyeStep.OP_INFO("0F+8D", "long jnl", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not less/greater or equal (SF=OF)"),
      new EyeStep.OP_INFO("0F+8E", "long jng", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if less or equal/not greater ((ZF=1) OR (SF!=OF))"),
      new EyeStep.OP_INFO("0F+8F", "long jg", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump far if not less nor equal/greater ((ZF=0) AND (SF=OF))"),
      new EyeStep.OP_INFO("0F+90", "seto", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - overflow (OF=1)"),
      new EyeStep.OP_INFO("0F+91", "setno", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not overflow (OF=0)"),
      new EyeStep.OP_INFO("0F+92", "setb", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - below/not above or equal/carry (CF=1)"),
      new EyeStep.OP_INFO("0F+93", "setnb", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not below/above or equal/not carry (CF=0)"),
      new EyeStep.OP_INFO("0F+94", "sete", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - zero/equal (ZF=1)"),
      new EyeStep.OP_INFO("0F+95", "setne", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not zero/not equal (ZF=0)"),
      new EyeStep.OP_INFO("0F+96", "setna", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - below or equal/not above (CF=1 OR ZF=1)"),
      new EyeStep.OP_INFO("0F+97", "seta", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not below or equal/above (CF=0 AND ZF=0)"),
      new EyeStep.OP_INFO("0F+98", "sets", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - sign (SF=1)"),
      new EyeStep.OP_INFO("0F+99", "setns", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not sign (SF=0)"),
      new EyeStep.OP_INFO("0F+9A", "setp", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - parity/parity even (PF=1)"),
      new EyeStep.OP_INFO("0F+9B", "setnp", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not parity/parity odd (PF=0)"),
      new EyeStep.OP_INFO("0F+9C", "setl", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - less/not greater (SF!=OF)"),
      new EyeStep.OP_INFO("0F+9D", "setnl", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not less/greater or equal (SF=OF)"),
      new EyeStep.OP_INFO("0F+9E", "setng", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - less or equal/not greater ((ZF=1) OR (SF!=OF))"),
      new EyeStep.OP_INFO("0F+9F", "setg", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Set Byte on Condition - not less nor equal/greater ((ZF=0) AND (SF=OF))"),
      new EyeStep.OP_INFO("0F+A0", "push", new OP_TYPES[1]
      {
        OP_TYPES.FS
      }, "Push Word, Doubleword or Quadword Onto the Stack"),
      new EyeStep.OP_INFO("0F+A1", "pop", new OP_TYPES[1]
      {
        OP_TYPES.FS
      }, "Pop a Value from the Stack"),
      new EyeStep.OP_INFO("0F+A2", "cpuid", new OP_TYPES[1]
      {
        OP_TYPES.IA32_BIOS
      }, "CPU Identification"),
      new EyeStep.OP_INFO("0F+A3", "bt", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Bit Test"),
      new EyeStep.OP_INFO("0F+A4", "shld", new OP_TYPES[3]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32,
        OP_TYPES.imm8
      }, "Double Precision Shift Left"),
      new EyeStep.OP_INFO("0F+A5", "shld", new OP_TYPES[3]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32,
        OP_TYPES.CL
      }, "Double Precision Shift Left"),
      new EyeStep.OP_INFO("0F+A8", "push", new OP_TYPES[1]
      {
        OP_TYPES.GS
      }, "Push Word, Doubleword or Quadword Onto the Stack"),
      new EyeStep.OP_INFO("0F+A9", "pop", new OP_TYPES[1]
      {
        OP_TYPES.GS
      }, "Pop a Value from the Stack"),
      new EyeStep.OP_INFO("0F+AA", "rsm", new OP_TYPES[0], "Resume from System Management Mode"),
      new EyeStep.OP_INFO("0F+AB", "bts", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Bit Test and Set"),
      new EyeStep.OP_INFO("0F+AC", "shrd", new OP_TYPES[3]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32,
        OP_TYPES.imm8
      }, "Double Precision Shift Right"),
      new EyeStep.OP_INFO("0F+AD", "shrd", new OP_TYPES[3]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32,
        OP_TYPES.CL
      }, "Double Precision Shift Right"),
      new EyeStep.OP_INFO("0F+AE+m0", "fxsave", new OP_TYPES[3]
      {
        OP_TYPES.m512,
        OP_TYPES.ST,
        OP_TYPES.ST1
      }, "Save x87 FPU, MMX, XMM, and MXCSR State"),
      new EyeStep.OP_INFO("0F+AE+m1", "fxrstor", new OP_TYPES[3]
      {
        OP_TYPES.ST,
        OP_TYPES.ST1,
        OP_TYPES.ST2
      }, "Restore x87 FPU, MMX, XMM, and MXCSR State"),
      new EyeStep.OP_INFO("0F+AE+m2", "ldmxcsr", new OP_TYPES[1]
      {
        OP_TYPES.m32
      }, "Load MXCSR Register"),
      new EyeStep.OP_INFO("0F+AE+m3", "stmxcsr", new OP_TYPES[1]
      {
        OP_TYPES.m32
      }, "Store MXCSR Register State"),
      new EyeStep.OP_INFO("0F+AE+m4", "xsave", new OP_TYPES[3]
      {
        OP_TYPES.m,
        OP_TYPES.EDX,
        OP_TYPES.EAX
      }, "Save Processor Extended States"),
      new EyeStep.OP_INFO("0F+AE+m5", "lfence", new OP_TYPES[0], "Load Fence"),
      new EyeStep.OP_INFO("0F+AE+m5", "xrstor", new OP_TYPES[3]
      {
        OP_TYPES.ST,
        OP_TYPES.ST1,
        OP_TYPES.ST2
      }, "Restore Processor Extended States"),
      new EyeStep.OP_INFO("0F+AE+m6", "mfence", new OP_TYPES[0], "Memory Fence"),
      new EyeStep.OP_INFO("0F+AE+m7", "sfence", new OP_TYPES[0], "Store Fence"),
      new EyeStep.OP_INFO("0F+AE+m7", "clflush", new OP_TYPES[1]
      {
        OP_TYPES.m8
      }, "Flush Cache Line"),
      new EyeStep.OP_INFO("0F+AF", "imul", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Signed Multiply"),
      new EyeStep.OP_INFO("0F+B0", "cmpxchg", new OP_TYPES[3]
      {
        OP_TYPES.r_m8,
        OP_TYPES.AL,
        OP_TYPES.r8
      }, "Compare and Exchange"),
      new EyeStep.OP_INFO("0F+B1", "cmpxchg", new OP_TYPES[3]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.EAX,
        OP_TYPES.r16_32
      }, "Compare and Exchange"),
      new EyeStep.OP_INFO("0F+B2", "lss", new OP_TYPES[3]
      {
        OP_TYPES.SS,
        OP_TYPES.r16_32,
        OP_TYPES.m16_32_and_16_32
      }, "Load Far Pointer"),
      new EyeStep.OP_INFO("0F+B3", "btr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Bit Test and Reset"),
      new EyeStep.OP_INFO("0F+B4", "lfs", new OP_TYPES[3]
      {
        OP_TYPES.FS,
        OP_TYPES.r_m16_32,
        OP_TYPES.m16_32_and_16_32
      }, "Load Far Pointer"),
      new EyeStep.OP_INFO("0F+B5", "lgs", new OP_TYPES[3]
      {
        OP_TYPES.GS,
        OP_TYPES.r_m16_32,
        OP_TYPES.m16_32_and_16_32
      }, "Load Far Pointer"),
      new EyeStep.OP_INFO("0F+B6", "movzx", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m8
      }, "Move with Zero-Extend"),
      new EyeStep.OP_INFO("0F+B7", "movzx", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16
      }, "Move with Zero-Extend"),
      new EyeStep.OP_INFO("F3+0F+B8", "popcnt", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Bit Population Count"),
      new EyeStep.OP_INFO("0F+B9", "ud", new OP_TYPES[0], "Undefined Instruction"),
      new EyeStep.OP_INFO("0F+BA+m4", "bt", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Bit Test"),
      new EyeStep.OP_INFO("0F+BA+m5", "bts", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Bit Test and Set"),
      new EyeStep.OP_INFO("0F+BA+m6", "btr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Bit Test and Reset"),
      new EyeStep.OP_INFO("0F+BA+m7", "btc", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Bit Test and Complement"),
      new EyeStep.OP_INFO("0F+BB", "btc", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Bit Test and Complement"),
      new EyeStep.OP_INFO("0F+BC", "bsf", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Bit Scan Forward"),
      new EyeStep.OP_INFO("0F+BD", "bsr", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Bit Scan Reverse"),
      new EyeStep.OP_INFO("0F+BE", "movsx", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m8
      }, "Move with Sign-Extension"),
      new EyeStep.OP_INFO("0F+BF", "movsx", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16
      }, "Move with Sign-Extension"),
      new EyeStep.OP_INFO("0F+C0", "xadd", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Exchange and Add"),
      new EyeStep.OP_INFO("0F+C1", "xadd", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Exchange and Add"),
      new EyeStep.OP_INFO("0F+C2", "cmpps", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Compare Packed Single-FP Values"),
      new EyeStep.OP_INFO("F3+0F+C2", "cmpss", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m32,
        OP_TYPES.imm8
      }, "Compare Scalar Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+C2", "cmppd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Compare Packed Double-FP Values"),
      new EyeStep.OP_INFO("F2+0F+C2", "cmpsd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m64,
        OP_TYPES.imm8
      }, "Compare Scalar Double-FP Values"),
      new EyeStep.OP_INFO("0F+C3", "movnti", new OP_TYPES[2]
      {
        OP_TYPES.m32,
        OP_TYPES.r32
      }, "Store Doubleword Using Non-Temporal Hint"),
      new EyeStep.OP_INFO("0F+C4", "pinsrw", new OP_TYPES[3]
      {
        OP_TYPES.mm,
        OP_TYPES.m16,
        OP_TYPES.imm8
      }, "Insert Word"),
      new EyeStep.OP_INFO("66+0F+C4", "pinsrw", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.m16,
        OP_TYPES.imm8
      }, "Insert Word"),
      new EyeStep.OP_INFO("0F+C5", "pextrw", new OP_TYPES[3]
      {
        OP_TYPES.r32,
        OP_TYPES.mm,
        OP_TYPES.imm8
      }, "Extract Word"),
      new EyeStep.OP_INFO("66+0F+C5", "pextrw", new OP_TYPES[3]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm,
        OP_TYPES.imm8
      }, "Extract Word"),
      new EyeStep.OP_INFO("0F+C6", "shufps", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Shuffle Packed Single-FP Values"),
      new EyeStep.OP_INFO("66+0F+C6", "shufpd", new OP_TYPES[3]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128,
        OP_TYPES.imm8
      }, "Shuffle Packed Double-FP Values"),
      new EyeStep.OP_INFO("0F+C7+m1", "cmpxchg8b", new OP_TYPES[3]
      {
        OP_TYPES.m64,
        OP_TYPES.EAX,
        OP_TYPES.EDX
      }, "Compare and Exchange Bytes"),
      new EyeStep.OP_INFO("0F+C7+m6", "vmptrld", new OP_TYPES[1]
      {
        OP_TYPES.m64
      }, "Load Pointer to Virtual-Machine Control Structure"),
      new EyeStep.OP_INFO("66+0F+C7+m6", "vmclean", new OP_TYPES[1]
      {
        OP_TYPES.m64
      }, "Clear Virtual-Machine Control Structure"),
      new EyeStep.OP_INFO("F3+0F+C7+m6", "vmxon", new OP_TYPES[1]
      {
        OP_TYPES.m64
      }, "Enter VMX Operation"),
      new EyeStep.OP_INFO("0F+C7+m7", "vmptrst", new OP_TYPES[1]
      {
        OP_TYPES.m64
      }, "Store Pointer to Virtual-Machine Control Structure"),
      new EyeStep.OP_INFO("0F+C8+r", "bswap", new OP_TYPES[1]
      {
        OP_TYPES.r16_32
      }, "Byte Swap"),
      new EyeStep.OP_INFO("66+0F+D0", "addsubpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Double-FP Add/Subtract"),
      new EyeStep.OP_INFO("F2+0F+D0", "addsubpd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Packed Single-FP Add/Subtract"),
      new EyeStep.OP_INFO("0F+D1", "psrlw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("66+0F+D1", "psrlw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("0F+D2", "psrld", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("66+0F+D2", "psrld", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("0F+D3", "psrlq", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("66+0F+D3", "psrlq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Right Logical"),
      new EyeStep.OP_INFO("0F+D4", "paddq", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Quadword Integers"),
      new EyeStep.OP_INFO("66+0F+D4", "paddq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Quadword Integers"),
      new EyeStep.OP_INFO("0F+D5", "pmullw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Multiply Packed Signed Integers and Store Low Result"),
      new EyeStep.OP_INFO("66+0F+D5", "pmullw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Signed Integers and Store Low Result"),
      new EyeStep.OP_INFO("66+0F+D6", "movq", new OP_TYPES[2]
      {
        OP_TYPES.xmm_m64,
        OP_TYPES.xmm
      }, "Move Quadword"),
      new EyeStep.OP_INFO("F3+0F+D6", "movq2dq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.mm
      }, "Move Quadword from MMX Technology to XMM Register"),
      new EyeStep.OP_INFO("F2+0F+D6", "movdq2q", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.xmm
      }, "Move Quadword from XMM to MMX Technology Register"),
      new EyeStep.OP_INFO("0F+D7", "pmovmskb", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.mm
      }, "Move Byte Mask"),
      new EyeStep.OP_INFO("66+0F+D7", "pmovmskb", new OP_TYPES[2]
      {
        OP_TYPES.r32,
        OP_TYPES.xmm
      }, "Move Byte Mask"),
      new EyeStep.OP_INFO("0F+D8", "psubusb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("66+0F+D8", "psubusb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("0F+D9", "psubusw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("66+0F+D9", "psubusw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("0F+DA", "pminub", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Minimum of Packed Unsigned Byte Integers"),
      new EyeStep.OP_INFO("66+0F+DA", "pminub", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Minimum of Packed Unsigned Byte Integers"),
      new EyeStep.OP_INFO("0F+DB", "pand", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Logical AND"),
      new EyeStep.OP_INFO("66+0F+DB", "pand", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Logical AND"),
      new EyeStep.OP_INFO("0F+DC", "paddusb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("66+0F+DC", "paddusb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("0F+DD", "paddusw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("66+0F+DD", "paddusw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Unsigned Integers with Unsigned Saturation"),
      new EyeStep.OP_INFO("0F+DE", "pmaxub", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Maximum of Packed Unsigned Byte Integers"),
      new EyeStep.OP_INFO("66+0F+DE", "pmaxub", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Maximum of Packed Unsigned Byte Integers"),
      new EyeStep.OP_INFO("0F+DF", "pandn", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Logical AND NOT"),
      new EyeStep.OP_INFO("66+0F+DF", "pandn", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Logical AND NOT"),
      new EyeStep.OP_INFO("0F+E0", "pavgb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Average Packed Integers"),
      new EyeStep.OP_INFO("66+0F+E0", "pavgb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Average Packed Integers"),
      new EyeStep.OP_INFO("0F+E1", "psraw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("66+0F+E1", "psraw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("0F+E2", "psrad", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("66+0F+E2", "psrad", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Right Arithmetic"),
      new EyeStep.OP_INFO("0F+E3", "pavgw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Average Packed Integers"),
      new EyeStep.OP_INFO("66+0F+E3", "pavgw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Average Packed Integers"),
      new EyeStep.OP_INFO("0F+E4", "pmulhuw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Multiply Packed Unsigned Integers and Store High Result"),
      new EyeStep.OP_INFO("66+0F+E4", "pmulhuw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Unsigned Integers and Store High Result"),
      new EyeStep.OP_INFO("0F+E5", "pmulhw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Multiply Packed Signed Integers and Store High Result"),
      new EyeStep.OP_INFO("66+0F+E5", "pmulhw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Signed Integers and Store High Result"),
      new EyeStep.OP_INFO("F2+0F+E6", "cvtpd2dq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert Packed Double-FP Values to DW Integers"),
      new EyeStep.OP_INFO("66+0F+E6", "cvttpd2dq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert with Trunc. Packed Double-FP Values to DW Integers"),
      new EyeStep.OP_INFO("F3+0F+E6", "cvtdq2pd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Convert Packed DW Integers to Double-FP Values"),
      new EyeStep.OP_INFO("0F+E7", "movntq", new OP_TYPES[2]
      {
        OP_TYPES.m64,
        OP_TYPES.mm
      }, "Store of Quadword Using Non-Temporal Hint"),
      new EyeStep.OP_INFO("66+0F+E7", "movntdq", new OP_TYPES[2]
      {
        OP_TYPES.m128,
        OP_TYPES.xmm
      }, "Store Double Quadword Using Non-Temporal Hint"),
      new EyeStep.OP_INFO("0F+E8", "psubsb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("66+0F+E8", "psubsb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("0F+E9", "psubsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("66+0F+E9", "psubsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("0F+EA", "pminsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Minimum of Packed Signed Word Integers"),
      new EyeStep.OP_INFO("66+0F+EA", "pminsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Minimum of Packed Signed Word Integers"),
      new EyeStep.OP_INFO("0F+EB", "por", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Bitwise Logical OR"),
      new EyeStep.OP_INFO("66+0F+EB", "por", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Bitwise Logical OR"),
      new EyeStep.OP_INFO("0F+EC", "paddsb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("66+0F+EC", "paddsb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("0F+ED", "paddsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("66+0F+ED", "paddsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Signed Integers with Signed Saturation"),
      new EyeStep.OP_INFO("0F+EE", "pmaxsw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Maximum of Packed Signed Word Integers"),
      new EyeStep.OP_INFO("66+0F+EE", "pmaxsw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Maximum of Packed Signed Word Integers"),
      new EyeStep.OP_INFO("0F+EF", "pxor", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("66+0F+EF", "pxor", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("F2+0F+F0", "lddqu", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.m128
      }, "Load Unaligned Integer 128 Bits"),
      new EyeStep.OP_INFO("0F+F1", "psllw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("66+0F+F1", "psllw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("0F+F2", "pslld", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("66+0F+F2", "pslld", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("0F+F3", "psllq", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("66+0F+F3", "psllq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Shift Packed Data Left Logical"),
      new EyeStep.OP_INFO("0F+F4", "pmuludq", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Multiply Packed Unsigned DW Integers"),
      new EyeStep.OP_INFO("66+0F+F4", "pmuludq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply Packed Unsigned DW Integers"),
      new EyeStep.OP_INFO("0F+F5", "pmaddwd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Multiply and Add Packed Integers"),
      new EyeStep.OP_INFO("66+0F+F5", "pmaddwd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Multiply and Add Packed Integers"),
      new EyeStep.OP_INFO("0F+F6", "psadbw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Compute Sum of Absolute Differences"),
      new EyeStep.OP_INFO("66+0F+F6", "psadbw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Compute Sum of Absolute Differences"),
      new EyeStep.OP_INFO("0F+F7", "maskmovq", new OP_TYPES[3]
      {
        OP_TYPES.m64,
        OP_TYPES.mm,
        OP_TYPES.mm
      }, "Store Selected Bytes of Quadword"),
      new EyeStep.OP_INFO("66+0F+F7", "maskmovdqu", new OP_TYPES[3]
      {
        OP_TYPES.m128,
        OP_TYPES.xmm,
        OP_TYPES.xmm
      }, "Store Selected Bytes of Double Quadword"),
      new EyeStep.OP_INFO("0F+F8", "psubb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Integers"),
      new EyeStep.OP_INFO("66+0F+F8", "psubb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Integers"),
      new EyeStep.OP_INFO("0F+F9", "psubw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Integers"),
      new EyeStep.OP_INFO("66+0F+F9", "psubw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Integers"),
      new EyeStep.OP_INFO("0F+FA", "psubd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Integers"),
      new EyeStep.OP_INFO("66+0F+FA", "psubd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Integers"),
      new EyeStep.OP_INFO("0F+FB", "psubq", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Subtract Packed Quadword Integers"),
      new EyeStep.OP_INFO("66+0F+FB", "psubq", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Subtract Packed Quadword Integers"),
      new EyeStep.OP_INFO("0F+FC", "paddb", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Integers"),
      new EyeStep.OP_INFO("66+0F+FC", "paddb", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Integers"),
      new EyeStep.OP_INFO("0F+FD", "paddw", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Integers"),
      new EyeStep.OP_INFO("66+0F+FD", "paddw", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Integers"),
      new EyeStep.OP_INFO("0F+FE", "paddd", new OP_TYPES[2]
      {
        OP_TYPES.mm,
        OP_TYPES.mm_m64
      }, "Add Packed Integers"),
      new EyeStep.OP_INFO("66+0F+FE", "paddd", new OP_TYPES[2]
      {
        OP_TYPES.xmm,
        OP_TYPES.xmm_m128
      }, "Add Packed Integers"),
      new EyeStep.OP_INFO("10", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Add with Carry"),
      new EyeStep.OP_INFO("11", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Add with Carry"),
      new EyeStep.OP_INFO("12", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Add with Carry"),
      new EyeStep.OP_INFO("13", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Add with Carry"),
      new EyeStep.OP_INFO("14", "adc", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Add with Carry"),
      new EyeStep.OP_INFO("15", "adc", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Add with Carry"),
      new EyeStep.OP_INFO("16", "push", new OP_TYPES[1]
      {
        OP_TYPES.SS
      }, "Push Stack Segment onto the stack"),
      new EyeStep.OP_INFO("17", "pop", new OP_TYPES[1]
      {
        OP_TYPES.SS
      }, "Pop Stack Segment off of the stack"),
      new EyeStep.OP_INFO("18", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("19", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("1A", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("1B", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("1C", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("1D", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("1E", "push", new OP_TYPES[1]
      {
        OP_TYPES.DS
      }, "Push Data Segment onto the stack"),
      new EyeStep.OP_INFO("1F", "pop", new OP_TYPES[1]
      {
        OP_TYPES.DS
      }, "Pop Data Segment off of the stack"),
      new EyeStep.OP_INFO("20", "and", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Logical AND"),
      new EyeStep.OP_INFO("21", "and", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Logical AND"),
      new EyeStep.OP_INFO("22", "and", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Logical AND"),
      new EyeStep.OP_INFO("23", "and", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Logical AND"),
      new EyeStep.OP_INFO("24", "and", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Logical AND"),
      new EyeStep.OP_INFO("25", "and", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Logical AND"),
      new EyeStep.OP_INFO("27", "daa", new OP_TYPES[1], "Decimal Adjust AL after Addition"),
      new EyeStep.OP_INFO("28", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Subtract"),
      new EyeStep.OP_INFO("29", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Subtract"),
      new EyeStep.OP_INFO("2A", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Subtract"),
      new EyeStep.OP_INFO("2B", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Subtract"),
      new EyeStep.OP_INFO("2C", "sub", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Subtract"),
      new EyeStep.OP_INFO("2D", "sub", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Subtract"),
      new EyeStep.OP_INFO("2F", "das", new OP_TYPES[1], "Decimal Adjust AL after Subtraction"),
      new EyeStep.OP_INFO("30", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("31", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("32", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("33", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("34", "xor", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("35", "xor", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("37", "aaa", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.AH
      }, "ASCII Adjust After Addition"),
      new EyeStep.OP_INFO("38", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("39", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("3A", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("3B", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("3C", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("3D", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("3F", "aas", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.AH
      }, "ASCII Adjust AL After Subtraction"),
      new EyeStep.OP_INFO("40+r", "inc", new OP_TYPES[1]
      {
        OP_TYPES.r16_32
      }, "Increment by 1"),
      new EyeStep.OP_INFO("48+r", "dec", new OP_TYPES[1]
      {
        OP_TYPES.r16_32
      }, "Decrement by 1"),
      new EyeStep.OP_INFO("50+r", "push", new OP_TYPES[1]
      {
        OP_TYPES.r16_32
      }, "Push Word, Doubleword or Quadword Onto the Stack"),
      new EyeStep.OP_INFO("58+r", "pop", new OP_TYPES[1]
      {
        OP_TYPES.r16_32
      }, "Pop a Value from the Stack"),
      new EyeStep.OP_INFO("60", "pushad", new OP_TYPES[0], "Push All General-Purpose Registers"),
      new EyeStep.OP_INFO("61", "popad", new OP_TYPES[0], "Pop All General-Purpose Registers"),
      new EyeStep.OP_INFO("62", "bound", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.m16_32_and_16_32
      }, "Check Array Index Against Bounds"),
      new EyeStep.OP_INFO("63", "arpl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16,
        OP_TYPES.r16
      }, "Adjust RPL Field of Segment Selector"),
      new EyeStep.OP_INFO("63", "arpl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16,
        OP_TYPES.r16
      }, "Adjust RPL Field of Segment Selector"),
      new EyeStep.OP_INFO("68", "push", new OP_TYPES[1]
      {
        OP_TYPES.imm16_32
      }, "Push Word, Doubleword or Quadword Onto the Stack"),
      new EyeStep.OP_INFO("69", "imul", new OP_TYPES[3]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Signed Multiply"),
      new EyeStep.OP_INFO("6A", "push", new OP_TYPES[1]
      {
        OP_TYPES.imm8
      }, "Push Word, Doubleword or Quadword Onto the Stack"),
      new EyeStep.OP_INFO("6B", "imul", new OP_TYPES[3]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Signed Multiply"),
      new EyeStep.OP_INFO("6C", "insb", new OP_TYPES[0], "Input from Port to String"),
      new EyeStep.OP_INFO("6D", "insd", new OP_TYPES[0], "Input from Port to String"),
      new EyeStep.OP_INFO("6E", "outsb", new OP_TYPES[0], "Output String to Port"),
      new EyeStep.OP_INFO("6F", "outsd", new OP_TYPES[0], "Output String to Port"),
      new EyeStep.OP_INFO("70", "jo short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if overflow (OF=1)"),
      new EyeStep.OP_INFO("71", "jno short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not overflow (OF=0))"),
      new EyeStep.OP_INFO("72", "jb short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if below/not above or equal/carry (CF=1)"),
      new EyeStep.OP_INFO("73", "jae short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not below/above or equal/not carry (CF=0))"),
      new EyeStep.OP_INFO("74", "je short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if zero/equal (ZF=1)"),
      new EyeStep.OP_INFO("75", "jne short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not zero/not equal (ZF=0)"),
      new EyeStep.OP_INFO("76", "jna short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if below or equal/not above (CF=1 OR ZF=1)"),
      new EyeStep.OP_INFO("77", "ja short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not below or equal/above (CF=0 AND ZF=0)"),
      new EyeStep.OP_INFO("78", "js short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if sign (SF=1)"),
      new EyeStep.OP_INFO("79", "jns short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not sign (SF=0)"),
      new EyeStep.OP_INFO("7A", "jp short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if parity/parity even (PF=1)"),
      new EyeStep.OP_INFO("7B", "jnp short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not parity/parity odd (PF=0)"),
      new EyeStep.OP_INFO("7C", "jl short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if less/not greater (SF!=OF)"),
      new EyeStep.OP_INFO("7D", "jge short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not less/greater or equal (SF=OF)"),
      new EyeStep.OP_INFO("7E", "jle short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if less or equal/not greater ((ZF=1) OR (SF!=OF))"),
      new EyeStep.OP_INFO("7F", "jg short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if not less nor equal/greater ((ZF=0) AND (SF=OF))"),
      new EyeStep.OP_INFO("80+m0", "add", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Add"),
      new EyeStep.OP_INFO("80+m1", "or", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("80+m2", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Add with Carry"),
      new EyeStep.OP_INFO("80+m3", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("80+m4", "and", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical AND"),
      new EyeStep.OP_INFO("80+m5", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Subtract"),
      new EyeStep.OP_INFO("80+m6", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("80+m7", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("81+m0", "add", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Add"),
      new EyeStep.OP_INFO("81+m1", "or", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("81+m2", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Add with Carry"),
      new EyeStep.OP_INFO("81+m3", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("81+m4", "and", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Logical AND"),
      new EyeStep.OP_INFO("81+m5", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Subtract"),
      new EyeStep.OP_INFO("81+m6", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("81+m7", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("82+m0", "add", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Add"),
      new EyeStep.OP_INFO("82+m1", "or", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("82+m2", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Add with Carry"),
      new EyeStep.OP_INFO("82+m3", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("82+m4", "and", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical AND"),
      new EyeStep.OP_INFO("82+m5", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Subtract"),
      new EyeStep.OP_INFO("82+m6", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("82+m7", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("83+m0", "add", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Add"),
      new EyeStep.OP_INFO("83+m1", "or", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Logical Inclusive OR"),
      new EyeStep.OP_INFO("83+m2", "adc", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Add with Carry"),
      new EyeStep.OP_INFO("83+m3", "sbb", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Integer Subtraction with Borrow"),
      new EyeStep.OP_INFO("83+m4", "and", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Logical AND"),
      new EyeStep.OP_INFO("83+m5", "sub", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Subtract"),
      new EyeStep.OP_INFO("83+m6", "xor", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Logical Exclusive OR"),
      new EyeStep.OP_INFO("83+m7", "cmp", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Compare Two Operands"),
      new EyeStep.OP_INFO("84", "test", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Logical Compare"),
      new EyeStep.OP_INFO("85", "test", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Logical Compare"),
      new EyeStep.OP_INFO("86", "xchg", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Exchange Register/Memory with Register"),
      new EyeStep.OP_INFO("87", "xchg", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Exchange Register/Memory with Register"),
      new EyeStep.OP_INFO("88", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.r8
      }, "Move"),
      new EyeStep.OP_INFO("89", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.r16_32
      }, "Move"),
      new EyeStep.OP_INFO("8A", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.r_m8
      }, "Move"),
      new EyeStep.OP_INFO("8B", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.r_m16_32
      }, "Move"),
      new EyeStep.OP_INFO("8C", "mov", new OP_TYPES[2]
      {
        OP_TYPES.m16,
        OP_TYPES.Sreg
      }, "Move"),
      new EyeStep.OP_INFO("8D", "lea", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.m32
      }, "Load Effective Address"),
      new EyeStep.OP_INFO("8E", "mov", new OP_TYPES[2]
      {
        OP_TYPES.Sreg,
        OP_TYPES.r_m16
      }, "Move"),
      new EyeStep.OP_INFO("8F", "pop", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Pop a Value from the Stack"),
      new EyeStep.OP_INFO("90", "nop", new OP_TYPES[0], "No Operation"),
      new EyeStep.OP_INFO("90+r", "xchg", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.r16_32
      }, "Exchange Register/Memory with Register"),
      new EyeStep.OP_INFO("98", "cbw", new OP_TYPES[2]
      {
        OP_TYPES.AX,
        OP_TYPES.AL
      }, "Convert Byte to Word"),
      new EyeStep.OP_INFO("99", "cwd", new OP_TYPES[2]
      {
        OP_TYPES.AX,
        OP_TYPES.AL
      }, "Convert Doubleword to Quadword"),
      new EyeStep.OP_INFO("9A", "callf", new OP_TYPES[1]
      {
        OP_TYPES.ptr16_32
      }, "Call Procedure"),
      new EyeStep.OP_INFO("9B", "fwait", new OP_TYPES[0], "Check pending unmasked floating-point exceptions"),
      new EyeStep.OP_INFO("9C", "pushfd", new OP_TYPES[0], "Push EFLAGS Register onto the Stack"),
      new EyeStep.OP_INFO("9D", "popfd", new OP_TYPES[0], "Pop Stack into EFLAGS Register"),
      new EyeStep.OP_INFO("9E", "sahf", new OP_TYPES[1]
      {
        OP_TYPES.AH
      }, "Store AH into Flags"),
      new EyeStep.OP_INFO("9F", "lahf", new OP_TYPES[1]
      {
        OP_TYPES.AH
      }, "Load Status Flags into AH Register"),
      new EyeStep.OP_INFO("A0", "mov", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.moffs8
      }, "Move"),
      new EyeStep.OP_INFO("A1", "mov", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.moffs16_32
      }, "Move"),
      new EyeStep.OP_INFO("A2", "mov", new OP_TYPES[2]
      {
        OP_TYPES.moffs8,
        OP_TYPES.AL
      }, "Move"),
      new EyeStep.OP_INFO("A3", "mov", new OP_TYPES[2]
      {
        OP_TYPES.moffs16_32,
        OP_TYPES.EAX
      }, "Move"),
      new EyeStep.OP_INFO("A4", "movsb", new OP_TYPES[0], "Move Data from String to String"),
      new EyeStep.OP_INFO("A5", "movsw", new OP_TYPES[0], "Move Data from String to String"),
      new EyeStep.OP_INFO("A6", "cmpsb", new OP_TYPES[0], "Compare String Operands"),
      new EyeStep.OP_INFO("A7", "cmpsw", new OP_TYPES[0], "Compare String Operands"),
      new EyeStep.OP_INFO("A8", "test", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Logical Compare"),
      new EyeStep.OP_INFO("A9", "test", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm16_32
      }, "Logical Compare"),
      new EyeStep.OP_INFO("AA", "stosb", new OP_TYPES[0], "Store String"),
      new EyeStep.OP_INFO("AB", "stosw", new OP_TYPES[0], "Store String"),
      new EyeStep.OP_INFO("AC", "lodsb", new OP_TYPES[0], "Load String"),
      new EyeStep.OP_INFO("AD", "lodsw", new OP_TYPES[0], "Load String"),
      new EyeStep.OP_INFO("AE", "scasb", new OP_TYPES[0], "Scan String"),
      new EyeStep.OP_INFO("AF", "scasw", new OP_TYPES[0], "Scan String"),
      new EyeStep.OP_INFO("B0+r", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r8,
        OP_TYPES.imm8
      }, "Move"),
      new EyeStep.OP_INFO("B8+r", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r16_32,
        OP_TYPES.imm16_32
      }, "Move"),
      new EyeStep.OP_INFO("C0+m0", "rol", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C0+m1", "ror", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C0+m2", "rcl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C0+m3", "rcr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C0+m4", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C0+m5", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C0+m6", "sal", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C0+m7", "sar", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C1+m0", "rol", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C1+m1", "ror", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C1+m2", "rcl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C1+m3", "rcr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Rotate"),
      new EyeStep.OP_INFO("C1+m4", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C1+m5", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C1+m6", "sal", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C1+m7", "sar", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm8
      }, "Shift"),
      new EyeStep.OP_INFO("C2", "ret", new OP_TYPES[1]
      {
        OP_TYPES.imm16
      }, "Return from procedure"),
      new EyeStep.OP_INFO("C3", "retn", new OP_TYPES[0], "Return from procedure"),
      new EyeStep.OP_INFO("C4", "les", new OP_TYPES[3]
      {
        OP_TYPES.ES,
        OP_TYPES.r16_32,
        OP_TYPES.m16_32_and_16_32
      }, "Load Far Pointer"),
      new EyeStep.OP_INFO("C5", "lds", new OP_TYPES[3]
      {
        OP_TYPES.DS,
        OP_TYPES.r16_32,
        OP_TYPES.m16_32_and_16_32
      }, "Load Far Pointer"),
      new EyeStep.OP_INFO("C6", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Move"),
      new EyeStep.OP_INFO("C7", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Move"),
      new EyeStep.OP_INFO("66+C7", "mov", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16
      }, "Move"),
      new EyeStep.OP_INFO("C8", "enter", new OP_TYPES[3]
      {
        OP_TYPES.EBP,
        OP_TYPES.imm16,
        OP_TYPES.imm8
      }, "Make Stack Frame for Procedure Parameters"),
      new EyeStep.OP_INFO("C9", "leave", new OP_TYPES[1]
      {
        OP_TYPES.EBP
      }, "High Level Procedure Exit"),
      new EyeStep.OP_INFO("CA", "retf", new OP_TYPES[1]
      {
        OP_TYPES.imm16
      }, "Return from procedure"),
      new EyeStep.OP_INFO("CB", "retf", new OP_TYPES[0], "Return from procedure"),
      new EyeStep.OP_INFO("CC", "int 3", new OP_TYPES[0], "Call to Interrupt Procedure"),
      new EyeStep.OP_INFO("CD", "int", new OP_TYPES[1]
      {
        OP_TYPES.imm8
      }, "Call to Interrupt Procedure"),
      new EyeStep.OP_INFO("CE", "into", new OP_TYPES[0], "Call to Interrupt Procedure"),
      new EyeStep.OP_INFO("CF", "iretd", new OP_TYPES[0], "Interrupt Return"),
      new EyeStep.OP_INFO("D0+m0", "rol", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D0+m1", "ror", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D0+m2", "rcl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D0+m3", "rcr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D0+m4", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D0+m5", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D0+m6", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D0+m7", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D1+m0", "rol", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D1+m1", "ror", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D1+m2", "rcl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D1+m3", "rcr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Rotate"),
      new EyeStep.OP_INFO("D1+m4", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D1+m5", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D1+m6", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D1+m7", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.one
      }, "Shift"),
      new EyeStep.OP_INFO("D2+m0", "rol", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D2+m1", "ror", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D2+m2", "rcl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D2+m3", "rcr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D2+m4", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D2+m5", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D2+m6", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D2+m7", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D3+m0", "rol", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D3+m1", "ror", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D3+m2", "rcl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D3+m3", "rcr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Rotate"),
      new EyeStep.OP_INFO("D3+m4", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D3+m5", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D3+m6", "shl", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D3+m7", "shr", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.CL
      }, "Shift"),
      new EyeStep.OP_INFO("D4", "aam", new OP_TYPES[3]
      {
        OP_TYPES.AL,
        OP_TYPES.AH,
        OP_TYPES.imm8
      }, "ASCII Adjust AX After Multiply"),
      new EyeStep.OP_INFO("D5", "aad", new OP_TYPES[3]
      {
        OP_TYPES.AL,
        OP_TYPES.AH,
        OP_TYPES.imm8
      }, "ASCII Adjust AX Before Division"),
      new EyeStep.OP_INFO("D6", "setalc", new OP_TYPES[1], "Set AL If Carry"),
      new EyeStep.OP_INFO("D7", "xlatb", new OP_TYPES[1], "Table Look-up Translation"),
      new EyeStep.OP_INFO("D8+m8", "fadd", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Add"),
      new EyeStep.OP_INFO("D8+m9", "fmul", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Multiply"),
      new EyeStep.OP_INFO("D8+mA", "fcom", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Compare Real"),
      new EyeStep.OP_INFO("D8+mB", "fcomp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Compare Real and Pop"),
      new EyeStep.OP_INFO("D8+mC", "fsub", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Subtract"),
      new EyeStep.OP_INFO("D8+mD", "fsubr", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Reverse Subtract"),
      new EyeStep.OP_INFO("D8+mE", "fdiv", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Divide"),
      new EyeStep.OP_INFO("D8+mF", "fdivr", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Reverse Divide"),
      new EyeStep.OP_INFO("D8+m0", "fadd", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Add"),
      new EyeStep.OP_INFO("D8+m1", "fmul", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Multiply"),
      new EyeStep.OP_INFO("D8+m2", "fcom", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real"),
      new EyeStep.OP_INFO("D8+m3", "fcomp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real and Pop"),
      new EyeStep.OP_INFO("D8+m4", "fsub", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Subtract"),
      new EyeStep.OP_INFO("D8+m5", "fsubr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Subtract"),
      new EyeStep.OP_INFO("D8+m6", "fdiv", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Divide"),
      new EyeStep.OP_INFO("D8+m7", "fdivr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Divide"),
      new EyeStep.OP_INFO("D9+m0", "fld", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load Floating Point Value"),
      new EyeStep.OP_INFO("D9+m1", "fxch", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Exchange Register Contents"),
      new EyeStep.OP_INFO("D9+m2", "fst", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Floating Point Value"),
      new EyeStep.OP_INFO("D9+m3", "fstp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Floating Point Value and Pop"),
      new EyeStep.OP_INFO("D9+m4", "fldenv", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load x87 FPU Environment"),
      new EyeStep.OP_INFO("D9+m5", "fldcw", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load x87 FPU Control Word"),
      new EyeStep.OP_INFO("D9+m6", "fnstenv", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store x87 FPU Environment"),
      new EyeStep.OP_INFO("D9+m7", "fnstcw", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store x87 FPU Control Word"),
      new EyeStep.OP_INFO("DA+m8", "fcmovb", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - below (CF=1)"),
      new EyeStep.OP_INFO("DA+m9", "fcmove", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - equal (ZF=1)"),
      new EyeStep.OP_INFO("DA+mA", "fcmovbe", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - below or equal (CF=1 or ZF=1)"),
      new EyeStep.OP_INFO("DA+mB", "fcmovu", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - unordered (PF=1)"),
      new EyeStep.OP_INFO("DA+mC", "fisub", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Subtract"),
      new EyeStep.OP_INFO("DA+mD", "fisubr", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Reverse Subtract"),
      new EyeStep.OP_INFO("DA+mE", "fidiv", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Divide"),
      new EyeStep.OP_INFO("DA+mF", "fidivr", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Reverse Divide"),
      new EyeStep.OP_INFO("DA+m0", "fiadd", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Add"),
      new EyeStep.OP_INFO("DA+m1", "fimul", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Multiply"),
      new EyeStep.OP_INFO("DA+m2", "ficom", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real"),
      new EyeStep.OP_INFO("DA+m3", "ficomp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real and Pop"),
      new EyeStep.OP_INFO("DA+m4", "fisub", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Subtract"),
      new EyeStep.OP_INFO("DA+m5", "fisubr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Subtract"),
      new EyeStep.OP_INFO("DA+m6", "fidiv", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Divide"),
      new EyeStep.OP_INFO("DA+m7", "fidivr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Divide"),
      new EyeStep.OP_INFO("DB+m8", "fcmovnb", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - not below (CF=0)"),
      new EyeStep.OP_INFO("DB+m9", "fcmovne", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - not equal (ZF=0)"),
      new EyeStep.OP_INFO("DB+mA", "fcmovnbe", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - below or equal (CF=0 and ZF=0)"),
      new EyeStep.OP_INFO("DB+mB", "fcmovnu", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "FP Conditional Move - not unordered (PF=0)"),
      new EyeStep.OP_INFO("DB+m0", "fild", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load Integer"),
      new EyeStep.OP_INFO("DB+m1", "fisttp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer with Truncation and Pop"),
      new EyeStep.OP_INFO("DB+m2", "fist", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer"),
      new EyeStep.OP_INFO("DB+m3", "fistp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer and Pop"),
      new EyeStep.OP_INFO("DB+m4", "finit", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Initialize Floating-Point Unit"),
      new EyeStep.OP_INFO("DB+m5", "fucomi", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Unordered Compare Floating Point Values and Set EFLAGS"),
      new EyeStep.OP_INFO("DB+m6", "fcomi", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Floating Point Values and Set EFLAGS"),
      new EyeStep.OP_INFO("DB+m7", "fstp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Floating Point Value and Pop"),
      new EyeStep.OP_INFO("DC+m8", "fadd", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Add"),
      new EyeStep.OP_INFO("DC+m9", "fmul", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Multiply"),
      new EyeStep.OP_INFO("DC+mA", "fcom", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Compare Real"),
      new EyeStep.OP_INFO("DC+mB", "fcomp", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Compare Real and Pop"),
      new EyeStep.OP_INFO("DC+mC", "fsub", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Subtract"),
      new EyeStep.OP_INFO("DC+mD", "fsubr", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Reverse Subtract"),
      new EyeStep.OP_INFO("DC+mE", "fdiv", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Divide"),
      new EyeStep.OP_INFO("DC+mF", "fdivr", new OP_TYPES[2]
      {
        OP_TYPES.STi,
        OP_TYPES.ST
      }, "Reverse Divide"),
      new EyeStep.OP_INFO("DC+m0", "fadd", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Add"),
      new EyeStep.OP_INFO("DC+m1", "fmul", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Multiply"),
      new EyeStep.OP_INFO("DC+m2", "fcom", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real"),
      new EyeStep.OP_INFO("DC+m3", "fcomp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real and Pop"),
      new EyeStep.OP_INFO("DC+m4", "fsub", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Subtract"),
      new EyeStep.OP_INFO("DC+m5", "fsubr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Subtract"),
      new EyeStep.OP_INFO("DC+m6", "fdiv", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Divide"),
      new EyeStep.OP_INFO("DC+m7", "fdivr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Divide"),
      new EyeStep.OP_INFO("DD+m8", "ffree", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Free Floating-Point Register"),
      new EyeStep.OP_INFO("DD+m0", "fld", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load Floating Point Value"),
      new EyeStep.OP_INFO("DD+m1", "fisttp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer with Truncation and Pop"),
      new EyeStep.OP_INFO("DD+m2", "fst", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Floating Point Value"),
      new EyeStep.OP_INFO("DD+m3", "fstp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Floating Point Value and Pop"),
      new EyeStep.OP_INFO("DD+m4", "frstor", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Restore x87 FPU State"),
      new EyeStep.OP_INFO("DD+m5", "fucomp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Unordered Compare Floating Point Values and Pop"),
      new EyeStep.OP_INFO("DD+m6", "fnsave", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store x87 FPU State"),
      new EyeStep.OP_INFO("DD+m7", "fnstsw", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store x87 FPU Status Word"),
      new EyeStep.OP_INFO("DE+m8", "faddp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Add and Pop"),
      new EyeStep.OP_INFO("DE+m9", "fmulp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Multiply and Pop"),
      new EyeStep.OP_INFO("DE+mA", "ficom", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Compare Real"),
      new EyeStep.OP_INFO("DE+mB", "ficomp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Compare Real and Pop"),
      new EyeStep.OP_INFO("DE+mC", "fsubrp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Reverse Subtract and Pop"),
      new EyeStep.OP_INFO("DE+mD", "fsubp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Subtract and Pop"),
      new EyeStep.OP_INFO("DE+mE", "fdivrp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Reverse Divide and Pop"),
      new EyeStep.OP_INFO("DE+mF", "fdivp", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Divide and Pop"),
      new EyeStep.OP_INFO("DE+m0", "fiadd", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Add"),
      new EyeStep.OP_INFO("DE+m1", "fimul", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Multiply"),
      new EyeStep.OP_INFO("DE+m2", "ficom", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real"),
      new EyeStep.OP_INFO("DE+m3", "ficomp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Compare Real and Pop"),
      new EyeStep.OP_INFO("DE+m4", "fisub", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Subtract"),
      new EyeStep.OP_INFO("DE+m5", "fisubr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Subtract"),
      new EyeStep.OP_INFO("DE+m6", "fidiv", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Divide"),
      new EyeStep.OP_INFO("DE+m7", "fdivr", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Reverse Divide"),
      new EyeStep.OP_INFO("DF+m8", "ffreep", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Free Floating-Point Register and Pop"),
      new EyeStep.OP_INFO("DF+m9", "fisttp", new OP_TYPES[1]
      {
        OP_TYPES.r32
      }, "Store Integer with Truncation and Pop"),
      new EyeStep.OP_INFO("DF+mA", "fist", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer"),
      new EyeStep.OP_INFO("DF+mB", "fistp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer and Pop"),
      new EyeStep.OP_INFO("DF+mC", "fnstsw", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store x87 FPU Status Word"),
      new EyeStep.OP_INFO("DF+mD", "fucomip", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Unordered Compare Floating Point Values and Set EFLAGS and Pop"),
      new EyeStep.OP_INFO("DF+mE", "fcomip", new OP_TYPES[2]
      {
        OP_TYPES.ST,
        OP_TYPES.STi
      }, "Compare Floating Point Values and Set EFLAGS and Pop"),
      new EyeStep.OP_INFO("DF+mF", "fistp", new OP_TYPES[1]
      {
        OP_TYPES.r64
      }, "Store Integer and Pop"),
      new EyeStep.OP_INFO("DF+m0", "fild", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load Integer"),
      new EyeStep.OP_INFO("DF+m1", "fisttp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer with Truncation and Pop"),
      new EyeStep.OP_INFO("DF+m2", "fist", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer"),
      new EyeStep.OP_INFO("DF+m3", "fistp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer and Pop"),
      new EyeStep.OP_INFO("DF+m4", "fbld", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load Binary Coded Decimal"),
      new EyeStep.OP_INFO("DF+m5", "fild", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Load Integer"),
      new EyeStep.OP_INFO("DF+m6", "fbstp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store BCD Integer and Pop"),
      new EyeStep.OP_INFO("DF+m7", "fistp", new OP_TYPES[1]
      {
        OP_TYPES.STi
      }, "Store Integer and Pop"),
      new EyeStep.OP_INFO("E0", "loopne", new OP_TYPES[2]
      {
        OP_TYPES.ECX,
        OP_TYPES.rel8
      }, "Decrement count; Jump short if count!=0 and ZF=0"),
      new EyeStep.OP_INFO("E1", "loope", new OP_TYPES[2]
      {
        OP_TYPES.ECX,
        OP_TYPES.rel8
      }, "Decrement count; Jump short if count!=0 and ZF=1"),
      new EyeStep.OP_INFO("E2", "loop", new OP_TYPES[2]
      {
        OP_TYPES.ECX,
        OP_TYPES.rel8
      }, "Decrement count; Jump short if count!=0"),
      new EyeStep.OP_INFO("E3", "jecxz", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump short if eCX register is 0"),
      new EyeStep.OP_INFO("E4", "in", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.imm8
      }, "Input from Port"),
      new EyeStep.OP_INFO("E5", "in", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.imm8
      }, "Input from Port"),
      new EyeStep.OP_INFO("E6", "out", new OP_TYPES[2]
      {
        OP_TYPES.imm8,
        OP_TYPES.AL
      }, "Output to Port"),
      new EyeStep.OP_INFO("E7", "out", new OP_TYPES[2]
      {
        OP_TYPES.imm8,
        OP_TYPES.EAX
      }, "Output to Port"),
      new EyeStep.OP_INFO("E8", "call", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Call Procedure"),
      new EyeStep.OP_INFO("E9", "jmp", new OP_TYPES[1]
      {
        OP_TYPES.rel16_32
      }, "Jump"),
      new EyeStep.OP_INFO("EA", "jmpf", new OP_TYPES[1]
      {
        OP_TYPES.ptr16_32
      }, "Jump"),
      new EyeStep.OP_INFO("EB", "jmp short", new OP_TYPES[1]
      {
        OP_TYPES.rel8
      }, "Jump"),
      new EyeStep.OP_INFO("EC", "in", new OP_TYPES[2]
      {
        OP_TYPES.AL,
        OP_TYPES.DX
      }, "Input from Port"),
      new EyeStep.OP_INFO("ED", "in", new OP_TYPES[2]
      {
        OP_TYPES.EAX,
        OP_TYPES.DX
      }, "Input from Port"),
      new EyeStep.OP_INFO("EE", "out", new OP_TYPES[2]
      {
        OP_TYPES.DX,
        OP_TYPES.AL
      }, "Output to Port"),
      new EyeStep.OP_INFO("EF", "out", new OP_TYPES[2]
      {
        OP_TYPES.DX,
        OP_TYPES.EAX
      }, "Output to Port"),
      new EyeStep.OP_INFO("F1", "int 1", new OP_TYPES[0], "Call to Interrupt Procedure"),
      new EyeStep.OP_INFO("F4", "hlt", new OP_TYPES[0], "Halt"),
      new EyeStep.OP_INFO("F5", "cmc", new OP_TYPES[0], "Complement Carry Flag"),
      new EyeStep.OP_INFO("F6+m0", "test", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical Compare"),
      new EyeStep.OP_INFO("F6+m1", "test", new OP_TYPES[2]
      {
        OP_TYPES.r_m8,
        OP_TYPES.imm8
      }, "Logical Compare"),
      new EyeStep.OP_INFO("F6+m2", "not", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "One's Complement Negation"),
      new EyeStep.OP_INFO("F6+m3", "neg", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Two's Complement Negation"),
      new EyeStep.OP_INFO("F6+m4", "mul", new OP_TYPES[3]
      {
        OP_TYPES.AX,
        OP_TYPES.AL,
        OP_TYPES.r_m8
      }, "Unsigned Multiply"),
      new EyeStep.OP_INFO("F6+m5", "imul", new OP_TYPES[3]
      {
        OP_TYPES.AX,
        OP_TYPES.AL,
        OP_TYPES.r_m8
      }, "Signed Multiply"),
      new EyeStep.OP_INFO("F6+m6", "div", new OP_TYPES[4]
      {
        OP_TYPES.AX,
        OP_TYPES.AL,
        OP_TYPES.AX,
        OP_TYPES.r_m8
      }, "Unigned Divide"),
      new EyeStep.OP_INFO("F6+m7", "idiv", new OP_TYPES[4]
      {
        OP_TYPES.AX,
        OP_TYPES.AL,
        OP_TYPES.AX,
        OP_TYPES.r_m8
      }, "Signed Divide"),
      new EyeStep.OP_INFO("F7+m0", "test", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Logical Compare"),
      new EyeStep.OP_INFO("F7+m1", "test", new OP_TYPES[2]
      {
        OP_TYPES.r_m16_32,
        OP_TYPES.imm16_32
      }, "Logical Compare"),
      new EyeStep.OP_INFO("F7+m2", "not", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "One's Complement Negation"),
      new EyeStep.OP_INFO("F7+m3", "neg", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Two's Complement Negation"),
      new EyeStep.OP_INFO("F7+m4", "mul", new OP_TYPES[3]
      {
        OP_TYPES.EDX,
        OP_TYPES.EAX,
        OP_TYPES.r_m16_32
      }, "Unsigned Multiply"),
      new EyeStep.OP_INFO("F7+m5", "imul", new OP_TYPES[3]
      {
        OP_TYPES.EDX,
        OP_TYPES.EAX,
        OP_TYPES.r_m16_32
      }, "Signed Multiply"),
      new EyeStep.OP_INFO("F7+m6", "div", new OP_TYPES[3]
      {
        OP_TYPES.EDX,
        OP_TYPES.EAX,
        OP_TYPES.r_m16_32
      }, "Unigned Divide"),
      new EyeStep.OP_INFO("F7+m7", "idiv", new OP_TYPES[3]
      {
        OP_TYPES.EDX,
        OP_TYPES.EAX,
        OP_TYPES.r_m16_32
      }, "Signed Divide"),
      new EyeStep.OP_INFO("F8", "clc", new OP_TYPES[0], "Clear Carry Flag"),
      new EyeStep.OP_INFO("F9", "stc", new OP_TYPES[0], "Set Carry Flag"),
      new EyeStep.OP_INFO("FA", "cli", new OP_TYPES[0], "Clear Interrupt Flag"),
      new EyeStep.OP_INFO("FB", "sti", new OP_TYPES[0], "Set Interrupt Flag"),
      new EyeStep.OP_INFO("FC", "cld", new OP_TYPES[0], "Clear Direction Flag"),
      new EyeStep.OP_INFO("FD", "std", new OP_TYPES[0], "Set Direction Flag"),
      new EyeStep.OP_INFO("FE+m0", "inc", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Increment by 1"),
      new EyeStep.OP_INFO("FE+m1", "dec", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Decrement by 1"),
      new EyeStep.OP_INFO("FE+mE", "inc", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Increment by 1"),
      new EyeStep.OP_INFO("FE+mF", "dec", new OP_TYPES[1]
      {
        OP_TYPES.r_m8
      }, "Decrement by 1"),
      new EyeStep.OP_INFO("FF+m0", "inc", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Increment by 1"),
      new EyeStep.OP_INFO("FF+m1", "dec", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Decrement by 1"),
      new EyeStep.OP_INFO("FF+m2", "call", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Call Procedure"),
      new EyeStep.OP_INFO("FF+m3", "callf", new OP_TYPES[1]
      {
        OP_TYPES.m16_32_and_16_32
      }, "Call Procedure"),
      new EyeStep.OP_INFO("FF+m4", "jmp", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Jump"),
      new EyeStep.OP_INFO("FF+m5", "jmpf", new OP_TYPES[1]
      {
        OP_TYPES.m16_32_and_16_32
      }, "Jump"),
      new EyeStep.OP_INFO("FF+m6", "push", new OP_TYPES[1]
      {
        OP_TYPES.r_m16_32
      }, "Push Word, Doubleword or Quadword Onto the Stack")
    };

    private static byte to_byte(string str, int offset)
    {
      int num1 = 0;
      if (str[offset] == '?' && str[offset + 1] == '?')
        return 0;
      for (int index = offset; index < offset + 2; ++index)
      {
        int num2 = 0;
        if (str[index] >= 'a')
          num2 = (int) str[index] - 87;
        else if (str[index] >= 'A')
          num2 = (int) str[index] - 55;
        else if (str[index] >= '0')
          num2 = (int) str[index] - 48;
        if (index == offset)
          num1 += num2 * 16;
        else
          num1 += num2;
      }
      return (byte) num1;
    }

    public static string to_str(byte b) => b.ToString("X2");

    public static bool open(string process_name)
    {
      Process[] processesByName = Process.GetProcessesByName(process_name.Replace(".exe", ""));
      return processesByName.Length != 0 && EyeStep.open(((IEnumerable<Process>) processesByName).First<Process>());
    }

    public static bool open(Process process)
    {
      if (EyeStep.OP_TABLE == null)
        EyeStep.init();
      if (process != null && process.Id != 0 && (!process.HasExited && process.MainModule != null))
      {
        if (process.MainModule.ModuleName.Length > 0)
        {
          try
          {
            int num = imports.OpenProcess(2035711U, false, process.Id);
            if (num != 0)
            {
              EyeStep.handle = num;
              EyeStep.current_proc = process;
              EyeStep.base_module = process.MainModule.BaseAddress.ToInt32();
              EyeStep.base_module_size = process.MainModule.ModuleMemorySize;
              return true;
            }
          }
          catch (Win32Exception ex)
          {
            EyeStep.handle = 0;
            EyeStep.current_proc = (Process) null;
            EyeStep.base_module = 0;
            EyeStep.base_module_size = 0;
            return false;
          }
        }
      }
      return false;
    }

    public static void close()
    {
      EyeStep.base_module = 0;
      EyeStep.base_module_size = 0;
      EyeStep.current_proc = new Process();
      EyeStep.handle = 0;
    }

    public static EyeStep.inst read(int address)
    {
      // ISSUE: variable of a compiler-generated type
      EyeStep.\u003C\u003Ec__DisplayClass88_0 func;
      // ISSUE: reference to a compiler-generated field
      func.p = new EyeStep.inst();
      // ISSUE: reference to a compiler-generated field
      func.p.address = address;
      int lpNumberOfBytesRead = 0;
      // ISSUE: reference to a compiler-generated field
      imports.ReadProcessMemory(EyeStep.handle, address, func.p.bytes, 16, ref lpNumberOfBytesRead);
      for (int index1 = 0; index1 < EyeStep.OP_TABLE.Length; ++index1)
      {
        EyeStep.OP_INFO opInfo = EyeStep.OP_TABLE[index1];
        // ISSUE: reference to a compiler-generated field
        func.p.flags = 0U;
        // ISSUE: reference to a compiler-generated field
        func.p.len = 0;
        byte num1 = EyeStep.to_byte(opInfo.code, 0);
        bool flag1 = false;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        switch (func.p.bytes[func.p.len])
        {
          case 38:
            // ISSUE: reference to a compiler-generated field
            ++func.p.len;
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 256U;
            break;
          case 46:
            // ISSUE: reference to a compiler-generated field
            ++func.p.len;
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 32U;
            break;
          case 54:
            // ISSUE: reference to a compiler-generated field
            ++func.p.len;
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 64U;
            break;
          case 62:
            // ISSUE: reference to a compiler-generated field
            ++func.p.len;
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 128U;
            break;
          case 100:
            // ISSUE: reference to a compiler-generated field
            ++func.p.len;
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 512U;
            break;
          case 101:
            // ISSUE: reference to a compiler-generated field
            ++func.p.len;
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 1024U;
            break;
          case 102:
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 4U;
            break;
          case 103:
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 8U;
            break;
          case 240:
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 16U;
            if (num1 != (byte) 240)
            {
              flag1 = true;
              break;
            }
            break;
          case 242:
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 1U;
            if (num1 != (byte) 242)
            {
              flag1 = true;
              break;
            }
            break;
          case 243:
            // ISSUE: reference to a compiler-generated field
            func.p.flags |= 2U;
            if (num1 != (byte) 243)
            {
              flag1 = true;
              break;
            }
            break;
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        bool flag2 = (int) func.p.bytes[func.p.len] == (int) num1;
        bool flag3 = false;
        for (int index2 = 2; index2 < 11 && opInfo.code.Length > index2; index2 += 3)
        {
          if (opInfo.code[index2] == '+')
          {
            if (opInfo.code[index2 + 1] != 'r')
            {
              if (!(opInfo.code[index2 + 1] == 'm' & flag2))
              {
                if (flag2)
                {
                  // ISSUE: reference to a compiler-generated field
                  ++func.p.len;
                  num1 = EyeStep.to_byte(opInfo.code, index2 + 1);
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  flag2 = (int) func.p.bytes[func.p.len] == (int) num1;
                }
              }
              else
              {
                byte num2 = EyeStep.to_byte("0" + opInfo.code[index2 + 2].ToString(), 0);
                if (num2 >= (byte) 0 && num2 < (byte) 8)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  flag2 = EyeStep.longreg(func.p.bytes[func.p.len + 1]) == (int) num2;
                  break;
                }
                byte num3 = (byte) ((uint) num2 - 8U);
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                flag2 = EyeStep.longreg(func.p.bytes[func.p.len + 1]) == (int) num3 && func.p.bytes[func.p.len + 1] >= (byte) 192;
                break;
              }
            }
            else
            {
              flag3 = true;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              flag2 = (int) func.p.bytes[func.p.len] >= (int) num1 && (int) func.p.bytes[func.p.len] < (int) num1 + 8;
              break;
            }
          }
        }
        if (flag2)
        {
          // ISSUE: reference to a compiler-generated field
          ++func.p.len;
          if (flag1)
          {
            // ISSUE: reference to a compiler-generated field
            switch (func.p.flags)
            {
              case 1:
                // ISSUE: reference to a compiler-generated field
                func.p.data = "repne ";
                break;
              case 2:
                // ISSUE: reference to a compiler-generated field
                func.p.data = "repe ";
                break;
              case 16:
                // ISSUE: reference to a compiler-generated field
                func.p.data = "lock ";
                break;
            }
          }
          // ISSUE: reference to a compiler-generated field
          func.p.data += opInfo.opcode_name;
          // ISSUE: reference to a compiler-generated field
          func.p.data += " ";
          // ISSUE: reference to a compiler-generated field
          func.p.info = opInfo;
          int length = opInfo.operands.Length;
          switch (length)
          {
            case 0:
              byte num2 = byte.MaxValue;
              // ISSUE: variable of a compiler-generated type
              EyeStep.\u003C\u003Ec__DisplayClass88_1 c;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              for (c.c = 0; c.c < length; c.c++)
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                func.p.operands[c.c].opmode = opInfo.operands[c.c];
                byte routine_name1 = num2;
                if (num2 == byte.MaxValue)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  routine_name1 = (byte) EyeStep.longreg(func.p.bytes[func.p.len]);
                }
                if (flag3)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  routine_name1 = (byte) EyeStep.finalreg(func.p.bytes[func.p.len - 1]);
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                switch (func.p.operands[c.c].opmode)
                {
                  case OP_TYPES.AL:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num3 = (int) func.p.operands[c.c].append_reg((byte) 0);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "al";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 1024U;
                    break;
                  case OP_TYPES.AH:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num4 = (int) func.p.operands[c.c].append_reg((byte) 4);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "ah";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 1024U;
                    break;
                  case OP_TYPES.AX:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num5 = (int) func.p.operands[c.c].append_reg((byte) 0);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "ax";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 2048U;
                    break;
                  case OP_TYPES.EAX:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num6 = (int) func.p.operands[c.c].append_reg((byte) 0);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "eax";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 4096U;
                    break;
                  case OP_TYPES.ECX:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num7 = (int) func.p.operands[c.c].append_reg((byte) 1);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "ecx";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 4096U;
                    break;
                  case OP_TYPES.EBP:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num8 = (int) func.p.operands[c.c].append_reg((byte) 3);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "ebp";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 4096U;
                    break;
                  case OP_TYPES.CL:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num9 = (int) func.p.operands[c.c].append_reg((byte) 1);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "cl";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 1024U;
                    break;
                  case OP_TYPES.Sreg:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.sreg_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 131072U;
                    break;
                  case OP_TYPES.ptr16_32:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_2(BitConverter.ToUInt32(func.p.bytes, func.p.len), true, ref func, ref c);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += ":";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_1(BitConverter.ToUInt16(func.p.bytes, func.p.len), true, ref func, ref c);
                    break;
                  case OP_TYPES.ES:
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "es";
                    break;
                  case OP_TYPES.DS:
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "ds";
                    break;
                  case OP_TYPES.SS:
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "ss";
                    break;
                  case OP_TYPES.FS:
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "fs";
                    break;
                  case OP_TYPES.GS:
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "gs";
                    break;
                  case OP_TYPES.one:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.operand operand1 = func.p.operands[c.c];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.operand operand2 = func.p.operands[c.c];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].disp8 = (byte) 1;
                    operand2.disp16 = (ushort) 1;
                    operand1.disp32 = 1U;
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "1";
                    break;
                  case OP_TYPES.r8:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.r8_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 1024U;
                    break;
                  case OP_TYPES.r16:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.r16_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 2048U;
                    break;
                  case OP_TYPES.r16_32:
                  case OP_TYPES.r32:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.r32_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 4096U;
                    break;
                  case OP_TYPES.r64:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.r64_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 8192U;
                    break;
                  case OP_TYPES.r_m8:
                  case OP_TYPES.r_m16:
                  case OP_TYPES.r_m16_32:
                  case OP_TYPES.r_m32:
                  case OP_TYPES.m16_32_and_16_32:
                  case OP_TYPES.m8:
                  case OP_TYPES.m16:
                  case OP_TYPES.m16_32:
                  case OP_TYPES.m32:
                  case OP_TYPES.m64real:
                  case OP_TYPES.m128:
                  case OP_TYPES.mm_m64:
                  case OP_TYPES.xmm_m32:
                  case OP_TYPES.xmm_m64:
                  case OP_TYPES.xmm_m128:
                  case OP_TYPES.STi:
                    // ISSUE: reference to a compiler-generated field
                    if (((int) func.p.flags & 32) == 32)
                    {
                      // ISSUE: reference to a compiler-generated field
                      func.p.data += "cs:";
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      if (((int) func.p.flags & 128) == 128)
                      {
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += "ds:";
                      }
                      else
                      {
                        // ISSUE: reference to a compiler-generated field
                        if (((int) func.p.flags & 256) == 256)
                        {
                          // ISSUE: reference to a compiler-generated field
                          func.p.data += "es:";
                        }
                        else
                        {
                          // ISSUE: reference to a compiler-generated field
                          if (((int) func.p.flags & 64) == 64)
                          {
                            // ISSUE: reference to a compiler-generated field
                            func.p.data += "ss:";
                          }
                          else
                          {
                            // ISSUE: reference to a compiler-generated field
                            if (((int) func.p.flags & 512) == 512)
                            {
                              // ISSUE: reference to a compiler-generated field
                              func.p.data += "fs:";
                            }
                            else
                            {
                              // ISSUE: reference to a compiler-generated field
                              if (((int) func.p.flags & 1024) == 1024)
                              {
                                // ISSUE: reference to a compiler-generated field
                                func.p.data += "gs:";
                              }
                            }
                          }
                        }
                      }
                    }
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    if (func.p.operands[c.c].opmode == OP_TYPES.moffs16_32)
                    {
                      // ISSUE: reference to a compiler-generated field
                      func.p.data += "[";
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      EyeStep.smethod_2(BitConverter.ToUInt32(func.p.bytes, func.p.len + 1), true, ref func, ref c);
                      // ISSUE: reference to a compiler-generated field
                      func.p.data += "]";
                      break;
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (c.c == 0)
                      num2 = routine_name1;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    byte routine_name2 = (byte) EyeStep.finalreg(func.p.bytes[func.p.len]);
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    switch ((int) func.p.bytes[func.p.len] / 64)
                    {
                      case 0:
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += "[";
                        switch (routine_name2)
                        {
                          case 4:
                            EyeStep.smethod_3((byte) 0, ref func, ref c);
                            break;
                          case 5:
                            // ISSUE: reference to a compiler-generated field
                            EyeStep.inst p = func.p;
                            string data = p.data;
                            uint num10;
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            func.p.operands[c.c].disp32 = num10 = BitConverter.ToUInt32(func.p.bytes, func.p.len + 1);
                            num10 = num10;
                            string str = num10.ToString("X8");
                            p.data = data + str;
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            func.p.operands[c.c].flags |= 512U;
                            // ISSUE: reference to a compiler-generated field
                            func.p.len += 4;
                            break;
                          default:
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            func.p.data += EyeStep.mnemonics.r32_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            func.p.operands[c.c].flags |= 4096U;
                            break;
                        }
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += "]";
                        break;
                      case 1:
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += "[";
                        if (routine_name2 == (byte) 4)
                        {
                          EyeStep.smethod_3((byte) 1, ref func, ref c);
                        }
                        else
                        {
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.data += EyeStep.mnemonics.r32_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.operands[c.c].flags |= 4096U;
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          EyeStep.smethod_0(func.p.bytes[func.p.len + 1], false, ref func, ref c);
                        }
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += "]";
                        break;
                      case 2:
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += "[";
                        if (routine_name2 == (byte) 4)
                        {
                          EyeStep.smethod_3((byte) 4, ref func, ref c);
                        }
                        else
                        {
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.data += EyeStep.mnemonics.r32_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.operands[c.c].flags |= 4096U;
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          EyeStep.smethod_2(BitConverter.ToUInt32(func.p.bytes, func.p.len + 1), false, ref func, ref c);
                        }
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += "]";
                        break;
                      case 3:
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        OP_TYPES opmode = func.p.operands[c.c].opmode;
                        if ((uint) opmode <= 38U)
                        {
                          if ((uint) opmode <= 28U)
                          {
                            switch (opmode)
                            {
                              case OP_TYPES.r_m8:
                                goto label_111;
                              case OP_TYPES.r_m16:
                                break;
                              default:
                                goto label_118;
                            }
                          }
                          else
                          {
                            switch (opmode)
                            {
                              case OP_TYPES.m8:
                                goto label_111;
                              case OP_TYPES.m16:
                                break;
                              default:
                                goto label_118;
                            }
                          }
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.data += EyeStep.mnemonics.r16_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.operands[c.c].flags |= 2048U;
                          break;
label_111:
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.data += EyeStep.mnemonics.r8_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          func.p.operands[c.c].flags |= 1024U;
                          break;
                        }
                        if ((uint) opmode <= 69U)
                        {
                          switch (opmode)
                          {
                            case OP_TYPES.m128:
                            case OP_TYPES.xmm_m32:
                            case OP_TYPES.xmm_m64:
                            case OP_TYPES.xmm_m128:
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.data += EyeStep.mnemonics.xmm_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.operands[c.c].flags |= 16384U;
                              goto label_121;
                            case OP_TYPES.mm_m64:
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.data += EyeStep.mnemonics.mm_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.operands[c.c].flags |= 32768U;
                              goto label_121;
                            case OP_TYPES.STi:
                            case OP_TYPES.ST:
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.data += EyeStep.mnemonics.st_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.operands[c.c].flags |= 65536U;
                              goto label_121;
                          }
                        }
                        else
                        {
                          switch (opmode)
                          {
                            case OP_TYPES.CRn:
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.data += EyeStep.mnemonics.cr_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.operands[c.c].flags |= 524288U;
                              goto label_121;
                            case OP_TYPES.DRn:
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.data += EyeStep.mnemonics.dr_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                              // ISSUE: reference to a compiler-generated field
                              // ISSUE: reference to a compiler-generated field
                              func.p.operands[c.c].flags |= 262144U;
                              goto label_121;
                          }
                        }
label_118:
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        func.p.data += EyeStep.mnemonics.r32_names[(int) func.p.operands[c.c].append_reg(routine_name2)];
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        func.p.operands[c.c].flags |= 4096U;
                        break;
                    }
label_121:
                    // ISSUE: reference to a compiler-generated field
                    ++func.p.len;
                    break;
                  case OP_TYPES.moffs8:
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "[";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_2(BitConverter.ToUInt32(func.p.bytes, func.p.len), true, ref func, ref c);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "]";
                    break;
                  case OP_TYPES.moffs16_32:
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "[";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_2(BitConverter.ToUInt32(func.p.bytes, func.p.len), true, ref func, ref c);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "]";
                    break;
                  case OP_TYPES.rel8:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_4(func.p.bytes[func.p.len], ref func, ref c);
                    break;
                  case OP_TYPES.rel16:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_5(BitConverter.ToUInt16(func.p.bytes, func.p.len), ref func, ref c);
                    break;
                  case OP_TYPES.rel16_32:
                  case OP_TYPES.rel32:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_6(BitConverter.ToUInt32(func.p.bytes, func.p.len), ref func, ref c);
                    break;
                  case OP_TYPES.imm8:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_0(func.p.bytes[func.p.len], true, ref func, ref c);
                    break;
                  case OP_TYPES.imm16:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_1(BitConverter.ToUInt16(func.p.bytes, func.p.len), true, ref func, ref c);
                    break;
                  case OP_TYPES.imm16_32:
                  case OP_TYPES.imm32:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    EyeStep.smethod_2(BitConverter.ToUInt32(func.p.bytes, func.p.len), true, ref func, ref c);
                    break;
                  case OP_TYPES.mm:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.mm_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 32768U;
                    break;
                  case OP_TYPES.xmm:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.xmm_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 16384U;
                    break;
                  case OP_TYPES.xmm0:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    int num11 = (int) func.p.operands[c.c].append_reg((byte) 0);
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += "xmm0";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 16384U;
                    break;
                  case OP_TYPES.ST:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.st_names[(int) func.p.operands[c.c].append_reg((byte) 0)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 65536U;
                    break;
                  case OP_TYPES.CRn:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.cr_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 524288U;
                    break;
                  case OP_TYPES.DRn:
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.data += EyeStep.mnemonics.dr_names[(int) func.p.operands[c.c].append_reg(routine_name1)];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    func.p.operands[c.c].flags |= 262144U;
                    break;
                }
                // ISSUE: reference to a compiler-generated field
                if (c.c < length - 1 && length > 1)
                {
                  // ISSUE: reference to a compiler-generated field
                  func.p.data += ",";
                }
              }
              goto label_129;
            case 1:
              // ISSUE: reference to a compiler-generated field
              func.p.flags |= 1U;
              goto case 0;
            case 2:
              // ISSUE: reference to a compiler-generated field
              func.p.flags |= 2U;
              goto case 0;
            default:
              // ISSUE: reference to a compiler-generated field
              func.p.flags |= 4U;
              goto case 0;
          }
        }
      }
label_129:
      // ISSUE: reference to a compiler-generated field
      if (func.p.len == 0)
      {
        // ISSUE: reference to a compiler-generated field
        func.p.len = 1;
        // ISSUE: reference to a compiler-generated field
        func.p.data = "???";
      }
      // ISSUE: reference to a compiler-generated field
      return func.p;
    }

    public static List<EyeStep.inst> read(int address, int count)
    {
      int address1 = address;
      List<EyeStep.inst> instList = new List<EyeStep.inst>();
      for (int index = 0; index < count; ++index)
      {
        EyeStep.inst inst = EyeStep.read(address1);
        instList.Add(inst);
        address1 += inst.len;
      }
      return instList;
    }

    public static List<EyeStep.inst> read_range(int from, int to)
    {
      int address = from;
      List<EyeStep.inst> instList = new List<EyeStep.inst>();
      EyeStep.inst inst;
      for (; address < to; address += inst.len)
      {
        inst = EyeStep.read(address);
        instList.Add(inst);
      }
      return instList;
    }

    [CompilerGenerated]
    internal static void smethod_0(
      byte x,
      bool constant,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_0 obj2,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_1 obj3)
    {
      string str;
      if (!constant)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].imm8 = x;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].flags |= 16U;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        str = x <= (byte) 127 ? "+" + obj2.p.operands[obj3.c].imm8.ToString("X2") : "-" + (256 - (int) obj2.p.operands[obj3.c].imm8).ToString("X2");
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].disp8 = x;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].flags |= 128U;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        str = obj2.p.operands[obj3.c].disp8.ToString("X2");
      }
      // ISSUE: reference to a compiler-generated field
      obj2.p.data += str;
      // ISSUE: reference to a compiler-generated field
      ++obj2.p.len;
    }

    [CompilerGenerated]
    internal static void smethod_1(
      ushort x,
      bool constant,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_0 obj2,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_1 obj3)
    {
      string str;
      if (!constant)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].imm16 = x;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].flags |= 32U;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        str = x <= (ushort) short.MaxValue ? "+" + obj2.p.operands[obj3.c].imm16.ToString("X4") : "-" + (65536 - (int) obj2.p.operands[obj3.c].imm16).ToString("X4");
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].disp16 = x;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].flags |= 256U;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        str = obj2.p.operands[obj3.c].disp16.ToString("X4");
      }
      // ISSUE: reference to a compiler-generated field
      obj2.p.data += str;
      // ISSUE: reference to a compiler-generated field
      obj2.p.len += 2;
    }

    [CompilerGenerated]
    internal static void smethod_2(
      uint x,
      bool b,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_0 obj2,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_1 obj3)
    {
      string str;
      if (!b)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].imm32 = x;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].flags |= 64U;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        str = x <= (uint) int.MaxValue ? "+" + obj2.p.operands[obj3.c].imm32.ToString("X8") : "-" + ((uint) -(int) obj2.p.operands[obj3.c].imm32).ToString("X8");
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].disp32 = x;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj2.p.operands[obj3.c].flags |= 512U;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        str = obj2.p.operands[obj3.c].disp32.ToString("X8");
      }
      // ISSUE: reference to a compiler-generated field
      obj2.p.data += str;
      // ISSUE: reference to a compiler-generated field
      obj2.p.len += 4;
    }

    [CompilerGenerated]
    internal static void smethod_3(
      [In] byte obj0,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_0 obj1,
      ref EyeStep.\u003C\u003Ec__DisplayClass88_1 c)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      byte x = obj1.p.bytes[++obj1.p.len];
      byte routine_name1 = (byte) EyeStep.longreg(x);
      byte routine_name2 = (byte) EyeStep.finalreg(x);
      if (((int) x + 32) / 32 % 2 == 0 && (int) x % 32 < 8)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj1.p.data += EyeStep.mnemonics.r32_names[(int) obj1.p.operands[c.c].append_reg(routine_name2)];
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        obj1.p.operands[c.c].flags |= 4096U;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (routine_name2 == (byte) 5 && obj1.p.bytes[obj1.p.len - 1] < (byte) 64)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          obj1.p.data += EyeStep.mnemonics.r32_names[(int) obj1.p.operands[c.c].append_reg(routine_name1)];
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          obj1.p.operands[c.c].flags |= 4096U;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          obj1.p.data += EyeStep.mnemonics.r32_names[(int) obj1.p.operands[c.c].append_reg(routine_name2)];
          // ISSUE: reference to a compiler-generated field
          obj1.p.data += "+";
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          obj1.p.data += EyeStep.mnemonics.r32_names[(int) obj1.p.operands[c.c].append_reg(routine_name1)];
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          obj1.p.operands[c.c].flags |= 4096U;
        }
        if ((int) x / 64 > 0)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          obj1.p.operands[c.c].mul = EyeStep.multipliers[(int) x / 64];
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string str = obj1.p.operands[c.c].mul.ToString("X1");
          // ISSUE: reference to a compiler-generated field
          obj1.p.data += "*";
          // ISSUE: reference to a compiler-generated field
          obj1.p.data += str;
        }
      }
      switch (obj0)
      {
        case 0:
          if (routine_name2 != (byte) 5)
            break;
          goto case 4;
        case 1:
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          EyeStep.smethod_0(obj1.p.bytes[obj1.p.len + 1], false, ref obj1, ref c);
          break;
        case 4:
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          EyeStep.smethod_2(BitConverter.ToUInt32(obj1.p.bytes, obj1.p.len + 1), true, ref obj1, ref c);
          break;
      }
    }

    [CompilerGenerated]
    internal static void smethod_4(
      byte x,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_0 obj1,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_1 obj2)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num = obj1.p.address + obj1.p.len;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      obj1.p.operands[obj2.c].rel8 = x;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      obj1.p.data += (num + 1 + (int) obj1.p.operands[obj2.c].rel8).ToString("X8");
      // ISSUE: reference to a compiler-generated field
      ++obj1.p.len;
    }

    [CompilerGenerated]
    internal static void smethod_5(
      ushort int_bytes,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_0 obj1,
      [In] ref EyeStep.\u003C\u003Ec__DisplayClass88_1 obj2)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num = obj1.p.address + obj1.p.len;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      obj1.p.operands[obj2.c].rel16 = int_bytes;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      obj1.p.data += (num + 2 + (int) obj1.p.operands[obj2.c].rel16).ToString("X8");
      // ISSUE: reference to a compiler-generated field
      obj1.p.len += 2;
    }

    [CompilerGenerated]
    internal static void smethod_6(
      uint routine_name,
      ref EyeStep.\u003C\u003Ec__DisplayClass88_0 func,
      params EyeStep.\u003C\u003Ec__DisplayClass88_1 arg_types)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num = func.p.address + func.p.len;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      func.p.operands[arg_types.c].rel32 = routine_name;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      func.p.data += ((long) (num + 4) + (long) func.p.operands[arg_types.c].rel32).ToString("X8");
      // ISSUE: reference to a compiler-generated field
      func.p.len += 4;
    }

    public class mnemonics
    {
      public static string[] r8_names = new string[8]
      {
        "al",
        "cl",
        "dl",
        "bl",
        "ah",
        "ch",
        "dh",
        "bh"
      };
      public static string[] r16_names = new string[8]
      {
        "ax",
        "cx",
        "dx",
        "bx",
        "sp",
        "bp",
        "si",
        "di"
      };
      public static string[] r32_names = new string[8]
      {
        "eax",
        "ecx",
        "edx",
        "ebx",
        "esp",
        "ebp",
        "esi",
        "edi"
      };
      public static string[] r64_names = new string[8]
      {
        "rax",
        "rcx",
        "rdx",
        "rbx",
        "rsp",
        "rbp",
        "rsi",
        "rdi"
      };
      public static string[] xmm_names = new string[8]
      {
        "xmm0",
        "xmm1",
        "xmm2",
        "xmm3",
        "xmm4",
        "xmm5",
        "xmm6",
        "xmm7"
      };
      public static string[] mm_names = new string[8]
      {
        "mm0",
        "mm1",
        "mm2",
        "mm3",
        "mm4",
        "mm5",
        "mm6",
        "mm7"
      };
      public static string[] sreg_names = new string[8]
      {
        "es",
        "cs",
        "ss",
        "ds",
        "fs",
        "gs",
        "hs",
        "is"
      };
      public static string[] dr_names = new string[8]
      {
        "dr0",
        "dr1",
        "dr2",
        "dr3",
        "dr4",
        "dr5",
        "dr6",
        "dr7"
      };
      public static string[] cr_names = new string[8]
      {
        "cr0",
        "cr1",
        "cr2",
        "cr3",
        "cr4",
        "cr5",
        "cr6",
        "cr7"
      };
      public static string[] st_names = new string[8]
      {
        "st(0)",
        "st(1)",
        "st(2)",
        "st(3)",
        "st(4)",
        "st(5)",
        "st(6)",
        "st(7)"
      };
    }

    public struct OP_INFO
    {
      public string code;
      public string opcode_name;
      public OP_TYPES[] operands;
      public string description;

      public OP_INFO(string routine_name, string func, params OP_TYPES[] arg_types, [In] string obj3)
      {
        this.code = routine_name;
        this.opcode_name = func;
        this.operands = arg_types;
        this.description = obj3;
      }
    }

    public class operand
    {
      public uint flags;
      public OP_TYPES opmode;
      public List<byte> reg;
      public byte mul;
      public byte rel8;
      public ushort rel16;
      public uint rel32;
      public byte imm8;
      public ushort imm16;
      public uint imm32;
      public byte disp8;
      public ushort disp16;
      public uint disp32;

      public operand()
      {
        this.reg = new List<byte>();
        this.rel8 = (byte) 0;
        this.rel16 = (ushort) 0;
        this.rel32 = 0U;
        this.imm8 = (byte) 0;
        this.imm16 = (ushort) 0;
        this.imm32 = 0U;
        this.disp8 = (byte) 0;
        this.disp16 = (ushort) 0;
        this.disp32 = 0U;
        this.mul = (byte) 0;
        this.opmode = OP_TYPES.AL;
        this.flags = 0U;
      }

      ~operand()
      {
      }

      public byte append_reg(byte routine_name)
      {
        this.reg.Add(routine_name);
        return routine_name;
      }
    }

    public class inst
    {
      public string data;
      public EyeStep.OP_INFO info;
      public uint flags;
      public int address;
      public byte[] bytes;
      public int len;
      public List<EyeStep.operand> operands;

      public inst()
      {
        this.bytes = new byte[16];
        this.operands = new List<EyeStep.operand>();
        this.operands.Add(new EyeStep.operand());
        this.operands.Add(new EyeStep.operand());
        this.operands.Add(new EyeStep.operand());
        this.operands.Add(new EyeStep.operand());
        this.address = 0;
        this.flags = 0U;
        this.len = 0;
      }

      ~inst() => this.operands.Clear();

      public EyeStep.operand src() => this.operands.Count <= 0 ? new EyeStep.operand() : this.operands[0];

      public EyeStep.operand dest() => this.operands.Count <= 1 ? new EyeStep.operand() : this.operands[1];
    }
  }
}
