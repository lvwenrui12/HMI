using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace hmitype
{
    public static class datasize
    {
        public static int appxinxisize0 = (int)((ushort)Marshal.SizeOf(default(appinf0)));

        public static int appxinxisize1 = (int)((ushort)Marshal.SizeOf(default(appinf1)));

        public static int pagexinxisize = (int)((ushort)Marshal.SizeOf(default(pagexinxi)));

        public static int pagexinxisize_up = (int)((ushort)Marshal.SizeOf(default(pagexinxi_up)));

        public static int objxinxisize = (int)((ushort)Marshal.SizeOf(default(objxinxi)));

        public static int picxinxisize = (int)((ushort)Marshal.SizeOf(default(Picturexinxi)));

        public static int zimoxinxisize = (int)((ushort)Marshal.SizeOf(default(zimoxinxi)));

        public static int strxinxisize = (int)((ushort)Marshal.SizeOf(default(strxinxi)));

        public static int attxinxisize_up = (int)((ushort)Marshal.SizeOf(default(attinf_Up)));

        public static int attxinxisize = (int)((ushort)Marshal.SizeOf(default(attinf)));

        public static int runattinfsize = (int)((ushort)Marshal.SizeOf(default(runattinf)));

        public static int gujianxinxisize = (int)((ushort)Marshal.SizeOf(default(gujianinf)));

        public static int Language = 0;

        public static byte banbenh = 0;

        public static byte banbenl = 48;

        public static byte filever = 17;

        public static ushort lcdbinver = 21;

        public static byte lcddriverver = 7;

        public static string apppasseord = "A678ert";

        public static int[] mycolors;

        public static string historycolors;

        public static bool historycolorschange = false;

        public static List<guanggaotype> guangdaos = new List<guanggaotype>();

        public static int mesgtim = 0;

        public static string myid = "123";

        public static ushort Color_touming = 168;

        public static ushort Color_toumingtihuan = 169;

        public static bool Opentouming = false;

        public static string dowloadurl = "";

        public static string downloadpage = "";

        public static byte interbanbenh = 0;

        public static byte interbanbenl = 0;

        public static string uptext = "";

        public static Icon Myico;

        public static string softname = "";

        public static string softlogo = "";

        public static Encoding Myencoding;

        public static Encoding Objzhushiencoding;

        public static byte hmibiaoshiH;

        public static byte hmibiaoshiL;

        public static string linpath = "";

        public static string Bianyipath = "";

        public static string Verzhuanhuanpath = "";

        public static string runfilepath = datasize.linpath + "\\ca.ca";

        public static string oldhistorypath;

        public static string newhistorypath;

        public static string layout;

        public static string layout_temp;

        public static string layout_defaut;

        public static int clientuptime = 0;

        public static string clientupaddr = "";

        public static string verfindaddr = "";

        public static bool findendstate = false;

        public static byte zikuver = 2;

        public static codemessagetype[] codemessage = new codemessagetype[]
        {
            new codemessagetype
            {
                allen = 1,
                keyword = 1,
                comshow = 1,
                mouseshow = 1,
                codehig = 1
            },
            new codemessagetype
            {
                allen = 1,
                keyword = 1,
                comshow = 1,
                mouseshow = 1,
                codehig = 1
            }
        };

        public static string loginjpgurl = "";

        public static int loginjpgnum = 0;

        public static string tanchuangurl = "";

        public static int tanchuangid = 0;

        public static encodetype[] encodes_App = new encodetype[]
        {
            new encodetype
            {
                encodename = "null",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 126,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "ascii",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 126,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "gb2312",
                codeh_star = 161,
                codeh_end = 247,
                codel_star = 161,
                codel_end = 254,
                jiaozhunh = 201,
                jiaozhunl = 162,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-1",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-2",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-3",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-4",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-5",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-6",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-7",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-8",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-9",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-13",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-15",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "iso-8859-11",
                codeh_star = 0,
                codeh_end = 0,
                codel_star = 32,
                codel_end = 255,
                jiaozhunh = 0,
                jiaozhunl = 88,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "ks_c_5601-1987",
                codeh_star = 161,
                codeh_end = 200,
                codel_star = 161,
                codel_end = 254,
                jiaozhunh = 195,
                jiaozhunl = 245,
                codelT0 = 255,
                codelV0 = 0
            },
            new encodetype
            {
                encodename = "big5",
                codeh_star = 160,
                codeh_end = 249,
                codel_star = 64,
                codel_end = 254,
                jiaozhunh = 245,
                jiaozhunl = 245,
                codelT0 = 126,
                codelV0 = 34
            }
        };

        public static int[] encodes_Ch = new int[]
        {
            1,
            2,
            16
        };

        public static int[] encodes_En = new int[]
        {
            1,
            3,
            2,
            15,
            16,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            14,
            12,
            13,
            14
        };

        public static int[] encodes_This;

        public static modelxinxi[] Modes_ch0 = new modelxinxi[]
        {
            new modelxinxi
            {
                Modelstring = "TJC3224T022_011",
                fenbianlv = "240X320",
                inch = "2.2",
                Flash = "4M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC3224T024_011",
                fenbianlv = "240X320",
                inch = "2.4",
                Flash = "4M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC3224T028_011",
                fenbianlv = "240X320",
                inch = "2.8",
                Flash = "4M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC4024T032_011",
                fenbianlv = "240X400",
                inch = "3.2",
                Flash = "4M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC4832T035_011",
                fenbianlv = "320X480",
                inch = "3.5",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC4827T043_011",
                fenbianlv = "480X272",
                inch = "4.3",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC8048T050_011",
                fenbianlv = "800X480",
                inch = "5.0",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC8048T070_011",
                fenbianlv = "800X480",
                inch = "7.0",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC8048T090_011",
                fenbianlv = "800X480",
                inch = "9.0",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            }
        };

        public static modelxinxi[] Modes_ch1 = new modelxinxi[]
        {
            new modelxinxi
            {
                Modelstring = "TJC3224K022_011",
                fenbianlv = "240X320",
                inch = "2.2",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC3224K024_011",
                fenbianlv = "240X320",
                inch = "2.4",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC3224K028_011",
                fenbianlv = "240X320",
                inch = "2.8",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC4024K032_011",
                fenbianlv = "240X400",
                inch = "3.2",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "TJC4832K035_011",
                fenbianlv = "320X480",
                inch = "3.5",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "TJC4827K043_011",
                fenbianlv = "480X272",
                inch = "4.3",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "TJC8048K050_011",
                fenbianlv = "800X480",
                inch = "5.0",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "TJC8048K070_011",
                fenbianlv = "800X480",
                inch = "7.0",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "TJC8048K090_011",
                fenbianlv = "800X480",
                inch = "9.0",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            }
        };

        public static modelxinxi[] Modes_en0 = new modelxinxi[]
        {
            new modelxinxi
            {
                Modelstring = "NX3224T024_011",
                fenbianlv = "240X320",
                inch = "2.4",
                Flash = "4M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX3224T028_011",
                fenbianlv = "240X320",
                inch = "2.8",
                Flash = "4M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX4024T032_011",
                fenbianlv = "240X400",
                inch = "3.2",
                Flash = "4M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX4832T035_011",
                fenbianlv = "320X480",
                inch = "3.5",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX4827T043_011",
                fenbianlv = "480X272",
                inch = "4.3",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX8048T050_011",
                fenbianlv = "800X480",
                inch = "5.0",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX8048T070_011",
                fenbianlv = "800X480",
                inch = "7.0",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX8048T090_011",
                fenbianlv = "800X480",
                inch = "9.0",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            }
        };

        public static modelxinxi[] Modes_en1 = new modelxinxi[]
        {
            new modelxinxi
            {
                Modelstring = "NX3224K024_011",
                fenbianlv = "240X320",
                inch = "2.4",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX3224K028_011",
                fenbianlv = "240X320",
                inch = "2.8",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX4024K032_011",
                fenbianlv = "240X400",
                inch = "3.2",
                Flash = "16M",
                RAM = 3584,
                GPU = "48M"
            },
            new modelxinxi
            {
                Modelstring = "NX4832K035_011",
                fenbianlv = "320X480",
                inch = "3.5",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "NX4827K043_011",
                fenbianlv = "480X272",
                inch = "4.3",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "NX8048K050_011",
                fenbianlv = "800X480",
                inch = "5.0",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "NX8048K070_011",
                fenbianlv = "800X480",
                inch = "7.0",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            },
            new modelxinxi
            {
                Modelstring = "NX8048K090_011",
                fenbianlv = "800X480",
                inch = "9.0",
                Flash = "32M",
                RAM = 8192,
                GPU = "108M"
            }
        };

        public static modelxinxi[][] Modes;

        public static byte GetencodeId(this string str)
        {
            byte b = 0;
            byte result;
            while ((int)b < datasize.encodes_App.Length)
            {
                if (datasize.encodes_App[(int)b].encodename == str)
                {
                    result = b;
                    return result;
                }
                b += 1;
            }
            result =Convert.ToByte(((datasize.Language == 0) ? 2 : 3));
            return result;
        }

        public static string GetencodeName(this byte id)
        {
            string result;
            if ((int)id < datasize.encodes_App.Length)
            {
                result = datasize.encodes_App[(int)id].encodename;
            }
            else
            {
                result = "null";
            }
            return result;
        }

        public static void Modelinit()
        {
            datasize.Modes = new modelxinxi[3][];
            if (datasize.Language == 0)
            {
                datasize.Modes[0] = datasize.Modes_ch0;
                datasize.Modes[1] = datasize.Modes_ch1;
                datasize.Modes[2] = new modelxinxi[0];
            }
            else
            {
                datasize.Modes[0] = datasize.Modes_en0;
                datasize.Modes[1] = datasize.Modes_en1;
                datasize.Modes[2] = new modelxinxi[0];
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < datasize.Modes[i].Length; j++)
                {
                    datasize.Modes[i][j].Modelcrc = datasize.Modes[i][j].Modelstring.GetbytesssASCII().getcrc(0);
                }
            }
        }

        public static modelxinxi Getmodelxinxi(string model, int xilie)
        {
            return datasize.Getmodelxinxi(model.GetbytesssASCII().getcrc(0), xilie);
        }

        public static modelxinxi Getmodelxinxi(uint crc, int xilie)
        {
            modelxinxi modelxinxi = default(modelxinxi);
            modelxinxi.Modelstring = "";
            modelxinxi result;
            if (xilie > 2)
            {
                result = modelxinxi;
            }
            else
            {
                for (int i = 0; i < datasize.Modes[xilie].Length; i++)
                {
                    if (datasize.Modes[xilie][i].Modelcrc == crc)
                    {
                        result = datasize.Modes[xilie][i];
                        return result;
                    }
                }
                result = modelxinxi;
            }
            return result;
        }
    }
}
