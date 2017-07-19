using System;

namespace hmitype
{
    public static class Hmi
    {
        public const ushort mymerrylenth = 8192;

        public const ushort Hexstrbuflenth = 2048;

        public static myappinf myapp;

        public unsafe static byte* Hexstrbuf;

        public static uint[] lastpagenamecrc;

        public static ushort[] lastpageid;

        public static uint[] lastobjaddr;

        public static uint[] lastobjnamecrc;

        public static ushort[] lastobjid;

        private static void Hmi_GuiPageInit()
        {
            GuiCurve.GuiCurvePageInit();
        }

        private static ushort Hmi_GetHexstr()
        {
            ushort result;
            for (int i = 7; i > -1; i--)
            {
                if (Hmi.myapp.hishexs[i] != 65535)
                {
                    ushort num = Hmi.myapp.hishexs[i];
                    Hmi.myapp.hishexs[i] = 65535;
                    result = num;
                    return result;
                }
            }
            result = 65535;
            return result;
        }

        public static void Hmi_SetHexIndex(int index)
        {
            if (Hmi.myapp.Hexstrindex != 65535)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Hmi.myapp.hishexs[i] == 65535)
                    {
                        Hmi.myapp.hishexs[i] = Hmi.myapp.Hexstrindex;
                        Hmi.myapp.Hexstrindex = (ushort)index;
                        return;
                    }
                }
                MessageOpen.Show("recursive depth exceeds the maximum value!");
            }
            else
            {
                Hmi.myapp.Hexstrindex = (ushort)index;
            }
        }

        public static void Hmi_OpenInit()
        {
            Hmi.myapp.SysRandMax = 2147483647;
            Hmi.myapp.SysRandMin = 0;
            Hmi.myapp.dra = 0;
            Hmi.myapp.dracolor = 63488;
            Hmi.myapp.USART.State = 254;
            Hmi.myapp.comcrc = 0;
            Hmi.myapp.sendfanhui = 2;
            Hmi.myapp.USART.UsartBo = 9600u;
            Hmi.myapp.runmod = 0;
            Commake.NorComSta.runmod = 1;
        }

        public static unsafe void Hmi_Init()
        {
            strxinxi strxinxi = default(strxinxi);
            appinf0 appinf = default(appinf0);
            Hmi.myapp.delay = 0;
            Hmi.myapp.brush.sta = 0;
            Hmi.myapp.brush.pointcolor = 0;
            Hmi.myapp.brush.backcolor = 0;
            Hmi.myapp.brush.hangjux = 0;
            Hmi.myapp.brush.hangjuy = 0;
            Hmi.myapp.brush.xjuzhong = 0;
            Hmi.myapp.brush.yjuzhong = 0;
            Hmi.myapp.upapp.lcddev.wup = 255;
            Hmi.myapp.brush.pw = 0;
            Hmi.myapp.paus = 0;
            Hmi.myapp.sys.thsp = 0;
            Hmi.myapp.sys.thsleepup = 0;
            Hmi.myapp.sys.ussp = 0;
            Hmi.myapp.touchsendxy = 0;
            Hmi.myapp.errcode = 255;
            Hmi.myapp.dpage = 0;
            Hmi.myapp.Hexstrindex = 65535;
            Hmi.myapp.downobjid = 255;
            Hmi.myapp.moveobjstate = 0;
            Hmi.Hmi_ClearTimer();
            Hmi.Hmi_Clearredian(0);
            Hmi.Hmi_ClearHexstr();
            Hmi.myapp.dpagemerrypos = 0;
            if (Hmi.myapp.binsuc != 1)
            {
                MessageOpen.Show("Data Error!");
            }
            else
            {
                Touch.TP_REST();
                Readdata.Readdata_ReadApp0(ref appinf);
                if (Hmi.myapp.app.strqyt > 0u)
                {
                    Readdata.Readdata_ReadStr(ref strxinxi, 0);
                    if (strxinxi.size < 8192)
                    {
                      
                        Readdata.SPI_Flash_Read(Hmi.myapp.mymerry, Hmi.myapp.app.strdataadd + strxinxi.addbeg, (uint)strxinxi.size);
                        Hmi.myapp.ovemerrys = strxinxi.size;
                    }
                }
                Readdata.Readdata_ReadStr(ref strxinxi, 1);
                Hmi.myapp.pagenameseradd = strxinxi.addbeg + Hmi.myapp.app.strdataadd;
                Hmi.myapp.upapp.Lcd_Set(appinf.guidire);
                uint[] array = new uint[2];
                Hmi.lastpagenamecrc = array;
                Hmi.lastpageid = new ushort[]
                {
                    65535,
                    65535
                };
                Hmi.lastobjaddr = new uint[]
                {
                    65535u,
                    65535u
                };
                array = new uint[2];
                Hmi.lastobjnamecrc = array;
                Hmi.lastobjid = new ushort[]
                {
                    65535,
                    65535
                };
            }
        }

        public unsafe static byte Hmi_GuiObjectRef()
        {
            byte result;
            if (Hmi.myapp.paus == 1)
            {
                result = 255;
            }
            else
            {
                for (byte b = 0; b < Hmi.myapp.dpagexinxi.objqyt; b += 1)
                {
                    if (Hmi.myapp.pageobjs[b].refFlag == 1)
                    {
                        if (b == 0)
                        {
                            for (byte b2 = 1; b2 < Hmi.myapp.dpagexinxi.objqyt; b2 += 1)
                            {
                                Hmi.myapp.pageobjs[b2].refFlag = 1;
                            }
                        }
                        if (Hmi.Hmi_Refobj(b) == 1)
                        {
                            result = 1;
                            return result;
                        }
                    }
                }
                result = 0;
            }
            return result;
        }

        public unsafe static byte Hmi_GuiObjectInit(byte ObjId)
        {
            objxinxi objxinxi = default(objxinxi);
            Readdata.Readdata_ReadObj(ref objxinxi, (int)(Hmi.myapp.dpagexinxi.objstar + (ushort)ObjId));
            if (objxinxi.objType < 50)
            {
                GuiObjControl.GuiObjControls[(int)objxinxi.objType].Init(&objxinxi, ObjId);
            }
            return 1;
        }

        public static void Hmi_ClearHexstr()
        {
            for (int i = 0; i < 8; i++)
            {
                Hmi.myapp.hishexs[i] = 65535;
            }
        }

        public unsafe static byte Hmi_loadref(byte index)
        {
            objxinxi objxinxi = default(objxinxi);
            byte result;
            if (index < Hmi.myapp.dpagexinxi.objqyt)
            {
                ushort index2 =(ushort)(Hmi.myapp.dpagexinxi.objstar + (ushort)index);
                Readdata.Readdata_ReadObj(ref objxinxi, (int)index2);
                if (objxinxi.objType < 50)
                {
                    GuiObjControl.GuiObjControls[(int)objxinxi.objType].Load(&objxinxi, index);
                }
                result = 1;
            }
            else
            {
                Hmi.myapp.errcode = 2;
                result = 0;
            }
            return result;
        }

        public unsafe static byte Hmi_Refobj(byte index)
        {
            objxinxi objxinxi = default(objxinxi);
            byte b = 0;
            byte result;
            if (index < Hmi.myapp.dpagexinxi.objqyt)
            {
                if (Hmi.myapp.pageobjs[index].vis == 1)
                {
                    ushort index2 = (ushort)(Hmi.myapp.dpagexinxi.objstar + (ushort)index);
                    Readdata.Readdata_ReadObj(ref objxinxi, (int)index2);
                    if (objxinxi.objType < 50)
                    {
                        GuiObjControl.GuiObjControls[(int)objxinxi.objType].Ref(&objxinxi, index);
                    }
                    else if (objxinxi.redian.events.Ref != 0)
                    {
                        Hmi.Hmi_SetHexIndex((int)(objxinxi.redian.events.Ref + objxinxi.zhilingstar));
                        if (Hmi.myapp.Hexstrindex != 65535)
                        {
                            b = 1;
                        }
                    }
                }
                Hmi.myapp.pageobjs[index].refFlag = 0;
                result = b;
            }
            else
            {
                Hmi.myapp.errcode = 2;
                result = 0;
            }
            return result;
        }

        public unsafe static byte Hmi_Hideobj(byte index)
        {
            objxinxi objxinxi = default(objxinxi);
            if (Hmi.myapp.pageobjs[index].vis == 1 && Hmi.myapp.pagestate == 1)
            {
                Readdata.Readdata_ReadObj(ref objxinxi, (int)(Hmi.myapp.dpagexinxi.objstar + (ushort)index));
                if (objxinxi.redian.events.Vis != 0)
                {
                    Hmi.Hmi_SetHexIndex((int)(objxinxi.redian.events.Vis + objxinxi.zhilingstar));
                }
            }
            Hmi.myapp.pageobjs[index].vis = 0;
            return 1;
        }

        public unsafe static byte Hmi_RefPage(ushort index)
        {
            strxinxi strxinxi = default(strxinxi);
            byte result;
            if (index >= Hmi.myapp.app.pageqyt)
            {
                Hmi.myapp.errcode = 3;
                result = 0;
            }
            else
            {
                Hmi.myapp.dpage = index;
                Hmi.myapp.downobjid = 255;
                Hmi.myapp.moveobjstate = 0;
                Hmi.myapp.dpagemerrypos = 0;
                Hmi.Hmi_ClearTimer();
                Hmi.Hmi_Clearredian(0);
                Hmi.Hmi_ClearHexstr();
                Hmi.Hmi_GuiPageInit();
                if (Hmi.myapp.upapp.runapptype != runapptype.run || Hmi.myapp.binsuc != 1)
                {
                    result = 1;
                }
                else
                {
                    Hmi.myapp.upapp.pageidchange((int)index);
                    Readdata.Readdata_ReadPage(ref Hmi.myapp.dpagexinxi, (int)index);
                    Readdata.Readdata_ReadStr(ref strxinxi, (int)Hmi.myapp.dpagexinxi.zhilingstar);
                    Hmi.myapp.dobjnameseradd = strxinxi.addbeg + Hmi.myapp.app.strdataadd;
                    Hmi.myapp.pageobjs = (pageobjs_*)(Hmi.myapp.mymerry + Hmi.myapp.ovemerrys);
                    if (Hmi.myapp.dpagexinxi.zhilingqyt > 0)
                    {
                        Readdata.Readdata_ReadStr(ref strxinxi, (int)(Hmi.myapp.dpagexinxi.zhilingstar + 1));
                        Readdata.SPI_Flash_Read(Hmi.myapp.mymerry + Hmi.myapp.ovemerrys, Hmi.myapp.app.strdataadd + strxinxi.addbeg, (uint)strxinxi.size);
                        Hmi.myapp.dpagemerrypos =(ushort)(Hmi.myapp.ovemerrys + strxinxi.size);
                        Hmi.myapp.Hexstrindex = (ushort)(Hmi.myapp.dpagexinxi.zhilingstar + 2);
                        Hmi.myapp.pagestate = 0;
                    }
                    result = 1;
                }
            }
            return result;
        }

        public static void Hmi_CodeEnd()
        {
            Hmi.myapp.Hexstrindex = 65535;
            if (Hmi.Hmi_GuiObjectRef() == 0)
            {
                if (Hmi.myapp.delay > 0)
                {
                    Sys.delay_ms(Hmi.myapp.delay);
                    Hmi.myapp.delay = 0;
                }
            }
            if (Hmi.myapp.Hexstrindex == 65535)
            {
                Hmi.myapp.Hexstrindex = Hmi.Hmi_GetHexstr();
            }
        }

        public unsafe static void Hmi_ScanHexCode()
        {
            PosLaction posLaction = default(PosLaction);
            strxinxi strxinxi = default(strxinxi);
            Readdata.Readdata_ReadStr(ref strxinxi, (int)Hmi.myapp.Hexstrindex);
            myappinf expr_28 = Hmi.myapp;
            expr_28.Hexstrindex += 1;
            if (strxinxi.size == 0 || strxinxi.size > 2048)
            {
                Hmi.Hmi_CodeEnd();
            }
            else
            {
                Readdata.SPI_Flash_Read(Hmi.Hexstrbuf, Hmi.myapp.app.strdataadd + strxinxi.addbeg, (uint)strxinxi.size);
                if (strxinxi.size == 1 && *Hmi.Hexstrbuf == 69)
                {
                    Hmi.Hmi_CodeEnd();
                }
                else
                {
                    posLaction.star = 0;
                    posLaction.end = (ushort)(strxinxi.size - 1);
                    if (Hmi.myapp.upapp.runapptype == runapptype.run)
                    {
                        if (CodeRun.Coderun_Run(Hmi.Hexstrbuf, &posLaction) == 0 && Hmi.myapp.errcode < 255)
                        {
                            Commake.Commake_SendBackerr(Hmi.myapp.errcode);
                        }
                    }
                }
            }
        }

        public unsafe static ushort Hmi_GetPageid(byte* buf, PosLaction* bufpos)
        {
            byte[] array = new byte[14];
            PosLaction posLaction = default(PosLaction);
            ushort result;
            if (buf[bufpos->star] == 112 && buf[bufpos->star + 1] == 91 && buf[bufpos->end] == 93)
            {
                posLaction.star = (ushort)(bufpos->star + 2);
                posLaction.end =(ushort)(bufpos->end - 1);
                byte b;
                int num = CodeRun.strgetS32(buf, &posLaction, &b);
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
                byte b = (byte)(bufpos->end - bufpos->star + 1);
                if (b > 14)
                {
                    result = 65535;
                }
                else
                {
                    fixed (byte* ptr = array)
                    {
                        Kuozhan.memcpy(ptr, buf + bufpos->star, (int)b);
                    }
                    uint num2 = array.getcrc(0);
                    if (num2 == Hmi.lastpagenamecrc[0])
                    {
                        result = Hmi.lastpageid[0];
                    }
                    else if (num2 == Hmi.lastpagenamecrc[1])
                    {
                        result = Hmi.lastpageid[1];
                    }
                    else
                    {
                        Hmi.lastpagenamecrc[0] = Hmi.lastpagenamecrc[1];
                        Hmi.lastpageid[0] = Hmi.lastpageid[1];
                        Hmi.lastpagenamecrc[1] = num2;
                        uint num3 = Datafind.Datafind_FindU32_Flash(&num2, Hmi.myapp.pagenameseradd, Hmi.myapp.app.pageqyt, 6);
                        Hmi.lastpageid[1] = (ushort)num3;
                        result = Hmi.lastpageid[1];
                    }
                }
            }
            return result;
        }

        public unsafe static ushort Hmi_GetObjid(byte* buf, PosLaction* bufpos, uint addr, uint qyt)
        {
            PosLaction posLaction = default(PosLaction);
            byte[] array = new byte[14];
            ushort result;
            if (buf[bufpos->star] == 98 && buf[bufpos->star + 1] == 91 && buf[bufpos->end] == 93)
            {
                posLaction.star =(ushort)(bufpos->star + 2);
                posLaction.end = (ushort)(bufpos->end - 1);
                byte b;
                int num = CodeRun.strgetS32(buf, &posLaction, &b);
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
                byte b = (byte)(bufpos->end - bufpos->star + 1);
                if (b > 14)
                {
                    result = 65535;
                }
                else
                {
                    fixed (byte* ptr = array)
                    {
                        Kuozhan.memcpy(ptr, buf + bufpos->star, (int)b);
                    }
                    uint num2 = array.getcrc(0);
                    if (num2 == Hmi.lastobjnamecrc[0] && addr == Hmi.lastobjaddr[0])
                    {
                        result = Hmi.lastobjid[0];
                    }
                    else if (num2 == Hmi.lastobjnamecrc[1] && addr == Hmi.lastobjaddr[1])
                    {
                        result = Hmi.lastobjid[1];
                    }
                    else
                    {
                        Hmi.lastobjnamecrc[0] = Hmi.lastobjnamecrc[1];
                        Hmi.lastobjid[0] = Hmi.lastobjid[1];
                        Hmi.lastobjaddr[0] = Hmi.lastobjaddr[1];
                        Hmi.lastobjaddr[1] = addr;
                        Hmi.lastobjnamecrc[1] = num2;
                        uint num3 = Datafind.Datafind_FindU32_Flash(&num2, addr, (ushort)qyt, 6);
                        Hmi.lastobjid[1] = (ushort)num3;
                        result = Hmi.lastobjid[1];
                    }
                }
            }
            return result;
        }

        public unsafe static void Hmi_ClearTimer()
        {
            *Hmi.myapp.systimerbuf = 0;
            Hmi.myapp.systimerbuf[1] = 0;
            for (int i = 0; i < 8; i++)
            {
                systimer_type* ptr = (systimer_type*)(Hmi.myapp.systimerbuf + (i * 5 + 4));
                ptr->id = 255;
                ptr->hexbufindex = 65535;
            }
        }

        public unsafe static void Hmi_Clearredian(byte state)
        {
            for (byte b = 0; b < Hmi.myapp.dpagexinxi.objqyt; b += 1)
            {
                Hmi.myapp.pageobjs[b].touchstate = state;
            }
        }

        public unsafe static void Hmi_Getredian(byte state)
        {
            objxinxi objxinxi = default(objxinxi);
            byte b =(byte)(Hmi.myapp.dpagexinxi.objqyt - 1);
            int num = (int)(Hmi.myapp.dpagexinxi.objstar + (ushort)Hmi.myapp.dpagexinxi.objqyt - 1);
            if (Hmi.myapp.dpagexinxi.objqyt != 0)
            {
                if (Hmi.myapp.touchsendxy == 1)
                {
                    Usart.Usart_SendByte(103);
                    Usart.Usart_SendByte((byte)(Hmi.myapp.upapp.tp_dev.x_down >> 8));
                    Usart.Usart_SendByte((byte)Hmi.myapp.upapp.tp_dev.x_down);
                    Usart.Usart_SendByte((byte)(Hmi.myapp.upapp.tp_dev.y_down >> 8));
                    Usart.Usart_SendByte((byte)Hmi.myapp.upapp.tp_dev.y_down);
                    Usart.Usart_SendByte(state);
                    Commake.Commake_SendEnd();
                }
                if (state == 1)
                {
                    for (int i = num; i >= (int)Hmi.myapp.dpagexinxi.objstar; i--)
                    {
                        if (Hmi.myapp.pageobjs[b].vis == 1)
                        {
                            Readdata.Readdata_ReadObj(ref objxinxi, i);
                            if (Hmi.myapp.upapp.tp_dev.x_down > objxinxi.redian.x && Hmi.myapp.upapp.tp_dev.x_down < objxinxi.redian.endx && Hmi.myapp.upapp.tp_dev.y_down > objxinxi.redian.y && Hmi.myapp.upapp.tp_dev.y_down < objxinxi.redian.endy)
                            {
                                if (Hmi.myapp.pageobjs[b].touchstate != 1)
                                {
                                    return;
                                }
                                if (Hmi.myapp.downobjid != b)
                                {
                                    Hmi.myapp.downobjid = b;
                                    if (objxinxi.objType == objtype.OBJECT_TYPE_SLIDER)
                                    {
                                        GuiSlider.GuiSliderPressDown(&objxinxi, b);
                                        Hmi.myapp.moveobjstate = 1;
                                    }
                                    if (objxinxi.redian.events.Down != 0)
                                    {
                                        Hmi.Hmi_SetHexIndex((int)(objxinxi.redian.events.Down + objxinxi.zhilingstar));
                                    }
                                }
                                break;
                            }
                        }
                        b -= 1;
                    }
                }
                else if (state == 0)
                {
                    if (Hmi.myapp.downobjid == 255 || Hmi.myapp.pageobjs[Hmi.myapp.downobjid].vis == 0)
                    {
                        return;
                    }
                    b = Hmi.myapp.downobjid;
                    int i = (int)((ushort)Hmi.myapp.downobjid + Hmi.myapp.dpagexinxi.objstar);
                    Readdata.Readdata_ReadObj(ref objxinxi, i);
                    if (objxinxi.objType == objtype.OBJECT_TYPE_SLIDER)
                    {
                        GuiSlider.GuiSliderPressUp(&objxinxi, Hmi.myapp.downobjid);
                    }
                    if (objxinxi.redian.events.Up != 0)
                    {
                        Hmi.Hmi_SetHexIndex((int)(objxinxi.redian.events.Up + objxinxi.zhilingstar));
                    }
                    if (objxinxi.redian.events.Slide != 0)
                    {
                        Hmi.Hmi_SetHexIndex((int)(objxinxi.redian.events.Slide + objxinxi.zhilingstar));
                    }
                }
                if (((int)objxinxi.redian.sendkey & 1 << (int)state) > 0)
                {
                    Usart.Usart_SendByte(101);
                    Usart.Usart_SendByte((byte)Hmi.myapp.dpage);
                    Usart.Usart_SendByte(b);
                    Usart.Usart_SendByte(state);
                    Commake.Commake_SendEnd();
                }
            }
        }

        public static void Hmi_Scanrediandown()
        {
            Hmi.Hmi_Getredian(1);
            Hmi.myapp.tpdownenter = 0;
        }

        public static void Hmi_Scanredianup()
        {
            Hmi.Hmi_Getredian(0);
            Hmi.myapp.tpupenter = 0;
            Hmi.myapp.downobjid = 255;
            Hmi.myapp.moveobjstate = 0;
        }

        public unsafe static byte Hmi_GetTimerHexbufIndex()
        {
            byte result;
            if (*Hmi.myapp.systimerbuf > 0)
            {
                if (Hmi.myapp.systimerbuf[1] >= *Hmi.myapp.systimerbuf)
                {
                    Hmi.myapp.systimerbuf[1] = 0;
                }
                for (byte b = Hmi.myapp.systimerbuf[1]; b < *Hmi.myapp.systimerbuf; b += 1)
                {
                    systimer_type* ptr = (systimer_type*)(Hmi.myapp.systimerbuf + (b * 5 + 4));
                    if (ptr->val == 65534)
                    {
                        Hmi.Hmi_SetHexIndex((int)ptr->hexbufindex);
                        ptr->val = 65535;
                        Hmi.myapp.systimerbuf[1] = (byte)(b + 1);
                        result = 1;
                        return result;
                    }
                }
                for (byte b = 0; b < Hmi.myapp.systimerbuf[1]; b += 1)
                {
                    systimer_type* ptr = (systimer_type*)(Hmi.myapp.systimerbuf + (b * 5 + 4));
                    if (ptr->val == 65534)
                    {
                        Hmi.Hmi_SetHexIndex((int)ptr->hexbufindex);
                        ptr->val = 65535;
                        Hmi.myapp.systimerbuf[1] =(byte)(b + 1);
                        result = 1;
                        return result;
                    }
                }
            }
            result = 0;
            return result;
        }

        static Hmi()
        {
            // 注意: 此类型已标记为 'beforefieldinit'.
            uint[] array = new uint[2];
            Hmi.lastpagenamecrc = array;
            Hmi.lastpageid = new ushort[]
            {
                65535,
                65535
            };
            Hmi.lastobjaddr = new uint[]
            {
                65535u,
                65535u
            };
            array = new uint[2];
            Hmi.lastobjnamecrc = array;
            Hmi.lastobjid = new ushort[]
            {
                65535,
                65535
            };
        }
    }
}
