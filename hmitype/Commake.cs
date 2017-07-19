using System.Runtime.InteropServices;
using hmitype;

public static class Commake
{
    // Fields
    public const ushort ComcodeLenth = 0x400;
    private const byte COMM_END_SYMBOL_1 = 0xff;
    private const byte COMM_END_SYMBOL_2 = 0xff;
    private const byte COMM_END_SYMBOL_3 = 0xff;
    public unsafe static byte* Comstrbuf;
    public static myappinf myapp;
    public static _NOR_COM_STATE_ NorComSta;

    // Methods
    public static unsafe void Commake_CheckNorComIdle()
    {
        if ((NorComSta.Recving == 0) && (NorComSta.RdPos != 0))
        {
            Commake_CLI();
            if ((NorComSta.Recving == 0) && ((NorComSta.RdPos + 1) == NorComSta.WrPos))
            {
                Comstrbuf[0] = 0;
                NorComSta.WrPos = 1;
                NorComSta.RdPos = 0;
            }
            Commake_SEI();
        }
    }

    private static unsafe byte Commake_CheckNorComOver()
    {
        byte num = 0;
        if (NorComSta.WrPos > NorComSta.RdPos)
        {
            if (NorComSta.WrPos > 0x3fa)
            {
                if (NorComSta.RdPos > (NorComSta.WrLen + 0x20))
                {
                    Comstrbuf[0] = 0;
                    Kuozhan.memcpy(Comstrbuf + 1, Comstrbuf + (NorComSta.WrPos - NorComSta.WrLen), NorComSta.WrLen);
                    NorComSta.WrPos = (short)(NorComSta.WrLen + 1);
                }
                else
                {
                    num = 1;
                }
            }
        }
        else if (NorComSta.WrPos > (NorComSta.RdPos - 6))
        {
            num = 1;
        }
        if (num > 0)
        {
            Commake_SendBackerr(0x24);
            NorComSta.WrPos = (short)(NorComSta.WrPos - NorComSta.WrLen);
            NorComSta.WrLen = 0;
            NorComSta.State = 4;
        }
        return num;
    }

    public static unsafe void Commake_ClearNorComData()
    {
        Comstrbuf[0] = 0;
        NorComSta.CRCcnt = 4;
        NorComSta.WrPos = 1;
        NorComSta.RdPos = 0;
        NorComSta.WrLen = 0;
        NorComSta.State = 0;
        NorComSta.Recving = 0;
    }

    private static void Commake_CLI()
    {
        Usart.usartzhongduan = false;
    }

