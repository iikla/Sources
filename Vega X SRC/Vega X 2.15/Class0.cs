// Decompiled with JetBrains decompiler
// Type: ns0.Class0
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System.IO;
using System.Windows.Forms;

namespace ns0
{
  internal class Class0
  {
    public static OpenFileDialog openFileDialog_0;

    public static void smethod_0(ListBox listBox_0, string string_0, string string_1)
    {
      foreach (FileInfo file in new DirectoryInfo(string_0).GetFiles(string_1))
        listBox_0.Items.Add((object) file.Name);
    }

    static Class0()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Lua Files (*.lua)|*.lua|Text Files (*txt)|*.txt";
      Class0.openFileDialog_0 = openFileDialog;
    }
  }
}
