using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.ScrollBar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace hmitype
{
    public static class Kuozhan
    {
        private static string[] En_cs;

        private static uint[] tab256 = new uint[]
        {
            0u,
            79764919u,
            159529838u,
            222504665u,
            319059676u,
            398814059u,
            445009330u,
            507990021u,
            638119352u,
            583659535u,
            797628118u,
            726387553u,
            890018660u,
            835552979u,
            1015980042u,
            944750013u,
            1276238704u,
            1221641927u,
            1167319070u,
            1095957929u,
            1595256236u,
            1540665371u,
            1452775106u,
            1381403509u,
            1780037320u,
            1859660671u,
            1671105958u,
            1733955601u,
            2031960084u,
            2111593891u,
            1889500026u,
            1952343757u,
            2552477408u,
            2632100695u,
            2443283854u,
            2506133561u,
            2334638140u,
            2414271883u,
            2191915858u,
            2254759653u,
            3190512472u,
            3135915759u,
            3081330742u,
            3009969537u,
            2905550212u,
            2850959411u,
            2762807018u,
            2691435357u,
            3560074640u,
            3505614887u,
            3719321342u,
            3648080713u,
            3342211916u,
            3287746299u,
            3467911202u,
            3396681109u,
            4063920168u,
            4143685023u,
            4223187782u,
            4286162673u,
            3779000052u,
            3858754371u,
            3904687514u,
            3967668269u,
            881225847u,
            809987520u,
            1023691545u,
            969234094u,
            662832811u,
            591600412u,
            771767749u,
            717299826u,
            311336399u,
            374308984u,
            453813921u,
            533576470u,
            25881363u,
            88864420u,
            134795389u,
            214552010u,
            2023205639u,
            2086057648u,
            1897238633u,
            1976864222u,
            1804852699u,
            1867694188u,
            1645340341u,
            1724971778u,
            1587496639u,
            1516133128u,
            1461550545u,
            1406951526u,
            1302016099u,
            1230646740u,
            1142491917u,
            1087903418u,
            2896545431u,
            2825181984u,
            2770861561u,
            2716262478u,
            3215044683u,
            3143675388u,
            3055782693u,
            3001194130u,
            2326604591u,
            2389456536u,
            2200899649u,
            2280525302u,
            2578013683u,
            2640855108u,
            2418763421u,
            2498394922u,
            3769900519u,
            3832873040u,
            3912640137u,
            3992402750u,
            4088425275u,
            4151408268u,
            4197601365u,
            4277358050u,
            3334271071u,
            3263032808u,
            3476998961u,
            3422541446u,
            3585640067u,
            3514407732u,
            3694837229u,
            3640369242u,
            1762451694u,
            1842216281u,
            1619975040u,
            1682949687u,
            2047383090u,
            2127137669u,
            1938468188u,
            2001449195u,
            1325665622u,
            1271206113u,
            1183200824u,
            1111960463u,
            1543535498u,
            1489069629u,
            1434599652u,
            1363369299u,
            622672798u,
            568075817u,
            748617968u,
            677256519u,
            907627842u,
            853037301u,
            1067152940u,
            995781531u,
            51762726u,
            131386257u,
            177728840u,
            240578815u,
            269590778u,
            349224269u,
            429104020u,
            491947555u,
            4046411278u,
            4126034873u,
            4172115296u,
            4234965207u,
            3794477266u,
            3874110821u,
            3953728444u,
            4016571915u,
            3609705398u,
            3555108353u,
            3735388376u,
            3664026991u,
            3290680682u,
            3236090077u,
            3449943556u,
            3378572211u,
            3174993278u,
            3120533705u,
            3032266256u,
            2961025959u,
            2923101090u,
            2868635157u,
            2813903052u,
            2742672763u,
            2604032198u,
            2683796849u,
            2461293480u,
            2524268063u,
            2284983834u,
            2364738477u,
            2175806836u,
            2238787779u,
            1569362073u,
            1498123566u,
            1409854455u,
            1355396672u,
            1317987909u,
            1246755826u,
            1192025387u,
            1137557660u,
            2072149281u,
            2135122070u,
            1912620623u,
            1992383480u,
            1753615357u,
            1816598090u,
            1627664531u,
            1707420964u,
            295390185u,
            358241886u,
            404320391u,
            483945776u,
            43990325u,
            106832002u,
            186451547u,
            266083308u,
            932423249u,
            861060070u,
            1041341759u,
            986742920u,
            613929101u,
            542559546u,
            756411363u,
            701822548u,
            3316196985u,
            3244833742u,
            3425377559u,
            3370778784u,
            3601682597u,
            3530312978u,
            3744426955u,
            3689838204u,
            3819031489u,
            3881883254u,
            3928223919u,
            4007849240u,
            4037393693u,
            4100235434u,
            4180117107u,
            4259748804u,
            2310601993u,
            2373574846u,
            2151335527u,
            2231098320u,
            2596047829u,
            2659030626u,
            2470359227u,
            2550115596u,
            2947551409u,
            2876312838u,
            2788305887u,
            2733848168u,
            3165939309u,
            3094707162u,
            3040238851u,
            2985771188u
        };

        public static void LanguageInit()
        {
            string text = Application.StartupPath + "\\hmics.lang";
            if (!File.Exists(text))
            {
                MessageOpen.Show("The file is missing:" + text);
                Application.Exit();
            }
            else
            {
                StreamReader streamReader = new StreamReader(text);
                byte[] array = new byte[streamReader.BaseStream.Length];
                streamReader.BaseStream.Read(array, 0, array.Length);
                Kuozhan.En_cs = Encoding.UTF8.GetString(array).Split(new char[]
                {
                    '\r'
                });
                streamReader.Close();
                streamReader.Dispose();
            }
        }

        public static void DrawThisLine(this UserControl this1, Color color, int wd)
        {
            Pen pen = new Pen(color, (float)wd);
            try
            {
                Point[] array = new Point[5];
                array[0].X = 0;
                array[0].Y = 0;
                array[1].X = this1.Width - 1;
                array[1].Y = 0;
                array[2].X = this1.Width - 1;
                array[2].Y = this1.Height - 1;
                array[3].X = 0;
                array[3].Y = this1.Height - 1;
                array[4].X = 0;
                array[4].Y = 0;
                this1.CreateGraphics().Clear(this1.BackColor);
                this1.CreateGraphics().DrawLines(pen, array);
            }
            catch
            {
            }
        }

        public static void DrawThisLine(this Panel this1, Color color, int wd)
        {
            Pen pen = new Pen(color, (float)wd);
            try
            {
                Point[] array = new Point[5];
                array[0].X = 1;
                array[0].Y = 0;
                array[1].X = this1.Width - 2;
                array[1].Y = 0;
                array[2].X = this1.Width - 2;
                array[2].Y = this1.Height - 1;
                array[3].X = 1;
                array[3].Y = this1.Height - 1;
                array[4].X = 1;
                array[4].Y = 0;
                this1.CreateGraphics().Clear(this1.BackColor);
                this1.CreateGraphics().DrawLines(pen, array);
            }
            catch
            {
            }
        }

        public static void Openhttp(string str)
        {
            if (Kuozhan.openie(str, 0) != "")
            {
                string text = Kuozhan.openie(str, 1);
                if (text != "")
                {
                    MessageOpen.Show(text);
                }
            }
        }

        private static string openie(string str, int state)
        {
            string result;
            try
            {
                if (state == 0)
                {
                    Process.Start(str);
                }
                if (state == 1)
                {
                    Process.Start("iexplore.exe", str);
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
            result = "";
            return result;
        }

        public static void addnewshu(this List<matt> atts, string name, byte vis, int datafenpei, byte lei, byte chonghui, string newval, string zhushi, byte isbangding, byte isxiugai, int maxval, int minval)
        {
            matt matt = new matt();
            matt.att.attlei = lei;
            matt.att.vis = vis;
            if (matt.att.attlei != attshulei.Sstr.typevalue)
            {
                lei &= 15;
                matt.att.maxval = maxval;
                matt.att.minval = minval;
                matt.att.zhanyonglenth = (ushort)datafenpei;
                matt.att.merrylenth = matt.att.zhanyonglenth;
                if (datafenpei == 1)
                {
                    matt.zhi = new byte[1];
                    matt.zhi[0] = (byte)newval.Getint();
                }
                else if (datafenpei == 2)
                {
                    if (lei == attshulei.UU16.typevalue)
                    {
                        matt.zhi = ((ushort)newval.Getint()).structToBytes();
                    }
                    else
                    {
                        matt.zhi = ((short)newval.Getint()).structToBytes();
                    }
                }
                else if (datafenpei == 4)
                {
                    if (lei == attshulei.SS32.typevalue)
                    {
                        matt.zhi = ((uint)newval.Getint()).structToBytes();
                    }
                    else
                    {
                        matt.zhi = newval.Getfloat().structToBytes();
                    }
                }
            }
            else
            {
                matt.zhi = newval.GetbytesssASCII();
                if (matt.zhi.Length == 0 || matt.zhi[matt.zhi.Length - 1] != 0)
                {
                    matt.zhi = Kuozhan.Gethebingbytes(matt.zhi, "".GetbytesssASCII(1));
                }
                matt.att.zhanyonglenth = (ushort)matt.zhi.Length;
                matt.att.merrylenth = (ushort)(datafenpei + 1);
            }
            matt.att.datafrom = 255;
            matt.name = name.GetbytesssASCII(8);
            matt.att.pos = 0;
            matt.att.isbangding = isbangding;
            matt.att.isxiugai = isxiugai;
            matt.att.chonghui = chonghui;
            matt.zhushi = datasize.Objzhushiencoding.GetBytes(zhushi);
            atts.Add(matt);
        }

        public static void Getlinpath()
        {
            string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + datasize.softname;
            if (!Directory.Exists(text))
            {
                if (!Kuozhan.cretfoder(text))
                {
                    text = Application.StartupPath;
                }
            }
            datasize.linpath = text;
            datasize.Bianyipath = text + "\\bianyi";
            datasize.Verzhuanhuanpath = text + "\\backup";
            datasize.oldhistorypath = text + "\\history.txt";
            datasize.newhistorypath = text + "\\openhistory.txt";
        }

        public static void delkuozhanfile(string path, string kuozhan)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] files = directoryInfo.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fileInfo = files[i];
                    if (fileInfo.Extension == "ca" || fileInfo.Extension == ".ca")
                    {
                        Kuozhan.del_f(fileInfo.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private static void del_f(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
            }
        }

        public static bool cretfoder(string path)
        {
            bool result;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                MessageOpen.Show("目录创建失败!".Language() + path);
                result = false;
                return result;
            }
            result = true;
            return result;
        }

        public static string GetnewText(string text, int val)
        {
            string result;
            if (val == 0)
            {
                result = text;
            }
            else if (text.Length == 0)
            {
                result = text;
            }
            else
            {
                int i = 0;
                while (i < Kuozhan.En_cs.Length)
                {
                    if (Kuozhan.En_cs[i] == text)
                    {
                        if (i + 1 < Kuozhan.En_cs.Length && Kuozhan.En_cs[i + 1].Length > 0)
                        {
                            result = Kuozhan.En_cs[i + 1];
                            return result;
                        }
                        result = text;
                        return result;
                    }
                    else
                    {
                        i += 2;
                    }
                }
                result = text;
            }
            return result;
        }

        public static string Language(this string text)
        {
            string result;
            if (datasize.Language == 0)
            {
                result = text;
            }
            else
            {
                int num = 0;
                int num2 = 1;
                int i = num;
                while (i < Kuozhan.En_cs.Length)
                {
                    if (Kuozhan.En_cs[i] == text)
                    {
                        if (i + num2 < Kuozhan.En_cs.Length && Kuozhan.En_cs[i + num2].Length > 0)
                        {
                            result = Kuozhan.En_cs[i + num2];
                            return result;
                        }
                        result = text;
                        return result;
                    }
                    else
                    {
                        i += 2;
                    }
                }
                result = text;
            }
            return result;
        }

        public static void Language(this Form f1)
        {
            if (datasize.Language != 0)
            {
                f1.Text = Kuozhan.GetnewText(f1.Text, datasize.Language);
                foreach (Control ct in f1.Controls)
                {
                    Kuozhan.Setobj(ct, datasize.Language);
                }
            }
        }

        public static void Setobj(Control ct, int val)
        {
            try
            {
                ct.Text = Kuozhan.GetnewText(ct.Text, val);
                if (ct.GetType() == typeof(Bar))
                {
                    foreach (object current in ((Bar)ct).Items)
                    {
                        Kuozhan.Traverseobject(current, val);
                    }
                }
                if (ct.GetType() == typeof(ItemPanel))
                {
                    foreach (object current in ((ItemPanel)ct).Items)
                    {
                        Kuozhan.Traverseobject(current, val);
                    }
                }
                if (ct.GetType() == typeof(SuperTabControl))
                {
                    foreach (object current in ((SuperTabControl)ct).Tabs)
                    {
                        Kuozhan.Traverseobject(current, val);
                    }
                }
                if (ct.GetType() == typeof(MenuStrip))
                {
                    foreach (ToolStripMenuItem myItems in ((MenuStrip)ct).Items)
                    {
                        Kuozhan.TraverseItems(myItems, val);
                    }
                }
                else if (ct.GetType() == typeof(ContextMenuStrip))
                {
                    foreach (ToolStripMenuItem myItems in ((ContextMenuStrip)ct).Items)
                    {
                        Kuozhan.TraverseItems(myItems, val);
                    }
                }
                else if (ct.GetType() == typeof(ToolStrip))
                {
                    foreach (ToolStripItem myItems2 in ((ToolStrip)ct).Items)
                    {
                        Kuozhan.TraverseItems(myItems2, val);
                    }
                }
                else if (ct.GetType() == typeof(DataGridView))
                {
                    foreach (DataGridViewColumn dataGridViewColumn in ((DataGridView)ct).Columns)
                    {
                        dataGridViewColumn.HeaderText = Kuozhan.GetnewText(dataGridViewColumn.HeaderText, val);
                    }
                }
                else if (ct.GetType() == typeof(StatusStrip))
                {
                    foreach (ToolStripLabel toolStripLabel in ((StatusStrip)ct).Items)
                    {
                        toolStripLabel.Text = Kuozhan.GetnewText(toolStripLabel.Text, val);
                    }
                }
                if (ct.Controls.Count > 0)
                {
                    for (int i = 0; i < ct.Controls.Count; i++)
                    {
                        Kuozhan.Setobj(ct.Controls[i], val);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                }
            }
        }

        private static void Traverseobject(object myItems, int val)
        {
            Type type = myItems.GetType();
            if (type == typeof(MetroTileItem))
            {
                MetroTileItem metroTileItem = (MetroTileItem)myItems;
                metroTileItem.Text = Kuozhan.GetnewText(metroTileItem.Text, val);
                metroTileItem.TitleText = Kuozhan.GetnewText(metroTileItem.TitleText, val);
            }
            if (type == typeof(ItemContainer))
            {
                ItemContainer itemContainer = (ItemContainer)myItems;
                itemContainer.Text = Kuozhan.GetnewText(itemContainer.Text, val);
                foreach (object current in itemContainer.SubItems)
                {
                    Kuozhan.Traverseobject(current, val);
                }
            }
            if (type == typeof(SuperTabItem))
            {
                SuperTabItem superTabItem = (SuperTabItem)myItems;
                superTabItem.Text = Kuozhan.GetnewText(superTabItem.Text, val);
                foreach (object current in superTabItem.SubItems)
                {
                    Kuozhan.Traverseobject(current, val);
                }
            }
            if (type == typeof(DockContainerItem))
            {
                DockContainerItem dockContainerItem = (DockContainerItem)myItems;
                dockContainerItem.Text = Kuozhan.GetnewText(dockContainerItem.Text, val);
                foreach (object current in dockContainerItem.SubItems)
                {
                    Kuozhan.Traverseobject(current, val);
                }
            }
            if (type == typeof(ButtonItem))
            {
                ButtonItem buttonItem = (ButtonItem)myItems;
                buttonItem.Text = Kuozhan.GetnewText(buttonItem.Text, val);
                buttonItem.Tooltip = Kuozhan.GetnewText(buttonItem.Tooltip, val);
                foreach (object current in buttonItem.SubItems)
                {
                    Kuozhan.Traverseobject(current, val);
                }
            }
            if (type == typeof(LabelItem))
            {
                LabelItem labelItem = (LabelItem)myItems;
                labelItem.Text = Kuozhan.GetnewText(labelItem.Text, val);
                foreach (object current in labelItem.SubItems)
                {
                    Kuozhan.Traverseobject(current, val);
                }
            }
        }

        private static void TraverseItems(ToolStripItem myItems, int val)
        {
            myItems.Text = Kuozhan.GetnewText(myItems.Text, val);
            if (!(myItems is ToolStripSeparator))
            {
                if (myItems is ToolStripMenuItem)
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)myItems;
                    if (toolStripMenuItem.DropDownItems.Count > 0)
                    {
                        for (int i = 0; i < toolStripMenuItem.DropDownItems.Count; i++)
                        {
                            Kuozhan.TraverseItems(toolStripMenuItem.DropDownItems[i], val);
                        }
                    }
                }
                if (myItems is ToolStripSplitButton)
                {
                    ToolStripSplitButton toolStripSplitButton = (ToolStripSplitButton)myItems;
                    if (toolStripSplitButton.DropDownItems.Count > 0)
                    {
                        for (int i = 0; i < toolStripSplitButton.DropDownItems.Count; i++)
                        {
                            Kuozhan.TraverseItems(toolStripSplitButton.DropDownItems[i], val);
                        }
                    }
                }
                if (myItems is ToolStripDropDownButton)
                {
                    ToolStripDropDownButton toolStripDropDownButton = (ToolStripDropDownButton)myItems;
                    if (toolStripDropDownButton.DropDownItems.Count > 0)
                    {
                        for (int i = 0; i < toolStripDropDownButton.DropDownItems.Count; i++)
                        {
                            Kuozhan.TraverseItems(toolStripDropDownButton.DropDownItems[i], val);
                        }
                    }
                }
            }
        }

        public static bool delfile(string path)
        {
            string messagestr = "";
            int i = 40;
            bool result;
            while (i > -1)
            {
                Thread.Sleep(50);
                try
                {
                    if (!File.Exists(path))
                    {
                        result = true;
                        return result;
                    }
                    File.Delete(path);
                    result = true;
                    return result;
                }
                catch (Exception ex)
                {
                    messagestr = ex.Message;
                    i--;
                }
            }
            MessageOpen.Show(messagestr);
            result = false;
            return result;
        }

        public static void Getquxian(int fudu, int yidong, ref List<int> myquxian)
        {
            int i = 0;
            int num = 0;
            int num2 = fudu / 2;
            myquxian.Clear();
            while (i < 3)
            {
                int num3 = -1 * Convert.ToInt32(Math.Sin(3.1415926535897931 * (double)num / 60.0) * (double)num2);
                myquxian.Add(num3 + yidong);
                if (num3 == 0)
                {
                    i++;
                }
                num++;
            }
        }

        public static Array Redim(this Array origArray, int desiredSize)
        {
            Type elementType = origArray.GetType().GetElementType();
            Array array = Array.CreateInstance(elementType, desiredSize);
            Array.Copy(origArray, 0, array, 0, Math.Min(origArray.Length, desiredSize));
            return array;
        }

        public static Array InsertArray(this Array origArray, Array inArray, int add)
        {
            Type elementType = origArray.GetType().GetElementType();
            Array array = Array.CreateInstance(elementType, origArray.Length + inArray.Length);
            if (add == -1)
            {
                Array.Copy(inArray, 0, array, 0, inArray.Length);
                Array.Copy(origArray, 0, array, inArray.Length, origArray.Length);
            }
            else
            {
                Array.Copy(origArray, 0, array, 0, add + 1);
                Array.Copy(inArray, 0, array, add + 1, inArray.Length);
                if (add < origArray.Length - 1)
                {
                    Array.Copy(origArray, add + 1, array, add + 1 + inArray.Length, origArray.Length - add - 1);
                }
            }
            return array;
        }

        public static byte[] subbytes(this byte[] bt1, int beg)
        {
            byte[] array = new byte[bt1.Length - beg];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = bt1[i + beg];
            }
            return array;
        }

        public static byte[] subbytes(this byte[] bt1, int beg, int qyt)
        {
            byte[] array = new byte[qyt];
            for (int i = 0; i < qyt; i++)
            {
                array[i] = bt1[i + beg];
            }
            return array;
        }

        public static string ByteGetstring(this byte bt)
        {
            byte[] array = new byte[2];
            array[0] = bt;
            return datasize.Myencoding.GetString(array, 0, 1);
        }

        public static string PosByteGetstring(this PosLaction Pos, byte[] buf)
        {
            return datasize.Myencoding.GetString(buf, (int)Pos.star, (int)(Pos.end - Pos.star + 1));
        }

        public unsafe static string PosByteGetstring(this PosLaction Pos, byte* buf)
        {
            PosLaction pos = default(PosLaction);
            byte[] array = new byte[(int)(Pos.end - Pos.star + 1)];
            int num = 0;
            for (int i = (int)Pos.star; i <= (int)Pos.end; i++)
            {
                array[num] = buf[i];
                num++;
            }
            pos.star = 0;
            pos.end = (ushort)(array.Length - 1);
            return pos.PosByteGetstring(array);
        }

        public static string GetCodesstring(this List<byte[]> ls)
        {
            string text = "";
            string result;
            if (ls == null)
            {
                result = text;
            }
            else
            {
                foreach (byte[] current in ls)
                {
                    if (text != "")
                    {
                        text = text + "\r\n" + current.Getstring(datasize.Myencoding);
                    }
                    else
                    {
                        text += current.Getstring(datasize.Myencoding);
                    }
                }
                result = text;
            }
            return result;
        }

        public static void PutRichtext_Code(this List<string> ls, RichTextBox text1)
        {
            if (ls != null)
            {
                text1.Text = "";
                for (int i = 0; i < ls.Count; i++)
                {
                    text1.AppendText(ls[i]);
                    text1.setzhishiline(i);
                    if (i < ls.Count - 1)
                    {
                        text1.AppendText("\r\n");
                    }
                }
            }
        }

        public static void Trim(this List<string> ls)
        {
            for (int i = 0; i < ls.Count; i++)
            {
                ls[i] = ls[i].Trim();
            }
        }

        public static List<byte[]> GetListbytes(this List<string> ls)
        {
            List<byte[]> list = new List<byte[]>();
            foreach (string current in ls)
            {
                list.Add(current.GetbytesssASCII());
            }
            return list;
        }

        public static List<string> GetListString(this List<byte[]> ls)
        {
            List<string> list = new List<string>();
            foreach (byte[] current in ls)
            {
                list.Add(current.Getstring(datasize.Myencoding));
            }
            return list;
        }

        public static void Showzi(this Bitmap bm, byte[] byte1, int height, Color color)
        {
            int num = (bm.Width - byte1.Length * 8 / height) / 2;
            int num2 = num;
            int num3 = bm.Height - height;
            for (int i = 0; i < byte1.Length; i++)
            {
                int num4 = (int)byte1[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((1 & num4 >> 7 - j) > 0)
                    {
                        bm.SetPixel(num2, num3, color);
                    }
                    num2++;
                    if (num2 >= num + byte1.Length * 8 / height)
                    {
                        num2 = num;
                        num3++;
                    }
                }
            }
        }

        public static string Gethanyi(this int index)
        {
            string text = Convert.ToString(index, 16);
            if (text.Length == 1)
            {
                text = "0" + text;
            }
            text = "0x" + text + " 0xff 0xff 0xff";
            return text.Gethanyi();
        }

        public static string Gethanyi(this string str)
        {
            string text = "";
            string[] array = str.Split(new char[]
            {
                ' '
            });
            string result;
            try
            {
                if (array.Length < 4)
                {
                    result = "";
                }
                else if (array[array.Length - 1] != "0xff" || array[array.Length - 2] != "0xff" || array[array.Length - 3] != "0xff")
                {
                    result = "";
                }
                else
                {
                    if (array.Length == 4)
                    {
                        string text2 = array[0];
                        switch (text2)
                        {
                            case "0x00":
                                text = "无效指令".Language();
                                break;
                            case "0x01":
                                text = "执行成功".Language();
                                break;
                            case "0x02":
                                text = "控件ID无效".Language();
                                break;
                            case "0x03":
                                text = "页面ID无效".Language();
                                break;
                            case "0x04":
                                text = "图片ID无效".Language();
                                break;
                            case "0x05":
                                text = "字库ID无效".Language();
                                break;
                            case "0x06":
                                text = "TIMER ID无效".Language();
                                break;
                            case "0x07":
                                text = "TIMER未配置".Language();
                                break;
                            case "0x08":
                                text = "系统变量ID无效".Language();
                                break;
                            case "0x11":
                                text = "波特率配置无效".Language();
                                break;
                            case "0x12":
                                text = "曲线ID号或通道设置无效".Language();
                                break;
                            case "0x1a":
                                text = "变量名称无效".Language();
                                break;
                            case "0x1b":
                                text = "变量运算无效".Language();
                                break;
                            case "0x1c":
                                text = "赋值操作失败".Language();
                                break;
                            case "0x1d":
                                text = "EEPROM操作失败".Language();
                                break;
                            case "0x1e":
                                text = "参数数量无效".Language();
                                break;
                            case "0x1f":
                                text = "IO操作失败".Language();
                                break;
                            case "0x20":
                                text = "转义字符使用错误".Language();
                                break;
                            case "0x21":
                                text = "IF判断语句中两个变量类型不匹配".Language();
                                break;
                            case "0x22":
                                text = "指令CRC校验错误".Language();
                                break;
                            case "0x23":
                                text = "变量名称太长".Language();
                                break;
                            case "0x24":
                                text = "串口缓冲区溢出".Language();
                                break;
                            case "0x86":
                                text = "自动进入睡眠模式".Language();
                                break;
                            case "0x87":
                                text = "自动唤醒睡眠".Language();
                                break;
                            case "0x88":
                                text = "系统启动成功".Language();
                                break;
                            case "0x89":
                                text = "开始SD卡升级".Language();
                                break;
                            case "0xfd":
                                text = "透传结束".Language();
                                break;
                            case "0xfe":
                                text = "透传准备就绪".Language();
                                break;
                        }
                    }
                    else if (array.Length > 4)
                    {
                        string text2 = array[0];
                        switch (text2)
                        {
                            case "0x65":
                                if (array.Length == 7)
                                {
                                    string[] array2 = new string[8];
                                    array2[0] = "页面".Language();
                                    array2[1] = ":";
                                    string[] arg_567_0 = array2;
                                    int arg_567_1 = 2;
                                    int num = Convert.ToInt32(array[1], 16);
                                    arg_567_0[arg_567_1] = num.ToString();
                                    array2[3] = "控件".Language();
                                    array2[4] = ":";
                                    string[] arg_595_0 = array2;
                                    int arg_595_1 = 5;
                                    num = Convert.ToInt32(array[2], 16);
                                    arg_595_0[arg_595_1] = num.ToString();
                                    array2[6] = " ";
                                    array2[7] = ((Convert.ToInt32(array[3], 16) == 0) ? "弹起".Language() : "按下".Language());
                                    text = string.Concat(array2);
                                }
                                break;
                            case "0x66":
                                if (array.Length == 5)
                                {
                                    text = "当前页面:".Language() + Convert.ToInt64(array[1], 16).ToString();
                                }
                                break;
                            case "0x67":
                                if (array.Length == 9)
                                {
                                    string[] array2 = new string[7];
                                    array2[0] = "坐标X:".Language();
                                    string[] arg_65D_0 = array2;
                                    int arg_65D_1 = 1;
                                    int num = Convert.ToInt32(array[1], 16) * 256 + Convert.ToInt32(array[2], 16);
                                    arg_65D_0[arg_65D_1] = num.ToString();
                                    array2[2] = " Y:";
                                    string[] arg_68E_0 = array2;
                                    int arg_68E_1 = 3;
                                    num = Convert.ToInt32(array[3], 16) * 256 + Convert.ToInt32(array[4], 16);
                                    arg_68E_0[arg_68E_1] = num.ToString();
                                    array2[4] = " ";
                                    array2[5] = "状态:".Language();
                                    array2[6] = ((Convert.ToInt32(array[5], 16) == 0) ? "弹起".Language() : "按下".Language());
                                    text = string.Concat(array2);
                                }
                                break;
                            case "0x68":
                                if (array.Length == 9)
                                {
                                    string[] array2 = new string[7];
                                    array2[0] = "睡眠模式触摸事件-坐标X:".Language();
                                    string[] arg_72B_0 = array2;
                                    int arg_72B_1 = 1;
                                    int num = Convert.ToInt32(array[1], 16) * 256 + Convert.ToInt32(array[2], 16);
                                    arg_72B_0[arg_72B_1] = num.ToString();
                                    array2[2] = " Y:";
                                    string[] arg_75C_0 = array2;
                                    int arg_75C_1 = 3;
                                    num = Convert.ToInt32(array[3], 16) * 256 + Convert.ToInt32(array[4], 16);
                                    arg_75C_0[arg_75C_1] = num.ToString();
                                    array2[4] = " ";
                                    array2[5] = "状态:".Language();
                                    array2[6] = ((Convert.ToInt32(array[5], 16) == 0) ? "弹起".Language() : "按下".Language());
                                    text = string.Concat(array2);
                                }
                                break;
                            case "0x70":
                                text = "字符串数据返回".Language();
                                break;
                            case "0x71":
                                if (array.Length == 8)
                                {
                                    text = "数值数据返回".Language();
                                }
                                break;
                            case "0x72":
                                if (array.Length == 5)
                                {
                                    text = "运行状态".Language() + ":" + ((Convert.ToInt32(array[1], 16) == 0) ? "正常".Language() : "休眠中".Language());
                                }
                                break;
                        }
                    }
                    result = text;
                }
            }
            catch
            {
                result = "";
            }
            return result;
        }

        private static string Getupdatestring(string str, int canshuindex, int addindex)
        {
            string text = "";
            string result;
            if (canshuindex == 0)
            {
                string[] array = str.Split(new char[]
                {
                    ' '
                });
                text = array[0] + " ";
                text += (int.Parse(array[1]) + addindex).ToString();
                result = text;
            }
            else
            {
                string[] array = str.Split(new char[]
                {
                    ','
                });
                for (int i = 0; i < canshuindex; i++)
                {
                    text = text + array[i] + ",";
                }
                text = text + (int.Parse(array[canshuindex]) + addindex).ToString() + ",";
                for (int i = canshuindex + 1; i < array.Length; i++)
                {
                    text = text + array[i] + ",";
                }
                result = text.Substring(0, text.Length - 1);
            }
            return result;
        }

        public static string Getval(string name)
        {
            return Kuozhan.getxmlstring(name);
        }

        public static void Putval(this string str, string name)
        {
            Kuozhan.putxmlstring(str, name);
        }

        public static void Getpath(this SaveFileDialog op, string name)
        {
            op.InitialDirectory = Kuozhan.getxmlstring(name);
        }

        public static void Getpath(this OpenFileDialog op, string name)
        {
            op.InitialDirectory = Kuozhan.getxmlstring(name);
        }

        public static void Putpath(this SaveFileDialog op, string name)
        {
            try
            {
                Kuozhan.putxmlstring(Path.GetDirectoryName(op.FileName), name);
            }
            catch
            {
            }
        }

        public static void Putpath(this OpenFileDialog op, string name)
        {
            if (File.Exists(op.FileName))
            {
                Kuozhan.putxmlstring(Path.GetDirectoryName(op.FileName), name);
            }
        }

        public static void Getcucolor()
        {
            string text = Kuozhan.getxmlstring("mycolors");
            if (text == "")
            {
                datasize.mycolors = new int[0];
            }
            else
            {
                string[] array = text.Split(new char[]
                {
                    ','
                });
                datasize.mycolors = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    datasize.mycolors[i] = array[i].Getint();
                }
            }
        }

        public static void Putcucolor(int[] colors)
        {
            bool flag = false;
            if (colors == null)
            {
                if (datasize.mycolors != null && datasize.mycolors.Length > 0)
                {
                    Kuozhan.putxmlstring("", "mycolors");
                    Kuozhan.Getcucolor();
                    return;
                }
            }
            if (colors.Length != datasize.mycolors.Length)
            {
                flag = true;
            }
            else
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] != datasize.mycolors[i])
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                string text = "";
                for (int i = 0; i < colors.Length - 1; i++)
                {
                    text = text + colors[i].ToString() + ",";
                }
                text += colors[colors.Length - 1].ToString();
                Kuozhan.putxmlstring(text, "mycolors");
                Kuozhan.Getcucolor();
            }
        }

        public static void addhistorycolor(string u16color)
        {
            int num = 8;
            string[] array = datasize.historycolors.Split(new char[]
            {
                '-'
            });
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string a = array2[i];
                if (a == u16color)
                {
                    return;
                }
            }
            if (datasize.historycolors != "")
            {
                datasize.historycolors = datasize.historycolors + "-" + u16color;
            }
            else
            {
                datasize.historycolors = u16color;
            }
            array = datasize.historycolors.Split(new char[]
            {
                '-'
            });
            if (array.Length > num)
            {
                datasize.historycolors = "";
                int num2 = array.Length - num;
                for (int j = 0; j < num - 1; j++)
                {
                    datasize.historycolors = datasize.historycolors + array[j + num2] + "-";
                }
                datasize.historycolors += array[num - 1 + num2];
            }
            datasize.historycolorschange = true;
        }

        public static string getxmlstring(string name)
        {
            string text = datasize.linpath + "\\data.xml";
            XmlDocument xmlDocument = new XmlDocument();
            string result;
            try
            {
                if (File.Exists(text))
                {
                    xmlDocument.Load(text);
                    XmlNode xmlNode = xmlDocument.SelectSingleNode("HMI").SelectSingleNode(name);
                    if (xmlNode != null)
                    {
                        result = xmlNode.InnerText;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("读配置文件出错,系统将重新复位配置文件:原因:".Language() + ex.Message);
                Kuozhan.delfile(text);
            }
            result = "";
            return result;
        }

        public static void putxmlstring(string path, string name)
        {
            string text = datasize.linpath + "\\data.xml";
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                if (!File.Exists(text))
                {
                    XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                    xmlDocument.AppendChild(newChild);
                    XmlElement newChild2 = xmlDocument.CreateElement("", "HMI", "");
                    xmlDocument.AppendChild(newChild2);
                    xmlDocument.Save(text);
                }
                xmlDocument.Load(text);
                XmlNode xmlNode = xmlDocument.SelectSingleNode("HMI").SelectSingleNode(name);
                if (xmlNode == null)
                {
                    XmlNode xmlNode2 = xmlDocument.SelectSingleNode("HMI");
                    XmlElement xmlElement = xmlDocument.CreateElement(name);
                    xmlElement.InnerText = path;
                    xmlNode2.AppendChild(xmlElement);
                }
                else
                {
                    xmlNode.InnerText = path;
                }
                xmlDocument.Save(text);
            }
            catch (Exception ex)
            {
                MessageOpen.Show("写配置文件出错,系统将重新复位配置文件,原因:".Language() + ex.Message);
                Kuozhan.delfile(text);
            }
        }

        public static bool CopyTextToClipboard(this string text)
        {
            bool result;
            try
            {
                DataObject dataObject = new DataObject();
                dataObject.SetData(DataFormats.UnicodeText, true, text);
                Clipboard.SetDataObject(dataObject, false, 3, 100);
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
            result = false;
            return result;
        }

        public static string ishefaname(this string str)
        {
            string result;
            if (str == null || str == "")
            {
                result = "名称不合法".Language();
            }
            else if (str.Substring(0, 1) == " ")
            {
                result = "名称不合法".Language();
            }
            else
            {
                byte[] bytes = datasize.Myencoding.GetBytes(str.Substring(0, 1));
                string text = "'\",&=+-*/.%\\[]";
                if (bytes[0] > 47 && bytes[0] < 58)
                {
                    result = "名称的第一位不能为数字".Language();
                }
                else
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (str.Contains(text.Substring(i, 1)))
                        {
                            result = "名称中出现非法字符".Language() + text.Substring(i, 1);
                            return result;
                        }
                    }
                    xitongtype_32[] xitong = Sysatt.xitong32;
                    for (int j = 0; j < xitong.Length; j++)
                    {
                        xitongtype_32 xitongtype_ = xitong[j];
                        if (xitongtype_.name.structToBytes().Getstring(datasize.Myencoding) == str)
                        {
                            result = "名称不合法".Language();
                            return result;
                        }
                    }
                    xitongtype_64[] xitong2 = Sysatt.xitong64;
                    for (int j = 0; j < xitong2.Length; j++)
                    {
                        xitongtype_64 xitongtype_2 = xitong2[j];
                        if (xitongtype_2.name.structToBytes().Getstring(datasize.Myencoding) == str)
                        {
                            result = "名称不合法".Language();
                            return result;
                        }
                    }
                    if (str.Length == "keybd".Length + 1 && str.Contains("keybd"))
                    {
                        char[] array = str.ToCharArray(str.Length - 1, 1);
                        if (array[0] >= 'A' && array[0] <= 'Z')
                        {
                            result = "名称不合法".Language();
                            return result;
                        }
                    }
                    result = "";
                }
            }
            return result;
        }

        public static bool openfile(ref StreamReader sr, string path)
        {
            bool result;
            try
            {
                sr = new StreamReader(path);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static string GetHexstring(this byte[] b)
        {
            string text = "";
            for (int i = 0; i < b.Length; i++)
            {
                string text2 = Convert.ToString(b[i], 16);
                if (text2.Length == 1)
                {
                    text2 = "0" + text2;
                }
                if (text == "")
                {
                    text = text2 + " ";
                }
                else
                {
                    text = text + text2 + " ";
                }
            }
            return text;
        }

        public static string Getstring(this byte[] b, Encoding en)
        {
            string result;
            if (b == null)
            {
                result = "";
            }
            else
            {
                int i;
                for (i = 0; i < b.Length; i++)
                {
                    if (b[i] == 0)
                    {
                        break;
                    }
                }
                if (i == 0)
                {
                    result = "";
                }
                else
                {
                    result = en.GetString(b, 0, i);
                }
            }
            return result;
        }

        public static string Getstring(this byte[] b, byte end)
        {
            int i;
            for (i = 0; i < b.Length; i++)
            {
                if (b[i] == 0 || b[i] == end)
                {
                    break;
                }
            }
            string result;
            if (i == 0)
            {
                result = "";
            }
            else
            {
                result = datasize.Myencoding.GetString(b, 0, i);
            }
            return result;
        }

        public static byte[] GetbytesssASCII(this string str)
        {
            byte[] result;
            if (str == "")
            {
                result = new byte[0];
            }
            else
            {
                result = datasize.Myencoding.GetBytes(str);
            }
            return result;
        }

        public static bool makebytes(byte[] b0, byte[] b1)
        {
            bool result;
            if (b0 == null || b1 == null)
            {
                result = (b0 == null && b1 == null);
            }
            else if (b0.Length != b1.Length)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < b0.Length; i++)
                {
                    if (b0[i] != b1[i])
                    {
                        result = false;
                        return result;
                    }
                }
                result = true;
            }
            return result;
        }

        public static byte[] GetbytesssASCII(this string str, int lenth)
        {
            byte[] array = new byte[lenth];
            byte[] bytes = datasize.Myencoding.GetBytes(str);
            for (int i = 0; i < lenth; i++)
            {
                if (i < bytes.Length)
                {
                    array[i] = bytes[i];
                }
                else
                {
                    array[i] = 0;
                }
            }
            return array;
        }

        public static List<byte[]> GetListBytes(this string str)
        {
            List<byte[]> list = new List<byte[]>();
            string[] array = str.Replace("(", "(").Replace(")", ")").Replace("\r\n", "\n").Split(new char[]
            {
                '\n'
            });
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                if (text.Length > 0)
                {
                    list.Add(text.GetbytesssASCII());
                }
            }
            return list;
        }

        public static List<string> GetListString(this string str)
        {
            List<string> list = new List<string>();
            string[] array = str.Replace("(", "(").Replace(")", ")").Replace("\r\n", "\n").Split(new char[]
            {
                '\n'
            });
            for (int i = 0; i < array.Length; i++)
            {
                if (i < 60000)
                {
                    if (array[i].Trim().Length > 0)
                    {
                        list.Add(array[i]);
                    }
                }
            }
            list.Codeduiqi();
            return list;
        }

        public static void Codeduiqi(this List<string> codes)
        {
            int num = 0;
            for (int i = 0; i < codes.Count; i++)
            {
                bool flag = false;
                string text = codes[i].Trim();
                if (text.Length > 0)
                {
                    if (text == "}" && i < codes.Count - 1)
                    {
                        string text2 = codes[i + 1].Trim();
                        if (text2 == "else" || (text2.Length > 8 && text2.Substring(0, 8) == "else if("))
                        {
                            text += text2;
                            flag = true;
                        }
                    }
                    if (text == "}" || (text.Length > 4 && text.Substring(0, 5) == "}else"))
                    {
                        num -= 2;
                    }
                    codes[i] = Kuozhan.getkongge(num) + text;
                    if (text == "{")
                    {
                        num += 2;
                    }
                    if (flag)
                    {
                        codes.Remove(codes[i + 1]);
                    }
                }
            }
        }

        public static string getkongge(int qyt)
        {
            string result;
            if (qyt < 0)
            {
                result = "";
            }
            else
            {
                string text = "                                                                                                                                                                         ";
                result = text.Substring(0, qyt);
            }
            return result;
        }

        public static int GetstringCode(this string val, Encoding enc)
        {
            int result = 0;
            byte[] bytes = enc.GetBytes(val);
            if (bytes.Length == 1)
            {
                result = (int)bytes[0];
            }
            else if (bytes.Length == 2)
            {
                result = (int)bytes[0] * 256 + (int)bytes[1];
            }
            return result;
        }

        public static Color Get24color(this ushort s)
        {
            Color result;
            try
            {
                int red = (s >> 11) * 255 / 31;
                int green = ((s & 2016) >> 5) * 255 / 63;
                int blue = (int)((s & 31) * 255 / 31);
                result = Color.FromArgb(red, green, blue);
            }
            catch
            {
                result = Color.Black;
            }
            return result;
        }

        public static ushort Get16Color(this Color c)
        {
            ushort result;
            try
            {
                int num = c.R >> 3 << 11;
                num |= c.G >> 2 << 5;
                num |= c.B >> 3;
                result = (ushort)num;
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public static int Getint(this string str)
        {
            int num = 0;
            int result;
            try
            {
                num = int.Parse(str);
            }
            catch
            {
                num = 0;
                result = num;
                return result;
            }
            result = num;
            return result;
        }

        public static float Getfloat(this string str)
        {
            float num = 0f;
            float result;
            try
            {
                num = float.Parse(str);
            }
            catch
            {
                num = 0f;
                result = num;
                return result;
            }
            result = num;
            return result;
        }

        public static bool IsdataS32(this string str, byte lei)
        {
            bool result;
            try
            {
                if (lei == attshulei.Sstr.typevalue)
                {
                    result = false;
                    return result;
                }
                lei &= 15;
                if (lei < attshulei.SS8.typevalue)
                {
                    if (lei == attshulei.UU8.typevalue)
                    {
                        byte b = byte.Parse(str);
                    }
                    else
                    {
                        if (lei != attshulei.UU16.typevalue)
                        {
                            result = false;
                            return result;
                        }
                        ushort num = ushort.Parse(str);
                    }
                }
                else if (lei == attshulei.SS8.typevalue)
                {
                    byte b = byte.Parse(str);
                }
                else if (lei == attshulei.SS16.typevalue)
                {
                    short num2 = short.Parse(str);
                }
                else
                {
                    if (lei != attshulei.SS32.typevalue)
                    {
                        result = false;
                        return result;
                    }
                    int num3 = int.Parse(str);
                }
            }
            catch
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }

        public static int GetintWithError(this string str)
        {
            int result = 0;
            try
            {
                result = int.Parse(str);
            }
            catch (Exception ex)
            {
                MessageOpen.Show("字符串转换为int出错".Language() + "\r\n" + str + ex.Message);
            }
            return result;
        }

        public static void delzhushi(this List<string> bt)
        {
            for (int i = 0; i < bt.Count; i++)
            {
                string text = bt[i];
                int num = Kuozhan.findguanjianstr(text, "//");
                if (num < 65535)
                {
                    bt[i] = text.Substring(0, num).Trim();
                }
                else
                {
                    bt[i] = text.Trim();
                }
            }
        }

        public static void setzhishiline(this RichTextBox text1, int lineindex)
        {
            try
            {
                if (lineindex >= 0 && lineindex < text1.Lines.Length)
                {
                    int num = Kuozhan.findguanjianstr(text1.Lines[lineindex], "//");
                    if (num < 65535)
                    {
                        text1.SelectionStart = text1.GetFirstCharIndexFromLine(lineindex);
                        text1.SelectionLength = num;
                        text1.SelectionColor = Color.Black;
                        text1.SelectionStart = text1.GetFirstCharIndexFromLine(lineindex) + num;
                        text1.SelectionLength = text1.Lines[lineindex].Length - num;
                        text1.SelectionColor = Color.Green;
                    }
                    else
                    {
                        text1.SelectionStart = text1.GetFirstCharIndexFromLine(lineindex);
                        text1.SelectionLength = text1.Lines[lineindex].Length;
                        text1.SelectionColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        public static int findguanjianstr(string str, string fstr)
        {
            int num = 0;
            int result;
            if (str.Contains(fstr))
            {
                int num2 = -1;
                while (num2 == -1 || num2 % 2 > 0)
                {
                    if (num2 == -1)
                    {
                        num2 = 0;
                    }
                    int num3 = str.IndexOf(fstr, num);
                    if (num3 == -1)
                    {
                        result = 65535;
                        return result;
                    }
                    for (int num4 = str.IndexOf("\"", num, num3 - num); num4 != -1; num4 = str.IndexOf("\"", num, num3 - num))
                    {
                        if (num4 == 0 || str.Substring(num4 - 1, 1) != "\\")
                        {
                            num2++;
                        }
                        num = num4 + 1;
                    }
                    num = num3 + fstr.Length;
                }
                num -= fstr.Length;
                result = num;
            }
            else
            {
                result = 65535;
            }
            return result;
        }

        public static void AddListBytes(this List<byte[]> list1, List<byte[]> newlist)
        {
            if (newlist != null)
            {
                foreach (byte[] current in newlist)
                {
                    list1.Add(current);
                }
            }
        }

        public static List<byte[]> CopyListBytes(this List<byte[]> list1)
        {
            List<byte[]> list2 = new List<byte[]>();
            list2.AddListBytes(list1);
            return list2;
        }

        public static List<string> CopyListString(this List<string> list1)
        {
            List<string> list2 = new List<string>();
            list2.AddListString(list1);
            return list2;
        }

        public static void AddListString(this List<string> list1, List<string> newlist)
        {
            if (newlist != null)
            {
                foreach (string current in newlist)
                {
                    list1.Add(current);
                }
            }
        }

        public static byte[] Gethebingbytes(byte[] bytes1, byte[] bytes2)
        {
            byte[] array = new byte[bytes1.Length + bytes2.Length];
            bytes1.CopyTo(array, 0);
            bytes2.CopyTo(array, bytes1.Length);
            return array;
        }

        public static byte[] Gethebingbytes(byte[] bytes1, byte[] bytes2, byte[] bytes3)
        {
            byte[] array = new byte[bytes1.Length + bytes2.Length + bytes3.Length];
            bytes1.CopyTo(array, 0);
            bytes2.CopyTo(array, bytes1.Length);
            bytes3.CopyTo(array, bytes1.Length + bytes2.Length);
            return array;
        }

        public static byte[] Gethebingbytes(byte[] bytes1, byte[] bytes2, byte[] bytes3, byte[] bytes4)
        {
            byte[] array = new byte[bytes1.Length + bytes2.Length + bytes3.Length + bytes4.Length];
            bytes1.CopyTo(array, 0);
            bytes2.CopyTo(array, bytes1.Length);
            bytes3.CopyTo(array, bytes1.Length + bytes2.Length);
            bytes4.CopyTo(array, bytes1.Length + bytes2.Length + bytes3.Length);
            return array;
        }

        public static object BytesTostruct(this byte[] bytes, Type strcutType)
        {
            object obj2;
            IntPtr destination = new IntPtr();
            int cb = 0;
            try
            {
                cb = Marshal.SizeOf(strcutType);
                destination = Marshal.AllocHGlobal(cb);
                Marshal.Copy(bytes, 0, destination, cb);
                obj2 = Marshal.PtrToStructure(destination, strcutType);
            }
            catch (Exception exception)
            {
                MessageOpen.Show(exception.Message);
                obj2 = null;
            }
            finally
            {
                Marshal.FreeHGlobal(destination);
            }
            return obj2;
        }

        


        public unsafe static void BytesToptr(this byte[] bytes, byte* pt)
        {
            bytes.BytesToptr(0, pt);
        }

        public unsafe static void BytesToptr(this byte[] bytes, int beg, byte* pt)
        {
            if (beg < bytes.Length)
            {
                for (int i = beg; i < bytes.Length; i++)
                {
                    *pt = bytes[i];
                    pt++;
                }
            }
        }

        public unsafe static object BytesTostruct(this byte[] bytes, int beg, Type strcutType)
        {
            object result;
            if (bytes.Length - beg < Marshal.SizeOf(strcutType))
            {
                MessageOpen.Show("数组空间不够,转换结构体失败".Language());
                result = null;
            }
            else
            {
                try
                {
                    try
                    {
                        //fixed (void* ptr = (void*)(&bytes[beg]))
                        fixed (void* ptr =(&bytes[beg]))
                        {
                            IntPtr ptr2 = new IntPtr(ptr);
                            result = Marshal.PtrToStructure(ptr2, strcutType);
                        }
                    }
                    finally
                    {
                        void* ptr = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                    result = null;
                }
            }
            return result;
        }

        public static byte[] structToBytes(this object structure)
        {
            int num = Marshal.SizeOf(structure);
            IntPtr intPtr = Marshal.AllocHGlobal(num);
            Marshal.StructureToPtr(structure, intPtr, false);
            byte[] array = new byte[num];
            Marshal.Copy(intPtr, array, 0, num);
            Marshal.FreeHGlobal(intPtr);
            return array;
        }

        public static byte[] ClassToBytes(this object structure)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, structure);
            byte[] array = new byte[memoryStream.Length];
            memoryStream.Position = 0L;
            memoryStream.Read(array, 0, (int)memoryStream.Length);
            return array;
        }

        public static object BytesToClass(this byte[] bytes)
        {
            return bytes.BytesToClass(0, bytes.Length);
        }

        public static object BytesToClass(this byte[] bytes, int beg, int qyt)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Position = 0L;
            memoryStream.Write(bytes, beg, qyt);
            memoryStream.Position = 0L;
            return binaryFormatter.Deserialize(memoryStream);
        }

        public unsafe static void sendstring_End(this SerialPort com1, string j, bool iscrc, Encoding en)
        {
            byte[] buffer = new byte[]
            {
                255,
                255,
                255
            };
            try
            {
                if (en == null)
                {
                    en = Encoding.GetEncoding("ascii");
                }
                string text = j.Trim();
                if (com1.IsOpen)
                {
                    if (text.Length > 0)
                    {
                        byte[] bytes = en.GetBytes(text);
                        com1.Write(bytes, 0, bytes.Length);
                    }
                    com1.Write(buffer, 0, 3);
                    if (iscrc)
                    {
                        uint num = en.GetBytes(j).getcrc(0);
                        void* ptr = (void*)(&num);
                        byte* ptr2 = (byte*)ptr;
                        com1.Write(new byte[]
                        {
                            *ptr2,
                            ptr2[1],
                            ptr2[2],
                            ptr2[3]
                        }, 0, 4);
                    }
                }
            }
            catch
            {
            }
        }

        public static void Getqumo(this Bitmap bm, ref byte[] bytes, int wid, int dd)
        {
            int num = 0;
            int num2 = 0;
            while (true)
            {
                bytes[dd] = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (bm.GetPixel(num, num2).R > 0)
                    {
                        bytes[dd] = (byte)((int)bytes[dd] + (1 << 7 - i));
                    }
                    num++;
                    if (num >= wid)
                    {
                        num2++;
                        num = 0;
                    }
                    if (num2 >= bm.Height)
                    {
                        break;
                    }
                }
                if (num2 >= bm.Height)
                {
                    break;
                }
                dd++;
            }
        }

        public static Bitmap GetBitmap(this byte[] img, Picturexinxi pic, bool Maketouming)
        {
            Bitmap bitmap = new Bitmap((int)pic.W, (int)pic.H);
            Graphics.FromImage(bitmap).Clear(Color.White);
            int i = 0;
            int j = 0;
            int num = 0;
            Bitmap result;
            try
            {
                if (pic.qumo == 10)
                {
                    while (j < (int)pic.H)
                    {
                        while (i < (int)pic.W)
                        {
                            ushort num2 = (ushort)img[num + 1];
                            num2 = (ushort)(num2 << 8);
                            num2 += (ushort)img[num];
                            if (num2 != datasize.Color_touming)
                            {
                                bitmap.SetPixel(i, j, num2.Get24color());
                            }
                            else if (!datasize.Opentouming && !Maketouming)
                            {
                                bitmap.SetPixel(i, j, datasize.Color_toumingtihuan.Get24color());
                            }
                            else
                            {
                                bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                            }
                            i++;
                            num += 2;
                        }
                        i = 0;
                        j++;
                    }
                }
                else if (pic.qumo == 11)
                {
                    j = (int)(pic.H - 1);
                    for (i = 0; i < (int)pic.W; i++)
                    {
                        while (j > -1)
                        {
                            ushort num2 = (ushort)img[num + 1];
                            num2 = (ushort)(num2 << 8);
                            num2 += (ushort)img[num];
                            if (num2 != datasize.Color_touming)
                            {
                                bitmap.SetPixel(i, j, num2.Get24color());
                            }
                            else if (!datasize.Opentouming && !Maketouming)
                            {
                                bitmap.SetPixel(i, j, datasize.Color_toumingtihuan.Get24color());
                            }
                            else
                            {
                                bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                            }
                            j--;
                            num += 2;
                        }
                        j = (int)(pic.H - 1);
                    }
                }
                else if (pic.qumo == 12)
                {
                    j = (int)(pic.H - 1);
                    i = (int)(pic.W - 1);
                    while (j > -1)
                    {
                        while (i > -1)
                        {
                            ushort num2 = (ushort)img[num + 1];
                            num2 = (ushort)(num2 << 8);
                            num2 += (ushort)img[num];
                            if (num2 != datasize.Color_touming)
                            {
                                bitmap.SetPixel(i, j, num2.Get24color());
                            }
                            else if (!datasize.Opentouming && !Maketouming)
                            {
                                bitmap.SetPixel(i, j, datasize.Color_toumingtihuan.Get24color());
                            }
                            else
                            {
                                bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                            }
                            i--;
                            num += 2;
                        }
                        i = (int)(pic.W - 1);
                        j--;
                    }
                }
                else if (pic.qumo == 13)
                {
                    j = 0;
                    for (i = (int)(pic.W - 1); i > -1; i--)
                    {
                        while (j < (int)pic.H)
                        {
                            ushort num2 = (ushort)img[num + 1];
                            num2 = (ushort)(num2 << 8);
                            num2 += (ushort)img[num];
                            if (num2 != datasize.Color_touming)
                            {
                                bitmap.SetPixel(i, j, num2.Get24color());
                            }
                            else if (!datasize.Opentouming && !Maketouming)
                            {
                                bitmap.SetPixel(i, j, datasize.Color_toumingtihuan.Get24color());
                            }
                            else
                            {
                                bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                            }
                            j++;
                            num += 2;
                        }
                        j = 0;
                    }
                }
                result = bitmap;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = bitmap;
            }
            return result;
        }

        public static void zhuanimg(byte[] limg, ref byte[] desimage, int w, int h)
        {
            int num = 0;
            byte[] array = new byte[limg.Length];
            for (int i = 0; i < h; i++)
            {
                int num2 = (i + 1) * w * 2 - 2;
                for (int j = 0; j < w; j++)
                {
                    array[num] = limg[num2];
                    array[num + 1] = limg[num2 + 1];
                    num += 2;
                    num2 -= 2;
                }
            }
            desimage = new byte[array.Length];
            array.CopyTo(desimage, 0);
        }

        public static byte[] getxuanzhuanziku(zimoxinxi zx, byte[] image, int qumo0, int qumo1)
        {
            byte[] array = new byte[image.Length];
            for (int i = 0; i < (int)zx.datastar; i++)
            {
                array[i] = image[i];
            }
            int num = (int)(zx.w * zx.h);
            int num2 = (int)(zx.w * zx.h / 8);
            int num3 = (image.Length - (int)zx.datastar) / num2;
            int num4 = qumo1 - qumo0;
            int num5 = (int)zx.datastar;
            int num6 = (int)zx.datastar;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = (int)zx.w;
            int h = (int)zx.h;
            for (int i = 0; i < num3; i++)
            {
                int num12 = num5;
                int num13 = num6;
                num11 = (int)zx.w;
                int num14 = num2;
                if (zx.state == 2)
                {
                    if (image[(int)zx.ascstar + i * 2] == 0)
                    {
                        num11 = (int)(zx.w / 2);
                        num14 = num2 / 2;
                    }
                }
                if (zx.state == 1)
                {
                    if ((long)i > (long)((ulong)(zx.qyt - 96u)))
                    {
                        num11 = (int)(zx.w / 2);
                        num14 = num2 / 2;
                    }
                }
                if (num4 == 1 || num4 == -3)
                {
                    if (qumo1 % 2 == 0)
                    {
                        num7 = num11 - 1;
                        num8 = num11;
                        num10 = h;
                        num9 = -1;
                    }
                    else
                    {
                        num7 = h - 1;
                        num8 = h;
                        num10 = num11;
                        num9 = -1;
                    }
                }
                if (num4 == 2 || num4 == -2)
                {
                    if (qumo1 % 2 == 0)
                    {
                        num7 = num11 * h - 1;
                        num8 = -1;
                        num10 = num11;
                        num9 = num11 * -1;
                    }
                    else
                    {
                        num7 = num11 * h - 1;
                        num8 = -1;
                        num10 = h;
                        num9 = h * -1;
                    }
                }
                if (num4 == 3 || num4 == -1)
                {
                    if (qumo1 % 2 == 0)
                    {
                        num7 = (h - 1) * num11;
                        num8 = num11 * -1;
                        num10 = h;
                        num9 = 1;
                    }
                    else
                    {
                        num7 = (num11 - 1) * h;
                        num8 = h * -1;
                        num10 = num11;
                        num9 = 1;
                    }
                }
                if (qumo0 == 4 && qumo1 == 0)
                {
                    num7 = 0;
                    num8 = num11;
                    num10 = h;
                    num9 = 1;
                }
                int num15 = num7;
                int num16 = 0;
                for (int j = 0; j < num14; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (((int)image[num12] & 1 << 7 - k) > 0)
                        {
                            int num17 = num15 / 8;
                            int num18 = num15 % 8;
                            byte[] expr_2A9_cp_0 = array;
                            int expr_2A9_cp_1 = num13 + num17;
                            expr_2A9_cp_0[expr_2A9_cp_1] |= (byte)(1 << 7 - num18);
                        }
                        num15 += num8;
                        num16++;
                        if (num16 >= num10)
                        {
                            num7 += num9;
                            num15 = num7;
                            num16 = 0;
                        }
                    }
                    num12++;
                }
                num6 += num2;
                num5 += num2;
            }
            return array;
        }

        public static bool checkbaohan(int cx0, int cy0, int cx1, int cy1, int x0, int y0, int x1, int y1)
        {
            if (x1 < x0 || y1 < y0)
            {
                if (x1 >= x0 && y1 <= y0)
                {
                    int num = y0;
                    y0 = y1;
                    y1 = num;
                }
                else if (x1 <= x0 && y1 >= y0)
                {
                    int num = x0;
                    x0 = x1;
                    x1 = num;
                }
                else if (x1 <= x0 && y1 <= y0)
                {
                    int num = y0;
                    y0 = y1;
                    y1 = num;
                    num = x0;
                    x0 = x1;
                    x1 = num;
                }
            }
            return (cx0 >= x0 && cx0 <= x1 && cy1 >= y0 && cy0 <= y1) || (x0 >= cx0 && x0 <= cx1 && y1 >= cy0 && y0 <= cy1);
        }

        public static void getxuanzhuanimage(byte[] image, ref byte[] desimage, int w, int h, int qumo0, int qumo1)
        {
            byte[] array = new byte[image.Length];
            int i = image.Length;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = qumo1 - qumo0;
            if (num5 == 1 || num5 == -3)
            {
                if (qumo0 % 2 == 0)
                {
                    num = w * 2 * (h - 1);
                    num2 = w * 2 * -1;
                }
                else
                {
                    num = h * 2 * (w - 1);
                    num2 = h * 2 * -1;
                }
                num3 = 2;
            }
            if (num5 == 2 || num5 == -2)
            {
                if (qumo0 % 2 == 0)
                {
                    num = w * 2 * h - 2;
                    num2 = -2;
                    num3 = w * 2 * -1;
                }
                else
                {
                    num = h * 2 * w - 2;
                    num2 = -2;
                    num3 = h * 2 * -1;
                }
            }
            if (num5 == 3 || num5 == -1)
            {
                if (qumo0 % 2 == 0)
                {
                    num = w * 2 - 2;
                    num2 = w * 2;
                }
                else
                {
                    num = h * 2 - 2;
                    num2 = h * 2;
                }
                num3 = -2;
            }
            int num6 = (qumo1 % 2 == 0) ? w : h;
            int num7 = num;
            while (i > 0)
            {
                for (int j = 0; j < num6; j++)
                {
                    array[num4] = image[num7];
                    array[num4 + 1] = image[num7 + 1];
                    i -= 2;
                    if (i <= 0)
                    {
                        break;
                    }
                    num4 += 2;
                    num7 += num2;
                }
                num += num3;
                num7 = num;
            }
            desimage = new byte[array.Length];
            array.CopyTo(desimage, 0);
        }

        public unsafe static void memcpy(byte* p1, byte* p2, int lenth)
        {
            for (int i = 0; i < lenth; i++)
            {
                *p1 = *p2;
                p1++;
                p2++;
            }
        }

        public static void SetSize(this Control me)
        {
            try
            {
                me.Top = 0;
                me.Left = 0;
                me.Width = me.Parent.Width;
                me.Height = me.Parent.Height;
            }
            catch
            {
            }
        }

        public static void setscrollbarnum(this HScrollBarAdv bar, int num, int maxscrollvalue)
        {
            int num2 = maxscrollvalue / 90;
            bar.Minimum = 0;
            int num3;
            int largeChange;
            if (num == 0)
            {
                num3 = 10;
                largeChange = 11;
            }
            else
            {
                int num4 = num;
                if (num4 > maxscrollvalue)
                {
                    num4 = maxscrollvalue;
                }
                num3 = num * 100 / (100 - (95 - num4 / num2));
                largeChange = num3 - num;
            }
            bar.Maximum = num3;
            bar.LargeChange = largeChange;
            bar.SmallChange = 1;
        }

        public static void setscrollbarnum(this VScrollBarAdv bar, int num, int maxscrollvalue)
        {
            int num2 = maxscrollvalue / 90;
            bar.Minimum = 0;
            int num3;
            int largeChange;
            if (num == 0)
            {
                num3 = 10;
                largeChange = 11;
            }
            else
            {
                int num4 = num;
                if (num4 > maxscrollvalue)
                {
                    num4 = maxscrollvalue;
                }
                num3 = num * 100 / (100 - (95 - num4 / num2));
                largeChange = num3 - num;
            }
            bar.Maximum = num3;
            bar.LargeChange = largeChange;
            bar.SmallChange = 1;
        }

        public static byte[] Appfree8(this byte[] bytes, string passstr)
        {
            byte[] array = new byte[bytes.Length];
            byte[] array2 = passstr.GetbytesssASCII();
            int num = array2.Length;
            int num2 = bytes.Length;
            int num3 = 0;
            for (int i = 0; i < num2; i++)
            {
                array[i] =(byte) (bytes[i] ^ array2[num3]);
                if (num3 == num)
                {
                    num3 = 0;
                }
            }
            return array;
        }

        public static byte[] Appfree10(this byte[] bytes, string passstr, uint ModelCRC)
        {
            byte[] array = new byte[bytes.Length];
            int num = array.Length;
            uint num2 = passstr.GetbytesssASCII().getcrc(0);
            num2 = ModelCRC.structToBytes().getcrc(num2, 0);
            byte[] array2 = num2.structToBytes();
            int num3 = 0;
            for (int i = 0; i < num; i++)
            {
                array[i] =(byte) (bytes[i] ^ array2[num3]);
                num3++;
                if (num3 > 3)
                {
                    num3 = 0;
                }
            }
            return array;
        }

        public static byte[] pagefree(this byte[] bytes, string passstr, byte mark)
        {
            byte[] array = new byte[bytes.Length];
            int num = array.Length;
            uint num2 = passstr.GetbytesssASCII().getcrc(0);
            num2 = mark.structToBytes().getcrc(num2, 0);
            byte[] array2 = num2.structToBytes();
            int num3 = 0;
            if (num > 5)
            {
                for (int i = 0; i < 6; i++)
                {
                    array[i] = bytes[i];
                }
            }
            for (int i = 6; i < array.Length; i++)
            {
                array[i] =(byte) (bytes[i] ^ array2[num3]);
                num3++;
                if (num3 > 3)
                {
                    num3 = 0;
                }
            }
            return array;
        }

        public static uint getcrc(this byte[] pData, int beg)
        {
            return pData.getcrc(Convert.ToUInt32("0xFFFFFFFF", 16), beg, pData.Length - beg);
        }

        public static uint getcrc(this byte[] pData, uint intcrc, int beg)
        {
            return pData.getcrc(intcrc, beg, pData.Length - beg);
        }

        public static uint getcrc(this byte[] pData, uint intcrc, int beg, int Length)
        {
            uint num = intcrc;
            int num2 = beg + Length - 1;
            uint result;
            if (num2 >= pData.Length)
            {
                result = 0u;
            }
            else
            {
                for (int i = beg; i <= num2; i++)
                {
                    num ^= (uint)pData[i];
                    for (int j = 0; j < 4; j++)
                    {
                        uint num3 = Kuozhan.tab256[(int)((byte)(num >> 24 & 255u))];
                        num <<= 8;
                        num ^= num3;
                    }
                }
                result = num;
            }
            return result;
        }

        public unsafe static uint CRC32(byte* buf, int lenth)
        {
            uint num = Convert.ToUInt32("0xFFFFFFFF", 16);
            uint num2 = 0u;
            while ((ulong)num2 < (ulong)((long)lenth))
            {
                num ^= (uint)buf[num2];
                for (uint num3 = 0u; num3 < 4u; num3 += 1u)
                {
                    uint num4 = Kuozhan.tab256[(int)((byte)(num >> 24 & 255u))];
                    num <<= 8;
                    num ^= num4;
                }
                num2 += 1u;
            }
            return num;
        }

        private static uint getfilecrc(StreamReader sr, int beg, int qyt)
        {
            uint num = Convert.ToUInt32("0xFFFFFFFF", 16);
            try
            {
                if (sr.BaseStream.Length >= (long)(beg + qyt))
                {
                    sr.BaseStream.Position = (long)beg;
                    byte[] array = new byte[1000000];
                    while (qyt > 0)
                    {
                        int num2;
                        if (qyt >= array.Length)
                        {
                            num2 = array.Length;
                        }
                        else
                        {
                            num2 = qyt;
                        }
                        qyt -= num2;
                        sr.BaseStream.Read(array, 0, num2);
                        num = array.getcrc(num, 0, num2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("校验HMI文件出现错误:".Language() + ex.Message);
            }
            return num;
        }

        public static bool CheckData(StreamReader sr, byte mark, byte state)
        {
            bool result;
            if (sr.BaseStream.Length <= (long)Marshal.SizeOf(default(appinf0)))
            {
                MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language());
                sr.Close();
                sr.Dispose();
                result = false;
            }
            else
            {
                sr.BaseStream.Position = 0L;
                byte[] array = new byte[datasize.appxinxisize0];
                sr.BaseStream.Read(array, 0, datasize.appxinxisize0);
                appinf0 appinf = (appinf0)array.BytesTostruct(default(appinf0).GetType());
                if (appinf.mark == 72)
                {
                    appinf.mark = 79;
                }
                if (appinf.mark != mark)
                {
                    MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language());
                    sr.Close();
                    sr.Dispose();
                    result = false;
                }
                else
                {
                    if (appinf.banbenh > 0 || appinf.banbenl > 32)
                    {
                        array = new byte[4];
                        sr.BaseStream.Position = sr.BaseStream.Length - 4L;
                        sr.BaseStream.Read(array, 0, array.Length);
                        uint num = (uint)array.BytesTostruct(0u.GetType());
                        num ^= (uint)((byte)appinf.Modelcrc);
                        num ^= (uint)appinf.mark;
                        num ^= (uint)((byte)appinf.datasize);
                        if (Kuozhan.getfilecrc(sr, 0, (int)(sr.BaseStream.Length - 4L)) != num)
                        {
                            MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language());
                            sr.Close();
                            sr.Dispose();
                            result = false;
                            return result;
                        }
                    }
                    if (datasize.banbenh != 0 || datasize.banbenl != 8)
                    {
                        if (state == 0)
                        {
                            if (appinf.filever > datasize.filever)
                            {
                                if (appinf.banbenh != 0 || appinf.banbenl >= 38)
                                {
                                    MessageOpen.Show(string.Concat(new string[]
                                    {
                                        "此资源文件是由更高的软件版本制作的(V".Language(),
                                        appinf.banbenh.ToString(),
                                        ".",
                                        appinf.banbenl.ToString(),
                                        "),请升级您的软件版本".Language()
                                    }));
                                    sr.Close();
                                    sr.Dispose();
                                    result = false;
                                    return result;
                                }
                            }
                        }
                        else if (appinf.banbenh != datasize.banbenh || appinf.banbenl != datasize.banbenl)
                        {
                            MessageOpen.Show("Version mismatch:" + appinf.banbenh.ToString() + "." + appinf.banbenl.ToString());
                            sr.Close();
                            sr.Dispose();
                            result = false;
                            return result;
                        }
                    }
                    result = true;
                }
            }
            return result;
        }
    }
}
