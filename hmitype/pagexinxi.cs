using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct pagexinxi
    {
        public ushort objstar;

        public byte objqyt;

        public ushort zhilingstar;

        public ushort zhilingqyt;

        public uint attdatapos;
    }
}
