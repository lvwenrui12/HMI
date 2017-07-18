using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace USARTHMI
{
    partial class sysset
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
          
            this.metroTileItem0 = new MetroTileItem();
            this.metroTileItem1 = new MetroTileItem();
            this.metroTileItem2 = new MetroTileItem();
            this.buttonX1 = new ButtonX();
            this.buttonX2 = new ButtonX();
            this.superTabControl2 = new SuperTabControl();
            this.superTabControlPanel1 = new SuperTabControlPanel();
            this.checkBox15 = new CheckBox();
            this.checkBox5 = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.checkBox14 = new CheckBox();
            this.checkBox13 = new CheckBox();
            this.checkBox12 = new CheckBox();
            this.checkBox11 = new CheckBox();
            this.groupBox1 = new GroupBox();
            this.checkBox4 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.superTabItem1 = new SuperTabItem();
            this.tem0 = new MetroTileItem();
            this.itemshow0 = new MetroTileItem();
            this.itemshow1 = new MetroTileItem();
            this.itemshow2 = new MetroTileItem();
            this.itemshow3 = new MetroTileItem();
            this.metroTileItem6 = new MetroTileItem();
            this.metroTileItem8 = new MetroTileItem();
            this.timer1 = new Timer(this.components);
            ((ISupportInitialize)this.superTabControl2).BeginInit();
            this.superTabControl2.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.metroTileItem0.Name = "metroTileItem0";
            this.metroTileItem0.SymbolColor = Color.Empty;
            this.metroTileItem0.TileColor = eMetroTileColor.Default;
            this.metroTileItem0.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.SymbolColor = Color.Empty;
            this.metroTileItem1.TileColor = eMetroTileColor.Default;
            this.metroTileItem1.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.SymbolColor = Color.Empty;
            this.metroTileItem2.TileColor = eMetroTileColor.Default;
            this.metroTileItem2.TileStyle.CornerType = eCornerType.Square;
            this.buttonX1.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX1.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new Point(750, 543);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new Size(104, 28);
            this.buttonX1.Style = eDotNetBarStyle.Office2003;
            this.buttonX1.TabIndex = 31;
            this.buttonX1.Text = "Cancel";
            this.buttonX1.Click += new EventHandler(this.buttonX1_Click);
            this.buttonX2.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX2.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new Point(640, 543);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new Size(104, 28);
            this.buttonX2.Style = eDotNetBarStyle.Office2003;
            this.buttonX2.TabIndex = 35;
            this.buttonX2.Text = "OK";
            this.buttonX2.Click += new EventHandler(this.buttonX2_Click);
            this.superTabControl2.BackColor = Color.White;
            this.superTabControl2.ControlBox.CloseBox.Name = "";
            this.superTabControl2.ControlBox.MenuBox.Name = "";
            this.superTabControl2.ControlBox.Name = "";
            this.superTabControl2.ControlBox.SubItems.AddRange(new BaseItem[]
            {
                this.superTabControl2.ControlBox.MenuBox,
                this.superTabControl2.ControlBox.CloseBox
            });
            this.superTabControl2.Controls.Add(this.superTabControlPanel1);
            this.superTabControl2.FixedTabSize = new Size(70, 0);
            this.superTabControl2.ForeColor = Color.Black;
            this.superTabControl2.Location = new Point(0, 0);
            this.superTabControl2.Name = "superTabControl2";
            this.superTabControl2.ReorderTabsEnabled = true;
            this.superTabControl2.SelectedTabFont = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.superTabControl2.SelectedTabIndex = 0;
            this.superTabControl2.Size = new Size(865, 537);
            this.superTabControl2.TabAlignment = eTabStripAlignment.Left;
            this.superTabControl2.TabFont = new Font("Segoe UI", 9f);
            this.superTabControl2.TabIndex = 39;
            this.superTabControl2.Tabs.AddRange(new BaseItem[]
            {
                this.superTabItem1
            });
            this.superTabControl2.TabStyle = eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl2.TabVerticalSpacing = 3;
            this.superTabControl2.Text = "superTabControl2";
            this.superTabControlPanel1.Controls.Add(this.checkBox15);
            this.superTabControlPanel1.Controls.Add(this.checkBox5);
            this.superTabControlPanel1.Controls.Add(this.groupBox2);
            this.superTabControlPanel1.Controls.Add(this.groupBox1);
            this.superTabControlPanel1.Dock = DockStyle.Fill;
            this.superTabControlPanel1.Location = new Point(72, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new Size(793, 537);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new Point(404, 21);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new Size(120, 16);
            this.checkBox15.TabIndex = 5;
            this.checkBox15.Text = "调试页面代码高亮";
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new Point(28, 21);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new Size(120, 16);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "编辑页面代码高亮";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.checkBox14);
            this.groupBox2.Controls.Add(this.checkBox13);
            this.groupBox2.Controls.Add(this.checkBox12);
            this.groupBox2.Controls.Add(this.checkBox11);
            this.groupBox2.Location = new Point(398, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(370, 108);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "              ";
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new Point(24, 82);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new Size(96, 16);
            this.checkBox14.TabIndex = 4;
            this.checkBox14.Text = "鼠标悬停提示";
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new Point(24, 55);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new Size(96, 16);
            this.checkBox13.TabIndex = 3;
            this.checkBox13.Text = "指令参数提示";
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new Point(24, 29);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new Size(132, 16);
            this.checkBox12.TabIndex = 2;
            this.checkBox12.Text = "键盘输入关键字提示";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new Point(6, 0);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new Size(168, 16);
            this.checkBox11.TabIndex = 1;
            this.checkBox11.Text = "调试页面代码区提示总开关";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new EventHandler(this.checkBox11_CheckedChanged);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new Point(22, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(370, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "              ";
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new Point(23, 82);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(96, 16);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "鼠标悬停提示";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new Point(23, 55);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(96, 16);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "指令参数提示";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new Point(23, 29);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(132, 16);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "键盘输入关键字提示";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(6, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(168, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "编辑页面代码区提示总开关";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "系统";
            this.tem0.Name = "tem0";
            this.tem0.SymbolColor = Color.Empty;
            this.tem0.TileColor = eMetroTileColor.Gray;
            this.tem0.TileSize = new Size(380, 55);
            this.tem0.TileStyle.CornerType = eCornerType.Square;
            this.tem0.TitleText = "TJC3224T022_011";
            this.tem0.TitleTextAlignment = ContentAlignment.TopLeft;
            this.tem0.TitleTextFont = new Font("宋体", 18f);
            this.itemshow0.Name = "itemshow0";
            this.itemshow0.SymbolColor = Color.Empty;
            this.itemshow0.TileColor = eMetroTileColor.Default;
            this.itemshow0.TileStyle.CornerType = eCornerType.Square;
            this.itemshow1.Name = "itemshow1";
            this.itemshow1.SymbolColor = Color.Empty;
            this.itemshow1.TileColor = eMetroTileColor.Default;
            this.itemshow1.TileStyle.CornerType = eCornerType.Square;
            this.itemshow2.Name = "itemshow2";
            this.itemshow2.SymbolColor = Color.Empty;
            this.itemshow2.TileColor = eMetroTileColor.Default;
            this.itemshow2.TileStyle.CornerType = eCornerType.Square;
            this.itemshow3.Name = "itemshow3";
            this.itemshow3.SymbolColor = Color.Empty;
            this.itemshow3.TileColor = eMetroTileColor.Default;
            this.itemshow3.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem6.Name = "metroTileItem6";
            this.metroTileItem6.SymbolColor = Color.Empty;
            this.metroTileItem6.TileColor = eMetroTileColor.Default;
            this.metroTileItem6.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem8.Name = "metroTileItem8";
            this.metroTileItem8.SymbolColor = Color.Empty;
            this.metroTileItem8.TileColor = eMetroTileColor.Default;
            this.metroTileItem8.TileStyle.CornerType = eCornerType.Square;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(865, 576);
            base.Controls.Add(this.superTabControl2);
            base.Controls.Add(this.buttonX2);
            base.Controls.Add(this.buttonX1);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "sysset";
            base.ShowIcon = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "设置";
            base.Load += new EventHandler(this.Form1_Load);
            ((ISupportInitialize)this.superTabControl2).EndInit();
            this.superTabControl2.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion
    }
}