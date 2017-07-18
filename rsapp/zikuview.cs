using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using hmitype;

namespace rsapp
{
    public partial class zikuview : DevComponents.DotNetBar.OfficeForm
    {
        private Bitmap bm;

        private Myapp_inf Myapp;

        private int zimoindex;

        private int zpages = 0;

        private int pageqyt = 0;

        private int dpage = 0;

        private int ziw;

        private int zih;

        private int hangjuw;

        private int hangjuh;

        private Formchuantiinf fc = default(Formchuantiinf);

    

        private PictureBox pictureBox1;

        private Button button1;

        private Timer timer1;

        private LinkLabel linkLabel1;

        private LinkLabel linkLabel2;

        private Label label1;

        private TextBox textBox1;

        private ButtonX button2;
        public zikuview()
        {
            InitializeComponent();
        }

        public zikuview(Myapp_inf app, int zimoindex_, Formchuantiinf f)
        {
            this.fc = f;
            this.zimoindex = zimoindex_;
            this.Myapp = app;
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void zikuview_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Ref();
        }

        private void showzi()
        {
            this.ziw = (int)this.Myapp.zimos[this.zimoindex].w;
            this.zih = (int)this.Myapp.zimos[this.zimoindex].h;
            this.hangjuw = 0;
            this.hangjuh = 0;
            if (this.Myapp.zimos[this.zimoindex].state == 2)
            {
                this.textBox1.Visible = true;
                this.button2.Visible = true;
                byte b = "?".GetbytesssASCII()[0];
                byte[] array = new byte[this.Myapp.zimos[this.zimoindex].qyt * 2u];
                byte[] array2 = this.Myapp.zimodatas[this.zimoindex];
                int num = this.ziw * this.zih / 8;
                num += 2;
                int num2 = 0;
                while ((long)num2 < (long)((ulong)this.Myapp.zimos[this.zimoindex].qyt))
                {
                    array[num2 * 2] = array2[num2 * 2 + (int)this.Myapp.zimos[this.zimoindex].ascstar];
                    array[num2 * 2 + 1] = array2[num2 * 2 + (int)this.Myapp.zimos[this.zimoindex].ascstar + 1];
                    if (array[num2 * 2] == 0)
                    {
                        array[num2 * 2] = b;
                    }
                    num2++;
                }
                this.textBox1.Text = Encoding.GetEncoding(datasize.encodes_App[(int)this.Myapp.zimos[this.zimoindex].encode].encodename).GetString(array);
                this.textBox1.Text = this.textBox1.Text.Replace("?", "");
            }
            else
            {
                this.textBox1.Visible = false;
                this.button2.Visible = false;
            }
        }

        private void Ref()
        {
            this.ziw = (int)this.Myapp.zimos[this.zimoindex].w;
            this.zih = (int)this.Myapp.zimos[this.zimoindex].h;
            this.hangjuw = 0;
            this.hangjuh = 0;
            this.pageqyt = this.pictureBox1.Width / (this.ziw + this.hangjuw) * (this.pictureBox1.Height / (this.zih + this.hangjuh));
            this.zpages = (int)((ulong)this.Myapp.zimos[this.zimoindex].qyt / (ulong)((long)this.pageqyt)) + 1;
            int num = this.dpage * this.pageqyt;
            int i = 0;
            int j = 0;
            this.bm = new Bitmap(this.pictureBox1.Width + 1, this.pictureBox1.Height + 1);
            Graphics.FromImage(this.bm).Clear(Color.White);
            while (j < this.pictureBox1.Height - this.zih)
            {
                while (i < this.pictureBox1.Width - this.ziw)
                {
                    if (!this.Xianshi(num, i, j, this.Myapp.zimos[this.zimoindex].qumo))
                    {
                        return;
                    }
                    i += this.ziw + this.hangjuw;
                    num++;
                    if ((long)num == (long)((ulong)this.Myapp.zimos[this.zimoindex].qyt))
                    {
                        break;
                    }
                }
                if ((long)num == (long)((ulong)this.Myapp.zimos[this.zimoindex].qyt))
                {
                    break;
                }
                i = 0;
                j += this.zih + this.hangjuh;
            }
            this.pictureBox1.Image = this.bm;
            this.label1.Text = "Page:" + (this.dpage + 1).ToString() + "/" + this.zpages.ToString();
        }

