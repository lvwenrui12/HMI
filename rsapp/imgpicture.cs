using hmitype;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace rsapp
{
    public class imgpicture : PictureBox
    {
        public Myapp_inf Myapp;

        public int xuhao;

        private PictureBox imagepp = new PictureBox();

        private Label labeltext = new Label();

        public event EventHandler img_MouseDown;


        public event EventHandler img_DoubleClick;


        public event KeyEventHandler img_Keydown;
       

        public imgpicture(Myapp_inf app, int index)
        {
            this.Myapp = app;
            this.xuhao = index;
            base.Controls.Clear();
            base.Controls.Add(this.imagepp);
            base.Controls.Add(this.labeltext);
            this.labeltext.AutoSize = true;
            this.imagepp.MouseDown += new MouseEventHandler(this.img_MouseDown_);
            base.MouseDown += new MouseEventHandler(this.img_MouseDown_);
            this.labeltext.MouseDown += new MouseEventHandler(this.img_MouseDown_);
            this.imagepp.DoubleClick += new EventHandler(this.img_DoubleClick_);
            base.DoubleClick += new EventHandler(this.img_DoubleClick_);
            this.labeltext.DoubleClick += new EventHandler(this.img_DoubleClick_);
            this.imagepp.KeyDown += new KeyEventHandler(this.img_Keydown_);
            base.KeyDown += new KeyEventHandler(this.img_Keydown_);
            this.labeltext.KeyDown += new KeyEventHandler(this.img_Keydown_);
        }

        private void img_MouseDown_(object sender, EventArgs e)
        {
            try
            {
                this.img_MouseDown(this, e);
            }
            catch
            {
            }
        }

        private void img_DoubleClick_(object sender, EventArgs e)
        {
            try
            {
                this.img_DoubleClick(this, e);
            }
            catch
            {
            }
        }

        private void img_Keydown_(object sender, KeyEventArgs e)
        {
            try
            {
                this.img_Keydown(sender, e);
            }
            catch
            {
            }
        }

        public void ViewPic(Color bcolor, Color pforcolor)
        {
            if (base.Width >= 1)
            {
                try
                {
                    int num;
                    if ((int)this.Myapp.images[this.xuhao].picturexinxi.W <= base.Width)
                    {
                        num = (int)this.Myapp.images[this.xuhao].picturexinxi.W;
                    }
                    else
                    {
                        num = base.Width;
                    }
                    int num2 = (int)this.Myapp.images[this.xuhao].picturexinxi.H * num / (int)this.Myapp.images[this.xuhao].picturexinxi.W;
                    base.Height = num2 + 40;
                    this.BackColor = bcolor;
                    this.imagepp.Size = new Size(num, num2);
                    this.imagepp.BackgroundImageLayout = ImageLayout.Zoom;
                    this.imagepp.BackgroundImage = this.Myapp.images[this.xuhao].imagebitbmp;
                    this.imagepp.Location = new Point(0, 20);
                    this.imagepp.Visible = true;
                    this.labeltext.Font = new Font(SystemFonts.DefaultFont.Name, 12f);
                    this.labeltext.ForeColor = pforcolor;
                    this.labeltext.BackColor = bcolor;
                    Control arg_1FA_0 = this.labeltext;
                    string[] array = new string[5];
                    array[0] = this.xuhao.ToString();
                    array[1] = "--SIZE:";
                    string[] arg_1BC_0 = array;
                    int arg_1BC_1 = 2;
                    ushort num3 = this.Myapp.images[this.xuhao].picturexinxi.W;
                    arg_1BC_0[arg_1BC_1] = num3.ToString();
                    array[3] = "X";
                    string[] arg_1F2_0 = array;
                    int arg_1F2_1 = 4;
                    num3 = this.Myapp.images[this.xuhao].picturexinxi.H;
                    arg_1F2_0[arg_1F2_1] = num3.ToString();
                    arg_1FA_0.Text = string.Concat(array);
                    this.labeltext.Visible = true;
                    this.labeltext.Location = new Point(10, base.Height - 20);
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                }
            }
        }

        public void Close()
        {
            if (this.imagepp != null)
            {
                this.imagepp.BackgroundImage = null;
                this.imagepp.Dispose();
            }
            if (this.labeltext != null)
            {
                this.labeltext.Dispose();
            }
            base.Controls.Clear();
        }

        private void imgpicture_Load(object sender, EventArgs e)
        {
        }
    }
}
