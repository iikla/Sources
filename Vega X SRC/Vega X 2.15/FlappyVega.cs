// Decompiled with JetBrains decompiler
// Type: ns0.FlappyVega
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
  public class FlappyVega : Form
  {
    private int int_0 = 5;
    private int int_1 = 7;
    private int int_2 = 0;
    private Point point_0;
    private IContainer icontainer_0 = (IContainer) null;
    private Panel panel1;
    private Panel panel2;
    private Label label1;
    private PictureBox ground;
    private PictureBox pipedown;
    private PictureBox bird;
    private PictureBox pipeup;
    private Label Score;
    private System.Windows.Forms.Timer timer_0;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;

    public FlappyVega() => this.InitializeComponent();

    private void timer_0_Tick(object sender, EventArgs e)
    {
      this.bird.Top += this.int_1;
      this.pipedown.Left -= this.int_0;
      this.pipeup.Left -= this.int_0;
      this.Score.Text = this.int_2.ToString();
      if (this.pipedown.Left < -600)
      {
        this.pipedown.Left = 800;
        ++this.int_2;
      }
      if (this.pipeup.Left < -650)
      {
        this.pipeup.Left = 800;
        ++this.int_2;
      }
      if ((this.bird.Bounds.IntersectsWith(this.pipedown.Bounds) || this.bird.Bounds.IntersectsWith(this.pipeup.Bounds) || this.bird.Bounds.IntersectsWith(this.ground.Bounds) ? 1 : (this.bird.Bounds.IntersectsWith(this.panel1.Bounds) ? 1 : 0)) == 0)
        return;
      this.method_0();
    }

    private void FlappyVega_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F)
        this.Close();
      if (e.KeyCode == Keys.A)
      {
        this.timer_0.Interval = 20;
        this.Score.Text += " ";
        Thread.Sleep(50);
        this.Score.Text += "Current Mode = EASY";
      }
      if (e.KeyCode == Keys.Z)
      {
        this.timer_0.Interval = 3;
        this.Score.Text += " ";
        Thread.Sleep(50);
        this.Score.Text += "Current Mode = EXPERT";
      }
      if (e.KeyCode == Keys.Q)
      {
        this.timer_0.Interval = 10;
        this.Score.Text += " ";
        Thread.Sleep(50);
        this.Score.Text += "Current Mode = HARD";
      }
      if (e.KeyCode == Keys.E)
      {
        this.timer_0.Enabled = true;
        this.label2.Visible = false;
        this.label3.Visible = false;
        this.label4.Visible = false;
        this.label5.Visible = false;
        this.label6.Visible = false;
      }
      if (e.KeyCode != Keys.Space)
        return;
      this.int_1 = -7;
    }

    private void method_0()
    {
      this.timer_0.Stop();
      this.Score.Text += "Game Over";
      this.Close();
    }

    private void FlappyVega_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Space)
        return;
      this.int_1 = 7;
    }

    private void FlappyVega_Load(object sender, EventArgs e) => this.TopMost = true;

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void method_1(object sender, EventArgs e) => this.Close();

    private void method_2(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void label5_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.icontainer_0 = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FlappyVega));
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.label1 = new Label();
      this.ground = new PictureBox();
      this.pipedown = new PictureBox();
      this.bird = new PictureBox();
      this.pipeup = new PictureBox();
      this.Score = new Label();
      this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.ground).BeginInit();
      ((ISupportInitialize) this.pipedown).BeginInit();
      ((ISupportInitialize) this.bird).BeginInit();
      ((ISupportInitialize) this.pipeup).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(60, 60, 60);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(800, 40);
      this.panel1.TabIndex = 1;
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Zoom;
      this.panel2.Location = new Point(1, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(44, 40);
      this.panel2.TabIndex = 10;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.Window;
      this.label1.Location = new Point(324, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(162, 21);
      this.label1.TabIndex = 3;
      this.label1.Text = "Vega X - Flappy Vega";
      this.ground.Image = (Image) componentResourceManager.GetObject("ground.Image");
      this.ground.Location = new Point(-1, 404);
      this.ground.Name = "ground";
      this.ground.Size = new Size(800, 144);
      this.ground.SizeMode = PictureBoxSizeMode.CenterImage;
      this.ground.TabIndex = 2;
      this.ground.TabStop = false;
      this.pipedown.Image = (Image) componentResourceManager.GetObject("pipedown.Image");
      this.pipedown.Location = new Point(564, 281);
      this.pipedown.Name = "pipedown";
      this.pipedown.Size = new Size(99, 123);
      this.pipedown.SizeMode = PictureBoxSizeMode.Zoom;
      this.pipedown.TabIndex = 3;
      this.pipedown.TabStop = false;
      this.bird.Image = (Image) componentResourceManager.GetObject("bird.Image");
      this.bird.Location = new Point(96, 178);
      this.bird.Name = "bird";
      this.bird.Size = new Size(49, 50);
      this.bird.SizeMode = PictureBoxSizeMode.Zoom;
      this.bird.TabIndex = 4;
      this.bird.TabStop = false;
      this.pipeup.Image = (Image) componentResourceManager.GetObject("pipeup.Image");
      this.pipeup.Location = new Point(630, 40);
      this.pipeup.Name = "pipeup";
      this.pipeup.Size = new Size(91, 118);
      this.pipeup.SizeMode = PictureBoxSizeMode.Zoom;
      this.pipeup.TabIndex = 5;
      this.pipeup.TabStop = false;
      this.Score.AutoSize = true;
      this.Score.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Score.ForeColor = SystemColors.Window;
      this.Score.Location = new Point(12, 418);
      this.Score.Name = "Score";
      this.Score.Size = new Size(0, 21);
      this.Score.TabIndex = 15;
      this.timer_0.Interval = 20;
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = SystemColors.Window;
      this.label2.Location = new Point(12, 55);
      this.label2.Name = "label2";
      this.label2.Size = new Size(208, 32);
      this.label2.TabIndex = 11;
      this.label2.Text = "Press 'E' To START";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = SystemColors.Window;
      this.label3.Location = new Point(11, 348);
      this.label3.Name = "label3";
      this.label3.Size = new Size(196, 21);
      this.label3.TabIndex = 16;
      this.label3.Text = "Press 'Q' For HARD Mode";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.Window;
      this.label4.Location = new Point(11, 372);
      this.label4.Name = "label4";
      this.label4.Size = new Size(217, 21);
      this.label4.TabIndex = 17;
      this.label4.Text = "Press 'Z' For EXTREME Mode";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = SystemColors.Window;
      this.label5.Location = new Point(11, 324);
      this.label5.Name = "label5";
      this.label5.Size = new Size(188, 21);
      this.label5.TabIndex = 18;
      this.label5.Text = "Press 'A' For EASY Mode";
      this.label5.Click += new EventHandler(this.label5_Click);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Red;
      this.label6.Location = new Point(110, 226);
      this.label6.Name = "label6";
      this.label6.Size = new Size(203, 21);
      this.label6.TabIndex = 19;
      this.label6.Text = "Tip: Press 'Space' To Jump!";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = SystemColors.Window;
      this.label7.Location = new Point(241, 363);
      this.label7.Name = "label7";
      this.label7.Size = new Size(317, 32);
      this.label7.TabIndex = 20;
      this.label7.Text = "Press 'F' To Close The Game";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(50, 50, 50);
      this.ClientSize = new Size(800, 450);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.Score);
      this.Controls.Add((Control) this.pipeup);
      this.Controls.Add((Control) this.bird);
      this.Controls.Add((Control) this.pipedown);
      this.Controls.Add((Control) this.ground);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FlappyVega);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Flappy Vega Minigame";
      this.Load += new EventHandler(this.FlappyVega_Load);
      this.KeyDown += new KeyEventHandler(this.FlappyVega_KeyDown);
      this.KeyUp += new KeyEventHandler(this.FlappyVega_KeyUp);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.ground).EndInit();
      ((ISupportInitialize) this.pipedown).EndInit();
      ((ISupportInitialize) this.bird).EndInit();
      ((ISupportInitialize) this.pipeup).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
