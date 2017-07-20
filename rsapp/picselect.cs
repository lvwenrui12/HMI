using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using hmitype;
using rsapp;

namespace rsapp
{
    public partial class picselect : DevComponents.DotNetBar.OfficeForm
    {
        #region 控件

        public Myapp_inf Myapp;

        private Formchuantiinf fc;

        private int picindex = -1;

   

        private picadmin picadmin1;

        private Label label1;

        private RadioButton radioButton1;

        private RadioButton radioButton2;

        private Panel panel1;

        private ButtonX button1;

        #endregion


        public picselect()
        {
            InitializeComponent();
        }

        public picselect(Myapp_inf app, Formchuantiinf fc_)
        {
            this.fc = fc_;
            this.Myapp = app;
            this.EnableGlass = false;
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void picadmin1_picselect(object sender, EventArgs e)
        {
            this.picindex = (int)sender;
        }

        private void picselect_Load(object sender, EventArgs e)
        {
            this.picadmin1.Setapp(this.Myapp);
            this.picadmin1.setfase();
            this.picadmin1.Ref();
            if (this.fc.str[1] == "0")
            {
                this.radioButton1.Checked = true;
            }
            if (this.fc.str[1] == "1")
            {
                this.radioButton2.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.picindex == -1)
            {
                MessageOpen.Show("没有选择图片".Language());
            }
            else
            {
                this.fc.str[0] = this.picindex.ToString();
                this.fc.str[1] = (this.radioButton1.Checked ? "0" : "1");
                base.DialogResult = DialogResult.OK;
            }
        }

    }
}