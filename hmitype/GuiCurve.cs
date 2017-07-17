using System;

namespace hmitype
{
    public static class GuiCurve
    {
        public struct CURVE_INDEX
        {
            public byte objID;

            public byte Ch;

            public ushort offset;
        }

        private const byte CURVE_PAGE_COUNT = 5;

        private const byte CURVE_OBJ_CHMAX = 4;

        private const byte REF_PER_LINE = 5;

        public static myappinf myapp;

        private static GuiCurve.CURVE_INDEX[] CurveIndex = new GuiCurve.CURVE_INDEX[5];

        private static byte CurveTranIndex = 255;

        private static ushort CurveTranCount = 0;

        public static void GuiCurvePageInit()
        {
            for (int i = 0; i < 5; i++)
            {
                GuiCurve.CurveIndex[i].objID = 255;
                GuiCurve.CurveIndex[i].Ch = 255;
                GuiCurve.CurveIndex[i].offset = 255;
            }
        }

        public unsafe static byte GuiCurveInit(objxinxi* obj, byte ID)
        {
            if (GuiCurve.myapp.upapp.runapptype == runapptype.bianji)
            {
                GuiCurve.GuiCurvePageInit();
            }
            byte result;
            if (obj->attpos + obj->attposqyt > 8192)
            {
                result = 0;
            }
            else
            {
                for (byte b = 0; b < 5; b += 1)
                {
                    if (GuiCurve.CurveIndex[(int)b].objID == 255)
                    {
                        GuiCurve.CurveIndex[(int)b].objID = ID;
                        GuiCurve.CurveIndex[(int)b].offset = obj->attpos;
                        if (GuiCurve.myapp.upapp.runapptype == runapptype.bianji)
                        {
                            GuiCurve.CurveRefBack(obj, ID);
                        }
                        break;
                    }
                }
                result = 1;
            }
            return result;
        }

