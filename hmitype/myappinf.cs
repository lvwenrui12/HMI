using System;

namespace hmitype
{
    public class myappinf
    {
        public upappinf upapp = new upappinf();

        public unsafe PosLaction* Mycanshus;

        public ushort[] hishexs = new ushort[8];

        public ushort dpage;

        public ushort dpagemerrypos;

        public pagexinxi dpagexinxi;

        public ushort ovemerrys;

        public appinf1 app;

        public brushxinxi brush;

        public ushort Hexstrindex;

        public UsartUpdatainf USART;

        public uint FlashClearadd;

        public byte touchsendxy;

        public byte sendfanhui;

        public unsafe pageobjs_* pageobjs;

        public byte downobjid;

        public byte moveobjstate;

        public ushort delay;

        public unsafe byte* mymerry;

        public int[] myxitong = new int[5];

        public byte paus;

        public byte comcrc;

        public uint pagenameseradd;

        public uint dobjnameseradd;

        public byte pagestate;

        public byte binsuc;

        public byte errcode;

        public sysinf sys;

        public unsafe byte* systimerbuf;

        public timeinf systime;

        public byte dra;

        public ushort dracolor;

        public ushort tpdownenter;

        public ushort tpupenter;

        public int SysRandMax = 2147483647;

        public int SysRandMin = 0;

        public byte delaystate = 1;

        public byte runmod;

        public byte encodeh_star;
    }
}
