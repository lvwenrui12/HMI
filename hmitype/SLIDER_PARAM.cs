using System;
using System.Runtime.InteropServices;

namespace hmitype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SLIDER_PARAM
    {
        public byte RefFlag;

        public byte Mode;

        public byte BackType;

        public byte CursorType;

        public byte CursorWid;

        public byte CursorHig;

        public ushort BkPicID;

        public ushort CuPicID;

        public ushort NowVal;

        public ushort MaxVal;

        public ushort MinVal;

        public ushort LastPos;

        public ushort TouchPos;

        public ushort LastVal;
    }
}
