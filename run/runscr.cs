using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colpanel;
using hmitype;

namespace run
{
    public partial class runscr : UserControl
    {
       
        public Myapp_inf Myapp;

        private unsafe byte* merrya = null;

        private Graphics gc;

        private Bitmap selectbm;

        public Colpanel.Colpanel objpanel;

        private string binpath;

        private Point dpoint = new Point(65535, 65535);

        public List<objedit> selectobjedits = new List<objedit>();

        public List<objedit> allobjedits = new List<objedit>();

        public List<objedit> tobjs = new List<objedit>();

        private mpage dpage;

        private Thread mainthread;

        private Thread timerms5;

        public myappinf myapp = new myappinf();

        public runscr()
        {
            InitializeComponent();
        }

        public event EventHandler Objselect;


        public event EventHandler ObjXYchang;


        public event EventHandler ObjKeyDown;


        public event EventHandler Objpanelresize;


        public event EventHandler Dragobj;


        public event EventHandler Moveobj;


        public event EventHandler Runcodestr;

        public event EventHandler pagechange;


        public event EventHandler SendCom;
      


     
        public void Upsr()
        {
            if (this.binpath != null)
            {
                try
                {
                    this.myapp.upapp.filesr = new StreamReader(this.binpath);
                    Readdata.Readdata_ReadBinapp();
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                }
            }
        }

