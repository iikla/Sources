// Decompiled with JetBrains decompiler
// Type: Celery.LOADING
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Celery
{
  public class LOADING : Form
  {
    private IContainer components;
    private Panel panel1;
    private Panel panel2;
    private Timer timer1;
    private Label label1;
    private Label label2;
    private PictureBox pictureBox1;

    public LOADING() => this.InitializeComponent();

    private void LOADING_Load(object dwFlags, EventArgs dx) => WinAPI.AnimateWindow(this.Handle, 500, 524288);

    [SpecialName]
    protected override CreateParams get_CreateParams()
    {
      CreateParams createParams = base.CreateParams;
      createParams.ClassStyle |= 131072;
      return createParams;
    }

    private void prograssbar1_Click([In] object obj0, [In] EventArgs obj1)
    {
    }

    protected override void WndProc([In] ref Message obj0)
    {
      if (obj0.Msg != 132)
      {
        base.WndProc(ref obj0);
      }
      else
      {
        base.WndProc(ref obj0);
        if ((int) obj0.Result != 1)
          return;
        obj0.Result = (IntPtr) 2;
      }
    }

    private void timer1_Tick(object form1, [In] EventArgs obj1)
    {
      this.panel2.Width += 3;
      if (this.panel2.Width < 289)
        return;
      this.label1.Text = "Initializing...";
      this.timer1.Stop();
      new Form1().Show();
      this.Hide();
    }

    private void panel2_Paint([In] object obj0, PaintEventArgs e)
    {
    }

    private void label2_Click([In] object obj0, EventArgs e)
    {
    }

    private void pictureBox1_Click([In] object obj0, EventArgs e)
    {
    }

    protected override void Dispose([In] bool obj0)
    {
      if (obj0 && this.components != null)
        this.components.Dispose();
      base.Dispose(obj0);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (LOADING));
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.timer1 = new Timer(this.components);
      this.label1 = new Label();
      this.label2 = new Label();
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.DarkSeaGreen;
      this.panel1.Location = new Point(-1, 289);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(289, 17);
      this.panel1.TabIndex = 2;
      this.panel2.BackColor = Color.LightGreen;
      this.panel2.Location = new Point(0, 289);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(61, 17);
      this.panel2.TabIndex = 3;
      this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
      this.timer1.Enabled = true;
      this.timer1.Interval = 15;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.FromArgb(30, 30, 30);
      this.label1.Font = new Font("Microsoft YaHei", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.ForeColor = Color.LightGreen;
      this.label1.Location = new Point(2, 270);
      this.label1.Name = "label1";
      this.label1.Size = new Size(90, 19);
      this.label1.TabIndex = 4;
      this.label1.Text = "Initializing..";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.FromArgb(30, 30, 30);
      this.label2.Font = new Font("Microsoft YaHei", 24f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label2.ForeColor = Color.LightGreen;
      this.label2.Location = new Point(78, 108);
      this.label2.Name = "label2";
      this.label2.Size = new Size(181, 52);
      this.label2.TabIndex = 5;
      this.label2.Text = "Celery™";
      this.label2.Visible = false;
      this.pictureBox1.BackgroundImage = (Image) Celery.Properties.Resources.cereri;
      this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox1.Location = new Point(-36, -3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(335, 274);
      this.pictureBox1.TabIndex = 6;
      this.pictureBox1.TabStop = false;
      this.BackColor = Color.FromArgb(30, 30, 30);
      this.ClientSize = new Size(284, 308);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (LOADING);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Load += new EventHandler(this.LOADING_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      [SpecialName] get
      {
        if (Celery.Properties.Resources.resourceMan == null)
          Celery.Properties.Resources.resourceMan = new ResourceManager("Celery.Properties.Resources", typeof (Celery.Properties.Resources).Assembly);
        return Celery.Properties.Resources.resourceMan;
      }
    }
  }
}
