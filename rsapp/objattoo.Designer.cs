using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ICSharpCode.TextEditor;

namespace rsapp
{
    partial class objattoo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(objattoo));
            this.label2 = new System.Windows.Forms.Label();
            this.labetextBox1l1 = new System.Windows.Forms.Label();
            this.tabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel0 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.textBox1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TabItem0 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.TabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.TabItem7 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.TabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.TabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.TabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.TabItem6 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.TabItem5 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel16 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zhantieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.superTabControlPanel0.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "(后初始化事件在所有控件刷新显示之后执行)";
            // 
            // labetextBox1l1
            // 
            this.labetextBox1l1.AutoSize = true;
            this.labetextBox1l1.BackColor = System.Drawing.Color.Transparent;
            this.labetextBox1l1.Location = new System.Drawing.Point(3, 29);
            this.labetextBox1l1.Name = "labetextBox1l1";
            this.labetextBox1l1.Size = new System.Drawing.Size(53, 12);
            this.labetextBox1l1.TabIndex = 2;
            this.labetextBox1l1.Text = "用户代码";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabControl1.ControlBox.MenuBox.Name = "";
            this.tabControl1.ControlBox.Name = "";
            this.tabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabControl1.ControlBox.MenuBox,
            this.tabControl1.ControlBox.CloseBox});
            this.tabControl1.Controls.Add(this.superTabControlPanel0);
            this.tabControl1.Controls.Add(this.superTabControlPanel1);
            this.tabControl1.Controls.Add(this.superTabControlPanel7);
            this.tabControl1.Controls.Add(this.superTabControlPanel2);
            this.tabControl1.Controls.Add(this.superTabControlPanel4);
            this.tabControl1.Controls.Add(this.superTabControlPanel3);
            this.tabControl1.Controls.Add(this.superTabControlPanel6);
            this.tabControl1.Controls.Add(this.superTabControlPanel5);
            this.tabControl1.FixedTabSize = new System.Drawing.Size(70, 0);
            this.tabControl1.Location = new System.Drawing.Point(3, 137);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.ReorderTabsEnabled = true;
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 242);
            this.tabControl1.TabFont = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit;
            this.tabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TabItem0,
            this.TabItem1,
            this.TabItem2,
            this.TabItem3,
            this.TabItem4,
            this.TabItem5,
            this.TabItem6,
            this.TabItem7});
            this.tabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.tabControl1.TabVerticalSpacing = 3;
            this.tabControl1.Text = "superTabControl2";
            this.tabControl1.SelectedTabChanging += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangingEventArgs>(this.tabControl1_SelectedTabChanging);
            this.tabControl1.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tabControl1_SelectedTabChanged);
            // 
            // superTabControlPanel0
            // 
            this.superTabControlPanel0.Controls.Add(this.textBox1);
            this.superTabControlPanel0.Controls.Add(this.checkBox1);
            this.superTabControlPanel0.Controls.Add(this.labetextBox1l1);
            this.superTabControlPanel0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel0.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel0.Name = "superTabControlPanel0";
            this.superTabControlPanel0.Size = new System.Drawing.Size(629, 242);
            this.superTabControlPanel0.TabIndex = 1;
            this.superTabControlPanel0.TabItem = this.TabItem0;
            // 
            // textBox1
            // 
            this.textBox1.AutoScroll = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Encoding = ((System.Text.Encoding)(resources.GetObject("textBox1.Encoding")));
            this.textBox1.IsIconBarVisible = false;
            this.textBox1.Location = new System.Drawing.Point(142, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShowEOLMarkers = true;
            this.textBox1.ShowInvalidLines = false;
            this.textBox1.ShowSpaces = true;
            this.textBox1.ShowTabs = true;
            this.textBox1.ShowVRuler = true;
            this.textBox1.Size = new System.Drawing.Size(224, 126);
            this.textBox1.TabIndent = 2;
            this.textBox1.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(3, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "发送键值";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // TabItem0
            // 
            this.TabItem0.AttachedControl = this.superTabControlPanel0;
            this.TabItem0.EnableImageAnimation = true;
            this.TabItem0.GlobalItem = false;
            this.TabItem0.Name = "TabItem0";
            this.TabItem0.Text = "TabItem0";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(629, 216);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.TabItem1;
            this.superTabControlPanel1.Visible = false;
            // 
            // TabItem1
            // 
            this.TabItem1.AttachedControl = this.superTabControlPanel1;
            this.TabItem1.GlobalItem = false;
            this.TabItem1.Name = "TabItem1";
            this.TabItem1.Text = "TabItem1";
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new System.Drawing.Size(629, 216);
            this.superTabControlPanel7.TabIndex = 0;
            this.superTabControlPanel7.TabItem = this.TabItem7;
            this.superTabControlPanel7.Visible = false;
            // 
            // TabItem7
            // 
            this.TabItem7.AttachedControl = this.superTabControlPanel7;
            this.TabItem7.GlobalItem = false;
            this.TabItem7.Name = "TabItem7";
            this.TabItem7.Text = "superTabItem7";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 36);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(629, 206);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.TabItem2;
            this.superTabControlPanel2.Visible = false;
            // 
            // TabItem2
            // 
            this.TabItem2.AttachedControl = this.superTabControlPanel2;
            this.TabItem2.GlobalItem = false;
            this.TabItem2.Name = "TabItem2";
            this.TabItem2.Text = "TabItem2";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(629, 216);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.TabItem4;
            this.superTabControlPanel4.Visible = false;
            // 
            // TabItem4
            // 
            this.TabItem4.AttachedControl = this.superTabControlPanel4;
            this.TabItem4.GlobalItem = false;
            this.TabItem4.Name = "TabItem4";
            this.TabItem4.Text = "TabItem4";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(629, 216);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.TabItem3;
            this.superTabControlPanel3.Visible = false;
            // 
            // TabItem3
            // 
            this.TabItem3.AttachedControl = this.superTabControlPanel3;
            this.TabItem3.GlobalItem = false;
            this.TabItem3.Name = "TabItem3";
            this.TabItem3.Text = "TabItem3";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(629, 216);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.TabItem6;
            this.superTabControlPanel6.Visible = false;
            // 
            // TabItem6
            // 
            this.TabItem6.AttachedControl = this.superTabControlPanel6;
            this.TabItem6.GlobalItem = false;
            this.TabItem6.Name = "TabItem6";
            this.TabItem6.Text = "superTabItem6";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(629, 216);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.TabItem5;
            this.superTabControlPanel5.Visible = false;
            // 
            // TabItem5
            // 
            this.TabItem5.AttachedControl = this.superTabControlPanel5;
            this.TabItem5.GlobalItem = false;
            this.TabItem5.Name = "TabItem5";
            this.TabItem5.Text = "superTabItem5";
            // 
            // superTabControlPanel16
            // 
            this.superTabControlPanel16.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel16.Name = "superTabControlPanel16";
            this.superTabControlPanel16.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.zhantieToolStripMenuItem,
            this.delToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.cutToolStripMenuItem.Text = "剪切";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.copyToolStripMenuItem.Text = "复制";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // zhantieToolStripMenuItem
            // 
            this.zhantieToolStripMenuItem.Name = "zhantieToolStripMenuItem";
            this.zhantieToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.zhantieToolStripMenuItem.Text = "粘贴";
            this.zhantieToolStripMenuItem.Click += new System.EventHandler(this.zhantieToolStripMenuItem_Click);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.delToolStripMenuItem.Text = "删除";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // objattoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Name = "objattoo";
            this.Size = new System.Drawing.Size(873, 695);
            this.Load += new System.EventHandler(this.objatt_Load);
            this.Resize += new System.EventHandler(this.objattoo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.superTabControlPanel0.ResumeLayout(false);
            this.superTabControlPanel0.PerformLayout();
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
