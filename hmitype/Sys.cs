using System;
using System.Threading;

namespace hmitype
{
    public static class Sys
    {
        public static myappinf myapp;

        private static int lastrandcc = -1234567;

        public static void delay_ms(ushort val)
        {
            try
            {
                if (Sys.myapp.upapp.runapptype == runapptype.run)
                {
                    if (Sys.myapp.upapp.Lcdshouxian > 0)
                    {
                        Sys.myapp.upapp.ScreenRef(1);
                    }
                    DateTime now = DateTime.Now;
                    while (Win32.Win32GetTime(now) < (uint)val)
                    {
                        if (Sys.myapp.upapp.runstate == 0)
                        {
                            break;
                        }
                        Thread.Sleep(1);
                    }
                }
                else
                {
                    while (val > 0)
                    {
                        if (Sys.myapp.upapp.runstate == 0)
                        {
                            break;
                        }
                        Thread.Sleep(1);
                        val -= 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("delayms is error" + ex.Message);
            }
        }

        public static void Endcomdata()
        {
            int num = 0;
            if (Sys.myapp.USART.lei != 0)
            {
                if (Sys.myapp.USART.lei != 1)
                {
                    if (Sys.myapp.USART.lei != 10)
                    {
                        if (Sys.myapp.USART.lei == 11)
                        {
                            num = 1;
                        }
                    }
                }
            }
            if (num == 1)
            {
                Sys.myapp.USART.State = 0;
                Commake.Commake_ClearNorComData();
                Usart.Usart_SendByte(253);
                Commake.Commake_SendEnd();
            }
        }

        public static int rand(int min, int max)
        {
            int result;
            if (min > max)
            {
                result = 0;
            }
            else
            {
                int num = (int)DateTime.Now.Ticks;
                num |= Sys.lastrandcc;
                Random random = new Random(num);
                Sys.lastrandcc = random.Next(-2147483647, 2147483647);
                int num2;
                if (max < 2147483647)
                {
                    num2 = random.Next(min, max + 1);
                }
                else if (min > -2147483648)
                {
                    num2 = random.Next(min - 1, max);
                    num2++;
                }
                else
                {
                    num2 = random.Next(min, max);
                    num2 += ((int)DateTime.Now.Ticks & 1);
                }
                result = num2;
            }
            return result;
        }
    }
}
