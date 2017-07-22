using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using hmitype;

public class mobj
{
    // Fields
    public List<matt> atts = new List<matt>();
    public byte[] attstrpianyi = new byte[180];
    public List<string>[] Codes = new List<string>[8];
    private string d3color0 = "59164";
    private string d3color1 = "16936";
    public byte isbangding = 0;
    public Myapp_inf Myapp;
    public objxinxi myobj;
    public mpage Mypage;
    public int objid;
    public string objname = "";

    // Methods
    public mobj(Myapp_inf app, mpage page)
    {
        this.Mypage = page;
        this.Myapp = app;
        this.Codes[0] = new List<string>();
        this.Codes[1] = new List<string>();
        this.Codes[2] = new List<string>();
        this.Codes[3] = new List<string>();
        this.Codes[4] = new List<string>();
        this.Codes[5] = new List<string>();
        this.Codes[6] = new List<string>();
        this.Codes[7] = new List<string>();
    }

    public void addtimers(int id)
    {
        foreach (int num in this.Myapp.systimers)
        {
            if (num == id)
            {
                return;
            }
        }
        this.Myapp.systimers.Add(id);
    }

    public unsafe bool attpianyiset(string attname, ushort dpianyi)
    {
        byte num;
        byte[] bytesssASCII = attname.GetbytesssASCII(attname.Length + 1);
        fixed (byte* numRef = bytesssASCII)
        {
            byte lenth = (byte)Strmake.Strmake_GetStrlen(numRef);
            num = Attmake.Attmake_GetAttindex(numRef, lenth);
        }
        if (num == 0xff)
        {
            this.Myapp.Addbianyierr("This attname is invalid!" + bytesssASCII.Getstring(datasize.Myencoding));
            return false;
        }
        dpianyi.structToBytes().CopyTo(this.attstrpianyi, (int)(num * 2));
        return true;
    }

    public unsafe bool BianyiCodes(ref List<byte[]> bts)
    {
        int hidecode;
        int num2;
        attinf attdown = new attinf();
        ushort[] numArray = new ushort[8];
        for (num2 = 0; num2 < this.attstrpianyi.Length; num2++)
        {
            this.attstrpianyi[num2] = 0xff;
        }
        attdown.pageid = (byte)this.Mypage.pageid;
        attdown.objid = (byte)this.objid;
        byte num3 = datasize.encodes_App[this.Myapp.myencode].codeh_star;
        matt att = this.Getatt("font");
        if (((att != null) && this.checkatt(att)) && (att.zhi[0] < this.Myapp.zimos.Count))
        {
            num3 = this.Myapp.zimos[att.zhi[0]].codeh_star;
        }
        num2 = 0;
        while (num2 < this.atts.Count)
        {
            if (this.checkatt(this.atts[num2]))
            {
                this.atts[num2].att.attinfUpToDown(ref attdown, num3);
                if ((attdown.state & 0x10) == 0)
                {
                    if ((attdown.state & 15) == attshulei.Sstr.typevalue)
                    {
                        attdown.pos = (ushort)this.Myapp.addstaticstring(this.atts[num2].zhi);
                        attdown.merrylenth = this.atts[num2].att.zhanyonglenth;
                    }
                    else
                    {
                        hidecode = this.atts[num2].zhi.getbytestoint(attdown.merrylenth, (byte)(attdown.state & 15));
                        Kuozhan.memcpy((byte*)&attdown.pos, (byte*)&hidecode, 4);
                    }
                }
                if (!this.Mypage.Allattbytes_set(this.objid, this.atts[num2].name.Getstring(datasize.Myencoding), attdown))
                {
                    return false;
                }
            }
            num2++;
        }
        attdown.merrylenth = 0;
        attdown.maxval = 0;
        attdown.minval = 0;
        if (objtype.getobjmark(this.atts[0].zhi[0]).show != 0)
        {
            attdown.state = attshulei.UU16.typevalue;
            attdown.pos = this.myobj.redian.x;
            if (!this.Mypage.Allattbytes_set(this.objid, "x", attdown))
            {
                return false;
            }
            attdown.state = attshulei.UU16.typevalue;
            attdown.pos = this.myobj.redian.y;
            if (!this.Mypage.Allattbytes_set(this.objid, "y", attdown))
            {
                return false;
            }
            attdown.state = attshulei.UU16.typevalue;
            attdown.pos = this.myobj.redian.endx;
            if (!this.Mypage.Allattbytes_set(this.objid, "endx", attdown))
            {
                return false;
            }
            attdown.state = attshulei.UU16.typevalue;
            attdown.pos = this.myobj.redian.endy;
            if (!this.Mypage.Allattbytes_set(this.objid, "endy", attdown))
            {
                return false;
            }
            attdown.state = attshulei.UU16.typevalue;
            attdown.pos = (ushort)((this.myobj.redian.endx - this.myobj.redian.x) + 1);
            if (!this.Mypage.Allattbytes_set(this.objid, "w", attdown))
            {
                return false;
            }
            attdown.state = attshulei.UU16.typevalue;
            attdown.pos = (ushort)((this.myobj.redian.endy - this.myobj.redian.y) + 1);
            if (!this.Mypage.Allattbytes_set(this.objid, "h", attdown))
            {
                return false;
            }
        }
        attdown.state = attshulei.UU8.typevalue;
        attdown.pos = (byte)this.objid;
        if (!this.Mypage.Allattbytes_set(this.objid, "id", attdown))
        {
            return false;
        }
        bts.Add("ref".GetbytesssASCII());
        hidecode = this.Getbianyi(ref bts, 0, false, 2);
        if (hidecode == 0xffff)
        {
            return false;
        }
        numArray[0] = (hidecode == 0) ? ((ushort)0) : ((ushort)(bts.Count - hidecode));
        bts.Add("E".GetbytesssASCII());
        bts.Add("vis".GetbytesssASCII());
        if (objtype.getobjmark(this.atts[0].zhi[0]).show > 0)
        {
            hidecode = this.Gethidecode(ref bts);
            if (hidecode == 0xffff)
            {
                return false;
            }
            numArray[1] = (hidecode == 0) ? ((ushort)0) : ((ushort)(bts.Count - hidecode));
        }
        bts.Add("E".GetbytesssASCII());
        objmark_ k_ = objtype.getobjmark(this.myobj.objType);
        int index = 0;
        for (num2 = 0; num2 < k_.events.Length; num2++)
        {
            index = k_.events[num2].eventid.Getint();
            if ((index != 0) && ((this.objid != 0) || ((index != 2) && (index != 3))))
            {
                bts.Add(k_.events[num2].eventres.GetbytesssASCII());
                hidecode = this.Getbianyi(ref bts, index, false, 2);
                if (hidecode == 0xffff)
                {
                    return false;
                }
                numArray[index] = (hidecode == 0) ? ((ushort)0) : ((ushort)(bts.Count - hidecode));
                bts.Add("E".GetbytesssASCII());
            }
        }
        fixed (void* voidRef = (&this.myobj.redian.events))
        {
            ushort* numPtr = (ushort*)voidRef;
            for (num2 = 0; num2 < 8; num2++)
            {
                numPtr[num2] = numArray[num2];
            }
        }
        return true;
    }

    public bool bianyionline(string strccom, ref byte[] descode, string code, bianyijieguotype by)
    {
        switch (this.codeyunxingjiance(strccom, ref descode))
        {
            case 0:
                if (guicombianyi.errmessage != "")
                {
                    this.sendbianyierror(((int)guicombianyi.errcode).Gethanyi(), guicombianyi.errmessage, by);
                }
                else
                {
                    this.sendbianyierror(((int)guicombianyi.errcode).Gethanyi(), code, by);
                }
                return false;

            case 2:
                this.sendbianyijinggao(guicombianyi.jinggaostr, code, by);
                return false;
        }
        return true;

        //byte b = this.codeyunxingjiance(strccom, ref descode);
        //bool result;
        //if (b == 0)
        //{
        //    if (guicombianyi.errmessage != "")
        //    {
        //        this.sendbianyierror(((int)guicombianyi.errcode).Gethanyi(), guicombianyi.errmessage, by);
        //    }
        //    else
        //    {
        //        this.sendbianyierror(((int)guicombianyi.errcode).Gethanyi(), code, by);
        //    }
        //    result = false;
        //}
        //else if (b == 2)
        //{
        //    this.sendbianyijinggao(guicombianyi.jinggaostr, code, by);
        //    result = false;
        //}
        //else
        //{
        //    result = true;
        //}
        //return result;
    }

    public bool biduiatt(string name, byte datalei)
    {
        foreach (matt matt in this.atts)
        {
            if (matt.name.Getstring(datasize.Myencoding) == name)
            {
                return true;
            }
        }
        return ((objtype.getobjmark(this.myobj.objType).show > 0) && (((((name == "x") || (name == "y")) || ((name == "w") || (name == "h"))) || (name == "endx")) || (name == "endy")));
    }

