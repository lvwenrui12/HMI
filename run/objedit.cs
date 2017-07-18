using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hmitype;

namespace run
{
    public partial class objedit : UserControl
    {

        public Myapp_inf Myapp;

        public mobj dobj;

        public int Isxuanzhong = 0;

        public bool IsMove = false;

        private MouseState mousestate = MouseState.defaut;

        private Point mouse_pos;

        public int obj_posX;

        public int obj_posY;

        private PosLaction objxy;

        private Pen pen1 = new Pen(Color.Red, 1f);

        private int mousexuanze = 3;

        public bool Isgaibian = false;

        public runscr runscr1;

        private Bitmap thisbm = null;

   

        private Label label1;

        private Label label2;

        private ImageList imageList1;
        public objedit()
        {
            InitializeComponent();
        }

        public event EventHandler ObjMousedown;


        public event EventHandler ObjXYchang;


        public event EventHandler ObjKeyDown;


        public event EventHandler Dragobj;


        public event EventHandler Moveobj;
       
      
        private void movexy(objedit ed, ref int cc, ref int cy, int mod)
        {
            if (ed.IsMove)
            {
                if (ed.obj_posX + cc + ed.Width >= (int)this.Myapp.lcdwidth)
                {
                    cc = (int)this.Myapp.lcdwidth - ed.obj_posX - ed.Width;
                }
                if (ed.obj_posY + cy + ed.Height >= (int)this.Myapp.lcdheight)
                {
                    cy = (int)this.Myapp.lcdheight - ed.obj_posY - ed.Height;
                }
                if (ed.obj_posX + cc < 0)
                {
                    cc = -ed.obj_posX;
                }
                if (ed.obj_posY + cy < 0)
                {
                    cy = -ed.obj_posY;
                }
                if (mod == 1)
                {
                    ed.Location = new Point(ed.obj_posX + cc, ed.obj_posY + cy);
                    if (cc != 0 || cy != 0)
                    {
                        ed.Isgaibian = true;
                        if (ed.Isxuanzhong == 2)
                        {
                            if (this.Dragobj != null)
                            {
                                this.Dragobj(ed.Location, null);
                            }
                        }
                    }
                }
            }
        }

