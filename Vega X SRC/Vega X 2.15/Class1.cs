// Decompiled with JetBrains decompiler
// Type: ns0.Class1
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System;
using System.Windows.Forms;

namespace ns0
{
  internal static class Class1
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Loader());
    }
  }
}
