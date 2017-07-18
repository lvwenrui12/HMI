using System;
using System.Windows.Forms;

namespace hmitype
{
    public static class Showfont
    {
        public static myappinf myapp;

        private unsafe static uint Findziadd(byte h, byte l, ref zimoxinxi mzimo)
        {
            uint result;
            fixed (zimoxinxi* ptr = &mzimo)
            {
                result = Showfont.Findziadd(h, l, ptr);
            }
            return result;
        }

        private unsafe static uint Findziadd(byte h, byte l, zimoxinxi* mzimo)
        {
            byte[] array = new byte[2];
            ushort num = (ushort)((int)h * 256 + (int)l);
            uint num2 = 0u;
            uint num3 = (uint)((ushort)(mzimo->qyt - 1u));
            uint num4 = mzimo->addbeg + Showfont.myapp.app.zimodataadd + (uint)mzimo->ascstar;
            uint result;
            while (num3 >= num2)
            {
                uint num5 = (num3 + num2) / 2u;
                uint add = num4 + num5 * 2u;
                Readdata.SPI_Flash_Read(ref array, add, 2u);
                if (array[0] == h && array[1] == l)
                {
                    result = mzimo->addbeg + Showfont.myapp.app.zimodataadd + (uint)mzimo->datastar + num5 * (uint)mzimo->w * (uint)mzimo->h / 8u;
                }
                else
                {
                    if (num3 != num2)
                    {
                        if ((ushort)array[0] * 256 + (ushort)array[1] > num)
                        {
                            num3 = num5 - 1u;
                        }
                        else
                        {
                            num2 = num5 + 1u;
                        }
                        continue;
                    }
                    result = 0u;
                }
                return result;
            }
            result = mzimo->addbeg + Showfont.myapp.app.zimodataadd + (uint)mzimo->datastar;
            return result;
        }

        private static void SendZiku(int x, int y, byte h, byte l)
        {
            byte[] array = new byte[2];
            int num = x;
            int num2 = y;
            byte b = 0;
            if (Showfont.myapp.brush.pw != 0)
            {
                h = 0;
                l = Showfont.myapp.brush.pw;
            }
            uint num3 = Showfont.myapp.brush.mzimo.addbeg + Showfont.myapp.app.zimodataadd + (uint)Showfont.myapp.brush.mzimo.datastar;
            if (Showfont.myapp.brush.mzimo.state == 1)
            {
                if (h != 0)
                {
                    if (l > Showfont.myapp.brush.mzimo.codelT0)
                    {
                        l -= Showfont.myapp.brush.mzimo.codelV0;
                    }
                    b = Showfont.myapp.brush.mzimo.w;
                    num3 += (uint)(((h - Showfont.myapp.brush.mzimo.codeh_star) * (Showfont.myapp.brush.mzimo.codel_end - Showfont.myapp.brush.mzimo.codel_star - Showfont.myapp.brush.mzimo.codelV0 + 1) + (l - Showfont.myapp.brush.mzimo.codel_star)) * (Showfont.myapp.brush.mzimo.w / 8) * Showfont.myapp.brush.mzimo.h);
                }
                else
                {
                    b = Convert.ToByte(Showfont.myapp.brush.mzimo.w / 2);
                    num3 += (uint)((ulong)(Showfont.myapp.brush.mzimo.qyt - 95u + (uint)l - 32u) * (ulong)((long)(Showfont.myapp.brush.mzimo.w / 8)) * (ulong)Showfont.myapp.brush.mzimo.h);
                }
            }
            else if (Showfont.myapp.brush.mzimo.state == 0)
            {
                b = Showfont.myapp.brush.mzimo.w;
                num3 += (uint)((l - 32) * (Showfont.myapp.brush.mzimo.h / 8 * Showfont.myapp.brush.mzimo.w));
            }
            else if (Showfont.myapp.brush.mzimo.state == 2)
            {
                if (h > 0)
                {
                    b = Showfont.myapp.brush.mzimo.w;
                }
                else
                {
                    b =Convert.ToByte(Showfont.myapp.brush.mzimo.w / 2);
                }
                num3 = Showfont.Findziadd(h, l, ref Showfont.myapp.brush.mzimo);
            }
            ushort num4 = (ushort)(Showfont.myapp.brush.mzimo.h / 8 * b);
            switch (Showfont.myapp.upapp.lcddev.guidire)
            {
                case 1:
                    y = (int)((ushort)(num2 + (int)Showfont.myapp.brush.mzimo.h - 1));
                    break;
                case 2:
                    x = (int)((ushort)(num + (int)b - 1));
                    y = (int)((ushort)(num2 + (int)Showfont.myapp.brush.mzimo.h - 1));
                    break;
                case 3:
                    x = (int)((ushort)(num + (int)b - 1));
                    break;
            }
            for (uint num5 = 0u; num5 < (uint)num4; num5 += 1u)
            {
                Readdata.SPI_Flash_Read(ref array, num3 + num5, 1u);
                for (byte b2 = 0; b2 < 8; b2 += 1)
                {
                    if (((int)array[0] & 1 << (int)(7 - b2)) > 0)
                    {
                        if (x >= (int)Showfont.myapp.brush.x && x <= (int)Showfont.myapp.brush.endx && y >= (int)Showfont.myapp.brush.y && y <= (int)Showfont.myapp.brush.endy)
                        {
                            Lcd.Lcd_DrawPoint(x, y, Showfont.myapp.brush.pointcolor);
                        }
                    }
                    switch (Showfont.myapp.upapp.lcddev.guidire)
                    {
                        case 0:
                            x++;
                            if (x - num == (int)b)
                            {
                                x = num;
                                y++;
                            }
                            break;
                        case 1:
                            y--;
                            if (y < num2)
                            {
                                y = (int)((ushort)(num2 + (int)Showfont.myapp.brush.mzimo.h - 1));
                                x++;
                            }
                            break;
                        case 2:
                            x--;
                            if (x < num)
                            {
                                x = (int)((ushort)(num + (int)b - 1));
                                y--;
                            }
                            break;
                        case 3:
                            y++;
                            if (y >= num2 + (int)Showfont.myapp.brush.mzimo.h)
                            {
                                y = num2;
                                x--;
                            }
                            break;
                    }
                }
            }
        }

