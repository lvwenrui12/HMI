using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CURVE_PARAM
    {
        public byte RefFlag;

        public byte BackType;

        public byte GridX;

        public byte GridY;

        public byte CH_qyt;

        public ushort PicID;

        public ushort objWid;

        public ushort objHig;

        public ushort Bkclr;

        public ushort Griclr;

        public byte DrawDir;

        public byte res0;
    }
}
