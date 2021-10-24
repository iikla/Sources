// Decompiled with JetBrains decompiler
// Type: ns0.AdjustableScripts
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeAreDevs_API;

namespace ns0
{
  public class AdjustableScripts : Form
  {
    private ExploitAPI exploitAPI_0 = new ExploitAPI();
    private Point point_0;
    private IContainer icontainer_0 = (IContainer) null;
    private Panel panel1;
    private Label label1;
    private Panel panel2;
    private Button button9;
    private Button button2;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox4;
    private Label label6;
    private Button button1;
    private Button button3;
    private Button button4;
    private Button button5;

    public AdjustableScripts() => this.InitializeComponent();

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void button9_Click(object sender, EventArgs e) => this.Close();

    private void button2_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      string text = this.textBox1.Text;
      if ((int) e.KeyChar != (int) Convert.ToChar((object) Keys.Return))
        return;
      this.exploitAPI_0.SendLuaScript("game.Players.LocalPlayer.Character.Humanoid.WalkSpeed = " + text);
      this.textBox1.Clear();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void AdjustableScripts_Load(object sender, EventArgs e) => this.TopMost = true;

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
    {
      string text = this.textBox2.Text;
      if ((int) e.KeyChar != (int) Convert.ToChar((object) Keys.Return))
        return;
      this.exploitAPI_0.SendLuaScript("game.Players.LocalPlayer.Character.Humanoid.JumpPower = " + text);
      this.textBox2.Clear();
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
    }

    private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
    {
      string text = this.textBox4.Text;
      if ((int) e.KeyChar != (int) Convert.ToChar((object) Keys.Return))
        return;
      this.exploitAPI_0.SendLuaScript("game.Workspace.Gravity = " + text);
      this.textBox4.Clear();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.exploitAPI_0.SendLuaScript("game.Players.LocalPlayer.Character.Humanoid.WalkSpeed = 16");
      Console.Beep();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.exploitAPI_0.SendLuaScript("game.Workspace.Gravity = 196.2");
      Console.Beep();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      this.exploitAPI_0.SendLuaScript("game.Players.LocalPlayer.Character.Humanoid.JumpPower = 50");
      Console.Beep();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      this.exploitAPI_0.SendLuaScript("game.Players.LocalPlayer.Character.Humanoid.JumpPower = 50");
      this.exploitAPI_0.SendLuaScript("game.Workspace.Gravity = 196.2");
      this.exploitAPI_0.SendLuaScript("game.Players.LocalPlayer.Character.Humanoid.WalkSpeed = 16");
      int num = (int) MessageBox.Show("All Character Modifications Have Been Reset.");
    }

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void label1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void label1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AdjustableScripts));
      this.panel1 = new Panel();
      this.button9 = new Button();
      this.button2 = new Button();
      this.panel2 = new Panel();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox4 = new TextBox();
      this.label6 = new Label();
      this.button1 = new Button();
      this.button3 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(60, 60, 60);
      this.panel1.Controls.Add((Control) this.button9);
      this.panel1.Controls.Add((Control) this.button2);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(393, 44);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.button9.BackColor = Color.FromArgb(60, 60, 60);
      this.button9.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button9.FlatStyle = FlatStyle.Flat;
      this.button9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button9.ForeColor = SystemColors.ControlLightLight;
      this.button9.Location = new Point(360, 5);
      this.button9.Name = "button9";
      this.button9.Size = new Size(30, 27);
      this.button9.TabIndex = 18;
      this.button9.Text = "X";
      this.button9.UseVisualStyleBackColor = false;
      this.button9.Click += new EventHandler(this.button9_Click);
      this.button2.BackColor = Color.FromArgb(60, 60, 60);
      this.button2.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button2.ForeColor = SystemColors.ControlLightLight;
      this.button2.Location = new Point(327, 5);
      this.button2.Name = "button2";
      this.button2.Size = new Size(30, 27);
      this.button2.TabIndex = 17;
      this.button2.Text = "—";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Zoom;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(47, 37);
      this.panel2.TabIndex = 12;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.Window;
      this.label1.Location = new Point((int) sbyte.MaxValue, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(124, 21);
      this.label1.TabIndex = 4;
      this.label1.Text = "Vega X - Scripts";
      this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
      this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = SystemColors.Control;
      this.label2.Location = new Point(90, 53);
      this.label2.Name = "label2";
      this.label2.Size = new Size(218, 25);
      this.label2.TabIndex = 207;
      this.label2.Text = "Character Modifications";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = SystemColors.Window;
      this.label3.Location = new Point(12, 86);
      this.label3.Name = "label3";
      this.label3.Size = new Size(93, 21);
      this.label3.TabIndex = 208;
      this.label3.Text = "Walkspeed:";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.Window;
      this.label4.Location = new Point(262, 87);
      this.label4.Name = "label4";
      this.label4.Size = new Size(103, 21);
      this.label4.TabIndex = 209;
      this.label4.Text = "Jump Power:";
      this.textBox1.Location = new Point(15, 111);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 210;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
      this.textBox2.Location = new Point(265, 111);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(100, 20);
      this.textBox2.TabIndex = 211;
      this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
      this.textBox2.KeyPress += new KeyPressEventHandler(this.textBox2_KeyPress);
      this.textBox4.Location = new Point(139, 111);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(100, 20);
      this.textBox4.TabIndex = 230;
      this.textBox4.TextChanged += new EventHandler(this.textBox4_TextChanged);
      this.textBox4.KeyPress += new KeyPressEventHandler(this.textBox4_KeyPress);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = SystemColors.Window;
      this.label6.Location = new Point(136, 86);
      this.label6.Name = "label6";
      this.label6.Size = new Size(65, 21);
      this.label6.TabIndex = 228;
      this.label6.Text = "Gravity:";
      this.button1.BackColor = Color.FromArgb(65, 65, 65);
      this.button1.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = SystemColors.Control;
      this.button1.Location = new Point(15, 136);
      this.button1.Name = "button1";
      this.button1.Size = new Size(100, 23);
      this.button1.TabIndex = 232;
      this.button1.Text = "RESET";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button3.BackColor = Color.FromArgb(65, 65, 65);
      this.button3.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.ForeColor = SystemColors.Control;
      this.button3.Location = new Point(139, 136);
      this.button3.Name = "button3";
      this.button3.Size = new Size(100, 23);
      this.button3.TabIndex = 233;
      this.button3.Text = "RESET";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button4.BackColor = Color.FromArgb(65, 65, 65);
      this.button4.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.ForeColor = SystemColors.Control;
      this.button4.Location = new Point(265, 136);
      this.button4.Name = "button4";
      this.button4.Size = new Size(100, 23);
      this.button4.TabIndex = 234;
      this.button4.Text = "RESET";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button5.BackColor = Color.FromArgb(65, 65, 65);
      this.button5.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.ForeColor = SystemColors.Control;
      this.button5.Location = new Point(12, 167);
      this.button5.Name = "button5";
      this.button5.Size = new Size(370, 40);
      this.button5.TabIndex = 235;
      this.button5.Text = "RESET ALL SETTINGS TO DEFAULT";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(50, 50, 50);
      this.ClientSize = new Size(394, 218);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (AdjustableScripts);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (AdjustableScripts);
      this.Load += new EventHandler(this.AdjustableScripts_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
