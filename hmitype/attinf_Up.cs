using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct attinf_Up
    {
        public ushort merrylenth;

        public ushort zhanyonglenth;

        public byte attlei;

        public byte datafrom;

        public ushort pos;

        public byte isbangding;

        public byte isxiugai;

        public byte chonghui;

        public int maxval;

        public int minval;

        public byte vis;
    }
}
