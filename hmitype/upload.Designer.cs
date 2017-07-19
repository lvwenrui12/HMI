using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace hmitype
{
    partial class upload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            this.label2 = new Label();
            this.label4 = new Label();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.label5 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.pictureBox1 = new PictureBox();
            this.linkLabel1 = new LinkLabel();
            this.label9 = new Label();
            this.textBox4 = new TextBox();
            this.timer1 = new Timer(this.components);
            this.label3 = new Label();
            this.textBox5 = new TextBox();
            this.label1 = new Label();
            this.buttonX1 = new ButtonX();
            this.textBox3 = new TextBoxX();
            this.button1 = new ButtonX();
         this.fenlei1 = new fenlei();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.label2.AutoSize = true;
            this.label2.Location = new Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "素材分类:";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(301, 58);
            this.label4.Name = "label4";
            this.label4.Size = new Size(35, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "名称:";
            this.textBox1.BackColor = SystemColors.Window;
            this.textBox1.Location = new Point(340, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(343, 21);
            this.textBox1.TabIndex = 6;
            this.textBox2.ForeColor = Color.Black;
            this.textBox2.Location = new Point(336, 133);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = ScrollBars.Vertical;
            this.textBox2.Size = new Size(347, 129);
            this.textBox2.TabIndex = 8;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(301, 136);
            this.label5.Name = "label5";
            this.label5.Size = new Size(35, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "描述:";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(277, 92);
            this.label7.Name = "label7";
            this.label7.Size = new Size(59, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "上传文件:";
            this.label8.Location = new Point(266, 264);
            this.label8.Name = "label8";
            this.label8.Size = new Size(70, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "上传进度:";
            this.label8.TextAlign = ContentAlignment.MiddleRight;
            this.pictureBox1.BackColor = Color.White;
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.Location = new Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(250, 250);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = Color.White;
            this.linkLabel1.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.linkLabel1.Location = new Point(69, 153);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(120, 16);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "点击选择缩略图";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(12, 294);
            this.label9.Name = "label9";
            this.label9.Size = new Size(41, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "用户名";
            this.textBox4.BackColor = Color.White;
            this.textBox4.BorderStyle = BorderStyle.None;
            this.textBox4.Location = new Point(338, 266);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new Size(240, 40);
            this.textBox4.TabIndex = 23;
            this.timer1.Enabled = true;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.label3.AutoSize = true;
            this.label3.ForeColor = Color.Blue;
            this.label3.Location = new Point(12, 361);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0, 12);
            this.label3.TabIndex = 25;
            this.textBox5.BackColor = Color.White;
            this.textBox5.ForeColor = Color.Black;
            this.textBox5.Location = new Point(12, 312);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new Size(671, 83);
            this.textBox5.TabIndex = 27;
            this.textBox5.Text = "1.通过审核的案列将根据案列质量获得1-20不等的积分，1积分=1元钱，可以在积分消费中直接输入银行账户或者支付宝账户提现，也可以申请转换为积分的1.1倍代金券。\r\n\r\n2.请选择正确的分类上传，否则将无法通过审核，若多次选错分类上传有可能被管理员屏蔽上传功能！\r\n\r\n3.欢迎大家踊跃上传案列，先有我为人人，再有人人为我。\r\n";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(338, 111);
            this.label1.Name = "label1";
            this.label1.Size = new Size(155, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "（请尽量使用rar压缩文件）";
            this.buttonX1.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX1.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new Point(651, 83);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new Size(29, 21);
            this.buttonX1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 29;
            this.buttonX1.Text = "...";
            this.buttonX1.Click += new EventHandler(this.buttonX1_Click);
            this.textBox3.BackColor = SystemColors.Window;
            this.textBox3.Border.Class = "TextBoxBorder";
            this.textBox3.Border.CornerType = eCornerType.Square;
            this.textBox3.Location = new Point(340, 83);
            this.textBox3.Name = "textBox3";
            this.textBox3.PreventEnterBeep = true;
            this.textBox3.Size = new Size(310, 21);
            this.textBox3.TabIndex = 30;
            this.button1.AccessibleRole = AccessibleRole.PushButton;
            this.button1.ColorTable = eButtonColor.OrangeWithBackground;
            this.button1.Location = new Point(584, 266);
            this.button1.Name = "button1";
            this.button1.Size = new Size(99, 40);
            this.button1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.button1.TabIndex = 31;
            this.button1.Text = "上传";
            this.button1.Click += new EventHandler(this.buttonX2_Click);
            this.fenlei1.Location = new Point(72, 10);
            this.fenlei1.Name = "fenlei1";
            this.fenlei1.Size = new Size(664, 20);
            this.fenlei1.TabIndex = 22;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(697, 400);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox3);
            base.Controls.Add(this.buttonX1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.textBox5);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textBox4);
         base.Controls.Add(this.fenlei1);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.linkLabel1);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label2);
            this.EnableGlass = false;
            base.MaximizeBox = false;
            base.Name = "upload";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "upload";
            base.Load += new EventHandler(this.upload_Load);
            ((ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}