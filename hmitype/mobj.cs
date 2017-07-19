using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace hmitype
{
    public class mobj
    {
        private string d3color0 = "59164";

        private string d3color1 = "16936";

        public Myapp_inf Myapp;

        public mpage Mypage;

        public int objid;

        public string objname = "";

        public objxinxi myobj;

        public List<string>[] Codes = new List<string>[8];

        public byte[] attstrpianyi = new byte[180];

        public List<matt> atts = new List<matt>();

        public byte isbangding = 0;

        public void Setscreenxy()
        {
            if (this.objid == 0)
            {
                this.myobj.redian.x = 0;
                this.myobj.redian.y = 0;
                this.myobj.redian.endx = (ushort)(this.Myapp.lcdwidth - 1);
                this.myobj.redian.endy = (ushort)(this.Myapp.lcdheight - 1);
                if (this.objid == 0 && this.atts.Count < 1)
                {
                    this.atts = objattcaozuo.Getmatts(objtype.page, ref this.myobj.redian);
                }
            }
        }

        public mobj copyobj()
        {
            mobj mobj = new mobj(this.Myapp, this.Mypage);
            mobj.objname = this.objname;
            mobj.myobj = this.myobj;
            mobj.Putcodes(this.Getcodes(), "E", datasize.filever);
            return mobj;
        }

        public bool Setshutxtlenth(string name, int newval)
        {
            PosLaction posLaction = default(PosLaction);
            posLaction.star = 0;
            posLaction.end = 7;
            matt matt = new matt();
            bool result;
            if (newval > 255)
            {
                MessageOpen.Show("字符串长度最长不能超过255字节".Language());
                result = false;
            }
            else
            {
                for (int i = 0; i < this.atts.Count; i++)
                {
                    int num = (int)Strmake.Strmake_StrSubstring(ref this.atts[i].name, ref posLaction, name, 0);
                    if (num != 65535)
                    {
                        if (num == 7 || this.atts[i].name[num + 1] == 0)
                        {
                            if (this.atts[i].att.attlei == attshulei.Sstr.typevalue)
                            {
                                if (this.atts[i].zhi.Length <= newval + 1)
                                {
                                    this.atts[i].att.merrylenth = (ushort)(newval + 1);
                                    result = true;
                                    return result;
                                }
                                MessageOpen.Show("设定长度小于当前字符串的默认初始长度,请先调整当前字符串的默认初始值".Language());
                                result = false;
                                return result;
                            }
                        }
                    }
                }
                result = false;
            }
            return result;
        }

        public int Getshutxt_merrylenth(string name, bool islenbiao)
        {
            PosLaction posLaction = default(PosLaction);
            posLaction.star = 0;
            posLaction.end = 7;
            matt matt = new matt();
            int result;
            if (islenbiao)
            {
                string[] array = name.Split(new char[]
                {
                    '_'
                });
                if (array.Length != 2)
                {
                    result = 0;
                    return result;
                }
                name = array[0];
            }
            for (int i = 0; i < this.atts.Count; i++)
            {
                int num = (int)Strmake.Strmake_StrSubstring(ref this.atts[i].name, ref posLaction, name, 0);
                if (num != 65535)
                {
                    if (num == 7 || this.atts[i].name[num + 1] == 0)
                    {
                        if (this.atts[i].att.attlei == attshulei.Sstr.typevalue)
                        {
                            result = (int)this.atts[i].att.merrylenth;
                            return result;
                        }
                    }
                }
            }
            result = 0;
            return result;
        }

        public bool Dellatt(string name)
        {
            PosLaction posLaction = default(PosLaction);
            posLaction.star = 0;
            posLaction.end = 7;
            bool result;
            for (int i = 0; i < this.atts.Count; i++)
            {
                int num = (int)Strmake.Strmake_StrSubstring(ref this.atts[i].name, ref posLaction, name, 0);
                if (num != 65535)
                {
                    if (num == 7 || this.atts[i].name[num + 1] == 0)
                    {
                        this.atts.RemoveAt(i);
                        result = true;
                        return result;
                    }
                }
            }
            result = false;
            return result;
        }

        public Encoding Getobjencodeing(string attname)
        {
            Encoding result;
            if (attname != "txt")
            {
                result = datasize.Myencoding;
            }
            else
            {
                int num = 255;
                byte[] array = this.GetattVal_byte("font");
                if (array != null)
                {
                    num = (int)array[0];
                }
                if (num < 255 && num < this.Myapp.zimos.Count)
                {
                    result = Encoding.GetEncoding(this.Myapp.zimos[num].encode.GetencodeName());
                }
                else
                {
                    result = datasize.Myencoding;
                }
            }
            return result;
        }

        public byte[] GetattVal_byte(string name)
        {
            matt matt = this.Getatt(name);
            byte[] result;
            if (matt == null)
            {
                result = null;
            }
            else
            {
                byte[] array = new byte[matt.zhi.Length];
                matt.zhi.CopyTo(array, 0);
                result = array;
            }
            return result;
        }

        public string GetattVal_string(string name)
        {
            matt matt = this.Getatt(name);
            string result;
            if (matt == null)
            {
                result = null;
            }
            else if (matt.att.attlei == attshulei.Sstr.typevalue)
            {
                Encoding encoding = this.Getobjencodeing(name);
                result = encoding.GetString(matt.zhi);
            }
            else if (matt.att.merrylenth == 1)
            {
                result = matt.zhi[0].ToString();
            }
            else if (matt.att.merrylenth == 2)
            {
                if ((matt.att.attlei & 15) == attshulei.UU16.typevalue)
                {
                    result = ((ushort)matt.zhi.BytesTostruct(0.GetType())).ToString();
                }
                else
                {
                    result = ((short)matt.zhi.BytesTostruct(0.GetType())).ToString();
                }
            }
            else if (matt.att.merrylenth == 4)
            {
                result = ((int)matt.zhi.BytesTostruct(0.GetType())).ToString();
            }
            else
            {
                result = null;
            }
            return result;
        }

        public matt Getatt(string name)
        {
            PosLaction posLaction = default(PosLaction);
            byte[] b = name.GetbytesssASCII(8);
            posLaction.star = 0;
            posLaction.end = 7;
            matt result;
            for (int i = 0; i < this.atts.Count; i++)
            {
                if (Kuozhan.makebytes(this.atts[i].name, b))
                {
                    if (this.checkatt(this.atts[i]))
                    {
                        result = this.atts[i];
                        return result;
                    }
                }
            }
            if (name == "id")
            {
                matt matt = new matt();
                matt.name = "id".GetbytesssASCII(8);
                matt.zhi = ((byte)this.objid).structToBytes();
                matt.zhushi = datasize.Objzhushiencoding.GetBytes("控件ID".Language());
                matt.att.isxiugai = 0;
                matt.att.chonghui = 255;
                matt.att.merrylenth = (ushort)matt.zhi.Length;
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.UU8.typevalue;
                matt.att.datafrom = 255;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                result = matt;
                return result;
            }
            if (name == "objname")
            {
                matt matt = new matt();
                matt.name = "objname".GetbytesssASCII(8);
                matt.zhi = this.objname.GetbytesssASCII(14);
                matt.zhushi = datasize.Objzhushiencoding.GetBytes("控件名称".Language());
                matt.att.isxiugai = 0;
                matt.att.chonghui = 255;
                matt.att.merrylenth = (ushort)(matt.zhi.Length + 1);
                matt.att.zhanyonglenth = matt.att.merrylenth;
                matt.att.attlei = attshulei.Sstr.typevalue;
                matt.att.datafrom = 255;
                matt.att.maxval = 0;
                matt.att.minval = 0;
                matt.att.pos = 0;
                matt.att.isbangding = 0;
                result = matt;
                return result;
            }
            if (objtype.getobjmark(this.myobj.objType).show > 0)
            {
                if (name == "x")
                {
                    matt matt = new matt();
                    matt.name = "x".GetbytesssASCII(8);
                    matt.zhi = this.myobj.redian.x.structToBytes();
                    matt.zhushi = datasize.Objzhushiencoding.GetBytes("X坐标".Language());
                    matt.att.isxiugai = 0;
                    matt.att.chonghui = 255;
                    matt.att.merrylenth = (ushort)matt.zhi.Length;
                    matt.att.zhanyonglenth = matt.att.merrylenth;
                    matt.att.attlei = attshulei.UU16.typevalue;
                    matt.att.datafrom = 255;
                    matt.att.maxval = 0;
                    matt.att.minval = 0;
                    matt.att.pos = 0;
                    matt.att.isbangding = 0;
                    result = matt;
                    return result;
                }
                if (name == "y")
                {
                    matt matt = new matt();
                    matt.name = "y".GetbytesssASCII(8);
                    matt.zhi = this.myobj.redian.y.structToBytes();
                    matt.zhushi = datasize.Objzhushiencoding.GetBytes("Y坐标".Language());
                    matt.att.isxiugai = 0;
                    matt.att.chonghui = 255;
                    matt.att.merrylenth = (ushort)matt.zhi.Length;
                    matt.att.zhanyonglenth = matt.att.merrylenth;
                    matt.att.attlei = attshulei.UU16.typevalue;
                    matt.att.datafrom = 255;
                    matt.att.maxval = 0;
                    matt.att.minval = 0;
                    matt.att.pos = 0;
                    matt.att.isbangding = 0;
                    result = matt;
                    return result;
                }
                if (name == "w")
                {
                    matt matt = new matt();
                    matt.name = "w".GetbytesssASCII(8);
                    matt.zhi = (this.myobj.redian.endx - this.myobj.redian.x + 1).structToBytes();
                    matt.zhushi = datasize.Objzhushiencoding.GetBytes("宽度".Language());
                    matt.att.isxiugai = 0;
                    matt.att.chonghui = 255;
                    matt.att.merrylenth = (ushort)matt.zhi.Length;
                    matt.att.zhanyonglenth = matt.att.merrylenth;
                    matt.att.attlei = attshulei.UU16.typevalue;
                    matt.att.datafrom = 255;
                    matt.att.maxval = 0;
                    matt.att.minval = 0;
                    matt.att.pos = 0;
                    matt.att.isbangding = 0;
                    result = matt;
                    return result;
                }
                if (name == "h")
                {
                    matt matt = new matt();
                    matt.name = "h".GetbytesssASCII(8);
                    matt.zhi = (this.myobj.redian.endy - this.myobj.redian.y + 1).structToBytes();
                    matt.zhushi = datasize.Objzhushiencoding.GetBytes("高度".Language());
                    matt.att.isxiugai = 0;
                    matt.att.chonghui = 255;
                    matt.att.merrylenth = (ushort)matt.zhi.Length;
                    matt.att.zhanyonglenth = matt.att.merrylenth;
                    matt.att.attlei = attshulei.UU16.typevalue;
                    matt.att.datafrom = 255;
                    matt.att.maxval = 0;
                    matt.att.minval = 0;
                    matt.att.pos = 0;
                    matt.att.isbangding = 0;
                    result = matt;
                    return result;
                }
                if (name == "endx")
                {
                    matt matt = new matt();
                    matt.name = "endx".GetbytesssASCII(8);
                    matt.zhi = this.myobj.redian.endx.structToBytes();
                    matt.zhushi = datasize.Objzhushiencoding.GetBytes("endx".Language());
                    matt.att.isxiugai = 0;
                    matt.att.chonghui = 255;
                    matt.att.merrylenth = (ushort)matt.zhi.Length;
                    matt.att.zhanyonglenth = matt.att.merrylenth;
                    matt.att.attlei = attshulei.UU16.typevalue;
                    matt.att.datafrom = 255;
                    matt.att.maxval = 0;
                    matt.att.minval = 0;
                    matt.att.pos = 0;
                    matt.att.isbangding = 0;
                    result = matt;
                    return result;
                }
                if (name == "endy")
                {
                    matt matt = new matt();
                    matt.name = "endy".GetbytesssASCII(8);
                    matt.zhi = this.myobj.redian.endy.structToBytes();
                    matt.zhushi = datasize.Objzhushiencoding.GetBytes("endy".Language());
                    matt.att.isxiugai = 0;
                    matt.att.chonghui = 255;
                    matt.att.merrylenth = (ushort)matt.zhi.Length;
                    matt.att.zhanyonglenth = matt.att.merrylenth;
                    matt.att.attlei = attshulei.UU16.typevalue;
                    matt.att.datafrom = 255;
                    matt.att.maxval = 0;
                    matt.att.minval = 0;
                    matt.att.pos = 0;
                    matt.att.isbangding = 0;
                    result = matt;
                    return result;
                }
            }
            result = null;
            return result;
        }

        public bool Setattval(string name, string newstr)
        {
            matt matt = this.Getatt(name);
            bool result;
            if (matt == null)
            {
                result = false;
            }
            else if (name == "objname")
            {
                result = this.Myapp.renameobj(this.Mypage, this, newstr);
            }
            else
            {
                if (objtype.getobjmark(this.myobj.objType).show > 0)
                {
                    if (name != null)
                    {
                        if (!(name == "x"))
                        {
                            if (!(name == "y"))
                            {
                                if (!(name == "w"))
                                {
                                    if (name == "h")
                                    {
                                        if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                                        {
                                            result = false;
                                            return result;
                                        }
                                        int num = newstr.Getint();
                                        if (num + (int)this.myobj.redian.y > (int)this.Myapp.lcdheight)
                                        {
                                            MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                                            result = false;
                                            return result;
                                        }
                                        if (objtype.getobjmark(this.myobj.objType).byx == 1)
                                        {
                                            if (num + (int)this.myobj.redian.x > (int)this.Myapp.lcdwidth)
                                            {
                                                MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                                                result = false;
                                                return result;
                                            }
                                        }
                                        if (num < 2)
                                        {
                                            MessageOpen.Show("高度最小值为2".Language());
                                            result = false;
                                            return result;
                                        }
                                        this.myobj.redian.endy = (ushort)((int)this.myobj.redian.y + num - 1);
                                        if (objtype.getobjmark(this.myobj.objType).byx == 1)
                                        {
                                            this.myobj.redian.endx = (ushort)((int)this.myobj.redian.x + num - 1);
                                        }
                                        if (this.myobj.objType == objtype.OBJECT_TYPE_SLIDER)
                                        {
                                            matt = this.Getatt("hig");
                                            if (matt != null)
                                            {
                                                matt.att.maxval = num;
                                            }
                                        }
                                        result = true;
                                        return result;
                                    }
                                }
                                else
                                {
                                    if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                                    {
                                        result = false;
                                        return result;
                                    }
                                    int num = newstr.Getint();
                                    if (num + (int)this.myobj.redian.x > (int)this.Myapp.lcdwidth)
                                    {
                                        MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                                        result = false;
                                        return result;
                                    }
                                    if (objtype.getobjmark(this.myobj.objType).byx == 1)
                                    {
                                        if (num + (int)this.myobj.redian.y > (int)this.Myapp.lcdheight)
                                        {
                                            MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                                            result = false;
                                            return result;
                                        }
                                    }
                                    if (num < 2)
                                    {
                                        MessageOpen.Show("宽度最小值为2".Language());
                                        result = false;
                                        return result;
                                    }
                                    this.myobj.redian.endx = (ushort)((int)this.myobj.redian.x + num - 1);
                                    if (objtype.getobjmark(this.myobj.objType).byx == 1)
                                    {
                                        this.myobj.redian.endy = (ushort)((int)this.myobj.redian.y + num - 1);
                                    }
                                    if (this.myobj.objType == objtype.OBJECT_TYPE_SLIDER)
                                    {
                                        matt = this.Getatt("wid");
                                        if (matt != null)
                                        {
                                            matt.att.maxval = num;
                                        }
                                    }
                                    result = true;
                                    return result;
                                }
                            }
                            else
                            {
                                if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                                {
                                    result = false;
                                    return result;
                                }
                                int num = newstr.Getint();
                                int num2 = (int)(this.myobj.redian.endy - this.myobj.redian.y + 1);
                                if (num + num2 > (int)this.Myapp.lcdheight)
                                {
                                    MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                                    result = false;
                                    return result;
                                }
                                this.myobj.redian.y = (ushort)num;
                                this.myobj.redian.endy = (ushort)((int)this.myobj.redian.y + num2 - 1);
                                result = true;
                                return result;
                            }
                        }
                        else
                        {
                            if (!newstr.IsdataS32(attshulei.UU16.typevalue))
                            {
                                result = false;
                                return result;
                            }
                            int num = newstr.Getint();
                            int num2 = (int)(this.myobj.redian.endx - this.myobj.redian.x + 1);
                            if (num + num2 > (int)this.Myapp.lcdwidth)
                            {
                                MessageOpen.Show("新的外观边界超出显示区域范围,设置取消".Language());
                                result = false;
                                return result;
                            }
                            this.myobj.redian.x = (ushort)num;
                            this.myobj.redian.endx = (ushort)((int)this.myobj.redian.x + num2 - 1);
                            result = true;
                            return result;
                        }
                    }
                }
                if (matt.att.attlei == attshulei.Sstr.typevalue)
                {
                    Encoding encoding = this.Getobjencodeing(name);
                    byte[] bytes = encoding.GetBytes(newstr);
                    if (bytes.Length >= (int)matt.att.merrylenth)
                    {
                        MessageOpen.Show("字符数量超过最大值".Language());
                        result = false;
                        return result;
                    }
                    matt arg_602_0 = matt;
                    byte[] arg_5FD_0 = bytes;
                    byte[] bytes2 = new byte[1];
                    arg_602_0.zhi = Kuozhan.Gethebingbytes(arg_5FD_0, bytes2);
                    matt.att.zhanyonglenth = (ushort)matt.zhi.Length;
                }
                else
                {
                    byte b = Convert.ToByte(matt.att.attlei & 15);
                    if (!newstr.IsdataS32(matt.att.attlei))
                    {
                        result = false;
                        return result;
                    }
                    int num3 = newstr.Getint();
                    if (num3 > matt.att.maxval || num3 < matt.att.minval)
                    {
                        result = false;
                        return result;
                    }
                    if (matt.att.merrylenth == 1)
                    {
                        if (num3 > 255)
                        {
                            result = false;
                            return result;
                        }
                        if (matt.zhi.Length != 1)
                        {
                            matt.zhi = new byte[1];
                        }
                        matt.zhi[0] = (byte)num3;
                        if (matt.att.attlei == attshulei.Strlenth.typevalue)
                        {
                            string[] array = name.Split(new char[]
                            {
                                '_'
                            });
                            if (array.Length == 2)
                            {
                                result = this.Setshutxtlenth(array[0], num3);
                                return result;
                            }
                        }
                        if (matt.att.attlei == attshulei.Select.typevalue)
                        {
                            this.isbangding = 0;
                            foreach (matt current in this.atts)
                            {
                                if (current.att.isbangding == 1 && this.checkatt(current))
                                {
                                    this.isbangding = 1;
                                    break;
                                }
                            }
                        }
                    }
                    else if (matt.att.merrylenth == 2)
                    {
                        if (b == attshulei.UU16.typevalue)
                        {
                            matt.zhi = ((ushort)num3).structToBytes();
                        }
                        else
                        {
                            matt.zhi = ((short)num3).structToBytes();
                        }
                    }
                    else if (matt.att.merrylenth == 4)
                    {
                        matt.zhi = num3.structToBytes();
                    }
                }
                result = true;
            }
            return result;
        }

        public List<matt> GetAllatts()
        {
            List<matt> list = new List<matt>();
            matt matt = new matt();
            matt.name = "id".GetbytesssASCII();
            matt.att.attlei = attshulei.UU8.typevalue;
            matt.att.merrylenth = 1;
            matt.att.isxiugai = 0;
            matt.zhushi = datasize.Objzhushiencoding.GetBytes("id".Language());
            matt.zhi = ((byte)this.objid).structToBytes();
            list.Add(matt);
            foreach (matt current in this.atts)
            {
                if (current.att.vis == 1)
                {
                    if (this.checkatt(current))
                    {
                        if (current.att.attlei == attshulei.Strlenth.typevalue)
                        {
                            current.zhi[0] = (byte)(this.Getshutxt_merrylenth(current.name.Getstring(datasize.Myencoding), true) - 1);
                        }
                        matt = new matt();
                        matt.att = current.att;
                        matt.name = new byte[current.name.Length];
                        current.name.CopyTo(matt.name, 0);
                        matt.zhi = new byte[current.zhi.Length];
                        current.zhi.CopyTo(matt.zhi, 0);
                        matt.zhushi = new byte[current.zhushi.Length];
                        current.zhushi.CopyTo(matt.zhushi, 0);
                        list.Add(matt);
                    }
                }
            }
            if (objtype.getobjmark(this.myobj.objType).show > 0 && this.myobj.objType != objtype.page)
            {
                matt = new matt();
                matt.name = "x".GetbytesssASCII();
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.merrylenth = 2;
                matt.att.isxiugai = 0;
                matt.zhushi = datasize.Objzhushiencoding.GetBytes("X坐标".Language());
                matt.zhi = ((ushort)this.GetattVal_string("x").Getint()).structToBytes();
                list.Add(matt);
                matt = new matt();
                matt.name = "y".GetbytesssASCII();
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.merrylenth = 2;
                matt.att.isxiugai = 0;
                matt.zhushi = datasize.Objzhushiencoding.GetBytes("Y坐标".Language());
                matt.zhi = ((ushort)this.GetattVal_string("y").Getint()).structToBytes();
                list.Add(matt);
                matt = new matt();
                matt.name = "w".GetbytesssASCII();
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.merrylenth = 2;
                matt.att.isxiugai = 0;
                matt.zhushi = datasize.Objzhushiencoding.GetBytes("宽度".Language());
                matt.zhi = ((ushort)this.GetattVal_string("w").Getint()).structToBytes();
                list.Add(matt);
                matt = new matt();
                matt.name = "h".GetbytesssASCII();
                matt.att.attlei = attshulei.UU16.typevalue;
                matt.att.merrylenth = 2;
                matt.att.isxiugai = 0;
                matt.zhushi = datasize.Objzhushiencoding.GetBytes("高度".Language());
                matt.zhi = ((ushort)this.GetattVal_string("h").Getint()).structToBytes();
                list.Add(matt);
            }
            return list;
        }

        public List<byte[]> GetfenleiCodesBytes(List<byte[]> lcodes, string name, string endstr)
        {
            bool flag = false;
            List<byte[]> list = new List<byte[]>();
            List<byte[]> result;
            foreach (byte[] current in lcodes)
            {
                if (flag)
                {
                    if (current.Length == endstr.Length && current.Getstring(datasize.Myencoding) == endstr)
                    {
                        result = list;
                        return result;
                    }
                    list.Add(current);
                }
                else if (current.Length == name.Length && current.Getstring(datasize.Myencoding) == name)
                {
                    flag = true;
                }
            }
            result = list;
            return result;
        }

        public List<string> GetfenleiCodesString(List<byte[]> lcodes, string name, string endstr)
        {
            bool flag = false;
            List<string> list = new List<string>();
            List<string> result;
            foreach (byte[] current in lcodes)
            {
                if (flag)
                {
                    if (current.Length == endstr.Length && current.Getstring(datasize.Myencoding) == endstr)
                    {
                        result = list;
                        return result;
                    }
                    string item = current.Getstring(datasize.Myencoding);
                    list.Add(item);
                }
                else if (current.Length == name.Length && current.Getstring(datasize.Myencoding) == name)
                {
                    flag = true;
                }
            }
            list.Codeduiqi();
            result = list;
            return result;
        }

        public void Putcodes(List<byte[]> lbt, string endstr, byte filever)
        {
            try
            {
                List<byte[]> list = this.GetfenleiCodesBytes(lbt, "att", endstr);
                int num = Marshal.SizeOf(default(attinf_Up));
                this.atts.Clear();
                this.isbangding = 0;
                byte[] array = new byte[0];
                foreach (byte[] current in list)
                {
                    array = current;
                    if (array.Length > 8 && array.Length < 1024)
                    {
                        matt matt = new matt();
                        matt.name = array.subbytes(0, 8);
                        if (matt.name[3] == 45)
                        {
                            matt.name[3] = 95;
                        }
                        if (filever < 9 && this.atts.Count == 0 && matt.name.Getstring(datasize.Myencoding) == "lei")
                        {
                            matt.name = "type".GetbytesssASCII(8);
                        }
                        if (filever < 8)
                        {
                            string text = matt.name.Getstring(datasize.Myencoding);
                            array = Kuozhan.Gethebingbytes(array.subbytes(0, 8 + num - 1), new byte[1], array.subbytes(8 + num - 1, array.Length - (8 + num - 1)));
                            if (text == "type" || (text.Length > 3 && text.Contains("vvs")))
                            {
                                array[8 + num - 1] = 0;
                            }
                            else
                            {
                                array[8 + num - 1] = 1;
                            }
                        }
                        byte[] bytes = array.subbytes(8, num);
                        matt.att = (attinf_Up)bytes.BytesTostruct(default(attinf_Up).GetType());
                        if (array.Length >= num + 8 + (int)matt.att.zhanyonglenth)
                        {
                            matt.zhi = array.subbytes(num + 8, (int)matt.att.zhanyonglenth);
                            matt.zhushi = array.subbytes(num + 8 + (int)matt.att.zhanyonglenth);
                            if (matt.att.attlei == attshulei.Sstr.typevalue)
                            {
                                if (matt.zhi.Length == 0 || matt.zhi[matt.zhi.Length - 1] != 0)
                                {
                                    matt.zhi = Kuozhan.Gethebingbytes(matt.zhi, "".GetbytesssASCII(1));
                                }
                                matt.att.zhanyonglenth = (ushort)matt.zhi.Length;
                                if (matt.att.zhanyonglenth > matt.att.merrylenth)
                                {
                                    matt.att.merrylenth = matt.att.zhanyonglenth;
                                }
                            }
                            this.atts.Add(matt);
                            this.checkatt(matt);
                        }
                    }
                }
                objattcaozuo.checkattline(ref this.atts);
            }
            catch (Exception ex)
            {
                MessageOpen.Show("设置控件属性出现错误".Language() + ex.Message);
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

        public List<byte[]> Getcodes()
        {
            List<byte[]> result = new List<byte[]>();
            this.Getcodes(ref result);
            return result;
        }

        public void Getcodes(ref List<byte[]> lcodes)
        {
            lcodes.Add("att".GetbytesssASCII());
            foreach (matt current in this.atts)
            {
                byte[] item = Kuozhan.Gethebingbytes(current.name, current.att.structToBytes(), current.zhi, current.zhushi);
                lcodes.Add(item);
            }
            lcodes.Add("E".GetbytesssASCII());
            objmark_ objmark_ = objtype.getobjmark(this.myobj.objType);
            for (int i = 0; i < objmark_.events.Length; i++)
            {
                lcodes.Add(objmark_.events[i].eventres.GetbytesssASCII());
                lcodes.AddListBytes(this.Codes[objmark_.events[i].eventid.Getint()].GetListbytes());
                lcodes.Add("E".GetbytesssASCII());
            }
        }

        private void getstylecode(ref List<string>[] zhiling, string indexstr, string style)
        {
            if (style != null && !(style == ""))
            {
                string[] array = indexstr.Split(new char[]
                {
                    '-'
                });
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string str = array2[i];
                    string text = "";
                    int num = str.Getint();
                    if (num < zhiling.Length)
                    {
                        if (style == "1")
                        {
                            text = "draw3d '&x&','&y&','&endx&','&endy&','&borderc&','&borderc&','&borderw&'";
                        }
                        else if (style == "2")
                        {
                            text = string.Concat(new string[]
                            {
                                "draw3d '&x&','&y&','&endx&','&endy&',",
                                this.d3color1,
                                ",",
                                this.d3color0,
                                ",1"
                            });
                        }
                        else if (style == "3")
                        {
                            text = string.Concat(new string[]
                            {
                                "draw3d '&x&','&y&','&endx&','&endy&',",
                                this.d3color0,
                                ",",
                                this.d3color1,
                                ",1"
                            });
                        }
                        else if (style == "4")
                        {
                            if (num == 4)
                            {
                                text = string.Concat(new string[]
                                {
                                    "draw3d '&x&','&y&','&endx&','&endy&',",
                                    this.d3color1,
                                    ",",
                                    this.d3color0,
                                    ",1"
                                });
                            }
                            else if (num == 6)
                            {
                                text = string.Concat(new string[]
                                {
                                    "draw3d '&x&','&y&','&endx&','&endy&',",
                                    this.d3color0,
                                    ",",
                                    this.d3color1,
                                    ",1"
                                });
                            }
                            else
                            {
                                text = string.Concat(new string[]
                                {
                                    "draw3d '&x&','&y&','&endx&','&endy&',",
                                    this.d3color0,
                                    ",",
                                    this.d3color1,
                                    ",1"
                                });
                            }
                        }
                        if (text != "")
                        {
                            zhiling[num].Add(text);
                        }
                    }
                }
            }
        }

        private int Getatt_Codes(ref List<string> mycodes, int index)
        {
            string str = "0";
            int num = 0;
            List<string>[] array = new List<string>[]
            {
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>()
            };
            this.myobj.objType = this.atts[0].zhi[0];
            int result;
            if (index >= array.Length)
            {
                result = 0;
            }
            else
            {
                if (this.atts.Count > 0 && this.atts[0].zhi.Length == 1)
                {
                    if (this.atts[0].zhi[0] == objtype.number)
                    {
                        string text = this.GetattVal_string("sta");
                        if (text != null)
                        {
                            if (text == "0")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&',0," + str);
                                if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                                {
                                    array[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                }
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                array[0].Add("nstr '&val&','&lenth&'");
                                array[2].Add("nstr '&val&','&lenth&'");
                                array[8].Add("nstr '&val&','&lenth&'");
                            }
                            else if (text == "1")
                            {
                                string text2 = this.GetattVal_string("style");
                                if (text2 != null)
                                {
                                    if (text2 == "1")
                                    {
                                        str = this.GetattVal_string("borderw");
                                    }
                                    else if (text2 == "2" || text2 == "3" || text2 == "4")
                                    {
                                        str = "1";
                                    }
                                }
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',1,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                array[0].Add("nstr '&val&','&lenth&'");
                                array[2].Add("nstr '&val&','&lenth&'");
                                array[8].Add("nstr '&val&','&lenth&'");
                                this.getstylecode(ref array, "0-2-8", text2);
                            }
                            else if (text == "2")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',2,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("pic '&x&','&y&','&pic&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("pic '&x&','&y&','&pic&'");
                                array[0].Add("nstr '&val&','&lenth&'");
                                array[2].Add("nstr '&val&','&lenth&'");
                                array[8].Add("nstr '&val&','&lenth&'");
                            }
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.button_t)
                    {
                        string text = this.GetattVal_string("sta");
                        string text3 = this.GetattVal_string("style");
                        if (text != null)
                        {
                            if (text == "0")
                            {
                                array[0].Add("if('&val&'==1)");
                                array[0].Add("{");
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc1&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("}else");
                                array[0].Add("{");
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc0&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("}");
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[2].Add("if('&val&'==1)");
                                array[2].Add("{");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc1&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("}else");
                                array[2].Add("{");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc0&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("}");
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[4].Add("if('&val&'==1)");
                                array[4].Add("{");
                                array[4].Add("'&val&'=0");
                                array[4].Add("}else");
                                array[4].Add("{");
                                array[4].Add("'&val&'=1");
                                array[4].Add("}");
                                if (this.GetattVal_string("val") == "0")
                                {
                                    array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc0&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                }
                                else
                                {
                                    array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc1&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                }
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            }
                            else if (text == "1")
                            {
                                string text2 = this.GetattVal_string("style");
                                if (text2 != null)
                                {
                                    if (text2 == "1")
                                    {
                                        str = this.GetattVal_string("borderw");
                                    }
                                    else if (text2 == "2" || text2 == "3" || text2 == "4")
                                    {
                                        str = "1";
                                    }
                                }
                                array[0].Add("if('&val&'==1)");
                                array[0].Add("{");
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco1&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                if (text3 != null && text3 == "4")
                                {
                                    array[0].Add(string.Concat(new string[]
                                    {
                                        "draw3d '&x&','&y&','&endx&','&endy&',",
                                        this.d3color0,
                                        ",",
                                        this.d3color1,
                                        ",1"
                                    }));
                                }
                                array[0].Add("}else");
                                array[0].Add("{");
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco0&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                if (text3 != null && text3 == "4")
                                {
                                    array[0].Add(string.Concat(new string[]
                                    {
                                        "draw3d '&x&','&y&','&endx&','&endy&',",
                                        this.d3color1,
                                        ",",
                                        this.d3color0,
                                        ",1"
                                    }));
                                }
                                array[0].Add("}");
                                array[2].Add("if('&val&'==1)");
                                array[2].Add("{");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco1&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                if (text3 != null && text3 == "4")
                                {
                                    array[2].Add(string.Concat(new string[]
                                    {
                                        "draw3d '&x&','&y&','&endx&','&endy&',",
                                        this.d3color0,
                                        ",",
                                        this.d3color1,
                                        ",1"
                                    }));
                                }
                                array[2].Add("}else");
                                array[2].Add("{");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco0&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                if (text3 != null && text3 == "4")
                                {
                                    array[2].Add(string.Concat(new string[]
                                    {
                                        "draw3d '&x&','&y&','&endx&','&endy&',",
                                        this.d3color1,
                                        ",",
                                        this.d3color0,
                                        ",1"
                                    }));
                                }
                                array[2].Add("}");
                                array[4].Add("if('&val&'==1)");
                                array[4].Add("{");
                                array[4].Add("'&val&'=0");
                                array[4].Add("}else");
                                array[4].Add("{");
                                array[4].Add("'&val&'=1");
                                array[4].Add("}");
                                if (this.GetattVal_string("val") == "0")
                                {
                                    array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco0&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                    array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                    if (text3 != null && text3 == "4")
                                    {
                                        array[8].Add(string.Concat(new string[]
                                        {
                                            "draw3d '&x&','&y&','&endx&','&endy&',",
                                            this.d3color1,
                                            ",",
                                            this.d3color0,
                                            ",1"
                                        }));
                                    }
                                }
                                else
                                {
                                    array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco1&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                    array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                    if (text3 != null && text3 == "4")
                                    {
                                        array[8].Add(string.Concat(new string[]
                                        {
                                            "draw3d '&x&','&y&','&endx&','&endy&',",
                                            this.d3color0,
                                            ",",
                                            this.d3color1,
                                            ",1"
                                        }));
                                    }
                                }
                                if (text3 != null && text3 != "4")
                                {
                                    this.getstylecode(ref array, "0-2-8", text2);
                                }
                            }
                            else if (text == "2")
                            {
                                array[0].Add("if('&val&'==1)");
                                array[0].Add("{");
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic1&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("}else");
                                array[0].Add("{");
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic0&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("}");
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[2].Add("if('&val&'==1)");
                                array[2].Add("{");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic1&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("}else");
                                array[2].Add("{");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic0&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("}");
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[4].Add("if('&val&'==1)");
                                array[4].Add("{");
                                array[4].Add("'&val&'=0");
                                array[4].Add("}else");
                                array[4].Add("{");
                                array[4].Add("'&val&'=1");
                                array[4].Add("}");
                                if (this.GetattVal_string("val") == "0")
                                {
                                    array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic0&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                }
                                else
                                {
                                    array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic1&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                }
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            }
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.checkbox)
                    {
                        string text2 = this.GetattVal_string("style");
                        array[0].Add("sya0='&w&'/4");
                        array[0].Add("sya1='&w&'-sya0-sya0");
                        array[0].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                        array[0].Add("if('&val&'==1)");
                        array[0].Add("{");
                        array[0].Add("fill '&x&'+sya0,'&y&'+sya0,sya1,sya1,'&pco&'");
                        array[0].Add("}");
                        array[2].Add("sya0='&w&'/4");
                        array[2].Add("sya1='&w&'-sya0-sya0");
                        array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                        array[2].Add("if('&val&'==1)");
                        array[2].Add("{");
                        array[2].Add("fill '&x&'+sya0,'&y&'+sya0,sya1,sya1,'&pco&'");
                        array[2].Add("}");
                        array[4].Add("if('&val&'==1)");
                        array[4].Add("{");
                        array[4].Add("'&val&'=0");
                        array[4].Add("}else");
                        array[4].Add("{");
                        array[4].Add("'&val&'=1");
                        array[4].Add("}");
                        array[8].Add("sya0='&w&'/4");
                        array[8].Add("sya1='&w&'-sya0-sya0");
                        array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                        if (this.GetattVal_string("val") == "1")
                        {
                            array[8].Add("fill '&x&'+sya0,'&y&'+sya0,sya1,sya1,'&pco&'");
                        }
                        this.getstylecode(ref array, "0-2-8", text2);
                    }
                    else if (this.atts[0].zhi[0] == objtype.radiobutton)
                    {
                        array[0].Add("sya0='&w&'/2");
                        array[0].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0,'&bco&'");
                        array[0].Add("cir '&x&'+sya0,'&y&'+sya0,sya0,16936");
                        array[0].Add("if('&val&'==1)");
                        array[0].Add("{");
                        array[0].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0/2,'&pco&'");
                        array[0].Add("}");
                        array[2].Add("sya0='&w&'/2");
                        array[2].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0,'&bco&'");
                        array[2].Add("cir '&x&'+sya0,'&y&'+sya0,sya0,16936");
                        array[2].Add("if('&val&'==1)");
                        array[2].Add("{");
                        array[2].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0/2,'&pco&'");
                        array[2].Add("}");
                        array[4].Add("if('&val&'==1)");
                        array[4].Add("{");
                        array[4].Add("'&val&'=0");
                        array[4].Add("}else");
                        array[4].Add("{");
                        array[4].Add("'&val&'=1");
                        array[4].Add("}");
                        array[8].Add("sya0='&w&'/2");
                        array[8].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0,'&bco&'");
                        array[8].Add("cir '&x&'+sya0,'&y&'+sya0,sya0,16936");
                        if (this.GetattVal_string("val") == "1")
                        {
                            array[8].Add("cirs '&x&'+sya0,'&y&'+sya0,sya0/2,'&pco&'");
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.Timer)
                    {
                        array[1].Add("timerset 0,'&id&',65535");
                        array[1].Add("L '&pageid&'-'&id&'a");
                        array[2].Add("if('&en&'==1)");
                        array[2].Add("{");
                        array[2].Add("timerset 1,'&id&','&tim&'");
                        array[2].Add("}");
                        array[7].Add("S '&pageid&'-'&id&'a");
                        array[0].Add("S '&pageid&'-'&id&'r");
                        array[0].Add("if('&en&'==1)");
                        array[0].Add("{");
                        array[0].Add("timerset 1,'&id&','&tim&'");
                        array[0].Add("}else");
                        array[0].Add("{");
                        array[0].Add("timerset 1,'&id&',65535");
                        array[0].Add("}");
                        array[17].Add("ifvis '&id&',1");
                        array[17].Add("L '&pageid&'-'&id&'r");
                    }
                    else if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_SLIDER)
                    {
                        array[2].Add("load '&id&'");
                    }
                    else if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_CURVE)
                    {
                        array[1].Add("init '&id&'");
                        array[2].Add("load '&id&'");
                    }
                    else if (this.atts[0].zhi[0] == objtype.text)
                    {
                        string text = this.GetattVal_string("sta");
                        if (text != null)
                        {
                            if (text == "0")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                                {
                                    array[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                }
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            }
                            else if (text == "1")
                            {
                                string text2 = this.GetattVal_string("style");
                                if (text2 != null)
                                {
                                    if (text2 == "1")
                                    {
                                        str = this.GetattVal_string("borderw");
                                    }
                                    else if (text2 == "2" || text2 == "3" || text2 == "4")
                                    {
                                        str = "1";
                                    }
                                }
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',1,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                this.getstylecode(ref array, "0-2-8", text2);
                            }
                            else if (text == "2")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',2,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[2].Add("pic '&x&','&y&','&pic&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&','&pw&'," + str);
                                array[8].Add("pic '&x&','&y&','&pic&'");
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            }
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.gtext)
                    {
                        string text = this.GetattVal_string("sta");
                        string text3 = this.GetattVal_string("style");
                        string text2 = this.GetattVal_string("style");
                        if (text == "1")
                        {
                            if (text2 != null)
                            {
                                if (text2 == "1")
                                {
                                    str = this.GetattVal_string("borderw");
                                }
                                else if (text2 == "2" || text2 == "3" || text2 == "4")
                                {
                                    str = "1";
                                }
                            }
                        }
                        if (text != null)
                        {
                            array[0].Add("S '&pageid&'-'&id&'r");
                            array[1].Add("setbrush '&x&','&y&','&w&','&h&','&font&',0,0,0,0,0,'&isbr&','&spax&','&spay&',0," + str);
                            array[1].Add("strsize '&txt&','&vvs2&','&vvs3&'");
                            array[1].Add("if('&dir&'==0)");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'='&x&'-'&vvs2&'-1");
                            array[1].Add("'&vvs1&'=32767");
                            array[1].Add("}else if('&dir&'==1)");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'='&endx&'+1");
                            array[1].Add("'&vvs1&'=32767");
                            array[1].Add("}else if('&dir&'==2)");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'='&y&'-'&vvs3&'-1");
                            array[1].Add("'&vvs0&'=32767");
                            array[1].Add("}else if('&dir&'==3)");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'='&endy&'+1");
                            array[1].Add("'&vvs0&'=32767");
                            array[1].Add("}");
                            array[1].Add("timerset 0,'&id&',65535");
                            array[1].Add("L '&pageid&'-'&id&'a");
                            array[1].Add("L '&pageid&'-'&id&'b");
                            array[1].Add("S '&pageid&'-'&id&'a");
                            array[1].Add("if('&en&'==1)");
                            array[1].Add("{");
                            array[1].Add("setbrush '&x&','&y&','&w&','&h&','&font&',0,0,0,0,0,'&isbr&','&spax&','&spay&',0," + str);
                            array[1].Add("strsize '&txt&','&vvs2&','&vvs3&'");
                            array[1].Add("if('&dir&'==0)");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'=32767");
                            array[1].Add("'&vvs0&'='&vvs0&'+'&dis&'");
                            array[1].Add("sya0='&x&'-'&vvs2&'");
                            array[1].Add("if('&vvs0&'>'&endx&')");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'='&x&'-'&vvs2&'");
                            array[1].Add("}else if('&vvs0&'<sya0)");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'=sya0");
                            array[1].Add("}");
                            array[1].Add("}else if('&dir&'==1)");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'=32767");
                            array[1].Add("'&vvs0&'='&vvs0&'-'&dis&'");
                            array[1].Add("sya0='&x&'-'&vvs2&'");
                            array[1].Add("if('&vvs0&'<sya0)");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'='&endx&'");
                            array[1].Add("}else if('&vvs0&'>'&endx&')");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'='&endx&'");
                            array[1].Add("}");
                            array[1].Add("}else if('&dir&'==2)");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'=32767");
                            array[1].Add("'&vvs1&'='&vvs1&'+'&dis&'");
                            array[1].Add("sya0='&y&'-'&vvs3&'");
                            array[1].Add("if('&vvs1&'>'&endy&')");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'='&y&'-'&vvs3&'");
                            array[1].Add("}else if('&vvs1&'<sya0)");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'=sya0");
                            array[1].Add("}");
                            array[1].Add("}else if('&dir&'==3)");
                            array[1].Add("{");
                            array[1].Add("'&vvs0&'=32767");
                            array[1].Add("'&vvs1&'='&vvs1&'-'&dis&'");
                            array[1].Add("sya0='&y&'-'&vvs3&'");
                            array[1].Add("if('&vvs1&'<sya0)");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'='&endy&'");
                            array[1].Add("}else if('&vvs1&'>'&endy&')");
                            array[1].Add("{");
                            array[1].Add("'&vvs1&'='&endy&'");
                            array[1].Add("}");
                            array[1].Add("}");
                            array[1].Add("ifvis '&id&',1");
                            array[1].Add("L '&pageid&'-'&id&'r");
                            array[1].Add("E");
                            array[1].Add("}");
                            array[1].Add("S '&pageid&'-'&id&'b");
                            if (text == "0")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',0,'&isbr&','&spax&','&spay&',0," + str);
                                if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                                {
                                    array[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                    array[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                }
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                array[2].Add("if('&en&'==1)");
                                array[2].Add("{");
                                array[2].Add("timerset 1,'&id&','&tim&'");
                                array[2].Add("}");
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[0].Add("zstr '&vvs0&','&vvs1&','&vvs2&','&vvs3&','&txt&'");
                                array[0].Add("if('&en&'==1)");
                                array[0].Add("{");
                                array[0].Add("timerset 1,'&id&','&tim&'");
                                array[0].Add("}else");
                                array[0].Add("{");
                                array[0].Add("timerset 1,'&id&',65535");
                                array[0].Add("}");
                            }
                            else if (text == "1")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',1,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                array[2].Add("if('&en&'==1)");
                                array[2].Add("{");
                                array[2].Add("timerset 1,'&id&','&tim&'");
                                array[2].Add("}");
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[0].Add("zstr '&vvs0&','&vvs1&','&vvs2&','&vvs3&','&txt&'");
                                this.getstylecode(ref array, "0-2-8", text2);
                                array[0].Add("if('&en&'==1)");
                                array[0].Add("{");
                                array[0].Add("timerset 1,'&id&','&tim&'");
                                array[0].Add("}else");
                                array[0].Add("{");
                                array[0].Add("timerset 1,'&id&',65535");
                                array[0].Add("}");
                            }
                            else if (text == "2")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',2,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("pic '&x&','&y&','&pic&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("pic '&x&','&y&','&pic&'");
                                array[2].Add("if('&en&'==1)");
                                array[2].Add("{");
                                array[2].Add("timerset 1,'&id&','&tim&'");
                                array[2].Add("}");
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[0].Add("zstr '&vvs0&','&vvs1&','&vvs2&','&vvs3&','&txt&'");
                                array[0].Add("if('&en&'==1)");
                                array[0].Add("{");
                                array[0].Add("timerset 1,'&id&','&tim&'");
                                array[0].Add("}else");
                                array[0].Add("{");
                                array[0].Add("timerset 1,'&id&',65535");
                                array[0].Add("}");
                            }
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.button)
                    {
                        string text = this.GetattVal_string("sta");
                        if (text != null)
                        {
                            if (text == "0")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                if (this.Mypage.objs[0].GetattVal_string("sta") == "2" && this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc"))
                                {
                                    array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',3,'&isbr&','&spax&','&spay&',0," + str);
                                }
                                else
                                {
                                    array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                }
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[4].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco2&','&picc2&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[4].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[6].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[6].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&picc&','&xcen&','&ycen&',10,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            }
                            else if (text == "1")
                            {
                                string text2 = this.GetattVal_string("style");
                                if (text2 != null)
                                {
                                    if (text2 == "1")
                                    {
                                        str = this.GetattVal_string("borderw");
                                    }
                                    else if (text2 == "2" || text2 == "3" || text2 == "4")
                                    {
                                        str = "1";
                                    }
                                }
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[4].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco2&','&bco2&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[4].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[6].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[6].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&bco&','&xcen&','&ycen&',11,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                this.getstylecode(ref array, "0-2-4-6-8", text2);
                            }
                            else if (text == "2")
                            {
                                array[0].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[0].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[2].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[2].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[4].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco2&','&pic2&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[4].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[6].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[6].Add("zstr 32767,32767,32767,32767,'&txt&'");
                                array[8].Add("setbrush '&x&','&y&','&w&','&h&','&font&','&pco&','&pic&','&xcen&','&ycen&',12,'&isbr&','&spax&','&spay&',0," + str);
                                array[8].Add("zstr 32767,32767,32767,32767,'&txt&'");
                            }
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.prog)
                    {
                        string text = this.GetattVal_string("sta");
                        string text3 = this.GetattVal_string("dez");
                        if (text != null)
                        {
                            if (text == "0")
                            {
                                if (text3 == "0")
                                {
                                    array[0].Add("sya0='&val&'*'&w&'/100");
                                    array[0].Add("fill '&x&','&y&',sya0,'&h&','&pco&'");
                                    array[0].Add("fill '&x&'+sya0,'&y&','&w&'-sya0,'&h&','&bco&'");
                                    array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[2].Add("fill '&x&','&y&','&val&'*'&w&'/100,'&h&','&pco&'");
                                    array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[8].Add("fill '&x&','&y&','&val&'*'&w&'/100,'&h&','&pco&'");
                                }
                                if (text3 == "1")
                                {
                                    array[0].Add("sya0='&val&'*'&h&'/100");
                                    array[0].Add("fill '&x&','&endy&'+1-sya0,'&w&',sya0,'&pco&'");
                                    array[0].Add("fill '&x&','&y&','&w&','&h&'-sya0,'&bco&'");
                                    array[2].Add("sya0='&val&'*'&h&'/100");
                                    array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[2].Add("fill '&x&','&endy&'+1-sya0,'&w&',sya0,'&pco&'");
                                    array[8].Add("sya0='&val&'*'&h&'/100");
                                    array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[8].Add("fill '&x&','&endy&'+1-sya0,'&w&',sya0,'&pco&'");
                                }
                            }
                            else if (text == "1")
                            {
                                if (text3 == "0")
                                {
                                    array[0].Add("sya0='&val&'*'&w&'/100");
                                    array[0].Add("xpic '&x&','&y&',sya0,'&h&',0,0,'&ppic&'");
                                    array[0].Add("xpic '&x&'+sya0,'&y&','&w&'-sya0,'&h&',sya0,0,'&bpic&'");
                                    array[2].Add("pic '&x&','&y&','&bpic&'");
                                    array[2].Add("xpic '&x&','&y&','&val&'*'&w&'/100,'&h&',0,0,'&ppic&'");
                                    array[8].Add("pic '&x&','&y&','&bpic&'");
                                    array[8].Add("xpic '&x&','&y&','&val&'*'&w&'/100,'&h&',0,0,'&ppic&'");
                                }
                                if (text3 == "1")
                                {
                                    array[0].Add("sya0='&val&'*'&h&'/100");
                                    array[0].Add("xpic '&x&','&endy&'+1-sya0,'&w&',sya0,0,'&h&'-sya0,'&ppic&'");
                                    array[0].Add("xpic '&x&','&y&','&w&','&h&'-sya0,0,0,'&bpic&'");
                                    array[2].Add("sya0='&val&'*'&h&'/100");
                                    array[2].Add("pic '&x&','&y&','&bpic&'");
                                    array[2].Add("xpic '&x&','&endy&'+1-sya0,'&w&',sya0,0,'&h&'-sya0,'&ppic&'");
                                    array[8].Add("sya0='&val&'*'&h&'/100");
                                    array[8].Add("pic '&x&','&y&','&bpic&'");
                                    array[8].Add("xpic '&x&','&endy&'+1-sya0,'&w&',sya0,0,'&h&'-sya0,'&ppic&'");
                                }
                            }
                        }
                    }
                    else if (this.atts[0].zhi[0] == objtype.pic)
                    {
                        array[0].Add("pic '&x&','&y&','&pic&'");
                        array[2].Add("pic '&x&','&y&','&pic&'");
                        array[8].Add("pic '&x&','&y&','&pic&'");
                    }
                    else if (this.atts[0].zhi[0] == objtype.picc)
                    {
                        array[0].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                        array[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                        array[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                    }
                    else if (this.atts[0].zhi[0] != objtype.touch)
                    {
                        if (this.atts[0].zhi[0] == objtype.zhizhen)
                        {
                            string text = this.GetattVal_string("sta");
                            if (text != null)
                            {
                                if (text == "0")
                                {
                                    array[0].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                    if (!(this.Mypage.objs[0].GetattVal_string("sta") == "2") || !(this.Mypage.objs[0].GetattVal_string("pic") == this.GetattVal_string("picc")))
                                    {
                                        array[2].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                    }
                                    array[8].Add("xpic '&x&','&y&','&w&','&h&','&x&','&y&','&picc&'");
                                }
                                else if (text == "1")
                                {
                                    array[0].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                }
                                else if (text == "2")
                                {
                                    array[0].Add("pic '&x&','&y&','&pic&'");
                                    array[2].Add("pic '&x&','&y&','&pic&'");
                                    array[8].Add("pic '&x&','&y&','&pic&'");
                                }
                                array[0].Add("draw_h '&w&'/2+'&x&','&h&'/2+'&y&','&h&'/2-'&wid&','&val&','&wid&','&pco&'");
                                array[2].Add("draw_h '&w&'/2+'&x&','&h&'/2+'&y&','&h&'/2-'&wid&','&val&','&wid&','&pco&'");
                                array[8].Add("draw_h '&w&'/2+'&x&','&h&'/2+'&y&','&h&'/2-'&wid&','&val&','&wid&','&pco&'");
                            }
                        }
                        else if (this.atts[0].zhi[0] == objtype.page)
                        {
                            string text = this.GetattVal_string("sta");
                            if (text != null)
                            {
                                if (text == "1")
                                {
                                    array[0].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[2].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                    array[8].Add("fill '&x&','&y&','&w&','&h&','&bco&'");
                                }
                                else if (text == "2")
                                {
                                    array[0].Add("pic '&x&','&y&','&pic&'");
                                    array[2].Add("pic '&x&','&y&','&pic&'");
                                    array[8].Add("pic '&x&','&y&','&pic&'");
                                }
                            }
                        }
                    }
                }
                foreach (string current in array[index])
                {
                    num++;
                    mycodes.Add(current);
                }
                result = num;
            }
            return result;
        }

        public string checkattval(matt at)
        {
            string result;
            try
            {
                if (at.att.attlei == attshulei.Picid.typevalue)
                {
                    int num = (int)((ushort)at.zhi.BytesTostruct(0.GetType()));
                    if (num >= this.Myapp.images.Count)
                    {
                        result = "图片ID无效".Language();
                        return result;
                    }
                }
                if (at.name.Getstring(datasize.Myencoding) == "font")
                {
                    if ((int)at.zhi[0] >= this.Myapp.zimos.Count)
                    {
                        if (this.GetattVal_string("txt") != null && this.GetattVal_string("txt") == "")
                        {
                            result = "";
                            return result;
                        }
                        result = "字库ID无效".Language();
                        return result;
                    }
                }
                if (at.name.Getstring(datasize.Myencoding) == "key")
                {
                    keyboardlisttype keyboardlisttype = this.Myapp.getkeyboardlisttype(at.zhi[0]);
                    if (keyboardlisttype.id != 255)
                    {
                        if (this.Myapp.findpagename(keyboardlisttype.pagename, 65535) == -1)
                        {
                            result = "键盘页面丢失(重新选择绑定可自动载入键盘页面)".Language();
                            return result;
                        }
                    }
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

        public bool biduiatt(string name, byte datalei)
        {
            bool result;
            foreach (matt current in this.atts)
            {
                if (current.name.Getstring(datasize.Myencoding) == name)
                {
                    result = true;
                    return result;
                }
            }
            if (objtype.getobjmark(this.myobj.objType).show > 0)
            {
                if (name == "x" || name == "y" || name == "w" || name == "h" || name == "endx" || name == "endy")
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        public bool checkatt(matt at)
        {
            bool result;
            if (datasize.Objzhushiencoding.GetString(at.zhushi).Contains("~"))
            {
                string[] array = datasize.Objzhushiencoding.GetString(at.zhushi).Split(new char[]
                {
                    '~'
                });
                if (array.Length > 10)
                {
                    MessageOpen.Show("控件属性数据错误:0".Language());
                    result = false;
                    return result;
                }
                for (int i = 1; i < array.Length; i++)
                {
                    string text = array[i];
                    string[] array2 = text.Split(new char[]
                    {
                        '='
                    });
                    if (array2.Length != 2)
                    {
                        array2 = text.Split(new char[]
                        {
                            '>'
                        });
                        if (array2.Length != 2)
                        {
                            MessageOpen.Show("控件属性数据错误:1".Language());
                            result = false;
                            return result;
                        }
                        string text2 = this.GetattVal_string(array2[0]);
                        if (text2 == null)
                        {
                            result = false;
                            return result;
                        }
                        if (text2.IsdataS32(attshulei.UU8.typevalue))
                        {
                            if (text2.Getint() < (int)byte.Parse(array2[1]))
                            {
                                result = false;
                                return result;
                            }
                        }
                    }
                    else
                    {
                        string text2 = this.GetattVal_string(array2[0]);
                        if (text2 == null)
                        {
                            result = false;
                            return result;
                        }
                        if (text2 != array2[1])
                        {
                            result = false;
                            return result;
                        }
                    }
                }
            }
            if (at.att.isbangding == 1)
            {
                this.isbangding = 1;
            }
            result = true;
            return result;
        }

        public unsafe bool attpianyiset(string attname, ushort dpianyi)
        {
            byte[] array = attname.GetbytesssASCII(attname.Length + 1);
            byte b;
            fixed (byte* ptr = array)
            {
                byte lenth = (byte)Strmake.Strmake_GetStrlen(ptr);
                b = Attmake.Attmake_GetAttindex(ptr, lenth);
            }
            bool result;
            if (b == 255)
            {
                this.Myapp.Addbianyierr("This attname is invalid!" + array.Getstring(datasize.Myencoding));
                result = false;
            }
            else
            {
                dpianyi.structToBytes().CopyTo(this.attstrpianyi, (int)(b * 2));
                result = true;
            }
            return result;
        }

        public unsafe bool BianyiCodes(ref List<byte[]> bts)
        {
            attinf latt = default(attinf);
            ushort[] array = new ushort[8];
            for (int i = 0; i < this.attstrpianyi.Length; i++)
            {
                this.attstrpianyi[i] = 255;
            }
            latt.pageid = (byte)this.Mypage.pageid;
            latt.objid = (byte)this.objid;
            byte codeh_star = datasize.encodes_App[(int)this.Myapp.myencode].codeh_star;
            matt matt = this.Getatt("font");
            if (matt != null && this.checkatt(matt))
            {
                if ((int)matt.zhi[0] < this.Myapp.zimos.Count)
                {
                    codeh_star = this.Myapp.zimos[(int)matt.zhi[0]].codeh_star;
                }
            }
            int num;
            bool result;
            for (int i = 0; i < this.atts.Count; i++)
            {
                if (this.checkatt(this.atts[i]))
                {
                    this.atts[i].att.attinfUpToDown(ref latt, codeh_star);
                    if ((latt.state & 16) == 0)
                    {
                        if ((latt.state & 15) == attshulei.Sstr.typevalue)
                        {
                            latt.pos = (ushort)this.Myapp.addstaticstring(this.atts[i].zhi);
                            latt.merrylenth = this.atts[i].att.zhanyonglenth;
                        }
                        else
                        {
                            num = this.atts[i].zhi.getbytestoint((int)latt.merrylenth, (byte)(latt.state & 15));
                            Kuozhan.memcpy((byte*)(&latt.pos), (byte*)(&num), 4);
                        }
                    }
                    if (!this.Mypage.Allattbytes_set(this.objid, this.atts[i].name.Getstring(datasize.Myencoding), latt))
                    {
                        result = false;
                        return result;
                    }
                }
            }
            latt.merrylenth = 0;
            latt.maxval = 0;
            latt.minval = 0;
            if (objtype.getobjmark(this.atts[0].zhi[0]).show != 0)
            {
                latt.state = attshulei.UU16.typevalue;
                latt.pos = this.myobj.redian.x;
                if (!this.Mypage.Allattbytes_set(this.objid, "x", latt))
                {
                    result = false;
                    return result;
                }
                latt.state = attshulei.UU16.typevalue;
                latt.pos = this.myobj.redian.y;
                if (!this.Mypage.Allattbytes_set(this.objid, "y", latt))
                {
                    result = false;
                    return result;
                }
                latt.state = attshulei.UU16.typevalue;
                latt.pos = this.myobj.redian.endx;
                if (!this.Mypage.Allattbytes_set(this.objid, "endx", latt))
                {
                    result = false;
                    return result;
                }
                latt.state = attshulei.UU16.typevalue;
                latt.pos = this.myobj.redian.endy;
                if (!this.Mypage.Allattbytes_set(this.objid, "endy", latt))
                {
                    result = false;
                    return result;
                }
                latt.state = attshulei.UU16.typevalue;
                latt.pos = (ushort)(this.myobj.redian.endx - this.myobj.redian.x + 1);
                if (!this.Mypage.Allattbytes_set(this.objid, "w", latt))
                {
                    result = false;
                    return result;
                }
                latt.state = attshulei.UU16.typevalue;
                latt.pos =(ushort)(this.myobj.redian.endy - this.myobj.redian.y + 1);
                if (!this.Mypage.Allattbytes_set(this.objid, "h", latt))
                {
                    result = false;
                    return result;
                }
            }
            latt.state = attshulei.UU8.typevalue;
            latt.pos = (ushort)((byte)this.objid);
            if (!this.Mypage.Allattbytes_set(this.objid, "id", latt))
            {
                result = false;
                return result;
            }
            bts.Add("ref".GetbytesssASCII());
            num = this.Getbianyi(ref bts, 0, false, 2);
            if (num == 65535)
            {
                result = false;
                return result;
            }
            array[0] = (ushort)((num == 0) ? 0 : (bts.Count - num));
            bts.Add("E".GetbytesssASCII());
            bts.Add("vis".GetbytesssASCII());
            if (objtype.getobjmark(this.atts[0].zhi[0]).show > 0)
            {
                num = this.Gethidecode(ref bts);
                if (num == 65535)
                {
                    result = false;
                    return result;
                }
                array[1] = (ushort)((num == 0) ? 0 : (bts.Count - num));
            }
            bts.Add("E".GetbytesssASCII());
            objmark_ objmark_ = objtype.getobjmark(this.myobj.objType);
            for (int i = 0; i < objmark_.events.Length; i++)
            {
                int num2 = objmark_.events[i].eventid.Getint();
                if (num2 != 0 && (this.objid != 0 || (num2 != 2 && num2 != 3)))
                {
                    bts.Add(objmark_.events[i].eventres.GetbytesssASCII());
                    num = this.Getbianyi(ref bts, num2, false, 2);
                    if (num == 65535)
                    {
                        result = false;
                        return result;
                    }
                    array[num2] = (ushort)((num == 0) ? 0 : (bts.Count - num));
                    bts.Add("E".GetbytesssASCII());
                }
            }
            fixed (void* ptr = (&this.myobj.redian.events))
            //fixed (void* ptr = (void*)(&this.myobj.redian.events))
            {
                ushort* ptr2 = (ushort*)ptr;
                for (int i = 0; i < 8; i++)
                {
                    ptr2[i] = array[i];
                }
            }
            result = true;
            return result;
        }

        public int Gethidecode(ref List<byte[]> ll)
        {
            int num = 0;
            byte[] item = new byte[0];
            if (this.objid > 0)
            {
                if (this.Mypage.objs[0].GetattVal_string("sta") == "1")
                {
                    this.bianyionline(string.Concat(new string[]
                    {
                        "fill ",
                        this.myobj.redian.x.ToString(),
                        ",",
                        this.myobj.redian.y.ToString(),
                        ",",
                        ((int)(this.myobj.redian.endx - this.myobj.redian.x + 1)).ToString(),
                        ",",
                        ((int)(this.myobj.redian.endy - this.myobj.redian.y + 1)).ToString(),
                        ",",
                        this.Mypage.objs[0].GetattVal_string("bco")
                    }), ref item, "", default(bianyijieguotype));
                    ll.Add(item);
                    num++;
                }
                else if (this.Mypage.objs[0].GetattVal_string("sta") == "2")
                {
                    this.bianyionline(string.Concat(new string[]
                    {
                        "xpic ",
                        this.myobj.redian.x.ToString(),
                        ",",
                        this.myobj.redian.y.ToString(),
                        ",",
                        ((int)(this.myobj.redian.endx - this.myobj.redian.x + 1)).ToString(),
                        ",",
                        ((int)(this.myobj.redian.endy - this.myobj.redian.y + 1)).ToString(),
                        ",",
                        this.myobj.redian.x.ToString(),
                        ",",
                        this.myobj.redian.y.ToString(),
                        ",",
                        this.Mypage.objs[0].GetattVal_string("pic")
                    }), ref item, "", default(bianyijieguotype));
                    ll.Add(item);
                    num++;
                }
                List<byte> list = this.Mypage.Getguanlianobjs(this.objid);
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if ((int)list[i] != this.objid)
                        {
                            this.bianyionline("ref " + list[i].ToString(), ref item, "", default(bianyijieguotype));
                            ll.Add(item);
                            num++;
                        }
                    }
                }
            }
            return num;
        }

        public int Getbianyi(ref List<byte[]> ll, int index, bool istihuan, int flg)
        {
            int decx = 0;
            List<string> list = new List<string>();
            List<byte[]> list2 = new List<byte[]>();
            if (flg == 1 || flg == 2)
            {
                this.Getatt_Codes(ref list, index);
            }
            decx = list.Count;
            if (flg == 0 || flg == 2)
            {
                foreach (string current in this.Codes[index])
                {
                    list.Add(current);
                }
            }
            if (flg == 1 || flg == 2)
            {
                this.Getatt_Codes(ref list, 10 + index);
            }
            if (index == 6)
            {
                matt matt = this.Getatt("key");
                if (matt != null && this.checkatt(matt))
                {
                    keyboardlisttype keyboardlisttype = this.Myapp.getkeyboardlisttype(matt.zhi[0]);
                    if (keyboardlisttype.id != 255 && this.Myapp.findpagename(keyboardlisttype.pagename, 65535) != -1)
                    {
                        list.Add(keyboardlisttype.pagename + ".loadpageid.val=dp");
                        list.Add(keyboardlisttype.pagename + ".loadcmpid.val='&id&'");
                        list.Add("page " + keyboardlisttype.pagename);
                    }
                }
            }
            this.canshutihuan(ref list, 0);
            list.delzhushi();
            int result;
            if (!this.GetbianyiCodes(list, ref list2, index, decx))
            {
                result = 65535;
            }
            else
            {
                int count = list2.Count;
                ll.AddListBytes(list2);
                result = count;
            }
            return result;
        }

        public int Getbianji(ref List<byte[]> ll)
        {
            List<string> list = new List<string>();
            this.Getatt_Codes(ref list, 8);
            List<byte[]> list2 = this.canshutihuan(ref list, 1);
            foreach (byte[] current in list2)
            {
                ll.Add(current);
            }
            return list2.Count;
        }

        private string chonggouif(string str, ref bianyijieguotype by)
        {
            PosLaction posLaction = default(PosLaction);
            string result;
            if (str.Substring(str.Length - 1, 1) == ")")
            {
                string text = "I ";
                int num = (int)this.getpanduan(str, ref posLaction);
                if (num == 0)
                {
                    this.sendbianyierror("语句错误:无判断符".Language(), str, by);
                    result = "";
                }
                else
                {
                    text += str.Substring(3, (int)(posLaction.star - 3));
                    text += ",";
                    text += str.Substring((int)(posLaction.end + 1), str.Length - (int)posLaction.end - 2);
                    text = text + "," + num.ToString();
                    text += ",0";
                    result = text;
                }
            }
            else
            {
                this.sendbianyierror("语句最后一个字符必须为后括号:)".Language(), str, by);
                result = "";
            }
            return result;
        }

        public void addtimers(int id)
        {
            foreach (int current in this.Myapp.systimers)
            {
                if (current == id)
                {
                    return;
                }
            }
            this.Myapp.systimers.Add(id);
        }

        public bool bianyionline(string strccom, ref byte[] descode, string code, bianyijieguotype by)
        {
            byte b = this.codeyunxingjiance(strccom, ref descode);
            bool result;
            if (b == 0)
            {
                if (guicombianyi.errmessage != "")
                {
                    this.sendbianyierror(((int)guicombianyi.errcode).Gethanyi(), guicombianyi.errmessage, by);
                }
                else
                {
                    this.sendbianyierror(((int)guicombianyi.errcode).Gethanyi(), code, by);
                }
                result = false;
            }
            else if (b == 2)
            {
                this.sendbianyijinggao(guicombianyi.jinggaostr, code, by);
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

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

        private void sendbianyierror(string error, string code, bianyijieguotype by)
        {
            this.Myapp.Addbianyierr(error + ":" + code + "(双击此处定位代码)".Language(), by);
        }

        private void sendbianyijinggao(string error, string code, bianyijieguotype by)
        {
            this.Myapp.Addbianyijinggao(error + ":" + code + "(双击此处定位代码)".Language(), by);
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

        private byte[] tihianhex(byte[] descode, List<hexreplace_type> hexrepalce)
        {
            byte[] array = new byte[1024];
            int num = 0;
            int i = 0;
            while (hexrepalce.Count > 0)
            {
                while (i < hexrepalce[0].beg)
                {
                    array[num] = descode[i];
                    num++;
                    i++;
                }
                hexrepalce[0].bytes.CopyTo(array, num);
                num += hexrepalce[0].bytes.Length;
                i += hexrepalce[0].qyt;
                hexrepalce.Remove(hexrepalce[0]);
            }
            while (i < descode.Length)
            {
                array[num] = descode[i];
                num++;
                i++;
            }
            return array.subbytes(0, num);
        }

        private byte getpanduan(string str, ref PosLaction fengge)
        {
            ushort num = (ushort)Kuozhan.findguanjianstr(str, ">=");
            byte result;
            if (num < 65535)
            {
                fengge.star = num;
                fengge.end = (ushort)(num + 1);
                result = 5;
            }
            else
            {
                num = (ushort)Kuozhan.findguanjianstr(str, "<=");
                if (num < 65535)
                {
                    fengge.star = num;
                    fengge.end = (ushort)(num + 1);
                    result = 4;
                }
                else
                {
                    num = (ushort)Kuozhan.findguanjianstr(str, "==");
                    if (num < 65535)
                    {
                        fengge.star = num;
                        fengge.end = (ushort)(num + 1);
                        result = 1;
                    }
                    else
                    {
                        num = (ushort)Kuozhan.findguanjianstr(str, "!=");
                        if (num < 65535)
                        {
                            fengge.star = num;
                            fengge.end =(ushort)(num + 1);
                            result = 6;
                        }
                        else
                        {
                            num = (ushort)Kuozhan.findguanjianstr(str, ">");
                            if (num < 65535)
                            {
                                fengge.star = num;
                                fengge.end = num;
                                result = 3;
                            }
                            else
                            {
                                num = (ushort)Kuozhan.findguanjianstr(str, "<");
                                if (num < 65535)
                                {
                                    fengge.star = num;
                                    fengge.end = num;
                                    result = 2;
                                }
                                else
                                {
                                    result = 0;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public PosLaction findstrindex(List<byte[]> btstr, int beg, string str, string tstr)
        {
            PosLaction posLaction = default(PosLaction);
            posLaction.star = 0;
            PosLaction result;
            for (int i = beg; i < btstr.Count; i++)
            {
                if (btstr[i].Getstring(datasize.Myencoding) == tstr)
                {
                    posLaction.star += 1;
                    posLaction.star += 1;
                }
                if (btstr[i].Getstring(datasize.Myencoding) == str)
                {
                    if (posLaction.star == 0)
                    {
                        posLaction.end = (ushort)i;
                        result = posLaction;
                        return result;
                    }
                    posLaction.star -= 1;
                }
            }
            posLaction.end = 65535;
            result = posLaction;
            return result;
        }

        private List<byte[]> canshutihuan(ref List<string> bt, byte state)
        {
            List<byte[]> list = new List<byte[]>();
            for (int i = 0; i < bt.Count; i++)
            {
                Encoding encoding = datasize.Myencoding;
                string text = bt[i];
                text = text.Replace("'&id&'", this.objid.ToString());
                text = text.Replace("'&pagename&'", this.Mypage.pagename);
                text = text.Replace("'&pageid&'", this.Mypage.pageid.ToString());
                text = text.Replace("'&objname&'", this.objname);
                text = text.Replace("'&endx&'", this.myobj.redian.endx.ToString());
                text = text.Replace("'&endy&'", this.myobj.redian.endy.ToString());
                text = text.Replace("'&x&'", this.myobj.redian.x.ToString());
                text = text.Replace("'&y&'", this.myobj.redian.y.ToString());
                text = text.Replace("'&w&'", ((int)(this.myobj.redian.endx - this.myobj.redian.x + 1)).ToString());
                text = text.Replace("'&h&'", ((int)(this.myobj.redian.endy - this.myobj.redian.y + 1)).ToString());
                string text2 = this.GetattVal_string("sta");
                if (text2 != null)
                {
                    text = text.Replace("'&sta&'", text2);
                }
                for (int j = 1; j < this.atts.Count; j++)
                {
                    if (this.checkatt(this.atts[j]))
                    {
                        if (text.Contains("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'"))
                        {
                            if (state == 1 || this.atts[j].att.isxiugai == 0)
                            {
                                if (this.atts[j].att.attlei != attshulei.Sstr.typevalue)
                                {
                                    byte b = Convert.ToByte(this.atts[j].att.attlei & 15);
                                    if (this.atts[j].att.merrylenth == 1)
                                    {
                                        text = text.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi[0].ToString());
                                    }
                                    else if (this.atts[j].att.merrylenth == 2)
                                    {
                                        if (b == attshulei.UU16.typevalue)
                                        {
                                            text = text.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi.BytesTostruct(0.GetType()).ToString());
                                        }
                                        else
                                        {
                                            text = text.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi.BytesTostruct(0.GetType()).ToString());
                                        }
                                    }
                                    else if (this.atts[j].att.merrylenth == 4)
                                    {
                                        text = text.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.atts[j].zhi.BytesTostruct(0.GetType()).ToString());
                                    }
                                }
                                else
                                {
                                    encoding = this.Getobjencodeing(this.atts[j].name.Getstring(datasize.Myencoding));
                                    text = text.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", "\"" + encoding.GetString(this.atts[j].zhi).Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r\n", "\\r") + "\"");
                                }
                            }
                            else
                            {
                                text = text.Replace("'&" + this.atts[j].name.Getstring(datasize.Myencoding) + "&'", this.objname + "." + this.atts[j].name.Getstring(datasize.Myencoding));
                            }
                        }
                    }
                }
                list.Add(encoding.GetBytes(text));
                bt[i] = text;
            }
            return list;
        }

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

        public ushort GetobjRambytes(ref byte[] lbytes, int beg)
        {
            int num = beg;
            ushort num2 = this.myobj.attpos;
            ushort result;
            if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_SLIDER)
            {
                SLIDER_PARAM sLIDER_PARAM = default(SLIDER_PARAM);
                try
                {
                    sLIDER_PARAM.RefFlag = 0;
                    sLIDER_PARAM.Mode = (byte)this.GetattVal_string("mode").Getint();
                    sLIDER_PARAM.BackType = (byte)this.GetattVal_string("sta").Getint();
                    sLIDER_PARAM.CursorType = (byte)this.GetattVal_string("psta").Getint();
                    sLIDER_PARAM.CursorWid = (byte)this.GetattVal_string("wid").Getint();
                    sLIDER_PARAM.CursorHig = (byte)this.GetattVal_string("hig").Getint();
                    if (sLIDER_PARAM.BackType == 0)
                    {
                        sLIDER_PARAM.BkPicID = (ushort)this.GetattVal_string("picc").Getint();
                    }
                    else if (sLIDER_PARAM.BackType == 2)
                    {
                        sLIDER_PARAM.BkPicID = (ushort)this.GetattVal_string("pic").Getint();
                    }
                    else if (sLIDER_PARAM.BackType == 1)
                    {
                        sLIDER_PARAM.BkPicID = (ushort)this.GetattVal_string("bco").Getint();
                    }
                    if (sLIDER_PARAM.CursorType == 0)
                    {
                        sLIDER_PARAM.CuPicID = (ushort)this.GetattVal_string("pco").Getint();
                    }
                    else if (sLIDER_PARAM.CursorType == 1)
                    {
                        sLIDER_PARAM.CuPicID = (ushort)this.GetattVal_string("pic2").Getint();
                    }
                    sLIDER_PARAM.MaxVal = (ushort)this.GetattVal_string("maxval").Getint();
                    sLIDER_PARAM.MinVal = (ushort)this.GetattVal_string("minval").Getint();
                    sLIDER_PARAM.NowVal = (ushort)this.GetattVal_string("val").Getint();
                    sLIDER_PARAM.LastVal = 65535;
                    this.atts[5].att.pos =(ushort)(this.myobj.attpos + 6);
                    this.atts[6].att.pos =(ushort)(this.myobj.attpos + 6);
                    this.atts[7].att.pos =(ushort)(this.myobj.attpos + 6);
                    this.atts[8].att.pos =(ushort)(this.myobj.attpos + 8);
                    this.atts[9].att.pos =(ushort)(this.myobj.attpos + 8);
                    this.atts[10].att.pos =(ushort)(this.myobj.attpos + 4);
                    this.atts[11].att.pos =(ushort)(this.myobj.attpos + 5);
                    this.atts[12].att.pos =(ushort)(this.myobj.attpos + 10);
                    this.atts[13].att.pos =(ushort)(this.myobj.attpos + 12);
                    this.atts[14].att.pos = (ushort)(this.myobj.attpos + 14);
                    sLIDER_PARAM.structToBytes().CopyTo(lbytes, num);
                    num += Marshal.SizeOf(default(SLIDER_PARAM));
                    result = (ushort)(num - beg);
                    return result;
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                    result = 0;
                    return result;
                }
            }
            if (this.atts[0].zhi[0] == objtype.OBJECT_TYPE_CURVE)
            {
                CURVE_PARAM cURVE_PARAM = default(CURVE_PARAM);
                CURVE_CHANNEL_PARAM cURVE_CHANNEL_PARAM = default(CURVE_CHANNEL_PARAM);
                try
                {
                    cURVE_PARAM.BackType = (byte)this.GetattVal_string("sta").Getint();
                    if (cURVE_PARAM.BackType == 0)
                    {
                        cURVE_PARAM.PicID = (ushort)this.GetattVal_string("picc").Getint();
                    }
                    else if (cURVE_PARAM.BackType == 2)
                    {
                        cURVE_PARAM.PicID = (ushort)this.GetattVal_string("pic").Getint();
                    }
                    cURVE_PARAM.GridX = (byte)this.GetattVal_string("gdw").Getint();
                    cURVE_PARAM.GridY = (byte)this.GetattVal_string("gdh").Getint();
                    cURVE_PARAM.RefFlag = 0;
                    cURVE_PARAM.CH_qyt = (byte)(this.GetattVal_string("ch").Getint() + 1);
                    cURVE_PARAM.objWid = (ushort)(this.myobj.redian.endx - this.myobj.redian.x + 1);
                    cURVE_PARAM.objHig =(ushort)(this.myobj.redian.endy - this.myobj.redian.y + 1);
                    cURVE_PARAM.Bkclr = (ushort)this.GetattVal_string("bco").Getint();
                    cURVE_PARAM.Griclr = (ushort)this.GetattVal_string("gdc").Getint();
                    cURVE_PARAM.DrawDir = (byte)this.GetattVal_string("dir").Getint();
                    ushort num3;
                    if ((double)cURVE_PARAM.objWid * 0.3 > 120.0)
                    {
                        num3 =(ushort)(cURVE_PARAM.objWid + 120);
                    }
                    else
                    {
                        num3 = (ushort)((double)cURVE_PARAM.objWid * 1.3);
                    }
                    this.atts[5].att.pos = (ushort)(this.myobj.attpos + 11);
                    this.atts[6].att.pos =(ushort)(this.myobj.attpos + 5);
                    this.atts[7].att.pos = (ushort)(this.myobj.attpos + 5);
                    this.atts[8].att.pos = (ushort)(this.myobj.attpos + 13);
                    this.atts[9].att.pos =(ushort)(this.myobj.attpos + 2);
                    this.atts[10].att.pos = (ushort)(this.myobj.attpos + 3);
                    cURVE_PARAM.structToBytes().CopyTo(lbytes, num);
                    num += Marshal.SizeOf(default(CURVE_PARAM));
                    num2 = (ushort)((int)num2 + Marshal.SizeOf(default(CURVE_PARAM)) + Marshal.SizeOf(default(CURVE_CHANNEL_PARAM)) * (int)cURVE_PARAM.CH_qyt);
                    for (int i = 0; i < (int)cURVE_PARAM.CH_qyt; i++)
                    {
                        this.atts[11 + i].att.pos = (ushort)((int)this.myobj.attpos + Marshal.SizeOf(default(CURVE_PARAM)) + Marshal.SizeOf(default(CURVE_CHANNEL_PARAM)) * i + 4);
                        cURVE_CHANNEL_PARAM = default(CURVE_CHANNEL_PARAM);
                        cURVE_CHANNEL_PARAM.BufPos.star = (ushort)((int)num2 + i * (int)num3);
                        cURVE_CHANNEL_PARAM.BufPos.end = (ushort)(cURVE_CHANNEL_PARAM.BufPos.star + num3 - 1);
                        switch (i)
                        {
                            case 0:
                                cURVE_CHANNEL_PARAM.Penclr = (ushort)this.GetattVal_string("pco0").Getint();
                                break;
                            case 1:
                                cURVE_CHANNEL_PARAM.Penclr = (ushort)this.GetattVal_string("pco1").Getint();
                                break;
                            case 2:
                                cURVE_CHANNEL_PARAM.Penclr = (ushort)this.GetattVal_string("pco2").Getint();
                                break;
                            case 3:
                                cURVE_CHANNEL_PARAM.Penclr = (ushort)this.GetattVal_string("pco3").Getint();
                                break;
                        }
                        cURVE_CHANNEL_PARAM.res0 =(ushort)(num3 - 1);
                        cURVE_CHANNEL_PARAM.BufNext = cURVE_CHANNEL_PARAM.BufPos.star;
                        cURVE_CHANNEL_PARAM.DotLen = 0;
                        cURVE_CHANNEL_PARAM.structToBytes().CopyTo(lbytes, num);
                        num += Marshal.SizeOf(default(CURVE_CHANNEL_PARAM));
                    }
                    byte[] array = new byte[(int)(num3 * (ushort)cURVE_PARAM.CH_qyt)];
                    array.CopyTo(lbytes, num);
                    num += array.Length;
                    result = (ushort)(num - beg);
                    return result;
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                    result = 0;
                    return result;
                }
            }
            for (int j = 0; j < this.atts.Count; j++)
            {
                if (this.atts[j].att.isxiugai == 1)
                {
                    if (this.checkatt(this.atts[j]))
                    {
                        if (this.atts[j].att.attlei == attshulei.Sstr.typevalue)
                        {
                            if (this.atts[j].zhi.Length == 0 || this.atts[j].zhi[this.atts[j].zhi.Length - 1] != 0)
                            {
                                Kuozhan.Gethebingbytes(this.atts[j].zhi, "".GetbytesssASCII(1));
                            }
                            if (this.atts[j].zhi.Length > (int)this.atts[j].att.merrylenth)
                            {
                                MessageOpen.Show("属性".Language() + this.atts[j].name.Getstring(datasize.Myencoding) + "初始值大于分配空间".Language());
                                result = 0;
                                return result;
                            }
                            this.atts[j].zhi.CopyTo(lbytes, num);
                            num += this.atts[j].zhi.Length;
                            byte[] array = "".GetbytesssASCII((int)this.atts[j].att.merrylenth - this.atts[j].zhi.Length);
                            array.CopyTo(lbytes, num);
                            num += array.Length;
                        }
                        else
                        {
                            if (this.atts[j].zhi.Length != (int)this.atts[j].att.merrylenth)
                            {
                                MessageOpen.Show("属性".Language() + this.atts[j].name.Getstring(datasize.Myencoding) + "初始值大于分配空间".Language());
                                result = 0;
                                return result;
                            }
                            this.atts[j].zhi.CopyTo(lbytes, num);
                            num += this.atts[j].zhi.Length;
                        }
                        this.atts[j].att.pos = num2;
                        num2 += this.atts[j].att.merrylenth;
                    }
                }
            }
            result = (ushort)(num - beg);
            return result;
        }
    }
}
