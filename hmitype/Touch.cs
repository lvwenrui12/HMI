using System;
using System.Windows.Forms;

namespace hmitype
{
    public static class Touch
    {
        public static myappinf myapp;

        public static void TP_REST()
        {
            Touch.myapp.upapp.tp_dev.touchstate = 0;
            Touch.myapp.systime.touchdowntime = 0u;
            Touch.myapp.tpupenter = 0;
            Touch.myapp.tpdownenter = 0;
        }

        public unsafe static void Touch_Tpscan()
        {
            if (Touch.myapp.upapp.tp_dev.touchstate == 1)
            {
                Touch.myapp.upapp.tp_dev.x_now = (ushort)(Control.MousePosition.X - Touch.myapp.upapp.mouse_pos.X + (int)Touch.myapp.upapp.tp_dev.x_down);
                Touch.myapp.upapp.tp_dev.y_now = (ushort)(Control.MousePosition.Y - Touch.myapp.upapp.mouse_pos.Y + (int)Touch.myapp.upapp.tp_dev.y_down);
                if (Touch.myapp.dra == 1)
                {
                    Lcd.Lcd_Fill((int)Touch.myapp.upapp.tp_dev.x_now, (int)Touch.myapp.upapp.tp_dev.y_now, 2, 2, Touch.myapp.dracolor);
                }
                if (Touch.myapp.Hexstrindex == 65535 && Touch.myapp.moveobjstate > 0 && Touch.myapp.systime.movetime > 20u)
                {
                    objxinxi objxinxi = default(objxinxi);
                    Readdata.Readdata_ReadObj(ref objxinxi, (int)((ushort)Touch.myapp.downobjid + Touch.myapp.dpagexinxi.objstar));
                    if (GuiSlider.GuiSliderPressMove(&objxinxi, Touch.myapp.downobjid) > 0)
                    {
                        if (objxinxi.redian.events.Slide != 0 && Touch.myapp.Hexstrindex == 65535)
                        {
                            Touch.myapp.Hexstrindex = (ushort)(objxinxi.redian.events.Slide + objxinxi.zhilingstar);
                        }
                    }
                    Touch.myapp.systime.movetime = 0u;
                }
            }
        }
    }
}
