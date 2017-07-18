using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FIRMWARE_TABLE
    {
        public ushort CPUID;

        public uint addr;

        public uint datalen;

        public ulong res;
    }
}
