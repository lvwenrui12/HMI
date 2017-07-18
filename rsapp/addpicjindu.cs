using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using hmitype;

namespace rsapp
{
    public partial class addpicjindu : DevComponents.DotNetBar.OfficeForm
    {
        private Myapp_inf Myapp;

        private int index_ = 0;

        private string lei_ = "";

    

        private Label label1;

        private Timer timer1;

        public addpicjindu(Myapp_inf app, string lei, int index)
        {
            this.Myapp = app;
            this.index_ = index;
            this.lei_ = lei;
            this.InitializeComponent();
            base.Icon = datasize.Myico;
            this.Language();
        }

        private bool openpic(ref Bitmap bm, string file)
        {
            bool result;
            try
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox.Load(file);
                bm = (Bitmap)pictureBox.Image;
                pictureBox.Dispose();
            }
            catch
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }

        private bool addpic(string lei, int index)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            int num = 1;
            int num2 = 0;
            int num3 = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = !(lei == "tihuan");
            openFileDialog.Filter = "所有文件|*.*".Language();
            openFileDialog.Getpath("pic");
            bool result;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                result = false;
            }
            else
            {
                openFileDialog.Putpath("pic");
                guiimagetype guiimagetype = default(guiimagetype);
                string[] fileNames = openFileDialog.FileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    string file = fileNames[i];
                    this.label1.Text = "正在转换图片".Language() + num.ToString();
                    num++;
                    Application.DoEvents();
                    bitmap = new Bitmap(1, 1);
                    if (this.openpic(ref bitmap, file))
                    {
                        num3++;
                        guiimagetype.imagebytes = new byte[bitmap.Width * bitmap.Height * 2];
                        int num4 = 0;
                        for (int j = 0; j < bitmap.Height; j++)
                        {
                            for (int k = 0; k < bitmap.Width; k++)
                            {
                                if (bitmap.GetPixel(k, j).A == 0)
                                {
                                    guiimagetype.imagebytes[num4] = (byte)(datasize.Color_touming % 256);
                                    guiimagetype.imagebytes[num4 + 1] = 0;
                                }
                                else
                                {
                                    ushort num5 = bitmap.GetPixel(k, j).Get16Color();
                                    guiimagetype.imagebytes[num4] = (byte)(num5 % 256);
                                    guiimagetype.imagebytes[num4 + 1] = (byte)(num5 / 256);
                                    if ((ushort)guiimagetype.imagebytes[num4] == datasize.Color_touming && guiimagetype.imagebytes[num4 + 1] == 0)
                                    {
                                        guiimagetype.imagebytes[num4] = (byte)datasize.Color_toumingtihuan;
                                    }
                                }
                                num4 += 2;
                            }
                        }
                        guiimagetype.picturexinxi.qumo = Convert.ToByte(this.Myapp.guidire + 10);
                        if (guiimagetype.picturexinxi.qumo != 10)
                        {
                            Kuozhan.getxuanzhuanimage(guiimagetype.imagebytes, ref guiimagetype.imagebytes, bitmap.Width, bitmap.Height, 0, (int)this.Myapp.guidire);
                        }
                        guiimagetype.picturexinxi.H = (ushort)bitmap.Height;
                        guiimagetype.picturexinxi.imgbytesize = (uint)guiimagetype.imagebytes.Length;
                        guiimagetype.picturexinxi.W = (ushort)bitmap.Width;
                        guiimagetype.imagebitbmp = guiimagetype.imagebytes.GetBitmap(guiimagetype.picturexinxi, datasize.Opentouming);
                        guiimagetype.imgxulie = guiimagetype.imagebitbmp.ClassToBytes();
                        if (lei == "add")
                        {
                            this.Myapp.images.Add(guiimagetype);
                        }
                        else if (lei == "insert")
                        {
                            if (index >= this.Myapp.images.Count)
                            {
                                result = false;
                                return result;
                            }
                            this.Myapp.images.Insert(index, guiimagetype);
                        }
                        else if (lei == "tihuan")
                        {
                            this.Myapp.images[index] = guiimagetype;
                        }
                    }
                    else
                    {
                        num2++;
                    }
                    if (bitmap != null)
                    {
                        bitmap.Dispose();
                    }
                }
                if (num3 > 0 && lei == "insert")
                {
                    byte[] array = ((ushort)index).structToBytes();
                    foreach (mpage current in this.Myapp.pages)
                    {
                        foreach (mobj current2 in current.objs)
                        {
                            foreach (matt current3 in current2.atts)
                            {
                                if (current3.att.attlei == attshulei.Picid.typevalue)
                                {
                                    ushort num6 = (ushort)current3.zhi.BytesTostruct(0.GetType());
                                    if (num6 != 65535 && (int)num6 >= index)
                                    {
                                        current3.zhi = ((ushort)((int)num6 + num3)).structToBytes();
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
                                            ushort num6 = (ushort)current3.zhi.BytesTostruct(0.GetType());
                                            if (num6 != 65535 && (int)num6 >= index)
                                            {
                                                current3.zhi = ((ushort)((int)num6 + num3)).structToBytes();
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
                                ushort num6 = (ushort)current3.zhi.BytesTostruct(0.GetType());
                                if (num6 != 65535 && (int)num6 >= index)
                                {
                                    current3.zhi = ((ushort)((int)num6 + num3)).structToBytes();
                                }
                            }
                        }
                    }
                }
                if (num2 == 0)
                {
                    MessageOpen.Show(string.Concat(new string[]
                    {
                        "成功导入".Language(),
                        " ",
                        num3.ToString(),
                        " ",
                        "张".Language()
                    }));
                }
                else
                {
                    MessageOpen.Show(string.Concat(new string[]
                    {
                        "成功导入".Language(),
                        " ",
                        num3.ToString(),
                        " ",
                        "张,失败".Language(),
                        " ",
                        num2.ToString(),
                        " ",
                        "张".Language()
                    }));
                }
                result = true;
            }
            return result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (this.addpic(this.lei_, this.index_))
            {
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void addpicjindu_Load(object sender, EventArgs e)
        {
        }
    }
}