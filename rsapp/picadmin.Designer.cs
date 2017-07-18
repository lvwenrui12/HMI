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
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(picadmin));
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new ToolStripMenuItem();
            this.toolStripMenuItem2 = new ToolStripMenuItem();
            this.toolStripMenuItem3 = new ToolStripMenuItem();
            this.toolStripMenuItem4 = new ToolStripMenuItem();
            this.daochuToolStripMenuItem = new ToolStripMenuItem();
            this.quansahnToolStripMenuItem = new ToolStripMenuItem();
            this.bar1 = new Bar();
            this.imageList1 = new ImageList(this.components);
            this.buttonItem1 = new ButtonItem();
            this.buttonItem2 = new ButtonItem();
            this.buttonItem5 = new ButtonItem();
            this.buttonItem7 = new ButtonItem();
            this.buttonItem3 = new ButtonItem();
            this.buttonItem4 = new ButtonItem();
            this.buttonItem6 = new ButtonItem();
            this.label1 = new LabelItem();
            this.pictureBox1 = new PictureBox();
            this.toolStripButton1 = new ToolStripButton();
            this.controlContainerItem1 = new ControlContainerItem();
            this.panel1 = new Colpanel.Colpanel();
            this.contextMenuStrip1.SuspendLayout();
            ((ISupportInitialize)this.bar1).BeginInit();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.toolStripMenuItem1,
                this.toolStripMenuItem2,
                this.toolStripMenuItem3,
                this.toolStripMenuItem4,
                this.daochuToolStripMenuItem,
                this.quansahnToolStripMenuItem
            });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(101, 136);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(100, 22);
            this.toolStripMenuItem1.Text = "添加";
            this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(100, 22);
            this.toolStripMenuItem2.Text = "删除";
            this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size(100, 22);
            this.toolStripMenuItem3.Text = "插入";
            this.toolStripMenuItem3.Click += new EventHandler(this.toolStripMenuItem3_Click);
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new Size(100, 22);
            this.toolStripMenuItem4.Text = "替换";
            this.toolStripMenuItem4.Click += new EventHandler(this.toolStripMenuItem4_Click);
            this.daochuToolStripMenuItem.Name = "daochuToolStripMenuItem";
            this.daochuToolStripMenuItem.Size = new Size(100, 22);
            this.daochuToolStripMenuItem.Text = "导出";
            this.daochuToolStripMenuItem.Click += new EventHandler(this.daochuToolStripMenuItem_Click);
            this.quansahnToolStripMenuItem.Name = "quansahnToolStripMenuItem";
            this.quansahnToolStripMenuItem.Size = new Size(100, 22);
            this.quansahnToolStripMenuItem.Text = "全删";
            this.quansahnToolStripMenuItem.Click += new EventHandler(this.quansahnToolStripMenuItem_Click);
            this.bar1.AntiAlias = true;
            this.bar1.Font = new Font("微软雅黑", 9f);
            this.bar1.Images = this.imageList1;
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new BaseItem[]
            {
                this.buttonItem1,
                this.buttonItem2,
                this.buttonItem5,
                this.buttonItem7,
                this.buttonItem3,
                this.buttonItem4,
                this.buttonItem6,
                this.label1
            });
            this.bar1.Location = new Point(17, 3);
            this.bar1.Name = "bar1";
            this.bar1.Size = new Size(231, 25);
            this.bar1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 56;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            this.imageList1.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dec.ico");
            this.imageList1.Images.SetKeyName(1, "up.ico");
            this.imageList1.Images.SetKeyName(2, "tihuan.ico");
            this.imageList1.Images.SetKeyName(3, "add.ico");
            this.imageList1.Images.SetKeyName(4, "down.ico");
            this.imageList1.Images.SetKeyName(5, "del.ico");
            this.imageList1.Images.SetKeyName(6, "insert.ico");
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
            this.buttonItem5.ImageIndex = 2;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "buttonItem5";
            this.buttonItem5.Tooltip = "替换";
            this.buttonItem5.Click += new EventHandler(this.buttonItem5_Click);
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
            this.buttonItem6.ImageIndex = 5;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "buttonItem6";
            this.buttonItem6.Tooltip = "全删";
            this.buttonItem6.Click += new EventHandler(this.buttonItem6_Click);
            this.label1.ItemAlignment = eItemAlignment.Far;
            this.label1.Name = "label1";
            this.label1.Text = "0";
            this.pictureBox1.Location = new Point(495, 219);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(41, 67);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            this.toolStripButton1.Image = (Image)componentResourceManager.GetObject("toolStripButton1.Image");
            this.toolStripButton1.ImageTransparentColor = Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new Size(123, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.controlContainerItem1.AllowItemResize = true;
            this.controlContainerItem1.MenuVisibility = eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            this.panel1.AutoScroll = true;
            this.panel1.DisabledBackColor = Color.Empty;
            this.panel1.Location = new Point(17, 119);
            this.panel1.Name = "panel1";
            this.panel1.objrefstate = false;
            this.panel1.Size = new Size(290, 105);
            this.panel1.Style.BackColor1.Color = Color.White;
            this.panel1.Style.BackColor2.Color = Color.White;
            this.panel1.TabIndex = 44;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.bar1);
            base.Controls.Add(this.pictureBox1);
            base.Name = "picadmin";
            base.Size = new Size(325, 478);
            base.Load += new EventHandler(this.picadmin_Load);
            base.Paint += new PaintEventHandler(this.picadmin_Paint);
            base.Resize += new EventHandler(this.picadmin_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((ISupportInitialize)this.bar1).EndInit();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);

        }

        #endregion
    }
}
