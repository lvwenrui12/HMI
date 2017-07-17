using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct appinf1
    {
        public uint picdataadd;

        public uint zimodataadd;

        public uint strdataadd;

        public ushort pageqyt;

        public ushort objqyt;

        public ushort picqyt;

        public ushort zimoqyt;

        public uint strqyt;

        public uint pageadd;

        public uint objadd;

        public uint picxinxiadd;

        public uint zimoxinxiadd;

        public uint strxinxiadd;

        public byte encode;

        public uint staticstringbeg;

        public uint attdatapos;

        public uint inputpos;

        public ushort inputqyts;

        public ushort inputdatasize;
    }
}
