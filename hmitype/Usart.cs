using System;

namespace hmitype
{
    public static class Usart
    {
        public static myappinf myapp;

        public static bool usartzhongduan = true;

        public static void Usart_SendByte(byte val)
        {
            Usart.myapp.upapp.SendCom(val);
        }

        public static void Usart_ComRecode(byte Res)
        {
            try
            {
                if (Usart.myapp.upapp.runapptype == runapptype.run)
                {
                    while (!Usart.usartzhongduan)
                    {
                    }
                    byte state = Usart.myapp.USART.State;
                    switch (state)
                    {
                        case 0:
                            Commake.Commake_RecvNorComData(Res);
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        default:
                            if (state == 23)
                            {
                                GuiCurve.RecCurveTranData(Res);
                            }
                            break;
                    }
                    if (Usart.myapp.sys.ussp > 0)
                    {
                        Usart.myapp.systime.sptime = Usart.myapp.systime.systemruntime;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("Usart_ComRecode RunError:" + ex.Message);
            }
        }
    }
}
