using System;

namespace hmitype
{
    public static class Rtc
    {
        public static TimeSpan DatetimeSpan;

        public static bool DatetimeSpan_val = false;

        public unsafe static byte Rtc_GetTime(int index, int* val)
        {
            DateTime now = DateTime.Now;
            switch (index)
            {
                case 0:
                    if (!Rtc.DatetimeSpan_val)
                    {
                        *val = now.Year;
                    }
                    else
                    {
                        *val = now.Subtract(Rtc.DatetimeSpan).Year;
                    }
                    break;
                case 1:
                    if (!Rtc.DatetimeSpan_val)
                    {
                        *val = now.Month;
                    }
                    else
                    {
                        *val = now.Subtract(Rtc.DatetimeSpan).Month;
                    }
                    break;
                case 2:
                    if (!Rtc.DatetimeSpan_val)
                    {
                        *val = now.Day;
                    }
                    else
                    {
                        *val = now.Subtract(Rtc.DatetimeSpan).Day;
                    }
                    break;
                case 3:
                    if (!Rtc.DatetimeSpan_val)
                    {
                        *val = now.Hour;
                    }
                    else
                    {
                        *val = now.Subtract(Rtc.DatetimeSpan).Hour;
                    }
                    break;
                case 4:
                    if (!Rtc.DatetimeSpan_val)
                    {
                        *val = now.Minute;
                    }
                    else
                    {
                        *val = now.Subtract(Rtc.DatetimeSpan).Minute;
                    }
                    break;
                case 5:
                    if (!Rtc.DatetimeSpan_val)
                    {
                        *val = now.Second;
                    }
                    else
                    {
                        *val = now.Subtract(Rtc.DatetimeSpan).Second;
                    }
                    break;
                case 6:
                    {
                        ushort y = (ushort)now.Subtract(Rtc.DatetimeSpan).Year;
                        ushort m = (ushort)now.Subtract(Rtc.DatetimeSpan).Month;
                        ushort d = (ushort)now.Subtract(Rtc.DatetimeSpan).Day;
                        *val = (int)Rtc.Rtc_ProcessWeek(y, m, d);
                        break;
                    }
            }
            return 1;
        }

        public static byte Rtc_ProcessWeek(ushort y, ushort m, ushort d)
        {
            if (m < 3)
            {
                y -= 1;
                m += 12;
            }
            return (byte)((d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400 + 1) % 7);
        }

        public static byte Rtc_SetTime(int index, int val)
        {
            byte result;
            if (index > 5)
            {
                result = 0;
            }
            else
            {
                try
                {
                    DateTime value = DateTime.Now;
                    if (Rtc.DatetimeSpan_val)
                    {
                        value = DateTime.Now.Subtract(Rtc.DatetimeSpan);
                    }
                    switch (index)
                    {
                        case 0:
                            value = DateTime.Parse(string.Concat(new string[]
                            {
                            val.ToString(),
                            "-",
                            value.Month.ToString(),
                            "-",
                            value.Day.ToString(),
                            " ",
                            value.Hour.ToString(),
                            ":",
                            value.Minute.ToString(),
                            ":",
                            value.Second.ToString()
                            }));
                            break;
                        case 1:
                            value = DateTime.Parse(string.Concat(new string[]
                            {
                            value.Year.ToString(),
                            "-",
                            val.ToString(),
                            "-",
                            value.Day.ToString(),
                            " ",
                            value.Hour.ToString(),
                            ":",
                            value.Minute.ToString(),
                            ":",
                            value.Second.ToString()
                            }));
                            break;
                        case 2:
                            value = DateTime.Parse(string.Concat(new string[]
                            {
                            value.Year.ToString(),
                            "-",
                            value.Month.ToString(),
                            "-",
                            val.ToString(),
                            " ",
                            value.Hour.ToString(),
                            ":",
                            value.Minute.ToString(),
                            ":",
                            value.Second.ToString()
                            }));
                            break;
                        case 3:
                            value = DateTime.Parse(string.Concat(new string[]
                            {
                            value.Year.ToString(),
                            "-",
                            value.Month.ToString(),
                            "-",
                            value.Day.ToString(),
                            " ",
                            val.ToString(),
                            ":",
                            value.Minute.ToString(),
                            ":",
                            value.Second.ToString()
                            }));
                            break;
                        case 4:
                            value = DateTime.Parse(string.Concat(new string[]
                            {
                            value.Year.ToString(),
                            "-",
                            value.Month.ToString(),
                            "-",
                            value.Day.ToString(),
                            " ",
                            value.Hour.ToString(),
                            ":",
                            val.ToString(),
                            ":",
                            value.Second.ToString()
                            }));
                            break;
                        case 5:
                            value = DateTime.Parse(string.Concat(new string[]
                            {
                            value.Year.ToString(),
                            "-",
                            value.Month.ToString(),
                            "-",
                            value.Day.ToString(),
                            " ",
                            value.Hour.ToString(),
                            ":",
                            value.Minute.ToString(),
                            ":",
                            val.ToString()
                            }));
                            break;
                    }
                    Rtc.DatetimeSpan = DateTime.Now.Subtract(value);
                    if (Rtc.DatetimeSpan.Days == 0 && Rtc.DatetimeSpan.Hours == 0 && Rtc.DatetimeSpan.Minutes == 0 && Rtc.DatetimeSpan.Seconds == 0)
                    {
                        Rtc.DatetimeSpan_val = false;
                    }
                    else
                    {
                        Rtc.DatetimeSpan_val = true;
                    }
                }
                catch
                {
                    result = 0;
                    return result;
                }
                result = 1;
            }
            return result;
        }
    }
}
