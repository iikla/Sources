// Decompiled with JetBrains decompiler
// Type: Celery.Program
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using System;
using System.Windows.Forms;

namespace Celery
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new LOADING());
    }
  }
}
