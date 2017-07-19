using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace run
{
    partial class objedit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(objedit));
            this.label1 = new Label();
            this.label2 = new Label();
            this.imageList1 = new ImageList(this.components);
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            this.imageList1.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "lockpic-64.png");
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(72, 149, 253);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "objedit";
            base.Load += new EventHandler(this.objedit_Load);
            base.PreviewKeyDown += new PreviewKeyDownEventHandler(this.objedit_PreviewKeyDown);
            base.MouseMove += new MouseEventHandler(this.objedit_MouseMove);
            base.KeyUp += new KeyEventHandler(this.objedit_KeyUp);
            base.MouseDown += new MouseEventHandler(this.objedit_MouseDown);
            base.MouseUp += new MouseEventHandler(this.objedit_MouseUp);
            base.KeyDown += new KeyEventHandler(this.objedit_KeyDown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}
