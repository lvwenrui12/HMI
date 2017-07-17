using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct pageobjs_
    {
        public byte vis;

        public byte touchstate;

        public byte refFlag;
    }
}
