using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace hmitype
{
    public class Myapp_inf
    {
        public delegate void appchangevent(bool chang);

        public delegate void savetempfile_();

        public delegate void refzikuevent_();

        public delegate void refpicevent_();

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct pagefiletype
        {
            public byte filever;

            public byte hmibiaoshiH;

            public byte resa;

            public byte resb;

            public byte resc;

            public byte resd;

            public uint pagexinxiadd;

            public ushort pagexinxiqyt;

            public uint objxinxiadd;

            public ushort objxinxiqyt;

            public uint strxinxiadd;

            public uint strxinxiqyt;

            public uint zikuxinxiadd;

            public byte zikuxinxiqyt;

            public uint picxinxiadd;

            public ushort picxinxiqyt;

            public uint strdataadd;

            public uint zikudataadd;

            public uint picdataadd;

            public uint res0;

            public uint res1;

            public uint res2;

            public uint res3;

            public uint res4;

            public uint res5;

            public uint res6;

            public uint res7;

            public uint res8;

            public uint res9;

            public uint res10;
        }

        public int[] codeqyt = new int[2];

        public List<bianyijieguotype> bianyijieguo = new List<bianyijieguotype>();

        public RichTextBox bianyitext;

        public byte guidire;

        public ushort lcdwidth;

        public ushort lcdheight;

        public List<mpage> pages = new List<mpage>();

        public List<guiimagetype> images = new List<guiimagetype>();

        public List<zimoxinxi> zimos = new List<zimoxinxi>();

        public List<byte[]> zimodatas = new List<byte[]>();

        public List<byte[]> Staticstring = new List<byte[]>();

        public bool changapp = false;

        public bool redianidshow = true;

        public databianyitype databianyi;

        public Myapp_inf.appchangevent changappevent;

        public Myapp_inf.savetempfile_ savetempfile;

        public Myapp_inf.refzikuevent_ refzikuevent;

        public Myapp_inf.refpicevent_ refpicevent;

        public int errors;

        public int warnings;

        public byte myencode;

        public byte xilie = 0;

        public modelxinxi Model;

        public List<int> systimers = new List<int>();

        public int xunhuanmark = 0;

        public List<mobj> copymobjs;

        public List<keyboardlisttype> Keyboardlist = new List<keyboardlisttype>();

        public int getbianyijieguotypeindex(int index)
        {
            int result;
            for (int i = 0; i < this.bianyijieguo.Count; i++)
            {
                if (this.bianyijieguo[i].Textlinindex == index)
                {
                    result = i;
                    return result;
                }
            }
            result = -1;
            return result;
        }

        public void addbianyisuc(string str)
        {
            this.addbianyisuc(str, Color.Black);
        }

        public void addbianyisuc(string str, Color color)
        {
            bianyijieguotype item = default(bianyijieguotype);
            item.pageid = 65535;
            item.Message = str;
            this.bianyijieguo.Add(item);
            if (this.bianyitext.Lines.Length == 0)
            {
                this.bianyitext.AppendText(str);
            }
            else
            {
                this.bianyitext.AppendText("\r\n" + str);
            }
            this.bianyitext.SelectionStart = this.bianyitext.Text.Length - str.Length;
            this.bianyitext.SelectionLength = str.Length;
            this.bianyitext.SelectionColor = color;
            this.bianyitext.SelectionStart = this.bianyitext.Text.Length;
            this.bianyitext.SelectionLength = 0;
            this.bianyitext.ScrollToCaret();
        }

        public void Addbianyierr(string str)
        {
            this.Addbianyierr(str, new bianyijieguotype
            {
                pageid = 65535
            });
        }

        public void Addbianyierr(string str, bianyijieguotype b)
        {
            str = "错误:".Language() + str;
            b.Message = str;
            b.Textlinindex = this.bianyitext.Lines.Length;
            this.bianyijieguo.Add(b);
            if (this.bianyitext.Lines.Length == 0)
            {
                this.bianyitext.AppendText(str);
            }
            else
            {
                this.bianyitext.AppendText("\r\n" + str);
            }
            try
            {
                this.bianyitext.SelectionStart = this.bianyitext.Text.Length - str.Length;
                this.bianyitext.SelectionLength = str.Length;
                this.bianyitext.SelectionColor = Color.Red;
                this.bianyitext.SelectionStart = this.bianyitext.Text.Length;
                this.bianyitext.SelectionLength = 0;
                this.bianyitext.ScrollToCaret();
            }
            catch
            {
            }
            this.errors++;
        }

        public void Addbianyijinggao(string str)
        {
            this.Addbianyijinggao(str, new bianyijieguotype
            {
                pageid = 65535
            });
        }

        public void Addbianyijinggao(string str, bianyijieguotype b)
        {
            str = "警告：".Language() + str;
            b.Message = str;
            b.Textlinindex = this.bianyitext.Lines.Length;
            this.bianyijieguo.Add(b);
            if (this.bianyitext.Lines.Length == 0)
            {
                this.bianyitext.AppendText(str);
            }
            else
            {
                this.bianyitext.AppendText("\r\n" + str);
            }
            this.bianyitext.SelectionStart = this.bianyitext.Text.Length - str.Length;
            this.bianyitext.SelectionLength = str.Length;
            this.bianyitext.SelectionColor = Color.Blue;
            this.bianyitext.SelectionStart = this.bianyitext.Text.Length;
            this.bianyitext.SelectionLength = 0;
            this.bianyitext.ScrollToCaret();
            this.warnings++;
        }

        public mpage Copypage(mpage page)
        {
            mpage mpage = this.Creatnewpage(false);
            mpage.mypage = page.mypage;
            foreach (mobj current in page.objs)
            {
                mobj mobj = new mobj(this, mpage);
                mobj.objname = current.objname;
                mobj.myobj = current.myobj;
                mobj.Putcodes(current.Getcodes(), "E", datasize.filever);
                mpage.objs.Add(mobj);
            }
            this.RefobjID(mpage);
            return mpage;
        }

        public bool Getpagenamecrcbytes(ref byte[] bt)
        {
            int num = Marshal.SizeOf(default(nameidtypecrc));
            List<nameidtypecrc> list = new List<nameidtypecrc>();
            List<string> list2 = new List<string>();
            bool result;
            for (int i = 0; i < this.pages.Count; i++)
            {
                nameidtypecrc item = default(nameidtypecrc);
                item.id = (ushort)i;
                item.crc = this.pages[i].pagename.GetbytesssASCII(14).getcrc(0);
                int j;
                for (j = 0; j < list.Count; j++)
                {
                    if (item.crc < list[j].crc)
                    {
                        list2.Insert(j, this.pages[i].pagename);
                        list.Insert(j, item);
                        j = 65535;
                    }
                    else if (item.crc == list[j].crc)
                    {
                        this.Addbianyierr("名称非法(CRC重复):".Language() + list2[j] + "-" + this.pages[i].pagename);
                        this.errors++;
                        result = false;
                        return result;
                    }
                }
                if (j == 0 || j == list.Count)
                {
                    list2.Add(this.pages[i].pagename);
                    list.Add(item);
                }
            }
            bt = new byte[num * this.pages.Count];
            for (int i = 0; i < list.Count; i++)
            {
                list[i].structToBytes().CopyTo(bt, i * num);
            }
            result = true;
            return result;
        }

        public int Getpagename(string str)
        {
            int result;
            for (int i = 0; i < this.pages.Count; i++)
            {
                if (this.pages[i].pagename == str)
                {
                    result = i;
                    return result;
                }
            }
            result = 65535;
            return result;
        }

        public mpage Creatnewpage(bool iscreatobj0)
        {
            mpage mpage = new mpage(this);
            mpage.pagename = "page0";
            if (this.findpagename(mpage.pagename, 65535) != -1)
            {
                mpage.pagename = this.getpagename_key("page");
            }
            mpage result;
            if (!iscreatobj0)
            {
                result = mpage;
            }
            else
            {
                mobj mobj = new mobj(this, mpage);
                mobj.Myapp = this;
                mobj.objname = mpage.pagename;
                mpage.objs.Add(mobj);
                this.RefobjID(mpage);
                mobj.Setscreenxy();
                result = mpage;
            }
            return result;
        }

        public string getpagename_key(string key)
        {
            string text = "";
            for (int i = 0; i < 65535; i++)
            {
                text = key + i.ToString();
                if (this.findpagename(text, 65535) == -1 && text.ishefaname() == "")
                {
                    break;
                }
            }
            return text;
        }

        public void RefAllID()
        {
            this.RefpageID();
            for (int i = 0; i < this.pages.Count; i++)
            {
                this.RefobjID(this.pages[i]);
            }
        }

        public void RefpageID()
        {
            for (int i = 0; i < this.pages.Count; i++)
            {
                this.pages[i].pageid = i;
            }
        }

        public void RefobjID(mpage page)
        {
            for (int i = 0; i < page.objs.Count; i++)
            {
                page.objs[i].objid = i;
            }
        }

        private byte findnewid(List<byte> ids, byte oldid)
        {
            byte b = 0;
            byte result;
            while ((int)b < ids.Count)
            {
                if (ids[(int)b] == oldid)
                {
                    result = b;
                    return result;
                }
                b += 1;
            }
            result = 255;
            return result;
        }

        private void findziku(mpage page1, ref List<zimoxinxi> zimoxinxis1, ref List<byte[]> zimodatas1)
        {
            List<byte> list = new List<byte>();
            foreach (mobj current in page1.objs)
            {
                foreach (matt current2 in current.atts)
                {
                    if (current2.att.attlei == attshulei.Font.typevalue)
                    {
                        if (current.checkatt(current2) && (int)current2.zhi[0] < page1.Myapp.zimos.Count)
                        {
                            byte b = this.findnewid(list, current2.zhi[0]);
                            if (b == 255)
                            {
                                b = (byte)list.Count;
                                list.Add(current2.zhi[0]);
                            }
                            current2.zhi[0] = b;
                        }
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                zimoxinxis1.Add(page1.Myapp.zimos[(int)list[i]]);
                byte[] array = new byte[page1.Myapp.zimodatas[(int)list[i]].Length];
                page1.Myapp.zimodatas[(int)list[i]].CopyTo(array, 0);
                zimodatas1.Add(array);
            }
        }

        private void findimage(mpage page1, ref List<guiimagetype> pageimages)
        {
            List<byte> list = new List<byte>();
            foreach (mobj current in page1.objs)
            {
                foreach (matt current2 in current.atts)
                {
                    if (current2.att.attlei == attshulei.Picid.typevalue)
                    {
                        if (current.checkatt(current2) && (int)current2.zhi[0] < page1.Myapp.images.Count)
                        {
                            byte b = this.findnewid(list, current2.zhi[0]);
                            if (b == 255)
                            {
                                b = (byte)list.Count;
                                list.Add(current2.zhi[0]);
                            }
                            current2.zhi[0] = b;
                        }
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                guiimagetype item = page1.Myapp.images[(int)list[i]];
                item.picturexinxi.imgbytesize = (uint)(item.imagebytes.Length + item.imgxulie.Length);
                item.picturexinxi.imgxuliebeg = (uint)item.imagebytes.Length;
                pageimages.Add(item);
            }
        }

        public bool putpage(mpage page1)
        {
            bool result;
            try
            {
                uint num = Convert.ToUInt32("0xFFFFFFFF", 16);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "page|*.page|所有文件|*.*".Language();
                saveFileDialog.Getpath("pagefile");
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    result = false;
                }
                else
                {
                    string fileName = saveFileDialog.FileName;
                    saveFileDialog.Putpath("pagefile");
                    if (File.Exists(fileName))
                    {
                        if (!Kuozhan.delfile(fileName))
                        {
                            result = false;
                            return result;
                        }
                    }
                    string pagename = page1.pagename;
                    page1 = this.Copypage(page1);
                    page1.pagename = pagename;
                    page1.objs[0].objname = pagename;
                    List<zimoxinxi> list = new List<zimoxinxi>();
                    List<byte[]> list2 = new List<byte[]>();
                    this.findziku(page1, ref list, ref list2);
                    List<guiimagetype> list3 = new List<guiimagetype>();
                    this.findimage(page1, ref list3);
                    pagexinxi_up mypage = page1.mypage;
                    mypage.name = (bytes_14)page1.pagename.GetbytesssASCII(14).BytesTostruct(default(bytes_14).GetType());
                    mypage.objstar = 0;
                    mypage.objqyt = (byte)page1.objs.Count;
                    objxinxi[] array = new objxinxi[page1.objs.Count];
                    List<byte[]> list4 = new List<byte[]>();
                    for (int i = 0; i < page1.objs.Count; i++)
                    {
                        array[i] = page1.objs[i].myobj;
                        array[i].name = (bytes_14)page1.objs[i].objname.GetbytesssASCII(14).BytesTostruct(default(bytes_14).GetType());
                        array[i].zhilingstar = (ushort)list4.Count;
                        page1.objs[i].Getcodes(ref list4);
                        array[i].zhilingend = (ushort)(list4.Count - 1);
                    }
                    strxinxi[] array2 = new strxinxi[list4.Count];
                    uint num2 = 0u;
                    for (int i = 0; i < list4.Count; i++)
                    {
                        array2[i].addbeg = num2;
                        array2[i].size = (ushort)list4[i].Length;
                        num2 += (uint)array2[i].size;
                    }
                    uint num3 = 0u;
                    for (int i = 0; i < list2.Count; i++)
                    {
                        num3 += (uint)list2[i].Length;
                    }
                    Myapp_inf.pagefiletype pagefiletype = default(Myapp_inf.pagefiletype);
                    pagefiletype.filever = datasize.filever;
                    pagefiletype.hmibiaoshiH = datasize.hmibiaoshiH;
                    pagefiletype.pagexinxiadd = (uint)Marshal.SizeOf(default(Myapp_inf.pagefiletype));
                    pagefiletype.pagexinxiqyt = 1;
                    pagefiletype.objxinxiadd = (uint)((ulong)pagefiletype.pagexinxiadd + (ulong)((long)(Marshal.SizeOf(default(pagexinxi_up)) * (int)pagefiletype.pagexinxiqyt)));
                    pagefiletype.objxinxiqyt = (ushort)page1.objs.Count;
                    pagefiletype.strxinxiadd = (uint)((ulong)pagefiletype.objxinxiadd + (ulong)((long)(Marshal.SizeOf(default(objxinxi)) * (int)pagefiletype.objxinxiqyt)));
                    pagefiletype.strxinxiqyt = (uint)list4.Count;
                    pagefiletype.zikuxinxiadd = (uint)((ulong)pagefiletype.strxinxiadd + (ulong)((long)Marshal.SizeOf(default(strxinxi)) * (long)((ulong)pagefiletype.strxinxiqyt)));
                    pagefiletype.zikuxinxiqyt = (byte)list.Count;
                    pagefiletype.picxinxiadd = (uint)((ulong)pagefiletype.zikuxinxiadd + (ulong)((long)(Marshal.SizeOf(default(zimoxinxi)) * (int)pagefiletype.zikuxinxiqyt)));
                    pagefiletype.picxinxiqyt = (ushort)list3.Count;
                    pagefiletype.strdataadd = (uint)((ulong)pagefiletype.picxinxiadd + (ulong)((long)(Marshal.SizeOf(default(Picturexinxi)) * (int)pagefiletype.picxinxiqyt)));
                    pagefiletype.zikudataadd = pagefiletype.strdataadd + num2;
                    pagefiletype.picdataadd = pagefiletype.zikudataadd + num3;
                    StreamWriter streamWriter = new StreamWriter(fileName);
                    byte[] array3 = pagefiletype.structToBytes().pagefree(datasize.apppasseord, datasize.hmibiaoshiH);
                    streamWriter.BaseStream.Write(array3, 0, array3.Length);
                    num = array3.getcrc(num, 0, array3.Length);
                    array3 = mypage.structToBytes();
                    streamWriter.BaseStream.Write(array3, 0, array3.Length);
                    num = array3.getcrc(num, 0, array3.Length);
                    for (int i = 0; i < array.Length; i++)
                    {
                        array3 = array[i].structToBytes();
                        streamWriter.BaseStream.Write(array3, 0, array3.Length);
                        num = array3.getcrc(num, 0, array3.Length);
                    }
                    for (int i = 0; i < array2.Length; i++)
                    {
                        array3 = array2[i].structToBytes();
                        streamWriter.BaseStream.Write(array3, 0, array3.Length);
                        num = array3.getcrc(num, 0, array3.Length);
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        array3 = list[i].structToBytes();
                        streamWriter.BaseStream.Write(array3, 0, array3.Length);
                        num = array3.getcrc(num, 0, array3.Length);
                    }
                    for (int i = 0; i < list3.Count; i++)
                    {
                        array3 = list3[i].picturexinxi.structToBytes();
                        streamWriter.BaseStream.Write(array3, 0, array3.Length);
                        num = array3.getcrc(num, 0, array3.Length);
                    }
                    for (int i = 0; i < list4.Count; i++)
                    {
                        streamWriter.BaseStream.Write(list4[i], 0, list4[i].Length);
                        num = list4[i].getcrc(num, 0, list4[i].Length);
                    }
                    for (int i = 0; i < list2.Count; i++)
                    {
                        streamWriter.BaseStream.Write(list2[i], 0, list2[i].Length);
                        num = list2[i].getcrc(num, 0, list2[i].Length);
                    }
                    for (int i = 0; i < list3.Count; i++)
                    {
                        streamWriter.BaseStream.Write(list3[i].imagebytes, 0, list3[i].imagebytes.Length);
                        num = list3[i].imagebytes.getcrc(num, 0, list3[i].imagebytes.Length);
                        streamWriter.BaseStream.Write(list3[i].imgxulie, 0, list3[i].imgxulie.Length);
                        num = list3[i].imgxulie.getcrc(num, 0, list3[i].imgxulie.Length);
                    }
                    num = Encoding.ASCII.GetBytes("pagefile").getcrc(num, 0);
                    array3 = num.structToBytes();
                    streamWriter.BaseStream.Write(array3, 0, array3.Length);
                    page1 = null;
                    streamWriter.Close();
                    streamWriter.Dispose();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = false;
            }
            return result;
        }

        public int Loadpage(string path, byte pagelei, string pagename, int insertid)
        {
            int result;
            try
            {
                if (pagename != "" && this.findpagename(pagename, 65535) != -1)
                {
                    result = this.findpagename(pagename, 65535);
                }
                else
                {
                    if (path == "")
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "page|*.page|所有文件|*.*".Language();
                        openFileDialog.Getpath("pagefile");
                        if (openFileDialog.ShowDialog() != DialogResult.OK)
                        {
                            result = -1;
                            return result;
                        }
                        path = openFileDialog.FileName;
                        openFileDialog.Putpath("pagefile");
                    }
                    if (!File.Exists(path))
                    {
                        MessageOpen.Show("文件路径失效".Language() + "\r\n" + path);
                        result = -1;
                    }
                    else
                    {
                        int count = this.zimos.Count;
                        int count2 = this.images.Count;
                        Myapp_inf.pagefiletype pagefiletype = default(Myapp_inf.pagefiletype);
                        StreamReader streamReader = new StreamReader(path);
                        byte[] array = new byte[Marshal.SizeOf(default(Myapp_inf.pagefiletype))];
                        streamReader.BaseStream.Position = 0L;
                        streamReader.BaseStream.Read(array, 0, array.Length);
                        pagefiletype = (Myapp_inf.pagefiletype)array.BytesTostruct(default(Myapp_inf.pagefiletype).GetType());
                        if (pagefiletype.filever > 14)
                        {
                            array = new byte[streamReader.BaseStream.Length];
                            streamReader.BaseStream.Position = 0L;
                            streamReader.BaseStream.Read(array, 0, array.Length);
                            uint num = array.getcrc(Convert.ToUInt32("0xFFFFFFFF", 16), 0, array.Length - 4);
                            num = Encoding.ASCII.GetBytes("pagefile").getcrc(num, 0);
                            if (!Kuozhan.makebytes(num.structToBytes(), array.subbytes(array.Length - 4, 4)))
                            {
                                MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language() + "\r\n" + path);
                                result = -1;
                                return result;
                            }
                        }
                        if (pagefiletype.hmibiaoshiH != datasize.hmibiaoshiH)
                        {
                            MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language() + "\r\n" + path);
                            result = -1;
                        }
                        else
                        {
                            array = array.pagefree(datasize.apppasseord, datasize.hmibiaoshiH);
                            pagefiletype = (Myapp_inf.pagefiletype)array.BytesTostruct(default(Myapp_inf.pagefiletype).GetType());
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.pagexinxiadd);
                            array = new byte[Marshal.SizeOf(default(pagexinxi_up))];
                            streamReader.BaseStream.Read(array, 0, array.Length);
                            pagexinxi_up mypage = (pagexinxi_up)array.BytesTostruct(default(pagexinxi_up).GetType());
                            if (pagename != "")
                            {
                                mypage.name = (bytes_14)pagename.GetbytesssASCII(14).BytesTostruct(default(bytes_14).GetType());
                            }
                            mypage.pagelei = pagelei;
                            objxinxi[] array2 = new objxinxi[(int)pagefiletype.objxinxiqyt];
                            strxinxi[] array3 = new strxinxi[pagefiletype.strxinxiqyt];
                            zimoxinxi[] array4 = new zimoxinxi[(int)pagefiletype.zikuxinxiqyt];
                            guiimagetype[] array5 = new guiimagetype[(int)pagefiletype.picxinxiqyt];
                            List<byte[]> list = new List<byte[]>();
                            List<byte[]> list2 = new List<byte[]>();
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.objxinxiadd);
                            int i;
                            for (i = 0; i < (int)pagefiletype.objxinxiqyt; i++)
                            {
                                array = new byte[Marshal.SizeOf(default(objxinxi))];
                                streamReader.BaseStream.Read(array, 0, array.Length);
                                array2[i] = (objxinxi)array.BytesTostruct(default(objxinxi).GetType());
                            }
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.strxinxiadd);
                            i = 0;
                            while ((long)i < (long)((ulong)pagefiletype.strxinxiqyt))
                            {
                                array = new byte[Marshal.SizeOf(default(strxinxi))];
                                streamReader.BaseStream.Read(array, 0, array.Length);
                                array3[i] = (strxinxi)array.BytesTostruct(default(strxinxi).GetType());
                                i++;
                            }
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.zikuxinxiadd);
                            for (i = 0; i < (int)pagefiletype.zikuxinxiqyt; i++)
                            {
                                array = new byte[Marshal.SizeOf(default(zimoxinxi))];
                                streamReader.BaseStream.Read(array, 0, array.Length);
                                array4[i] = (zimoxinxi)array.BytesTostruct(default(zimoxinxi).GetType());
                            }
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.picxinxiadd);
                            for (i = 0; i < (int)pagefiletype.picxinxiqyt; i++)
                            {
                                array = new byte[Marshal.SizeOf(default(Picturexinxi))];
                                streamReader.BaseStream.Read(array, 0, array.Length);
                                array5[i].picturexinxi = (Picturexinxi)array.BytesTostruct(default(Picturexinxi).GetType());
                            }
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.strdataadd);
                            for (i = 0; i < array3.Length; i++)
                            {
                                array = new byte[(int)array3[i].size];
                                streamReader.BaseStream.Read(array, 0, array.Length);
                                list2.Add(array);
                            }
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.zikudataadd);
                            for (i = 0; i < array4.Length; i++)
                            {
                                array = new byte[array4[i].size];
                                streamReader.BaseStream.Read(array, 0, array.Length);
                                list.Add(array);
                            }
                            streamReader.BaseStream.Position = (long)((ulong)pagefiletype.picdataadd);
                            for (i = 0; i < array5.Length; i++)
                            {
                                array5[i].imagebytes = new byte[array5[i].picturexinxi.imgxuliebeg];
                                streamReader.BaseStream.Read(array5[i].imagebytes, 0, array5[i].imagebytes.Length);
                                array5[i].imgxulie = new byte[array5[i].picturexinxi.imgbytesize - array5[i].picturexinxi.imgxuliebeg];
                                streamReader.BaseStream.Read(array5[i].imgxulie, 0, array5[i].imgxulie.Length);
                                array5[i].picturexinxi.imgbytesize = (uint)array5[i].imagebytes.Length;
                                array5[i].imagebitbmp = (array5[i].imgxulie.BytesToClass() as Bitmap);
                            }
                            streamReader.Close();
                            streamReader.Dispose();
                            mpage mpage = new mpage(this);
                            mpage.mypage = mypage;
                            mpage.pagename = mypage.name.structToBytes().Getstring(datasize.Myencoding);
                            List<byte[]> list3 = new List<byte[]>();
                            for (i = 0; i < (int)pagefiletype.objxinxiqyt; i++)
                            {
                                mobj mobj = new mobj(this, mpage);
                                mobj.myobj = array2[i];
                                mobj.objname = array2[i].name.structToBytes().Getstring(datasize.Myencoding);
                                list3.Clear();
                                for (int j = (int)array2[i].zhilingstar; j < (int)(array2[i].zhilingend + 1); j++)
                                {
                                    list3.Add(list2[j]);
                                }
                                mobj.Putcodes(list3, "E", pagefiletype.filever);
                                mpage.objs.Add(mobj);
                                this.RefobjID(mpage);
                            }
                            if (this.findpagename(mpage.pagename, 65535) != -1 || (pagelei == 0 && mpage.pagename.ishefaname() != ""))
                            {
                                mpage.pagename = this.getpagename_key(mpage.pagename);
                            }
                            mpage.objs[0].objname = mpage.pagename;
                            mpage.objs[0].Setscreenxy();
                            List<byte> list4 = new List<byte>();
                            string text = "";
                            for (i = 0; i < array4.Length; i++)
                            {
                                byte item = this.initfont(array4[i], list[i]);
                                list4.Add(item);
                                string text2 = text;
                                text = string.Concat(new string[]
                                {
                                    text2,
                                    Encoding.Default.GetString(this.zimodatas[i], 0, (int)array4[i].ascstar),
                                    "(size:",
                                    array4[i].w.ToString(),
                                    "X",
                                    array4[i].h.ToString(),
                                    ",encode:",
                                    array4[i].encode.GetencodeName(),
                                    ",qyt:",
                                    array4[i].qyt.ToString(),
                                    ",datasize:",
                                    array4[i].size.ToString("0,000"),
                                    ")\r\n"
                                });
                            }
                            foreach (mobj mobj in mpage.objs)
                            {
                                //mobj mobj;
                                foreach (matt current in mobj.atts)
                                {
                                    if (current.att.attlei == attshulei.Font.typevalue)
                                    {
                                        if ((int)current.zhi[0] < list4.Count)
                                        {
                                            current.zhi[0] = list4[(int)current.zhi[0]];
                                        }
                                    }
                                }
                            }
                            list4.Clear();
                            for (i = 0; i < array5.Length; i++)
                            {
                                byte item = this.initpic(array5[i]);
                                list4.Add(item);
                            }
                            foreach (mobj mobj in mpage.objs)
                            {
                                //mobj mobj;
                                foreach (matt current in mobj.atts)
                                {
                                    if (current.att.attlei == attshulei.Picid.typevalue)
                                    {
                                        if ((int)current.zhi[0] < list4.Count)
                                        {
                                            current.zhi[0] = list4[(int)current.zhi[0]];
                                        }
                                    }
                                }
                            }
                            if (insertid < 0 || insertid >= this.pages.Count)
                            {
                                this.pages.Add(mpage);
                            }
                            else
                            {
                                this.pages.Insert(insertid, mpage);
                            }
                            this.RefpageID();
                            if (count != this.zimos.Count || count2 != this.images.Count)
                            {
                                new datazhuan(this).ShowDialog();
                                if (this.refzikuevent != null)
                                {
                                    this.refzikuevent();
                                }
                                if (this.refpicevent != null)
                                {
                                    this.refpicevent();
                                }
                                if (this.savetempfile != null)
                                {
                                    this.savetempfile();
                                }
                                if (this.changappevent != null)
                                {
                                    this.changappevent(true);
                                }
                                if (count != this.zimos.Count)
                                {
                                    MessageOpen.Show("已向工程中添加如下字库:".Language() + "\r\n" + text);
                                }
                            }
                            result = mpage.pageid;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = -1;
            }
            return result;
        }

        private byte initfont(zimoxinxi zimoxinxi1, byte[] zimodata1)
        {
            byte result;
            for (int i = 0; i < this.zimos.Count; i++)
            {
                if (this.zimos[i].h == zimoxinxi1.h && this.zimos[i].encode == zimoxinxi1.encode && this.zimos[i].state == zimoxinxi1.state)
                {
                    result = (byte)i;
                    return result;
                }
            }
            this.zimos.Add(zimoxinxi1);
            byte[] array = new byte[zimodata1.Length];
            zimodata1.CopyTo(array, 0);
            this.zimodatas.Add(array);
            result = (byte)(this.zimos.Count - 1);
            return result;
        }

        private byte initpic(guiimagetype img1)
        {
            byte result;
            for (int i = 0; i < this.images.Count; i++)
            {
                if (this.images[i].picturexinxi.W == img1.picturexinxi.W && this.images[i].picturexinxi.H == img1.picturexinxi.H && Kuozhan.makebytes(this.images[i].imgxulie, img1.imgxulie))
                {
                    result = (byte)i;
                    return result;
                }
            }
            this.images.Add(img1);
            result = (byte)(this.images.Count - 1);
            return result;
        }

        public void loadkeyboardlist()
        {
            string str = this.lcdwidth.ToString() + this.lcdheight.ToString();
            string str2;
            if (datasize.Language == 0)
            {
                str2 = Application.StartupPath + "\\keyboardch";
            }
            else
            {
                str2 = Application.StartupPath + "\\keyboarden";
            }
            this.Keyboardlist.Clear();
            keyboardlisttype item = new keyboardlisttype
            {
                id = 1,
                showname = "全键盘".Language(),
                pagename = "keybdA",
                filepath = str2 + "\\" + str + "\\1.page"
            };
            this.Keyboardlist.Add(item);
            item = new keyboardlisttype
            {
                id = 2,
                showname = "数字键盘".Language(),
                pagename = "keybdB",
                filepath = str2 + "\\" + str + "\\2.page"
            };
            this.Keyboardlist.Add(item);
            item = new keyboardlisttype
            {
                id = 3,
                showname = "九宫格键盘".Language(),
                pagename = "keybdC",
                filepath = str2 + "\\" + str + "\\3.page"
            };
            this.Keyboardlist.Add(item);
            if (datasize.Language == 0)
            {
                item = new keyboardlisttype
                {
                    id = 4,
                    showname = "输入法全键盘".Language(),
                    pagename = "keybdAP",
                    filepath = str2 + "\\" + str + "\\4.page"
                };
                this.Keyboardlist.Add(item);
            }
        }

        public keyboardlisttype getkeyboardlisttype(byte id)
        {
            keyboardlisttype result;
            foreach (keyboardlisttype current in this.Keyboardlist)
            {
                if (current.id == id)
                {
                    result = current;
                    return result;
                }
            }
            result = new keyboardlisttype
            {
                id = 255,
                pagename = "",
                showname = "无".Language(),
                filepath = ""
            };
            return result;
        }

        public keyboardlisttype getkeyboardlisttype(string pagename)
        {
            keyboardlisttype result;
            foreach (keyboardlisttype current in this.Keyboardlist)
            {
                if (current.pagename == pagename)
                {
                    result = current;
                    return result;
                }
            }
            result = new keyboardlisttype
            {
                id = 255,
                pagename = "",
                showname = "无".Language(),
                filepath = ""
            };
            return result;
        }

        public int Addkeyboard(keyboardlisttype key1, int insertid)
        {
            int result;
            if (key1.id == 255)
            {
                result = -1;
            }
            else
            {
                int num = this.findpagename(key1.pagename, 65535);
                if (num != -1)
                {
                    result = num;
                }
                else if (!File.Exists(key1.filepath))
                {
                    MessageOpen.Show("文件路径失效".Language() + "\r\n" + key1.filepath);
                    result = -1;
                }
                else
                {
                    int num2 = this.Loadpage(key1.filepath, key1.id, key1.pagename, insertid);
                    if (num2 == -1)
                    {
                        result = -1;
                    }
                    else
                    {
                        this.pages[num2].mypage.pagelock = 1;
                        result = num2;
                    }
                }
            }
            return result;
        }

        public bool resetkeyboard(int pageid)
        {
            keyboardlisttype key = this.getkeyboardlisttype(this.pages[pageid].mypage.pagelei);
            bool result;
            if (key.id != 255)
            {
                if (!File.Exists(key.filepath))
                {
                    MessageOpen.Show("文件路径失效".Language() + "\r\n" + key.filepath);
                    result = false;
                }
                else
                {
                    this.delpage(pageid, true);
                    result = (this.Addkeyboard(key, pageid) >= 0);
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool resetpage(int pageindex)
        {
            bool result;
            if (pageindex < this.pages.Count)
            {
                if (this.pages[pageindex].mypage.pagelei > 0 && this.pages[pageindex].mypage.pagelei < 21)
                {
                    if (this.resetkeyboard(pageindex))
                    {
                        result = true;
                        return result;
                    }
                }
            }
            MessageOpen.Show("重置系统页面失败".Language());
            result = false;
            return result;
        }

        public int addstaticstring(byte[] str)
        {
            if (str[str.Length - 1] != 0)
            {
                str = Kuozhan.Gethebingbytes(str, new byte[1]);
                str[str.Length - 1] = 0;
            }
            int result;
            for (int i = 0; i < this.Staticstring.Count; i++)
            {
                if (Kuozhan.makebytes(this.Staticstring[i], str))
                {
                    result = this.staticstringdextobeg(i);
                    return result;
                }
            }
            this.Staticstring.Add(str);
            result = this.staticstringdextobeg(this.Staticstring.Count - 1);
            return result;
        }

        public int staticstringdextobeg(int index)
        {
            int num = 0;
            for (int i = 0; i < index; i++)
            {
                num += this.Staticstring[i].Length;
            }
            return num;
        }

        public int getstaticstringdataqyt()
        {
            int num = 0;
            for (int i = 0; i < this.Staticstring.Count; i++)
            {
                num += this.Staticstring[i].Length;
            }
            return num;
        }

        public Myapp_inf()
        {
            this.copymobjs = new List<mobj>();
            this.lcdwidth = 320;
            this.lcdheight = 240;
            this.myencode = Encoding.Default.BodyName.GetencodeId();
            if (datasize.Language == 1 && this.myencode == 2)
            {
                this.myencode = 3;
            }
            datasize.Myencoding = Encoding.GetEncoding(datasize.encodes_App[(int)this.myencode].encodename);
        }

        public bool Open(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            bool result;
            try
            {
                if (!Kuozhan.CheckData(streamReader, datasize.hmibiaoshiH, 0))
                {
                    result = false;
                }
                else if (!this.readdatathis(streamReader))
                {
                    MessageOpen.Show("错误的资源文件或者资源文件已经受损".Language());
                    streamReader.Close();
                    streamReader.Dispose();
                    result = false;
                }
                else
                {
                    streamReader.Close();
                    streamReader.Dispose();
                    this.loadkeyboardlist();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = false;
            }
            return result;
        }

        public int getobjqyt()
        {
            int num = 0;
            foreach (mpage current in this.pages)
            {
                num += current.objs.Count;
            }
            return num;
        }

        public void Addziku(string path, string lei, int index)
        {
            this.Addziku(new string[]
            {
                path
            }, lei, index);
        }

        public void Addziku(string[] paths, string lei, int index)
        {
            int num = 0;
            int num2 = Marshal.SizeOf(default(zimoxinxi));
            for (int i = 0; i < paths.Length; i++)
            {
                string path = paths[i];
                StreamReader streamReader = new StreamReader(path);
                byte[] array = new byte[num2];
                streamReader.BaseStream.Read(array, 0, num2);
                zimoxinxi zimoxinxi = (zimoxinxi)array.BytesTostruct(default(zimoxinxi).GetType());
                if (zimoxinxi.ver > datasize.zikuver)
                {
                    MessageOpen.Show("error fontfile ver!");
                }
                else
                {
                    if (lei == "add")
                    {
                        this.zimos.Add(zimoxinxi);
                    }
                    else if (lei == "tihuan")
                    {
                        this.zimos[index] = zimoxinxi;
                    }
                    else if (lei == "insert")
                    {
                        this.zimos.Insert(index, zimoxinxi);
                    }
                    array = new byte[zimoxinxi.size];
                    streamReader.BaseStream.Read(array, 0, array.Length);
                    if (lei == "add")
                    {
                        this.zimodatas.Add(array);
                    }
                    else if (lei == "tihuan")
                    {
                        this.zimodatas[index] = new byte[array.Length];
                        array.CopyTo(this.zimodatas[index], 0);
                    }
                    else if (lei == "insert")
                    {
                        this.zimodatas.Insert(index, array);
                    }
                    num++;
                }
                streamReader.Close();
                streamReader.Dispose();
            }
            new datazhuan(this).ShowDialog();
            if (lei == "insert")
            {
                foreach (mpage current in this.pages)
                {
                    foreach (mobj current2 in current.objs)
                    {
                        foreach (matt current3 in current2.atts)
                        {
                            if (current3.att.attlei == attshulei.Font.typevalue)
                            {
                                ushort num3 = (ushort)((byte)current3.zhi.BytesTostruct(0.GetType()));
                                if ((int)num3 >= index)
                                {
                                    current3.zhi = ((byte)((int)num3 + num)).structToBytes();
                                }
                            }
                        }
                    }
                }
                foreach (mpage current in this.pages)
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
                                        if (current3.att.attlei == attshulei.Font.typevalue)
                                        {
                                            ushort num3 = (ushort)((byte)current3.zhi.BytesTostruct(0.GetType()));
                                            if ((int)num3 >= index)
                                            {
                                                current3.zhi = ((byte)((int)num3 + num)).structToBytes();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (mobj current2 in this.copymobjs)
                {
                    foreach (matt current3 in current2.atts)
                    {
                        if (current3.att.attlei == attshulei.Font.typevalue)
                        {
                            ushort num3 = (ushort)((byte)current3.zhi.BytesTostruct(0.GetType()));
                            if ((int)num3 >= index)
                            {
                                current3.zhi = ((byte)((int)num3 + num)).structToBytes();
                            }
                        }
                    }
                }
            }
        }

        public void delzimo(int index)
        {
            this.zimos.RemoveAt(index);
            this.zimodatas.RemoveAt(index);
            if (index < this.zimos.Count)
            {
                foreach (mpage current in this.pages)
                {
                    foreach (mobj current2 in current.objs)
                    {
                        foreach (matt current3 in current2.atts)
                        {
                            if (current3.att.attlei == attshulei.Font.typevalue)
                            {
                                byte b = (byte)current3.zhi.BytesTostruct(0.GetType());
                                if ((int)b > index)
                                {
                                    current3.zhi = (b - 1).structToBytes();
                                }
                            }
                        }
                    }
                }
            }
            foreach (mpage current in this.pages)
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
                                    if (current3.att.attlei == attshulei.Font.typevalue)
                                    {
                                        byte b = (byte)current3.zhi.BytesTostruct(0.GetType());
                                        if ((int)b > index)
                                        {
                                            current3.zhi = (b - 1).structToBytes();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (mobj current2 in this.copymobjs)
            {
                foreach (matt current3 in current2.atts)
                {
                    if (current3.att.attlei == attshulei.Font.typevalue)
                    {
                        byte b = (byte)current3.zhi.BytesTostruct(0.GetType());
                        if ((int)b > index)
                        {
                            current3.zhi = (b - 1).structToBytes();
                        }
                    }
                }
            }
        }

        public void delAllzimo()
        {
            this.zimos.Clear();
            this.zimodatas.Clear();
        }

        public void delpic(int index)
        {
            this.images.RemoveAt(index);
            if (index < this.images.Count)
            {
                foreach (mpage current in this.pages)
                {
                    foreach (mobj current2 in current.objs)
                    {
                        foreach (matt current3 in current2.atts)
                        {
                            if (current3.att.attlei == attshulei.Picid.typevalue)
                            {
                                ushort num = (ushort)current3.zhi.BytesTostruct(0.GetType());
                                if ((int)num > index)
                                {
                                    current3.zhi = (num - 1).structToBytes();
                                }
                            }
                        }
                    }
                }
            }
            foreach (mpage current in this.pages)
            {
                foreach (objsetcom_P current4 in current.objsetcomps)
                {
                    foreach (objsetcom current5 in current4.objset)
                    {
                        if (current5.backobj != null)
                        {
                            foreach (matt current3 in current5.backobj.atts)
                            {
                                if (current3.att.attlei == attshulei.Picid.typevalue)
                                {
                                    ushort num = (ushort)current3.zhi.BytesTostruct(0.GetType());
                                    if ((int)num > index)
                                    {
                                        current3.zhi = (num - 1).structToBytes();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (mobj current2 in this.copymobjs)
            {
                foreach (matt current3 in current2.atts)
                {
                    if (current3.att.attlei == attshulei.Picid.typevalue)
                    {
                        ushort num = (ushort)current3.zhi.BytesTostruct(0.GetType());
                        if ((int)num > index)
                        {
                            current3.zhi = (num - 1).structToBytes();
                        }
                    }
                }
            }
        }

        public void delAllpic()
        {
            this.images.Clear();
        }

        public void delpage(int index, bool isrefid)
        {
            this.pages.RemoveAt(index);
            if (isrefid)
            {
                this.RefpageID();
            }
        }

        public void delAllpage()
        {
            this.pages.Clear();
        }

        public bool renameobj(mpage page, mobj obj, string newname)
        {
            int num = newname.GetbytesssASCII().Length;
            bool result;
            if (num == 0 || num > 14)
            {
                MessageOpen.Show("名称长度最小1字节，最大14字节".Language());
                result = false;
            }
            else
            {
                string text = newname.ishefaname();
                if (text != "")
                {
                    MessageOpen.Show(text);
                    result = false;
                }
                else if (this.findobjname(page, obj, newname))
                {
                    MessageOpen.Show("名称重复!".Language());
                    result = false;
                }
                else
                {
                    obj.objname = newname;
                    result = true;
                }
            }
            return result;
        }

        public bool findobjname(mpage page, mobj obj, string newname)
        {
            bool result;
            foreach (mobj current in page.objs)
            {
                if (current.objname == newname && current != obj)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        public void makeobjname(mpage page, mobj obj, string initname)
        {
            try
            {
                string text = initname;
                for (int i = 0; i < 255; i++)
                {
                    string text2 = text + i.ToString();
                    if (text2.GetbytesssASCII().Length > 14)
                    {
                        text = text.Substring(0, text.Length - 1);
                        i = 0;
                    }
                    else if (!this.findobjname(page, obj, text2))
                    {
                        obj.objname = text2;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        public int findpagename(string name, int noid)
        {
            PosLaction posLaction = default(PosLaction);
            posLaction.star = 0;
            posLaction.end = (ushort)(name.Length - 1);
            if (noid > this.pages.Count)
            {
                noid = this.pages.Count;
            }
            int result;
            for (int i = 0; i < noid; i++)
            {
                if (this.pages[i].pagename == name)
                {
                    result = i;
                    return result;
                }
            }
            for (int i = noid + 1; i < this.pages.Count; i++)
            {
                if (this.pages[i].pagename == name)
                {
                    result = i;
                    return result;
                }
            }
            result = -1;
            return result;
        }

        public bool Savefile(string path, int bianyi, RichTextBox text)
        {
            this.bianyitext = text;
            if (bianyi == 1)
            {
                this.bianyitext.Text = "";
                this.bianyijieguo.Clear();
                this.errors = 0;
                this.warnings = 0;
            }
            bool result;
            if (!Kuozhan.delfile(path))
            {
                result = false;
            }
            else
            {
                if (this.Savelinfile(path, bianyi))
                {
                    if (bianyi == 0 || this.errors == 0)
                    {
                        result = true;
                        return result;
                    }
                }
                result = false;
            }
            return result;
        }

        public int GetAlldataSize()
        {
            int num = 0;
            for (int i = 0; i < this.images.Count; i++)
            {
                num += this.images[i].imagebytes.Length;
            }
            for (int i = 0; i < this.zimodatas.Count; i++)
            {
                num += this.zimodatas[i].Length;
            }
            return num / 1000;
        }
    }
}
