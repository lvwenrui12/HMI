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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(objatt));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhushi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isbangding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isxiugai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mustr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_addshu = new System.Windows.Forms.ToolStripMenuItem();
            this.ssssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmb_Temp = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.mustr.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.val,
            this.type,
            this.zhushi,
            this.isbangding,
            this.isxiugai,
            this.attid,
            this.initval});
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(3, 26);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(224, 251);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // name
            // 
            this.name.HeaderText = "属性";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 80;
            // 
            // val
            // 
            this.val.HeaderText = "值";
            this.val.Name = "val";
            this.val.ReadOnly = true;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.type.HeaderText = "type";
            this.type.MinimumWidth = 2;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Visible = false;
            this.type.Width = 2;
            // 
            // zhushi
            // 
            this.zhushi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.zhushi.HeaderText = "zhushi";
            this.zhushi.Name = "zhushi";
            this.zhushi.Visible = false;
            this.zhushi.Width = 5;
            // 
            // isbangding
            // 
            this.isbangding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.isbangding.HeaderText = "isbangding";
            this.isbangding.Name = "isbangding";
            this.isbangding.Visible = false;
            this.isbangding.Width = 5;
            // 
            // isxiugai
            // 
            this.isxiugai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.isxiugai.HeaderText = "isxiugai";
            this.isxiugai.Name = "isxiugai";
            this.isxiugai.Visible = false;
            this.isxiugai.Width = 5;
            // 
            // attid
            // 
            this.attid.HeaderText = "attid";
            this.attid.Name = "attid";
            this.attid.Visible = false;
            // 
            // initval
            // 
            this.initval.HeaderText = "initval";
            this.initval.Name = "initval";
            this.initval.Visible = false;
            // 
            // mustr
            // 
            this.mustr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_addshu,
            this.ssssToolStripMenuItem});
            this.mustr.Name = "mustr";
            this.mustr.Size = new System.Drawing.Size(125, 48);
            // 
            // ToolStripMenuItem_addshu
            // 
            this.ToolStripMenuItem_addshu.Name = "ToolStripMenuItem_addshu";
            this.ToolStripMenuItem_addshu.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_addshu.Text = "添加成员";
            // 
            // ssssToolStripMenuItem
            // 
            this.ssssToolStripMenuItem.Name = "ssssToolStripMenuItem";
            this.ssssToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ssssToolStripMenuItem.Text = "删除成员";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(3, 283);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(224, 49);
            this.textBox1.TabIndex = 1;
            // 
            // cmb_Temp
            // 
            this.cmb_Temp.BackColor = System.Drawing.Color.White;
            this.cmb_Temp.DropDownHeight = 250;
            this.cmb_Temp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Temp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Temp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Temp.FormattingEnabled = true;
            this.cmb_Temp.IntegralHeight = false;
            this.cmb_Temp.Location = new System.Drawing.Point(233, 26);
            this.cmb_Temp.Name = "cmb_Temp";
            this.cmb_Temp.Size = new System.Drawing.Size(38, 20);
            this.cmb_Temp.TabIndex = 3;
            this.cmb_Temp.Visible = false;
            this.cmb_Temp.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_Temp_DrawItem);
            this.cmb_Temp.SelectionChangeCommitted += new System.EventHandler(this.cmb_Temp_SelectionChangeCommitted);
            this.cmb_Temp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Temp_KeyPress);
            this.cmb_Temp.Leave += new System.EventHandler(this.cmb_Temp_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "delete.ico");
            // 
            // objatt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmb_Temp);
            this.Controls.Add(this.dataGridView1);
            this.Name = "objatt";
            this.Size = new System.Drawing.Size(308, 389);
            this.Load += new System.EventHandler(this.objatt_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.objatt_Paint);
            this.Resize += new System.EventHandler(this.objatt_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.mustr.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewTextBoxColumn type;
    }
}
