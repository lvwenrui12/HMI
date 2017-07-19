using System;

namespace hmitype
{
    public static class GuiSlider
    {
        public static myappinf myapp;

        private unsafe static byte ValueToTouchPos(objxinxi* obj, SLIDER_PARAM* pSliRam, byte ID)
        {
            if (pSliRam->Mode > 0)
            {
                byte b = Convert.ToByte(pSliRam->CursorHig / 2);
                byte b2 = Convert.ToByte(pSliRam->CursorHig - b);
                if (pSliRam->NowVal >= pSliRam->MaxVal)
                {
                    pSliRam->TouchPos = (ushort)(obj->redian.y + (ushort)b2 - 1);
                }
                else if (pSliRam->NowVal <= pSliRam->MinVal)
                {
                    pSliRam->TouchPos = (ushort)(obj->redian.endy - (ushort)b);
                }
                else
                {
                    ushort num = (ushort)((pSliRam->NowVal - pSliRam->MinVal) * (obj->redian.endy - obj->redian.y - (ushort)pSliRam->CursorHig + 1) / (pSliRam->MaxVal - pSliRam->MinVal + 1));
                    pSliRam->TouchPos = (ushort)(obj->redian.endy - (ushort)b2 - num);
                }
            }
            else
            {
                byte b = Convert.ToByte(pSliRam->CursorWid / 2);
                byte b2 = Convert.ToByte(pSliRam->CursorWid - b);
                if (pSliRam->NowVal >= pSliRam->MaxVal)
                {
                    pSliRam->TouchPos =(ushort)(obj->redian.endx - (ushort)b2 + 1);
                }
                else if (pSliRam->NowVal <= pSliRam->MinVal)
                {
                    pSliRam->TouchPos = (ushort)(obj->redian.x + (ushort)b);
                }
                else
                {
                    ushort num = (ushort)((long)(obj->redian.x + (ushort)b) + (long)((ulong)(pSliRam->NowVal - pSliRam->MinVal) * (ulong)((long)(obj->redian.endx - obj->redian.x - (ushort)pSliRam->CursorWid + 1)) / (ulong)((long)(pSliRam->MaxVal - pSliRam->MinVal + 1))));
                    pSliRam->TouchPos = num;
                }
            }
            if (GuiSlider.myapp.upapp.runapptype == runapptype.run)
            {
                GuiSlider.myapp.pageobjs[ID].refFlag = 1;
            }
            pSliRam->LastVal = pSliRam->NowVal;
            return 1;
        }

        private unsafe static byte DrawSliderBackGround(objxinxi* obj, SLIDER_PARAM* pSliRam)
        {
            byte result;
            switch (pSliRam->BackType)
            {
                case 0:
                    if (pSliRam->BkPicID >= GuiSlider.myapp.app.picqyt)
                    {
                        result = 0;
                        return result;
                    }
                    Readdata.Readdata_ReadPic(ref GuiSlider.myapp.brush.pic, (int)pSliRam->BkPicID);
                    break;
                case 1:
                    GuiSlider.myapp.brush.backcolor = pSliRam->BkPicID;
                    break;
                case 2:
                    if (pSliRam->BkPicID >= GuiSlider.myapp.app.picqyt)
                    {
                        result = 0;
                        return result;
                    }
                    GuiSlider.myapp.brush.x = obj->redian.x;
                    GuiSlider.myapp.brush.y = obj->redian.y;
                    Readdata.Readdata_ReadPic(ref GuiSlider.myapp.brush.pic, (int)pSliRam->BkPicID);
                    break;
            }
            GuiSlider.myapp.brush.sta = pSliRam->BackType;
            Showpic.Showpic_Clearspa((int)obj->redian.x, (int)obj->redian.y, (int)(obj->redian.endx - obj->redian.x + 1), (int)(obj->redian.endy - obj->redian.y + 1));
            result = 1;
            return result;
        }

