using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace USARTHMI
{
    partial class logon
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
          

            if (disposing && this.components != null)
            {
                if (this.bitmap != null)
                {
                    this.bitmap.Dispose();
                    this.bitmap = null;
                }
                this.components.Dispose();
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

            this.timer2 = new Timer(this.components);
            this.label1 = new Label();
            base.SuspendLayout();
            this.timer2.Enabled = true;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            this.label1.BackColor = Color.White;
            this.label1.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label1.Location = new Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new Size(49, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(284, 262);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "logon";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "logon";
            base.Load += new EventHandler(this.logon_Load);
            base.ResumeLayout(false);
        }

        #endregion
    }
}