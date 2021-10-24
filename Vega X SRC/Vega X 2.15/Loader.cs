// Decompiled with JetBrains decompiler
// Type: ns0.Loader
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ns0
{
  public class Loader : Form
  {
    private int int_0 = 0;
    private IContainer icontainer_0 = (IContainer) null;
    private ProgressBar progressBar1;
    private Label label2;
    private System.Windows.Forms.Timer timer_0;
    private Label label1;
    private Panel panel2;
    private Label label3;
    private Button button5;

    public Loader() => this.InitializeComponent();

    private void Loader_Load(object sender, EventArgs e)
    {
      this.TopMost = true;
      this.timer_0.Enabled = true;
      this.timer_0.Interval = 100;
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      this.int_0 += 50;
      if (this.int_0 >= 1000)
      {
        this.timer_0.Enabled = false;
        this.timer_0.Stop();
        this.Hide();
        Thread.Sleep(500);
        new VegaX().Show();
        int num = (int) MessageBox.Show("Check The Options Tab For Updates & Patch Notes!", "Made By 1_F0", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
      }
      if (this.int_0 >= 650)
      {
        this.label3.Visible = true;
        this.label2.Visible = false;
      }
      this.progressBar1.Value = this.int_0;
    }

    private void progressBar1_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void button5_Click(object sender, EventArgs e) => this.timer_0.Interval = 10;

    protected override void Dispose(bool disposing)
    {
      if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.icontainer_0 = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Loader));
      this.progressBar1 = new ProgressBar();
      this.label2 = new Label();
      this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
      this.label1 = new Label();
      this.panel2 = new Panel();
      this.label3 = new Label();
      this.button5 = new Button();
      this.SuspendLayout();
      this.progressBar1.Location = new Point(26, 56);
      this.progressBar1.Maximum = 1000;
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(344, 23);
      this.progressBar1.TabIndex = 4;
      this.progressBar1.Click += new EventHandler(this.progressBar1_Click);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(116, 90);
      this.label2.Name = "label2";
      this.label2.Size = new Size(165, 21);
      this.label2.TabIndex = 5;
      this.label2.Text = "Loading apis . . . ";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI Semibold", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(114, 12);
      this.label1.Name = "label1";
      this.label1.Size = new Size(165, 30);
      this.label1.TabIndex = 3;
      this.label1.Text = "Vega X - Loader";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Zoom;
      this.panel2.Location = new Point(3, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(48, 40);
      this.panel2.TabIndex = 12;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.White;
      this.label3.Location = new Point(145, 90);
      this.label3.Name = "label3";
      this.label3.Size = new Size(97, 21);
      this.label3.TabIndex = 13;
      this.label3.Text = "Opening . . .";
      this.label3.Visible = false;
      this.button5.BackColor = Color.FromArgb(65, 65, 65);
      this.button5.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.ForeColor = SystemColors.Control;
      this.button5.Location = new Point(299, 95);
      this.button5.Name = "button5";
      this.button5.Size = new Size(86, 30);
      this.button5.TabIndex = 14;
      this.button5.Text = "Skip Loading";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(60, 60, 60);
      this.ClientSize = new Size(399, 138);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.label3);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Loader);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Loader);
      this.Load += new EventHandler(this.Loader_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
