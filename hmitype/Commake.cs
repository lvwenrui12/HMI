using System;

namespace hmitype
{
    public static class Commake
    {
        public struct _NOR_COM_STATE_
        {
            public short WrPos;

            public short RdPos;

            public byte runmod;

            public byte WrLen;

            public byte State;

            public byte CRCcnt;

            public byte Recving;
        }

        private const byte COMM_END_SYMBOL_1 = 255;

        private const byte COMM_END_SYMBOL_2 = 255;

        private const byte COMM_END_SYMBOL_3 = 255;

        public const ushort ComcodeLenth = 1024;

        public static myappinf myapp;

        public unsafe static byte* Comstrbuf;

        public static Commake._NOR_COM_STATE_ NorComSta;

        private static void Commake_CLI()
        {
            Usart.usartzhongduan = false;
        }

        private static void Commake_SEI()
        {
            Usart.usartzhongduan = true;
        }

        public unsafe static void Commake_SendAtt(ref runattinf att1, byte state)
        {
            fixed (runattinf* ptr = &att1)
            {
                Commake.Commake_SendAtt(ptr, state);
            }
        }

        private unsafe static byte Commake_Comyouxian(PosLaction* pos)
        {
            byte result;
            if (Strmake.Strmake_Makestr(Commake.Comstrbuf + pos->star, "runmod=", 7) == 1)
            {
                byte b = Convert.ToByte(Commake.Comstrbuf[pos->star + 7] - 48);
                //byte b = Commake.Comstrbuf[pos->star + 7] - 48;
                if (b == 0 || b == 1 || b == 2)
                {
                    Sysatt.Sysatt_SetXitongval(21, (int)b);
                    Commake.Commake_SendBacksuc();
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                if (Strmake.Strmake_Makestr(Commake.Comstrbuf + pos->star, "com_st", 6) == 1)
                {
                    if (Strmake.Strmake_Makestr(Commake.Comstrbuf + pos->star, "com_star", 8) == 1)
                    {
                        Commake.NorComSta.runmod = 1;
                        result = 1;
                        return result;
                    }
                    if (Strmake.Strmake_Makestr(Commake.Comstrbuf + pos->star, "com_stop", 8) == 1)
                    {
                        Commake.NorComSta.runmod = 0;
                        result = 1;
                        return result;
                    }
                }
                result = 0;
            }
            return result;
        }

        private unsafe static void Commake_RecvComEnd()
        {
            ushort num = (ushort)(Commake.NorComSta.WrPos - (short)Commake.NorComSta.WrLen);
            PosLaction posLaction;
            posLaction.star = num;
            posLaction.end = (ushort)(posLaction.star + (ushort)Commake.NorComSta.WrLen - 1);
            if (Commake.Commake_Comyouxian(&posLaction) == 1)
            {
                Commake.NorComSta.WrPos = (short)(Commake.NorComSta.WrPos - (short)Commake.NorComSta.WrLen);
            }
            else
            {
                Commake.Comstrbuf[num - 1] = Commake.NorComSta.WrLen;
                Commake.Comstrbuf[Commake.NorComSta.WrPos] = 0;
                Commake.NorComSta.WrPos = (short)(Commake.NorComSta.WrPos + 1);
                if (Commake.NorComSta.WrPos > 992 && Commake.NorComSta.RdPos > 204)
                {
                    *Commake.Comstrbuf = 0;
                    Commake.NorComSta.WrPos = 1;
                }
            }
            Commake.NorComSta.State = 0;
            Commake.NorComSta.WrLen = 0;
            Commake.NorComSta.Recving = 0;
        }

        private unsafe static byte Commake_CheckNorComOver()
        {
            byte b = 0;
            if (Commake.NorComSta.WrPos > Commake.NorComSta.RdPos)
            {
                if (Commake.NorComSta.WrPos > 1018)
                {
                    if (Commake.NorComSta.RdPos > (short)(Commake.NorComSta.WrLen + 32))
                    {
                        *Commake.Comstrbuf = 0;
                        Kuozhan.memcpy(Commake.Comstrbuf + 1, Commake.Comstrbuf + (Commake.NorComSta.WrPos - (short)Commake.NorComSta.WrLen), (int)Commake.NorComSta.WrLen);
                        Commake.NorComSta.WrPos = (short)(Commake.NorComSta.WrLen + 1);
                    }
                    else
                    {
                        b = 1;
                    }
                }
            }
            else if (Commake.NorComSta.WrPos > Commake.NorComSta.RdPos - 6)
            {
                b = 1;
            }
            if (b > 0)
            {
                Commake.Commake_SendBackerr(36);
                Commake.NorComSta.WrPos =(short) (Commake.NorComSta.WrPos - (short)Commake.NorComSta.WrLen);
                Commake.NorComSta.WrLen = 0;
                Commake.NorComSta.State = 4;
            }
            return b;
        }

        public unsafe static byte Commake_GetComm(PosLaction* pos)
        {
            byte b = Commake.Comstrbuf[Commake.NorComSta.RdPos];
            if (b == 0 && Commake.NorComSta.RdPos > Commake.NorComSta.WrPos)
            {
                Commake.NorComSta.RdPos = 0;
                b = Commake.Comstrbuf[Commake.NorComSta.RdPos];
            }
            byte result;
            if (b > 0)
            {
                pos->star = (ushort)(Commake.NorComSta.RdPos + 1);
                pos->end = (ushort)(Commake.NorComSta.RdPos + (short)b);
                Commake.NorComSta.RdPos = (short)(Commake.NorComSta.RdPos + (short)(b + 1));
                if (Commake.NorComSta.RdPos >= 1024 || (Commake.Comstrbuf[Commake.NorComSta.RdPos] == 0 && Commake.NorComSta.RdPos > Commake.NorComSta.WrPos))
                {
                    Commake.NorComSta.RdPos = 0;
                }
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public unsafe static void Commake_RecvNorComData(byte da)
        {
            byte NorComStaState = Commake.NorComSta.State;
            switch (NorComStaState)
            {
                case 0:
                    Commake.NorComSta.Recving = 1;
                    if (da != 255)
                    {
                        byte* arg_66_0 = ref *Commake.Comstrbuf;
                        short wrPos;
                        Commake.NorComSta.WrPos =(short) ((wrPos = Commake.NorComSta.WrPos) + 1);
                        *(arg_66_0 + wrPos) = da;
                        Commake.NorComSta.WrLen = Convert.ToByte((Commake.NorComSta.WrLen + 1));
                        Commake.Commake_CheckNorComOver();
                    }
                    else
                    {
                        Commake.NorComSta.State = Commake.NorComSta.State + 1;
                    }
                    break;
                case 1:
                    if (da == 255)
                    {
                        Commake.NorComSta.State = Commake.NorComSta.State + 1;
                    }
                    else
                    {
                        byte* arg_E1_0 = ref *Commake.Comstrbuf;
                        short wrPos;
                        Commake.NorComSta.WrPos = (wrPos = Commake.NorComSta.WrPos) + 1;
                        *(arg_E1_0 + wrPos) = 255;
                        byte* arg_103_0 = ref *Commake.Comstrbuf;
                        Commake.NorComSta.WrPos = (wrPos = Commake.NorComSta.WrPos) + 1;
                        *(arg_103_0 + wrPos) = da;
                        Commake.NorComSta.WrLen = Commake.NorComSta.WrLen + 2;
                        Commake.NorComSta.State = 0;
                    }
                    break;
                case 2:
                    if (da == 255)
                    {
                        if (Commake.NorComSta.WrLen > 0)
                        {
                            if (Commake.myapp.comcrc > 0)
                            {
                                Commake.NorComSta.State = Commake.NorComSta.State + 1;
                            }
                            else
                            {
                                Commake.Commake_RecvComEnd();
                            }
                        }
                        else
                        {
                            Commake.NorComSta.State = 0;
                        }
                    }
                    else
                    {
                        byte* arg_1B0_0 = ref *Commake.Comstrbuf;
                        short wrPos;
                        Commake.NorComSta.WrPos = (wrPos = Commake.NorComSta.WrPos) + 1;
                        *(arg_1B0_0 + wrPos) = 255;
                        byte* arg_1D2_0 = ref *Commake.Comstrbuf;
                        Commake.NorComSta.WrPos = (wrPos = Commake.NorComSta.WrPos) + 1;
                        *(arg_1D2_0 + wrPos) = 255;
                        byte* arg_1F4_0 = ref *Commake.Comstrbuf;
                        Commake.NorComSta.WrPos = (wrPos = Commake.NorComSta.WrPos) + 1;
                        *(arg_1F4_0 + wrPos) = da;
                        Commake.NorComSta.WrLen = Commake.NorComSta.WrLen + 3;
                        Commake.NorComSta.State = 0;
                    }
                    break;
                case 3:
                    {
                        byte* arg_236_0 = ref *Commake.Comstrbuf;
                        short wrPos;
                        Commake.NorComSta.WrPos = (wrPos = Commake.NorComSta.WrPos) + 1;
                        *(arg_236_0 + wrPos) = da;
                        Commake.NorComSta.WrLen = Commake.NorComSta.WrLen + 1;
                        Commake.NorComSta.CRCcnt = Commake.NorComSta.CRCcnt - 1;
                        if (Commake.NorComSta.CRCcnt == 0)
                        {
                            Commake.NorComSta.CRCcnt = 4;
                            Commake.Commake_RecvComEnd();
                        }
                        break;
                    }
                case 4:
                    if (da == 255)
                    {
                        Commake.NorComSta.State = Commake.NorComSta.State + 1;
                    }
                    break;
                case 5:
                    if (da == 255)
                    {
                        Commake.NorComSta.State = Commake.NorComSta.State + 1;
                    }
                    break;
                case 6:
                    if (da == 255)
                    {
                        Commake.NorComSta.State = 0;
                    }
                    break;
            }
            if (Commake.NorComSta.WrLen > 250 && Commake.NorComSta.State == 0)
            {
                Commake.NorComSta.WrPos = Commake.NorComSta.WrPos - (short)Commake.NorComSta.WrLen;
                Commake.NorComSta.WrLen = 0;
            }
        }

        public unsafe static void Commake_CheckNorComIdle()
        {
            if (Commake.NorComSta.Recving == 0 && Commake.NorComSta.RdPos != 0)
            {
                Commake.Commake_CLI();
                if (Commake.NorComSta.Recving == 0 && Commake.NorComSta.RdPos + 1 == Commake.NorComSta.WrPos)
                {
                    *Commake.Comstrbuf = 0;
                    Commake.NorComSta.WrPos = 1;
                    Commake.NorComSta.RdPos = 0;
                }
                Commake.Commake_SEI();
            }
        }

        public unsafe static void Commake_ClearNorComData()
        {
            *Commake.Comstrbuf = 0;
            Commake.NorComSta.CRCcnt = 4;
            Commake.NorComSta.WrPos = 1;
            Commake.NorComSta.RdPos = 0;
            Commake.NorComSta.WrLen = 0;
            Commake.NorComSta.State = 0;
            Commake.NorComSta.Recving = 0;
        }

        public unsafe static byte Commake_ScanComcode()
        {
            byte result;
            PosLaction posLaction;
            if (Commake.NorComSta.runmod != 1)
            {
                result = 0;
            }
            else if (Commake.Commake_GetComm(&posLaction) > 0)
            {
                if (Commake.myapp.comcrc > 0)
                {
                    uint num = Kuozhan.CRC32(Commake.Comstrbuf + posLaction.star, (int)(Commake.Comstrbuf[posLaction.star - 1] - 4));
                    uint num2;
                    Kuozhan.memcpy((byte*)(&num2), Commake.Comstrbuf + (posLaction.end - 3), 4);
                    posLaction.end -= 4;
                    if (num != num2)
                    {
                        Commake.myapp.errcode = 34;
                        Commake.Commake_SendBackerr(Commake.myapp.errcode);
                        result = 1;
                        return result;
                    }
                }
                if (CodeRun.Coderun_Run(Commake.Comstrbuf, &posLaction) == 1)
                {
                    Commake.Commake_SendBacksuc();
                }
                else if (Commake.myapp.errcode < 255)
                {
                    Commake.Commake_SendBackerr(Commake.myapp.errcode);
                }
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public static void Commake_SendBackerr(byte val)
        {
            if (Commake.myapp.Hexstrindex != 65535 || Commake.myapp.sendfanhui == 2 || Commake.myapp.sendfanhui == 3)
            {
                Usart.Usart_SendByte(val);
                Commake.Commake_SendEnd();
            }
        }

        public static void Commake_SendBacksuc()
        {
            if (Commake.myapp.sendfanhui == 1 || Commake.myapp.sendfanhui == 3)
            {
                Usart.Usart_SendByte(1);
                Commake.Commake_SendEnd();
            }
        }

        public unsafe static void Commake_Prints(byte* str, byte end)
        {
            while (*str != 0)
            {
                Usart.Usart_SendByte(*str);
                str++;
            }
            if (end > 0)
            {
                Commake.Commake_SendEnd();
            }
        }

        public unsafe static void Commake_PrintBytes(byte* str, ushort lenth)
        {
            for (int i = 0; i < (int)lenth; i++)
            {
                Usart.Usart_SendByte(str[i]);
            }
        }

        public static void Commake_SendEnd()
        {
            Usart.Usart_SendByte(255);
            Usart.Usart_SendByte(255);
            Usart.Usart_SendByte(255);
        }

        public unsafe static void Commake_PrintIntToStr(int val, byte isend)
        {
            byte[] array = new byte[13];
            fixed (byte* ptr = array)
            {
                Strmake.Strmake_S32ToStr(val, ptr, 0, 1);
                Commake.Commake_Prints(ptr, isend);
            }
        }

        public unsafe static void Commake_SendAtt(runattinf* att1, byte state)
        {
            if (att1->attlei == attshulei.Sstr.typevalue)
            {
                if (state == 1)
                {
                    Usart.Usart_SendByte(112);
                }
                Commake.Commake_Prints(att1->Pz, 0);
            }
            else
            {
                if (state == 1)
                {
                    Usart.Usart_SendByte(113);
                }
                Commake.Commake_PrintBytes((byte*)(&att1->val), 4);
            }
            if (state == 1)
            {
                Commake.Commake_SendEnd();
            }
        }
    }
}