        public void Pausesr()
        {
            try
            {
                if (this.myapp.upapp.filesr != null)
                {
                    this.myapp.upapp.filesr.Close();
                    this.myapp.upapp.filesr.Dispose();
                    this.myapp.upapp.filesr = null;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        public byte Refpage_Edit(mpage page)
        {
            this.dpage = page;
            this.tobjs.Clear();
            this.selectobjedits.Clear();
            while (this.allobjedits.Count > 0)
            {
                objedit objedit = this.allobjedits[0];
                this.allobjedits.Remove(objedit);
                objedit.Dispose();
            }
            Hmi.Hmi_ClearTimer();
            Hmi.Hmi_Clearredian(0);
            Hmi.Hmi_ClearHexstr();
            this.BackgroundImage = null;
            byte result;
            if (this.Myapp.pages.Count == 0 || page == null)
            {
                result = 1;
            }
            else
            {
                this.myapp.dpage = (ushort)page.pageid;
                base.Visible = false;
                this.LoadAllObj();
                base.Visible = true;
                if (this.tobjs.Count == 0 && this.objpanel.Visible)
                {
                    this.objpanel.Visible = false;
                    if (this.Objpanelresize != null)
                    {
                        this.Objpanelresize(null, null);
                    }
                }
                result = 1;
            }
            return result;
        }

        private void LoadObj___(mobj obj)
        {
            objedit objedit = new objedit();
            try
            {
                objedit.dobj = obj;
                objedit.Location = new Point((int)objedit.dobj.myobj.redian.x, (int)objedit.dobj.myobj.redian.y);
                objedit.Width = (int)(objedit.dobj.myobj.redian.endx - objedit.dobj.myobj.redian.x + 1);
                objedit.Height = (int)(objedit.dobj.myobj.redian.endy - objedit.dobj.myobj.redian.y + 1);
                objedit.IsMove = (obj.atts[0].zhi[0] != objtype.page);
                if (objedit.Width < 3)
                {
                    objedit.Width = 3;
                }
                if (base.Height < 3)
                {
                    objedit.Height = 3;
                }
                objedit.BackColor = ((obj.atts[0].zhi[0] == objtype.page) ? Color.FromArgb(0, 72, 149, 253) : Color.FromArgb(50, 72, 149, 253));
                objedit.ObjMousedown += new EventHandler(this.T_objMousedown);
                objedit.ObjXYchang += new EventHandler(this.T_objXYchang);
                objedit.ObjKeyDown += new EventHandler(this.T_objKeyDown);
                objedit.Dragobj += new EventHandler(this.T_dragobj);
                objedit.Moveobj += new EventHandler(this.T_moveobj);
                objedit.Myapp = this.Myapp;
                objedit.runscr1 = this;
                objedit.Visible = true;
                base.Controls.Add(objedit);
                objedit.BringToFront();
                objedit.Chonghuibmp();
                this.allobjedits.Add(objedit);
            }
            catch (Exception ex)
            {
                MessageOpen.Show("加载控件出现错误 ".Language() + ex.Message);
            }
        }

        private void LoadpanelObj___(mobj obj)
        {
            objedit objedit = new objedit();
            try
            {
                objedit.dobj = obj;
                objedit.Location = new Point(5, 3);
                if (this.tobjs.Count > 0)
                {
                    Point panelLocation = this.tobjs[this.tobjs.Count - 1].GetPanelLocation();
                    panelLocation.X += 40;
                    objedit.Location = panelLocation;
                }
                objedit.Width = 35;
                objedit.Height = 35;
                objedit.IsMove = false;
                objedit.BackColor = ((obj.atts[0].zhi[0] == objtype.page) ? Color.FromArgb(0, 72, 149, 253) : Color.FromArgb(50, 72, 149, 253));
                objedit.ObjMousedown += new EventHandler(this.T_objMousedown);
                objedit.ObjXYchang += new EventHandler(this.T_objXYchang);
                objedit.ObjKeyDown += new EventHandler(this.T_objKeyDown);
                objedit.Myapp = this.Myapp;
                objedit.runscr1 = this;
                objedit.BackgroundImageLayout = ImageLayout.None;
                this.objpanel.Controls.Add(objedit);
                objedit.Chonghuibmp();
                objedit.BringToFront();
                objedit.Visible = true;
                this.allobjedits.Add(objedit);
                if (!this.objpanel.Visible)
                {
                    if (this.objpanel.Height != 60)
                    {
                        this.objpanel.Height = 60;
                    }
                    this.objpanel.Visible = true;
                    if (this.Objpanelresize != null)
                    {
                        this.Objpanelresize(null, null);
                    }
                }
                this.tobjs.Add(objedit);
            }
            catch (Exception ex)
            {
                MessageOpen.Show("加载控件出现错误 ".Language() + ex.Message);
            }
        }

        public void LoadObj(mobj obj)
        {
            if (objtype.getobjmark(obj.myobj.objType).show == 0)
            {
                this.LoadpanelObj___(obj);
            }
            else
            {
                this.LoadObj___(obj);
            }
        }

        public void LoadAllObj()
        {
            string text = "";
            for (int i = 0; i < this.Myapp.pages[(int)this.myapp.dpage].objs.Count; i++)
            {
                this.LoadObj(this.Myapp.pages[(int)this.myapp.dpage].objs[i]);
                mobj mobj = this.Myapp.pages[(int)this.myapp.dpage].objs[i];
                if (objtype.getobjmark(mobj.myobj.objType).show == 1)
                {
                    if (mobj.myobj.redian.x < 0 || mobj.myobj.redian.endx >= this.Myapp.lcdwidth || mobj.myobj.redian.y < 0 || mobj.myobj.redian.endy >= this.Myapp.lcdheight)
                    {
                        text = text + mobj.objname + ",";
                    }
                }
            }
            if (text != "")
            {
                text = text.Substring(0, text.Length - 1);
                MessageOpen.Show(string.Concat(new string[]
                {
                    "控件".Language(),
                    ":",
                    text,
                    " ",
                    "超出显示区域范围,加载被取消".Language()
                }));
            }
        }

        public void T_objMousedown(object sender, EventArgs e)
        {
            objedit objedit = (objedit)sender;
            bool flag = false;
            bool flag2 = true;
            if (objedit != null)
            {
                this.setxuanzhong_del(0);
                if (Control.ModifierKeys != Keys.Control)
                {
                    if (!this.findselectedit(objedit))
                    {
                        this.setxuanzhong_all(false);
                        this.setxuanzhong_add(objedit);
                    }
                    else if (objedit.Isxuanzhong != 2)
                    {
                        this.findjizhun(objedit);
                        flag2 = false;
                    }
                }
                else
                {
                    foreach (objedit current in this.selectobjedits)
                    {
                        if (current == objedit)
                        {
                            flag = true;
                            this.setxuanzhong_del(current);
                            break;
                        }
                    }
                    if (!flag)
                    {
                        this.setxuanzhong_add(objedit);
                    }
                }
                this.findjizhun();
                if (flag2)
                {
                    if (this.Objselect != null)
                    {
                        this.Objselect(null, null);
                    }
                }
                objedit.Focus();
            }
        }

        public objedit Getobjedit(int index)
        {
            objedit result;
            for (int i = 0; i < this.allobjedits.Count; i++)
            {
                if (this.allobjedits[i].dobj.objid == index)
                {
                    result = this.allobjedits[i];
                    return result;
                }
            }
            result = null;
            return result;
        }

        private bool findselectedit(objedit objedit1)
        {
            bool result;
            foreach (objedit current in this.selectobjedits)
            {
                if (current == objedit1)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        private void findjizhun(objedit objedit1)
        {
            foreach (objedit current in this.selectobjedits)
            {
                if (current.IsMove && current == objedit1)
                {
                    if (current.Isxuanzhong != 2)
                    {
                        current.Setxuanzhong(2);
                    }
                }
                else if (current.Isxuanzhong != 1)
                {
                    current.Setxuanzhong(1);
                }
            }
        }

        private void findjizhun()
        {
            foreach (objedit current in this.selectobjedits)
            {
                if (current.Isxuanzhong == 2)
                {
                    return;
                }
            }
            foreach (objedit current in this.selectobjedits)
            {
                if (current.IsMove || current.dobj.myobj.objType == objtype.page)
                {
                    if (current.Isxuanzhong != 2)
                    {
                        current.Setxuanzhong(2);
                    }
                    break;
                }
            }
        }

        public void setxuanzhong_all(bool state)
        {
            while (this.selectobjedits.Count > 0)
            {
                this.selectobjedits[0].Setxuanzhong(0);
                this.selectobjedits.Remove(this.selectobjedits[0]);
            }
            if (state)
            {
                foreach (objedit current in this.allobjedits)
                {
                    if (current.dobj.objid != 0 || !state)
                    {
                        this.setxuanzhong_add(current);
                    }
                }
                this.findjizhun();
            }
        }

        private void T_moveobj(object sender, EventArgs e)
        {
            if (this.Moveobj != null)
            {
                this.Moveobj(null, null);
            }
        }

        private void T_dragobj(object sender, EventArgs e)
        {
            if (this.Dragobj != null)
            {
                this.Dragobj(sender, e);
            }
        }

        private void T_objKeyDown(object sender, EventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.bianji)
            {
                string text = ((string)sender).Trim();
                if (text == "A")
                {
                    this.ctrl_A();
                }
                else if (this.ObjKeyDown != null)
                {
                    this.ObjKeyDown(text, null);
                }
            }
        }

        private void ctrl_A()
        {
            this.setxuanzhong_all(true);
            this.findjizhun();
            if (this.Objselect != null)
            {
                this.Objselect(null, null);
            }
            if (this.selectobjedits.Count > 0)
            {
                this.selectobjedits[0].Focus();
            }
        }

        public void setxuanzhong_del(int objid)
        {
            foreach (objedit current in this.selectobjedits)
            {
                if (current.dobj.objid == objid)
                {
                    current.Setxuanzhong(0);
                    this.selectobjedits.Remove(current);
                    this.findjizhun();
                    break;
                }
            }
        }

        public void setxuanzhong_del(objedit objedit1)
        {
            foreach (objedit current in this.selectobjedits)
            {
                if (current == objedit1)
                {
                    current.Setxuanzhong(0);
                    this.selectobjedits.Remove(current);
                    this.findjizhun();
                    break;
                }
            }
        }

        public void setxuanzhong_add(int objid)
        {
            foreach (objedit current in this.allobjedits)
            {
                if (current.dobj.objid == objid)
                {
                    if (current.dobj.atts[0].zhi[0] != objtype.page || this.selectobjedits.Count == 0)
                    {
                        this.selectobjedits.Add(current);
                        current.Setxuanzhong(1);
                        this.findjizhun();
                    }
                    break;
                }
            }
        }

        public void setxuanzhong_add(objedit ed)
        {
            this.selectobjedits.Add(ed);
            ed.Setxuanzhong(1);
            this.findjizhun();
        }

        private void T_objXYchang(object sender, EventArgs e)
        {
            objedit objedit = (objedit)sender;
            if (this.ObjXYchang != null)
            {
                this.ObjXYchang(null, null);
            }
            if (objedit != null)
            {
                objedit.Focus();
            }
        }

        private byte setdate(byte state, uint value)
        {
            return 1;
        }

        private void runscr_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.bianji)
            {
                if (this.dpoint.X != 65535)
                {
                    if (e.X >= this.dpoint.X && e.Y >= this.dpoint.Y)
                    {
                        this.Drakuang(this.dpoint.X, this.dpoint.Y, e.X - this.dpoint.X + 1, e.Y - this.dpoint.Y + 1);
                    }
                    else if (e.X >= this.dpoint.X && e.Y <= this.dpoint.Y)
                    {
                        this.Drakuang(this.dpoint.X, e.Y, e.X - this.dpoint.X + 1, this.dpoint.Y - e.Y + 1);
                    }
                    else if (e.X <= this.dpoint.X && e.Y >= this.dpoint.Y)
                    {
                        this.Drakuang(e.X, this.dpoint.Y, this.dpoint.X - e.X + 1, e.Y - this.dpoint.Y + 1);
                    }
                    else
                    {
                        this.Drakuang(e.X, e.Y, this.dpoint.X - e.X + 1, this.dpoint.Y - e.Y + 1);
                    }
                }
            }
        }

        private void Drakuang(int x0, int y0, int x1, int y1)
        {
            try
            {
                Graphics graphics = base.CreateGraphics();
                Graphics graphics2 = Graphics.FromImage(this.selectbm);
                graphics2.DrawImage(this.BackgroundImage, 0, 0);
                Pen pen = new Pen(Color.FromArgb(0, 0, 0));
                Pen pen2 = new Pen(Color.FromArgb(255, 255, 255));
                pen.DashStyle = DashStyle.Dot;
                pen2.DashStyle = DashStyle.Dot;
                graphics2.DrawRectangle(pen, x0, y0, x1, y1);
                graphics2.DrawRectangle(pen2, x0 + 1, y0 + 1, x1 - 1, y1 - 1);
                graphics.DrawImage(this.selectbm, 0, 0);
            }
            catch
            {
            }
        }

        private void runscr_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.bianji)
            {
                try
                {
                    if (e.KeyCode == Keys.A && Control.ModifierKeys == Keys.Control)
                    {
                        this.ctrl_A();
                    }
                    else if (e.KeyCode == Keys.Z && Control.ModifierKeys == Keys.Control)
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("Z", null);
                        }
                    }
                    else if (e.KeyCode == Keys.Y && Control.ModifierKeys == Keys.Control)
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("Y", null);
                        }
                    }
                    else if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Control)
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("C", null);
                        }
                    }
                    else if (e.KeyCode == Keys.V && Control.ModifierKeys == Keys.Control)
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("V", null);
                        }
                    }
                    else if (e.KeyCode == Keys.X && Control.ModifierKeys == Keys.Control)
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("X", null);
                        }
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("D", null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                }
            }
        }

    

        public void guiint_bianji(Myapp_inf Myapp_, string binpath_)
        {
            this.gui_int(Myapp_.images, binpath_, Myapp_, runapptype.bianji);
        }

        public void guiint_run(List<guiimagetype> guiimages_, string binpath_)
        {
            this.gui_int(guiimages_, binpath_, null, runapptype.run);
        }

        public unsafe void gui_int(List<guiimagetype> guiimages_, string binpath_, Myapp_inf mapp_, byte bianjistate)
        {
            this.Myapp = mapp_;
            this.myapp.upapp.images = guiimages_;
            this.binpath = binpath_;
            this.myapp.upapp.filesr = new StreamReader(this.binpath);
            this.myapp.upapp.runapptype = bianjistate;
            if (this.merrya == null)
            {
                this.merrya = (byte*)((void*)Marshal.AllocHGlobal(128000));
            }
            this.myapp.upapp.pageidchange = new pageidchange_(this.pageidchange);
            this.myapp.upapp.ScreenRef = new ScreenRef_(this.Screenref);
            this.myapp.upapp.Sendruncodestr = new Sendruncodestr_(this.Sendruncodestr);
            this.myapp.upapp.Lcd_Set = new Lcd_Set_(this.Lcd_Set);
            this.myapp.upapp.SendCom = new SendCom_(this.SendCom_Code);
            Attmake.myapp = this.myapp;
            CodeRun.myapp = this.myapp;
            Commake.myapp = this.myapp;
            GuiCurve.myapp = this.myapp;
            Showpic.myapp = this.myapp;
            Showfont.myapp = this.myapp;
            GuiSlider.myapp = this.myapp;
            GuiTimer.myapp = this.myapp;
            Hmi.myapp = this.myapp;
            Lcd.myapp = this.myapp;
            Readdata.myapp = this.myapp;
            Sys.myapp = this.myapp;
            Sysatt.myapp = this.myapp;
            Touch.myapp = this.myapp;
            Usart.myapp = this.myapp;
            Commake.Comstrbuf = this.merrya;
            this.myapp.mymerry = this.merrya + 1024;
            Hmi.Hexstrbuf = this.merrya + 9216;
            this.myapp.systimerbuf = this.merrya + 11264;
            this.myapp.Mycanshus = (PosLaction*)(this.merrya + 11776);
            this.myapp.binsuc = 1;
            if (Readdata.Readdata_ReadBinapp() == 0)
            {
                MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language());
                this.myapp.binsuc = 0;
            }
            Hmi.Hmi_OpenInit();
            Hmi.Hmi_Init();
            Hmi.Hmi_RefPage(0);
            this.myapp.USART.State = 0;
            Commake.Commake_ClearNorComData();
            this.myapp.upapp.runstate = 1;
            if (this.myapp.upapp.runapptype == runapptype.run)
            {
                if (this.mainthread == null || !this.mainthread.IsAlive)
                {
                    Win32.timeBeginPeriod(1);
                    DateTime now = DateTime.Now;
                    DateTime value = now;
                    Rtc.DatetimeSpan = now.AddDays((double)Kuozhan.Getval("datetime_d").Getint()).AddHours((double)Kuozhan.Getval("datetime_h").Getint()).AddMinutes((double)Kuozhan.Getval("datetime_m").Getint()).AddSeconds((double)Kuozhan.Getval("datetime_s").Getint()).Subtract(value);
                    if (Rtc.DatetimeSpan.Days == 0 && Rtc.DatetimeSpan.Hours == 0 && Rtc.DatetimeSpan.Minutes == 0 && Rtc.DatetimeSpan.Seconds == 0)
                    {
                        Rtc.DatetimeSpan_val = false;
                    }
                    else
                    {
                        Rtc.DatetimeSpan_val = true;
                    }
                    this.mainthread = new Thread(new ThreadStart(this.runmain));
                    this.timerms5 = new Thread(new ThreadStart(this.timerm_5ms));
                    Hmi.Hmi_ClearTimer();
                    this.timerms5.Start();
                    this.mainthread.Start();
                }
            }
        }

        private void runmain()
        {
            Thread.Sleep(100);
            Win32.timeBeginPeriod(1);
            try
            {
                while (this.myapp.upapp.runstate == 1)
                {
                    Touch.Touch_Tpscan();
                    byte state = this.myapp.USART.State;
                    if (state <= 9)
                    {
                        if (state != 0)
                        {
                            if (state == 9)
                            {
                                Sys.Endcomdata();
                            }
                        }
                        else
                        {
                            if (this.myapp.runmod > 0)
                            {
                                if (Commake.Commake_ScanComcode() == 0)
                                {
                                    Commake.Commake_CheckNorComIdle();
                                }
                                if (this.myapp.upapp.Lcdshouxian == 1)
                                {
                                    this.myapp.upapp.ScreenRef(0);
                                }
                                if (this.myapp.runmod == 2)
                                {
                                    continue;
                                }
                            }
                            if (this.myapp.Hexstrindex != 65535)
                            {
                                Hmi.Hmi_ScanHexCode();
                            }
                            else
                            {
                                this.myapp.pagestate = 1;
                                if (this.myapp.upapp.Lcdshouxian == 1)
                                {
                                    this.myapp.upapp.ScreenRef(0);
                                }
                                if (this.myapp.tpdownenter == 1)
                                {
                                    Hmi.Hmi_Scanrediandown();
                                }
                                else if (this.myapp.tpupenter == 1)
                                {
                                    Hmi.Hmi_Scanredianup();
                                }
                                else if (Commake.Commake_ScanComcode() == 0)
                                {
                                    Commake.Commake_CheckNorComIdle();
                                    Hmi.Hmi_GuiObjectRef();
                                    if (this.myapp.Hexstrindex == 65535)
                                    {
                                        Hmi.Hmi_GetTimerHexbufIndex();
                                    }
                                }
                            }
                        }
                    }
                    else if (state != 22)
                    {
                        switch (state)
                        {
                            case 253:
                                lock (this.myapp.upapp.Screenbm)
                                {
                                    Graphics.FromImage(this.myapp.upapp.Screenbm).Clear(Color.Black);
                                }
                                this.myapp.upapp.ScreenRef(1);
                                Application.DoEvents();
                                Thread.Sleep(100);
                                Hmi.Hmi_OpenInit();
                                Hmi.Hmi_Init();
                                Hmi.Hmi_RefPage(0);
                                this.myapp.USART.State = 0;
                                Commake.Commake_ClearNorComData();
                                break;
                            case 255:
                                Commake.Commake_ClearNorComData();
                                this.myapp.USART.State = 0;
                                break;
                        }
                    }
                    else
                    {
                        Usart.Usart_SendByte(254);
                        Commake.Commake_SendEnd();
                        this.myapp.USART.State = 23;
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.myapp.upapp.runstate == 1)
                {
                    MessageOpen.Show(ex.Message);
                }
            }
        }

        private void pageidchange(int id)
        {
            if (this.pagechange != null)
            {
                this.pagechange(id, null);
            }
        }

        private void Sendruncodestr(string str)
        {
            if (this.Runcodestr != null)
            {
                this.Runcodestr(str, null);
            }
        }

        private void timerm_5ms()
        {
            Win32.timeBeginPeriod(1);
            DateTime now = DateTime.Now;
            while (true)
            {
                Thread.Sleep(5);
                GuiTimer.timerm_5ms(Win32.Win32GetTime(now));
                now = DateTime.Now;
            }
        }

        private void SendCom_Code(byte b)
        {
            this.SendCom(b, null);
        }

        public void Screenref(byte state)
        {
            try
            {
                if (this.myapp.upapp.runapptype == runapptype.run && this.myapp.upapp.Screenbm != null)
                {
                    lock (this.myapp.upapp.Screenbm)
                    {
                        this.myapp.upapp.Lcdshouxian = 0;
                        Bitmap bitmap = new Bitmap(this.myapp.upapp.Screenbm.Width, this.myapp.upapp.Screenbm.Height);
                        Graphics.FromImage(bitmap).DrawImage(this.myapp.upapp.Screenbm, 0, 0);
                        this.BackgroundImage = bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void Writedatetimespan()
        {
            try
            {
                Rtc.DatetimeSpan.Days.ToString().Putval("datetime_d");
                Rtc.DatetimeSpan.Hours.ToString().Putval("datetime_h");
                Rtc.DatetimeSpan.Minutes.ToString().Putval("datetime_m");
                Rtc.DatetimeSpan.Seconds.ToString().Putval("datetime_s");
            }
            catch
            {
            }
        }

        private void ClosemainThread()
        {
            try
            {
                this.myapp.upapp.runstate = 0;
                if (this.mainthread != null)
                {
                    int num = 0;
                    while (this.mainthread.IsAlive && num < 1000)
                    {
                        num++;
                        Thread.Sleep(1);
                    }
                    num = 0;
                    while (this.mainthread.IsAlive && num < 1000)
                    {
                        this.mainthread.Abort();
                        Thread.Sleep(1);
                    }
                    if (this.mainthread.IsAlive)
                    {
                        MessageOpen.Show("Close RunThread Overtime");
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("Close RunThread Error" + ex.Message);
            }
        }

        private void CloseTimerThread()
        {
            try
            {
                if (this.timerms5 != null)
                {
                    int num = 0;
                    while (this.timerms5.IsAlive && num < 1000)
                    {
                        this.timerms5.Abort();
                        Thread.Sleep(1);
                    }
                    if (this.timerms5.IsAlive)
                    {
                        MessageOpen.Show("Close TimerThread Overtime");
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("Close TimerThread Error" + ex.Message);
            }
        }

        public unsafe void RunStop()
        {
            try
            {
                this.myapp.upapp.runstate = 0;
                this.binpath = null;
                if (this.myapp.upapp.runapptype == runapptype.bianji)
                {
                    if (this.myapp.upapp.filesr != null)
                    {
                        this.tobjs.Clear();
                        this.selectobjedits.Clear();
                        while (this.allobjedits.Count > 0)
                        {
                            objedit objedit = this.allobjedits[0];
                            this.allobjedits.Remove(objedit);
                            objedit.Dispose();
                        }
                        this.myapp.upapp.filesr.Close();
                        this.myapp.upapp.filesr.Dispose();
                        this.myapp.upapp.filesr = null;
                    }
                }
                else if (this.myapp.upapp.runapptype == runapptype.run)
                {
                    this.Writedatetimespan();
                    this.CloseTimerThread();
                    this.ClosemainThread();
                    if (this.myapp.upapp.filesr != null)
                    {
                        this.myapp.upapp.filesr.Close();
                        this.myapp.upapp.filesr.Dispose();
                        this.myapp.upapp.filesr = null;
                    }
                }
                if (this.merrya != null)
                {
                    Commake.Comstrbuf = null;
                    this.myapp.mymerry = null;
                    Hmi.Hexstrbuf = null;
                    this.myapp.systimerbuf = null;
                    this.myapp.Mycanshus = null;
                    Marshal.FreeHGlobal((IntPtr)((void*)this.merrya));
                    Commake.Comstrbuf = null;
                    this.myapp.mymerry = null;
                    Hmi.Hexstrbuf = null;
                    this.myapp.systimerbuf = null;
                    this.myapp.Mycanshus = null;
                    this.merrya = null;
                }
                this.Myapp = null;
                this.myapp.upapp.images = null;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void runscr_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.bianji)
            {
                this.dpoint.X = e.X;
                this.dpoint.Y = e.Y;
            }
            else
            {
                this.myapp.upapp.mouse_pos.X = Control.MousePosition.X;
                this.myapp.upapp.mouse_pos.Y = Control.MousePosition.Y;
                this.myapp.systime.movetime = 0u;
                this.myapp.upapp.tp_dev.touchstate = 1;
                this.myapp.upapp.tp_dev.touchtime = 1u;
                this.myapp.upapp.tp_dev.x_now = (ushort)e.X;
                this.myapp.upapp.tp_dev.y_now = (ushort)e.Y;
                if (this.myapp.tpupenter == 0)
                {
                    this.myapp.upapp.tp_dev.x_down = this.myapp.upapp.tp_dev.x_now;
                    this.myapp.upapp.tp_dev.y_down = this.myapp.upapp.tp_dev.y_now;
                    this.myapp.tpdownenter = 1;
                }
            }
        }

        private void runscr_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.run)
            {
                this.myapp.upapp.tp_dev.touchtime = 0u;
                this.myapp.upapp.tp_dev.touchstate = 0;
                this.myapp.tpupenter = 1;
            }
            else
            {
                this.Refresh();
                this.setxuanzhong_all(false);
                foreach (objedit current in this.allobjedits)
                {
                    if (current.dobj.atts[0].zhi[0] != objtype.page && objtype.getobjmark(current.dobj.atts[0].zhi[0]).show != 0 && Kuozhan.checkbaohan(current.Left, current.Top, current.Left + current.Width - 1, current.Top + current.Height - 1, this.dpoint.X, this.dpoint.Y, e.X, e.Y))
                    {
                        this.setxuanzhong_add(current);
                    }
                }
                if (this.selectobjedits.Count == 0)
                {
                    this.setxuanzhong_add(0);
                }
                this.dpoint.X = 65535;
                if (this.Objselect != null)
                {
                    this.Objselect(null, null);
                }
                base.Focus();
            }
        }

        public bool Lcd_Set(byte state)
        {
            appinf0 appinf = default(appinf0);
            Readdata.Readdata_ReadApp0(ref appinf);
            bool result;
            if (state % 2 == 0)
            {
                this.myapp.upapp.lcddev.guidire = state;
                base.Width = (int)appinf.lcdscreenw;
                base.Height = (int)appinf.lcdscreenh;
                this.myapp.upapp.lcddev.width = (ushort)base.Width;
                this.myapp.upapp.lcddev.height = (ushort)base.Height;
                this.myapp.upapp.Myscr.Endx = base.Width - 1;
                this.myapp.upapp.Myscr.Endy = base.Height - 1;
                this.myapp.upapp.Screenbm = new Bitmap(base.Width, base.Height);
                this.gc = base.CreateGraphics();
                this.selectbm = new Bitmap(base.Width, base.Height);
                result = true;
            }
            else
            {
                this.myapp.upapp.lcddev.guidire = state;
                base.Width = (int)appinf.lcdscreenh;
                base.Height = (int)appinf.lcdscreenw;
                this.myapp.upapp.lcddev.width = (ushort)base.Width;
                this.myapp.upapp.lcddev.height = (ushort)base.Height;
                this.myapp.upapp.Myscr.Endx = base.Width - 1;
                this.myapp.upapp.Myscr.Endy = base.Height - 1;
                this.myapp.upapp.Screenbm = new Bitmap(base.Width, base.Height);
                this.gc = base.CreateGraphics();
                this.selectbm = new Bitmap(base.Width, base.Height);
                result = true;
            }
            return result;
        }

        private void runscr_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
    }
}
