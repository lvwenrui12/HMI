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
            CURVE_PARAM* curve_paramPtr = (CURVE_PARAM*)(myapp.mymerry + index->offset);
            if (index->Ch < curve_paramPtr->CH_qyt)
            {
                CURVE_CHANNEL_PARAM* curve_channel_paramPtr = (CURVE_CHANNEL_PARAM*)((((uint)curve_paramPtr) + sizeof(CURVE_PARAM)) + (sizeof(CURVE_CHANNEL_PARAM) * index->Ch));
                if (data > curve_paramPtr->objHig)
                {
                    myapp.mymerry[curve_channel_paramPtr->BufNext] = (byte)(curve_paramPtr->objHig - 1);
                }
                else
                {
                    myapp.mymerry[curve_channel_paramPtr->BufNext] = data;
                }
                if (curve_channel_paramPtr->BufNext != curve_channel_paramPtr->BufPos.end)
                {
                    curve_channel_paramPtr->BufNext = (ushort)(curve_channel_paramPtr->BufNext + 1);
                }
                else
                {
                    curve_channel_paramPtr->BufNext = curve_channel_paramPtr->BufPos.star;
                }
                if (curve_channel_paramPtr->DotLen < curve_paramPtr->objWid)
                {
                    curve_channel_paramPtr->DotLen = (ushort)(curve_channel_paramPtr->DotLen + 1);
                }
                myapp.pageobjs[index->objID].refFlag = 1;
                return 1;
            }
            return 0;

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
                    Showpic.Showpic_ShowXpic((int)obj->redian.x, (int)obj->redian.y, (ushort)(obj->redian.endx - obj->redian.x + 1), (ushort)(obj->redian.endy - obj->redian.y + 1), (int)obj->redian.x, (int)obj->redian.y, ptr->PicID);
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
            byte qyt = 0;
            byte[] buffer = new byte[4];
            ushort[] numArray = new ushort[4];
            ushort[] numArray2 = new ushort[4];
            ushort[] numArray3 = new ushort[4];
            ushort[] numArray4 = new ushort[4];
            byte[] buffer2 = new byte[4];
            int num9 = 0;
            int num10 = 0;
            Picturexinxi pic = new Picturexinxi();
            CURVE_PARAM* curve_paramPtr = (CURVE_PARAM*)(myapp.mymerry + obj->attpos);
            CURVE_CHANNEL_PARAM*[] curve_channel_paramPtrArray = new CURVE_CHANNEL_PARAM*[4];
            short x = 0;
            short num12 = 0;
            short endy = 0;
            short y = 0;
            short num17 = 0;
            if (curve_paramPtr->CH_qyt <= 4)
            {
                byte num3;
                for (num3 = 0; num3 < curve_paramPtr->CH_qyt; num3 = (byte)(num3 + 1))
                {
                    curve_channel_paramPtrArray[num3] = (CURVE_CHANNEL_PARAM*)((((uint)curve_paramPtr) + sizeof(CURVE_PARAM)) + (sizeof(CURVE_CHANNEL_PARAM) * num3));
                }
                byte num2 = 0;
                num3 = 0;
                while (num3 < curve_paramPtr->CH_qyt)
                {
                    buffer[num3] = 1;
                    numArray3[num3] = curve_channel_paramPtrArray[num3]->DotLen;
                    if (numArray3[num3] > 0)
                    {
                        num2 = (byte)(num2 + 1);
                    }
                    numArray4[num3] = obj->redian.x;
                    if (curve_paramPtr->DrawDir == 0)
                    {
                        numArray[num3] = (ushort)(curve_channel_paramPtrArray[num3]->BufNext - 1);
                        num17 = -1;
                    }
                    else
                    {
                        num17 = (short)(curve_channel_paramPtrArray[num3]->BufNext - curve_channel_paramPtrArray[num3]->BufPos.star);
                        if (num17 >= numArray3[num3])
                        {
                            numArray[num3] = (ushort)(curve_channel_paramPtrArray[num3]->BufNext - curve_channel_paramPtrArray[num3]->DotLen);
                        }
                        else
                        {
                            numArray[num3] = (ushort)((curve_channel_paramPtrArray[num3]->BufPos.end - (curve_channel_paramPtrArray[num3]->DotLen - num17)) + 1);
                        }
                        if (curve_paramPtr->DrawDir == 2)
                        {
                            num17 = (short)((obj->redian.endx - obj->redian.x) + 1);
                            if (numArray3[num3] < num17)
                            {
                                numArray4[num3] = (ushort)(numArray4[num3] + ((ushort)(num17 - numArray3[num3])));
                            }
                        }
                        num17 = 1;
                    }
                    num3 = (byte)(num3 + 1);
                }
                if (num2 == 0)
                {
                    CurveRefBack(obj, ID);
                }
                else
                {
                    if (curve_paramPtr->BackType == 0)
                    {
                        qyt = 5;
                        Readdata.Readdata_ReadPic(ref pic, curve_paramPtr->PicID);
                        num9 = (int)(pic.addbeg + myapp.app.picdataadd);
                        if (myapp.upapp.lcddev.guidire == 0)
                        {
                            num9 += ((obj->redian.y * pic.W) + obj->redian.x) << 1;
                            num10 = qyt << 1;
                        }
                        else if (myapp.upapp.lcddev.guidire == 1)
                        {
                            num9 += (((pic.H - obj->redian.endy) - 1) + (obj->redian.x * pic.H)) << 1;
                            num10 = (qyt * pic.H) << 1;
                        }
                        else if (myapp.upapp.lcddev.guidire == 2)
                        {
                            num9 += ((((pic.H - obj->redian.endy) * pic.W) - obj->redian.x) - qyt) << 1;
                            num10 = qyt * -2;
                        }
                        else if (myapp.upapp.lcddev.guidire == 3)
                        {
                            num9 += (obj->redian.y + (((pic.W - obj->redian.x) - qyt) * pic.H)) << 1;
                            num10 = (qyt * pic.H) * -2;
                        }
                    }
                    else if (curve_paramPtr->BackType == 2)
                    {
                        qyt = 5;
                        Readdata.Readdata_ReadPic(ref pic, curve_paramPtr->PicID);
                        num9 = (int)(pic.addbeg + myapp.app.picdataadd);
                        if (myapp.upapp.lcddev.guidire == 0)
                        {
                            num10 = qyt << 1;
                        }
                        else if (myapp.upapp.lcddev.guidire == 1)
                        {
                            num10 = (qyt * pic.H) << 1;
                        }
                        else if (myapp.upapp.lcddev.guidire == 2)
                        {
                            num9 += (pic.W - qyt) << 1;
                            num10 = qyt * -2;
                        }
                        else if (myapp.upapp.lcddev.guidire == 3)
                        {
                            num9 += ((pic.W - qyt) * pic.H) << 1;
                            num10 = (qyt * pic.H) * -2;
                        }
                    }
                    else
                    {
                        x = (short)obj->redian.x;
                        num12 = (short)(x + curve_paramPtr->GridX);
                    }
                    for (short i = (short)obj->redian.x; i <= obj->redian.endx; i = (short)(i + qyt))
                    {
                        short endx = (short)((i + 5) - 1);
                        if (endx > obj->redian.endx)
                        {
                            endx = (short)obj->redian.endx;
                        }
                        if (curve_paramPtr->BackType == 1)
                        {
                            if (curve_paramPtr->GridX > 0)
                            {
                                ushort num15;
                                ushort num16;
                                if (i == x)
                                {
                                    Lcd.LCD_addset((ushort)i, obj->redian.y, (ushort)i, obj->redian.endy, 1);
                                    Lcd.Lcd_WR_POINT(curve_paramPtr->objHig, curve_paramPtr->Griclr);
                                    num15 = (ushort)(i + 1);
                                }
                                else
                                {
                                    num15 = (ushort)i;
                                }
                                if ((num15 + 5) >= num12)
                                {
                                    num16 = (ushort)(num12 - 1);
                                    x = num12;
                                    num12 = (short)(num12 + curve_paramPtr->GridX);
                                }
                                else
                                {
                                    num16 = (ushort)((num15 + 5) - 1);
                                }
                                qyt = (byte)((num16 - i) + 1);
                                if ((i + qyt) > obj->redian.endx)
                                {
                                    num16 = (ushort)endx;
                                    qyt = (byte)((endx - i) + 1);
                                }
                                if (curve_paramPtr->GridY > 0)
                                {
                                    endy = (short)obj->redian.endy;
                                    while (endy >= obj->redian.y)
                                    {
                                        y = (short)((endy - curve_paramPtr->GridY) + 1);
                                        if (y < obj->redian.y)
                                        {
                                            y = (short)obj->redian.y;
                                        }
                                        Lcd.LCD_addset(num15, (ushort)endy, num16, (ushort)endy, 1);
                                        Lcd.Lcd_WR_POINT((ushort)((num16 - num15) + 1), curve_paramPtr->Griclr);
                                        Lcd.LCD_addset(num15, (ushort)y, num16, (ushort)(endy - 1), 1);
                                        Lcd.Lcd_WR_POINT((uint)(((num16 - num15) + 1) * (endy - y)), curve_paramPtr->Bkclr);
                                        endy = (short)(endy - curve_paramPtr->GridY);
                                    }
                                }
                                else
                                {
                                    num9 = curve_paramPtr->objHig * ((num16 - num15) + 1);
                                    Lcd.LCD_addset(num15, obj->redian.y, num16, obj->redian.endy, 1);
                                    Lcd.Lcd_WR_POINT((uint)num9, curve_paramPtr->Bkclr);
                                }
                            }
                            else if (curve_paramPtr->GridY > 0)
                            {
                                for (endy = (short)obj->redian.endy; endy >= obj->redian.y; endy = (short)(endy - curve_paramPtr->GridY))
                                {
                                    y = (short)((endy - curve_paramPtr->GridY) + 1);
                                    if (y < obj->redian.y)
                                    {
                                        y = (short)obj->redian.y;
                                    }
                                    Lcd.LCD_addset((ushort)i, (ushort)y, (ushort)endx, (ushort)endy, 1);
                                    qyt = (byte)((endx - i) + 1);
                                    Lcd.Lcd_WR_POINT((uint)(qyt * (endy - y)), curve_paramPtr->Bkclr);
                                    Lcd.Lcd_WR_POINT(qyt, curve_paramPtr->Griclr);
                                }
                            }
                            else
                            {
                                qyt = (byte)((endx - i) + 1);
                                num9 = curve_paramPtr->objHig * ((endx - i) + 1);
                                Lcd.LCD_addset((ushort)i, obj->redian.y, (ushort)endx, obj->redian.endy, 1);
                                Lcd.Lcd_WR_POINT((uint)num9, curve_paramPtr->Bkclr);
                            }
                        }
                        else
                        {
                            Lcd.LCD_addset((ushort)i, obj->redian.y, (ushort)endx, obj->redian.endy, 1);
                            if ((myapp.upapp.lcddev.guidire & 1) > 0)
                            {
                                Showpic.Showpic_SendDataOffset((uint)num9, (ushort)(pic.H << 1), (ushort)((endx - i) + 1), (byte)curve_paramPtr->objHig);
                            }
                            else
                            {
                                Showpic.Showpic_SendDataOffset((uint)num9, (ushort)(pic.W << 1), curve_paramPtr->objHig, (byte)((endx - i) + 1));
                            }
                            num9 += num10;
                        }
                        for (num3 = 0; num3 < curve_paramPtr->CH_qyt; num3 = (byte)(num3 + 1))
                        {
                            if ((numArray3[num3] > 0) && (i >= numArray4[num3]))
                            {
                                for (num2 = 0; num2 < qyt; num2 = (byte)(num2 + 1))
                                {
                                    byte num6;
                                    byte num5 = myapp.mymerry[numArray[num3]];
                                    byte num4 = buffer2[num3];
                                    if (buffer[num3] > 0)
                                    {
                                        num4 = num5;
                                        buffer[num3] = 0;
                                    }
                                    if (num5 > num4)
                                    {
                                        num6 = (byte)((num5 - num4) + 1);
                                        Lcd.LCD_addset((ushort)(i + num2), (ushort)(obj->redian.endy - num5), (ushort)(i + num2), (ushort)(obj->redian.endy - num4), 1);
                                        Lcd.Lcd_WR_POINT(num6, curve_channel_paramPtrArray[num3]->Penclr);
                                    }
                                    else
                                    {
                                        num6 = (byte)((num4 - num5) + 1);
                                        Lcd.LCD_addset((ushort)(i + num2), (ushort)(obj->redian.endy - num4), (ushort)(i + num2), (ushort)(obj->redian.endy - num5), 1);
                                        Lcd.Lcd_WR_POINT(num6, curve_channel_paramPtrArray[num3]->Penclr);
                                    }
                                    buffer2[num3] = num5;
                                    numArray[num3] = (ushort)(numArray[num3] + num17);
                                    if (numArray[num3] > curve_channel_paramPtrArray[num3]->BufPos.end)
                                    {
                                        numArray[num3] = curve_channel_paramPtrArray[num3]->BufPos.star;
                                    }
                                    else if (numArray[num3] < curve_channel_paramPtrArray[num3]->BufPos.star)
                                    {
                                        numArray[num3] = curve_channel_paramPtrArray[num3]->BufPos.end;
                                    }
                                    numArray3[num3] = (ushort)(numArray3[num3] - 1);
                                    if (numArray3[num3] == 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                myapp.pageobjs[ID].refFlag = 0;
            }
            return 0;

        }

        public static unsafe byte GuiCruveClear(byte id, byte ch)
        {
            byte num2 = 0xff;
            for (byte i = 0; i < 5; i = (byte)(i + 1))
            {
                if (CurveIndex[i].objID == id)
                {
                    CURVE_PARAM* curve_paramPtr = (CURVE_PARAM*)(myapp.mymerry + CurveIndex[i].offset);
                    if (ch < curve_paramPtr->CH_qyt)
                    {
                        num2 = ch;
                    }
                    else if (ch == 0xff)
                    {
                        ch = 0;
                        num2 = (byte)(curve_paramPtr->CH_qyt - 1);
                    }
                    if (num2 < 0xff)
                    {
                        while (ch <= num2)
                        {
                            CURVE_CHANNEL_PARAM* curve_channel_paramPtr = (CURVE_CHANNEL_PARAM*)((((uint)curve_paramPtr) + sizeof(CURVE_PARAM)) + (sizeof(CURVE_CHANNEL_PARAM) * ch));
                            curve_channel_paramPtr->DotLen = 0;
                            curve_channel_paramPtr->BufNext = curve_channel_paramPtr->BufPos.star;
                            myapp.pageobjs[id].refFlag = 1;
                            ch = (byte)(ch + 1);
                        }
                        return 1;
                    }
                }
            }
            return 0;
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
                    fixed (void* ptr =(&GuiCurve.CurveIndex[(int)b]))
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
                fixed (void* ptr =(&GuiCurve.CurveIndex[(int)GuiCurve.CurveTranIndex]))
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
