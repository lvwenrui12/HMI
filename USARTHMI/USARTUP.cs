using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using hmitype;

namespace USARTHMI
{
    public partial class USARTUP : DevComponents.DotNetBar.OfficeForm
    {
        private struct lasttime
        {
            public int lastsendsize;

            public DateTime dt;
        }

     

        private SerialPort com1;

        private Label label2;

        private Label label4;

        private Label label7;

        private TextBox textBox2;

        private System.Windows.Forms.Timer timer1;

        private ComboBoxEx comboBox3;

        private ComboBoxEx comboBox2;

        private ButtonX btnBeginDownLoad;

        private ButtonX button2;

        private CheckBox checkBox3;

        private bool jieshu = false;

        private bool islianji = false;

        private int allsize;

        private int sendsize;

        private string binpath;

        private bool isupdata = false;

        private DateTime uptime = DateTime.Now;

        private appinf0 thisapp0;

        private Comuser mycom = new Comuser();

        private int sk = 0;

        private byte[] Lbytes;

        private List<USARTUP.lasttime> lastsendsize = new List<USARTUP.lasttime>();

        public USARTUP()
        {
            InitializeComponent();
        }
        public USARTUP(string path)
        {
            this.binpath = path;
            this.EnableGlass = false;
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void endsend()
        {
            try
            {
                this.com1.Close();
                this.islianji = false;
                this.isupdata = false;
                this.btnBeginDownLoad.Text = "联机并开始下载".Language();
                this.btnBeginDownLoad.Enabled = true;
                this.button2.Enabled = true;
                this.sendsize = 0;
                TextBox expr_59 = this.textBox2;
                expr_59.Text = expr_59.Text + "已强制中断!".Language() + "\r\n";
                this.timer1.Enabled = false;
                this.comboBox3.Enabled = true;
                this.comboBox2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private byte xinghaotoxilie(string xinghao)
        {
            string a = xinghao.Substring(0, 1);
            int num = 0;
            if (a == "T")
            {
                num = 7;
            }
            else if (a == "N")
            {
                num = 6;
            }
            byte result;
            if (xinghao.Length > num)
            {
                string a2 = xinghao.Substring(num, 1);
                if (a2 == "T")
                {
                    result = 0;
                    return result;
                }
                if (a2 == "K")
                {
                    result = 1;
                    return result;
                }
                if (a2 == "H")
                {
                    result = 2;
                    return result;
                }
            }
            result = 255;
            return result;
        }

        private ushort getbinver(ushort cpuid)
        {
            gujianinf gujianinf = default(gujianinf);
            int num;
            ushort result;
            if (cpuid == 61488 || cpuid == 61489)
            {
                num = 180;
            }
            else
            {
                if (cpuid != 61699)
                {
                    MessageOpen.Show("No Find Cpu Model");
                    result = 65535;
                    return result;
                }
                num = 236;
            }
            StreamReader streamReader = new StreamReader(this.binpath);
            appinf0 appinf = default(appinf0);
            byte[] array = new byte[Marshal.SizeOf(default(appinf0))];
            streamReader.BaseStream.Read(array, 0, array.Length);
            appinf = (appinf0)array.BytesTostruct(default(appinf0).GetType());
            streamReader.BaseStream.Position = (long)((ulong)appinf.hexaddr);
            hexhead hexhead = default(hexhead);
            array = new byte[Marshal.SizeOf(default(hexhead))];
            streamReader.BaseStream.Read(array, 0, array.Length);
            hexhead = (hexhead)array.BytesTostruct(default(hexhead).GetType());
            array = new byte[Marshal.SizeOf(default(FIRMWARE_TABLE))];
            FIRMWARE_TABLE fIRMWARE_TABLE = default(FIRMWARE_TABLE);
            for (int i = 0; i < (int)hexhead.Count; i++)
            {
                streamReader.BaseStream.Read(array, 0, array.Length);
                fIRMWARE_TABLE = (FIRMWARE_TABLE)array.BytesTostruct(default(FIRMWARE_TABLE).GetType());
                if (fIRMWARE_TABLE.CPUID == cpuid)
                {
                    streamReader.BaseStream.Position = (long)((ulong)(appinf.hexaddr + fIRMWARE_TABLE.addr) + (ulong)((long)num));
                    array = new byte[Marshal.SizeOf(default(gujianinf))];
                    streamReader.BaseStream.Read(array, 0, array.Length);
                    result = ((gujianinf)array.BytesTostruct(default(gujianinf).GetType())).ver;
                    return result;
                }
            }
            result = 65535;
            return result;
        }

        private uint getxinghaocrc(string xinghao)
        {
            uint result = 0u;
            if (xinghao.Length > 1)
            {
                string a = xinghao.Substring(xinghao.Length - 1, 1);
                if (a == "R" || a == "N" || a == "C")
                {
                    xinghao = xinghao.Substring(0, xinghao.Length - 1);
                }
                result = xinghao.GetbytesssASCII().getcrc(0);
            }
            return result;
        }

        private bool isqiangzhi(string model)
        {
            bool result;
            if (model.Length != 15 && model.Length != 16)
            {
                result = true;
            }
            else
            {
                string a = model.Substring(model.Length - 1, 1);
                result = (a != "R" && a != "N" && a != "C");
            }
            return result;
        }

        private string getpeizhistr()
        {
            string text = "whmi_set " + this.mycom.touch.ToString();
            try
            {
                string text2 = Convert.ToString((this.mycom.Lcdid & 65280) >> 8, 16);
                if (text2.Length == 1)
                {
                    text2 = "0" + text2;
                }
                text += text2;
                text2 = Convert.ToString(this.mycom.Lcdid & 255, 16);
                if (text2.Length == 1)
                {
                    text2 = "0" + text2;
                }
                text += text2;
                text += ",123";
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                text = "";
            }
            return text;
        }

        private void ComUpdata(bool iscrc)
        {
            uint num = uint.Parse(this.comboBox2.Text);
            this.jieshu = false;
            this.isupdata = false;
            Win32.timeBeginPeriod(1);
            int num2 = 0;
            appinf0 appinf = default(appinf0);
            try
            {
                int num3 = this.mycom.getlianji(this.textBox2, this.comboBox3.Text, 0, true, true, iscrc);
                string text2;
                if (num3 == 1)
                {
                    if (this.getxinghaocrc(this.mycom.xinghao.Trim()) != this.thisapp0.Modelcrc)
                    {
                        string text = this.mycom.xinghao.Trim();
                        if (text.Length > 1)
                        {
                            string a = text.Substring(text.Length - 1, 1);
                            if (a == "R" || a == "N" || a == "C")
                            {
                                text = text.Substring(0, text.Length - 1);
                            }
                        }
                        MessageOpen.Show(string.Concat(new string[]
                        {
                            "当前连接设备的型号与本资源文件中配置的型号不匹配,请重新配置正确的型号后再重新编译资源文件。".Language(),
                            "\r\n",
                            datasize.Getmodelxinxi(this.thisapp0.Modelcrc, (int)this.thisapp0.xilie).Modelstring,
                            " (",
                            "资源文件配置型号".Language(),
                            ")\r\n",
                            text,
                            " (",
                            "设备型号".Language(),
                            ")"
                        }));
                        this.endsend();
                        return;
                    }
                    if (this.getbinver(this.mycom.cpuchip) != this.mycom.gujianver)
                    {
                        MessageOpen.Show("当前连接设备的固件版本号与当前软件不匹配,你可以忽略此警告,当你使用当前软件制作的资源文件下载一次到设备之后设备将会自动升级(升级过程会白屏5-10秒,属于正常现象),之后不会再出现此提示。".Language());
                    }
                    this.islianji = true;
                    TextBox expr_1FA = this.textBox2;
                    text2 = expr_1FA.Text;
                    expr_1FA.Text = string.Concat(new string[]
                    {
                        text2,
                        "强制下载波特率:".Language(),
                        num.ToString(),
                        "  ",
                        "开始下载".Language(),
                        "\r\n"
                    });
                }
                else if (num3 != 2)
                {
                    if (num3 != 3)
                    {
                        this.endsend();
                        return;
                    }
                    if (this.mycom.gujianver <= 50 || this.mycom.gujianver >= 55 || !this.isqiangzhi(this.mycom.xinghao))
                    {
                        this.endsend();
                        return;
                    }
                    if (MessageOpen.Show("检测到非法型号，是否需要强制下载?".Language(), "提示".Language(), MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        this.endsend();
                        return;
                    }
                    string text = this.getpeizhistr();
                    if (text.Length < 5)
                    {
                        this.endsend();
                        return;
                    }
                    this.com1.sendstring_End("00", false, null);
                    this.com1.sendstring_End(text, false, null);
                    for (num3 = 0; num3 != 1; num3 = this.mycom.getlianji(this.textBox2, this.comboBox3.Text, 0, false, true, iscrc))
                    {
                        if (MessageOpen.Show("请给设备重新上电,重新上电之后可能出现花屏或者黑屏现象是正常的，重新上电后继续强制下载点击 是 退出强制下载点击 否 ".Language(), "提示".Language(), MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            this.endsend();
                            return;
                        }
                    }
                    num3 = 3;
                }
                if (num3 == 1 || num3 == 3)
                {
                    StreamReader streamReader = new StreamReader(this.binpath);
                    this.allsize = (int)streamReader.BaseStream.Length;
                    this.Lbytes = new byte[this.allsize];
                    streamReader.BaseStream.Read(this.Lbytes, 0, this.Lbytes.Length);
                    streamReader.Close();
                    if (num3 == 3)
                    {
                        byte[] bytes = this.Lbytes.subbytes(0, datasize.appxinxisize0);
                        appinf = (appinf0)bytes.BytesTostruct(default(appinf0).GetType());
                        appinf.Modelcrc = "123".GetbytesssASCII().getcrc(0);
                        appinf.structToBytes().CopyTo(this.Lbytes, 0);
                        uint num4 = this.Lbytes.getcrc(4294967295u, 0, this.Lbytes.Length - 4);
                        num4 ^= (uint)((byte)appinf.Modelcrc);
                        num4 ^= (uint)appinf.mark;
                        num4 ^= (uint)((byte)appinf.datasize);
                        num4.structToBytes().CopyTo(this.Lbytes, this.Lbytes.Length - 4);
                    }
                    string text = string.Concat(new string[]
                    {
                        "whmi-wri ",
                        this.allsize.ToString(),
                        ",",
                        num.ToString(),
                        ",",
                        this.thisapp0.banbenh.ToString()
                    });
                    this.com1.sendstring_End("00", false, null);
                    this.com1.sendstring_End(text, false, null);
                    if (this.com1.BaudRate != (int)num)
                    {
                        Thread.Sleep(100);
                        this.com1.Close();
                        this.com1.BaudRate = (int)num;
                        this.com1.Open();
                    }
                }
                this.sendsize = 0;
                this.btnBeginDownLoad.Enabled = true;
                this.btnBeginDownLoad.Text = "停止".Language();
                this.sk = 0;
                this.isupdata = true;
                while (true)
                {
                    Application.DoEvents();
                    if (this.jieshu)
                    {
                        break;
                    }
                    this.sk = 0;
                    while (this.sk != 5)
                    {
                        Application.DoEvents();
                        Thread.Sleep(2);
                        num2++;
                        if (num2 > 500)
                        {
                            if (this.sendsize == 0)
                            {
                                this.com1.Close();
                                this.com1.BaudRate = this.mycom.botelv;
                                this.com1.Open();
                                Thread.Sleep(100);
                                string text = string.Concat(new string[]
                                {
                                    "tjchmi-wri ",
                                    this.allsize.ToString(),
                                    ",",
                                    num.ToString(),
                                    ",",
                                    this.thisapp0.banbenh.ToString()
                                });
                                this.com1.sendstring_End("00", false, null);
                                this.com1.sendstring_End(text, false, null);
                                Thread.Sleep(100);
                                this.com1.Close();
                                this.com1.BaudRate = (int)num;
                                this.com1.Open();
                            }
                            num2 = 0;
                        }
                        if (this.jieshu)
                        {
                            goto Block_26;
                        }
                        while (this.com1.BytesToRead > 0)
                        {
                            int num5 = this.com1.ReadByte();
                            if (num5 == 5)
                            {
                                this.sk = 5;
                            }
                            else if (num5 == 6)
                            {
                                goto Block_28;
                            }
                        }
                    }
                    Thread.Sleep(5);
                    if (this.com1.IsOpen)
                    {
                        while (this.com1.BytesToRead > 0)
                        {
                            int num5 = this.com1.ReadByte();
                            if (num5 == 5)
                            {
                                this.sk = 5;
                            }
                        }
                    }
                    this.sk = 0;
                    if (this.sendsize >= this.allsize)
                    {
                        goto Block_32;
                    }
                    if (this.sendsize == 0)
                    {
                        Thread.Sleep(400);
                        this.lastsendsize.Clear();
                        this.lastsendsize.Add(new USARTUP.lasttime
                        {
                            lastsendsize = 0,
                            dt = DateTime.Now
                        });
                        this.uptime = DateTime.Now;
                        this.timer1.Enabled = true;
                    }
                    if (this.allsize - this.sendsize >= 4096)
                    {
                        if (num >= 57600u)
                        {
                            this.com1.Write(this.Lbytes, this.sendsize, 4096);
                            this.sendsize += 4096;
                        }
                        else
                        {
                            this.com1.Write(this.Lbytes, this.sendsize, 1024);
                            this.sendsize += 1024;
                            Application.DoEvents();
                            this.com1.Write(this.Lbytes, this.sendsize, 1024);
                            this.sendsize += 1024;
                            Application.DoEvents();
                            this.com1.Write(this.Lbytes, this.sendsize, 1024);
                            this.sendsize += 1024;
                            Application.DoEvents();
                            this.com1.Write(this.Lbytes, this.sendsize, 1024);
                            this.sendsize += 1024;
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        this.com1.Write(this.Lbytes, this.sendsize, this.allsize - this.sendsize);
                        this.sendsize = this.allsize;
                    }
                }
                this.endsend();
                return;
                Block_26:
                this.endsend();
                return;
                Block_28:
                MessageOpen.Show("串口通讯产生错误".Language());
                this.jieshu = true;
                this.endsend();
                return;
                Block_32:
                TimeSpan timeSpan = DateTime.Now.Subtract(this.uptime);
                this.showdown();
                this.com1.Close();
                this.isupdata = false;
                this.islianji = false;
                TextBox expr_8AF = this.textBox2;
                text2 = expr_8AF.Text;
                expr_8AF.Text = string.Concat(new string[]
                {
                    text2,
                    "下载完成!总耗时:".Language(),
                    timeSpan.Hours.ToString(),
                    "时".Language(),
                    timeSpan.Minutes.ToString(),
                    "分".Language(),
                    timeSpan.Seconds.ToString(),
                    "秒".Language(),
                    "\r\n"
                });
                this.button2.Enabled = true;
                this.timer1.Enabled = false;
                this.comboBox3.Enabled = true;
                this.comboBox2.Enabled = true;
                this.btnBeginDownLoad.Enabled = true;
                this.btnBeginDownLoad.Text = "联机并开始下载".Language();
                if (num3 == 3)
                {
                    MessageOpen.Show("强制下载已经结束,请给设备重新上电".Language() + "\r\n" + "设备重新上电之后可能会白屏5-10秒(内部固件升级),然后会出现提示:Please re download the resource file 如果看到此提示说明强制下载成功,再次按正常流程下载一次即可!".Language());
                }
            }
            catch (Exception ex)
            {
                this.endsend();
                MessageOpen.Show(ex.Message);
            }
        }

        private void getports()
        {
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
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("获取计算机COM口列表失败!".Language() + "\r\n" + "错误信息:".Language() + ex.Message);
            }
            this.comboBox3.SelectedIndex = 0;
        }

        private void USARTUP_Load(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(this.binpath);
            this.allsize = (int)streamReader.BaseStream.Length;
            ushort num = (ushort)Marshal.SizeOf(default(appinf0));
            if (streamReader.BaseStream.Length < (long)(num + 3))
            {
                MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language());
                streamReader.Close();
                streamReader.Dispose();
                base.Close();
            }
            byte[] array = new byte[(int)num];
            streamReader.BaseStream.Read(array, 0, (int)num);
            this.thisapp0 = (appinf0)array.BytesTostruct(default(appinf0).GetType());
            if (this.thisapp0.mark != datasize.hmibiaoshiL)
            {
                MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language());
                streamReader.Close();
                streamReader.Dispose();
                base.Close();
            }
            streamReader.Close();
            streamReader.Dispose();
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.Add("2400");
            this.comboBox2.Items.Add("4800");
            this.comboBox2.Items.Add("9600");
            this.comboBox2.Items.Add("19200");
            this.comboBox2.Items.Add("38400");
            this.comboBox2.Items.Add("57600");
            this.comboBox2.Items.Add("115200");
            this.comboBox2.Text = "115200";
            this.getports();
            this.mycom.com1 = this.com1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.mycom.comclose();
            base.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (this.isupdata)
            {
                this.showdown();
            }
            this.timer1.Enabled = true;
        }

        private void showdown()
        {
            this.lastsendsize.Add(new USARTUP.lasttime
            {
                lastsendsize = this.sendsize,
                dt = DateTime.Now
            });
            while (this.lastsendsize.Count > 5)
            {
                this.lastsendsize.Remove(this.lastsendsize[0]);
            }
            if (this.lastsendsize.Count > 1)
            {
                long num;
                if (DateTime.Now.Subtract(this.lastsendsize[0].dt).Seconds == 0)
                {
                    num = 0L;
                }
                else
                {
                    num = (long)((this.sendsize - this.lastsendsize[0].lastsendsize) / DateTime.Now.Subtract(this.lastsendsize[0].dt).Seconds);
                }
                if (num > 0L)
                {
                    this.label2.Text = string.Concat(new string[]
                    {
                        "文件大小:".Language(),
                        this.allsize.ToString(),
                        " ",
                        "已下载:".Language(),
                        this.sendsize.ToString(),
                        " ",
                        "下载速度:".Language(),
                        num.ToString(),
                        " ",
                        "预计剩余时间:".Language(),
                        ((long)(this.allsize - this.sendsize) / num).ToString(),
                        "秒".Language()
                    });
                }
                else
                {
                    this.label2.Text = string.Concat(new string[]
                    {
                        "文件大小:".Language(),
                        this.allsize.ToString(),
                        " ",
                        "已下载:".Language(),
                        this.sendsize.ToString(),
                        " ",
                        "下载速度:".Language(),
                        num.ToString(),
                        " ",
                        "预计剩余时间:".Language(),
                        "---"
                    });
                    if (this.lastsendsize.Count == 5 && this.lastsendsize[0].lastsendsize == this.lastsendsize[4].lastsendsize)
                    {
                        this.lastsendsize.Clear();
                        if (MessageOpen.Show("通讯超时,需要继续等待设备回应吗？".Language(), "通讯超时".Language(), MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            this.jieshu = true;
                            this.lastsendsize.Clear();
                        }
                    }
                }
            }
        }

        private void USARTUP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.mycom.State != 0)
            {
                this.mycom.State = 2;
                e.Cancel = true;
            }
            else if (this.islianji || !this.btnBeginDownLoad.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint num = uint.Parse(this.comboBox2.Text);
            num /= 9u;
            this.label2.Text = string.Concat(new string[]
            {
                "文件大小:".Language(),
                this.allsize.ToString(),
                " ",
                "预计下载时间:".Language(),
                ((long)this.allsize / (long)((ulong)num)).ToString(),
                "秒".Language()
            });
        }

        #region 联机并开始下载
        private void btnBeginDownLoad_Click(object sender, EventArgs e)
        {
            this.btnBeginDownLoad.Enabled = false;
            this.button2.Enabled = false;
            this.comboBox3.Enabled = false;
            this.comboBox2.Enabled = false;
            bool iscrc = false;
            if (this.checkBox3.Visible && this.checkBox3.Checked)
            {
                iscrc = true;
            }
            if (!this.islianji)
            {
                if (this.comboBox2.Text == "")
                {
                    MessageOpen.Show("请选择下载使用的波特率".Language());
                    this.btnBeginDownLoad.Enabled = true;
                }
                else if (this.comboBox3.Text == "")
                {
                    MessageOpen.Show("请选择串口号".Language());
                    this.btnBeginDownLoad.Enabled = true;
                }
                else
                {
                    this.ComUpdata(iscrc);
                }
            }
            else
            {
                this.timer1.Enabled = false;
                if (MessageOpen.Show("确认要停止下载吗?,停止下载会导致你的设备中的数据文件不完整，设备再次开机将无法正常使用，需要您再次重新完整下载一次资源文件!".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.jieshu = true;
                }
                else
                {
                    this.btnBeginDownLoad.Enabled = true;
                }
                this.timer1.Enabled = true;
            }
        }

        #endregion
    }
}