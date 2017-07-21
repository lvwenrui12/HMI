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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(zikuadmin));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.label1 = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(61, 114);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(210, 144);
            this.listBox1.TabIndex = 50;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dec.ico");
            this.imageList1.Images.SetKeyName(1, "up.ico");
            this.imageList1.Images.SetKeyName(2, "tihuan.ico");
            this.imageList1.Images.SetKeyName(3, "add.ico");
            this.imageList1.Images.SetKeyName(4, "down.ico");
            this.imageList1.Images.SetKeyName(5, "del.ico");
            this.imageList1.Images.SetKeyName(6, "insert.ico");
            this.imageList1.Images.SetKeyName(7, "REFBAR.ico");
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.Images = this.imageList1;
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem8,
            this.buttonItem7,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem6,
            this.label1});
            this.bar1.Location = new System.Drawing.Point(46, 17);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(238, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 60;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ImageIndex = 3;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            this.buttonItem1.Tooltip = "添加";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ImageIndex = 0;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            this.buttonItem2.Tooltip = "删除";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem8
            // 
            this.buttonItem8.ImageIndex = 2;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Text = "buttonItem5";
            this.buttonItem8.Tooltip = "替换";
            this.buttonItem8.Click += new System.EventHandler(this.buttonItem8_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.ImageIndex = 6;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Text = "insert";
            this.buttonItem7.Tooltip = "插入";
            this.buttonItem7.Click += new System.EventHandler(this.buttonItem7_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ImageIndex = 1;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "buttonItem3";
            this.buttonItem3.Tooltip = "上移";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.ImageIndex = 4;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "buttonItem4";
            this.buttonItem4.Tooltip = "下移";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // buttonItem5
            // 
            this.buttonItem5.ImageIndex = 7;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "buttonItem5";
            this.buttonItem5.Tooltip = "预览";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // buttonItem6
            // 
            this.buttonItem6.ImageIndex = 5;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "buttonItem6";
            this.buttonItem6.Tooltip = "全删";
            this.buttonItem6.Click += new System.EventHandler(this.buttonItem6_Click);
            // 
            // label1
            // 
            this.label1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.label1.Name = "label1";
            this.label1.Text = "0";
            // 
            // zikuadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bar1);
            this.Name = "zikuadmin";
            this.Size = new System.Drawing.Size(322, 412);
            this.Load += new System.EventHandler(this.zikuadmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.zikuadmin_Paint);
            this.Resize += new System.EventHandler(this.zikuadmin_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


    }
}
