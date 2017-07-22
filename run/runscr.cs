using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Colpanel;
using hmitype;
using run;



namespace run
{
    public class runscr : UserControl
    {
        // Fields
        public List<objedit> allobjedits = new List<objedit>();
        private string binpath;
        private IContainer components = null;
        private mpage dpage;
        private Point dpoint = new Point(0xffff, 0xffff);
        private Graphics gc;
        private Thread mainthread;
        private unsafe byte* merrya = null;
        public myappinf myapp = new myappinf();
        public Myapp_inf Myapp;
        public Colpanel.Colpanel objpanel;
        private Bitmap selectbm;
        public List<objedit> selectobjedits = new List<objedit>();
        private Thread timerms5;
        public List<objedit> tobjs = new List<objedit>();

        // Events
        public event EventHandler Dragobj;

        public event EventHandler Moveobj;

        public event EventHandler ObjKeyDown;

        public event EventHandler Objpanelresize;

        public event EventHandler Objselect;

        public event EventHandler ObjXYchang;

        public event EventHandler pagechange;

        public event EventHandler Runcodestr;

        public event EventHandler SendCom;

        // Methods
        public runscr()
        {
            this.InitializeComponent();
        }

        private void ClosemainThread()
        {
            try
            {
                this.myapp.upapp.runstate = 0;
                if (this.mainthread != null)
                {
                    int num = 0;
                    while (this.mainthread.IsAlive && (num < 0x3e8))
                    {
                        num++;
                        Thread.Sleep(1);
                    }
                    num = 0;
                    while (this.mainthread.IsAlive && (num < 0x3e8))
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
            catch (Exception exception)
            {
                MessageOpen.Show("Close RunThread Error" + exception.Message);
            }
        }

        private void CloseTimerThread()
        {
            try
            {
                if (this.timerms5 != null)
                {
                    int num = 0;
                    while (this.timerms5.IsAlive && (num < 0x3e8))
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
            catch (Exception exception)
            {
                MessageOpen.Show("Close TimerThread Error" + exception.Message);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Drakuang(int x0, int y0, int x1, int y1)
        {
            try
            {
                Graphics graphics = base.CreateGraphics();
                Graphics graphics2 = Graphics.FromImage(this.selectbm);
                graphics2.DrawImage(this.BackgroundImage, 0, 0);
                Pen pen = new Pen(Color.FromArgb(0, 0, 0));
                Pen pen2 = new Pen(Color.FromArgb(0xff, 0xff, 0xff));
                pen.DashStyle = DashStyle.Dot;
                pen2.DashStyle = DashStyle.Dot;
                graphics2.DrawRectangle(pen, x0, y0, x1, y1);
                graphics2.DrawRectangle(pen2, (int)(x0 + 1), (int)(y0 + 1), (int)(x1 - 1), (int)(y1 - 1));
                graphics.DrawImage(this.selectbm, 0, 0);
            }
            catch
            {
            }
        }

        private void findjizhun()
        {
            foreach (objedit objedit in this.selectobjedits)
            {
                if (objedit.Isxuanzhong == 2)
                {
                    return;
                }
            }
            foreach (objedit objedit in this.selectobjedits)
            {
                if (objedit.IsMove || (objedit.dobj.myobj.objType == objtype.page))
                {
                    if (objedit.Isxuanzhong != 2)
                    {
                        objedit.Setxuanzhong(2);
                    }
                    break;
                }
            }
        }

        private void findjizhun(objedit objedit1)
        {
            foreach (objedit objedit in this.selectobjedits)
            {
                if (objedit.IsMove && (objedit == objedit1))
                {
                    if (objedit.Isxuanzhong != 2)
                    {
                        objedit.Setxuanzhong(2);
                    }
                }
                else if (objedit.Isxuanzhong != 1)
                {
                    objedit.Setxuanzhong(1);
                }
            }
        }

        private bool findselectedit(objedit objedit1)
        {
            foreach (objedit objedit in this.selectobjedits)
            {
                if (objedit == objedit1)
                {
                    return true;
                }
            }
            return false;
        }

        public objedit Getobjedit(int index)
        {
            for (int i = 0; i < this.allobjedits.Count; i++)
            {
                if (this.allobjedits[i].dobj.objid == index)
                {
                    return this.allobjedits[i];
                }
            }
            return null;
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
                this.merrya = (byte*)Marshal.AllocHGlobal(0x1f400);
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
            this.myapp.mymerry = this.merrya + 0x400;
            Hmi.Hexstrbuf = this.merrya + 0x2400;
            this.myapp.systimerbuf = this.merrya + 0x2c00;
            this.myapp.Mycanshus = (PosLaction*)(this.merrya + 0x2e00);
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
            if ((this.myapp.upapp.runapptype == runapptype.run) && ((this.mainthread == null) || !this.mainthread.IsAlive))
            {
                Win32.timeBeginPeriod(1);
                DateTime now = DateTime.Now;
                DateTime time2 = now;
                Rtc.DatetimeSpan = now.AddDays((double)Kuozhan.Getval("datetime_d").Getint()).AddHours((double)Kuozhan.Getval("datetime_h").Getint()).AddMinutes((double)Kuozhan.Getval("datetime_m").Getint()).AddSeconds((double)Kuozhan.Getval("datetime_s").Getint()).Subtract(time2);
                if ((((Rtc.DatetimeSpan.Days == 0) && (Rtc.DatetimeSpan.Hours == 0)) && (Rtc.DatetimeSpan.Minutes == 0)) && (Rtc.DatetimeSpan.Seconds == 0))
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

        public void guiint_bianji(Myapp_inf Myapp_, string binpath_)
        {
            this.gui_int(Myapp_.images, binpath_, Myapp_, runapptype.bianji);
        }

        public void guiint_run(List<guiimagetype> guiimages_, string binpath_)
        {
            this.gui_int(guiimages_, binpath_, null, runapptype.run);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.Name = "runscr";
            base.Size = new Size(0x13b, 0xec);
            base.Load += new EventHandler(this.runscr_Load);
            base.MouseMove += new MouseEventHandler(this.runscr_MouseMove);
            base.MouseDown += new MouseEventHandler(this.runscr_MouseDown);
            base.MouseUp += new MouseEventHandler(this.runscr_MouseUp);
            base.KeyDown += new KeyEventHandler(this.runscr_KeyDown);
            base.ResumeLayout(false);
        }

        public bool Lcd_Set(byte state)
        {
            appinf0 appinf = new appinf0();
            Readdata.Readdata_ReadApp0(ref appinf);
            if ((state % 2) == 0)
            {
                this.myapp.upapp.lcddev.guidire = state;
                base.Width = appinf.lcdscreenw;
                base.Height = appinf.lcdscreenh;
                this.myapp.upapp.lcddev.width = (ushort)base.Width;
                this.myapp.upapp.lcddev.height = (ushort)base.Height;
                this.myapp.upapp.Myscr.Endx = base.Width - 1;
                this.myapp.upapp.Myscr.Endy = base.Height - 1;
                this.myapp.upapp.Screenbm = new Bitmap(base.Width, base.Height);
                this.gc = base.CreateGraphics();
                this.selectbm = new Bitmap(base.Width, base.Height);
                return true;
            }
            this.myapp.upapp.lcddev.guidire = state;
            base.Width = appinf.lcdscreenh;
            base.Height = appinf.lcdscreenw;
            this.myapp.upapp.lcddev.width = (ushort)base.Width;
            this.myapp.upapp.lcddev.height = (ushort)base.Height;
            this.myapp.upapp.Myscr.Endx = base.Width - 1;
            this.myapp.upapp.Myscr.Endy = base.Height - 1;
            this.myapp.upapp.Screenbm = new Bitmap(base.Width, base.Height);
            this.gc = base.CreateGraphics();
            this.selectbm = new Bitmap(base.Width, base.Height);
            return true;
        }

        public void LoadAllObj()
        {
            string str = "";
            for (int i = 0; i < this.Myapp.pages[this.myapp.dpage].objs.Count; i++)
            {
                this.LoadObj(this.Myapp.pages[this.myapp.dpage].objs[i]);
                mobj mobj = this.Myapp.pages[this.myapp.dpage].objs[i];
                if ((objtype.getobjmark(mobj.myobj.objType).show == 1) && ((((mobj.myobj.redian.x < 0) || (mobj.myobj.redian.endx >= this.Myapp.lcdwidth)) || (mobj.myobj.redian.y < 0)) || (mobj.myobj.redian.endy >= this.Myapp.lcdheight)))
                {
                    str = str + mobj.objname + ",";
                }
            }
            if (str != "")
            {
                str = str.Substring(0, str.Length - 1);
                MessageOpen.Show("控件".Language() + ":" + str + " " + "超出显示区域范围,加载被取消".Language());
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

        private void LoadObj___(mobj obj)
        {
            objedit objedit = new objedit();
            try
            {
                objedit.dobj = obj;
                objedit.Location = new Point(objedit.dobj.myobj.redian.x, objedit.dobj.myobj.redian.y);
                objedit.Width = (objedit.dobj.myobj.redian.endx - objedit.dobj.myobj.redian.x) + 1;
                objedit.Height = (objedit.dobj.myobj.redian.endy - objedit.dobj.myobj.redian.y) + 1;
                objedit.IsMove = obj.atts[0].zhi[0] != objtype.page;
                if (objedit.Width < 3)
                {
                    objedit.Width = 3;
                }
                if (base.Height < 3)
                {
                    objedit.Height = 3;
                }
                objedit.BackColor = (obj.atts[0].zhi[0] == objtype.page) ? Color.FromArgb(0, 0x48, 0x95, 0xfd) : Color.FromArgb(50, 0x48, 0x95, 0xfd);
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
            catch (Exception exception)
            {
                MessageOpen.Show("加载控件出现错误 ".Language() + exception.Message);
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
                objedit.Width = 0x23;
                objedit.Height = 0x23;
                objedit.IsMove = false;
                objedit.BackColor = (obj.atts[0].zhi[0] == objtype.page) ? Color.FromArgb(0, 0x48, 0x95, 0xfd) : Color.FromArgb(50, 0x48, 0x95, 0xfd);
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
            catch (Exception exception)
            {
                MessageOpen.Show("加载控件出现错误 ".Language() + exception.Message);
            }
        }

        private void pageidchange(int id)
        {
            if (this.pagechange != null)
            {
                this.pagechange(id, null);
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
            catch (Exception exception)
            {
                MessageOpen.Show(exception.Message);
            }
        }

        public byte Refpage_Edit(mpage page)
        {
            this.dpage = page;
            this.tobjs.Clear();
            this.selectobjedits.Clear();
            while (this.allobjedits.Count > 0)
            {
                objedit item = this.allobjedits[0];
                this.allobjedits.Remove(item);
                item.Dispose();
            }
            Hmi.Hmi_ClearTimer();
            Hmi.Hmi_Clearredian(0);
            Hmi.Hmi_ClearHexstr();
            this.BackgroundImage = null;
            if ((this.Myapp.pages.Count != 0) && (page != null))
            {
                this.myapp.dpage = (ushort)page.pageid;
                base.Visible = false;
                this.LoadAllObj();
                base.Visible = true;
                if ((this.tobjs.Count == 0) && this.objpanel.Visible)
                {
                    this.objpanel.Visible = false;
                    if (this.Objpanelresize != null)
                    {
                        this.Objpanelresize(null, null);
                    }
                }
            }
            return 1;
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
                    switch (this.myapp.USART.State)
                    {
                        case 0xfd:
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

                        case 0xff:
                            Commake.Commake_ClearNorComData();
                            this.myapp.USART.State = 0;
                            break;

                        case 0x16:
                            Usart.Usart_SendByte(0xfe);
                            Commake.Commake_SendEnd();
                            this.myapp.USART.State = 0x17;
                            break;

                        case 0:
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
                                    break;
                                }
                            }
                            if (this.myapp.Hexstrindex != 0xffff)
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
                                    if (this.myapp.Hexstrindex == 0xffff)
                                    {
                                        Hmi.Hmi_GetTimerHexbufIndex();
                                    }
                                }
                            }
                            break;

                        case 9:
                            Sys.Endcomdata();
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                if (this.myapp.upapp.runstate == 1)
                {
                    MessageOpen.Show(exception.Message);
                }
            }
        }

        private void runscr_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.bianji)
            {
                try
                {
                    if ((e.KeyCode == Keys.A) && (Control.ModifierKeys == Keys.Control))
                    {
                        this.ctrl_A();
                    }
                    else if ((e.KeyCode == Keys.Z) && (Control.ModifierKeys == Keys.Control))
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("Z", null);
                        }
                    }
                    else if ((e.KeyCode == Keys.Y) && (Control.ModifierKeys == Keys.Control))
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("Y", null);
                        }
                    }
                    else if ((e.KeyCode == Keys.C) && (Control.ModifierKeys == Keys.Control))
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("C", null);
                        }
                    }
                    else if ((e.KeyCode == Keys.V) && (Control.ModifierKeys == Keys.Control))
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("V", null);
                        }
                    }
                    else if ((e.KeyCode == Keys.X) && (Control.ModifierKeys == Keys.Control))
                    {
                        if (this.ObjKeyDown != null)
                        {
                            this.ObjKeyDown("X", null);
                        }
                    }
                    else if ((e.KeyCode == Keys.Delete) && (this.ObjKeyDown != null))
                    {
                        this.ObjKeyDown("D", null);
                    }
                }
                catch (Exception exception)
                {
                    MessageOpen.Show(exception.Message);
                }
            }
        }

