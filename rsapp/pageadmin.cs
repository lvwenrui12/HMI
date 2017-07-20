using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColList;
using DevComponents.DotNetBar;
using hmitype;

namespace rsapp
{
    public partial class pageadmin : UserControl
    {

        #region 控件
        private Myapp_inf Myapp;

      

        private Panel panel1;

        private PictureBox pictureBox2;

        private ImageList imageList1;

        private Bar bar1;

        private ButtonItem buttonItem1;

        private ButtonItem buttonItem2;

        private ButtonItem buttonItem7;

        private ButtonItem buttonItem3;

        private ButtonItem buttonItem4;

        private ButtonItem buttonItem5;

        private ButtonItem buttonItem6;

        private LabelItem label1;

        private ColListBox colListBox1;

        private ButtonItem buttonItem8;

        private ButtonItem buttonItem9;

        private ButtonItem buttonItem10;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem delToolStripMenuItem;

        private ToolStripMenuItem insertToolStripMenuItem;

        private ToolStripMenuItem upToolStripMenuItem;

        private ToolStripMenuItem downToolStripMenuItem;

        private ToolStripMenuItem putToolStripMenuItem;

        private ToolStripMenuItem loadToolStripMenuItem;

        private ToolStripMenuItem newToolStripMenuItem;

        private ToolStripMenuItem copyToolStripMenuItem;

        private ToolStripMenuItem delallToolStripMenuItem;

        private ToolStripMenuItem renameToolStripMenuItem;

        private ToolStripMenuItem resetToolStripMenuItem;

        private ToolStripMenuItem suodingToolStripMenuItem;


        #endregion

        public event EventHandler Selectenter;


        public event EventHandler pagecheng;
       

        public pageadmin()
        {
            this.InitializeComponent();
        }

        public void Setapp(Myapp_inf app)
        {
            this.Myapp = app;
            if (app == null)
            {
                if (colListBox1!=null)
                {
                    this.colListBox1.Items_Clear();
                }
                this.bar1.Enabled = false;
                this.label1.Text = "0";
            }
            else
            {
                this.bar1.Enabled = true;
                this.RefList();
            }
        }

        private void upindex()
        {
            if (this.colListBox1.SelectItemindex != -1)
            {
                if (this.Myapp.pages.Count > 1 && this.colListBox1.SelectItemindex > 0)
                {
                    int num = this.colListBox1.SelectItemindex - 1;
                    this.jiaohunziku(this.colListBox1.SelectItemindex, num);
                    this.selectindex(num);
                }
            }
        }

        private void downindex()
        {
            if (this.colListBox1.SelectItemindex != -1)
            {
                if (this.Myapp.pages.Count > 1 && this.colListBox1.SelectItemindex < this.Myapp.pages.Count - 1)
                {
                    int num = this.colListBox1.SelectItemindex + 1;
                    this.jiaohunziku(this.colListBox1.SelectItemindex, num);
                    this.selectindex(num);
                }
            }
        }

        private void jiaohunziku(int index0, int index1)
        {
            mpage value = this.Myapp.pages[index0];
            mpage value2 = this.Myapp.pages[index1];
            this.Myapp.pages[index0] = value2;
            this.Myapp.pages[index1] = value;
            this.Myapp.RefpageID();
            this.RefList();
            if (this.pagecheng != null)
            {
                this.pagecheng(null, null);
            }
        }

        public void selectindex(int index)
        {
            if (index < -1)
            {
                index = -1;
            }
            if (index < this.Myapp.pages.Count)
            {
                this.colListBox1.SelectItemindex = index;
            }
        }

        public void RefList()
        {
            this.colListBox1.Itemschonghui = false;
            this.colListBox1.Items_Clear();
            for (int i = 0; i < this.Myapp.pages.Count; i++)
            {
                int index = 13;
                Color thisFontColor_defaut = Color.Black;
                if (this.Myapp.pages[i].mypage.pagelei > 0 && this.Myapp.pages[i].mypage.pagelei < 21)
                {
                    index = 14;
                }
                if (this.Myapp.pages[i].mypage.pagelock == 1)
                {
                    index = 15;
                    thisFontColor_defaut = Color.Gray;
                }
                if (this.Myapp.pages[i].mypage.pagelei > 0 && this.Myapp.pages[i].mypage.pagelei < 21)
                {
                    thisFontColor_defaut = Color.Blue;
                }
                ColListBoxItem item = new ColListBoxItem
                {
                    img = this.imageList1.Images[index],
                    Text = this.Myapp.pages[i].pagename,
                    obj = this.Myapp.pages[i].pageid,
                    itemcolor = new ColListBoxItemColor(thisFontColor_defaut, Color.White)
                };
                this.colListBox1.Items_Add(item);
            }
            this.label1.Text = this.Myapp.pages.Count.ToString();
            this.colListBox1.Itemschonghui = true;
        }

