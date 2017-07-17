using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct pagexinxi_up
    {
        public bytes_14 name;

        public byte pagelei;

        public byte objqyt;

        public ushort objstar;

        public byte pagelock;

        public uint password;

        public byte rese;
    }
}
