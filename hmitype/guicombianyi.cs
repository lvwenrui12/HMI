using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace hmitype
{
    public static class guicombianyi
    {
        private static mobj dobj;

        public static byte errcode;

        public static string errmessage = "";

        public static string jinggaostr = "";

        public static List<hexreplace_type> hexreplace = new List<hexreplace_type>();

        private static void hexattreplaceadd(hexreplace_type hex1)
        {
            int i = 0;
            while (i < guicombianyi.hexreplace.Count)
            {
                if (hex1.beg < guicombianyi.hexreplace[i].beg)
                {
                    guicombianyi.hexreplace.Insert(i, hex1);
                }
                else if (hex1.beg != guicombianyi.hexreplace[i].beg)
                {
                    i++;
                    continue;
                }
                return;
            }
            guicombianyi.hexreplace.Add(hex1);
        }

        private unsafe static ushort Getpageid(byte* buf, PosLaction* bufpos)
        {
            PosLaction posLaction = default(PosLaction);
            ushort result;
            if (buf[bufpos->star] == 112 && buf[bufpos->star + 1] == 91 && buf[bufpos->end] == 93)
            {
                posLaction.star = (ushort)(bufpos->star + 2);
                posLaction.end =(ushort)(bufpos->end - 1);
                byte b;
                int num = guicombianyi.strgetS32(buf, &posLaction, &b);
                if (b == 0)
                {
                    result = 65535;
                }
                else
                {
                    result = (ushort)num;
                }
            }
            else
            {
                result = (ushort)guicombianyi.dobj.Mypage.Myapp.Getpagename((*bufpos).PosByteGetstring(buf));
            }
            return result;
        }

        private unsafe static ushort Getobjid(byte* buf, PosLaction* bufpos, mpage page)
        {
            PosLaction posLaction = default(PosLaction);
            ushort result;
            if (buf[bufpos->star] == 98 && buf[bufpos->star + 1] == 91 && buf[bufpos->end] == 93)
            {
                posLaction.star = (ushort)(bufpos->star + 2);
                posLaction.end =(ushort)(bufpos->end - 1);
                byte b;
                int num = guicombianyi.strgetS32(buf, &posLaction, &b);
                if (b == 0)
                {
                    result = 65535;
                }
                else
                {
                    result = (ushort)num;
                }
            }
            else
            {
                result = (ushort)page.Getobjid((*bufpos).PosByteGetstring(buf));
            }
            return result;
        }

        private unsafe static byte setatt(ref runattinf b1, ref runattinf b2, byte yunsuan)
        {
            fixed (runattinf* runattinfRef = (&b1))
            {
                fixed (runattinf* runattinfRef2 = (&b2))
                {
                    return setatt(runattinfRef, runattinfRef2, yunsuan);
                }
            }

        }

        private unsafe static byte setatt(runattinf* b1, runattinf* b2, byte yunsuan)
        {
            byte result;
            if (b2->isxiugai == 1)
            {
                if (b2->attlei != attshulei.Sstr.typevalue && b1->attlei != attshulei.Sstr.typevalue && yunsuan == 0)
                {
                    if (b2->datafrom != 200)
                    {
                        result = 1;
                        return result;
                    }
                }
                else if (b2->attlei == attshulei.Sstr.typevalue && b1->attlei == attshulei.Sstr.typevalue && b2->datafrom == 254)
                {
                    result = 1;
                    return result;
                }
            }
            guicombianyi.errcode = 28;
            result = 0;
            return result;
        }

        private unsafe static void Getsysname(byte* buf, PosLaction* bufpos, runattinf* att)
        {
            byte b = (byte)(bufpos->end - bufpos->star + 1);
            if (b < 5)
            {
                uint num = 0u;
                Kuozhan.memcpy((byte*)(&num), buf + bufpos->star, (int)b);
                fixed (void* ptr = (&Sysatt.xitong32[0]))
                {
                    num = Datafind.Datafind_FindU32_Memory(&num, (uint*)ptr, Sysatt.xitong32qyt, (uint)(Marshal.SizeOf(default(xitongtype_32)) / 4));
                }
                if (num != 65535u)
                {
                    att->val = 0;
                    att->datafrom = Sysatt.xitong32[(int)((UIntPtr)num)].mark;
                    att->attlei = attshulei.SS32.typevalue;
                    att->att.merrylenth = 4;
                    att->att.maxval = 2147483647;
                    att->att.minval = -2147483648;
                    att->isxiugai = 1;
                    hexreplace_type hex = default(hexreplace_type);
                    hex.beg = (int)bufpos->star;
                    hex.qyt = (int)b;
                    hex.bytes = new byte[5];
                    hex.bytes[0] = 4;
                    hex.bytes[1] = 4;
                    hex.bytes[2] = (byte)num;
                    guicombianyi.hexattreplaceadd(hex);
                }
            }
            else if (b < 9)
            {
                ulong num2 = 0uL;
                Kuozhan.memcpy((byte*)(&num2), buf + bufpos->star, (int)b);
                uint num;
                fixed (void* ptr =(&Sysatt.xitong64[0]))
                {
                    num = Datafind.Datafind_FindU64_Memory(&num2, (uint*)ptr, Sysatt.xitong64qyt, (uint)(Marshal.SizeOf(default(xitongtype_64)) / 4));
                }
                if (num != 65535u)
                {
                    att->val = 0;
                    att->datafrom = Sysatt.xitong64[(int)((UIntPtr)num)].mark;
                    att->attlei = attshulei.SS32.typevalue;
                    att->att.merrylenth = 4;
                    att->att.maxval = 2147483647;
                    att->att.minval = -2147483648;
                    att->isxiugai = 1;
                    hexreplace_type hex = default(hexreplace_type);
                    hex.beg = (int)bufpos->star;
                    hex.qyt = (int)b;
                    hex.bytes = new byte[5];
                    hex.bytes[0] = 4;
                    hex.bytes[1] = 8;
                    hex.bytes[2] = (byte)num;
                    guicombianyi.hexattreplaceadd(hex);
                }
            }
        }

        private unsafe static void Getatt(byte* buf, PosLaction* bufpos, runattinf* att)
        {
            hexreplace_type hex = default(hexreplace_type);
            PosLaction pos = default(PosLaction);
            uint num = 0u;
            ushort num2 = 0;
            ushort num3 = 0;
            att->datafrom = 255;
            att->isref = 0;
            if (buf[bufpos->star] != 46)
            {
                for (uint num4 = (uint)bufpos->star; num4 <= (uint)bufpos->end; num4 += 1u)
                {
                    if (buf[num4] < 9)
                    {
                        num4 += 5u;
                    }
                    if (buf[num4] == 46 && num != 1u)
                    {
                        if (num2 == 0)
                        {
                            num2 = (ushort)((byte)num4);
                        }
                        else
                        {
                            if (num3 != 0)
                            {
                                return;
                            }
                            num3 = (ushort)((byte)num4);
                        }
                    }
                    else if (buf[num4] == 91)
                    {
                        num = 1u;
                    }
                    else if (buf[num4] == 93)
                    {
                        num = 2u;
                    }
                }
                if (num2 == 0)
                {
                    guicombianyi.Getsysname(buf, bufpos, att);
                }
                else
                {
                    pos.star = bufpos->star;
                    pos.end =(ushort)(num2 - 1);
                    ushort num5;
                    ushort num6;
                    if (num3 > 0)
                    {
                        num5 = guicombianyi.Getpageid(buf, &pos);
                        if (num5 == 65535)
                        {
                            return;
                        }
                        pos.star =(ushort)(num2 + 1);
                        pos.end =(ushort)(num3 - 1);
                        if ((int)num5 == guicombianyi.dobj.Mypage.pageid || num == 2u)
                        {
                            num6 = guicombianyi.Getobjid(buf, &pos, guicombianyi.dobj.Mypage);
                        }
                        else
                        {
                            num6 = guicombianyi.Getobjid(buf, &pos, guicombianyi.dobj.Mypage.Myapp.pages[(int)num5]);
                        }
                        pos.star =(ushort)(num3 + 1);
                    }
                    else
                    {
                        num5 = (ushort)guicombianyi.dobj.Mypage.pageid;
                        num6 = guicombianyi.Getobjid(buf, &pos, guicombianyi.dobj.Mypage);
                        pos.star =(ushort)(num2 + 1);
                    }
                    pos.end = bufpos->end;
                    if (num6 != 65535 && pos.star <= pos.end)
                    {
                        if (buf[pos.star] == 116 && buf[pos.star + pos.end - pos.star] == 108)
                        {
                            buf[pos.star] = buf[pos.star];
                        }
                        num2 = (ushort)Attmake.Attmake_GetAttindex(buf + pos.star, (byte)(pos.end - pos.star + 1));
                        if (num2 != 255)
                        {
                            if (num != 2u)
                            {
                                hex.bytes = new byte[5];
                                hex.bytes[0] = 1;
                                hex.beg = (int)bufpos->star;
                                hex.qyt = (int)(bufpos->end - bufpos->star + 1);
                                string text = pos.PosByteGetstring(buf);
                                matt matt = new matt();
                                byte encodeh_star = 0;
                                matt matt2 = guicombianyi.dobj.Getatt("font");
                                if (matt2 != null && guicombianyi.dobj.checkatt(matt2))
                                {
                                    if ((int)matt2.zhi[0] < guicombianyi.dobj.Myapp.zimos.Count)
                                    {
                                        encodeh_star = guicombianyi.dobj.Myapp.zimos[(int)matt2.zhi[0]].codeh_star;
                                    }
                                }
                                if ((int)num5 != guicombianyi.dobj.Mypage.pageid)
                                {
                                    num3 = (ushort)guicombianyi.dobj.Mypage.Myapp.pages[(int)num5].objs[(int)num6].GetattVal_byte("vscope")[0];
                                    if (num3 != 1)
                                    {
                                        return;
                                    }
                                    matt = guicombianyi.dobj.Mypage.Myapp.pages[(int)num5].objs[(int)num6].Getatt(text);
                                    if (matt == null)
                                    {
                                        return;
                                    }
                                    if (!guicombianyi.dobj.Mypage.Myapp.pages[(int)num5].objs[(int)num6].checkatt(matt))
                                    {
                                        return;
                                    }
                                    matt.att.attinfUpToDown(ref att->att, encodeh_star);
                                }
                                else
                                {
                                    matt = guicombianyi.dobj.Mypage.objs[(int)num6].Getatt(text);
                                    if (matt == null)
                                    {
                                        return;
                                    }
                                    if (!guicombianyi.dobj.Mypage.objs[(int)num6].checkatt(matt))
                                    {
                                        return;
                                    }
                                    matt.att.attinfUpToDown(ref att->att, encodeh_star);
                                }
                                guicombianyi.dobj.Myapp.pages[(int)num5].getappattindex((int)num6, text).structToBytes().CopyTo(hex.bytes, 1);
                                guicombianyi.hexattreplaceadd(hex);
                                att->attlei = (byte)(att->att.state & 15);
                                if ((att->att.state & 16) > 0)
                                {
                                    att->datafrom = 254;
                                    att->isxiugai = 1;
                                }
                                else
                                {
                                    att->isxiugai = 0;
                                    if (att->attlei != attshulei.Sstr.typevalue)
                                    {
                                        att->datafrom = 253;
                                    }
                                    else
                                    {
                                        att->datafrom = 252;
                                    }
                                }
                            }
                            else
                            {
                                if (Strmake.Strmake_Makestr(buf + pos.star, "txt", 3) == 1 && Strmake.Strmake_Makestr(buf + pos.star, "txt_", 4) != 1)
                                {
                                    att->attlei = attshulei.Sstr.typevalue;
                                }
                                else
                                {
                                    att->attlei = attshulei.SS32.typevalue;
                                }
                                att->isxiugai = 1;
                            }
                            att->datafrom = 254;
                        }
                    }
                }
            }
        }

        private unsafe static byte attadd(byte* buf, ref runattinf b1, ref runattinf b2, ref runattinf b3, byte yunsuan)
        {
            //return guicombianyi.attadd(buf, &b1, &b2, &b3, yunsuan);
            fixed (runattinf* runattinfRef = (&b1))
            {
                fixed (runattinf* runattinfRef2 = (&b2))
                {
                    fixed (runattinf* runattinfRef3 = (&b3))
                    {
                        return attadd(buf, runattinfRef, runattinfRef2, runattinfRef3, yunsuan);
                    }
                }
            }

        }

        private unsafe static byte attadd(byte* buf, runattinf* b1, runattinf* b2, runattinf* b3, byte yunsuan)
        {
            byte result;
            if (b1->attlei == attshulei.Sstr.typevalue && b2->attlei == attshulei.Sstr.typevalue && b3->attlei == attshulei.Sstr.typevalue && yunsuan == 43)
            {
                if (b1->datafrom == 254 && b1->Pz == b3->Pz)
                {
                    if (guicombianyi.setatt(b2, b3, yunsuan) > 0)
                    {
                        result = 1;
                        return result;
                    }
                }
                else if (b2->datafrom == 254 && b2->Pz == b3->Pz)
                {
                    if (guicombianyi.setatt(b1, b3, yunsuan) > 0)
                    {
                        result = 1;
                        return result;
                    }
                }
                else
                {
                    if (guicombianyi.setatt(b1, b3, 0) == 0)
                    {
                        result = 0;
                        return result;
                    }
                    if (guicombianyi.setatt(b2, b3, yunsuan) > 0)
                    {
                        result = 1;
                        return result;
                    }
                }
            }
            else
            {
                if (b2->attlei != attshulei.Sstr.typevalue && b3->attlei == attshulei.Sstr.typevalue && (yunsuan == 45 || (yunsuan == 43 && b2->val < 0)))
                {
                    result = 1;
                    return result;
                }
                if (b1->attlei != attshulei.Sstr.typevalue && b2->attlei != attshulei.Sstr.typevalue && b3->attlei != attshulei.Sstr.typevalue)
                {
                    if (yunsuan == 43)
                    {
                        b3->val = b1->val + b2->val;
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 45)
                    {
                        b3->val = b1->val - b2->val;
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 42)
                    {
                        b3->val = b1->val * b2->val;
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 47)
                    {
                        b3->val = ((b2->val == 0) ? 0 : (b1->val / b2->val));
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 37)
                    {
                        b3->val = b1->val % b2->val;
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 124)
                    {
                        b3->val = (b1->val | b2->val);
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 38)
                    {
                        b3->val = (b1->val & b2->val);
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 60)
                    {
                        b3->val = b1->val << b2->val;
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                    if (yunsuan == 62)
                    {
                        b3->val = b1->val >> b2->val;
                        result = guicombianyi.setatt(b3, b3, 0);
                        return result;
                    }
                }
            }
            guicombianyi.errcode = 27;
            result = 0;
            return result;
        }

        private unsafe static ushort getstratt(byte* buf, ref PosLaction thispos, ref runattinf att)
        {
            ushort result;
            fixed (PosLaction* ptr = &thispos)
            {
                fixed (runattinf* ptr2 = &att)
                {
                    result = guicombianyi.getstratt(buf, ptr, ptr2);
                }
            }
            return result;
        }

        private unsafe static ushort getstratt(byte* buf, PosLaction* bufpos, runattinf* att)
        {
            ushort num = bufpos->star;
            PosLaction pos = default(PosLaction);
            att->datafrom = 255;
            att->isref = 0;
            ushort result;
            if (bufpos->end < bufpos->star)
            {
                guicombianyi.errcode = 26;
                result = 65535;
            }
            else if (buf[num] == 34)
            {
                buf[num] = 0;
                num += 1;
                ushort num2 = 65535;
                ushort num3 = num;
                while (num <= bufpos->end)
                {
                    if (buf[num] == 92)
                    {
                        if (num == bufpos->end)
                        {
                            guicombianyi.errcode = 32;
                            result = 65535;
                            return result;
                        }
                        num += 1;
                        if (buf[num] == 92 || buf[num] == 34)
                        {
                            buf[num3] = buf[num];
                        }
                        else
                        {
                            if (buf[num] != 114)
                            {
                                guicombianyi.errcode = 32;
                                result = 65535;
                                return result;
                            }
                            buf[num3] = 13;
                            num3 += 1;
                            buf[num3] = 10;
                        }
                        if (num == bufpos->end)
                        {
                            guicombianyi.errcode = 32;
                            result = 65535;
                            return result;
                        }
                        num += 1;
                        num3 += 1;
                    }
                    else
                    {
                        buf[num3] = buf[num];
                        if (buf[num] == 34)
                        {
                            buf[num3] = 0;
                            num2 = num;
                            break;
                        }
                        num += 1;
                        num3 += 1;
                    }
                }
                if (num2 != 65535)
                {
                    att->att.pos = (ushort)(bufpos->star + 1);
                    att->attlei = attshulei.Sstr.typevalue;
                    att->att.merrylenth = (ushort)(num3 - bufpos->star);
                    att->datafrom = 253;
                    att->isxiugai = 0;
                    att->Pz = buf + att->att.pos;
                    result = num2;
                }
                else
                {
                    guicombianyi.errcode = 26;
                    result = 65535;
                }
            }
            else if (buf[num] == 45 || (buf[num] > 47 && buf[num] < 58))
            {
                if (buf[num] == 45)
                {
                    num += 1;
                }
                while (num <= bufpos->end)
                {
                    if (buf[num] < 48 || buf[num] > 57)
                    {
                        num -= 1;
                        break;
                    }
                    if (num == bufpos->end)
                    {
                        break;
                    }
                    num += 1;
                }
                att->att.merrylenth = 4;
                att->val = Strmake.Strmake_StrToS32(buf + bufpos->star, (byte)(num - bufpos->star + 1));
                att->attlei = attshulei.SS32.typevalue;
                att->datafrom = 253;
                att->isxiugai = 0;
                hexreplace_type hex = default(hexreplace_type);
                hex.beg = (int)bufpos->star;
                hex.qyt = (int)(num - bufpos->star + 1);
                if (hex.qyt > 3 && Strmake.Strmake_Makestr(buf, "I ", 2) != 1)
                {
                    hex.bytes = new byte[5];
                    hex.bytes[0] = 3;
                    att->val.structToBytes().CopyTo(hex.bytes, 1);
                    guicombianyi.hexattreplaceadd(hex);
                }
                result = num;
            }
            else
            {
                pos.star = bufpos->star;
                if (Strmake.Strmake_IsAttendbyte(buf[num]) == 1)
                {
                    guicombianyi.errcode = 26;
                    result = 65535;
                }
                else
                {
                    int num4 = 0;
                    if (num > bufpos->end)
                    {
                        guicombianyi.errcode = 26;
                        result = 65535;
                    }
                    else
                    {
                        ushort num2 = 0;
                        while (num <= bufpos->end)
                        {
                            if (buf[num] < 9)
                            {
                                num2 += 5;
                                num += 5;
                            }
                            if (num4 == 0 && Strmake.Strmake_IsAttendbyte(buf[num]) == 1)
                            {
                                num -= 1;
                                break;
                            }
                            if (buf[num] == 91)
                            {
                                num4++;
                            }
                            else if (buf[num] == 93)
                            {
                                num4--;
                            }
                            if (num2 == 49)
                            {
                                guicombianyi.errcode = 35;
                                result = 65535;
                                return result;
                            }
                            num2 += 1;
                            num += 1;
                        }
                        if (num > bufpos->end)
                        {
                            num = bufpos->end;
                        }
                        pos.end = num;
                        guicombianyi.Getatt(buf, &pos, att);
                        if (att->datafrom == 255)
                        {
                            guicombianyi.errcode = 26;
                            if (guicombianyi.errmessage == "")
                            {
                                guicombianyi.errmessage = pos.PosByteGetstring(buf);
                            }
                            result = 65535;
                        }
                        else
                        {
                            result = num;
                        }
                    }
                }
            }
            return result;
        }

        private unsafe static int strgetu32(byte* buf, ref PosLaction pos, byte* back, bool isaddnewcom)
        {
            int result;
            fixed (PosLaction* ptr = &pos)
            {
                result = guicombianyi.strgetS32(buf, ptr, back);
            }
            return result;
        }

        private unsafe static int strgetS32(byte* buf, PosLaction* pos, byte* back)
        {
            runattinf[] array = new runattinf[2];
            *back = 1;
            ushort num = guicombianyi.getstratt(buf, ref *pos, ref array[1]);
            int result;
            if (array[1].datafrom == 255)
            {
                *back = 0;
                result = 0;
            }
            else if (array[1].attlei == attshulei.Sstr.typevalue)
            {
                *back = 0;
                guicombianyi.errcode = 27;
                result = 0;
            }
            else if (num >= pos->end)
            {
                result = array[1].val;
            }
            else
            {
                while (num < pos->end)
                {
                    num += 1;
                    byte b = Strmake.Strmake_Isyunsuanascii(buf + num);
                    if (b <= 0)
                    {
                        guicombianyi.errcode = 26;
                        *back = 0;
                        result = 0;
                        return result;
                    }
                    pos->star = (ushort)(num + (ushort)b);
                    b = buf[num];
                    num = guicombianyi.getstratt(buf, ref *pos, ref array[0]);
                    if (array[0].datafrom == 255)
                    {
                        *back = 0;
                        result = 0;
                        return result;
                    }
                    array[1].datafrom = 253;
                    array[1].isxiugai = 1;
                    if (guicombianyi.attadd(buf, ref array[1], ref array[0], ref array[1], b) == 0)
                    {
                        *back = 0;
                        result = 0;
                        return result;
                    }
                }
                result = array[1].val;
            }
            return result;
        }

        private unsafe static byte jiexicans(byte* buf, int index, int bufbeg, int qyt, byte lei, ref runattinf[] runatt)
        {
            byte b = 1;
            while (qyt > 0)
            {
                if (lei == 0)
                {
                    *(int*)(Hmi.myapp.Mycanshus + index) = guicombianyi.strgetS32(buf, Hmi.myapp.Mycanshus + bufbeg, &b);
                }
                else if (lei == 1)
                {
                    int num = (int)guicombianyi.getstratt(buf, ref Hmi.myapp.Mycanshus[bufbeg], ref runatt[index]);
                    if (runatt[index].datafrom == 255)
                    {
                        b = 0;
                    }
                    else if (num != (int)Hmi.myapp.Mycanshus[bufbeg].end)
                    {
                        guicombianyi.errcode = 26;
                        b = 0;
                    }
                }
                else if (lei == 2)
                {
                    int num = guicombianyi.strgetS32(buf, Hmi.myapp.Mycanshus + bufbeg, &b);
                    if (b == 0)
                    {
                        num = (int)guicombianyi.Getobjid(buf, Hmi.myapp.Mycanshus + bufbeg, guicombianyi.dobj.Mypage);
                        if (num == 65535)
                        {
                            guicombianyi.errcode = 2;
                        }
                        else
                        {
                            guicombianyi.errcode = 255;
                            b = 1;
                        }
                    }
                    *(int*)(Hmi.myapp.Mycanshus + index) = num;
                }
                else if (lei == 3)
                {
                    int num = guicombianyi.strgetS32(buf, Hmi.myapp.Mycanshus + bufbeg, &b);
                    if (b == 0)
                    {
                        num = (int)guicombianyi.Getpageid(buf, Hmi.myapp.Mycanshus + bufbeg);
                        if (num == 65535)
                        {
                            guicombianyi.errcode = 3;
                        }
                        else
                        {
                            guicombianyi.errcode = 255;
                            b = 1;
                        }
                    }
                    *(int*)(Hmi.myapp.Mycanshus + index) = num;
                }
                if (b == 0)
                {
                    break;
                }
                index++;
                bufbeg++;
                qyt--;
            }
            return b;
        }

        public unsafe static byte CodeRun_Run(byte* buf, PosLaction* poscode, mobj mobj)
        {
            PosLaction posLaction = default(PosLaction);
            guicombianyi.dobj = mobj;
            guicombianyi.hexreplace.Clear();
            hexreplace_type hex = default(hexreplace_type);
            runattinf[] array = new runattinf[3];
            bool flag = false;
            byte b = 0;
            guicombianyi.errcode = 255;
            guicombianyi.errmessage = "";
            guicombianyi.jinggaostr = "";
            posLaction = *poscode;
            ushort num =(ushort)(poscode->end - poscode->star + 1);
            byte result;
            if (num == 1 && buf[poscode->star] == 69)
            {
                result = 1;
            }
            else if (Strmake.Strmake_Makestr(buf + poscode->star, "T ", 2) == 1 && num == 3)
            {
                result = 1;
            }
            else if (Strmake.Strmake_Makestr(buf + poscode->star, "L ", 2) == 1 && num > 2)
            {
                result = 1;
            }
            else if (Strmake.Strmake_Makestr(buf + poscode->star, "S ", 2) == 1 && num > 2)
            {
                result = 1;
            }
            else if (Strmake.Strmake_Makestr(buf + poscode->star, "add ", 4) == 1)
            {
                posLaction.star =(ushort)(poscode->star + 4);
                posLaction.end = poscode->end;
                byte b2 = Strmake.Strmake_StrGetcanshu(buf, &posLaction, Hmi.myapp.Mycanshus, 3);
                if (b2 == 0)
                {
                    guicombianyi.errcode = 30;
                    result = 0;
                }
                else
                {
                    for (num = 0; num < 3; num += 1)
                    {
                        guicombianyi.strgetS32(buf, Hmi.myapp.Mycanshus + num, &b2);
                        if (b2 == 0)
                        {
                            result = 0;
                            return result;
                        }
                    }
                    result = 1;
                }
            }
            else
            {
                byte b2 = 0;
                for (uint num2 = (uint)poscode->star; num2 <= (uint)poscode->end; num2 += 1u)
                {
                    if (buf[num2] == 32)
                    {
                        break;
                    }
                    if (buf[num2] == 61 || buf[num2] == 43 || buf[num2] == 45)
                    {
                        b2 = 255;
                        break;
                    }
                    if (b2 == 8)
                    {
                        b2 = 255;
                        break;
                    }
                    b2 += 1;
                }
                if (b2 == 0)
                {
                    guicombianyi.errcode = 0;
                    result = 0;
                }
                else if ((ushort)b2 < poscode->end && buf[b2] == 32 && buf[b2 + 1] == 32)
                {
                    guicombianyi.errmessage = "指令后出现多余的空格".Language();
                    result = 0;
                }
                else
                {
                    byte b3 = 255;
                    hex.qyt = (int)(b2 + 1);
                    hex.beg = 0;
                    hex.bytes = new byte[3];
                    hex.bytes[0] = 9;
                    if (b2 < 5)
                    {
                        uint num2 = 0u;
                        Kuozhan.memcpy((byte*)(&num2), buf + poscode->star, (int)b2);
                        if (num2 == "I\0\0\0".strtoU32())
                        {
                            flag = true;
                        }
                        if (guidatamake.xiliepaichucom32[(int)guicombianyi.dobj.Myapp.xilie] != null && guidatamake.xiliepaichucom32[(int)guicombianyi.dobj.Myapp.xilie].Contains(num2))
                        {
                            guicombianyi.jinggaostr = "当前配置的硬件系列不支持的指令".Language();
                        }
                        fixed (void* ptr = CodeRun.com32)
                        {
                            num2 = Datafind.Datafind_FindU32_Memory(&num2, (uint*)ptr, (uint)CodeRun.com32qyt, (uint)(sizeof(comtype_32) / 4));
                        }
                        if (num2 == 65535u)
                        {
                            guicombianyi.errcode = 0;
                            result = 0;
                            return result;
                        }
                        int comindex = (int)CodeRun.com32[(int)((UIntPtr)num2)].comindex;
                        b3 = CodeRun.com32[(int)((UIntPtr)num2)].canqyt;
                        b = CodeRun.com32[(int)((UIntPtr)num2)].canlei;
                        byte res = CodeRun.com32[(int)((UIntPtr)num2)].res;
                        hex.bytes[1] = (byte)num2;
                        hex.bytes[2] = 4;
                    }
                    else if (b2 < 9)
                    {
                        ulong value = 0uL;
                        Kuozhan.memcpy((byte*)(&value), buf + poscode->star, (int)b2);
                        if (guidatamake.xiliepaichucom64[(int)guicombianyi.dobj.Myapp.xilie] != null && guidatamake.xiliepaichucom64[(int)guicombianyi.dobj.Myapp.xilie].Contains(value))
                        {
                            guicombianyi.jinggaostr = "当前配置的硬件系列不支持的指令".Language();
                        }
                        uint num2;
                        fixed (void* ptr = CodeRun.com64)
                        {
                            num2 = Datafind.Datafind_FindU64_Memory(&value, (uint*)ptr, (uint)CodeRun.com64qyt, (uint)(sizeof(comtype_64) / 4));
                        }
                        if (num2 == 65535u)
                        {
                            guicombianyi.errcode = 0;
                            result = 0;
                            return result;
                        }
                        int comindex = (int)CodeRun.com64[(int)((UIntPtr)num2)].comindex;
                        b3 = CodeRun.com64[(int)((UIntPtr)num2)].canqyt;
                        b = CodeRun.com64[(int)((UIntPtr)num2)].canlei;
                        byte res = CodeRun.com64[(int)((UIntPtr)num2)].res;
                        hex.bytes[1] = (byte)num2;
                        hex.bytes[2] = 8;
                    }
                    if (b3 != 255)
                    {
                        guicombianyi.hexattreplaceadd(hex);
                        posLaction.star =(ushort)(poscode->star + (ushort)b2 + 1);
                        posLaction.end = poscode->end;
                        b2 = Strmake.Strmake_StrGetcanshu(buf, &posLaction, Hmi.myapp.Mycanshus, b3);
                        if (b2 == 0)
                        {
                            guicombianyi.errcode = 30;
                            result = 0;
                        }
                        else
                        {
                            if (Strmake.Strmake_Makestr(buf, "xstr ", 5) == 1 || Strmake.Strmake_Makestr(buf, "zstr ", 5) == 1)
                            {
                                if (buf[Hmi.myapp.Mycanshus[b3 - 1].star] == 34 && buf[Hmi.myapp.Mycanshus[b3 - 1].end] == 34)
                                {
                                    byte[] array2 = new byte[(int)(Hmi.myapp.Mycanshus[b3 - 1].end - Hmi.myapp.Mycanshus[b3 - 1].star)];
                                    fixed (byte* ptr2 = array2)
                                    {
                                        Kuozhan.memcpy(ptr2, buf + (Hmi.myapp.Mycanshus[b3 - 1].star + 1), array2.Length - 1);
                                    }
                                    array2[array2.Length - 1] = 0;
                                    ushort num3 = (ushort)guicombianyi.dobj.Myapp.addstaticstring(array2);
                                    hexreplace_type hex2 = default(hexreplace_type);
                                    hex2.beg = (int)Hmi.myapp.Mycanshus[b3 - 1].star;
                                    hex2.qyt = (int)(Hmi.myapp.Mycanshus[b3 - 1].end - Hmi.myapp.Mycanshus[b3 - 1].star + 1);
                                    hex2.bytes = new byte[5];
                                    hex2.bytes[0] = 2;
                                    num3.structToBytes().CopyTo(hex2.bytes, 1);
                                    ((ushort)array2.Length).structToBytes().CopyTo(hex2.bytes, 3);
                                    guicombianyi.hexattreplaceadd(hex2);
                                }
                            }
                            if (b == 0)
                            {
                                if (guicombianyi.jiexicans(buf, 0, 0, (int)b3, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b < 4)
                            {
                                b =(byte)(b3 - b);
                                if (guicombianyi.jiexicans(buf, 0, 0, (int)b, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (guicombianyi.jiexicans(buf, 0, (int)b, (int)(b3 - b), 1, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b < 14)
                            {
                                b -= 10;
                                b = (byte)(b3 - b);
                                if (guicombianyi.jiexicans(buf, 0, 0, (int)b, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (guicombianyi.jiexicans(buf, (int)b, (int)b, (int)(b3 - b), 2, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b < 24)
                            {
                                b -= 20;
                                b =(byte)(b3 - b);
                                if (guicombianyi.jiexicans(buf, 0, 0, (int)b, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (guicombianyi.jiexicans(buf, (int)b, (int)b, (int)(b3 - b), 3, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b < 104)
                            {
                                b -= 100;
                                if (guicombianyi.jiexicans(buf, 0, 0, (int)b, 1, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (guicombianyi.jiexicans(buf, (int)b, (int)b, (int)(b3 - b), 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b < 114)
                            {
                                b -= 110;
                                if (guicombianyi.jiexicans(buf, 0, 0, (int)b, 2, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (guicombianyi.jiexicans(buf, (int)b, (int)b, (int)(b3 - b), 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b < 124)
                            {
                                b -= 120;
                                if (guicombianyi.jiexicans(buf, 0, 0, (int)b, 3, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (guicombianyi.jiexicans(buf, (int)b, (int)b, (int)(b3 - b), 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b != 255)
                            {
                                guicombianyi.errcode = 30;
                                result = 0;
                                return result;
                            }
                            if (flag)
                            {
                                if ((array[0].attlei == attshulei.Sstr.typevalue && array[1].attlei != attshulei.Sstr.typevalue) || (array[0].attlei != attshulei.Sstr.typevalue && array[1].attlei == attshulei.Sstr.typevalue))
                                {
                                    guicombianyi.errcode = 33;
                                    result = 0;
                                    return result;
                                }
                            }
                            if (guicombianyi.jinggaostr != "")
                            {
                                result = 2;
                            }
                            else
                            {
                                result = 1;
                            }
                        }
                    }
                    else
                    {
                        if (poscode->end - poscode->star > 2)
                        {
                            posLaction.star = poscode->star;
                            posLaction.end = poscode->end;
                            uint num2 = (uint)guicombianyi.getstratt(buf, ref posLaction, ref array[2]);
                            if (array[2].datafrom == 255)
                            {
                                result = 0;
                                return result;
                            }
                            if (num2 < (uint)poscode->end)
                            {
                                num2 += 1u;
                                b2 = Strmake.Strmake_Isyunsuanascii(buf + num2);
                                if (b2 == 2)
                                {
                                    num2 += 1u;
                                }
                                if (num2 < (uint)poscode->end)
                                {
                                    if (buf[num2] == 61 || (b2 > 0 && num2 + 1u < (uint)poscode->end && buf[num2 + 1u] == 61))
                                    {
                                        if (buf[num2] == 61)
                                        {
                                            posLaction.star = (ushort)(num2 + 1u);
                                            posLaction.end = poscode->end;
                                            num2 = (uint)guicombianyi.getstratt(buf, ref posLaction, ref array[0]);
                                            if (array[0].datafrom == 255)
                                            {
                                                result = 0;
                                                return result;
                                            }
                                            if (num2 < (uint)posLaction.end)
                                            {
                                                num2 += 1u;
                                                b2 = Strmake.Strmake_Isyunsuanascii(buf + num2);
                                                if (b2 == 2)
                                                {
                                                    num2 += 1u;
                                                }
                                                if (num2 >= (uint)poscode->end || b2 <= 0)
                                                {
                                                    guicombianyi.errcode = 26;
                                                    result = 0;
                                                    return result;
                                                }
                                                b2 = buf[num2];
                                                num2 += 1u;
                                            }
                                            else
                                            {
                                                fixed (runattinf* ptr3 = array)
                                                {
                                                    b2 = guicombianyi.setatt(ptr3, ptr3 + 2, 0);
                                                }
                                                if (b2 == 0)
                                                {
                                                    result = 0;
                                                    return result;
                                                }
                                                result = 1;
                                                return result;
                                            }
                                        }
                                        else
                                        {
                                            b2 = buf[num2];
                                            num2 += 2u;
                                            fixed (void* ptr4 =(&array[0]))
                                            {
                                                fixed (void* ptr5 = (&array[2]))
                                                {
                                                    Kuozhan.memcpy((byte*)ptr4, (byte*)ptr5, datasize.runattinfsize);
                                                }
                                            }
                                        }
                                        posLaction.star = (ushort)num2;
                                        num2 = (uint)guicombianyi.getstratt(buf, ref posLaction, ref array[1]);
                                        if (array[1].datafrom == 255)
                                        {
                                            result = 0;
                                            return result;
                                        }
                                        fixed (runattinf* ptr3 = array)
                                        {
                                            b2 = guicombianyi.attadd(buf, ptr3, ptr3 + 1, ptr3 + 2, b2);
                                        }
                                        if (b2 == 0)
                                        {
                                            result = 0;
                                            return result;
                                        }
                                        while (num2 < (uint)posLaction.end)
                                        {
                                            num2 += 1u;
                                            b2 = Strmake.Strmake_Isyunsuanascii(buf + num2);
                                            if (b2 == 2)
                                            {
                                                num2 += 1u;
                                            }
                                            if (num2 >= (uint)poscode->end || b2 <= 0)
                                            {
                                                guicombianyi.errcode = 26;
                                                result = 0;
                                                return result;
                                            }
                                            b2 = buf[num2];
                                            posLaction.star = (ushort)(num2 + 1u);
                                            num2 = (uint)guicombianyi.getstratt(buf, ref posLaction, ref array[1]);
                                            if (array[1].datafrom == 255)
                                            {
                                                result = 0;
                                                return result;
                                            }
                                            if (guicombianyi.attadd(buf, ref array[2], ref array[1], ref array[2], b2) == 0)
                                            {
                                                result = 0;
                                                return result;
                                            }
                                        }
                                        result = 1;
                                        return result;
                                    }
                                    else
                                    {
                                        b2 = 0;
                                        if (buf[poscode->end] == 43 && buf[poscode->end - 1] == 43)
                                        {
                                            b2 = 43;
                                        }
                                        else if (buf[poscode->end] == 45 && buf[poscode->end - 1] == 45)
                                        {
                                            b2 = 45;
                                        }
                                        if (b2 > 0)
                                        {
                                            if (num2 + 1u != (uint)posLaction.end)
                                            {
                                                guicombianyi.errcode = 26;
                                                result = 0;
                                                return result;
                                            }
                                            array[1].attlei = attshulei.SS32.typevalue;
                                            array[1].val = 1;
                                            array[1].datafrom = 253;
                                            if (guicombianyi.attadd(buf, ref array[2], ref array[1], ref array[2], b2) == 0)
                                            {
                                                result = 0;
                                                return result;
                                            }
                                            result = 1;
                                            return result;
                                        }
                                    }
                                }
                            }
                        }
                        guicombianyi.errcode = 0;
                        result = 0;
                    }
                }
            }
            return result;
        }
    }
}
