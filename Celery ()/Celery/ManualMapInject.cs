// Decompiled with JetBrains decompiler
// Type: Celery.ManualMapInject
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Celery
{
  public static class ManualMapInject
  {
    public static bool MapInject()
    {
      Process process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + "mminj.exe");
      if (process.Id == 0)
      {
        int num1 = (int) MessageBox.Show("Failed to start mminj");
      }
      if (process.Handle == IntPtr.Zero || (int) process.Handle == 0)
      {
        int num2 = (int) MessageBox.Show("Failed to start mminj");
      }
      return true;
    }
  }
}
