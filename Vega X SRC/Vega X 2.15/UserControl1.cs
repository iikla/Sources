// Decompiled with JetBrains decompiler
// Type: ns0.UserControl1
// Assembly: Vega X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E478D6FE-DAB5-4BFC-B363-100441C5D48B
// Assembly location: C:\Users\chann\OneDrive\Desktop\Vega X - v2.1.5a\Vega X - v2.1.5a\Vega X_patched-cleaned.exe

using FastColoredTextBoxNS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns0
{
  public class UserControl1 : UserControl
  {
    private IContainer icontainer_0 = (IContainer) null;
    private FastColoredTextBox fastColoredTextBox1;
    private ContextMenuStrip contextMenuStrip1;

    public UserControl1() => this.InitializeComponent();

    private void fastColoredTextBox1_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UserControl1));
      this.fastColoredTextBox1 = new FastColoredTextBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
      ((ISupportInitialize) this.fastColoredTextBox1).BeginInit();
      this.SuspendLayout();
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
      this.fastColoredTextBox1.AutoScrollMinSize = new Size(675, 126);
      this.fastColoredTextBox1.BackBrush = (Brush) null;
      this.fastColoredTextBox1.BackColor = Color.FromArgb(50, 50, 50);
      this.fastColoredTextBox1.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
      this.fastColoredTextBox1.CharHeight = 14;
      this.fastColoredTextBox1.CharWidth = 8;
      this.fastColoredTextBox1.CommentPrefix = "--";
      this.fastColoredTextBox1.Cursor = Cursors.IBeam;
      this.fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
      this.fastColoredTextBox1.Dock = DockStyle.Fill;
      this.fastColoredTextBox1.Font = new Font("Courier New", 9.75f);
      this.fastColoredTextBox1.ForeColor = Color.White;
      this.fastColoredTextBox1.IndentBackColor = Color.FromArgb(45, 45, 45);
      this.fastColoredTextBox1.IsReplaceMode = false;
      this.fastColoredTextBox1.Language = Language.Lua;
      this.fastColoredTextBox1.LeftBracket = '(';
      this.fastColoredTextBox1.LeftBracket2 = '{';
      this.fastColoredTextBox1.Location = new Point(0, 0);
      this.fastColoredTextBox1.Name = "fastColoredTextBox1";
      this.fastColoredTextBox1.Paddings = new Padding(0);
      this.fastColoredTextBox1.RightBracket = ')';
      this.fastColoredTextBox1.RightBracket2 = '}';
      this.fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 0, 0, (int) byte.MaxValue);
      this.fastColoredTextBox1.ServiceColors = (ServiceColors) componentResourceManager.GetObject("fastColoredTextBox1.ServiceColors");
      this.fastColoredTextBox1.Size = new Size(669, 251);
      this.fastColoredTextBox1.TabIndex = 24;
      this.fastColoredTextBox1.Text = componentResourceManager.GetString("fastColoredTextBox1.Text");
      this.fastColoredTextBox1.Zoom = 100;
      this.fastColoredTextBox1.Load += new EventHandler(this.fastColoredTextBox1_Load);
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(61, 4);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.fastColoredTextBox1);
      this.Name = nameof (UserControl1);
      this.Size = new Size(669, 251);
      ((ISupportInitialize) this.fastColoredTextBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
