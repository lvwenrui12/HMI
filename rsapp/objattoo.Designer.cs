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
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(objattoo));
            this.label2 = new Label();
            this.labetextBox1l1 = new Label();
            this.tabControl1 = new SuperTabControl();
            this.superTabControlPanel0 = new SuperTabControlPanel();
            this.textBox1 = new TextEditorControl();
            this.checkBox1 = new CheckBox();
            this.TabItem0 = new SuperTabItem();
            this.superTabControlPanel1 = new SuperTabControlPanel();
            this.TabItem1 = new SuperTabItem();
            this.superTabControlPanel7 = new SuperTabControlPanel();
            this.TabItem7 = new SuperTabItem();
            this.superTabControlPanel2 = new SuperTabControlPanel();
            this.TabItem2 = new SuperTabItem();
            this.superTabControlPanel4 = new SuperTabControlPanel();
            this.TabItem4 = new SuperTabItem();
            this.superTabControlPanel3 = new SuperTabControlPanel();
            this.TabItem3 = new SuperTabItem();
            this.superTabControlPanel6 = new SuperTabControlPanel();
            this.TabItem6 = new SuperTabItem();
            this.superTabControlPanel5 = new SuperTabControlPanel();
            this.TabItem5 = new SuperTabItem();
            this.superTabControlPanel16 = new SuperTabControlPanel();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new ToolStripMenuItem();
            this.copyToolStripMenuItem = new ToolStripMenuItem();
            this.zhantieToolStripMenuItem = new ToolStripMenuItem();
            this.delToolStripMenuItem = new ToolStripMenuItem();
            ((ISupportInitialize)this.tabControl1).BeginInit();
            this.tabControl1.SuspendLayout();
            this.superTabControlPanel0.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.ForeColor = Color.FromArgb(0, 0, 192);
            this.label2.Location = new Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new Size(245, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "(后初始化事件在所有控件刷新显示之后执行)";
            this.labetextBox1l1.AutoSize = true;
            this.labetextBox1l1.BackColor = Color.Transparent;
            this.labetextBox1l1.Location = new Point(3, 29);
            this.labetextBox1l1.Name = "labetextBox1l1";
            this.labetextBox1l1.Size = new Size(53, 12);
            this.labetextBox1l1.TabIndex = 2;
            this.labetextBox1l1.Text = "用户代码";
            this.tabControl1.BackColor = Color.White;
            this.tabControl1.ControlBox.CloseBox.Name = "";
            this.tabControl1.ControlBox.MenuBox.Name = "";
            this.tabControl1.ControlBox.Name = "";
            this.tabControl1.ControlBox.SubItems.AddRange(new BaseItem[]
            {
                this.tabControl1.ControlBox.MenuBox,
                this.tabControl1.ControlBox.CloseBox
            });
            this.tabControl1.Controls.Add(this.superTabControlPanel0);
            this.tabControl1.Controls.Add(this.superTabControlPanel1);
            this.tabControl1.Controls.Add(this.superTabControlPanel7);
            this.tabControl1.Controls.Add(this.superTabControlPanel2);
            this.tabControl1.Controls.Add(this.superTabControlPanel4);
            this.tabControl1.Controls.Add(this.superTabControlPanel3);
            this.tabControl1.Controls.Add(this.superTabControlPanel6);
            this.tabControl1.Controls.Add(this.superTabControlPanel5);
            this.tabControl1.FixedTabSize = new Size(70, 0);
            this.tabControl1.Location = new Point(3, 137);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.ReorderTabsEnabled = true;
            this.tabControl1.SelectedTabFont = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new Size(629, 242);
            this.tabControl1.TabFont = new Font("Segoe UI", 9f);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabLayoutType = eSuperTabLayoutType.SingleLineFit;
            this.tabControl1.Tabs.AddRange(new BaseItem[]
            {
                this.TabItem0,
                this.TabItem1,
                this.TabItem2,
                this.TabItem3,
                this.TabItem4,
                this.TabItem5,
                this.TabItem6,
                this.TabItem7
            });
            this.tabControl1.TabStyle = eSuperTabStyle.Office2010BackstageBlue;
            this.tabControl1.TabVerticalSpacing = 3;
            this.tabControl1.Text = "superTabControl2";
            this.tabControl1.SelectedTabChanging += new EventHandler<SuperTabStripSelectedTabChangingEventArgs>(this.tabControl1_SelectedTabChanging);
            this.tabControl1.SelectedTabChanged += new EventHandler<SuperTabStripSelectedTabChangedEventArgs>(this.tabControl1_SelectedTabChanged);
            this.superTabControlPanel0.Controls.Add(this.textBox1);
            this.superTabControlPanel0.Controls.Add(this.checkBox1);
            this.superTabControlPanel0.Controls.Add(this.labetextBox1l1);
            this.superTabControlPanel0.Dock = DockStyle.Fill;
            this.superTabControlPanel0.Location = new Point(0, 26);
            this.superTabControlPanel0.Name = "superTabControlPanel0";
            this.superTabControlPanel0.Size = new Size(629, 216);
            this.superTabControlPanel0.TabIndex = 1;
            this.superTabControlPanel0.TabItem = this.TabItem0;
            this.textBox1.AutoScroll = true;
            this.textBox1.BorderStyle = BorderStyle.FixedSingle;
            this.textBox1.Encoding = (Encoding)componentResourceManager.GetObject("textBox1.Encoding");
            this.textBox1.IsIconBarVisible = false;
            this.textBox1.Location = new Point(142, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShowEOLMarkers = true;
            this.textBox1.ShowInvalidLines = false;
            this.textBox1.ShowSpaces = true;
            this.textBox1.ShowTabs = true;
            this.textBox1.ShowVRuler = true;
            this.textBox1.Size = new Size(224, 126);
            this.textBox1.TabIndent = 2;
            this.textBox1.TabIndex = 8;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = Color.Transparent;
            this.checkBox1.Location = new Point(3, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(72, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "发送键值";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Click += new EventHandler(this.checkBox_Click);
            this.TabItem0.AttachedControl = this.superTabControlPanel0;
            this.TabItem0.EnableImageAnimation = true;
            this.TabItem0.GlobalItem = false;
            this.TabItem0.Name = "TabItem0";
            this.TabItem0.Text = "TabItem0";
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Dock = DockStyle.Fill;
            this.superTabControlPanel1.Location = new Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new Size(629, 216);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.TabItem1;
            this.TabItem1.AttachedControl = this.superTabControlPanel1;
            this.TabItem1.GlobalItem = false;
            this.TabItem1.Name = "TabItem1";
            this.TabItem1.Text = "TabItem1";
            this.superTabControlPanel7.Dock = DockStyle.Fill;
            this.superTabControlPanel7.Location = new Point(0, 26);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new Size(629, 216);
            this.superTabControlPanel7.TabIndex = 0;
            this.superTabControlPanel7.TabItem = this.TabItem7;
            this.TabItem7.AttachedControl = this.superTabControlPanel7;
            this.TabItem7.GlobalItem = false;
            this.TabItem7.Name = "TabItem7";
            this.TabItem7.Text = "superTabItem7";
            this.superTabControlPanel2.Dock = DockStyle.Fill;
            this.superTabControlPanel2.Location = new Point(0, 36);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new Size(629, 206);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.TabItem2;
            this.TabItem2.AttachedControl = this.superTabControlPanel2;
            this.TabItem2.GlobalItem = false;
            this.TabItem2.Name = "TabItem2";
            this.TabItem2.Text = "TabItem2";
            this.superTabControlPanel4.Dock = DockStyle.Fill;
            this.superTabControlPanel4.Location = new Point(0, 26);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new Size(629, 216);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.TabItem4;
            this.TabItem4.AttachedControl = this.superTabControlPanel4;
            this.TabItem4.GlobalItem = false;
            this.TabItem4.Name = "TabItem4";
            this.TabItem4.Text = "TabItem4";
            this.superTabControlPanel3.Dock = DockStyle.Fill;
            this.superTabControlPanel3.Location = new Point(0, 26);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new Size(629, 216);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.TabItem3;
            this.TabItem3.AttachedControl = this.superTabControlPanel3;
            this.TabItem3.GlobalItem = false;
            this.TabItem3.Name = "TabItem3";
            this.TabItem3.Text = "TabItem3";
            this.superTabControlPanel6.Dock = DockStyle.Fill;
            this.superTabControlPanel6.Location = new Point(0, 26);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new Size(629, 216);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.TabItem6;
            this.TabItem6.AttachedControl = this.superTabControlPanel6;
            this.TabItem6.GlobalItem = false;
            this.TabItem6.Name = "TabItem6";
            this.TabItem6.Text = "superTabItem6";
            this.superTabControlPanel5.Dock = DockStyle.Fill;
            this.superTabControlPanel5.Location = new Point(0, 26);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new Size(629, 216);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.TabItem5;
            this.TabItem5.AttachedControl = this.superTabControlPanel5;
            this.TabItem5.GlobalItem = false;
            this.TabItem5.Name = "TabItem5";
            this.TabItem5.Text = "superTabItem5";
            this.superTabControlPanel16.Location = new Point(0, 0);
            this.superTabControlPanel16.Name = "superTabControlPanel16";
            this.superTabControlPanel16.Size = new Size(200, 100);
            this.superTabControlPanel16.TabIndex = 0;
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.cutToolStripMenuItem,
                this.copyToolStripMenuItem,
                this.zhantieToolStripMenuItem,
                this.delToolStripMenuItem
            });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(101, 92);
            this.contextMenuStrip1.Opening += new CancelEventHandler(this.contextMenuStrip1_Opening);
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new Size(100, 22);
            this.cutToolStripMenuItem.Text = "剪切";
            this.cutToolStripMenuItem.Click += new EventHandler(this.cutToolStripMenuItem_Click);
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new Size(100, 22);
            this.copyToolStripMenuItem.Text = "复制";
            this.copyToolStripMenuItem.Click += new EventHandler(this.copyToolStripMenuItem_Click);
            this.zhantieToolStripMenuItem.Name = "zhantieToolStripMenuItem";
            this.zhantieToolStripMenuItem.Size = new Size(100, 22);
            this.zhantieToolStripMenuItem.Text = "粘贴";
            this.zhantieToolStripMenuItem.Click += new EventHandler(this.zhantieToolStripMenuItem_Click);
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new Size(100, 22);
            this.delToolStripMenuItem.Text = "删除";
            this.delToolStripMenuItem.Click += new EventHandler(this.delToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.Controls.Add(this.tabControl1);
            base.Name = "objattoo";
            base.Size = new Size(873, 695);
            base.Load += new EventHandler(this.objatt_Load);
            base.Resize += new EventHandler(this.objattoo_Resize);
            ((ISupportInitialize)this.tabControl1).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.superTabControlPanel0.ResumeLayout(false);
            this.superTabControlPanel0.PerformLayout();
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        #endregion
    }
}
