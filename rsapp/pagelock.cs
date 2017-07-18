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
    public partial class pagelock : DevComponents.DotNetBar.OfficeForm
    {
      

        private Label label1;

        private Label label2;

        private TextBox textBox1;

        private TextBox textBox2;

        private ButtonX buttonX1;

        private ButtonX buttonX2;

        private Label label3;

        private mpage mypage;
        public pagelock()
        {
            InitializeComponent();
        }
        public pagelock(mpage mypage_)
        {
            this.mypage = mypage_;
            this.EnableGlass = false;
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void pagelock_Load(object sender, EventArgs e)
        {
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != this.textBox2.Text)
            {
                MessageOpen.Show("两次输入密码不一致，请重新输入！".Language());
            }
            else
            {
                if (this.textBox1.Text == "")
                {
                    this.mypage.mypage.password = 0u;
                }
                else
                {
                    this.mypage.mypage.password = this.textBox1.Text.GetbytesssASCII().getcrc(0);
                }
                this.mypage.mypage.pagelock = 1;
                base.DialogResult = DialogResult.OK;
            }
        }
    }
}