        private void runscr_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
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
                this.myapp.systime.movetime = 0;
                this.myapp.upapp.tp_dev.touchstate = 1;
                this.myapp.upapp.tp_dev.touchtime = 1;
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

        private void runscr_MouseMove(object sender, MouseEventArgs e)
        {
            if ((this.myapp.upapp.runapptype == runapptype.bianji) && (this.dpoint.X != 0xffff))
            {
                if ((e.X >= this.dpoint.X) && (e.Y >= this.dpoint.Y))
                {
                    this.Drakuang(this.dpoint.X, this.dpoint.Y, (e.X - this.dpoint.X) + 1, (e.Y - this.dpoint.Y) + 1);
                }
                else if ((e.X >= this.dpoint.X) && (e.Y <= this.dpoint.Y))
                {
                    this.Drakuang(this.dpoint.X, e.Y, (e.X - this.dpoint.X) + 1, (this.dpoint.Y - e.Y) + 1);
                }
                else if ((e.X <= this.dpoint.X) && (e.Y >= this.dpoint.Y))
                {
                    this.Drakuang(e.X, this.dpoint.Y, (this.dpoint.X - e.X) + 1, (e.Y - this.dpoint.Y) + 1);
                }
                else
                {
                    this.Drakuang(e.X, e.Y, (this.dpoint.X - e.X) + 1, (this.dpoint.Y - e.Y) + 1);
                }
            }
        }

