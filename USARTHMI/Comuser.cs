using hmitype;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace USARTHMI
{
    internal class Comuser
    {
        public SerialPort com1;

        private List<int> Bot = new List<int>();

        private List<string> lcoms = new List<string>();

        public string xinghao = "";

        public int touch = 0;

        public ushort gujianver;

        public ushort cpuchip;

        public string FlashIDstring = "";

        public int Lcdid = 0;

        private string Oldcom = "";

        private int Oldbo = 0;

        private int FlashSize = 0;

        public int botelv;

        public int xilie;

        public int State = 0;

        private bool islaodmessage = true;

        public Comuser()
        {
            this.Bot.Clear();
            this.Bot.Add(2400);
            this.Bot.Add(4800);
            this.Bot.Add(9600);
            this.Bot.Add(19200);
            this.Bot.Add(38400);
            this.Bot.Add(57600);
            this.Bot.Add(115200);
            this.Oldbo = Kuozhan.getxmlstring("oldbo_").Getint();
            this.Oldcom = Kuozhan.getxmlstring("oldcom_");
        }

        public int Getcomstr()
        {
            int num = 0;
            byte[] array = new byte[500];
            PosLaction posLaction = default(PosLaction);
            PosLaction[] array2 = new PosLaction[30];
            int result;
            try
            {
                while (this.com1.BytesToRead > 0)
                {
                    array[num] = (byte)this.com1.ReadByte();
                    num++;
                    if (num > 499)
                    {
                        break;
                    }
                }
                num -= 4;
                if (num < 1)
                {
                    result = 0;
                    return result;
                }
                posLaction.star = 0;
                posLaction.end = (ushort)num;
                int num2 = (int)Strmake.Strmake_StrSubstring(ref array, ref posLaction, "comok ", 1);
                this.FlashSize = 0;
                if (num2 != 65535)
                {
                    posLaction.star = (ushort)(num2 + 1);
                    if (Strmake.Strmake_StrGetcanshu(ref array, ref posLaction, ref array2, 7) == 1)
                    {
                        this.touch = array2[0].PosByteGetstring(array).Getint();
                        this.Lcdid = array2[1].PosByteGetstring(array).Getint();
                        this.xinghao = array2[2].PosByteGetstring(array);
                        this.gujianver = (ushort)((byte)array2[3].PosByteGetstring(array).Getint());
                        this.cpuchip = (ushort)array2[4].PosByteGetstring(array).Getint();
                        this.FlashIDstring = array2[5].PosByteGetstring(array);
                        this.FlashSize = array2[6].PosByteGetstring(array).Getint();
                        string text = this.xinghao.Trim();
                        modelxinxi modelxinxi;
                        if (text.Length > 1)
                        {
                            string a = text.Substring(text.Length - 1, 1);
                            if (a == "R" || a == "N" || a == "C")
                            {
                                text = text.Substring(0, text.Length - 1);
                            }
                            else
                            {
                                this.xilie = 0;
                                modelxinxi = datasize.Getmodelxinxi("123", this.xilie);
                                if (this.islaodmessage)
                                {
                                    MessageOpen.Show("非法型号".Language() + this.xinghao);
                                    result = 3;
                                    return result;
                                }
                                result = 1;
                                return result;
                            }
                        }
                        this.xilie = 0;
                        modelxinxi = datasize.Getmodelxinxi(text, this.xilie);
                        if (modelxinxi.Modelstring == "")
                        {
                            this.xilie = 1;
                            modelxinxi = datasize.Getmodelxinxi(text, this.xilie);
                        }
                        if (!(modelxinxi.Modelstring == ""))
                        {
                            result = 1;
                            return result;
                        }
                        if (this.islaodmessage)
                        {
                            MessageOpen.Show("非法型号".Language() + this.xinghao);
                            result = 3;
                            return result;
                        }
                        result = 1;
                        return result;
                    }
                    else if (Strmake.Strmake_StrGetcanshu(ref array, ref posLaction, ref array2, 6) == 1)
                    {
                        this.touch = array2[0].PosByteGetstring(array).Getint();
                        this.Lcdid = array2[1].PosByteGetstring(array).Getint();
                        this.xinghao = array2[2].PosByteGetstring(array);
                        this.gujianver = (ushort)((byte)array2[4].PosByteGetstring(array).Getint());
                        this.gujianver *= 256;
                        this.gujianver += (ushort)((byte)array2[3].PosByteGetstring(array).Getint());
                        this.FlashIDstring = array2[5].PosByteGetstring(array);
                        string text = this.xinghao.Trim();
                        modelxinxi modelxinxi;
                        if (text.Length > 1)
                        {
                            string a = text.Substring(text.Length - 1, 1);
                            if (a == "R" || a == "N" || a == "C")
                            {
                                text = text.Substring(0, text.Length - 1);
                            }
                            else
                            {
                                this.xilie = 0;
                                modelxinxi = datasize.Getmodelxinxi("123", this.xilie);
                                if (this.islaodmessage)
                                {
                                    MessageOpen.Show("非法型号".Language() + this.xinghao);
                                    result = 3;
                                    return result;
                                }
                                result = 1;
                                return result;
                            }
                        }
                        this.xilie = 0;
                        modelxinxi = datasize.Getmodelxinxi(text, this.xilie);
                        if (modelxinxi.Modelstring == "")
                        {
                            this.xilie = 1;
                            modelxinxi = datasize.Getmodelxinxi(text, this.xilie);
                        }
                        if (!(modelxinxi.Modelstring == ""))
                        {
                            result = 1;
                            return result;
                        }
                        if (this.islaodmessage)
                        {
                            MessageOpen.Show("非法型号".Language() + this.xinghao);
                            result = 3;
                            return result;
                        }
                        result = 1;
                        return result;
                    }
                }
                else
                {
                    num2 = (int)Strmake.Strmake_StrSubstring(ref array, ref posLaction, "downbin", 1);
                    if (num2 != 65535)
                    {
                        result = 2;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = 0;
                return result;
            }
            result = 0;
            return result;
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
                if (this.lcoms.Count == 1)
                {
                    MessageOpen.Show(ex.Message);
                }
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
            catch
            {
            }
        }

        public int getlianji(TextBox text1, string portname, int bo, bool islaodmessage_, bool qiangzhi, bool iscrc)
        {
            this.State = 1;
            int result = this.lianji(text1, portname, bo, islaodmessage_, qiangzhi, iscrc);
            this.State = 0;
            return result;
        }

        private int lianji(TextBox text1, string portname, int bo, bool islaodmessage_, bool qiangzhi, bool iscrc)
        {
            this.islaodmessage = islaodmessage_;
            List<int> list = new List<int>();
            list.Clear();
            this.lcoms.Clear();
            if (bo == 0 && this.Oldbo > 0)
            {
                list.Add(this.Oldbo);
            }
            if ((portname == "" || portname.Contains("自动搜索".Language())) && this.Oldcom != "")
            {
                this.lcoms.Add(this.Oldcom);
            }
            if (bo == 0)
            {
                foreach (int current in this.Bot)
                {
                    list.Add(current);
                }
            }
            else
            {
                list.Add(bo);
            }
            if (portname == "" || portname.Contains("自动搜索".Language()))
            {
                try
                {
                    string[] portNames = SerialPort.GetPortNames();
                    string[] array = portNames;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string item = array[i];
                        this.lcoms.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageOpen.Show("获取计算机COM口列表失败!\r\n错误信息:".Language() + ex.Message);
                }
            }
            else
            {
                this.lcoms.Add(portname);
            }
            int result;
            foreach (string current2 in this.lcoms)
            {
                Win32.timeBeginPeriod(1);
                for (int j = 0; j < list.Count; j++)
                {
                    if (this.State == 2)
                    {
                        this.comclose();
                        text1.Text = "联机失败".Language() + "\r\n";
                        result = 0;
                        return result;
                    }
                    text1.Text = string.Concat(new string[]
                    {
                        "尝试联机".Language(),
                        current2,
                        ":",
                        list[j].ToString(),
                        "\r\n"
                    });
                    this.comclose();
                    if (this.comopen(current2, list[j]))
                    {
                        this.Cleargetbuff();
                        this.Doyanshi(400);
                        this.com1.sendstring_End("00", iscrc, null);
                        this.com1.sendstring_End("connect", iscrc, null);
                        int yanshi = 1800000 / list[j] + 50;
                        this.Doyanshi(yanshi);
                        int num = this.Getcomstr();
                        if (num == 1)
                        {
                            string text2 = "S" + this.gujianver.ToString();
                            this.botelv = list[j];
                            string text3 = "none";
                            if (this.touch == 0)
                            {
                                text3 = "不带触摸".Language();
                            }
                            if (this.touch == 1)
                            {
                                text3 = "电阻式触摸".Language();
                            }
                            if (this.touch == 2)
                            {
                                text3 = "电容式触摸".Language();
                            }
                            text1.Text = string.Concat(new string[]
                            {
                                "联机成功!串口号:".Language(),
                                current2,
                                ",设备当前波特率:".Language(),
                                this.botelv.ToString(),
                                ",",
                                "设备型号:".Language(),
                                this.xinghao,
                                "(",
                                text3,
                                ")",
                                ",固件版本:".Language(),
                                text2,
                                ",",
                                "设备序列号:".Language(),
                                this.FlashIDstring,
                                ",CPUID:",
                                this.cpuchip.ToString(),
                                ",",
                                "Flash容量:".Language(),
                                this.FlashSize.ToString(),
                                "(",
                                (this.FlashSize / 1024 / 1024).ToString(),
                                "MB)\r\n"
                            });
                            this.com1.sendstring_End("runmod=2", iscrc, null);
                            this.jiance(yanshi, qiangzhi, iscrc);
                            this.com1.sendstring_End("runmod=0", iscrc, null);
                            this.Cleargetbuff();
                            Kuozhan.putxmlstring(list[j].ToString(), "oldbo_");
                            Kuozhan.putxmlstring(current2, "oldcom_");
                            this.Oldbo = list[j];
                            this.Oldcom = current2;
                            result = 1;
                            return result;
                        }
                        if (num == 2)
                        {
                            text1.Text = "进入设备固件恢复!".Language() + "\r\n";
                            result = 2;
                            return result;
                        }
                        if (num == 3)
                        {
                            result = 3;
                            return result;
                        }
                    }
                }
            }
            text1.Text = "联机失败".Language() + "\r\n";
            result = 0;
            return result;
        }

        private void jiance(int yanshi, bool qiangzhi, bool iscrc)
        {
            byte[] array = new byte[500];
            try
            {
                this.com1.sendstring_End("print \"mystop_yes\"", iscrc, null);
                if (this.DoeventsComStr("mystop_yes", 200) != 0)
                {
                    this.Cleargetbuff();
                    this.com1.sendstring_End("get sleep", iscrc, null);
                    this.com1.sendstring_End("get dim", iscrc, null);
                    this.Doyanshi(yanshi);
                    int num = 0;
                    while (this.com1.BytesToRead > 0)
                    {
                        array[num] = (byte)this.com1.ReadByte();
                        num++;
                        if (num > 499)
                        {
                            break;
                        }
                    }
                    if (num == 16)
                    {
                        if (array[0] == 113 && array[1] == 1)
                        {
                            if (qiangzhi)
                            {
                                this.com1.sendstring_End("sleep=0", iscrc, null);
                            }
                            else
                            {
                                if (MessageOpen.Show("设备处于休眠状态,是否需要立刻唤醒? ".Language(), "确认".Language(), MessageBoxButtons.YesNo) != DialogResult.Yes)
                                {
                                    return;
                                }
                                this.com1.sendstring_End("sleep=0", iscrc, null);
                            }
                        }
                        this.Doyanshi(50);
                        if (array[8] == 113 && array[9] < 5)
                        {
                            if (qiangzhi)
                            {
                                this.com1.sendstring_End("dim=100", iscrc, null);
                            }
                            else if (MessageOpen.Show("设备亮度极低,是否需要立刻设置到最高亮度? ".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                this.com1.sendstring_End("dim=100", iscrc, null);
                            }
                        }
                        this.Doyanshi(yanshi);
                        this.Cleargetbuff();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private byte DoeventsComStr(string str, int chaotim)
        {
            byte[] array = new byte[1000];
            PosLaction posLaction = default(PosLaction);
            int num = 0;
            byte result;
            while (chaotim > 0)
            {
                while (this.com1.BytesToRead > 0)
                {
                    array[num] = (byte)this.com1.ReadByte();
                    num++;
                    if (num > 999)
                    {
                        break;
                    }
                }
                if (num > 0)
                {
                    posLaction.star = 0;
                    posLaction.end = (ushort)(num - 1);
                }
                if (Strmake.Strmake_StrSubstring(ref array, ref posLaction, str, 1) != 65535)
                {
                    result = 1;
                    return result;
                }
                chaotim -= 10;
                this.Doyanshi(10);
            }
            result = 0;
            return result;
        }

        private void Doyanshi(int yanshi)
        {
            while (yanshi > 1 && this.State == 1)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                yanshi--;
            }
        }

        public void Cleargetbuff()
        {
            while (this.com1.BytesToRead > 0)
            {
                int num = this.com1.ReadByte();
            }
        }
    }
}
