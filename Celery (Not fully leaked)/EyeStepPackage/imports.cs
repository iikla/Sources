// Decompiled with JetBrains decompiler
// Type: EyeStepPackage.imports
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System.Runtime.InteropServices;

namespace EyeStepPackage
{
  public class imports
  {
    public const uint PAGE_NOACCESS = 1;
    public const uint PAGE_READONLY = 2;
    public const uint PAGE_READWRITE = 4;
    public const uint PAGE_WRITECOPY = 8;
    public const uint PAGE_EXECUTE = 16;
    public const uint PAGE_EXECUTE_READ = 32;
    public const uint PAGE_EXECUTE_READWRITE = 64;
    public const uint PAGE_EXECUTE_WRITECOPY = 128;
    public const uint PAGE_GUARD = 256;
    public const uint PAGE_NOCACHE = 512;
    public const uint PAGE_WRITECOMBINE = 1024;
    public const uint MEM_COMMIT = 4096;
    public const uint MEM_RESERVE = 8192;
    public const uint MEM_DECOMMIT = 16384;
    public const uint MEM_RELEASE = 32768;
    public const uint PROCESS_WM_READ = 16;
    public const uint PROCESS_ALL_ACCESS = 2035711;
    public const int EXCEPTION_CONTINUE_EXECUTION = -1;
    public const int EXCEPTION_CONTINUE_SEARCH = 0;

    [DllImport("kernel32.dll")]
    public static extern int OpenProcess(
      uint dwDesiredAccess,
      bool bInheritHandle,
      int dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(
      int hProcess,
      int lpBaseAddress,
      byte[] lpBuffer,
      int dwSize,
      ref int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(
      int hProcess,
      int lpBaseAddress,
      byte[] lpBuffer,
      int dwSize,
      ref int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    public static extern bool VirtualProtectEx(
      int hProcess,
      int lpBaseAddress,
      int dwSize,
      uint new_protect,
      ref uint lpOldProtect);

    [DllImport("kernel32.dll")]
    public static extern int VirtualQueryEx(
      int hProcess,
      int lpAddress,
      out imports.MEMORY_BASIC_INFORMATION lpBuffer,
      uint dwLength);

    [DllImport("kernel32.dll")]
    public static extern int VirtualAllocEx(
      int hProcess,
      int lpAddress,
      int size,
      uint allocation_type,
      uint protect);

    [DllImport("kernel32.dll")]
    public static extern int VirtualFreeEx(
      int hProcess,
      int lpAddress,
      int size,
      uint allocation_type);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern int GetModuleHandle(string lpModuleName);

    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern int GetProcAddress(int hModule, string procName);

    [DllImport("kernel32.dll")]
    public static extern int CreateRemoteThread(
      int hProcess,
      int lpThreadAttributes,
      uint dwStackSize,
      int lpStartAddress,
      int lpParameter,
      uint dwCreationFlags,
      out int lpThreadId);

    public struct MEMORY_BASIC_INFORMATION
    {
      public int BaseAddress;
      public int AllocationBase;
      public uint AllocationProtect;
      public int RegionSize;
      public uint State;
      public uint Protect;
      public uint Type;
    }
  }
}
