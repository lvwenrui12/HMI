using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace hmitype
{
    public static class readdata0
    {
        public static List<pagexinxi_up> Lpages = new List<pagexinxi_up>();

        public static List<objxinxi> Lobjs = new List<objxinxi>();

        public static List<strxinxi> strs = new List<strxinxi>();

        public static List<byte[]> strbytes = new List<byte[]>();

        public static bool readdatathis(this Myapp_inf Myapp, StreamReader sr)
        {
            byte[] array = new byte[4];
            List<byte[]> list = new List<byte[]>();
            appinf0 appinf = default(appinf0);
            appinf1 appinf2 = default(appinf1);
            bool result;
            try
            {
                sr.BaseStream.Position = 0L;
                byte[] array2 = new byte[datasize.appxinxisize0];
                sr.BaseStream.Read(array2, 0, datasize.appxinxisize0);
                appinf = (appinf0)array2.BytesTostruct(default(appinf0).GetType());
                if (appinf.banbenh > 0 || appinf.banbenl > 35)
                {
                    sr.BaseStream.Position = 196L;
                    sr.BaseStream.Read(array, 0, 4);
                    if ((uint)array.BytesTostruct(0u.GetType()) != array2.getcrc(4294967295u, 0, datasize.appxinxisize0))
                    {
                        result = false;
                        return result;
                    }
                }
                if (appinf.banbenh == 0 && appinf.banbenl < 33)
                {
                    sr.BaseStream.Position = 0L;
                    array2 = new byte[datasize.appxinxisize0];
                    sr.BaseStream.Read(array2, 0, 16);
                    appinf = (appinf0)array2.BytesTostruct(default(appinf0).GetType());
                    sr.BaseStream.Position = 16L;
                    array2 = new byte[datasize.appxinxisize1];
                    sr.BaseStream.Read(array2, 0, 45);
                    appinf2 = (appinf1)array2.BytesTostruct(default(appinf1).GetType());
                }
                else
                {
                    sr.BaseStream.Position = 200L;
                    array2 = new byte[datasize.appxinxisize1];
                    sr.BaseStream.Read(array2, 0, datasize.appxinxisize1);
                }
                if (appinf.banbenh == 0 && appinf.banbenl > 32 && appinf.banbenl < 36)
                {
                    byte b = (byte)appinf.Modelcrc;
                    byte mark = appinf.mark;
                    byte b2 = (byte)(appinf.Modelcrc >> 1);
                    byte b3 = (byte)(datasize.hmibiaoshiH >> 1);
                    for (int i = 0; i < 16; i++)
                    {
                        byte[] expr_249_cp_0 = array2;
                        int expr_249_cp_1 = i;
                        expr_249_cp_0[expr_249_cp_1] ^= b3;
                        byte[] expr_261_cp_0 = array2;
                        int expr_261_cp_1 = i;
                        expr_261_cp_0[expr_261_cp_1] ^= b2;
                        byte[] expr_279_cp_0 = array2;
                        int expr_279_cp_1 = i;
                        expr_279_cp_0[expr_279_cp_1] ^= mark;
                        byte[] expr_291_cp_0 = array2;
                        int expr_291_cp_1 = i;
                        expr_291_cp_0[expr_291_cp_1] ^= b;
                    }
                }
                else if (appinf.banbenh > 0 || appinf.banbenl > 35)
                {
                    if (appinf.filever < 3)
                    {
                        sr.BaseStream.Position = 396L;
                        sr.BaseStream.Read(array, 0, 4);
                        if ((uint)array.BytesTostruct(0u.GetType()) != array2.getcrc(4294967295u, 0, datasize.appxinxisize1 - 14))
                        {
                            result = false;
                            return result;
                        }
                    }
                    else if (appinf.filever == 3)
                    {
                        sr.BaseStream.Position = 396L;
                        sr.BaseStream.Read(array, 0, 4);
                        if ((uint)array.BytesTostruct(0u.GetType()) != array2.getcrc(4294967295u, 0, datasize.appxinxisize1 - 12))
                        {
                            result = false;
                            return result;
                        }
                    }
                    else if (appinf.filever < 17)
                    {
                        sr.BaseStream.Position = 396L;
                        sr.BaseStream.Read(array, 0, 4);
                        if ((uint)array.BytesTostruct(0u.GetType()) != array2.getcrc(4294967295u, 0, datasize.appxinxisize1 - 8))
                        {
                            result = false;
                            return result;
                        }
                    }
                    else
                    {
                        sr.BaseStream.Position = 396L;
                        sr.BaseStream.Read(array, 0, 4);
                        if ((uint)array.BytesTostruct(0u.GetType()) != array2.getcrc(4294967295u, 0, datasize.appxinxisize1))
                        {
                            result = false;
                            return result;
                        }
                    }
                }
                if (appinf.filever > 5 && appinf.filever < 10)
                {
                    array2 = array2.Appfree8(datasize.apppasseord);
                }
                else if (appinf.filever >= 10)
                {
                    array2 = array2.Appfree10(datasize.apppasseord, appinf.Modelcrc);
                }
                appinf2 = (appinf1)array2.BytesTostruct(default(appinf1).GetType());
                Myapp.images.Clear();
                sr.BaseStream.Position = (long)((ulong)appinf2.picxinxiadd);
                int j;
                for (j = 0; j < (int)appinf2.picqyt; j++)
                {
                    guiimagetype guiimagetype = default(guiimagetype);
                    array2 = new byte[datasize.picxinxisize];
                    sr.BaseStream.Read(array2, 0, datasize.picxinxisize);
                    guiimagetype.picturexinxi = (Picturexinxi)array2.BytesTostruct(default(Picturexinxi).GetType());
                    Myapp.images.Add(guiimagetype);
                }
                sr.BaseStream.Position = (long)((ulong)appinf2.picdataadd);
                for (j = 0; j < Myapp.images.Count; j++)
                {
                    guiimagetype guiimagetype = Myapp.images[j];
                    guiimagetype.imagebytes = new byte[guiimagetype.picturexinxi.imgbytesize];
                    sr.BaseStream.Read(guiimagetype.imagebytes, 0, guiimagetype.imagebytes.Length);
                    Myapp.images[j] = guiimagetype;
                }
                sr.BaseStream.Position = (long)((ulong)appinf2.zimoxinxiadd);
                Myapp.zimos.Clear();
                for (j = 0; j < (int)appinf2.zimoqyt; j++)
                {
                    array2 = new byte[datasize.zimoxinxisize];
                    sr.BaseStream.Read(array2, 0, datasize.zimoxinxisize);
                    zimoxinxi item = (zimoxinxi)array2.BytesTostruct(default(zimoxinxi).GetType());
                    Myapp.zimos.Add(item);
                }
                sr.BaseStream.Position = (long)((ulong)appinf2.zimodataadd);
                Myapp.zimodatas.Clear();
                for (j = 0; j < Myapp.zimos.Count; j++)
                {
                    array2 = new byte[Myapp.zimos[(int)((ushort)j)].size];
                    sr.BaseStream.Read(array2, 0, array2.Length);
                    Myapp.zimodatas.Add(array2);
                }
                sr.BaseStream.Position = (long)((ulong)appinf2.strxinxiadd);
                readdata0.strs.Clear();
                j = 0;
                while ((long)j < (long)((ulong)appinf2.strqyt))
                {
                    array2 = new byte[datasize.strxinxisize];
                    sr.BaseStream.Read(array2, 0, datasize.strxinxisize);
                    readdata0.strs.Add((strxinxi)array2.BytesTostruct(default(strxinxi).GetType()));
                    j++;
                }
                sr.BaseStream.Position = (long)((ulong)appinf2.strdataadd);
                readdata0.strbytes.Clear();
                for (j = 0; j < readdata0.strs.Count; j++)
                {
                    array2 = new byte[(int)readdata0.strs[(int)((ushort)j)].size];
                    sr.BaseStream.Read(array2, 0, array2.Length);
                    readdata0.strbytes.Add(array2);
                }
                sr.BaseStream.Position = (long)((ulong)appinf2.pageadd);
                readdata0.Lpages.Clear();
                for (j = 0; j < (int)appinf2.pageqyt; j++)
                {
                    array2 = new byte[datasize.pagexinxisize_up];
                    sr.BaseStream.Read(array2, 0, array2.Length);
                    readdata0.Lpages.Add((pagexinxi_up)array2.BytesTostruct(default(pagexinxi_up).GetType()));
                }
                sr.BaseStream.Position = (long)((ulong)appinf2.objadd);
                readdata0.Lobjs.Clear();
                for (j = 0; j < (int)appinf2.objqyt; j++)
                {
                    array2 = new byte[datasize.objxinxisize];
                    if (appinf.banbenh == 0 && appinf.banbenl < 33)
                    {
                        sr.BaseStream.Read(array2, 0, array2.Length - 8);
                        array2[array2.Length - 1] = array2[array2.Length - 8 - 1];
                        array2[array2.Length - 2] = array2[array2.Length - 8 - 2];
                        array2[array2.Length - 3] = array2[array2.Length - 8 - 3];
                        array2[array2.Length - 4] = array2[array2.Length - 8 - 4];
                    }
                    else
                    {
                        sr.BaseStream.Read(array2, 0, array2.Length);
                    }
                    readdata0.Lobjs.Add((objxinxi)array2.BytesTostruct(default(objxinxi).GetType()));
                }
                for (j = 0; j < Myapp.zimos.Count; j++)
                {
                    zimoxinxi value = Myapp.zimos[j];
                    if ((int)value.encode < datasize.encodes_App.Length)
                    {
                        if (value.ver == 0 || value.ver == 1)
                        {
                            if (value.encode == 0)
                            {
                                if (value.state == 0 && datasize.Language == 1)
                                {
                                    value.encode =(byte) ((value.qyt < 100u) ? 1 : 3);
                                }
                                else
                                {
                                    value.encode = 2;
                                }
                            }
                            value.codelT0 = 255;
                            value.codelV0 = 0;
                            value.codeh_star = datasize.encodes_App[(int)value.encode].codeh_star;
                            value.codeh_end = datasize.encodes_App[(int)value.encode].codeh_end;
                            value.codel_star = datasize.encodes_App[(int)value.encode].codel_star;
                            value.codel_end = datasize.encodes_App[(int)value.encode].codel_end;
                        }
                        if (value.ver != 0)
                        {
                            value.ver = datasize.zikuver;
                        }
                        Myapp.zimos[j] = value;
                    }
                    else
                    {
                        Myapp.zimos.RemoveAt(j);
                        Myapp.zimodatas.RemoveAt(j);
                        j--;
                    }
                }
                if (appinf.banbenh == 0 && appinf.banbenl < 33)
                {
                    appinf2.encode = 0;
                    if (readdata0.strbytes.Count > 1)
                    {
                        string @string = Encoding.ASCII.GetString(readdata0.strbytes[1]);
                        if (@string.Length >= 7 && @string.Substring(0, 7) == "encode:")
                        {
                            appinf2.encode = readdata0.strbytes[1][7];
                        }
                    }
                    if ((appinf.old_screenw == 800 && appinf.old_screenh == 480) || (appinf.old_screenw == 480 && appinf.old_screenh == 272))
                    {
                        appinf.lcdscreenw = appinf.old_screenw;
                        appinf.lcdscreenh = appinf.old_screenh;
                        appinf.guidire = appinf.old_lcddire;
                    }
                    else
                    {
                        appinf.lcdscreenw = appinf.old_screenh;
                        appinf.lcdscreenh = appinf.old_screenw;
                        appinf.guidire =(byte) ((appinf.old_lcddire == 0) ? 1 : 0);
                    }
                    Myapp.guidire = appinf.guidire;
                    new datazhuan(Myapp).ShowDialog();
                }
                Myapp.myencode = appinf2.encode;
                if (Myapp.myencode == 0 || (int)Myapp.myencode >= datasize.encodes_App.Length)
                {
                    Myapp.myencode = ((datasize.Language == 0) ? "gb2312".GetencodeId() : "iso-8859-1".GetencodeId());
                }
                datasize.Myencoding = Encoding.GetEncoding(datasize.encodes_App[(int)Myapp.myencode].encodename);
                Myapp.xilie =(byte) ((appinf.xilie > 2) ? 0 : appinf.xilie);
                Myapp.guidire = appinf.guidire;
                Myapp.lcdwidth = ((Myapp.guidire % 2 == 0) ? appinf.lcdscreenw : appinf.lcdscreenh);
                Myapp.lcdheight = ((Myapp.guidire % 2 == 0) ? appinf.lcdscreenh : appinf.lcdscreenw);
                Myapp.Model = datasize.Getmodelxinxi(appinf.Modelcrc, (int)Myapp.xilie);
                if (appinf.banbenh == 0 && appinf.banbenl < 30)
                {
                    datasize.Opentouming = false;
                    for (int k = 0; k < Myapp.images.Count; k++)
                    {
                        for (j = 0; j < Myapp.images[k].imagebytes.Length - 1; j += 2)
                        {
                            if ((ushort)Myapp.images[k].imagebytes[j] == datasize.Color_touming && Myapp.images[k].imagebytes[j + 1] == 0)
                            {
                                Myapp.images[k].imagebytes[j] = (byte)datasize.Color_toumingtihuan;
                            }
                        }
                    }
                }
                else
                {
                    datasize.Opentouming = false;
                }
                progform progform = null;
                int num = 1;
                int num2 = 0;
                if (Myapp.images.Count > 0)
                {
                    progform = new progform();
                    num = (int)(appinf2.zimodataadd - appinf2.picdataadd);
                    num2 = 0;
                    progform.Show();
                    Application.DoEvents();
                    Thread.Sleep(300);
                }
                for (int k = 0; k < Myapp.images.Count; k++)
                {
                    guiimagetype guiimagetype = Myapp.images[k];
                    if (appinf.filever > 6)
                    {
                        guiimagetype.imgxulie = guiimagetype.imagebytes.subbytes((int)guiimagetype.picturexinxi.imgxuliebeg, (int)((long)guiimagetype.imagebytes.Length - (long)((ulong)guiimagetype.picturexinxi.imgxuliebeg)));
                        guiimagetype.imagebitbmp = (guiimagetype.imgxulie.BytesToClass() as Bitmap);
                        guiimagetype.imagebytes = guiimagetype.imagebytes.subbytes(0, (int)guiimagetype.picturexinxi.imgxuliebeg);
                        guiimagetype.picturexinxi.imgbytesize = (uint)guiimagetype.imagebytes.Length;
                    }
                    else
                    {
                        guiimagetype.imagebitbmp = Myapp.images[k].imagebytes.GetBitmap(Myapp.images[k].picturexinxi, datasize.Opentouming);
                        guiimagetype.imgxulie = guiimagetype.imagebitbmp.ClassToBytes();
                    }
                    Myapp.images[k] = guiimagetype;
                    num2 += (int)guiimagetype.picturexinxi.imgbytesize;
                    progform.setprogval(num2 * 100 / num);
                    Application.DoEvents();
                }
                if (progform != null)
                {
                    Application.DoEvents();
                    Thread.Sleep(300);
                    progform.Close();
                }
                Myapp.pages.Clear();
                for (int l = 0; l < readdata0.Lpages.Count; l++)
                {
                    mpage mpage = new mpage(Myapp);
                    if (readdata0.Lpages[l].objqyt == 0)
                    {
                        pagexinxi_up value2 = readdata0.Lpages[l];
                        value2.objqyt = (byte)((ushort)value2.pagelock - value2.objstar + 1);
                        readdata0.Lpages[l] = value2;
                    }
                    if (appinf.banbenh == 0 && appinf.banbenl < 42)
                    {
                        pagexinxi_up value3 = readdata0.Lpages[l];
                        value3.pagelei = 0;
                        value3.pagelock = 0;
                        value3.password = 0u;
                        readdata0.Lpages[l] = value3;
                    }
                    if (appinf.filever < 13)
                    {
                        pagexinxi_up value3 = readdata0.Lpages[l];
                        value3.password = 0u;
                        readdata0.Lpages[l] = value3;
                    }
                    mpage.mypage = readdata0.Lpages[l];
                    mpage.pagename = mpage.mypage.name.structToBytes().Getstring(datasize.Myencoding);
                    if (mpage.mypage.pagelei == 0 && mpage.pagename.ishefaname() != "")
                    {
                        mpage.pagename = Myapp.getpagename_key(mpage.pagename);
                        mpage.mypage.name = (bytes_14)mpage.pagename.GetbytesssASCII(14).BytesTostruct(default(bytes_14).GetType());
                    }
                    if (mpage.mypage.objqyt > 0)
                    {
                        int num3 = (int)(mpage.mypage.objstar + (ushort)mpage.mypage.objqyt - 1);
                        for (j = (int)mpage.mypage.objstar; j <= num3; j++)
                        {
                            mobj mobj = new mobj(Myapp, mpage);
                            mobj.myobj = readdata0.Lobjs[j];
                            mobj.objname = readdata0.Lobjs[j].name.structToBytes().Getstring(datasize.Myencoding);
                            list.Clear();
                            for (int m = (int)readdata0.Lobjs[j].zhilingstar; m < (int)(readdata0.Lobjs[j].zhilingend + 1); m++)
                            {
                                list.Add(readdata0.strbytes[m]);
                            }
                            if (appinf.filever < 5)
                            {
                                mobj.Putcodes(list, "end", appinf.filever);
                            }
                            else
                            {
                                mobj.Putcodes(list, "E", appinf.filever);
                            }
                            if (appinf.banbenh == 0 && appinf.banbenl < 36 && mobj.myobj.objType == objtype.Timer)
                            {
                                mobj.Codes[7].AddListString(mobj.Codes[2]);
                                mobj.Codes[2].Clear();
                            }
                            mpage.objs.Add(mobj);
                        }
                    }
                    mpage.objs[0].objname = mpage.pagename;
                    Myapp.pages.Add(mpage);
                }
                Myapp.RefAllID();
                if (appinf.banbenh == 0 && appinf.banbenl == 8)
                {
                    foreach (mpage current in Myapp.pages)
                    {
                        if (current.objs[0].atts.Count == 4 && current.objs[0].atts[2].name.Getstring(datasize.Myencoding) == "pco")
                        {
                            current.objs[0].atts[2].name = "bco".GetbytesssASCII(8);
                        }
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = false;
            }
            return result;
        }
    }
}
