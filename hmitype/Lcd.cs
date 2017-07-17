using System;
using System.Drawing;

namespace hmitype
{
    public static class Lcd
    {
        public static myappinf myapp;

        public static void Lcd_DrawPoint(int x, int y, ushort color)
        {
            try
            {
                if (x > -1 && y > -1 && x < (int)Lcd.myapp.upapp.lcddev.width && y < (int)Lcd.myapp.upapp.lcddev.height)
                {
                    lock (Lcd.myapp.upapp.Screenbm)
                    {
                        Lcd.myapp.upapp.Screenbm.SetPixel(x, y, color.Get24color());
                        Lcd.myapp.upapp.Lcdshouxian = 1;
                    }
                }
            }
            catch
            {
            }
        }

        public static void LCD_addset(int Xpos, int Ypos, int XEnd, int YEnd, byte isend)
        {
            Lcd.myapp.upapp.Myscr.Xpos = Xpos;
            Lcd.myapp.upapp.Myscr.Ypos = Ypos;
            Lcd.myapp.upapp.Myscr.Endx = XEnd;
            Lcd.myapp.upapp.Myscr.Endy = YEnd;
            switch (Lcd.myapp.upapp.lcddev.guidire)
            {
                case 0:
                    Lcd.myapp.upapp.Myscr.DX = Lcd.myapp.upapp.Myscr.Xpos;
                    Lcd.myapp.upapp.Myscr.DY = Lcd.myapp.upapp.Myscr.Ypos;
                    break;
                case 1:
                    Lcd.myapp.upapp.Myscr.DX = Lcd.myapp.upapp.Myscr.Xpos;
                    Lcd.myapp.upapp.Myscr.DY = Lcd.myapp.upapp.Myscr.Endy;
                    break;
                case 2:
                    Lcd.myapp.upapp.Myscr.DX = Lcd.myapp.upapp.Myscr.Endx;
                    Lcd.myapp.upapp.Myscr.DY = Lcd.myapp.upapp.Myscr.Endy;
                    break;
                case 3:
                    Lcd.myapp.upapp.Myscr.DX = Lcd.myapp.upapp.Myscr.Endx;
                    Lcd.myapp.upapp.Myscr.DY = Lcd.myapp.upapp.Myscr.Ypos;
                    break;
            }
        }

        public static void Lcd_SendColorData(ushort c)
        {
            try
            {
                if (Lcd.myapp.upapp.Myscr.DY <= Lcd.myapp.upapp.Myscr.Endy && Lcd.myapp.upapp.Myscr.DX <= Lcd.myapp.upapp.Myscr.Endx)
                {
                    if (c != datasize.Color_touming)
                    {
                        lock (Lcd.myapp.upapp.Screenbm)
                        {
                            Lcd.myapp.upapp.Screenbm.SetPixel(Lcd.myapp.upapp.Myscr.DX, Lcd.myapp.upapp.Myscr.DY, c.Get24color());
                            Lcd.myapp.upapp.Lcdshouxian = 1;
                        }
                    }
                    else if (!datasize.Opentouming)
                    {
                        lock (Lcd.myapp.upapp.Screenbm)
                        {
                            Lcd.myapp.upapp.Screenbm.SetPixel(Lcd.myapp.upapp.Myscr.DX, Lcd.myapp.upapp.Myscr.DY, datasize.Color_toumingtihuan.Get24color());
                            Lcd.myapp.upapp.Lcdshouxian = 1;
                        }
                    }
                    else
                    {
                        Lcd.myapp.upapp.havetouming = true;
                    }
                    switch (Lcd.myapp.upapp.lcddev.guidire)
                    {
                        case 0:
                            {
                                upappinf expr_1C6_cp_0 = Lcd.myapp.upapp;
                                expr_1C6_cp_0.Myscr.DX = expr_1C6_cp_0.Myscr.DX + 1;
                                if (Lcd.myapp.upapp.Myscr.DX > Lcd.myapp.upapp.Myscr.Endx)
                                {
                                    Lcd.myapp.upapp.Myscr.DX = Lcd.myapp.upapp.Myscr.Xpos;
                                    upappinf expr_23C_cp_0 = Lcd.myapp.upapp;
                                    expr_23C_cp_0.Myscr.DY = expr_23C_cp_0.Myscr.DY + 1;
                                }
                                break;
                            }
                        case 1:
                            {
                                upappinf expr_25E_cp_0 = Lcd.myapp.upapp;
                                expr_25E_cp_0.Myscr.DY = expr_25E_cp_0.Myscr.DY - 1;
                                if (Lcd.myapp.upapp.Myscr.DY < Lcd.myapp.upapp.Myscr.Ypos)
                                {
                                    Lcd.myapp.upapp.Myscr.DY = Lcd.myapp.upapp.Myscr.Endy;
                                    upappinf expr_2D4_cp_0 = Lcd.myapp.upapp;
                                    expr_2D4_cp_0.Myscr.DX = expr_2D4_cp_0.Myscr.DX + 1;
                                }
                                break;
                            }
                        case 2:
                            {
                                upappinf expr_2F6_cp_0 = Lcd.myapp.upapp;
                                expr_2F6_cp_0.Myscr.DX = expr_2F6_cp_0.Myscr.DX - 1;
                                if (Lcd.myapp.upapp.Myscr.DX < Lcd.myapp.upapp.Myscr.Xpos)
                                {
                                    Lcd.myapp.upapp.Myscr.DX = Lcd.myapp.upapp.Myscr.Endx;
                                    upappinf expr_36C_cp_0 = Lcd.myapp.upapp;
                                    expr_36C_cp_0.Myscr.DY = expr_36C_cp_0.Myscr.DY - 1;
                                }
                                break;
                            }
                        case 3:
                            {
                                upappinf expr_38E_cp_0 = Lcd.myapp.upapp;
                                expr_38E_cp_0.Myscr.DY = expr_38E_cp_0.Myscr.DY + 1;
                                if (Lcd.myapp.upapp.Myscr.DY > Lcd.myapp.upapp.Myscr.Endy)
                                {
                                    Lcd.myapp.upapp.Myscr.DY = Lcd.myapp.upapp.Myscr.Ypos;
                                    upappinf expr_404_cp_0 = Lcd.myapp.upapp;
                                    expr_404_cp_0.Myscr.DX = expr_404_cp_0.Myscr.DX - 1;
                                }
                                break;
                            }
                    }
                }
            }
            catch
            {
            }
        }