        private void runscr_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.run)
            {
                this.myapp.upapp.tp_dev.touchtime = 0;
                this.myapp.upapp.tp_dev.touchstate = 0;
                this.myapp.tpupenter = 1;
            }
            else
            {
                this.Refresh();
                this.setxuanzhong_all(false);
                foreach (objedit objedit in this.allobjedits)
                {
                    if (((objedit.dobj.atts[0].zhi[0] != objtype.page) && (objtype.getobjmark(objedit.dobj.atts[0].zhi[0]).show != 0)) && Kuozhan.checkbaohan(objedit.Left, objedit.Top, (objedit.Left + objedit.Width) - 1, (objedit.Top + objedit.Height) - 1, this.dpoint.X, this.dpoint.Y, e.X, e.Y))
                    {
                        this.setxuanzhong_add(objedit);
                    }
                }
                if (this.selectobjedits.Count == 0)
                {
                    this.setxuanzhong_add(0);
                }
                this.dpoint.X = 0xffff;
                if (this.Objselect != null)
                {
                    this.Objselect(null, null);
                }
                base.Focus();
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
                            objedit item = this.allobjedits[0];
                            this.allobjedits.Remove(item);
                            item.Dispose();
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
                    Marshal.FreeHGlobal((IntPtr)this.merrya);
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
            catch (Exception exception)
            {
                MessageOpen.Show(exception.Message);
            }
        }

        public void Screenref(byte state)
        {
            try
            {
                if ((this.myapp.upapp.runapptype == runapptype.run) && (this.myapp.upapp.Screenbm != null))
                {
                    lock (this.myapp.upapp.Screenbm)
                    {
                        this.myapp.upapp.Lcdshouxian = 0;
                        Bitmap image = new Bitmap(this.myapp.upapp.Screenbm.Width, this.myapp.upapp.Screenbm.Height);
                        Graphics.FromImage(image).DrawImage(this.myapp.upapp.Screenbm, 0, 0);
                        this.BackgroundImage = image;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageOpen.Show(exception.Message);
            }
        }

        private void SendCom_Code(byte b)
        {
            this.SendCom(b, null);
        }

        private void Sendruncodestr(string str)
        {
            if (this.Runcodestr != null)
            {
                this.Runcodestr(str, null);
            }
        }

        private byte setdate(byte state, uint value)
        {
            return 1;
        }

        public void setxuanzhong_add(objedit ed)
        {
            this.selectobjedits.Add(ed);
            ed.Setxuanzhong(1);
            this.findjizhun();
        }

        public void setxuanzhong_add(int objid)
        {
            foreach (objedit objedit in this.allobjedits)
            {
                if (objedit.dobj.objid == objid)
                {
                    if ((objedit.dobj.atts[0].zhi[0] != objtype.page) || (this.selectobjedits.Count == 0))
                    {
                        this.selectobjedits.Add(objedit);
                        objedit.Setxuanzhong(1);
                        this.findjizhun();
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
                foreach (objedit objedit in this.allobjedits)
                {
                    if ((objedit.dobj.objid != 0) || !state)
                    {
                        this.setxuanzhong_add(objedit);
                    }
                }
                this.findjizhun();
            }
        }

        public void setxuanzhong_del(objedit objedit1)
        {
            foreach (objedit objedit in this.selectobjedits)
            {
                if (objedit == objedit1)
                {
                    objedit.Setxuanzhong(0);
                    this.selectobjedits.Remove(objedit);
                    this.findjizhun();
                    break;
                }
            }
        }

        public void setxuanzhong_del(int objid)
        {
            foreach (objedit objedit in this.selectobjedits)
            {
                if (objedit.dobj.objid == objid)
                {
                    objedit.Setxuanzhong(0);
                    this.selectobjedits.Remove(objedit);
                    this.findjizhun();
                    break;
                }
            }
        }

        private void T_dragobj(object sender, EventArgs e)
        {
            if (this.Dragobj != null)
            {
                this.Dragobj(sender, e);
            }
        }

        private void T_moveobj(object sender, EventArgs e)
        {
            if (this.Moveobj != null)
            {
                this.Moveobj(null, null);
            }
        }

        private void T_objKeyDown(object sender, EventArgs e)
        {
            if (this.myapp.upapp.runapptype == runapptype.bianji)
            {
                string str = ((string)sender).Trim();
                if (str == "A")
                {
                    this.ctrl_A();
                }
                else if (this.ObjKeyDown != null)
                {
                    this.ObjKeyDown(str, null);
                }
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
                    foreach (objedit objedit2 in this.selectobjedits)
                    {
                        if (objedit2 == objedit)
                        {
                            flag = true;
                            this.setxuanzhong_del(objedit2);
                            break;
                        }
                    }
                    if (!flag)
                    {
                        this.setxuanzhong_add(objedit);
                    }
                }
                this.findjizhun();
                if (flag2 && (this.Objselect != null))
                {
                    this.Objselect(null, null);
                }
                objedit.Focus();
            }
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

        public void Upsr()
        {
            if (this.binpath != null)
            {
                try
                {
                    this.myapp.upapp.filesr = new StreamReader(this.binpath);
                    Readdata.Readdata_ReadBinapp();
                }
                catch (Exception exception)
                {
                    MessageOpen.Show(exception.Message);
                }
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
    }

}





