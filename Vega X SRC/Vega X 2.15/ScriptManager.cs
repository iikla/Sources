// Decompiled with JetBrains decompiler
// Type: ns0.ScriptManager
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeAreDevs_API;

namespace ns0
{
  public class ScriptManager : Form
  {
    private ExploitAPI exploitAPI_0 = new ExploitAPI();
    private DataTable dataTable_0;
    private Point point_0;
    private IContainer icontainer_0 = (IContainer) null;
    private Panel panel1;
    private Label label2;
    private Label label1;
    private Panel panel2;
    private Button button107;
    private Button button2;
    private DataGridView dataGridView1;
    private RichTextBox richTextBox2;
    private Button button8;
    private Button button1;
    private Button button3;
    private Button button4;
    private Label label3;
    private Label label4;
    private RichTextBox richTextBox1;
    private Button button5;
    private Button button6;
    private Label label5;
    private Label label6;
    private Button button7;
    private Button button9;

    public ScriptManager() => this.InitializeComponent();

    private void ScriptManager_Load(object sender, EventArgs e)
    {
      this.TopMost = true;
      this.dataTable_0 = new DataTable();
      this.dataTable_0.Columns.Add("Title", typeof (string));
      this.dataTable_0.Columns.Add("Scripts", typeof (string));
      this.dataGridView1.DataSource = (object) this.dataTable_0;
      this.dataGridView1.Columns["Scripts"].Visible = false;
    }

    private void label6_Click(object sender, EventArgs e)
    {
    }

    private void button8_Click(object sender, EventArgs e)
    {
      this.dataTable_0.Rows.Add((object) this.richTextBox1.Text, (object) this.richTextBox2.Text);
      this.richTextBox1.Clear();
      this.richTextBox2.Clear();
    }

    private void button7_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("To use the script manager, first add a *SCRIPT TITLE* and a *SCRIPT*. Then press *SAVE*. Your script will save to the *SCRIPT LIST*. To retrieve a script, select it from the *SCRIPT LIST* and press the *OPEN SCRIPT* button. Then you can execute it with the *EXECUTE SCRIPT* button. Enjoy! ");
    }

    private void button4_Click(object sender, EventArgs e) => this.exploitAPI_0.SendLuaScript(this.richTextBox2.Text);