        private unsafe static byte DrawSliderCursor(objxinxi* obj, SLIDER_PARAM* pSliRam, ushort* CurXPos, ushort* CurXEnd, ushort* CurYPos, ushort* CurYEnd)
        {
            if (pSliRam->Mode > 0)
            {
                byte b = (byte)(pSliRam->CursorHig / 2);
                *CurXPos = (ushort)((obj->redian.endx - obj->redian.x + 1 - (ushort)pSliRam->CursorWid) / 2 + obj->redian.x);
                *CurXEnd = (ushort)(*CurXPos + (ushort)pSliRam->CursorWid - 1);
                *CurYEnd =(ushort)(pSliRam->TouchPos + (ushort)b);
                *CurYPos = (ushort)(*CurYEnd - (ushort)pSliRam->CursorHig + 1);
            }
            else
            {
                byte b =(Convert.ToByte(pSliRam->CursorWid / 2));
                *CurYPos = (ushort)((obj->redian.endy - obj->redian.y + 1 - (ushort)pSliRam->CursorHig) / 2 + obj->redian.y);
                *CurYEnd =(ushort)(*CurYPos + (ushort)pSliRam->CursorHig - 1);
                *CurXPos =(ushort)(pSliRam->TouchPos - (ushort)b);
                *CurXEnd = (ushort)(*CurXPos + (ushort)pSliRam->CursorWid - 1);
            }
            byte result;
            if (pSliRam->CursorType > 0)
            {
                if (pSliRam->CuPicID >= GuiSlider.myapp.app.picqyt)
                {
                    result = 0;
                    return result;
                }
                GuiSlider.myapp.brush.sta = 2;
                Readdata.Readdata_ReadPic(ref GuiSlider.myapp.brush.pic, (int)pSliRam->CuPicID);
                GuiSlider.myapp.brush.x = *CurXPos;
                GuiSlider.myapp.brush.y = *CurYPos;
            }
            else
            {
                GuiSlider.myapp.brush.sta = 1;
                GuiSlider.myapp.brush.backcolor = pSliRam->CuPicID;
            }
            Showpic.Showpic_Clearspa((int)(*CurXPos), (int)(*CurYPos), (int)pSliRam->CursorWid, (int)pSliRam->CursorHig);
            result = 1;
            return result;
        }

        private unsafe static byte ClearSliderCursor(objxinxi* obj, SLIDER_PARAM* pSliRam, ushort* CurXPos, ushort* CurXEnd, ushort* CurYPos, ushort* CurYEnd)
        {
            ushort num = 0;
            ushort num2 = 0;
            ushort num3 = 0;
            ushort num4 = 0;
            if (pSliRam->Mode > 0)
            {
                num = *CurXPos;
                num3 = *CurXEnd;
                if (*CurYEnd < pSliRam->LastPos)
                {
                    num4 = pSliRam->LastPos;
                    num2 =(ushort)(num4 - (ushort)pSliRam->CursorHig + 1);
                    if (*CurYEnd >= num2)
                    {
                        num2 =(ushort)(*CurYEnd + 1);
                    }
                }
                else if (*CurYEnd > pSliRam->LastPos)
                {
                    num4 = pSliRam->LastPos;
                    num2 = (ushort)(num4 - (ushort)pSliRam->CursorHig + 1);
                    if (num4 >= *CurYPos)
                    {
                        num4 = (ushort)(*CurYPos - 1);
                    }
                }
            }
            else
            {
                num2 = *CurYPos;
                num4 = *CurYEnd;
                if (*CurXPos < pSliRam->LastPos)
                {
                    num = pSliRam->LastPos;
                    num3 =(ushort)(num + (ushort)pSliRam->CursorWid - 1);
                    if (*CurXEnd >= num)
                    {
                        num =(ushort)(*CurXEnd + 1);
                    }
                }
                else if (*CurXPos > pSliRam->LastPos)
                {
                    num = pSliRam->LastPos;
                    num3 = (ushort)(num + (ushort)pSliRam->CursorWid - 1);
                    if (num3 >= *CurXPos)
                    {
                        num3 =(ushort)(*CurXPos - 1);
                    }
                }
            }
            switch (pSliRam->BackType)
            {
                case 0:
                    Readdata.Readdata_ReadPic(ref GuiSlider.myapp.brush.pic, (int)pSliRam->BkPicID);
                    break;
                case 1:
                    GuiSlider.myapp.brush.backcolor = pSliRam->BkPicID;
                    break;
                case 2:
                    Readdata.Readdata_ReadPic(ref GuiSlider.myapp.brush.pic, (int)pSliRam->BkPicID);
                    GuiSlider.myapp.brush.x = obj->redian.x;
                    GuiSlider.myapp.brush.y = obj->redian.y;
                    break;
            }
            GuiSlider.myapp.brush.sta = pSliRam->BackType;
            Showpic.Showpic_Clearspa((int)num, (int)num2, (int)(num3 - num + 1), (int)(num4 - num2 + 1));
            return 1;
        }

