using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace hmitype
{
    public class FTPClient
    {
        public enum TransferType
        {
            Binary,
            ASCII
        }

        private string strRemoteHost;

        private int strRemotePort;

        private string strRemotePath;

        private string strRemoteUser;

        private string strRemotePass;

        private bool bConnected;

        public int dataqyt = 0;

        private string strMsg;

        private string strReply;

        private int iReplyCode;

        private Socket socketControl;

        private FTPClient.TransferType trType;

        public int BLOCK_SIZE = 2048;

        private Encoding ASCII = Encoding.ASCII;

        public string RemoteHost
        {
            get
            {
                return this.strRemoteHost;
            }
            set
            {
                this.strRemoteHost = value;
            }
        }

        public int RemotePort
        {
            get
            {
                return this.strRemotePort;
            }
            set
            {
                this.strRemotePort = value;
            }
        }

        public string RemotePath
        {
            get
            {
                return this.strRemotePath;
            }
            set
            {
                this.strRemotePath = value;
            }
        }

        public string RemoteUser
        {
            set
            {
                this.strRemoteUser = value;
            }
        }

        public string RemotePass
        {
            set
            {
                this.strRemotePass = value;
            }
        }

        public bool Connected
        {
            get
            {
                return this.bConnected;
            }
        }

        public FTPClient()
        {
            this.strRemoteHost = "";
            this.strRemotePath = "/";
            this.strRemoteUser = "";
            this.strRemotePass = "";
            this.strRemotePort = 21;
            this.bConnected = false;
        }

        public FTPClient(string remoteHost, string remotePath, string remoteUser, string remotePass, int remotePort)
        {
            this.strRemoteHost = remoteHost;
            this.strRemotePath = remotePath;
            this.strRemoteUser = remoteUser;
            this.strRemotePass = remotePass;
            this.strRemotePort = remotePort;
            this.Connect();
        }

        public string Connect()
        {
            this.socketControl = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(this.RemoteHost), this.strRemotePort);
            string result;
            try
            {
                this.socketControl.Connect(remoteEP);
            }
            catch (Exception)
            {
                this.DisConnect();
                result = "Couldn't connect toremote server";
                return result;
            }
            this.ReadReply();
            if (this.iReplyCode != 220)
            {
                this.DisConnect();
                result = this.strReply.Substring(4);
            }
            else
            {
                this.SendCommand("USER " + this.strRemoteUser);
                if (this.iReplyCode != 331 && this.iReplyCode != 230)
                {
                    this.CloseSocketConnect();
                    result = this.strReply.Substring(4);
                }
                else
                {
                    if (this.iReplyCode != 230)
                    {
                        this.SendCommand("PASS " + this.strRemotePass);
                        if (this.iReplyCode != 230 && this.iReplyCode != 202)
                        {
                            this.CloseSocketConnect();
                            result = this.strReply.Substring(4);
                            return result;
                        }
                    }
                    this.bConnected = true;
                    this.ChDir(this.strRemotePath);
                    result = "ok";
                }
            }
            return result;
        }

        public void DisConnect()
        {
            if (this.socketControl != null)
            {
                this.SendCommand("QUIT");
            }
            this.CloseSocketConnect();
        }

        public void SetTransferType(FTPClient.TransferType ttType)
        {
            if (ttType == FTPClient.TransferType.Binary)
            {
                this.SendCommand("TYPE I");
            }
            else
            {
                this.SendCommand("TYPE A");
            }
            if (this.iReplyCode != 200)
            {
                throw new IOException(this.strReply.Substring(4));
            }
            this.trType = ttType;
        }

        public FTPClient.TransferType GetTransferType()
        {
            return this.trType;
        }

        public string[] Dir(string strMask)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            Socket socket = this.CreateDataSocket();
            byte[] array = new byte[this.BLOCK_SIZE];
            this.SendCommand("NLST " + strMask);
            if (this.iReplyCode != 150 && this.iReplyCode != 125 && this.iReplyCode != 226)
            {
                throw new IOException(this.strReply.Substring(4));
            }
            this.strMsg = "";
            int num;
            do
            {
                num = socket.Receive(array, array.Length, SocketFlags.None);
                this.strMsg += this.ASCII.GetString(array, 0, num);
            }
            while (num >= array.Length);
            char[] separator = new char[]
            {
                '\n'
            };
            string[] result = this.strMsg.Split(separator);
            socket.Close();
            if (this.iReplyCode != 226)
            {
                this.ReadReply();
                if (this.iReplyCode != 226)
                {
                    throw new IOException(this.strReply.Substring(4));
                }
            }
            return result;
        }

        private long GetFileSize(string strFileName)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            this.SendCommand("SIZE " + Path.GetFileName(strFileName));
            if (this.iReplyCode == 213)
            {
                return long.Parse(this.strReply.Substring(4));
            }
            throw new IOException(this.strReply.Substring(4));
        }

        public void Delete(string strFileName)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            this.SendCommand("DELE " + strFileName);
            if (this.iReplyCode != 250)
            {
                throw new IOException(this.strReply.Substring(4));
            }
        }

        public void Rename(string strOldFileName, string strNewFileName)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            this.SendCommand("RNFR " + strOldFileName);
            if (this.iReplyCode != 350)
            {
                throw new IOException(this.strReply.Substring(4));
            }
            this.SendCommand("RNTO " + strNewFileName);
            if (this.iReplyCode != 250)
            {
                throw new IOException(this.strReply.Substring(4));
            }
        }

        public void Get(string strFileNameMask, string strFolder)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            string[] array = this.Dir(strFileNameMask);
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                if (!text.Equals(""))
                {
                    this.Get(text, strFolder, text);
                }
            }
        }

        public void Get(string strRemoteFileName, string strFolder, string strLocalFileName)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            this.SetTransferType(FTPClient.TransferType.Binary);
            if (strLocalFileName.Equals(""))
            {
                strLocalFileName = strRemoteFileName;
            }
            if (!File.Exists(strLocalFileName))
            {
                Stream stream = File.Create(strLocalFileName);
                stream.Close();
            }
            FileStream fileStream = new FileStream(strFolder + "\\" + strLocalFileName, FileMode.Create);
            Socket socket = this.CreateDataSocket();
            this.SendCommand("RETR " + strRemoteFileName);
            if (this.iReplyCode != 150 && this.iReplyCode != 125 && this.iReplyCode != 226 && this.iReplyCode != 250)
            {
                throw new IOException(this.strReply.Substring(4));
            }
            byte[] array = new byte[this.BLOCK_SIZE];
            int num;
            do
            {
                num = socket.Receive(array, array.Length, SocketFlags.None);
                fileStream.Write(array, 0, num);
            }
            while (num > 0);
            fileStream.Close();
            if (socket.Connected)
            {
                socket.Close();
            }
            if (this.iReplyCode != 226 && this.iReplyCode != 250)
            {
                this.ReadReply();
                if (this.iReplyCode != 226 && this.iReplyCode != 250)
                {
                    throw new IOException(this.strReply.Substring(4));
                }
            }
        }

        public void Put(string strFileName, string ftpname, TextBox label1)
        {
            FileInfo fileInfo = new FileInfo(strFileName);
            long length = fileInfo.Length;
            if (!this.bConnected)
            {
                this.Connect();
            }
            Socket socket = this.CreateDataSocket();
            this.SendCommand("STOR " + ftpname);
            if (this.iReplyCode != 125 && this.iReplyCode != 150)
            {
                throw new IOException(this.strReply.Substring(4));
            }
            FileStream fileStream = new FileStream(strFileName, FileMode.Open);
            this.dataqyt = 0;
            byte[] array = new byte[this.BLOCK_SIZE];
            int num;
            while ((num = fileStream.Read(array, 0, array.Length)) > 0)
            {
                socket.Send(array, num, SocketFlags.None);
                this.dataqyt += num;
                label1.Text = ((long)(this.dataqyt * 100) / length).ToString() + "%";
                Application.DoEvents();
            }
            fileStream.Close();
            if (socket.Connected)
            {
                socket.Close();
            }
            if (this.iReplyCode != 226 && this.iReplyCode != 250)
            {
                this.ReadReply();
                if (this.iReplyCode != 226 && this.iReplyCode != 250)
                {
                    throw new IOException(this.strReply.Substring(4));
                }
            }
        }

        public void MkDir(string strDirName)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            this.SendCommand("MKD " + strDirName);
            if (this.iReplyCode != 257)
            {
                throw new IOException(this.strReply.Substring(4));
            }
        }

        public void RmDir(string strDirName)
        {
            if (!this.bConnected)
            {
                this.Connect();
            }
            this.SendCommand("RMD " + strDirName);
            if (this.iReplyCode != 250)
            {
                throw new IOException(this.strReply.Substring(4));
            }
        }

        public void ChDir(string strDirName)
        {
            if (!strDirName.Equals(".") && !strDirName.Equals(""))
            {
                if (!this.bConnected)
                {
                    this.Connect();
                }
                this.SendCommand("CWD " + strDirName);
                if (this.iReplyCode != 250)
                {
                    throw new IOException(this.strReply.Substring(4));
                }
                this.strRemotePath = strDirName;
            }
        }

        private void ReadReply()
        {
            this.strMsg = "";
            this.strReply = this.ReadLine();
            this.iReplyCode = int.Parse(this.strReply.Substring(0, 3));
        }

        private Socket CreateDataSocket()
        {
            this.SendCommand("PASV");
            if (this.iReplyCode != 227)
            {
                throw new IOException(this.strReply.Substring(4));
            }
            int num = this.strReply.IndexOf('(');
            int num2 = this.strReply.IndexOf(')');
            string text = this.strReply.Substring(num + 1, num2 - num - 1);
            int[] array = new int[6];
            int length = text.Length;
            int num3 = 0;
            string text2 = "";
            int num4 = 0;
            while (num4 < length && num3 <= 6)
            {
                char c = char.Parse(text.Substring(num4, 1));
                if (char.IsDigit(c))
                {
                    text2 += c;
                }
                else if (c != ',')
                {
                    throw new IOException("Malformed PASVstrReply: " + this.strReply);
                }
                if (c == ',' || num4 + 1 == length)
                {
                    try
                    {
                        array[num3++] = int.Parse(text2);
                        text2 = "";
                    }
                    catch (Exception)
                    {
                        throw new IOException("Malformed PASV strReply: " + this.strReply);
                    }
                }
                num4++;
            }
            string ipString = string.Concat(new object[]
            {
                array[0],
                ".",
                array[1],
                ".",
                array[2],
                ".",
                array[3]
            });
            int port = (array[4] << 8) + array[5];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ipString), port);
            try
            {
                socket.Connect(remoteEP);
            }
            catch (Exception)
            {
                throw new IOException("Can't connect toremote server");
            }
            return socket;
        }

        private void CloseSocketConnect()
        {
            if (this.socketControl != null)
            {
                this.socketControl.Close();
                this.socketControl = null;
            }
            this.bConnected = false;
        }

        private string ReadLine()
        {
            byte[] array = new byte[this.BLOCK_SIZE];
            int num;
            do
            {
                num = this.socketControl.Receive(array, array.Length, SocketFlags.None);
                this.strMsg += this.ASCII.GetString(array, 0, num);
            }
            while (num >= array.Length);
            char[] separator = new char[]
            {
                '\n'
            };
            string[] array2 = this.strMsg.Split(separator);
            if (this.strMsg.Length > 2)
            {
                this.strMsg = array2[array2.Length - 2];
            }
            else
            {
                this.strMsg = array2[0];
            }
            string result;
            if (!this.strMsg.Substring(3, 1).Equals(" "))
            {
                result = this.ReadLine();
            }
            else
            {
                result = this.strMsg;
            }
            return result;
        }

        private void SendCommand(string strCommand)
        {
            byte[] bytes = Encoding.ASCII.GetBytes((strCommand + "\r\n").ToCharArray());
            this.socketControl.Send(bytes, bytes.Length, SocketFlags.None);
            this.ReadReply();
        }
    }
}
