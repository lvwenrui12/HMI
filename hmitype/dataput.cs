using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace hmitype
{
    public static class dataput
    {
        public static int strdatasize = 0;

        public static List<pagexinxi> pages_down = new List<pagexinxi>();

        public static List<objxinxi> Lobjs = new List<objxinxi>();

        public static List<byte[]> Lobjattdatapianyi = new List<byte[]>();

        public static List<strxinxi> strxinxis = new List<strxinxi>();

        public static List<byte[]> strbytes = new List<byte[]>();

        private static List<LcCL_type> LcCL_L = new List<LcCL_type>();

        private static List<LcCL_type> LcCL_S = new List<LcCL_type>();

        private static int bianyi = 0;

        public static bool Savelinfile(this Myapp_inf Myapp, string path, int isbianyi)
        {
            dataput.bianyi = isbianyi;
            StreamWriter streamWriter = new StreamWriter(path);
            appinf0 appinf = default(appinf0);
            appinf1 appinf2 = default(appinf1);
            uint num = Convert.ToUInt32("0xFFFFFFFF", 16);
            bool result;
            try
            {
                if ((int)Myapp.myencode > datasize.encodes_App.Length)
                {
                    Myapp.myencode = ((datasize.Language == 0) ? "gb2312".GetencodeId() : "iso-8859-1".GetencodeId());
                }
                appinf.banbenh = datasize.banbenh;
                appinf.banbenl = datasize.banbenl;
                appinf.filever = datasize.filever;
                appinf.mark = ((dataput.bianyi == 1) ? datasize.hmibiaoshiL : datasize.hmibiaoshiH);
                appinf.encodeh_star = datasize.encodes_App[(int)Myapp.myencode].codeh_star;
                if (!Myapp.StructHtoL(ref appinf, ref appinf2))
                {
                    if (dataput.bianyi == 1)
                    {
                        if (datasize.Language == 0)
                        {
                            Myapp.Addbianyierr(string.Concat(new object[]
                            {
                                "编译失败!".Language(),
                                " ",
                                Myapp.errors,
                                "个错误,".Language(),
                                " ",
                                Myapp.warnings.ToString(),
                                "个警告".Language()
                            }));
                        }
                        else
                        {
                            Myapp.Addbianyierr(string.Concat(new object[]
                            {
                                "编译失败!".Language(),
                                " ",
                                Myapp.errors,
                                " ",
                                "个错误,".Language(),
                                " ",
                                Myapp.warnings.ToString(),
                                " ",
                                "个警告".Language()
                            }));
                        }
                    }
                    streamWriter.Close();
                    streamWriter.Dispose();
                    result = false;
                }
                else
                {
                    appinf.datasize += 4u;
                    byte[] array = new byte[400];
                    appinf.structToBytes().CopyTo(array, 0);
                    appinf2.structToBytes().Appfree10(datasize.apppasseord, appinf.Modelcrc).CopyTo(array, 200);
                    uint num2 = array.getcrc(4294967295u, 0, datasize.appxinxisize0);
                    num2.structToBytes().CopyTo(array, 196);
                    num2 = array.getcrc(4294967295u, 200, datasize.appxinxisize1);
                    num2.structToBytes().CopyTo(array, 396);
                    num = array.getcrc(num, 0);
                    streamWriter.BaseStream.Write(array, 0, array.Length);
                    int i;
                    if (dataput.bianyi == 1)
                    {
                        array = new byte[3696];
                        for (i = 0; i < array.Length; i++)
                        {
                            array[i] = 0;
                        }
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, array.Length);
                    }
                    for (i = 0; i < Myapp.images.Count; i++)
                    {
                        num = Myapp.images[i].imagebytes.getcrc(num, 0);
                        if (dataput.bianyi != 1)
                        {
                            num = Myapp.images[i].imgxulie.getcrc(num, 0);
                        }
                        streamWriter.BaseStream.Write(Myapp.images[i].imagebytes, 0, Myapp.images[i].imagebytes.Length);
                        if (dataput.bianyi != 1)
                        {
                            streamWriter.BaseStream.Write(Myapp.images[i].imgxulie, 0, Myapp.images[i].imgxulie.Length);
                        }
                    }
                    for (i = 0; i < Myapp.zimos.Count; i++)
                    {
                        num = Myapp.zimodatas[i].getcrc(num, 0);
                        streamWriter.BaseStream.Write(Myapp.zimodatas[i], 0, Myapp.zimodatas[i].Length);
                    }
                    if (dataput.bianyi == 1)
                    {
                        int num3 = (Myapp.Getallimgsize(dataput.bianyi) + Myapp.Getallzimosize(false)) % 4096;
                        if (num3 != 0)
                        {
                            array = new byte[4096 - num3];
                            for (i = 0; i < array.Length; i++)
                            {
                                array[i] = 0;
                            }
                            num = array.getcrc(num, 0);
                            streamWriter.BaseStream.Write(array, 0, array.Length);
                        }
                    }
                    for (i = 0; i < dataput.strbytes.Count; i++)
                    {
                        num = dataput.strbytes[i].getcrc(num, 0);
                        streamWriter.BaseStream.Write(dataput.strbytes[i], 0, dataput.strbytes[i].Length);
                    }
                    if (dataput.bianyi == 1)
                    {
                        StreamReader streamReader = new StreamReader(Application.StartupPath + "\\asp" + appinf.xilie.ToString() + ".dll");
                        array = new byte[streamReader.BaseStream.Length];
                        streamReader.BaseStream.Position = 0L;
                        streamReader.BaseStream.Read(array, 0, array.Length);
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, array.Length);
                        streamReader.Close();
                        streamReader = new StreamReader(Application.StartupPath + "\\cd" + appinf.xilie.ToString() + ".dll");
                        array = new byte[streamReader.BaseStream.Length];
                        streamReader.BaseStream.Position = 0L;
                        streamReader.BaseStream.Read(array, 0, array.Length);
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, array.Length);
                        streamReader.Close();
                        streamReader = new StreamReader(Application.StartupPath + "\\syscom.bin");
                        array = new byte[streamReader.BaseStream.Length];
                        streamReader.BaseStream.Position = 0L;
                        streamReader.BaseStream.Read(array, 0, array.Length);
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, array.Length);
                        streamReader.Close();
                        streamReader = new StreamReader(Application.StartupPath + "\\input.bin");
                        array = new byte[streamReader.BaseStream.Length];
                        streamReader.BaseStream.Position = 0L;
                        streamReader.BaseStream.Read(array, 0, array.Length);
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, array.Length);
                        streamReader.Close();
                    }
                    if (dataput.bianyi == 1)
                    {
                        for (i = 0; i < dataput.pages_down.Count; i++)
                        {
                            array = dataput.pages_down[i].structToBytes();
                            num = array.getcrc(num, 0);
                            streamWriter.BaseStream.Write(array, 0, array.Length);
                        }
                    }
                    else
                    {
                        for (i = 0; i < Myapp.pages.Count; i++)
                        {
                            array = Myapp.pages[i].mypage.structToBytes();
                            num = array.getcrc(num, 0);
                            streamWriter.BaseStream.Write(array, 0, array.Length);
                        }
                    }
                    for (i = 0; i < dataput.Lobjs.Count; i++)
                    {
                        array = dataput.Lobjs[i].structToBytes();
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, datasize.objxinxisize);
                        if (dataput.bianyi == 1)
                        {
                            num = dataput.Lobjattdatapianyi[i].getcrc(num, 0);
                            streamWriter.BaseStream.Write(dataput.Lobjattdatapianyi[i], 0, dataput.Lobjattdatapianyi[i].Length);
                        }
                    }
                    uint num4 = 0u;
                    for (i = 0; i < (int)appinf2.picqyt; i++)
                    {
                        guiimagetype guiimagetype = Myapp.images[i];
                        guiimagetype.picturexinxi.addbeg = num4;
                        guiimagetype.picturexinxi.pictureid = (ushort)i;
                        if (dataput.bianyi != 1)
                        {
                            guiimagetype.picturexinxi.imgxuliebeg = guiimagetype.picturexinxi.imgbytesize;
                        }
                        if (dataput.bianyi != 1)
                        {
                            guiimagetype.picturexinxi.imgbytesize = guiimagetype.picturexinxi.imgbytesize + (uint)guiimagetype.imgxulie.Length;
                        }
                        array = guiimagetype.picturexinxi.structToBytes();
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, datasize.picxinxisize);
                        num4 += (uint)Myapp.images[i].imagebytes.Length;
                    }
                    i = 0;
                    while ((long)i < (long)((ulong)appinf2.strqyt))
                    {
                        array = dataput.strxinxis[i].structToBytes();
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, datasize.strxinxisize);
                        i++;
                    }
                    num4 = 0u;
                    for (i = 0; i < (int)appinf2.zimoqyt; i++)
                    {
                        zimoxinxi zimoxinxi = Myapp.zimos[i];
                        zimoxinxi.addbeg = num4;
                        array = zimoxinxi.structToBytes();
                        num = array.getcrc(num, 0);
                        streamWriter.BaseStream.Write(array, 0, datasize.zimoxinxisize);
                        num4 += (uint)Myapp.zimodatas[i].Length;
                    }
                    num ^= (uint)((byte)appinf.Modelcrc);
                    num ^= (uint)appinf.mark;
                    num ^= (uint)((byte)appinf.datasize);
                    streamWriter.BaseStream.Write(num.structToBytes(), 0, 4);
                    streamWriter.Close();
                    streamWriter.Dispose();
                    if (dataput.bianyi == 1)
                    {
                        if (datasize.Language == 0)
                        {
                            Myapp.addbianyisuc(string.Concat(new object[]
                            {
                                "编译成功!".Language(),
                                " ",
                                Myapp.errors,
                                "个错误,".Language(),
                                " ",
                                Myapp.warnings.ToString(),
                                "个警告,文件大小:".Language(),
                                appinf.datasize.ToString("000,000")
                            }), (Myapp.warnings > 0) ? Color.Blue : Color.Black);
                        }
                        else
                        {
                            Myapp.addbianyisuc(string.Concat(new object[]
                            {
                                "编译成功!".Language(),
                                " ",
                                Myapp.errors,
                                " ",
                                "个错误,".Language(),
                                " ",
                                Myapp.warnings.ToString(),
                                " ",
                                "个警告,文件大小:".Language(),
                                appinf.datasize.ToString("000,000")
                            }), (Myapp.warnings > 0) ? Color.Blue : Color.Black);
                        }
                    }
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

        private static bool StructHtoL(this Myapp_inf Myapp, ref appinf0 app0, ref appinf1 app1)
        {
            dataput.strdatasize = 0;
            dataput.strbytes.Clear();
            dataput.strxinxis.Clear();
            dataput.pages_down.Clear();
            dataput.Lobjs.Clear();
            dataput.Lobjattdatapianyi.Clear();
            dataput.strbytes.Clear();
            dataput.LcCL_L.Clear();
            dataput.LcCL_S.Clear();
            byte[] array = new byte[0];
            List<byte[]> list = new List<byte[]>();
            List<byte[]> list2 = new List<byte[]>();
            pagexinxi item = default(pagexinxi);
            app0.lcdscreenw = ((Myapp.guidire % 2 == 0) ? Myapp.lcdwidth : Myapp.lcdheight);
            app0.lcdscreenh = ((Myapp.guidire % 2 == 0) ? Myapp.lcdheight : Myapp.lcdwidth);
            app0.guidire = Myapp.guidire;
            app1.encode = Myapp.myencode;
            app0.xilie = Myapp.xilie;
            app0.old_screenw = ((Myapp.lcdwidth > Myapp.lcdheight) ? Myapp.lcdwidth : Myapp.lcdheight);
            app0.old_screenh = ((Myapp.lcdwidth > Myapp.lcdheight) ? Myapp.lcdheight : Myapp.lcdwidth);
            app0.old_lcddire = 0;
            Myapp.xunhuanmark = 0;
            bool flag = true;
            array = new byte[256000];
            ushort num = 0;
            int i;
            bool result;
            if (dataput.bianyi == 1)
            {
                Myapp.databianyi.PrivateMemorys = new List<byte[]>();
                Myapp.Staticstring.Clear();
                for (i = 0; i < Myapp.pages.Count; i++)
                {
                    for (int j = 0; j < Myapp.pages[i].objs.Count; j++)
                    {
                        Myapp.pages[i].objs[j].myobj.merry = Myapp.pages[i].objs[j].atts[1].zhi[0];
                        Myapp.pages[i].objs[j].myobj.objType = Myapp.pages[i].objs[j].atts[0].zhi[0];
                        if (Myapp.pages[i].objs[j].myobj.merry == 1)
                        {
                            Myapp.pages[i].objs[j].myobj.attpos = num;
                            int k = (int)Myapp.pages[i].objs[j].GetobjRambytes(ref array, (int)num);
                            Myapp.pages[i].objs[j].myobj.attposqyt = (ushort)k;
                            num += (ushort)k;
                        }
                    }
                }
                Myapp.databianyi.PublicMemorys = array.subbytes(0, (int)num);
                for (i = 0; i < Myapp.pages.Count; i++)
                {
                    array = new byte[256000];
                    num = (ushort)(Marshal.SizeOf(default(pageobjs_)) * Myapp.pages[i].objs.Count);
                    for (int j = 0; j < Myapp.pages[i].objs.Count; j++)
                    {
                        new pageobjs_
                        {
                            vis = 1,
                            touchstate = 1,
                            refFlag = 1
                        }.structToBytes().CopyTo(array, j * Marshal.SizeOf(default(pageobjs_)));
                        Myapp.pages[i].objs[j].myobj.merry = Myapp.pages[i].objs[j].atts[1].zhi[0];
                        Myapp.pages[i].objs[j].myobj.objType = Myapp.pages[i].objs[j].atts[0].zhi[0];
                        if (Myapp.pages[i].objs[j].myobj.merry == 0)
                        {
                            Myapp.pages[i].objs[j].myobj.attpos = (ushort)((int)num + Myapp.databianyi.PublicMemorys.Length);
                            int k = (int)Myapp.pages[i].objs[j].GetobjRambytes(ref array, (int)num);
                            Myapp.pages[i].objs[j].myobj.attposqyt = (ushort)k;
                            num += (ushort)k;
                        }
                    }
                    Myapp.databianyi.PrivateMemorys.Add(array.subbytes(0, (int)num));
                }
                dataput.Lstrbyteaddstring(Myapp.databianyi.PublicMemorys, false);
                if (!Myapp.Getpagenamecrcbytes(ref array))
                {
                    result = false;
                    return result;
                }
                dataput.Lstrbyteaddstring(array, false);
                Myapp.addbianyisuc("全局内存占用:".Language() + Myapp.databianyi.PublicMemorys.Length.ToString());
                Myapp.addbianyisuc("图片总大小:".Language() + Myapp.Getallimgsize(1).ToString("000,000"));
                Myapp.addbianyisuc("字库总大小:".Language() + Myapp.Getallzimosize(true).ToString("000,000"));
                Application.DoEvents();
                int num2 = 0;
                for (i = 0; i < Myapp.pages.Count; i++)
                {
                    Myapp.pages[i].attpos = (uint)num2;
                    Myapp.pages[i].refallatt();
                    num2 += Myapp.pages[i].allattnames.Count;
                }
            }
            i = 0;
            while (i < Myapp.pages.Count)
            {
                Myapp.systimers.Clear();
                if (dataput.bianyi != 1)
                {
                    goto IL_6A5;
                }
                if (Myapp.pages[i].bianyi())
                {
                    goto IL_6A5;
                }
                flag = false;
                IL_ABF:
                i++;
                continue;
                IL_6A5:
                Application.DoEvents();
                list.Add(Myapp.pages[i].pagename.GetbytesssASCII(15));
                if (dataput.bianyi == 1)
                {
                    item = default(pagexinxi);
                    item.objqyt = (byte)Myapp.pages[i].objs.Count;
                    item.objstar = (ushort)dataput.Lobjs.Count;
                }
                else
                {
                    Myapp.pages[i].mypage.name = (bytes_14)Myapp.pages[i].pagename.GetbytesssASCII(14).BytesTostruct(default(bytes_14).GetType());
                    Myapp.pages[i].mypage.objstar = (ushort)dataput.Lobjs.Count;
                    Myapp.pages[i].mypage.objqyt = (byte)Myapp.pages[i].objs.Count;
                }
                if (Myapp.pages[i].objs.Count > 0)
                {
                    for (int j = 0; j < Myapp.pages[i].objs.Count; j++)
                    {
                        mobj mobj = Myapp.pages[i].objs[j];
                        mobj.myobj.name = (bytes_14)mobj.objname.GetbytesssASCII(14).BytesTostruct(default(bytes_14).GetType());
                        list2.Clear();
                        if (dataput.bianyi == 1)
                        {
                            if (!mobj.BianyiCodes(ref list2))
                            {
                                result = false;
                                return result;
                            }
                        }
                        else
                        {
                            mobj.Getcodes(ref list2);
                        }
                        if (list2.Count > 0)
                        {
                            mobj.myobj.zhilingstar = (ushort)dataput.strxinxis.Count;
                            dataput.strdatasize.structToBytes().CopyTo(mobj.attstrpianyi, 0);
                            for (int k = 0; k < list2.Count; k++)
                            {
                                dataput.Lstrbyteaddstring(list2[k], true);
                            }
                            mobj.myobj.zhilingend = (ushort)((int)mobj.myobj.zhilingstar + list2.Count - 1);
                        }
                        else
                        {
                            MessageOpen.Show("检测到控件代码为0,保存的资源文件可能会出现异常".Language());
                            mobj.myobj.zhilingstar = 65535;
                            mobj.myobj.zhilingend = 65535;
                        }
                        dataput.Lobjs.Add(mobj.myobj);
                        dataput.Lobjattdatapianyi.Add(mobj.attstrpianyi);
                    }
                }
                else if (dataput.bianyi == 1)
                {
                    item.objstar = 65535;
                }
                else
                {
                    Myapp.pages[i].mypage.objstar = 65535;
                }
                if (dataput.bianyi == 1)
                {
                    item.zhilingstar = (ushort)dataput.strxinxis.Count;
                    for (int k = 0; k < Myapp.pages[i].Codes.Count; k++)
                    {
                        dataput.Lstrbyteaddstring(Myapp.pages[i].Codes[k], true);
                    }
                    item.zhilingqyt = (ushort)(dataput.strxinxis.Count - (int)item.zhilingstar);
                    dataput.pages_down.Add(item);
                }
                if (Myapp.systimers.Count > 6)
                {
                    Myapp.Addbianyierr("页面:".Language() + Myapp.pages[i].pagename + " " + "失败! 系统定时任务数量不能超过6条".Language());
                    result = false;
                    return result;
                }
                goto IL_ABF;
            }
            if (dataput.bianyi == 1)
            {
                dataput.makestrsbytes();
            }
            if (!flag)
            {
                result = flag;
            }
            else
            {
                if (dataput.bianyi == 1)
                {
                    app1.staticstringbeg = (uint)dataput.strdatasize;
                    if (Myapp.Staticstring.Count > 0)
                    {
                        byte[] array2 = new byte[Myapp.getstaticstringdataqyt()];
                        int num3 = 0;
                        foreach (byte[] array3 in Myapp.Staticstring)
                        {
                            array3.CopyTo(array2, num3);
                            num3 += array3.Length;
                        }
                        dataput.Lstrbyteaddstring(array2, false);
                    }
                    app1.attdatapos = (uint)dataput.strdatasize;
                    for (i = 0; i < Myapp.pages.Count; i++)
                    {
                        pagexinxi value = dataput.pages_down[i];
                        value.attdatapos = (uint)dataput.strdatasize;
                        dataput.pages_down[i] = value;
                        dataput.Lstrbyteaddstring(Myapp.pages[i].allattbytes, false);
                    }
                }
                app0.Modelcrc = Myapp.Model.Modelcrc;
                app1.pageqyt = (ushort)Myapp.pages.Count;
                app1.objqyt = (ushort)dataput.Lobjs.Count;
                app1.zimoqyt = (ushort)Myapp.zimos.Count;
                app1.picqyt = (ushort)Myapp.images.Count;
                app1.picdataadd = 400u;
                if (dataput.bianyi == 1)
                {
                    app1.picdataadd = 4096u;
                }
                app1.zimodataadd = (uint)((ulong)app1.picdataadd + (ulong)((long)Myapp.Getallimgsize(dataput.bianyi)));
                app1.strdataadd = (uint)((ulong)app1.zimodataadd + (ulong)((long)Myapp.Getallzimosize(false)));
                if (dataput.bianyi == 1)
                {
                    uint num4 = app1.strdataadd % 4096u;
                    if (num4 != 0u)
                    {
                        app1.strdataadd += 4096u - num4;
                    }
                }
                app0.hexaddr = (uint)((ulong)app1.strdataadd + (ulong)((long)dataput.strdatasize));
                app0.oldgujianqyt = 0u;
                app0.driverqyt = 0u;
                app0.hexlenth = 0u;
                app0.syscomqyt = 0u;
                app1.inputdatasize = 0;
                if (dataput.bianyi == 1)
                {
                    StreamReader streamReader = new StreamReader(Application.StartupPath + "\\asp" + app0.xilie.ToString() + ".dll");
                    hexhead hexhead = default(hexhead);
                    byte[] array3 = new byte[Marshal.SizeOf(default(hexhead))];
                    streamReader.BaseStream.Read(array3, 0, array3.Length);
                    hexhead = (hexhead)array3.BytesTostruct(default(hexhead).GetType());
                    app0.oldgujianadd = hexhead.F030addr + app0.hexaddr;
                    app0.oldgujianqyt = hexhead.F030datalenth;
                    app0.hexlenth = (uint)streamReader.BaseStream.Length;
                    streamReader.BaseStream.Close();
                    streamReader.Close();
                    streamReader.Dispose();
                    if (hexhead.headver != datasize.lcdbinver)
                    {
                        MessageOpen.Show("asp.dll文件与程序不匹配".Language() + datasize.lcdbinver.ToString() + "-" + hexhead.headver.ToString());
                        Application.Exit();
                        result = false;
                        return result;
                    }
                    streamReader = new StreamReader(Application.StartupPath + "\\cd" + app0.xilie.ToString() + ".dll");
                    app0.driverqyt = (uint)streamReader.BaseStream.Length;
                    byte[] array4 = new byte[1];
                    streamReader.BaseStream.Position = 0L;
                    streamReader.BaseStream.Read(array4, 0, 1);
                    streamReader.Close();
                    streamReader.Dispose();
                    if (array4[0] != datasize.lcddriverver)
                    {
                        MessageOpen.Show("cd" + app0.xilie.ToString() + ".dll ver is Error:" + array4[0].ToString());
                        result = false;
                        return result;
                    }
                    streamReader = new StreamReader(Application.StartupPath + "\\syscom.bin");
                    app0.syscomqyt = (uint)streamReader.BaseStream.Length;
                    streamReader.Close();
                    streamReader.Dispose();
                    streamReader = new StreamReader(Application.StartupPath + "\\input.bin");
                    app1.inputdatasize = (ushort)streamReader.BaseStream.Length;
                    array4 = new byte[2];
                    streamReader.BaseStream.Position = 0L;
                    streamReader.BaseStream.Read(array4, 0, array4.Length);
                    app1.inputqyts = (ushort)array4.BytesTostruct(0.GetType());
                    streamReader.Close();
                    streamReader.Dispose();
                }
                app0.driveradd = app0.hexaddr + app0.hexlenth;
                app0.syscomadd = app0.driveradd + app0.driverqyt;
                app1.inputpos = app0.syscomadd + app0.syscomqyt;
                app1.pageadd = app1.inputpos + (uint)app1.inputdatasize;
                if (dataput.bianyi == 1)
                {
                    app1.objadd = (uint)((ulong)app1.pageadd + (ulong)((long)(dataput.pages_down.Count * datasize.pagexinxisize)));
                }
                else
                {
                    app1.objadd = (uint)((ulong)app1.pageadd + (ulong)((long)(Myapp.pages.Count * datasize.pagexinxisize_up)));
                }
                app1.picxinxiadd = (uint)((ulong)app1.objadd + (ulong)((long)((int)app1.objqyt * (datasize.objxinxisize + ((dataput.bianyi == 1) ? 180 : 0)))));
                app1.strxinxiadd = (uint)((ulong)app1.picxinxiadd + (ulong)((long)(datasize.picxinxisize * (int)app1.picqyt)));
                app1.strqyt = (uint)dataput.strxinxis.Count;
                app1.zimoxinxiadd = (uint)((ulong)app1.strxinxiadd + (ulong)((long)(datasize.strxinxisize * dataput.strxinxis.Count)));
                app0.datasize = (uint)((ulong)app1.zimoxinxiadd + (ulong)((long)(datasize.zimoxinxisize * (int)app1.zimoqyt)));
                if (dataput.bianyi == 0)
                {
                    Myapp.codeqyt[0] = Myapp.Getallstrxinxiqyt();
                    if (Myapp.codeqyt[0] > 65534)
                    {
                        MessageOpen.Show("源代码总数超过最大限制(当前使用:".Language() + dataput.strbytes.Count.ToString("000,000") + "最大限制:65534)".Language());
                        result = false;
                        return result;
                    }
                }
                else
                {
                    Myapp.codeqyt[1] = Myapp.Getallstrxinxiqyt();
                    if (Myapp.codeqyt[1] > 65534)
                    {
                        Myapp.Addbianyierr("编译代码总数超过最大限制(当前使用:".Language() + dataput.strbytes.Count.ToString("000,000") + "最大限制:65534)".Language());
                        result = false;
                        return result;
                    }
                }
                result = flag;
            }
            return result;
        }

        public static int Getallimgsize(this Myapp_inf Myapp, int state)
        {
            int num = 0;
            for (int i = 0; i < Myapp.images.Count; i++)
            {
                num += Myapp.images[i].imagebytes.Length;
                if (state == 0)
                {
                    num += Myapp.images[i].imgxulie.Length;
                }
            }
            return num;
        }

        public static int Getallzimosize(this Myapp_inf Myapp, bool istype)
        {
            int num = 0;
            for (int i = 0; i < Myapp.zimos.Count; i++)
            {
                num += Myapp.zimodatas[i].Length;
                if (istype)
                {
                    num += datasize.zimoxinxisize;
                }
            }
            return num;
        }

        public static int Getallstrxinxiqyt(this Myapp_inf Myapp)
        {
            return dataput.strxinxis.Count;
        }

        private unsafe static int Lstrbyteaddstring(byte[] b, bool biaoji)
        {
            strxinxi item = default(strxinxi);
            if (dataput.bianyi == 1 && biaoji)
            {
                fixed (byte* ptr = b)
                {
                    if (b.Length > 5)
                    {
                        if (Strmake.Strmake_Makestr(ptr, "LcCL ", 5) == 1)
                        {
                            string[] array = b.Getstring(datasize.Myencoding).Split(new char[]
                            {
                                ' '
                            });
                            if (array.Length == 3)
                            {
                                if (array[1] == "L")
                                {
                                    dataput.LcCL_L.Add(new LcCL_type
                                    {
                                        strbytesid = dataput.strbytes.Count,
                                        biaoji = array[2]
                                    });
                                    b = (array[1] + "   ").GetbytesssASCII();
                                }
                                else if (array[1] == "S")
                                {
                                    dataput.LcCL_S.Add(new LcCL_type
                                    {
                                        strbytesid = dataput.strbytes.Count,
                                        biaoji = array[2]
                                    });
                                    b = (array[1] + " " + array[2]).GetbytesssASCII();
                                }
                            }
                        }
                    }
                }
            }
            item.size = (ushort)b.Length;
            item.addbeg = (uint)dataput.strdatasize;
            dataput.strxinxis.Add(item);
            dataput.strbytes.Add(b);
            dataput.strdatasize += b.Length;
            return dataput.strxinxis.Count - 1;
        }

        private static int makestrsbytes()
        {
            int result;
            if (dataput.LcCL_L.Count > 0 && dataput.LcCL_S.Count > 0)
            {
                for (int i = 0; i < dataput.LcCL_L.Count; i++)
                {
                    int num = dataput.getxuhao(dataput.LcCL_L[i].biaoji);
                    if (num == 65535)
                    {
                        MessageBox.Show("无效标记".Language());
                        result = 0;
                        return result;
                    }
                    ((ushort)(num + 1)).structToBytes().CopyTo(dataput.strbytes[dataput.LcCL_L[i].strbytesid], 2);
                }
            }
            result = 1;
            return result;
        }

        private static int getxuhao(string biaoji)
        {
            int result;
            for (int i = 0; i < dataput.LcCL_S.Count; i++)
            {
                if (dataput.LcCL_S[i].biaoji == biaoji)
                {
                    result = dataput.LcCL_S[i].strbytesid;
                    return result;
                }
            }
            result = 65535;
            return result;
        }
    }
}
