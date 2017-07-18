using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using hmitype;

namespace rsapp
{
    public partial class zikucreat : DevComponents.DotNetBar.OfficeForm
    {
        #region 控件
        private showzitype_ hanzipos;

        private showzitype_ zifupos;

        private string zimostr = "";

        private bool auto = false;

        public Formchuantiinf fc;

        private bool creatend = false;

        private Bitmap bm;

        private int Encode = 0;

        private Myapp_inf Myapp = null;

        private IContainer components = null;

        private Label label1;

        private PictureBox pictureBoxzi;

        private Label label3;

        private Label label5;

        private Label label6;

        private Label label7;

        private Label label4;

        private PictureBox pictureBoxm;

        private GroupBox groupBox1;

        private Label label9;

        private Label label8;

        private PictureBox pictureBox1;

        private ComboBoxEx comboBox1;

        private CheckBoxX checkBox1;

        private ComboBoxEx comboBox2;

        private ComboBoxEx comboBox4;

        private ComboBoxEx comboBox5;

        private TextBoxX textBox1;

        private ButtonX button1;

        private TextBoxX textBox2;

        private ComboBoxEx comboBoxEx1;

        private Label label2;

        private LinkLabel linkLabel1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem toolStripMenuItem2;

        private ToolStripMenuItem toolStripMenuItem4;

        private ToolStripMenuItem toolStripMenuItem6;

        private ToolStripMenuItem toolStripMenuItem8;

        private ToolStripMenuItem toolStripMenuItem10;

        private ToolStripMenuItem toolStripMenuItem12;


        #endregion

        public zikucreat()
        {
            InitializeComponent();
        }

