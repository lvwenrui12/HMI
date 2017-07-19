using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace USARTHMI
{
    partial class USARTUP
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
            this.com1 = new SerialPort(this.components);
            this.label2 = new Label();
            this.label4 = new Label();
            this.label7 = new Label();
            this.textBox2 = new TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox3 = new ComboBoxEx();
            this.comboBox2 = new ComboBoxEx();
            this.button3 = new ButtonX();
            this.button2 = new ButtonX();
            this.checkBox3 = new CheckBox();
            base.SuspendLayout();
            this.com1.WriteBufferSize = 204800;
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Location = new Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label4.Location = new Point(15, 31);
            this.label4.Name = "label4";
            this.label4.Size = new Size(66, 12);
            this.label4.TabIndex = 165;
            this.label4.Text = "串口号:";
            this.label4.TextAlign = ContentAlignment.MiddleRight;
            this.label7.Location = new Point(217, 31);
            this.label7.Name = "label7";
            this.label7.Size = new Size(149, 12);
            this.label7.TabIndex = 167;
            this.label7.Text = "下载使用的波特率:";
            this.label7.TextAlign = ContentAlignment.MiddleRight;
            this.textBox2.BackColor = Color.White;
            this.textBox2.BorderStyle = BorderStyle.FixedSingle;
            this.textBox2.Location = new Point(10, 78);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = ScrollBars.Vertical;
            this.textBox2.Size = new Size(567, 152);
            this.textBox2.TabIndex = 168;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.comboBox3.DisplayMember = "Text";
            this.comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.ItemHeight = 15;
            this.comboBox3.Location = new Point(84, 22);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(127, 21);
            this.comboBox3.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBox3.TabIndex = 171;
            this.comboBox2.DisplayMember = "Text";
            this.comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 15;
            this.comboBox2.Location = new Point(372, 22);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(127, 21);
            this.comboBox2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBox2.TabIndex = 172;
            this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
            this.button3.AccessibleRole = AccessibleRole.PushButton;
            this.button3.ColorTable = eButtonColor.OrangeWithBackground;
            this.button3.Location = new Point(367, 237);
            this.button3.Name = "button3";
            this.button3.Size = new Size(131, 32);
            this.button3.Style = eDotNetBarStyle.Office2003;
            this.button3.TabIndex = 173;
            this.button3.Text = "联机并开始下载";
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button2.AccessibleRole = AccessibleRole.PushButton;
            this.button2.ColorTable = eButtonColor.OrangeWithBackground;
            this.button2.Location = new Point(504, 237);
            this.button2.Name = "button2";
            this.button2.Size = new Size(73, 32);
            this.button2.Style = eDotNetBarStyle.Office2003;
            this.button2.TabIndex = 174;
            this.button2.Text = "退出";
            this.button2.Click += new EventHandler(this.button2_Click);
            this.checkBox3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new Point(372, 56);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(90, 16);
            this.checkBox3.TabIndex = 191;
            this.checkBox3.Text = "自动加入CRC";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(194, 217, 247);
            base.ClientSize = new Size(583, 273);
            base.Controls.Add(this.checkBox3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.comboBox2);
            base.Controls.Add(this.comboBox3);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "USARTUP";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "串口下载";
            base.Load += new EventHandler(this.USARTUP_Load);
            base.FormClosing += new FormClosingEventHandler(this.USARTUP_FormClosing);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}