        public static void Lcd_SendFill(ushort color, int qyt)
        {
            for (int i = 0; i < qyt; i++)
            {
                Lcd.Lcd_SendColorData(color);
            }
        }

        public static void Lcd_WR_POINT(uint qyt, ushort color)
        {
            for (uint num = 0u; num < qyt; num += 1u)
            {
                Lcd.Lcd_SendColorData(color);
            }
        }

        public static void Lcd_DrawLine(int x1, int y1, int x2, int y2, ushort color, byte cu)
        {
            int num = 0;
            int num2 = 0;
            int num3 = x2 - x1;
            int num4 = y2 - y1;
            int num5 = x1;
            int num6 = y1;
            int num7;
            if (num3 > 0)
            {
                num7 = 1;
            }
            else if (num3 == 0)
            {
                num7 = 0;
            }
            else
            {
                num7 = -1;
                num3 = -num3;
            }
            int num8;
            if (num4 > 0)
            {
                num8 = 1;
            }
            else if (num4 == 0)
            {
                num8 = 0;
            }
            else
            {
                num8 = -1;
                num4 = -num4;
            }
            int num9;
            if (num3 > num4)
            {
                num9 = num3;
            }
            else
            {
                num9 = num4;
            }
            ushort num10 = 0;
            while ((int)num10 <= num9 + 1)
            {
                if (cu == 1)
                {
                    Lcd.Lcd_DrawPoint((int)((ushort)num5), (int)((ushort)num6), color);
                }
                else
                {
                    Lcd.Lcd_Fill((int)((ushort)num5), (int)((ushort)num6), (int)cu, (int)cu, color);
                }
                num += num3;
                num2 += num4;
                if (num > num9)
                {
                    num -= num9;
                    num5 += num7;
                }
                if (num2 > num9)
                {
                    num2 -= num9;
                    num6 += num8;
                }
                num10 += 1;
            }
        }

        public static void Lcd_Draw_h(ushort x0, ushort y0, ushort r, ushort jiao, byte cu, ushort color)
        {
            double num = (double)r;
            double num2 = 3.141592653 * (double)jiao / 180.0;
            double num3 = num * Math.Cos(num2);
            double num4 = num * Math.Sin(num2);
            Lcd.Lcd_DrawLine((int)((ushort)((double)x0 - num3)), (int)((ushort)((double)y0 - num4)), (int)x0, (int)y0, color, cu);
        }

