using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace hmitype
{
    public partial class progform : Form
    {
        private ProgressBarX progressBarX1;
        public progform()
        {
            InitializeComponent();
        }
        public void setprogval(int val)
        {
            try
            {
                if (val > 100)
                {
                    val = 100;
                }
                this.progressBarX1.Value = val;
            }
            catch
            {
            }
        }

        private void progform_Load(object sender, EventArgs e)
        {
            this.progressBarX1.Value = 0;
            this.progressBarX1.Top = 0;
            this.progressBarX1.Left = 0;
            base.Width = this.progressBarX1.Width;
            base.Height = this.progressBarX1.Height;
        }

    }
}
