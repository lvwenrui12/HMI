using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hmitype;

namespace rsapp
{
    public partial class picview : Form
    {
        public Myapp_inf Myapp;

        public int picindex = 0;


        private Panel panel1;

        private PictureBox pictureBox1;

        private Label label1;

        public picview()
        {
            InitializeComponent();
        }
        public picview(Myapp_inf app, int indexpic)
        {
            this.Myapp = app;
            this.picindex = indexpic;
            this.InitializeComponent();
            base.Icon = datasize.Myico;
        }

        private void picview_Load(object sender, EventArgs e)
        {
            try
            {
                this.pictureBox1.Width = (int)this.Myapp.images[this.picindex].picturexinxi.W;
                this.pictureBox1.Height = (int)this.Myapp.images[this.picindex].picturexinxi.H;
                int num = (this.panel1.Width - this.pictureBox1.Width) / 2;
                int num2 = (this.panel1.Height - this.pictureBox1.Height) / 2;
                if (num < 0)
                {
                    num = 0;
                }
                if (num2 < 30)
                {
                    num2 = 30;
                }
                this.label1.Left = num;
                this.label1.Top = num2 - this.label1.Height - 3;
                this.label1.Text = "Size:" + this.pictureBox1.Width.ToString() + "*" + this.pictureBox1.Height.ToString();
                this.pictureBox1.Top = num2;
                this.pictureBox1.Left = num;
                this.pictureBox1.BackgroundImageLayout = ImageLayout.None;
                this.pictureBox1.BackgroundImage = this.Myapp.images[this.picindex].imagebitbmp;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void picview_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (this.pictureBox1.BackgroundImage != null)
                {
                    this.pictureBox1.BackgroundImage = null;
                }
            }
            catch
            {
            }
        }
    }
}
