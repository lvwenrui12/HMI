using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct runattinf
    {
        public unsafe byte* Pz;

        public int val;

        public attinf att;

        public byte attlei;

        public byte datafrom;

        public byte isref;

        public byte isxiugai;
    }
}
