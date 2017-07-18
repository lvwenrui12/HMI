using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hmitype;
using USARTHMI.Properties;

namespace USARTHMI
{
    public partial class logon : Form
    {
      

        private Timer timer2;

        private Label label1;

        private static logon instance;

        private Bitmap bitmap;
      
        public static logon Instance
        {
            get
            {
                return logon.instance;
            }
            set
            {
                logon.instance = value;
            }
        }
        private bool getlogin()
        {
            string text = datasize.linpath + "\\login.jpg";
            bool result;
            try
            {
                if (File.Exists(text))
                {
                    if (File.GetCreationTime(text).AddDays(1.0) < DateTime.Now)
                    {
                        result = false;
                    }
                    else
                    {
                        this.bitmap = new Bitmap(text);
                        result = true;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                Kuozhan.delfile(text);
                result = false;
            }
            return result;
        }

        public logon()
        {
            this.InitializeComponent();
            base.FormBorderStyle = FormBorderStyle.None;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.ShowInTaskbar = false;
            if (datasize.Language == 0)
            {
                if (!this.getlogin())
                {
                    this.bitmap = new Bitmap(Resources.tjclogo);
                }
            }
            else
            {
                this.bitmap = new Bitmap(Resources.iteadlogo);
            }
            base.ClientSize = this.bitmap.Size;
            this.BackgroundImage = this.bitmap;
            this.setmessage("正在检测版本更新...".Language());
        }

        private void setmessage(string str)
        {
            this.label1.AutoSize = true;
            this.label1.Text = str;
            int width = this.label1.Width;
            int height = this.label1.Height;
            this.label1.AutoSize = false;
            this.label1.Width = width;
            this.label1.Height = height + 4;
            this.label1.Location = new Point(2, 2);
        }

      

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.timer2.Enabled = false;
            try
            {
                string path = datasize.linpath + "\\login.jpg";
                datasize.loginjpgurl = null;
                Win32.gethmiver(2500, 5000, 0, 5000, false, false, false, 1);
                while (!datasize.findendstate)
                {
                    Application.DoEvents();
                }
                this.bitmap.Dispose();
                if (File.Exists(path))
                {
                    Kuozhan.delfile(path);
                }
                base.Close();
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void logon_Load(object sender, EventArgs e)
        {
        }
    }
}
