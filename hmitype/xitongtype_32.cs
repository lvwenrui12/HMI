using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct xitongtype_32
    {
        public uint name;

        public byte mark;

        public byte res0;

        public ushort res1;
    }
}
