using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct attinf
    {
        public ushort pos;

        public ushort merrylenth;

        public byte state;

        public byte pageid;

        public byte objid;

        public int maxval;

        public int minval;

        public byte encodeh_star;
    }
}
