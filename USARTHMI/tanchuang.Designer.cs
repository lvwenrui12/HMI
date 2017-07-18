using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace USARTHMI
{
    partial class tanchuang
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

            this.components = new Container();
            this.webBrowser1 = new WebBrowser();
            this.checkBox1 = new CheckBox();
            this.timer1 = new Timer(this.components);
            base.SuspendLayout();
            this.webBrowser1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.webBrowser1.Location = new Point(0, 0);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new Size(774, 521);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.checkBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(8, 527);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(96, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "下次不再提醒";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.timer1.Interval = 10;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(774, 542);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.webBrowser1);
            this.EnableGlass = false;
            base.MaximizeBox = false;
            base.Name = "tanchuang";
            base.StartPosition = FormStartPosition.CenterScreen;
            base.Load += new EventHandler(this.tanchuang_Load);
            base.ResumeLayout(false);
            base.PerformLayout();

        }

        #endregion
    }
}