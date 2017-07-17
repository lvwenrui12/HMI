using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace hmitype
{
    partial class progform
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
            this.Text = "progform";

            this.progressBarX1 = new ProgressBarX();
            base.SuspendLayout();
            this.progressBarX1.BackgroundStyle.BackColor = Color.FromArgb(255, 255, 255);
            this.progressBarX1.BackgroundStyle.BackColor2 = Color.FromArgb(255, 255, 255);
            this.progressBarX1.BackgroundStyle.CornerType = eCornerType.Square;
            this.progressBarX1.BackgroundStyle.Font = new Font("宋体", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.progressBarX1.BackgroundStyle.TextAlignment = eStyleTextAlignment.Center;
            this.progressBarX1.BackgroundStyle.TextColor = Color.Black;
            this.progressBarX1.Location = new Point(2, 5);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new Size(500, 40);
            this.progressBarX1.Style = eDotNetBarStyle.Office2003;
            this.progressBarX1.TabIndex = 182;
            this.progressBarX1.Text = "Load data.....";
            this.progressBarX1.TextVisible = true;
            this.progressBarX1.Value = 50;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(535, 59);
            base.Controls.Add(this.progressBarX1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "progform";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "progform";
            base.TopMost = true;
            base.Load += new EventHandler(this.progform_Load);
            base.ResumeLayout(false);
        }

        #endregion
    }
}