using System;
using System.Drawing;
using System.Windows.Forms;

namespace hmitype
{
    partial class fenlei
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

            this.comboBox1 = new ComboBox();
            this.comboBox2 = new ComboBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.comboBox3 = new ComboBox();
            this.label4 = new Label();
            this.comboBox4 = new ComboBox();
            this.label1 = new Label();
            this.panel1 = new Panel();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(106, 20);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new Point(118, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(106, 20);
            this.comboBox2.TabIndex = 24;
            this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(107, 4);
            this.label2.Name = "label2";
            this.label2.Size = new Size(11, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "-";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(225, 5);
            this.label3.Name = "label3";
            this.label3.Size = new Size(11, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "-";
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new Point(236, 0);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(106, 20);
            this.comboBox3.TabIndex = 26;
            this.comboBox3.SelectedIndexChanged += new EventHandler(this.comboBox3_SelectedIndexChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(345, 5);
            this.label4.Name = "label4";
            this.label4.Size = new Size(11, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "-";
            this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new Point(356, 0);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new Size(106, 20);
            this.comboBox4.TabIndex = 28;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new Size(95, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "正在加载分类...";
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(561, 22);
            this.panel1.TabIndex = 31;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.comboBox4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.comboBox3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.comboBox2);
            base.Controls.Add(this.comboBox1);
            base.Name = "fenlei";
            base.Size = new Size(589, 93);
        
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}
