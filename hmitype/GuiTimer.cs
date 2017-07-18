using System;

namespace hmitype
{
    public static class GuiTimer
    {
        public static myappinf myapp;

        public unsafe static void timerm_5ms(uint tt)
        {
            try
            {
                myappinf expr_0C_cp_0 = GuiTimer.myapp;
                expr_0C_cp_0.systime.systemruntime = expr_0C_cp_0.systime.systemruntime + tt;
                myappinf expr_23_cp_0 = GuiTimer.myapp;
                expr_23_cp_0.systime.movetime = expr_23_cp_0.systime.movetime + tt;
                myappinf expr_3A_cp_0 = GuiTimer.myapp;
                expr_3A_cp_0.systime.guitime_20 = expr_3A_cp_0.systime.guitime_20 + tt;
                if (GuiTimer.myapp.systime.guitime_20 >= 20u)
                {
                    try
                    {
                        if (*GuiTimer.myapp.systimerbuf > 0)
                        {
                            for (int i = 0; i < (int)(*GuiTimer.myapp.systimerbuf); i++)
                            {
                                systimer_type* ptr = (systimer_type*)(GuiTimer.myapp.systimerbuf + (i * 5 + 4));
                                if (ptr->val < 65534 && ptr->val > 0)
                                {
                                    systimer_type* expr_B2 = ptr;
                                    expr_B2->val = (ushort)(expr_B2->val + 1);
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageOpen.Show("merry conflict!");
                    }
                    GuiTimer.myapp.systime.guitime_20 = 0u;
                }
                if (GuiTimer.myapp.systime.touchdowntime > 0u)
                {
                    myappinf expr_121_cp_0 = GuiTimer.myapp;
                    expr_121_cp_0.systime.touchdowntime = expr_121_cp_0.systime.touchdowntime + tt;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("timerm_5ms Runerror:" + ex.Message);
            }
        }

        public static uint Gettime(uint time)
        {
            uint result;
            if (time <= GuiTimer.myapp.systime.systemruntime)
            {
                result = GuiTimer.myapp.systime.systemruntime - time;
            }
            else
            {
                result = 4294967295u - GuiTimer.myapp.systime.systemruntime + time;
            }
            return result;
        }
    }
}
