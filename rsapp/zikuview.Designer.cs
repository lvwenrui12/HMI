using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace rsapp
{
    partial class zikuview
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
            this.pictureBox1 = new PictureBox();
            this.button1 = new Button();
            this.timer1 = new Timer(this.components);
            this.linkLabel1 = new LinkLabel();
            this.linkLabel2 = new LinkLabel();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.button2 = new ButtonX();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.pictureBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.pictureBox1.BackColor = Color.White;
            this.pictureBox1.Location = new Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(552, 410);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.button1.Location = new Point(12, 438);
            this.button1.Name = "button1";
            this.button1.Size = new Size(62, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.timer1.Enabled = true;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.linkLabel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new Point(347, 442);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(41, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "ÉÏÒ»Ò³";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new Point(394, 442);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new Size(41, 12);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "ÏÂÒ»Ò³";
            this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            this.label1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(441, 442);
            this.label1.Name = "label1";
            this.label1.Size = new Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.textBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.textBox1.BackColor = Color.White;
            this.textBox1.Location = new Point(12, 418);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(423, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Visible = false;
            this.button2.AccessibleRole = AccessibleRole.PushButton;
            this.button2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.button2.ColorTable = eButtonColor.OrangeWithBackground;
            this.button2.Location = new Point(441, 418);
            this.button2.Name = "button2";
            this.button2.Size = new Size(111, 23);
            this.button2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.button2.TabIndex = 7;
            this.button2.Text = "ÐÞ¸Ä×Ö¿â";
            this.button2.Visible = false;
            this.button2.Click += new EventHandler(this.button2_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(553, 461);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.linkLabel2);
            base.Controls.Add(this.linkLabel1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.pictureBox1);
            this.EnableGlass = false;
            base.Name = "zikuview";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "×Ö¿âÔ¤ÀÀ";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.zikuview_Load);
            ((ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}