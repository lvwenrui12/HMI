using System;

namespace hmitype
{
    public static class Attmake
    {
        public const uint attstr32qyt = 53u;

        public const uint attstr64qyt = 11u;

        public const byte attnameqyt = 180;

        public static myappinf myapp;

        public static string[] attnames = new string[]
        {
            "lei",
            "vscope",
            "sta",
            "ch",
            "bco",
            "picc",
            "pic",
            "gdc",
            "gdw",
            "gdh",
            "pco0",
            "pco1",
            "pco2",
            "pco3",
            "mode",
            "psta",
            "pco",
            "pic2",
            "wid",
            "hig",
            "val",
            "maxval",
            "minval",
            "picc2",
            "bco2",
            "font",
            "xcen",
            "ycen",
            "txt",
            "txt_maxl",
            "dez",
            "bpic",
            "ppic",
            "tim",
            "en",
            "picc0",
            "picc1",
            "bco0",
            "bco1",
            "pic0",
            "pic1",
            "lenth",
            "x",
            "y",
            "endx",
            "endy",
            "w",
            "h",
            "dir",
            "id",
            "vvs0",
            "vvs1",
            "vvs2",
            "vvs3",
            "isbr",
            "dis",
            "spax",
            "spay",
            "pw",
            "style",
            "borderc",
            "borderw",
            "type",
            "key"
        };

        public static attstrtype_32[] attstr32;

        public static attstrtype_64[] attstr64;

