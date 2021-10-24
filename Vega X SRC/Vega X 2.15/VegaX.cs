// Decompiled with JetBrains decompiler
// Type: ns0.VegaX
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeAreDevs_API;

namespace ns0
{
  public class VegaX : Form
  {
    private ExploitAPI exploitAPI_0 = new ExploitAPI();
    private Point point_0;
    private IContainer icontainer_0 = (IContainer) null;
    private Panel panel1;
    private Label label1;
    private Panel panel2;
    private Button button1;
    private Button button2;
    private Button button3;
    private ListBox listBox1;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;
    private Button button11;
    private Button button9;
    private TabControl TabControl1;
    private Button ATab;
    private Button RTab;
    private Label label2;
    private Button button10;
    private Button button12;
    private ToolStripMenuItem lightThemeToolStripMenuItem;
    private ToolStripMenuItem dEFAULTTHEMEToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip1;
    private PictureBox pictureBox1;
    private ToolStripSeparator toolStripSeparator11;
    private ToolStripMenuItem cUSTOMTHEMEToolStripMenuItem;
    private ToolStripMenuItem rEMOVECUSTOMTHEMEToolStripMenuItem;
    private CheckBox checkBox1;
    private TrackBar trackBar1;
    private TrackBar trackBar2;
    private Timer timer_0;
    private ToolStripSeparator toolStripSeparator14;
    private ToolStripSeparator toolStripSeparator15;
    private ToolStripSeparator toolStripSeparator16;
    private ToolStripMenuItem topBarPanelColorsToolStripMenuItem;
    private ToolStripMenuItem lightBlueToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator10;
    private ToolStripMenuItem deepRedToolStripMenuItem;
    private ToolStripMenuItem lightGreenToolStripMenuItem;
    private Button button13;
    private ToolStripSeparator toolStripSeparator17;
    private ToolStripMenuItem dimRedToolStripMenuItem;
    private ToolStripMenuItem brightPurpleToolStripMenuItem;
    private ToolStripMenuItem grayThemeToolStripMenuItem;
    private ToolStripMenuItem redToolStripMenuItem;
    private ToolStripMenuItem orangeToolStripMenuItem;
    private ToolStripMenuItem yellowToolStripMenuItem;
    private ToolStripMenuItem greenToolStripMenuItem;
    private ToolStripMenuItem blueToolStripMenuItem;
    private ToolStripMenuItem purpleToolStripMenuItem;
    private ToolStripMenuItem darkGreenToolStripMenuItem;
    private ToolStripMenuItem lightBlueToolStripMenuItem1;
    private ToolStripMenuItem blackToolStripMenuItem;
    private ToolStripMenuItem pinkToolStripMenuItem;
    private ToolStripMenuItem tanToolStripMenuItem;
    private ToolStripMenuItem whiteToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem tRANSPARENTTEXTBOXToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem onToolStripMenuItem;
    private ToolStripMenuItem offToolStripMenuItem;
    private Button button14;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripSeparator toolStripSeparator6;
    private Button button15;
    private Label label30;
    private RadioButton EasyExploitRadioButton;
    private RadioButton WrdRadioButton;

    public VegaX() => this.InitializeComponent();

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void panel2_Paint(object sender, PaintEventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show("Do You Really Want To Close Vega X?", "Vega X | Execution", MessageBoxButtons.YesNo))
      {
        case DialogResult.Yes:
          Application.Exit();
          break;
      }
    }

