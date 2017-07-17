using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Picturexinxi
    {
        public byte qumo;

        public ushort pictureid;

        public ushort name;

        public uint addbeg;

        public ushort W;

        public ushort H;

        public uint imgbytesize;

        public uint imgxuliebeg;

        public byte res0;

        public byte res1;
    }
}
