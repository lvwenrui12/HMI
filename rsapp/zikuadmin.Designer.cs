using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace rsapp
{
    partial class zikuadmin
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

            ComponentResourceManager resources = new ComponentResourceManager(typeof(zikuadmin));
            this.listBox1 = new ListBox();
            this.imageList1 = new ImageList(this.components);
            this.bar1 = new Bar();
            this.buttonItem1 = new ButtonItem();
            this.buttonItem2 = new ButtonItem();
            this.buttonItem8 = new ButtonItem();
            this.buttonItem7 = new ButtonItem();
            this.buttonItem3 = new ButtonItem();
            this.buttonItem4 = new ButtonItem();
            this.buttonItem5 = new ButtonItem();
            this.buttonItem6 = new ButtonItem();
            this.label1 = new LabelItem();
            ((ISupportInitialize)this.bar1).BeginInit();
            base.SuspendLayout();
            this.listBox1.BorderStyle = BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(61, 114);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(210, 144);
            this.listBox1.TabIndex = 50;
            this.listBox1.KeyDown += new KeyEventHandler(this.listBox1_KeyDown);
            this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dec.ico");
            this.imageList1.Images.SetKeyName(1, "up.ico");
            this.imageList1.Images.SetKeyName(2, "tihuan.ico");
            this.imageList1.Images.SetKeyName(3, "add.ico");
            this.imageList1.Images.SetKeyName(4, "down.ico");
            this.imageList1.Images.SetKeyName(5, "del.ico");
            this.imageList1.Images.SetKeyName(6, "insert.ico");
            this.imageList1.Images.SetKeyName(7, "REFBAR.ICO");
            this.bar1.AntiAlias = true;
            this.bar1.Font = new Font("微软雅黑", 9f);
            this.bar1.Images = this.imageList1;
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new BaseItem[]
            {
                this.buttonItem1,
                this.buttonItem2,
                this.buttonItem8,
                this.buttonItem7,
                this.buttonItem3,
                this.buttonItem4,
                this.buttonItem5,
                this.buttonItem6,
                this.label1
            });
            this.bar1.Location = new Point(46, 17);
            this.bar1.Name = "bar1";
            this.bar1.Size = new Size(238, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 60;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            this.buttonItem1.ImageIndex = 3;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            this.buttonItem1.Tooltip = "添加";
            this.buttonItem1.Click += new EventHandler(this.buttonItem1_Click);
            this.buttonItem2.ImageIndex = 0;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            this.buttonItem2.Tooltip = "删除";
            this.buttonItem2.Click += new EventHandler(this.buttonItem2_Click);
            this.buttonItem8.ImageIndex = 2;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Text = "buttonItem5";
            this.buttonItem8.Tooltip = "替换";
            this.buttonItem8.Click += new EventHandler(this.buttonItem8_Click);
            this.buttonItem7.ImageIndex = 6;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Text = "insert";
            this.buttonItem7.Tooltip = "插入";
            this.buttonItem7.Click += new EventHandler(this.buttonItem7_Click);
            this.buttonItem3.ImageIndex = 1;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "buttonItem3";
            this.buttonItem3.Tooltip = "上移";
            this.buttonItem3.Click += new EventHandler(this.buttonItem3_Click);
            this.buttonItem4.ImageIndex = 4;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "buttonItem4";
            this.buttonItem4.Tooltip = "下移";
            this.buttonItem4.Click += new EventHandler(this.buttonItem4_Click);
            this.buttonItem5.ImageIndex = 7;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "buttonItem5";
            this.buttonItem5.Tooltip = "预览";
            this.buttonItem5.Click += new EventHandler(this.buttonItem5_Click);
            this.buttonItem6.ImageIndex = 5;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "buttonItem6";
            this.buttonItem6.Tooltip = "全删";
            this.buttonItem6.Click += new EventHandler(this.buttonItem6_Click);
            this.label1.ItemAlignment = eItemAlignment.Far;
            this.label1.Name = "label1";
            this.label1.Text = "0";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            base.Controls.Add(this.listBox1);
            base.Controls.Add(this.bar1);
            base.Name = "zikuadmin";
            base.Size = new Size(322, 412);
            base.Load += new EventHandler(this.zikuadmin_Load);
            base.Paint += new PaintEventHandler(this.zikuadmin_Paint);
            base.Resize += new EventHandler(this.zikuadmin_Resize);
            ((ISupportInitialize)this.bar1).EndInit();
            base.ResumeLayout(false);
        }

        #endregion


    }
}
