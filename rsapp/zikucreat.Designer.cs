using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace rsapp
{
    partial class zikucreat
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
            this.SuspendLayout();
            // 
            // zikucreat
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.DoubleBuffered = true;
            this.Name = "zikucreat";
            this.Text = "×Ö¿âÖÆ×÷¹¤¾ß";
            this.components = new Container();
            this.label1 = new Label();
            this.pictureBoxzi = new PictureBox();
            this.label3 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label4 = new Label();
            this.pictureBoxm = new PictureBox();
            this.groupBox1 = new GroupBox();
            this.comboBox4 = new ComboBoxEx();
            this.comboBox2 = new ComboBoxEx();
            this.label9 = new Label();
            this.label8 = new Label();
            this.pictureBox1 = new PictureBox();
            this.label2 = new Label();
            this.linkLabel1 = new LinkLabel();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new ToolStripMenuItem();
            this.toolStripMenuItem4 = new ToolStripMenuItem();
            this.toolStripMenuItem6 = new ToolStripMenuItem();
            this.toolStripMenuItem8 = new ToolStripMenuItem();
            this.comboBox1 = new ComboBoxEx();
            this.checkBox1 = new CheckBoxX();
            this.comboBox5 = new ComboBoxEx();
            this.textBox1 = new TextBoxX();
            this.button1 = new ButtonX();
            this.textBox2 = new TextBoxX();
            this.comboBoxEx1 = new ComboBoxEx();
            this.toolStripMenuItem10 = new ToolStripMenuItem();
            this.toolStripMenuItem12 = new ToolStripMenuItem();
            ((ISupportInitialize)this.pictureBoxzi).BeginInit();
            ((ISupportInitialize)this.pictureBoxm).BeginInit();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.label1.Location = new Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "×Ö¸ß:";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            this.pictureBoxzi.BackColor = Color.Red;
            this.pictureBoxzi.Location = new Point(13, 59);
            this.pictureBoxzi.Name = "pictureBoxzi";
            this.pictureBoxzi.Size = new Size(26, 20);
            this.pictureBoxzi.TabIndex = 5;
            this.pictureBoxzi.TabStop = false;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(2, 355);
            this.label3.Name = "label3";
            this.label3.Size = new Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label5.Location = new Point(129, 12);
            this.label5.Name = "label5";
            this.label5.Size = new Size(49, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "±àÂë:";
            this.label5.TextAlign = ContentAlignment.MiddleRight;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(65, 206);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0, 12);
            this.label6.TabIndex = 12;
            this.label7.Location = new Point(59, 314);
            this.label7.Name = "label7";
            this.label7.Size = new Size(49, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "·¶Î§:";
            this.label7.TextAlign = ContentAlignment.MiddleRight;
            this.label4.Location = new Point(240, 314);
            this.label4.Name = "label4";
            this.label4.Size = new Size(76, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "×Ö¿âÃû³Æ:";
            this.label4.TextAlign = ContentAlignment.MiddleRight;
            this.pictureBoxm.BackColor = Color.Red;
            this.pictureBoxm.Location = new Point(265, 59);
            this.pictureBoxm.Name = "pictureBoxm";
            this.pictureBoxm.Size = new Size(26, 20);
            this.pictureBoxm.TabIndex = 24;
            this.pictureBoxm.TabStop = false;
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.pictureBoxzi);
            this.groupBox1.Controls.Add(this.pictureBoxm);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Location = new Point(4, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(428, 246);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ô¤ÀÀÇø";
            this.comboBox4.DisplayMember = "Text";
            this.comboBox4.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.ItemHeight = 15;
            this.comboBox4.Location = new Point(265, 32);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new Size(115, 21);
            this.comboBox4.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBox4.TabIndex = 36;
            this.comboBox4.DropDownClosed += new EventHandler(this.comboBox4_DropDownClosed);
            this.comboBox2.DisplayMember = "Text";
            this.comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 15;
            this.comboBox2.Location = new Point(13, 32);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(115, 21);
            this.comboBox2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBox2.TabIndex = 35;
            this.comboBox2.DropDownClosed += new EventHandler(this.comboBox2_DropDownClosed);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(263, 17);
            this.label9.Name = "label9";
            this.label9.Size = new Size(71, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "µ¥×Ö½Ú×Ö·û:";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(11, 17);
            this.label8.Name = "label8";
            this.label8.Size = new Size(71, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "Ë«×Ö½Ú×Ö·û:";
            this.pictureBox1.BackColor = Color.Red;
            this.pictureBox1.Location = new Point(116, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(143, 130);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.label2.Location = new Point(355, 223);
            this.label2.Name = "label2";
            this.label2.Size = new Size(51, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "¼ä¾à:";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.ContextMenuStrip = this.contextMenuStrip1;
            this.linkLabel1.Location = new Point(406, 227);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(11, 12);
            this.linkLabel1.TabIndex = 42;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "0";
            this.linkLabel1.Click += new EventHandler(this.linkLabel1_Click);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
            {
        this.toolStripMenuItem2,
        this.toolStripMenuItem4,
        this.toolStripMenuItem6,
        this.toolStripMenuItem8,
        this.toolStripMenuItem10,
        this.toolStripMenuItem12
            });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(91, 136);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(152, 22);
            this.toolStripMenuItem2.Text = "0";
            this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new Size(152, 22);
            this.toolStripMenuItem4.Text = "2";
            this.toolStripMenuItem4.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new Size(152, 22);
            this.toolStripMenuItem6.Text = "4";
            this.toolStripMenuItem6.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new Size(152, 22);
            this.toolStripMenuItem8.Text = "6";
            this.toolStripMenuItem8.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 15;
            this.comboBox1.Location = new Point(55, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(51, 21);
            this.comboBox1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBox1.TabIndex = 32;
            this.comboBox1.DropDownClosed += new EventHandler(this.comboBox1_DropDownClosed);
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackgroundStyle.CornerType = eCornerType.Square;
            this.checkBox1.Location = new Point(299, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(76, 18);
            this.checkBox1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "×ÖÌå¼Ó´Ö";
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.comboBox5.DisplayMember = "Text";
            this.comboBox5.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.ItemHeight = 15;
            this.comboBox5.Location = new Point(109, 305);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new Size(125, 21);
            this.comboBox5.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBox5.TabIndex = 36;
            this.comboBox5.SelectedIndexChanged += new EventHandler(this.comboBox5_SelectedIndexChanged);
            this.textBox1.Border.Class = "TextBoxBorder";
            this.textBox1.Border.CornerType = eCornerType.Square;
            this.textBox1.Location = new Point(322, 305);
            this.textBox1.Name = "textBox1";
            this.textBox1.PreventEnterBeep = true;
            this.textBox1.Size = new Size(110, 21);
            this.textBox1.TabIndex = 37;
            this.button1.AccessibleRole = AccessibleRole.PushButton;
            this.button1.ColorTable = eButtonColor.OrangeWithBackground;
            this.button1.Location = new Point(322, 332);
            this.button1.Name = "button1";
            this.button1.Size = new Size(110, 35);
            this.button1.Style = eDotNetBarStyle.Office2003;
            this.button1.TabIndex = 38;
            this.button1.Text = "Éú³É×Ö¿â";
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox2.Border.Class = "TextBoxBorder";
            this.textBox2.Border.CornerType = eCornerType.Square;
            this.textBox2.Location = new Point(6, 385);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.PreventEnterBeep = true;
            this.textBox2.ScrollBars = ScrollBars.Vertical;
            this.textBox2.Size = new Size(428, 146);
            this.textBox2.TabIndex = 39;
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 15;
            this.comboBoxEx1.Location = new Point(178, 11);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new Size(115, 21);
            this.comboBoxEx1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 37;
            this.comboBoxEx1.DropDownClosed += new EventHandler(this.comboBoxEx1_DropDownClosed);
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new Size(152, 22);
            this.toolStripMenuItem10.Text = "8";
            this.toolStripMenuItem10.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new Size(152, 22);
            this.toolStripMenuItem12.Text = "10";
            this.toolStripMenuItem12.Click += new EventHandler(this.toolStripMenuItem2_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(436, 535);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.comboBox5);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.comboBoxEx1);
            base.Controls.Add(this.comboBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
          
            base.StartPosition = FormStartPosition.CenterScreen;
         
            base.Load += new EventHandler(this.ziku_Load);
            base.FormClosing += new FormClosingEventHandler(this.zikucreat_FormClosing);
            ((ISupportInitialize)this.pictureBoxzi).EndInit();
            ((ISupportInitialize)this.pictureBoxm).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();

        }

        #endregion
    }
}