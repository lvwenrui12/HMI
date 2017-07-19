using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColList;

namespace hmitype
{
    public partial class ListMessage : Form
    {
        private ColListBox colListBox1;
        private IContainer components;
        public EventHandler KeyEnter;
        public ColListBox listbox1;
        private ImageList messageimage;
        private Timer timerclose;
        private TopMessage Topm1;
        private Point vispoint;
        
        public bool vis
        {
            get
            {
                return !(base.Location == this.vispoint);
            }
            set
            {
                if (!value)
                {
                    if (base.Location.X != this.vispoint.X || base.Location.Y != this.vispoint.Y)
                    {
                        base.Height = 2;
                        base.Location = this.vispoint;
                    }
                    this.Topm1.vis = false;
                }
            }
        }

        private void showpoint(Point point, int xdec, int ydec)
        {
            if (point.X + base.Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                point.X -= base.Width + xdec;
            }
            if (point.Y + base.Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                point.Y -= base.Height + ydec;
            }
            base.Location = point;
            this.Refresh();
        }

        public ListMessage()
        {
            this.InitializeComponent();
            this.listbox1 = this.colListBox1;
        }

        private void ListMessage_Load(object sender, EventArgs e)
        {
            base.Location = this.vispoint;
            this.colListBox1.itemmovestate = false;
            this.colListBox1.imglayout = 1;
            this.colListBox1.idwidth = 0;
            this.colListBox1.GotFocus += new EventHandler(this.ThisGotFouce);
            this.colListBox1.LostFocus += new EventHandler(this.ThisLostFouce);
            this.colListBox1.DialogKeyPress += new KeyEventHandler(this.OnDialogKey);
            this.colListBox1.ItemDoubleClick += new EventHandler(this.colListBox_ItemDoubleClick);
            this.colListBox1.ItemSelectChang += new EventHandler(this.colListBox_ItemSelectChang);
            this.colListBox1.listbordercolor = Color.Gray;
            this.Topm1 = new TopMessage();
            this.Topm1.Width = 10;
            this.Topm1.Height = 10;
            this.Topm1.Show();
        }

        private void colListBox_ItemSelectChang(object sender, EventArgs e)
        {
            textmessage_type tm = default(textmessage_type);
            if (this.vis && this.colListBox1.SelectItemindex > -1)
            {
                tm = ((listmessage_type)this.colListBox1.Items[this.colListBox1.SelectItemindex].obj).textmessage;
                this.Topm1.Showstring(tm, -1, new Point(base.Left + base.Width + 4, base.Top + this.colListBox1.Itemheight * this.colListBox1.SelectItemindex - this.colListBox1.ScrollValue), base.Width + 8, 16);
            }
            else
            {
                this.Topm1.Showstring(tm, -1, new Point(0, 0), 0, 0);
            }
        }

        private void colListBox_ItemDoubleClick(object sender, EventArgs e)
        {
            this.SendEnter();
        }

        public void OnDialogKey(object sender, KeyEventArgs e)
        {
            Keys keyData = e.KeyData;
            if (this.vis)
            {
                if (keyData == Keys.Down)
                {
                    this.colListBox1.ItemselectDown();
                }
                else if (keyData == Keys.Up)
                {
                    this.colListBox1.ItemselectUp();
                }
                else if (keyData == Keys.Return)
                {
                    this.SendEnter();
                }
                else if (keyData == Keys.Escape)
                {
                    if (this.vis)
                    {
                        this.vis = false;
                    }
                }
            }
        }

        private void SendEnter()
        {
            if (this.KeyEnter != null && this.listbox1.SelectItemindex > -1)
            {
                this.KeyEnter(this.listbox1.GetItem(this.listbox1.SelectItemindex).obj, null);
            }
            this.vis = false;
        }

        private void ItemDoubleClick(object sender, EventArgs e)
        {
            this.SendEnter();
        }

        public void Reftextmessages(List<listmessage_type> ms, Point point, int xdec, int ydec)
        {
            this.colListBox1.Itemschonghui = false;
            this.colListBox1.Items_Clear();
            if (ms.Count <= 7)
            {
                base.Height = ms.Count * 18 + 10;
            }
            else
            {
                base.Height = 136;
            }
            foreach (listmessage_type current in ms)
            {
                if (current.xiugaistate == 11)
                {
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        img = this.messageimage.Images[current.imgindex],
                        imgen = 1,
                        Text = current.Text,
                        obj = current,
                        itemcolor = new ColListBoxItemColor(Color.Green, this.colListBox1.BackColor)
                    });
                }
                else if (current.xiugaistate == 10)
                {
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        img = this.messageimage.Images[current.imgindex],
                        imgen = 0,
                        Text = current.Text,
                        obj = current
                    });
                }
                else
                {
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        img = this.messageimage.Images[current.imgindex],
                        Text = current.Text,
                        obj = current
                    });
                }
            }
            this.colListBox1.Itemschonghui = true;
            if (ms.Count > 0)
            {
                this.showpoint(point, xdec, ydec);
                this.colListBox1.SelectItemindex = 0;
            }
        }

        private void ThisGotFouce(object sender, EventArgs e)
        {
            this.close_end();
        }

        private void ThisLostFouce(object sender, EventArgs e)
        {
            this.close_yanshi();
        }

        public void close_yanshi()
        {
            if (this.vis)
            {
                this.timerclose.Enabled = false;
                this.timerclose.Enabled = true;
            }
        }

        public void close_end()
        {
            this.timerclose.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.vis)
            {
                this.vis = false;
            }
            this.timerclose.Enabled = false;
        }

        private void ListMessage_Resize(object sender, EventArgs e)
        {
            try
            {
                this.listbox1.Location = new Point(0, 0);
                this.listbox1.Width = base.Width;
                this.listbox1.Height = base.Height;
            }
            catch
            {
            }
        }

        private void ListMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Topm1 != null)
            {
                this.Topm1.Close();
            }
            if (this.Topm1 != null)
            {
                this.Topm1.Dispose();
            }
            this.Topm1 = null;
        }


    }
}
