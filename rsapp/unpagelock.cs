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
    public partial class unpagelock : DevComponents.DotNetBar.OfficeForm
    {
      

        private Label label1;

        private TextBox textBox1;

        private ButtonX buttonX1;

        private ButtonX buttonX2;

        private mpage mypage;
        public unpagelock(mpage mypage_)
        {
            this.mypage = mypage_;
            this.EnableGlass = false;
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (this.mypage.mypage.password != this.textBox1.Text.GetbytesssASCII().getcrc(0))
            {
                MessageOpen.Show("√‹¬Î¥ÌŒÛ£¨«Î÷ÿ–¬ ‰»Î£°".Language());
                this.textBox1.Focus();
                this.textBox1.SelectAll();
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

    }
}