using System;
using System.Text;

namespace hmitype
{
    public static class Strmake
    {
        private static byte[] u8tables = new byte[]
        {
            48,
            49,
            50,
            51,
            52,
            53,
            54,
            55,
            56,
            57
        };

        public unsafe static ushort Strmake_StrSubstring(ref byte[] buf, ref PosLaction bufpos, string val, byte starmod)
        {
            byte[] array = Kuozhan.Gethebingbytes(val.GetbytesssASCII(), "".GetbytesssASCII(1));
            ushort result;
            fixed (byte* ptr = buf)
            {
                fixed (PosLaction* ptr2 = &bufpos)
                {
                    fixed (byte* ptr3 = array)
                    {
                        result = Strmake.Strmake_StrSubstring(ptr, ptr2, ptr3, starmod);
                    }
                }
            }
            return result;
        }

        public unsafe static ushort Strmake_StrSubstring(byte* buf, ref PosLaction bufpos, string val, byte starmod)
        {
            byte[] array = Kuozhan.Gethebingbytes(val.GetbytesssASCII(), "".GetbytesssASCII(1));
            ushort result;
            fixed (PosLaction* ptr = &bufpos)
            {
                fixed (byte* ptr2 = array)
                {
                    result = Strmake.Strmake_StrSubstring(buf, ptr, ptr2, starmod);
                }
            }
            return result;
        }

        public unsafe static byte Strmake_StrGetcanshu(ref byte[] buf, ref PosLaction poscode, ref PosLaction[] cancode, byte canshuqyt)
        {
            byte result;
            fixed (byte* ptr = buf)
            {
                fixed (PosLaction* ptr2 = &poscode)
                {
                    fixed (PosLaction* ptr3 = cancode)
                    {
                        result = Strmake.Strmake_StrGetcanshu(ptr, ptr2, ptr3, canshuqyt);
                    }
                }
            }
            return result;
        }

        public unsafe static byte Strmake_StrGetcanshu(byte* buf, ref PosLaction poscode, ref PosLaction[] cancode, byte canshuqyt)
        {
            byte result;
            fixed (PosLaction* ptr = &poscode)
            {
                fixed (PosLaction* ptr2 = cancode)
                {
                    result = Strmake.Strmake_StrGetcanshu(buf, ptr, ptr2, canshuqyt);
                }
            }
            return result;
        }

        public unsafe static byte Strmake_Makestr(byte* v1, string str, byte lenth)
        {
            byte[] array = str.GetbytesssASCII();
            array = Kuozhan.Gethebingbytes(array, "".GetbytesssASCII(1));
            fixed (byte* ptr = array)
            {
                return Strmake.Strmake_Makestr(v1, ptr, lenth);
            }
        }

        public unsafe static string Strmake_BytesToStr16(byte[] bytes)
        {
            byte[] array = new byte[bytes.Length * 2];
            string @string;
            fixed (byte* ptr = bytes)
            {
                fixed (byte* ptr2 = array)
                {
                    Strmake.Strmake_BytesToStr16(ptr, ptr2, (byte)bytes.Length);
                    @string = Encoding.ASCII.GetString(array);
                }
            }
            return @string;
        }

