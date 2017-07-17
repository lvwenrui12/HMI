using System;

namespace hmitype
{
    public static class Datafind
    {
        public unsafe static uint Datafind_FindU32_Memory(uint* val, uint* datastar, uint datarows, uint datalenth)
        {
            int i = 0;
            int num = (int)(datarows - 1u);
            uint result;
            while (i < num)
            {
                uint num2 = (uint)(i + (num - i >> 1));
                if (datastar[num2 * datalenth] > *val)
                {
                    num = (int)(num2 - 1u);
                }
                else
                {
                    if (datastar[num2 * datalenth] >= *val)
                    {
                        result = num2;
                        return result;
                    }
                    i = (int)(num2 + 1u);
                }
            }
            if (datastar[(long)i * (long)((ulong)datalenth) * 4L / 4L] == *val)
            {
                result = (uint)i;
                return result;
            }
            result = 65535u;
            return result;
        }

        public unsafe static uint Datafind_FindU64_Memory(ulong* val, uint* datastar, uint datarows, uint datalenth)
        {
            int i = 0;
            int num = (int)(datarows - 1u);
            uint result;
            while (i < num)
            {
                uint num2 = (uint)(i + (num - i >> 1));
                if (*(long*)(datastar + num2 * datalenth) > (long)(*val))
                {
                    num = (int)(num2 - 1u);
                }
                else
                {
                    if (*(long*)(datastar + num2 * datalenth) >= (long)(*val))
                    {
                        result = num2;
                        return result;
                    }
                    i = (int)(num2 + 1u);
                }
            }
            if (*(long*)(datastar + (long)i * (long)((ulong)datalenth) * 4L / 4L) == (long)(*val))
            {
                result = (uint)i;
                return result;
            }
            result = 65535u;
            return result;
        }

        public unsafe static uint Datafind_FindU32_Flash(uint* val, uint datastar, ushort datarows, ushort datalenth)
        {
            int i = 0;
            int num = (int)(datarows - 1);
            uint[] array = new uint[2];
            uint result;
            while (i < num)
            {
                uint num2 = (uint)(i + (num - i >> 1));
                fixed (void* ptr = array)
                {
                    Readdata.SPI_Flash_Read((byte*)ptr, datastar + num2 * (uint)datalenth, 8u);
                }
                if (array[0] > *val)
                {
                    num = (int)(num2 - 1u);
                }
                else
                {
                    if (array[0] >= *val)
                    {
                        result = array[1];
                        return result;
                    }
                    i = (int)(num2 + 1u);
                }
            }
            fixed (void* ptr2 = (void*)(&array[0]))
            {
                Readdata.SPI_Flash_Read((byte*)ptr2, (uint)((ulong)datastar + (ulong)((long)(i * (int)datalenth))), 8u);
            }
            if (array[0] == *val)
            {
                result = array[1];
                return result;
            }
            result = 4294967295u;
            return result;
        }
    }
}
