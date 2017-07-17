using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct bytes_14
    {
        public uint a;

        public uint b;

        public uint c;

        public ushort d;
    }
}
