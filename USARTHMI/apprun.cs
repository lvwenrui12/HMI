using Colpanel;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using hmitype;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using run;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using USARTHMI.Properties;

namespace USARTHMI
{
    public partial class apprun : DevComponents.DotNetBar.OfficeForm
    {
        private delegate void SetListBoxCallback(string str);

        private delegate void sendrunscr(string str, bool iscrc, Encoding en);

 
        private Label label6;

        private Label label1;

        private CheckBox checkBox1;

        private Label label2;

        private Label label3;

        private SerialPort com1;

        private System.Windows.Forms.Timer timer2;

        private LinkLabel linkLabel1;

        private LinkLabel linkLabel2;

        private Label label4;

        private Label label5;

        private LinkLabel linkLabel3;

        private Button codetext_clear;

        private Colpanel.Colpanel panel1;

        private runscr runscr1;

        private RadioButton radioButton1;

        private GroupBox groupBox1;

        private RadioButton radioButton2;

        private Label label7;

        private Label label8;

        private LinkLabel linkLabel4;

        private Label label9;

        private TextBox textBox2;

        private LinkLabel linkLabel5;

        private Panel panel2;

        private Label label11;

        private TextBox textBox5;

        private Label label10;

        private TextBox textBox4;

        private CheckBox checkBox2;

        private Label label14;

        private TextBox textBox8;

        private Label label15;

        private TextBox textBox9;

        private Label label12;

        private System.Windows.Forms.Timer timercom;

        private CheckBox checkBox3;

        private ComboBoxEx comboBox2;

        private ComboBoxEx comboBox4;

        private ListBoxAdv listBox1;

        private ListBoxAdv listBox2;

        private ButtonX button2;

        private TextBoxX textBox3;

        private SuperTooltip superTooltip1;

        private Bar bar1;

        private ComboBoxItem comboBox1;

        private LabelItem toolStripLabel1;

        private ComboBoxItem comboBox3;

        private ButtonItem Button3;

        private LabelItem labelItem1;

        private Label label13;

        private Label label16;

        private ButtonItem buttonItem1;

        private ButtonItem buttonItem2;

        private ButtonItem buttonItem3;

        private ButtonItem buttonItem4;

        private LabelItem labelItem2;

        private ButtonItem buttonItem5;

        private RichTextBoxEx codetext;

        private Button codetext_vis;

        private Button codetext_copy;

        private System.Windows.Forms.Timer timer1;

        private ButtonItem buttonItem6;

        private TextEditorControl textEditorControl1;

        private LabelItem labelItem3;

        private ComboBoxItem comboBoxItem1;

        private textmsg textmsg1 = null;

        public Myapp_inf Myapp = null;

        private string binpath;

        private string comdata;

        private string comdata2;

        private int monitime = 0;

        private int sheibeitime = 0;

        private Comuser mycom1 = new Comuser();

        private int jieshuqyt = 0;

        private int ddx = 0;

        private int comrecstate = 0;

        private int sendbo = 0;

        private int sendboyan = 0;

        private int quxianfudu = 0;

        private int quxianyidong = 0;

        private bool quxiansendmoni = false;

        private bool quxiansendcom = false;

        private byte[] quxiantongdaos = new byte[4];

        private Thread Threadsendbo;

        private bool thisisclose = false;

        private int xilie_shebei = -1;

