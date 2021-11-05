// Decompiled with JetBrains decompiler
// Type: SlickTabControl
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E27F4AF-15AB-4158-990D-009821ACB1E5
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery\Celery\Celery-SRC.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class SlickTabControl
{
  public Form Parent;
  public int X;
  public int Y;
  public int MaxTabs;
  public string DefaultCaption;
  public int SelectedIndex;
  public SlickTab SelectedItem;
  public Color TabBackColor;
  public Color TabSelectedColor;
  private bool last_visibility;
  private Image TabBackgroundImage;
  private List<SlickTab> Tabs;
  private Label btn_open;

  public event TOnSelect OnSelect;

  public void SetVisible(bool v)
  {
    this.last_visibility = v;
    foreach (SlickTab tab in this.Tabs)
    {
      tab.btn_x.Visible = v;
      tab.lbl_caption.Visible = v;
      tab.tab_bg.Visible = v;
    }
    this.btn_open.Visible = v;
  }

  private void initOpenButton()
  {
    this.btn_open = new Label();
    this.btn_open.Text = "+";
    this.btn_open.Font = new Font("Arial", 14f);
    this.btn_open.ForeColor = Color.Gray;
    this.btn_open.BackColor = Color.Transparent;
    this.btn_open.MouseEnter += (EventHandler) ((sender, e) => this.btn_open.ForeColor = Color.DarkGray);
    this.btn_open.MouseLeave += (EventHandler) ((sender, e) => this.btn_open.ForeColor = Color.Gray);
    this.btn_open.MouseUp += (MouseEventHandler) ((sender, e) =>
    {
      if (this.Tabs.Count >= this.MaxTabs)
        return;
      SlickTab selectedItem = this.SelectedItem;
      this.Add(this.DefaultCaption);
      this.SelectedIndex = this.Tabs.Count - 1;
      this.SelectedItem = this.Tabs[this.SelectedIndex];
      this.Update();
      if (this.OnSelect == null)
        return;
      this.OnSelect.DynamicInvoke((object) this.SelectedItem, (object) selectedItem);
    });
    this.Parent.Controls.Add((Control) this.btn_open);
  }

  public SlickTabControl(Form parentForm)
  {
    this.last_visibility = true;
    this.Parent = parentForm;
    this.X = 0;
    this.Y = 0;
    this.TabBackgroundImage = (Image) null;
    this.TabBackColor = Color.FromArgb(60, 65, 66);
    this.TabSelectedColor = Color.FromArgb(40, 40, 50);
    this.Tabs = new List<SlickTab>();
    this.MaxTabs = 3;
    this.DefaultCaption = "Untitled";
    this.initOpenButton();
  }

  public SlickTabControl(Form parentForm, int xpos, int ypos)
  {
    this.last_visibility = true;
    this.Parent = parentForm;
    this.X = xpos;
    this.Y = ypos;
    this.TabBackgroundImage = (Image) null;
    this.TabBackColor = Color.FromArgb(60, 65, 66);
    this.TabSelectedColor = Color.FromArgb(40, 40, 50);
    this.Tabs = new List<SlickTab>();
    this.MaxTabs = 3;
    this.DefaultCaption = "Untitled";
    this.initOpenButton();
  }

  public void SetPosition(int xpos, int ypos)
  {
    this.X = xpos;
    this.Y = ypos;
  }

  public void SetMaxTabs(int count) => this.MaxTabs = count;

  public void SetTabBackgroundImage(Image img) => this.TabBackgroundImage = img;

  private SlickTab CreateBlankTab()
  {
    SlickTab slicktab = new SlickTab();
    slicktab.btn_x.Font = new Font("Arial", 9.75f, FontStyle.Regular);
    slicktab.btn_x.Text = "x";
    slicktab.btn_x.Size = new Size(18, 18);
    slicktab.btn_x.ForeColor = Color.White;
    slicktab.btn_x.BackColor = Color.Transparent;
    slicktab.btn_x.MouseUp += (MouseEventHandler) ((sender, e) =>
    {
      if (this.Tabs.Count <= 1)
        return;
      this.Remove(slicktab);
      this.Update();
    });
    slicktab.btn_x.MouseEnter += (EventHandler) ((sender, e) => slicktab.btn_x.ForeColor = Color.Gray);
    slicktab.btn_x.MouseLeave += (EventHandler) ((sender, e) => slicktab.btn_x.ForeColor = Color.White);
    slicktab.lbl_caption.Font = new Font("Arial", 9f, FontStyle.Regular);
    slicktab.lbl_caption.ForeColor = Color.White;
    slicktab.lbl_caption.BackColor = Color.Transparent;
    slicktab.lbl_caption.Size = new Size(80, 18);
    slicktab.SelectedColor = this.TabSelectedColor;
    slicktab.BackColor = this.TabBackColor;
    this.Parent.Controls.Add((Control) slicktab.tab_bg);
    this.Parent.Controls.Add((Control) slicktab.btn_x);
    this.Parent.Controls.Add((Control) slicktab.lbl_caption);
    int current_index = this.Tabs.Count;
    if (current_index == 0)
    {
      SlickTab selectedItem = this.SelectedItem;
      this.SelectedItem = slicktab;
      this.SelectedIndex = 0;
      if (this.OnSelect != null)
        this.OnSelect.DynamicInvoke((object) slicktab, (object) selectedItem);
    }
    slicktab.lbl_caption.BringToFront();
    slicktab.btn_x.BringToFront();
    slicktab.Update(this.X, this.Y);
    this.Tabs.Add(slicktab);
    slicktab.lbl_caption.MouseUp += (MouseEventHandler) ((sender, e) =>
    {
      if (this.SelectedItem == slicktab)
        return;
      SlickTab selectedItem = this.SelectedItem;
      this.SelectedIndex = current_index;
      this.SelectedItem = slicktab;
      this.Update();
      if (this.OnSelect == null)
        return;
      this.OnSelect.DynamicInvoke((object) slicktab, (object) selectedItem);
    });
    slicktab.tab_bg.MouseUp += (MouseEventHandler) ((sender, e) =>
    {
      if (this.SelectedItem == slicktab)
        return;
      SlickTab selectedItem = this.SelectedItem;
      this.SelectedIndex = current_index;
      this.SelectedItem = slicktab;
      this.Update();
      if (this.OnSelect == null)
        return;
      this.OnSelect.DynamicInvoke((object) slicktab, (object) selectedItem);
    });
    return slicktab;
  }

  public SlickTab Add()
  {
    SlickTab blankTab = this.CreateBlankTab();
    blankTab.Caption = "Untitled";
    blankTab.Data = (object) string.Empty;
    return blankTab;
  }

  public SlickTab Add(string caption)
  {
    SlickTab blankTab = this.CreateBlankTab();
    blankTab.Caption = caption;
    blankTab.Data = (object) string.Empty;
    return blankTab;
  }

  public SlickTab Add(string caption, string initial_data)
  {
    SlickTab blankTab = this.CreateBlankTab();
    blankTab.Caption = caption;
    blankTab.Data = (object) initial_data;
    return blankTab;
  }

  public void Remove(int index)
  {
    if (this.SelectedIndex == index)
    {
      this.SelectedIndex = 0;
      SlickTab selectedItem = this.SelectedItem;
      foreach (SlickTab tab in this.Tabs)
      {
        ++this.SelectedIndex;
        if (tab != this.SelectedItem)
        {
          this.SelectedItem = tab;
          break;
        }
      }
      this.Update();
      if (this.OnSelect != null)
        this.OnSelect.DynamicInvoke((object) this.SelectedItem, (object) selectedItem);
    }
    this.Parent.Controls.Remove((Control) this.Tabs[index].btn_x);
    this.Parent.Controls.Remove((Control) this.Tabs[index].lbl_caption);
    this.Parent.Controls.Remove((Control) this.Tabs[index].tab_bg);
    this.Tabs[index].Active = false;
    this.Tabs.RemoveAt(index);
  }

  public void Remove(SlickTab tab)
  {
    if (this.SelectedItem == tab)
    {
      this.SelectedIndex = 0;
      SlickTab selectedItem = this.SelectedItem;
      foreach (SlickTab tab1 in this.Tabs)
      {
        ++this.SelectedIndex;
        if (tab1 != this.SelectedItem)
        {
          this.SelectedItem = tab1;
          break;
        }
      }
      this.Update();
      if (this.OnSelect != null)
        this.OnSelect.DynamicInvoke((object) this.SelectedItem, (object) selectedItem);
    }
    this.Parent.Controls.Remove((Control) tab.btn_x);
    this.Parent.Controls.Remove((Control) tab.lbl_caption);
    this.Parent.Controls.Remove((Control) tab.tab_bg);
    tab.Active = false;
    this.Tabs.Remove(tab);
  }

  public void Swap(int a_index, int b_index)
  {
    SlickTab tab = this.Tabs[a_index];
    this.Tabs.RemoveAt(a_index);
    this.Tabs.Insert(b_index, tab);
  }

  public void Update()
  {
    for (int index = 0; index < this.Tabs.Count; ++index)
    {
      this.Tabs[index].Selected = false;
      int referenceX = this.X;
      if (index > 0)
        referenceX = this.Tabs[index - 1].tab_bg.Right + 4;
      if (this.Tabs[index] == this.SelectedItem)
        this.Tabs[index].Selected = true;
      this.Tabs[index].Update(referenceX, this.Y);
    }
    if (this.Tabs.Count == this.MaxTabs)
      this.btn_open.Visible = false;
    else
      this.btn_open.Visible = this.last_visibility;
    if (this.Tabs.Count > 0)
      this.btn_open.Location = new Point(this.Tabs[this.Tabs.Count - 1].tab_bg.Right, this.Y - 1);
    else
      this.btn_open.Location = new Point(this.X, this.Y - 1);
  }
}
