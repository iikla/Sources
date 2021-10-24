// Decompiled with JetBrains decompiler
// Type: ns0.SimpleUI
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using FastColoredTextBoxNS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeAreDevs_API;

namespace ns0
{
  public class SimpleUI : Form
  {
    private ExploitAPI exploitAPI_0 = new ExploitAPI();
    private Point point_0;
    private IContainer icontainer_0 = (IContainer) null;
    private Panel panel1;
    private Label label1;
    private Panel panel2;
    private Button button10;
    private Button button1;
    private FastColoredTextBox fastColoredTextBox1;
    private Button button3;
    private Button button2;
    private Button button4;
    private Button button5;
    private Button button6;

    public SimpleUI() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void button10_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void button5_Click(object sender, EventArgs e) => this.exploitAPI_0.LaunchExploit();

    private void button2_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      openFileDialog.Title = "Open";
      this.fastColoredTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
    }

    private void button3_Click(object sender, EventArgs e) => this.exploitAPI_0.SendLuaScript(this.fastColoredTextBox1.Text);

    private void button4_Click(object sender, EventArgs e) => this.fastColoredTextBox1.Clear();

    private void panel1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void SimpleUI_Load(object sender, EventArgs e) => this.TopMost = true;

    private void label1_MouseUp(object sender, MouseEventArgs e)
    {
    }

    private void label1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void label1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void button6_Click(object sender, EventArgs e) => new ScriptHub().Show();

    protected override void Dispose(bool disposing)
    {
      if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.icontainer_0 = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SimpleUI));
      this.panel1 = new Panel();
      this.button1 = new Button();
      this.button10 = new Button();
      this.panel2 = new Panel();
      this.label1 = new Label();
      this.fastColoredTextBox1 = new FastColoredTextBox();
      this.button3 = new Button();
      this.button2 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.button6 = new Button();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.fastColoredTextBox1).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(60, 60, 60);
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Controls.Add((Control) this.button10);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Location = new Point(0, -1);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(543, 41);
      this.panel1.TabIndex = 0;
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.button1.BackColor = Color.FromArgb(60, 60, 60);
      this.button1.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = SystemColors.ControlLightLight;
      this.button1.Location = new Point(509, 5);
      this.button1.Name = "button1";
      this.button1.Size = new Size(30, 27);
      this.button1.TabIndex = 15;
      this.button1.Text = "X";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button10.BackColor = Color.FromArgb(60, 60, 60);
      this.button10.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button10.FlatStyle = FlatStyle.Flat;
      this.button10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button10.ForeColor = SystemColors.ControlLightLight;
      this.button10.Location = new Point(475, 5);
      this.button10.Name = "button10";
      this.button10.Size = new Size(28, 27);
      this.button10.TabIndex = 14;
      this.button10.Text = "—";
      this.button10.UseVisualStyleBackColor = false;
      this.button10.Click += new EventHandler(this.button10_Click);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Zoom;
      this.panel2.Location = new Point(0, 1);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(44, 40);
      this.panel2.TabIndex = 11;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.Window;
      this.label1.Location = new Point(203, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(144, 21);
      this.label1.TabIndex = 4;
      this.label1.Text = "Vega X - Simple UI";
      this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
      this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
      this.label1.MouseUp += new MouseEventHandler(this.label1_MouseUp);
      this.fastColoredTextBox1.AutoCompleteBracketsList = new char[10]
      {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '"',
        '"',
        '\'',
        '\''
      };
      this.fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
      this.fastColoredTextBox1.AutoScrollMinSize = new Size(195, 70);
      this.fastColoredTextBox1.BackBrush = (Brush) null;
      this.fastColoredTextBox1.BackColor = Color.FromArgb(50, 50, 50);
      this.fastColoredTextBox1.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
      this.fastColoredTextBox1.CharHeight = 14;
      this.fastColoredTextBox1.CharWidth = 8;
      this.fastColoredTextBox1.CommentPrefix = "--";
      this.fastColoredTextBox1.Cursor = Cursors.IBeam;
      this.fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
      this.fastColoredTextBox1.Font = new Font("Courier New", 9.75f);
      this.fastColoredTextBox1.ForeColor = Color.White;
      this.fastColoredTextBox1.IndentBackColor = Color.FromArgb(40, 40, 40);
      this.fastColoredTextBox1.IsReplaceMode = false;
      this.fastColoredTextBox1.Language = Language.Lua;
      this.fastColoredTextBox1.LeftBracket = '(';
      this.fastColoredTextBox1.LeftBracket2 = '{';
      this.fastColoredTextBox1.Location = new Point(6, 46);
      this.fastColoredTextBox1.Name = "fastColoredTextBox1";
      this.fastColoredTextBox1.Paddings = new Padding(0);
      this.fastColoredTextBox1.RightBracket = ')';
      this.fastColoredTextBox1.RightBracket2 = '}';
      this.fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 0, 0, (int) byte.MaxValue);
      this.fastColoredTextBox1.ServiceColors = (ServiceColors) componentResourceManager.GetObject("fastColoredTextBox1.ServiceColors");
      this.fastColoredTextBox1.Size = new Size(525, 154);
      this.fastColoredTextBox1.TabIndex = 25;
      this.fastColoredTextBox1.Text = "-- Vega X - Simple UI\r\n\r\n-- Full-LUA Execution\r\n\r\n-- Made By 1_F0";
      this.fastColoredTextBox1.Zoom = 100;
      this.button3.BackColor = Color.FromArgb(65, 65, 65);
      this.button3.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.ForeColor = SystemColors.Control;
      this.button3.Location = new Point(12, 206);
      this.button3.Name = "button3";
      this.button3.Size = new Size(89, 30);
      this.button3.TabIndex = 26;
      this.button3.Text = "Execute";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button2.BackColor = Color.FromArgb(65, 65, 65);
      this.button2.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.ForeColor = SystemColors.Control;
      this.button2.Location = new Point(202, 206);
      this.button2.Name = "button2";
      this.button2.Size = new Size(89, 30);
      this.button2.TabIndex = 27;
      this.button2.Text = "Open File";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button4.BackColor = Color.FromArgb(65, 65, 65);
      this.button4.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.ForeColor = SystemColors.Control;
      this.button4.Location = new Point(107, 206);
      this.button4.Name = "button4";
      this.button4.Size = new Size(89, 30);
      this.button4.TabIndex = 28;
      this.button4.Text = "Clear";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button5.BackColor = Color.FromArgb(65, 65, 65);
      this.button5.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.ForeColor = SystemColors.Control;
      this.button5.Location = new Point(442, 206);
      this.button5.Name = "button5";
      this.button5.Size = new Size(89, 30);
      this.button5.TabIndex = 29;
      this.button5.Text = "Attach";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.button6.BackColor = Color.FromArgb(65, 65, 65);
      this.button6.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button6.FlatStyle = FlatStyle.Flat;
      this.button6.ForeColor = SystemColors.Control;
      this.button6.Location = new Point(297, 206);
      this.button6.Name = "button6";
      this.button6.Size = new Size(89, 30);
      this.button6.TabIndex = 30;
      this.button6.Text = "Script Hub";
      this.button6.UseVisualStyleBackColor = false;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(45, 45, 45);
      this.ClientSize = new Size(543, 245);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.fastColoredTextBox1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (SimpleUI);
      this.Text = nameof (SimpleUI);
      this.Load += new EventHandler(this.SimpleUI_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.fastColoredTextBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
