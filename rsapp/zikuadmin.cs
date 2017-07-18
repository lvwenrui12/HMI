using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using hmitype;

namespace rsapp
{
    public partial class zikuadmin : UserControl
    {
        #region 控件
        private Myapp_inf Myapp;
        
        private ListBox listBox1;

        private ImageList imageList1;

        private Bar bar1;

        private ButtonItem buttonItem1;

        private ButtonItem buttonItem2;

        private ButtonItem buttonItem7;

        private ButtonItem buttonItem3;

        private ButtonItem buttonItem4;

        private ButtonItem buttonItem5;

        private ButtonItem buttonItem6;

        private LabelItem label1;

        private ButtonItem buttonItem8;


        #endregion
        public zikuadmin()
        {
            InitializeComponent();
        }


        public event EventHandler zikuupdate;
       
        public void Setapp(Myapp_inf app)
        {
            this.Myapp = app;
            if (app == null)
            {
                this.listBox1.Items.Clear();
                this.bar1.Enabled = false;
                this.label1.Text = "0";
            }
            else
            {
                this.bar1.Enabled = true;
            }
        }

     
        public void Ref()
        {
            this.listBox1.Items.Clear();
            for (int i = 0; i < this.Myapp.zimos.Count; i++)
            {
                ListBox.ObjectCollection arg_15A_0 = this.listBox1.Items;
                string[] array = new string[14];
                array[0] = i.ToString();
                array[1] = "-";
                array[2] = datasize.Myencoding.GetString(this.Myapp.zimodatas[i], 0, (int)this.Myapp.zimos[i].ascstar);
                array[3] = "(size:";
                string[] arg_9C_0 = array;
                int arg_9C_1 = 4;
                byte b = this.Myapp.zimos[i].w;
                arg_9C_0[arg_9C_1] = b.ToString();
                array[5] = "X";
                string[] arg_C5_0 = array;
                int arg_C5_1 = 6;
                b = this.Myapp.zimos[i].h;
                arg_C5_0[arg_C5_1] = b.ToString();
                array[7] = ",encode:";
                array[8] = this.Myapp.zimos[i].encode.GetencodeName();
                array[9] = ",qyt:";
                string[] arg_116_0 = array;
                int arg_116_1 = 10;
                uint qyt = this.Myapp.zimos[i].qyt;
                arg_116_0[arg_116_1] = qyt.ToString();
                array[11] = ",datasize:";
                array[12] = (this.Myapp.zimodatas[i].Length + datasize.zimoxinxisize).ToString("0,000");
                array[13] = ")";
                arg_15A_0.Add(string.Concat(array));
            }
            this.label1.Text = this.Myapp.zimos.Count.ToString();
        }

        private void zikuadmin_Resize(object sender, EventArgs e)
        {
            try
            {
                this.bar1.Left = 1;
                this.bar1.Top = 1;
                this.bar1.Width = base.Width - 2;
                int top = this.bar1.Top + this.bar1.Height;
                this.listBox1.Top = top;
                this.listBox1.Left = 1;
                this.listBox1.Width = base.Width - 2;
                this.listBox1.Height = base.Height - this.listBox1.Top - 1;
            }
            catch
            {
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            this.listBox1.SetSize();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "zi文件|*.zi|所有文件|*.*".Language();
            openFileDialog.Multiselect = true;
            openFileDialog.Getpath("ziku");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.Putpath("ziku");
                this.Myapp.Addziku(openFileDialog.FileNames, "add", 0);
                this.Ref();
                this.zikuupdate(null, null);
            }
        }

        private void upindex()
        {
            if (this.listBox1.Items.Count > 0 && this.listBox1.SelectedIndex > -1)
            {
                if (this.Myapp.zimos.Count > 1 && this.listBox1.SelectedIndex > 0)
                {
                    int num = this.listBox1.SelectedIndex - 1;
                    this.jiaohunziku(this.listBox1.SelectedIndex, num);
                    this.listBox1.SelectedIndex = num;
                }
            }
        }

        private void downindex()
        {
            if (this.listBox1.Items.Count > 0 && this.listBox1.SelectedIndex > -1)
            {
                if (this.Myapp.zimos.Count > 1 && this.listBox1.SelectedIndex < this.Myapp.zimos.Count - 1)
                {
                    int num = this.listBox1.SelectedIndex + 1;
                    this.jiaohunziku(this.listBox1.SelectedIndex, num);
                    this.listBox1.SelectedIndex = num;
                }
            }
        }

