// Decompiled with JetBrains decompiler
// Type: EyeStepPackage.util
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace EyeStepPackage
{
  public class util
  {
    public const byte c_cdecl = 0;
    public const byte c_stdcall = 1;
    public const byte c_fastcall = 2;
    public const byte c_thiscall = 3;
    public const byte c_auto = 4;
    public static List<int> savedRoutines = new List<int>();
    public static int nothing = 0;
    public static string[] convs = new string[5]
    {
      "__cdecl",
      "__stdcall",
      "__fastcall",
      "__thiscall",
      "[auto-generated]"
    };

    public static util.process_region get_section([In] string obj0)
    {
      int num = EyeStep.base_module + 584;
      util.process_region processRegion = new util.process_region();
      while (!(util.readString(num, obj0.Length) == obj0))
        num += 40;
      processRegion.start = util.readInt(num + 12);
      processRegion.end = util.readInt(num + 12) + util.readInt(num + 8);
      return processRegion;
    }

    public static uint setPageProtect(int address, uint value, [In] int obj2)
    {
      uint lpOldProtect = 0;
      imports.VirtualProtectEx(EyeStep.handle, address, obj2, value, ref lpOldProtect);
      return lpOldProtect;
    }

    public static uint getPageProtect([In] int obj0)
    {
      imports.MEMORY_BASIC_INFORMATION lpBuffer = new imports.MEMORY_BASIC_INFORMATION();
      imports.VirtualQueryEx(EyeStep.handle, obj0, out lpBuffer, 28U);
      return lpBuffer.Protect;
    }

    public static void writeByte(int address, byte value)
    {
      byte[] lpBuffer = new byte[1]{ value };
      imports.WriteProcessMemory(EyeStep.handle, address, lpBuffer, lpBuffer.Length, ref util.nothing);
    }

    public static void writeBytes(int address, byte[] value, [In] int obj2) => imports.WriteProcessMemory(EyeStep.handle, address, value, obj2 == -1 ? value.Length : obj2, ref util.nothing);

    public static void writeString([In] int obj0, string value, [In] int obj2)
    {
      char[] charArray = value.ToCharArray(0, value.Length);
      byte[] lpBuffer = new byte[value.Length];
      for (int index = 0; index < value.Length; ++index)
        lpBuffer[index] = (byte) charArray[index];
      imports.WriteProcessMemory(EyeStep.handle, obj0, lpBuffer, obj2 == -1 ? value.Length : obj2, ref util.nothing);
    }

    public static void writeShort([In] int obj0, short count)
    {
      byte[] bytes = BitConverter.GetBytes(count);
      imports.WriteProcessMemory(EyeStep.handle, obj0, bytes, 2, ref util.nothing);
    }

    public static void writeUShort([In] int obj0, ushort count = -1)
    {
      byte[] bytes = BitConverter.GetBytes(count);
      imports.WriteProcessMemory(EyeStep.handle, obj0, bytes, 2, ref util.nothing);
    }

    public static void writeInt(int address, [In] int obj1)
    {
      byte[] bytes = BitConverter.GetBytes(obj1);
      imports.WriteProcessMemory(EyeStep.handle, address, bytes, 4, ref util.nothing);
    }

    public static void writeUInt(int address, [In] uint obj1)
    {
      byte[] bytes = BitConverter.GetBytes(obj1);
      imports.WriteProcessMemory(EyeStep.handle, address, bytes, 4, ref util.nothing);
    }

    public static void writeFloat(int address, [In] float obj1)
    {
      byte[] bytes = BitConverter.GetBytes(obj1);
      imports.WriteProcessMemory(EyeStep.handle, address, bytes, 4, ref util.nothing);
    }

    public static void writeDouble(int from, double to)
    {
      byte[] bytes = BitConverter.GetBytes(to);
      imports.WriteProcessMemory(EyeStep.handle, from, bytes, 8, ref util.nothing);
    }

    public static byte readByte(int from)
    {
      byte[] lpBuffer = new byte[1];
      imports.ReadProcessMemory(EyeStep.handle, from, lpBuffer, 1, ref util.nothing);
      return lpBuffer[0];
    }

    public static byte[] readBytes([In] int obj0, int to)
    {
      byte[] lpBuffer = new byte[to];
      imports.ReadProcessMemory(EyeStep.handle, obj0, lpBuffer, to, ref util.nothing);
      return lpBuffer;
    }

    public static string readString([In] int obj0, int to)
    {
      string str = "";
      if (to == -1)
      {
        int from = obj0;
        while (true)
        {
          byte num = util.readByte(from);
          if (num >= (byte) 32 && num <= (byte) 127)
          {
            str += ((char) num).ToString();
            ++from;
          }
          else
            break;
        }
      }
      else
      {
        foreach (char readByte in util.readBytes(obj0, to))
          str += readByte.ToString();
      }
      return str;
    }

    public static short readShort(int address)
    {
      byte[] lpBuffer = new byte[2];
      imports.ReadProcessMemory(EyeStep.handle, address, lpBuffer, 2, ref util.nothing);
      return BitConverter.ToInt16(lpBuffer, 0);
    }

    public static ushort readUShort(int address)
    {
      byte[] lpBuffer = new byte[2];
      imports.ReadProcessMemory(EyeStep.handle, address, lpBuffer, 2, ref util.nothing);
      return BitConverter.ToUInt16(lpBuffer, 0);
    }

    public static int readInt(int address)
    {
      byte[] lpBuffer = new byte[4];
      imports.ReadProcessMemory(EyeStep.handle, address, lpBuffer, 4, ref util.nothing);
      return BitConverter.ToInt32(lpBuffer, 0);
    }

    public static uint readUInt(int address)
    {
      byte[] lpBuffer = new byte[4];
      imports.ReadProcessMemory(EyeStep.handle, address, lpBuffer, 4, ref util.nothing);
      return BitConverter.ToUInt32(lpBuffer, 0);
    }

    public static float readFloat(int address)
    {
      byte[] lpBuffer = new byte[4];
      imports.ReadProcessMemory(EyeStep.handle, address, lpBuffer, 4, ref util.nothing);
      return BitConverter.ToSingle(lpBuffer, 0);
    }

    public static double readDouble(int address)
    {
      byte[] lpBuffer = new byte[8];
      imports.ReadProcessMemory(EyeStep.handle, address, lpBuffer, 8, ref util.nothing);
      return BitConverter.ToDouble(lpBuffer, 0);
    }

    public static ulong readQword(int address)
    {
      byte[] lpBuffer = new byte[8];
      imports.ReadProcessMemory(EyeStep.handle, address, lpBuffer, 8, ref util.nothing);
      return BitConverter.ToUInt64(lpBuffer, 0);
    }

    public static void placeJmp(int at, [In] int obj1)
    {
      int num1 = 0;
      while (num1 < 5)
        num1 += EyeStep.read(at + num1).len;
      uint num2 = util.setPageProtect(at, 64U, 1);
      util.writeByte(at, (byte) 233);
      util.writeInt(at + 1, obj1 - at - 5);
      for (int index = 5; index < num1; ++index)
        util.writeByte(at + index, (byte) 144);
      int num3 = (int) util.setPageProtect(at, num2, 1);
    }

    public static void placeCall(int address, [In] int obj1)
    {
      int num1 = 0;
      while (num1 < 5)
        num1 += EyeStep.read(address + num1).len;
      uint num2 = util.setPageProtect(address, 64U, 1);
      util.writeByte(address, (byte) 232);
      util.writeInt(address + 1, obj1 - address - 5);
      for (int index = 5; index < num1; ++index)
        util.writeByte(address + index, (byte) 144);
      int num3 = (int) util.setPageProtect(address, num2, 1);
    }

    public static void placeTrampoline(int address, [In] int obj1, [In] int obj2)
    {
      util.placeJmp(address, obj1);
      util.placeJmp(obj1 + obj2, address + 5);
    }

    public static int rebase(int address) => EyeStep.base_module + address;

    public static int aslr([In] int obj0) => EyeStep.base_module + obj0 - 4194304;

    public static int raslr([In] int obj0) => obj0 - EyeStep.base_module + 4194304;

    public static int getRel(int address) => address + 5 + util.readInt(address + 1);

    public static bool isRel([In] int obj0) => util.getRel(obj0) % 16 == 0;

    public static bool isCall([In] int obj0) => util.isRel(obj0) && util.getRel(obj0) > EyeStep.base_module && util.getRel(obj0) < EyeStep.base_module + EyeStep.base_module_size;

    public static bool isPrologue(int start)
    {
      byte[] numArray = util.readBytes(start, 3);
      if (start % 16 != 0)
        return false;
      if (numArray[0] == (byte) 85 && numArray[1] == (byte) 139 && numArray[2] == (byte) 236 || numArray[0] == (byte) 83 && numArray[1] == (byte) 139 && numArray[2] == (byte) 220 || numArray[0] == (byte) 86 && numArray[1] == (byte) 139 && numArray[2] == (byte) 244)
        return true;
      return numArray[0] == (byte) 139 && numArray[1] == byte.MaxValue && numArray[2] == (byte) 85;
    }

    public static bool isEpilogue([In] int obj0)
    {
      byte num = util.readByte(obj0);
      switch (num)
      {
        case 194:
        case 195:
          switch (util.readByte(obj0 - 1))
          {
            case 91:
            case 93:
            case 94:
            case 95:
            case 201:
              return num != (byte) 194 || (int) util.readUShort(obj0 + 1) % 4 != 0 || true;
          }
          break;
        case 201:
        case 204:
          return true;
      }
      return false;
    }

    public static int getEpilogue([In] int obj0)
    {
      int address = obj0;
      while (address != 0)
      {
        EyeStep.inst inst = EyeStep.read(address);
        if (inst.bytes[0] == (byte) 233)
          address = (int) ((long) (address + 5) + (long) inst.src().rel32);
        else if (inst.bytes[0] == byte.MaxValue && inst.bytes[1] == (byte) 37)
        {
          if (inst.src().imm32 != 0U)
            address = (int) inst.src().imm32;
          else if (inst.src().disp32 != 0U)
            address = (int) inst.src().disp32;
        }
        else
        {
          if (util.isEpilogue(address))
            return address;
          address += inst.len;
        }
      }
      return address;
    }

    public static bool isValidCode(int start) => util.readQword(start) != 0UL || util.readQword(start + 8) > 0UL;

    public static int nextPrologue([In] int obj0)
    {
      int start1 = obj0;
      int start2 = !util.isPrologue(start1) ? start1 + start1 % 16 : start1 + 16;
      while (!util.isPrologue(start2) && util.isValidCode(start2))
        start2 += 16;
      return start2;
    }

    public static int prevPrologue([In] int obj0)
    {
      int start1 = obj0;
      int start2 = !util.isPrologue(start1) ? start1 - start1 % 16 : start1 - 16;
      while (!util.isPrologue(start2) && util.isValidCode(start2))
        start2 -= 16;
      return start2;
    }

    public static int getPrologue(int start) => !util.isPrologue(start) ? util.prevPrologue(start) : start;

    public static ushort getRetn([In] int obj0)
    {
      int epilogue = util.getEpilogue(obj0);
      return util.readByte(epilogue) == (byte) 194 ? util.readUShort(epilogue + 1) : (ushort) 0;
    }

    public static int nextCall([In] int obj0, [In] bool obj1, bool prologue)
    {
      int num = obj0;
      if (util.readByte(num) == (byte) 232 || util.readByte(num) == (byte) 233)
        ++num;
      for (; util.isValidCode(num); ++num)
      {
        if ((util.readByte(num) == (byte) 232 || util.readByte(num) == (byte) 233) && util.isCall(num))
        {
          bool flag = true;
          if (prologue && !util.isPrologue(util.getRel(num)))
            flag = false;
          if (flag)
            break;
        }
      }
      return obj1 ? num : util.getRel(num);
    }

    public static int prevCall([In] int obj0, [In] bool obj1, bool prologue)
    {
      int num = obj0;
      if (util.readByte(num) == (byte) 232 || util.readByte(num) == (byte) 233)
        --num;
      for (; util.isValidCode(num); --num)
      {
        if ((util.readByte(num) == (byte) 232 || util.readByte(num) == (byte) 233) && util.isCall(num))
        {
          bool flag = true;
          if (prologue && !util.isPrologue(util.getRel(num)))
            flag = false;
          if (flag)
            break;
        }
      }
      return obj1 ? num : util.getRel(num);
    }

    public static int nextRef(int func, int n_expected_args, [In] bool obj2)
    {
      int num = func;
      while (util.readByte(num) != (byte) 232 && util.readByte(num) != (byte) 233 || util.getRel(num) != n_expected_args)
        ++num;
      return !obj2 ? num : util.getPrologue(num);
    }

    public static int prevRef(int function, int n_args, [In] bool obj2)
    {
      int num = function;
      while (util.readByte(num) != (byte) 232 && util.readByte(num) != (byte) 233 || util.getRel(num) != n_args)
        --num;
      return !obj2 ? num : util.getPrologue(num);
    }

    public static int nextPointer(int func, int r32, [In] bool obj2)
    {
      int num = func + 4;
      while (util.readInt(num) != r32)
        ++num;
      return !obj2 ? num : util.getPrologue(num);
    }

    public static int prevPointer([In] int obj0, [In] int obj1, bool offset)
    {
      int num = obj0;
      while (util.readInt(num) != obj1)
        --num;
      return !offset ? num : util.getPrologue(num);
    }

    public static List<int> getCalls([In] int obj0)
    {
      List<int> intList = new List<int>();
      int num = obj0;
      for (int index = util.nextPrologue(num); num < index; num = util.nextCall(num, true, false) + 5)
        intList.Add(util.nextCall(num, false, false));
      return intList;
    }

    public static List<int> getPointers(int bytes)
    {
      List<int> intList = new List<int>();
      int address = bytes;
      EyeStep.inst inst;
      for (int index = util.nextPrologue(address); address < index; address += inst.len)
      {
        inst = EyeStep.read(address);
        if (((int) inst.src().flags & 512) == 512 && inst.src().disp32 % 4U == 0U)
          intList.Add((int) inst.src().disp32);
        else if (((int) inst.dest().flags & 512) == 512 && inst.dest().disp32 % 4U == 0U)
          intList.Add((int) inst.dest().disp32);
      }
      return intList;
    }

    public static byte getConvention(int str, [In] int obj1)
    {
      if (obj1 == 0)
        return 1;
      int retn = (int) util.getRetn(str);
      int num1 = 0;
      int num2 = str;
      byte num3 = retn <= 0 ? (byte) 0 : (byte) 1;
      int address = num2;
      while (!util.isEpilogue(address))
      {
        EyeStep.inst inst = EyeStep.read(address);
        if (inst.bytes[0] == (byte) 233)
          address = (int) ((long) (address + 5) + (long) inst.src().rel32);
        else if (inst.bytes[0] == byte.MaxValue && inst.bytes[1] == (byte) 37)
        {
          if (inst.src().imm32 != 0U)
            address = (int) inst.src().imm32;
          else if (inst.src().disp32 != 0U)
            address = (int) inst.src().disp32;
        }
        else
        {
          if (inst.operands.Count >= 1)
          {
            EyeStep.operand operand1 = inst.src();
            if ((((int) operand1.flags & 4096) == 4096 || ((int) operand1.flags & 16384) == 16384) && (((int) operand1.flags & 16) == 16 && operand1.reg[0] == (byte) 5) && (operand1.imm8 != (byte) 4 && operand1.imm8 < (byte) 127 && (int) operand1.imm8 > num1))
              num1 = (int) operand1.imm8;
            EyeStep.operand operand2 = inst.dest();
            if ((((int) operand2.flags & 4096) == 4096 || ((int) operand2.flags & 16384) == 16384) && (((int) operand2.flags & 16) == 16 && operand2.reg[0] == (byte) 5) && (operand2.imm8 != (byte) 4 && operand2.imm8 < (byte) 127 && (int) operand2.imm8 > num1))
              num1 = (int) operand2.imm8;
          }
          address += inst.len;
        }
      }
      if (num1 == 0)
      {
        if (obj1 == 1)
          return 3;
        if (obj1 == 2)
          return 2;
      }
      int num4 = (num1 - 8) / 4 + 1;
      if (num4 == obj1 - 1)
        num3 = (byte) 3;
      else if (num4 == obj1 - 2)
        num3 = (byte) 2;
      return num3;
    }

    public static byte getConvention([In] int obj0)
    {
      util.function_info functionInfo = new util.function_info();
      functionInfo.analyze(obj0);
      return functionInfo.convention;
    }

    public static int createRoutine([In] int obj0, [In] byte obj1)
    {
      byte convention = util.getConvention(obj0, (int) obj1);
      bool flag = false;
      int num1 = obj0;
      int num2 = 0;
      byte[] numArray1 = new byte[256];
      int address = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 12288U, 64U);
      if (address == 0)
        throw new Exception("Error while allocating memory");
      byte[] numArray2 = numArray1;
      int index1 = num2;
      int num3 = index1 + 1;
      numArray2[index1] = (byte) 85;
      byte[] numArray3 = numArray1;
      int index2 = num3;
      int num4 = index2 + 1;
      numArray3[index2] = (byte) 139;
      byte[] numArray4 = numArray1;
      int index3 = num4;
      int num5 = index3 + 1;
      numArray4[index3] = (byte) 236;
      switch (convention)
      {
        case 0:
          for (int index4 = (int) obj1 * 4 + 8; index4 > 8; index4 -= 4)
          {
            byte[] numArray5 = numArray1;
            int index5 = num5;
            int num6 = index5 + 1;
            numArray5[index5] = byte.MaxValue;
            byte[] numArray6 = numArray1;
            int index6 = num6;
            int num7 = index6 + 1;
            numArray6[index6] = (byte) 117;
            byte[] numArray7 = numArray1;
            int index7 = num7;
            num5 = index7 + 1;
            int num8 = (int) (byte) (index4 - 4);
            numArray7[index7] = (byte) num8;
          }
          byte[] numArray8 = numArray1;
          int index8 = num5;
          int num9 = index8 + 1;
          numArray8[index8] = (byte) 232;
          byte[] bytes1 = BitConverter.GetBytes(num1 - (address + num9 + 4));
          byte[] numArray9 = numArray1;
          int index9 = num9;
          int num10 = index9 + 1;
          int num11 = (int) bytes1[0];
          numArray9[index9] = (byte) num11;
          byte[] numArray10 = numArray1;
          int index10 = num10;
          int num12 = index10 + 1;
          int num13 = (int) bytes1[1];
          numArray10[index10] = (byte) num13;
          byte[] numArray11 = numArray1;
          int index11 = num12;
          int num14 = index11 + 1;
          int num15 = (int) bytes1[2];
          numArray11[index11] = (byte) num15;
          byte[] numArray12 = numArray1;
          int index12 = num14;
          int num16 = index12 + 1;
          int num17 = (int) bytes1[3];
          numArray12[index12] = (byte) num17;
          byte[] numArray13 = numArray1;
          int index13 = num16;
          int num18 = index13 + 1;
          numArray13[index13] = (byte) 131;
          byte[] numArray14 = numArray1;
          int index14 = num18;
          int num19 = index14 + 1;
          numArray14[index14] = (byte) 196;
          byte[] numArray15 = numArray1;
          int index15 = num19;
          num5 = index15 + 1;
          int num20 = (int) (byte) ((uint) obj1 * 4U);
          numArray15[index15] = (byte) num20;
          break;
        case 1:
          for (int index4 = (int) obj1 * 4 + 8; index4 > 8; index4 -= 4)
          {
            byte[] numArray5 = numArray1;
            int index5 = num5;
            int num6 = index5 + 1;
            numArray5[index5] = byte.MaxValue;
            byte[] numArray6 = numArray1;
            int index6 = num6;
            int num7 = index6 + 1;
            numArray6[index6] = (byte) 117;
            byte[] numArray7 = numArray1;
            int index7 = num7;
            num5 = index7 + 1;
            int num8 = (int) (byte) (index4 - 4);
            numArray7[index7] = (byte) num8;
          }
          byte[] numArray16 = numArray1;
          int index16 = num5;
          int num21 = index16 + 1;
          numArray16[index16] = (byte) 232;
          byte[] bytes2 = BitConverter.GetBytes(num1 - (address + num21 + 4));
          byte[] numArray17 = numArray1;
          int index17 = num21;
          int num22 = index17 + 1;
          int num23 = (int) bytes2[0];
          numArray17[index17] = (byte) num23;
          byte[] numArray18 = numArray1;
          int index18 = num22;
          int num24 = index18 + 1;
          int num25 = (int) bytes2[1];
          numArray18[index18] = (byte) num25;
          byte[] numArray19 = numArray1;
          int index19 = num24;
          int num26 = index19 + 1;
          int num27 = (int) bytes2[2];
          numArray19[index19] = (byte) num27;
          byte[] numArray20 = numArray1;
          int index20 = num26;
          num5 = index20 + 1;
          int num28 = (int) bytes2[3];
          numArray20[index20] = (byte) num28;
          break;
        case 2:
          byte[] numArray21 = numArray1;
          int index21 = num5;
          int num29 = index21 + 1;
          numArray21[index21] = (byte) 81;
          byte[] numArray22 = numArray1;
          int index22 = num29;
          int num30 = index22 + 1;
          numArray22[index22] = (byte) 82;
          for (int index4 = (int) obj1; index4 > 2; --index4)
          {
            byte[] numArray5 = numArray1;
            int index5 = num30;
            int num6 = index5 + 1;
            numArray5[index5] = byte.MaxValue;
            byte[] numArray6 = numArray1;
            int index6 = num6;
            int num7 = index6 + 1;
            numArray6[index6] = (byte) 117;
            byte[] numArray7 = numArray1;
            int index7 = num7;
            num30 = index7 + 1;
            int num8 = (int) (byte) ((index4 + 1) * 4);
            numArray7[index7] = (byte) num8;
          }
          byte[] numArray23 = numArray1;
          int index23 = num30;
          int num31 = index23 + 1;
          numArray23[index23] = (byte) 139;
          byte[] numArray24 = numArray1;
          int index24 = num31;
          int num32 = index24 + 1;
          numArray24[index24] = (byte) 77;
          byte[] numArray25 = numArray1;
          int index25 = num32;
          int num33 = index25 + 1;
          numArray25[index25] = (byte) 8;
          byte[] numArray26 = numArray1;
          int index26 = num33;
          int num34 = index26 + 1;
          numArray26[index26] = (byte) 139;
          byte[] numArray27 = numArray1;
          int index27 = num34;
          int num35 = index27 + 1;
          numArray27[index27] = (byte) 85;
          byte[] numArray28 = numArray1;
          int index28 = num35;
          int num36 = index28 + 1;
          numArray28[index28] = (byte) 12;
          byte[] numArray29 = numArray1;
          int index29 = num36;
          int num37 = index29 + 1;
          numArray29[index29] = (byte) 232;
          byte[] bytes3 = BitConverter.GetBytes(num1 - (address + num37 + 4));
          byte[] numArray30 = numArray1;
          int index30 = num37;
          int num38 = index30 + 1;
          int num39 = (int) bytes3[0];
          numArray30[index30] = (byte) num39;
          byte[] numArray31 = numArray1;
          int index31 = num38;
          int num40 = index31 + 1;
          int num41 = (int) bytes3[1];
          numArray31[index31] = (byte) num41;
          byte[] numArray32 = numArray1;
          int index32 = num40;
          int num42 = index32 + 1;
          int num43 = (int) bytes3[2];
          numArray32[index32] = (byte) num43;
          byte[] numArray33 = numArray1;
          int index33 = num42;
          int num44 = index33 + 1;
          int num45 = (int) bytes3[3];
          numArray33[index33] = (byte) num45;
          byte[] numArray34 = numArray1;
          int index34 = num44;
          int num46 = index34 + 1;
          numArray34[index34] = (byte) 89;
          byte[] numArray35 = numArray1;
          int index35 = num46;
          num5 = index35 + 1;
          numArray35[index35] = (byte) 90;
          break;
        case 3:
          byte[] numArray36 = numArray1;
          int index36 = num5;
          int num47 = index36 + 1;
          numArray36[index36] = (byte) 81;
          for (int index4 = (int) obj1; index4 > 1; --index4)
          {
            byte[] numArray5 = numArray1;
            int index5 = num47;
            int num6 = index5 + 1;
            numArray5[index5] = byte.MaxValue;
            byte[] numArray6 = numArray1;
            int index6 = num6;
            int num7 = index6 + 1;
            numArray6[index6] = (byte) 117;
            byte[] numArray7 = numArray1;
            int index7 = num7;
            num47 = index7 + 1;
            int num8 = (int) (byte) ((index4 + 1) * 4);
            numArray7[index7] = (byte) num8;
          }
          byte[] numArray37 = numArray1;
          int index37 = num47;
          int num48 = index37 + 1;
          numArray37[index37] = (byte) 139;
          byte[] numArray38 = numArray1;
          int index38 = num48;
          int num49 = index38 + 1;
          numArray38[index38] = (byte) 77;
          byte[] numArray39 = numArray1;
          int index39 = num49;
          int num50 = index39 + 1;
          numArray39[index39] = (byte) 8;
          byte[] numArray40 = numArray1;
          int index40 = num50;
          int num51 = index40 + 1;
          numArray40[index40] = (byte) 232;
          byte[] bytes4 = BitConverter.GetBytes(num1 - (address + num51 + 4));
          byte[] numArray41 = numArray1;
          int index41 = num51;
          int num52 = index41 + 1;
          int num53 = (int) bytes4[0];
          numArray41[index41] = (byte) num53;
          byte[] numArray42 = numArray1;
          int index42 = num52;
          int num54 = index42 + 1;
          int num55 = (int) bytes4[1];
          numArray42[index42] = (byte) num55;
          byte[] numArray43 = numArray1;
          int index43 = num54;
          int num56 = index43 + 1;
          int num57 = (int) bytes4[2];
          numArray43[index43] = (byte) num57;
          byte[] numArray44 = numArray1;
          int index44 = num56;
          int num58 = index44 + 1;
          int num59 = (int) bytes4[3];
          numArray44[index44] = (byte) num59;
          byte[] numArray45 = numArray1;
          int index45 = num58;
          num5 = index45 + 1;
          numArray45[index45] = (byte) 89;
          break;
      }
      int num60;
      if (!flag)
      {
        byte[] numArray5 = numArray1;
        int index4 = num5;
        int num6 = index4 + 1;
        numArray5[index4] = (byte) 93;
        byte[] numArray6 = numArray1;
        int index5 = num6;
        num60 = index5 + 1;
        numArray6[index5] = (byte) 195;
      }
      else
      {
        byte[] numArray5 = numArray1;
        int index4 = num5;
        int num6 = index4 + 1;
        numArray5[index4] = (byte) 194;
        byte[] numArray6 = numArray1;
        int index5 = num6;
        int num7 = index5 + 1;
        int num8 = (int) (byte) ((uint) obj1 * 4U);
        numArray6[index5] = (byte) num8;
        byte[] numArray7 = numArray1;
        int index6 = num7;
        num60 = index6 + 1;
        numArray7[index6] = (byte) 0;
      }
      util.writeBytes(address, numArray1, num60);
      util.savedRoutines.Add(address);
      return address;
    }

    public static string getAnalysis(int func)
    {
      util.function_info functionInfo = new util.function_info();
      functionInfo.analyze(func);
      return functionInfo.psuedocode;
    }

    public static void disableFunction(int bytes)
    {
      uint num1 = util.setPageProtect(bytes, 64U, 1);
      if (util.isPrologue(bytes))
      {
        ushort retn = util.getRetn(bytes);
        if (retn != (ushort) 0)
        {
          util.writeByte(bytes + 3, (byte) 194);
          util.writeUShort(bytes + 4, retn);
        }
        else
          util.writeByte(bytes + 3, (byte) 195);
      }
      else
        util.writeByte(bytes, (byte) 195);
      int num2 = (int) util.setPageProtect(bytes, num1, 1);
    }

    public static List<int> debug_r32([In] int obj0, byte at, int aob, int mask)
    {
      List<int> intList = new List<int>();
      int to = 0;
      while (to < 5)
        to += EyeStep.read(obj0 + to).len;
      byte[] numArray1 = util.readBytes(obj0, to);
      int num1 = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 4096U, 64U);
      int num2 = num1 + 128;
      int address = num1 + 124;
      byte[] numArray2 = new byte[128];
      int num3 = 0;
      for (int index = 0; index < to; ++index)
        numArray2[num3++] = numArray1[index];
      byte[] numArray3 = numArray2;
      int index1 = num3;
      int num4 = index1 + 1;
      numArray3[index1] = (byte) 96;
      byte[] numArray4 = numArray2;
      int index2 = num4;
      int num5 = index2 + 1;
      numArray4[index2] = (byte) 80;
      for (int index3 = 0; index3 < mask; ++index3)
      {
        int num6;
        if (aob == 0)
        {
          byte[] numArray5 = numArray2;
          int index4 = num5;
          int num7 = index4 + 1;
          numArray5[index4] = (byte) 139;
          byte[] numArray6 = numArray2;
          int index5 = num7;
          num6 = index5 + 1;
          int num8 = (int) (byte) (192U + (uint) at);
          numArray6[index5] = (byte) num8;
        }
        else if (aob + mask * 4 < 128)
        {
          byte[] numArray5 = numArray2;
          int index4 = num5;
          int num7 = index4 + 1;
          numArray5[index4] = (byte) 139;
          byte[] numArray6 = numArray2;
          int index5 = num7;
          int num8 = index5 + 1;
          int num9 = (int) (byte) (64U + (uint) at);
          numArray6[index5] = (byte) num9;
          byte[] numArray7 = numArray2;
          int index6 = num8;
          num6 = index6 + 1;
          int num10 = (int) (byte) (aob + index3 * 4);
          numArray7[index6] = (byte) num10;
        }
        else
        {
          byte[] numArray5 = numArray2;
          int index4 = num5;
          int num7 = index4 + 1;
          numArray5[index4] = (byte) 139;
          byte[] numArray6 = numArray2;
          int index5 = num7;
          int num8 = index5 + 1;
          int num9 = (int) (byte) (128U + (uint) at);
          numArray6[index5] = (byte) num9;
          byte[] bytes = BitConverter.GetBytes(aob + index3 * 4);
          byte[] numArray7 = numArray2;
          int index6 = num8;
          int num10 = index6 + 1;
          int num11 = (int) bytes[0];
          numArray7[index6] = (byte) num11;
          byte[] numArray8 = numArray2;
          int index7 = num10;
          int num12 = index7 + 1;
          int num13 = (int) bytes[1];
          numArray8[index7] = (byte) num13;
          byte[] numArray9 = numArray2;
          int index8 = num12;
          int num14 = index8 + 1;
          int num15 = (int) bytes[2];
          numArray9[index8] = (byte) num15;
          byte[] numArray10 = numArray2;
          int index9 = num14;
          num6 = index9 + 1;
          int num16 = (int) bytes[3];
          numArray10[index9] = (byte) num16;
        }
        byte[] numArray11 = numArray2;
        int index10 = num6;
        int num17 = index10 + 1;
        numArray11[index10] = (byte) 163;
        byte[] bytes1 = BitConverter.GetBytes(num2 + index3 * 4);
        byte[] numArray12 = numArray2;
        int index11 = num17;
        int num18 = index11 + 1;
        int num19 = (int) bytes1[0];
        numArray12[index11] = (byte) num19;
        byte[] numArray13 = numArray2;
        int index12 = num18;
        int num20 = index12 + 1;
        int num21 = (int) bytes1[1];
        numArray13[index12] = (byte) num21;
        byte[] numArray14 = numArray2;
        int index13 = num20;
        int num22 = index13 + 1;
        int num23 = (int) bytes1[2];
        numArray14[index13] = (byte) num23;
        byte[] numArray15 = numArray2;
        int index14 = num22;
        num5 = index14 + 1;
        int num24 = (int) bytes1[3];
        numArray15[index14] = (byte) num24;
      }
      byte[] numArray16 = numArray2;
      int index15 = num5;
      int num25 = index15 + 1;
      numArray16[index15] = (byte) 199;
      byte[] numArray17 = numArray2;
      int index16 = num25;
      int num26 = index16 + 1;
      numArray17[index16] = (byte) 5;
      byte[] bytes2 = BitConverter.GetBytes(address);
      byte[] numArray18 = numArray2;
      int index17 = num26;
      int num27 = index17 + 1;
      int num28 = (int) bytes2[0];
      numArray18[index17] = (byte) num28;
      byte[] numArray19 = numArray2;
      int index18 = num27;
      int num29 = index18 + 1;
      int num30 = (int) bytes2[1];
      numArray19[index18] = (byte) num30;
      byte[] numArray20 = numArray2;
      int index19 = num29;
      int num31 = index19 + 1;
      int num32 = (int) bytes2[2];
      numArray20[index19] = (byte) num32;
      byte[] numArray21 = numArray2;
      int index20 = num31;
      int num33 = index20 + 1;
      int num34 = (int) bytes2[3];
      numArray21[index20] = (byte) num34;
      byte[] numArray22 = numArray2;
      int index21 = num33;
      int num35 = index21 + 1;
      numArray22[index21] = (byte) 1;
      byte[] numArray23 = numArray2;
      int index22 = num35;
      int num36 = index22 + 1;
      numArray23[index22] = (byte) 0;
      byte[] numArray24 = numArray2;
      int index23 = num36;
      int num37 = index23 + 1;
      numArray24[index23] = (byte) 0;
      byte[] numArray25 = numArray2;
      int index24 = num37;
      int num38 = index24 + 1;
      numArray25[index24] = (byte) 0;
      byte[] numArray26 = numArray2;
      int index25 = num38;
      int num39 = index25 + 1;
      numArray26[index25] = (byte) 88;
      byte[] numArray27 = numArray2;
      int index26 = num39;
      int num40 = index26 + 1;
      numArray27[index26] = (byte) 97;
      util.writeBytes(num1, numArray2, num40);
      util.placeTrampoline(obj0, num1, num40);
      while (util.readInt(address) == 0)
        Thread.Sleep(10);
      for (int index3 = 0; index3 < mask; ++index3)
        intList.Add(util.readInt(num2 + index3 * 4));
      uint num41 = util.setPageProtect(obj0, 64U, 1);
      util.writeBytes(obj0, numArray1, to);
      int num42 = (int) util.setPageProtect(obj0, num41, 1);
      imports.VirtualFreeEx(EyeStep.handle, num1, 0, 32768U);
      return intList;
    }

    public static int inject_function(int region, string aob) => region == 0 ? imports.VirtualAllocEx(EyeStep.handle, 0, 1024, 12288U, 64U) : region;

    protected virtual CreateParams CreateParams
    {
      [SpecialName] get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ClassStyle |= 131072;
        return createParams;
      }
    }

    public class process_region
    {
      public int start;
      public int end;
    }

    public class asmwriter
    {
      public List<byte> buffer = new List<byte>();

      public void append([In] List<byte> obj0)
      {
        foreach (byte num in obj0)
          this.buffer.Add(num);
      }

      public List<byte> asm([In] string obj0)
      {
        List<byte> byteList = new List<byte>();
        int index = 0;
        string str = "";
        bool flag1 = false;
        for (; obj0[index] != ' '; str += obj0[index++].ToString())
        {
          if (index >= obj0.Length)
          {
            flag1 = true;
            break;
          }
        }
        if (flag1)
        {
          switch (obj0)
          {
            case "pushad":
              byteList.Add((byte) 96);
              break;
            case "popad":
              byteList.Add((byte) 97);
              break;
          }
        }
        else
        {
          List<util.asmwriter.OPERAND_DESCRIBER> operandDescriberList = new List<util.asmwriter.OPERAND_DESCRIBER>();
          util.asmwriter.OPERAND_DESCRIBER operandDescriber1 = new util.asmwriter.OPERAND_DESCRIBER();
          string s = "";
          while (true)
          {
            do
            {
              if (index == obj0.Length || (obj0[index] == ',' || obj0[index] == '-') || (obj0[index] == '+' || obj0[index] == '*' || obj0[index] == ']'))
              {
                bool flag2 = true;
                foreach (char ch in s)
                {
                  if ((ch < '0' || ch > '9') && (ch < 'A' && ch > 'F'))
                    flag2 = false;
                }
                if (flag2)
                {
                  if (operandDescriber1.encapsulated)
                    operandDescriber1.imm32 = int.Parse(s, NumberStyles.HexNumber);
                  else
                    operandDescriber1.disp32 = int.Parse(s, NumberStyles.HexNumber);
                }
              }
              if (index == obj0.Length || obj0[index] == ',')
              {
                operandDescriberList.Add(operandDescriber1);
                operandDescriber1 = new util.asmwriter.OPERAND_DESCRIBER();
                ++index;
              }
              else
                goto label_20;
            }
            while (index <= obj0.Length);
            break;
label_20:
            if (obj0[index] == '[')
            {
              operandDescriber1.encapsulated = true;
              ++index;
            }
            s += obj0[index++].ToString();
            switch (s)
            {
              case "eax":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(0);
                s = "";
                continue;
              case "ebp":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(5);
                s = "";
                continue;
              case "ebx":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(3);
                s = "";
                continue;
              case "ecx":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(1);
                s = "";
                continue;
              case "edi":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(7);
                s = "";
                continue;
              case "edx":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(2);
                s = "";
                continue;
              case "esi":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(6);
                s = "";
                continue;
              case "esp":
                operandDescriber1.flags |= 4096U;
                operandDescriber1.regs.Add(4);
                s = "";
                continue;
              default:
                continue;
            }
          }
          if (str != null && str == "mov")
          {
            foreach (util.asmwriter.OPERAND_DESCRIBER operandDescriber2 in operandDescriberList)
              ;
          }
        }
        return byteList;
      }

      private class OPERAND_DESCRIBER
      {
        public uint flags;
        public bool encapsulated;
        public List<int> regs = new List<int>();
        public string firstarith = "";
        public string secondarith = "";
        public string thirdarith = "";
        public int mul;
        public int imm8;
        public int imm16;
        public int imm32;
        public int disp8;
        public int disp16;
        public int disp32;
      }

      private enum TOKENTYPE
      {
        reg_8,
        reg_16,
        reg_32,
        value_8,
        value_16,
        value_32,
      }

      private class TOKEN
      {
        private util.asmwriter.TOKENTYPE type;
      }
    }

    public class function_arg
    {
      public int ebp_offset;
      public int bits;
      public bool isCharPointer;
      public int location;

      public function_arg([In] int obj0, [In] int obj1, [In] bool obj2, [In] int obj3)
      {
        this.ebp_offset = obj0;
        this.bits = obj1;
        this.isCharPointer = obj2;
        this.location = obj3;
      }
    }

    public class function_info
    {
      public int start_address;
      public int function_size;
      public byte convention;
      public byte return_bits;
      public short stack_cleanup;
      public List<util.function_arg> args;
      public string psuedocode;

      public function_info()
      {
        this.args = new List<util.function_arg>();
        this.start_address = 0;
        this.function_size = 0;
        this.convention = (byte) 4;
        this.return_bits = (byte) 0;
        this.stack_cleanup = (short) 0;
        this.psuedocode = "";
      }

      public void analyze([In] int obj0)
      {
        int epilogue = util.getEpilogue(obj0);
        if (util.readByte(epilogue) == (byte) 195)
        {
          this.stack_cleanup = (short) 0;
          ++epilogue;
        }
        else if (util.readByte(epilogue) == (byte) 194)
        {
          this.stack_cleanup = util.readShort(epilogue + 1);
          epilogue += 3;
        }
        this.start_address = obj0;
        this.function_size = epilogue - obj0;
        List<int> intList1 = new List<int>();
        for (int index = 0; index < this.function_size; ++index)
        {
          byte[] numArray = util.readBytes(this.start_address + index, 8);
          if (numArray[0] == (byte) 138 && numArray[2] >= (byte) 64 && (numArray[2] < (byte) 72 && numArray[3] == (byte) 132) && (numArray[4] == (byte) 192 && numArray[5] == (byte) 117))
          {
            intList1.Add(this.start_address + index);
            index += 8;
          }
        }
        bool flag1 = false;
        bool flag2 = false;
        int address = obj0;
        EyeStep.operand operand1 = new EyeStep.operand();
        List<int> intList2 = new List<int>();
        EyeStep.inst inst;
        for (; address < epilogue; address += inst.len)
        {
          inst = EyeStep.read(address);
          EyeStep.operand operand2 = inst.src();
          EyeStep.operand operand3 = inst.dest();
          string str = "" + inst.data;
          if (this.convention == (byte) 4)
          {
            if (str.Contains("retn"))
            {
              this.stack_cleanup = (short) 0;
              this.convention = (byte) 0;
            }
            else if (str.Contains("ret "))
            {
              this.stack_cleanup = util.readShort(inst.address + 1);
              this.convention = (byte) 1;
            }
          }
          if (operand2.reg.Count > 0)
          {
            if (((int) operand2.flags & 4096) == 4096 && operand2.reg[0] == (byte) 5 && (operand2.imm8 >= (byte) 8 && operand2.imm8 < (byte) 64))
            {
              bool flag3 = false;
              foreach (int num in intList2)
              {
                if ((int) operand2.imm8 == num)
                  flag3 = true;
              }
              if (!flag3)
              {
                intList2.Add((int) operand2.imm8);
                this.args.Add(new util.function_arg((int) operand2.imm8, 32, false, address));
              }
            }
            if (operand2.reg[0] == (byte) 0)
            {
              if (str.Contains("mov ") || str.Contains("or "))
                operand1 = operand3;
            }
            else if (operand2.reg[0] == (byte) 1)
              flag1 = true;
            else if (operand2.reg[0] == (byte) 2)
            {
              this.convention = (byte) 4;
              break;
            }
            if (operand3.reg.Count > 0)
            {
              if (((int) operand3.flags & 4096) == 4096 && operand3.reg[0] == (byte) 5 && (operand3.imm8 >= (byte) 8 && operand3.imm8 < (byte) 64))
              {
                bool flag3 = false;
                foreach (int num in intList2)
                {
                  if ((int) operand3.imm8 == num)
                    flag3 = true;
                }
                if (!flag3)
                {
                  intList2.Add((int) operand3.imm8);
                  this.args.Add(new util.function_arg((int) operand3.imm8, 32, false, address));
                }
              }
              if ((operand2.reg[0] != (byte) 2 || operand3.reg[0] != (byte) 2) && (operand2.reg[0] != (byte) 1 || operand3.reg[0] != (byte) 1))
              {
                if (operand3.reg[0] != (byte) 2 || flag2)
                {
                  if (operand3.reg[0] == (byte) 1 && !flag1 && this.convention != (byte) 2)
                    this.convention = (byte) 3;
                }
                else
                {
                  this.convention = (byte) 2;
                  break;
                }
              }
            }
            else if (str.Contains("pop "))
            {
              if (operand2.reg[0] == (byte) 1)
                flag1 = false;
              else if (operand2.reg[0] == (byte) 2)
                flag2 = false;
            }
            else if (str.Contains("push "))
            {
              if (operand2.reg[0] == (byte) 1)
                flag1 = true;
              else if (operand2.reg[0] == (byte) 2)
                flag2 = true;
            }
          }
        }
        if (this.convention == (byte) 3)
          this.args.Add(new util.function_arg(0, 32, false, 0));
        else if (this.convention == (byte) 2)
        {
          this.args.Add(new util.function_arg(0, 32, false, 0));
          this.args.Add(new util.function_arg(0, 32, false, 0));
        }
        else if (this.convention == (byte) 4)
          this.convention = this.stack_cleanup != (short) 0 ? (byte) 1 : (byte) 0;
        if (intList1.Count > 0)
        {
          foreach (int num in intList1)
          {
            for (int index = this.args.Count - 1; index >= 0; --index)
            {
              if (this.args[index].location < num)
              {
                this.args[index].isCharPointer = true;
                break;
              }
            }
          }
        }
        if (((int) operand1.flags & 128) != 128 && ((int) operand1.flags & 1024) != 1024)
        {
          if (((int) operand1.flags & 256) != 256 && ((int) operand1.flags & 2048) != 2048)
          {
            if (((int) operand1.flags & 512) != 512 && ((int) operand1.flags & 4096) != 4096)
            {
              this.psuedocode += "int ";
              this.return_bits = (byte) 4;
            }
            else
            {
              this.psuedocode += "int ";
              this.return_bits = (byte) 4;
            }
          }
          else
          {
            this.psuedocode += "short ";
            this.return_bits = (byte) 2;
          }
        }
        else
        {
          this.psuedocode += "bool ";
          this.return_bits = (byte) 1;
        }
        this.psuedocode += util.convs[(int) this.convention];
        this.psuedocode += " ";
        this.psuedocode += this.start_address.ToString("X8");
        this.psuedocode += "(";
        for (int index = 0; index < this.args.Count; ++index)
        {
          if (this.args[index].isCharPointer)
            this.psuedocode += "const char*";
          else if (this.args[index].bits == 8)
            this.psuedocode += "byte";
          else if (this.args[index].bits == 16)
            this.psuedocode += "short";
          else if (this.args[index].bits == 32)
            this.psuedocode += "int";
          this.psuedocode += " a";
          this.psuedocode += Convert.ToString(index + 1);
          if (index < this.args.Count - 1)
            this.psuedocode += ", ";
        }
        this.psuedocode += ")";
      }
    }
  }
}