        public unsafe static byte GuiCurveAdd(GuiCurve.CURVE_INDEX* index, byte data)
        {
            CURVE_PARAM* ptr = (CURVE_PARAM*)(GuiCurve.myapp.mymerry + index->offset);
            byte result;
            if (index->Ch < ptr->CH_qyt)
            {
                CURVE_CHANNEL_PARAM* ptr2 = ptr + (long)sizeof(CURVE_PARAM) / (long)sizeof(CURVE_CHANNEL_PARAM) + (long)(sizeof(CURVE_CHANNEL_PARAM) * (int)index->Ch) / (long)sizeof(CURVE_CHANNEL_PARAM);
                if ((ushort)data > ptr->objHig)
                {
                    GuiCurve.myapp.mymerry[ptr2->BufNext] = (byte)(ptr->objHig - 1);
                }
                else
                {
                    GuiCurve.myapp.mymerry[ptr2->BufNext] = data;
                }
                if (ptr2->BufNext != ptr2->BufPos.end)
                {
                    CURVE_CHANNEL_PARAM* expr_A6 = ptr2;
                    expr_A6->BufNext = expr_A6->BufNext + 1;
                }
                else
                {
                    ptr2->BufNext = ptr2->BufPos.star;
                }
                if (ptr2->DotLen < ptr->objWid)
                {
                    CURVE_CHANNEL_PARAM* expr_E1 = ptr2;
                    expr_E1->DotLen = expr_E1->DotLen + 1;
                }
                GuiCurve.myapp.pageobjs[index->objID].refFlag = 1;
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public unsafe static byte CurveRefBack(objxinxi* obj, byte ID)
        {
            byte[] array = new byte[0];
            CURVE_PARAM* ptr;
            if (GuiCurve.myapp.upapp.runapptype == runapptype.bianji)
            {
                GuiCurve.GuiCurvePageInit();
                ptr = (CURVE_PARAM*)GuiCurve.myapp.mymerry;
            }
            else
            {
                ptr = (CURVE_PARAM*)(GuiCurve.myapp.mymerry + obj->attpos);
            }
            if (GuiCurve.myapp.upapp.runapptype == runapptype.bianji || GuiCurve.myapp.pageobjs[ID].vis == 1)
            {
                if (ptr->BackType == 0)
                {
                    Showpic.Showpic_ShowXpic((int)obj->redian.x, (int)obj->redian.y, obj->redian.endx - obj->redian.x + 1, obj->redian.endy - obj->redian.y + 1, (int)obj->redian.x, (int)obj->redian.y, ptr->PicID);
                }
                else if (ptr->BackType == 2)
                {
                    Showpic.Showpic_ShowPic((int)obj->redian.x, (int)obj->redian.y, ptr->PicID);
                }
                else
                {
                    uint qyt = (uint)(ptr->objWid * ptr->objHig);
                    Lcd.LCD_addset((int)obj->redian.x, (int)obj->redian.y, (int)obj->redian.endx, (int)obj->redian.endy, 1);
                    Lcd.Lcd_WR_POINT(qyt, ptr->Bkclr);
                    if (ptr->GridX > 0)
                    {
                        for (short num = (short)obj->redian.x; num <= (short)obj->redian.endx; num += (short)ptr->GridX)
                        {
                            Lcd.LCD_addset((int)((ushort)num), (int)obj->redian.y, (int)((ushort)num), (int)obj->redian.endy, 1);
                            Lcd.Lcd_WR_POINT((uint)ptr->objHig, ptr->Griclr);
                        }
                    }
                    if (ptr->GridY > 0)
                    {
                        for (short num = (short)obj->redian.endy; num >= (short)obj->redian.y; num -= (short)ptr->GridY)
                        {
                            Lcd.LCD_addset((int)obj->redian.x, (int)((ushort)num), (int)obj->redian.endx, (int)((ushort)num), 1);
                            Lcd.Lcd_WR_POINT((uint)ptr->objWid, ptr->Griclr);
                        }
                    }
                }
            }
            return 1;
        }

        public unsafe static byte GuiCurveRef(objxinxi* obj, byte ID)
        {
            byte b = 0;
            byte[] array = new byte[4];
            ushort[] array2 = new ushort[4];
            ushort[] array3 = new ushort[4];
            ushort[] array4 = new ushort[4];
            ushort[] array5 = new ushort[4];
            byte[] array6 = new byte[4];
            int num = 0;
            int num2 = 0;
            Picturexinxi picturexinxi = default(Picturexinxi);
            CURVE_PARAM* ptr = (CURVE_PARAM*)(GuiCurve.myapp.mymerry + obj->attpos);
            CURVE_CHANNEL_PARAM*[] array7 = new CURVE_CHANNEL_PARAM*[4];
            short num3 = 0;
            short num4 = 0;
            short num5 = 0;
            byte result;
            if (ptr->CH_qyt > 4)
            {
                result = 0;
            }
            else
            {
                for (byte b2 = 0; b2 < ptr->CH_qyt; b2 += 1)
                {
                    array7[(int)b2] = ptr + (long)sizeof(CURVE_PARAM) / (long)sizeof(CURVE_CHANNEL_PARAM) + (long)(sizeof(CURVE_CHANNEL_PARAM) * (int)b2) / (long)sizeof(CURVE_CHANNEL_PARAM);
                }
                byte b3 = 0;
                for (byte b2 = 0; b2 < ptr->CH_qyt; b2 += 1)
                {
                    array[(int)b2] = 1;
                    array4[(int)b2] = array7[(int)b2]->DotLen;
                    if (array4[(int)b2] > 0)
                    {
                        b3 += 1;
                    }
                    array5[(int)b2] = obj->redian.x;
                    if (ptr->DrawDir == 0)
                    {
                        array2[(int)b2] = array7[(int)b2]->BufNext - 1;
                        num5 = -1;
                    }
                    else
                    {
                        num5 = (short)(array7[(int)b2]->BufNext - array7[(int)b2]->BufPos.star);
                        if (num5 >= (short)array4[(int)b2])
                        {
                            array2[(int)b2] = array7[(int)b2]->BufNext - array7[(int)b2]->DotLen;
                        }
                        else
                        {
                            array2[(int)b2] = array7[(int)b2]->BufPos.end - (array7[(int)b2]->DotLen - (ushort)num5) + 1;
                        }
                        if (ptr->DrawDir == 2)
                        {
                            num5 = (short)(obj->redian.endx - obj->redian.x + 1);
                            if (array4[(int)b2] < (ushort)num5)
                            {
                                ushort[] expr_1DE_cp_0 = array5;
                                byte expr_1DE_cp_1 = b2;
                                expr_1DE_cp_0[(int)expr_1DE_cp_1] = expr_1DE_cp_0[(int)expr_1DE_cp_1] + (ushort)(num5 - (short)array4[(int)b2]);
                            }
                        }
                        num5 = 1;
                    }
                }
                if (b3 == 0)
                {
                    GuiCurve.CurveRefBack(obj, ID);
                }
                else
                {
                    if (ptr->BackType == 0)
                    {
                        b = 5;
                        Readdata.Readdata_ReadPic(ref picturexinxi, (int)ptr->PicID);
                        num = (int)(picturexinxi.addbeg + GuiCurve.myapp.app.picdataadd);
                        if (GuiCurve.myapp.upapp.lcddev.guidire == 0)
                        {
                            num += (int)(obj->redian.y * picturexinxi.W + obj->redian.x) << 1;
                            num2 = (int)b << 1;
                        }
                        else if (GuiCurve.myapp.upapp.lcddev.guidire == 1)
                        {
                            num += (int)(picturexinxi.H - obj->redian.endy - 1 + obj->redian.x * picturexinxi.H) << 1;
                            num2 = (int)((ushort)b * picturexinxi.H) << 1;
                        }
                        else if (GuiCurve.myapp.upapp.lcddev.guidire == 2)
                        {
                            num += (int)((picturexinxi.H - obj->redian.endy) * picturexinxi.W - obj->redian.x - (ushort)b) << 1;
                            num2 = (int)b * -2;
                        }
                        else if (GuiCurve.myapp.upapp.lcddev.guidire == 3)
                        {
                            num += (int)(obj->redian.y + (picturexinxi.W - obj->redian.x - (ushort)b) * picturexinxi.H) << 1;
                            num2 = (int)((ushort)b * picturexinxi.H) * -2;
                        }
                    }
                    else if (ptr->BackType == 2)
                    {
                        b = 5;
                        Readdata.Readdata_ReadPic(ref picturexinxi, (int)ptr->PicID);
                        num = (int)(picturexinxi.addbeg + GuiCurve.myapp.app.picdataadd);
                        if (GuiCurve.myapp.upapp.lcddev.guidire == 0)
                        {
                            num2 = (int)b << 1;
                        }
                        else if (GuiCurve.myapp.upapp.lcddev.guidire == 1)
                        {
                            num2 = (int)((ushort)b * picturexinxi.H) << 1;
                        }
                        else if (GuiCurve.myapp.upapp.lcddev.guidire == 2)
                        {
                            num += (int)(picturexinxi.W - (ushort)b) << 1;
                            num2 = (int)b * -2;
                        }
                        else if (GuiCurve.myapp.upapp.lcddev.guidire == 3)
                        {
                            num += (int)((picturexinxi.W - (ushort)b) * picturexinxi.H) << 1;
                            num2 = (int)((ushort)b * picturexinxi.H) * -2;
                        }
                    }
                    else
                    {
                        num3 = (short)obj->redian.x;
                        num4 = num3 + (short)ptr->GridX;
                    }
                    for (short num6 = (short)obj->redian.x; num6 <= (short)obj->redian.endx; num6 += (short)b)
                    {
                        short num7 = num6 + 5 - 1;
                        if (num7 > (short)obj->redian.endx)
                        {
                            num7 = (short)obj->redian.endx;
                        }
                        if (ptr->BackType == 1)
                        {
                            if (ptr->GridX > 0)
                            {
                                ushort num8;
                                if (num6 == num3)
                                {
                                    Lcd.LCD_addset((int)((ushort)num6), (int)obj->redian.y, (int)((ushort)num6), (int)obj->redian.endy, 1);
                                    Lcd.Lcd_WR_POINT((uint)ptr->objHig, ptr->Griclr);
                                    num8 = (ushort)(num6 + 1);
                                }
                                else
                                {
                                    num8 = (ushort)num6;
                                }
                                ushort num9;
                                if (num8 + 5 >= (ushort)num4)
                                {
                                    num9 = (ushort)(num4 - 1);
                                    num3 = num4;
                                    num4 += (short)ptr->GridX;
                                }
                                else
                                {
                                    num9 = num8 + 5 - 1;
                                }
                                b = (byte)(num9 - (ushort)num6 + 1);
                                if (num6 + (short)b > (short)obj->redian.endx)
                                {
                                    num9 = (ushort)num7;
                                    b = (byte)(num7 - num6 + 1);
                                }
                                if (ptr->GridY > 0)
                                {
                                    for (short num10 = (short)obj->redian.endy; num10 >= (short)obj->redian.y; num10 -= (short)ptr->GridY)
                                    {
                                        short num11 = num10 - (short)ptr->GridY + 1;
                                        if (num11 < (short)obj->redian.y)
                                        {
                                            num11 = (short)obj->redian.y;
                                        }
                                        Lcd.LCD_addset((int)num8, (int)((ushort)num10), (int)num9, (int)((ushort)num10), 1);
                                        Lcd.Lcd_WR_POINT((uint)(num9 - num8 + 1), ptr->Griclr);
                                        Lcd.LCD_addset((int)num8, (int)((ushort)num11), (int)num9, (int)((ushort)(num10 - 1)), 1);
                                        Lcd.Lcd_WR_POINT((uint)((num9 - num8 + 1) * (ushort)(num10 - num11)), ptr->Bkclr);
                                    }
                                }
                                else
                                {
                                    num = (int)(ptr->objHig * (num9 - num8 + 1));
                                    Lcd.LCD_addset((int)num8, (int)obj->redian.y, (int)num9, (int)obj->redian.endy, 1);
                                    Lcd.Lcd_WR_POINT((uint)num, ptr->Bkclr);
                                }
                            }
                            else if (ptr->GridY > 0)
                            {
                                for (short num10 = (short)obj->redian.endy; num10 >= (short)obj->redian.y; num10 -= (short)ptr->GridY)
                                {
                                    short num11 = num10 - (short)ptr->GridY + 1;
                                    if (num11 < (short)obj->redian.y)
                                    {
                                        num11 = (short)obj->redian.y;
                                    }
                                    Lcd.LCD_addset((int)((ushort)num6), (int)((ushort)num11), (int)((ushort)num7), (int)((ushort)num10), 1);
                                    b = (byte)(num7 - num6 + 1);
                                    Lcd.Lcd_WR_POINT((uint)((short)b * (num10 - num11)), ptr->Bkclr);
                                    Lcd.Lcd_WR_POINT((uint)b, ptr->Griclr);
                                }
                            }
                            else
                            {
                                b = (byte)(num7 - num6 + 1);
                                num = (int)(ptr->objHig * (ushort)(num7 - num6 + 1));
                                Lcd.LCD_addset((int)((ushort)num6), (int)obj->redian.y, (int)((ushort)num7), (int)obj->redian.endy, 1);
                                Lcd.Lcd_WR_POINT((uint)num, ptr->Bkclr);
                            }
                        }
                        else
                        {
                            Lcd.LCD_addset((int)((ushort)num6), (int)obj->redian.y, (int)((ushort)num7), (int)obj->redian.endy, 1);
                            if ((GuiCurve.myapp.upapp.lcddev.guidire & 1) > 0)
                            {
                                Showpic.Showpic_SendDataOffset((uint)num, (ushort)(picturexinxi.H << 1), (ushort)(num7 - num6 + 1), (byte)ptr->objHig);
                            }
                            else
                            {
                                Showpic.Showpic_SendDataOffset((uint)num, (ushort)(picturexinxi.W << 1), ptr->objHig, (byte)(num7 - num6 + 1));
                            }
                            num += num2;
                        }
                        for (byte b2 = 0; b2 < ptr->CH_qyt; b2 += 1)
                        {
                            if (array4[(int)b2] > 0 && num6 >= (short)array5[(int)b2])
                            {
                                for (b3 = 0; b3 < b; b3 += 1)
                                {
                                    byte b4 = GuiCurve.myapp.mymerry[array2[(int)b2]];
                                    byte b5 = array6[(int)b2];
                                    if (array[(int)b2] > 0)
                                    {
                                        b5 = b4;
                                        array[(int)b2] = 0;
                                    }
                                    if (b4 > b5)
                                    {
                                        byte qyt = b4 - b5 + 1;
                                        Lcd.LCD_addset((int)((ushort)(num6 + (short)b3)), (int)(obj->redian.endy - (ushort)b4), (int)((ushort)(num6 + (short)b3)), (int)(obj->redian.endy - (ushort)b5), 1);
                                        Lcd.Lcd_WR_POINT((uint)qyt, array7[(int)b2]->Penclr);
                                    }
                                    else
                                    {
                                        byte qyt = b5 - b4 + 1;
                                        Lcd.LCD_addset((int)((ushort)(num6 + (short)b3)), (int)(obj->redian.endy - (ushort)b5), (int)((ushort)(num6 + (short)b3)), (int)(obj->redian.endy - (ushort)b4), 1);
                                        Lcd.Lcd_WR_POINT((uint)qyt, array7[(int)b2]->Penclr);
                                    }
                                    array6[(int)b2] = b4;
                                    array2[(int)b2] = array2[(int)b2] + (ushort)num5;
                                    if (array2[(int)b2] > array7[(int)b2]->BufPos.end)
                                    {
                                        array2[(int)b2] = array7[(int)b2]->BufPos.star;
                                    }
                                    else if (array2[(int)b2] < array7[(int)b2]->BufPos.star)
                                    {
                                        array2[(int)b2] = array7[(int)b2]->BufPos.end;
                                    }
                                    ushort[] expr_ABE_cp_0 = array4;
                                    byte expr_ABE_cp_1 = b2;
                                    expr_ABE_cp_0[(int)expr_ABE_cp_1] = expr_ABE_cp_0[(int)expr_ABE_cp_1] - 1;
                                    if (array4[(int)b2] == 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                GuiCurve.myapp.pageobjs[ID].refFlag = 0;
                result = 0;
            }
            return result;
        }

        public unsafe static byte GuiCruveClear(byte id, byte ch)
        {
            byte b = 255;
            byte result;
            for (byte b2 = 0; b2 < 5; b2 += 1)
            {
                if (GuiCurve.CurveIndex[(int)b2].objID == id)
                {
                    CURVE_PARAM* ptr = (CURVE_PARAM*)(GuiCurve.myapp.mymerry + GuiCurve.CurveIndex[(int)b2].offset);
                    if (ch < ptr->CH_qyt)
                    {
                        b = ch;
                    }
                    else if (ch == 255)
                    {
                        ch = 0;
                        b = ptr->CH_qyt - 1;
                    }
                    if (b < 255)
                    {
                        while (ch <= b)
                        {
                            CURVE_CHANNEL_PARAM* ptr2 = ptr + (long)sizeof(CURVE_PARAM) / (long)sizeof(CURVE_CHANNEL_PARAM) + (long)(sizeof(CURVE_CHANNEL_PARAM) * (int)ch) / (long)sizeof(CURVE_CHANNEL_PARAM);
                            ptr2->DotLen = 0;
                            ptr2->BufNext = ptr2->BufPos.star;
                            GuiCurve.myapp.pageobjs[id].refFlag = 1;
                            ch += 1;
                        }
                        result = 1;
                        return result;
                    }
                }
            }
            result = 0;
            return result;
        }

        public unsafe static byte GuiCruveCmd(byte id, byte ch, byte data)
        {
            byte b;
            for (b = 0; b < 5; b += 1)
            {
                if (GuiCurve.CurveIndex[(int)b].objID == id)
                {
                    break;
                }
            }
            byte result;
            if (b < 5)
            {
                if (ch < 4)
                {
                    GuiCurve.CurveIndex[(int)b].Ch = ch;
                    byte b2;
                    fixed (void* ptr = (void*)(&GuiCurve.CurveIndex[(int)b]))
                    {
                        b2 = GuiCurve.GuiCurveAdd((GuiCurve.CURVE_INDEX*)ptr, data);
                    }
                    result = b2;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public unsafe static byte SetCurveTranMode(byte ObjID, byte Ch, ushort Len)
        {
            GuiCurve.CurveTranIndex = 0;
            while (GuiCurve.CurveTranIndex < 5)
            {
                if (GuiCurve.CurveIndex[(int)GuiCurve.CurveTranIndex].objID == ObjID)
                {
                    break;
                }
                GuiCurve.CurveTranIndex += 1;
            }
            byte result;
            if (GuiCurve.CurveTranIndex < 5)
            {
                CURVE_PARAM* ptr = (CURVE_PARAM*)(GuiCurve.myapp.mymerry + GuiCurve.CurveIndex[(int)GuiCurve.CurveTranIndex].offset);
                if (Ch < ptr->CH_qyt)
                {
                    if (Len < 1024)
                    {
                        GuiCurve.CurveIndex[(int)GuiCurve.CurveTranIndex].Ch = Ch;
                        GuiCurve.CurveTranCount = Len;
                        result = 1;
                        return result;
                    }
                }
            }
            result = 0;
            return result;
        }

        public unsafe static byte RecCurveTranData(byte dat)
        {
            byte result;
            if (GuiCurve.CurveTranCount > 0)
            {
                fixed (void* ptr = (void*)(&GuiCurve.CurveIndex[(int)GuiCurve.CurveTranIndex]))
                {
                    GuiCurve.GuiCurveAdd((GuiCurve.CURVE_INDEX*)ptr, dat);
                }
                GuiCurve.CurveTranCount -= 1;
                if (GuiCurve.CurveTranCount == 0)
                {
                    GuiCurve.myapp.USART.State = 9;
                }
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