        private void pageadmin_Paint(object sender, PaintEventArgs e)
        {
            this.DrawThisLine(Color.FromArgb(51, 153, 255), 1);
        }

        private void pageadmin_Resize(object sender, EventArgs e)
        {
            try
            {
                this.bar1.Left = 1;
                this.bar1.Top = 1;
                this.bar1.Width = base.Width - 2;
                this.colListBox1.Top = this.bar1.Top + this.bar1.Height + 1;
                this.colListBox1.Left = 1;
                this.colListBox1.Width = base.Width - 2;
                this.colListBox1.Height = base.Height - this.colListBox1.Top - 1;
            }
            catch
            {
            }
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            this.insertpage();
        }

        private void insertpage()
        {
            int num = this.colListBox1.SelectItemindex;
            mpage item = this.Myapp.Creatnewpage(true);
            if (this.Myapp.pages.Count == 0 || num < 0 || num >= this.Myapp.pages.Count)
            {
                this.Myapp.pages.Add(item);
                num = this.Myapp.pages.Count - 1;
            }
            else
            {
                this.Myapp.pages.Insert(num, item);
            }
            this.Myapp.RefpageID();
            this.RefList();
            this.selectindex(num);
            if (this.pagecheng != null)
            {
                this.pagecheng(null, null);
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.delpage();
        }

        private void delpage()
        {
            int num = this.colListBox1.SelectItemindex;
            if (this.colListBox1.SelectItemindex != -1)
            {
                if (!this.checkkeybangding(num))
                {
                    if (MessageOpen.Show("确认删除吗? ".Language() + "页面:".Language() + this.Myapp.pages[num].pagename, "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Myapp.delpage(this.colListBox1.SelectItemindex, true);
                        if (num >= this.Myapp.pages.Count)
                        {
                            num = this.Myapp.pages.Count - 1;
                        }
                        this.RefList();
                        this.selectindex(num);
                        if (this.pagecheng != null)
                        {
                            this.pagecheng(null, null);
                        }
                    }
                }
            }
            else
            {
                MessageOpen.Show("请选择页面".Language());
            }
        }

        private bool checkkeybangding(int index)
        {
            bool result;
            if (this.Myapp.pages[index].mypage.pagelei > 0 && this.Myapp.pages[index].mypage.pagelei < 21)
            {
                foreach (mpage current in this.Myapp.pages)
                {
                    foreach (mobj current2 in current.objs)
                    {
                        foreach (matt current3 in current2.atts)
                        {
                            if (current3.att.attlei == attshulei.key.typevalue)
                            {
                                if (current3.zhi.Length == 1 && current3.zhi[0] == this.Myapp.pages[index].mypage.pagelei)
                                {
                                    if (current2.checkatt(current3))
                                    {
                                        MessageOpen.Show(string.Concat(new string[]
                                        {
                                            "页面:".Language(),
                                            this.Myapp.pages[index].pagename,
                                            " ",
                                            "已经被以下控件绑定,不可删除!".Language(),
                                            "\r\n".Language(),
                                            current.pagename,
                                            ".",
                                            current2.objname
                                        }));
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            result = false;
            return result;
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.delall();
        }

        private void delall()
        {
            if (MessageOpen.Show("确认删除吗? ".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Myapp.delAllpage();
                this.RefList();
                this.selectindex(this.colListBox1.SelectItemindex);
                if (this.pagecheng != null)
                {
                    this.pagecheng(null, null);
                }
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            this.copypage();
        }

        private void copypage()
        {
            if (this.colListBox1.SelectItemindex != -1)
            {
                mpage mpage = this.Myapp.Copypage(this.Myapp.pages[this.colListBox1.SelectItemindex]);
                mpage.mypage.pagelei = 0;
                this.Myapp.pages.Add(mpage);
                this.Myapp.RefpageID();
                this.RefList();
                this.selectindex(this.Myapp.pages.Count - 1);
                if (this.pagecheng != null)
                {
                    this.pagecheng(null, null);
                }
            }
            else
            {
                MessageOpen.Show("请选择页面".Language());
            }
        }

        private void pageadmin_Load(object sender, EventArgs e)
        {
            Kuozhan.Setobj(this.contextMenuStrip1, datasize.Language);
            this.colListBox1.Itemheight = 20;
            this.colListBox1.itemeditenabled = true;
            this.colListBox1.listborderwidth = 0;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.downindex();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            this.upindex();
        }

        private void colListBox1_ItemSelectChang(object sender, EventArgs e)
        {
            if (this.Selectenter != null)
            {
                this.Selectenter(this.colListBox1.SelectItemindex, null);
            }
            this.colListBox1.Focus();
        }

        private void colListBox1_DialogKeyPress(object sender, KeyEventArgs e)
        {
            if (!this.colListBox1.EditState && e.KeyCode == Keys.Delete)
            {
                this.delpage();
            }
        }

        private void colListBox1_ItemEditEnd(object sender, ColListBoxItemEditEventArgs e)
        {
            if (e.itemindex >= 0 && e.itemindex < this.Myapp.pages.Count)
            {
                if (!(e.newtext == e.oldtext))
                {
                    if (this.Myapp.pages[e.itemindex].mypage.pagelei != 0)
                    {
                        this.colListBox1.Items[e.itemindex].Text = e.oldtext;
                        MessageOpen.Show("系统页面不可修改名称".Language());
                    }
                    else
                    {
                        e.newtext = e.newtext.Trim();
                        int num = e.newtext.GetbytesssASCII().Length;
                        if (num == 0 || num > 14)
                        {
                            this.colListBox1.Items[e.itemindex].Text = e.oldtext;
                            MessageOpen.Show("名称长度最小1字节，最大14字节".Language());
                        }
                        else
                        {
                            string text = e.newtext.ishefaname();
                            if (text != "")
                            {
                                MessageOpen.Show(text);
                                this.colListBox1.Items[e.itemindex].Text = e.oldtext;
                            }
                            else if (this.Myapp.findpagename(e.newtext, e.itemindex) != -1)
                            {
                                this.colListBox1.Items[e.itemindex].Text = e.oldtext;
                                MessageOpen.Show("名称重复!".Language());
                            }
                            else if (this.Myapp.findobjname(this.Myapp.pages[e.itemindex], this.Myapp.pages[e.itemindex].objs[0], e.newtext))
                            {
                                this.colListBox1.Items[e.itemindex].Text = e.oldtext;
                                MessageOpen.Show("名称修改失败：当前页面下有此名称的控件".Language());
                            }
                            else
                            {
                                if (this.Myapp.pages[e.itemindex].objs.Count > 0)
                                {
                                    if (this.Myapp.pages[e.itemindex].objs[0].atts[0].att.attlei == attshulei.Type.typevalue && this.Myapp.pages[e.itemindex].objs[0].atts[0].zhi[0] == objtype.page)
                                    {
                                        this.Myapp.pages[e.itemindex].objs[0].objname = e.newtext;
                                    }
                                }
                                this.colListBox1.Items[e.itemindex].Text = e.newtext;
                                this.Myapp.pages[e.itemindex].pagename = e.newtext;
                                this.colListBox1_ItemSelectChang(sender, new EventArgs());
                                if (this.pagecheng != null)
                                {
                                    this.pagecheng(null, null);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            this.pagedaoru();
        }

        private void pagedaoru()
        {
            if (this.Myapp != null)
            {
                if (this.Myapp.Loadpage("", 0, "", 65535) != -1)
                {
                    this.RefList();
                    this.selectindex(this.Myapp.pages.Count - 1);
                    if (this.pagecheng != null)
                    {
                        this.pagecheng(null, null);
                    }
                }
            }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            this.pagedaochu();
        }

        private void pagedaochu()
        {
            if (this.Myapp != null && this.colListBox1.SelectItemindex != -1 && this.colListBox1.SelectItemindex < this.Myapp.pages.Count)
            {
                this.Myapp.putpage(this.Myapp.pages[this.colListBox1.SelectItemindex]);
            }
            else
            {
                MessageOpen.Show("请选择页面".Language());
            }
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.delpage();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.insertpage();
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.upindex();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.downindex();
        }

        private void putToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pagedaochu();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pagedaoru();
        }

        private void delallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.delall();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.copypage();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colListBox1.SelectItemindex >= 0 && this.Myapp.pages.Count != 0)
            {
                this.colListBox1.EditState = true;
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            mpage mpage = this.Myapp.Creatnewpage(true);
            this.Myapp.pages.Add(mpage);
            this.Myapp.RefpageID();
            this.RefList();
            this.selectindex(mpage.pageid);
            if (this.pagecheng != null)
            {
                this.pagecheng(null, null);
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colListBox1.SelectItemindex >= 0 && this.Myapp.pages.Count != 0)
            {
                int num = this.colListBox1.SelectItemindex;
                if (num < this.Myapp.pages.Count)
                {
                    if (MessageOpen.Show("确认要重置".Language() + this.Myapp.pages[num].pagename + "?", "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Myapp.resetpage(num);
                        if (this.pagecheng != null)
                        {
                            this.pagecheng(null, null);
                        }
                        if (this.Selectenter != null)
                        {
                            this.Selectenter(-1, null);
                        }
                        this.RefList();
                        if (num >= this.Myapp.pages.Count)
                        {
                            num = this.Myapp.pages.Count - 1;
                        }
                        this.colListBox1.SelectItemindex = num;
                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.colListBox1.SelectItemindex >= 0 && this.Myapp.pages.Count != 0)
            {
                if (this.colListBox1.SelectItemindex < this.Myapp.pages.Count)
                {
                    if (this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.pagelei > 0 && this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.pagelei < 21)
                    {
                        this.resetToolStripMenuItem.Visible = true;
                        this.resetToolStripMenuItem.ForeColor = Color.Red;
                        this.renameToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        this.resetToolStripMenuItem.Visible = false;
                        this.renameToolStripMenuItem.Enabled = true;
                    }
                    if (this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.pagelock == 0)
                    {
                        this.suodingToolStripMenuItem.Text = "锁定".Language();
                        this.suodingToolStripMenuItem.ForeColor = Color.Blue;
                    }
                    else
                    {
                        this.suodingToolStripMenuItem.Text = "解锁".Language();
                        this.suodingToolStripMenuItem.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void colListBox1_ItemDoubleClick(object sender, EventArgs e)
        {
            if (this.colListBox1.SelectItemindex < this.Myapp.pages.Count)
            {
                if (this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.pagelei != 0)
                {
                    MessageOpen.Show("系统页面不可修改名称".Language());
                }
                else
                {
                    this.colListBox1.EditState = true;
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mpage mpage = this.Myapp.Creatnewpage(true);
            this.Myapp.pages.Add(mpage);
            this.Myapp.RefpageID();
            this.RefList();
            this.selectindex(mpage.pageid);
            if (this.pagecheng != null)
            {
                this.pagecheng(null, null);
            }
        }

        private void suodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colListBox1.SelectItemindex >= 0 && this.Myapp.pages.Count != 0)
            {
                if (this.colListBox1.SelectItemindex < this.Myapp.pages.Count)
                {
                    if (this.suodingToolStripMenuItem.Text == "锁定".Language())
                    {
                        Form form = new pagelock(this.Myapp.pages[this.colListBox1.SelectItemindex]);
                        form.ShowDialog();
                        if (form.DialogResult != DialogResult.OK)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.password != 0u)
                        {
                            Form form = new unpagelock(this.Myapp.pages[this.colListBox1.SelectItemindex]);
                            form.ShowDialog();
                            if (form.DialogResult != DialogResult.OK)
                            {
                                return;
                            }
                        }
                        if (this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.pagelei > 0)
                        {
                            if (MessageOpen.Show("此页面为系统页面，解锁之后如果对此页面做了不正当的修改，可能会影响到其他页面的正常调用，请慎重！".Language() + "\r\n" + "确认要解锁码？".Language(), "确认".Language(), MessageBoxButtons.YesNo) != DialogResult.Yes)
                            {
                                return;
                            }
                        }
                        this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.pagelock = 0;
                        this.Myapp.pages[this.colListBox1.SelectItemindex].mypage.password = 0u;
                    }
                    if (this.pagecheng != null)
                    {
                        this.pagecheng(null, null);
                    }
                    if (this.Selectenter != null)
                    {
                        this.Selectenter(-1, null);
                    }
                    int selectItemindex = this.colListBox1.SelectItemindex;
                    this.RefList();
                    this.colListBox1.SelectItemindex = selectItemindex;
                }
            }
        }

    }
}
