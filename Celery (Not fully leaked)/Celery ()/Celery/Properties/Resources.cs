// Decompiled with JetBrains decompiler
// Type: Celery.Properties.Resources
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Celery.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [SpecialName]
    internal static ResourceManager get_ResourceManager()
    {
      // ISSUE: reference to a compiler-generated field
      if (Celery.Properties.Resources.resourceMan == null)
      {
        // ISSUE: reference to a compiler-generated field
        Celery.Properties.Resources.resourceMan = new ResourceManager("Celery.Properties.Resources", typeof (Celery.Properties.Resources).Assembly);
      }
      // ISSUE: reference to a compiler-generated field
      return Celery.Properties.Resources.resourceMan;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Celery.Properties.Resources.resourceCulture;
      [param: In] set => Celery.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap _58afdad6829958a978a4a693 => (Bitmap) Celery.Properties.Resources.get_ResourceManager().GetObject("58afdad6829958a978a4a693", Celery.Properties.Resources.resourceCulture);

    internal static Bitmap cereri => (Bitmap) Celery.Properties.Resources.get_ResourceManager().GetObject(nameof (cereri), Celery.Properties.Resources.resourceCulture);

    internal static Bitmap yellow_circle_transparent_background_logo_image_free_logo_png_yellow_circle_png_2000_1902 => (Bitmap) Celery.Properties.Resources.get_ResourceManager().GetObject("yellow-circle-transparent-background-logo-image-free-logo-png-yellow-circle-png-2000_1902", Celery.Properties.Resources.resourceCulture);

    public static Settings Default
    {
      [SpecialName] get => Settings.defaultInstance;
    }
  }
}
