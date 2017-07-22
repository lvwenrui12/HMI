using System;
using hmitype;

public static class Attmake
{
    // Fields
    public const byte attnameqyt = 180;
    public static string[] attnames = new string[] {
        "lei", "vscope", "sta", "ch", "bco", "picc", "pic", "gdc", "gdw", "gdh", "pco0", "pco1", "pco2", "pco3", "mode", "psta",
        "pco", "pic2", "wid", "hig", "val", "maxval", "minval", "picc2", "bco2", "font", "xcen", "ycen", "txt", "txt_maxl", "dez", "bpic",
        "ppic", "tim", "en", "picc0", "picc1", "bco0", "bco1", "pic0", "pic1", "lenth", "x", "y", "endx", "endy", "w", "h",
        "dir", "id", "vvs0", "vvs1", "vvs2", "vvs3", "isbr", "dis", "spax", "spay", "pw", "style", "borderc", "borderw", "type", "key"
     };
    public static attstrtype_32[] attstr32;
    public const uint attstr32qyt = 0x35;
    public static attstrtype_64[] attstr64;
    public const uint attstr64qyt = 11;
    public static myappinf myapp;

    // Methods
    private static unsafe byte AttAdd_gui(byte* buf, runattinf* b1, runattinf* b2, runattinf* b3, byte yunsuan)
    {
        ushort index = 0;
        if ((((b1->attlei == attshulei.Sstr.typevalue) && (b2->attlei == attshulei.Sstr.typevalue)) && (b3->attlei == attshulei.Sstr.typevalue)) && (yunsuan == 0x2b))
        {
            if ((b1->datafrom == 0xfe) && (b1->Pz == b3->Pz))
            {
                if (Attmake_SetAtt(b2, b3, yunsuan) > 0)
                {
                    return 1;
                }
            }
            else if ((b2->datafrom == 0xfe) && (b2->Pz == b3->Pz))
            {
                if (Attmake_SetAtt(b1, b3, yunsuan) > 0)
                {
                    return 1;
                }
            }
            else
            {
                if (Attmake_SetAtt(b1, b3, 0) == 0)
                {
                    return 0;
                }
                if (Attmake_SetAtt(b2, b3, yunsuan) > 0)
                {
                    return 1;
                }
            }
        }
        else
        {
            if (((b2->attlei != attshulei.Sstr.typevalue) && (b3->attlei == attshulei.Sstr.typevalue)) && ((yunsuan == 0x2d) || ((yunsuan == 0x2b) && (b2->val < 0))))
            {
                index = Strmake.Strmake_GetStrlen_Encode(b3->Pz, b3->att.encodeh_star);
                if (b2->val >= index)
                {
                    b3->Pz[0] = 0;
                    return 1;
                }
                index = Strmake.Strmake_GetStrlen_Encode_Lenth(b3->Pz, b3->att.encodeh_star, (byte)(index - b2->val));
                b3->Pz[index] = 0;
                return 1;
            }
            if (((b1->attlei != attshulei.Sstr.typevalue) && (b2->attlei != attshulei.Sstr.typevalue)) && (b3->attlei != attshulei.Sstr.typevalue))
            {
                if (yunsuan == 0x2b)
                {
                    b3->val = b1->val + b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 0x2d)
                {
                    b3->val = b1->val - b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 0x2a)
                {
                    b3->val = b1->val * b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 0x2f)
                {
                    b3->val = (b2->val == 0) ? 0 : (b1->val / b2->val);
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 0x25)
                {
                    b3->val = b1->val % b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 0x7c)
                {
                    b3->val = b1->val | b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 0x26)
                {
                    b3->val = b1->val & b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 60)
                {
                    b3->val = b1->val << b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
                if (yunsuan == 0x3e)
                {
                    b3->val = b1->val >> b2->val;
                    return Attmake_SetAtt(b3, b3, 0);
                }
            }
        }
        myapp.errcode = 0x1b;
        return 0;
    }

    private static unsafe byte AttConvert_gui(runattinf* b1, runattinf* b2, byte lenth1, byte lenth2)
    {
        if ((b1->attlei != attshulei.Sstr.typevalue) && (b2->attlei == attshulei.Sstr.typevalue))
        {
            if (b2->datafrom != 0xfe)
            {
                myapp.errcode = 0x1b;
                return 0;
            }
            if (lenth1 == 0)
            {
                lenth1 = Strmake.Strmake_GetS32strlen(b1->val);
            }
            if (b2->att.merrylenth <= lenth1)
            {
                lenth1 = (byte)(b2->att.merrylenth - 1);
            }
            Strmake.Strmake_S32ToStr(b1->val, b2->Pz, lenth1, 1);
        }
        else
        {
            if ((b1->attlei == attshulei.Sstr.typevalue) && (b2->attlei != attshulei.Sstr.typevalue))
            {
                b2->val = Strmake.Strmake_StrToS32(b1->Pz, lenth1);
                return Attmake_SetAtt(b2, b2, 0);
            }
            myapp.errcode = 0x1b;
            return 0;
        }
        return 1;
    }

    public static void attinfUpToDown(this attinf_Up attup, ref attinf attdown, byte encodeh_star)
    {
        attdown.state = (byte)(attup.attlei & 15);
        if (attup.isxiugai == 1)
        {
            attdown.state = (byte)(attdown.state | 0x10);
        }
        if (attup.chonghui == 1)
        {
            attdown.state = (byte)(attdown.state | 0x20);
        }
        attdown.encodeh_star = encodeh_star;
        attdown.merrylenth = attup.merrylenth;
        attdown.pos = attup.pos;
        attdown.maxval = attup.maxval;
        attdown.minval = attup.minval;
    }

    public static void attinit()
    {
        attstrtype_32[] e_Array = new attstrtype_32[0x35];
        attstrtype_32 e_65 = new attstrtype_32();
        attstrtype_32 e_ = e_65;
        e_.name = "h\0\0\0".strtoU32();
        e_.id = 0x2f;
        e_.res0 = 0;
        e_.res1 = 0;
        e_.res2 = 0;
        e_Array[0] = e_;
        e_65 = new attstrtype_32();
        attstrtype_32 e_2 = e_65;
        e_2.name = "w\0\0\0".strtoU32();
        e_2.id = 0x2e;
        e_2.res0 = 0;
        e_2.res1 = 0;
        e_2.res2 = 0;
        e_Array[1] = e_2;
        e_65 = new attstrtype_32();
        attstrtype_32 e_3 = e_65;
        e_3.name = "x\0\0\0".strtoU32();
        e_3.id = 0x2a;
        e_3.res0 = 0;
        e_3.res1 = 0;
        e_3.res2 = 0;
        e_Array[2] = e_3;
        e_65 = new attstrtype_32();
        attstrtype_32 e_4 = e_65;
        e_4.name = "y\0\0\0".strtoU32();
        e_4.id = 0x2b;
        e_4.res0 = 0;
        e_4.res1 = 0;
        e_4.res2 = 0;
        e_Array[3] = e_4;
        e_65 = new attstrtype_32();
        attstrtype_32 e_5 = e_65;
        e_5.name = "id\0\0".strtoU32();
        e_5.id = 0x31;
        e_5.res0 = 0;
        e_5.res1 = 0;
        e_5.res2 = 0;
        e_Array[4] = e_5;
        e_65 = new attstrtype_32();
        attstrtype_32 e_6 = e_65;
        e_6.name = "ch\0\0".strtoU32();
        e_6.id = 3;
        e_6.res0 = 0;
        e_6.res1 = 0;
        e_6.res2 = 0;
        e_Array[5] = e_6;
        e_65 = new attstrtype_32();
        attstrtype_32 e_7 = e_65;
        e_7.name = "en\0\0".strtoU32();
        e_7.id = 0x22;
        e_7.res0 = 0;
        e_7.res1 = 0;
        e_7.res2 = 0;
        e_Array[6] = e_7;
        e_65 = new attstrtype_32();
        attstrtype_32 e_8 = e_65;
        e_8.name = "pw\0\0".strtoU32();
        e_8.id = 0x3a;
        e_8.res0 = 0;
        e_8.res1 = 0;
        e_8.res2 = 0;
        e_Array[7] = e_8;
        e_65 = new attstrtype_32();
        attstrtype_32 e_9 = e_65;
        e_9.name = "sta\0".strtoU32();
        e_9.id = 2;
        e_9.res0 = 0;
        e_9.res1 = 0;
        e_9.res2 = 0;
        e_Array[8] = e_9;
        e_65 = new attstrtype_32();
        attstrtype_32 e_10 = e_65;
        e_10.name = "gdc\0".strtoU32();
        e_10.id = 7;
        e_10.res0 = 0;
        e_10.res1 = 0;
        e_10.res2 = 0;
        e_Array[9] = e_10;
        e_65 = new attstrtype_32();
        attstrtype_32 e_11 = e_65;
        e_11.name = "pic\0".strtoU32();
        e_11.id = 6;
        e_11.res0 = 0;
        e_11.res1 = 0;
        e_11.res2 = 0;
        e_Array[10] = e_11;
        e_65 = new attstrtype_32();
        attstrtype_32 e_12 = e_65;
        e_12.name = "wid\0".strtoU32();
        e_12.id = 0x12;
        e_12.res0 = 0;
        e_12.res1 = 0;
        e_12.res2 = 0;
        e_Array[11] = e_12;
        e_65 = new attstrtype_32();
        attstrtype_32 e_13 = e_65;
        e_13.name = "hig\0".strtoU32();
        e_13.id = 0x13;
        e_13.res0 = 0;
        e_13.res1 = 0;
        e_13.res2 = 0;
        e_Array[12] = e_13;
        e_65 = new attstrtype_32();
        attstrtype_32 e_14 = e_65;
        e_14.name = "gdh\0".strtoU32();
        e_14.id = 9;
        e_14.res0 = 0;
        e_14.res1 = 0;
        e_14.res2 = 0;
        e_Array[13] = e_14;
        e_65 = new attstrtype_32();
        attstrtype_32 e_15 = e_65;
        e_15.name = "lei\0".strtoU32();
        e_15.id = 0;
        e_15.res0 = 0;
        e_15.res1 = 0;
        e_15.res2 = 0;
        e_Array[14] = e_15;
        e_65 = new attstrtype_32();
        attstrtype_32 e_16 = e_65;
        e_16.name = "val\0".strtoU32();
        e_16.id = 20;
        e_16.res0 = 0;
        e_16.res1 = 0;
        e_16.res2 = 0;
        e_Array[15] = e_16;
        e_65 = new attstrtype_32();
        attstrtype_32 e_17 = e_65;
        e_17.name = "tim\0".strtoU32();
        e_17.id = 0x21;
        e_17.res0 = 0;
        e_17.res1 = 0;
        e_17.res2 = 0;
        e_Array[0x10] = e_17;
        e_65 = new attstrtype_32();
        attstrtype_32 e_18 = e_65;
        e_18.name = "bco\0".strtoU32();
        e_18.id = 4;
        e_18.res0 = 0;
        e_18.res1 = 0;
        e_18.res2 = 0;
        e_Array[0x11] = e_18;
        e_65 = new attstrtype_32();
        attstrtype_32 e_19 = e_65;
        e_19.name = "pco\0".strtoU32();
        e_19.id = 0x10;
        e_19.res0 = 0;
        e_19.res1 = 0;
        e_19.res2 = 0;
        e_Array[0x12] = e_19;
        e_65 = new attstrtype_32();
        attstrtype_32 e_20 = e_65;
        e_20.name = "dir\0".strtoU32();
        e_20.id = 0x30;
        e_20.res0 = 0;
        e_20.res1 = 0;
        e_20.res2 = 0;
        e_Array[0x13] = e_20;
        e_65 = new attstrtype_32();
        attstrtype_32 e_21 = e_65;
        e_21.name = "dis\0".strtoU32();
        e_21.id = 0x37;
        e_21.res0 = 0;
        e_21.res1 = 0;
        e_21.res2 = 0;
        e_Array[20] = e_21;
        e_65 = new attstrtype_32();
        attstrtype_32 e_22 = e_65;
        e_22.name = "txt\0".strtoU32();
        e_22.id = 0x1c;
        e_22.res0 = 0;
        e_22.res1 = 0;
        e_22.res2 = 0;
        e_Array[0x15] = e_22;
        e_65 = new attstrtype_32();
        attstrtype_32 e_23 = e_65;
        e_23.name = "gdw\0".strtoU32();
        e_23.id = 8;
        e_23.res0 = 0;
        e_23.res1 = 0;
        e_23.res2 = 0;
        e_Array[0x16] = e_23;
        e_65 = new attstrtype_32();
        attstrtype_32 e_24 = e_65;
        e_24.name = "key\0".strtoU32();
        e_24.id = 0x3f;
        e_24.res0 = 0;
        e_24.res1 = 0;
        e_24.res2 = 0;
        e_Array[0x17] = e_24;
        e_65 = new attstrtype_32();
        attstrtype_32 e_25 = e_65;
        e_25.name = "dez\0".strtoU32();
        e_25.id = 30;
        e_25.res0 = 0;
        e_25.res1 = 0;
        e_25.res2 = 0;
        e_Array[0x18] = e_25;
        e_65 = new attstrtype_32();
        attstrtype_32 e_26 = e_65;
        e_26.name = "pic0".strtoU32();
        e_26.id = 0x27;
        e_26.res0 = 0;
        e_26.res1 = 0;
        e_26.res2 = 0;
        e_Array[0x19] = e_26;
        e_65 = new attstrtype_32();
        attstrtype_32 e_27 = e_65;
        e_27.name = "bco0".strtoU32();
        e_27.id = 0x25;
        e_27.res0 = 0;
        e_27.res1 = 0;
        e_27.res2 = 0;
        e_Array[0x1a] = e_27;
        e_65 = new attstrtype_32();
        attstrtype_32 e_28 = e_65;
        e_28.name = "pco0".strtoU32();
        e_28.id = 10;
        e_28.res0 = 0;
        e_28.res1 = 0;
        e_28.res2 = 0;
        e_Array[0x1b] = e_28;
        e_65 = new attstrtype_32();
        attstrtype_32 e_29 = e_65;
        e_29.name = "vvs0".strtoU32();
        e_29.id = 50;
        e_29.res0 = 0;
        e_29.res1 = 0;
        e_29.res2 = 0;
        e_Array[0x1c] = e_29;
        e_65 = new attstrtype_32();
        attstrtype_32 e_30 = e_65;
        e_30.name = "pic1".strtoU32();
        e_30.id = 40;
        e_30.res0 = 0;
        e_30.res1 = 0;
        e_30.res2 = 0;
        e_Array[0x1d] = e_30;
        e_65 = new attstrtype_32();
        attstrtype_32 e_31 = e_65;
        e_31.name = "bco1".strtoU32();
        e_31.id = 0x26;
        e_31.res0 = 0;
        e_31.res1 = 0;
        e_31.res2 = 0;
        e_Array[30] = e_31;
        e_65 = new attstrtype_32();
        attstrtype_32 e_32 = e_65;
        e_32.name = "pco1".strtoU32();
        e_32.id = 11;
        e_32.res0 = 0;
        e_32.res1 = 0;
        e_32.res2 = 0;
        e_Array[0x1f] = e_32;
        e_65 = new attstrtype_32();
        attstrtype_32 e_33 = e_65;
        e_33.name = "vvs1".strtoU32();
        e_33.id = 0x33;
        e_33.res0 = 0;
        e_33.res1 = 0;
        e_33.res2 = 0;
        e_Array[0x20] = e_33;
        e_65 = new attstrtype_32();
        attstrtype_32 e_34 = e_65;
        e_34.name = "pic2".strtoU32();
        e_34.id = 0x11;
        e_34.res0 = 0;
        e_34.res1 = 0;
        e_34.res2 = 0;
        e_Array[0x21] = e_34;
        e_65 = new attstrtype_32();
        attstrtype_32 e_35 = e_65;
        e_35.name = "bco2".strtoU32();
        e_35.id = 0x18;
        e_35.res0 = 0;
        e_35.res1 = 0;
        e_35.res2 = 0;
        e_Array[0x22] = e_35;
        e_65 = new attstrtype_32();
        attstrtype_32 e_36 = e_65;
        e_36.name = "pco2".strtoU32();
        e_36.id = 12;
        e_36.res0 = 0;
        e_36.res1 = 0;
        e_36.res2 = 0;
        e_Array[0x23] = e_36;
        e_65 = new attstrtype_32();
        attstrtype_32 e_37 = e_65;
        e_37.name = "vvs2".strtoU32();
        e_37.id = 0x34;
        e_37.res0 = 0;
        e_37.res1 = 0;
        e_37.res2 = 0;
        e_Array[0x24] = e_37;
        e_65 = new attstrtype_32();
        attstrtype_32 e_38 = e_65;
        e_38.name = "pco3".strtoU32();
        e_38.id = 13;
        e_38.res0 = 0;
        e_38.res1 = 0;
        e_38.res2 = 0;
        e_Array[0x25] = e_38;
        e_65 = new attstrtype_32();
        attstrtype_32 e_39 = e_65;
        e_39.name = "vvs3".strtoU32();
        e_39.id = 0x35;
        e_39.res0 = 0;
        e_39.res1 = 0;
        e_39.res2 = 0;
        e_Array[0x26] = e_39;
        e_65 = new attstrtype_32();
        attstrtype_32 e_40 = e_65;
        e_40.name = "psta".strtoU32();
        e_40.id = 15;
        e_40.res0 = 0;
        e_40.res1 = 0;
        e_40.res2 = 0;
        e_Array[0x27] = e_40;
        e_65 = new attstrtype_32();
        attstrtype_32 e_41 = e_65;
        e_41.name = "picc".strtoU32();
        e_41.id = 5;
        e_41.res0 = 0;
        e_41.res1 = 0;
        e_41.res2 = 0;
        e_Array[40] = e_41;
        e_65 = new attstrtype_32();
        attstrtype_32 e_42 = e_65;
        e_42.name = "bpic".strtoU32();
        e_42.id = 0x1f;
        e_42.res0 = 0;
        e_42.res1 = 0;
        e_42.res2 = 0;
        e_Array[0x29] = e_42;
        e_65 = new attstrtype_32();
        attstrtype_32 e_43 = e_65;
        e_43.name = "ppic".strtoU32();
        e_43.id = 0x20;
        e_43.res0 = 0;
        e_43.res1 = 0;
        e_43.res2 = 0;
        e_Array[0x2a] = e_43;
        e_65 = new attstrtype_32();
        attstrtype_32 e_44 = e_65;
        e_44.name = "mode".strtoU32();
        e_44.id = 14;
        e_44.res0 = 0;
        e_44.res1 = 0;
        e_44.res2 = 0;
        e_Array[0x2b] = e_44;
        e_65 = new attstrtype_32();
        attstrtype_32 e_45 = e_65;
        e_45.name = "type".strtoU32();
        e_45.id = 0x3e;
        e_45.res0 = 0;
        e_45.res1 = 0;
        e_45.res2 = 0;
        e_Array[0x2c] = e_45;
        e_65 = new attstrtype_32();
        attstrtype_32 e_46 = e_65;
        e_46.name = "xcen".strtoU32();
        e_46.id = 0x1a;
        e_46.res0 = 0;
        e_46.res1 = 0;
        e_46.res2 = 0;
        e_Array[0x2d] = e_46;
        e_65 = new attstrtype_32();
        attstrtype_32 e_47 = e_65;
        e_47.name = "ycen".strtoU32();
        e_47.id = 0x1b;
        e_47.res0 = 0;
        e_47.res1 = 0;
        e_47.res2 = 0;
        e_Array[0x2e] = e_47;
        e_65 = new attstrtype_32();
        attstrtype_32 e_48 = e_65;
        e_48.name = "isbr".strtoU32();
        e_48.id = 0x36;
        e_48.res0 = 0;
        e_48.res1 = 0;
        e_48.res2 = 0;
        e_Array[0x2f] = e_48;
        e_65 = new attstrtype_32();
        attstrtype_32 e_49 = e_65;
        e_49.name = "font".strtoU32();
        e_49.id = 0x19;
        e_49.res0 = 0;
        e_49.res1 = 0;
        e_49.res2 = 0;
        e_Array[0x30] = e_49;
        e_65 = new attstrtype_32();
        attstrtype_32 e_50 = e_65;
        e_50.name = "spax".strtoU32();
        e_50.id = 0x38;
        e_50.res0 = 0;
        e_50.res1 = 0;
        e_50.res2 = 0;
        e_Array[0x31] = e_50;
        e_65 = new attstrtype_32();
        attstrtype_32 e_51 = e_65;
        e_51.name = "endx".strtoU32();
        e_51.id = 0x2c;
        e_51.res0 = 0;
        e_51.res1 = 0;
        e_51.res2 = 0;
        e_Array[50] = e_51;
        e_65 = new attstrtype_32();
        attstrtype_32 e_52 = e_65;
        e_52.name = "spay".strtoU32();
        e_52.id = 0x39;
        e_52.res0 = 0;
        e_52.res1 = 0;
        e_52.res2 = 0;
        e_Array[0x33] = e_52;
        attstrtype_32 e_53 = new attstrtype_32
        {
            name = "endy".strtoU32(),
            id = 0x2d,
            res0 = 0,
            res1 = 0,
            res2 = 0
        };
        e_Array[0x34] = e_53;
        attstr32 = e_Array;
        attstrtype_64[] e_Array2 = new attstrtype_64[11];
        attstrtype_64 e_66 = new attstrtype_64();
        attstrtype_64 e_54 = e_66;
        e_54.name = "picc0\0\0\0".strtoU64();
        e_54.id = 0x23;
        e_54.res0 = 0;
        e_54.res1 = 0;
        e_54.res2 = 0;
        e_Array2[0] = e_54;
        e_66 = new attstrtype_64();
        attstrtype_64 e_55 = e_66;
        e_55.name = "picc1\0\0\0".strtoU64();
        e_55.id = 0x24;
        e_55.res0 = 0;
        e_55.res1 = 0;
        e_55.res2 = 0;
        e_Array2[1] = e_55;
        e_66 = new attstrtype_64();
        attstrtype_64 e_56 = e_66;
        e_56.name = "picc2\0\0\0".strtoU64();
        e_56.id = 0x17;
        e_56.res0 = 0;
        e_56.res1 = 0;
        e_56.res2 = 0;
        e_Array2[2] = e_56;
        e_66 = new attstrtype_64();
        attstrtype_64 e_57 = e_66;
        e_57.name = "style\0\0\0".strtoU64();
        e_57.id = 0x3b;
        e_57.res0 = 0;
        e_57.res1 = 0;
        e_57.res2 = 0;
        e_Array2[3] = e_57;
        e_66 = new attstrtype_64();
        attstrtype_64 e_58 = e_66;
        e_58.name = "lenth\0\0\0".strtoU64();
        e_58.id = 0x29;
        e_58.res0 = 0;
        e_58.res1 = 0;
        e_58.res2 = 0;
        e_Array2[4] = e_58;
        e_66 = new attstrtype_64();
        attstrtype_64 e_59 = e_66;
        e_59.name = "vscope\0\0".strtoU64();
        e_59.id = 1;
        e_59.res0 = 0;
        e_59.res1 = 0;
        e_59.res2 = 0;
        e_Array2[5] = e_59;
        e_66 = new attstrtype_64();
        attstrtype_64 e_60 = e_66;
        e_60.name = "minval\0\0".strtoU64();
        e_60.id = 0x16;
        e_60.res0 = 0;
        e_60.res1 = 0;
        e_60.res2 = 0;
        e_Array2[6] = e_60;
        e_66 = new attstrtype_64();
        attstrtype_64 e_61 = e_66;
        e_61.name = "maxval\0\0".strtoU64();
        e_61.id = 0x15;
        e_61.res0 = 0;
        e_61.res1 = 0;
        e_61.res2 = 0;
        e_Array2[7] = e_61;
        e_66 = new attstrtype_64();
        attstrtype_64 e_62 = e_66;
        e_62.name = "borderc\0".strtoU64();
        e_62.id = 60;
        e_62.res0 = 0;
        e_62.res1 = 0;
        e_62.res2 = 0;
        e_Array2[8] = e_62;
        e_66 = new attstrtype_64();
        attstrtype_64 e_63 = e_66;
        e_63.name = "borderw\0".strtoU64();
        e_63.id = 0x3d;
        e_63.res0 = 0;
        e_63.res1 = 0;
        e_63.res2 = 0;
        e_Array2[9] = e_63;
        attstrtype_64 e_64 = new attstrtype_64
        {
            name = "txt_maxl".strtoU64(),
            id = 0x1d,
            res0 = 0,
            res1 = 0,
            res2 = 0
        };
        e_Array2[10] = e_64;
        attstr64 = e_Array2;
    }

    public static unsafe byte Attmake_AttAdd(byte* buf, ref runattinf b1, ref runattinf b2, ref runattinf b3, byte yunsuan)
    {
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

    public static unsafe byte Attmake_AttAdd(byte* buf, runattinf* b1, runattinf* b2, runattinf* b3, byte yunsuan)
    {
        byte num = AttAdd_gui(buf, b1, b2, b3, yunsuan);
        if (((num == 1) && (b3->isref == 1)) && (b3->att.pageid == myapp.dpage))
        {
            myapp.pageobjs[b3->att.objid].refFlag = 1;
        }
        return num;
    }

    public static unsafe byte Attmake_AttConvert(ref runattinf b1, ref runattinf b2, byte lenth1, byte lenth2)
    {
        byte num;
        fixed (runattinf* runattinfRef = (&b1))
        {
            fixed (runattinf* runattinfRef2 = (&b2))
            {
                num = Attmake_AttConvert(runattinfRef, runattinfRef2, lenth1, lenth2);
            }
        }
        return num;
    }

    public static unsafe byte Attmake_AttConvert(runattinf* b1, runattinf* b2, byte lenth1, byte lenth2)
    {
        byte num = AttConvert_gui(b1, b2, lenth1, lenth2);
        if (((num == 1) && (b2->isref == 1)) && (b2->att.pageid == myapp.dpage))
        {
            myapp.pageobjs[b2->att.objid].refFlag = 1;
        }
        return num;
    }

    public static unsafe void Attmake_GetAtt(byte* buf, PosLaction* bufpos, runattinf* att)
    {
        PosLaction laction = new PosLaction();
        pagexinxi page = new pagexinxi();
        strxinxi str = new strxinxi();
        uint add = 0;
        ushort index = 0;
        ushort num5 = 0;
        ushort num6 = 0;
        ushort num7 = 0;
        att->datafrom = 0xff;
        att->isref = 0;
        if (buf[bufpos->star] != 0x2e)
        {
            uint attdatapos;
            if (buf[bufpos->star] == 1)
            {
                Kuozhan.memcpy((byte*)&attdatapos, buf + (bufpos->star + 1), 4);
                attdatapos = (uint)(attdatapos * datasize.attxinxisize);
                attdatapos += myapp.app.attdatapos;
            }
            else
            {
                for (uint i = bufpos->star; i <= bufpos->end; i++)
                {
                    if (buf[i] < 9)
                    {
                        i += 5;
                    }
                    if ((buf[i] == 0x2e) && (add != 1))
                    {
                        if (num6 == 0)
                        {
                            num6 = (ushort)i;
                            continue;
                        }
                        if (num7 == 0)
                        {
                            num7 = (ushort)i;
                            continue;
                        }
                        return;
                    }
                    if (buf[i] == 0x5b)
                    {
                        add = 1;
                    }
                    else if (buf[i] == 0x5d)
                    {
                        add = 2;
                    }
                }
                if (num6 == 0)
                {
                    Sysatt.Sysatt_GetSysname(buf + bufpos->star, (byte)((bufpos->end - bufpos->star) + 1), att);
                    return;
                }
                laction.star = bufpos->star;
                laction.end = (ushort)(num6 - 1);
                if (num7 > 0)
                {
                    index = Hmi.Hmi_GetPageid(buf, &laction);
                    if (index == 0xffff)
                    {
                        return;
                    }
                    laction.star = (ushort)(num6 + 1);
                    laction.end = (ushort)(num7 - 1);
                    if (index == myapp.dpage)
                    {
                        num5 = Hmi.Hmi_GetObjid(buf, &laction, myapp.dobjnameseradd, myapp.dpagexinxi.objqyt);
                        attdatapos = myapp.dpagexinxi.attdatapos;
                    }
                    else
                    {
                        Readdata.Readdata_ReadPage(ref page, index);
                        Readdata.Readdata_ReadStr(ref str, page.zhilingstar);
                        num5 = Hmi.Hmi_GetObjid(buf, &laction, str.addbeg + myapp.app.strdataadd, page.objqyt);
                        attdatapos = page.attdatapos;
                    }
                    laction.star = (ushort)(num7 + 1);
                }
                else
                {
                    index = myapp.dpage;
                    num5 = Hmi.Hmi_GetObjid(buf, &laction, myapp.dobjnameseradd, myapp.dpagexinxi.objqyt);
                    laction.star = (ushort)(num6 + 1);
                    attdatapos = myapp.dpagexinxi.attdatapos;
                }
                laction.end = bufpos->end;
                if ((num5 == 0xffff) || (laction.star > laction.end))
                {
                    return;
                }
                num6 = Attmake_GetAttindex(buf + laction.star, (byte)((laction.end - laction.star) + 1));
                if (num6 == 0xff)
                {
                    return;
                }
                if (index != myapp.dpage)
                {
                    add = myapp.app.objadd + ((uint)(((ushort)(num5 + page.objstar)) * (datasize.objxinxisize + 180)));
                    num7 = 0;
                    Readdata.SPI_Flash_Read((byte*)&num7, add + 15, 1);
                    if (num7 != 1)
                    {
                        return;
                    }
                }
                else
                {
                    add = myapp.app.objadd + ((uint)(((ushort)(num5 + myapp.dpagexinxi.objstar)) * (datasize.objxinxisize + 180)));
                }
                Readdata.SPI_Flash_Read((byte*)&num6, (uint)((add + datasize.objxinxisize) + (num6 * 2)), 2);
                if (num6 == 0xffff)
                {
                    return;
                }
                attdatapos += (uint)(datasize.attxinxisize * num6);
            }
            add = myapp.app.strdataadd + attdatapos;
            Readdata.SPI_Flash_Read((byte*)&att->att, add, (uint)datasize.attxinxisize);
            att->attlei = (byte)(att->att.state & 15);
            if ((att->att.state & 0x10) > 0)
            {
                att->isxiugai = 1;
                att->datafrom = 0xfe;
                att->Pz = myapp.mymerry + att->att.pos;
            }
            else
            {
                att->isxiugai = 0;
                if (att->attlei != attshulei.Sstr.typevalue)
                {
                    att->datafrom = 0xfd;
                }
                else
                {
                    att->datafrom = 0xfc;
                }
            }
            if ((att->att.state & 0x20) > 0)
            {
                att->isref = 1;
            }
            if (att->attlei != attshulei.Sstr.typevalue)
            {
                att->val = 0;
                if (att->datafrom == 0xfe)
                {
                    if (att->attlei == attshulei.SS16.typevalue)
                    {
                        short num8 = 0;
                        Kuozhan.memcpy((byte*)&num8, myapp.mymerry + att->att.pos, att->att.merrylenth);
                        att->val = num8;
                    }
                    else
                    {
                        Kuozhan.memcpy((byte*)&att->val, myapp.mymerry + att->att.pos, att->att.merrylenth);
                    }
                }
                else
                {
                    Kuozhan.memcpy((byte*)&att->val, (byte*)&att->att.pos, 4);
                }
            }
        }
    }

    // hmitype.Attmake
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


    public static unsafe ushort Attmake_GetstrAtt(byte* buf, ref PosLaction thispos, ref runattinf att)
    {
        ushort num;
        fixed (PosLaction* lactionRef = (&thispos))
        {
            fixed (runattinf* runattinfRef = (&att))
            {
                num = Attmake_GetstrAtt(buf, lactionRef, runattinfRef);
            }
        }
        return num;
    }

    public static unsafe ushort Attmake_GetstrAtt(byte* buf, PosLaction* bufpos, runattinf* att)
    {
        ushort star = bufpos->star;
        ushort num3 = 0;
        ushort index = 0;
        PosLaction laction = new PosLaction();
        att->datafrom = 0xff;
        att->isref = 0;
        if (bufpos->end < bufpos->star)
        {
            myapp.errcode = 0x1a;
            return 0xffff;
        }
        if (buf[star] != 0x22)
        {
            if ((((buf[star] >= 9) || (buf[star] <= 1)) && (buf[star] != 0x2d)) && ((buf[star] <= 0x2f) || (buf[star] >= 0x3a)))
            {
                laction.star = bufpos->star;
                if (Strmake.Strmake_IsAttendbyte(buf[star]) == 1)
                {
                    myapp.errcode = 0x1a;
                    return 0xffff;
                }
                int num = 0;
                while (star <= bufpos->end)
                {
                    num3 = 0;
                    while (star <= bufpos->end)
                    {
                        if (buf[star] < 9)
                        {
                            num3 = (ushort)(num3 + 5);
                            star = (ushort)(star + 5);
                        }
                        if ((num == 0) && (Strmake.Strmake_IsAttendbyte(buf[star]) == 1))
                        {
                            star = (ushort)(star - 1);
                            break;
                        }
                        if (buf[star] == 0x5b)
                        {
                            num++;
                        }
                        else if (buf[star] == 0x5d)
                        {
                            num--;
                        }
                        if (num3 == 0x31)
                        {
                            myapp.errcode = 0x23;
                            return 0xffff;
                        }
                        num3 = (ushort)(num3 + 1);
                        star = (ushort)(star + 1);
                    }
                    if (star > bufpos->end)
                    {
                        star = bufpos->end;
                    }
                    laction.end = star;
                    Attmake_GetAtt(buf, &laction, att);
                    if (att->datafrom == 0xff)
                    {
                        myapp.errcode = 0x1a;
                        return 0xffff;
                    }
                    return star;
                }
                myapp.errcode = 0x1a;
                return 0xffff;
            }
            if (buf[star] < 9)
            {
                if (buf[star] == 3)
                {
                    Kuozhan.memcpy((byte*)&att->val, buf + (star + 1), 4);
                    att->datafrom = 0xfd;
                    att->att.merrylenth = 4;
                    att->attlei = attshulei.SS32.typevalue;
                    att->isxiugai = 0;
                }
                else if (buf[bufpos->star] == 2)
                {
                    att->datafrom = 0xfc;
                    Kuozhan.memcpy((byte*)&att->att.pos, buf + (bufpos->star + 1), 4);
                    att->att.state = attshulei.Sstr.typevalue;
                    att->isxiugai = 0;
                }
                else if (buf[bufpos->star] == 4)
                {
                    Sysatt.Sysatt_GetXitongval(buf[bufpos->star + 1], buf[bufpos->star + 2], att);
                }
                return (ushort)(star + 4);
            }
            if (buf[star] == 0x2d)
            {
                star = (ushort)(star + 1);
            }
            while (star <= bufpos->end)
            {
                if ((buf[star] < 0x30) || (buf[star] > 0x39))
                {
                    star = (ushort)(star - 1);
                    break;
                }
                if (star == bufpos->end)
                {
                    break;
                }
                star = (ushort)(star + 1);
            }
        }
        else
        {
            buf[star] = 0;
            star = (ushort)(star + 1);
            num3 = 0xffff;
            index = star;
            while (star <= bufpos->end)
            {
                if (buf[star] == 0x5c)
                {
                    if (star == bufpos->end)
                    {
                        myapp.errcode = 0x20;
                        return 0xffff;
                    }
                    star = (ushort)(star + 1);
                    if ((buf[star] == 0x5c) || (buf[star] == 0x22))
                    {
                        buf[index] = buf[star];
                    }
                    else if (buf[star] == 0x72)
                    {
                        buf[index] = 13;
                        index = (ushort)(index + 1);
                        buf[index] = 10;
                    }
                    else
                    {
                        myapp.errcode = 0x20;
                        return 0xffff;
                    }
                    if (star == bufpos->end)
                    {
                        myapp.errcode = 0x20;
                        return 0xffff;
                    }
                    star = (ushort)(star + 1);
                    index = (ushort)(index + 1);
                }
                else
                {
                    buf[index] = buf[star];
                    if (buf[star] == 0x22)
                    {
                        buf[index] = 0;
                        num3 = star;
                        break;
                    }
                    star = (ushort)(star + 1);
                    index = (ushort)(index + 1);
                }
            }
            if (num3 != 0xffff)
            {
                att->att.pos = (ushort)(bufpos->star + 1);
                att->attlei = attshulei.Sstr.typevalue;
                att->att.merrylenth = (ushort)(index - bufpos->star);
                att->datafrom = 0xfd;
                att->isxiugai = 0;
                att->Pz = buf + att->att.pos;
                att->att.encodeh_star = myapp.encodeh_star;
                return num3;
            }
            myapp.errcode = 0x1a;
            return 0xffff;
        }
        att->val = Strmake.Strmake_StrToS32(buf + bufpos->star, (byte)((star - bufpos->star) + 1));
        att->datafrom = 0xfd;
        att->att.merrylenth = 4;
        att->attlei = attshulei.SS32.typevalue;
        att->isxiugai = 0;
        return star;
    }

    public static unsafe byte Attmake_Makeatt(byte* buf, runattinf* b1, runattinf* b2, byte yunsuan)
    {
        if ((b2->attlei != attshulei.Sstr.typevalue) && (b2->attlei != attshulei.Sstr.typevalue))
        {
            if (yunsuan == 1)
            {
                if (b1->val == b2->val)
                {
                    return 1;
                }
                return 0;
            }
            if (yunsuan == 2)
            {
                if (b1->val < b2->val)
                {
                    return 1;
                }
                return 0;
            }
            if (yunsuan == 3)
            {
                if (b1->val > b2->val)
                {
                    return 1;
                }
                return 0;
            }
            if (yunsuan == 4)
            {
                if (b1->val <= b2->val)
                {
                    return 1;
                }
                return 0;
            }
            if (yunsuan == 5)
            {
                if (b1->val >= b2->val)
                {
                    return 1;
                }
                return 0;
            }
            if (yunsuan == 6)
            {
                if (b1->val != b2->val)
                {
                    return 1;
                }
                return 0;
            }
        }
        else if (((b2->attlei == attshulei.Sstr.typevalue) && (b1->attlei == attshulei.Sstr.typevalue)) && ((yunsuan == 1) || (yunsuan == 6)))
        {
            if (Strmake.Strmake_Makestr(b1->Pz, b2->Pz, 0) == 1)
            {
                if (yunsuan == 1)
                {
                    return 1;
                }
                return 0;
            }
            if (yunsuan == 1)
            {
                return 0;
            }
            return 1;
        }
        return 0;
    }

    public static unsafe byte Attmake_SetAtt(ref runattinf b1, ref runattinf b2, byte yunsuan)
    {
        byte num;
        fixed (runattinf* runattinfRef = (&b1))
        {
            fixed (runattinf* runattinfRef2 = (&b2))
            {
                num = Attmake_SetAtt(runattinfRef, runattinfRef2, yunsuan);
            }
        }
        return num;
    }

    public static unsafe byte Attmake_SetAtt(runattinf* b1, runattinf* b2, byte yunsuan)
    {
        byte num = SetAtt_gui(b1, b2, yunsuan);
        if (((num == 1) && (b2->isref == 1)) && (b2->att.pageid == myapp.dpage))
        {
            myapp.pageobjs[b2->att.objid].refFlag = 1;
        }
        return num;
    }

    public static int getbytestoint(this byte[] bytes, int memorylenth, byte attlei)
    {
        int num = 0;
        if ((bytes.Length == 0) || (memorylenth > bytes.Length))
        {
            return 0;
        }
        if (memorylenth == 1)
        {
            return bytes[0];
        }
        if (memorylenth == 2)
        {
            if ((attlei & 15) == attshulei.UU16.typevalue)
            {
                num = (ushort)bytes.BytesTostruct(((ushort)0).GetType());
            }
            else
            {
                num = (short)bytes.BytesTostruct(((short)0).GetType());
            }
            return num;
        }
        if (memorylenth == 4)
        {
            num = (int)bytes.BytesTostruct(0.GetType());
        }
        return num;
    }

    private static unsafe byte SetAtt_gui(runattinf* b1, runattinf* b2, byte yunsuan)
    {
        if (b2->isxiugai == 1)
        {
            if (((b2->attlei != attshulei.Sstr.typevalue) && (b1->attlei != attshulei.Sstr.typevalue)) && (yunsuan == 0))
            {
                if (b2->datafrom == 0xfd)
                {
                    b2->val = b2->val;
                    return 1;
                }
                if ((b1->val > b2->att.maxval) || (b1->val < b2->att.minval))
                {
                    myapp.errcode = 0x1c;
                    return 0;
                }
                if (b2->datafrom == 0xfe)
                {
                    if (b2->att.merrylenth == 2)
                    {
                        if (b1->attlei == attshulei.UU16.typevalue)
                        {
                            ushort val = (ushort)b1->val;
                            Kuozhan.memcpy(b2->Pz, (byte*)&val, b2->att.merrylenth);
                        }
                        else
                        {
                            short num4 = (short)b1->val;
                            Kuozhan.memcpy(b2->Pz, (byte*)&num4, b2->att.merrylenth);
                        }
                    }
                    else
                    {
                        Kuozhan.memcpy(b2->Pz, (byte*)&b1->val, b2->att.merrylenth);
                    }
                    return 1;
                }
                switch (Sysatt.Sysatt_SetXitongval(b2->datafrom, b1->val))
                {
                    case 1:
                        return 1;

                    case 2:
                        myapp.errcode = 0xff;
                        return 0;
                }
            }
            else if (((b2->attlei == attshulei.Sstr.typevalue) && (b1->attlei == attshulei.Sstr.typevalue)) && (b2->datafrom == 0xfe))
            {
                ushort num3;
                ushort num = Strmake.Strmake_GetStrlen(b1->Pz);
                ushort num2 = Strmake.Strmake_GetStrlen(b2->Pz);
                byte* pz = b2->Pz;
                if (yunsuan == 0x2b)
                {
                    pz += num2;
                    num3 = (ushort)((b2->att.merrylenth - num2) - 1);
                }
                else
                {
                    num3 = (ushort)(b2->att.merrylenth - 1);
                }
                if (num3 > num)
                {
                    num3 = num;
                }
                Kuozhan.memcpy(pz, b1->Pz, num3);
                pz[num3] = 0;
                return 1;
            }
        }
        myapp.errcode = 0x1c;
        return 0;
    }
}




