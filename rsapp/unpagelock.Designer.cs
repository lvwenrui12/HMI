using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace rsapp
{
    partial class unpagelock
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
            this.textBox1 = new TextBox();
            this.buttonX1 = new ButtonX();
            this.buttonX2 = new ButtonX();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(63, 19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入解锁密码";
            this.textBox1.Location = new Point(65, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new Size(195, 21);
            this.textBox1.TabIndex = 2;
            this.buttonX1.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX1.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new Point(243, 68);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new Size(94, 33);
            this.buttonX1.Style = eDotNetBarStyle.Office2003;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new EventHandler(this.buttonX1_Click);
            this.buttonX2.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX2.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new Point(143, 68);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new Size(94, 33);
            this.buttonX2.Style = eDotNetBarStyle.Office2003;
            this.buttonX2.TabIndex = 5;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new EventHandler(this.buttonX2_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(344, 110);
            base.Controls.Add(this.buttonX2);
            base.Controls.Add(this.buttonX1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.Name = "unpagelock";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "pagelock";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}