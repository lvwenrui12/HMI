using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColList;
using DevComponents.DotNetBar;

namespace rsapp
{
    partial class pageadmin
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
        // rsapp.pageadmin
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageadmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem10 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.label1 = new DevComponents.DotNetBar.LabelItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colListBox1 = new ColList.ColListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(278, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 108);
            this.panel1.TabIndex = 44;
            this.panel1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(-66, -111);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(131, 61);
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dec.bmp");
            this.imageList1.Images.SetKeyName(1, "up.ico");
            this.imageList1.Images.SetKeyName(2, "tihuan.ico");
            this.imageList1.Images.SetKeyName(3, "add.ico");
            this.imageList1.Images.SetKeyName(4, "down.ico");
            this.imageList1.Images.SetKeyName(5, "del.ico");
            this.imageList1.Images.SetKeyName(6, "insert.ico");
            this.imageList1.Images.SetKeyName(7, "dup-file.ico");
            this.imageList1.Images.SetKeyName(8, "jumplist_newtask.ico");
            this.imageList1.Images.SetKeyName(9, "remove-file.ico");
            this.imageList1.Images.SetKeyName(10, "removico.ico");
            this.imageList1.Images.SetKeyName(11, "XSLTFile.ico");
            this.imageList1.Images.SetKeyName(12, "up.ico");
            this.imageList1.Images.SetKeyName(13, "message-2.ico");
            this.imageList1.Images.SetKeyName(14, "page1.ico");
            this.imageList1.Images.SetKeyName(15, "suoding2.ico");
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
            this.buttonItem7,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem8,
            this.buttonItem6,
            this.label1});
            this.bar1.Location = new System.Drawing.Point(3, 3);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(357, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 57;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.AutoExpandOnClick = true;
            this.buttonItem1.ImageIndex = 8;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            this.buttonItem1.Tooltip = "添加";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ImageIndex = 9;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            this.buttonItem2.Tooltip = "删除";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.ImageIndex = 12;
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
            this.buttonItem5.Tooltip = "复制";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // buttonItem8
            // 
            this.buttonItem8.AutoExpandOnClick = true;
            this.buttonItem8.ImageIndex = 13;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem9,
            this.buttonItem10});
            this.buttonItem8.Text = "load";
            this.buttonItem8.Tooltip = "导入/导出页面";
            // 
            // buttonItem9
            // 
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.Text = "导出页面";
            this.buttonItem9.Click += new System.EventHandler(this.buttonItem9_Click);
            // 
            // buttonItem10
            // 
            this.buttonItem10.Name = "buttonItem10";
            this.buttonItem10.Text = "导入页面";
            this.buttonItem10.Click += new System.EventHandler(this.buttonItem10_Click);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.delToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.putToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.suodingToolStripMenuItem,
            this.delallToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 268);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newToolStripMenuItem.Text = "新建";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.delToolStripMenuItem.Text = "删除";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.insertToolStripMenuItem.Text = "插入";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.upToolStripMenuItem.Text = "上移";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.downToolStripMenuItem.Text = "下移";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyToolStripMenuItem.Text = "复制";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.renameToolStripMenuItem.Text = "重命名";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loadToolStripMenuItem.Text = "导入页面";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // putToolStripMenuItem
            // 
            this.putToolStripMenuItem.Name = "putToolStripMenuItem";
            this.putToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.putToolStripMenuItem.Text = "导出页面";
            this.putToolStripMenuItem.Click += new System.EventHandler(this.putToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetToolStripMenuItem.Text = "重置系统页面";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // suodingToolStripMenuItem
            // 
            this.suodingToolStripMenuItem.Name = "suodingToolStripMenuItem";
            this.suodingToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.suodingToolStripMenuItem.Text = "锁定";
            this.suodingToolStripMenuItem.Click += new System.EventHandler(this.suodingToolStripMenuItem_Click);
            // 
            // delallToolStripMenuItem
            // 
            this.delallToolStripMenuItem.Name = "delallToolStripMenuItem";
            this.delallToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.delallToolStripMenuItem.Text = "全删";
            this.delallToolStripMenuItem.Click += new System.EventHandler(this.delallToolStripMenuItem_Click);
            // 
            // colListBox1
            // 
            this.colListBox1.BackColor = System.Drawing.Color.White;
            this.colListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.colListBox1.EditState = false;
            this.colListBox1.idwidth = 16;
            this.colListBox1.imglayout = ((byte)(0));
            this.colListBox1.itembackcolor_select = System.Drawing.Color.Blue;
            this.colListBox1.itembordercolor_move = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(156)))), ((int)(((byte)(5)))));
            this.colListBox1.itembordercolor_select = System.Drawing.Color.Blue;
            this.colListBox1.itemeditenabled = false;
            this.colListBox1.itemfontcolor_defaut = System.Drawing.Color.Black;
            this.colListBox1.itemfontcolor_select = System.Drawing.Color.White;
            this.colListBox1.Itemfontsize = 9;
            this.colListBox1.Itemheight = 16;
            this.colListBox1.itemmovebackcolor1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(154)))));
            this.colListBox1.itemmovestate = true;
            this.colListBox1.Itemschonghui = true;
            this.colListBox1.listbordercolor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.colListBox1.listborderwidth = 1;
            this.colListBox1.Location = new System.Drawing.Point(27, 68);
            this.colListBox1.Name = "colListBox1";
            this.colListBox1.SelectItemindex = -1;
            this.colListBox1.Size = new System.Drawing.Size(146, 206);
            this.colListBox1.TabIndex = 58;
            this.colListBox1.DialogKeyPress += new System.Windows.Forms.KeyEventHandler(this.colListBox1_DialogKeyPress);
            this.colListBox1.ItemSelectChang += new System.EventHandler(this.colListBox1_ItemSelectChang);
            this.colListBox1.ItemDoubleClick += new System.EventHandler(this.colListBox1_ItemDoubleClick);
            this.colListBox1.ItemEditEnd += new ColList.ColListBoxItemEditEventHandler(this.colListBox1_ItemEditEnd);
            // 
            // pageadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.colListBox1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.panel1);
            this.Name = "pageadmin";
            this.Size = new System.Drawing.Size(404, 374);
            this.Load += new System.EventHandler(this.pageadmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.pageadmin_Paint);
            this.Resize += new System.EventHandler(this.pageadmin_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
    }
}
