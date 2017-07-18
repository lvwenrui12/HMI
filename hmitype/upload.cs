using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Newtonsoft.Json.Linq;

namespace hmitype
{
    public partial class upload : DevComponents.DotNetBar.OfficeForm
    {
     

        private Label label2;

        private Label label4;

        private TextBox textBox1;

        private TextBox textBox2;

        private Label label5;

        private Label label7;

        private Label label8;

        private PictureBox pictureBox1;

        private LinkLabel linkLabel1;

        private Label label9;

      //  private hmitype.fenlei fenlei1;
       private fenlei fenlei1;

        private TextBox textBox4;

        private Timer timer1;

        private Label label3;

        private TextBox textBox5;

        private Label label1;

        private ButtonX buttonX1;

        private TextBoxX textBox3;

        private ButtonX button1;

        private string suolvtu = "";

        private string bianjiid = "";

        private string bianjipicadd = "";

        private string bianjidataadd = "";

        public upload(string id)
        {
            this.bianjiid = id;
            this.InitializeComponent();
            base.Icon = datasize.Myico;
        }

        private void upload_Load(object sender, EventArgs e)
        {
            this.label9.Text = php.Username;
            this.textBox4.Text = "";
            this.textBox4.ScrollBars = ScrollBars.None;
        }

        private bool uploadfile()
        {
            string text = "";
            int num = 1;
            bool result;
            try
            {
                if (this.fenlei1.getid() == "")
                {
                    MessageOpen.Show("请选择分类".Language());
                    result = false;
                }
                else if (this.textBox1.Text == "")
                {
                    MessageOpen.Show("请输入名称".Language());
                    result = false;
                }
                else
                {
                    if (this.textBox3.Text == "")
                    {
                        if (this.bianjiid == "")
                        {
                            MessageOpen.Show("请选择文件".Language());
                            result = false;
                            return result;
                        }
                    }
                    else if (!File.Exists(this.textBox3.Text))
                    {
                        MessageOpen.Show("找不到文件".Language() + this.textBox3.Text);
                        result = false;
                        return result;
                    }
                    if (this.suolvtu == "")
                    {
                        if (this.bianjiid == "")
                        {
                            MessageOpen.Show("请选择缩略图".Language());
                            result = false;
                            return result;
                        }
                    }
                    if (this.textBox2.Text == "")
                    {
                        this.textBox2.Text = " ";
                    }
                    FTPClient fTPClient = new FTPClient("123.57.231.215", "", "hmiftp", "hmiftp2015", 99);
                    while (!fTPClient.Connected && num >= 0)
                    {
                        text = fTPClient.Connect();
                        num--;
                    }
                    if (!fTPClient.Connected)
                    {
                        this.textBox4.Text = "连接服务器失败 ".Language() + text;
                        result = false;
                    }
                    else
                    {
                        string text2;
                        if (this.suolvtu == "")
                        {
                            text2 = this.bianjipicadd;
                        }
                        else
                        {
                            text2 = php.Userid + "pic" + this.gettimestr() + Path.GetExtension(this.suolvtu);
                            fTPClient.ChDir("pic");
                            if (this.bianjiid != "")
                            {
                                fTPClient.Delete(this.bianjipicadd);
                            }
                            fTPClient.Put(this.suolvtu, text2, this.textBox4);
                        }
                        string text3;
                        if (this.textBox3.Text == "")
                        {
                            text3 = this.bianjidataadd;
                        }
                        else
                        {
                            text3 = php.Userid + "data" + this.gettimestr() + Path.GetExtension(this.textBox3.Text);
                            fTPClient.ChDir("../");
                            fTPClient.ChDir("file");
                            if (this.bianjiid != "")
                            {
                                fTPClient.Delete(this.bianjidataadd);
                            }
                            fTPClient.Put(this.textBox3.Text, text3, this.textBox4);
                        }
                        text = this.fileputphp(text3, text2, this.textBox1.Text, this.fenlei1.getid(), "1", this.textBox2.Text);
                        if (text != "ok")
                        {
                            if (this.textBox3.Text != "")
                            {
                                fTPClient.Delete(text3);
                            }
                            fTPClient.ChDir("../");
                            fTPClient.ChDir("pic");
                            if (this.suolvtu != "")
                            {
                                fTPClient.Delete(text2);
                            }
                            fTPClient.DisConnect();
                            this.textBox4.Text = "创建数据库失败:".Language() + text;
                            this.textBox4.ScrollBars = ScrollBars.Vertical;
                            result = false;
                        }
                        else
                        {
                            this.textBox4.ScrollBars = ScrollBars.None;
                            fTPClient.DisConnect();
                            MessageOpen.Show("上传成功,请等待管理员审核,审核时间1-3个工作日".Language());
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.textBox4.Text = ex.Message;
                result = false;
            }
            return result;
        }

        private string fileputphp(string Filadd, string Picadd, string Name, string Fpath, string Typepath, string Des)
        {
            string result;
            if (this.bianjiid == "")
            {
                result = php.GethttpBack("http://bbs.tjc1688.com/hmi/upfile.php", string.Concat(new string[]
                {
                    php.getsafeMD5(),
                    "&action=add&Filadd=",
                    Filadd,
                    "&Picadd=",
                    Picadd,
                    "&Name=",
                    Name,
                    "&Fpath=",
                    Fpath,
                    "&Typepath=",
                    Typepath,
                    "&Des=",
                    Des
                }));
            }
            else
            {
                result = php.GethttpBack("http://bbs.tjc1688.com/hmi/upfile.php", string.Concat(new string[]
                {
                    php.getsafeMD5(),
                    "&action=edit&id=",
                    this.bianjiid,
                    "&Filadd=",
                    Filadd,
                    "&Picadd=",
                    Picadd,
                    "&Name=",
                    Name,
                    "&Fpath=",
                    Fpath,
                    "&Typepath=",
                    Typepath,
                    "&Des=",
                    Des
                }));
            }
            return result;
        }

        private string gettimestr()
        {
            DateTime now = DateTime.Now;
            return string.Concat(new string[]
            {
                now.Year.ToString(),
                now.Month.ToString(),
                now.Month.ToString(),
                now.Day.ToString(),
                now.Hour.ToString(),
                now.Minute.ToString(),
                now.Second.ToString()
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.opensuolvtu();
        }

        private void opensuolvtu()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "所有文件|*.*".Language();
                openFileDialog.Getpath("ftpslvtu");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Putpath("ftpslvtu");
                    this.pictureBox1.Load(openFileDialog.FileName);
                    this.suolvtu = openFileDialog.FileName;
                    if (this.linkLabel1.Visible)
                    {
                        this.linkLabel1.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.opensuolvtu();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (!this.fenlei1.Reffenlei())
            {
                base.Close();
            }
            else
            {
                if (this.bianjiid != "")
                {
                    JObject jObject = php.getxiangqingjson(this.bianjiid);
                    if (jObject == null)
                    {
                        return;
                    }
                    JToken jToken = jObject.First;
                    for (int i = 0; i < jObject.Count; i++)
                    {
                        if (jToken.Path == "f_user")
                        {
                            php.Username = jObject["f_user"].ToString();
                        }
                        if (jToken.Path == "f_name")
                        {
                            this.textBox1.Text = jObject["f_name"].ToString();
                        }
                        if (jToken.Path == "f_user")
                        {
                            this.textBox2.Text = jObject["f_des"].ToString();
                        }
                        if (jToken.Path == "f_typeid")
                        {
                            this.fenlei1.setid(jObject["f_typeid"].ToString());
                        }
                        if (jToken.Path == "f_image")
                        {
                            this.bianjipicadd = jObject["f_image"].ToString();
                        }
                        if (jToken.Path == "f_file")
                        {
                            this.bianjidataadd = jObject["f_file"].ToString();
                        }
                        jToken = jToken.Next;
                    }
                    this.label9.Text = php.Username;
                }
                this.button1.Enabled = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有文件|*.*".Language();
            openFileDialog.Getpath("ftpupfile");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox3.Text = openFileDialog.FileName;
                openFileDialog.Putpath("ftpupfile");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            if (this.uploadfile())
            {
                if (this.bianjiid != "")
                {
                    base.Close();
                    return;
                }
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.suolvtu = "";
                this.linkLabel1.Visible = true;
                this.pictureBox1.Image = null;
            }
            this.button1.Enabled = true;
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
        }
    }

  
}