using System;

namespace hmitype
{
    public static class guidatamake
    {
        public const byte guicomcan_u32 = 0;

        public const byte guicomcan_backatt1 = 1;

        public const byte guicomcan_backatt2 = 2;

        public const byte guicomcan_backatt3 = 3;

        public const byte guicomcan_backu32obj1 = 11;

        public const byte guicomcan_backu32obj2 = 12;

        public const byte guicomcan_backu32obj3 = 13;

        public const byte guicomcan_backu32page1 = 21;

        public const byte guicomcan_backu32page2 = 22;

        public const byte guicomcan_backu32page3 = 23;

        public const byte guicomcan_fatt1 = 101;

        public const byte guicomcan_fatt2 = 102;

        public const byte guicomcan_fatt3 = 103;

        public const byte guicomcan_fu32obj1 = 111;

        public const byte guicomcan_fu32obj2 = 112;

        public const byte guicomcan_fu32obj3 = 113;

        public const byte guicomcan_fu32page1 = 121;

        public const byte guicomcan_fu32page2 = 122;

        public const byte guicomcan_fu32page3 = 123;

        public const byte guicomcan_null = 255;

        public const byte comindex_c1com = 0;

        public const byte comindex_xstr = 1;

        public const byte comindex_eepr = 2;

        public const byte comindex_gpio = 3;

        public const byte comindex_sys = 4;

        public const byte comindex_chuchang = 5;

        public const byte comindex_input = 6;

        public const byte datafrom_xitong_sys0 = 0;

        public const byte datafrom_xitong_sys1 = 1;

        public const byte datafrom_xitong_sys2 = 2;

        public const byte datafrom_xitong_sya0 = 3;

        public const byte datafrom_xitong_sya1 = 4;

        public const byte datafrom_xitong_baud = 5;

        public const byte datafrom_xitong_bauds = 6;

        public const byte datafrom_xitong_bl = 7;

        public const byte datafrom_xitong_intbl = 8;

        public const byte datafrom_xitong_bkcmd = 9;

        public const byte datafrom_xitong_spax = 10;

        public const byte datafrom_xitong_spay = 11;

        public const byte datafrom_xitong_ussp = 12;

        public const byte datafrom_xitong_thsp = 13;

        public const byte datafrom_xitong_thup = 14;

        public const byte datafrom_xitong_sendxy = 15;

        public const byte datafrom_xitong_thc = 16;

        public const byte datafrom_xitong_thdra = 17;

        public const byte datafrom_xitong_sleep = 18;

        public const byte datafrom_xitong_rand = 19;

        public const byte datafrom_xitong_crcf = 20;

        public const byte datafrom_xitong_runmod = 21;

        public const byte datafrom_xitong_dp = 22;

        public const byte datafrom_xitong_wup = 23;

        public const byte datafrom_xitong_delay = 120;

        public const byte datafrom_xitong_x = 200;

        public const byte datafrom_rtc0 = 210;

        public const byte datafrom_rtc1 = 211;

        public const byte datafrom_rtc2 = 212;

        public const byte datafrom_rtc3 = 213;

        public const byte datafrom_rtc4 = 214;

        public const byte datafrom_rtc5 = 215;

        public const byte datafrom_rtc6 = 216;

        public const byte datafrom_pio0 = 220;

        public const byte datafrom_pio1 = 221;

        public const byte datafrom_pio2 = 222;

        public const byte datafrom_pio3 = 223;

        public const byte datafrom_pio4 = 224;

        public const byte datafrom_pio5 = 225;

        public const byte datafrom_pio6 = 226;

        public const byte datafrom_pio7 = 227;

        public const byte datafrom_pwm0 = 236;

        public const byte datafrom_pwm1 = 237;

        public const byte datafrom_pwm2 = 238;

        public const byte datafrom_pwm3 = 239;

        public const byte datafrom_pwm4 = 240;

        public const byte datafrom_pwm5 = 241;

        public const byte datafrom_pwm6 = 242;

        public const byte datafrom_pwm7 = 243;

        public const byte datafrom_pwmf = 244;

        public const byte datafrom_null = 255;

        public const byte datafrom_memory = 254;

        public const byte datafrom_buf = 253;

        public const byte datafrom_flash = 252;

        public static ulong[][] xiliepaichucom64 = new ulong[3][];

        public static uint[][] xiliepaichucom32 = new uint[3][];

        public static ulong[][] xiliepaichuxitong64 = new ulong[3][];

        public static uint[][] xiliepaichuxitong32 = new uint[3][];

        public static void GuidataAppinit()
        {
            Sysatt.initstsatt();
            CodeRun.Cominit();
            Attmake.attinit();
            guidatamake.xiliepaichucom64[0] = new ulong[]
            {
                "cfgpio\0\0".strtoU64()
            };
            guidatamake.xiliepaichucom32[0] = new uint[]
            {
                "repo".strtoU32(),
                "wepo".strtoU32(),
                "rept".strtoU32(),
                "wept".strtoU32()
            };
            guidatamake.xiliepaichuxitong32[0] = new uint[]
            {
                "rtc0".strtoU32(),
                "rtc1".strtoU32(),
                "rtc2".strtoU32(),
                "rtc3".strtoU32(),
                "rtc4".strtoU32(),
                "rtc5".strtoU32(),
                "pio0".strtoU32(),
                "pio1".strtoU32(),
                "pio2".strtoU32(),
                "pio3".strtoU32(),
                "pio4".strtoU32(),
                "pio5".strtoU32(),
                "rtc6".strtoU32(),
                "pio6".strtoU32(),
                "pio7".strtoU32(),
                "pwm4".strtoU32(),
                "pwm5".strtoU32(),
                "pwm6".strtoU32(),
                "pwm7".strtoU32(),
                "pwmf".strtoU32()
            };
        }

        public static uint strtoU32(this string str)
        {
            return (uint)str.GetbytesssASCII(4).BytesTostruct(0u.GetType());
        }

        public static ulong strtoU64(this string str)
        {
            return (ulong)str.GetbytesssASCII(8).BytesTostruct(0uL.GetType());
        }
    }
}
