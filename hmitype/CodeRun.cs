using System;

namespace hmitype
{
    public static class CodeRun
    {
        public unsafe delegate byte comrun_(int* can, byte state, byte* buf, runattinf* att);

        public static myappinf myapp;

        public static comtype_32[] com32 = new comtype_32[0];

        public static comtype_64[] com64 = new comtype_64[0];

        public static byte com32qyt;

        public static byte com64qyt;

        public static unsafe CodeRun.comrun_[] comrun = new CodeRun.comrun_[]
        {
            new CodeRun.comrun_(CodeRun.gui_c1com),
            new CodeRun.comrun_(CodeRun.gui_xstr),
            new CodeRun.comrun_(CodeRun.gui_eepr),
            new CodeRun.comrun_(CodeRun.gui_gpio),
            new CodeRun.comrun_(CodeRun.gui_sys),
            new CodeRun.comrun_(CodeRun.gui_chuchang),
            new CodeRun.comrun_(CodeRun.gui_input)
        };

        private unsafe static byte jiexicans(byte* buf, int index, int bufbeg, int qyt, byte lei, ref runattinf[] runatt)
        {
            byte result;
            fixed (runattinf* ptr = runatt)
            {
                result = CodeRun.jiexicans(buf, index, bufbeg, qyt, lei, ptr);
            }
            return result;
        }

