using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct zimoxinxi
    {
        public byte codelT0;

        public byte codelV0;

        public byte qumo;

        public byte encode;

        public byte state;

        public byte w;

        public byte h;

        public byte codeh_star;

        public byte codeh_end;

        public byte codel_star;

        public byte codel_end;

        public uint qyt;

        public byte ver;

        public byte ascstar;

        public ushort datastar;

        public uint size;

        public uint addbeg;
    }
}
