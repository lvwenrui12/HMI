using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hmitype
{
    public partial class datazhuan : Form
    {
      //  private IContainer components = null;

        private Label label3;
     

        private Timer timer2;

        private Timer timer1;

        private int tw;

        private int th;

        public Myapp_inf Myapp;


        public datazhuan(Myapp_inf app)
        {
            this.Myapp = app;
            this.InitializeComponent();
            this.Language();
        }


        private void datazhuan_Load(object sender, EventArgs e)
        {
            this.tw = base.Width;
            this.th = base.Height;
            base.Width = 1;
            base.Height = 1;
        }

        private void qumozhuan()
        {
            guiimagetype value = default(guiimagetype);
            zimoxinxi zimoxinxi = default(zimoxinxi);
            byte b = Convert.ToByte(this.Myapp.guidire + 10);
            for (int i = 0; i < this.Myapp.images.Count; i++)
            {
                this.label3.Visible = true;
                if (this.Myapp.images[i].picturexinxi.qumo != b)
                {
                    this.label3.Text = "正在转换资源文件:".Language() + i.ToString() + "/" + this.Myapp.images.Count.ToString();
                    Application.DoEvents();
                    int num = (int)this.Myapp.images[i].picturexinxi.qumo;
                    value = this.Myapp.images[i];
                    if (num == 1)
                    {
                        Kuozhan.zhuanimg(this.Myapp.images[i].imagebytes, ref value.imagebytes, (int)this.Myapp.images[i].picturexinxi.W, (int)this.Myapp.images[i].picturexinxi.H);
                        num = 10;
                    }
                    else if (num == 0)
                    {
                        num = 10;
                    }
                    if (num != (int)b)
                    {
                        Kuozhan.getxuanzhuanimage(this.Myapp.images[i].imagebytes, ref value.imagebytes, (int)this.Myapp.images[i].picturexinxi.W, (int)this.Myapp.images[i].picturexinxi.H, num - 10, (int)(b - 10));
                    }
                    value.picturexinxi.qumo = b;
                    this.Myapp.images[i] = value;
                }
            }
            for (int i = 0; i < this.Myapp.zimos.Count; i++)
            {
                zimoxinxi = this.Myapp.zimos[i];
                if ((int)zimoxinxi.encode < datasize.encodes_App.Length)
                {
                    if (zimoxinxi.ver == 0 || zimoxinxi.ver == 1)
                    {
                        if (zimoxinxi.encode == 0)
                        {
                            if (zimoxinxi.state == 0 && datasize.Language == 1)
                            {
                                zimoxinxi.encode = (byte)((zimoxinxi.qyt < 100u) ? 1 : 3);
                            }
                            else
                            {
                                zimoxinxi.encode = 2;
                            }
                        }
                        zimoxinxi.codelT0 = 255;
                        zimoxinxi.codelV0 = 0;
                        zimoxinxi.codeh_star = datasize.encodes_App[(int)zimoxinxi.encode].codeh_star;
                        zimoxinxi.codeh_end = datasize.encodes_App[(int)zimoxinxi.encode].codeh_end;
                        zimoxinxi.codel_star = datasize.encodes_App[(int)zimoxinxi.encode].codel_star;
                        zimoxinxi.codel_end = datasize.encodes_App[(int)zimoxinxi.encode].codel_end;
                    }
                }
                if (zimoxinxi.ver != 0)
                {
                    zimoxinxi.ver = datasize.zikuver;
                }
                this.label3.Visible = true;
                if (this.Myapp.zimos[i].qumo != b)
                {
                    this.label3.Text = "正在转换字库文件:".Language() + i.ToString() + "/" + this.Myapp.zimos.Count.ToString();
                    Application.DoEvents();
                    int num = (int)this.Myapp.zimos[i].qumo;
                    if (zimoxinxi.ver == 0)
                    {
                        if (zimoxinxi.state == 2)
                        {
                            byte[] array = new byte[this.Myapp.zimodatas[i].Length];
                            int j;
                            for (j = 0; j <= (int)zimoxinxi.datastar; j++)
                            {
                                array[j] = this.Myapp.zimodatas[i][j];
                            }
                            int num2 = (int)(zimoxinxi.datastar + 1);
                            int num3 = num2;
                            int num4 = (int)(zimoxinxi.w * zimoxinxi.h / 8 + 2);
                            j = 0;
                            while ((long)j < (long)((ulong)zimoxinxi.qyt))
                            {
                                array[num2] = this.Myapp.zimodatas[i][num3];
                                array[num2 + 1] = this.Myapp.zimodatas[i][num3 + 1];
                                num2 += 2;
                                num3 += num4;
                                j++;
                            }
                            num3 = (int)(zimoxinxi.datastar + 1);
                            j = 0;
                            while ((long)j < (long)((ulong)zimoxinxi.qyt))
                            {
                                num3 += 2;
                                for (int k = 0; k < num4 - 2; k++)
                                {
                                    array[num2] = this.Myapp.zimodatas[i][num3];
                                    num2++;
                                    num3++;
                                }
                                j++;
                            }
                            this.Myapp.zimodatas[i] = array;
                            zimoxinxi.ascstar = (byte)(this.Myapp.zimos[i].datastar + 1);
                            zimoxinxi.datastar = (ushort)((uint)zimoxinxi.ascstar + zimoxinxi.qyt * 2u);
                        }
                        else
                        {
                            zimoxinxi.ascstar = (byte)(this.Myapp.zimos[i].datastar + 1);
                            zimoxinxi.datastar = (ushort)zimoxinxi.ascstar;
                        }
                        this.Myapp.zimodatas[i] = Kuozhan.getxuanzhuanziku(zimoxinxi, this.Myapp.zimodatas[i], 4, 0);
                        num = 10;
                        zimoxinxi.ver = datasize.zikuver;
                    }
                    if (num != (int)b)
                    {
                        this.Myapp.zimodatas[i] = Kuozhan.getxuanzhuanziku(zimoxinxi, this.Myapp.zimodatas[i], num - 10, (int)(b - 10));
                    }
                    zimoxinxi.qumo = b;
                    this.Myapp.zimos[i] = zimoxinxi;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.timer2.Enabled)
            {
                this.timer2.Enabled = false;
                base.Width = this.tw;
                base.Height = this.th;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.qumozhuan();
            this.timer2.Enabled = false;
            this.timer2.Dispose();
            base.Close();
        }
    }
}
