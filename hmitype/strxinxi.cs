using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct strxinxi
    {
        public uint addbeg;

        public ushort size;
    }
}
