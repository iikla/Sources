// Decompiled with JetBrains decompiler
// Type: ns0.MiniGame
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns0
{
  public class MiniGame : Form
  {
    private Graphics graphics_0;
    private int int_0 = 150;
    private int int_1 = 100;
    private int int_2 = 3;
    private int int_3 = 2;
    private IContainer icontainer_0 = (IContainer) null;
    private Timer timer_0;

    public MiniGame()
    {
      this.InitializeComponent();
      this.Paint += new PaintEventHandler(this.MiniGame_Paint);
      this.DoubleBuffered = true;
    }

    private void MiniGame_Paint(object sender, PaintEventArgs e)
    {
      this.graphics_0 = e.Graphics;
      this.graphics_0.FillEllipse((Brush) new SolidBrush(Color.Blue), this.int_0, this.int_1, 10, 10);
    }

    private void method_0()
    {
      int num1 = this.int_0 + this.int_2;
      int num2 = this.int_1 + this.int_3;
      if ((num1 < -5 ? 1 : (num1 > this.ClientSize.Width ? 1 : 0)) != 0)
        this.int_2 = -this.int_2;
      if ((num2 < 0 ? 1 : (num2 > this.ClientSize.Height ? 1 : 0)) != 0)
        this.int_3 = -this.int_3;
      this.int_0 += this.int_2;
      this.int_1 += this.int_3;
      this.Invalidate();
    }

    private void MiniGame_Load(object sender, EventArgs e) => this.TopMost = true;

    private void timer_0_Tick(object sender, EventArgs e) => this.method_0();

    protected override void Dispose(bool disposing)
    {
      if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.icontainer_0 = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MiniGame));
      this.timer_0 = new Timer(this.icontainer_0);
      this.SuspendLayout();
      this.timer_0.Enabled = true;
      this.timer_0.Interval = 10;
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(60, 60, 60);
      this.ClientSize = new Size(800, 450);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (MiniGame);
      this.Text = "MiniGame (Re-Size Window To Move)";
      this.Load += new EventHandler(this.MiniGame_Load);
      this.ResumeLayout(false);
    }
  }
}
