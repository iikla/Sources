// Decompiled with JetBrains decompiler
// Type: GClass0
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

public class GClass0
{
  public static string smethod_0(string string_0)
  {
    int length = string_0.Length;
    char[] chArray = new char[length];
    for (int index = 0; index < chArray.Length; ++index)
    {
      char ch = string_0[index];
      byte num1 = (byte) ((uint) ch ^ (uint) (length - index));
      byte num2 = (byte) ((int) ch >> 8 ^ index);
      chArray[index] = (char) ((uint) num2 << 8 | (uint) num1);
    }
    return string.Intern(new string(chArray));
  }
}