    private List<byte[]> canshutihuan(ref List<string> bt, byte state)
    {
        List<byte[]> list = new List<byte[]>();
        string s = "";
        for (int i = 0; i < bt.Count; i++)
        {
            Encoding myencoding = datasize.Myencoding;
            s = bt[i];
            int num4 = (this.myobj.redian.endx - this.myobj.redian.x) + 1;
            num4 = (this.myobj.redian.endy - this.myobj.redian.y) + 1;
            s = s.Replace("'&id&'", this.objid.ToString()).Replace("'&pagename&'", this.Mypage.pagename).Replace("'&pageid&'", this.Mypage.pageid.ToString()).Replace("'&objname&'", this.objname).Replace("'&endx&'", this.myobj.redian.endx.ToString()).Replace("'&endy&'", this.myobj.redian.endy.ToString()).Replace("'&x&'", this.myobj.redian.x.ToString()).Replace("'&y&'", this.myobj.redian.y.ToString()).Replace("'&w&'", num4.ToString()).Replace("'&h&'", num4.ToString());
            string newValue = this.GetattVal_string("sta");
            if (newValue != null)
            {
                s = s.Replace("'&sta&'", newValue);
            }
            for (int j = 1; j < this.atts.Count; j++)
            {
                if (this.checkatt(this.atts[j]) && s.Contains("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'"))
                {
                    if ((state == 1) || (this.atts[j].att.isxiugai == 0))
                    {
                        if (this.atts[j].att.attlei != attshulei.Sstr.typevalue)
                        {
                            byte num2 = (byte)(this.atts[j].att.attlei & 15);
                            if (this.atts[j].att.merrylenth == 1)
                            {
                                s = s.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi[0].ToString());
                            }
                            else if (this.atts[j].att.merrylenth == 2)
                            {
                                if (num2 == attshulei.UU16.typevalue)
                                {
                                    s = s.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi.BytesTostruct(((ushort)0).GetType()).ToString());
                                }
                                else
                                {
                                    s = s.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi.BytesTostruct(((short)0).GetType()).ToString());
                                }
                            }
                            else if (this.atts[j].att.merrylenth == 4)
                            {
                                s = s.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi.BytesTostruct(0.GetType()).ToString());
                            }
                        }
                        else
                        {
                            myencoding = this.Getobjencodeing(this.atts[j].name.Getstring(datasize.Myencoding));
                            s = s.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", "\"" + myencoding.GetString(this.atts[j].zhi).Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\r\n", @"\r") + "\"");
                        }
                    }
                    else
                    {
                        s = s.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.objname + "." + this.atts[j].name.Getstring(datasize.Myencoding));
                    }
                }
            }
            list.Add(myencoding.GetBytes(s));
            bt[i] = s;
        }
        return list;
    }

    public bool checkatt(matt at)
    {
        string str = "";
        if (datasize.Objzhushiencoding.GetString(at.zhushi).Contains("~"))
        {
            string[] strArray = datasize.Objzhushiencoding.GetString(at.zhushi).Split(new char[] { '~' });
            if (strArray.Length > 10)
            {
                MessageOpen.Show("控件属性数据错误:0".Language());
                return false;
            }
            for (int i = 1; i < strArray.Length; i++)
            {
                string str2 = strArray[i];
                string[] strArray2 = str2.Split(new char[] { '=' });
                if (strArray2.Length != 2)
                {
                    strArray2 = str2.Split(new char[] { '>' });
                    if (strArray2.Length != 2)
                    {
                        MessageOpen.Show("控件属性数据错误:1".Language());
                        return false;
                    }
                    str = this.GetattVal_string(strArray2[0]);
                    if (str == null)
                    {
                        return false;
                    }
                    if (str.IsdataS32(attshulei.UU8.typevalue) && (str.Getint() < byte.Parse(strArray2[1])))
                    {
                        return false;
                    }
                }
                else
                {
                    str = this.GetattVal_string(strArray2[0]);
                    if (str == null)
                    {
                        return false;
                    }
                    if (str != strArray2[1])
                    {
                        return false;
                    }
                }
            }
        }
        if (at.att.isbangding == 1)
        {
            this.isbangding = 1;
        }
        return true;
    }

    public string checkattval(matt at)
    {
        try
        {
            if (at.att.attlei == attshulei.Picid.typevalue)
            {
                int num = (ushort)at.zhi.BytesTostruct(((ushort)0).GetType());
                if (num >= this.Myapp.images.Count)
                {
                    return "图片ID无效".Language();
                }
            }
            if ((at.name.Getstring(datasize.Myencoding) == "font") && (at.zhi[0] >= this.Myapp.zimos.Count))
            {
                if ((this.GetattVal_string("txt") != null) && (this.GetattVal_string("txt") == ""))
                {
                    return "";
                }
                return "字库ID无效".Language();
            }
            if (at.name.Getstring(datasize.Myencoding) == "key")
            {
                keyboardlisttype keyboardlisttype = this.Myapp.getkeyboardlisttype(at.zhi[0]);
                if ((keyboardlisttype.id != 0xff) && (this.Myapp.findpagename(keyboardlisttype.pagename, 0xffff) == -1))
                {
                    return "键盘页面丢失(重新选择绑定可自动载入键盘页面)".Language();
                }
            }
        }
        catch (Exception exception)
        {
            return exception.Message;
        }
        return "";
    }

    private string chonggouif(string str, ref bianyijieguotype by)
    {
        PosLaction fengge = new PosLaction();
        if (str.Substring(str.Length - 1, 1) == ")")
        {
            string str2 = "I ";
            int num = this.getpanduan(str, ref fengge);
            if (num == 0)
            {
                this.sendbianyierror("语句错误:无判断符".Language(), str, by);
                return "";
            }
            return ((((str2 + str.Substring(3, fengge.star - 3)) + "," + str.Substring(fengge.end + 1, (str.Length - fengge.end) - 2)) + "," + num.ToString()) + ",0");
        }
        this.sendbianyierror("语句最后一个字符必须为后括号:)".Language(), str, by);
        return "";
    }

    private unsafe byte codeyunxingjiance(string strcom, ref byte[] descode)
    {
        PosLaction posLaction = default(PosLaction);
        PosLaction[] array = new PosLaction[128];
        byte[] array2 = strcom.GetbytesssASCII();
        posLaction.star = 0;
        posLaction.end = (ushort)(array2.Length - 1);
        descode = new byte[0];
        byte b;
        fixed (byte* ptr = array2)
        {
            fixed (PosLaction* ptr2 = array)
            {
                b = guicombianyi.CodeRun_Run(ptr, &posLaction, this);
                if (b == 1 && guicombianyi.errcode == 255)
                {
                    descode = strcom.GetbytesssASCII();
                    if (guicombianyi.hexreplace.Count > 0)
                    {
                        descode = this.tihianhex(descode, guicombianyi.hexreplace);
                    }
                    if (array2.Length > 2 && Strmake.Strmake_Makestr(ptr, "L ", 2) == 1)
                    {
                        descode = Kuozhan.Gethebingbytes("LcCL ".GetbytesssASCII(), descode);
                    }
                    else if (array2.Length > 2 && Strmake.Strmake_Makestr(ptr, "S ", 2) == 1)
                    {
                        descode = Kuozhan.Gethebingbytes("LcCL ".GetbytesssASCII(), descode);
                    }
                }
            }
        }
        if (descode.Length == 0)
        {
            descode = strcom.GetbytesssASCII();
        }
        return b;
    }

    public mobj copyobj()
    {
        mobj mobj = new mobj(this.Myapp, this.Mypage)
        {
            objname = this.objname,
            myobj = this.myobj
        };
        mobj.Putcodes(this.Getcodes(), "E", datasize.filever);
        return mobj;
    }

    public bool Dellatt(string name)
    {
        PosLaction bufpos = new PosLaction
        {
            star = 0,
            end = 7
        };
        for (int i = 0; i < this.atts.Count; i++)
        {
            int num2 = Strmake.Strmake_StrSubstring(ref this.atts[i].name, ref bufpos, name, 0);
            if ((num2 != 0xffff) && ((num2 == 7) || (this.atts[i].name[num2 + 1] == 0)))
            {
                this.atts.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public PosLaction findstrindex(List<byte[]> btstr, int beg, string str, string tstr)
    {
        PosLaction laction = new PosLaction
        {
            star = 0
        };
        for (int i = beg; i < btstr.Count; i++)
        {
            if (btstr[i].Getstring(datasize.Myencoding) == tstr)
            {
                laction.star = (ushort)(laction.star + 1);
                laction.star = (ushort)(laction.star + 1);
            }
            if (btstr[i].Getstring(datasize.Myencoding) == str)
            {
                if (laction.star == 0)
                {
                    laction.end = (ushort)i;
                    return laction;
                }
                laction.star = (ushort)(laction.star - 1);
            }
        }
        laction.end = 0xffff;
        return laction;
    }

    public List<matt> GetAllatts()
    {
        List<matt> list = new List<matt>();
        matt item = new matt
        {
            name = "id".GetbytesssASCII()
        };
        item.att.attlei = attshulei.UU8.typevalue;
        item.att.merrylenth = 1;
        item.att.isxiugai = 0;
        item.zhushi = datasize.Objzhushiencoding.GetBytes("id".Language());
        item.zhi = ((byte)this.objid).structToBytes();
        list.Add(item);
        foreach (matt matt2 in this.atts)
        {
            if ((matt2.att.vis == 1) && this.checkatt(matt2))
            {
                if (matt2.att.attlei == attshulei.Strlenth.typevalue)
                {
                    matt2.zhi[0] = (byte)(this.Getshutxt_merrylenth(matt2.name.Getstring(datasize.Myencoding), true) - 1);
                }
                item = new matt
                {
                    att = matt2.att,
                    name = new byte[matt2.name.Length]
                };
                matt2.name.CopyTo(item.name, 0);
                item.zhi = new byte[matt2.zhi.Length];
                matt2.zhi.CopyTo(item.zhi, 0);
                item.zhushi = new byte[matt2.zhushi.Length];
                matt2.zhushi.CopyTo(item.zhushi, 0);
                list.Add(item);
            }
        }
        if ((objtype.getobjmark(this.myobj.objType).show > 0) && (this.myobj.objType != objtype.page))
        {
            item = new matt
            {
                name = "x".GetbytesssASCII()
            };
            item.att.attlei = attshulei.UU16.typevalue;
            item.att.merrylenth = 2;
            item.att.isxiugai = 0;
            item.zhushi = datasize.Objzhushiencoding.GetBytes("X坐标".Language());
            item.zhi = ((ushort)this.GetattVal_string("x").Getint()).structToBytes();
            list.Add(item);
            item = new matt
            {
                name = "y".GetbytesssASCII()
            };
            item.att.attlei = attshulei.UU16.typevalue;
            item.att.merrylenth = 2;
            item.att.isxiugai = 0;
            item.zhushi = datasize.Objzhushiencoding.GetBytes("Y坐标".Language());
            item.zhi = ((ushort)this.GetattVal_string("y").Getint()).structToBytes();
            list.Add(item);
            item = new matt
            {
                name = "w".GetbytesssASCII()
            };
            item.att.attlei = attshulei.UU16.typevalue;
            item.att.merrylenth = 2;
            item.att.isxiugai = 0;
            item.zhushi = datasize.Objzhushiencoding.GetBytes("宽度".Language());
            item.zhi = ((ushort)this.GetattVal_string("w").Getint()).structToBytes();
            list.Add(item);
            item = new matt
            {
                name = "h".GetbytesssASCII()
            };
            item.att.attlei = attshulei.UU16.typevalue;
            item.att.merrylenth = 2;
            item.att.isxiugai = 0;
            item.zhushi = datasize.Objzhushiencoding.GetBytes("高度".Language());
            item.zhi = ((ushort)this.GetattVal_string("h").Getint()).structToBytes();
            list.Add(item);
        }
        return list;
    }

    public matt Getatt(string name)
    {
        matt matt;
        PosLaction laction = new PosLaction();
        byte[] bytesssASCII = name.GetbytesssASCII(8);
        laction.star = 0;
        laction.end = 7;
        for (int i = 0; i < this.atts.Count; i++)
        {
            if (Kuozhan.makebytes(this.atts[i].name, bytesssASCII) && this.checkatt(this.atts[i]))
            {
                return this.atts[i];
            }
        }
        if (name == "id")
        {
            matt = new matt
            {
                name = "id".GetbytesssASCII(8),
                zhi = ((byte)this.objid).structToBytes(),
                zhushi = datasize.Objzhushiencoding.GetBytes("控件ID".Language())
            };
            matt.att.isxiugai = 0;
            matt.att.chonghui = 0xff;
            matt.att.merrylenth = (ushort)matt.zhi.Length;
            matt.att.zhanyonglenth = matt.att.merrylenth;
            matt.att.attlei = attshulei.UU8.typevalue;
            matt.att.datafrom = 0xff;
            matt.att.maxval = 0;
            matt.att.minval = 0;
            matt.att.pos = 0;
            matt.att.isbangding = 0;
            return matt;
        }
        if (name == "objname")
        {
            matt = new matt
            {
                name = "objname".GetbytesssASCII(8),
                zhi = this.objname.GetbytesssASCII(14),
                zhushi = datasize.Objzhushiencoding.GetBytes("控件名称".Language())
            };
            matt.att.isxiugai = 0;
            matt.att.chonghui = 0xff;
            matt.att.merrylenth = (ushort)(matt.zhi.Length + 1);
            matt.att.zhanyonglenth = matt.att.merrylenth;
            matt.att.attlei = attshulei.Sstr.typevalue;
            matt.att.datafrom = 0xff;
            matt.att.maxval = 0;
            matt.att.minval = 0;
            matt.att.pos = 0;
            matt.att.isbangding = 0;
            return matt;
        }
        if (objtype.getobjmark(this.myobj.objType).show > 0)
        {
            if (name == "x")
            {
                matt = new matt
                {
                    name = "x".GetbytesssASCII(8),
                    zhi = this.myobj.redian.x.structToBytes(),
                    zhushi = datasize.Objzhushiencoding.GetBytes("X坐标".Language())
                };
                matt.att.isxiugai = 0;
                matt.att.chonghui = 0xff;
                matt.att.merrylenth = (ushort)matt.zhi.Length;
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.datafrom = 0xff;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                return matt;
            }
            if (name == "y")
            {
                matt = new matt
                {
                    name = "y".GetbytesssASCII(8),
                    zhi = this.myobj.redian.y.structToBytes(),
                    zhushi = datasize.Objzhushiencoding.GetBytes("Y坐标".Language())
                };
                matt.att.isxiugai = 0;
                matt.att.chonghui = 0xff;
                matt.att.merrylenth = (ushort)matt.zhi.Length;
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.datafrom = 0xff;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                return matt;
            }
            if (name == "w")
            {
                matt = new matt
                {
                    name = "w".GetbytesssASCII(8),
                    zhi = ((ushort)((this.myobj.redian.endx - this.myobj.redian.x) + 1)).structToBytes(),
                    zhushi = datasize.Objzhushiencoding.GetBytes("宽度".Language())
                };
                matt.att.isxiugai = 0;
                matt.att.chonghui = 0xff;
                matt.att.merrylenth = (ushort)matt.zhi.Length;
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.datafrom = 0xff;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                return matt;
            }
            if (name == "h")
            {
                matt = new matt
                {
                    name = "h".GetbytesssASCII(8),
                    zhi = ((ushort)((this.myobj.redian.endy - this.myobj.redian.y) + 1)).structToBytes(),
                    zhushi = datasize.Objzhushiencoding.GetBytes("高度".Language())
                };
                matt.att.isxiugai = 0;
                matt.att.chonghui = 0xff;
                matt.att.merrylenth = (ushort)matt.zhi.Length;
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.datafrom = 0xff;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                return matt;
            }
            if (name == "endx")
            {
                matt = new matt
                {
                    name = "endx".GetbytesssASCII(8),
                    zhi = this.myobj.redian.endx.structToBytes(),
                    zhushi = datasize.Objzhushiencoding.GetBytes("endx".Language())
                };
                matt.att.isxiugai = 0;
                matt.att.chonghui = 0xff;
                matt.att.merrylenth = (ushort)matt.zhi.Length;
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.datafrom = 0xff;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                return matt;
            }
            if (name == "endy")
            {
                matt = new matt
                {
                    name = "endy".GetbytesssASCII(8),
                    zhi = this.myobj.redian.endy.structToBytes(),
                    zhushi = datasize.Objzhushiencoding.GetBytes("endy".Language())
                };
                matt.att.isxiugai = 0;
                matt.att.chonghui = 0xff;
                matt.att.merrylenth = (ushort)matt.zhi.Length;
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.datafrom = 0xff;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                return matt;
            }
        }
        return null;
    }

    private int Getatt_Codes(ref List<string> mycodes, int index)
    {
        string str = "0";
        int num = 0;
        List<string>[] zhiling = new List<string>[] {
            new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(),
            new List<string>(), new List<string>(), new List<string>()
         };
        this.myobj.objType = this.atts[0].zhi[0];
        if (index >= zhiling.Length)
        {
            return 0;
        }
        if ((this.atts.Count > 0) && (this.atts[0].zhi.Length == 1))
        {
            string str2;
            if (this.atts[0].zhi[0] == objtype.number)
            {
                switch (this.GetattVal_string("sta"))
                {
                    case "0":
                        zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&',0," + str);
                        if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                        {
                            zhiling[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                        }
                        zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                        zhiling[0].Add("nstr '&val&','&lenth&'");
                        zhiling[2].Add("nstr '&val&','&lenth&'");
                        zhiling[8].Add("nstr '&val&','&lenth&'");
                        break;

                    case "1":
                        str2 = this.GetattVal_string("style");
                        if (str2 != null)
                        {
                            if (str2 == "1")
                            {
                                str = this.GetattVal_string("borderw");
                            }
                            else if (((str2 == "2") || (str2 == "3")) || (str2 == "4"))
                            {
                                str = "1";
                            }
                        }
                        zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',1,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                        zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                        zhiling[0].Add("nstr '&val&','&lenth&'");
                        zhiling[2].Add("nstr '&val&','&lenth&'");
                        zhiling[8].Add("nstr '&val&','&lenth&'");
                        this.getstylecode(ref zhiling, "0-2-8", str2);
                        break;

                    case "2":
                        zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',2,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[2].Add("pic '&x&','&y&','&pic&'");
                        zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[8].Add("pic '&x&','&y&','&pic&'");
                        zhiling[0].Add("nstr '&val&','&lenth&'");
                        zhiling[2].Add("nstr '&val&','&lenth&'");
                        zhiling[8].Add("nstr '&val&','&lenth&'");
                        break;
                }
            }
            else
            {
                string str3;
                string str4;
                if (this.atts[0].zhi[0] == objtype.button_t)
                {
                    str3 = this.GetattVal_string("sta");
                    str4 = this.GetattVal_string("style");
                    if (str3 != null)
                    {
                        if (str3 == "0")
                        {
                            zhiling[0].Add("if('&val&'==1)");
                            zhiling[0].Add("{");
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc1&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("}else");
                            zhiling[0].Add("{");
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc0&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("}");
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[2].Add("if('&val&'==1)");
                            zhiling[2].Add("{");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc1&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("}else");
                            zhiling[2].Add("{");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc0&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("}");
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[4].Add("if('&val&'==1)");
                            zhiling[4].Add("{");
                            zhiling[4].Add("'&val&'=0");
                            zhiling[4].Add("}else");
                            zhiling[4].Add("{");
                            zhiling[4].Add("'&val&'=1");
                            zhiling[4].Add("}");
                            if (this.GetattVal_string("val") == "0")
                            {
                                zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc0&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            }
                            else
                            {
                                zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc1&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            }
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                        }
                        else if (str3 == "1")
                        {
                            str2 = this.GetattVal_string("style");
                            if (str2 != null)
                            {
                                if (str2 == "1")
                                {
                                    str = this.GetattVal_string("borderw");
                                }
                                else if (((str2 == "2") || (str2 == "3")) || (str2 == "4"))
                                {
                                    str = "1";
                                }
                            }
                            zhiling[0].Add("if('&val&'==1)");
                            zhiling[0].Add("{");
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco1&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            if ((str4 != null) && (str4 == "4"))
                            {
                                zhiling[0].Add("draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color0 + "," + this.d3color1 + ",1");
                            }
                            zhiling[0].Add("}else");
                            zhiling[0].Add("{");
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco0&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            if ((str4 != null) && (str4 == "4"))
                            {
                                zhiling[0].Add("draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color1 + "," + this.d3color0 + ",1");
                            }
                            zhiling[0].Add("}");
                            zhiling[2].Add("if('&val&'==1)");
                            zhiling[2].Add("{");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco1&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            if ((str4 != null) && (str4 == "4"))
                            {
                                zhiling[2].Add("draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color0 + "," + this.d3color1 + ",1");
                            }
                            zhiling[2].Add("}else");
                            zhiling[2].Add("{");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco0&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            if ((str4 != null) && (str4 == "4"))
                            {
                                zhiling[2].Add("draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color1 + "," + this.d3color0 + ",1");
                            }
                            zhiling[2].Add("}");
                            zhiling[4].Add("if('&val&'==1)");
                            zhiling[4].Add("{");
                            zhiling[4].Add("'&val&'=0");
                            zhiling[4].Add("}else");
                            zhiling[4].Add("{");
                            zhiling[4].Add("'&val&'=1");
                            zhiling[4].Add("}");
                            if (this.GetattVal_string("val") == "0")
                            {
                                zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco0&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                if ((str4 != null) && (str4 == "4"))
                                {
                                    zhiling[8].Add("draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color1 + "," + this.d3color0 + ",1");
                                }
                            }
                            else
                            {
                                zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco1&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                if ((str4 != null) && (str4 == "4"))
                                {
                                    zhiling[8].Add("draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color0 + "," + this.d3color1 + ",1");
                                }
                            }
                            if ((str4 != null) && (str4 != "4"))
                            {
                                this.getstylecode(ref zhiling, "0-2-8", str2);
                            }
                        }
                        else if (str3 == "2")
                        {
                            zhiling[0].Add("if('&val&'==1)");
                            zhiling[0].Add("{");
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic1&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("}else");
                            zhiling[0].Add("{");
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic0&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("}");
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[2].Add("if('&val&'==1)");
                            zhiling[2].Add("{");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic1&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("}else");
                            zhiling[2].Add("{");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic0&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("}");
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[4].Add("if('&val&'==1)");
                            zhiling[4].Add("{");
                            zhiling[4].Add("'&val&'=0");
                            zhiling[4].Add("}else");
                            zhiling[4].Add("{");
                            zhiling[4].Add("'&val&'=1");
                            zhiling[4].Add("}");
                            if (this.GetattVal_string("val") == "0")
                            {
                                zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic0&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            }
                            else
                            {
                                zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic1&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            }
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                        }
                    }
                }
                else if (this.atts[0].zhi[0] == objtype.checkbox)
                {
                    str2 = this.GetattVal_string("style");
                    zhiling[0].Add("sya0='&w&'/4");
                    zhiling[0].Add("sya1='&w&'-sya0-sya0");
                    zhiling[0].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                    zhiling[0].Add("if('&val&'==1)");
                    zhiling[0].Add("{");
                    zhiling[0].Add("fill '&x&'+sya0,'&y&'+sya0,sya1,sya1,'&pco&'");
                    zhiling[0].Add("}");
                    zhiling[2].Add("sya0='&w&'/4");
                    zhiling[2].Add("sya1='&w&'-sya0-sya0");
                    zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                    zhiling[2].Add("if('&val&'==1)");
                    zhiling[2].Add("{");
                    zhiling[2].Add("fill '&x&'+sya0,'&y&'+sya0,sya1,sya1,'&pco&'");
                    zhiling[2].Add("}");
                    zhiling[4].Add("if('&val&'==1)");
                    zhiling[4].Add("{");
                    zhiling[4].Add("'&val&'=0");
                    zhiling[4].Add("}else");
                    zhiling[4].Add("{");
                    zhiling[4].Add("'&val&'=1");
                    zhiling[4].Add("}");
                    zhiling[8].Add("sya0='&w&'/4");
                    zhiling[8].Add("sya1='&w&'-sya0-sya0");
                    zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                    if (this.GetattVal_string("val") == "1")
                    {
                        zhiling[8].Add("fill '&x&'+sya0,'&y&'+sya0,sya1,sya1,'&pco&'");
                    }
                    this.getstylecode(ref zhiling, "0-2-8", str2);
                }
                else if (this.atts[0].zhi[0] == objtype.radiobutton)
                {
                    zhiling[0].Add("sya0='&w&'/2");
                    zhiling[0].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0,'&bco&'");
                    zhiling[0].Add("cir '&x&'+sya0,'&y&'+sya0,sya0,16936");
                    zhiling[0].Add("if('&val&'==1)");
                    zhiling[0].Add("{");
                    zhiling[0].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0/2,'&pco&'");
                    zhiling[0].Add("}");
                    zhiling[2].Add("sya0='&w&'/2");
                    zhiling[2].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0,'&bco&'");
                    zhiling[2].Add("cir '&x&'+sya0,'&y&'+sya0,sya0,16936");
                    zhiling[2].Add("if('&val&'==1)");
                    zhiling[2].Add("{");
                    zhiling[2].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0/2,'&pco&'");
                    zhiling[2].Add("}");
                    zhiling[4].Add("if('&val&'==1)");
                    zhiling[4].Add("{");
                    zhiling[4].Add("'&val&'=0");
                    zhiling[4].Add("}else");
                    zhiling[4].Add("{");
                    zhiling[4].Add("'&val&'=1");
                    zhiling[4].Add("}");
                    zhiling[8].Add("sya0='&w&'/2");
                    zhiling[8].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0,'&bco&'");
                    zhiling[8].Add("cir '&x&'+sya0,'&y&'+sya0,sya0,16936");
                    if (this.GetattVal_string("val") == "1")
                    {
                        zhiling[8].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0/2,'&pco&'");
                    }
                }
                else if (this.atts[0].zhi[0] == objtype.Timer)
                {
                    zhiling[1].Add("timerset 0,'&id&',65535");
                    zhiling[1].Add("L '&pageid&'-'&id&'a");
                    zhiling[2].Add("if('&en&'==1)");
                    zhiling[2].Add("{");
                    zhiling[2].Add("timerset 1,'&id&','&tim&'");
                    zhiling[2].Add("}");
                    zhiling[7].Add("S '&pageid&'-'&id&'a");
                    zhiling[0].Add("S '&pageid&'-'&id&'r");
                    zhiling[0].Add("if('&en&'==1)");
                    zhiling[0].Add("{");
                    zhiling[0].Add("timerset 1,'&id&','&tim&'");
                    zhiling[0].Add("}else");
                    zhiling[0].Add("{");
                    zhiling[0].Add("timerset 1,'&id&',65535");
                    zhiling[0].Add("}");
                    zhiling[0x11].Add("ifvis '&id&',1");
                    zhiling[0x11].Add("L '&pageid&'-'&id&'r");
                }
                else if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_SLIDER)
                {
                    zhiling[2].Add("load '&id&'");
                }
                else if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_CURVE)
                {
                    zhiling[1].Add("init '&id&'");
                    zhiling[2].Add("load '&id&'");
                }
                else if (this.atts[0].zhi[0] == objtype.text)
                {
                    str3 = this.GetattVal_string("sta");
                    if (str3 != null)
                    {
                        if (str3 == "0")
                        {
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                            {
                                zhiling[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                            }
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                        }
                        else if (str3 == "1")
                        {
                            str2 = this.GetattVal_string("style");
                            if (str2 != null)
                            {
                                if (str2 == "1")
                                {
                                    str = this.GetattVal_string("borderw");
                                }
                                else if (((str2 == "2") || (str2 == "3")) || (str2 == "4"))
                                {
                                    str = "1";
                                }
                            }
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',1,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            this.getstylecode(ref zhiling, "0-2-8", str2);
                        }
                        else if (str3 == "2")
                        {
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',2,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[2].Add("pic '&x&','&y&','&pic&'");
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                            zhiling[8].Add("pic '&x&','&y&','&pic&'");
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                        }
                    }
                }
                else if (this.atts[0].zhi[0] == objtype.gtext)
                {
                    str3 = this.GetattVal_string("sta");
                    str4 = this.GetattVal_string("style");
                    str2 = this.GetattVal_string("style");
                    if ((str3 == "1") && (str2 != null))
                    {
                        if (str2 == "1")
                        {
                            str = this.GetattVal_string("borderw");
                        }
                        else if (((str2 == "2") || (str2 == "3")) || (str2 == "4"))
                        {
                            str = "1";
                        }
                    }
                    if (str3 != null)
                    {
                        zhiling[0].Add("S '&pageid&'-'&id&'r");
                        zhiling[1].Add("setbrush '&x&','&y&','&w&','&h&','&font&',0,0,0,0,0,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[1].Add("strsize '&txt&','&vvs2&','&vvs3&'");
                        zhiling[1].Add("if('&dir&'==0)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'='&x&'-'&vvs2&'-1");
                        zhiling[1].Add("'&vvs1&'=32767");
                        zhiling[1].Add("}else if('&dir&'==1)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'='&endx&'+1");
                        zhiling[1].Add("'&vvs1&'=32767");
                        zhiling[1].Add("}else if('&dir&'==2)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'='&y&'-'&vvs3&'-1");
                        zhiling[1].Add("'&vvs0&'=32767");
                        zhiling[1].Add("}else if('&dir&'==3)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'='&endy&'+1");
                        zhiling[1].Add("'&vvs0&'=32767");
                        zhiling[1].Add("}");
                        zhiling[1].Add("timerset 0,'&id&',65535");
                        zhiling[1].Add("L '&pageid&'-'&id&'a");
                        zhiling[1].Add("L '&pageid&'-'&id&'b");
                        zhiling[1].Add("S '&pageid&'-'&id&'a");
                        zhiling[1].Add("if('&en&'==1)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("setbrush '&x&','&y&','&w&','&h&','&font&',0,0,0,0,0,'&isbr&','&spax&','&spay&',0," + str);
                        zhiling[1].Add("strsize '&txt&','&vvs2&','&vvs3&'");
                        zhiling[1].Add("if('&dir&'==0)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'=32767");
                        zhiling[1].Add("'&vvs0&'='&vvs0&'+'&dis&'");
                        zhiling[1].Add("sya0='&x&'-'&vvs2&'");
                        zhiling[1].Add("if('&vvs0&'>'&endx&')");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'='&x&'-'&vvs2&'");
                        zhiling[1].Add("}else if('&vvs0&'<sya0)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'=sya0");
                        zhiling[1].Add("}");
                        zhiling[1].Add("}else if('&dir&'==1)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'=32767");
                        zhiling[1].Add("'&vvs0&'='&vvs0&'-'&dis&'");
                        zhiling[1].Add("sya0='&x&'-'&vvs2&'");
                        zhiling[1].Add("if('&vvs0&'<sya0)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'='&endx&'");
                        zhiling[1].Add("}else if('&vvs0&'>'&endx&')");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'='&endx&'");
                        zhiling[1].Add("}");
                        zhiling[1].Add("}else if('&dir&'==2)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'=32767");
                        zhiling[1].Add("'&vvs1&'='&vvs1&'+'&dis&'");
                        zhiling[1].Add("sya0='&y&'-'&vvs3&'");
                        zhiling[1].Add("if('&vvs1&'>'&endy&')");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'='&y&'-'&vvs3&'");
                        zhiling[1].Add("}else if('&vvs1&'<sya0)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'=sya0");
                        zhiling[1].Add("}");
                        zhiling[1].Add("}else if('&dir&'==3)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs0&'=32767");
                        zhiling[1].Add("'&vvs1&'='&vvs1&'-'&dis&'");
                        zhiling[1].Add("sya0='&y&'-'&vvs3&'");
                        zhiling[1].Add("if('&vvs1&'<sya0)");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'='&endy&'");
                        zhiling[1].Add("}else if('&vvs1&'>'&endy&')");
                        zhiling[1].Add("{");
                        zhiling[1].Add("'&vvs1&'='&endy&'");
                        zhiling[1].Add("}");
                        zhiling[1].Add("}");
                        zhiling[1].Add("ifvis '&id&',1");
                        zhiling[1].Add("L '&pageid&'-'&id&'r");
                        zhiling[1].Add("E");
                        zhiling[1].Add("}");
                        zhiling[1].Add("S '&pageid&'-'&id&'b");
                        if (str3 == "0")
                        {
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&',0," + str);
                            if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                            {
                                zhiling[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                zhiling[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                            }
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                            zhiling[2].Add("if('&en&'==1)");
                            zhiling[2].Add("{");
                            zhiling[2].Add("timerset 1,'&id&','&tim&'");
                            zhiling[2].Add("}");
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[0].Add("zstr '&vvs0&','&vvs1&','&vvs2&','&vvs3&','&txt&'");
                            zhiling[0].Add("if('&en&'==1)");
                            zhiling[0].Add("{");
                            zhiling[0].Add("timerset 1,'&id&','&tim&'");
                            zhiling[0].Add("}else");
                            zhiling[0].Add("{");
                            zhiling[0].Add("timerset 1,'&id&',65535");
                            zhiling[0].Add("}");
                        }
                        else if (str3 == "1")
                        {
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',1,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                            zhiling[2].Add("if('&en&'==1)");
                            zhiling[2].Add("{");
                            zhiling[2].Add("timerset 1,'&id&','&tim&'");
                            zhiling[2].Add("}");
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[0].Add("zstr '&vvs0&','&vvs1&','&vvs2&','&vvs3&','&txt&'");
                            this.getstylecode(ref zhiling, "0-2-8", str2);
                            zhiling[0].Add("if('&en&'==1)");
                            zhiling[0].Add("{");
                            zhiling[0].Add("timerset 1,'&id&','&tim&'");
                            zhiling[0].Add("}else");
                            zhiling[0].Add("{");
                            zhiling[0].Add("timerset 1,'&id&',65535");
                            zhiling[0].Add("}");
                        }
                        else if (str3 == "2")
                        {
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',2,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("pic '&x&','&y&','&pic&'");
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[8].Add("pic '&x&','&y&','&pic&'");
                            zhiling[2].Add("if('&en&'==1)");
                            zhiling[2].Add("{");
                            zhiling[2].Add("timerset 1,'&id&','&tim&'");
                            zhiling[2].Add("}");
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[0].Add("zstr '&vvs0&','&vvs1&','&vvs2&','&vvs3&','&txt&'");
                            zhiling[0].Add("if('&en&'==1)");
                            zhiling[0].Add("{");
                            zhiling[0].Add("timerset 1,'&id&','&tim&'");
                            zhiling[0].Add("}else");
                            zhiling[0].Add("{");
                            zhiling[0].Add("timerset 1,'&id&',65535");
                            zhiling[0].Add("}");
                        }
                    }
                }
                else if (this.atts[0].zhi[0] == objtype.button)
                {
                    str3 = this.GetattVal_string("sta");
                    if (str3 != null)
                    {
                        if (str3 == "0")
                        {
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            if ((this.Mypage.objs[0].GetattVal_string("sta") == "2") && (this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                            {
                                zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                            }
                            else
                            {
                                zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            }
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[4].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco2&','&picc2&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[4].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[6].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[6].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                        }
                        else if (str3 == "1")
                        {
                            str2 = this.GetattVal_string("style");
                            if (str2 != null)
                            {
                                if (str2 == "1")
                                {
                                    str = this.GetattVal_string("borderw");
                                }
                                else if (((str2 == "2") || (str2 == "3")) || (str2 == "4"))
                                {
                                    str = "1";
                                }
                            }
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[4].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco2&','&bco2&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[4].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[6].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[6].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            this.getstylecode(ref zhiling, "0-2-4-6-8", str2);
                        }
                        else if (str3 == "2")
                        {
                            zhiling[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[4].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco2&','&pic2&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[4].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[6].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[6].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            zhiling[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                            zhiling[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                        }
                    }
                }
                else if (this.atts[0].zhi[0] == objtype.prog)
                {
                    str3 = this.GetattVal_string("sta");
                    str4 = this.GetattVal_string("dez");
                    if (str3 != null)
                    {
                        if (str3 == "0")
                        {
                            switch (str4)
                            {
                                case "0":
                                    zhiling[0].Add("sya0='&val&'*'&w&'/100");
                                    zhiling[0].Add("fill '&x&','&y&',sya0,'&h&','&pco&'");
                                    zhiling[0].Add("fill '&x&'+sya0,'&y&','&w&'-sya0,'&h&','&bco&'");
                                    zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    zhiling[2].Add("fill '&x&','&y&','&val&'*'&w&'/100,'&h&','&pco&'");
                                    zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    zhiling[8].Add("fill '&x&','&y&','&val&'*'&w&'/100,'&h&','&pco&'");
                                    break;

                                case "1":
                                    zhiling[0].Add("sya0='&val&'*'&h&'/100");
                                    zhiling[0].Add("fill '&x&','&endy&'+1-sya0,'&w&',sya0,'&pco&'");
                                    zhiling[0].Add("fill '&x&','&y&','&w&','&h&'-sya0,'&bco&'");
                                    zhiling[2].Add("sya0='&val&'*'&h&'/100");
                                    zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    zhiling[2].Add("fill '&x&','&endy&'+1-sya0,'&w&',sya0,'&pco&'");
                                    zhiling[8].Add("sya0='&val&'*'&h&'/100");
                                    zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    zhiling[8].Add("fill '&x&','&endy&'+1-sya0,'&w&',sya0,'&pco&'");
                                    break;
                            }
                        }
                        else if (str3 == "1")
                        {
                            switch (str4)
                            {
                                case "0":
                                    zhiling[0].Add("sya0='&val&'*'&w&'/100");
                                    zhiling[0].Add("xpic '&x&','&y&',sya0,'&h&',0,0,'&ppic&'");
                                    zhiling[0].Add("xpic '&x&'+sya0,'&y&','&w&'-sya0,'&h&',sya0,0,'&bpic&'");
                                    zhiling[2].Add("pic '&x&','&y&','&bpic&'");
                                    zhiling[2].Add("xpic '&x&','&y&','&val&'*'&w&'/100,'&h&',0,0,'&ppic&'");
                                    zhiling[8].Add("pic '&x&','&y&','&bpic&'");
                                    zhiling[8].Add("xpic '&x&','&y&','&val&'*'&w&'/100,'&h&',0,0,'&ppic&'");
                                    break;

                                case "1":
                                    zhiling[0].Add("sya0='&val&'*'&h&'/100");
                                    zhiling[0].Add("xpic '&x&','&endy&'+1-sya0,'&w&',sya0,0,'&h&'-sya0,'&ppic&'");
                                    zhiling[0].Add("xpic '&x&','&y&','&w&','&h&'-sya0,0,0,'&bpic&'");
                                    zhiling[2].Add("sya0='&val&'*'&h&'/100");
                                    zhiling[2].Add("pic '&x&','&y&','&bpic&'");
                                    zhiling[2].Add("xpic '&x&','&endy&'+1-sya0,'&w&',sya0,0,'&h&'-sya0,'&ppic&'");
                                    zhiling[8].Add("sya0='&val&'*'&h&'/100");
                                    zhiling[8].Add("pic '&x&','&y&','&bpic&'");
                                    zhiling[8].Add("xpic '&x&','&endy&'+1-sya0,'&w&',sya0,0,'&h&'-sya0,'&ppic&'");
                                    break;
                            }
                        }
                    }
                }
                else if (this.atts[0].zhi[0] == objtype.pic)
                {
                    zhiling[0].Add("pic '&x&','&y&','&pic&'");
                    zhiling[2].Add("pic '&x&','&y&','&pic&'");
                    zhiling[8].Add("pic '&x&','&y&','&pic&'");
                }
                else if (this.atts[0].zhi[0] == objtype.picc)
                {
                    zhiling[0].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                    zhiling[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                    zhiling[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                }
                else if (this.atts[0].zhi[0] != objtype.touch)
                {
                    if (this.atts[0].zhi[0] == objtype.zhizhen)
                    {
                        str3 = this.GetattVal_string("sta");
                        if (str3 != null)
                        {
                            if (str3 == "0")
                            {
                                zhiling[0].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                                {
                                    zhiling[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                }
                                zhiling[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                            }
                            else if (str3 == "1")
                            {
                                zhiling[0].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                            }
                            else if (str3 == "2")
                            {
                                zhiling[0].Add("pic '&x&','&y&','&pic&'");
                                zhiling[2].Add("pic '&x&','&y&','&pic&'");
                                zhiling[8].Add("pic '&x&','&y&','&pic&'");
                            }
                            zhiling[0].Add("draw_h '&w&'/2+'&x&','&h&'/2+'&y&','&h&'/2-'&wid&','&val&','&wid&','&pco&'");
                            zhiling[2].Add("draw_h '&w&'/2+'&x&','&h&'/2+'&y&','&h&'/2-'&wid&','&val&','&wid&','&pco&'");
                            zhiling[8].Add("draw_h '&w&'/2+'&x&','&h&'/2+'&y&','&h&'/2-'&wid&','&val&','&wid&','&pco&'");
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.page)
                    {
                        switch (this.GetattVal_string("sta"))
                        {
                            case "1":
                                zhiling[0].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                zhiling[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                zhiling[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                break;

                            case "2":
                                zhiling[0].Add("pic '&x&','&y&','&pic&'");
                                zhiling[2].Add("pic '&x&','&y&','&pic&'");
                                zhiling[8].Add("pic '&x&','&y&','&pic&'");
                                break;
                        }
                    }
                }
            }
        }
        foreach (string str5 in zhiling[index])
        {
            num++;
            mycodes.Add(str5);
        }
        return num;
    }

    public byte[] GetattVal_byte(string name)
    {
        matt att = this.Getatt(name);
        if (att == null)
        {
            return null;
        }
        byte[] array = new byte[att.zhi.Length];
        att.zhi.CopyTo(array, 0);
        return array;
    }

    public string GetattVal_string(string name)
    {
        matt att = this.Getatt(name);
        if (att != null)
        {
            if (att.att.attlei == attshulei.Sstr.typevalue)
            {
                return this.Getobjencodeing(name).GetString(att.zhi);
            }
            if (att.att.merrylenth == 1)
            {
                return att.zhi[0].ToString();
            }
            if (att.att.merrylenth == 2)
            {
                if ((att.att.attlei & 15) == attshulei.UU16.typevalue)
                {
                    ushort num = (ushort)att.zhi.BytesTostruct(((ushort)0).GetType());
                    return num.ToString();
                }
                short num2 = (short)att.zhi.BytesTostruct(((short)0).GetType());
                return num2.ToString();
            }
            if (att.att.merrylenth == 4)
            {
                int num3 = (int)att.zhi.BytesTostruct(0.GetType());
                return num3.ToString();
            }
        }
        return null;
    }

    public int Getbianji(ref List<byte[]> ll)
    {
        List<string> mycodes = new List<string>();
        this.Getatt_Codes(ref mycodes, 8);
        List<byte[]> list2 = this.canshutihuan(ref mycodes, 1);
        foreach (byte[] buffer in list2)
        {
            ll.Add(buffer);
        }
        return list2.Count;
    }

    public int Getbianyi(ref List<byte[]> ll, int index, bool istihuan, int flg)
    {
        int decx = 0;
        int count = 0;
        List<string> mycodes = new List<string>();
        List<byte[]> cglist = new List<byte[]>();
        if ((flg == 1) || (flg == 2))
        {
            this.Getatt_Codes(ref mycodes, index);
        }
        decx = mycodes.Count;
        if ((flg == 0) || (flg == 2))
        {
            foreach (string str in this.Codes[index])
            {
                mycodes.Add(str);
            }
        }
        if ((flg == 1) || (flg == 2))
        {
            this.Getatt_Codes(ref mycodes, 10 + index);
        }
        if (index == 6)
        {
            matt att = this.Getatt("key");
            if ((att != null) && this.checkatt(att))
            {
                keyboardlisttype keyboardlisttype = this.Myapp.getkeyboardlisttype(att.zhi[0]);
                if ((keyboardlisttype.id != 0xff) && (this.Myapp.findpagename(keyboardlisttype.pagename, 0xffff) != -1))
                {
                    mycodes.Add(keyboardlisttype.pagename + ".loadpageid.val=dp");
                    mycodes.Add(keyboardlisttype.pagename + ".loadcmpid.val='&id&'");
                    mycodes.Add("page " + keyboardlisttype.pagename);
                }
            }
        }
        this.canshutihuan(ref mycodes, 0);
        mycodes.delzhushi();
        if (!this.GetbianyiCodes(mycodes, ref cglist, index, decx))
        {
            return 0xffff;
        }
        count = cglist.Count;
        ll.AddListBytes(cglist);
        return count;
    }

    // hmitype.mobj
    public unsafe bool GetbianyiCodes(List<string> bts, ref List<byte[]> cglist, int eventid, int decx)
    {
        int i = 0;
        byte[] item = new byte[0];
        PosLaction posLaction = default(PosLaction);
        List<ifbianyi_> list = new List<ifbianyi_>();
        bianyijieguotype by = default(bianyijieguotype);
        by.pageid = this.Mypage.pageid;
        by.objid = this.objid;
        by.eventid = eventid;
        posLaction.star = 0;
        bool result;
        try
        {
            i = 0;
            while (i < bts.Count)
            {
                by.line = i - decx;
                string text = bts[i];
                if (text.Length > 0)
                {
                    posLaction.end = (ushort)(bts[i].Length - 1);
                    if (bts[i].Length > 11 && bts[i].Substring(0, 11) == "timerset 0,")
                    {
                        string[] array = bts[i].Split(new char[]
                        {
                        ','
                        });
                        this.addtimers(array[1].Getint());
                    }
                    if ((bts[i].Length > 4 && bts[i].Substring(0, 3) == "if(") || (bts[i].Length > 7 && bts[i].Substring(0, 6) == "while(") || (bts[i].Length > 5 && bts[i].Substring(0, 4) == "for("))
                    {
                        ifbianyi_ item2 = default(ifbianyi_);
                        item2.endstr = new List<string>();
                        string text2;
                        string str;
                        if (bts[i].Substring(0, 1) == "w")
                        {
                            text2 = "S while" + this.Myapp.xunhuanmark.ToString();
                            this.Myapp.xunhuanmark++;
                            this.bianyionline(text2, ref item, bts[by.line + decx], by);
                            cglist.Add(item);
                            item2.endstr.Add("L while" + (this.Myapp.xunhuanmark - 1).ToString());
                            str = "if" + bts[i].Substring(5, bts[i].Length - 5);
                        }
                        else if (bts[i].Substring(0, 1) == "f")
                        {
                            string[] array = bts[i].Split(new char[]
                            {
                            ';'
                            });
                            if (array.Length != 3 || bts[i].Substring(bts[i].Length - 1, 1) != ")")
                            {
                                this.sendbianyierror("for语句格式无效".Language(), bts[i - 1], by);
                                result = false;
                                return result;
                            }
                            text2 = array[0].Split(new char[]
                            {
                            '('
                            })[1];
                            this.bianyionline(text2, ref item, bts[by.line + decx], by);
                            cglist.Add(item);
                            text2 = "S for" + this.Myapp.xunhuanmark.ToString();
                            this.Myapp.xunhuanmark++;
                            this.bianyionline(text2, ref item, bts[by.line + decx], by);
                            cglist.Add(item);
                            text2 = array[2].Split(new char[]
                            {
                            ')'
                            })[0];
                            this.bianyionline(text2, ref item, bts[by.line + decx], by);
                            item2.endstr.Add(array[2].Split(new char[]
                            {
                            ')'
                            })[0]);
                            item2.endstr.Add("L for" + (this.Myapp.xunhuanmark - 1).ToString());
                            str = "if(" + array[1] + ")";
                        }
                        else
                        {
                            str = bts[i];
                        }
                        text2 = this.chonggouif(str, ref by);
                        if (text2 == "")
                        {
                            result = false;
                            return result;
                        }
                        i++;
                        if (i >= bts.Count || bts[i][0] != '{' || bts[i].Length != 1)
                        {
                            this.sendbianyierror("语句错误:无前括号:{".Language(), bts[i - 1], by);
                            result = false;
                            return result;
                        }
                        i++;
                        if (i >= bts.Count)
                        {
                            this.sendbianyierror("语句错误:无后括号:}".Language(), bts[i - 1], by);
                            result = false;
                            return result;
                        }
                        this.bianyionline(text2, ref item, bts[by.line + decx], by);
                        cglist.Add(item);
                        item2.ListIndex = (int)((ushort)(cglist.Count - 1));
                        item2.id = by.line + decx;
                        item2.Lei = "if";
                        item2.guanlian = -1;
                        list.Add(item2);
                    }
                    else
                    {
                        if (text == "{")
                        {
                            this.sendbianyierror("多余的前括号:{".Language(), bts[i], by);
                            result = false;
                            return result;
                        }
                        if (text == "}")
                        {
                            if (list.Count == 0)
                            {
                                this.sendbianyierror("多余的后括号:}".Language(), bts[i], by);
                                result = false;
                                return result;
                            }
                            if (list[list.Count - 1].endstr != null && list[list.Count - 1].endstr.Count > 0)
                            {
                                foreach (string current in list[list.Count - 1].endstr)
                                {
                                    string text2 = current;
                                    this.bianyionline(text2, ref item, bts[by.line + decx], by);
                                    cglist.Add(item);
                                }
                            }
                            int num = list[list.Count - 1].ListIndex;
                            int num2 = num;
                            int num3 = cglist.Count - 1 - list[list.Count - 1].ListIndex;
                            byte[] bytes = num3.ToString().GetbytesssASCII();
                            cglist[num] = Kuozhan.Gethebingbytes(cglist[num].subbytes(0, cglist[num].Length - 1), bytes);
                            list.Remove(list[list.Count - 1]);
                            i++;
                            int j = 0;
                            while (j < list.Count)
                            {
                                if (list[j].guanlian == num2)
                                {
                                    num = list[j].ListIndex;
                                    num3 = cglist.Count - 1 - list[j].ListIndex;
                                    bytes = num3.ToString().GetbytesssASCII();
                                    cglist[num] = Kuozhan.Gethebingbytes(cglist[num].subbytes(0, cglist[num].Length - 1), bytes);
                                    list.Remove(list[j]);
                                }
                                else
                                {
                                    j++;
                                }
                            }
                        }
                        else if (text == "}else")
                        {
                            if (list.Count == 0)
                            {
                                this.sendbianyierror("多余的后括号:}".Language(), bts[i], by);
                                result = false;
                                return result;
                            }
                            int num = list[list.Count - 1].ListIndex;
                            int num2 = num;
                            int num3 = cglist.Count - list[list.Count - 1].ListIndex;
                            byte[] bytes = num3.ToString().GetbytesssASCII();
                            cglist[num] = Kuozhan.Gethebingbytes(cglist[num].subbytes(0, cglist[num].Length - 1), bytes);
                            list.Remove(list[list.Count - 1]);
                            i++;
                            int j = 0;
                            while (j < list.Count)
                            {
                                if (list[j].guanlian == num2)
                                {
                                    num = list[j].ListIndex;
                                    num3 = cglist.Count - 1 - list[j].ListIndex;
                                    bytes = num3.ToString().GetbytesssASCII();
                                    cglist[num] = Kuozhan.Gethebingbytes(cglist[num].subbytes(0, cglist[num].Length - 1), bytes);
                                    list.Remove(list[j]);
                                }
                                else
                                {
                                    j++;
                                }
                            }
                            if (i >= bts.Count || bts[i][0] != '{')
                            {
                                this.sendbianyierror("else语句错误:无前括号:{".Language(), bts[i], by);
                                result = false;
                                return result;
                            }
                            i++;
                            if (i >= bts.Count)
                            {
                                this.sendbianyierror("else语句错误:无后括号:}".Language(), bts[i], by);
                                result = false;
                                return result;
                            }
                            cglist.Add("T 0".GetbytesssASCII());
                            list.Add(new ifbianyi_
                            {
                                ListIndex = (int)((ushort)(cglist.Count - 1)),
                                id = by.line + decx,
                                Lei = "else",
                                guanlian = -1
                            });
                        }
                        else if (bts[i].Length > 10 && bts[i].Substring(0, 9) == "}else if(")
                        {
                            if (list.Count == 0)
                            {
                                this.sendbianyierror("多余的后括号:}".Language(), bts[i], by);
                                result = false;
                                return result;
                            }
                            int num = list[list.Count - 1].ListIndex;
                            int num2 = num;
                            int num3 = cglist.Count - list[list.Count - 1].ListIndex;
                            byte[] bytes = num3.ToString().GetbytesssASCII();
                            cglist[num] = Kuozhan.Gethebingbytes(cglist[num].subbytes(0, cglist[num].Length - 1), bytes);
                            list.Remove(list[list.Count - 1]);
                            i++;
                            int j = 0;
                            while (j < list.Count)
                            {
                                if (list[j].guanlian == num2)
                                {
                                    num = list[j].ListIndex;
                                    num3 = cglist.Count - 1 - list[j].ListIndex;
                                    bytes = num3.ToString().GetbytesssASCII();
                                    cglist[num] = Kuozhan.Gethebingbytes(cglist[num].subbytes(0, cglist[num].Length - 1), bytes);
                                    list.Remove(list[j]);
                                }
                                else
                                {
                                    j++;
                                }
                            }
                            if (i >= bts.Count || bts[i][0] != '{')
                            {
                                this.sendbianyierror("else语句错误:无前括号:{".Language(), bts[i], by);
                                result = false;
                                return result;
                            }
                            i++;
                            if (i >= bts.Count)
                            {
                                this.sendbianyierror("else语句错误:无后括号:}".Language(), bts[i], by);
                                result = false;
                                return result;
                            }
                            cglist.Add("T 0".GetbytesssASCII());
                            list.Add(new ifbianyi_
                            {
                                ListIndex = (int)((ushort)(cglist.Count - 1)),
                                id = by.line + decx,
                                Lei = "else",
                                guanlian = (int)((ushort)cglist.Count)
                            });
                            i -= 2;
                            string text2 = this.chonggouif(bts[i].Substring(6, bts[i].Length - 6), ref by);
                            if (text2 == "")
                            {
                                result = false;
                                return result;
                            }
                            i++;
                            if (i >= bts.Count || bts[i][0] != '{' || bts[i].Length != 1)
                            {
                                this.sendbianyierror("语句错误:无前括号:{".Language(), bts[i - 1], by);
                                result = false;
                                return result;
                            }
                            i++;
                            if (i >= bts.Count)
                            {
                                this.sendbianyierror("语句错误:无后括号:}".Language(), bts[i - 1], by);
                                result = false;
                                return result;
                            }
                            this.bianyionline(text2, ref item, bts[by.line + decx], by);
                            cglist.Add(item);
                            list.Add(new ifbianyi_
                            {
                                ListIndex = (int)((ushort)(cglist.Count - 1)),
                                id = by.line + decx,
                                Lei = "else if",
                                guanlian = -1
                            });
                        }
                        else
                        {
                            string text2 = bts[i];
                            this.bianyionline(text2, ref item, bts[by.line + decx], by);
                            cglist.Add(item);
                            i++;
                        }
                    }
                }
                else
                {
                    i++;
                }
            }
            if (list.Count > 0)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    by.line = list[j].id - decx;
                    this.sendbianyierror(list[j].Lei + "不完整:".Language(), bts[list[j].id], by);
                }
                result = false;
                return result;
            }
            for (i = 0; i < cglist.Count; i++)
            {
                if (cglist[i].Length > 2 && cglist[i][0] == 84 && cglist[i][1] == 32)
                {
                    int num3;
                    try
                    {
                        fixed (byte* ptr = &cglist[i][2])
                        {
                            num3 = Strmake.Strmake_StrToS32(ptr, (byte)(cglist[i].Length - 2)) + 1;
                        }
                    }
                    finally
                    {
                        byte* ptr = null;
                    }
                    int num = 0;
                    while (i + num3 < cglist.Count && cglist[i + num3].Length > 2 && cglist[i + num3][0] == 84 && cglist[i + num3][1] == 32)
                    {
                        try
                        {
                            fixed (byte* ptr = &cglist[i + num3][2])
                            {
                                num3 += Strmake.Strmake_StrToS32(ptr, (byte)(cglist[i + num3].Length - 2)) + 1;
                            }
                        }
                        finally
                        {
                            byte* ptr = null;
                        }
                        num++;
                    }
                    if (num > 0)
                    {
                        cglist[i] = Kuozhan.Gethebingbytes(cglist[i].subbytes(0, 2), (num3 - 1).ToString().GetbytesssASCII());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.Myapp.Addbianyierr(ex.Message);
            result = false;
            return result;
        }
        result = true;
        return result;
    }


    public List<byte[]> Getcodes()
    {
        List<byte[]> lcodes = new List<byte[]>();
        this.Getcodes(ref lcodes);
        return lcodes;
    }

    public void Getcodes(ref List<byte[]> lcodes)
    {
        lcodes.Add("att".GetbytesssASCII());
        foreach (matt matt in this.atts)
        {
            byte[] item = Kuozhan.Gethebingbytes(matt.name, matt.att.structToBytes(), matt.zhi, matt.zhushi);
            lcodes.Add(item);
        }
        lcodes.Add("E".GetbytesssASCII());
        objmark_ k_ = objtype.getobjmark(this.myobj.objType);
        for (int i = 0; i < k_.events.Length; i++)
        {
            lcodes.Add(k_.events[i].eventres.GetbytesssASCII());
            lcodes.AddListBytes(this.Codes[k_.events[i].eventid.Getint()].GetListbytes());
            lcodes.Add("E".GetbytesssASCII());
        }
    }

    public List<byte[]> GetfenleiCodesBytes(List<byte[]> lcodes, string name, string endstr)
    {
        bool flag = false;
        List<byte[]> list = new List<byte[]>();
        foreach (byte[] buffer in lcodes)
        {
            if (flag)
            {
                if ((buffer.Length == endstr.Length) && (buffer.Getstring(datasize.Myencoding) == endstr))
                {
                    return list;
                }
                list.Add(buffer);
            }
            else if ((buffer.Length == name.Length) && (buffer.Getstring(datasize.Myencoding) == name))
            {
                flag = true;
            }
        }
        return list;
    }

    public List<string> GetfenleiCodesString(List<byte[]> lcodes, string name, string endstr)
    {
        bool flag = false;
        List<string> codes = new List<string>();
        foreach (byte[] buffer in lcodes)
        {
            if (flag)
            {
                if ((buffer.Length == endstr.Length) && (buffer.Getstring(datasize.Myencoding) == endstr))
                {
                    return codes;
                }
                string item = buffer.Getstring(datasize.Myencoding);
                codes.Add(item);
            }
            else if ((buffer.Length == name.Length) && (buffer.Getstring(datasize.Myencoding) == name))
            {
                flag = true;
            }
        }
        codes.Codeduiqi();
        return codes;
    }

    public int Gethidecode(ref List<byte[]> ll)
    {
        int num = 0;
        byte[] descode = new byte[0];
        if (this.objid > 0)
        {
            string[] strArray;
            int num4;
            bianyijieguotype bianyijieguotype;
            if (this.Mypage.objs[0].GetattVal_string("sta") == "1")
            {
                strArray = new string[10];
                strArray[0] = "fill ";
                strArray[1] = this.myobj.redian.x.ToString();
                strArray[2] = ",";
                strArray[3] = this.myobj.redian.y.ToString();
                strArray[4] = ",";
                num4 = (this.myobj.redian.endx - this.myobj.redian.x) + 1;
                strArray[5] = num4.ToString();
                strArray[6] = ",";
                num4 = (this.myobj.redian.endy - this.myobj.redian.y) + 1;
                strArray[7] = num4.ToString();
                strArray[8] = ",";
                strArray[9] = this.Mypage.objs[0].GetattVal_string("bco");
                bianyijieguotype = new bianyijieguotype();
                this.bianyionline(string.Concat(strArray), ref descode, "", bianyijieguotype);
                ll.Add(descode);
                num++;
            }
            else if (this.Mypage.objs[0].GetattVal_string("sta") == "2")
            {
                strArray = new string[14];
                strArray[0] = "xpic ";
                strArray[1] = this.myobj.redian.x.ToString();
                strArray[2] = ",";
                strArray[3] = this.myobj.redian.y.ToString();
                strArray[4] = ",";
                num4 = (this.myobj.redian.endx - this.myobj.redian.x) + 1;
                strArray[5] = num4.ToString();
                strArray[6] = ",";
                strArray[7] = ((this.myobj.redian.endy - this.myobj.redian.y) + 1).ToString();
                strArray[8] = ",";
                strArray[9] = this.myobj.redian.x.ToString();
                strArray[10] = ",";
                strArray[11] = this.myobj.redian.y.ToString();
                strArray[12] = ",";
                strArray[13] = this.Mypage.objs[0].GetattVal_string("pic");
                bianyijieguotype = new bianyijieguotype();
                this.bianyionline(string.Concat(strArray), ref descode, "", bianyijieguotype);
                ll.Add(descode);
                num++;
            }
            List<byte> guanlianobjs = this.Mypage.Getguanlianobjs(this.objid);
            if (guanlianobjs.Count <= 0)
            {
                return num;
            }
            for (int i = 0; i < guanlianobjs.Count; i++)
            {
                if (guanlianobjs[i] != this.objid)
                {
                    byte num5 = guanlianobjs[i];
                    bianyijieguotype = new bianyijieguotype();
                    this.bianyionline("ref " + num5.ToString(), ref descode, "", bianyijieguotype);
                    ll.Add(descode);
                    num++;
                }
            }
        }
        return num;
    }

    public Encoding Getobjencodeing(string attname)
    {
        if (attname == "txt")
        {
            int num = 0xff;
            byte[] buffer = this.GetattVal_byte("font");
            if (buffer != null)
            {
                num = buffer[0];
            }
            if ((num < 0xff) && (num < this.Myapp.zimos.Count))
            {
                return Encoding.GetEncoding(this.Myapp.zimos[num].encode.GetencodeName());
            }
        }
        return datasize.Myencoding;
    }

    public ushort GetobjRambytes(ref byte[] lbytes, int beg)
    {
        byte[] bytesssASCII;
        Exception exception;
        int index = beg;
        ushort attpos = this.myobj.attpos;
        ushort num3 = 0;
        if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_SLIDER)
        {
            SLIDER_PARAM structure = new SLIDER_PARAM();
            try
            {
                structure.RefFlag = 0;
                structure.Mode = (byte)this.GetattVal_string("mode").Getint();
                structure.BackType = (byte)this.GetattVal_string("sta").Getint();
                structure.CursorType = (byte)this.GetattVal_string("psta").Getint();
                structure.CursorWid = (byte)this.GetattVal_string("wid").Getint();
                structure.CursorHig = (byte)this.GetattVal_string("hig").Getint();
                if (structure.BackType == 0)
                {
                    structure.BkPicID = (ushort)this.GetattVal_string("picc").Getint();
                }
                else if (structure.BackType == 2)
                {
                    structure.BkPicID = (ushort)this.GetattVal_string("pic").Getint();
                }
                else if (structure.BackType == 1)
                {
                    structure.BkPicID = (ushort)this.GetattVal_string("bco").Getint();
                }
                if (structure.CursorType == 0)
                {
                    structure.CuPicID = (ushort)this.GetattVal_string("pco").Getint();
                }
                else if (structure.CursorType == 1)
                {
                    structure.CuPicID = (ushort)this.GetattVal_string("pic2").Getint();
                }
                structure.MaxVal = (ushort)this.GetattVal_string("maxval").Getint();
                structure.MinVal = (ushort)this.GetattVal_string("minval").Getint();
                structure.NowVal = (ushort)this.GetattVal_string("val").Getint();
                structure.LastVal = 0xffff;
                this.atts[5].att.pos = (ushort)(this.myobj.attpos + 6);
                this.atts[6].att.pos = (ushort)(this.myobj.attpos + 6);
                this.atts[7].att.pos = (ushort)(this.myobj.attpos + 6);
                this.atts[8].att.pos = (ushort)(this.myobj.attpos + 8);
                this.atts[9].att.pos = (ushort)(this.myobj.attpos + 8);
                this.atts[10].att.pos = (ushort)(this.myobj.attpos + 4);
                this.atts[11].att.pos = (ushort)(this.myobj.attpos + 5);
                this.atts[12].att.pos = (ushort)(this.myobj.attpos + 10);
                this.atts[13].att.pos = (ushort)(this.myobj.attpos + 12);
                this.atts[14].att.pos = (ushort)(this.myobj.attpos + 14);
                structure.structToBytes().CopyTo(lbytes, index);
                index += Marshal.SizeOf(new SLIDER_PARAM());
                return (ushort)(index - beg);
            }
            catch (Exception exception1)
            {
                exception = exception1;
                MessageOpen.Show(exception.Message);
                return 0;
            }
        }
        if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_CURVE)
        {
            CURVE_PARAM curve_param = new CURVE_PARAM();
            CURVE_CHANNEL_PARAM curve_channel_param = new CURVE_CHANNEL_PARAM();
            try
            {
                curve_param.BackType = (byte)this.GetattVal_string("sta").Getint();
                if (curve_param.BackType == 0)
                {
                    curve_param.PicID = (ushort)this.GetattVal_string("picc").Getint();
                }
                else if (curve_param.BackType == 2)
                {
                    curve_param.PicID = (ushort)this.GetattVal_string("pic").Getint();
                }
                curve_param.GridX = (byte)this.GetattVal_string("gdw").Getint();
                curve_param.GridY = (byte)this.GetattVal_string("gdh").Getint();
                curve_param.RefFlag = 0;
                curve_param.CH_qyt = (byte)(this.GetattVal_string("ch").Getint() + 1);
                curve_param.objWid = (ushort)((this.myobj.redian.endx - this.myobj.redian.x) + 1);
                curve_param.objHig = (ushort)((this.myobj.redian.endy - this.myobj.redian.y) + 1);
                curve_param.Bkclr = (ushort)this.GetattVal_string("bco").Getint();
                curve_param.Griclr = (ushort)this.GetattVal_string("gdc").Getint();
                curve_param.DrawDir = (byte)this.GetattVal_string("dir").Getint();
                if ((curve_param.objWid * 0.3) > 120.0)
                {
                    num3 = (ushort)(curve_param.objWid + 120);
                }
                else
                {
                    num3 = (ushort)(curve_param.objWid * 1.3);
                }
                this.atts[5].att.pos = (ushort)(this.myobj.attpos + 11);
                this.atts[6].att.pos = (ushort)(this.myobj.attpos + 5);
                this.atts[7].att.pos = (ushort)(this.myobj.attpos + 5);
                this.atts[8].att.pos = (ushort)(this.myobj.attpos + 13);
                this.atts[9].att.pos = (ushort)(this.myobj.attpos + 2);
                this.atts[10].att.pos = (ushort)(this.myobj.attpos + 3);
                curve_param.structToBytes().CopyTo(lbytes, index);
                CURVE_PARAM curve_param2 = new CURVE_PARAM();
                index += Marshal.SizeOf(curve_param2);
                curve_param2 = new CURVE_PARAM();
                CURVE_CHANNEL_PARAM curve_channel_param2 = new CURVE_CHANNEL_PARAM();
                attpos = (ushort)((attpos + Marshal.SizeOf(curve_param2)) + (Marshal.SizeOf(curve_channel_param2) * curve_param.CH_qyt));
                for (int j = 0; j < curve_param.CH_qyt; j++)
                {
                    curve_param2 = new CURVE_PARAM();
                    curve_channel_param2 = new CURVE_CHANNEL_PARAM();
                    this.atts[11 + j].att.pos = (ushort)(((this.myobj.attpos + Marshal.SizeOf(curve_param2)) + (Marshal.SizeOf(curve_channel_param2) * j)) + 4);
                    curve_channel_param = new CURVE_CHANNEL_PARAM();
                    curve_channel_param.BufPos.star = (ushort)(attpos + (j * num3));
                    curve_channel_param.BufPos.end = (ushort)((curve_channel_param.BufPos.star + num3) - 1);
                    switch (j)
                    {
                        case 0:
                            curve_channel_param.Penclr = (ushort)this.GetattVal_string("pco0").Getint();
                            break;

                        case 1:
                            curve_channel_param.Penclr = (ushort)this.GetattVal_string("pco1").Getint();
                            break;

                        case 2:
                            curve_channel_param.Penclr = (ushort)this.GetattVal_string("pco2").Getint();
                            break;

                        case 3:
                            curve_channel_param.Penclr = (ushort)this.GetattVal_string("pco3").Getint();
                            break;
                    }
                    curve_channel_param.res0 = (ushort)(num3 - 1);
                    curve_channel_param.BufNext = curve_channel_param.BufPos.star;
                    curve_channel_param.DotLen = 0;
                    curve_channel_param.structToBytes().CopyTo(lbytes, index);
                    curve_channel_param2 = new CURVE_CHANNEL_PARAM();
                    index += Marshal.SizeOf(curve_channel_param2);
                }
                bytesssASCII = new byte[num3 * curve_param.CH_qyt];
                bytesssASCII.CopyTo(lbytes, index);
                index += bytesssASCII.Length;
                return (ushort)(index - beg);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                MessageOpen.Show(exception.Message);
                return 0;
            }
        }
        for (int i = 0; i < this.atts.Count; i++)
        {
            if ((this.atts[i].att.isxiugai == 1) && this.checkatt(this.atts[i]))
            {
                if (this.atts[i].att.attlei == attshulei.Sstr.typevalue)
                {
                    if ((this.atts[i].zhi.Length == 0) || (this.atts[i].zhi[this.atts[i].zhi.Length - 1] != 0))
                    {
                        Kuozhan.Gethebingbytes(this.atts[i].zhi, "".GetbytesssASCII(1));
                    }
                    if (this.atts[i].zhi.Length > this.atts[i].att.merrylenth)
                    {
                        MessageOpen.Show("属性".Language() + this.atts[i].name.Getstring(datasize.Myencoding) + "初始值大于分配空间".Language());
                        return 0;
                    }
                    this.atts[i].zhi.CopyTo(lbytes, index);
                    index += this.atts[i].zhi.Length;
                    bytesssASCII = "".GetbytesssASCII(this.atts[i].att.merrylenth - this.atts[i].zhi.Length);
                    bytesssASCII.CopyTo(lbytes, index);
                    index += bytesssASCII.Length;
                }
                else
                {
                    if (this.atts[i].zhi.Length != this.atts[i].att.merrylenth)
                    {
                        MessageOpen.Show("属性".Language() + this.atts[i].name.Getstring(datasize.Myencoding) + "初始值大于分配空间".Language());
                        return 0;
                    }
                    this.atts[i].zhi.CopyTo(lbytes, index);
                    index += this.atts[i].zhi.Length;
                }
                this.atts[i].att.pos = attpos;
                attpos = (ushort)(attpos + this.atts[i].att.merrylenth);
            }
        }
        return (ushort)(index - beg);
    }

    private byte getpanduan(string str, ref PosLaction fengge)
    {
        ushort num = (ushort)Kuozhan.findguanjianstr(str, ">=");
        if (num < 0xffff)
        {
            fengge.star = num;
            fengge.end = (ushort)(num + 1);
            return 5;
        }
        num = (ushort)Kuozhan.findguanjianstr(str, "<=");
        if (num < 0xffff)
        {
            fengge.star = num;
            fengge.end = (ushort)(num + 1);
            return 4;
        }
        num = (ushort)Kuozhan.findguanjianstr(str, "==");
        if (num < 0xffff)
        {
            fengge.star = num;
            fengge.end = (ushort)(num + 1);
            return 1;
        }
        num = (ushort)Kuozhan.findguanjianstr(str, "!=");
        if (num < 0xffff)
        {
            fengge.star = num;
            fengge.end = (ushort)(num + 1);
            return 6;
        }
        num = (ushort)Kuozhan.findguanjianstr(str, ">");
        if (num < 0xffff)
        {
            fengge.star = num;
            fengge.end = num;
            return 3;
        }
        num = (ushort)Kuozhan.findguanjianstr(str, "<");
        if (num < 0xffff)
        {
            fengge.star = num;
            fengge.end = num;
            return 2;
        }
        return 0;
    }

    public int Getshutxt_merrylenth(string name, bool islenbiao)
    {
        PosLaction bufpos = new PosLaction
        {
            star = 0,
            end = 7
        };
        matt matt = new matt();
        if (islenbiao)
        {
            string[] strArray = name.Split(new char[] { '_' });
            if (strArray.Length != 2)
            {
                return 0;
            }
            name = strArray[0];
        }
        for (int i = 0; i < this.atts.Count; i++)
        {
            int num2 = Strmake.Strmake_StrSubstring(ref this.atts[i].name, ref bufpos, name, 0);
            if (((num2 != 0xffff) && ((num2 == 7) || (this.atts[i].name[num2 + 1] == 0))) && (this.atts[i].att.attlei == attshulei.Sstr.typevalue))
            {
                return this.atts[i].att.merrylenth;
            }
        }
        return 0;
    }

    private void getstylecode(ref List<string>[] zhiling, string indexstr, string style)
    {
        if ((style != null) && !(style == ""))
        {
            string[] strArray = indexstr.Split(new char[] { '-' });
            foreach (string str2 in strArray)
            {
                string item = "";
                int @int = str2.Getint();
                if (@int < zhiling.Length)
                {
                    if (style == "1")
                    {
                        item = "draw3d '&x&','&y&','&endx&','&endy&','&borderc&','&borderc&','&borderw&'";
                    }
                    else if (style == "2")
                    {
                        item = "draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color1 + "," + this.d3color0 + ",1";
                    }
                    else if (style == "3")
                    {
                        item = "draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color0 + "," + this.d3color1 + ",1";
                    }
                    else if (style == "4")
                    {
                        if (@int == 4)
                        {
                            item = "draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color1 + "," + this.d3color0 + ",1";
                        }
                        else if (@int == 6)
                        {
                            item = "draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color0 + "," + this.d3color1 + ",1";
                        }
                        else
                        {
                            item = "draw3d '&x&','&y&','&endx&','&endy&'," + this.d3color0 + "," + this.d3color1 + ",1";
                        }
                    }
                    if (item != "")
                    {
                        zhiling[@int].Add(item);
                    }
                }
            }
        }
    }

    public void Putcodes(List<byte[]> lbt, string endstr, byte filever)
    {
        try
        {
            List<byte[]> list = this.GetfenleiCodesBytes(lbt, "att", endstr);
            attinf_Up structure = new attinf_Up();
            int qyt = Marshal.SizeOf(structure);
            this.atts.Clear();
            this.isbangding = 0;
            byte[] buffer2 = new byte[0];
            foreach (byte[] buffer3 in list)
            {
                buffer2 = buffer3;
                if ((buffer2.Length > 8) && (buffer2.Length < 0x400))
                {
                    matt item = new matt
                    {
                        name = buffer2.subbytes(0, 8)
                    };
                    if (item.name[3] == 0x2d)
                    {
                        item.name[3] = 0x5f;
                    }
                    if (((filever < 9) && (this.atts.Count == 0)) && (item.name.Getstring(datasize.Myencoding) == "lei"))
                    {
                        item.name = "type".GetbytesssASCII(8);
                    }
                    if (filever < 8)
                    {
                        string str = item.name.Getstring(datasize.Myencoding);
                        buffer2 = Kuozhan.Gethebingbytes(buffer2.subbytes(0, (8 + qyt) - 1), new byte[1], buffer2.subbytes((8 + qyt) - 1, buffer2.Length - ((8 + qyt) - 1)));
                        if ((str == "type") || ((str.Length > 3) && str.Contains("vvs")))
                        {
                            buffer2[(8 + qyt) - 1] = 0;
                        }
                        else
                        {
                            buffer2[(8 + qyt) - 1] = 1;
                        }
                    }
                    byte[] bytes = buffer2.subbytes(8, qyt);
                    structure = new attinf_Up();
                    item.att = (attinf_Up)bytes.BytesTostruct(structure.GetType());
                    if (buffer2.Length >= ((qyt + 8) + item.att.zhanyonglenth))
                    {
                        item.zhi = buffer2.subbytes(qyt + 8, item.att.zhanyonglenth);
                        item.zhushi = buffer2.subbytes((qyt + 8) + item.att.zhanyonglenth);
                        if (item.att.attlei == attshulei.Sstr.typevalue)
                        {
                            if ((item.zhi.Length == 0) || (item.zhi[item.zhi.Length - 1] != 0))
                            {
                                item.zhi = Kuozhan.Gethebingbytes(item.zhi, "".GetbytesssASCII(1));
                            }
                            item.att.zhanyonglenth = (ushort)item.zhi.Length;
                            if (item.att.zhanyonglenth > item.att.merrylenth)
                            {
                                item.att.merrylenth = item.att.zhanyonglenth;
                            }
                        }
                        this.atts.Add(item);
                        this.checkatt(item);
                    }
                }
            }
            objattcaozuo.checkattline(ref this.atts);
        }
        catch (Exception exception)
        {
            MessageOpen.Show("设置控件属性出现错误".Language() + exception.Message);
        }
        this.Codes[0] = this.GetfenleiCodesString(lbt, "ref", endstr);
        this.Codes[1] = this.GetfenleiCodesString(lbt, "chang", endstr);
        this.Codes[2] = this.GetfenleiCodesString(lbt, "load", endstr);
        this.Codes[3] = this.GetfenleiCodesString(lbt, "loadend", endstr);
        this.Codes[4] = this.GetfenleiCodesString(lbt, "down", endstr);
        this.Codes[5] = this.GetfenleiCodesString(lbt, "res0", endstr);
        this.Codes[6] = this.GetfenleiCodesString(lbt, "up", endstr);
        this.Codes[7] = this.GetfenleiCodesString(lbt, "slide", endstr);
    }

    private void sendbianyierror(string error, string code, bianyijieguotype by)
    {
        this.Myapp.Addbianyierr(error + ":" + code + "(双击此处定位代码)".Language(), by);
    }

    private void sendbianyijinggao(string error, string code, bianyijieguotype by)
    {
        this.Myapp.Addbianyijinggao(error + ":" + code + "(双击此处定位代码)".Language(), by);
    }

    public bool Setattval(string name, string newstr)
    {
        matt att = this.Getatt(name);
        if (att == null)
        {
            return false;
        }
        if (name == "objname")
        {
            return this.Myapp.renameobj(this.Mypage, this, newstr);
        }
        if (objtype.getobjmark(this.myobj.objType).show > 0)
        {
            int num3 = 0;
            string str = name;
            if (str != null)
            {
                int @int;
                if (!(str == "x"))
                {
                    if (str == "y")
                    {
                        if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                        {
                            return false;
                        }
                        @int = newstr.Getint();
                        num3 = (this.myobj.redian.endy - this.myobj.redian.y) + 1;
                        if ((@int + num3) > this.Myapp.lcdheight)
                        {
                            MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                            return false;
                        }
                        this.myobj.redian.y = (ushort)@int;
                        this.myobj.redian.endy = (ushort)((this.myobj.redian.y + num3) - 1);
                        return true;
                    }
                    if (str == "w")
                    {
                        if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                        {
                            return false;
                        }
                        @int = newstr.Getint();
                        if ((@int + this.myobj.redian.x) > this.Myapp.lcdwidth)
                        {
                            MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                            return false;
                        }
                        if ((objtype.getobjmark(this.myobj.objType).byx == 1) && ((@int + this.myobj.redian.y) > this.Myapp.lcdheight))
                        {
                            MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                            return false;
                        }
                        if (@int < 2)
                        {
                            MessageOpen.Show("宽度最小值为2".Language());
                            return false;
                        }
                        this.myobj.redian.endx = (ushort)((this.myobj.redian.x + @int) - 1);
                        if (objtype.getobjmark(this.myobj.objType).byx == 1)
                        {
                            this.myobj.redian.endy = (ushort)((this.myobj.redian.y + @int) - 1);
                        }
                        if (this.myobj.objType == objtype.OBJECT_TYPE_SLIDER)
                        {
                            att = this.Getatt("wid");
                            if (att != null)
                            {
                                att.att.maxval = @int;
                            }
                        }
                        return true;
                    }
                    if (str == "h")
                    {
                        if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                        {
                            return false;
                        }
                        @int = newstr.Getint();
                        if ((@int + this.myobj.redian.y) > this.Myapp.lcdheight)
                        {
                            MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                            return false;
                        }
                        if ((objtype.getobjmark(this.myobj.objType).byx == 1) && ((@int + this.myobj.redian.x) > this.Myapp.lcdwidth))
                        {
                            MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                            return false;
                        }
                        if (@int < 2)
                        {
                            MessageOpen.Show("高度最小值为2".Language());
                            return false;
                        }
                        this.myobj.redian.endy = (ushort)((this.myobj.redian.y + @int) - 1);
                        if (objtype.getobjmark(this.myobj.objType).byx == 1)
                        {
                            this.myobj.redian.endx = (ushort)((this.myobj.redian.x + @int) - 1);
                        }
                        if (this.myobj.objType == objtype.OBJECT_TYPE_SLIDER)
                        {
                            att = this.Getatt("hig");
                            if (att != null)
                            {
                                att.att.maxval = @int;
                            }
                        }
                        return true;
                    }
                }
                else
                {
                    if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                    {
                        return false;
                    }
                    @int = newstr.Getint();
                    num3 = (this.myobj.redian.endx - this.myobj.redian.x) + 1;
                    if ((@int + num3) > this.Myapp.lcdwidth)
                    {
                        MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                        return false;
                    }
                    this.myobj.redian.x = (ushort)@int;
                    this.myobj.redian.endx = (ushort)((this.myobj.redian.x + num3) - 1);
                    return true;
                }
            }
        }
        if (att.att.attlei == attshulei.Sstr.typevalue)
        {
            byte[] bytes = this.Getobjencodeing(name).GetBytes(newstr);
            if (bytes.Length >= att.att.merrylenth)
            {
                MessageOpen.Show("字符数量超过最大值".Language());
                return false;
            }
            att.zhi = Kuozhan.Gethebingbytes(bytes, new byte[1]);
            att.att.zhanyonglenth = (ushort)att.zhi.Length;
        }
        else
        {
            byte num2 = (byte)(att.att.attlei & 15);
            if (!newstr.IsdataS32(att.att.attlei))
            {
                return false;
            }
            int newval = newstr.Getint();
            if ((newval > att.att.maxval) || (newval < att.att.minval))
            {
                return false;
            }
            if (att.att.merrylenth == 1)
            {
                if (newval > 0xff)
                {
                    return false;
                }
                if (att.zhi.Length != 1)
                {
                    att.zhi = new byte[1];
                }
                att.zhi[0] = (byte)newval;
                if (att.att.attlei == attshulei.Strlenth.typevalue)
                {
                    string[] strArray = name.Split(new char[] { '_' });
                    if (strArray.Length == 2)
                    {
                        return this.Setshutxtlenth(strArray[0], newval);
                    }
                }
                if (att.att.attlei == attshulei.Select.typevalue)
                {
                    this.isbangding = 0;
                    foreach (matt matt2 in this.atts)
                    {
                        if ((matt2.att.isbangding == 1) && this.checkatt(matt2))
                        {
                            this.isbangding = 1;
                            break;
                        }
                    }
                }
            }
            else if (att.att.merrylenth == 2)
            {
                if (num2 == attshulei.UU16.typevalue)
                {
                    att.zhi = ((ushort)newval).structToBytes();
                }
                else
                {
                    att.zhi = ((short)newval).structToBytes();
                }
            }
            else if (att.att.merrylenth == 4)
            {
                att.zhi = newval.structToBytes();
            }
        }
        return true;
    }

    public void Setscreenxy()
    {
        if (this.objid == 0)
        {
            this.myobj.redian.x = 0;
            this.myobj.redian.y = 0;
            this.myobj.redian.endx = (ushort)(this.Myapp.lcdwidth - 1);
            this.myobj.redian.endy = (ushort)(this.Myapp.lcdheight - 1);
            if ((this.objid == 0) && (this.atts.Count < 1))
            {
                this.atts = objattcaozuo.Getmatts(objtype.page, ref this.myobj.redian);
            }
        }
    }

    public bool Setshutxtlenth(string name, int newval)
    {
        PosLaction bufpos = new PosLaction
        {
            star = 0,
            end = 7
        };
        matt matt = new matt();
        if (newval > 0xff)
        {
            MessageOpen.Show("字符串长度最长不能超过255字节".Language());
            return false;
        }
        for (int i = 0; i < this.atts.Count; i++)
        {
            int num2 = Strmake.Strmake_StrSubstring(ref this.atts[i].name, ref bufpos, name, 0);
            if (((num2 != 0xffff) && ((num2 == 7) || (this.atts[i].name[num2 + 1] == 0))) && (this.atts[i].att.attlei == attshulei.Sstr.typevalue))
            {
                if (this.atts[i].zhi.Length <= (newval + 1))
                {
                    this.atts[i].att.merrylenth = (ushort)(newval + 1);
                    return true;
                }
                MessageOpen.Show("设定长度小于当前字符串的默认初始长度,请先调整当前字符串的默认初始值".Language());
                return false;
            }
        }
        return false;
    }

    private byte[] tihianhex(byte[] descode, List<hexreplace_type> hexrepalce)
    {
        byte[] array = new byte[0x400];
        int index = 0;
        int num2 = 0;
        while (hexrepalce.Count > 0)
        {
            while (num2 < hexrepalce[0].beg)
            {
                array[index] = descode[num2];
                index++;
                num2++;
            }
            hexrepalce[0].bytes.CopyTo(array, index);
            index += hexrepalce[0].bytes.Length;
            num2 += hexrepalce[0].qyt;
            hexrepalce.Remove(hexrepalce[0]);
        }
        while (num2 < descode.Length)
        {
            array[index] = descode[num2];
            index++;
            num2++;
        }
        return array.subbytes(0, index);
    }
}