        private unsafe static byte RefSliderCursor(objxinxi* obj, byte ID)
        {
            SLIDER_PARAM* ptr = (SLIDER_PARAM*)(GuiSlider.myapp.mymerry + obj->attpos);
            ushort lastPos;
            ushort num;
            ushort num2;
            ushort lastPos2;
            GuiSlider.DrawSliderCursor(obj, ptr, &lastPos, &num, &num2, &lastPos2);
            GuiSlider.ClearSliderCursor(obj, ptr, &lastPos, &num, &num2, &lastPos2);
            if (ptr->Mode > 0)
            {
                ptr->LastPos = lastPos2;
            }
            else
            {
                ptr->LastPos = lastPos;
            }
            return 1;
        }

        public unsafe static byte GuiSliderLoad(objxinxi* obj, byte ID)
        {
            GuiSlider.GuiSliderRef(obj, ID);
            return 1;
        }

        public unsafe static byte GuiSliderObjInit(objxinxi* obj, byte ID)
        {
            if (GuiSlider.myapp.upapp.runapptype == runapptype.bianji)
            {
                GuiSlider.GuiSliderRef(obj, ID);
            }
            return 1;
        }

        public unsafe static byte GuiSliderRef(objxinxi* obj, byte ID)
        {
            SLIDER_PARAM* ptr;
            if (GuiSlider.myapp.upapp.runapptype == runapptype.bianji)
            {
                ptr = (SLIDER_PARAM*)GuiSlider.myapp.mymerry;
            }
            else
            {
                ptr = (SLIDER_PARAM*)(GuiSlider.myapp.mymerry + obj->attpos);
            }
            if (ptr->LastVal != ptr->NowVal)
            {
                GuiSlider.ValueToTouchPos(obj, ptr, ID);
            }
            GuiSlider.DrawSliderBackGround(obj, ptr);
            ushort lastPos;
            ushort num;
            ushort num2;
            ushort lastPos2;
            GuiSlider.DrawSliderCursor(obj, ptr, &lastPos, &num, &num2, &lastPos2);
            if (ptr->Mode > 0)
            {
                ptr->LastPos = lastPos2;
            }
            else
            {
                ptr->LastPos = lastPos;
            }
            if (GuiSlider.myapp.upapp.runapptype == runapptype.run)
            {
                GuiSlider.myapp.pageobjs[ID].refFlag = 0;
            }
            return 1;
        }

