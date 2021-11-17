// Decompiled with JetBrains decompiler
// Type: Celery.WinAPI
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using System;
using System.Runtime.InteropServices;

namespace Celery
{
  internal class WinAPI
  {
    public const int HOR_Positive = 1;
    public const int HOR_NEGATIVE = 2;
    public const int VER_POSITIVE = 4;
    public const int VER_NEGATIVE = 8;
    public const int CENTER = 16;
    public const int BLEND = 524288;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int AnimateWindow([In] IntPtr obj0, [In] int obj1, int _param2);
  }
}
