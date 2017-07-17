using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct attstrtype_64
    {
        public ulong name;

        public byte id;

        public byte res0;

        public byte res1;

        public byte res2;
    }
}