        public static void attinit()
        {
            Attmake.attstr32 = new attstrtype_32[]
            {
                new attstrtype_32
                {
                    name = "h\0\0\0".strtoU32(),
                    id = 47,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "w\0\0\0".strtoU32(),
                    id = 46,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "x\0\0\0".strtoU32(),
                    id = 42,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "y\0\0\0".strtoU32(),
                    id = 43,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "id\0\0".strtoU32(),
                    id = 49,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "ch\0\0".strtoU32(),
                    id = 3,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "en\0\0".strtoU32(),
                    id = 34,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pw\0\0".strtoU32(),
                    id = 58,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "sta\0".strtoU32(),
                    id = 2,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "gdc\0".strtoU32(),
                    id = 7,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pic\0".strtoU32(),
                    id = 6,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "wid\0".strtoU32(),
                    id = 18,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "hig\0".strtoU32(),
                    id = 19,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "gdh\0".strtoU32(),
                    id = 9,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "lei\0".strtoU32(),
                    id = 0,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "val\0".strtoU32(),
                    id = 20,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "tim\0".strtoU32(),
                    id = 33,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "bco\0".strtoU32(),
                    id = 4,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pco\0".strtoU32(),
                    id = 16,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "dir\0".strtoU32(),
                    id = 48,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "dis\0".strtoU32(),
                    id = 55,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "txt\0".strtoU32(),
                    id = 28,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "gdw\0".strtoU32(),
                    id = 8,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "key\0".strtoU32(),
                    id = 63,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "dez\0".strtoU32(),
                    id = 30,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pic0".strtoU32(),
                    id = 39,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "bco0".strtoU32(),
                    id = 37,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pco0".strtoU32(),
                    id = 10,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "vvs0".strtoU32(),
                    id = 50,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pic1".strtoU32(),
                    id = 40,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "bco1".strtoU32(),
                    id = 38,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pco1".strtoU32(),
                    id = 11,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "vvs1".strtoU32(),
                    id = 51,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pic2".strtoU32(),
                    id = 17,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "bco2".strtoU32(),
                    id = 24,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pco2".strtoU32(),
                    id = 12,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "vvs2".strtoU32(),
                    id = 52,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "pco3".strtoU32(),
                    id = 13,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "vvs3".strtoU32(),
                    id = 53,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "psta".strtoU32(),
                    id = 15,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "picc".strtoU32(),
                    id = 5,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "bpic".strtoU32(),
                    id = 31,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "ppic".strtoU32(),
                    id = 32,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "mode".strtoU32(),
                    id = 14,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "type".strtoU32(),
                    id = 62,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "xcen".strtoU32(),
                    id = 26,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "ycen".strtoU32(),
                    id = 27,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "isbr".strtoU32(),
                    id = 54,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "font".strtoU32(),
                    id = 25,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "spax".strtoU32(),
                    id = 56,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "endx".strtoU32(),
                    id = 44,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "spay".strtoU32(),
                    id = 57,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_32
                {
                    name = "endy".strtoU32(),
                    id = 45,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                }
            };
            Attmake.attstr64 = new attstrtype_64[]
            {
                new attstrtype_64
                {
                    name = "picc0\0\0\0".strtoU64(),
                    id = 35,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "picc1\0\0\0".strtoU64(),
                    id = 36,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "picc2\0\0\0".strtoU64(),
                    id = 23,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "style\0\0\0".strtoU64(),
                    id = 59,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "lenth\0\0\0".strtoU64(),
                    id = 41,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "vscope\0\0".strtoU64(),
                    id = 1,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "minval\0\0".strtoU64(),
                    id = 22,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "maxval\0\0".strtoU64(),
                    id = 21,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "borderc\0".strtoU64(),
                    id = 60,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "borderw\0".strtoU64(),
                    id = 61,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                },
                new attstrtype_64
                {
                    name = "txt_maxl".strtoU64(),
                    id = 29,
                    res0 = 0,
                    res1 = 0,
                    res2 = 0
                }
            };
        }

        public unsafe static byte Attmake_AttConvert(ref runattinf b1, ref runattinf b2, byte lenth1, byte lenth2)
        {
            byte result;
            fixed (runattinf* ptr = &b1)
            {
                fixed (runattinf* ptr2 = &b2)
                {
                    result = Attmake.Attmake_AttConvert(ptr, ptr2, lenth1, lenth2);
                }
            }
            return result;
        }

        public unsafe static byte Attmake_SetAtt(ref runattinf b1, ref runattinf b2, byte yunsuan)
        {
            byte result;
            fixed (runattinf* ptr = &b1)
            {
                fixed (runattinf* ptr2 = &b2)
                {
                    result = Attmake.Attmake_SetAtt(ptr, ptr2, yunsuan);
                }
            }
            return result;
        }

        public unsafe static ushort Attmake_GetstrAtt(byte* buf, ref PosLaction thispos, ref runattinf att)
        {
            ushort result;
            fixed (PosLaction* ptr = &thispos)
            {
                fixed (runattinf* ptr2 = &att)
                {
                    result = Attmake.Attmake_GetstrAtt(buf, ptr, ptr2);
                }
            }
            return result;
        }

        public unsafe static byte Attmake_AttAdd(byte* buf, ref runattinf b1, ref runattinf b2, ref runattinf b3, byte yunsuan)
        {
            //return Attmake.Attmake_AttAdd(buf, &b1, &b2, &b3, yunsuan);

            fixed (runattinf* runattinfRef = (&b1))
            {
                fixed (runattinf* runattinfRef2 = (&b2))
                {
                    fixed (runattinf* runattinfRef3 = (&b3))
                    {
                        return Attmake_AttAdd(buf, runattinfRef, runattinfRef2, runattinfRef3, yunsuan);
                    }
                }
            }

        }

        public static void attinfUpToDown(this attinf_Up attup, ref attinf attdown, byte encodeh_star)
        {
            attdown.state =(byte) (attup.attlei & 15);
            if (attup.isxiugai == 1)
            {
                attdown.state |= 16;
            }
            if (attup.chonghui == 1)
            {
                attdown.state |= 32;
            }
            attdown.encodeh_star = encodeh_star;
            attdown.merrylenth = attup.merrylenth;
            attdown.pos = attup.pos;
            attdown.maxval = attup.maxval;
            attdown.minval = attup.minval;
        }

        public static int getbytestoint(this byte[] bytes, int memorylenth, byte attlei)
        {
            int num = 0;
            int result;
            if (bytes.Length == 0 || memorylenth > bytes.Length)
            {
                result = 0;
            }
            else
            {
                if (memorylenth == 1)
                {
                    num = (int)bytes[0];
                }
                else if (memorylenth == 2)
                {
                    if ((attlei & 15) == attshulei.UU16.typevalue)
                    {
                        num = (int)((ushort)bytes.BytesTostruct(0.GetType()));
                    }
                    else
                    {
                        num = (int)((short)bytes.BytesTostruct(0.GetType()));
                    }
                }
                else if (memorylenth == 4)
                {
                    num = (int)bytes.BytesTostruct(0.GetType());
                }
                result = num;
            }
            return result;
        }

        private unsafe static byte AttConvert_gui(runattinf* b1, runattinf* b2, byte lenth1, byte lenth2)
        {
            byte result;
            if (b1->attlei != attshulei.Sstr.typevalue && b2->attlei == attshulei.Sstr.typevalue)
            {
                if (b2->datafrom != 254)
                {
                    Attmake.myapp.errcode = 27;
                    result = 0;
                }
                else
                {
                    if (lenth1 == 0)
                    {
                        lenth1 = Strmake.Strmake_GetS32strlen(b1->val);
                    }
                    if (b2->att.merrylenth <= (ushort)lenth1)
                    {
                        lenth1 = (byte)(b2->att.merrylenth - 1);
                    }
                    Strmake.Strmake_S32ToStr(b1->val, b2->Pz, lenth1, 1);
                    result = 1;
                }
            }
            else if (b1->attlei == attshulei.Sstr.typevalue && b2->attlei != attshulei.Sstr.typevalue)
            {
                b2->val = Strmake.Strmake_StrToS32(b1->Pz, lenth1);
                result = Attmake.Attmake_SetAtt(b2, b2, 0);
            }
            else
            {
                Attmake.myapp.errcode = 27;
                result = 0;
            }
            return result;
        }

        private unsafe static byte SetAtt_gui(runattinf* b1, runattinf* b2, byte yunsuan)
        {
            byte result;
            if (b2->isxiugai == 1)
            {
                if (b2->attlei != attshulei.Sstr.typevalue && b1->attlei != attshulei.Sstr.typevalue && yunsuan == 0)
                {
                    if (b2->datafrom == 253)
                    {
                        b2->val = b2->val;
                        result = 1;
                        return result;
                    }
                    if (b1->val > b2->att.maxval || b1->val < b2->att.minval)
                    {
                        Attmake.myapp.errcode = 28;
                        result = 0;
                        return result;
                    }
                    if (b2->datafrom == 254)
                    {
                        if (b2->att.merrylenth == 2)
                        {
                            if (b1->attlei == attshulei.UU16.typevalue)
                            {
                                ushort num = (ushort)b1->val;
                                Kuozhan.memcpy(b2->Pz, (byte*)(&num), (int)b2->att.merrylenth);
                            }
                            else
                            {
                                short num2 = (short)b1->val;
                                Kuozhan.memcpy(b2->Pz, (byte*)(&num2), (int)b2->att.merrylenth);
                            }
                        }
                        else
                        {
                            Kuozhan.memcpy(b2->Pz, (byte*)(&b1->val), (int)b2->att.merrylenth);
                        }
                        result = 1;
                        return result;
                    }
                    ushort num3 = (ushort)Sysatt.Sysatt_SetXitongval(b2->datafrom, b1->val);
                    if (num3 == 1)
                    {
                        result = 1;
                        return result;
                    }
                    if (num3 == 2)
                    {
                        Attmake.myapp.errcode = 255;
                        result = 0;
                        return result;
                    }
                }
                else if (b2->attlei == attshulei.Sstr.typevalue && b1->attlei == attshulei.Sstr.typevalue && b2->datafrom == 254)
                {
                    ushort num3 = Strmake.Strmake_GetStrlen(b1->Pz);
                    ushort num4 = Strmake.Strmake_GetStrlen(b2->Pz);
                    byte* ptr = b2->Pz;
                    ushort num5;
                    if (yunsuan == 43)
                    {
                        ptr += num4;
                        num5 =(ushort)(b2->att.merrylenth - num4 - 1);
                    }
                    else
                    {
                        num5 =(ushort)(b2->att.merrylenth - 1);
                    }
                    if (num5 > num3)
                    {
                        num5 = num3;
                    }
                    Kuozhan.memcpy(ptr, b1->Pz, (int)num5);
                    ptr[num5] = 0;
                    result = 1;
                    return result;
                }
            }
            Attmake.myapp.errcode = 28;
            result = 0;
            return result;
        }

        private unsafe static byte AttAdd_gui(byte* buf, runattinf* b1, runattinf* b2, runattinf* b3, byte yunsuan)
        {
            byte result;
            if (b1->attlei == attshulei.Sstr.typevalue && b2->attlei == attshulei.Sstr.typevalue && b3->attlei == attshulei.Sstr.typevalue && yunsuan == 43)
            {
                if (b1->datafrom == 254 && b1->Pz == b3->Pz)
                {
                    if (Attmake.Attmake_SetAtt(b2, b3, yunsuan) > 0)
                    {
                        result = 1;
                        return result;
                    }
                }
                else if (b2->datafrom == 254 && b2->Pz == b3->Pz)
                {
                    if (Attmake.Attmake_SetAtt(b1, b3, yunsuan) > 0)
                    {
                        result = 1;
                        return result;
                    }
                }
                else
                {
                    if (Attmake.Attmake_SetAtt(b1, b3, 0) == 0)
                    {
                        result = 0;
                        return result;
                    }
                    if (Attmake.Attmake_SetAtt(b2, b3, yunsuan) > 0)
                    {
                        result = 1;
                        return result;
                    }
                }
            }
            else if (b2->attlei != attshulei.Sstr.typevalue && b3->attlei == attshulei.Sstr.typevalue && (yunsuan == 45 || (yunsuan == 43 && b2->val < 0)))
            {
                ushort num = Strmake.Strmake_GetStrlen_Encode(b3->Pz, b3->att.encodeh_star);
                if (b2->val >= (int)num)
                {
                    *b3->Pz = 0;
                    result = 1;
                    return result;
                }
                num = Strmake.Strmake_GetStrlen_Encode_Lenth(b3->Pz, b3->att.encodeh_star, (byte)((int)num - b2->val));
                b3->Pz[num] = 0;
                result = 1;
                return result;
            }
            else if (b1->attlei != attshulei.Sstr.typevalue && b2->attlei != attshulei.Sstr.typevalue && b3->attlei != attshulei.Sstr.typevalue)
            {
                if (yunsuan == 43)
                {
                    b3->val = b1->val + b2->val;
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 45)
                {
                    b3->val = b1->val - b2->val;
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 42)
                {
                    b3->val = b1->val * b2->val;
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 47)
                {
                    b3->val = ((b2->val == 0) ? 0 : (b1->val / b2->val));
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 37)
                {
                    b3->val = b1->val % b2->val;
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 124)
                {
                    b3->val = (b1->val | b2->val);
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 38)
                {
                    b3->val = (b1->val & b2->val);
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 60)
                {
                    b3->val = b1->val << b2->val;
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
                if (yunsuan == 62)
                {
                    b3->val = b1->val >> b2->val;
                    result = Attmake.Attmake_SetAtt(b3, b3, 0);
                    return result;
                }
            }
            Attmake.myapp.errcode = 27;
            result = 0;
            return result;
        }

        public unsafe static byte Attmake_GetAttindex(byte* name, byte lenth)
        {
            byte result;
            if (lenth < 5)
            {
                uint num = 0u;
                Kuozhan.memcpy((byte*)(&num), name, (int)lenth);
                fixed (void* ptr = Attmake.attstr32)
                {
                    num = Datafind.Datafind_FindU32_Memory(&num, (uint*)ptr, 53u, (uint)(sizeof(attstrtype_32) / 4));
                }
                if (num == 65535u)
                {
                    result = 255;
                }
                else
                {
                    result = Attmake.attstr32[(int)((UIntPtr)num)].id;
                }
            }
            else if (lenth < 9)
            {
                ulong num2 = 0uL;
                Kuozhan.memcpy((byte*)(&num2), name, (int)lenth);
                uint num;
                fixed (void* ptr = Attmake.attstr64)
                {
                    num = Datafind.Datafind_FindU64_Memory(&num2, (uint*)ptr, 11u, (uint)(sizeof(attstrtype_64) / 4));
                }
                if (num == 65535u)
                {
                    result = 255;
                }
                else
                {
                    result = Attmake.attstr64[(int)((UIntPtr)num)].id;
                }
            }
            else
            {
                result = 255;
            }
            return result;
        }

        public unsafe static byte Attmake_Makeatt(byte* buf, runattinf* b1, runattinf* b2, byte yunsuan)
        {
            byte result;
            if (b2->attlei != attshulei.Sstr.typevalue && b2->attlei != attshulei.Sstr.typevalue)
            {
                if (yunsuan == 1)
                {
                    if (b1->val == b2->val)
                    {
                        result = 1;
                        return result;
                    }
                    result = 0;
                    return result;
                }
                else if (yunsuan == 2)
                {
                    if (b1->val < b2->val)
                    {
                        result = 1;
                        return result;
                    }
                    result = 0;
                    return result;
                }
                else if (yunsuan == 3)
                {
                    if (b1->val > b2->val)
                    {
                        result = 1;
                        return result;
                    }
                    result = 0;
                    return result;
                }
                else if (yunsuan == 4)
                {
                    if (b1->val <= b2->val)
                    {
                        result = 1;
                        return result;
                    }
                    result = 0;
                    return result;
                }
                else if (yunsuan == 5)
                {
                    if (b1->val >= b2->val)
                    {
                        result = 1;
                        return result;
                    }
                    result = 0;
                    return result;
                }
                else if (yunsuan == 6)
                {
                    if (b1->val != b2->val)
                    {
                        result = 1;
                        return result;
                    }
                    result = 0;
                    return result;
                }
            }
            else if (b2->attlei == attshulei.Sstr.typevalue && b1->attlei == attshulei.Sstr.typevalue)
            {
                if (yunsuan == 1 || yunsuan == 6)
                {
                    if (Strmake.Strmake_Makestr(b1->Pz, b2->Pz, 0) == 1)
                    {
                        if (yunsuan == 1)
                        {
                            result = 1;
                            return result;
                        }
                        result = 0;
                        return result;
                    }
                    else
                    {
                        if (yunsuan == 1)
                        {
                            result = 0;
                            return result;
                        }
                        result = 1;
                        return result;
                    }
                }
            }
            result = 0;
            return result;
        }

        public unsafe static byte Attmake_AttConvert(runattinf* b1, runattinf* b2, byte lenth1, byte lenth2)
        {
            byte b3 = Attmake.AttConvert_gui(b1, b2, lenth1, lenth2);
            if (b3 == 1 && b2->isref == 1 && (ushort)b2->att.pageid == Attmake.myapp.dpage)
            {
                Attmake.myapp.pageobjs[b2->att.objid].refFlag = 1;
            }
            return b3;
        }

        public unsafe static byte Attmake_SetAtt(runattinf* b1, runattinf* b2, byte yunsuan)
        {
            byte b3 = Attmake.SetAtt_gui(b1, b2, yunsuan);
            if (b3 == 1 && b2->isref == 1 && (ushort)b2->att.pageid == Attmake.myapp.dpage)
            {
                Attmake.myapp.pageobjs[b2->att.objid].refFlag = 1;
            }
            return b3;
        }

        public unsafe static ushort Attmake_GetstrAtt(byte* buf, PosLaction* bufpos, runattinf* att)
        {
            ushort num = bufpos->star;
            PosLaction posLaction = default(PosLaction);
            att->datafrom = 255;
            att->isref = 0;
            ushort result;
            if (bufpos->end < bufpos->star)
            {
                Attmake.myapp.errcode = 26;
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
                            Attmake.myapp.errcode = 32;
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
                                Attmake.myapp.errcode = 32;
                                result = 65535;
                                return result;
                            }
                            buf[num3] = 13;
                            num3 += 1;
                            buf[num3] = 10;
                        }
                        if (num == bufpos->end)
                        {
                            Attmake.myapp.errcode = 32;
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
                    att->att.pos =(ushort)(bufpos->star + 1);
                    att->attlei = attshulei.Sstr.typevalue;
                    att->att.merrylenth =(ushort)(num3 - bufpos->star);
                    att->datafrom = 253;
                    att->isxiugai = 0;
                    att->Pz = buf + att->att.pos;
                    att->att.encodeh_star = Attmake.myapp.encodeh_star;
                    result = num2;
                }
                else
                {
                    Attmake.myapp.errcode = 26;
                    result = 65535;
                }
            }
            else if ((buf[num] < 9 && buf[num] > 1) || buf[num] == 45 || (buf[num] > 47 && buf[num] < 58))
            {
                if (buf[num] < 9)
                {
                    if (buf[num] == 3)
                    {
                        Kuozhan.memcpy((byte*)(&att->val), buf + (num + 1), 4);
                        att->datafrom = 253;
                        att->att.merrylenth = 4;
                        att->attlei = attshulei.SS32.typevalue;
                        att->isxiugai = 0;
                    }
                    else if (buf[bufpos->star] == 2)
                    {
                        att->datafrom = 252;
                        Kuozhan.memcpy((byte*)(&att->att.pos), buf + (bufpos->star + 1), 4);
                        att->att.state = attshulei.Sstr.typevalue;
                        att->isxiugai = 0;
                    }
                    else if (buf[bufpos->star] == 4)
                    {
                        Sysatt.Sysatt_GetXitongval(buf[bufpos->star + 1], buf[bufpos->star + 2], att);
                    }
                    num += 4;
                }
                else
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
                    att->val = Strmake.Strmake_StrToS32(buf + bufpos->star, (byte)(num - bufpos->star + 1));
                    att->datafrom = 253;
                    att->att.merrylenth = 4;
                    att->attlei = attshulei.SS32.typevalue;
                    att->isxiugai = 0;
                }
                result = num;
            }
            else
            {
                posLaction.star = bufpos->star;
                if (Strmake.Strmake_IsAttendbyte(buf[num]) == 1)
                {
                    Attmake.myapp.errcode = 26;
                    result = 65535;
                }
                else
                {
                    int num4 = 0;
                    if (num > bufpos->end)
                    {
                        Attmake.myapp.errcode = 26;
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
                                Attmake.myapp.errcode = 35;
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
                        posLaction.end = num;
                        Attmake.Attmake_GetAtt(buf, &posLaction, att);
                        if (att->datafrom == 255)
                        {
                            Attmake.myapp.errcode = 26;
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

        public unsafe static byte Attmake_AttAdd(byte* buf, runattinf* b1, runattinf* b2, runattinf* b3, byte yunsuan)
        {
            byte b4 = Attmake.AttAdd_gui(buf, b1, b2, b3, yunsuan);
            if (b4 == 1 && b3->isref == 1 && (ushort)b3->att.pageid == Attmake.myapp.dpage)
            {
                Attmake.myapp.pageobjs[b3->att.objid].refFlag = 1;
            }
            return b4;
        }

        public unsafe static void Attmake_GetAtt(byte* buf, PosLaction* bufpos, runattinf* att)
        {
            PosLaction posLaction = default(PosLaction);
            pagexinxi pagexinxi = default(pagexinxi);
            strxinxi strxinxi = default(strxinxi);
            uint num = 0u;
            ushort num2 = 0;
            ushort num3 = 0;
            att->datafrom = 255;
            att->isref = 0;
            if (buf[bufpos->star] != 46)
            {
                uint num4;
                if (buf[bufpos->star] == 1)
                {
                    Kuozhan.memcpy((byte*)(&num4), buf + (bufpos->star + 1), 4);
                    num4 *= (uint)datasize.attxinxisize;
                    num4 += Attmake.myapp.app.attdatapos;
                }
                else
                {
                    for (uint num5 = (uint)bufpos->star; num5 <= (uint)bufpos->end; num5 += 1u)
                    {
                        if (buf[num5] < 9)
                        {
                            num5 += 5u;
                        }
                        if (buf[num5] == 46 && num != 1u)
                        {
                            if (num2 == 0)
                            {
                                num2 = (ushort)num5;
                            }
                            else
                            {
                                if (num3 != 0)
                                {
                                    return;
                                }
                                num3 = (ushort)num5;
                            }
                        }
                        else if (buf[num5] == 91)
                        {
                            num = 1u;
                        }
                        else if (buf[num5] == 93)
                        {
                            num = 2u;
                        }
                    }
                    if (num2 == 0)
                    {
                        Sysatt.Sysatt_GetSysname(buf + bufpos->star, (byte)(bufpos->end - bufpos->star + 1), att);
                        return;
                    }
                    posLaction.star = bufpos->star;
                    posLaction.end = (ushort)(num2 - 1);
                    ushort num6;
                    ushort num7;
                    if (num3 > 0)
                    {
                        num6 = Hmi.Hmi_GetPageid(buf, &posLaction);
                        if (num6 == 65535)
                        {
                            return;
                        }
                        posLaction.star = (ushort)(num2 + 1);
                        posLaction.end =(ushort)(num3 - 1);
                        if (num6 == Attmake.myapp.dpage)
                        {
                            num7 = Hmi.Hmi_GetObjid(buf, &posLaction, Attmake.myapp.dobjnameseradd, (uint)Attmake.myapp.dpagexinxi.objqyt);
                            num4 = Attmake.myapp.dpagexinxi.attdatapos;
                        }
                        else
                        {
                            Readdata.Readdata_ReadPage(ref pagexinxi, (int)num6);
                            Readdata.Readdata_ReadStr(ref strxinxi, (int)pagexinxi.zhilingstar);
                            num7 = Hmi.Hmi_GetObjid(buf, &posLaction, strxinxi.addbeg + Attmake.myapp.app.strdataadd, (uint)pagexinxi.objqyt);
                            num4 = pagexinxi.attdatapos;
                        }
                        posLaction.star = (ushort)(num3 + 1);
                    }
                    else
                    {
                        num6 = Attmake.myapp.dpage;
                        num7 = Hmi.Hmi_GetObjid(buf, &posLaction, Attmake.myapp.dobjnameseradd, (uint)Attmake.myapp.dpagexinxi.objqyt);
                        posLaction.star =(ushort)(num2 + 1);
                        num4 = Attmake.myapp.dpagexinxi.attdatapos;
                    }
                    posLaction.end = bufpos->end;
                    if (num7 == 65535 || posLaction.star > posLaction.end)
                    {
                        return;
                    }
                    num2 = (ushort)Attmake.Attmake_GetAttindex(buf + posLaction.star, (byte)(posLaction.end - posLaction.star + 1));
                    if (num2 == 255)
                    {
                        return;
                    }
                    if (num6 != Attmake.myapp.dpage)
                    {
                        num = (uint)((ulong)Attmake.myapp.app.objadd + (ulong)(num7 + pagexinxi.objstar) * (ulong)((long)(datasize.objxinxisize + 180)));
                        num3 = 0;
                        Readdata.SPI_Flash_Read((byte*)(&num3), num + 15u, 1u);
                        if (num3 != 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        num = (uint)((ulong)Attmake.myapp.app.objadd + (ulong)(num7 + Attmake.myapp.dpagexinxi.objstar) * (ulong)((long)(datasize.objxinxisize + 180)));
                    }
                    Readdata.SPI_Flash_Read((byte*)(&num2), (uint)((ulong)num + (ulong)((long)datasize.objxinxisize) + (ulong)((long)(num2 * 2))), 2u);
                    if (num2 == 65535)
                    {
                        return;
                    }
                    num4 += (uint)(datasize.attxinxisize * (int)num2);
                }
                num = Attmake.myapp.app.strdataadd + num4;
                Readdata.SPI_Flash_Read((byte*)(&att->att), num, (uint)datasize.attxinxisize);
                att->attlei =(byte) (att->att.state & 15);
                if ((att->att.state & 16) > 0)
                {
                    att->isxiugai = 1;
                    att->datafrom = 254;
                    att->Pz = Attmake.myapp.mymerry + att->att.pos;
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
                if ((att->att.state & 32) > 0)
                {
                    att->isref = 1;
                }
                if (att->attlei != attshulei.Sstr.typevalue)
                {
                    att->val = 0;
                    if (att->datafrom == 254)
                    {
                        if (att->attlei == attshulei.SS16.typevalue)
                        {
                            short val = 0;
                            Kuozhan.memcpy((byte*)(&val), Attmake.myapp.mymerry + att->att.pos, (int)att->att.merrylenth);
                            att->val = (int)val;
                        }
                        else
                        {
                            Kuozhan.memcpy((byte*)(&att->val), Attmake.myapp.mymerry + att->att.pos, (int)att->att.merrylenth);
                        }
                    }
                    else
                    {
                        Kuozhan.memcpy((byte*)(&att->val), (byte*)(&att->att.pos), 4);
                    }
                }
            }
        }
    }
}
