// Decompiled with JetBrains decompiler
// Type: Celery.auto_hook
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using EyeStepPackage;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Celery
{
  internal class auto_hook
  {
    public static bool injecting;
    public static bool injected;
    public static int injected_proc_id;

    private static void inject([In] int obj0)
    {
      int procAddress1 = imports.GetProcAddress(imports.GetModuleHandle("ntdll.dll"), "LdrFindResource_U");
      uint num1 = util.setPageProtect(procAddress1, 64U, 1);
      util.writeBytes(procAddress1, new byte[5]
      {
        (byte) 139,
        byte.MaxValue,
        (byte) 85,
        (byte) 139,
        (byte) 236
      }, -1);
      int num2 = (int) util.setPageProtect(procAddress1, num1, 1);
      int procAddress2 = imports.GetProcAddress(imports.GetModuleHandle("ntdll.dll"), "LdrLoadDll");
      int address1 = imports.GetProcAddress(imports.GetModuleHandle("KERNELBASE.dll"), "LoadLibraryExW");
      byte[] numArray = util.readBytes(address1, 512);
      for (int index = 0; index < numArray.Length; ++index)
      {
        if (numArray[index] == byte.MaxValue && numArray[index + 1] == (byte) 21)
        {
          int address2 = util.readInt(address1 + index + 2);
          if (util.readInt(address2) == procAddress2)
          {
            address1 = address2;
            break;
          }
        }
      }
      uint num3 = util.setPageProtect(procAddress2 - 5, 64U, 1);
      util.writeBytes(procAddress2 - 5, new byte[5]
      {
        (byte) 85,
        (byte) 139,
        (byte) 236,
        (byte) 235,
        (byte) 5
      }, -1);
      int num4 = (int) util.setPageProtect(procAddress2 - 5, num3, 1);
      uint num5 = util.setPageProtect(address1, 64U, 1);
      util.writeInt(address1, procAddress2 - 5);
      int num6 = (int) util.setPageProtect(address1, num5, 1);
      if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "dll\\celery.bin"))
        File.Exists(AppDomain.CurrentDomain.BaseDirectory + "dll\\celery.dll");
      auto_hook.injected_proc_id = obj0;
      auto_hook.injected = true;
    }

    public static bool quick_inject()
    {
      if (auto_hook.injecting)
        return true;
      bool flag = true;
      Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
      if (processesByName.Length == 1)
      {
        if (processesByName[0].Id != auto_hook.injected_proc_id)
        {
          auto_hook.injected_proc_id = 0;
          auto_hook.injected = false;
          flag = false;
          if (EyeStep.open("RobloxPlayerBeta.exe"))
          {
            auto_hook.injecting = true;
            ManualMapInject.MapInject();
            auto_hook.injected_proc_id = processesByName[0].Id;
            auto_hook.injected = true;
            auto_hook.injecting = false;
          }
        }
      }
      else
      {
        auto_hook.injected_proc_id = 0;
        auto_hook.injected = false;
        flag = false;
      }
      return flag;
    }

    public static void on_update()
    {
      if (auto_hook.injecting)
        return;
      Process[] procs = Process.GetProcessesByName("RobloxPlayerBeta");
      if (procs.Length == 1)
      {
        if (procs[0].Id == auto_hook.injected_proc_id)
          return;
        auto_hook.injected_proc_id = 0;
        auto_hook.injected = false;
        if (!EyeStep.open("RobloxPlayerBeta.exe"))
          return;
        auto_hook.injecting = true;
        new Thread((ThreadStart) (() =>
        {
          Thread.CurrentThread.IsBackground = true;
          Thread.Sleep(5000);
          ManualMapInject.MapInject();
          auto_hook.injected_proc_id = procs[0].Id;
          auto_hook.injected = true;
          auto_hook.injecting = false;
        })).Start();
      }
      else
      {
        auto_hook.injected_proc_id = 0;
        auto_hook.injected = false;
      }
    }

    public static bool check_injected() => auto_hook.injected_proc_id != 0 && auto_hook.injected;
  }
}
