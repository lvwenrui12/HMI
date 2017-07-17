using DevComponents.DotNetBar;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace hmitype
{
    public class download : OfficeForm
    {
        private IContainer components = null;

        private Label label1;

        private Label label2;

        private Label label3;

        private System.Windows.Forms.Timer timer1;

        private TextBox textBox1;

        private ButtonX button2;

        private ButtonX button1;

        private ButtonX button3;

        private string url = "";

        private string tempexepath = datasize.linpath + "\\temp.exe";

        private urldown urldown1 = new urldown();

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new TextBox();
            this.button2 = new ButtonX();
            this.button1 = new ButtonX();
            this.button3 = new ButtonX();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Location = new Point(300, 52);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "下载进度";
            this.label1.Click += new EventHandler(this.label1_Click);
            this.label2.BackColor = Color.Transparent;
            this.label2.Location = new Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(485, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "select update";
            this.label3.BackColor = Color.Transparent;
            this.label3.Location = new Point(3, 180);
            this.label3.Name = "label3";
            this.label3.Size = new Size(485, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "如果自动下载速度过慢或者出现下载异常，请选择手动打开下载页面";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.Blue;
            this.textBox1.Location = new Point(5, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(272, 140);
            this.textBox1.TabIndex = 6;
            this.button2.AccessibleRole = AccessibleRole.PushButton;
            this.button2.ColorTable = eButtonColor.OrangeWithBackground;
            this.button2.Location = new Point(302, 67);
            this.button2.Name = "button2";
            this.button2.Size = new Size(175, 32);
            this.button2.Style = eDotNetBarStyle.Office2003;
            this.button2.TabIndex = 7;
            this.button2.Text = "自动下载最新程序";
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button1.AccessibleRole = AccessibleRole.PushButton;
            this.button1.ColorTable = eButtonColor.OrangeWithBackground;
            this.button1.Location = new Point(302, 105);
            this.button1.Name = "button1";
            this.button1.Size = new Size(175, 32);
            this.button1.Style = eDotNetBarStyle.Office2003;
            this.button1.TabIndex = 8;
            this.button1.Text = "手动打开下载页面";
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button3.AccessibleRole = AccessibleRole.PushButton;
            this.button3.ColorTable = eButtonColor.OrangeWithBackground;
            this.button3.Location = new Point(302, 143);
            this.button3.Name = "button3";
            this.button3.Size = new Size(175, 32);
            this.button3.Style = eDotNetBarStyle.Office2003;
            this.button3.TabIndex = 9;
            this.button3.Text = "下次再升级";
            this.button3.Click += new EventHandler(this.button3_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(489, 216);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "download";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Update";
            base.Load += new EventHandler(this.download_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);

        public download(string url_)
        {
            this.url = url_;
            this.EnableGlass = false;
            this.InitializeComponent();
            this.label1.Text = "";
            this.Language();
            base.Icon = datasize.Myico;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.label1.Text = "下载进度:".Language();
            this.urldown1.url = this.url;
            this.urldown1.filepath = this.tempexepath;
            this.urldown1.DownStar();
            this.timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kuozhan.Openhttp(datasize.downloadpage);
            Environment.Exit(0);
        }

        private void download_Load(object sender, EventArgs e)
        {
            this.label2.Text = string.Concat(new string[]
            {
                "当前软件版本:".Language(),
                datasize.banbenh.ToString(),
                ".",
                datasize.banbenl.ToString(),
                " ",
                "官方发布最新版本:".Language(),
                datasize.interbanbenh.ToString(),
                ".",
                datasize.interbanbenl.ToString(),
                " ",
                "请选择下载方式:".Language()
            });
            this.textBox1.Text = datasize.uptext;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.label1.Text = "下载进度:".Language() + this.urldown1.filelenth.ToString();
                if (this.urldown1.downok)
                {
                    download.WinExec(this.tempexepath, 1);
                    Thread.Sleep(200);
                    Environment.Exit(0);
                }
                if (this.urldown1.error != "")
                {
                    this.timer1.Enabled = false;
                    this.button2.Enabled = true;
                    this.button3.Enabled = true;
                    MessageOpen.Show("download error!");
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
