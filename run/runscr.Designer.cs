using System;
using System.Drawing;
using System.Windows.Forms;

namespace run
{
    partial class runscr
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
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.Name = "runscr";
            base.Size = new Size(315, 236);
            base.Load += new EventHandler(this.runscr_Load);
            base.MouseMove += new MouseEventHandler(this.runscr_MouseMove);
            base.MouseDown += new MouseEventHandler(this.runscr_MouseDown);
            base.MouseUp += new MouseEventHandler(this.runscr_MouseUp);
            base.KeyDown += new KeyEventHandler(this.runscr_KeyDown);
            base.ResumeLayout(false);
        }

        #endregion
    }
}
