using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct hexhead
    {
        public byte Count;

        public uint F030addr;

        public uint F030datalenth;

        public ushort headver;

        public uint res;

        public byte res2;
    }
}
