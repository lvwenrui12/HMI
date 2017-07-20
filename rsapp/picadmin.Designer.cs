using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace rsapp
{
    partial class picadmin
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
        // rsapp.picadmin
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(picadmin));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.daochuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quansahnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.label1 = new DevComponents.DotNetBar.LabelItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.panel1 = new Colpanel.Colpanel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.daochuToolStripMenuItem,
            this.quansahnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 136);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "添加";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "删除";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "插入";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem4.Text = "替换";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // daochuToolStripMenuItem
            // 
            this.daochuToolStripMenuItem.Name = "daochuToolStripMenuItem";
            this.daochuToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.daochuToolStripMenuItem.Text = "导出";
            this.daochuToolStripMenuItem.Click += new System.EventHandler(this.daochuToolStripMenuItem_Click);
            // 
            // quansahnToolStripMenuItem
            // 
            this.quansahnToolStripMenuItem.Name = "quansahnToolStripMenuItem";
            this.quansahnToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.quansahnToolStripMenuItem.Text = "全删";
            this.quansahnToolStripMenuItem.Click += new System.EventHandler(this.quansahnToolStripMenuItem_Click);
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
            this.buttonItem5,
            this.buttonItem7,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem6,
            this.label1});
            this.bar1.Location = new System.Drawing.Point(17, 3);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(231, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 56;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
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
            // buttonItem5
            // 
            this.buttonItem5.ImageIndex = 2;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "buttonItem5";
            this.buttonItem5.Tooltip = "替换";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
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
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(123, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = true;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel1.Location = new System.Drawing.Point(17, 119);
            this.panel1.Name = "panel1";
            this.panel1.objrefstate = false;
            this.panel1.Size = new System.Drawing.Size(290, 105);
            this.panel1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panel1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panel1.TabIndex = 44;
            // 
            // picadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bar1);
            this.Name = "picadmin";
            this.Size = new System.Drawing.Size(325, 478);
            this.Load += new System.EventHandler(this.picadmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.picadmin_Paint);
            this.Resize += new System.EventHandler(this.picadmin_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
    }
}
