using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct comtype_64
    {
        public ulong name;

        public byte comindex;

        public byte canqyt;

        public byte canlei;

        public byte res;
    }
}