        private Encoding sendencoding;
        public apprun(string path, Myapp_inf myapp_)
        {
            this.Myapp = myapp_;
            this.binpath = path;
            this.InitializeComponent();
            if (datasize.Language == 0)
            {
            }
            this.Language();
            base.Icon = datasize.Myico;
        }
        private void run_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.textmsg1 != null)
            {
                this.textmsg1.CloseMe();
            }
            this.thisisclose = true;
            if (this.mycom1.State != 0)
            {
                this.mycom1.State = 2;
                e.Cancel = true;
            }
            else
            {
                this.sendboend();
                this.mycom1.comclose();
                this.runscr1.RunStop();
                if (this.runscr1 != null)
                {
                    this.runscr1.Dispose();
                }
                this.runscr1 = null;
            }
        }

        private unsafe void sendmoni(string j, bool iscrc, Encoding en)
        {
            if (en == null)
            {
                en = Encoding.GetEncoding("ascii");
            }
            if (this.runscr1.InvokeRequired)
            {
                apprun.sendrunscr method = new apprun.sendrunscr(this.sendmoni);
                this.runscr1.Invoke(method, new object[]
                {
                    j,
                    iscrc,
                    en
                });
            }
            else
            {
                string text = j.Trim();
                if (text.Length > 0)
                {
                    byte[] bytes = en.GetBytes(text);
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Usart.Usart_ComRecode(bytes[i]);
                    }
                    Usart.Usart_ComRecode(255);
                    Usart.Usart_ComRecode(255);
                    Usart.Usart_ComRecode(255);
                    if (iscrc)
                    {
                        uint num = en.GetBytes(j).getcrc(0);
                        void* ptr = (void*)(&num);
                        byte* ptr2 = (byte*)ptr;
                        Usart.Usart_ComRecode(*ptr2);
                        Usart.Usart_ComRecode(ptr2[1]);
                        Usart.Usart_ComRecode(ptr2[2]);
                        Usart.Usart_ComRecode(ptr2[3]);
                    }
                }
            }
        }

        private void SendLastCode(string j)
        {
            if (this.textEditorControl1.Document.TotalNumberOfLines == 2 && this.textEditorControl1.Document.GetText(this.textEditorControl1.Document.GetLineSegment(0)) == "openvis")
            {
                this.runscr1.myapp.upapp.SendRuncodeTime = this.textEditorControl1.Document.GetText(this.textEditorControl1.Document.GetLineSegment(1)).Getint();
                this.codetext_clear.Visible = true;
                this.codetext_copy.Visible = true;
                this.codetext_vis.Visible = true;
                this.codetext.Visible = true;
            }
            else
            {
                if (this.comboBox1.SelectedIndex == 0 || this.comboBox1.SelectedIndex == 2)
                {
                    this.sendmoni(j, this.checkBox3.Checked, this.sendencoding);
                }
                if (this.comboBox1.SelectedIndex == 1 || this.comboBox1.SelectedIndex == 2)
                {
                    this.com1.sendstring_End(j, this.checkBox3.Checked, this.sendencoding);
                }
            }
        }

        private void sendLast()
        {
            if (this.comboBox1.SelectedIndex == 1 || this.comboBox1.SelectedIndex == 2)
            {
                if (!this.com1.IsOpen)
                {
                    MessageOpen.Show("设备未连接".Language());
                }
            }
            if (this.textEditorControl1.Document.TextContent != "")
            {
                int line = this.textEditorControl1.Document.TextArea.Caret.Line;
                if (line < this.textEditorControl1.Document.TotalNumberOfLines)
                {
                    LineSegment lineSegment = this.textEditorControl1.Document.GetLineSegment(line);
                    this.SendLastCode(this.textEditorControl1.Document.GetText(lineSegment));
                }
            }
        }

        private void sendall()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.label4.Text = "数据含义:".Language();
            this.label4.ForeColor = Color.Black;
            this.label5.Text = "数据含义:".Language();
            this.label5.ForeColor = Color.Black;
            if (this.comboBox1.SelectedIndex == 1 || this.comboBox1.SelectedIndex == 2)
            {
                if (!this.com1.IsOpen)
                {
                    MessageOpen.Show("设备未连接".Language());
                }
            }
            if (this.textEditorControl1.Document.TotalNumberOfLines > 0)
            {
                foreach (LineSegment current in this.textEditorControl1.Document.LineSegmentCollection)
                {
                    string text = this.textEditorControl1.Document.GetText(current).Trim();
                    if (text.Length > 0)
                    {
                        this.SendLastCode(text);
                    }
                }
            }
        }

        public void SetListBox(string str)
        {
            if (this.listBox1.InvokeRequired)
            {
                apprun.SetListBoxCallback method = new apprun.SetListBoxCallback(this.SetListBox);
                this.listBox1.Invoke(method, new object[]
                {
                    str
                });
            }
            else
            {
                if (this.listBox1.Items.Count >= 800)
                {
                    this.listBox1.Items.Clear();
                }
                this.listBox1.Items.Add(str);
                this.xuanzhonglist(this.listBox1, this.label13);
            }
        }

        public void SetRunCodeListBox(string str)
        {
            if (this.codetext.InvokeRequired)
            {
                apprun.SetListBoxCallback method = new apprun.SetListBoxCallback(this.SetRunCodeListBox);
                this.codetext.Invoke(method, new object[]
                {
                    str
                });
            }
            else
            {
                this.codetext.AppendText(str + "\r\n");
            }
        }

        private void runscr1_SendCom(object sender, EventArgs e)
        {
            this.monitime = 0;
            int num = (int)((byte)sender);
            string text = Convert.ToString(num, 16);
            if (text.Length == 1)
            {
                text = "0" + text;
            }
            this.comdata2 = this.comdata2 + "0x" + text + " ";
            if (this.comrecstate == 1)
            {
                if (this.com1.IsOpen)
                {
                    byte[] buffer = new byte[]
                    {
                        (byte)num
                    };
                    this.com1.Write(buffer, 0, 1);
                }
            }
            if (text == "ff")
            {
                this.ddx++;
            }
            else
            {
                this.ddx = 0;
            }
            if (this.comdata2.Length > 4096)
            {
                this.ddx = 3;
            }
            if (this.ddx >= 3)
            {
                this.ddx = 0;
                this.SetListBox(this.comdata2.Trim());
                Application.DoEvents();
                this.comdata2 = "";
            }
        }

        private void getports()
        {
            this.comboBox2.Items.Clear();
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.Add("自动搜索".Language());
            try
            {
                string[] portNames = SerialPort.GetPortNames();
                string[] array = portNames;
                for (int i = 0; i < array.Length; i++)
                {
                    string item = array[i];
                    this.comboBox3.Items.Add(item);
                    this.comboBox2.Items.Add(item);
                }
                this.comboBox3.SelectedIndex = 0;
                if (this.comboBox2.Items.Count > 0)
                {
                    this.comboBox2.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("获取计算机COM口列表失败！".Language() + "\r\n" + "错误信息:".Language() + ex.Message);
            }
        }

        private void ResizeForm()
        {
            try
            {
                if (this.panel1.Width > 50 && this.panel1.Height > 50)
                {
                    int num = (this.panel1.Width - this.runscr1.Width) / 2;
                    int num2 = (this.panel1.Height - this.runscr1.Height) / 2;
                    if (num < 0)
                    {
                        num = 0;
                    }
                    if (num2 < 0)
                    {
                        num2 = 0;
                    }
                    this.runscr1.Location = new Point(num, num2);
                }
            }
            catch
            {
            }
        }

        private void run_Load(object sender, EventArgs e)
        {
            this.textEditorControl1.Width = this.listBox1.Left - 10 - this.textEditorControl1.Left;
            this.panel2.Location = this.textEditorControl1.Location;
            this.panel2.Size = this.textEditorControl1.Size;
            this.panel2.BringToFront();
            this.textEditorControl1.Document.autohscroll = true;
            this.textEditorControl1.ShowEOLMarkers = false;
            this.textEditorControl1.Encoding = Encoding.Default;
            this.textEditorControl1.ShowSpaces = false;
            this.textEditorControl1.ShowTabs = false;
            this.textEditorControl1.ShowVRuler = false;
            this.textEditorControl1.TabIndent = 2;
            this.textEditorControl1.ShowLineNumbers = false;
            this.textEditorControl1.Text = "";
            if (datasize.codemessage[1].codehig == 1)
            {
                this.textEditorControl1.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#-2");
            }
            else
            {
                this.textEditorControl1.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy();
            }
            this.textEditorControl1.Document.TextKeyPress += new DocumentEventHandler(this.textBox1_KeyPress);
            this.textEditorControl1.Document.TextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.panel1.panel_init();
            if (this.Myapp != null && this.textmsg1 == null)
            {
                this.textmsg1 = new textmsg(this.textEditorControl1, 1);
                this.textmsg1.Myapp = this.Myapp;
                this.textmsg1.dpage = this.Myapp.pages[0];
                this.textmsg1.textevent = true;
            }
            try
            {
                base.Icon = datasize.Myico;
                this.Text = datasize.softname;
                this.quxiantongdaos[0] = 0;
                this.quxiantongdaos[1] = 255;
                this.quxiantongdaos[2] = 255;
                this.quxiantongdaos[3] = 255;
                this.comboBox4.Items.Clear();
                this.comboBox4.Items.Add("2400");
                this.comboBox4.Items.Add("4800");
                this.comboBox4.Items.Add("9600");
                this.comboBox4.Items.Add("19200");
                this.comboBox4.Items.Add("38400");
                this.comboBox4.Items.Add("57600");
                this.comboBox4.Items.Add("115200");
                this.comboBox4.Text = "9600";
                this.comboBox3.Visible = false;
                this.Button3.Visible = false;
                this.toolStripLabel1.Visible = false;
                this.comdata = "";
                this.comboBox1.Items.Clear();
                this.comboBox1.Items.Add("当前模拟器".Language());
                this.comboBox1.Items.Add("本机串口".Language());
                this.comboBox1.Items.Add("模拟器和串口".Language());
                this.comboBox1.SelectedIndex = 0;
                this.comboBoxItem1.Items.Clear();
                int[] encodes_This = datasize.encodes_This;
                for (int i = 0; i < encodes_This.Length; i++)
                {
                    int j = encodes_This[i];
                    this.comboBoxItem1.Items.Add(datasize.encodes_App[j].encodename);
                }
                if ((int)this.Myapp.myencode >= datasize.encodes_App.Length)
                {
                    this.Myapp.myencode = ((datasize.Language == 0) ? "gb2312".GetencodeId() : "iso-8859-1".GetencodeId());
                }
                this.sendencoding = Encoding.GetEncoding(datasize.encodes_App[(int)this.Myapp.myencode].encodename);
                string encodename = datasize.encodes_App[(int)this.Myapp.myencode].encodename;
                for (int j = 0; j < this.comboBoxItem1.Items.Count; j++)
                {
                    if (this.comboBoxItem1.Items[j].ToString() == encodename)
                    {
                        this.comboBoxItem1.SelectedIndex = j;
                        break;
                    }
                }
                this.getports();
                this.mycom1.com1 = this.com1;
                this.runscr1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void runscr1_Runcode(object sender, EventArgs e)
        {
            this.SetRunCodeListBox((string)sender);
        }

        private void textBox1_KeyPress(object sender, DocumentEventArgs e)
        {
            Keys keys = (Keys)sender;
            if (this.checkBox1.Checked)
            {
                if (keys == Keys.Return)
                {
                    if (this.textmsg1 == null || this.textmsg1.Listm1 == null || !this.textmsg1.Listm1.vis)
                    {
                        this.sendLast();
                    }
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.textEditorControl1.Text == "crcf=")
            {
                this.checkBox3.Visible = true;
            }
        }

        private void xuanzhonglist(ListBoxAdv list1, Label label)
        {
            try
            {
                if (list1 != null && list1.Items.Count > 0 && list1.VScrollBar != null)
                {
                    list1.AutoScrollPosition = new Point(0, list1.VScrollBar.Maximum - list1.VScrollBar.LargeChange + 1);
                    list1.RefreshItems();
                }
                Application.DoEvents();
                Thread.Sleep(1);
                list1.SelectedIndex = list1.Items.Count - 1;
                label.Text = list1.Items.Count.ToString();
            }
            catch
            {
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.timer2.Enabled = false;
            bool flag = false;
            try
            {
                if (this.com1.IsOpen && this.com1.BytesToRead > 0)
                {
                    this.sheibeitime = 0;
                    byte[] array = new byte[this.com1.BytesToRead];
                    this.com1.Read(array, 0, array.Length);
                    for (int i = 0; i < array.Length; i++)
                    {
                        string text = Convert.ToString(array[i], 16);
                        if (this.comrecstate == 1)
                        {
                            Usart.Usart_ComRecode(array[i]);
                        }
                        if (text.Length == 1)
                        {
                            text = "0" + text;
                        }
                        this.comdata = this.comdata + "0x" + text + " ";
                        if (text == "ff")
                        {
                            this.jieshuqyt++;
                        }
                        else
                        {
                            this.jieshuqyt = 0;
                        }
                        if (this.comdata.Length > 4096)
                        {
                            this.jieshuqyt = 3;
                            i = array.Length;
                        }
                        if (this.jieshuqyt > 2)
                        {
                            if (this.listBox2.Items.Count >= 800)
                            {
                                this.listBox2.Items.Clear();
                            }
                            this.listBox2.Items.Add(this.comdata.Trim());
                            Application.DoEvents();
                            flag = true;
                            this.comdata = "";
                            this.jieshuqyt = 0;
                            if (this.thisisclose)
                            {
                                return;
                            }
                        }
                    }
                }
                if (flag)
                {
                    this.xuanzhonglist(this.listBox2, this.label16);
                }
                this.timer2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageOpen.Show("串口通讯出现异常,强制关闭!".Language() + "\r\n" + ex.Message);
                this.closelianji();
            }
        }

        private void closelianji()
        {
            if (this.mycom1.State == 1)
            {
                this.mycom1.State = 2;
                while (this.mycom1.State != 0)
                {
                }
            }
            this.timer2.Enabled = false;
            this.mycom1.comclose();
            this.xilie_shebei = -1;
            this.timer2.Enabled = false;
            this.Button3.Text = "联机".Language();
            this.textBox3.Text = "设备状态:".Language() + "未联机".Language();
        }

        private void openlianji()
        {
            bool iscrc = false;
            if (this.checkBox3.Visible && this.checkBox3.Checked)
            {
                iscrc = true;
            }
            this.sendmoni("runmod=2", this.checkBox3.Checked, null);
            if (this.mycom1.getlianji(this.textBox3, this.comboBox3.Text, 0, true, false, iscrc) == 1)
            {
                this.xilie_shebei = this.mycom1.xilie;
                this.comrecstate = 0;
                this.timer2.Enabled = true;
                this.Button3.Text = "断开".Language();
                this.timer2.Enabled = true;
            }
            this.sendmoni("runmod=0", this.checkBox3.Checked, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.radioButton2.Enabled = (this.comboBox1.SelectedIndex == 0);
            if (this.comboBox1.SelectedIndex != 1 && this.comboBox1.SelectedIndex != 2)
            {
                this.closelianji();
                this.comboBox3.Visible = false;
                this.Button3.Visible = false;
                this.toolStripLabel1.Visible = false;
                this.listBox2.BackColor = this.BackColor;
                this.listBox1.BackColor = Color.White;
            }
            else
            {
                if (this.comboBox1.SelectedIndex == 1)
                {
                    this.listBox1.BackColor = this.BackColor;
                }
                else
                {
                    this.listBox1.BackColor = Color.White;
                }
                this.listBox2.BackColor = Color.White;
                this.toolStripLabel1.Visible = true;
                this.comboBox3.Visible = true;
                this.Button3.Visible = true;
            }
            this.bar1.Refresh();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            this.Button3.Enabled = false;
            if (this.Button3.Text == "联机".Language())
            {
                bool enabled = this.buttonItem1.Enabled;
                this.buttonItem1.Enabled = false;
                this.openlianji();
                this.buttonItem1.Enabled = enabled;
            }
            else
            {
                this.closelianji();
            }
            this.Button3.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.sendall();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.listBox1.Items.Clear();
            this.label4.Text = "数据含义:".Language();
            this.label4.ForeColor = Color.Black;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count > 0)
            {
                if (this.listBox1.SelectedIndex >= 0)
                {
                    this.label4.Text = "数据含义:".Language() + this.listBox1.SelectedItem.ToString().Gethanyi().Language();
                    int num = Convert.ToInt32(this.listBox1.SelectedItem.ToString().Split(new char[]
                    {
                        ' '
                    })[0], 16);
                    if (num == 0 || (num > 1 && num < 101))
                    {
                        this.label4.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.label4.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.listBox2.Items.Clear();
            this.label5.Text = "数据含义:".Language();
            this.label5.ForeColor = Color.Black;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox2.Items.Count > 0)
            {
                if (this.listBox2.SelectedIndex >= 0)
                {
                    this.label5.Text = "数据含义:".Language() + this.listBox2.SelectedItem.ToString().Gethanyi();
                    int num = Convert.ToInt32(this.listBox2.SelectedItem.ToString().Split(new char[]
                    {
                        ' '
                    })[0], 16);
                    if (num == 0 || (num > 1 && num < 101))
                    {
                        this.label5.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.label5.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.codetext.Text = "";
        }

        private void runscr1_Resize(object sender, EventArgs e)
        {
            this.ResizeForm();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            this.ResizeForm();
        }

        private void radiochang()
        {
            this.linkLabel1.Visible = this.radioButton1.Checked;
            this.comboBox1.Enabled = this.radioButton1.Checked;
            this.linkLabel5.Visible = this.radioButton1.Checked;
            this.linkLabel4.Visible = this.radioButton2.Checked;
            this.label7.Visible = this.radioButton2.Checked;
            this.label8.Visible = this.radioButton2.Checked;
            this.comboBox2.Visible = this.radioButton2.Checked;
            this.comboBox4.Visible = this.radioButton2.Checked;
            this.textEditorControl1.Document.ReadOnly = this.radioButton2.Checked;
            this.comrecstate = (this.radioButton1.Checked ? 0 : 1);
            this.buttonItem1.Enabled = this.radioButton1.Checked;
            if (this.radioButton1.Checked)
            {
                if (this.com1.IsOpen)
                {
                    this.timer2.Enabled = false;
                    this.comclose();
                    this.linkLabel4.Text = "开始".Language();
                    this.comboBox2.Enabled = true;
                    this.comboBox4.Enabled = true;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.radiochang();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.radiochang();
        }

        public bool comopen(string portname, int baurate)
        {
            bool result = false;
            try
            {
                if (this.com1 != null)
                {
                    this.com1.BaudRate = baurate;
                    this.com1.PortName = portname;
                    this.com1.Open();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                MessageOpen.Show(ex.Message);
            }
            return result;
        }

        public void comclose()
        {
            try
            {
                if (this.com1 != null)
                {
                    if (this.com1.IsOpen)
                    {
                        this.com1.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!this.com1.IsOpen)
            {
                if (this.comopen(this.comboBox2.Text, this.comboBox4.Text.Getint()))
                {
                    this.listBox2.Items.Clear();
                    this.textEditorControl1.Text = "";
                    this.linkLabel4.Text = "停止".Language();
                    this.comboBox2.Enabled = false;
                    this.comboBox4.Enabled = false;
                    this.timer2.Enabled = true;
                }
            }
            else
            {
                this.timer2.Enabled = false;
                this.comclose();
                this.linkLabel4.Text = "开始".Language();
                this.comboBox2.Enabled = true;
                this.comboBox4.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.sendboyan = int.Parse(this.textBox2.Text);
                if (this.sendboyan > 1000)
                {
                    this.textBox2.Text = "1000";
                    this.sendboyan = 1000;
                }
            }
            catch
            {
            }
        }

        private void sendboend()
        {
            if (this.Threadsendbo != null)
            {
                if (this.Threadsendbo.IsAlive)
                {
                    this.sendbo = 2;
                    while (this.sendbo != 0)
                    {
                        Application.DoEvents();
                    }
                }
            }
            this.textBox2.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
            this.textBox8.Enabled = true;
            this.textBox9.Enabled = true;
            this.button2.Text = "发送".Language();
            this.Button3.Enabled = true;
            this.comboBox1.Enabled = true;
            this.comboBox3.Enabled = true;
        }

        private void Sendbo()
        {
            Random random = new Random();
            List<int> list = new List<int>();
            int num = 0;
            int num2 = 1;
            byte[] array = new byte[3];
            Win32.timeBeginPeriod(1);
            array[0] = 255;
            array[1] = 255;
            array[2] = 255;
            Kuozhan.Getquxian(this.quxianfudu, this.quxianyidong, ref list);
            this.sendboyan = this.textBox2.Text.Getint();
            while (this.sendbo == 1)
            {
                try
                {
                    Application.DoEvents();
                    this.sendboyan = this.textBox2.Text.Getint();
                    byte b = (byte)list[num];
                    int num3 = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (this.quxiantongdaos[i] < 4)
                        {
                            byte b2;
                            if (num + 16 * i >= list.Count)
                            {
                                int j;
                                for (j = num + 16 * i; j >= list.Count; j -= list.Count)
                                {
                                }
                                b2 = (byte)list[j];
                            }
                            else
                            {
                                b2 = (byte)list[num + 16 * i];
                            }
                            if (this.checkBox2.Checked)
                            {
                                b = (byte)random.Next(int.Parse(this.textBox8.Text), int.Parse(this.textBox9.Text));
                                b2 = (byte)random.Next(int.Parse(this.textBox8.Text), int.Parse(this.textBox9.Text));
                            }
                            string text = string.Concat(new string[]
                            {
                                "add ",
                                this.textBox5.Text,
                                ",",
                                this.quxiantongdaos[i].ToString(),
                                ",",
                                b2.ToString()
                            });
                            if (this.quxiansendmoni)
                            {
                                this.sendmoni(text, this.checkBox3.Checked, null);
                                num3 += text.Length;
                            }
                            if (this.quxiansendcom)
                            {
                                if (this.com1.IsOpen)
                                {
                                    this.com1.sendstring_End(text, this.checkBox3.Checked, null);
                                    num3 = 0;
                                }
                            }
                        }
                    }
                    Application.DoEvents();
                    for (int k = 0; k < this.sendboyan; k++)
                    {
                        Thread.Sleep(1);
                        Application.DoEvents();
                        if (this.sendbo != 1)
                        {
                            break;
                        }
                    }
                    for (int k = 0; k < num3; k++)
                    {
                        Thread.Sleep(1);
                        Application.DoEvents();
                        if (this.sendbo != 1)
                        {
                            break;
                        }
                    }
                    num2++;
                    num++;
                    if (num == list.Count)
                    {
                        num = 0;
                        num2 = 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                    this.sendbo = 1;
                    while (this.sendbo == 1)
                    {
                        Application.DoEvents();
                    }
                }
            }
            this.sendbo = 0;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!this.panel2.Visible)
            {
                this.panel2.Visible = true;
            }
            else
            {
                this.sendboend();
                this.panel2.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.gettongdao();
        }

        private void gettongdao()
        {
            try
            {
                this.quxiantongdaos[0] = 255;
                this.quxiantongdaos[1] = 255;
                this.quxiantongdaos[2] = 255;
                this.quxiantongdaos[3] = 255;
                string[] array = this.textBox4.Text.Split(new char[]
                {
                    ','
                });
                if (array.Length < 5)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        this.quxiantongdaos[i] = byte.Parse(array[i]);
                    }
                }
                else
                {
                    this.quxiantongdaos[0] = 255;
                    this.quxiantongdaos[1] = 255;
                    this.quxiantongdaos[2] = 255;
                    this.quxiantongdaos[3] = 255;
                }
            }
            catch
            {
                this.quxiantongdaos[0] = 255;
                this.quxiantongdaos[1] = 255;
                this.quxiantongdaos[2] = 255;
                this.quxiantongdaos[3] = 255;
            }
        }

        private void apprun_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.textmsg1 != null)
                {
                    this.textmsg1.closemessageshow();
                }
                int num = (base.Width - this.label1.Left - 10) / 2;
                this.label3.Left = this.label1.Left + num;
                this.listBox2.Left = this.label3.Left;
                this.label5.Left = this.label3.Left;
                this.listBox1.Width = num - 10;
                this.listBox2.Width = num - 10;
                this.linkLabel2.Left = this.listBox1.Left + this.listBox1.Width - this.linkLabel2.Width;
                this.linkLabel3.Left = this.listBox2.Left + this.listBox2.Width - this.linkLabel3.Width;
                this.label16.Left = this.label3.Left + this.label3.Width + 5;
                this.label13.Left = this.label1.Left + this.label1.Width + 5;
            }
            catch
            {
            }
        }

        private void timercom_Tick(object sender, EventArgs e)
        {
            this.timercom.Enabled = false;
            if (this.monitime > 300)
            {
                if (this.comdata2 != null && this.comdata2 != "")
                {
                    this.ddx = 0;
                    this.SetListBox(this.comdata2.Trim());
                    this.comdata2 = "";
                    this.monitime = 0;
                }
            }
            else
            {
                this.monitime += this.timercom.Interval;
            }
            if (this.sheibeitime > 300)
            {
                if (this.comdata != null && this.comdata != "")
                {
                    if (this.listBox2.Items.Count >= 800)
                    {
                        this.listBox2.Items.Clear();
                    }
                    this.listBox2.Items.Add(this.comdata.Trim());
                    this.xuanzhonglist(this.listBox2, this.label16);
                    this.comdata = "";
                    this.jieshuqyt = 0;
                    this.sheibeitime = 0;
                }
            }
            else
            {
                this.sheibeitime += this.timercom.Interval;
            }
            this.timercom.Enabled = true;
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(this.listBox2.SelectedItem.ToString());
            }
            catch
            {
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(this.listBox1.SelectedItem.ToString());
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button2.Text == "发送".Language())
            {
                this.gettongdao();
                if (this.quxiantongdaos[0] == 255 && this.quxiantongdaos[1] == 255 && this.quxiantongdaos[2] == 255 && this.quxiantongdaos[3] == 255)
                {
                    MessageOpen.Show("请输入正确的通道数".Language());
                }
                else
                {
                    this.quxiansendmoni = false;
                    this.quxiansendcom = false;
                    if (this.comboBox1.SelectedIndex == 0 || this.comboBox1.SelectedIndex == 2)
                    {
                        this.quxiansendmoni = true;
                    }
                    if (this.comboBox1.SelectedIndex == 1 || this.comboBox1.SelectedIndex == 2)
                    {
                        this.quxiansendcom = true;
                    }
                    this.quxianfudu = (int.Parse(this.textBox9.Text) - int.Parse(this.textBox8.Text)) / 2;
                    this.quxianfudu *= 2;
                    this.quxianyidong = int.Parse(this.textBox8.Text) + this.quxianfudu / 2;
                    if (this.quxianfudu / 2 + this.quxianyidong > 255)
                    {
                        MessageOpen.Show("值超出范围".Language());
                    }
                    else
                    {
                        this.button2.Text = "停止".Language();
                        this.textBox2.Enabled = false;
                        this.textBox4.Enabled = false;
                        this.textBox5.Enabled = false;
                        this.textBox8.Enabled = false;
                        this.textBox9.Enabled = false;
                        this.Button3.Enabled = false;
                        this.comboBox1.Enabled = false;
                        this.comboBox3.Enabled = false;
                        this.sendbo = 1;
                        this.Threadsendbo = new Thread(new ThreadStart(this.Sendbo));
                        this.Threadsendbo.Start();
                    }
                }
            }
            else
            {
                this.sendboend();
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            this.sendboend();
            if (this.com1.IsOpen)
            {
                flag = true;
                this.closelianji();
            }
            this.sendmoni("runmod=2", this.checkBox3.Checked, null);
            new USARTUP(this.binpath).ShowDialog();
            this.sendmoni("runmod=0", this.checkBox3.Checked, null);
            if (flag)
            {
                this.Button3.Enabled = false;
                bool enabled = this.buttonItem1.Enabled;
                this.buttonItem1.Enabled = false;
                this.openlianji();
                this.Button3.Enabled = true;
                this.buttonItem1.Enabled = enabled;
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (!this.com1.IsOpen)
            {
                MessageOpen.Show("设备未连接".Language());
            }
            else if (this.xilie_shebei != 1 && this.xilie_shebei != 2)
            {
                MessageOpen.Show("增强型及以上系列才支持RTC".Language());
            }
            else
            {
                this.com1.sendstring_End("rtc0=" + DateTime.Now.Year.ToString(), this.checkBox3.Checked, null);
                this.com1.sendstring_End("rtc1=" + DateTime.Now.Month.ToString(), this.checkBox3.Checked, null);
                this.com1.sendstring_End("rtc2=" + DateTime.Now.Day.ToString(), this.checkBox3.Checked, null);
                this.com1.sendstring_End("rtc3=" + DateTime.Now.Hour.ToString(), this.checkBox3.Checked, null);
                this.com1.sendstring_End("rtc4=" + DateTime.Now.Minute.ToString(), this.checkBox3.Checked, null);
                this.com1.sendstring_End("rtc5=" + DateTime.Now.Second.ToString(), this.checkBox3.Checked, null);
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (!this.com1.IsOpen)
            {
                MessageOpen.Show("设备未连接".Language());
            }
            else
            {
                this.com1.sendstring_End("rest", this.checkBox3.Checked, null);
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            this.sendmoni("rtc0=" + DateTime.Now.Year.ToString(), this.checkBox3.Checked, null);
            this.sendmoni("rtc1=" + DateTime.Now.Month.ToString(), this.checkBox3.Checked, null);
            this.sendmoni("rtc2=" + DateTime.Now.Day.ToString(), this.checkBox3.Checked, null);
            this.sendmoni("rtc3=" + DateTime.Now.Hour.ToString(), this.checkBox3.Checked, null);
            this.sendmoni("rtc4=" + DateTime.Now.Minute.ToString(), this.checkBox3.Checked, null);
            this.sendmoni("rtc5=" + DateTime.Now.Second.ToString(), this.checkBox3.Checked, null);
        }

        private void runscr1_Runcodestr(object sender, EventArgs e)
        {
            try
            {
                if (this.codetext.Visible)
                {
                    string runCodeListBox = (string)sender;
                    this.SetRunCodeListBox(runCodeListBox);
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void richTextBoxEx1_TextChanged(object sender, EventArgs e)
        {
        }

        private void codetext_vis_Click(object sender, EventArgs e)
        {
            this.codetext_clear.Visible = false;
            this.codetext_copy.Visible = false;
            this.codetext_vis.Visible = false;
            this.codetext.Visible = false;
            this.runscr1.myapp.upapp.SendRuncodeTime = 0;
        }

        private void codetext_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.codetext.Text, TextDataFormat.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (this.Myapp == null)
            {
                StreamReader streamReader = new StreamReader(this.binpath);
                if (!Kuozhan.CheckData(streamReader, datasize.hmibiaoshiL, 1))
                {
                    base.Close();
                    return;
                }
                streamReader.Close();
                streamReader.Dispose();
                this.runscr1.guiint_run(null, this.binpath);
            }
            else
            {
                this.runscr1.guiint_run(this.Myapp.images, this.binpath);
            }
            this.apprun_Resize(null, null);
            this.runscr1.Visible = true;
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.sendmoni("rest", this.checkBox3.Checked, null);
        }

        private void apprun_Move(object sender, EventArgs e)
        {
            if (this.textmsg1 != null)
            {
                this.textmsg1.closemessageshow();
            }
        }

        private void runscr1_pagechange(object sender, EventArgs e)
        {
            if (this.textmsg1 != null)
            {
                int num = (int)sender;
                if (num < this.Myapp.pages.Count)
                {
                    this.textmsg1.dpage = this.Myapp.pages[num];
                }
            }
        }

        private void comboBoxItem1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sendencoding = Encoding.GetEncoding(this.comboBoxItem1.Text);
        }
    }
}