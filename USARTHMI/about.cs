using DevComponents.DotNetBar;
using hmitype;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using USARTHMI.Properties;
namespace USARTHMI
{
    public partial class about : DevComponents.DotNetBar.OfficeForm
    {
     
        private Label label1;

        private Label label2;

        private PictureBox pictureBox1;

        private LinkLabel linkLabel1;
        public about()
        {
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void about_Load(object sender, EventArgs e)
        {
            this.label1.Text = string.Concat(new string[]
            {
                datasize.softname,
                " V",
                datasize.banbenh.ToString(),
                ".",
                datasize.banbenl.ToString()
            });
            if (datasize.Language == 1)
            {
                this.label2.Text = "ITEAD";
                this.linkLabel1.Text = "http://nextion.itead.cc/";
            }
            else
            {
                this.label2.Text = "深圳市淘晶驰电子有限公司".Language();
                this.linkLabel1.Text = "http://tjc1688.com/";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kuozhan.Openhttp(this.linkLabel1.Text);
        }
    }
}