using System;
using System.Drawing;
using System.Windows.Forms;

namespace hmitype
{
    partial class TopMessage
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
            this.timer1 = new Timer(this.components);
            this.timer2 = new Timer(this.components);
            base.SuspendLayout();
            this.timer1.Interval = 5;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(255, 255, 230);
            base.ClientSize = new Size(267, 189);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "TopMessage";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            this.Text = "TopMessage";
            base.TopMost = true;
            base.Load += new EventHandler(this.TopMessage_Load);
            base.Paint += new PaintEventHandler(this.TopMessage_Paint);
            base.ResumeLayout(false);



        }

        #endregion
    }
}