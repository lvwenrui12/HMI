using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using hmitype;

namespace USARTHMI
{
    public partial class sysset : DevComponents.DotNetBar.OfficeForm
    {
        #region ¿Ø¼þ

        private MetroTileItem metroTileItem0;

        private MetroTileItem metroTileItem1;

        private MetroTileItem metroTileItem2;

        private ButtonX buttonX1;

        private ButtonX buttonX2;

        private SuperTabControl superTabControl2;

        private MetroTileItem itemshow1;

        private MetroTileItem itemshow2;

        private MetroTileItem itemshow3;

        private MetroTileItem metroTileItem6;

        private MetroTileItem metroTileItem8;

        private MetroTileItem itemshow0;

        private MetroTileItem tem0;

        private SuperTabControlPanel superTabControlPanel1;

        private SuperTabItem superTabItem1;

        private CheckBox checkBox1;

        private GroupBox groupBox1;

        private CheckBox checkBox4;

        private CheckBox checkBox3;

        private CheckBox checkBox2;

        private GroupBox groupBox2;

        private CheckBox checkBox14;

        private CheckBox checkBox13;

        private CheckBox checkBox12;

        private CheckBox checkBox11;

        private Timer timer1;

        private CheckBox checkBox15;

        private CheckBox checkBox5;


        #endregion
        public sysset()
        {
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = (datasize.codemessage[0].allen == 1);
            this.checkBox2.Checked = (datasize.codemessage[0].keyword == 1);
            this.checkBox3.Checked = (datasize.codemessage[0].comshow == 1);
            this.checkBox4.Checked = (datasize.codemessage[0].mouseshow == 1);
            this.checkBox5.Checked = (datasize.codemessage[0].codehig == 1);
            this.checkBox11.Checked = (datasize.codemessage[1].allen == 1);
            this.checkBox12.Checked = (datasize.codemessage[1].keyword == 1);
            this.checkBox13.Checked = (datasize.codemessage[1].comshow == 1);
            this.checkBox14.Checked = (datasize.codemessage[1].mouseshow == 1);
            this.checkBox15.Checked = (datasize.codemessage[1].codehig == 1);
            this.refmessagecheck();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            datasize.codemessage[0].allen = Convert.ToByte((this.checkBox1.Checked ? 1 : 0));
            datasize.codemessage[0].keyword = Convert.ToByte(this.checkBox2.Checked ? 1 : 0);
            datasize.codemessage[0].comshow = Convert.ToByte(this.checkBox3.Checked ? 1 : 0);
            datasize.codemessage[0].mouseshow = Convert.ToByte(this.checkBox4.Checked ? 1 : 0);
            datasize.codemessage[0].codehig = Convert.ToByte(this.checkBox5.Checked ? 1 : 0);
            this.savecodemessage("codemessage0", datasize.codemessage[0]);
            datasize.codemessage[1].allen = Convert.ToByte(this.checkBox11.Checked ? 1 : 0);
            datasize.codemessage[1].keyword = Convert.ToByte(this.checkBox12.Checked ? 1 : 0);
            datasize.codemessage[1].comshow = Convert.ToByte(this.checkBox13.Checked ? 1 : 0);
            datasize.codemessage[1].mouseshow = Convert.ToByte(this.checkBox14.Checked ? 1 : 0);
            datasize.codemessage[1].codehig = Convert.ToByte(this.checkBox15.Checked ? 1 : 0);
            this.savecodemessage("codemessage1", datasize.codemessage[1]);
            base.Close();
        }

        private void savecodemessage(string key, codemessagetype m1)
        {
            string path = string.Concat(new string[]
            {
                m1.allen.ToString(),
                "-",
                m1.keyword.ToString(),
                "-",
                m1.comshow.ToString(),
                "-",
                m1.mouseshow.ToString()
            });
            Kuozhan.putxmlstring(path, key);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.refmessagecheck();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            this.refmessagecheck();
        }

        private void refmessagecheck()
        {
            this.checkBox2.Enabled = this.checkBox1.Checked;
            this.checkBox3.Enabled = this.checkBox1.Checked;
            this.checkBox4.Enabled = this.checkBox1.Checked;
            this.checkBox12.Enabled = this.checkBox11.Checked;
            this.checkBox13.Enabled = this.checkBox11.Checked;
            this.checkBox14.Enabled = this.checkBox11.Checked;
        }
    }
}