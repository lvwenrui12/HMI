using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace rsapp
{
    partial class pagelock
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new Label();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.buttonX1 = new ButtonX();
            this.buttonX2 = new ButtonX();
            this.label3 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(19, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(287, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入锁定密码(任意长度任意字符,留空为无需密码)";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new Size(113, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请再次输入锁定密码";
            this.textBox1.Location = new Point(21, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new Size(195, 21);
            this.textBox1.TabIndex = 2;
            this.textBox2.Location = new Point(21, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new Size(195, 21);
            this.textBox2.TabIndex = 3;
            this.buttonX1.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX1.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new Point(326, 117);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new Size(94, 33);
            this.buttonX1.Style = eDotNetBarStyle.Office2003;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new EventHandler(this.buttonX1_Click);
            this.buttonX2.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX2.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new Point(226, 117);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new Size(94, 33);
            this.buttonX2.Style = eDotNetBarStyle.Office2003;
            this.buttonX2.TabIndex = 5;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new EventHandler(this.buttonX2_Click);
            this.label3.AutoSize = true;
            this.label3.ForeColor = Color.Blue;
            this.label3.Location = new Point(19, 98);
            this.label3.Name = "label3";
            this.label3.Size = new Size(143, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "请务必妥善保管您的密码!";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(426, 157);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.buttonX2);
            base.Controls.Add(this.buttonX1);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.Name = "pagelock";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "pagelock";
            base.Load += new EventHandler(this.pagelock_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}