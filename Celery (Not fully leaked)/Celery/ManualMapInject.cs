// Decompiled with JetBrains decompiler
// Type: Celery.ManualMapInject
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

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
