using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using USARTHMI.Properties;

namespace USARTHMI
{
    partial class about
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
            this.Text = "about";

            this.label1 = new Label();
            this.label2 = new Label();
            this.linkLabel1 = new LinkLabel();
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "USART HMI";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "kaifashang";
            this.linkLabel1.Location = new Point(12, 107);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(220, 55);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.pictureBox1.Image = USARTHMI.Properties.Resources.guanyu;
            this.pictureBox1.Location = new Point(238, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(303, 203);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(539, 204);
            base.Controls.Add(this.linkLabel1);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            this.EnableGlass = false;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
         
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "¹ØÓÚ";
            base.Load += new EventHandler(this.about_Load);
            ((ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}