using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace rsapp
{
    partial class objatt
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
         
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(objatt));
            this.dataGridView1 = new DataGridView();
            this.name = new DataGridViewTextBoxColumn();
            this.val = new DataGridViewTextBoxColumn();
            this.lei = new DataGridViewTextBoxColumn();
            this.zhushi = new DataGridViewTextBoxColumn();
            this.isbangding = new DataGridViewTextBoxColumn();
            this.isxiugai = new DataGridViewTextBoxColumn();
            this.attid = new DataGridViewTextBoxColumn();
            this.initval = new DataGridViewTextBoxColumn();
            this.mustr = new ContextMenuStrip(this.components);
            this.ToolStripMenuItem_addshu = new ToolStripMenuItem();
            this.ssssToolStripMenuItem = new ToolStripMenuItem();
            this.textBox1 = new TextBox();
            this.cmb_Temp = new ComboBox();
            this.comboBox1 = new ComboBox();
            this.imageList1 = new ImageList(this.components);
            ((ISupportInitialize)this.dataGridView1).BeginInit();
            this.mustr.SuspendLayout();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = Color.White;
            this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                this.name,
                this.val,
                this.lei,
                this.zhushi,
                this.isbangding,
                this.isxiugai,
                this.attid,
                this.initval
            });
            this.dataGridView1.GridColor = Color.Silver;
            this.dataGridView1.Location = new Point(3, 26);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new Size(224, 251);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Scroll += new ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.Paint += new PaintEventHandler(this.dataGridView1_Paint);
            this.name.HeaderText = "属性";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 80;
            this.val.HeaderText = "值";
            this.val.Name = "val";
            this.val.ReadOnly = true;
            this.lei.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.lei.HeaderText = "type";
            this.lei.MinimumWidth = 2;
            this.lei.Name = "type";
            this.lei.ReadOnly = true;
            this.lei.Visible = false;
            this.lei.Width = 2;
            this.zhushi.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.zhushi.HeaderText = "zhushi";
            this.zhushi.Name = "zhushi";
            this.zhushi.Visible = false;
            this.zhushi.Width = 5;
            this.isbangding.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.isbangding.HeaderText = "isbangding";
            this.isbangding.Name = "isbangding";
            this.isbangding.Visible = false;
            this.isbangding.Width = 5;
            this.isxiugai.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.isxiugai.HeaderText = "isxiugai";
            this.isxiugai.Name = "isxiugai";
            this.isxiugai.Visible = false;
            this.isxiugai.Width = 5;
            this.attid.HeaderText = "attid";
            this.attid.Name = "attid";
            this.attid.Visible = false;
            this.initval.HeaderText = "initval";
            this.initval.Name = "initval";
            this.initval.Visible = false;
            this.mustr.Items.AddRange(new ToolStripItem[]
            {
                this.ToolStripMenuItem_addshu,
                this.ssssToolStripMenuItem
            });
            this.mustr.Name = "mustr";
            this.mustr.Size = new Size(125, 48);
            this.ToolStripMenuItem_addshu.Name = "ToolStripMenuItem_addshu";
            this.ToolStripMenuItem_addshu.Size = new Size(124, 22);
            this.ToolStripMenuItem_addshu.Text = "添加成员";
            this.ssssToolStripMenuItem.Name = "ssssToolStripMenuItem";
            this.ssssToolStripMenuItem.Size = new Size(124, 22);
            this.ssssToolStripMenuItem.Text = "删除成员";
            this.textBox1.BackColor = Color.FromArgb(240, 240, 240);
            this.textBox1.BorderStyle = BorderStyle.FixedSingle;
            this.textBox1.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.textBox1.Location = new Point(3, 283);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(224, 49);
            this.textBox1.TabIndex = 1;
            this.cmb_Temp.BackColor = Color.White;
            this.cmb_Temp.DropDownHeight = 250;
            this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmb_Temp.FlatStyle = FlatStyle.Flat;
            this.cmb_Temp.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.cmb_Temp.FormattingEnabled = true;
            this.cmb_Temp.IntegralHeight = false;
            this.cmb_Temp.Location = new Point(233, 26);
            this.cmb_Temp.Name = "cmb_Temp";
            this.cmb_Temp.Size = new Size(38, 20);
            this.cmb_Temp.TabIndex = 3;
            this.cmb_Temp.Visible = false;
            this.cmb_Temp.DrawItem += new DrawItemEventHandler(this.cmb_Temp_DrawItem);
            this.cmb_Temp.SelectionChangeCommitted += new EventHandler(this.cmb_Temp_SelectionChangeCommitted);
            this.cmb_Temp.Leave += new EventHandler(this.cmb_Temp_Leave);
            this.cmb_Temp.KeyPress += new KeyPressEventHandler(this.cmb_Temp_KeyPress);
            this.comboBox1.BackColor = Color.White;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(3, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(228, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectionChangeCommitted += new EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.imageList1.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "delete.ico");
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.Controls.Add(this.comboBox1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.cmb_Temp);
            base.Controls.Add(this.dataGridView1);
            base.Name = "objatt";
            base.Size = new Size(308, 389);
            base.Load += new EventHandler(this.objatt_Load);
            base.Paint += new PaintEventHandler(this.objatt_Paint);
            base.Resize += new EventHandler(this.objatt_Resize);
            ((ISupportInitialize)this.dataGridView1).EndInit();
            this.mustr.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}
