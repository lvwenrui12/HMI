using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct eventtyte
    {
        public ushort Ref;

        public ushort Vis;

        public ushort Load;

        public ushort Loadend;

        public ushort Down;

        public ushort Res0;

        public ushort Up;

        public ushort Slide;
    }
}
