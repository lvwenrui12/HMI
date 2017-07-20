using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

using rsapp;

namespace rsapp
{
    partial class picselect
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
            this.radioButton1 = new RadioButton();
            this.radioButton2 = new RadioButton();
            this.panel1 = new Panel();
            this.button1 = new ButtonX();
             this.picadmin1 = new picadmin();

            this.panel1.SuspendLayout();

            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图像加载方式:";
            this.label1.Visible = false;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new Point(12, 48);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(47, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "正常";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(65, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(47, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "切图";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.panel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Location = new Point(0, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(245, 45);
            this.panel1.TabIndex = 5;
            this.button1.AccessibleRole = AccessibleRole.PushButton;
            this.button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.button1.ColorTable = eButtonColor.OrangeWithBackground;
            this.button1.Location = new Point(156, 7);
            this.button1.Name = "button1";
            this.button1.Size = new Size(83, 32);
            this.button1.Style = eDotNetBarStyle.Office2003;
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.Click += new EventHandler(this.button1_Click);
            this.picadmin1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.picadmin1.BackColor = SystemColors.MenuHighlight;
            this.picadmin1.Location = new Point(0, 0);
            this.picadmin1.Name = "picadmin1";
            this.picadmin1.Size = new Size(245, 467);
            this.picadmin1.TabIndex = 0;
            this.picadmin1.picselect += new EventHandler(this.picadmin1_picselect);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(246, 509);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.picadmin1);
            this.DoubleBuffered = true;
            base.MaximizeBox = false;
            base.Name = "picselect";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "图片选择";
            base.Load += new EventHandler(this.picselect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion
    }
}