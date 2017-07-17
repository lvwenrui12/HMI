using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct systimer_type
    {
        public byte id;

        public ushort hexbufindex;

        public ushort val;
    }
}
