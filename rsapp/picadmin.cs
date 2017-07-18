using Colpanel;
using DevComponents.DotNetBar;
using hmitype;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace rsapp
{
    public partial class picadmin : UserControl
    {
        private Myapp_inf Myapp;

        public imgpicture dimgpic;

        private List<imgpicture> imgpics = new List<imgpicture>();

     
        private PictureBox pictureBox1;

        private Colpanel.Colpanel panel1;

        private ToolStripButton toolStripButton1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem daochuToolStripMenuItem;

        private ToolStripMenuItem toolStripMenuItem1;

        private ToolStripMenuItem toolStripMenuItem2;

        private ToolStripMenuItem toolStripMenuItem3;

        private ToolStripMenuItem toolStripMenuItem4;

        private ToolStripMenuItem quansahnToolStripMenuItem;

        private Bar bar1;

        private ButtonItem buttonItem1;

        private ButtonItem buttonItem2;

        private ImageList imageList1;

        private ButtonItem buttonItem3;

        private ButtonItem buttonItem4;

        private ButtonItem buttonItem5;

        private ButtonItem buttonItem6;

        private ButtonItem buttonItem7;

        private ControlContainerItem controlContainerItem1;

        private LabelItem label1;

        public event EventHandler picupdate;


        public event EventHandler picselect;
        

        public picadmin()
        {
            this.InitializeComponent();
            Kuozhan.Setobj(this.contextMenuStrip1, datasize.Language);
        }

        public void setfase()
        {
            this.bar1.Enabled = false;
        }

        public void Setapp(Myapp_inf app)
        {
            this.panel1.panel_init();
            this.Myapp = app;
            if (app == null)
            {
                this.Clearpic();
                this.bar1.Enabled = false;
                this.label1.Text = "0";
            }
            else
            {
                this.bar1.Enabled = true;
            }
        }

        private void Clearpic()
        {
            for (int i = this.imgpics.Count - 1; i > -1; i--)
            {
                this.imgpics[i].Close();
                this.imgpics[i].Dispose();
            }
            while (this.imgpics.Count > 0)
            {
                this.imgpics.RemoveAt(0);
            }
            this.imgpics.Clear();
            this.panel1.Controls.Clear();
        }

        public void Ref()
        {
            Pen pen = new Pen(Color.Black, 1f);
            this.dimgpic = null;
            this.Clearpic();
            if (this.Myapp != null)
            {
                try
                {
                    imagesizexytype imagesizexytype = new imagesizexytype
                    {
                        x = 0,
                        y = 0,
                        width = 0,
                        height = 0
                    };
                    if (this.panel1.Width > 24)
                    {
                        for (int i = 0; i < this.Myapp.images.Count; i++)
                        {
                            imgpicture imgpicture = new imgpicture(this.Myapp, i);
                            Point point = new Point(0, imagesizexytype.y + imagesizexytype.height);
                            imgpicture.Location = point;
                            imgpicture.Tag = point;
                            imgpicture.Width = this.panel1.Width - 24;
                            imgpicture.ViewPic(Color.White, Color.Black);
                            this.panel1.Controls.Add(imgpicture);
                            imgpicture.Visible = true;
                            imgpicture.Focus();
                            imgpicture.img_MouseDown += new EventHandler(this.buttonimg_MouseDown);
                            imgpicture.img_DoubleClick += new EventHandler(this.buttonimg_DoubleClick);
                            imgpicture.img_Keydown += new KeyEventHandler(this.buttonimg_KeyDown);
                            imgpicture.ContextMenuStrip = this.contextMenuStrip1;
                            imagesizexytype.x = point.X;
                            imagesizexytype.y = point.Y;
                            imagesizexytype.width = imgpicture.Width;
                            imagesizexytype.height = imgpicture.Height;
                            this.imgpics.Add(imgpicture);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                }
                this.label1.Text = this.Myapp.images.Count.ToString();
            }
        }

        private void buttonimg_MouseDown(object sender, EventArgs e)
        {
            try
            {
                imgpicture imgpicture = (imgpicture)sender;
                if (this.dimgpic != null)
                {
                    this.dimgpic.ViewPic(this.panel1.BackColor, Color.Black);
                }
                this.dimgpic = imgpicture;
                this.dimgpic.ViewPic(Color.Blue, Color.White);
                if (this.picselect != null)
                {
                    this.picselect(this.dimgpic.xuhao, null);
                }
                imgpicture.Focus();
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void selectindex(int index)
        {
            if (index > -1 && index < this.imgpics.Count)
            {
                this.buttonimg_MouseDown(this.imgpics[index], null);
            }
        }

        private void addpic()
        {
            Form form = new addpicjindu(this.Myapp, "add", 0);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                this.Ref();
                this.picupdate(null, null);
            }
        }

        private void delpic()
        {
            try
            {
                if (this.dimgpic != null)
                {
                    if (!this.piccheck(this.dimgpic.xuhao))
                    {
                        if (MessageOpen.Show("确认删除吗? ".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int num = this.dimgpic.xuhao;
                            this.Myapp.delpic(this.dimgpic.xuhao);
                            this.Ref();
                            if (num >= this.imgpics.Count)
                            {
                                num = this.imgpics.Count - 1;
                            }
                            this.selectindex(num);
                            this.picupdate(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private bool piccheck(int index)
        {
            bool result;
            foreach (mpage current in this.Myapp.pages)
            {
                foreach (mobj current2 in current.objs)
                {
                    foreach (matt current3 in current2.atts)
                    {
                        if (current3.att.attlei == attshulei.Picid.typevalue)
                        {
                            ushort num = (ushort)current3.zhi.BytesTostruct(0.GetType());
                            if ((int)num == index)
                            {
                                if (current2.checkatt(current3))
                                {
                                    MessageOpen.Show(string.Concat(new string[]
                                    {
                                        "图片ID:".Language(),
                                        index.ToString(),
                                        " ",
                                        "已经被以下控件使用,不可删除!".Language(),
                                        "\r\n".Language(),
                                        current.pagename,
                                        ".",
                                        current2.objname
                                    }));
                                    result = true;
                                    return result;
                                }
                                current3.zhi = 65535.structToBytes();
                            }
                        }
                    }
                }
            }
            result = false;
            return result;
        }

        private void tihuanpic()
        {
            if (this.dimgpic != null)
            {
                Form form = new addpicjindu(this.Myapp, "tihuan", this.dimgpic.xuhao);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Ref();
                    this.picupdate(null, null);
                }
            }
        }

        private void uppic()
        {
            if (this.dimgpic != null)
            {
                if (this.Myapp.images.Count > 1 && this.dimgpic.xuhao > 0)
                {
                    int num = this.dimgpic.xuhao - 1;
                    this.jiaohunpic(this.dimgpic.xuhao, num);
                    this.selectindex(num);
                }
            }
        }

        private void downpic()
        {
            if (this.dimgpic != null)
            {
                if (this.Myapp.images.Count > 1 && this.dimgpic.xuhao < this.Myapp.images.Count - 1)
                {
                    int num = this.dimgpic.xuhao + 1;
                    this.jiaohunpic(this.dimgpic.xuhao, num);
                    this.selectindex(num);
                }
            }
        }

        private void jiaohunpic(int index0, int index1)
        {
            guiimagetype value = this.Myapp.images[index0];
            this.Myapp.images[index0] = this.Myapp.images[index1];
            this.Myapp.images[index1] = value;
            foreach (mpage current in this.Myapp.pages)
            {
                foreach (mobj current2 in current.objs)
                {
                    foreach (matt current3 in current2.atts)
                    {
                        if (current3.att.attlei == attshulei.Picid.typevalue)
                        {
                            ushort num = (ushort)current3.zhi.BytesTostruct(0.GetType());
                            if ((int)num == index0)
                            {
                                current3.zhi = ((ushort)index1).structToBytes();
                            }
                            else if ((int)num == index1)
                            {
                                current3.zhi = ((ushort)index0).structToBytes();
                            }
                        }
                    }
                }
            }
            foreach (mpage current in this.Myapp.pages)
            {
                foreach (objsetcom_P current4 in current.objsetcomps)
                {
                    foreach (objsetcom current5 in current4.objset)
                    {
                        if (current5.backobj != null)
                        {
                            foreach (matt current3 in current5.backobj.atts)
                            {
                                if (current3.att.attlei == attshulei.Picid.typevalue)
                                {
                                    ushort num = (ushort)current3.zhi.BytesTostruct(0.GetType());
                                    if ((int)num == index0)
                                    {
                                        current3.zhi = ((ushort)index1).structToBytes();
                                    }
                                    else if ((int)num == index1)
                                    {
                                        current3.zhi = ((ushort)index0).structToBytes();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (mobj current2 in this.Myapp.copymobjs)
            {
                foreach (matt current3 in current2.atts)
                {
                    if (current3.att.attlei == attshulei.Picid.typevalue)
                    {
                        ushort num = (ushort)current3.zhi.BytesTostruct(0.GetType());
                        if ((int)num == index0)
                        {
                            current3.zhi = ((ushort)index1).structToBytes();
                        }
                        else if ((int)num == index1)
                        {
                            current3.zhi = ((ushort)index0).structToBytes();
                        }
                    }
                }
            }
            this.Ref();
            this.picupdate(null, null);
        }

        private void insertpic()
        {
            if (this.dimgpic != null)
            {
                Form form = new addpicjindu(this.Myapp, "insert", this.dimgpic.xuhao);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Ref();
                    this.picupdate(null, null);
                }
            }
        }

        private void delallpic()
        {
            if (this.Myapp.images.Count > 0)
            {
                if (MessageOpen.Show("确认要删除所有图片吗?".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Myapp.delAllpic();
                    this.Ref();
                    this.picupdate(null, null);
                }
            }
        }

        private void buttonimg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.delpic();
            }
        }

        private void buttonimg_DoubleClick(object sender, EventArgs e)
        {
            imgpicture imgpicture = (imgpicture)sender;
            new picview(this.Myapp, imgpicture.xuhao).ShowDialog();
        }

        private void picadmin_Paint(object sender, PaintEventArgs e)
        {
            this.DrawThisLine(Color.FromArgb(51, 153, 255), 1);
        }

        private void picadmin_Resize(object sender, EventArgs e)
        {
            try
            {
                this.bar1.Left = 1;
                this.bar1.Top = 1;
                this.bar1.Width = base.Width - 2;
                int top = this.bar1.Top + this.bar1.Height;
                this.panel1.Top = top;
                this.panel1.Left = 1;
                this.panel1.Width = base.Width - 2;
                this.panel1.Height = base.Height - this.panel1.Top - 1;
                if (base.Width > 10)
                {
                    this.Ref();
                }
            }
            catch
            {
            }
        }

        private void daochuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.daochupic();
        }

        private ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo[] array = imageEncoders;
            ImageCodecInfo result;
            for (int i = 0; i < array.Length; i++)
            {
                ImageCodecInfo imageCodecInfo = array[i];
                if (imageCodecInfo.MimeType == mimeType)
                {
                    result = imageCodecInfo;
                    return result;
                }
            }
            MessageOpen.Show("not find ImageCodecInfo" + mimeType);
            result = null;
            return result;
        }

        private void daochupic()
        {
            if (this.dimgpic != null)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "jpg|*.jpg|bmp|*.bmp|png|*.png".Language();
                    saveFileDialog.Getpath("topic");
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        saveFileDialog.Putpath("topic");
                        Bitmap bitmap = this.Myapp.images[this.dimgpic.xuhao].imagebytes.GetBitmap(this.Myapp.images[this.dimgpic.xuhao].picturexinxi, true);
                        EncoderParameters encoderParameters = new EncoderParameters();
                        long[] value = new long[]
                        {
                            100L
                        };
                        EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, value);
                        encoderParameters.Param[0] = encoderParameter;
                        if (Path.GetExtension(saveFileDialog.FileName) == ".jpg")
                        {
                            bitmap.Save(saveFileDialog.FileName, this.GetCodecInfo("image/jpeg"), encoderParameters);
                        }
                        else if (Path.GetExtension(saveFileDialog.FileName) == ".bmp")
                        {
                            bitmap.Save(saveFileDialog.FileName, this.GetCodecInfo("image/bmp"), encoderParameters);
                        }
                        else if (Path.GetExtension(saveFileDialog.FileName) == ".png")
                        {
                            bitmap.Save(saveFileDialog.FileName, this.GetCodecInfo("image/png"), encoderParameters);
                        }
                        bitmap.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.addpic();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.delpic();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.insertpic();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.tihuanpic();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void quansahnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.delallpic();
        }

        private void picadmin_Load(object sender, EventArgs e)
        {
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.addpic();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.delpic();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            this.tihuanpic();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.delallpic();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            this.insertpic();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            this.uppic();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.downpic();
        }
    }
}