    private static unsafe byte Commake_Comyouxian(PosLaction* pos)
    {
        byte result;
        if (Strmake.Strmake_Makestr(Commake.Comstrbuf + pos->star, "runmod=", 7) == 1)
        {
            byte b = (byte)(Commake.Comstrbuf[pos->star + 7] - 48);
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

    public static unsafe byte Commake_GetComm(PosLaction* pos)
    {
        byte num = Comstrbuf[NorComSta.RdPos];
        if ((num == 0) && (NorComSta.RdPos > NorComSta.WrPos))
        {
            NorComSta.RdPos = 0;
            num = Comstrbuf[NorComSta.RdPos];
        }
        if (num > 0)
        {
            pos->star = (ushort)(NorComSta.RdPos + 1);
            pos->end = (ushort)(NorComSta.RdPos + num);
            NorComSta.RdPos = (short)(NorComSta.RdPos + ((short)(num + 1)));
            if ((NorComSta.RdPos >= 0x400) || ((Comstrbuf[NorComSta.RdPos] == 0) && (NorComSta.RdPos > NorComSta.WrPos)))
            {
                NorComSta.RdPos = 0;
            }
            return 1;
        }
        return 0;
    }

    public static unsafe void Commake_PrintBytes(byte* str, ushort lenth)
    {
        for (int i = 0; i < lenth; i++)
        {
            Usart.Usart_SendByte(str[i]);
        }
    }

    public static unsafe void Commake_PrintIntToStr(int val, byte isend)
    {
        byte[] buffer = new byte[13];
        fixed (byte* numRef = buffer)
        {
            Strmake.Strmake_S32ToStr(val, numRef, 0, 1);
            Commake_Prints(numRef, isend);
        }
    }

    public static unsafe void Commake_Prints(byte* str, byte end)
    {
        while (str[0] != 0)
        {
            Usart.Usart_SendByte(str[0]);
            str++;
        }
        if (end > 0)
        {
            Commake_SendEnd();
        }
    }

    private static unsafe void Commake_RecvComEnd()
    {
        PosLaction laction;
        ushort num = (ushort)(NorComSta.WrPos - NorComSta.WrLen);
        laction.star = num;
        laction.end = (ushort)((laction.star + NorComSta.WrLen) - 1);
        if (Commake_Comyouxian(&laction) == 1)
        {
            NorComSta.WrPos = (short)(NorComSta.WrPos - NorComSta.WrLen);
        }
        else
        {
            Comstrbuf[num - 1] = NorComSta.WrLen;
            Comstrbuf[NorComSta.WrPos] = 0;
            NorComSta.WrPos = (short)(NorComSta.WrPos + 1);
            if ((NorComSta.WrPos > 0x3e0) && (NorComSta.RdPos > 0xcc))
            {
                Comstrbuf[0] = 0;
                NorComSta.WrPos = 1;
            }
        }
        NorComSta.State = 0;
        NorComSta.WrLen = 0;
        NorComSta.Recving = 0;
    }

    public static unsafe void Commake_RecvNorComData(byte da)
    {
        short num2;
        switch (NorComSta.State)
        {
            case 0:
                NorComSta.Recving = 1;
                if (da == 0xff)
                {
                    NorComSta.State = (byte)(NorComSta.State + 1);
                    break;
                }
                NorComSta.WrPos = (short)((num2 = NorComSta.WrPos) + 1);
                Comstrbuf[num2] = da;
                NorComSta.WrLen = (byte)(NorComSta.WrLen + 1);
                Commake_CheckNorComOver();
                break;

            case 1:
                if (da != 0xff)
                {
                    NorComSta.WrPos = (short)((num2 = NorComSta.WrPos) + 1);
                    Comstrbuf[num2] = 0xff;
                    NorComSta.WrPos = (short)((num2 = NorComSta.WrPos) + 1);
                    Comstrbuf[num2] = da;
                    NorComSta.WrLen = (byte)(NorComSta.WrLen + 2);
                    NorComSta.State = 0;
                    break;
                }
                NorComSta.State = (byte)(NorComSta.State + 1);
                break;

            case 2:
                if (da != 0xff)
                {
                    NorComSta.WrPos = (short)((num2 = NorComSta.WrPos) + 1);
                    Comstrbuf[num2] = 0xff;
                    NorComSta.WrPos = (short)((num2 = NorComSta.WrPos) + 1);
                    Comstrbuf[num2] = 0xff;
                    NorComSta.WrPos = (short)((num2 = NorComSta.WrPos) + 1);
                    Comstrbuf[num2] = da;
                    NorComSta.WrLen = (byte)(NorComSta.WrLen + 3);
                    NorComSta.State = 0;
                    break;
                }
                if (NorComSta.WrLen <= 0)
                {
                    NorComSta.State = 0;
                    break;
                }
                if (myapp.comcrc <= 0)
                {
                    Commake_RecvComEnd();
                    break;
                }
                NorComSta.State = (byte)(NorComSta.State + 1);
                break;

            case 3:
                NorComSta.WrPos = (short)((num2 = NorComSta.WrPos) + 1);
                Comstrbuf[num2] = da;
                NorComSta.WrLen = (byte)(NorComSta.WrLen + 1);
                NorComSta.CRCcnt = (byte)(NorComSta.CRCcnt - 1);
                if (NorComSta.CRCcnt == 0)
                {
                    NorComSta.CRCcnt = 4;
                    Commake_RecvComEnd();
                }
                break;

            case 4:
                if (da == 0xff)
                {
                    NorComSta.State = (byte)(NorComSta.State + 1);
                }
                break;

            case 5:
                if (da == 0xff)
                {
                    NorComSta.State = (byte)(NorComSta.State + 1);
                }
                break;

            case 6:
                if (da == 0xff)
                {
                    NorComSta.State = 0;
                }
                break;
        }
        if ((NorComSta.WrLen > 250) && (NorComSta.State == 0))
        {
            NorComSta.WrPos = (short)(NorComSta.WrPos - NorComSta.WrLen);
            NorComSta.WrLen = 0;
        }
    }

    public static unsafe byte Commake_ScanComcode()
    {
        PosLaction laction;
        if ((NorComSta.runmod == 1) && (Commake_GetComm(&laction) > 0))
        {
            if (myapp.comcrc > 0)
            {
                uint num2;
                uint num = Kuozhan.CRC32(Comstrbuf + laction.star, Comstrbuf[laction.star - 1] - 4);
                Kuozhan.memcpy((byte*)&num2, Comstrbuf + (laction.end - 3), 4);
                laction.end = (ushort)(laction.end - 4);
                if (num != num2)
                {
                    myapp.errcode = 0x22;
                    Commake_SendBackerr(myapp.errcode);
                    return 1;
                }
            }
            if (CodeRun.Coderun_Run(Comstrbuf, &laction) == 1)
            {
                Commake_SendBacksuc();
            }
            else if (myapp.errcode < 0xff)
            {
                Commake_SendBackerr(myapp.errcode);
            }
            return 1;
        }
        return 0;
    }

    private static void Commake_SEI()
    {
        Usart.usartzhongduan = true;
    }

    //public static unsafe void Commake_SendAtt(ref runattinf att1, byte state)
    //{
    //    fixed (runattinf* runattinfRef = ((runattinf*)att1))
    //    {
    //        Commake_SendAtt(runattinfRef, state);
    //    }
    //}

    public unsafe static void Commake_SendAtt(ref runattinf att1, byte state)
    {
        fixed (runattinf* ptr = &att1)
        {
            Commake.Commake_SendAtt(ptr, state);
        }
    }


    //public static unsafe void Commake_SendAtt(runattinf* att1, byte state)
    //{
    //    if (att1.attlei == attshulei.Sstr.typevalue)
    //    {
    //        if (state == 1)
    //        {
    //            Usart.Usart_SendByte(0x70);
    //        }
    //        Commake_Prints(att1.Pz, 0);
    //    }
    //    else
    //    {
    //        if (state == 1)
    //        {
    //            Usart.Usart_SendByte(0x71);
    //        }
    //        Commake_PrintBytes((byte*)&att1.val, 4);
    //    }
    //    if (state == 1)
    //    {
    //        Commake_SendEnd();
    //    }
    //}

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

    public static void Commake_SendBackerr(byte val)
    {
        if (((myapp.Hexstrindex != 0xffff) || (myapp.sendfanhui == 2)) || (myapp.sendfanhui == 3))
        {
            Usart.Usart_SendByte(val);
            Commake_SendEnd();
        }
    }

    public static void Commake_SendBacksuc()
    {
        if ((myapp.sendfanhui == 1) || (myapp.sendfanhui == 3))
        {
            Usart.Usart_SendByte(1);
            Commake_SendEnd();
        }
    }

    public static void Commake_SendEnd()
    {
        Usart.Usart_SendByte(0xff);
        Usart.Usart_SendByte(0xff);
        Usart.Usart_SendByte(0xff);
    }

    // Nested Types
    [StructLayout(LayoutKind.Sequential)]
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
}





