using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CURVE_CHANNEL_PARAM
    {
        public PosLaction BufPos;

        public ushort Penclr;

        public ushort res0;

        public ushort BufNext;

        public ushort DotLen;
    }
}
