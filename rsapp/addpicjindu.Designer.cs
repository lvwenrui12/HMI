using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace rsapp
{
    partial class addpicjindu
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
            this.timer1 = new Timer(this.components);
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.Blue;
            this.label1.Location = new Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ÃÌº”Õº∆¨";
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(194, 217, 247);
            base.ClientSize = new Size(390, 95);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "addpicjindu";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ÃÌº”Õº∆¨";
            base.Load += new EventHandler(this.addpicjindu_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}