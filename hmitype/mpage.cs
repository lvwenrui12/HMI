using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace hmitype
{
    [Serializable]
    public class mpage
    {
        public Myapp_inf Myapp;

        public ButtonItem chexiaobutton;

        public ButtonItem huifubutton;

        public int pageid = 65535;

        public string pagename = "";

        public pagexinxi_up mypage = default(pagexinxi_up);

        public List<byte[]> Codes = new List<byte[]>();

        public List<mobj> objs = new List<mobj>();

        public objsetcom_P dcomp0 = null;

        public objsetcom_P dcomp1 = null;

        public List<objsetcom_P> objsetcomps;

        public int objsetcomindex;

        public List<string> allattnames = new List<string>();

        public byte[] allattbytes;

        public uint attpos;

        private void objsetcom_add(objsetcom_P com)
        {
            if (this.objsetcomps.Count > 0 && this.objsetcomindex < this.objsetcomps.Count - 1)
            {
                if (this.objsetcomindex % 2 != 0)
                {
                    this.objsetcomindex--;
                }
                while (this.objsetcomindex < this.objsetcomps.Count)
                {
                    this.objsetcomps.Remove(this.objsetcomps[this.objsetcomps.Count - 1]);
                }
            }
            this.objsetcomps.Add(com);
            this.objsetcomindex = this.objsetcomps.Count - 1;
        }

        public void starback()
        {
            this.dcomp0 = new objsetcom_P();
            this.dcomp1 = new objsetcom_P();
            this.dcomp0.objset = new List<objsetcom>();
            this.dcomp1.objset = new List<objsetcom>();
        }

        public void endback()
        {
            if (this.dcomp0 != null && this.dcomp0.objset != null)
            {
                if (this.dcomp0.objset.Count > 0)
                {
                    this.objsetcom_add(this.dcomp0);
                    this.objsetcom_add(this.dcomp1);
                }
                this.dcomp0 = new objsetcom_P();
                this.dcomp0 = null;
                this.refbackview();
            }
        }

        public void refbackview()
        {
            try
            {
                if (this.chexiaobutton != null && this.huifubutton != null)
                {
                    this.chexiaobutton.Text = this.chexiaobutton.Text.Split(new char[]
                    {
                        '('
                    })[0] + "(" + (this.objsetcomps.Count / 2 - (this.objsetcomps.Count - this.objsetcomindex) / 2).ToString() + ")";
                    this.huifubutton.Text = this.huifubutton.Text.Split(new char[]
                    {
                        '('
                    })[0] + "(" + ((this.objsetcomps.Count - this.objsetcomindex) / 2).ToString() + ")";
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("refbackview error:" + ex.Message);
            }
        }

        public void refallatt()
        {
            this.allattnames.Clear();
            for (int i = 0; i < this.objs.Count; i++)
            {
                for (int j = 0; j < this.objs[i].atts.Count; j++)
                {
                    if (this.objs[i].checkatt(this.objs[i].atts[j]))
                    {
                        this.allattnames.Add(this.objs[i].objname + "." + this.objs[i].atts[j].name.Getstring(datasize.Myencoding));
                    }
                }
                this.allattnames.Add(this.objs[i].objname + ".id");
                this.allattnames.Add(this.objs[i].objname + ".type");
                if (objtype.getobjmark(this.objs[i].myobj.objType).show > 0)
                {
                    this.allattnames.Add(this.objs[i].objname + ".x");
                    this.allattnames.Add(this.objs[i].objname + ".y");
                    this.allattnames.Add(this.objs[i].objname + ".endx");
                    this.allattnames.Add(this.objs[i].objname + ".endy");
                    this.allattnames.Add(this.objs[i].objname + ".w");
                    this.allattnames.Add(this.objs[i].objname + ".h");
                }
            }
            this.allattbytes = new byte[this.allattnames.Count * datasize.attxinxisize];
        }

        public uint getappattindex(int objid, string attname)
        {
            string b = this.objs[objid].objname + "." + attname;
            uint result;
            for (int i = 0; i < this.allattnames.Count; i++)
            {
                if (this.allattnames[i] == b)
                {
                    result = (uint)((long)i + (long)((ulong)this.attpos));
                    return result;
                }
            }
            result = 0u;
            return result;
        }

        private int getpageattindex(int objid, string attname)
        {
            string b = this.objs[objid].objname + "." + attname;
            int result;
            for (int i = 0; i < this.allattnames.Count; i++)
            {
                if (this.allattnames[i] == b)
                {
                    result = i;
                    return result;
                }
            }
            result = -1;
            return result;
        }

        public bool Allattbytes_set(int objid, string attname, attinf latt)
        {
            int num = this.getpageattindex(objid, attname);
            bool result;
            if (num == -1)
            {
                this.Myapp.Addbianyierr("This attname is invalid!" + this.pagename + "." + attname);
                result = false;
            }
            else
            {
                latt.structToBytes().CopyTo(this.allattbytes, num * datasize.attxinxisize);
                result = this.objs[objid].attpianyiset(attname, (ushort)num);
            }
            return result;
        }

        public bool moveobjid(int index, int newindex)
        {
            bool result;
            if (index >= this.objs.Count || newindex >= this.objs.Count || index == newindex)
            {
                result = false;
            }
            else
            {
                objsetcom item = default(objsetcom);
                objsetcom item2 = default(objsetcom);
                if (this.dcomp0 != null)
                {
                    this.dcomp0.Refpage = true;
                    this.dcomp1.Refpage = true;
                    item2.lei = "moveobjid";
                    item2.id = index;
                    item2.Tag = newindex.ToString();
                    item.lei = "moveobjid";
                    item.id = newindex;
                    item.Tag = index.ToString();
                    this.dcomp0.objset.Add(item);
                    this.dcomp1.objset.Add(item2);
                }
                mobj item3 = this.objs[index];
                this.objs.Remove(item3);
                if (newindex == this.objs.Count)
                {
                    this.objs.Add(item3);
                }
                else
                {
                    this.objs.Insert(newindex, item3);
                }
                this.Myapp.RefobjID(this);
                result = true;
            }
            return result;
        }

        public void delobj(int index)
        {
            if (index < this.objs.Count)
            {
                objsetcom item = default(objsetcom);
                objsetcom item2 = default(objsetcom);
                if (this.dcomp0 != null)
                {
                    item2.lei = "delobj";
                    item2.id = index;
                    if (index == this.objs.Count - 1)
                    {
                        item.lei = "addobj";
                        item.id = 65535;
                    }
                    else
                    {
                        item.lei = "insertobj";
                        item.id = index;
                    }
                    item.backobj = this.objs[index].copyobj();
                    this.dcomp0.objset.Add(item);
                    this.dcomp1.objset.Add(item2);
                }
                this.objs.Remove(this.objs[index]);
                this.Myapp.RefobjID(this);
            }
        }

        public void addobj(mobj obj)
        {
            objsetcom item = default(objsetcom);
            objsetcom item2 = default(objsetcom);
            if (this.dcomp0 != null)
            {
                item2.lei = "addobj";
                item2.id = 65535;
                item2.backobj = obj.copyobj();
                item.lei = "delobj";
                item.id = this.objs.Count;
                this.dcomp0.objset.Add(item);
                this.dcomp1.objset.Add(item2);
            }
            this.objs.Add(obj);
            this.Myapp.RefobjID(this);
        }

        public void insertobj(int index, mobj obj)
        {
            if (index < this.objs.Count)
            {
                objsetcom item = default(objsetcom);
                objsetcom item2 = default(objsetcom);
                if (this.dcomp0 != null)
                {
                    item2.lei = "insertobj";
                    item2.id = index;
                    item2.backobj = obj.copyobj();
                    item.lei = "delobj";
                    item.id = this.objs.Count;
                    this.dcomp0.objset.Add(item);
                    this.dcomp1.objset.Add(item2);
                }
                this.objs.Insert(index, obj);
                this.Myapp.RefobjID(this);
            }
        }

        public void changobjxy(int index, int x, int y)
        {
            this.changobjxy(index, x, y, (int)(this.objs[index].myobj.redian.endx - this.objs[index].myobj.redian.x + 1), (int)(this.objs[index].myobj.redian.endy - this.objs[index].myobj.redian.y + 1));
        }

        public void changobjxy(int index, int x, int y, int w, int h)
        {
            this.changobjattch(index, "x", x.ToString());
            this.changobjattch(index, "y", y.ToString());
            this.changobjattch(index, "w", w.ToString());
            this.changobjattch(index, "h", h.ToString());
        }

        public bool changobjattch(int index, string attname, string newstr)
        {
            bool result;
            try
            {
                if (index >= this.objs.Count)
                {
                    result = false;
                }
                else
                {
                    string text = this.objs[index].GetattVal_string(attname);
                    if (!this.objs[index].Setattval(attname, newstr))
                    {
                        result = false;
                    }
                    else
                    {
                        matt matt = this.objs[index].Getatt(attname);
                        if (matt != null)
                        {
                            if (matt.att.isbangding == 1 && matt.att.attlei == attshulei.Picid.typevalue && newstr != "65535")
                            {
                                this.changobjxy(this.objs[index].objid, (int)this.objs[index].myobj.redian.x, (int)this.objs[index].myobj.redian.y, (int)this.Myapp.images[newstr.Getint()].picturexinxi.W, (int)this.Myapp.images[newstr.Getint()].picturexinxi.H);
                            }
                            else if (this.objs[index].atts[0].zhi[0] == objtype.OBJECT_TYPE_SLIDER)
                            {
                                if (attname == "pic2" && newstr != "65535")
                                {
                                    string arg_1D1_2 = "wid";
                                    ushort num = this.Myapp.images[newstr.Getint()].picturexinxi.W;
                                    if (!this.changobjattch(index, arg_1D1_2, num.ToString()))
                                    {
                                        int num2 = (int)(this.objs[index].myobj.redian.endx - this.objs[index].myobj.redian.x + 1);
                                        if (num2 > 255)
                                        {
                                            num2 = 255;
                                        }
                                        this.changobjattch(index, "wid", num2.ToString());
                                    }
                                    string arg_273_2 = "hig";
                                    num = this.Myapp.images[newstr.Getint()].picturexinxi.H;
                                    if (!this.changobjattch(index, arg_273_2, num.ToString()))
                                    {
                                        int num2 = (int)(this.objs[index].myobj.redian.endy - this.objs[index].myobj.redian.y + 1);
                                        if (num2 > 255)
                                        {
                                            num2 = 255;
                                        }
                                        this.changobjattch(index, "hig", num2.ToString());
                                    }
                                }
                                else
                                {
                                    int num2 = (int)(this.objs[index].myobj.redian.endx - this.objs[index].myobj.redian.x + 1);
                                    if (this.objs[index].GetattVal_string("wid").Getint() > num2)
                                    {
                                        if (num2 > 255)
                                        {
                                            num2 = 255;
                                        }
                                        this.changobjattch(index, "wid", num2.ToString());
                                    }
                                    num2 = (int)(this.objs[index].myobj.redian.endy - this.objs[index].myobj.redian.y + 1);
                                    if (this.objs[index].GetattVal_string("hig").Getint() > num2)
                                    {
                                        if (num2 > 255)
                                        {
                                            num2 = 255;
                                        }
                                        this.changobjattch(index, "hig", num2.ToString());
                                    }
                                }
                            }
                        }
                        if (text == newstr)
                        {
                            result = true;
                        }
                        else
                        {
                            if (this.dcomp0 != null)
                            {
                                objsetcom item = default(objsetcom);
                                objsetcom item2 = default(objsetcom);
                                item2.lei = "attch";
                                item2.id = index;
                                item2.attname = attname;
                                item2.attval = newstr;
                                item.lei = "attch";
                                item.id = index;
                                item.attname = attname;
                                item.attval = text;
                                this.dcomp0.objset.Add(item);
                                this.dcomp1.objset.Add(item2);
                            }
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
                result = false;
            }
            return result;
        }

        public int jiancechongdie(int x, int y, int endx, int endy, mobj paichuobj)
        {
            int result;
            if (x < 0 || y < 0 || endx < 0 || endy < 0)
            {
                result = -1;
            }
            else if (x >= (int)this.Myapp.lcdwidth || y >= (int)this.Myapp.lcdwidth || endx >= (int)this.Myapp.lcdwidth || endy >= (int)this.Myapp.lcdheight)
            {
                result = -1;
            }
            else
            {
                for (int i = this.objs.Count - 1; i > 0; i--)
                {
                    if (this.objs[i] != paichuobj && objtype.getobjmark(this.objs[i].myobj.objType).show == 1)
                    {
                        if ((int)this.objs[i].myobj.redian.x == x && (int)this.objs[i].myobj.redian.y == y && (int)this.objs[i].myobj.redian.endx == endx && (int)this.objs[i].myobj.redian.endy == endy)
                        {
                            result = i;
                            return result;
                        }
                    }
                }
                result = 0;
            }
            return result;
        }

        public bool Getobjnamecrcbytes(ref byte[] bt)
        {
            int num = Marshal.SizeOf(default(nameidtypecrc));
            List<nameidtypecrc> list = new List<nameidtypecrc>();
            List<string> list2 = new List<string>();
            bool result;
            for (int i = 0; i < this.objs.Count; i++)
            {
                nameidtypecrc item = default(nameidtypecrc);
                item.crc = this.objs[i].objname.GetbytesssASCII(14).getcrc(0);
                item.id = (ushort)i;
                int j;
                for (j = 0; j < list.Count; j++)
                {
                    if (item.crc < list[j].crc)
                    {
                        list2.Insert(j, this.objs[i].objname);
                        list.Insert(j, item);
                        j = 65535;
                    }
                    else if (item.crc == list[j].crc)
                    {
                        this.Myapp.Addbianyierr(string.Concat(new string[]
                        {
                            "名称非法(CRC重复):".Language(),
                            this.pagename,
                            ":",
                            list2[j],
                            "-",
                            this.objs[i].objname
                        }));
                        result = false;
                        return result;
                    }
                }
                if (j == 0 || j == list.Count)
                {
                    list.Add(item);
                    list2.Add(this.objs[i].objname);
                }
            }
            bt = new byte[num * list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                list[i].structToBytes().CopyTo(bt, i * num);
            }
            result = true;
            return result;
        }

        public List<byte> Getjiaochaobjs(int index)
        {
            List<byte> list = new List<byte>();
            if (index > 0 && index < this.objs.Count)
            {
                for (int i = 1; i < this.objs.Count; i++)
                {
                    if (i != index && objtype.getobjmark(this.objs[i].atts[0].zhi[0]).show != 0)
                    {
                        if (Kuozhan.checkbaohan((int)this.objs[i].myobj.redian.x, (int)this.objs[i].myobj.redian.y, (int)this.objs[i].myobj.redian.endx, (int)this.objs[i].myobj.redian.endy, (int)this.objs[index].myobj.redian.x, (int)this.objs[index].myobj.redian.y, (int)this.objs[index].myobj.redian.endx, (int)this.objs[index].myobj.redian.endy))
                        {
                            list.Add((byte)i);
                        }
                    }
                }
            }
            return list;
        }

        public List<byte> Getguanlianobjs(int index)
        {
            List<byte> list = new List<byte>();
            list.Add((byte)index);
            this.guanlianobjs(ref list, index);
            for (int i = 0; i < list.Count; i++)
            {
                if ((int)list[i] == index)
                {
                    list.Remove(list[i]);
                    i--;
                }
            }
            return list;
        }

        private void guanlianobjs(ref List<byte> mobjs, int index)
        {
            List<byte> list = this.Getjiaochaobjs(index);
            foreach (byte current in list)
            {
                if ((int)current != index && this.AddListU8s(ref mobjs, (int)current))
                {
                    this.guanlianobjs(ref mobjs, (int)current);
                }
            }
        }

        private bool AddListU8s(ref List<byte> mobjs, int index)
        {
            bool flag = false;
            bool result;
            for (int i = mobjs.Count - 1; i > -1; i--)
            {
                if (index > (int)mobjs[i])
                {
                    if (i < mobjs.Count - 1)
                    {
                        mobjs.Insert(i + 1, (byte)index);
                        flag = true;
                    }
                    break;
                }
                if (index == (int)mobjs[i])
                {
                    result = false;
                    return result;
                }
            }
            if (!flag)
            {
                mobjs.Add((byte)index);
            }
            result = true;
            return result;
        }

        public mpage(Myapp_inf app)
        {
            this.Myapp = app;
            this.objsetcomps = new List<objsetcom_P>();
            this.objsetcomindex = 0;
            this.dcomp0 = null;
            this.dcomp1 = null;
        }

        public int Getobjid(string str)
        {
            int result;
            for (int i = 0; i < this.objs.Count; i++)
            {
                if (this.objs[i].objname == str)
                {
                    result = i;
                    return result;
                }
            }
            result = 65535;
            return result;
        }

        private bool objjiance(mobj dobj)
        {
            bool result = true;
            if (dobj.myobj.redian.x < 0 || dobj.myobj.redian.endx >= this.Myapp.lcdwidth || dobj.myobj.redian.y < 0 || dobj.myobj.redian.endy >= this.Myapp.lcdheight)
            {
                this.Myapp.Addbianyierr(string.Concat(new string[]
                {
                    "页面:".Language(),
                    this.pagename,
                    " ",
                    "失败:".Language(),
                    dobj.objname,
                    " ",
                    "坐标无效".Language()
                }));
                result = false;
            }
            for (int i = 0; i < dobj.atts.Count; i++)
            {
                if (dobj.checkatt(dobj.atts[i]))
                {
                    string text = dobj.checkattval(dobj.atts[i]);
                    if (text != "")
                    {
                        this.Myapp.Addbianyierr(string.Concat(new string[]
                        {
                            "页面:".Language(),
                            this.pagename,
                            " ",
                            "失败:".Language(),
                            dobj.objname,
                            ".",
                            dobj.atts[i].name.Getstring(datasize.Myencoding),
                            " ",
                            "初始值无效:".Language(),
                            text
                        }));
                        result = false;
                    }
                }
            }
            return result;
        }

        public bool bianyi()
        {
            List<int> list = new List<int>();
            List<byte[]> list2 = new List<byte[]>();
            byte[] item = new byte[0];
            this.Codes.Clear();
            bool result;
            try
            {
                int num = this.Myapp.databianyi.PrivateMemorys[this.pageid].Length + this.Myapp.databianyi.PublicMemorys.Length;
                if (num > this.Myapp.Model.RAM)
                {
                    this.Myapp.Addbianyierr(string.Concat(new string[]
                    {
                        "页面:".Language(),
                        this.pagename,
                        " ",
                        "失败! 内存溢出:".Language(),
                        this.Myapp.databianyi.PublicMemorys.Length.ToString(),
                        "+",
                        this.Myapp.databianyi.PrivateMemorys[this.pageid].Length.ToString(),
                        "=",
                        num.ToString()
                    }));
                    result = false;
                }
                else if (this.objs.Count > 251)
                {
                    this.Myapp.Addbianyierr("页面:".Language() + this.pagename + " " + "控件数量超过最大值".Language());
                    result = false;
                }
                else if (!this.Getobjnamecrcbytes(ref item))
                {
                    result = false;
                }
                else
                {
                    this.Codes.Add(item);
                    for (int i = 0; i < this.objs.Count; i++)
                    {
                        if (i > 0 && objtype.getobjmark(this.objs[i].myobj.objType).show == 1)
                        {
                            int num2 = this.jiancechongdie((int)this.objs[i].myobj.redian.x, (int)this.objs[i].myobj.redian.y, (int)this.objs[i].myobj.redian.endx, (int)this.objs[i].myobj.redian.endy, this.objs[i]);
                            if (num2 > 0)
                            {
                                if (!list.Contains(num2))
                                {
                                    this.Myapp.Addbianyijinggao(string.Concat(new string[]
                                    {
                                        "控件重叠:".Language(),
                                        " ",
                                        this.pagename,
                                        ":",
                                        this.objs[i].objname,
                                        "&",
                                        this.objs[num2].objname
                                    }));
                                }
                                list.Add(i);
                            }
                        }
                        if (!this.objjiance(this.objs[i]))
                        {
                        }
                    }
                    this.Codes.Add(this.Myapp.databianyi.PrivateMemorys[this.pageid]);
                    list2.Clear();
                    for (int j = 0; j < this.objs.Count; j++)
                    {
                        this.objs[j].Getbianyi(ref list2, 1, true, 2);
                    }
                    this.Codes.AddListBytes(list2);
                    int num3 = 0;
                    for (int j = 0; j < this.objs.Count; j++)
                    {
                        if (this.objs[j].myobj.objType == objtype.OBJECT_TYPE_CURVE)
                        {
                            if (num3 < 255)
                            {
                                num3++;
                                if (num3 > 5)
                                {
                                    this.Myapp.Addbianyierr("页面:".Language() + this.pagename + " " + "失败! 曲线控件数量大于5".Language());
                                    num3 = 255;
                                }
                            }
                        }
                    }
                    list2.Clear();
                    this.objs[0].Getbianyi(ref list2, 2, false, 0);
                    this.Codes.AddListBytes(list2);
                    list2.Clear();
                    for (int j = 0; j < this.objs.Count; j++)
                    {
                        int num2 = this.objs[j].Getbianyi(ref list2, 2, false, 1);
                        if (num2 > 0)
                        {
                            byte[] item2 = new byte[0];
                            this.objs[j].bianyionline("ifload " + j.ToString() + "," + num2.ToString(), ref item2, "", default(bianyijieguotype));
                            list2.Insert(list2.Count - num2, item2);
                        }
                    }
                    this.Codes.AddListBytes(list2);
                    list2.Clear();
                    this.objs[0].Getbianyi(ref list2, 3, false, 0);
                    this.Codes.AddListBytes(list2);
                    this.Codes.Add("E".GetbytesssASCII());
                    if (this.Myapp.errors == 0)
                    {
                        this.Myapp.addbianyisuc(string.Concat(new string[]
                        {
                            "页面:".Language(),
                            this.pagename,
                            " ",
                            "占用内存:".Language(),
                            this.Myapp.databianyi.PublicMemorys.Length.ToString(),
                            "+",
                            this.Myapp.databianyi.PrivateMemorys[this.pageid].Length.ToString(),
                            "=",
                            num.ToString()
                        }));
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Myapp.Addbianyierr("error:" + ex.Message);
                result = false;
            }
            return result;
        }
    }
}
