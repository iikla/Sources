// Decompiled with JetBrains decompiler
// Type: EyeStepPackage.FunctionArg
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

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
