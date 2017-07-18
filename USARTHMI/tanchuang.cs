using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using hmitype;

namespace USARTHMI
{
    public partial class tanchuang : DevComponents.DotNetBar.OfficeForm
    {
        #region 控件
        private string thisadd;

        private int chongshi = 0;

   

        private WebBrowser webBrowser1;

        private CheckBox checkBox1;

        private Timer timer1;


        #endregion
        public tanchuang()
        {
            InitializeComponent();
        }
        public tanchuang(string add)
        {
            this.thisadd = add;
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
            this.Text = datasize.softname;
        }

        private void tanchuang_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 4000;
            this.timer1.Enabled = true;
            this.chongshi = 0;
            this.webBrowser1.Navigate(this.thisadd);
            if (Kuozhan.getxmlstring("st0") == datasize.tanchuangid.ToString())
            {
                this.checkBox1.Checked = true;
            }
            else
            {
                this.checkBox1.Checked = false;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.chongshi == 3)
            {
                this.timer1.Enabled = false;
                MessageOpen.Show("弹窗提示加载失败".Language());
                base.Close();
            }
            else
            {
                if (this.chongshi > 0)
                {
                    this.timer1.Interval = 2000;
                }
                this.chongshi++;
                this.webBrowser1.Navigate("about:blank");
                this.webBrowser1.Navigate(this.thisadd);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                Kuozhan.putxmlstring(datasize.tanchuangid.ToString(), "st0");
            }
            else
            {
                Kuozhan.putxmlstring("a", "st0");
            }
        }

      
    }
}