        private unsafe static byte ChangeTouchValue(objxinxi* obj, SLIDER_PARAM* pSliRam, ushort val)
        {
            ushort nowVal = pSliRam->NowVal;
            if (pSliRam->Mode > 0)
            {
                byte b =Convert.ToByte(pSliRam->CursorHig / 2);
                byte b2 =(byte) (pSliRam->CursorHig / 2);
                if (val >= obj->redian.endy - (ushort)b)
                {
                    pSliRam->TouchPos =(ushort)(obj->redian.endy - (ushort)b);
                    pSliRam->NowVal = pSliRam->MinVal;
                }
                else if (val <= obj->redian.y + (ushort)b2 - 1)
                {
                    pSliRam->TouchPos = (ushort)(obj->redian.y + (ushort)b2 - 1);
                    pSliRam->NowVal = pSliRam->MaxVal;
                }
                else
                {
                    pSliRam->TouchPos = val;
                    pSliRam->NowVal = (ushort)((ulong)pSliRam->MinVal + (ulong)(obj->redian.endy - (ushort)b2 - val) * (ulong)((long)(pSliRam->MaxVal - pSliRam->MinVal + 1)) / (ulong)((long)(obj->redian.endy - obj->redian.y - (ushort)pSliRam->CursorHig + 1)));
                }
            }
            else
            {
                byte b = Convert.ToByte(pSliRam->CursorWid / 2);
                byte b2 = Convert.ToByte(pSliRam->CursorWid - b);
                if (val <= obj->redian.x + (ushort)b)
                {
                    pSliRam->TouchPos = (ushort)(obj->redian.x + (ushort)b);
                    pSliRam->NowVal = pSliRam->MinVal;
                }
                else if (val >= obj->redian.endx - (ushort)b2 + 1)
                {
                    pSliRam->TouchPos = (ushort)(obj->redian.endx - (ushort)b2 + 1);
                    pSliRam->NowVal = pSliRam->MaxVal;
                }
                else
                {
                    pSliRam->TouchPos = val;
                    pSliRam->NowVal = (ushort)((ulong)pSliRam->MinVal + (ulong)(val - obj->redian.x - (ushort)b) * (ulong)((long)(pSliRam->MaxVal - pSliRam->MinVal + 1)) / (ulong)((long)(obj->redian.endx - obj->redian.x - (ushort)pSliRam->CursorWid + 1)));
                }
            }
            if (pSliRam->NowVal > 100)
            {
                pSliRam->NowVal = pSliRam->NowVal;
            }
            byte result;
            if (nowVal != pSliRam->NowVal)
            {
                pSliRam->LastVal = pSliRam->NowVal;
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public unsafe static byte GuiSliderPressMove(objxinxi* obj, byte ID)
        {
            SLIDER_PARAM* ptr = (SLIDER_PARAM*)(GuiSlider.myapp.mymerry + obj->attpos);
            ushort touchPos = ptr->TouchPos;
            ushort val;
            if (ptr->Mode > 0)
            {
                val = GuiSlider.myapp.upapp.tp_dev.y_now;
            }
            else
            {
                val = GuiSlider.myapp.upapp.tp_dev.x_now;
            }
            byte result = GuiSlider.ChangeTouchValue(obj, ptr, val);
            if (touchPos != ptr->TouchPos)
            {
                GuiSlider.RefSliderCursor(obj, ID);
            }
            return result;
        }

        public unsafe static byte GuiSliderPressDown(objxinxi* obj, byte ID)
        {
            SLIDER_PARAM* ptr = (SLIDER_PARAM*)(GuiSlider.myapp.mymerry + obj->attpos);
            ushort touchPos = ptr->TouchPos;
            ushort val;
            if (ptr->Mode > 0)
            {
                val = GuiSlider.myapp.upapp.tp_dev.y_down;
            }
            else
            {
                val = GuiSlider.myapp.upapp.tp_dev.x_down;
            }
            GuiSlider.ChangeTouchValue(obj, ptr, val);
            if (touchPos != ptr->TouchPos)
            {
                GuiSlider.RefSliderCursor(obj, ID);
            }
            return 1;
        }

        public unsafe static byte GuiSliderPressUp(objxinxi* obj, byte ID)
        {
            return 1;
        }
    }
}
