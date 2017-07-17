using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace hmitype
{
    public class upappinf
    {
        public pageidchange_ pageidchange;

        public Sendruncodestr_ Sendruncodestr;

        public ScreenRef_ ScreenRef;

        public Lcd_Set_ Lcd_Set;

        public SendCom_ SendCom;

        public StreamReader filesr;

        public List<guiimagetype> images = new List<guiimagetype>();

        public byte runapptype;

        public byte runstate;

        public byte Lcdshouxian;

        public bool havetouming = false;

        public Bitmap Screenbm;

        public lcddevxinxi lcddev;

        public tp_devinf tp_dev;

        public int SendRuncodeTime;

        public screenxinxi Myscr;

        public Point mouse_pos;
    }
}