        public unsafe static byte Showfont_XstringHZK(int x, int y, int w, int h, byte* buf)
        {
            size_tyte size_tyte = default(size_tyte);
            int num = (int)Showfont.myapp.brush.x;
            int num2 = (int)Showfont.myapp.brush.y;
            byte result;
            if (buf == 0)
            {
                MessageBox.Show("error");
                result = 0;
            }
            else
            {
                try
                {
                    if ((ushort)Showfont.myapp.brush.zikuid >= Showfont.myapp.app.zimoqyt)
                    {
                        if (*buf != 0)
                        {
                            Showfont.myapp.errcode = 5;
                            result = 0;
                            return result;
                        }
                        if (Showfont.myapp.brush.sta < 10)
                        {
                            myappinf expr_AA_cp_0 = Showfont.myapp;
                            expr_AA_cp_0.brush.sta = expr_AA_cp_0.brush.sta + 10;
                        }
                    }
                    if (Showfont.myapp.brush.endx >= Showfont.myapp.upapp.lcddev.width)
                    {
                        Showfont.myapp.brush.endx = Showfont.myapp.upapp.lcddev.width - 1;
                    }
                    if (Showfont.myapp.brush.endy >= Showfont.myapp.upapp.lcddev.height)
                    {
                        Showfont.myapp.brush.endy = Showfont.myapp.upapp.lcddev.height - 1;
                    }
                    if (Showfont.myapp.brush.sta < 10)
                    {
                        myappinf expr_199_cp_0 = Showfont.myapp;
                        expr_199_cp_0.brush.sta = expr_199_cp_0.brush.sta + 10;
                    }
                    if (Showfont.myapp.brush.sta == 0 || Showfont.myapp.brush.sta == 2 || Showfont.myapp.brush.sta == 10 || Showfont.myapp.brush.sta == 12)
                    {
                        if (Showfont.myapp.brush.backcolor >= Showfont.myapp.app.picqyt)
                        {
                            Showfont.myapp.errcode = 4;
                            result = 0;
                            return result;
                        }
                    }
                    if (*buf == 0)
                    {
                        if (Showfont.myapp.brush.sta < 10)
                        {
                            myappinf expr_26F_cp_0 = Showfont.myapp;
                            expr_26F_cp_0.brush.sta = expr_26F_cp_0.brush.sta + 10;
                        }
                    }
                    if (Showfont.myapp.brush.sta > 9)
                    {
                        if (Showfont.myapp.brush.sta == 11)
                        {
                            Lcd.Lcd_Fill(num, num2, (int)((ushort)((int)Showfont.myapp.brush.endx - num + 1)), (int)((ushort)((int)Showfont.myapp.brush.endy - num2 + 1)), Showfont.myapp.brush.backcolor);
                        }
                        else if (Showfont.myapp.brush.sta == 10)
                        {
                            Showpic.Showpic_ShowXpic(num, num2, (ushort)((int)Showfont.myapp.brush.endx - num + 1), (ushort)((int)Showfont.myapp.brush.endy - num2 + 1), num, num2, Showfont.myapp.brush.backcolor);
                        }
                        else if (Showfont.myapp.brush.sta == 12)
                        {
                            Showpic.Showpic_ShowPic(num, num2, Showfont.myapp.brush.backcolor);
                        }
                        if (*buf == 0)
                        {
                            result = 1;
                            return result;
                        }
                        Showfont.myapp.brush.sta = 3;
                    }
                    if (w == 32767)
                    {
                        Showfont.myapp.brush.brendx = (short)Showfont.myapp.brush.endx;
                        Showfont.myapp.brush.brendy = (short)Showfont.myapp.brush.endy;
                        Showfont.Showfont_StringHZK((int)Showfont.myapp.brush.x, (int)Showfont.myapp.brush.y, buf, 0, ref size_tyte);
                    }
                    else
                    {
                        size_tyte.a = (ushort)w;
                        size_tyte.b = (ushort)h;
                    }
                    if (x == 32767)
                    {
                        if (Showfont.myapp.brush.xjuzhong > 0)
                        {
                            int num3 = (int)(Showfont.myapp.brush.endx - Showfont.myapp.brush.x + 1 - size_tyte.a);
                            if (num3 > 1)
                            {
                                if (Showfont.myapp.brush.xjuzhong == 1)
                                {
                                    num += (int)((ushort)(num3 / 2));
                                }
                                else
                                {
                                    num += num3;
                                }
                            }
                        }
                    }
                    else
                    {
                        num = x;
                    }
                    if (y == 32767)
                    {
                        if (Showfont.myapp.brush.yjuzhong > 0)
                        {
                            int num3 = (int)(Showfont.myapp.brush.endy - Showfont.myapp.brush.y + 1 - size_tyte.b);
                            if (num3 > 1)
                            {
                                if (Showfont.myapp.brush.yjuzhong == 1)
                                {
                                    num2 += (int)((ushort)(num3 / 2));
                                }
                                else
                                {
                                    num2 += num3;
                                }
                            }
                        }
                    }
                    else
                    {
                        num2 = y;
                    }
                    if (w != 32767)
                    {
                        Showfont.myapp.brush.brendx = (short)(num + w);
                        Showfont.myapp.brush.brendy = (short)(num2 + h);
                    }
                    Showfont.Showfont_StringHZK(num, num2, buf, 1, ref size_tyte);
                }
                catch (Exception ex)
                {
                    MessageOpen.Show("Showfont_StringHZK is error!" + ex.Message);
                }
                result = 1;
            }
            return result;
        }

