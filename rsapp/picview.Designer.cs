using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace rsapp
{
    partial class picview
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.panel1.SuspendLayout();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = Color.Silver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(860, 526);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label1.Location = new Point(250, 127);
            this.label1.Name = "label1";
            this.label1.Size = new Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.pictureBox1.Location = new Point(253, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(322, 219);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = ImageLayout.None;
            base.ClientSize = new Size(884, 550);
            base.Controls.Add(this.panel1);
            base.MaximizeBox = false;
            base.Name = "picview";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "图片预览";
            base.Load += new EventHandler(this.picview_Load);
            base.FormClosed += new FormClosedEventHandler(this.picview_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        #endregion
    }
}