        private bool Xianshi(int index, int dxianshix, int dxianshiy, byte qumo)
        {
            int num = this.ziw * this.zih / 8;
            int i = num;
            int num2 = this.ziw;
            int num3 = this.zih;
            int num4 = index * num + (int)this.Myapp.zimos[this.zimoindex].datastar;
            bool result;
            try
            {
                if ((long)num4 >= (long)((ulong)this.Myapp.zimos[this.zimoindex].size))
                {
                    MessageOpen.Show("this xuhao is error!");
                    result = false;
                    return result;
                }
                if (this.Myapp.zimos[this.zimoindex].state == 2)
                {
                    if (this.Myapp.zimodatas[this.zimoindex][(int)this.Myapp.zimos[this.zimoindex].ascstar + index * 2] == 0)
                    {
                        num2 = this.ziw / 2;
                    }
                }
                else if (this.Myapp.zimos[this.zimoindex].state == 1)
                {
                    if ((long)index > (long)((ulong)(this.Myapp.zimos[this.zimoindex].qyt - 96u)))
                    {
                        num2 = this.ziw / 2;
                    }
                }
                if (qumo == 10)
                {
                    int num5 = 0;
                    int num6 = 0;
                    while (i > 0)
                    {
                        byte b = this.Myapp.zimodatas[this.zimoindex][num4];
                        num4++;
                        for (int j = 0; j < 8; j++)
                        {
                            if (((int)b & 1 << 7 - j) > 0)
                            {
                                this.bm.SetPixel(dxianshix + num5, dxianshiy + num6, Color.Black);
                            }
                            num5++;
                            if (num5 >= num2)
                            {
                                num5 = 0;
                                num6++;
                            }
                        }
                        i--;
                    }
                }
                if (qumo == 11)
                {
                    int num5 = 0;
                    int num6 = num3 - 1;
                    while (i > 0)
                    {
                        byte b = this.Myapp.zimodatas[this.zimoindex][num4];
                        num4++;
                        for (int j = 0; j < 8; j++)
                        {
                            if (((int)b & 1 << 7 - j) > 0)
                            {
                                this.bm.SetPixel(dxianshix + num5, dxianshiy + num6, Color.Black);
                            }
                            num6--;
                            if (num6 < 0)
                            {
                                num6 = num3 - 1;
                                num5++;
                            }
                        }
                        i--;
                    }
                }
                if (qumo == 12)
                {
                    int num5 = num2 - 1;
                    int num6 = num3 - 1;
                    while (i > 0)
                    {
                        byte b = this.Myapp.zimodatas[this.zimoindex][num4];
                        num4++;
                        for (int j = 0; j < 8; j++)
                        {
                            if (((int)b & 1 << 7 - j) > 0)
                            {
                                this.bm.SetPixel(dxianshix + num5, dxianshiy + num6, Color.Black);
                            }
                            num5--;
                            if (num5 < 0)
                            {
                                num5 = num2 - 1;
                                num6--;
                            }
                        }
                        i--;
                    }
                }
                if (qumo == 13)
                {
                    int num5 = num2 - 1;
                    int num6 = 0;
                    while (i > 0)
                    {
                        byte b = this.Myapp.zimodatas[this.zimoindex][num4];
                        num4++;
                        for (int j = 0; j < 8; j++)
                        {
                            if (((int)b & 1 << 7 - j) > 0)
                            {
                                this.bm.SetPixel(dxianshix + num5, dxianshiy + num6, Color.Black);
                            }
                            num6++;
                            if (num6 >= num3)
                            {
                                num6 = 0;
                                num5--;
                            }
                        }
                        i--;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = false;
                return result;
            }
            result = true;
            return result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.showzi();
            this.Ref();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.dpage < this.zpages - 1)
            {
                this.dpage++;
            }
            this.Ref();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.dpage > 0)
            {
                this.dpage--;
            }
            this.Ref();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.fc.str[0] = this.textBox1.Text;
            this.fc.str[1] = this.zih.ToString();
            this.fc.str[2] = Encoding.Default.GetString(this.Myapp.zimodatas[this.zimoindex], 0, (int)this.Myapp.zimos[this.zimoindex].ascstar);
            Form form = new zikucreat(this.fc, (int)this.Myapp.zimos[this.zimoindex].encode, this.Myapp);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                if (MessageOpen.Show("是否立即替换刚才生成的字库?".Language(), "提示".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = this.fc.str[0];
                    int num = Marshal.SizeOf(default(zimoxinxi));
                    StreamReader streamReader = new StreamReader(path);
                    byte[] array = new byte[num];
                    streamReader.BaseStream.Read(array, 0, num);
                    zimoxinxi value = (zimoxinxi)array.BytesTostruct(default(zimoxinxi).GetType());
                    this.Myapp.zimos[this.zimoindex] = value;
                    array = new byte[value.size];
                    streamReader.BaseStream.Read(array, 0, array.Length);
                    this.Myapp.zimodatas[this.zimoindex] = new byte[array.Length];
                    array.CopyTo(this.Myapp.zimodatas[this.zimoindex], 0);
                    streamReader.Close();
                    streamReader.Dispose();
                    this.showzi();
                    this.fc.str[1] = "edit";
                    new datazhuan(this.Myapp).ShowDialog();
                    this.Ref();
                }
            }
            else
            {
                this.fc.str[1] = "";
            }
        }
    }
}