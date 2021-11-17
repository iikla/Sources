// Decompiled with JetBrains decompiler
// Type: Celery.Form1
// Assembly: Celery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09130F4E-6DB0-4861-80C4-AA5DA5D76CCC
// Assembly location: C:\Users\chann\OneDrive\Desktop\Celery (1)\Celery\Celery ().exe

using EyeStepPackage;
using Microsoft.Win32;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Celery
{
  public class Form1 : Form
  {
    private List<Form1.rescale_data> rescale_datas = new List<Form1.rescale_data>();
    private const int MOUSEEVENTF_MOVE = 1;
    private const int MOUSEEVENTF_LEFTDOWN = 2;
    private const int MOUSEEVENTF_LEFTUP = 4;
    private const int MOUSEEVENTF_RIGHTDOWN = 8;
    private const int MOUSEEVENTF_RIGHTUP = 16;
    private const int MOUSEEVENTF_MIDDLEDOWN = 32;
    private const int MOUSEEVENTF_MIDDLEUP = 64;
    private const int MOUSEEVENTF_ABSOLUTE = 32768;
    public bool form_resizing;
    public Size form_resize_start;
    public DateTime celeryin_last_write_time;
    public SlickTabControl script_tabs;
    private List<System.Tuple<string, string>> fflags = new List<System.Tuple<string, string>>();
    private bool shift_key_down;
    public int update_d;
    private IContainer components;
    private PictureBox btn_minimize;
    private PictureBox btn_exit;
    private Timer timer1;
    private Timer timer2;
    private Label lbl_logo;
    private Panel panel1;
    private Panel line2;
    private Button btn_script_hub;
    private Button btn_inject;
    private ListBox lb_script_hub;
    private Panel ConsoleOutput;
    private Panel H2;
    private Panel H1;
    private Button btn_mode_execution;
    private Button btn_mode_output;
    private Scintilla scintilla1;
    private Button btn_save_file;
    private Button btn_load_file;
    private Button btn_clear;
    private Button btn_run_script;
    private RichTextBox txt_editor;
    private Timer animate;
    private PictureBox pictureBox1;

    public Form1()
    {
      this.form_resizing = false;
      this.form_resize_start = new Size(this.Width, this.Height);
      this.InitializeComponent();
      this.InitializeScintilla();
      this.ResizeBegin += new EventHandler(this.form_resizebegin);
      this.ResizeEnd += new EventHandler(this.form_resizeend);
      this.Resize += new EventHandler(this.form_resize);
      this.add_rescale((Control) this.btn_run_script, false, false, false, true);
      this.add_rescale((Control) this.btn_clear, false, false, false, true);
      this.add_rescale((Control) this.btn_save_file, false, false, false, true);
      this.add_rescale((Control) this.btn_load_file, false, false, false, true);
      this.add_rescale((Control) this.btn_inject, false, false, true, true);
      this.add_rescale((Control) this.line2, false, false, true, true);
      this.add_rescale((Control) this.panel1, true, true, false, false);
      this.add_rescale((Control) this.scintilla1, true, true, false, false);
      this.add_rescale((Control) this.txt_editor, true, true, false, false);
      this.add_rescale((Control) this.ConsoleOutput, true, true, false, false);
      this.add_rescale((Control) this.lb_script_hub, false, true, true, false);
      this.add_rescale((Control) this.btn_minimize, false, false, true, false);
      this.add_rescale((Control) this.btn_exit, false, false, true, false);
      this.add_rescale((Control) this.btn_script_hub, false, false, true, false);
      this.add_rescale((Control) this.btn_mode_execution, false, false, true, false);
      this.add_rescale((Control) this.btn_mode_output, false, false, true, false);
      this.add_rescale((Control) this.H1, false, false, true, false);
      this.add_rescale((Control) this.H2, false, false, true, false);
    }

    public void add_rescale(Control sender, bool e, [In] bool obj2, [In] bool obj3, [In] bool obj4) => this.rescale_datas.Add(new Form1.rescale_data()
    {
      ctrl = sender,
      resize_x = e,
      resize_y = obj2,
      reposition_x = obj3,
      reposition_y = obj4,
      form_offset = new Point(this.Right - sender.Left, this.Bottom - sender.Top),
      form_initial_size = this.Size,
      ctrl_initial_size = sender.Size
    });

    [DllImport("user32.dll")]
    private static extern void mouse_event(int a, int b, int t, [In] int obj3, [In] int obj4);

    private void form_resizebegin([In] object obj0, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
        return;
      this.form_resizing = true;
      this.form_resize_start = new Size(this.Width, this.Height);
    }

    private void form_resize([In] object obj0, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
        return;
      if (this.Width < 540)
        this.btn_inject.Visible = false;
      else
        this.btn_inject.Visible = true;
      if (this.Width >= 460 && this.Height >= 120)
        return;
      Point mousePosition = Control.MousePosition;
      int x = mousePosition.X;
      mousePosition = Control.MousePosition;
      int y = mousePosition.Y;
      Form1.mouse_event(4, x, y, 0, 0);
      if (this.Width < 460)
        this.Width = 460;
      if (this.Height >= 120)
        return;
      this.Height = 120;
    }

    public void form_resizeend([In] object obj0, EventArgs e)
    {
      this.form_resizing = false;
      this.form_resize_start = new Size(this.Width, this.Height);
    }

    [SpecialName]
    protected override CreateParams get_CreateParams()
    {
      CreateParams createParams = base.CreateParams;
      createParams.ClassStyle |= 131072;
      return createParams;
    }

    public string HttpGet([In] string obj0)
    {
      using (HttpWebResponse response = (HttpWebResponse) WebRequest.Create(obj0).GetResponse())
      {
        using (Stream responseStream = response.GetResponseStream())
        {
          using (StreamReader streamReader = new StreamReader(responseStream))
            return streamReader.ReadToEnd();
        }
      }
    }

    private void Form1_Load(object word, EventArgs color)
    {
      WinAPI.AnimateWindow(this.Handle, 500, 524288);
      this.H1.BackColor = System.Drawing.Color.LightGreen;
      this.H1.Visible = true;
      this.Invalidate(true);
      this.refreshScripts();
      this.timer2_Tick(word, color);
      this.timer2.Start();
    }

    private float Lerp([In] float obj0, [In] float obj1, float startIndex) => (float) ((1.0 - (double) startIndex) * (double) obj0 + (double) startIndex * (double) obj1);

    private void InitializeScintilla()
    {
      this.script_tabs = new SlickTabControl((Form) this);
      this.script_tabs.SetPosition(0, this.btn_mode_output.Top + 1);
      this.script_tabs.TabBackColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 20, 20, 20);
      this.script_tabs.TabSelectedColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 46, 46, 46);
      this.script_tabs.SetMaxTabs(8);
      this.script_tabs.Add("Untitled*", "print(\"Hello, world\")");
      this.script_tabs.Update();
      this.script_tabs.OnSelect += (TOnSelect) ((obj0, e) =>
      {
        SlickTab slickTab = (SlickTab) obj0;
        ((SlickTab) e).Data = (object) this.scintilla1.Text;
        this.scintilla1.Text = (string) slickTab.Data;
      });
      string str1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
      string str2 = "0123456789";
      string str3 = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
      this.scintilla1.StyleResetDefault();
      this.scintilla1.Styles[32].Font = "Consolas";
      this.scintilla1.Styles[32].Size = 10;
      this.scintilla1.Styles[32].ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.scintilla1.Styles[32].BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.scintilla1.StyleClearAll();
      this.scintilla1.Margins[0].Width = 12;
      this.scintilla1.Margins[1].Width = 6;
      this.scintilla1.Styles[0].ForeColor = System.Drawing.Color.Silver;
      this.scintilla1.Styles[1].ForeColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 232, 119);
      this.scintilla1.Styles[2].ForeColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 232, 119);
      this.scintilla1.Styles[4].ForeColor = System.Drawing.Color.LightGreen;
      this.scintilla1.Styles[5].ForeColor = System.Drawing.Color.LightGreen;
      this.scintilla1.Styles[13].ForeColor = System.Drawing.Color.LightGreen;
      this.scintilla1.Styles[14].ForeColor = System.Drawing.Color.DarkGreen;
      this.scintilla1.Styles[15].ForeColor = System.Drawing.Color.DarkGreen;
      this.scintilla1.Styles[5].Bold = true;
      this.scintilla1.Styles[13].Bold = true;
      this.scintilla1.Styles[14].Bold = true;
      this.scintilla1.Styles[15].Bold = true;
      this.scintilla1.Styles[6].ForeColor = System.Drawing.Color.GreenYellow;
      this.scintilla1.Styles[7].ForeColor = System.Drawing.Color.LightGreen;
      this.scintilla1.Styles[8].ForeColor = System.Drawing.Color.GreenYellow;
      this.scintilla1.Styles[10].ForeColor = System.Drawing.Color.White;
      this.scintilla1.Styles[9].ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.scintilla1.Lexer = Lexer.Lua;
      this.scintilla1.WordChars = str1 + str2 + str3;
      this.scintilla1.SetKeywords(0, "warn workspace game assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath require package.cpath package.loaded package.loadlib package.path package.preload wait and break do else elseif end for function if in local nil not or repeat return then until while false true goto");
      this.scintilla1.SetKeywords(1, "red ToConsole");
      this.scintilla1.SetKeywords(2, "Celery");
      this.scintilla1.SetKeywords(3, "toconsole decompile getclipboard setclipboard gethiddenprop sethiddenprop gethiddenproperty sethiddenproperty iscclosure islclosure newcclosure hookfunction getrawmetatable getnamecallmethod checkcaller getreg getrenv getgenv getsenv getconnections getgc rnet Drawing");
      this.scintilla1.SetProperty("fold", "1");
      this.scintilla1.SetProperty("fold.compact", "1");
      this.scintilla1.Margins[2].Type = MarginType.Symbol;
      this.scintilla1.Margins[2].Mask = 4261412864U;
      this.scintilla1.Margins[2].BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
      this.scintilla1.Margins[2].Sensitive = true;
      this.scintilla1.Margins[2].Width = 0;
      for (int index = 25; index <= 31; ++index)
      {
        this.scintilla1.Markers[index].SetForeColor(SystemColors.ControlLightLight);
        this.scintilla1.Markers[index].SetBackColor(System.Drawing.Color.FromArgb(20, 20, 20));
      }
      this.scintilla1.CaretForeColor = System.Drawing.Color.FromArgb(225, 225, 225);
      this.scintilla1.CaretLineBackColor = System.Drawing.Color.FromArgb(225, 225, 225);
      this.scintilla1.Markers[30].Symbol = MarkerSymbol.BoxPlus;
      this.scintilla1.Markers[31].Symbol = MarkerSymbol.BoxMinus;
      this.scintilla1.Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
      this.scintilla1.Markers[27].Symbol = MarkerSymbol.TCorner;
      this.scintilla1.Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
      this.scintilla1.Markers[29].Symbol = MarkerSymbol.VLine;
      this.scintilla1.Markers[28].Symbol = MarkerSymbol.LCorner;
      this.scintilla1.SetFoldMarginColor(true, System.Drawing.Color.FromArgb(25, 25, 25));
      this.scintilla1.SetFoldMarginHighlightColor(true, System.Drawing.Color.FromArgb(25, 25, 25));
      this.scintilla1.Styles[33].BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
      this.scintilla1.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
      this.scintilla1.HScrollBar = false;
    }

    protected override void WndProc(ref Message sender)
    {
      if (sender.Msg == 132)
      {
        base.WndProc(ref sender);
        if ((int) sender.Result != 1)
          return;
        Point client = this.PointToClient(new Point(sender.LParam.ToInt32()));
        if (client.Y <= 10)
        {
          if (client.X <= 10)
            sender.Result = (IntPtr) 13;
          else if (client.X < this.Size.Width - 10)
            sender.Result = (IntPtr) 12;
          else
            sender.Result = (IntPtr) 14;
        }
        else if (client.Y <= this.Size.Height - 10)
        {
          if (client.X <= 10)
            sender.Result = (IntPtr) 10;
          else if (client.X < this.Size.Width - 10)
            sender.Result = (IntPtr) 2;
          else
            sender.Result = (IntPtr) 11;
        }
        else if (client.X <= 10)
          sender.Result = (IntPtr) 16;
        else if (client.X < this.Size.Width - 10)
          sender.Result = (IntPtr) 15;
        else
          sender.Result = (IntPtr) 17;
      }
      else
        base.WndProc(ref sender);
    }

    private void scintilla1_Click([In] object obj0, EventArgs e)
    {
    }

    private void pictureBox2_Click([In] object obj0, EventArgs e)
    {
      this.Close();
      Environment.Exit(0);
    }

    private void timer1_Tick([In] object obj0, EventArgs e)
    {
      if (this.Opacity == 1.0)
        this.timer1.Stop();
      this.Opacity += 0.2;
    }

    public string GetMachineGuid()
    {
      string name1 = "SOFTWARE\\Microsoft\\Cryptography";
      string name2 = "MachineGuid";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return ((registryKey2 != null ? registryKey2.GetValue(name2) : throw new KeyNotFoundException(string.Format("Key Not Found: {0}", (object) name1))) ?? throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2))).ToString();
      }
    }

    private void label1_Click([In] object obj0, EventArgs e)
    {
    }

    private void CheckKeyword([In] string obj0, System.Drawing.Color e, [In] int obj2)
    {
      if (!this.txt_editor.Text.Contains(obj0))
        return;
      int num = -1;
      int selectionStart = this.txt_editor.SelectionStart;
      while ((num = this.txt_editor.Text.IndexOf(obj0, num + 1)) != -1)
      {
        this.txt_editor.Select(num + obj2, obj0.Length);
        this.txt_editor.SelectionColor = e;
        this.txt_editor.Select(selectionStart, 0);
        this.txt_editor.SelectionColor = System.Drawing.Color.FromArgb(200, 200, 200);
      }
    }

    public void update_output_colors()
    {
      this.CheckKeyword("Celery", System.Drawing.Color.LightGreen, 0);
      this.CheckKeyword("Command", System.Drawing.Color.LightGreen, 0);
      this.CheckKeyword("About", System.Drawing.Color.Yellow, 0);
      this.CheckKeyword("Usage", System.Drawing.Color.Yellow, 0);
      this.CheckKeyword("NO", System.Drawing.Color.Red, 0);
      this.CheckKeyword("OK", System.Drawing.Color.Lime, 0);
      this.CheckKeyword("[r]", System.Drawing.Color.Red, 0);
      this.CheckKeyword("[g]", System.Drawing.Color.Green, 0);
      this.CheckKeyword("[b]", System.Drawing.Color.Blue, 0);
    }

    private void button6_Click(object sender, EventArgs e)
    {
      this.H1.BackColor = System.Drawing.Color.LightGreen;
      this.H2.BackColor = System.Drawing.Color.Black;
      this.ConsoleOutput.Visible = false;
      this.scintilla1.Visible = true;
      this.script_tabs.SetVisible(true);
    }

    private void button5_Click(object sender, EventArgs e)
    {
      this.H1.BackColor = System.Drawing.Color.Black;
      this.H2.BackColor = System.Drawing.Color.LightGreen;
      this.ConsoleOutput.Visible = true;
      this.scintilla1.Visible = false;
      this.script_tabs.SetVisible(false);
      this.update_output_colors();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void H2_Paint(object sender, PaintEventArgs e)
    {
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      string str1 = this.HttpGet("https://raw.githubusercontent.com/thedoomed/Celery/main/settings.txt");
      string str2 = str1.Substring(str1.IndexOf("celeryversion=") + 14, 7);
      string str3 = System.IO.File.ReadAllText(Application.StartupPath + "\\VERSION.txt");
      if (!(str2 != str3))
        return;
      this.timer2.Stop();
      if (MessageBox.Show("A new update is available. For the best experience, it is recommended to stay up-to-date. Please press ok to download.", "Update", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      string str4 = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf('\\'));
      string str5 = Path.GetTempPath() + "Celery" + str2 + ".zip";
      string str6 = str2;
      string destinationDirectoryName = str4 + "\\Celery" + str6;
      using (WebClient webClient = new WebClient())
      {
        using (Stream stream = webClient.OpenRead("https://github.com/thedoomed/Celery/raw/main/Celery.zip"))
        {
          using (ZipArchive source = new ZipArchive(stream))
            source.ExtractToDirectory(destinationDirectoryName);
        }
      }
      this.Close();
      Environment.Exit(0);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string text = this.scintilla1.Text;
      if (EyeStep.handle != 0 && this.lbl_logo.Text == "[ celery - injected ]")
      {
        int procAddress = imports.GetProcAddress(imports.GetModuleHandle("KERNELBASE.dll"), "FreeConsole");
        if (util.readUInt(procAddress + 8) == 1U)
          return;
        uint num1 = util.setPageProtect(procAddress, 64U, 1);
        int size = text.Length * 2;
        int num2 = imports.VirtualAllocEx(EyeStep.handle, 0, size, 4096U, 64U);
        util.writeUnicodeString(num2, text, text.Length);
        util.writeUInt(procAddress + 8, 1U);
        util.writeInt(procAddress + 12, num2);
        util.writeInt(procAddress + 16, text.Length);
        int num3 = (int) util.setPageProtect(procAddress, num1, 1);
      }
      else
        this.button8_Click((object) this.btn_inject, e);
    }

    private void button2_Click(object sender, EventArgs e) => this.scintilla1.Text = "";

    private void button3_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Text Files (*.txt) | *.txt";
      openFileDialog.Title = "Celery - Load File";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.scintilla1.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
      int num;
      for (num = openFileDialog.FileName.Length - 1; num >= 0; --num)
      {
        if (openFileDialog.FileName[num] == '\\' || openFileDialog.FileName[num] == '/')
        {
          ++num;
          break;
        }
      }
      this.script_tabs.SelectedItem.Caption = openFileDialog.FileName.Substring(num, openFileDialog.FileName.Length - num);
    }

    private void richTextBox1_Focused(object sender, EventArgs e) => this.txt_editor.Text = "";

    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.LShiftKey && e.KeyCode != Keys.RShiftKey && e.KeyCode != Keys.ShiftKey)
        return;
      this.shift_key_down = false;
    }

    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.LShiftKey && e.KeyCode != Keys.RShiftKey && e.KeyCode != Keys.ShiftKey)
        return;
      this.shift_key_down = true;
    }

    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r' || this.shift_key_down)
        return;
      string str1 = this.txt_editor.Text.Replace("\n", "") + "             ";
      if (str1.ToLower().Substring(0, 4) == "cmds")
      {
        this.txt_editor.Text = "[Command] key\n[About] Generates a new key for you to send to the owner of Celery\nto be whitelisted on this device\n\n[Command] setfflag name value\n[About] Sets the value of the FFlag 'name' to 'value'.\nUse this command BEFORE joining a ROBLOX game.\n[Usage] setfflag FFlagEnableCaptureMode true\n\n[Command] resetfflags\n[About] Restores any previous settings for fflags\n\n";
        this.update_output_colors();
      }
      else if (str1.ToLower() == "help")
        this.txt_editor.Text = "[Celery] Type \"cmds\" to view commands";
      else if (str1.ToLower().Substring(0, 8) == "setfflag")
      {
        string text = this.txt_editor.Text;
        string str2 = "{\n";
        int index1 = 9;
        while (index1 < text.Length && (text[index1] < ' ' || text[index1] > '~'))
          ++index1;
        while (index1 < text.Length)
        {
          string str3 = "";
          string str4 = "";
          char ch;
          while (index1 < text.Length && text[index1] != ' ')
          {
            string str5 = str3;
            ch = text[index1++];
            string str6 = ch.ToString();
            str3 = str5 + str6;
          }
          int index2 = index1 + 1;
          while (index2 < text.Length && (text[index2] != ' ' && text[index2] != '\n') && text[index2] != '\r')
          {
            string str5 = str4;
            ch = text[index2++];
            string str6 = ch.ToString();
            str4 = str5 + str6;
          }
          index1 = index2 + 1;
          this.fflags.Add(new System.Tuple<string, string>(str3, str4));
        }
        int num1 = 0;
        foreach (System.Tuple<string, string> fflag in this.fflags)
        {
          str2 = str2 + "\"" + fflag.Item1 + "\": ";
          str2 += fflag.Item2;
          if (num1++ < this.fflags.Count - 1)
            str2 += ",";
        }
        string contents = str2 + "\n}\n";
        string str7 = this.HttpGet("https://raw.githubusercontent.com/thedoomed/Celery/main/settings.txt");
        string str8 = str7.Substring(str7.IndexOf("rbxversion=") + 11, 16);
        string path1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Versions\\version-" + str8;
        if (Directory.Exists(path1))
        {
          string path2 = path1 + "\\ClientSettings";
          if (!Directory.Exists(path2))
            Directory.CreateDirectory(path2);
          string path3 = path2 + "\\ClientAppSettings.json";
          if (!System.IO.File.Exists(path3))
          {
            using (FileStream fileStream = System.IO.File.Create(path3))
            {
              foreach (char ch in contents.ToCharArray())
                fileStream.WriteByte((byte) ch);
            }
          }
          else
          {
            try
            {
              System.IO.File.WriteAllText(path3, contents);
            }
            catch (UnauthorizedAccessException ex)
            {
              int num2 = (int) MessageBox.Show("ROBLOX is currently using the previous fflag settings..");
            }
          }
        }
        this.txt_editor.Text = "";
      }
      else if (str1.ToLower().Substring(0, 11) == "resetfflags")
      {
        this.fflags.Clear();
        string str2 = this.HttpGet("https://raw.githubusercontent.com/thedoomed/Celery/main/settings.txt");
        string str3 = str2.Substring(str2.IndexOf("rbxversion=") + 11, 16);
        string path1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Versions\\version-" + str3;
        if (Directory.Exists(path1))
        {
          string path2 = path1 + "\\ClientSettings";
          if (Directory.Exists(path2))
          {
            string path3 = path2;
            string path4 = path2 + "\\ClientAppSettings.json";
            if (System.IO.File.Exists(path4))
              System.IO.File.Delete(path4);
            try
            {
              Directory.Delete(path3);
            }
            catch (UnauthorizedAccessException ex)
            {
              int num = (int) MessageBox.Show("ROBLOX is currently using the previous fflag settings..");
            }
          }
        }
        this.txt_editor.Text = "";
      }
      else
      {
        if (!(str1.ToLower().Substring(0, 3) == "key"))
          return;
        Process.Start("celery_auther.exe");
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
      if (processesByName.Length == 0 || !(this.lbl_logo.Text != "[ celery - injected ]") || !EyeStep.open(((IEnumerable<Process>) processesByName).First<Process>()))
        return;
      string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
      int procAddress = imports.GetProcAddress(imports.GetModuleHandle("KERNELBASE.dll"), "FreeConsole");
      uint num1 = util.setPageProtect(procAddress, 64U, 1);
      util.writeBytes(procAddress, new byte[2]
      {
        (byte) 195,
        (byte) 144
      }, -1);
      int size = baseDirectory.Length * 2;
      int num2 = imports.VirtualAllocEx(EyeStep.handle, 0, size, 4096U, 64U);
      util.writeUnicodeString(num2, baseDirectory, baseDirectory.Length);
      util.writeUInt(procAddress + 8, 1U);
      util.writeInt(procAddress + 12, num2);
      util.writeInt(procAddress + 16, baseDirectory.Length);
      int num3 = (int) util.setPageProtect(procAddress, num1, 1);
      auto_hook.quick_inject();
      this.lbl_logo.Text = "[ celery - injected ]";
    }

    private void refreshScripts()
    {
      this.lb_script_hub.Items.Clear();
      if (!Directory.Exists(Application.StartupPath + "\\content\\scripts"))
        return;
      foreach (FileInfo enumerateFile in new DirectoryInfo(Application.StartupPath + "\\content\\scripts").EnumerateFiles())
      {
        if ((enumerateFile.Extension.ToUpper() == ".TXT" ? 1 : (enumerateFile.Extension.ToUpper() == ".LUA" ? 1 : 0)) != 0)
          this.lb_script_hub.Items.Add((object) enumerateFile.ToString());
      }
    }

    private void button7_Click(object sender, EventArgs e) => this.refreshScripts();

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (System.IO.File.Exists(Application.StartupPath + "\\content\\scripts\\" + this.lb_script_hub.GetItemText(this.lb_script_hub.SelectedItem)))
      {
        StreamReader streamReader = new StreamReader(Application.StartupPath + "\\content\\scripts\\" + this.lb_script_hub.GetItemText(this.lb_script_hub.SelectedItem));
        this.scintilla1.Text = streamReader.ReadToEnd();
        streamReader.Dispose();
        streamReader.Close();
        this.script_tabs.SelectedItem.Caption = this.lb_script_hub.GetItemText(this.lb_script_hub.SelectedItem);
      }
      this.refreshScripts();
    }

    private void H1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void button4_Click(object disposing, [In] EventArgs obj1)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Text Files (*.txt) | *.txt";
      saveFileDialog.Title = "Celery - Save File";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      System.IO.File.WriteAllText(saveFileDialog.FileName, this.scintilla1.Text);
      int num;
      for (num = saveFileDialog.FileName.Length - 1; num >= 0; --num)
      {
        if (saveFileDialog.FileName[num] == '\\' || saveFileDialog.FileName[num] == '/')
        {
          ++num;
          break;
        }
      }
      this.script_tabs.SelectedItem.Caption = saveFileDialog.FileName.Substring(num, saveFileDialog.FileName.Length - num);
    }

    private void btn_minimize_Click([In] object obj0, EventArgs last) => this.WindowState = FormWindowState.Minimized;

    private void animate_Tick([In] object obj0, EventArgs e)
    {
      this.script_tabs.Update();
      int num1 = 12;
      if (this.scintilla1.Lines.Count >= 10)
        num1 += 7;
      if (this.scintilla1.Lines.Count >= 100)
        num1 += 7;
      if (this.scintilla1.Lines.Count >= 1000)
        num1 += 7;
      if (this.scintilla1.Lines.Count >= 10000)
        num1 += 7;
      this.scintilla1.Margins[0].Width = num1;
      Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
      if (processesByName.Length == 0)
        this.lbl_logo.Text = "";
      else if (EyeStep.handle != 0 && EyeStep.current_proc != null && ((IEnumerable<Process>) processesByName).First<Process>().Id != EyeStep.current_proc.Id)
        this.lbl_logo.Text = "";
      this.lbl_logo.Left = this.Width / 2 - 76;
      foreach (Form1.rescale_data rescaleData in this.rescale_datas)
      {
        if (rescaleData.reposition_x)
          rescaleData.ctrl.Location = new Point(this.Width - rescaleData.form_offset.X, rescaleData.ctrl.Location.Y);
        if (rescaleData.reposition_y)
          rescaleData.ctrl.Location = new Point(rescaleData.ctrl.Location.X, this.Height - rescaleData.form_offset.Y);
        if (rescaleData.resize_x)
        {
          int num2 = this.Width - rescaleData.form_initial_size.Width;
          rescaleData.ctrl.Width = rescaleData.ctrl_initial_size.Width + num2;
        }
        if (rescaleData.resize_y)
        {
          int num2 = this.Height - rescaleData.form_initial_size.Height;
          rescaleData.ctrl.Height = rescaleData.ctrl_initial_size.Height + num2;
        }
      }
      this.pictureBox1.Invalidate();
    }

    private void btn_script_hub_Click([In] object obj0, EventArgs e) => this.refreshScripts();

    private void ConsoleOutput_Paint([In] object obj0, PaintEventArgs address)
    {
    }

    private void scintilla1_Click_1([In] object obj0, EventArgs e)
    {
    }

    private void pictureBox1_Click([In] object obj0, EventArgs e)
    {
    }

    protected override void Dispose(bool sender)
    {
      if (sender && this.components != null)
        this.components.Dispose();
      base.Dispose(sender);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.btn_exit = new PictureBox();
      this.btn_minimize = new PictureBox();
      this.lbl_logo = new Label();
      this.timer1 = new Timer(this.components);
      this.timer2 = new Timer(this.components);
      this.panel1 = new Panel();
      this.line2 = new Panel();
      this.btn_inject = new Button();
      this.lb_script_hub = new ListBox();
      this.ConsoleOutput = new Panel();
      this.txt_editor = new RichTextBox();
      this.scintilla1 = new Scintilla();
      this.btn_save_file = new Button();
      this.btn_load_file = new Button();
      this.btn_clear = new Button();
      this.btn_run_script = new Button();
      this.btn_script_hub = new Button();
      this.H2 = new Panel();
      this.H1 = new Panel();
      this.btn_mode_execution = new Button();
      this.btn_mode_output = new Button();
      this.animate = new Timer(this.components);
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.btn_exit).BeginInit();
      ((ISupportInitialize) this.btn_minimize).BeginInit();
      this.panel1.SuspendLayout();
      this.ConsoleOutput.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.btn_exit.Image = (Image) componentResourceManager.GetObject("btn_exit.Image");
      this.btn_exit.Location = new Point(692, 8);
      this.btn_exit.Margin = new Padding(4);
      this.btn_exit.Name = "btn_exit";
      this.btn_exit.Size = new Size(23, 18);
      this.btn_exit.SizeMode = PictureBoxSizeMode.StretchImage;
      this.btn_exit.TabIndex = 32;
      this.btn_exit.TabStop = false;
      this.btn_exit.Click += new EventHandler(this.pictureBox2_Click);
      this.btn_minimize.Image = (Image) componentResourceManager.GetObject("btn_minimize.Image");
      this.btn_minimize.Location = new Point(662, 8);
      this.btn_minimize.Margin = new Padding(4);
      this.btn_minimize.Name = "btn_minimize";
      this.btn_minimize.Size = new Size(23, 18);
      this.btn_minimize.SizeMode = PictureBoxSizeMode.StretchImage;
      this.btn_minimize.TabIndex = 31;
      this.btn_minimize.TabStop = false;
      this.btn_minimize.Click += new EventHandler(this.btn_minimize_Click);
      this.lbl_logo.AutoSize = true;
      this.lbl_logo.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbl_logo.ForeColor = System.Drawing.Color.LightGreen;
      this.lbl_logo.Location = new Point(260, 7);
      this.lbl_logo.Margin = new Padding(4, 0, 4, 0);
      this.lbl_logo.Name = "lbl_logo";
      this.lbl_logo.Size = new Size(0, 18);
      this.lbl_logo.TabIndex = 49;
      this.lbl_logo.TextAlign = ContentAlignment.MiddleCenter;
      this.lbl_logo.Click += new EventHandler(this.label1_Click);
      this.timer1.Interval = 30;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.timer2.Interval = 10000;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.panel1.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
      this.panel1.Controls.Add((Control) this.line2);
      this.panel1.Controls.Add((Control) this.btn_inject);
      this.panel1.Controls.Add((Control) this.lb_script_hub);
      this.panel1.Controls.Add((Control) this.ConsoleOutput);
      this.panel1.Controls.Add((Control) this.scintilla1);
      this.panel1.Controls.Add((Control) this.btn_save_file);
      this.panel1.Controls.Add((Control) this.btn_load_file);
      this.panel1.Controls.Add((Control) this.btn_clear);
      this.panel1.Controls.Add((Control) this.btn_run_script);
      this.panel1.Location = new Point(-25, 66);
      this.panel1.Margin = new Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(741, 284);
      this.panel1.TabIndex = 10;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.line2.BackColor = System.Drawing.Color.LightGreen;
      this.line2.Location = new Point(472, 278);
      this.line2.Margin = new Padding(4);
      this.line2.Name = "line2";
      this.line2.Size = new Size(100, 1);
      this.line2.TabIndex = 16;
      this.line2.Visible = false;
      this.btn_inject.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_inject.FlatAppearance.BorderSize = 0;
      this.btn_inject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_inject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_inject.FlatStyle = FlatStyle.Flat;
      this.btn_inject.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_inject.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_inject.Location = new Point(472, 251);
      this.btn_inject.Margin = new Padding(4);
      this.btn_inject.Name = "btn_inject";
      this.btn_inject.Size = new Size(100, 28);
      this.btn_inject.TabIndex = 17;
      this.btn_inject.Text = "Inject";
      this.btn_inject.UseVisualStyleBackColor = false;
      this.btn_inject.Click += new EventHandler(this.button8_Click);
      this.lb_script_hub.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
      this.lb_script_hub.BorderStyle = BorderStyle.None;
      this.lb_script_hub.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lb_script_hub.ForeColor = System.Drawing.Color.LightGreen;
      this.lb_script_hub.FormattingEnabled = true;
      this.lb_script_hub.IntegralHeight = false;
      this.lb_script_hub.ItemHeight = 18;
      this.lb_script_hub.Location = new Point(580, 0);
      this.lb_script_hub.Margin = new Padding(4);
      this.lb_script_hub.Name = "lb_script_hub";
      this.lb_script_hub.Size = new Size(157, 278);
      this.lb_script_hub.TabIndex = 16;
      this.lb_script_hub.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
      this.ConsoleOutput.Controls.Add((Control) this.txt_editor);
      this.ConsoleOutput.Location = new Point(35, 0);
      this.ConsoleOutput.Margin = new Padding(4);
      this.ConsoleOutput.Name = "ConsoleOutput";
      this.ConsoleOutput.Size = new Size(537, 247);
      this.ConsoleOutput.TabIndex = 14;
      this.ConsoleOutput.Visible = false;
      this.ConsoleOutput.Paint += new PaintEventHandler(this.ConsoleOutput_Paint);
      this.txt_editor.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.txt_editor.BorderStyle = BorderStyle.None;
      this.txt_editor.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 186);
      this.txt_editor.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.txt_editor.Location = new Point(0, 0);
      this.txt_editor.Margin = new Padding(4);
      this.txt_editor.Name = "txt_editor";
      this.txt_editor.Size = new Size(537, 243);
      this.txt_editor.TabIndex = 50;
      this.txt_editor.Text = "[Celery]: Initializing...\n[Celery]: Done!\n[Celery]: Type \"cmds\" to view commands\n";
      this.txt_editor.GotFocus += new EventHandler(this.richTextBox1_Focused);
      this.txt_editor.KeyDown += new KeyEventHandler(this.richTextBox1_KeyDown);
      this.txt_editor.KeyPress += new KeyPressEventHandler(this.richTextBox1_KeyPress);
      this.txt_editor.KeyUp += new KeyEventHandler(this.richTextBox1_KeyUp);
      this.scintilla1.BorderStyle = BorderStyle.None;
      this.scintilla1.Location = new Point(28, 0);
      this.scintilla1.Margin = new Padding(4);
      this.scintilla1.Name = "scintilla1";
      this.scintilla1.Size = new Size(544, 247);
      this.scintilla1.TabIndex = 5;
      this.scintilla1.Text = "print(\"Hello, world!\")";
      this.scintilla1.Click += new EventHandler(this.scintilla1_Click_1);
      this.btn_save_file.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_save_file.FlatAppearance.BorderSize = 0;
      this.btn_save_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_save_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_save_file.FlatStyle = FlatStyle.Flat;
      this.btn_save_file.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_save_file.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_save_file.Location = new Point(364, 251);
      this.btn_save_file.Margin = new Padding(4);
      this.btn_save_file.Name = "btn_save_file";
      this.btn_save_file.Size = new Size(100, 28);
      this.btn_save_file.TabIndex = 9;
      this.btn_save_file.Text = "Save File";
      this.btn_save_file.UseVisualStyleBackColor = false;
      this.btn_save_file.Click += new EventHandler(this.button4_Click);
      this.btn_load_file.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_load_file.FlatAppearance.BorderSize = 0;
      this.btn_load_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_load_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_load_file.FlatStyle = FlatStyle.Flat;
      this.btn_load_file.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_load_file.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_load_file.Location = new Point(256, 251);
      this.btn_load_file.Margin = new Padding(4);
      this.btn_load_file.Name = "btn_load_file";
      this.btn_load_file.Size = new Size(100, 28);
      this.btn_load_file.TabIndex = 8;
      this.btn_load_file.Text = "Load File";
      this.btn_load_file.UseVisualStyleBackColor = false;
      this.btn_load_file.Click += new EventHandler(this.button3_Click);
      this.btn_clear.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_clear.FlatAppearance.BorderSize = 0;
      this.btn_clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_clear.FlatStyle = FlatStyle.Flat;
      this.btn_clear.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_clear.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_clear.Location = new Point(148, 251);
      this.btn_clear.Margin = new Padding(4);
      this.btn_clear.Name = "btn_clear";
      this.btn_clear.Size = new Size(100, 28);
      this.btn_clear.TabIndex = 7;
      this.btn_clear.Text = "Clear";
      this.btn_clear.UseVisualStyleBackColor = false;
      this.btn_clear.Click += new EventHandler(this.button2_Click);
      this.btn_run_script.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_run_script.FlatAppearance.BorderSize = 0;
      this.btn_run_script.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_run_script.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_run_script.FlatStyle = FlatStyle.Flat;
      this.btn_run_script.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_run_script.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_run_script.Location = new Point(33, 251);
      this.btn_run_script.Margin = new Padding(4);
      this.btn_run_script.Name = "btn_run_script";
      this.btn_run_script.Size = new Size(107, 28);
      this.btn_run_script.TabIndex = 6;
      this.btn_run_script.Text = "Run Script";
      this.btn_run_script.UseVisualStyleBackColor = false;
      this.btn_run_script.Click += new EventHandler(this.button1_Click);
      this.btn_script_hub.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_script_hub.FlatAppearance.BorderSize = 0;
      this.btn_script_hub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_script_hub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_script_hub.FlatStyle = FlatStyle.Flat;
      this.btn_script_hub.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_script_hub.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_script_hub.Location = new Point(555, 37);
      this.btn_script_hub.Margin = new Padding(4);
      this.btn_script_hub.Name = "btn_script_hub";
      this.btn_script_hub.Size = new Size(157, 28);
      this.btn_script_hub.TabIndex = 18;
      this.btn_script_hub.Text = "Refresh Scripts";
      this.btn_script_hub.UseVisualStyleBackColor = false;
      this.btn_script_hub.Click += new EventHandler(this.btn_script_hub_Click);
      this.H2.BackColor = System.Drawing.Color.Black;
      this.H2.Location = new Point(447, 64);
      this.H2.Margin = new Padding(4);
      this.H2.Name = "H2";
      this.H2.Size = new Size(100, 1);
      this.H2.TabIndex = 13;
      this.H2.Paint += new PaintEventHandler(this.H2_Paint);
      this.H1.BackColor = System.Drawing.Color.LightGreen;
      this.H1.Location = new Point(347, 64);
      this.H1.Margin = new Padding(4);
      this.H1.Name = "H1";
      this.H1.Size = new Size(100, 1);
      this.H1.TabIndex = 12;
      this.H1.Paint += new PaintEventHandler(this.H1_Paint);
      this.btn_mode_execution.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_mode_execution.FlatAppearance.BorderSize = 0;
      this.btn_mode_execution.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_mode_execution.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_mode_execution.FlatStyle = FlatStyle.Flat;
      this.btn_mode_execution.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_mode_execution.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_mode_execution.Location = new Point(347, 37);
      this.btn_mode_execution.Margin = new Padding(4);
      this.btn_mode_execution.Name = "btn_mode_execution";
      this.btn_mode_execution.Size = new Size(100, 28);
      this.btn_mode_execution.TabIndex = 11;
      this.btn_mode_execution.Text = "Execution";
      this.btn_mode_execution.UseVisualStyleBackColor = false;
      this.btn_mode_execution.Click += new EventHandler(this.button6_Click);
      this.btn_mode_output.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
      this.btn_mode_output.FlatAppearance.BorderSize = 0;
      this.btn_mode_output.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
      this.btn_mode_output.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 35, 35);
      this.btn_mode_output.FlatStyle = FlatStyle.Flat;
      this.btn_mode_output.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.btn_mode_output.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
      this.btn_mode_output.Location = new Point(447, 37);
      this.btn_mode_output.Margin = new Padding(4);
      this.btn_mode_output.Name = "btn_mode_output";
      this.btn_mode_output.Size = new Size(100, 28);
      this.btn_mode_output.TabIndex = 10;
      this.btn_mode_output.Text = "Output";
      this.btn_mode_output.UseVisualStyleBackColor = false;
      this.btn_mode_output.Click += new EventHandler(this.button5_Click);
      this.animate.Enabled = true;
      this.animate.Interval = 10;
      this.animate.Tick += new EventHandler(this.animate_Tick);
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.BackgroundImage = (Image) componentResourceManager.GetObject("pictureBox1.BackgroundImage");
      this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox1.Location = new Point(-6, -6);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Padding = new Padding(5, 0, 0, 0);
      this.pictureBox1.Size = new Size(65, 45);
      this.pictureBox1.TabIndex = 50;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
      this.ClientSize = new Size(724, 350);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.btn_script_hub);
      this.Controls.Add((Control) this.lbl_logo);
      this.Controls.Add((Control) this.btn_exit);
      this.Controls.Add((Control) this.btn_minimize);
      this.Controls.Add((Control) this.H2);
      this.Controls.Add((Control) this.btn_mode_output);
      this.Controls.Add((Control) this.H1);
      this.Controls.Add((Control) this.btn_mode_execution);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Form1);
      this.ShowIcon = false;
      this.SizeGripStyle = SizeGripStyle.Show;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Celery";
      this.Load += new EventHandler(this.Form1_Load);
      ((ISupportInitialize) this.btn_exit).EndInit();
      ((ISupportInitialize) this.btn_minimize).EndInit();
      this.panel1.ResumeLayout(false);
      this.ConsoleOutput.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    protected override CreateParams CreateParams
    {
      [SpecialName] get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ClassStyle |= 131072;
        return createParams;
      }
    }

    private class rescale_data
    {
      public Control ctrl;
      public bool resize_x;
      public bool resize_y;
      public bool reposition_x;
      public bool reposition_y;
      public Point form_offset;
      public Size form_initial_size;
      public Size ctrl_initial_size;
    }
  }
}
