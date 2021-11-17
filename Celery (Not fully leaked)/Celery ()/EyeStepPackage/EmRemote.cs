// Decompiled with JetBrains decompiler
// Type: EyeStepPackage.EmRemote
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EyeStepPackage
{
  public class EmRemote
  {
    public static int function_ids;
    private Dictionary<string, EmRemote.RoutineInfo> routines;
    private int remote_loc;
    private int func_id_loc;
    private int args_loc;
    private int ret_loc_small;
    private int ret_loc_large;
    private int funcs_loc;
    private int spoofroutine;
    private int spoofredirect;
    private int veh_watcher;
    private EmRemote.vectored_exception_handler veh_watcher_f;
    public int bp_terminate_thread;
    public byte next_conv = byte.MaxValue;

    public EmRemote()
    {
      this.routines = new Dictionary<string, EmRemote.RoutineInfo>();
      this.remote_loc = 0;
      this.func_id_loc = 0;
      this.ret_loc_small = 0;
      this.ret_loc_large = 0;
      this.args_loc = 0;
      this.funcs_loc = 0;
      this.spoofroutine = 0;
      this.spoofredirect = 0;
    }

    ~EmRemote() => this.Flush();

    private byte[] convert_le(byte[] @object) => new byte[4]
    {
      @object[3],
      @object[2],
      @object[1],
      @object[0]
    };

    public void SetVEH([In] EmRemote.vectored_exception_handler obj0)
    {
      this.veh_watcher_f = obj0;
      this.veh_watcher = imports.VirtualAllocEx(EyeStep.handle, 0, 4096, 12288U, 64U);
      if (this.veh_watcher == 0)
        return;
      this.bp_terminate_thread = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 4096U, 64U);
      if (this.bp_terminate_thread == 0)
        return;
      util.writeInt(this.bp_terminate_thread + 128, imports.GetProcAddress(imports.GetModuleHandle("KERNELBASE.dll"), "GetCurrentThread"));
      util.writeInt(this.bp_terminate_thread + 132, imports.GetProcAddress(imports.GetModuleHandle("KERNEL32.dll"), "TerminateThread"));
      List<byte> byteList1 = new List<byte>();
      byteList1.Add(byte.MaxValue);
      byteList1.Add((byte) 21);
      foreach (byte num in BitConverter.GetBytes(this.bp_terminate_thread + 128))
        byteList1.Add(num);
      byteList1.Add((byte) 106);
      byteList1.Add((byte) 0);
      byteList1.Add((byte) 80);
      byteList1.Add(byte.MaxValue);
      byteList1.Add((byte) 21);
      foreach (byte num in BitConverter.GetBytes(this.bp_terminate_thread + 132))
        byteList1.Add(num);
      byteList1.Add((byte) 139);
      byteList1.Add((byte) 229);
      byteList1.Add((byte) 93);
      byteList1.Add((byte) 194);
      byteList1.Add((byte) 16);
      byteList1.Add((byte) 0);
      util.writeBytes(this.bp_terminate_thread, byteList1.ToArray(), -1);
      this.Add("AddVectoredExceptionHandler", imports.GetProcAddress(imports.GetModuleHandle("ntdll.dll"), "RtlAddVectoredExceptionHandler"), new string[2]
      {
        "int",
        "int"
      });
      int num1 = this.veh_watcher + 1024;
      List<byte> byteList2 = new List<byte>();
      byteList2.Add((byte) 85);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 236);
      byteList2.Add((byte) 81);
      byteList2.Add((byte) 86);
      byteList2.Add((byte) 131);
      byteList2.Add((byte) 236);
      byteList2.Add((byte) 32);
      byteList2.Add((byte) 49);
      byteList2.Add((byte) 201);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 224);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 228);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 232);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 236);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 240);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 244);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 248);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 77);
      byteList2.Add((byte) 252);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 117);
      byteList2.Add((byte) 8);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 184);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 100);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 13);
      byteList2.Add((byte) 48);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 59);
      byteList2.Add((byte) 65);
      byteList2.Add((byte) 8);
      byteList2.Add((byte) 115);
      byteList2.Add((byte) 10);
      byteList2.Add((byte) 51);
      byteList2.Add((byte) 192);
      byteList2.Add((byte) 89);
      byteList2.Add((byte) 94);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 229);
      byteList2.Add((byte) 93);
      byteList2.Add((byte) 194);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 141);
      byteList2.Add((byte) 69);
      byteList2.Add((byte) 224);
      byteList2.Add((byte) 106);
      byteList2.Add((byte) 28);
      byteList2.Add((byte) 80);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add(byte.MaxValue);
      byteList2.Add((byte) 177);
      byteList2.Add((byte) 184);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add(byte.MaxValue);
      byteList2.Add((byte) 21);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 96))
        byteList2.Add(num2);
      util.writeInt(num1 + 96, imports.GetProcAddress(imports.GetModuleHandle("KERNEL32.dll"), "VirtualQuery"));
      byteList2.Add((byte) 247);
      byteList2.Add((byte) 69);
      byteList2.Add((byte) 240);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 16);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 117);
      byteList2.Add((byte) 20);
      byteList2.Add((byte) 246);
      byteList2.Add((byte) 69);
      byteList2.Add((byte) 240);
      byteList2.Add((byte) 1);
      byteList2.Add((byte) 116);
      byteList2.Add((byte) 14);
      byteList2.Add((byte) 246);
      byteList2.Add((byte) 69);
      byteList2.Add((byte) 244);
      byteList2.Add((byte) 1);
      byteList2.Add((byte) 116);
      byteList2.Add((byte) 10);
      byteList2.Add((byte) 51);
      byteList2.Add((byte) 192);
      byteList2.Add((byte) 89);
      byteList2.Add((byte) 94);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 229);
      byteList2.Add((byte) 93);
      byteList2.Add((byte) 194);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 184);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 120);
      byteList2.Add((byte) 253);
      byteList2.Add((byte) 157);
      byteList2.Add((byte) 15);
      byteList2.Add((byte) 49);
      byteList2.Add((byte) 144);
      byteList2.Add((byte) 117);
      byteList2.Add((byte) 10);
      byteList2.Add((byte) 51);
      byteList2.Add((byte) 192);
      byteList2.Add((byte) 89);
      byteList2.Add((byte) 94);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 229);
      byteList2.Add((byte) 93);
      byteList2.Add((byte) 194);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 61);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 64))
        byteList2.Add(num2);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 116);
      byteList2.Add((byte) 30);
      byteList2.Add((byte) 106);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 104);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 260))
        byteList2.Add(num2);
      util.writeString(num1 + 260, "Multi-threaded VEH Not Supported", -1);
      byteList2.Add((byte) 104);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 264))
        byteList2.Add(num2);
      util.writeString(num1 + 320, "More than one thread tried to access the VEH", -1);
      byteList2.Add((byte) 106);
      byteList2.Add((byte) 0);
      byteList2.Add(byte.MaxValue);
      byteList2.Add((byte) 21);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 256))
        byteList2.Add(num2);
      util.writeInt(num1 + 256, imports.GetProcAddress(imports.GetModuleHandle("USER32.dll"), "MessageBoxA"));
      byteList2.Add((byte) 51);
      byteList2.Add((byte) 192);
      byteList2.Add((byte) 89);
      byteList2.Add((byte) 94);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 229);
      byteList2.Add((byte) 93);
      byteList2.Add((byte) 194);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 5);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 64))
        byteList2.Add(num2);
      byteList2.Add((byte) 1);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 6);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 8))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 184);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 12))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 176);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 16))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 172);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 20))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 168);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 24))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 164);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 28))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 196);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 32))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 180);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 36))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 160);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 40))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 70);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 156);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 163);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 44))
        byteList2.Add(num2);
      byteList2.Add((byte) 131);
      byteList2.Add((byte) 61);
      foreach (byte num2 in BitConverter.GetBytes(num1))
        byteList2.Add(num2);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 117);
      byteList2.Add((byte) 31);
      byteList2.Add((byte) 83);
      byteList2.Add((byte) 87);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 61);
      foreach (byte num2 in BitConverter.GetBytes(imports.GetProcAddress(imports.GetModuleHandle("KERNEL32.dll"), "Sleep")))
        byteList2.Add(num2);
      byteList2.Add((byte) 187);
      foreach (byte num2 in BitConverter.GetBytes(num1))
        byteList2.Add(num2);
      byteList2.Add((byte) 15);
      byteList2.Add((byte) 31);
      byteList2.Add((byte) 128);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 106);
      byteList2.Add((byte) 3);
      byteList2.Add(byte.MaxValue);
      byteList2.Add((byte) 215);
      byteList2.Add((byte) 131);
      byteList2.Add((byte) 59);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 116);
      byteList2.Add((byte) 247);
      byteList2.Add((byte) 95);
      byteList2.Add((byte) 91);
      byteList2.Add((byte) 199);
      byteList2.Add((byte) 5);
      foreach (byte num2 in BitConverter.GetBytes(num1))
        byteList2.Add(num2);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 12))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 184);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 16))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 176);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 20))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 172);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 24))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 168);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 28))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 164);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 32))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 196);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 36))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 180);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 40))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 160);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 78);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 44))
        byteList2.Add(num2);
      byteList2.Add((byte) 137);
      byteList2.Add((byte) 129);
      byteList2.Add((byte) 156);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 89);
      byteList2.Add((byte) 94);
      byteList2.Add((byte) 161);
      foreach (byte num2 in BitConverter.GetBytes(num1 + 4))
        byteList2.Add(num2);
      byteList2.Add((byte) 139);
      byteList2.Add((byte) 229);
      byteList2.Add((byte) 93);
      byteList2.Add((byte) 194);
      byteList2.Add((byte) 4);
      byteList2.Add((byte) 0);
      byteList2.Add((byte) 204);
      util.writeBytes(this.veh_watcher, byteList2.ToArray(), -1);
      int num3 = (int) MessageBox.Show("VEH: " + this.veh_watcher.ToString("X8"));
      new Thread(new ThreadStart(this.veh_watcher_thread)).Start();
      this.Call("AddVectoredExceptionHandler", new object[2]
      {
        (object) 1,
        (object) this.veh_watcher
      });
    }

    private void veh_watcher_thread()
    {
      while (this.veh_watcher != 0 && this.veh_watcher_f != null)
      {
        Thread.Sleep(3);
        int address = this.veh_watcher + 1024;
        if (util.readByte(address + 64) > (byte) 0)
        {
          util.writeByte(address + 64, (byte) 0);
          util.writeInt(address + 4, this.veh_watcher_f(ref new pcontext()
          {
            eip = util.readInt(address + 12)
          }));
          util.writeInt(address, 1);
        }
      }
    }

    public void Flush()
    {
      if (this.veh_watcher != 0)
        imports.VirtualFreeEx(EyeStep.handle, this.veh_watcher, 0, 32768U);
      util.placeJmp(this.remote_loc + 6, this.remote_loc + 25);
      Thread.Sleep(1000);
      foreach (KeyValuePair<string, EmRemote.RoutineInfo> routine in this.routines)
        imports.VirtualFreeEx(EyeStep.handle, routine.Value.routine, 0, 32768U);
      imports.VirtualFreeEx(EyeStep.handle, this.remote_loc, 0, 32768U);
    }

    public void Load()
    {
      this.remote_loc = imports.VirtualAllocEx(EyeStep.handle, 0, 2047, 12288U, 64U);
      this.func_id_loc = this.remote_loc + 512;
      this.ret_loc_small = this.remote_loc + 516;
      this.ret_loc_large = this.remote_loc + 520;
      this.args_loc = this.remote_loc + 528;
      this.funcs_loc = this.remote_loc + 680;
      byte[] numArray = new byte[256];
      numArray[0] = (byte) 85;
      numArray[1] = (byte) 139;
      numArray[2] = (byte) 236;
      numArray[3] = (byte) 80;
      numArray[4] = (byte) 86;
      numArray[5] = (byte) 87;
      numArray[6] = (byte) 139;
      numArray[7] = (byte) 61;
      byte[] bytes1 = BitConverter.GetBytes(this.func_id_loc);
      numArray[8] = bytes1[0];
      numArray[9] = bytes1[1];
      numArray[10] = bytes1[2];
      numArray[11] = bytes1[3];
      numArray[12] = (byte) 129;
      numArray[13] = byte.MaxValue;
      numArray[14] = (byte) 0;
      numArray[15] = (byte) 0;
      numArray[16] = (byte) 0;
      numArray[17] = (byte) 0;
      numArray[18] = (byte) 116;
      numArray[19] = (byte) 242;
      numArray[20] = byte.MaxValue;
      numArray[21] = (byte) 37;
      byte[] bytes2 = BitConverter.GetBytes(this.func_id_loc);
      numArray[22] = bytes2[0];
      numArray[23] = bytes2[1];
      numArray[24] = bytes2[2];
      numArray[25] = bytes2[3];
      numArray[26] = (byte) 88;
      numArray[27] = (byte) 94;
      numArray[28] = (byte) 95;
      numArray[29] = (byte) 93;
      numArray[30] = (byte) 194;
      numArray[31] = (byte) 4;
      numArray[32] = (byte) 0;
      util.writeBytes(this.remote_loc, numArray, 33);
      int lpThreadId = 0;
      imports.CreateRemoteThread(EyeStep.handle, 0, 0U, this.remote_loc, 0, 0U, out lpThreadId);
    }

    public void PushConvention(string data)
    {
      byte num = 0;
      foreach (string conv in util.convs)
      {
        if (!(data == conv))
        {
          ++num;
        }
        else
        {
          this.next_conv = num;
          break;
        }
      }
    }

    public void Add(string data, int callback, string[] @object)
    {
      byte num1 = this.next_conv;
      if (this.next_conv == byte.MaxValue)
        num1 = util.getConvention(callback, @object.Length);
      else
        this.next_conv = byte.MaxValue;
      int address = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 4096U, 64U);
      this.routines[data] = new EmRemote.RoutineInfo(address, num1);
      byte[] numArray1 = new byte[256];
      int num2 = 0;
      int num3 = 0;
      if (num1 == (byte) 3 || num1 == (byte) 2)
      {
        byte[] numArray2 = numArray1;
        int index1 = num2;
        int num4 = index1 + 1;
        numArray2[index1] = (byte) 139;
        byte[] numArray3 = numArray1;
        int index2 = num4;
        int num5 = index2 + 1;
        numArray3[index2] = (byte) 13;
        byte[] bytes1 = BitConverter.GetBytes(this.args_loc + 8 * num3++);
        byte[] numArray4 = numArray1;
        int index3 = num5;
        int num6 = index3 + 1;
        int num7 = (int) bytes1[0];
        numArray4[index3] = (byte) num7;
        byte[] numArray5 = numArray1;
        int index4 = num6;
        int num8 = index4 + 1;
        int num9 = (int) bytes1[1];
        numArray5[index4] = (byte) num9;
        byte[] numArray6 = numArray1;
        int index5 = num8;
        int num10 = index5 + 1;
        int num11 = (int) bytes1[2];
        numArray6[index5] = (byte) num11;
        byte[] numArray7 = numArray1;
        int index6 = num10;
        num2 = index6 + 1;
        int num12 = (int) bytes1[3];
        numArray7[index6] = (byte) num12;
        if (num1 == (byte) 2)
        {
          byte[] numArray8 = numArray1;
          int index7 = num2;
          int num13 = index7 + 1;
          numArray8[index7] = (byte) 139;
          byte[] numArray9 = numArray1;
          int index8 = num13;
          int num14 = index8 + 1;
          numArray9[index8] = (byte) 21;
          byte[] bytes2 = BitConverter.GetBytes(this.args_loc + 8 * num3++);
          byte[] numArray10 = numArray1;
          int index9 = num14;
          int num15 = index9 + 1;
          int num16 = (int) bytes2[0];
          numArray10[index9] = (byte) num16;
          byte[] numArray11 = numArray1;
          int index10 = num15;
          int num17 = index10 + 1;
          int num18 = (int) bytes2[1];
          numArray11[index10] = (byte) num18;
          byte[] numArray12 = numArray1;
          int index11 = num17;
          int num19 = index11 + 1;
          int num20 = (int) bytes2[2];
          numArray12[index11] = (byte) num20;
          byte[] numArray13 = numArray1;
          int index12 = num19;
          num2 = index12 + 1;
          int num21 = (int) bytes2[3];
          numArray13[index12] = (byte) num21;
        }
      }
      int index13 = @object.Length - 1;
      while (num3 < @object.Length)
      {
        if (@object[index13] == "double")
        {
          byte[] numArray2 = numArray1;
          int index1 = num2;
          int num4 = index1 + 1;
          numArray2[index1] = (byte) 15;
          byte[] numArray3 = numArray1;
          int index2 = num4;
          int num5 = index2 + 1;
          numArray3[index2] = (byte) 16;
          byte[] numArray4 = numArray1;
          int index3 = num5;
          int num6 = index3 + 1;
          numArray4[index3] = (byte) 5;
          byte[] bytes = BitConverter.GetBytes(this.args_loc + 8 * num3++);
          byte[] numArray5 = numArray1;
          int index4 = num6;
          int num7 = index4 + 1;
          int num8 = (int) bytes[0];
          numArray5[index4] = (byte) num8;
          byte[] numArray6 = numArray1;
          int index5 = num7;
          int num9 = index5 + 1;
          int num10 = (int) bytes[1];
          numArray6[index5] = (byte) num10;
          byte[] numArray7 = numArray1;
          int index6 = num9;
          int num11 = index6 + 1;
          int num12 = (int) bytes[2];
          numArray7[index6] = (byte) num12;
          byte[] numArray8 = numArray1;
          int index7 = num11;
          int num13 = index7 + 1;
          int num14 = (int) bytes[3];
          numArray8[index7] = (byte) num14;
          byte[] numArray9 = numArray1;
          int index8 = num13;
          int num15 = index8 + 1;
          numArray9[index8] = (byte) 242;
          byte[] numArray10 = numArray1;
          int index9 = num15;
          int num16 = index9 + 1;
          numArray10[index9] = (byte) 15;
          byte[] numArray11 = numArray1;
          int index10 = num16;
          int num17 = index10 + 1;
          numArray11[index10] = (byte) 17;
          byte[] numArray12 = numArray1;
          int index11 = num17;
          int num18 = index11 + 1;
          numArray12[index11] = (byte) 4;
          byte[] numArray13 = numArray1;
          int index12 = num18;
          num2 = index12 + 1;
          numArray13[index12] = (byte) 36;
        }
        else
        {
          byte[] numArray2 = numArray1;
          int index1 = num2;
          int num4 = index1 + 1;
          numArray2[index1] = byte.MaxValue;
          byte[] numArray3 = numArray1;
          int index2 = num4;
          int num5 = index2 + 1;
          numArray3[index2] = (byte) 53;
          byte[] bytes = BitConverter.GetBytes(this.args_loc + 8 * num3++);
          byte[] numArray4 = numArray1;
          int index3 = num5;
          int num6 = index3 + 1;
          int num7 = (int) bytes[0];
          numArray4[index3] = (byte) num7;
          byte[] numArray5 = numArray1;
          int index4 = num6;
          int num8 = index4 + 1;
          int num9 = (int) bytes[1];
          numArray5[index4] = (byte) num9;
          byte[] numArray6 = numArray1;
          int index5 = num8;
          int num10 = index5 + 1;
          int num11 = (int) bytes[2];
          numArray6[index5] = (byte) num11;
          byte[] numArray7 = numArray1;
          int index6 = num10;
          num2 = index6 + 1;
          int num12 = (int) bytes[3];
          numArray7[index6] = (byte) num12;
        }
        --index13;
      }
      byte[] numArray14 = numArray1;
      int index14 = num2;
      int num22 = index14 + 1;
      numArray14[index14] = (byte) 191;
      byte[] bytes3 = BitConverter.GetBytes(callback);
      byte[] numArray15 = numArray1;
      int index15 = num22;
      int num23 = index15 + 1;
      int num24 = (int) bytes3[0];
      numArray15[index15] = (byte) num24;
      byte[] numArray16 = numArray1;
      int index16 = num23;
      int num25 = index16 + 1;
      int num26 = (int) bytes3[1];
      numArray16[index16] = (byte) num26;
      byte[] numArray17 = numArray1;
      int index17 = num25;
      int num27 = index17 + 1;
      int num28 = (int) bytes3[2];
      numArray17[index17] = (byte) num28;
      byte[] numArray18 = numArray1;
      int index18 = num27;
      int num29 = index18 + 1;
      int num30 = (int) bytes3[3];
      numArray18[index18] = (byte) num30;
      byte[] numArray19 = numArray1;
      int index19 = num29;
      int num31 = index19 + 1;
      numArray19[index19] = byte.MaxValue;
      byte[] numArray20 = numArray1;
      int index20 = num31;
      int num32 = index20 + 1;
      numArray20[index20] = (byte) 215;
      byte[] numArray21 = numArray1;
      int index21 = num32;
      int num33 = index21 + 1;
      numArray21[index21] = (byte) 163;
      byte[] bytes4 = BitConverter.GetBytes(this.ret_loc_small);
      byte[] numArray22 = numArray1;
      int index22 = num33;
      int num34 = index22 + 1;
      int num35 = (int) bytes4[0];
      numArray22[index22] = (byte) num35;
      byte[] numArray23 = numArray1;
      int index23 = num34;
      int num36 = index23 + 1;
      int num37 = (int) bytes4[1];
      numArray23[index23] = (byte) num37;
      byte[] numArray24 = numArray1;
      int index24 = num36;
      int num38 = index24 + 1;
      int num39 = (int) bytes4[2];
      numArray24[index24] = (byte) num39;
      byte[] numArray25 = numArray1;
      int index25 = num38;
      int num40 = index25 + 1;
      int num41 = (int) bytes4[3];
      numArray25[index25] = (byte) num41;
      byte[] numArray26 = numArray1;
      int index26 = num40;
      int num42 = index26 + 1;
      numArray26[index26] = (byte) 243;
      byte[] numArray27 = numArray1;
      int index27 = num42;
      int num43 = index27 + 1;
      numArray27[index27] = (byte) 15;
      byte[] numArray28 = numArray1;
      int index28 = num43;
      int num44 = index28 + 1;
      numArray28[index28] = (byte) 126;
      byte[] numArray29 = numArray1;
      int index29 = num44;
      int num45 = index29 + 1;
      numArray29[index29] = (byte) 4;
      byte[] numArray30 = numArray1;
      int index30 = num45;
      int num46 = index30 + 1;
      numArray30[index30] = (byte) 36;
      byte[] numArray31 = numArray1;
      int index31 = num46;
      int num47 = index31 + 1;
      numArray31[index31] = (byte) 102;
      byte[] numArray32 = numArray1;
      int index32 = num47;
      int num48 = index32 + 1;
      numArray32[index32] = (byte) 15;
      byte[] numArray33 = numArray1;
      int index33 = num48;
      int num49 = index33 + 1;
      numArray33[index33] = (byte) 214;
      byte[] numArray34 = numArray1;
      int index34 = num49;
      int num50 = index34 + 1;
      numArray34[index34] = (byte) 5;
      byte[] bytes5 = BitConverter.GetBytes(this.ret_loc_large);
      byte[] numArray35 = numArray1;
      int index35 = num50;
      int num51 = index35 + 1;
      int num52 = (int) bytes5[0];
      numArray35[index35] = (byte) num52;
      byte[] numArray36 = numArray1;
      int index36 = num51;
      int num53 = index36 + 1;
      int num54 = (int) bytes5[1];
      numArray36[index36] = (byte) num54;
      byte[] numArray37 = numArray1;
      int index37 = num53;
      int num55 = index37 + 1;
      int num56 = (int) bytes5[2];
      numArray37[index37] = (byte) num56;
      byte[] numArray38 = numArray1;
      int index38 = num55;
      int num57 = index38 + 1;
      int num58 = (int) bytes5[3];
      numArray38[index38] = (byte) num58;
      if (num1 == (byte) 0)
      {
        byte[] numArray2 = numArray1;
        int index1 = num57;
        int num4 = index1 + 1;
        numArray2[index1] = (byte) 129;
        byte[] numArray3 = numArray1;
        int index2 = num4;
        int num5 = index2 + 1;
        numArray3[index2] = (byte) 196;
        byte[] bytes1 = BitConverter.GetBytes(@object.Length * 4);
        byte[] numArray4 = numArray1;
        int index3 = num5;
        int num6 = index3 + 1;
        int num7 = (int) bytes1[0];
        numArray4[index3] = (byte) num7;
        byte[] numArray5 = numArray1;
        int index4 = num6;
        int num8 = index4 + 1;
        int num9 = (int) bytes1[1];
        numArray5[index4] = (byte) num9;
        byte[] numArray6 = numArray1;
        int index5 = num8;
        int num10 = index5 + 1;
        int num11 = (int) bytes1[2];
        numArray6[index5] = (byte) num11;
        byte[] numArray7 = numArray1;
        int index6 = num10;
        num57 = index6 + 1;
        int num12 = (int) bytes1[3];
        numArray7[index6] = (byte) num12;
      }
      byte[] numArray39 = numArray1;
      int index39 = num57;
      int num59 = index39 + 1;
      numArray39[index39] = (byte) 199;
      byte[] numArray40 = numArray1;
      int index40 = num59;
      int num60 = index40 + 1;
      numArray40[index40] = (byte) 5;
      byte[] bytes6 = BitConverter.GetBytes(this.func_id_loc);
      byte[] numArray41 = numArray1;
      int index41 = num60;
      int num61 = index41 + 1;
      int num62 = (int) bytes6[0];
      numArray41[index41] = (byte) num62;
      byte[] numArray42 = numArray1;
      int index42 = num61;
      int num63 = index42 + 1;
      int num64 = (int) bytes6[1];
      numArray42[index42] = (byte) num64;
      byte[] numArray43 = numArray1;
      int index43 = num63;
      int num65 = index43 + 1;
      int num66 = (int) bytes6[2];
      numArray43[index43] = (byte) num66;
      byte[] numArray44 = numArray1;
      int index44 = num65;
      int num67 = index44 + 1;
      int num68 = (int) bytes6[3];
      numArray44[index44] = (byte) num68;
      byte[] numArray45 = numArray1;
      int index45 = num67;
      int num69 = index45 + 1;
      numArray45[index45] = (byte) 0;
      byte[] numArray46 = numArray1;
      int index46 = num69;
      int num70 = index46 + 1;
      numArray46[index46] = (byte) 0;
      byte[] numArray47 = numArray1;
      int index47 = num70;
      int num71 = index47 + 1;
      numArray47[index47] = (byte) 0;
      byte[] numArray48 = numArray1;
      int index48 = num71;
      int num72 = index48 + 1;
      numArray48[index48] = (byte) 0;
      util.writeBytes(address, numArray1, num72);
      util.placeJmp(address + num72, this.remote_loc + 6);
      util.writeInt(this.funcs_loc + this.routines.Count * 4, address);
    }

    public void AddProtected(string data, int result, [In] string[] obj2)
    {
      if (this.spoofredirect == 0 || this.spoofroutine == 0)
      {
        List<int> source = scanner.scan(".text", "558BEC5DFF25????????CC", 1, 0, (scanner.scancheck[]) null);
        if (source.Count == 0)
        {
          int num = (int) MessageBox.Show("[EyeStep -> Fatal Error] Retcheck scan fail");
        }
        this.spoofroutine = source.First<int>() + 4;
        this.spoofredirect = util.readInt(this.spoofroutine + 2);
      }
      byte convention = util.getConvention(result, obj2.Length);
      int address = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 12288U, 64U);
      if (util.isPrologue(result))
        result += 3;
      this.routines[data] = new EmRemote.RoutineInfo(address, convention);
      byte[] numArray1 = new byte[256];
      int num1 = 0;
      int num2 = 0;
      if (convention == (byte) 3 || convention == (byte) 2)
      {
        byte[] numArray2 = numArray1;
        int index1 = num1;
        int num3 = index1 + 1;
        numArray2[index1] = (byte) 139;
        byte[] numArray3 = numArray1;
        int index2 = num3;
        int num4 = index2 + 1;
        numArray3[index2] = (byte) 13;
        byte[] bytes1 = BitConverter.GetBytes(this.args_loc + 8 * num2++);
        byte[] numArray4 = numArray1;
        int index3 = num4;
        int num5 = index3 + 1;
        int num6 = (int) bytes1[0];
        numArray4[index3] = (byte) num6;
        byte[] numArray5 = numArray1;
        int index4 = num5;
        int num7 = index4 + 1;
        int num8 = (int) bytes1[1];
        numArray5[index4] = (byte) num8;
        byte[] numArray6 = numArray1;
        int index5 = num7;
        int num9 = index5 + 1;
        int num10 = (int) bytes1[2];
        numArray6[index5] = (byte) num10;
        byte[] numArray7 = numArray1;
        int index6 = num9;
        num1 = index6 + 1;
        int num11 = (int) bytes1[3];
        numArray7[index6] = (byte) num11;
        if (convention == (byte) 2)
        {
          byte[] numArray8 = numArray1;
          int index7 = num1;
          int num12 = index7 + 1;
          numArray8[index7] = (byte) 139;
          byte[] numArray9 = numArray1;
          int index8 = num12;
          int num13 = index8 + 1;
          numArray9[index8] = (byte) 21;
          byte[] bytes2 = BitConverter.GetBytes(this.args_loc + 8 * num2++);
          byte[] numArray10 = numArray1;
          int index9 = num13;
          int num14 = index9 + 1;
          int num15 = (int) bytes2[0];
          numArray10[index9] = (byte) num15;
          byte[] numArray11 = numArray1;
          int index10 = num14;
          int num16 = index10 + 1;
          int num17 = (int) bytes2[1];
          numArray11[index10] = (byte) num17;
          byte[] numArray12 = numArray1;
          int index11 = num16;
          int num18 = index11 + 1;
          int num19 = (int) bytes2[2];
          numArray12[index11] = (byte) num19;
          byte[] numArray13 = numArray1;
          int index12 = num18;
          num1 = index12 + 1;
          int num20 = (int) bytes2[3];
          numArray13[index12] = (byte) num20;
        }
      }
      int index13 = obj2.Length - 1;
      while (num2 < obj2.Length)
      {
        if (obj2[index13] == "double")
        {
          byte[] numArray2 = numArray1;
          int index1 = num1;
          int num3 = index1 + 1;
          numArray2[index1] = (byte) 15;
          byte[] numArray3 = numArray1;
          int index2 = num3;
          int num4 = index2 + 1;
          numArray3[index2] = (byte) 16;
          byte[] numArray4 = numArray1;
          int index3 = num4;
          int num5 = index3 + 1;
          numArray4[index3] = (byte) 5;
          byte[] bytes = BitConverter.GetBytes(this.args_loc + 8 * num2++);
          byte[] numArray5 = numArray1;
          int index4 = num5;
          int num6 = index4 + 1;
          int num7 = (int) bytes[0];
          numArray5[index4] = (byte) num7;
          byte[] numArray6 = numArray1;
          int index5 = num6;
          int num8 = index5 + 1;
          int num9 = (int) bytes[1];
          numArray6[index5] = (byte) num9;
          byte[] numArray7 = numArray1;
          int index6 = num8;
          int num10 = index6 + 1;
          int num11 = (int) bytes[2];
          numArray7[index6] = (byte) num11;
          byte[] numArray8 = numArray1;
          int index7 = num10;
          int num12 = index7 + 1;
          int num13 = (int) bytes[3];
          numArray8[index7] = (byte) num13;
          byte[] numArray9 = numArray1;
          int index8 = num12;
          int num14 = index8 + 1;
          numArray9[index8] = (byte) 242;
          byte[] numArray10 = numArray1;
          int index9 = num14;
          int num15 = index9 + 1;
          numArray10[index9] = (byte) 15;
          byte[] numArray11 = numArray1;
          int index10 = num15;
          int num16 = index10 + 1;
          numArray11[index10] = (byte) 17;
          byte[] numArray12 = numArray1;
          int index11 = num16;
          int num17 = index11 + 1;
          numArray12[index11] = (byte) 4;
          byte[] numArray13 = numArray1;
          int index12 = num17;
          num1 = index12 + 1;
          numArray13[index12] = (byte) 36;
        }
        else
        {
          byte[] numArray2 = numArray1;
          int index1 = num1;
          int num3 = index1 + 1;
          numArray2[index1] = byte.MaxValue;
          byte[] numArray3 = numArray1;
          int index2 = num3;
          int num4 = index2 + 1;
          numArray3[index2] = (byte) 53;
          byte[] bytes = BitConverter.GetBytes(this.args_loc + 8 * num2++);
          byte[] numArray4 = numArray1;
          int index3 = num4;
          int num5 = index3 + 1;
          int num6 = (int) bytes[0];
          numArray4[index3] = (byte) num6;
          byte[] numArray5 = numArray1;
          int index4 = num5;
          int num7 = index4 + 1;
          int num8 = (int) bytes[1];
          numArray5[index4] = (byte) num8;
          byte[] numArray6 = numArray1;
          int index5 = num7;
          int num9 = index5 + 1;
          int num10 = (int) bytes[2];
          numArray6[index5] = (byte) num10;
          byte[] numArray7 = numArray1;
          int index6 = num9;
          num1 = index6 + 1;
          int num11 = (int) bytes[3];
          numArray7[index6] = (byte) num11;
        }
        --index13;
      }
      byte[] numArray14 = numArray1;
      int index14 = num1;
      int num21 = index14 + 1;
      numArray14[index14] = (byte) 232;
      byte[] numArray15 = numArray1;
      int index15 = num21;
      int num22 = index15 + 1;
      numArray15[index15] = (byte) 0;
      byte[] numArray16 = numArray1;
      int index16 = num22;
      int num23 = index16 + 1;
      numArray16[index16] = (byte) 0;
      byte[] numArray17 = numArray1;
      int index17 = num23;
      int num24 = index17 + 1;
      numArray17[index17] = (byte) 0;
      byte[] numArray18 = numArray1;
      int index18 = num24;
      int num25 = index18 + 1;
      numArray18[index18] = (byte) 0;
      int num26 = (int) util.readByte(result - 3) % 8;
      for (int index1 = 0; index1 < 3; ++index1)
        numArray1[num25++] = util.readByte(result - 3 + index1);
      byte[] numArray19 = numArray1;
      int index19 = num25;
      int num27 = index19 + 1;
      numArray19[index19] = (byte) 139;
      byte[] numArray20 = numArray1;
      int index20 = num27;
      int num28 = index20 + 1;
      int num29 = (int) (byte) (120 + num26);
      numArray20[index20] = (byte) num29;
      byte[] numArray21 = numArray1;
      int index21 = num28;
      int num30 = index21 + 1;
      numArray21[index21] = (byte) 4;
      byte[] numArray22 = numArray1;
      int index22 = num30;
      int num31 = index22 + 1;
      numArray22[index22] = (byte) 129;
      byte[] numArray23 = numArray1;
      int index23 = num31;
      int num32 = index23 + 1;
      numArray23[index23] = (byte) 199;
      byte[] numArray24 = numArray1;
      int index24 = num32;
      int num33 = index24 + 1;
      numArray24[index24] = (byte) 33;
      byte[] numArray25 = numArray1;
      int index25 = num33;
      int num34 = index25 + 1;
      numArray25[index25] = (byte) 0;
      byte[] numArray26 = numArray1;
      int index26 = num34;
      int num35 = index26 + 1;
      numArray26[index26] = (byte) 0;
      byte[] numArray27 = numArray1;
      int index27 = num35;
      int num36 = index27 + 1;
      numArray27[index27] = (byte) 0;
      byte[] numArray28 = numArray1;
      int index28 = num36;
      int num37 = index28 + 1;
      numArray28[index28] = (byte) 137;
      byte[] numArray29 = numArray1;
      int index29 = num37;
      int num38 = index29 + 1;
      numArray29[index29] = (byte) 61;
      byte[] bytes3 = BitConverter.GetBytes(this.spoofredirect);
      byte[] numArray30 = numArray1;
      int index30 = num38;
      int num39 = index30 + 1;
      int num40 = (int) bytes3[0];
      numArray30[index30] = (byte) num40;
      byte[] numArray31 = numArray1;
      int index31 = num39;
      int num41 = index31 + 1;
      int num42 = (int) bytes3[1];
      numArray31[index31] = (byte) num42;
      byte[] numArray32 = numArray1;
      int index32 = num41;
      int num43 = index32 + 1;
      int num44 = (int) bytes3[2];
      numArray32[index32] = (byte) num44;
      byte[] numArray33 = numArray1;
      int index33 = num43;
      int num45 = index33 + 1;
      int num46 = (int) bytes3[3];
      numArray33[index33] = (byte) num46;
      byte[] numArray34 = numArray1;
      int index34 = num45;
      int num47 = index34 + 1;
      numArray34[index34] = (byte) 191;
      byte[] bytes4 = BitConverter.GetBytes(this.spoofroutine);
      byte[] numArray35 = numArray1;
      int index35 = num47;
      int num48 = index35 + 1;
      int num49 = (int) bytes4[0];
      numArray35[index35] = (byte) num49;
      byte[] numArray36 = numArray1;
      int index36 = num48;
      int num50 = index36 + 1;
      int num51 = (int) bytes4[1];
      numArray36[index36] = (byte) num51;
      byte[] numArray37 = numArray1;
      int index37 = num50;
      int num52 = index37 + 1;
      int num53 = (int) bytes4[2];
      numArray37[index37] = (byte) num53;
      byte[] numArray38 = numArray1;
      int index38 = num52;
      int num54 = index38 + 1;
      int num55 = (int) bytes4[3];
      numArray38[index38] = (byte) num55;
      byte[] numArray39 = numArray1;
      int index39 = num54;
      int num56 = index39 + 1;
      numArray39[index39] = (byte) 137;
      byte[] numArray40 = numArray1;
      int index40 = num56;
      int num57 = index40 + 1;
      int num58 = (int) (byte) (120 + num26);
      numArray40[index40] = (byte) num58;
      byte[] numArray41 = numArray1;
      int index41 = num57;
      int num59 = index41 + 1;
      numArray41[index41] = (byte) 4;
      byte[] numArray42 = numArray1;
      int index42 = num59;
      int num60 = index42 + 1;
      numArray42[index42] = (byte) 191;
      byte[] bytes5 = BitConverter.GetBytes(result);
      byte[] numArray43 = numArray1;
      int index43 = num60;
      int num61 = index43 + 1;
      int num62 = (int) bytes5[0];
      numArray43[index43] = (byte) num62;
      byte[] numArray44 = numArray1;
      int index44 = num61;
      int num63 = index44 + 1;
      int num64 = (int) bytes5[1];
      numArray44[index44] = (byte) num64;
      byte[] numArray45 = numArray1;
      int index45 = num63;
      int num65 = index45 + 1;
      int num66 = (int) bytes5[2];
      numArray45[index45] = (byte) num66;
      byte[] numArray46 = numArray1;
      int index46 = num65;
      int num67 = index46 + 1;
      int num68 = (int) bytes5[3];
      numArray46[index46] = (byte) num68;
      byte[] numArray47 = numArray1;
      int index47 = num67;
      int num69 = index47 + 1;
      numArray47[index47] = byte.MaxValue;
      byte[] numArray48 = numArray1;
      int index48 = num69;
      int num70 = index48 + 1;
      numArray48[index48] = (byte) 231;
      byte[] numArray49 = numArray1;
      int index49 = num70;
      int num71 = index49 + 1;
      numArray49[index49] = (byte) 163;
      byte[] bytes6 = BitConverter.GetBytes(this.ret_loc_small);
      byte[] numArray50 = numArray1;
      int index50 = num71;
      int num72 = index50 + 1;
      int num73 = (int) bytes6[0];
      numArray50[index50] = (byte) num73;
      byte[] numArray51 = numArray1;
      int index51 = num72;
      int num74 = index51 + 1;
      int num75 = (int) bytes6[1];
      numArray51[index51] = (byte) num75;
      byte[] numArray52 = numArray1;
      int index52 = num74;
      int num76 = index52 + 1;
      int num77 = (int) bytes6[2];
      numArray52[index52] = (byte) num77;
      byte[] numArray53 = numArray1;
      int index53 = num76;
      int num78 = index53 + 1;
      int num79 = (int) bytes6[3];
      numArray53[index53] = (byte) num79;
      byte[] numArray54 = numArray1;
      int index54 = num78;
      int num80 = index54 + 1;
      numArray54[index54] = (byte) 243;
      byte[] numArray55 = numArray1;
      int index55 = num80;
      int num81 = index55 + 1;
      numArray55[index55] = (byte) 15;
      byte[] numArray56 = numArray1;
      int index56 = num81;
      int num82 = index56 + 1;
      numArray56[index56] = (byte) 126;
      byte[] numArray57 = numArray1;
      int index57 = num82;
      int num83 = index57 + 1;
      numArray57[index57] = (byte) 4;
      byte[] numArray58 = numArray1;
      int index58 = num83;
      int num84 = index58 + 1;
      numArray58[index58] = (byte) 36;
      byte[] numArray59 = numArray1;
      int index59 = num84;
      int num85 = index59 + 1;
      numArray59[index59] = (byte) 102;
      byte[] numArray60 = numArray1;
      int index60 = num85;
      int num86 = index60 + 1;
      numArray60[index60] = (byte) 15;
      byte[] numArray61 = numArray1;
      int index61 = num86;
      int num87 = index61 + 1;
      numArray61[index61] = (byte) 214;
      byte[] numArray62 = numArray1;
      int index62 = num87;
      int num88 = index62 + 1;
      numArray62[index62] = (byte) 5;
      byte[] bytes7 = BitConverter.GetBytes(this.ret_loc_large);
      byte[] numArray63 = numArray1;
      int index63 = num88;
      int num89 = index63 + 1;
      int num90 = (int) bytes7[0];
      numArray63[index63] = (byte) num90;
      byte[] numArray64 = numArray1;
      int index64 = num89;
      int num91 = index64 + 1;
      int num92 = (int) bytes7[1];
      numArray64[index64] = (byte) num92;
      byte[] numArray65 = numArray1;
      int index65 = num91;
      int num93 = index65 + 1;
      int num94 = (int) bytes7[2];
      numArray65[index65] = (byte) num94;
      byte[] numArray66 = numArray1;
      int index66 = num93;
      int num95 = index66 + 1;
      int num96 = (int) bytes7[3];
      numArray66[index66] = (byte) num96;
      if (convention == (byte) 0)
      {
        byte[] numArray2 = numArray1;
        int index1 = num95;
        int num3 = index1 + 1;
        numArray2[index1] = (byte) 129;
        byte[] numArray3 = numArray1;
        int index2 = num3;
        int num4 = index2 + 1;
        numArray3[index2] = (byte) 196;
        byte[] bytes1 = BitConverter.GetBytes(obj2.Length * 4);
        byte[] numArray4 = numArray1;
        int index3 = num4;
        int num5 = index3 + 1;
        int num6 = (int) bytes1[0];
        numArray4[index3] = (byte) num6;
        byte[] numArray5 = numArray1;
        int index4 = num5;
        int num7 = index4 + 1;
        int num8 = (int) bytes1[1];
        numArray5[index4] = (byte) num8;
        byte[] numArray6 = numArray1;
        int index5 = num7;
        int num9 = index5 + 1;
        int num10 = (int) bytes1[2];
        numArray6[index5] = (byte) num10;
        byte[] numArray7 = numArray1;
        int index6 = num9;
        num95 = index6 + 1;
        int num11 = (int) bytes1[3];
        numArray7[index6] = (byte) num11;
      }
      byte[] numArray67 = numArray1;
      int index67 = num95;
      int num97 = index67 + 1;
      numArray67[index67] = (byte) 199;
      byte[] numArray68 = numArray1;
      int index68 = num97;
      int num98 = index68 + 1;
      numArray68[index68] = (byte) 5;
      byte[] bytes8 = BitConverter.GetBytes(this.func_id_loc);
      byte[] numArray69 = numArray1;
      int index69 = num98;
      int num99 = index69 + 1;
      int num100 = (int) bytes8[0];
      numArray69[index69] = (byte) num100;
      byte[] numArray70 = numArray1;
      int index70 = num99;
      int num101 = index70 + 1;
      int num102 = (int) bytes8[1];
      numArray70[index70] = (byte) num102;
      byte[] numArray71 = numArray1;
      int index71 = num101;
      int num103 = index71 + 1;
      int num104 = (int) bytes8[2];
      numArray71[index71] = (byte) num104;
      byte[] numArray72 = numArray1;
      int index72 = num103;
      int num105 = index72 + 1;
      int num106 = (int) bytes8[3];
      numArray72[index72] = (byte) num106;
      byte[] numArray73 = numArray1;
      int index73 = num105;
      int num107 = index73 + 1;
      numArray73[index73] = (byte) 0;
      byte[] numArray74 = numArray1;
      int index74 = num107;
      int num108 = index74 + 1;
      numArray74[index74] = (byte) 0;
      byte[] numArray75 = numArray1;
      int index75 = num108;
      int num109 = index75 + 1;
      numArray75[index75] = (byte) 0;
      byte[] numArray76 = numArray1;
      int index76 = num109;
      int num110 = index76 + 1;
      numArray76[index76] = (byte) 0;
      util.writeBytes(address, numArray1, num110);
      util.placeJmp(address + num110, this.remote_loc + 6);
      util.writeInt(this.funcs_loc + this.routines.Count * 4, address);
    }

    public Tuple<int, long> Call(string address)
    {
      int routine = this.routines[address].routine;
      List<KeyValuePair<int, int>> keyValuePairList = new List<KeyValuePair<int, int>>();
      util.writeInt(this.func_id_loc, routine);
      while (util.readInt(this.func_id_loc) != 0)
        Thread.Sleep(1);
      foreach (KeyValuePair<int, int> keyValuePair in keyValuePairList)
      {
        byte[] numArray = new byte[keyValuePair.Value];
        for (int index = 0; index < keyValuePair.Value; ++index)
          numArray[index] = (byte) 0;
        util.writeBytes(keyValuePair.Key, numArray, keyValuePair.Value);
      }
      return new Tuple<int, long>(util.readInt(this.ret_loc_small), (long) util.readQword(this.ret_loc_large));
    }

    public Tuple<int, long> Call([In] string obj0, object[] protect)
    {
      EmRemote.RoutineInfo routine1 = this.routines[obj0];
      int routine2 = routine1.routine;
      byte conv = routine1.conv;
      List<KeyValuePair<int, int>> keyValuePairList = new List<KeyValuePair<int, int>>();
      if (protect.Length != 0)
      {
        for (int index = 0; index < protect.Length; ++index)
        {
          object obj = conv != (byte) 3 || index != 0 ? (conv != (byte) 3 || index >= 2 ? protect[protect.Length - 1 - index] : protect[index]) : protect[index];
          if (obj != null)
          {
            FunctionArg functionArg = new FunctionArg(0);
            if (obj is string)
              functionArg = new FunctionArg((string) obj);
            else if (!(obj is ulong) && !(obj is double) && !(obj is Decimal))
            {
              if (obj is int || obj is uint || (obj is short || obj is ushort) || (obj is byte || obj is char))
                functionArg = new FunctionArg((int) obj);
            }
            else
              functionArg = new FunctionArg((double) obj);
            if (functionArg.type == "string")
            {
              int length = functionArg.str.Length;
              functionArg.small = this.remote_loc + 1024 + 256 * keyValuePairList.Count;
              util.writeBytes(functionArg.small, Encoding.ASCII.GetBytes(functionArg.str), -1);
              util.writeInt(functionArg.small + length + 4 + length % 4, length);
              keyValuePairList.Add(new KeyValuePair<int, int>(functionArg.small, length));
              util.writeInt(this.args_loc + index * 8, functionArg.small);
            }
            else if (functionArg.type == "smallvalue")
              util.writeInt(this.args_loc + index * 8, functionArg.small);
            else if (functionArg.type == "largevalue")
              util.writeDouble(this.args_loc + index * 8, functionArg.large);
          }
        }
      }
      util.writeInt(this.func_id_loc, routine2);
      while (util.readInt(this.func_id_loc) != 0)
        Thread.Sleep(1);
      foreach (KeyValuePair<int, int> keyValuePair in keyValuePairList)
      {
        byte[] numArray = new byte[keyValuePair.Value];
        for (int index = 0; index < keyValuePair.Value; ++index)
          numArray[index] = (byte) 0;
        util.writeBytes(keyValuePair.Key, numArray, keyValuePair.Value);
      }
      return new Tuple<int, long>(util.readInt(this.ret_loc_small), (long) util.readQword(this.ret_loc_large));
    }

    private struct RoutineInfo
    {
      public int routine;
      public byte conv;
      public int id;

      public RoutineInfo(int address, [In] byte obj1)
      {
        this.routine = address;
        this.conv = obj1;
        this.id = EmRemote.function_ids++;
      }
    }

    public delegate int vectored_exception_handler([In] ref pcontext obj0);
  }
}
