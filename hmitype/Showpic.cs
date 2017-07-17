using System;
using System.Drawing;

namespace hmitype
{
    public static class Showpic
    {
        public static myappinf myapp;

        public unsafe static byte Showpic_Picq(int x, int y, ushort w, ushort h, int x2, int y2, ref Picturexinxi mpicture)
        {
            byte result;
            fixed (Picturexinxi* ptr = &mpicture)
            {
                result = Showpic.Showpic_ShowXpic_M(x, y, w, h, x2, y2, ptr);
            }
            return result;
        }

        public static byte Showpic_ShowPic(int x, int y, ushort picindex)
        {
            byte result;
            try
            {
                if (picindex >= Showpic.myapp.app.picqyt)
                {
                    if (picindex == 65535)
                    {
                        result = 1;
                        return result;
                    }
                    Showpic.myapp.errcode = 4;
                    result = 0;
                    return result;
                }
                else if ((int)picindex < Showpic.myapp.upapp.images.Count)
                {
                    lock (Showpic.myapp.upapp.Screenbm)
                    {
                        Graphics.FromImage(Showpic.myapp.upapp.Screenbm).DrawImage(Showpic.myapp.upapp.images[(int)picindex].imagebitbmp, new Point(x, y));
                        Showpic.myapp.upapp.Lcdshouxian = 1;
                    }
                }
                else
                {
                    MessageOpen.Show("Images is Error!" + Showpic.myapp.upapp.images.Count.ToString());
                }
            }
            catch
            {
            }
            result = 1;
            return result;
        }

        public unsafe static byte Showpic_ShowXpic(int x, int y, ushort w, ushort h, int x2, int y2, ushort picindex)
        {
            Picturexinxi picturexinxi = default(Picturexinxi);
            byte result;
            if (picindex >= Showpic.myapp.app.picqyt)
            {
                if (picindex == 65535)
                {
                    result = 1;
                }
                else
                {
                    Showpic.myapp.errcode = 4;
                    result = 0;
                }
            }
            else
            {
                Readdata.Readdata_ReadPic(ref picturexinxi, (int)picindex);
                result = Showpic.Showpic_ShowXpic_M(x, y, w, h, x2, y2, &picturexinxi);
            }
            return result;
        }

        public unsafe static byte Showpic_ShowXpic_M(int x, int y, ushort w, ushort h, int x2, int y2, Picturexinxi* mpicture)
        {
            try
            {
                if ((int)mpicture->pictureid < Showpic.myapp.upapp.images.Count)
                {
                    lock (Showpic.myapp.upapp.Screenbm)
                    {
                        Graphics.FromImage(Showpic.myapp.upapp.Screenbm).DrawImage(Showpic.myapp.upapp.images[(int)mpicture->pictureid].imagebitbmp, new Rectangle(x, y, (int)w, (int)h), new Rectangle(x2, y2, (int)w, (int)h), GraphicsUnit.Pixel);
                        Showpic.myapp.upapp.Lcdshouxian = 1;
                    }
                }
                else
                {
                    MessageOpen.Show("Images is Error!" + Showpic.myapp.upapp.images.Count.ToString());
                }
            }
            catch
            {
            }
            return 1;
        }

        public static void Showpic_Clearspa(int x, int y, int w, int h)
        {
            if (Showpic.myapp.brush.sta == 1)
            {
                Lcd.Lcd_Fill(x, y, w, h, Showpic.myapp.brush.backcolor);
            }
            else if (Showpic.myapp.brush.sta == 0)
            {
                Showpic.Showpic_Picq(x, y, (ushort)w, (ushort)h, x, y, ref Showpic.myapp.brush.pic);
            }
            else if (Showpic.myapp.brush.sta == 2)
            {
                Showpic.Showpic_Picq(x, y, (ushort)w, (ushort)h, (int)((ushort)(x - (int)Showpic.myapp.brush.x)), (int)((ushort)(y - (int)Showpic.myapp.brush.y)), ref Showpic.myapp.brush.pic);
            }
        }

        public static void Showpic_SendData(uint address, uint qyt)
        {
            Showpic.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)address);
            byte[] array = new byte[2];
            int num = 0;
            while ((long)num < (long)((ulong)qyt))
            {
                Showpic.myapp.upapp.filesr.BaseStream.Read(array, 0, 2);
                ushort num2 = (ushort)array[1];
                num2 *= 256;
                num2 += (ushort)array[0];
                Lcd.Lcd_SendColorData(num2);
                num++;
            }
        }

        public static void Showpic_SendDataOffset(uint address, ushort offset, ushort WinH, byte WinW)
        {
            uint num = address;
            for (int i = 0; i < (int)WinH; i++)
            {
                Showpic.Showpic_SendData(num, (uint)WinW);
                num += (uint)offset;
            }
        }
    }
}
