// Decompiled with JetBrains decompiler
// Type: ns1.Class2
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns1
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class Class2
  {
    private static ResourceManager resourceManager_0;
    private static CultureInfo cultureInfo_0;

    internal Class2()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Class2.resourceManager_0 == null)
          Class2.resourceManager_0 = new ResourceManager("Vega_X.Properties.Resources", typeof (Class2).Assembly);
        return Class2.resourceManager_0;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Class2.cultureInfo_0;
      set => Class2.cultureInfo_0 = value;
    }
  }
}
