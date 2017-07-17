using System;

namespace hmitype
{
    public struct tp_devinf
    {
        public ushort x_now;

        public ushort y_now;

        public ushort x_down;

        public ushort y_down;

        public byte touchstate;

        public uint touchtime;
    }
}
