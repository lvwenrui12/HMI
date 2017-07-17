using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PosLaction
    {
        public ushort star;

        public ushort end;
    }
}