        private void jiaohunziku(int index0, int index1)
        {
            zimoxinxi value = this.Myapp.zimos[index0];
            byte[] array = new byte[this.Myapp.zimodatas[index0].Length];
            this.Myapp.zimodatas[index0].CopyTo(array, 0);
            this.Myapp.zimos[index0] = this.Myapp.zimos[index1];
            this.Myapp.zimodatas[index0] = new byte[this.Myapp.zimodatas[index1].Length];
            this.Myapp.zimodatas[index1].CopyTo(this.Myapp.zimodatas[index0], 0);
            this.Myapp.zimos[index1] = value;
            this.Myapp.zimodatas[index1] = new byte[array.Length];
            array.CopyTo(this.Myapp.zimodatas[index1], 0);
            foreach (mpage current in this.Myapp.pages)
            {
                foreach (mobj current2 in current.objs)
                {
                    foreach (matt current3 in current2.atts)
                    {
                        if (current3.att.attlei == attshulei.Font.typevalue)
                        {
                            byte b = (byte)current3.zhi.BytesTostruct(0.GetType());
                            if ((int)b == index0)
                            {
                                current3.zhi = ((byte)index1).structToBytes();
                            }
                            else if ((int)b == index1)
                            {
                                current3.zhi = ((byte)index0).structToBytes();
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
                                if (current3.att.attlei == attshulei.Font.typevalue)
                                {
                                    byte b = (byte)current3.zhi.BytesTostruct(0.GetType());
                                    if ((int)b == index0)
                                    {
                                        current3.zhi = ((byte)index1).structToBytes();
                                    }
                                    else if ((int)b == index1)
                                    {
                                        current3.zhi = ((byte)index0).structToBytes();
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
                    if (current3.att.attlei == attshulei.Font.typevalue)
                    {
                        byte b = (byte)current3.zhi.BytesTostruct(0.GetType());
                        if ((int)b == index0)
                        {
                            current3.zhi = ((byte)index1).structToBytes();
                        }
                        else if ((int)b == index1)
                        {
                            current3.zhi = ((byte)index0).structToBytes();
                        }
                    }
                }
            }
            this.Ref();
            this.zikuupdate(null, null);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.delziku();
        }

        private void delziku()
        {
            int selectedIndex = this.listBox1.SelectedIndex;
            if (this.listBox1.Items.Count > 0 && selectedIndex > -1)
            {
                if (!this.zikucheck(selectedIndex))
                {
                    if (MessageOpen.Show("确认删除吗? ".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Myapp.delzimo(selectedIndex);
                        this.Ref();
                        this.zikuupdate(null, null);
                        if (this.listBox1.Items.Count > selectedIndex)
                        {
                            this.listBox1.SelectedIndex = selectedIndex;
                        }
                        else if (this.listBox1.Items.Count > 0)
                        {
                            this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                        }
                    }
                }
            }
        }

        private bool zikucheck(int index)
        {
            byte[] array = ((byte)index).structToBytes();
            bool result;
            foreach (mpage current in this.Myapp.pages)
            {
                foreach (mobj current2 in current.objs)
                {
                    foreach (matt current3 in current2.atts)
                    {
                        if (current3.att.attlei == attshulei.Font.typevalue)
                        {
                            if (current3.zhi.Length == 1 && current3.zhi[0] == array[0])
                            {
                                if (current2.checkatt(current3))
                                {
                                    MessageOpen.Show(string.Concat(new string[]
                                    {
                                        "字库ID:".Language(),
                                        index.ToString(),
                                        " ",
                                        "已经被以下控件使用,不可删除!".Language(),
                                        "\r\n".Language(),
                                        current.pagename,
                                        ".",
                                        current2.objname
                                    }));
                                    result = true;
                                    return result;
                                }
                                current3.zhi = 0.structToBytes();
                            }
                        }
                    }
                }
            }
            result = false;
            return result;
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count > 0 && this.listBox1.SelectedIndex > -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "zi文件|*.zi|所有文件|*.*".Language();
                openFileDialog.Multiselect = true;
                openFileDialog.Getpath("ziku");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Putpath("ziku");
                    this.Myapp.Addziku(openFileDialog.FileNames, "insert", this.listBox1.SelectedIndex);
                    this.Ref();
                    this.zikuupdate(null, null);
                }
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            if (this.Myapp.zimos.Count > 0)
            {
                if (MessageOpen.Show("确认要删除所有字库吗? ".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Myapp.delAllzimo();
                    this.Ref();
                    this.zikuupdate(null, null);
                }
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            Formchuantiinf f = default(Formchuantiinf);
            f.str = new string[3];
            f.str[1] = "";
            if (this.listBox1.Items.Count > 0)
            {
                if (this.listBox1.SelectedIndex > -1)
                {
                    new zikuview(this.Myapp, this.listBox1.SelectedIndex, f).ShowDialog();
                    if (f.str[1] != "")
                    {
                        this.Ref();
                        this.zikuupdate(null, null);
                    }
                }
            }
        }

        private void zikuadmin_Paint(object sender, PaintEventArgs e)
        {
            this.DrawThisLine(Color.FromArgb(51, 153, 255), 1);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            this.upindex();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.downindex();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count > 0 && this.listBox1.SelectedIndex > -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "zi文件|*.zi|所有文件|*.*".Language();
                openFileDialog.Multiselect = false;
                openFileDialog.Getpath("ziku");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Putpath("ziku");
                    this.Myapp.Addziku(openFileDialog.FileName, "tihuan", this.listBox1.SelectedIndex);
                    this.Ref();
                    this.zikuupdate(null, null);
                }
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.delziku();
            }
        }

        private void zikuadmin_Load(object sender, EventArgs e)
        {
        }

     
    }
}
