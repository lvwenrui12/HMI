using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct redianinf
    {
        public ushort x;

        public ushort y;

        public ushort endx;

        public ushort endy;

        public byte res0;

        public byte sendkey;

        public eventtyte events;
    }
}
