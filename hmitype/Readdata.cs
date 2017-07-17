using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace hmitype
{
    public static class Readdata
    {
        public static ushort appxinxisize0 = (ushort)Marshal.SizeOf(default(appinf0));

        public static ushort appxinxisize1 = (ushort)Marshal.SizeOf(default(appinf1));

        public static ushort pagexinxisize = (ushort)Marshal.SizeOf(default(pagexinxi));

        public static ushort objxinxisize = (ushort)Marshal.SizeOf(default(objxinxi));

        public static ushort picxinxisize = (ushort)Marshal.SizeOf(default(Picturexinxi));

        public static ushort zimoxinxisize = (ushort)Marshal.SizeOf(default(zimoxinxi));

        public static ushort strxinxisize = (ushort)Marshal.SizeOf(default(strxinxi));

        public static ushort redianxinxisize = (ushort)Marshal.SizeOf(default(redianinf));

        public static myappinf myapp;

        public unsafe static void SPI_Flash_Read(ref byte[] buf, uint add, uint qyt)
        {
            fixed (byte* ptr = buf)
            {
                Readdata.SPI_Flash_Read(ptr, add, qyt);
            }
        }

        public static byte Readdata_ReadBinapp()
        {
            byte[] array = new byte[4];
            appinf0 appinf = default(appinf0);
            byte result;
            if (Readdata.Readdata_ReadApp0(ref appinf) == 0)
            {
                result = 0;
            }
            else
            {
                byte[] array2 = new byte[Marshal.SizeOf(default(appinf1))];
                Readdata.myapp.upapp.filesr.BaseStream.Position = 200L;
                Readdata.myapp.upapp.filesr.BaseStream.Read(array2, 0, Marshal.SizeOf(default(appinf1)));
                Readdata.myapp.upapp.filesr.BaseStream.Position = 396L;
                Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, 4);
                if ((uint)array.BytesTostruct(0u.GetType()) != array2.getcrc(4294967295u, 0, (int)Readdata.appxinxisize1))
                {
                    result = 0;
                }
                else
                {
                    array2 = array2.Appfree10(datasize.apppasseord, appinf.Modelcrc);
                    Readdata.myapp.app = (appinf1)array2.BytesTostruct(default(appinf1).GetType());
                    progform progform = null;
                    int num = 1;
                    int num2 = 0;
                    if (Readdata.myapp.upapp.runapptype == runapptype.run && Readdata.myapp.upapp.images == null)
                    {
                        Readdata.myapp.upapp.images = new List<guiimagetype>();
                        if (Readdata.myapp.app.picqyt > 0)
                        {
                            num = (int)(Readdata.myapp.app.zimodataadd - Readdata.myapp.app.picdataadd);
                            num2 = 0;
                            progform = new progform();
                            progform.Show();
                            Application.DoEvents();
                            Thread.Sleep(300);
                        }
                        for (int i = 0; i < (int)Readdata.myapp.app.picqyt; i++)
                        {
                            Picturexinxi pic = default(Picturexinxi);
                            Readdata.Readdata_ReadPic(ref pic, i);
                            guiimagetype item = default(guiimagetype);
                            item.imagebitbmp = new Bitmap((int)pic.W, (int)pic.H);
                            byte[] array3 = new byte[(int)(pic.W * pic.H * 2)];
                            Readdata.myapp.upapp.filesr.BaseStream.Position = (long)(pic.addbeg + Readdata.myapp.app.picdataadd);
                            Readdata.myapp.upapp.filesr.BaseStream.Read(array3, 0, array3.Length);
                            item.imagebitbmp = array3.GetBitmap(pic, datasize.Opentouming);
                            Readdata.myapp.upapp.images.Add(item);
                            num2 += (int)pic.imgbytesize;
                            progform.setprogval(num2 * 100 / num);
                            Application.DoEvents();
                        }
                        if (progform != null)
                        {
                            Application.DoEvents();
                            Thread.Sleep(300);
                            progform.Close();
                        }
                    }
                    result = 1;
                }
            }
            return result;
        }

        public static byte Readdata_ReadApp0(ref appinf0 app0)
        {
            byte[] array = new byte[4];
            byte[] array2 = new byte[(int)Readdata.appxinxisize0];
            Readdata.myapp.upapp.filesr.BaseStream.Position = 0L;
            Readdata.myapp.upapp.filesr.BaseStream.Read(array2, 0, (int)Readdata.appxinxisize0);
            Readdata.myapp.upapp.filesr.BaseStream.Position = 196L;
            Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, 4);
            byte result;
            if ((uint)array.BytesTostruct(0u.GetType()) != array2.getcrc(4294967295u, 0, (int)Readdata.appxinxisize0))
            {
                result = 0;
            }
            else
            {
                app0 = (appinf0)array2.BytesTostruct(default(appinf0).GetType());
                Readdata.myapp.encodeh_star = app0.encodeh_star;
                result = 1;
            }
            return result;
        }

        public static void Readdata_RedZimo(ref zimoxinxi zi, int index)
        {
            byte[] array = new byte[(int)Readdata.zimoxinxisize];
            Readdata.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)Readdata.myapp.app.zimoxinxiadd + (ulong)((long)((int)Readdata.zimoxinxisize * index)));
            Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, (int)Readdata.zimoxinxisize);
            zi = (zimoxinxi)array.BytesTostruct(default(zimoxinxi).GetType());
        }

        public static void Readdata_ReadPic(ref Picturexinxi pic, int index)
        {
            byte[] array = new byte[(int)Readdata.picxinxisize];
            Readdata.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)Readdata.myapp.app.picxinxiadd + (ulong)((long)((int)Readdata.picxinxisize * index)));
            Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, (int)Readdata.picxinxisize);
            pic = (Picturexinxi)array.BytesTostruct(default(Picturexinxi).GetType());
        }

        public static void Readdata_ReadPage(ref pagexinxi page, int index)
        {
            byte[] array = new byte[(int)Readdata.pagexinxisize];
            Readdata.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)Readdata.myapp.app.pageadd + (ulong)((long)((int)Readdata.pagexinxisize * index)));
            Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, array.Length);
            page = (pagexinxi)array.BytesTostruct(default(pagexinxi).GetType());
        }

        public static void Readdata_ReadStr(ref strxinxi str, int index)
        {
            byte[] array = new byte[(int)Readdata.strxinxisize];
            Readdata.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)Readdata.myapp.app.strxinxiadd + (ulong)((long)((int)Readdata.strxinxisize * index)));
            Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, (int)Readdata.strxinxisize);
            str = (strxinxi)array.BytesTostruct(default(strxinxi).GetType());
        }

        public static void Readdata_ReadObj(ref objxinxi obj, int index)
        {
            byte[] array = new byte[(int)Readdata.objxinxisize];
            if (Readdata.myapp.upapp.runapptype == runapptype.run)
            {
                Readdata.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)Readdata.myapp.app.objadd + (ulong)((long)((int)(Readdata.objxinxisize + 180) * index)));
            }
            else
            {
                Readdata.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)Readdata.myapp.app.objadd + (ulong)((long)((int)Readdata.objxinxisize * index)));
            }
            Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, (int)Readdata.objxinxisize);
            obj = (objxinxi)array.BytesTostruct(default(objxinxi).GetType());
        }

        public unsafe static void SPI_Flash_Read(byte* bt1, uint add, uint qyt)
        {
            try
            {
                byte[] array = new byte[qyt];
                Readdata.myapp.upapp.filesr.BaseStream.Position = (long)((ulong)add);
                Readdata.myapp.upapp.filesr.BaseStream.Read(array, 0, (int)qyt);
                array.BytesToptr(bt1);
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }
    }
}