        public static void Cominit()
        {
            CodeRun.com64 = new comtype_64[]
            {
                new comtype_64
                {
                    name = "click\0\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 2,
                    canlei = 111,
                    res = 35
                },
                new comtype_64
                {
                    name = "comok\0\0\0".strtoU64(),
                    comindex = 5,
                    canqyt = 7,
                    canlei = 255,
                    res = 0
                },
                new comtype_64
                {
                    name = "btlen\0\0\0".strtoU64(),
                    comindex = 1,
                    canqyt = 2,
                    canlei = 102,
                    res = 8
                },
                new comtype_64
                {
                    name = "ifvis\0\0\0".strtoU64(),
                    comindex = 4,
                    canqyt = 2,
                    canlei = 0,
                    res = 2
                },
                new comtype_64
                {
                    name = "print\0\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 101,
                    res = 17
                },
                new comtype_64
                {
                    name = "code_c\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 24
                },
                new comtype_64
                {
                    name = "draw3d\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 7,
                    canlei = 0,
                    res = 12
                },
                new comtype_64
                {
                    name = "ifload\0\0".strtoU64(),
                    comindex = 4,
                    canqyt = 2,
                    canlei = 0,
                    res = 1
                },
                new comtype_64
                {
                    name = "sendme\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 18
                },
                new comtype_64
                {
                    name = "draw_h\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 6,
                    canlei = 0,
                    res = 1
                },
                new comtype_64
                {
                    name = "printh\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 255,
                    res = 25
                },
                new comtype_64
                {
                    name = "strlen\0\0".strtoU64(),
                    comindex = 1,
                    canqyt = 2,
                    canlei = 102,
                    res = 2
                },
                new comtype_64
                {
                    name = "cfgpio\0\0".strtoU64(),
                    comindex = 3,
                    canqyt = 3,
                    canlei = 11,
                    res = 0
                },
                new comtype_64
                {
                    name = "showqq\0\0".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 3
                },
                new comtype_64
                {
                    name = "substr\0\0".strtoU64(),
                    comindex = 1,
                    canqyt = 4,
                    canlei = 102,
                    res = 7
                },
                new comtype_64
                {
                    name = "pa_txt\0\0".strtoU64(),
                    comindex = 6,
                    canqyt = 4,
                    canlei = 102,
                    res = 1
                },
                new comtype_64
                {
                    name = "strsize\0".strtoU64(),
                    comindex = 1,
                    canqyt = 3,
                    canlei = 103,
                    res = 3
                },
                new comtype_64
                {
                    name = "touch_j\0".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 19
                },
                new comtype_64
                {
                    name = "randset\0".strtoU64(),
                    comindex = 0,
                    canqyt = 2,
                    canlei = 0,
                    res = 30
                },
                new comtype_64
                {
                    name = "lcd_dev\0".strtoU64(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 255,
                    res = 34
                },
                new comtype_64
                {
                    name = "lhmi_cle".strtoU64(),
                    comindex = 5,
                    canqyt = 0,
                    canlei = 255,
                    res = 1
                },
                new comtype_64
                {
                    name = "whmi_cle".strtoU64(),
                    comindex = 4,
                    canqyt = 2,
                    canlei = 0,
                    res = 3
                },
                new comtype_64
                {
                    name = "setbrush".strtoU64(),
                    comindex = 1,
                    canqyt = 15,
                    canlei = 0,
                    res = 4
                },
                new comtype_64
                {
                    name = "ref_stop".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 20
                },
                new comtype_64
                {
                    name = "com_stop".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 22
                },
                new comtype_64
                {
                    name = "ref_star".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 21
                },
                new comtype_64
                {
                    name = "com_star".strtoU64(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 23
                },
                new comtype_64
                {
                    name = "doevents".strtoU64(),
                    comindex = 4,
                    canqyt = 0,
                    canlei = 255,
                    res = 6
                },
                new comtype_64
                {
                    name = "timerset".strtoU64(),
                    comindex = 4,
                    canqyt = 3,
                    canlei = 0,
                    res = 0
                },
                new comtype_64
                {
                    name = "getpassw".strtoU64(),
                    comindex = 4,
                    canqyt = 0,
                    canlei = 255,
                    res = 5
                },
                new comtype_64
                {
                    name = "lcd_refx".strtoU64(),
                    comindex = 4,
                    canqyt = 0,
                    canlei = 255,
                    res = 4
                },
                new comtype_64
                {
                    name = "setbaudz".strtoU64(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 0,
                    res = 32
                }
            };
            CodeRun.com32 = new comtype_32[]
            {
                new comtype_32
                {
                    name = "I\0\0\0".strtoU32(),
                    comindex = 0,
                    canqyt = 4,
                    canlei = 102,
                    res = 28
                },
                new comtype_32
                {
                    name = "pic\0".strtoU32(),
                    comindex = 0,
                    canqyt = 3,
                    canlei = 0,
                    res = 15
                },
                new comtype_32
                {
                    name = "cle\0".strtoU32(),
                    comindex = 0,
                    canqyt = 2,
                    canlei = 0,
                    res = 36
                },
                new comtype_32
                {
                    name = "ref\0".strtoU32(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 111,
                    res = 6
                },
                new comtype_32
                {
                    name = "cir\0".strtoU32(),
                    comindex = 0,
                    canqyt = 4,
                    canlei = 0,
                    res = 13
                },
                new comtype_32
                {
                    name = "vis\0".strtoU32(),
                    comindex = 0,
                    canqyt = 2,
                    canlei = 111,
                    res = 31
                },
                new comtype_32
                {
                    name = "cls\0".strtoU32(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 0,
                    res = 0
                },
                new comtype_32
                {
                    name = "get\0".strtoU32(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 101,
                    res = 27
                },
                new comtype_32
                {
                    name = "cov\0".strtoU32(),
                    comindex = 0,
                    canqyt = 3,
                    canlei = 102,
                    res = 26
                },
                new comtype_32
                {
                    name = "tsw\0".strtoU32(),
                    comindex = 0,
                    canqyt = 2,
                    canlei = 111,
                    res = 16
                },
                new comtype_32
                {
                    name = "xpic".strtoU32(),
                    comindex = 0,
                    canqyt = 7,
                    canlei = 0,
                    res = 5
                },
                new comtype_32
                {
                    name = "load".strtoU32(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 0,
                    res = 7
                },
                new comtype_32
                {
                    name = "page".strtoU32(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 121,
                    res = 9
                },
                new comtype_32
                {
                    name = "line".strtoU32(),
                    comindex = 0,
                    canqyt = 5,
                    canlei = 0,
                    res = 10
                },
                new comtype_32
                {
                    name = "fill".strtoU32(),
                    comindex = 0,
                    canqyt = 5,
                    canlei = 0,
                    res = 8
                },
                new comtype_32
                {
                    name = "repo".strtoU32(),
                    comindex = 2,
                    canqyt = 2,
                    canlei = 101,
                    res = 1
                },
                new comtype_32
                {
                    name = "wepo".strtoU32(),
                    comindex = 2,
                    canqyt = 2,
                    canlei = 101,
                    res = 0
                },
                new comtype_32
                {
                    name = "pa_q".strtoU32(),
                    comindex = 6,
                    canqyt = 2,
                    canlei = 102,
                    res = 0
                },
                new comtype_32
                {
                    name = "picq".strtoU32(),
                    comindex = 0,
                    canqyt = 5,
                    canlei = 0,
                    res = 4
                },
                new comtype_32
                {
                    name = "nstr".strtoU32(),
                    comindex = 1,
                    canqyt = 2,
                    canlei = 101,
                    res = 6
                },
                new comtype_32
                {
                    name = "xstr".strtoU32(),
                    comindex = 1,
                    canqyt = 11,
                    canlei = 1,
                    res = 0
                },
                new comtype_32
                {
                    name = "zstr".strtoU32(),
                    comindex = 1,
                    canqyt = 5,
                    canlei = 1,
                    res = 5
                },
                new comtype_32
                {
                    name = "cirs".strtoU32(),
                    comindex = 0,
                    canqyt = 4,
                    canlei = 0,
                    res = 14
                },
                new comtype_32
                {
                    name = "addt".strtoU32(),
                    comindex = 0,
                    canqyt = 3,
                    canlei = 0,
                    res = 29
                },
                new comtype_32
                {
                    name = "init".strtoU32(),
                    comindex = 0,
                    canqyt = 1,
                    canlei = 0,
                    res = 2
                },
                new comtype_32
                {
                    name = "rept".strtoU32(),
                    comindex = 2,
                    canqyt = 2,
                    canlei = 0,
                    res = 3
                },
                new comtype_32
                {
                    name = "wept".strtoU32(),
                    comindex = 2,
                    canqyt = 2,
                    canlei = 0,
                    res = 2
                },
                new comtype_32
                {
                    name = "rfpt".strtoU32(),
                    comindex = 2,
                    canqyt = 3,
                    canlei = 0,
                    res = 5
                },
                new comtype_32
                {
                    name = "wfpt".strtoU32(),
                    comindex = 2,
                    canqyt = 3,
                    canlei = 0,
                    res = 4
                },
                new comtype_32
                {
                    name = "rest".strtoU32(),
                    comindex = 0,
                    canqyt = 0,
                    canlei = 0,
                    res = 33
                },
                new comtype_32
                {
                    name = "draw".strtoU32(),
                    comindex = 0,
                    canqyt = 5,
                    canlei = 0,
                    res = 11
                }
            };
            CodeRun.com32qyt = (byte)CodeRun.com32.Length;
            CodeRun.com64qyt = (byte)CodeRun.com64.Length;
        }

        private unsafe static byte gui_c1com(int* comcan, byte state, byte* buf, runattinf* runatt)
        {
            objxinxi objxinxi = default(objxinxi);
            byte result;
            if (state < 6)
            {
                switch (state)
                {
                    case 0:
                        Lcd.Lcd_Clear((ushort)(*comcan));
                        result = 1;
                        return result;
                    case 1:
                        Lcd.Lcd_Draw_h((ushort)(*comcan), (ushort)comcan[1], (ushort)comcan[2], (ushort)comcan[3], (byte)comcan[4], (ushort)comcan[5]);
                        result = 1;
                        return result;
                    case 2:
                        result = Hmi.Hmi_GuiObjectInit((byte)(*comcan));
                        return result;
                    case 3:
                        result = 1;
                        return result;
                    case 4:
                        result = Showpic.Showpic_ShowXpic((int)((ushort)(*comcan)), (int)((ushort)comcan[1]), (ushort)comcan[2], (ushort)comcan[3], (int)((ushort)(*comcan)), (int)((ushort)comcan[1]), (ushort)comcan[4]);
                        return result;
                    case 5:
                        result = Showpic.Showpic_ShowXpic((int)((ushort)(*comcan)), (int)((ushort)comcan[1]), (ushort)comcan[2], (ushort)comcan[3], (int)((ushort)comcan[4]), (int)((ushort)comcan[5]), (ushort)comcan[6]);
                        return result;
                }
            }
            else if (state < 12)
            {
                switch (state)
                {
                    case 6:
                        if (*comcan >= (int)CodeRun.myapp.dpagexinxi.objqyt)
                        {
                            CodeRun.myapp.errcode = 2;
                            result = 0;
                            return result;
                        }
                        CodeRun.myapp.pageobjs[*comcan].refFlag = 1;
                        result = 1;
                        return result;
                    case 7:
                        if (*comcan >= (int)CodeRun.myapp.dpagexinxi.objqyt)
                        {
                            CodeRun.myapp.errcode = 2;
                            result = 0;
                            return result;
                        }
                        result = Hmi.Hmi_loadref((byte)(*comcan));
                        return result;
                    case 8:
                        Lcd.Lcd_Fill((int)((ushort)(*comcan)), (int)((ushort)comcan[1]), (int)((ushort)comcan[2]), (int)((ushort)comcan[3]), (ushort)comcan[4]);
                        result = 1;
                        return result;
                    case 9:
                        result = Hmi.Hmi_RefPage((ushort)(*comcan));
                        return result;
                    case 10:
                        Lcd.Lcd_DrawLine((int)((ushort)(*comcan)), (int)((ushort)comcan[1]), (int)((ushort)comcan[2]), (int)((ushort)comcan[3]), (ushort)comcan[4], 1);
                        result = 1;
                        return result;
                    case 11:
                        Lcd.Lcd_DrawRectangle((ushort)(*comcan), (ushort)comcan[1], (ushort)comcan[2], (ushort)comcan[3], (ushort)comcan[4], 1);
                        result = 1;
                        return result;
                }
            }
            else if (state < 18)
            {
                switch (state)
                {
                    case 12:
                        Lcd.Lcd_DrawRectangle3D((ushort)(*comcan), (ushort)comcan[1], (ushort)comcan[2], (ushort)comcan[3], (ushort)comcan[4], (ushort)comcan[5], (byte)comcan[6]);
                        result = 1;
                        return result;
                    case 13:
                        Lcd.Lcd_Draw_Circle((ushort)(*comcan), (ushort)comcan[1], (ushort)comcan[2], (ushort)comcan[3]);
                        result = 1;
                        return result;
                    case 14:
                        Lcd.Lcd_Draw_Circles((ushort)(*comcan), (ushort)comcan[1], (ushort)comcan[2], (ushort)comcan[3]);
                        result = 1;
                        return result;
                    case 15:
                        result = Showpic.Showpic_ShowPic((int)((ushort)(*comcan)), (int)((ushort)comcan[1]), (ushort)comcan[2]);
                        return result;
                    case 16:
                        if (*comcan < (int)CodeRun.myapp.dpagexinxi.objqyt)
                        {
                            CodeRun.myapp.pageobjs[*comcan].touchstate = (byte)comcan[1];
                        }
                        else
                        {
                            if (*comcan != 255)
                            {
                                CodeRun.myapp.errcode = 2;
                                result = 0;
                                return result;
                            }
                            for (byte b = 0; b < CodeRun.myapp.dpagexinxi.objqyt; b += 1)
                            {
                                CodeRun.myapp.pageobjs[b].touchstate = (byte)comcan[1];
                            }
                        }
                        result = 1;
                        return result;
                    case 17:
                        Commake.Commake_SendAtt(runatt, 0);
                        result = 0;
                        return result;
                }
            }
            else if (state < 24)
            {
                switch (state)
                {
                    case 18:
                        Usart.Usart_SendByte(102);
                        Usart.Usart_SendByte((byte)CodeRun.myapp.dpage);
                        Commake.Commake_SendEnd();
                        result = 0;
                        return result;
                    case 19:
                        result = 1;
                        return result;
                    case 20:
                        CodeRun.myapp.paus = 1;
                        result = 1;
                        return result;
                    case 21:
                        CodeRun.myapp.paus = 0;
                        result = 1;
                        return result;
                    case 22:
                        Commake.NorComSta.runmod = 0;
                        result = 1;
                        return result;
                    case 23:
                        Commake.NorComSta.runmod = 1;
                        result = 1;
                        return result;
                }
            }
            else if (state < 30)
            {
                switch (state)
                {
                    case 24:
                        CodeRun.myapp.USART.State = 255;
                        result = 1;
                        return result;
                    case 25:
                        for (uint num = (uint)((PosLaction*)comcan)->star; num <= (uint)((PosLaction*)comcan)->end; num += 3u)
                        {
                            Strmake.Strmake_Str16ToBytes(buf + num, buf + num, 2);
                            Usart.Usart_SendByte(buf[num]);
                        }
                        result = 0;
                        return result;
                    case 26:
                        result = Attmake.Attmake_AttConvert(runatt, runatt + 1, (byte)comcan[2], 0);
                        return result;
                    case 27:
                        Commake.Commake_SendAtt(runatt, 1);
                        result = 0;
                        return result;
                    case 28:
                        {
                            if (CodeRun.myapp.Hexstrindex == 65535)
                            {
                                CodeRun.myapp.errcode = 0;
                                result = 0;
                                return result;
                            }
                            if (Attmake.Attmake_Makeatt(buf, runatt, runatt + 1, (byte)comcan[2]) == 1)
                            {
                                result = 0;
                                return result;
                            }
                            myappinf expr_5F1 = CodeRun.myapp;
                            expr_5F1.Hexstrindex += (ushort)comcan[3];
                            result = 0;
                            return result;
                        }
                    case 29:
                        if (GuiCurve.SetCurveTranMode((byte)(*comcan), (byte)comcan[1], (ushort)comcan[2]) > 0)
                        {
                            CodeRun.myapp.USART.lei = 11;
                            CodeRun.myapp.USART.State = 22;
                        }
                        else
                        {
                            CodeRun.myapp.errcode = 18;
                        }
                        result = 0;
                        return result;
                }
            }
            else if (state < 35)
            {
                switch (state)
                {
                    case 30:
                        if (comcan[1] < *comcan)
                        {
                            CodeRun.myapp.errcode = 28;
                            result = 0;
                            return result;
                        }
                        CodeRun.myapp.SysRandMax = comcan[1];
                        CodeRun.myapp.SysRandMin = *comcan;
                        result = 1;
                        return result;
                    case 31:
                        if (*comcan == 0)
                        {
                            result = 1;
                            return result;
                        }
                        if (*comcan < (int)CodeRun.myapp.dpagexinxi.objqyt)
                        {
                            if (comcan[1] > 0)
                            {
                                CodeRun.myapp.pageobjs[*comcan].vis = 1;
                                CodeRun.myapp.pageobjs[*comcan].refFlag = 1;
                            }
                            else
                            {
                                Hmi.Hmi_Hideobj((byte)(*comcan));
                            }
                        }
                        else
                        {
                            if (*comcan != 255)
                            {
                                CodeRun.myapp.errcode = 2;
                                result = 0;
                                return result;
                            }
                            if (comcan[1] > 0)
                            {
                                comcan[1] = 1;
                            }
                            else
                            {
                                Hmi.Hmi_Refobj(0);
                            }
                            for (byte b = 1; b < CodeRun.myapp.dpagexinxi.objqyt; b += 1)
                            {
                                CodeRun.myapp.pageobjs[b].vis = (byte)comcan[1];
                                CodeRun.myapp.pageobjs[b].refFlag = (byte)comcan[1];
                            }
                        }
                        result = 1;
                        return result;
                    case 32:
                        CodeRun.myapp.errcode = 0;
                        result = 0;
                        return result;
                    case 33:
                        CodeRun.myapp.USART.State = 253;
                        result = 0;
                        return result;
                    case 34:
                        result = 1;
                        return result;
                }
            }
            else if (state < 40)
            {
                switch (state)
                {
                    case 35:
                        if (*comcan < (int)CodeRun.myapp.dpagexinxi.objqyt)
                        {
                            Readdata.Readdata_ReadObj(ref objxinxi, *comcan + (int)CodeRun.myapp.dpagexinxi.objstar);
                            if (comcan[1] == 1 && objxinxi.redian.events.Down != 0)
                            {
                                Hmi.Hmi_SetHexIndex((int)(objxinxi.redian.events.Down + objxinxi.zhilingstar));
                            }
                            else if (comcan[1] == 0 && objxinxi.redian.events.Up != 0)
                            {
                                Hmi.Hmi_SetHexIndex((int)(objxinxi.redian.events.Up + objxinxi.zhilingstar));
                            }
                            result = 1;
                            return result;
                        }
                        CodeRun.myapp.errcode = 2;
                        result = 0;
                        return result;
                    case 36:
                        if (GuiCurve.GuiCruveClear((byte)(*comcan), (byte)comcan[1]) == 0)
                        {
                            CodeRun.myapp.errcode = 18;
                            result = 0;
                            return result;
                        }
                        result = 1;
                        return result;
                }
            }
            result = 1;
            return result;
        }

        private unsafe static byte gui_gpio(int* comcan, byte state, byte* buf, runattinf* runatt)
        {
            return 1;
        }

        private unsafe static byte gui_xstr(int* comcan, byte state, byte* buf, runattinf* runatt)
        {
            size_tyte size_tyte = default(size_tyte);
            byte[] array = new byte[24];
            if (state == 4 || state == 0)
            {
                CodeRun.myapp.brush.x = (ushort)(*comcan);
                CodeRun.myapp.brush.y = (ushort)comcan[1];
                CodeRun.myapp.brush.endx = (ushort)((int)CodeRun.myapp.brush.x + comcan[2] - 1);
                CodeRun.myapp.brush.endy = (ushort)((int)CodeRun.myapp.brush.y + comcan[3] - 1);
                CodeRun.myapp.brush.zikuid = (byte)comcan[4];
                CodeRun.myapp.brush.pointcolor = (ushort)comcan[5];
                CodeRun.myapp.brush.backcolor = (ushort)comcan[6];
                CodeRun.myapp.brush.xjuzhong = (byte)comcan[7];
                CodeRun.myapp.brush.yjuzhong = (byte)comcan[8];
                CodeRun.myapp.brush.sta = (byte)comcan[9];
                if (state != 4)
                {
                    CodeRun.myapp.brush.hangjux = 0;
                    CodeRun.myapp.brush.hangjuy = 0;
                }
                if ((ushort)CodeRun.myapp.brush.zikuid < CodeRun.myapp.app.zimoqyt)
                {
                    Readdata.Readdata_RedZimo(ref CodeRun.myapp.brush.mzimo, (int)CodeRun.myapp.brush.zikuid);
                }
            }
            byte result;
            if (state == 0)
            {
                CodeRun.myapp.brush.pw = 0;
                CodeRun.myapp.brush.isbr = 1;
                if (runatt->datafrom == 252)
                {
                    CodeRun.myapp.brush.flashadd = CodeRun.myapp.app.staticstringbeg + CodeRun.myapp.app.strdataadd + (uint)runatt->att.pos;
                    byte[] array2 = new byte[(int)runatt->att.merrylenth];
                    Readdata.SPI_Flash_Read(ref array2, CodeRun.myapp.brush.flashadd, (uint)array2.Length);
                    array2[array2.Length - 1] = 0;
                    byte b;
                    fixed (byte* ptr = array2)
                    {
                        b = Showfont.Showfont_XstringHZK(32767, 32767, 32767, 32767, ptr);
                    }
                    CodeRun.myapp.brush.flashadd = 0u;
                    result = b;
                }
                else if (runatt->attlei == attshulei.Sstr.typevalue)
                {
                    result = Showfont.Showfont_XstringHZK(32767, 32767, 32767, 32767, runatt->Pz);
                }
                else
                {
                    CodeRun.myapp.errcode = 27;
                    result = 0;
                }
            }
            else if (state == 2)
            {
                if (runatt->attlei != attshulei.Sstr.typevalue || runatt[1].attlei == attshulei.Sstr.typevalue)
                {
                    CodeRun.myapp.errcode = 27;
                    result = 0;
                }
                else
                {
                    runatt[1].val = (int)Strmake.Strmake_GetStrlen_Encode(runatt->Pz, runatt->att.encodeh_star);
                    result = Attmake.Attmake_SetAtt(ref runatt[1], ref runatt[1], 0);
                }
            }
            else if (state == 3)
            {
                CodeRun.myapp.brush.brendx = (short)CodeRun.myapp.brush.endx;
                CodeRun.myapp.brush.brendy = (short)CodeRun.myapp.brush.endy;
                if (runatt->attlei == attshulei.Sstr.typevalue && runatt[1].attlei != attshulei.Sstr.typevalue && runatt[2].attlei != attshulei.Sstr.typevalue)
                {
                    if (runatt->datafrom == 252)
                    {
                        CodeRun.myapp.brush.flashadd = CodeRun.myapp.app.staticstringbeg + CodeRun.myapp.app.strdataadd + (uint)runatt->att.pos;
                        byte[] array2 = new byte[(int)runatt->att.merrylenth];
                        Readdata.SPI_Flash_Read(ref array2, CodeRun.myapp.brush.flashadd, (uint)array2.Length);
                        array2[array2.Length - 1] = 0;
                        fixed (byte* ptr = array2)
                        {
                            Showfont.Showfont_StringHZK((int)CodeRun.myapp.brush.x, (int)CodeRun.myapp.brush.y, ptr, 0, ref size_tyte);
                        }
                        CodeRun.myapp.brush.flashadd = 0u;
                    }
                    else
                    {
                        Showfont.Showfont_StringHZK((int)CodeRun.myapp.brush.x, (int)CodeRun.myapp.brush.y, runatt->Pz, 0, ref size_tyte);
                    }
                    runatt[1].val = (int)size_tyte.a;
                    runatt[2].val = (int)size_tyte.b;
                    byte b = Attmake.Attmake_SetAtt(ref runatt[1], ref runatt[1], 0);
                    if (b == 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        b = Attmake.Attmake_SetAtt(ref runatt[2], ref runatt[2], 0);
                        if (b == 0)
                        {
                            result = 0;
                        }
                        else
                        {
                            result = 1;
                        }
                    }
                }
                else
                {
                    CodeRun.myapp.errcode = 27;
                    result = 0;
                }
            }
            else
            {
                if (state == 4)
                {
                    CodeRun.myapp.brush.isbr = (byte)comcan[10];
                    CodeRun.myapp.brush.hangjux = (byte)comcan[11];
                    CodeRun.myapp.brush.hangjuy = (byte)comcan[12];
                    CodeRun.myapp.brush.pw = (byte)comcan[13];
                    if (comcan[14] > 0)
                    {
                        if ((int)(CodeRun.myapp.brush.endx - CodeRun.myapp.brush.x + 1) > comcan[14] * 2 && (int)(CodeRun.myapp.brush.endy - CodeRun.myapp.brush.y + 1) > comcan[14] * 2)
                        {
                            myappinf expr_6EB_cp_0 = CodeRun.myapp;
                            expr_6EB_cp_0.brush.x =(ushort)(expr_6EB_cp_0.brush.x + (ushort)((byte)comcan[14]));
                            myappinf expr_709_cp_0 = CodeRun.myapp;
                            expr_709_cp_0.brush.y = (ushort)(expr_709_cp_0.brush.y + (ushort)((byte)comcan[14]));
                            myappinf expr_727_cp_0 = CodeRun.myapp;
                            expr_727_cp_0.brush.endx =(ushort)(expr_727_cp_0.brush.endx - (ushort)((byte)comcan[14]));
                            myappinf expr_745_cp_0 = CodeRun.myapp;
                            expr_745_cp_0.brush.endy =(ushort)(expr_745_cp_0.brush.endy - (ushort)((byte)comcan[14]));
                        }
                    }
                    if (CodeRun.myapp.brush.pw == 1)
                    {
                        CodeRun.myapp.brush.pw = 42;
                    }
                }
                else if (state == 5)
                {
                    if (runatt->datafrom == 252)
                    {
                        CodeRun.myapp.brush.flashadd = CodeRun.myapp.app.staticstringbeg + CodeRun.myapp.app.strdataadd + (uint)runatt->att.pos;
                        byte[] array2 = new byte[(int)runatt->att.merrylenth];
                        Readdata.SPI_Flash_Read(ref array2, CodeRun.myapp.brush.flashadd, (uint)array2.Length);
                        array2[array2.Length - 1] = 0;
                        byte b;
                        fixed (byte* ptr = array2)
                        {
                            b = Showfont.Showfont_XstringHZK(*comcan, comcan[1], comcan[2], comcan[3], ptr);
                        }
                        CodeRun.myapp.brush.flashadd = 0u;
                        result = b;
                        return result;
                    }
                    result = Showfont.Showfont_XstringHZK(*comcan, comcan[1], comcan[2], comcan[3], runatt->Pz);
                    return result;
                }
                else
                {
                    if (state == 6)
                    {
                        byte b;
                        fixed (byte* ptr = array)
                        {
                            Strmake.Strmake_S32ToStr(runatt->val, ptr, (byte)comcan[1], 1);
                            b = Showfont.Showfont_XstringHZK(32767, 32767, 32767, 32767, ptr);
                        }
                        result = b;
                        return result;
                    }
                    if (state == 7)
                    {
                        if (runatt->attlei != attshulei.Sstr.typevalue || runatt[1].attlei != attshulei.Sstr.typevalue)
                        {
                            CodeRun.myapp.errcode = 27;
                            result = 0;
                            return result;
                        }
                        byte b = (byte)Strmake.Strmake_GetStrlen_Encode_Lenth(runatt->Pz, runatt->att.encodeh_star, (byte)comcan[2]);
                        int num = (int)Strmake.Strmake_GetStrlen_Encode_Lenth(runatt->Pz + b, runatt->att.encodeh_star, (byte)comcan[3]);
                        Kuozhan.memcpy(runatt[1].Pz, runatt->Pz + b, num);
                        runatt[1].Pz[num] = 0;
                        result = Attmake.Attmake_SetAtt(ref runatt[1], ref runatt[1], 0);
                        return result;
                    }
                    else if (state == 8)
                    {
                        if (runatt->attlei != attshulei.Sstr.typevalue || runatt[1].attlei == attshulei.Sstr.typevalue)
                        {
                            CodeRun.myapp.errcode = 27;
                            result = 0;
                            return result;
                        }
                        runatt[1].val = (int)Strmake.Strmake_GetStrlen(runatt->Pz);
                        result = Attmake.Attmake_SetAtt(ref runatt[1], ref runatt[1], 0);
                        return result;
                    }
                }
                result = 1;
            }
            return result;
        }

        private unsafe static byte gui_sys(int* comcan, byte state, byte* buf, runattinf* runatt)
        {
            strxinxi strxinxi = default(strxinxi);
            byte result;
            switch (state)
            {
                case 0:
                    if (*comcan == 0)
                    {
                        for (byte b = 0; b < *CodeRun.myapp.systimerbuf; b += 1)
                        {
                            systimer_type* ptr = (systimer_type*)(CodeRun.myapp.systimerbuf + (b * 5 + 4));
                            if ((int)ptr->id == comcan[1])
                            {
                                result = 1;
                                return result;
                            }
                        }
                        if (*CodeRun.myapp.systimerbuf < 8)
                        {
                            systimer_type* ptr = (systimer_type*)(CodeRun.myapp.systimerbuf + (*CodeRun.myapp.systimerbuf * 5 + 4));
                            Readdata.Readdata_ReadStr(ref strxinxi, (int)CodeRun.myapp.Hexstrindex);
                            myappinf expr_E3 = CodeRun.myapp;
                            expr_E3.Hexstrindex += 1;
                            Readdata.SPI_Flash_Read(Hmi.Hexstrbuf, CodeRun.myapp.app.strdataadd + strxinxi.addbeg, (uint)strxinxi.size);
                            if (Strmake.Strmake_Makestr(Hmi.Hexstrbuf, "L ", 2) == 1)
                            {
                                ptr->hexbufindex = (ushort)Hmi.Hexstrbuf[3];
                                systimer_type* expr_14A = ptr;
                                expr_14A->hexbufindex = (ushort)(expr_14A->hexbufindex << 8);
                                systimer_type* expr_159 = ptr;
                                expr_159->hexbufindex = (ushort)(expr_159->hexbufindex + (ushort)Hmi.Hexstrbuf[2]);
                                ptr->id = (byte)comcan[1];
                                if (comcan[2] == 65535)
                                {
                                    ptr->val = 0;
                                }
                                else
                                {
                                    ptr->val = (ushort)(65534 - comcan[2] / 20);
                                }
                                byte* expr_1BC = CodeRun.myapp.systimerbuf;
                                *expr_1BC += 1;
                            }
                        }
                    }
                    else if (*comcan == 1)
                    {
                        for (byte b = 0; b < *CodeRun.myapp.systimerbuf; b += 1)
                        {
                            systimer_type* ptr = (systimer_type*)(CodeRun.myapp.systimerbuf + (b * 5 + 4));
                            if ((int)ptr->id == comcan[1])
                            {
                                if (comcan[2] == 65535)
                                {
                                    ptr->val = 0;
                                }
                                else
                                {
                                    ptr->val = (ushort)(65534 - comcan[2] / 20);
                                }
                                result = 1;
                                return result;
                            }
                        }
                    }
                    break;
                case 1:
                    if (*comcan >= (int)CodeRun.myapp.dpagexinxi.objqyt)
                    {
                        CodeRun.myapp.errcode = 2;
                        result = 0;
                        return result;
                    }
                    if (CodeRun.myapp.Hexstrindex != 65535)
                    {
                        if (CodeRun.myapp.pageobjs[*comcan].vis == 0 || CodeRun.myapp.pageobjs[*comcan].refFlag == 0)
                        {
                            myappinf expr_2FA = CodeRun.myapp;
                            expr_2FA.Hexstrindex += (ushort)comcan[1];
                        }
                        CodeRun.myapp.pageobjs[*comcan].refFlag = 0;
                    }
                    break;
                case 2:
                    if (*comcan >= (int)CodeRun.myapp.dpagexinxi.objqyt)
                    {
                        CodeRun.myapp.errcode = 2;
                        result = 0;
                        return result;
                    }
                    if (CodeRun.myapp.Hexstrindex != 65535)
                    {
                        if (CodeRun.myapp.pageobjs[*comcan].vis == 0)
                        {
                            myappinf expr_39F = CodeRun.myapp;
                            expr_39F.Hexstrindex += (ushort)comcan[1];
                        }
                    }
                    break;
                case 6:
                    if (CodeRun.myapp.Hexstrindex != 65535)
                    {
                        Hmi.Hmi_GuiObjectRef();
                        if (CodeRun.myapp.upapp.Lcdshouxian > 0)
                        {
                            CodeRun.myapp.upapp.ScreenRef(0);
                        }
                    }
                    break;
            }
            result = 1;
            return result;
        }

        private unsafe static byte gui_input(int* comcan, byte state, byte* buf, runattinf* runatt)
        {
            byte result;
            switch (state)
            {
                case 0:
                    if (runatt->attlei != attshulei.Sstr.typevalue || runatt[1].attlei == attshulei.Sstr.typevalue)
                    {
                        CodeRun.myapp.errcode = 27;
                        result = 0;
                    }
                    else
                    {
                        uint num = Kuozhan.CRC32(runatt->Pz, (int)Strmake.Strmake_GetStrlen(runatt->Pz));
                        num = Datafind.Datafind_FindU32_Flash(&num, CodeRun.myapp.app.inputpos + 2u, CodeRun.myapp.app.inputqyts, 8);
                        if (num == 4294967295u)
                        {
                            runatt[1].val = 0;
                        }
                        else
                        {
                            runatt[1].val = (int)(num >> 17);
                        }
                        result = Attmake.Attmake_SetAtt(ref runatt[1], ref runatt[1], 0);
                    }
                    break;
                case 1:
                    if (runatt->attlei != attshulei.Sstr.typevalue || runatt[1].attlei != attshulei.Sstr.typevalue)
                    {
                        CodeRun.myapp.errcode = 27;
                        result = 0;
                    }
                    else
                    {
                        uint num = Kuozhan.CRC32(runatt->Pz, (int)Strmake.Strmake_GetStrlen(runatt->Pz));
                        num = Datafind.Datafind_FindU32_Flash(&num, CodeRun.myapp.app.inputpos + 2u, CodeRun.myapp.app.inputqyts, 8);
                        ushort num2;
                        if (num == 4294967295u)
                        {
                            num = 0u;
                            num2 = 0;
                        }
                        else
                        {
                            num2 = (ushort)(num >> 17);
                            num = (uint)((ushort)num);
                        }
                        int num3 = 0;
                        if (comcan[2] > -1 && comcan[3] > -1)
                        {
                            if (comcan[2] + comcan[3] <= (int)num2)
                            {
                                num3 = comcan[3] * 2;
                                if ((int)runatt[1].att.merrylenth <= num3)
                                {
                                    num3 = (int)(runatt[1].att.merrylenth - 1);
                                }
                            }
                        }
                        Readdata.SPI_Flash_Read(runatt[1].Pz, (uint)((ulong)(CodeRun.myapp.app.inputpos + num) + (ulong)((long)(comcan[2] * 2))), (uint)num3);
                        runatt[1].Pz[num3] = 0;
                        result = Attmake.Attmake_SetAtt(ref runatt[1], ref runatt[1], 0);
                    }
                    break;
                default:
                    result = 1;
                    break;
            }
            return result;
        }

        private unsafe static byte gui_chuchang(int* comcan, byte state, byte* buf, runattinf* runatt)
        {
            return 1;
        }

        private unsafe static byte gui_eepr(int* comcan, byte state, byte* buf, runattinf* runatt)
        {
            return 1;
        }

        private unsafe static byte jiexicans(byte* buf, int index, int bufbeg, int qyt, byte lei, runattinf* runatt)
        {
            byte b = 1;
            while (qyt > 0)
            {
                if (lei == 0)
                {
                    *(int*)(CodeRun.myapp.Mycanshus + index) = CodeRun.strgetS32(buf, CodeRun.myapp.Mycanshus + bufbeg, &b);
                }
                else if (lei == 1)
                {
                    int num = (int)Attmake.Attmake_GetstrAtt(buf, CodeRun.myapp.Mycanshus + bufbeg, runatt + index);
                    if (runatt[index].datafrom == 255)
                    {
                        b = 0;
                    }
                    else if (num != (int)CodeRun.myapp.Mycanshus[bufbeg].end)
                    {
                        CodeRun.myapp.errcode = 26;
                        b = 0;
                    }
                }
                else if (lei == 2)
                {
                    int num = CodeRun.strgetS32(buf, CodeRun.myapp.Mycanshus + bufbeg, &b);
                    if (b == 0)
                    {
                        num = (int)Hmi.Hmi_GetObjid(buf, CodeRun.myapp.Mycanshus + bufbeg, CodeRun.myapp.dobjnameseradd, (uint)CodeRun.myapp.dpagexinxi.objqyt);
                        if (num == 65535)
                        {
                            CodeRun.myapp.errcode = 2;
                        }
                        else
                        {
                            CodeRun.myapp.errcode = 255;
                            b = 1;
                        }
                    }
                    *(int*)(CodeRun.myapp.Mycanshus + index) = num;
                }
                else if (lei == 3)
                {
                    int num = CodeRun.strgetS32(buf, CodeRun.myapp.Mycanshus + bufbeg, &b);
                    if (b == 0)
                    {
                        num = (int)Hmi.Hmi_GetPageid(buf, CodeRun.myapp.Mycanshus + bufbeg);
                        if (num == 65535)
                        {
                            CodeRun.myapp.errcode = 3;
                        }
                        else
                        {
                            CodeRun.myapp.errcode = 255;
                            b = 1;
                        }
                    }
                    *(int*)(CodeRun.myapp.Mycanshus + index) = num;
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

        public unsafe static int strgetS32(byte* buf, PosLaction* pos, byte* back)
        {
            runattinf[] array = new runattinf[2];
            *back = 1;
            ushort num = Attmake.Attmake_GetstrAtt(buf, ref *pos, ref array[1]);
            int result;
            if (array[1].datafrom == 255)
            {
                *back = 0;
                result = 0;
            }
            else if (array[1].attlei == attshulei.Sstr.typevalue)
            {
                *back = 0;
                CodeRun.myapp.errcode = 27;
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
                    if (b == 2)
                    {
                        num += 1;
                    }
                    if (num >= pos->end || b <= 0)
                    {
                        CodeRun.myapp.errcode = 26;
                        *back = 0;
                        result = 0;
                        return result;
                    }
                    b = buf[num];
                    pos->star =(ushort)(num + 1);
                    num = Attmake.Attmake_GetstrAtt(buf, ref *pos, ref array[0]);
                    if (array[0].datafrom == 255)
                    {
                        *back = 0;
                        result = 0;
                        return result;
                    }
                    array[1].datafrom = 253;
                    array[1].isref = 0;
                    array[1].isxiugai = 1;
                    if (Attmake.Attmake_AttAdd(buf, ref array[1], ref array[0], ref array[1], b) == 0)
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

        public unsafe static byte Coderun_Run(byte* buf, PosLaction* poscode)
        {
            byte b = 0;
            byte b2 = 0;
            PosLaction posLaction = default(PosLaction);
            runattinf[] array = new runattinf[3];
            CodeRun.comrun_ comrun_ = null;
            byte b3 = 0;
            byte b4 = 0;
            byte state = 0;
            CodeRun.myapp.errcode = 255;
            byte result;
            try
            {
                if (CodeRun.myapp.upapp.runapptype == runapptype.run && CodeRun.myapp.upapp.SendRuncodeTime > 0)
                {
                    Sys.delay_ms((ushort)CodeRun.myapp.upapp.SendRuncodeTime);
                    CodeRun.myapp.upapp.Sendruncodestr((*poscode).PosByteGetstring(buf));
                }
                if (Strmake.Strmake_Makestr(buf + poscode->star, "add ", 4) == 1)
                {
                    posLaction = *poscode;
                    posLaction.star += 4;
                    b = Strmake.Strmake_StrGetcanshu(buf, &posLaction, CodeRun.myapp.Mycanshus, 3);
                    if (b == 0)
                    {
                        CodeRun.myapp.errcode = 30;
                        result = 0;
                    }
                    else
                    {
                        for (ulong num = 0uL; num < 3uL; num += 1uL)
                        {
                            array[(int)(checked((IntPtr)num))].val = CodeRun.strgetS32(buf, CodeRun.myapp.Mycanshus + num * (ulong)((long)sizeof(PosLaction)) / (ulong)sizeof(PosLaction), &b);
                            if (b == 0)
                            {
                                result = 0;
                                return result;
                            }
                        }
                        if (GuiCurve.GuiCruveCmd((byte)array[0].val, (byte)array[1].val, (byte)array[2].val) == 0)
                        {
                            CodeRun.myapp.errcode = 18;
                        }
                        result = 0;
                    }
                }
                else if (CodeRun.myapp.Hexstrindex != 65535 && Strmake.Strmake_Makestr(buf + poscode->star, "T ", 2) == 1)
                {
                    myappinf expr_1F3 = CodeRun.myapp;
                    expr_1F3.Hexstrindex += (ushort)Strmake.Strmake_StrToS32(buf + (poscode->star + 2), (byte)(poscode->end - poscode->star - 1));
                    result = 0;
                }
                else if (CodeRun.myapp.Hexstrindex != 65535 && Strmake.Strmake_Makestr(buf + poscode->star, "L ", 2) == 1)
                {
                    CodeRun.myapp.Hexstrindex = (ushort)buf[poscode->star + 3];
                    myappinf expr_278 = CodeRun.myapp;
                    expr_278.Hexstrindex = (ushort)(expr_278.Hexstrindex << 8);
                    myappinf expr_28B = CodeRun.myapp;
                    expr_28B.Hexstrindex += (ushort)buf[poscode->star + 2];
                    result = 0;
                }
                else if (CodeRun.myapp.Hexstrindex != 65535 && Strmake.Strmake_Makestr(buf + poscode->star, "S ", 2) == 1)
                {
                    result = 0;
                }
                else
                {
                    if (buf[poscode->star] > 8)
                    {
                        b = 0;
                        b3 = 255;
                        uint num2;
                        if (buf[poscode->star] == 9)
                        {
                            num2 = (uint)buf[poscode->star + 1];
                            b = 2;
                            b2 = buf[poscode->star + 2];
                        }
                        else
                        {
                            for (num2 = (uint)poscode->star; num2 <= (uint)poscode->end; num2 += 1u)
                            {
                                if (buf[num2] == 32)
                                {
                                    break;
                                }
                                if (buf[num2] == 61 || buf[num2] == 43 || buf[num2] == 45)
                                {
                                    b = 255;
                                    break;
                                }
                                if (b == 8)
                                {
                                    b = 255;
                                    break;
                                }
                                b += 1;
                            }
                            if (b == 0)
                            {
                                CodeRun.myapp.errcode = 0;
                                result = 0;
                                return result;
                            }
                            if (b < 5)
                            {
                                num2 = 0u;
                                Kuozhan.memcpy((byte*)(&num2), buf + poscode->star, (int)b);
                                try
                                {
                                    fixed (void* ptr = CodeRun.com32)
                                    {
                                        num2 = Datafind.Datafind_FindU32_Memory(&num2, (uint*)ptr, (uint)CodeRun.com32qyt, (uint)(sizeof(comtype_32) / 4));
                                    }
                                }
                                finally
                                {
                                    void* ptr = null;
                                }
                                if (num2 == 65535u)
                                {
                                    CodeRun.myapp.errcode = 0;
                                    result = 0;
                                    return result;
                                }
                                b2 = 4;
                            }
                            else if (b < 9)
                            {
                                ulong num = 0uL;
                                Kuozhan.memcpy((byte*)(&num), buf + poscode->star, (int)b);
                                try
                                {
                                    fixed (void* ptr = CodeRun.com64)
                                    {
                                        num2 = Datafind.Datafind_FindU64_Memory(&num, (uint*)ptr, (uint)CodeRun.com64qyt, (uint)(sizeof(comtype_64) / 4));
                                    }
                                }
                                finally
                                {
                                    void* ptr = null;
                                }
                                if (num2 == 65535u)
                                {
                                    CodeRun.myapp.errcode = 0;
                                    result = 0;
                                    return result;
                                }
                                b2 = 8;
                            }
                        }
                        if (b2 == 4)
                        {
                            comrun_ = CodeRun.comrun[(int)CodeRun.com32[(int)((UIntPtr)num2)].comindex];
                            b3 = CodeRun.com32[(int)((UIntPtr)num2)].canqyt;
                            b4 = CodeRun.com32[(int)((UIntPtr)num2)].canlei;
                            state = CodeRun.com32[(int)((UIntPtr)num2)].res;
                        }
                        else if (b2 == 8)
                        {
                            comrun_ = CodeRun.comrun[(int)CodeRun.com64[(int)((UIntPtr)num2)].comindex];
                            b3 = CodeRun.com64[(int)((UIntPtr)num2)].canqyt;
                            b4 = CodeRun.com64[(int)((UIntPtr)num2)].canlei;
                            state = CodeRun.com64[(int)((UIntPtr)num2)].res;
                        }
                        if (b3 != 255)
                        {
                            posLaction.star = (ushort)(poscode->star + (ushort)b + 1);
                            posLaction.end = poscode->end;
                            b = Strmake.Strmake_StrGetcanshu(buf, &posLaction, CodeRun.myapp.Mycanshus, b3);
                            if (b == 0)
                            {
                                CodeRun.myapp.errcode = 30;
                                result = 0;
                                return result;
                            }
                            if (b4 == 0)
                            {
                                if (CodeRun.jiexicans(buf, 0, 0, (int)b3, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b4 < 4)
                            {
                                b4 =Convert.ToByte(b3 - b4);
                                if (CodeRun.jiexicans(buf, 0, 0, (int)b4, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (CodeRun.jiexicans(buf, 0, (int)b4, (int)(b3 - b4), 1, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b4 < 14)
                            {
                                b4 -= 10;
                                b4 = Convert.ToByte(b3 - b4);
                                if (CodeRun.jiexicans(buf, 0, 0, (int)b4, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (CodeRun.jiexicans(buf, (int)b4, (int)b4, (int)(b3 - b4), 2, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b4 < 24)
                            {
                                b4 -= 20;
                                b4 = Convert.ToByte(b3 - b4);
                                if (CodeRun.jiexicans(buf, 0, 0, (int)b4, 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (CodeRun.jiexicans(buf, (int)b4, (int)b4, (int)(b3 - b4), 3, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b4 < 104)
                            {
                                b4 -= 100;
                                if (CodeRun.jiexicans(buf, 0, 0, (int)b4, 1, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (CodeRun.jiexicans(buf, (int)b4, (int)b4, (int)(b3 - b4), 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b4 < 114)
                            {
                                b4 -= 110;
                                if (CodeRun.jiexicans(buf, 0, 0, (int)b4, 2, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (CodeRun.jiexicans(buf, (int)b4, (int)b4, (int)(b3 - b4), 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b4 < 124)
                            {
                                b4 -= 120;
                                if (CodeRun.jiexicans(buf, 0, 0, (int)b4, 3, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                                if (CodeRun.jiexicans(buf, (int)b4, (int)b4, (int)(b3 - b4), 0, ref array) == 0)
                                {
                                    result = 0;
                                    return result;
                                }
                            }
                            else if (b4 != 255)
                            {
                                CodeRun.myapp.errcode = 0;
                                result = 0;
                                return result;
                            }
                            try
                            {
                                fixed (runattinf* ptr2 = array)
                                {
                                    b = comrun_((int*)CodeRun.myapp.Mycanshus, state, buf, ptr2);
                                }
                            }
                            finally
                            {
                                runattinf* ptr2 = null;
                            }
                            result = b;
                            return result;
                        }
                    }
                    if (poscode->end - poscode->star > 2)
                    {
                        posLaction.star = poscode->star;
                        posLaction.end = poscode->end;
                        uint num2 = (uint)Attmake.Attmake_GetstrAtt(buf, ref posLaction, ref array[2]);
                        if (array[2].datafrom == 255)
                        {
                            result = 0;
                            return result;
                        }
                        if (num2 < (uint)poscode->end)
                        {
                            num2 += 1u;
                            b = Strmake.Strmake_Isyunsuanascii(buf + num2);
                            if (b == 2)
                            {
                                num2 += 1u;
                            }
                            if (num2 < (uint)poscode->end)
                            {
                                if (buf[num2] == 61 || (b > 0 && num2 + 1u < (uint)poscode->end && buf[num2 + 1u] == 61))
                                {
                                    if (buf[num2] == 61)
                                    {
                                        posLaction.star = (ushort)(num2 + 1u);
                                        posLaction.end = poscode->end;
                                        num2 = (uint)Attmake.Attmake_GetstrAtt(buf, ref posLaction, ref array[0]);
                                        if (array[0].datafrom == 255)
                                        {
                                            result = 0;
                                            return result;
                                        }
                                        if (num2 < (uint)posLaction.end)
                                        {
                                            num2 += 1u;
                                            b = Strmake.Strmake_Isyunsuanascii(buf + num2);
                                            if (b == 2)
                                            {
                                                num2 += 1u;
                                            }
                                            if (num2 >= (uint)poscode->end || b <= 0)
                                            {
                                                CodeRun.myapp.errcode = 26;
                                                result = 0;
                                                return result;
                                            }
                                            b = buf[num2];
                                            num2 += 1u;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                fixed (runattinf* ptr3 = array)
                                                {
                                                    b = Attmake.Attmake_SetAtt(ptr3, ptr3 + 2, 0);
                                                }
                                            }
                                            finally
                                            {
                                                runattinf* ptr3 = null;
                                            }
                                            if (b == 0)
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
                                        b = buf[num2];
                                        num2 += 2u;
                                        try
                                        {
                                            fixed (void* ptr4 =(&array[0]))
                                            {
                                                try
                                                {
                                                    fixed (void* ptr5 = (&array[2]))
                                                    {
                                                        Kuozhan.memcpy((byte*)ptr4, (byte*)ptr5, datasize.runattinfsize);
                                                    }
                                                }
                                                finally
                                                {
                                                    void* ptr5 = null;
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            void* ptr4 = null;
                                        }
                                    }
                                    posLaction.star = (ushort)num2;
                                    num2 = (uint)Attmake.Attmake_GetstrAtt(buf, ref posLaction, ref array[1]);
                                    if (array[1].datafrom == 255)
                                    {
                                        result = 0;
                                        return result;
                                    }
                                    try
                                    {
                                        fixed (runattinf* ptr3 = array)
                                        {
                                            b = Attmake.Attmake_AttAdd(buf, ptr3, ptr3 + 1, ptr3 + 2, b);
                                        }
                                    }
                                    finally
                                    {
                                        runattinf* ptr3 = null;
                                    }
                                    if (b == 0)
                                    {
                                        result = 0;
                                        return result;
                                    }
                                    while (num2 < (uint)posLaction.end)
                                    {
                                        num2 += 1u;
                                        b = Strmake.Strmake_Isyunsuanascii(buf + num2);
                                        if (b == 2)
                                        {
                                            num2 += 1u;
                                        }
                                        if (num2 >= (uint)poscode->end || b <= 0)
                                        {
                                            CodeRun.myapp.errcode = 26;
                                            result = 0;
                                            return result;
                                        }
                                        b = buf[num2];
                                        posLaction.star = (ushort)(num2 + 1u);
                                        num2 = (uint)Attmake.Attmake_GetstrAtt(buf, ref posLaction, ref array[1]);
                                        if (array[1].datafrom == 255)
                                        {
                                            result = 0;
                                            return result;
                                        }
                                        if (Attmake.Attmake_AttAdd(buf, ref array[2], ref array[1], ref array[2], b) == 0)
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
                                    b = 0;
                                    if (buf[poscode->end] == 43 && buf[poscode->end - 1] == 43)
                                    {
                                        b = 43;
                                    }
                                    else if (buf[poscode->end] == 45 && buf[poscode->end - 1] == 45)
                                    {
                                        b = 45;
                                    }
                                    if (b > 0)
                                    {
                                        if (num2 + 1u != (uint)posLaction.end)
                                        {
                                            CodeRun.myapp.errcode = 26;
                                            result = 0;
                                            return result;
                                        }
                                        array[1].attlei = attshulei.SS32.typevalue;
                                        array[1].val = 1;
                                        array[1].datafrom = 253;
                                        if (Attmake.Attmake_AttAdd(buf, ref array[2], ref array[1], ref array[2], b) == 0)
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
                    CodeRun.myapp.errcode = 0;
                    result = 0;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("Runcode is Error:" + ex.Message);
                result = 0;
            }
            return result;
        }
    }
}