        public unsafe static byte Showfont_StringHZK(int x, int y, byte* buf, byte mod, ref size_tyte size)
        {
            int num = x;
            int num2 = 1;
            int num3 = 0;
            size.a = 0;
            size.b = 0;
            byte result;
            while (*buf > 0)
            {
                while (*buf == 13 && buf[1] == 10)
                {
                    x = num;
                    y += (int)((ushort)(Showfont.myapp.brush.mzimo.h + Showfont.myapp.brush.hangjuy));
                    if (y > (int)Showfont.myapp.brush.brendy)
                    {
                        if (mod == 1)
                        {
                            result = 1;
                            return result;
                        }
                    }
                    num2++;
                    buf += 2;
                }
                if (*buf != 0)
                {
                    byte b;
                    byte h;
                    if (Showfont.myapp.brush.mzimo.codeh_star == 0 || Showfont.myapp.brush.pw != 0 || *buf <= 126)
                    {
                        b = Showfont.myapp.brush.mzimo.h / 2;
                        h = 0;
                    }
                    else
                    {
                        b = Showfont.myapp.brush.mzimo.w;
                        h = *buf;
                        buf++;
                        if (*buf == 0)
                        {
                            result = 1;
                            return result;
                        }
                    }
                    byte l = *buf;
                    if (Showfont.myapp.brush.isbr == 1)
                    {
                        if (x + (int)b - 1 > (int)Showfont.myapp.brush.brendx)
                        {
                            x = num;
                            y += (int)((ushort)(Showfont.myapp.brush.mzimo.h + Showfont.myapp.brush.hangjuy));
                            if (y > (int)Showfont.myapp.brush.brendy)
                            {
                                if (mod == 1)
                                {
                                    result = 1;
                                    return result;
                                }
                            }
                            num2++;
                        }
                    }
                    if (num2 > 0)
                    {
                        size.b += (ushort)(num2 * (int)(Showfont.myapp.brush.hangjuy + Showfont.myapp.brush.mzimo.h));
                        num2 = 0;
                    }
                    if (num3 < x + (int)b)
                    {
                        num3 = x + (int)b;
                        size.a = (ushort)(num3 - num);
                    }
                    if (mod == 1 && x <= (int)Showfont.myapp.brush.endx && y <= (int)Showfont.myapp.brush.endy)
                    {
                        Showfont.SendZiku(x, y, h, l);
                    }
                    buf++;
                    x += (int)((ushort)(b + Showfont.myapp.brush.hangjux));
                    continue;
                }
                result = 1;
                return result;
            }
            result = 1;
            return result;
        }
    }
}