        public static void Lcd_Draw_Circles(ushort x0, ushort y0, ushort r, ushort color)
        {
            if (r <= x0 && r <= y0 && y0 + r <= Lcd.myapp.upapp.lcddev.height && x0 + r <= Lcd.myapp.upapp.lcddev.width)
            {
                int i = 0;
                int num = (int)r;
                int num2 = 3 - ((int)r << 1);
                while (i <= num)
                {
                    uint qyt = (uint)(i * 2 + 1);
                    Lcd.LCD_addset((int)((ushort)((int)x0 - num)), (int)((ushort)((int)y0 - i)), (int)((ushort)((int)x0 - num)), (int)((ushort)((int)y0 + i)), 1);
                    Lcd.Lcd_WR_POINT(qyt, color);
                    Lcd.LCD_addset((int)((ushort)((int)x0 + num)), (int)((ushort)((int)y0 - i)), (int)((ushort)((int)x0 + num)), (int)((ushort)((int)y0 + i)), 1);
                    Lcd.Lcd_WR_POINT(qyt, color);
                    qyt = (uint)(num * 2 + 1);
                    Lcd.LCD_addset((int)((ushort)((int)x0 - i)), (int)((ushort)((int)y0 - num)), (int)((ushort)((int)x0 - i)), (int)((ushort)((int)y0 + num)), 1);
                    Lcd.Lcd_WR_POINT(qyt, color);
                    Lcd.LCD_addset((int)((ushort)((int)x0 + i)), (int)((ushort)((int)y0 - num)), (int)((ushort)((int)x0 + i)), (int)((ushort)((int)y0 + num)), 1);
                    Lcd.Lcd_WR_POINT(qyt, color);
                    i++;
                    if (num2 < 0)
                    {
                        num2 += 4 * i + 6;
                    }
                    else
                    {
                        num2 += 10 + 4 * (i - num);
                        num--;
                    }
                }
            }
        }

        public static void Lcd_Draw_Circle(ushort x0, ushort y0, ushort r, ushort color)
        {
            if (r <= x0 && r <= y0 && y0 + r <= Lcd.myapp.upapp.lcddev.height && x0 + r <= Lcd.myapp.upapp.lcddev.width)
            {
                int i = 0;
                int num = (int)r;
                int num2 = 3 - ((int)r << 1);
                while (i <= num)
                {
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 + i)), (int)((ushort)((int)y0 - num)), color);
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 + num)), (int)((ushort)((int)y0 - i)), color);
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 + num)), (int)((ushort)((int)y0 + i)), color);
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 + i)), (int)((ushort)((int)y0 + num)), color);
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 - i)), (int)((ushort)((int)y0 + num)), color);
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 - num)), (int)((ushort)((int)y0 + i)), color);
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 - i)), (int)((ushort)((int)y0 - num)), color);
                    Lcd.Lcd_DrawPoint((int)((ushort)((int)x0 - num)), (int)((ushort)((int)y0 - i)), color);
                    i++;
                    if (num2 < 0)
                    {
                        num2 += 4 * i + 6;
                    }
                    else
                    {
                        num2 += 10 + 4 * (i - num);
                        num--;
                    }
                }
            }
        }

        public static void Lcd_DrawRectangle3D(ushort x1, ushort y1, ushort x2, ushort y2, ushort color1, ushort color2, byte wid)
        {
            Lcd.Lcd_Fill((int)x1, (int)y1, (int)(x2 - x1 + 1), (int)wid, color1);
            Lcd.Lcd_Fill((int)x1, (int)(y2 - (ushort)wid + 1), (int)(x2 - x1 + 1), (int)wid, color2);
            Lcd.Lcd_Fill((int)x1, (int)y1, (int)wid, (int)(y2 - y1 + 1), color1);
            Lcd.Lcd_Fill((int)(x2 - (ushort)wid + 1), (int)y1, (int)wid, (int)(y2 - y1 + 1), color2);
        }

        public static void Lcd_DrawRectangle(ushort x1, ushort y1, ushort x2, ushort y2, ushort color, byte wid)
        {
            Lcd.Lcd_DrawRectangle3D(x1, y1, x2, y2, color, color, wid);
        }

        public static void Lcd_Fill(int sx, int sy, int w, int h, ushort color)
        {
            try
            {
                lock (Lcd.myapp.upapp.Screenbm)
                {
                    Graphics.FromImage(Lcd.myapp.upapp.Screenbm).FillRectangle(new SolidBrush(color.Get24color()), sx, sy, w, h);
                    Lcd.myapp.upapp.Lcdshouxian = 1;
                }
            }
            catch
            {
            }
        }

        public static void Lcd_Clear(ushort color)
        {
            try
            {
                lock (Lcd.myapp.upapp.Screenbm)
                {
                    Graphics.FromImage(Lcd.myapp.upapp.Screenbm).Clear(color.Get24color());
                    Lcd.myapp.upapp.Lcdshouxian = 1;
                }
            }
            catch
            {
            }
        }
    }
}
