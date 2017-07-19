using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace hmitype
{
    partial class datazhuan
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
            this.label3 = new Label();
            this.timer2 = new Timer(this.components);
            this.timer1 = new Timer(this.components);
            base.SuspendLayout();
            this.label3.AutoSize = true;
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            this.timer2.Enabled = true;
            this.timer2.Interval = 1500;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(377, 51);
            base.Controls.Add(this.label3);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "datazhuan";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "datazhuan";
            base.Load += new EventHandler(this.datazhuan_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}