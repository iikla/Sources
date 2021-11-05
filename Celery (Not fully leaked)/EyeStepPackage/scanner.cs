// Decompiled with JetBrains decompiler
// Type: EyeStepPackage.scanner
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace EyeStepPackage
{
  public class scanner
  {
    private static bool compare_bytes(
      [In] byte[] obj0,
      [In] ref int obj1,
      [In] byte[] obj2,
      [In] char[] obj3,
      int checks = default (int))
    {
      for (int index = 0; index < checks; ++index)
      {
        if (obj3[index] == '.' && (int) obj0[obj1 + index] != (int) obj2[index])
          return false;
      }
      return true;
    }

    public static List<int> scan(
      string func,
      string _offset,
      int _small,
      [In] int obj3,
      [In] scanner.scancheck[] obj4)
    {
      return scanner.scan(util.get_section(func), _offset, _small, obj3, obj4);
    }

    public static List<int> scan(
      [In] util.process_region obj0,
      string lpThreadAttributes,
      int dwStackSize,
      int lpStartAddress,
      scanner.scancheck[] lpParameter)
    {
      List<int> intList = new List<int>();
      imports.MEMORY_BASIC_INFORMATION lpBuffer = new imports.MEMORY_BASIC_INFORMATION();
      byte[] numArray1 = new byte[128];
      char[] chArray1 = new char[128];
      int index1 = 0;
      int index2 = 0;
      for (; index1 < lpThreadAttributes.Length; ++index1)
      {
        if (lpThreadAttributes[index1] != ' ')
        {
          char[] chArray2 = new char[2]
          {
            lpThreadAttributes[index1],
            lpThreadAttributes[1 + index1++]
          };
          if (chArray2[0] == '?' && chArray2[1] == '?')
          {
            numArray1[index2] = (byte) 0;
            chArray1[index2++] = '?';
          }
          else
          {
            int index3 = 0;
            int num = 0;
            while (true)
            {
              if (chArray2[index3] <= '`')
              {
                if (chArray2[index3] > '@')
                  num = (int) chArray2[index3] - 55;
                else if (chArray2[index3] >= '0')
                  num = (int) chArray2[index3] - 48;
              }
              else
                goto label_11;
label_9:
              if (index3 == 0)
              {
                ++index3;
                numArray1[index2] += (byte) (num * 16);
                continue;
              }
              break;
label_11:
              num = (int) chArray2[index3] - 87;
              goto label_9;
            }
            numArray1[index2] += (byte) num;
            chArray1[index2++] = '.';
          }
        }
      }
      int start = obj0.start;
      int end = obj0.end;
      while (start < end)
      {
        imports.VirtualQueryEx(EyeStep.handle, start, out lpBuffer, 44U);
        if (lpBuffer.BaseAddress != 0)
        {
          if (((int) lpBuffer.State & 4096) == 4096 && ((int) lpBuffer.Protect & 1) != 1 && (((int) lpBuffer.Protect & 512) != 512 && ((int) lpBuffer.Protect & 256) != 256))
          {
            byte[] numArray2 = util.readBytes(start, lpBuffer.RegionSize);
            for (int index3 = 0; index3 < lpBuffer.RegionSize; index3 += dwStackSize)
            {
              if (scanner.compare_bytes(numArray2, ref index3, numArray1, chArray1, chArray1.Length))
              {
                int num1 = start + index3;
                if (lpParameter == null)
                {
                  intList.Add(num1);
                }
                else
                {
                  int num2 = 0;
                  foreach (scanner.scancheck scancheck in lpParameter)
                  {
                    switch (scancheck.type)
                    {
                      case scanner.scanchecks.byte_equal:
                        if ((int) numArray2[index3 + scancheck.offset] == (int) scancheck.small)
                        {
                          ++num2;
                          break;
                        }
                        break;
                      case scanner.scanchecks.word_equal:
                        if ((int) BitConverter.ToUInt16(numArray2, index3 + scancheck.offset) == (int) scancheck.small)
                        {
                          ++num2;
                          break;
                        }
                        break;
                      case scanner.scanchecks.int_equal:
                        if ((int) BitConverter.ToUInt32(numArray2, index3 + scancheck.offset) == (int) scancheck.small)
                        {
                          ++num2;
                          break;
                        }
                        break;
                      case scanner.scanchecks.byte_notequal:
                        if ((int) numArray2[index3 + scancheck.offset] != (int) scancheck.small)
                        {
                          ++num2;
                          break;
                        }
                        break;
                      case scanner.scanchecks.word_notequal:
                        if ((int) BitConverter.ToUInt16(numArray2, index3 + scancheck.offset) != (int) scancheck.small)
                        {
                          ++num2;
                          break;
                        }
                        break;
                      case scanner.scanchecks.int_notequal:
                        if ((int) BitConverter.ToUInt32(numArray2, index3 + scancheck.offset) != (int) scancheck.small)
                        {
                          ++num2;
                          break;
                        }
                        break;
                    }
                  }
                  if (num2 == lpParameter.Length)
                    intList.Add(num1);
                }
                if (lpStartAddress > 0 && intList.Count >= lpStartAddress)
                  break;
              }
            }
          }
          start += lpBuffer.RegionSize;
        }
      }
      return intList;
    }

    public static string aobstring([In] string obj0)
    {
      string str = "";
      for (int index = 0; index < obj0.Length; ++index)
      {
        byte b = (byte) obj0[index];
        str += EyeStep.to_str(b);
        if (index < obj0.Length - 1)
          str += " ";
      }
      return str;
    }

    public static string ptrstring(int dwDesiredAccess)
    {
      byte[] bytes = BitConverter.GetBytes(dwDesiredAccess);
      return "" + EyeStep.to_str(bytes[0]) + EyeStep.to_str(bytes[1]) + EyeStep.to_str(bytes[2]) + EyeStep.to_str(bytes[3]);
    }

    public static List<int> scan_xrefs([In] string obj0, int bInheritHandle)
    {
      List<int> source = scanner.scan(new util.process_region()
      {
        start = util.get_section(".rdata").start,
        end = util.get_section(".data").end
      }, scanner.aobstring(obj0), 4, bInheritHandle, (scanner.scancheck[]) null);
      return source.Count > 0 ? scanner.scan(".text", scanner.ptrstring(source.Last<int>()), 1, 0, (scanner.scancheck[]) null) : throw new Exception("No results found for string");
    }

    public static List<int> scan_xrefs(int hObject)
    {
      List<int> intList = new List<int>();
      imports.MEMORY_BASIC_INFORMATION lpBuffer = new imports.MEMORY_BASIC_INFORMATION();
      int baseModule = EyeStep.base_module;
      for (int index1 = EyeStep.base_module + EyeStep.base_module_size; baseModule < index1; baseModule += lpBuffer.RegionSize)
      {
        imports.VirtualQueryEx(EyeStep.handle, baseModule, out lpBuffer, 44U);
        if (lpBuffer.Protect == 32U)
        {
          byte[] numArray = util.readBytes(baseModule, lpBuffer.RegionSize);
          for (int index2 = 0; index2 < lpBuffer.RegionSize; ++index2)
          {
            if ((numArray[index2] == (byte) 232 || numArray[index2] == (byte) 233) && util.getRel(baseModule + index2) == hObject)
              intList.Add(baseModule + index2);
          }
        }
      }
      return intList;
    }

    public enum scanchecks
    {
      byte_equal,
      word_equal,
      int_equal,
      byte_notequal,
      word_notequal,
      int_notequal,
    }

    public struct scancheck
    {
      public scanner.scanchecks type;
      public int offset;
      public uint small;
      public ulong large;

      public scancheck(scanner.scanchecks hProcess, int lpAddress, uint dwSize)
      {
        this.type = hProcess;
        this.offset = lpAddress;
        this.small = dwSize;
        this.large = 0UL;
      }
    }
  }
}