        private void objedit_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMove)
            {
                int num = 0;
                int num2 = 0;
                switch (this.mousestate)
                {
                    case MouseState.defaut:
                        if (e.X > base.Width - this.mousexuanze)
                        {
                            this.Cursor = Cursors.SizeWE;
                        }
                        else if (e.Y > base.Height - this.mousexuanze)
                        {
                            this.Cursor = Cursors.SizeNS;
                        }
                        else
                        {
                            this.Cursor = Cursors.Hand;
                        }
                        if (this.Moveobj != null)
                        {
                            this.Moveobj(null, null);
                        }
                        break;
                    case MouseState.Move:
                        num = Control.MousePosition.X - this.mouse_pos.X;
                        num2 = Control.MousePosition.Y - this.mouse_pos.Y;
                        foreach (objedit current in this.runscr1.selectobjedits)
                        {
                            this.movexy(current, ref num, ref num2, 0);
                        }
                        foreach (objedit current in this.runscr1.selectobjedits)
                        {
                            this.movexy(current, ref num, ref num2, 1);
                        }
                        if (num != 0 || num2 != 0)
                        {
                            if (this.runscr1.selectobjedits.Count == 1 && this.BackgroundImage != null)
                            {
                                this.BackgroundImage = null;
                            }
                        }
                        break;
                    case MouseState.Xadd:
                        if (this.dobj.isbangding == 2)
                        {
                            base.Height = num;
                        }
                        num = (int)this.objxy.star + Control.MousePosition.X - this.mouse_pos.X;
                        if (base.Left + num > (int)this.Myapp.lcdwidth)
                        {
                            num = (int)this.Myapp.lcdwidth - base.Left;
                        }
                        if (objtype.getobjmark(this.dobj.myobj.objType).byx == 1)
                        {
                            if (base.Top + num > (int)this.Myapp.lcdheight)
                            {
                                num = (int)this.Myapp.lcdheight - base.Top;
                            }
                        }
                        if (num < 2)
                        {
                            num = 2;
                        }
                        base.Width = num;
                        if (objtype.getobjmark(this.dobj.myobj.objType).byx == 1)
                        {
                            base.Height = num;
                        }
                        this.Isgaibian = true;
                        break;
                    case MouseState.Yadd:
                        if (this.dobj.isbangding == 2)
                        {
                            base.Width = num;
                        }
                        num = (int)this.objxy.end + Control.MousePosition.Y - this.mouse_pos.Y;
                        if (base.Top + num > (int)this.Myapp.lcdheight)
                        {
                            num = (int)this.Myapp.lcdheight - base.Top;
                        }
                        if (objtype.getobjmark(this.dobj.myobj.objType).byx == 1)
                        {
                            if (base.Left + num > (int)this.Myapp.lcdwidth)
                            {
                                num = (int)this.Myapp.lcdwidth - base.Left;
                            }
                        }
                        if (num < 2)
                        {
                            num = 2;
                        }
                        base.Height = num;
                        if (objtype.getobjmark(this.dobj.myobj.objType).byx == 1)
                        {
                            base.Width = num;
                        }
                        this.Isgaibian = true;
                        break;
                }
            }
        }

        private void objedit_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ObjMousedown != null)
            {
                this.ObjMousedown(this, null);
            }
            if (e.Button == MouseButtons.Left && this.IsMove)
            {
                switch (this.mousestate)
                {
                    case MouseState.defaut:
                        this.mouse_pos = Control.MousePosition;
                        this.obj_posX = base.Left;
                        this.obj_posY = base.Top;
                        foreach (objedit current in this.runscr1.selectobjedits)
                        {
                            if (current != this)
                            {
                                current.obj_posX = current.Left;
                                current.obj_posY = current.Top;
                            }
                        }
                        this.objxy.star = (ushort)base.Width;
                        this.objxy.end = (ushort)base.Height;
                        if (e.X > base.Width - this.mousexuanze)
                        {
                            this.Cursor = Cursors.SizeWE;
                            this.mousestate = MouseState.Xadd;
                            this.BackgroundImage = null;
                        }
                        else if (e.Y > base.Height - this.mousexuanze)
                        {
                            this.Cursor = Cursors.SizeNS;
                            this.mousestate = MouseState.Yadd;
                            this.BackgroundImage = null;
                        }
                        else
                        {
                            this.Cursor = Cursors.Hand;
                            this.mousestate = MouseState.Move;
                        }
                        break;
                }
            }
        }

        private void objedit_MouseUp(object sender, MouseEventArgs e)
        {
            this.mousestate = MouseState.defaut;
            if (this.ObjXYchang != null)
            {
                this.ObjXYchang(this, null);
            }
            this.Chonghuibmp();
        }

        public void attgaixy()
        {
            try
            {
                if (this.IsMove)
                {
                    base.Location = new Point((int)this.dobj.myobj.redian.x, (int)this.dobj.myobj.redian.y);
                    base.Width = (int)(this.dobj.myobj.redian.endx - this.dobj.myobj.redian.x + 1);
                    base.Height = (int)(this.dobj.myobj.redian.endy - this.dobj.myobj.redian.y + 1);
                }
                this.Chonghuibmp();
            }
            catch (Exception ex)
            {
                MessageOpen.Show("from att make xy Error" + ex.Message);
            }
        }

        public void Setxuanzhong(int state)
        {
            this.Isxuanzhong = state;
            this.Ref();
        }

        public void Ref()
        {
            if (this.dobj.Mypage.mypage.pagelock != 1)
            {
                Pen pen = new Pen(Color.White);
                Pen pen2 = new Pen(Color.Green);
                Bitmap bitmap = new Bitmap(base.Width, base.Height);
                if (this.Isxuanzhong == 2)
                {
                    pen2 = new Pen(Color.Blue);
                }
                if (this.thisbm != null)
                {
                    Graphics.FromImage(bitmap).DrawImage(this.thisbm, 0, 0);
                }
                if (this.dobj.atts[0].zhi[0] != objtype.page && this.Myapp.redianidshow)
                {
                    string objname = this.dobj.objname;
                    Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.White), 1, 1, 8 * objname.Length, 14);
                    if (this.Isxuanzhong == 0)
                    {
                        string text = this.dobj.GetattVal_string("vscope");
                        if (text != null && text == "1")
                        {
                            Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.Black), 2, 2, 8 * objname.Length - 2, 12);
                            Graphics.FromImage(bitmap).DrawString(objname, new Font(Encoding.Default.EncodingName, 9f), new SolidBrush(Color.White), new Point(0, 0));
                        }
                        else
                        {
                            Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.Yellow), 2, 2, 8 * objname.Length - 2, 12);
                            Graphics.FromImage(bitmap).DrawString(objname, new Font(Encoding.Default.EncodingName, 9f), new SolidBrush(Color.Black), new Point(0, 0));
                        }
                    }
                    else if (this.Isxuanzhong == 1)
                    {
                        Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.Green), 2, 2, 8 * objname.Length - 2, 12);
                        Graphics.FromImage(bitmap).DrawString(objname, new Font(Encoding.Default.EncodingName, 9f), new SolidBrush(Color.White), new Point(0, 0));
                    }
                    else if (this.Isxuanzhong == 2)
                    {
                        Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.Blue), 2, 2, 8 * objname.Length - 2, 12);
                        Graphics.FromImage(bitmap).DrawString(objname, new Font(Encoding.Default.EncodingName, 9f), new SolidBrush(Color.White), new Point(0, 0));
                    }
                }
                if (this.Isxuanzhong > 0)
                {
                    pen.DashStyle = DashStyle.Dot;
                    Graphics.FromImage(bitmap).DrawRectangle(pen, 2, 2, base.Width - 4, base.Height - 4);
                    Graphics.FromImage(bitmap).DrawRectangle(pen2, 1, 1, base.Width - 2, base.Height - 2);
                }
                if (this.dobj.atts[0].zhi[0] == objtype.page)
                {
                    base.Parent.BackgroundImage = bitmap;
                }
                else
                {
                    this.BackgroundImage = bitmap;
                }
            }
        }

        public unsafe void Chonghuibmp()
        {
            List<byte[]> list = new List<byte[]>();
            byte[] array = new byte[1];
            PosLaction posLaction = default(PosLaction);
            try
            {
                if (this.runscr1.myapp.upapp.filesr != null)
                {
                    if (this.dobj.atts[0].zhi[0] == objtype.page)
                    {
                        lock (this.runscr1.myapp.upapp.Screenbm)
                        {
                            Graphics.FromImage(this.runscr1.myapp.upapp.Screenbm).Clear(Color.White);
                        }
                    }
                    else if (this.dobj.Mypage.mypage.pagelock == 0)
                    {
                        lock (this.runscr1.myapp.upapp.Screenbm)
                        {
                            Graphics.FromImage(this.runscr1.myapp.upapp.Screenbm).Clear(Color.FromArgb(0, 0, 0, 0));
                        }
                    }
                    this.runscr1.myapp.upapp.havetouming = false;
                    if (objtype.getobjmark(this.dobj.atts[0].zhi[0]).show == 0)
                    {
                        this.Ref();
                    }
                    else
                    {
                        if (this.dobj.myobj.redian.x < 0 || this.dobj.myobj.redian.endx >= this.Myapp.lcdwidth || this.dobj.myobj.redian.y < 0 || this.dobj.myobj.redian.endy >= this.Myapp.lcdheight)
                        {
                            this.thisbm = new Bitmap(base.Width, base.Height);
                            this.BackgroundImage = null;
                        }
                        else
                        {
                            if (this.dobj.atts[0].zhi[0] < 50)
                            {
                                objxinxi myobj = this.dobj.myobj;
                                array = new byte[128000];
                                myobj.attpos = 0;
                                myobj.attposqyt = this.dobj.GetobjRambytes(ref array, 0);
                                array = array.subbytes(0, (int)myobj.attposqyt);
                                array.BytesToptr(0, this.runscr1.myapp.mymerry);
                                array = new byte[1];

                                hmitype.GuiObjControl.GuiObjControls[(int)this.dobj.atts[0].zhi[0]].Init(&myobj, (byte)this.dobj.objid);
                            }
                            else
                            {
                                this.dobj.Getbianji(ref list);
                                if (list.Count > 0)
                                {
                                    posLaction.star = 0;
                                    foreach (byte[] current in list)
                                    {
                                        try
                                        {
                                            fixed (byte* ptr = current)
                                            {
                                                posLaction.end = (ushort)(current.Length - 1);
                                                CodeRun.Coderun_Run(ptr, &posLaction);
                                            }
                                        }
                                        finally
                                        {
                                            byte* ptr = null;
                                        }
                                    }
                                }
                            }
                            if (this.dobj.Mypage.mypage.pagelock == 0)
                            {
                                this.thisbm = new Bitmap(base.Width, base.Height);
                                lock (this.runscr1.myapp.upapp.Screenbm)
                                {
                                    Graphics.FromImage(this.thisbm).DrawImage(this.runscr1.myapp.upapp.Screenbm, new Rectangle(0, 0, base.Width, base.Height), new Rectangle(base.Left, base.Top, base.Width, base.Height), GraphicsUnit.Pixel);
                                }
                                if (base.Parent != null && this.dobj.atts[0].zhi[0] == objtype.page)
                                {
                                    base.Visible = false;
                                    this.Ref();
                                }
                                else if (this.dobj.atts[0].zhi[0] != objtype.page)
                                {
                                    base.Visible = true;
                                    this.Ref();
                                }
                            }
                        }
                        if (this.dobj.Mypage.mypage.pagelock == 1)
                        {
                            base.Enabled = false;
                            if (this.dobj.atts[0].zhi[0] == objtype.page)
                            {
                                string text = "页面已锁定".Language();
                                this.thisbm = new Bitmap(this.runscr1.myapp.upapp.Screenbm.Width, this.runscr1.myapp.upapp.Screenbm.Height);
                                Graphics.FromImage(this.thisbm).Clear(Color.FromArgb(50, 72, 149, 253));
                                Graphics.FromImage(this.thisbm).FillRectangle(new SolidBrush(Color.White), (this.thisbm.Width - this.imageList1.Images[0].Width) / 2 - 20, (this.thisbm.Height - this.imageList1.Images[0].Height) / 2 - 20, this.imageList1.Images[0].Width + 40, this.imageList1.Images[0].Height + 40);
                                Graphics.FromImage(this.thisbm).DrawImage(this.imageList1.Images[0], (this.thisbm.Width - this.imageList1.Images[0].Width) / 2, (this.thisbm.Height - this.imageList1.Images[0].Height) / 2);
                                this.BackgroundImage = this.thisbm;
                                base.Visible = true;
                            }
                            else
                            {
                                base.Visible = false;
                            }
                        }
                    }
                    if (this.runscr1.myapp.upapp.havetouming)
                    {
                        this.BackColor = Color.FromArgb(0, 0, 0, 0);
                    }
                    if (this.dobj.Mypage.mypage.pagelock == 1 && this.dobj.objid == this.dobj.Mypage.objs.Count - 1)
                    {
                        lock (this.runscr1.myapp.upapp.Screenbm)
                        {
                            this.thisbm = new Bitmap(this.runscr1.myapp.upapp.Screenbm.Width, this.runscr1.myapp.upapp.Screenbm.Height);
                            Graphics.FromImage(this.thisbm).DrawImage(this.runscr1.myapp.upapp.Screenbm, 0, 0);
                            this.runscr1.BackgroundImage = this.thisbm;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("重绘控件出现错误 ".Language() + ex.Message);
            }
        }

        private void objedit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                bool flag = true;
                if (e.KeyCode == Keys.A && Control.ModifierKeys == Keys.Control)
                {
                    if (this.ObjKeyDown != null)
                    {
                        this.ObjKeyDown("A", null);
                    }
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
                else if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
                {
                    if (this.ObjKeyDown != null)
                    {
                        this.ObjKeyDown("S", null);
                    }
                }
                else if (e.KeyCode == Keys.V && (Control.ModifierKeys & Keys.Control) != Keys.None && (Control.ModifierKeys & Keys.Shift) != Keys.None)
                {
                    if (this.ObjKeyDown != null)
                    {
                        this.ObjKeyDown("VV", null);
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if (this.ObjKeyDown != null)
                    {
                        this.ObjKeyDown("D", null);
                    }
                }
                else
                {
                    switch (e.KeyData)
                    {
                        case Keys.Left:
                            foreach (objedit current in this.runscr1.selectobjedits)
                            {
                                if (current.Left < 1)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                foreach (objedit current in this.runscr1.selectobjedits)
                                {
                                    current.Left--;
                                    current.Isgaibian = true;
                                }
                            }
                            break;
                        case Keys.Up:
                            foreach (objedit current in this.runscr1.selectobjedits)
                            {
                                if (current.Top < 1)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                foreach (objedit current in this.runscr1.selectobjedits)
                                {
                                    current.Top--;
                                    current.Isgaibian = true;
                                }
                            }
                            break;
                        case Keys.Right:
                            foreach (objedit current in this.runscr1.selectobjedits)
                            {
                                if (current.Left + current.Width >= (int)this.Myapp.lcdwidth)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                foreach (objedit current in this.runscr1.selectobjedits)
                                {
                                    current.Left++;
                                    current.Isgaibian = true;
                                }
                            }
                            break;
                        case Keys.Down:
                            foreach (objedit current in this.runscr1.selectobjedits)
                            {
                                if (current.Top + current.Height >= (int)this.Myapp.lcdheight)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                foreach (objedit current in this.runscr1.selectobjedits)
                                {
                                    current.Top++;
                                    current.Isgaibian = true;
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("#1:" + ex.Message);
            }
        }

        private void objedit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void objedit_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.Isgaibian)
            {
                if (this.ObjXYchang != null)
                {
                    this.ObjXYchang(this, null);
                }
            }
            foreach (objedit current in this.runscr1.selectobjedits)
            {
                if (current.Isgaibian)
                {
                    if (current.ObjXYchang != null)
                    {
                        current.ObjXYchang(this, null);
                    }
                }
            }
        }

        private void objedit_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
    }
}
