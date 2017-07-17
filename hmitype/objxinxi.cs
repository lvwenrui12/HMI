using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct objxinxi
    {
        public bytes_14 name;

        public byte objType;

        public byte merry;

        public ushort attpos;

        public ushort attposqyt;

        public redianinf redian;

        public ushort zhilingstar;

        public ushort zhilingend;
    }
}
