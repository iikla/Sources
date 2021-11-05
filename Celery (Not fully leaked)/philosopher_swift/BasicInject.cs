// Decompiled with JetBrains decompiler
// Type: philosopher_swift.BasicInject
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace philosopher_swift
{
  public class BasicInject
  {
    [DllImport("kernel32")]
    public static extern IntPtr CreateRemoteThread(
      [In] IntPtr obj0,
      [In] IntPtr obj1,
      [In] uint obj2,
      UIntPtr dwFreeType,
      [In] IntPtr obj4,
      [In] uint obj5,
      [In] ref IntPtr obj6);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess([In] uint obj0, [In] int obj1, [In] int obj2);

    [DllImport("kernel32.dll")]
    public static extern int CloseHandle([In] IntPtr obj0);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool VirtualFreeEx([In] IntPtr obj0, [In] IntPtr obj1, [In] UIntPtr obj2, uint nSize);

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
    public static extern UIntPtr GetProcAddress([In] IntPtr obj0, string milliseconds);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr VirtualAllocEx(
      IntPtr hProcess,
      IntPtr strDLLName,
      [In] uint obj2,
      [In] uint obj3,
      [In] uint obj4);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(
      [In] IntPtr obj0,
      [In] IntPtr obj1,
      string resize_y,
      UIntPtr reposition_x,
      ref IntPtr reposition_y);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle([In] string obj0);

    [DllImport("kernel32", SetLastError = true)]
    internal static extern int WaitForSingleObject([In] IntPtr obj0, [In] int obj1);

    public static int GetProcessId(string sender) => Process.GetProcessesByName(sender)[0].Id;

    public static unsafe void InjectDLL([In] IntPtr obj0, string e)
    {
      int num1 = e.Length + 1;
      IntPtr num2 = BasicInject.VirtualAllocEx(obj0, (IntPtr) (void*) null, (uint) num1, 4096U, 64U);
      IntPtr reposition_y;
      BasicInject.WriteProcessMemory(obj0, num2, e, (UIntPtr) (ulong) num1, ref reposition_y);
      UIntPtr procAddress = BasicInject.GetProcAddress(BasicInject.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
      IntPtr remoteThread = BasicInject.CreateRemoteThread(obj0, (IntPtr) (void*) null, 0U, procAddress, num2, 0U, ref reposition_y);
      Thread.Sleep(1000);
      BasicInject.VirtualFreeEx(obj0, num2, (UIntPtr) 0UL, 32768U);
      BasicInject.CloseHandle(remoteThread);
    }
  }
}
