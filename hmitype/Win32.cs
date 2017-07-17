using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hmitype
{
    public static class Win32
    {
        [StructLayout(LayoutKind.Sequential)]
        public class SystemTime
        {
            public ushort wYear;

            public ushort wMonth;

            public ushort wDayOfWeek;

            public ushort wDay;

            public ushort Whour;

            public ushort wMinute;

            public ushort wSecond;

            public ushort wMilliseconds;
        }

        private static Thread uclient;

        private static Thread ugetvertime;

        private static int getvershorttime = 0;

        private static int getverlongtime = 0;

        private static bool getvertishi_ok = false;

        private static bool getvertishi_err = false;

        private static bool getverautoshowdown = false;

        private static int getver_retry = 0;

        private static int getver_retrytime = 0;

        private static int islogin = 0;

        private static int findchaotime = 0;

        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(Win32.SystemTime st);

        [DllImport("winmm")]
        public static extern void timeBeginPeriod(int t);

        [DllImport("winmm")]
        public static extern void timeEndPeriod(int t);

        [DllImport("Kernel32.dll")]
        public static extern void SetLocalTime(Win32.SystemTime st);

        public static uint Win32GetTime(DateTime tt)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(tt);
            return (uint)(timeSpan.Milliseconds + timeSpan.Seconds * 1000 + timeSpan.Minutes * 1000 * 60);
        }

        public static void clientup()
        {
            if (datasize.clientuptime > 0)
            {
                if (Win32.uclient == null)
                {
                    Win32.uclient = new Thread(new ThreadStart(Win32.uuclientup));
                    Win32.uclient.Start();
                }
            }
        }

        private static void uuclientup()
        {
            int num = 0;
            string text = "";
            string address = datasize.clientupaddr + "?state=up";
            WebClient webClient = new WebClient();
            while (true)
            {
                text = "";
                num = 0;
                while (!text.Contains("ok") && num < 3)
                {
                    try
                    {
                        Thread.Sleep(1000);
                        text = Encoding.UTF8.GetString(webClient.DownloadData(address));
                        num++;
                    }
                    catch
                    {
                    }
                }
                for (int i = 0; i < datasize.clientuptime; i++)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public static void gethmiver(int shortms, int longms, int retry, int retrytime, bool tishi_ok, bool tishi_err, bool showdown, int islogin_)
        {
            Win32.timeBeginPeriod(1);
            if (Win32.ugetvertime != null && Win32.ugetvertime.IsAlive)
            {
                MessageOpen.Show("正在查询中".Language());
            }
            else
            {
                Win32.islogin = islogin_;
                Win32.getver_retry = retry;
                Win32.getver_retrytime = retrytime;
                Win32.getvertishi_ok = tishi_ok;
                Win32.getvertishi_err = tishi_err;
                Win32.getverautoshowdown = showdown;
                Win32.getvershorttime = shortms;
                Win32.getverlongtime = longms;
                datasize.findendstate = false;
                Win32.ugetvertime = new Thread(new ThreadStart(Win32.getvertime));
                Win32.ugetvertime.Start();
            }
        }

        private static void getvertime()
        {
            Win32.timeBeginPeriod(1);
            int i = Win32.getver_retry;
            int num = Win32.getvershorttime;
            Win32.findchaotime = Win32.getverlongtime;
            int num2 = 100;
            try
            {
                while (i >= 0)
                {
                    int j = 0;
                    Thread thread = new Thread(new ThreadStart(Win32.findver));
                    thread.Start();
                    while (j < Win32.findchaotime)
                    {
                        Thread.Sleep(num2);
                        if (!thread.IsAlive && j > num)
                        {
                            i = -1;
                            break;
                        }
                        j += num2;
                    }
                    if (thread.IsAlive)
                    {
                        thread.Abort();
                    }
                    i--;
                    Win32.findchaotime = Win32.getver_retrytime;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
            if (datasize.dowloadurl == "")
            {
                if (Win32.getvertishi_ok)
                {
                    MessageOpen.Show("当前版本已是最新版本!".Language());
                }
            }
            else if (datasize.dowloadurl == "err")
            {
                if (Win32.getvertishi_err)
                {
                    MessageOpen.Show("服务器连接失败,无法检测最新版本,请检查你的网络连接,以确保你使用的是最新的HMI编辑软件".Language());
                }
            }
            else if (Win32.getverautoshowdown)
            {
                new download(datasize.dowloadurl).ShowDialog();
            }
            datasize.findendstate = true;
        }

        private static void findver()
        {
            WebClient webClient = new WebClient();
            datasize.dowloadurl = "err";
            datasize.guangdaos.Clear();
            datasize.mesgtim = 0;
            while (datasize.dowloadurl == "err")
            {
                try
                {
                    string str = WebClientString.Getstring(string.Concat(new string[]
                    {
                        datasize.verfindaddr,
                        "?state=0&login=",
                        Win32.islogin.ToString(),
                        "&encode=",
                        Encoding.Default.BodyName,
                        "&myid=",
                        datasize.myid,
                        "&dver=",
                        datasize.banbenh.ToString(),
                        ".",
                        datasize.banbenl.ToString()
                    }));
                    string[] array = str.getziduanstr("&*@ver=").Split(new char[]
                    {
                        '.'
                    });
                    if (array.Length == 2)
                    {
                        datasize.interbanbenh = byte.Parse(array[0].Trim());
                        datasize.interbanbenl = byte.Parse(array[1].Trim());
                        datasize.clientuptime = str.getziduanstr("&*@ct=").Getint();
                        datasize.tanchuangid = str.getziduanstr("&*@st0=").Getint();
                        datasize.tanchuangurl = str.getziduanstr("&*@st1=");
                        datasize.mesgtim = str.getziduanstr("&*@mesgtim=").Getint() * 1000;
                        if (datasize.Language == 0)
                        {
                            datasize.loginjpgurl = str.getziduanstr("&*@jpg=");
                            datasize.loginjpgnum = str.getziduanstr("&*@jpgnum=").Getint();
                        }
                        if (datasize.mesgtim > 900 && datasize.mesgtim < 6500000)
                        {
                            array = str.getziduanstr("&*@mesg=").Trim().Replace("\r\n", "\r").Split(new char[]
                            {
                                '\r'
                            });
                            string[] array2 = array;
                            for (int i = 0; i < array2.Length; i++)
                            {
                                string text = array2[i];
                                string text2 = text.Trim();
                                if (text2.Length > 1)
                                {
                                    string[] array3 = text2.Replace("%^", "\r").Split(new char[]
                                    {
                                        '\r'
                                    });
                                    if (array3.Length > 1)
                                    {
                                        datasize.guangdaos.Add(new guanggaotype
                                        {
                                            str = array3[0],
                                            url = array3[1]
                                        });
                                    }
                                    else
                                    {
                                        datasize.guangdaos.Add(new guanggaotype
                                        {
                                            str = array3[0],
                                            url = ""
                                        });
                                    }
                                }
                            }
                        }
                        if (datasize.banbenh == datasize.interbanbenh && datasize.banbenl == datasize.interbanbenl)
                        {
                            datasize.dowloadurl = "";
                            if (datasize.clientuptime > 0)
                            {
                                Win32.clientup();
                            }
                            break;
                        }
                        datasize.downloadpage = str.getziduanstr("&*@downadd=");
                        datasize.dowloadurl = str.getziduanstr("&*@exeadd=");
                        datasize.uptext = str.getziduanstr("&*@uptext=");
                        if (!(datasize.dowloadurl == ""))
                        {
                            break;
                        }
                        datasize.dowloadurl = "err";
                    }
                }
                catch
                {
                    datasize.dowloadurl = "err";
                }
                for (int j = 0; j < 10; j++)
                {
                   
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
            }
        }

        private static string getziduanstr(this string str, string ziduan)
        {
            int num = Win32.findstr(str, ziduan, 0);
            string result;
            if (num == -1)
            {
                result = "";
            }
            else
            {
                num += ziduan.Length;
                int num2 = Win32.findstr(str, "&*@", num);
                if (num2 == -1)
                {
                    num2 = str.Length;
                }
                num2--;
                if (num > num2)
                {
                    result = "";
                }
                else
                {
                    string text = str.Substring(num, num2 - num + 1);
                    result = text;
                }
            }
            return result;
        }

        private static int findstr(string str, string find, int beg)
        {
            int length = str.Length;
            int length2 = find.Length;
            int result;
            if (str.Contains(find))
            {
                for (int i = beg; i <= length - length2; i++)
                {
                    if (str.Substring(i, length2) == find)
                    {
                        result = i;
                        return result;
                    }
                }
            }
            result = -1;
            return result;
        }

        private static string GetMacAddress()
        {
            string result;
            try
            {
                string text = "";
                ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        if ((bool)managementObject["IPEnabled"])
                        {
                            text = managementObject["MacAddress"].ToString().Trim();
                            if (text != "")
                            {
                                break;
                            }
                        }
                    }
                }
                if (text == "")
                {
                    text = "0000";
                }
                result = text;
            }
            catch
            {
                result = "0000";
            }
            return result;
        }

        private static string GetDiskID()
        {
            string result;
            try
            {
                string text = "";
                ManagementClass managementClass = new ManagementClass("Win32_PhysicalMedia");
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        text = managementObject.Properties["SerialNumber"].Value.ToString().Trim();
                        if (text != "")
                        {
                            break;
                        }
                    }
                }
                if (text == "")
                {
                    text = "0000";
                }
                result = text;
            }
            catch
            {
                result = "0000";
            }
            return result;
        }

        private static string GetMotherBoardSerialNumber()
        {
            string result;
            try
            {
                string text = "";
                ManagementClass managementClass = new ManagementClass("WIN32_BaseBoard");
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        text = managementObject["SerialNumber"].ToString().Trim();
                        if (text != "")
                        {
                            break;
                        }
                    }
                }
                if (text == "")
                {
                    text = "0000";
                }
                result = text;
            }
            catch
            {
                result = "0000";
            }
            return result;
        }

        public static string GetMyID()
        {
            string result;
            try
            {
                string text = Win32.GetMotherBoardSerialNumber();
                string text2 = Win32.GetDiskID();
                string text3 = Win32.GetMacAddress();
                if (text != "0000")
                {
                    text = Strmake.Strmake_BytesToStr16(Encoding.ASCII.GetBytes(text).getcrc(0).structToBytes());
                }
                if (text2 != "0000")
                {
                    text2 = Strmake.Strmake_BytesToStr16(Encoding.ASCII.GetBytes(text2).getcrc(0).structToBytes());
                }
                if (text3 != "0000")
                {
                    text3 = Strmake.Strmake_BytesToStr16(Encoding.ASCII.GetBytes(text3).getcrc(0).structToBytes());
                }
                result = string.Concat(new string[]
                {
                    text,
                    "-",
                    text2,
                    "-",
                    text3
                });
            }
            catch
            {
                result = "error";
            }
            return result;
        }
    }
}