        public zikucreat(Formchuantiinf zi, int encode_, Myapp_inf app)
        {
            this.Myapp = app;
            this.fc = zi;
            this.Encode = encode_;
            if (this.Encode == 0 || this.Encode >= datasize.encodes_App.Length)
            {
                this.Encode = (int)((datasize.Language == 0) ? "gb2312".GetencodeId() : "iso-8859-1".GetencodeId());
            }
            if (this.fc.str[0] != "")
            {
                this.auto = true;
            }
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void ziku_Load(object sender, EventArgs e)
        {
            this.label3.Visible = false;
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("16");
            this.comboBox1.Items.Add("24");
            this.comboBox1.Items.Add("32");
            this.comboBox1.Items.Add("40");
            this.comboBox1.Items.Add("48");
            this.comboBox1.Items.Add("56");
            this.comboBox1.Items.Add("64");
            this.comboBox1.Items.Add("72");
            this.comboBox1.Items.Add("80");
            this.comboBox1.Items.Add("96");
            this.comboBox1.Items.Add("112");
            this.comboBox1.Items.Add("128");
            this.comboBox1.Items.Add("144");
            this.comboBox1.Items.Add("160");
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.Items.Clear();
            this.comboBox4.Items.Clear();
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] families = installedFontCollection.Families;
            int num = families.Length;
            for (int i = 0; i < num; i++)
            {
                string name = families[i].Name;
                this.comboBox2.Items.Add(name);
                this.comboBox4.Items.Add(name);
            }
            this.comboBox2.Text = SystemFonts.DefaultFont.Name;
            this.comboBox4.Text = SystemFonts.DefaultFont.Name;
            this.comboBoxEx1.Items.Clear();
            int[] encodes_This = datasize.encodes_This;
            for (int j = 0; j < encodes_This.Length; j++)
            {
                int i = encodes_This[j];
                this.comboBoxEx1.Items.Add(datasize.encodes_App[i].encodename);
            }
            string encodename = datasize.encodes_App[this.Encode].encodename;
            for (int i = 0; i < this.comboBoxEx1.Items.Count; i++)
            {
                if (this.comboBoxEx1.Items[i].ToString() == encodename)
                {
                    this.comboBoxEx1.SelectedIndex = i;
                    break;
                }
            }
            this.refencode();
            if (this.auto)
            {
                if (this.comboBox5.Items.Count >= 2)
                {
                    this.comboBox5.SelectedIndex = 2;
                }
                else
                {
                    this.comboBox5.SelectedIndex = 0;
                }
                this.textBox2.Text = this.fc.str[0];
                this.textBox1.Text = this.fc.str[2];
                for (int i = 0; i < this.comboBox1.Items.Count; i++)
                {
                    if (this.comboBox1.Items[i].ToString() == this.fc.str[1])
                    {
                        this.comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
            this.Refzifu();
            if (this.pictureBoxzi.Visible)
            {
                this.Refhanzi();
            }
        }

        private void refencode()
        {
            if (datasize.encodes_App[this.Encode].codeh_star != 0)
            {
                if (this.comboBox5.Items.Count != 3)
                {
                    this.comboBox5.Items.Clear();
                    this.comboBox5.Items.Add("ASCII字符".Language());
                    this.comboBox5.Items.Add("所有字符".Language());
                    this.comboBox5.Items.Add("指定字符".Language());
                    this.comboBox5.SelectedIndex = 1;
                    this.Refhanzi();
                }
                this.label5.Enabled = true;
                this.label9.Visible = true;
                this.label8.Visible = true;
                this.pictureBoxzi.Visible = true;
                this.comboBox4.Left = this.groupBox1.Width - this.comboBox4.Width - 10;
                this.comboBox2.Visible = true;
                this.label7.Visible = true;
                this.comboBox5.Visible = true;
            }
            else
            {
                if (this.comboBox5.Items.Count != 1)
                {
                    this.comboBox5.Items.Clear();
                    this.comboBox5.Items.Add("ASCII字符".Language());
                    this.comboBox5.SelectedIndex = 0;
                }
                this.label5.Enabled = false;
                this.label9.Visible = false;
                this.label8.Visible = false;
                this.pictureBoxzi.Visible = false;
                this.comboBox4.Left = (this.groupBox1.Width - this.comboBox4.Width) / 2;
                this.comboBox2.Visible = false;
                this.label7.Visible = false;
                this.comboBox5.Visible = false;
            }
            this.pictureBoxm.Left = this.comboBox4.Left;
            this.label9.Left = this.comboBox4.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.pictureBoxzi.Visible)
            {
                this.Refhanzi();
            }
            this.Refzifu();
            this.button1.Enabled = false;
            this.creatend = false;
            if (this.comboBoxEx1.Text.Trim() == "")
            {
                this.button1.Enabled = true;
                MessageOpen.Show("请选择字库编码".Language());
            }
            else if (this.textBox1.Text == "")
            {
                this.button1.Enabled = true;
                MessageOpen.Show("请定义字库名称".Language());
            }
            else
            {
                if (this.creat())
                {
                    if (this.auto)
                    {
                        base.DialogResult = DialogResult.OK;
                    }
                    else if (this.Myapp != null)
                    {
                        if (MessageOpen.Show("是否立即加入刚才生成的字库?".Language(), "提示".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Myapp.Addziku(this.fc.str[0], "add", 0);
                        }
                    }
                }
                this.button1.Enabled = true;
            }
        }

        private void strinsert(string val, Encoding enc)
        {
            int num = val.GetstringCode(enc);
            int length = this.zimostr.Length;
            for (int i = 0; i < length; i++)
            {
                if (this.zimostr.Substring(i, 1).GetstringCode(enc) > num)
                {
                    this.zimostr = this.zimostr.Insert(i, val);
                    return;
                }
            }
            this.zimostr += val;
        }

        private void zimostradd(string val, Encoding enc)
        {
            if (!this.zimostr.Contains(val))
            {
                byte[] bytes = enc.GetBytes(val);
                if (bytes.Length >= 0)
                {
                    if (bytes[0] > 31 && bytes[0] < 127)
                    {
                        this.strinsert(val, enc);
                    }
                    else if (bytes[0] > 127 && bytes.Length == 2)
                    {
                        this.strinsert(val, enc);
                    }
                }
            }
        }

        private bool creat()
        {
            int num = 0;
            byte[] array = new byte[2];
            byte[] array2 = new byte[1];
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "zi|*.zi";
            bool result;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                result = false;
            }
            else
            {
                string fileName = saveFileDialog.FileName;
                byte[] array3 = this.textBox1.Text.GetbytesssASCII();
                int num2 = int.Parse(this.comboBox1.Text);
                zimoxinxi zimoxinxi = default(zimoxinxi);
                int count = Marshal.SizeOf(default(zimoxinxi));
                zimoxinxi.state = (byte)this.comboBox5.SelectedIndex;
                zimoxinxi.addbeg = 0u;
                zimoxinxi.ver = datasize.zikuver;
                zimoxinxi.ascstar = (byte)array3.Length;
                zimoxinxi.datastar = (ushort)zimoxinxi.ascstar;
                zimoxinxi.h = byte.Parse(num2.ToString());
                zimoxinxi.qumo = 10;
                zimoxinxi.encode = (byte)this.Encode;
                zimoxinxi.codeh_star = datasize.encodes_App[(int)zimoxinxi.encode].codeh_star;
                zimoxinxi.codeh_end = datasize.encodes_App[(int)zimoxinxi.encode].codeh_end;
                zimoxinxi.codel_star = datasize.encodes_App[(int)zimoxinxi.encode].codel_star;
                zimoxinxi.codel_end = datasize.encodes_App[(int)zimoxinxi.encode].codel_end;
                zimoxinxi.codelT0 = datasize.encodes_App[(int)zimoxinxi.encode].codelT0;
                zimoxinxi.codelV0 = datasize.encodes_App[(int)zimoxinxi.encode].codelV0;
                byte[] array4 = new byte[0];
                int num3 = 0;
                int num4;
                byte[] array5;
                if (zimoxinxi.state == 0)
                {
                    if (datasize.encodes_App[(int)zimoxinxi.encode].codeh_star != 0)
                    {
                        zimoxinxi.qyt = 95u;
                    }
                    else
                    {
                        zimoxinxi.qyt = (uint)(datasize.encodes_App[(int)zimoxinxi.encode].codel_end - datasize.encodes_App[(int)zimoxinxi.encode].codel_star + 1);
                    }
                    zimoxinxi.w = byte.Parse(((int)(zimoxinxi.h / 2)).ToString());
                    num4 = (int)(zimoxinxi.h * zimoxinxi.w / 8);
                    array5 = new byte[(ulong)zimoxinxi.qyt * (ulong)((long)num4)];
                }
                else
                {
                    zimoxinxi.w = zimoxinxi.h;
                    if (zimoxinxi.state == 1)
                    {
                        zimoxinxi.qyt = (uint)((zimoxinxi.codeh_end - zimoxinxi.codeh_star + 1) * (zimoxinxi.codel_end - zimoxinxi.codel_star - zimoxinxi.codelV0 + 1) + 95);
                    }
                    if (zimoxinxi.state == 2)
                    {
                        this.zimostr = "";
                        this.textBox2.Text = this.textBox2.Text + " ";
                        for (int i = 0; i < this.textBox2.Text.Length; i++)
                        {
                            this.zimostradd(this.textBox2.Text.Substring(i, 1), Encoding.GetEncoding(datasize.encodes_App[(int)zimoxinxi.encode].encodename));
                        }
                        if (this.zimostr == "")
                        {
                            MessageOpen.Show("没有可以取的字".Language());
                            result = false;
                            return result;
                        }
                        zimoxinxi.qyt = (uint)this.zimostr.Length;
                        zimoxinxi.datastar = (ushort)((uint)zimoxinxi.ascstar + zimoxinxi.qyt * 2u);
                        array4 = new byte[zimoxinxi.qyt * 2u];
                    }
                    num4 = (int)(zimoxinxi.h * zimoxinxi.w / 8);
                    if (zimoxinxi.state == 2)
                    {
                        array5 = new byte[(ulong)zimoxinxi.qyt * (ulong)((long)(num4 + 2))];
                    }
                    else
                    {
                        array5 = new byte[(ulong)zimoxinxi.qyt * (ulong)((long)num4)];
                    }
                }
                Bitmap bitmap = new Bitmap((int)zimoxinxi.w, (int)zimoxinxi.h);
                Encoding encoding = Encoding.GetEncoding(datasize.encodes_App[this.Encode].encodename);
                this.label3.Text = "";
                this.label3.Visible = true;
                if (zimoxinxi.state == 1)
                {
                    for (int j = (int)datasize.encodes_App[(int)zimoxinxi.encode].codeh_star; j <= (int)datasize.encodes_App[(int)zimoxinxi.encode].codeh_end; j++)
                    {
                        for (int k = (int)datasize.encodes_App[(int)zimoxinxi.encode].codel_star; k <= (int)datasize.encodes_App[(int)zimoxinxi.encode].codel_end; k++)
                        {
                            if (k <= (int)zimoxinxi.codelT0 || k > (int)(zimoxinxi.codelT0 + zimoxinxi.codelV0))
                            {
                                if (this.creatend)
                                {
                                    result = false;
                                    return result;
                                }
                                Application.DoEvents();
                                array[0] = (byte)j;
                                array[1] = (byte)k;
                                gdizi.bmpprintstr(bitmap, encoding.GetString(array), this.hanzipos, bitmap.Width, bitmap.Height, false);
                                bitmap.Getqumo(ref array5, bitmap.Width, num);
                                num += num4;
                            }
                        }
                        Application.DoEvents();
                        this.label3.Text = "进度:".Language() + (num * 100 / array5.Length).ToString() + "%";
                    }
                    for (int k = 32; k <= 126; k++)
                    {
                        array2[0] = byte.Parse(k.ToString());
                        gdizi.bmpprintstr(bitmap, encoding.GetString(array2), this.zifupos, bitmap.Height / 2, bitmap.Height, true);
                        bitmap.Getqumo(ref array5, bitmap.Width / 2, num);
                        num += num4;
                        Application.DoEvents();
                        this.label3.Text = "进度:".Language() + (num * 100 / array5.Length).ToString() + "%";
                    }
                }
                else if (zimoxinxi.state == 0)
                {
                    int k = 32;
                    while ((long)k < (long)((ulong)(32u + zimoxinxi.qyt)))
                    {
                        array2[0] = byte.Parse(k.ToString());
                        gdizi.bmpprintstr(bitmap, encoding.GetString(array2), this.zifupos, bitmap.Height / 2, bitmap.Height, true);
                        bitmap.Getqumo(ref array5, bitmap.Width, num);
                        num += num4;
                        Application.DoEvents();
                        this.label3.Text = "进度:".Language() + (num * 100 / array5.Length).ToString() + "%";
                        k++;
                    }
                }
                if (zimoxinxi.state == 2)
                {
                    for (int l = 0; l < this.zimostr.Length; l++)
                    {
                        Application.DoEvents();
                        this.label3.Text = l.ToString();
                        byte[] bytes = Encoding.GetEncoding(datasize.encodes_App[(int)zimoxinxi.encode].encodename).GetBytes(this.zimostr.Substring(l, 1));
                        if (bytes.Length >= 0)
                        {
                            if (bytes[0] > 31 && bytes[0] < 127)
                            {
                                array2[0] = bytes[0];
                                gdizi.bmpprintstr(bitmap, encoding.GetString(array2), this.zifupos, bitmap.Height / 2, bitmap.Height, true);
                                array4[num3] = 0;
                                num3++;
                                array4[num3] = bytes[0];
                                num3++;
                                bitmap.Getqumo(ref array5, bitmap.Width / 2, num);
                                num += num4;
                            }
                            else if (bytes[0] > 127 && bytes.Length == 2)
                            {
                                array[0] = bytes[0];
                                array[1] = bytes[1];
                                gdizi.bmpprintstr(bitmap, encoding.GetString(array), this.hanzipos, bitmap.Height, bitmap.Height, false);
                                array4[num3] = bytes[0];
                                num3++;
                                array4[num3] = bytes[1];
                                num3++;
                                bitmap.Getqumo(ref array5, bitmap.Width, num);
                                num += num4;
                            }
                        }
                        Application.DoEvents();
                        this.label3.Text = "进度:".Language() + (num * 100 / array5.Length).ToString() + "%";
                    }
                }
                zimoxinxi.size = (uint)(array5.Length + array3.Length);
                StreamWriter streamWriter = new StreamWriter(fileName);
                streamWriter.BaseStream.Write(zimoxinxi.structToBytes(), 0, count);
                streamWriter.BaseStream.Write(array3, 0, array3.Length);
                if (array4.Length > 1)
                {
                    streamWriter.BaseStream.Write(array4, 0, array4.Length);
                }
                streamWriter.BaseStream.Write(array5, 0, array5.Length);
                int num5 = (int)streamWriter.BaseStream.Length;
                streamWriter.Close();
                streamWriter.Dispose();
                this.fc.str[0] = fileName;
                Label expr_9FC = this.label3;
                expr_9FC.Text = expr_9FC.Text + "  " + "字库大小:".Language() + num5.ToString("0,000");
                MessageOpen.Show("生成字库完成,字库大小:".Language() + num5.ToString("0,000"));
                result = true;
            }
            return result;
        }

        private void Refhanzi()
        {
            this.button1.Enabled = false;
            try
            {
                if (this.checkBox1.Checked)
                {
                    this.hanzipos.fonstyl = FontStyle.Bold;
                }
                else
                {
                    this.hanzipos.fonstyl = FontStyle.Regular;
                }
                int num = int.Parse(this.comboBox1.Text);
                this.pictureBoxzi.Width = num;
                this.pictureBoxzi.Height = num;
                this.hanzipos.ziti = this.comboBox2.Text;
                this.hanzipos = gdizi.Getzipos(Encoding.GetEncoding(datasize.encodes_App[this.Encode].encodename).GetString(new byte[]
                {
                    datasize.encodes_App[this.Encode].jiaozhunh,
                    datasize.encodes_App[this.Encode].jiaozhunl
                }), this.hanzipos, this.pictureBoxzi.Width, this.pictureBoxzi.Height, this.pictureBoxzi);
                if (this.hanzipos.zisize >= 1f)
                {
                    this.viewhanzi();
                    this.button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void viewhanzi()
        {
            this.bm = new Bitmap(this.pictureBoxzi.Width, this.pictureBoxzi.Height);
            gdizi.bmpprintstr(this.bm, Encoding.GetEncoding(datasize.encodes_App[this.Encode].encodename).GetString(new byte[]
            {
                datasize.encodes_App[this.Encode].jiaozhunh,
                datasize.encodes_App[this.Encode].jiaozhunl
            }), this.hanzipos, this.bm.Width, this.bm.Height, false);
            this.pictureBoxzi.Image = this.bm;
        }

        private void Refzifu()
        {
            this.button1.Enabled = false;
            try
            {
                if (this.checkBox1.Checked)
                {
                    this.zifupos.fonstyl = FontStyle.Bold;
                }
                else
                {
                    this.zifupos.fonstyl = FontStyle.Regular;
                }
                int num = int.Parse(this.comboBox1.Text);
                this.pictureBoxm.Width = num / 2;
                this.pictureBoxm.Height = num;
                this.zifupos.ziti = this.comboBox4.Text;
                this.zifupos = gdizi.Getzipos("X", this.zifupos, this.pictureBoxm.Width, this.pictureBoxm.Height, this.pictureBoxm);
                if (this.zifupos.zisize >= 1f)
                {
                    this.viewzifu();
                    this.button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void viewzifu()
        {
            this.bm = new Bitmap(this.pictureBoxm.Width, this.pictureBoxm.Height);
            gdizi.bmpprintstr(this.bm, "X", this.zifupos, this.bm.Width, this.bm.Height, true);
            this.pictureBoxm.Image = this.bm;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox5.SelectedIndex == 0)
                {
                    this.comboBox2.Visible = false;
                    this.pictureBoxzi.Visible = false;
                    this.label8.Visible = false;
                }
                else
                {
                    this.comboBox2.Visible = true;
                    this.pictureBoxzi.Visible = true;
                    this.label8.Visible = true;
                }
                int num = base.Height - base.ClientRectangle.Height;
                if (this.comboBox5.SelectedIndex == 2)
                {
                    base.Height = this.textBox2.Top + this.textBox2.Height + num + 10;
                }
                else
                {
                    base.Height = this.button1.Top + this.button1.Height + num + 10;
                }
            }
            finally
            {
            }
        }

        private void zikucreat_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.creatend = true;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            this.Refzifu();
            if (this.pictureBoxzi.Visible)
            {
                this.Refhanzi();
            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            this.Refhanzi();
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            this.Refzifu();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.pictureBoxzi.Visible)
            {
                this.Refhanzi();
            }
            this.Refzifu();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.linkLabel1.ContextMenuStrip.Show(this.linkLabel1, new Point(0, 0));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.linkLabel1.Text = ((ToolStripMenuItem)sender).Text;
            this.zifupos.yuliang = this.linkLabel1.Text.Getint();
            this.hanzipos.yuliang = this.zifupos.yuliang;
            this.Refzifu();
            if (this.pictureBoxzi.Visible)
            {
                this.Refhanzi();
            }
        }

        private void comboBoxEx1_DropDownClosed(object sender, EventArgs e)
        {
            this.Encode = (int)this.comboBoxEx1.Text.GetencodeId();
            this.refencode();
            this.Refzifu();
            if (this.pictureBoxzi.Visible)
            {
                this.Refhanzi();
            }
        }
    }
}