// Decompiled with JetBrains decompiler
// Type: Celery.Resize
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Celery
{
  public class Resize
  {
    private const int MOUSEEVENTF_MOVE = 1;
    private const int MOUSEEVENTF_LEFTDOWN = 2;
    private const int MOUSEEVENTF_LEFTUP = 4;
    private const int MOUSEEVENTF_RIGHTDOWN = 8;
    private const int MOUSEEVENTF_RIGHTUP = 16;
    private const int MOUSEEVENTF_MIDDLEDOWN = 32;
    private const int MOUSEEVENTF_MIDDLEUP = 64;
    private const int MOUSEEVENTF_ABSOLUTE = 32768;
    public static Form main_form;
    public static bool form_resizing;
    public static Size form_resize_start;

    [DllImport("user32.dll")]
    private static extern void mouse_event([In] int obj0, [In] int obj1, int dwFlag, int _param3, [In] int obj4);

    public static void init([In] Form obj0)
    {
      Resize.main_form = obj0;
      Resize.form_resizing = false;
      Resize.form_resize_start = new Size(obj0.Width, obj0.Height);
      obj0.ResizeBegin += new EventHandler(Resize.form_resizebegin);
      obj0.ResizeEnd += new EventHandler(Resize.form_resizeend);
      obj0.Resize += new EventHandler(Resize.form_resize);
    }

    private static void form_resizebegin([In] object obj0, [In] EventArgs obj1)
    {
      if (Resize.main_form.WindowState == FormWindowState.Minimized || Resize.main_form.WindowState == FormWindowState.Maximized)
        return;
      Resize.form_resizing = true;
      Resize.form_resize_start = new Size(Resize.main_form.Width, Resize.main_form.Height);
    }

    private static void form_resize([In] object obj0, [In] EventArgs obj1)
    {
      if (Resize.main_form.WindowState == FormWindowState.Minimized || Resize.main_form.WindowState == FormWindowState.Maximized || Resize.main_form.Width >= 300 && Resize.main_form.Height >= 120)
        return;
      Point mousePosition = Control.MousePosition;
      int x = mousePosition.X;
      mousePosition = Control.MousePosition;
      int y = mousePosition.Y;
      Resize.mouse_event(4, x, y, 0, 0);
      if (Resize.main_form.Width < 300)
        Resize.main_form.Width = 304;
      if (Resize.main_form.Height >= 120)
        return;
      Resize.main_form.Height = 124;
    }

    public static void form_resizeend([In] object obj0, [In] EventArgs obj1)
    {
      Resize.form_resizing = false;
      Resize.form_resize_start = new Size(Resize.main_form.Width, Resize.main_form.Height);
    }
  }
}
