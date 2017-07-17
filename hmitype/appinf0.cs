using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct appinf0
    {
        public byte old_lcddire;

        public byte banbenh;

        public byte banbenl;

        public byte mark;

        public uint oldgujianadd;

        public uint oldgujianqyt;

        public ushort old_screenw;

        public ushort old_screenh;

        public ushort lcdscreenw;

        public ushort lcdscreenh;

        public byte guidire;

        public byte xilie;

        public uint syscomadd;

        public uint syscomqyt;

        public uint driveradd;

        public uint driverqyt;

        public uint hexaddr;

        public uint hexlenth;

        public uint Modelcrc;

        public byte filever;

        public byte encodeh_star;

        public ushort res2;

        public uint res3;

        public ushort res4;

        public uint datasize;
    }
}
