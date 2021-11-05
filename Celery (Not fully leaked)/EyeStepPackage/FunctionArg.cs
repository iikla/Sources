// Decompiled with JetBrains decompiler
// Type: EyeStepPackage.FunctionArg
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System.Runtime.InteropServices;

namespace EyeStepPackage
{
  public class FunctionArg
  {
    public int small;
    public double large;
    public string str;
    public string type;

    public FunctionArg([In] int obj0)
    {
      this.small = obj0;
      this.type = "smallvalue";
    }

    public FunctionArg(double _routine)
    {
      this.large = _routine;
      this.type = "largevalue";
    }

    public FunctionArg([In] string obj0)
    {
      this.str = obj0;
      this.type = "string";
    }
  }
}
