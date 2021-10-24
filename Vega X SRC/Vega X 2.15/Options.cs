// Decompiled with JetBrains decompiler
// Type: ns0.Options
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using WeAreDevs_API;

namespace ns0
{
  public class Options : Form
  {
    private ExploitAPI exploitAPI_0 = new ExploitAPI();
    private Point point_0;
    private IContainer icontainer_0 = (IContainer) null;
    private Panel panel1;
    private Button button1;
    private Button button2;
    private Label label1;
    private Panel panel2;
    private Button button4;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private Button button5;
    private Button button8;
    private Button button9;
    private Button button10;
    private Button button11;
    private Button button12;
    private CheckBox checkBox3;
    private Button button3;
    private Button button13;
    private Panel panel5;
    private Label label2;
    private Label label3;
    private RichTextBox richTextBox1;
    private Button button15;
    private Button button16;
    private Button button7;
    private Button button17;
    private Button button6;
    private Button button18;
    private Button button19;
    private RichTextBox richTextBox2;
    private Label label4;
    private Button button20;
    private Button button21;
    private Button button14;

    public Options() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      foreach (Process process in Process.GetProcesses())
      {
        if (process.ProcessName == "RobloxPlayerBeta")
          process.Kill();
      }
    }

    private void method_0(object sender, EventArgs e) => this.TopMost = true;

    private void method_1(object sender, EventArgs e) => this.TopMost = false;

    private void button4_Click(object sender, EventArgs e)
    {
      string Script = new WebClient().DownloadString("https://the-shed.dev/scripts/sbp.lua");
      this.exploitAPI_0.SendLuaScript(Script);
      this.exploitAPI_0.SendLuaCScript(Script);
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

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void label1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      string Script = new WebClient().DownloadString("https://pastebin.com/raw/sVxD31v1");
      this.exploitAPI_0.SendLuaScript(Script);
      this.exploitAPI_0.SendLuaCScript(Script);
    }

    private void Options_Load(object sender, EventArgs e) => this.TopMost = true;

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      string Script = new WebClient().DownloadString("https://pastebin.com/raw/pQF6rXMm");
      this.exploitAPI_0.SendLuaScript(Script);
      this.exploitAPI_0.SendLuaCScript(Script);
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void button5_Click(object sender, EventArgs e) => this.exploitAPI_0.SendLuaScript(new WebClient().DownloadString("https://pastebin.com/raw/SiqScdtW"));

    private void method_2(object sender, EventArgs e)
    {
    }

    private void method_3(object sender, EventArgs e)
    {
    }