    private void button3_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      using (Stream stream = (Stream) File.Open(saveFileDialog.FileName, FileMode.CreateNew))
      {
        using (StreamWriter streamWriter = new StreamWriter(stream))
          streamWriter.Write(this.richTextBox2.Text);
      }
    }

    private void richTextBox2_TextChanged(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.richTextBox1.Clear();
      this.richTextBox2.Clear();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      if (rowIndex <= -1)
        return;
      this.richTextBox1.Text = this.dataTable_0.Rows[rowIndex].ItemArray[0].ToString();
      this.richTextBox2.Text = this.dataTable_0.Rows[rowIndex].ItemArray[1].ToString();
    }

    private void button5_Click(object sender, EventArgs e) => this.dataTable_0.Rows[this.dataGridView1.CurrentCell.RowIndex].Delete();

    private void button107_Click(object sender, EventArgs e) => this.Close();

    private void button2_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Left += e.X - this.point_0.X;
      this.Top += e.Y - this.point_0.Y;
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e) => this.point_0 = new Point(e.X, e.Y);

    private void button9_Click(object sender, EventArgs e) => this.exploitAPI_0.LaunchExploit();

    protected override void Dispose(bool disposing)
    {
      if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ScriptManager));
      this.panel1 = new Panel();
      this.label2 = new Label();
      this.label1 = new Label();
      this.panel2 = new Panel();
      this.button107 = new Button();
      this.button2 = new Button();
      this.dataGridView1 = new DataGridView();
      this.richTextBox2 = new RichTextBox();
      this.button8 = new Button();
      this.button1 = new Button();
      this.button3 = new Button();
      this.button4 = new Button();
      this.label3 = new Label();
      this.label4 = new Label();
      this.richTextBox1 = new RichTextBox();
      this.button5 = new Button();
      this.button6 = new Button();
      this.label5 = new Label();
      this.label6 = new Label();
      this.button7 = new Button();
      this.button9 = new Button();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(60, 60, 60);
      this.panel1.Controls.Add((Control) this.button107);
      this.panel1.Controls.Add((Control) this.button2);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(779, 44);
      this.panel1.TabIndex = 1;
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Ivory;
      this.label2.Location = new Point(56, 8);
      this.label2.Name = "label2";
      this.label2.Size = new Size(0, 25);
      this.label2.TabIndex = 21;
      this.label2.Visible = false;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.Window;
      this.label1.Location = new Point(309, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(186, 21);
      this.label1.TabIndex = 2;
      this.label1.Text = "Vega X - Script Manager";
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Zoom;
      this.panel2.Location = new Point(2, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(48, 39);
      this.panel2.TabIndex = 1;
      this.button107.BackColor = Color.FromArgb(60, 60, 60);
      this.button107.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button107.FlatStyle = FlatStyle.Flat;
      this.button107.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button107.ForeColor = SystemColors.ControlLightLight;
      this.button107.Location = new Point(744, 8);
      this.button107.Name = "button107";
      this.button107.Size = new Size(30, 27);
      this.button107.TabIndex = 23;
      this.button107.Text = "X";
      this.button107.UseVisualStyleBackColor = false;
      this.button107.Click += new EventHandler(this.button107_Click);
      this.button2.BackColor = Color.FromArgb(60, 60, 60);
      this.button2.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button2.ForeColor = SystemColors.ControlLightLight;
      this.button2.Location = new Point(711, 8);
      this.button2.Name = "button2";
      this.button2.Size = new Size(30, 27);
      this.button2.TabIndex = 22;
      this.button2.Text = "—";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToResizeColumns = false;
      this.dataGridView1.AllowUserToResizeRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(511, 108);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.Size = new Size(246, 240);
      this.dataGridView1.TabIndex = 5;
      this.richTextBox2.BackColor = Color.FromArgb(30, 30, 30);
      this.richTextBox2.BorderStyle = BorderStyle.None;
      this.richTextBox2.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBox2.ForeColor = Color.ForestGreen;
      this.richTextBox2.Location = new Point(135, 144);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.Size = new Size(350, 204);
      this.richTextBox2.TabIndex = 137;
      this.richTextBox2.Text = "-- Paste Your Script Here";
      this.richTextBox2.TextChanged += new EventHandler(this.richTextBox2_TextChanged);
      this.button8.BackColor = Color.FromArgb(65, 65, 65);
      this.button8.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button8.FlatStyle = FlatStyle.Flat;
      this.button8.ForeColor = SystemColors.Control;
      this.button8.Location = new Point(135, 354);
      this.button8.Name = "button8";
      this.button8.Size = new Size(83, 30);
      this.button8.TabIndex = 138;
      this.button8.Text = "Save";
      this.button8.UseVisualStyleBackColor = false;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button1.BackColor = Color.FromArgb(65, 65, 65);
      this.button1.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = SystemColors.Control;
      this.button1.Location = new Point(402, 354);
      this.button1.Name = "button1";
      this.button1.Size = new Size(83, 30);
      this.button1.TabIndex = 139;
      this.button1.Text = "Clear";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button3.BackColor = Color.FromArgb(65, 65, 65);
      this.button3.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.ForeColor = SystemColors.Control;
      this.button3.Location = new Point(313, 354);
      this.button3.Name = "button3";
      this.button3.Size = new Size(83, 30);
      this.button3.TabIndex = 140;
      this.button3.Text = "File";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button4.BackColor = Color.FromArgb(65, 65, 65);
      this.button4.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.ForeColor = SystemColors.Control;
      this.button4.Location = new Point(224, 354);
      this.button4.Name = "button4";
      this.button4.Size = new Size(83, 30);
      this.button4.TabIndex = 141;
      this.button4.Text = "Execute";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = SystemColors.Window;
      this.label3.Location = new Point(50, 104);
      this.label3.Name = "label3";
      this.label3.Size = new Size(68, 32);
      this.label3.TabIndex = 24;
      this.label3.Text = "Title:";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.Window;
      this.label4.Location = new Point(35, 144);
      this.label4.Name = "label4";
      this.label4.Size = new Size(83, 32);
      this.label4.TabIndex = 142;
      this.label4.Text = "Script:";
      this.richTextBox1.BackColor = Color.FromArgb(30, 30, 30);
      this.richTextBox1.BorderStyle = BorderStyle.None;
      this.richTextBox1.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBox1.ForeColor = Color.ForestGreen;
      this.richTextBox1.Location = new Point(135, 108);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
      this.richTextBox1.Size = new Size(350, 28);
      this.richTextBox1.TabIndex = 143;
      this.richTextBox1.Text = "-- Script Name Here";
      this.button5.BackColor = Color.FromArgb(65, 65, 65);
      this.button5.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.ForeColor = SystemColors.Control;
      this.button5.Location = new Point(644, 354);
      this.button5.Name = "button5";
      this.button5.Size = new Size(113, 30);
      this.button5.TabIndex = 144;
      this.button5.Text = "Delete Script";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.button6.BackColor = Color.FromArgb(65, 65, 65);
      this.button6.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button6.FlatStyle = FlatStyle.Flat;
      this.button6.ForeColor = SystemColors.Control;
      this.button6.Location = new Point(511, 354);
      this.button6.Name = "button6";
      this.button6.Size = new Size((int) sbyte.MaxValue, 30);
      this.button6.TabIndex = 145;
      this.button6.Text = "Open Script";
      this.button6.UseVisualStyleBackColor = false;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = SystemColors.Window;
      this.label5.Location = new Point(212, 65);
      this.label5.Name = "label5";
      this.label5.Size = new Size(182, 32);
      this.label5.TabIndex = 146;
      this.label5.Text = "Script Manager";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = SystemColors.Window;
      this.label6.Location = new Point(574, 66);
      this.label6.Name = "label6";
      this.label6.Size = new Size(121, 32);
      this.label6.TabIndex = 147;
      this.label6.Text = "Script List";
      this.label6.Click += new EventHandler(this.label6_Click);
      this.button7.BackColor = Color.FromArgb(65, 65, 65);
      this.button7.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button7.FlatStyle = FlatStyle.Flat;
      this.button7.ForeColor = SystemColors.Control;
      this.button7.Location = new Point(22, 318);
      this.button7.Name = "button7";
      this.button7.Size = new Size(96, 66);
      this.button7.TabIndex = 148;
      this.button7.Text = "How To Use The Script Manager";
      this.button7.UseVisualStyleBackColor = false;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.button9.BackColor = Color.FromArgb(65, 65, 65);
      this.button9.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
      this.button9.FlatStyle = FlatStyle.Flat;
      this.button9.ForeColor = SystemColors.Control;
      this.button9.Location = new Point(22, 267);
      this.button9.Name = "button9";
      this.button9.Size = new Size(96, 45);
      this.button9.TabIndex = 149;
      this.button9.Text = "Attach";
      this.button9.UseVisualStyleBackColor = false;
      this.button9.Click += new EventHandler(this.button9_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(50, 50, 50);
      this.ClientSize = new Size(780, 404);
      this.Controls.Add((Control) this.button9);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.richTextBox1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.richTextBox2);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (ScriptManager);
      this.Text = nameof (ScriptManager);
      this.Load += new EventHandler(this.ScriptManager_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
