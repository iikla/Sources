// Decompiled with JetBrains decompiler
// Type: SlickTab
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using System.Drawing;
using System.Windows.Forms;

public class SlickTab
{
  public Label btn_x;
  public Label lbl_caption;
  public PictureBox tab_bg;
  public Color BackColor;
  public Color SelectedColor;
  public string Caption;
  public bool TextScale;
  public bool Selected;
  public bool Active;
  public object Data;

  public SlickTab()
  {
    this.Active = true;
    this.btn_x = new Label();
    this.lbl_caption = new Label();
    this.tab_bg = new PictureBox();
    this.Caption = "Untitled";
    this.TextScale = false;
    this.Selected = false;
  }

  public void Update(int referenceX, int referenceY)
  {
    this.lbl_caption.Text = this.Caption;
    if (this.TextScale)
      this.tab_bg.Size = new Size(106 + this.Caption.Length, this.lbl_caption.Bottom - this.tab_bg.Top);
    else
      this.tab_bg.Size = new Size(this.tab_bg.Size.Width, this.lbl_caption.Bottom - this.tab_bg.Top);
    if (this.Selected)
      this.tab_bg.BackColor = this.SelectedColor;
    else
      this.tab_bg.BackColor = this.BackColor;
    this.lbl_caption.BackColor = this.tab_bg.BackColor;
    this.btn_x.BackColor = this.tab_bg.BackColor;
    this.tab_bg.Location = new Point(referenceX, referenceY);
    this.lbl_caption.Location = new Point(referenceX + 8, referenceY + 3);
    this.btn_x.Location = new Point(referenceX + (this.tab_bg.Width - 20), referenceY + 2);
  }
}