        public unsafe static byte Strmake_Isyunsuanascii(byte* bt)
        {
            byte result;
            if (*bt == 43 || *bt == 45 || *bt == 42 || *bt == 47 || *bt == 37 || *bt == 124 || *bt == 38)
            {
                result = 1;
            }
            else if (*bt == 60 && bt[1] == 60)
            {
                result = 2;
            }
            else if (*bt == 62 && bt[1] == 62)
            {
                result = 2;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public static byte Strmake_IsAttendbyte(byte bt)
        {
            byte result;
            if (bt == 124)
            {
                result = 1;
            }
            else
            {
                if (bt > 32 && bt < 63)
                {
                    if (bt > 59)
                    {
                        result = 1;
                        return result;
                    }
                    if (bt == 43 || bt == 45 || bt == 42 || bt == 47 || bt == 37 || bt == 33 || bt == 38)
                    {
                        result = 1;
                        return result;
                    }
                }
                result = 0;
            }
            return result;
        }

        private unsafe static ushort Findfenge(byte* buf, PosLaction* bufPos)
        {
            ushort num = bufPos->star;
            byte b = 0;
            ushort result;
            while (num <= bufPos->end)
            {
                if (buf[num] < 9)
                {
                    num += 5;
                    if (num > bufPos->end)
                    {
                        result = 65535;
                        return result;
                    }
                }
                if (buf[num] != 44 || b != 0)
                {
                    if (buf[num] == 34)
                    {
                        if (num == bufPos->star)
                        {
                            b = 1;
                        }
                        else if (buf[num - 1] != 92)
                        {
                            if (b == 0)
                            {
                                b = 1;
                            }
                            else
                            {
                                b = 0;
                            }
                        }
                    }
                    num += 1;
                    continue;
                }
                result = num;
                return result;
            }
            result = 65535;
            return result;
        }

        public unsafe static ushort Strmake_StrSubstring(byte* buf, PosLaction* bufpos, byte* val, byte starmod)
        {
            ushort num = bufpos->star;
            ushort num2 = 0;
            ushort result;
            while (num <= bufpos->end)
            {
                if (buf[num] == val[num2])
                {
                    num2 += 1;
                    if (val[num2] == 0)
                    {
                        result = num;
                        return result;
                    }
                }
                else
                {
                    if (starmod == 0)
                    {
                        result = 65535;
                        return result;
                    }
                    num2 = 0;
                }
                num += 1;
            }
            result = 65535;
            return result;
        }

        public unsafe static byte Strmake_StrGetcanshu(byte* buf, PosLaction* poscode, PosLaction* cancode, byte canshuqyt)
        {
            ushort num = poscode->star;
            PosLaction posLaction;
            posLaction.end = poscode->end;
            byte result;
            if (canshuqyt == 0)
            {
                if (poscode->star > poscode->end)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                ushort num2 = 0;
                while (num2 < (ushort)canshuqyt)
                {
                    if (num > poscode->end)
                    {
                        result = 0;
                        return result;
                    }
                    posLaction.star = num;
                    cancode[num2].star = num;
                    num = Strmake.Findfenge(buf, &posLaction);
                    if (num == 65535)
                    {
                        if (num2 != (ushort)(canshuqyt - 1))
                        {
                            result = 0;
                            return result;
                        }
                        cancode[num2].end = poscode->end;
                        result = 1;
                        return result;
                    }
                    else
                    {
                        if (num == cancode[num2].star)
                        {
                            result = 0;
                            return result;
                        }
                        cancode[num2].end = num - 1;
                        num += 1;
                        num2 += 1;
                    }
                }
                result = 0;
            }
            return result;
        }

        public unsafe static byte Strmake_Makestr(byte* v1, byte* v2, byte lenth)
        {
            byte result;
            if (lenth == 0)
            {
                while (*v1 == *v2)
                {
                    if (*v1 == 0)
                    {
                        result = 1;
                        return result;
                    }
                    v1++;
                    v2++;
                }
                result = 0;
            }
            else
            {
                while (lenth > 0)
                {
                    if (*v1 != *v2)
                    {
                        result = 0;
                        return result;
                    }
                    v1++;
                    v2++;
                    lenth -= 1;
                }
                result = 1;
            }
            return result;
        }

        public unsafe static ushort Strmake_GetStrlen(byte* buf)
        {
            ushort num = 0;
            while (*buf != 0)
            {
                buf++;
                num += 1;
            }
            return num;
        }

        public unsafe static ushort Strmake_GetStrlen_Encode(byte* buf, byte encodeh_star)
        {
            byte b = 0;
            ushort num = 0;
            while (num < 255)
            {
                if (buf[b] == 0)
                {
                    break;
                }
                num += 1;
                if ((encodeh_star > 0 && buf[b] > encodeh_star) || buf[b] == 13)
                {
                    b += 1;
                }
                if (buf[b] == 0)
                {
                    break;
                }
                b += 1;
            }
            return num;
        }

        public unsafe static ushort Strmake_GetStrlen_Encode_Lenth(byte* buf, byte encodeh_star, byte lenth)
        {
            byte b = 0;
            ushort num = 0;
            ushort result;
            if (lenth < 1)
            {
                result = 0;
            }
            else
            {
                while (num < 255)
                {
                    if (buf[b] == 0)
                    {
                        break;
                    }
                    num += 1;
                    if ((encodeh_star > 0 && buf[b] > encodeh_star) || buf[b] == 13)
                    {
                        b += 1;
                    }
                    if (buf[b] == 0)
                    {
                        break;
                    }
                    b += 1;
                    if (num >= (ushort)lenth)
                    {
                        result = (ushort)b;
                        return result;
                    }
                }
                result = (ushort)b;
            }
            return result;
        }

        public static byte Strmake_GetS32strlen(int num)
        {
            byte result;
            if (num == -2147483648)
            {
                result = 10;
            }
            else
            {
                if (num < 0)
                {
                    num *= -1;
                }
                if (num >= 1000000000)
                {
                    result = 10;
                }
                else if (num >= 100000000)
                {
                    result = 9;
                }
                else if (num >= 10000000)
                {
                    result = 8;
                }
                else if (num >= 1000000)
                {
                    result = 7;
                }
                else if (num >= 100000)
                {
                    result = 6;
                }
                else if (num >= 10000)
                {
                    result = 5;
                }
                else if (num >= 1000)
                {
                    result = 4;
                }
                else if (num >= 100)
                {
                    result = 3;
                }
                else if (num >= 10)
                {
                    result = 2;
                }
                else
                {
                    result = 1;
                }
            }
            return result;
        }

        public unsafe static void Strmake_S32ToStr(int num, byte* buf, byte lenth, byte isend)
        {
            byte b = Strmake.Strmake_GetS32strlen(num);
            if (lenth == 0)
            {
                lenth = b;
            }
            if (num == -2147483648)
            {
                *buf = 45;
                buf++;
                byte[] array = "2147483648".GetbytesssASCII();
                fixed (byte* ptr = array)
                {
                    Kuozhan.memcpy(buf, ptr, (int)lenth);
                }
                if (isend == 1)
                {
                    buf[lenth] = 0;
                }
            }
            else
            {
                if (num < 0)
                {
                    num *= -1;
                    *buf = 45;
                    buf++;
                }
                byte b2;
                if (b > lenth)
                {
                    b2 = b - lenth;
                    for (int i = 1; i <= (int)b2; i++)
                    {
                        num /= 10;
                    }
                    b2 += 1;
                }
                else
                {
                    b = lenth;
                    b2 = 1;
                }
                for (int i = (int)b2; i <= (int)b; i++)
                {
                    if (num == 0)
                    {
                        buf[(int)b - i] = Strmake.u8tables[0];
                    }
                    else
                    {
                        buf[(int)b - i] = Strmake.u8tables[num % 10];
                    }
                    num /= 10;
                }
                if (isend == 1)
                {
                    buf[lenth] = 0;
                }
            }
        }

        public unsafe static int Strmake_StrToS32(byte* bt1, byte lenth)
        {
            int num = 0;
            int num2 = 1;
            int result;
            if (*bt1 == 45)
            {
                num2 = -1;
                bt1++;
                if (lenth > 0)
                {
                    lenth -= 1;
                    if (lenth == 0)
                    {
                        result = 0;
                        return result;
                    }
                }
            }
            if (lenth == 0)
            {
                lenth = 10;
            }
            while (*bt1 > 47 && *bt1 < 58 && lenth > 0)
            {
                num *= 10;
                num += (int)(*bt1 - 48);
                bt1++;
                lenth -= 1;
            }
            result = num * num2;
            return result;
        }

        public unsafe static void Strmake_BytesToStr16(byte* str, byte* buf, byte len)
        {
            int num = 0;
            for (int i = 0; i < (int)len; i++)
            {
                int num2 = (int)str[i];
                int num3 = num2 / 16;
                int num4 = num2 % 16;
                if (num3 < 10)
                {
                    buf[num] = (byte)(num3 + 48);
                }
                else
                {
                    buf[num] = (byte)(65 + num3 - 10);
                }
                num++;
                if (num4 < 10)
                {
                    buf[num] = (byte)(num4 + 48);
                }
                else
                {
                    buf[num] = (byte)(65 + num4 - 10);
                }
                num++;
            }
        }

        public unsafe static void Strmake_Str16ToBytes(byte* str, byte* buf, byte len)
        {
            int num = 0;
            for (int i = 0; i < (int)len; i += 2)
            {
                int num2 = (int)str[i];
                if (num2 > 70)
                {
                    num2 -= 32;
                }
                int num3;
                if (num2 < 58)
                {
                    num3 = num2 - 48;
                }
                else
                {
                    num3 = num2 - 65 + 10;
                }
                num2 = (int)str[i + 1];
                if (num2 > 70)
                {
                    num2 -= 32;
                }
                int num4;
                if (num2 < 58)
                {
                    num4 = num2 - 48;
                }
                else
                {
                    num4 = num2 - 65 + 10;
                }
                buf[num] = (byte)(num3 * 16 + num4);
                num++;
            }
        }
    }
}
