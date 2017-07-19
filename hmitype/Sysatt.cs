using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    public static class Sysatt
    {
        public static myappinf myapp;

        public static xitongtype_32[] xitong32;

        public static xitongtype_64[] xitong64;

        public static uint xitong32qyt = 0u;

        public static uint xitong64qyt = 0u;

        public static void initstsatt()
        {
            Sysatt.xitong32 = new xitongtype_32[]
            {
                new xitongtype_32
                {
                    name = "dp\0\0".strtoU32(),
                    mark = 22,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "RED\0".strtoU32(),
                    mark = 200,
                    res0 = 0,
                    res1 = 63488
                },
                new xitongtype_32
                {
                    name = "thc\0".strtoU32(),
                    mark = 16,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "dim\0".strtoU32(),
                    mark = 7,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "wup\0".strtoU32(),
                    mark = 23,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "sya0".strtoU32(),
                    mark = 3,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "rtc0".strtoU32(),
                    mark = 210,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio0".strtoU32(),
                    mark = 220,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "sys0".strtoU32(),
                    mark = 0,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "sya1".strtoU32(),
                    mark = 4,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "rtc1".strtoU32(),
                    mark = 211,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio1".strtoU32(),
                    mark = 221,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "sys1".strtoU32(),
                    mark = 1,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "rtc2".strtoU32(),
                    mark = 212,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio2".strtoU32(),
                    mark = 222,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "sys2".strtoU32(),
                    mark = 2,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "rtc3".strtoU32(),
                    mark = 213,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio3".strtoU32(),
                    mark = 223,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "rtc4".strtoU32(),
                    mark = 214,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pwm4".strtoU32(),
                    mark = 240,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio4".strtoU32(),
                    mark = 224,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "rtc5".strtoU32(),
                    mark = 215,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pwm5".strtoU32(),
                    mark = 241,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio5".strtoU32(),
                    mark = 225,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "rtc6".strtoU32(),
                    mark = 216,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pwm6".strtoU32(),
                    mark = 242,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio6".strtoU32(),
                    mark = 226,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pwm7".strtoU32(),
                    mark = 243,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pio7".strtoU32(),
                    mark = 227,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "BLUE".strtoU32(),
                    mark = 200,
                    res0 = 0,
                    res1 = 31
                },
                new xitongtype_32
                {
                    name = "GRAY".strtoU32(),
                    mark = 200,
                    res0 = 0,
                    res1 = 33840
                },
                new xitongtype_32
                {
                    name = "rand".strtoU32(),
                    mark = 19,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "baud".strtoU32(),
                    mark = 5,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "crcf".strtoU32(),
                    mark = 20,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "pwmf".strtoU32(),
                    mark = 244,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "thsp".strtoU32(),
                    mark = 13,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "ussp".strtoU32(),
                    mark = 12,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "thup".strtoU32(),
                    mark = 14,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "dims".strtoU32(),
                    mark = 8,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "spax".strtoU32(),
                    mark = 10,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_32
                {
                    name = "spay".strtoU32(),
                    mark = 11,
                    res0 = 0,
                    res1 = 0
                }
            };
            Sysatt.xitong64 = new xitongtype_64[]
            {
                new xitongtype_64
                {
                    name = "WHITE\0\0\0".strtoU64(),
                    mark = 200,
                    res0 = 0,
                    res1 = 65535
                },
                new xitongtype_64
                {
                    name = "BLACK\0\0\0".strtoU64(),
                    mark = 200,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_64
                {
                    name = "GREEN\0\0\0".strtoU64(),
                    mark = 200,
                    res0 = 0,
                    res1 = 2016
                },
                new xitongtype_64
                {
                    name = "BROWN\0\0\0".strtoU64(),
                    mark = 200,
                    res0 = 0,
                    res1 = 48192
                },
                new xitongtype_64
                {
                    name = "thdra\0\0\0".strtoU64(),
                    mark = 17,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_64
                {
                    name = "bkcmd\0\0\0".strtoU64(),
                    mark = 9,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_64
                {
                    name = "sleep\0\0\0".strtoU64(),
                    mark = 18,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_64
                {
                    name = "bauds\0\0\0".strtoU64(),
                    mark = 6,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_64
                {
                    name = "delay\0\0\0".strtoU64(),
                    mark = 120,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_64
                {
                    name = "YELLOW\0\0".strtoU64(),
                    mark = 200,
                    res0 = 0,
                    res1 = 65504
                },
                new xitongtype_64
                {
                    name = "runmod\0\0".strtoU64(),
                    mark = 21,
                    res0 = 0,
                    res1 = 0
                },
                new xitongtype_64
                {
                    name = "sendxy\0\0".strtoU64(),
                    mark = 15,
                    res0 = 0,
                    res1 = 0
                }
            };
            Sysatt.xitong32qyt = (uint)((byte)Sysatt.xitong32.Length);
            Sysatt.xitong64qyt = (uint)((byte)Sysatt.xitong64.Length);
        }

        public unsafe static void Sysatt_GetSysname(byte* name, byte lenth, runattinf* att)
        {
            if (lenth < 5)
            {
                uint num = 0u;
                Kuozhan.memcpy((byte*)(&num), name, (int)lenth);
                fixed (void* ptr = (&Sysatt.xitong32[0]))
                {
                    num = Datafind.Datafind_FindU32_Memory(&num, (uint*)ptr, Sysatt.xitong32qyt, (uint)(Marshal.SizeOf(default(xitongtype_32)) / 4));
                }
                if (num != 65535u)
                {
                    Sysatt.Sysatt_GetXitongval(4, (byte)num, att);
                }
            }
            else if (lenth < 9)
            {
                ulong num2 = 0uL;
                Kuozhan.memcpy((byte*)(&num2), name, (int)lenth);
                uint num;
                fixed (void* ptr = (&Sysatt.xitong64[0]))
                {
                    num = Datafind.Datafind_FindU64_Memory(&num2, (uint*)ptr, Sysatt.xitong64qyt, (uint)(Marshal.SizeOf(default(xitongtype_64)) / 4));
                }
                if (num != 65535u)
                {
                    Sysatt.Sysatt_GetXitongval(8, (byte)num, att);
                }
            }
        }

        public static byte Sysatt_SetXitongval(byte index, int val)
        {
            byte result;
            if (index <= 4)
            {
                Sysatt.myapp.myxitong[(int)index] = val;
            }
            else
            {
                if (index >= 210 && index <= 216)
                {
                    result = Rtc.Rtc_SetTime((int)(index - 210), val);
                    return result;
                }
                if (index >= 220 && index <= 227)
                {
                    result = 1;
                    return result;
                }
                if (index >= 240 && index <= 243)
                {
                    result = 1;
                    return result;
                }
                if (index == 200)
                {
                    result = 0;
                    return result;
                }
                switch (index)
                {
                    case 5:
                        result = 1;
                        return result;
                    case 6:
                        result = 1;
                        return result;
                    case 7:
                        if (val > 100)
                        {
                            result = 0;
                            return result;
                        }
                        result = 1;
                        return result;
                    case 8:
                        if (val > 100)
                        {
                            result = 0;
                            return result;
                        }
                        result = 1;
                        return result;
                    case 9:
                        if (val > 3)
                        {
                            result = 0;
                            return result;
                        }
                        Sysatt.myapp.sendfanhui = (byte)val;
                        break;
                    case 10:
                        Sysatt.myapp.brush.hangjux = (byte)val;
                        break;
                    case 11:
                        Sysatt.myapp.brush.hangjuy = (byte)val;
                        break;
                    case 12:
                        Sysatt.myapp.sys.ussp = val * 1000;
                        if (Sysatt.myapp.sys.ussp > 0 && Sysatt.myapp.sys.ussp < 3000)
                        {
                            Sysatt.myapp.sys.ussp = 3000;
                        }
                        Sysatt.myapp.systime.sptime = Sysatt.myapp.systime.systemruntime;
                        break;
                    case 13:
                        Sysatt.myapp.sys.thsp = val * 1000;
                        if (Sysatt.myapp.sys.thsp > 0 && Sysatt.myapp.sys.thsp < 3000)
                        {
                            Sysatt.myapp.sys.thsp = 3000;
                        }
                        Sysatt.myapp.systime.sptime = Sysatt.myapp.systime.systemruntime;
                        break;
                    case 14:
                        Sysatt.myapp.sys.thsleepup = (byte)val;
                        break;
                    case 15:
                        Sysatt.myapp.touchsendxy = (byte)val;
                        break;
                    case 16:
                        Sysatt.myapp.dracolor = (ushort)((byte)val);
                        break;
                    case 17:
                        if (val > 1)
                        {
                            result = 0;
                            return result;
                        }
                        Sysatt.myapp.dra = (byte)val;
                        break;
                    case 18:
                        result = 1;
                        return result;
                    case 19:
                        result = 0;
                        return result;
                    case 20:
                        if (val > 0)
                        {
                            Sysatt.myapp.comcrc = 1;
                        }
                        else
                        {
                            Sysatt.myapp.comcrc = 0;
                        }
                        result = 1;
                        return result;
                    case 21:
                        if (val >= 0 && val < 3)
                        {
                            Sysatt.myapp.runmod = (byte)val;
                        }
                        result = 1;
                        return result;
                    case 22:
                        if (val >= (int)Sysatt.myapp.app.pageqyt)
                        {
                            result = 0;
                            return result;
                        }
                        Hmi.Hmi_RefPage((ushort)val);
                        result = 1;
                        return result;
                    case 23:
                        if ((val >= 0 && val < (int)Sysatt.myapp.app.pageqyt) || val == 255)
                        {
                            Sysatt.myapp.upapp.lcddev.wup = (byte)val;
                            result = 1;
                            return result;
                        }
                        Sysatt.myapp.errcode = 3;
                        result = 0;
                        return result;
                    default:
                        if (index == 120)
                        {
                            if (Sysatt.myapp.delay != 0 || Hmi.Hmi_GuiObjectRef() == 0)
                            {
                                Sys.delay_ms((ushort)val);
                            }
                            else
                            {
                                Sysatt.myapp.delay = (ushort)val;
                            }
                            if (Sysatt.myapp.upapp.Lcdshouxian > 0)
                            {
                                Sysatt.myapp.upapp.ScreenRef(0);
                            }
                            result = 1;
                            return result;
                        }
                        if (index != 244)
                        {
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

        public unsafe static byte Sysatt_GetXitongval(byte lei, byte id, runattinf* att)
        {
            int val = 0;
            byte mark;
            byte* ptr2;
            if (lei == 4)
            {
                fixed (byte* ptr = &Sysatt.xitong32[(int)id].res0)
                {
                    mark = Sysatt.xitong32[(int)id].mark;
                    ptr2 = ptr;
                    att->datafrom = Sysatt.xitong32[(int)id].mark;
                }
            }
            else
            {
                fixed (byte* ptr = &Sysatt.xitong64[(int)id].res0)
                {
                    mark = Sysatt.xitong64[(int)id].mark;
                    ptr2 = ptr;
                    att->datafrom = Sysatt.xitong64[(int)id].mark;
                }
            }
            att->attlei = attshulei.SS32.typevalue;
            att->att.merrylenth = 4;
            att->att.maxval = 2147483647;
            att->att.minval = -2147483647;
            att->isxiugai = 1;
            byte result;
            if (mark <= 4)
            {
                val = Sysatt.myapp.myxitong[(int)mark];
            }
            else if (mark >= 210 && mark <= 216)
            {
                if (Rtc.Rtc_GetTime((int)(mark - 210), &val) == 255)
                {
                    result = 0;
                    return result;
                }
            }
            else if (mark < 220 || mark > 227)
            {
                if (mark < 240 || mark > 243)
                {
                    if (mark == 200)
                    {
                        val = (int)(*(ushort*)(ptr2 + 1));
                    }
                    else
                    {
                        byte b = mark;
                        switch (b)
                        {
                            case 5:
                                val = (int)Sysatt.myapp.USART.UsartBo;
                                break;
                            case 6:
                                val = 9600;
                                break;
                            case 7:
                                val = 100;
                                break;
                            case 8:
                                val = 100;
                                break;
                            case 9:
                                val = (int)Sysatt.myapp.sendfanhui;
                                break;
                            case 10:
                                val = (int)Sysatt.myapp.brush.hangjux;
                                break;
                            case 11:
                                val = (int)Sysatt.myapp.brush.hangjuy;
                                break;
                            case 12:
                                val = Sysatt.myapp.sys.ussp / 1000;
                                break;
                            case 13:
                                val = Sysatt.myapp.sys.thsp / 1000;
                                break;
                            case 14:
                                val = (int)Sysatt.myapp.sys.thsleepup;
                                break;
                            case 15:
                                val = (int)Sysatt.myapp.touchsendxy;
                                break;
                            case 16:
                                val = (int)Sysatt.myapp.dracolor;
                                break;
                            case 17:
                                val = (int)Sysatt.myapp.dra;
                                break;
                            case 18:
                                break;
                            case 19:
                                val = Sys.rand(Sysatt.myapp.SysRandMin, Sysatt.myapp.SysRandMax);
                                break;
                            case 20:
                                if (Sysatt.myapp.comcrc > 0)
                                {
                                    val = 1;
                                }
                                else
                                {
                                    val = 0;
                                }
                                break;
                            case 21:
                                val = (int)Sysatt.myapp.runmod;
                                break;
                            case 22:
                                val = (int)Sysatt.myapp.dpage;
                                break;
                            case 23:
                                val = (int)Sysatt.myapp.upapp.lcddev.wup;
                                break;
                            default:
                                if (b != 120)
                                {
                                    if (b != 244)
                                    {
                                        att->datafrom = 255;
                                        result = 0;
                                        return result;
                                    }
                                }
                                else
                                {
                                    val = 0;
                                }
                                break;
                        }
                    }
                }
            }
            att->val = val;
            result = 1;
            return result;
        }
    }
}
