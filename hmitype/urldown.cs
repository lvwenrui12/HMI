using System;
using System.IO;
using System.Net;
using System.Threading;

namespace hmitype
{
    public class urldown
    {
        public string url = "";

        public string filepath = "";

        public int filelenth = 0;

        public bool downok = false;

        public int chongshi = 3;

        public string error = "";

        private string temppath = "";

        private StreamWriter comsr;

        private Stream file1;

        private Thread uu;

        public void DownStar()
        {
            int num = 0;
            this.temppath = datasize.linpath + "\\downtemp.temp";
            while (!Kuozhan.delfile(this.temppath))
            {
                this.temppath += num;
                num++;
            }
            this.uu = new Thread(new ThreadStart(this.Downloadfile));
            this.uu.Start();
        }

        public void DownStop()
        {
            this.uu.Abort();
            this.closeziyuan();
        }

        private void Downloadfile()
        {
            int i = 0;
            while (i <= this.chongshi)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    if (this.downok)
                    {
                        this.downok = false;
                    }
                    if (this.error != "")
                    {
                        this.error = "";
                    }
                    if (!Kuozhan.delfile(this.temppath))
                    {
                        this.error = "file error" + this.temppath;
                        break;
                    }
                    this.comsr = new StreamWriter(this.temppath);
                    this.file1 = webClient.OpenRead(this.url);
                    byte[] array = new byte[65536];
                    this.filelenth = 0;
                    int j = 1;
                    while (j > 0)
                    {
                        j = this.file1.Read(array, 0, array.Length);
                        this.comsr.BaseStream.Write(array, 0, j);
                        this.filelenth += j;
                    }
                    this.comsr.Close();
                    this.comsr.Dispose();
                    this.file1.Close();
                    this.file1.Dispose();
                    if (!Kuozhan.delfile(this.filepath))
                    {
                        this.error = "file error" + this.temppath;
                        break;
                    }
                    File.Move(this.temppath, this.filepath);
                    this.downok = true;
                    break;
                }
                catch (Exception ex)
                {
                    this.closeziyuan();
                    i++;
                    if (i > this.chongshi)
                    {
                        this.error = ex.Message + "\r\n";
                    }
                }
            }
        }

        private void closeziyuan()
        {
            try
            {
                this.comsr.Close();
                this.comsr.Dispose();
                this.file1.Close();
                this.file1.Dispose();
            }
            catch
            {
            }
        }
    }
}