    private void button8_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.youtube.com/channel/UCPnCsR8_hY_z7tceY5-0KSA?sub_confirmation=1");
      Process.Start("https://www.roblox.com/groups/3872274/Pr0Ph3cy#!/about");
    }

    private void button9_Click(object sender, EventArgs e) => Process.Start("https://obfuscator.aztupscripts.xyz/");

    private void method_4(object sender, EventArgs e)
    {
    }

    private void button10_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void button11_Click(object sender, EventArgs e) => new SimpleUI().Show();

    private void button12_Click(object sender, EventArgs e) => this.exploitAPI_0.SendLuaScript(new WebClient().DownloadString("https://pastebin.com/raw/D4dWs2Vc"));

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      VegaX vegaX = Application.OpenForms.OfType<VegaX>().FirstOrDefault<VegaX>();
      if (vegaX == null)
        return;
      vegaX.TopMost = this.checkBox3.Checked;
      this.TopMost = false;
    }

    private void method_5(object sender, EventArgs e)
    {
    }

    private void method_6(object sender, EventArgs e) => Process.Start("https://www.youtube.com/channel/UCPnCsR8_hY_z7tceY5-0KSA?sub_confirmation=1");

    private void button3_Click(object sender, EventArgs e) => new MiniGame().Show();

    private void button13_Click(object sender, EventArgs e) => Process.Start("https://pastebin.com/raw/cFWfNhmW");

    private void method_7(object sender, EventArgs e) => this.Close();

    private void button14_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Kill Roblox: Closes Roblox | Attach Method 2: A Faster Attaching Method | Boost FPS: Limits Graphics | Bypass AC: Bypasses *SOME* Anti-Cheats | TopMost: Puts Vega On Top Of Other Programs | Anti-AFK: Prevents Getting Kicked For Inactivity");
    }

    private void button16_Click(object sender, EventArgs e) => Process.Start("https://up-to-down.net/82375/VegaExecutor");

    private void button15_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("1_F0 - Making The Exploit", "Vega X | Credits", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
    }

    private void button7_Click(object sender, EventArgs e) => this.Close();

    private void button17_Click(object sender, EventArgs e) => Process.Start("https://1f0discordlink.weebly.com/");

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void button6_Click(object sender, EventArgs e) => new FlappyVega().Show();

    private void button18_Click(object sender, EventArgs e) => new AdjustableScripts().Show();

    private void button19_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Everything Seems To Be Working Fine.", "Vega X | Status", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
    }

    private void button20_Click(object sender, EventArgs e) => this.exploitAPI_0.SendLuaScript(this.richTextBox2.Text);

    private void button21_Click(object sender, EventArgs e) => this.richTextBox2.Clear();

    protected override void Dispose(bool disposing)
    {
      if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Options));
      this.panel1 = new Panel();
      this.button7 = new Button();
      this.button10 = new Button();
      this.panel2 = new Panel();
      this.label1 = new Label();
      this.button1 = new Button();
      this.button2 = new Button();
      this.button4 = new Button();
      this.checkBox1 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.button5 = new Button();
      this.button8 = new Button();
      this.button9 = new Button();
      this.button11 = new Button();
      this.button12 = new Button();
      this.checkBox3 = new CheckBox();
      this.button3 = new Button();
      this.button13 = new Button();
      this.panel5 = new Panel();
      this.label2 = new Label();
      this.label3 = new Label();
      this.richTextBox1 = new RichTextBox();
      this.button15 = new Button();
      this.button16 = new Button();
      this.button17 = new Button();
      this.button6 = new Button();
      this.button18 = new Button();
      this.button19 = new Button();
      this.richTextBox2 = new RichTextBox();
      this.label4 = new Label();
      this.button20 = new Button();
      this.button21 = new Button();
      this.button14 = new Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(60, 60, 60);
      this.panel1.Controls.Add((Control) this.button7);
      this.panel1.Controls.Add((Control) this.button10);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Location = new Point(-1, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(744, 40);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.button7.BackColor = Color.FromArgb(60, 60, 60);
      this.button7.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button7.FlatStyle = FlatStyle.Flat;
      this.button7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button7.ForeColor = SystemColors.ControlLightLight;
      this.button7.Location = new Point(709, 5);
      this.button7.Name = "button7";
      this.button7.Size = new Size(30, 27);
      this.button7.TabIndex = 14;
      this.button7.Text = "X";
      this.button7.UseVisualStyleBackColor = false;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.button10.BackColor = Color.FromArgb(60, 60, 60);
      this.button10.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button10.FlatStyle = FlatStyle.Flat;
      this.button10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button10.ForeColor = SystemColors.ControlLightLight;
      this.button10.Location = new Point(676, 5);
      this.button10.Name = "button10";
      this.button10.Size = new Size(30, 27);
      this.button10.TabIndex = 13;
      this.button10.Text = "—";
      this.button10.UseVisualStyleBackColor = false;
      this.button10.Click += new EventHandler(this.button10_Click);
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
      this.label1.Location = new Point(305, 8);
      this.label1.Name = "label1";
      this.label1.Size = new Size(132, 21);
      this.label1.TabIndex = 3;
      this.label1.Text = "Vega X - Options";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
      this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
      this.button1.BackColor = Color.FromArgb(65, 65, 65);
      this.button1.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = SystemColors.Control;
      this.button1.Location = new Point(12, 82);
      this.button1.Name = "button1";
      this.button1.Size = new Size(128, 30);
      this.button1.TabIndex = 4;
      this.button1.Text = "Kill Roblox";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.BackColor = Color.FromArgb(65, 65, 65);
      this.button2.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.ForeColor = SystemColors.Control;
      this.button2.Location = new Point(146, 118);
      this.button2.Name = "button2";
      this.button2.Size = new Size(123, 30);
      this.button2.TabIndex = 5;
      this.button2.Text = "Unlock / Boost FPS";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button4.BackColor = Color.FromArgb(65, 65, 65);
      this.button4.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.ForeColor = SystemColors.Control;
      this.button4.Location = new Point(12, 280);
      this.button4.Name = "button4";
      this.button4.Size = new Size(258, 38);
      this.button4.TabIndex = 13;
      this.button4.Text = "Chat Bypass Script";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.checkBox1.AutoSize = true;
      this.checkBox1.ForeColor = SystemColors.Control;
      this.checkBox1.Location = new Point(18, 154);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(67, 17);
      this.checkBox1.TabIndex = 23;
      this.checkBox1.Text = "Anti-AFK";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.ForeColor = SystemColors.Control;
      this.checkBox2.Location = new Point(186, 155);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(77, 17);
      this.checkBox2.TabIndex = 24;
      this.checkBox2.Text = "Bypass AC";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.button5.BackColor = Color.FromArgb(65, 65, 65);
      this.button5.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.ForeColor = SystemColors.Control;
      this.button5.Location = new Point(12, 118);
      this.button5.Name = "button5";
      this.button5.Size = new Size(128, 29);
      this.button5.TabIndex = 26;
      this.button5.Text = "Force Reset Character";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.button8.BackColor = Color.FromArgb(65, 65, 65);
      this.button8.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button8.FlatStyle = FlatStyle.Flat;
      this.button8.ForeColor = SystemColors.Control;
      this.button8.Location = new Point(12, 245);
      this.button8.Name = "button8";
      this.button8.Size = new Size(258, 30);
      this.button8.TabIndex = 28;
      this.button8.Text = "YouTube Channel / Roblox Group Links";
      this.button8.UseVisualStyleBackColor = false;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button9.BackColor = Color.FromArgb(65, 65, 65);
      this.button9.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button9.FlatStyle = FlatStyle.Flat;
      this.button9.ForeColor = SystemColors.Control;
      this.button9.Location = new Point(12, 207);
      this.button9.Name = "button9";
      this.button9.Size = new Size(128, 32);
      this.button9.TabIndex = 29;
      this.button9.Text = "Obfuscate Script";
      this.button9.UseVisualStyleBackColor = false;
      this.button9.Click += new EventHandler(this.button9_Click);
      this.button11.BackColor = Color.FromArgb(65, 65, 65);
      this.button11.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button11.FlatStyle = FlatStyle.Flat;
      this.button11.ForeColor = SystemColors.Control;
      this.button11.Location = new Point(146, 207);
      this.button11.Name = "button11";
      this.button11.Size = new Size(124, 32);
      this.button11.TabIndex = 30;
      this.button11.Text = "Simple UI";
      this.button11.UseVisualStyleBackColor = false;
      this.button11.Click += new EventHandler(this.button11_Click);
      this.button12.BackColor = Color.FromArgb(65, 65, 65);
      this.button12.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button12.FlatStyle = FlatStyle.Flat;
      this.button12.ForeColor = SystemColors.Control;
      this.button12.Location = new Point(12, 177);
      this.button12.Name = "button12";
      this.button12.Size = new Size(259, 24);
      this.button12.TabIndex = 31;
      this.button12.Text = "Disable Respawn";
      this.button12.UseVisualStyleBackColor = false;
      this.button12.Click += new EventHandler(this.button12_Click);
      this.checkBox3.AutoSize = true;
      this.checkBox3.ForeColor = SystemColors.Control;
      this.checkBox3.Location = new Point(103, 154);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(68, 17);
      this.checkBox3.TabIndex = 32;
      this.checkBox3.Text = "TopMost";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
      this.button3.BackColor = Color.FromArgb(65, 65, 65);
      this.button3.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.ForeColor = SystemColors.Control;
      this.button3.Location = new Point(12, 324);
      this.button3.Name = "button3";
      this.button3.Size = new Size(128, 30);
      this.button3.TabIndex = 33;
      this.button3.Text = "Easy Minigame";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button13.BackColor = Color.FromArgb(65, 65, 65);
      this.button13.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button13.FlatStyle = FlatStyle.Flat;
      this.button13.ForeColor = SystemColors.Control;
      this.button13.Location = new Point(146, 324);
      this.button13.Name = "button13";
      this.button13.Size = new Size(124, 30);
      this.button13.TabIndex = 35;
      this.button13.Text = "Version Checker";
      this.button13.UseVisualStyleBackColor = false;
      this.button13.Click += new EventHandler(this.button13_Click);
      this.panel5.BackColor = Color.Transparent;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.ForeColor = SystemColors.ControlLightLight;
      this.panel5.Location = new Point(277, 82);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(15, 315);
      this.panel5.TabIndex = 125;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = SystemColors.Window;
      this.label2.Location = new Point(75, 52);
      this.label2.Name = "label2";
      this.label2.Size = new Size(134, 21);
      this.label2.TabIndex = 14;
      this.label2.Text = "Vega X - Settings";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = SystemColors.Window;
      this.label3.Location = new Point(365, 52);
      this.label3.Name = "label3";
      this.label3.Size = new Size(117, 21);
      this.label3.TabIndex = 126;
      this.label3.Text = "Vega X - Extras";
      this.richTextBox1.BackColor = Color.FromArgb(30, 30, 30);
      this.richTextBox1.BorderStyle = BorderStyle.None;
      this.richTextBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBox1.ForeColor = SystemColors.Window;
      this.richTextBox1.ImeMode = ImeMode.On;
      this.richTextBox1.Location = new Point(298, 82);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
      this.richTextBox1.Size = new Size(262, 146);
      this.richTextBox1.TabIndex = (int) sbyte.MaxValue;
      this.richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
      this.richTextBox1.TextChanged += new EventHandler(this.richTextBox1_TextChanged);
      this.button15.BackColor = Color.FromArgb(65, 65, 65);
      this.button15.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button15.FlatStyle = FlatStyle.Flat;
      this.button15.ForeColor = SystemColors.Control;
      this.button15.Location = new Point(298, 324);
      this.button15.Name = "button15";
      this.button15.Size = new Size(123, 30);
      this.button15.TabIndex = 130;
      this.button15.Text = "Credits";
      this.button15.UseVisualStyleBackColor = false;
      this.button15.Click += new EventHandler(this.button15_Click);
      this.button16.BackColor = Color.FromArgb(65, 65, 65);
      this.button16.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button16.FlatStyle = FlatStyle.Flat;
      this.button16.ForeColor = SystemColors.Control;
      this.button16.Location = new Point(427, 324);
      this.button16.Name = "button16";
      this.button16.Size = new Size(133, 30);
      this.button16.TabIndex = 131;
      this.button16.Text = "Newest Verison";
      this.button16.UseVisualStyleBackColor = false;
      this.button16.Click += new EventHandler(this.button16_Click);
      this.button17.BackColor = Color.FromArgb(65, 65, 65);
      this.button17.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button17.FlatStyle = FlatStyle.Flat;
      this.button17.ForeColor = SystemColors.Control;
      this.button17.Location = new Point(298, 360);
      this.button17.Name = "button17";
      this.button17.Size = new Size(262, 37);
      this.button17.TabIndex = 132;
      this.button17.Text = "Join My Community Discord Server";
      this.button17.UseVisualStyleBackColor = false;
      this.button17.Click += new EventHandler(this.button17_Click);
      this.button6.BackColor = Color.FromArgb(65, 65, 65);
      this.button6.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button6.FlatStyle = FlatStyle.Flat;
      this.button6.ForeColor = SystemColors.Control;
      this.button6.Location = new Point(146, 82);
      this.button6.Name = "button6";
      this.button6.Size = new Size(123, 30);
      this.button6.TabIndex = 133;
      this.button6.Text = "Flappy Bird";
      this.button6.UseVisualStyleBackColor = false;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.button18.BackColor = Color.FromArgb(65, 65, 65);
      this.button18.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button18.FlatStyle = FlatStyle.Flat;
      this.button18.ForeColor = SystemColors.Control;
      this.button18.Location = new Point(298, 234);
      this.button18.Name = "button18";
      this.button18.Size = new Size(262, 41);
      this.button18.TabIndex = 134;
      this.button18.Text = "Adjustable Scripts Menu";
      this.button18.UseVisualStyleBackColor = false;
      this.button18.Click += new EventHandler(this.button18_Click);
      this.button19.BackColor = Color.FromArgb(65, 65, 65);
      this.button19.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button19.FlatStyle = FlatStyle.Flat;
      this.button19.ForeColor = SystemColors.Control;
      this.button19.Location = new Point(298, 280);
      this.button19.Name = "button19";
      this.button19.Size = new Size(262, 38);
      this.button19.TabIndex = 135;
      this.button19.Text = "Troubleshoot Tester";
      this.button19.UseVisualStyleBackColor = false;
      this.button19.Click += new EventHandler(this.button19_Click);
      this.richTextBox2.BackColor = Color.FromArgb(30, 30, 30);
      this.richTextBox2.BorderStyle = BorderStyle.None;
      this.richTextBox2.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBox2.ForeColor = Color.ForestGreen;
      this.richTextBox2.Location = new Point(566, 82);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.Size = new Size(165, 221);
      this.richTextBox2.TabIndex = 136;
      this.richTextBox2.Text = "-- Vega X - Alternative Execution Method\n\n-- Full LUA Compatible\n\n-- Made By Youtube.com/1f0yt\n";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.Window;
      this.label4.Location = new Point(574, 52);
      this.label4.Name = "label4";
      this.label4.Size = new Size(146, 21);
      this.label4.TabIndex = 137;
      this.label4.Text = "Alternate Executor";
      this.button20.BackColor = Color.FromArgb(65, 65, 65);
      this.button20.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button20.FlatStyle = FlatStyle.Flat;
      this.button20.ForeColor = SystemColors.Control;
      this.button20.Location = new Point(566, 309);
      this.button20.Name = "button20";
      this.button20.Size = new Size(165, 45);
      this.button20.TabIndex = 138;
      this.button20.Text = "Execute";
      this.button20.UseVisualStyleBackColor = false;
      this.button20.Click += new EventHandler(this.button20_Click);
      this.button21.BackColor = Color.FromArgb(65, 65, 65);
      this.button21.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button21.FlatStyle = FlatStyle.Flat;
      this.button21.ForeColor = SystemColors.Control;
      this.button21.Location = new Point(566, 360);
      this.button21.Name = "button21";
      this.button21.Size = new Size(165, 36);
      this.button21.TabIndex = 139;
      this.button21.Text = "Clear";
      this.button21.UseVisualStyleBackColor = false;
      this.button21.Click += new EventHandler(this.button21_Click);
      this.button14.BackColor = Color.FromArgb(65, 65, 65);
      this.button14.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button14.FlatStyle = FlatStyle.Flat;
      this.button14.ForeColor = SystemColors.Control;
      this.button14.Location = new Point(12, 360);
      this.button14.Name = "button14";
      this.button14.Size = new Size(258, 37);
      this.button14.TabIndex = 129;
      this.button14.Text = "Options Menu Button Explainations";
      this.button14.UseVisualStyleBackColor = false;
      this.button14.Click += new EventHandler(this.button14_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(50, 50, 50);
      this.ClientSize = new Size(743, 408);
      this.Controls.Add((Control) this.button21);
      this.Controls.Add((Control) this.button20);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.richTextBox2);
      this.Controls.Add((Control) this.button19);
      this.Controls.Add((Control) this.button18);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button17);
      this.Controls.Add((Control) this.button16);
      this.Controls.Add((Control) this.button15);
      this.Controls.Add((Control) this.button14);
      this.Controls.Add((Control) this.richTextBox1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.panel5);
      this.Controls.Add((Control) this.button13);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.button12);
      this.Controls.Add((Control) this.button11);
      this.Controls.Add((Control) this.button9);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Options);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Load += new EventHandler(this.Options_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
