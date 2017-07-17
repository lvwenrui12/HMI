using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct gujianinf
    {
        public uint typecrc;

        public ushort ver;

        public uint size;

        public uint crc;

        public byte pass;

        public ushort cpuid;

        public ushort lowver;

        public uint res1;

        public uint res2;

        public uint res3;
    }
}
