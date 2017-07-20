


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using hmitype;
using USARTHMI.Properties;

namespace USARTHMI

{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string text = Application.StartupPath + "\\hmics.lang";
            if (!File.Exists(text))
            {
                MessageOpen.Show("The file is missing:" + text);
                Application.Exit();
            }
            else
            {
                Kuozhan.LanguageInit();
                datasize.Language = 0;
                if (datasize.Language == 0)
                {
                    datasize.Myencoding = Encoding.GetEncoding("gb2312");
                    datasize.Objzhushiencoding = Encoding.GetEncoding("gb2312");
                    datasize.hmibiaoshiL = 84;
                    datasize.softname = "USART HMI";
                    datasize.Myico = Resources.tjcico;
                    datasize.verfindaddr = "http://hmi.tjc1688.com/ver/ver.php";
                    datasize.clientupaddr = "http://hmi.tjc1688.com/ver/up.php";
                    datasize.encodes_This = datasize.encodes_Ch;
                }
                else
                {
                    datasize.Myencoding = Encoding.GetEncoding("iso-8859-1");
                    datasize.Objzhushiencoding = Encoding.GetEncoding("iso-8859-1");
                    datasize.hmibiaoshiL = 78;
                    datasize.softname = "Nextion Editor";
                    datasize.Myico = Resources.iteadico;
                    datasize.verfindaddr = "http://nextion.itead.cc/ver/ver.php";
                    datasize.clientupaddr = "http://nextion.itead.cc/ver/up.php";
                    datasize.encodes_This = datasize.encodes_En;
                }
                datasize.Modelinit();
                guidatamake.GuidataAppinit();
                datasize.hmibiaoshiH = Convert.ToByte(datasize.hmibiaoshiL + 1);
                Kuozhan.Getlinpath();
                Kuozhan.delkuozhanfile(datasize.linpath, "ca");
                DateTime now = DateTime.Now;
                datasize.runfilepath = string.Concat(new string[]
                {
                    datasize.linpath,
                    "\\",
                    now.Year.ToString(),
                    now.Month.ToString(),
                    now.Day.ToString(),
                    now.Hour.ToString(),
                    now.Minute.ToString(),
                    now.Second.ToString(),
                    ".ca"
                });
                datasize.layout = datasize.linpath + "\\layout.ini";
                datasize.layout_defaut = Application.StartupPath + "\\layout_defaut.ini";
                datasize.layout_temp = Application.StartupPath + "\\layout_temp.ini";
                Kuozhan.Getcucolor();
                datasize.historycolors = Kuozhan.getxmlstring("historycolors");
                datasize.myid = Win32.GetMyID();
                new logon().ShowDialog();
                Thread.Sleep(300);
                if (datasize.dowloadurl != "")
                {
                    if (!(datasize.dowloadurl == "err"))
                    {
                        new download(datasize.dowloadurl).ShowDialog();
                    }
                }
                Program.Loadcodemessage("codemessage0", ref datasize.codemessage[0]);
                Program.Loadcodemessage("codemessage1", ref datasize.codemessage[1]);
                Application.Run(new main());
            }
        }

        private static void Loadcodemessage(string key, ref codemessagetype m1)
        {
            string text = Kuozhan.getxmlstring(key);
            if (text != "")
            {
                string[] array = text.Split(new char[]
                {
                    '-'
                });
                if (array.Length == 5)
                {
                    m1.allen = (byte)array[0].Getint();
                    m1.keyword = (byte)array[1].Getint();
                    m1.comshow = (byte)array[2].Getint();
                    m1.mouseshow = (byte)array[3].Getint();
                    m1.codehig = (byte)array[4].Getint();
                }
            }
        }
    }




}