    private void panel2_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Made By 1_F0", "Credits", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
    }

    private void label1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void label1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void button2_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void button6_Click(object sender, EventArgs e)
    {
      FastColoredTextBox fastColoredTextBox = ((IEnumerable<Control>) this.TabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true)).FirstOrDefault<Control>() as FastColoredTextBox;
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      using (Stream stream = (Stream) File.Open(saveFileDialog.FileName, FileMode.CreateNew))
      {
        using (StreamWriter streamWriter = new StreamWriter(stream))
          streamWriter.Write(fastColoredTextBox.Text);
      }
    }

    private void button8_Click(object sender, EventArgs e) => (((IEnumerable<Control>) this.TabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true)).FirstOrDefault<Control>() as FastColoredTextBox).Text = "";

    private void button7_Click(object sender, EventArgs e)
    {
      FastColoredTextBox fastColoredTextBox = ((IEnumerable<Control>) this.TabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true)).FirstOrDefault<Control>() as FastColoredTextBox;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      openFileDialog.Title = "Open";
      fastColoredTextBox.Text = File.ReadAllText(openFileDialog.FileName);
    }

    private void button5_Click(object sender, EventArgs e) => new Options().Show();

    private void VegaX_Load(object sender, EventArgs e)
    {
      this.timer_0.Start();
      string text = "Scriptbox " + (this.TabControl1.TabCount + 1).ToString();
      UserControl1 userControl1 = new UserControl1();
      userControl1.Dock = DockStyle.Fill;
      TabPage tabPage = new TabPage(text);
      tabPage.Controls.Add((Control) userControl1);
      this.TabControl1.TabPages.Add(tabPage);
      this.TopMost = true;
      this.listBox1.Items.Clear();
      Class0.smethod_0(this.listBox1, "./Scripts", "*.txt");
      Class0.smethod_0(this.listBox1, "./Scripts", "*.lua");
      this.pictureBox1.AllowDrop = true;
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.WrdRadioButton.Checked = true;
    }

    private void button9_Click(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      Class0.smethod_0(this.listBox1, "./Scripts", "*.txt");
      Class0.smethod_0(this.listBox1, "./Scripts", "*.lua");
      new ScriptManager().Show();
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e) => (((IEnumerable<Control>) this.TabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true)).FirstOrDefault<Control>() as FastColoredTextBox).Text = File.ReadAllText(string.Format("./Scripts/{0}", this.listBox1.SelectedItem));

    private void button3_Click(object sender, EventArgs e)
    {
      FastColoredTextBox fastColoredTextBox = ((IEnumerable<Control>) this.TabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true)).FirstOrDefault<Control>() as FastColoredTextBox;
      this.exploitAPI_0.SendLuaScript(fastColoredTextBox.Text);
      this.exploitAPI_0.SendLuaCScript(fastColoredTextBox.Text);
    }

    private void button11_Click(object sender, EventArgs e)
    {
      if (this.EasyExploitRadioButton.Checked)
      {
        this.exploitAPI_0.LaunchExploit();
      }
      else
      {
        if (!this.WrdRadioButton.Checked)
          return;
        this.exploitAPI_0.LaunchExploit();
      }
    }

    private void method_0(object sender, EventArgs e) => new ScriptHub().Show();

    private void button10_Click(object sender, EventArgs e) => this.contextMenuStrip1.Show((Control) this.button10, 0, this.button10.Height);

    private void ATab_Click(object sender, EventArgs e)
    {
      string text = "Scriptbox" + (this.TabControl1.TabCount + 1).ToString();
      UserControl1 userControl1 = new UserControl1();
      userControl1.Dock = DockStyle.Fill;
      TabPage tabPage = new TabPage(text);
      tabPage.Controls.Add((Control) userControl1);
      this.TabControl1.TabPages.Add(tabPage);
    }

    private void RTab_Click(object sender, EventArgs e) => this.TabControl1.TabPages.Remove(this.TabControl1.SelectedTab);

    private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void method_1(object sender, EventArgs e)
    {
    }

    private void TabControl1_Click(object sender, EventArgs e)
    {
    }

    private void panel1_Click(object sender, EventArgs e)
    {
    }

    private void listBox1_Click(object sender, EventArgs e)
    {
    }

    private void VegaX_Click(object sender, EventArgs e)
    {
    }

    private void method_2(object sender, EventArgs e)
    {
      if (this.listBox1.SelectedIndex == -1)
        return;
      this.exploitAPI_0.SendLuaScript(File.ReadAllText("scripts\\" + this.listBox1.SelectedItem.ToString()));
      this.exploitAPI_0.SendLuaCScript(File.ReadAllText("scripts\\" + this.listBox1.SelectedItem.ToString()));
    }

    private void method_3(object sender, EventArgs e)
    {
      FastColoredTextBox fastColoredTextBox = ((IEnumerable<Control>) this.TabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true)).FirstOrDefault<Control>() as FastColoredTextBox;
      if (this.listBox1.SelectedIndex != -1)
      {
        fastColoredTextBox.Text = File.ReadAllText("scripts\\" + this.listBox1.SelectedItem.ToString());
      }
      else
      {
        int num = (int) MessageBox.Show("Please select a script from the list before trying to loading it in tab.", GClass0.smethod_0("JŢɯͤ"));
      }
    }

    private void method_4(object sender, EventArgs e)
    {
    }

    private void VegaX_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void method_5(object sender, EventArgs e)
    {
    }

    private void lightThemeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void method_6(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.DarkRed;

    private void method_7(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Orange;

    private void method_8(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Yellow;

    private void method_9(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Green;

    private void method_10(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Blue;

    private void method_11(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Purple;

    private void method_12(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Black;

    private void method_13(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Pink;

    private void method_14(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.White;

    private void dEFAULTTHEMEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form.ActiveForm.BackColor = this.button12.BackColor;
      this.panel1.BackColor = this.button13.BackColor;
    }

    private void method_15(object sender, EventArgs e)
    {
    }

    private void method_16(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Copy;

    private void pictureBox1_DragDrop(object sender, DragEventArgs e)
    {
      object data = e.Data.GetData(DataFormats.FileDrop);
      if (data == null)
        return;
      string[] strArray = data as string[];
      if ((uint) strArray.Length <= 0U)
        return;
      this.pictureBox1.Image = Image.FromFile(strArray[0]);
    }

    private void rEMOVECUSTOMTHEMEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show("Do You Really Want To Remove Your Custom Theme?", "Vega X | Themes", MessageBoxButtons.YesNo))
      {
        case DialogResult.Yes:
          this.pictureBox1.Image = (Image) null;
          break;
      }
    }

    private void method_17(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.LightBlue;

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox1.CheckState == CheckState.Checked)
        Form.ActiveForm.Opacity = (double) this.trackBar1.Value / 10.0;
      if (this.checkBox1.CheckState != CheckState.Unchecked)
        return;
      Form.ActiveForm.Opacity = (double) this.trackBar2.Value / 10.0;
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
      if (this.Opacity < 1.0)
        this.Opacity += 0.15;
      else
        this.timer_0.Stop();
    }

    private void toolStripSeparator15_Click(object sender, EventArgs e)
    {
    }

    private void lightBlueToolStripMenuItem_Click(object sender, EventArgs e) => this.panel1.BackColor = Color.CornflowerBlue;

    private void deepRedToolStripMenuItem_Click(object sender, EventArgs e) => this.panel1.BackColor = Color.OrangeRed;

    private void lightGreenToolStripMenuItem_Click(object sender, EventArgs e) => this.panel1.BackColor = Color.DarkSeaGreen;

    private void method_18(object sender, EventArgs e) => this.panel1.BackColor = this.button13.BackColor;

    private void dimRedToolStripMenuItem_Click(object sender, EventArgs e) => this.panel1.BackColor = Color.IndianRed;

    private void brightPurpleToolStripMenuItem_Click(object sender, EventArgs e) => this.panel1.BackColor = Color.MediumPurple;

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void grayThemeToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Gray;

    private void redToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Red;

    private void orangeToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Orange;

    private void yellowToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Yellow;

    private void greenToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Green;

    private void blueToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Blue;

    private void purpleToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Purple;

    private void darkGreenToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.DarkGreen;

    private void lightBlueToolStripMenuItem1_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.LightBlue;

    private void blackToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Black;

    private void pinkToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Pink;

    private void tanToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.Tan;

    private void whiteToolStripMenuItem_Click(object sender, EventArgs e) => Form.ActiveForm.BackColor = Color.White;

    private void method_19(object sender, EventArgs e)
    {
    }

    private void cUSTOMTHEMEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Drag And Drop Any '.GIF', '.JPEG', '.PNG', or '.JPG' File In-Between The 'Options' Button And The 'Script Hub' Button To Use A Custom Theme.");
    }

    private void tRANSPARENTTEXTBOXToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void onToolStripMenuItem_Click(object sender, EventArgs e) => this.TabControl1.SendToBack();

    private void offToolStripMenuItem_Click(object sender, EventArgs e) => this.TabControl1.BringToFront();

    private void button14_Click(object sender, EventArgs e)
    {
      FastColoredTextBox fastColoredTextBox = ((IEnumerable<Control>) this.TabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true)).FirstOrDefault<Control>() as FastColoredTextBox;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      openFileDialog.Title = "Open";
      fastColoredTextBox.Text = File.ReadAllText(openFileDialog.FileName);
      this.exploitAPI_0.SendLuaScript(fastColoredTextBox.Text);
      this.exploitAPI_0.SendLuaCScript(fastColoredTextBox.Text);
    }

    private void button15_Click(object sender, EventArgs e) => new ScriptHub().Show();

    private void method_20(object sender, EventArgs e)
    {
    }

    private void WrdRadioButton_CheckedChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (VegaX));
      this.panel1 = new Panel();
      this.button15 = new Button();
      this.checkBox1 = new CheckBox();
      this.label2 = new Label();
      this.button2 = new Button();
      this.button1 = new Button();
      this.label1 = new Label();
      this.panel2 = new Panel();
      this.button10 = new Button();
      this.button3 = new Button();
      this.listBox1 = new ListBox();
      this.button5 = new Button();
      this.button6 = new Button();
      this.button7 = new Button();
      this.button8 = new Button();
      this.button11 = new Button();
      this.button9 = new Button();
      this.TabControl1 = new TabControl();
      this.ATab = new Button();
      this.RTab = new Button();
      this.button12 = new Button();
      this.lightThemeToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.grayThemeToolStripMenuItem = new ToolStripMenuItem();
      this.redToolStripMenuItem = new ToolStripMenuItem();
      this.orangeToolStripMenuItem = new ToolStripMenuItem();
      this.yellowToolStripMenuItem = new ToolStripMenuItem();
      this.greenToolStripMenuItem = new ToolStripMenuItem();
      this.blueToolStripMenuItem = new ToolStripMenuItem();
      this.purpleToolStripMenuItem = new ToolStripMenuItem();
      this.darkGreenToolStripMenuItem = new ToolStripMenuItem();
      this.lightBlueToolStripMenuItem1 = new ToolStripMenuItem();
      this.blackToolStripMenuItem = new ToolStripMenuItem();
      this.pinkToolStripMenuItem = new ToolStripMenuItem();
      this.tanToolStripMenuItem = new ToolStripMenuItem();
      this.whiteToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.dEFAULTTHEMEToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
      this.toolStripSeparator11 = new ToolStripSeparator();
      this.toolStripSeparator15 = new ToolStripSeparator();
      this.topBarPanelColorsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.lightBlueToolStripMenuItem = new ToolStripMenuItem();
      this.deepRedToolStripMenuItem = new ToolStripMenuItem();
      this.lightGreenToolStripMenuItem = new ToolStripMenuItem();
      this.dimRedToolStripMenuItem = new ToolStripMenuItem();
      this.brightPurpleToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator17 = new ToolStripSeparator();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripSeparator14 = new ToolStripSeparator();
      this.cUSTOMTHEMEToolStripMenuItem = new ToolStripMenuItem();
      this.rEMOVECUSTOMTHEMEToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator16 = new ToolStripSeparator();
      this.tRANSPARENTTEXTBOXToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.onToolStripMenuItem = new ToolStripMenuItem();
      this.offToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.toolStripSeparator10 = new ToolStripSeparator();
      this.pictureBox1 = new PictureBox();
      this.trackBar1 = new TrackBar();
      this.trackBar2 = new TrackBar();
      this.timer_0 = new Timer(this.icontainer_0);
      this.button13 = new Button();
      this.button14 = new Button();
      this.label30 = new Label();
      this.WrdRadioButton = new RadioButton();
      this.EasyExploitRadioButton = new RadioButton();
      this.panel1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.trackBar1.BeginInit();
      this.trackBar2.BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(60, 60, 60);
      this.panel1.Controls.Add((Control) this.EasyExploitRadioButton);
      this.panel1.Controls.Add((Control) this.WrdRadioButton);
      this.panel1.Controls.Add((Control) this.label30);
      this.panel1.Controls.Add((Control) this.button15);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.button2);
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(815, 43);
      this.panel1.TabIndex = 0;
      this.panel1.Click += new EventHandler(this.panel1_Click);
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.button15.BackColor = Color.FromArgb(65, 65, 65);
      this.button15.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button15.FlatStyle = FlatStyle.Flat;
      this.button15.ForeColor = SystemColors.Control;
      this.button15.Location = new Point(628, 6);
      this.button15.Name = "button15";
      this.button15.Size = new Size(89, 30);
      this.button15.TabIndex = 23;
      this.button15.Text = "Script Hub";
      this.button15.UseVisualStyleBackColor = false;
      this.button15.Click += new EventHandler(this.button15_Click);
      this.checkBox1.AutoSize = true;
      this.checkBox1.ForeColor = SystemColors.Control;
      this.checkBox1.Location = new Point(703, 271);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(83, 17);
      this.checkBox1.TabIndex = 22;
      this.checkBox1.Text = "Transparent";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Ivory;
      this.label2.Location = new Point(56, 8);
      this.label2.Name = "label2";
      this.label2.Size = new Size(0, 25);
      this.label2.TabIndex = 21;
      this.label2.Visible = false;
      this.button2.BackColor = Color.FromArgb(60, 60, 60);
      this.button2.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button2.ForeColor = SystemColors.ControlLightLight;
      this.button2.Location = new Point(732, 4);
      this.button2.Name = "button2";
      this.button2.Size = new Size(30, 36);
      this.button2.TabIndex = 4;
      this.button2.Text = "—";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button1.BackColor = Color.FromArgb(60, 60, 60);
      this.button1.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = SystemColors.ControlLightLight;
      this.button1.Location = new Point(768, 3);
      this.button1.Name = "button1";
      this.button1.Size = new Size(42, 37);
      this.button1.TabIndex = 3;
      this.button1.Text = "X";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.Window;
      this.label1.Location = new Point(325, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(122, 21);
      this.label1.TabIndex = 2;
      this.label1.Text = "Vega X - v2.1.5a";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
      this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Zoom;
      this.panel2.Location = new Point(2, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(48, 39);
      this.panel2.TabIndex = 1;
      this.panel2.Click += new EventHandler(this.panel2_Click);
      this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
      this.button10.BackColor = Color.FromArgb(65, 65, 65);
      this.button10.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button10.FlatStyle = FlatStyle.Flat;
      this.button10.ForeColor = SystemColors.Control;
      this.button10.Location = new Point(618, 328);
      this.button10.Name = "button10";
      this.button10.Size = new Size(89, 30);
      this.button10.TabIndex = 20;
      this.button10.Text = "UI Themes";
      this.button10.UseVisualStyleBackColor = false;
      this.button10.Click += new EventHandler(this.button10_Click);
      this.button3.BackColor = Color.FromArgb(65, 65, 65);
      this.button3.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.ForeColor = SystemColors.Control;
      this.button3.Location = new Point(5, 328);
      this.button3.Name = "button3";
      this.button3.Size = new Size(89, 30);
      this.button3.TabIndex = 2;
      this.button3.Text = "Execute";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.listBox1.BackColor = Color.FromArgb(57, 57, 57);
      this.listBox1.BorderStyle = BorderStyle.None;
      this.listBox1.ForeColor = SystemColors.Window;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(686, 100);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(116, 169);
      this.listBox1.TabIndex = 9;
      this.listBox1.Click += new EventHandler(this.listBox1_Click);
      this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
      this.button5.BackColor = Color.FromArgb(65, 65, 65);
      this.button5.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.ForeColor = SystemColors.Control;
      this.button5.Location = new Point(480, 328);
      this.button5.Name = "button5";
      this.button5.Size = new Size(89, 30);
      this.button5.TabIndex = 11;
      this.button5.Text = "Options";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.button6.BackColor = Color.FromArgb(65, 65, 65);
      this.button6.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button6.FlatStyle = FlatStyle.Flat;
      this.button6.ForeColor = SystemColors.Control;
      this.button6.Location = new Point(290, 328);
      this.button6.Name = "button6";
      this.button6.Size = new Size(89, 30);
      this.button6.TabIndex = 12;
      this.button6.Text = "Save File";
      this.button6.UseVisualStyleBackColor = false;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.button7.BackColor = Color.FromArgb(65, 65, 65);
      this.button7.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button7.FlatStyle = FlatStyle.Flat;
      this.button7.ForeColor = SystemColors.Control;
      this.button7.Location = new Point(195, 328);
      this.button7.Name = "button7";
      this.button7.Size = new Size(89, 30);
      this.button7.TabIndex = 13;
      this.button7.Text = "Open File";
      this.button7.UseVisualStyleBackColor = false;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.button8.BackColor = Color.FromArgb(65, 65, 65);
      this.button8.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button8.FlatStyle = FlatStyle.Flat;
      this.button8.ForeColor = SystemColors.Control;
      this.button8.Location = new Point(100, 328);
      this.button8.Name = "button8";
      this.button8.Size = new Size(89, 30);
      this.button8.TabIndex = 14;
      this.button8.Text = "Clear";
      this.button8.UseVisualStyleBackColor = false;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button11.BackColor = Color.FromArgb(65, 65, 65);
      this.button11.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button11.FlatStyle = FlatStyle.Flat;
      this.button11.ForeColor = SystemColors.Control;
      this.button11.Location = new Point(713, 328);
      this.button11.Name = "button11";
      this.button11.Size = new Size(89, 30);
      this.button11.TabIndex = 18;
      this.button11.Text = "Attach";
      this.button11.UseVisualStyleBackColor = false;
      this.button11.Click += new EventHandler(this.button11_Click);
      this.button9.BackColor = Color.FromArgb(65, 65, 65);
      this.button9.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button9.FlatStyle = FlatStyle.Flat;
      this.button9.ForeColor = SystemColors.Control;
      this.button9.Location = new Point(686, 288);
      this.button9.Name = "button9";
      this.button9.Size = new Size(116, 34);
      this.button9.TabIndex = 19;
      this.button9.Text = "Script Manager";
      this.button9.UseVisualStyleBackColor = false;
      this.button9.Click += new EventHandler(this.button9_Click);
      this.TabControl1.Location = new Point(3, 44);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(677, 277);
      this.TabControl1.TabIndex = 24;
      this.TabControl1.SelectedIndexChanged += new EventHandler(this.TabControl1_SelectedIndexChanged);
      this.TabControl1.Click += new EventHandler(this.TabControl1_Click);
      this.ATab.BackColor = Color.FromArgb(65, 65, 65);
      this.ATab.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.ATab.FlatStyle = FlatStyle.Flat;
      this.ATab.ForeColor = SystemColors.Control;
      this.ATab.Location = new Point(686, 47);
      this.ATab.Name = "ATab";
      this.ATab.Size = new Size(116, 22);
      this.ATab.TabIndex = 25;
      this.ATab.Text = "Add Tab";
      this.ATab.UseVisualStyleBackColor = false;
      this.ATab.Click += new EventHandler(this.ATab_Click);
      this.RTab.BackColor = Color.FromArgb(65, 65, 65);
      this.RTab.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.RTab.FlatStyle = FlatStyle.Flat;
      this.RTab.ForeColor = SystemColors.Control;
      this.RTab.Location = new Point(686, 72);
      this.RTab.Name = "RTab";
      this.RTab.Size = new Size(116, 22);
      this.RTab.TabIndex = 26;
      this.RTab.Text = "Remove Tab";
      this.RTab.UseVisualStyleBackColor = false;
      this.RTab.Click += new EventHandler(this.RTab_Click);
      this.button12.BackColor = Color.FromArgb(45, 45, 45);
      this.button12.Location = new Point(792, 100);
      this.button12.Name = "button12";
      this.button12.Size = new Size(10, 10);
      this.button12.TabIndex = 27;
      this.button12.Text = "button12";
      this.button12.UseVisualStyleBackColor = false;
      this.lightThemeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[15]
      {
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.grayThemeToolStripMenuItem,
        (ToolStripItem) this.redToolStripMenuItem,
        (ToolStripItem) this.orangeToolStripMenuItem,
        (ToolStripItem) this.yellowToolStripMenuItem,
        (ToolStripItem) this.greenToolStripMenuItem,
        (ToolStripItem) this.blueToolStripMenuItem,
        (ToolStripItem) this.purpleToolStripMenuItem,
        (ToolStripItem) this.darkGreenToolStripMenuItem,
        (ToolStripItem) this.lightBlueToolStripMenuItem1,
        (ToolStripItem) this.blackToolStripMenuItem,
        (ToolStripItem) this.pinkToolStripMenuItem,
        (ToolStripItem) this.tanToolStripMenuItem,
        (ToolStripItem) this.whiteToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator4
      });
      this.lightThemeToolStripMenuItem.ForeColor = SystemColors.Control;
      this.lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
      this.lightThemeToolStripMenuItem.Size = new Size(211, 22);
      this.lightThemeToolStripMenuItem.Text = "Colors";
      this.lightThemeToolStripMenuItem.Click += new EventHandler(this.lightThemeToolStripMenuItem_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(129, 6);
      this.grayThemeToolStripMenuItem.Name = "grayThemeToolStripMenuItem";
      this.grayThemeToolStripMenuItem.Size = new Size(132, 22);
      this.grayThemeToolStripMenuItem.Text = "Gray";
      this.grayThemeToolStripMenuItem.Click += new EventHandler(this.grayThemeToolStripMenuItem_Click);
      this.redToolStripMenuItem.Name = "redToolStripMenuItem";
      this.redToolStripMenuItem.Size = new Size(132, 22);
      this.redToolStripMenuItem.Text = "Red";
      this.redToolStripMenuItem.Click += new EventHandler(this.redToolStripMenuItem_Click);
      this.orangeToolStripMenuItem.Name = "orangeToolStripMenuItem";
      this.orangeToolStripMenuItem.Size = new Size(132, 22);
      this.orangeToolStripMenuItem.Text = "Orange";
      this.orangeToolStripMenuItem.Click += new EventHandler(this.orangeToolStripMenuItem_Click);
      this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
      this.yellowToolStripMenuItem.Size = new Size(132, 22);
      this.yellowToolStripMenuItem.Text = "Yellow";
      this.yellowToolStripMenuItem.Click += new EventHandler(this.yellowToolStripMenuItem_Click);
      this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
      this.greenToolStripMenuItem.Size = new Size(132, 22);
      this.greenToolStripMenuItem.Text = "Green";
      this.greenToolStripMenuItem.Click += new EventHandler(this.greenToolStripMenuItem_Click);
      this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
      this.blueToolStripMenuItem.Size = new Size(132, 22);
      this.blueToolStripMenuItem.Text = "Blue";
      this.blueToolStripMenuItem.Click += new EventHandler(this.blueToolStripMenuItem_Click);
      this.purpleToolStripMenuItem.Name = "purpleToolStripMenuItem";
      this.purpleToolStripMenuItem.Size = new Size(132, 22);
      this.purpleToolStripMenuItem.Text = "Purple";
      this.purpleToolStripMenuItem.Click += new EventHandler(this.purpleToolStripMenuItem_Click);
      this.darkGreenToolStripMenuItem.Name = "darkGreenToolStripMenuItem";
      this.darkGreenToolStripMenuItem.Size = new Size(132, 22);
      this.darkGreenToolStripMenuItem.Text = "Dark Green";
      this.darkGreenToolStripMenuItem.Click += new EventHandler(this.darkGreenToolStripMenuItem_Click);
      this.lightBlueToolStripMenuItem1.Name = "lightBlueToolStripMenuItem1";
      this.lightBlueToolStripMenuItem1.Size = new Size(132, 22);
      this.lightBlueToolStripMenuItem1.Text = "Light Blue";
      this.lightBlueToolStripMenuItem1.Click += new EventHandler(this.lightBlueToolStripMenuItem1_Click);
      this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
      this.blackToolStripMenuItem.Size = new Size(132, 22);
      this.blackToolStripMenuItem.Text = "Black";
      this.blackToolStripMenuItem.Click += new EventHandler(this.blackToolStripMenuItem_Click);
      this.pinkToolStripMenuItem.Name = "pinkToolStripMenuItem";
      this.pinkToolStripMenuItem.Size = new Size(132, 22);
      this.pinkToolStripMenuItem.Text = "Pink";
      this.pinkToolStripMenuItem.Click += new EventHandler(this.pinkToolStripMenuItem_Click);
      this.tanToolStripMenuItem.Name = "tanToolStripMenuItem";
      this.tanToolStripMenuItem.Size = new Size(132, 22);
      this.tanToolStripMenuItem.Text = "Tan";
      this.tanToolStripMenuItem.Click += new EventHandler(this.tanToolStripMenuItem_Click);
      this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
      this.whiteToolStripMenuItem.Size = new Size(132, 22);
      this.whiteToolStripMenuItem.Text = "White";
      this.whiteToolStripMenuItem.Click += new EventHandler(this.whiteToolStripMenuItem_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(129, 6);
      this.dEFAULTTHEMEToolStripMenuItem.ForeColor = SystemColors.Control;
      this.dEFAULTTHEMEToolStripMenuItem.Name = "dEFAULTTHEMEToolStripMenuItem";
      this.dEFAULTTHEMEToolStripMenuItem.Size = new Size(211, 22);
      this.dEFAULTTHEMEToolStripMenuItem.Text = "DEFAULT THEME";
      this.dEFAULTTHEMEToolStripMenuItem.Click += new EventHandler(this.dEFAULTTHEMEToolStripMenuItem_Click);
      this.contextMenuStrip1.BackColor = Color.FromArgb(70, 70, 70);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this.toolStripSeparator11,
        (ToolStripItem) this.lightThemeToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator15,
        (ToolStripItem) this.topBarPanelColorsToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.dEFAULTTHEMEToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator14,
        (ToolStripItem) this.cUSTOMTHEMEToolStripMenuItem,
        (ToolStripItem) this.rEMOVECUSTOMTHEMEToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator16,
        (ToolStripItem) this.tRANSPARENTTEXTBOXToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator10
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(212, 172);
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new Size(208, 6);
      this.toolStripSeparator15.Name = "toolStripSeparator15";
      this.toolStripSeparator15.Size = new Size(208, 6);
      this.toolStripSeparator15.Click += new EventHandler(this.toolStripSeparator15_Click);
      this.topBarPanelColorsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.lightBlueToolStripMenuItem,
        (ToolStripItem) this.deepRedToolStripMenuItem,
        (ToolStripItem) this.lightGreenToolStripMenuItem,
        (ToolStripItem) this.dimRedToolStripMenuItem,
        (ToolStripItem) this.brightPurpleToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator17
      });
      this.topBarPanelColorsToolStripMenuItem.ForeColor = SystemColors.Control;
      this.topBarPanelColorsToolStripMenuItem.Name = "topBarPanelColorsToolStripMenuItem";
      this.topBarPanelColorsToolStripMenuItem.Size = new Size(211, 22);
      this.topBarPanelColorsToolStripMenuItem.Text = "TopBar / Panel Colors";
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(145, 6);
      this.lightBlueToolStripMenuItem.Name = "lightBlueToolStripMenuItem";
      this.lightBlueToolStripMenuItem.Size = new Size(148, 22);
      this.lightBlueToolStripMenuItem.Text = "Light Blue";
      this.lightBlueToolStripMenuItem.Click += new EventHandler(this.lightBlueToolStripMenuItem_Click);
      this.deepRedToolStripMenuItem.Name = "deepRedToolStripMenuItem";
      this.deepRedToolStripMenuItem.Size = new Size(148, 22);
      this.deepRedToolStripMenuItem.Text = "Bright Orange";
      this.deepRedToolStripMenuItem.Click += new EventHandler(this.deepRedToolStripMenuItem_Click);
      this.lightGreenToolStripMenuItem.Name = "lightGreenToolStripMenuItem";
      this.lightGreenToolStripMenuItem.Size = new Size(148, 22);
      this.lightGreenToolStripMenuItem.Text = "Light Green";
      this.lightGreenToolStripMenuItem.Click += new EventHandler(this.lightGreenToolStripMenuItem_Click);
      this.dimRedToolStripMenuItem.Name = "dimRedToolStripMenuItem";
      this.dimRedToolStripMenuItem.Size = new Size(148, 22);
      this.dimRedToolStripMenuItem.Text = "Dim Red";
      this.dimRedToolStripMenuItem.Click += new EventHandler(this.dimRedToolStripMenuItem_Click);
      this.brightPurpleToolStripMenuItem.Name = "brightPurpleToolStripMenuItem";
      this.brightPurpleToolStripMenuItem.Size = new Size(148, 22);
      this.brightPurpleToolStripMenuItem.Text = "Bright Purple";
      this.brightPurpleToolStripMenuItem.Click += new EventHandler(this.brightPurpleToolStripMenuItem_Click);
      this.toolStripSeparator17.Name = "toolStripSeparator17";
      this.toolStripSeparator17.Size = new Size(145, 6);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(208, 6);
      this.toolStripSeparator14.Name = "toolStripSeparator14";
      this.toolStripSeparator14.Size = new Size(208, 6);
      this.cUSTOMTHEMEToolStripMenuItem.ForeColor = SystemColors.Control;
      this.cUSTOMTHEMEToolStripMenuItem.Name = "cUSTOMTHEMEToolStripMenuItem";
      this.cUSTOMTHEMEToolStripMenuItem.Size = new Size(211, 22);
      this.cUSTOMTHEMEToolStripMenuItem.Text = "CUSTOM THEME";
      this.cUSTOMTHEMEToolStripMenuItem.Click += new EventHandler(this.cUSTOMTHEMEToolStripMenuItem_Click);
      this.rEMOVECUSTOMTHEMEToolStripMenuItem.ForeColor = SystemColors.Control;
      this.rEMOVECUSTOMTHEMEToolStripMenuItem.Name = "rEMOVECUSTOMTHEMEToolStripMenuItem";
      this.rEMOVECUSTOMTHEMEToolStripMenuItem.Size = new Size(211, 22);
      this.rEMOVECUSTOMTHEMEToolStripMenuItem.Text = "REMOVE CUSTOM THEME";
      this.rEMOVECUSTOMTHEMEToolStripMenuItem.Click += new EventHandler(this.rEMOVECUSTOMTHEMEToolStripMenuItem_Click);
      this.toolStripSeparator16.Name = "toolStripSeparator16";
      this.toolStripSeparator16.Size = new Size(208, 6);
      this.tRANSPARENTTEXTBOXToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.onToolStripMenuItem,
        (ToolStripItem) this.offToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator6
      });
      this.tRANSPARENTTEXTBOXToolStripMenuItem.ForeColor = SystemColors.Control;
      this.tRANSPARENTTEXTBOXToolStripMenuItem.Name = "tRANSPARENTTEXTBOXToolStripMenuItem";
      this.tRANSPARENTTEXTBOXToolStripMenuItem.Size = new Size(211, 22);
      this.tRANSPARENTTEXTBOXToolStripMenuItem.Text = "REMOVE TEXT BOX";
      this.tRANSPARENTTEXTBOXToolStripMenuItem.Click += new EventHandler(this.tRANSPARENTTEXTBOXToolStripMenuItem_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(88, 6);
      this.onToolStripMenuItem.Name = "onToolStripMenuItem";
      this.onToolStripMenuItem.Size = new Size(91, 22);
      this.onToolStripMenuItem.Text = "On";
      this.onToolStripMenuItem.Click += new EventHandler(this.onToolStripMenuItem_Click);
      this.offToolStripMenuItem.Name = "offToolStripMenuItem";
      this.offToolStripMenuItem.Size = new Size(91, 22);
      this.offToolStripMenuItem.Text = "Off";
      this.offToolStripMenuItem.Click += new EventHandler(this.offToolStripMenuItem_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(88, 6);
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new Size(208, 6);
      this.pictureBox1.BackColor = Color.Transparent;
      this.pictureBox1.Location = new Point(-1, -1);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(816, 366);
      this.pictureBox1.TabIndex = 29;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.pictureBox1.DragDrop += new DragEventHandler(this.pictureBox1_DragDrop);
      this.pictureBox1.DragEnter += new DragEventHandler(this.pictureBox1_DragEnter);
      this.trackBar1.Location = new Point(792, 276);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new Size(10, 45);
      this.trackBar1.TabIndex = 1;
      this.trackBar1.Value = 7;
      this.trackBar2.Location = new Point(776, 276);
      this.trackBar2.Name = "trackBar2";
      this.trackBar2.Size = new Size(10, 45);
      this.trackBar2.TabIndex = 30;
      this.trackBar2.Value = 10;
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.button13.BackColor = Color.FromArgb(60, 60, 60);
      this.button13.Location = new Point(776, 191);
      this.button13.Name = "button13";
      this.button13.Size = new Size(10, 10);
      this.button13.TabIndex = 31;
      this.button13.Text = "button13";
      this.button13.UseVisualStyleBackColor = false;
      this.button14.BackColor = Color.FromArgb(65, 65, 65);
      this.button14.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button14.FlatStyle = FlatStyle.Flat;
      this.button14.ForeColor = SystemColors.Control;
      this.button14.Location = new Point(385, 328);
      this.button14.Name = "button14";
      this.button14.Size = new Size(89, 30);
      this.button14.TabIndex = 32;
      this.button14.Text = "Execute File";
      this.button14.UseVisualStyleBackColor = false;
      this.button14.Click += new EventHandler(this.button14_Click);
      this.label30.AutoSize = true;
      this.label30.BackColor = Color.FromArgb(60, 60, 60);
      this.label30.Font = new Font("Segoe UI Semibold", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label30.ForeColor = Color.Red;
      this.label30.Location = new Point(574, 15);
      this.label30.Name = "label30";
      this.label30.Size = new Size(55, 13);
      this.label30.TabIndex = 323;
      this.label30.Text = "*NEW* ▶";
      this.WrdRadioButton.AutoSize = true;
      this.WrdRadioButton.Location = new Point(63, 13);
      this.WrdRadioButton.Name = "WrdRadioButton";
      this.WrdRadioButton.Size = new Size(84, 17);
      this.WrdRadioButton.TabIndex = 324;
      this.WrdRadioButton.TabStop = true;
      this.WrdRadioButton.Text = "WRDv2 API";
      this.WrdRadioButton.UseVisualStyleBackColor = true;
      this.WrdRadioButton.CheckedChanged += new EventHandler(this.WrdRadioButton_CheckedChanged);
      this.EasyExploitRadioButton.AutoSize = true;
      this.EasyExploitRadioButton.Location = new Point(153, 13);
      this.EasyExploitRadioButton.Name = "EasyExploitRadioButton";
      this.EasyExploitRadioButton.Size = new Size(84, 17);
      this.EasyExploitRadioButton.TabIndex = 325;
      this.EasyExploitRadioButton.TabStop = true;
      this.EasyExploitRadioButton.Text = "WRDv1 API";
      this.EasyExploitRadioButton.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(45, 45, 45);
      this.ClientSize = new Size(814, 364);
      this.Controls.Add((Control) this.button14);
      this.Controls.Add((Control) this.RTab);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.button10);
      this.Controls.Add((Control) this.ATab);
      this.Controls.Add((Control) this.TabControl1);
      this.Controls.Add((Control) this.button9);
      this.Controls.Add((Control) this.button11);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.button12);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.trackBar1);
      this.Controls.Add((Control) this.trackBar2);
      this.Controls.Add((Control) this.button13);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (VegaX);
      this.Opacity = 0.0;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Vega X";
      this.FormClosing += new FormClosingEventHandler(this.VegaX_FormClosing);
      this.Load += new EventHandler(this.VegaX_Load);
      this.Click += new EventHandler(this.VegaX_Click);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.trackBar1.EndInit();
      this.trackBar2.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
