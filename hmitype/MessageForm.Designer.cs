using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace hmitype
{
    partial class MessageForm
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "MessageForm";

            this.panelEx1 = new PanelEx();
            this.checkBox1 = new CheckBox();
            this.labelceshi = new LabelX();
            this.label1 = new LabelX();
            this.messagetext = new RichTextBox();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new ToolStripMenuItem();
            this.zhantieToolStripMenuItem = new ToolStripMenuItem();
            this.line1 = new Line();
            this.p2 = new PanelEx();
            this.p1 = new PanelEx();
            this.p0 = new PanelEx();
            this.panelEx2 = new PanelEx();
            this.labelX3 = new LabelX();
            this.labelX2 = new LabelX();
            this.timer1 = new Timer(this.components);
            this.panelEx1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            base.SuspendLayout();
            this.panelEx1.CanvasColor = SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.checkBox1);
            this.panelEx1.Controls.Add(this.labelceshi);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.messagetext);
            this.panelEx1.Controls.Add(this.line1);
            this.panelEx1.Controls.Add(this.p2);
            this.panelEx1.Controls.Add(this.p1);
            this.panelEx1.Controls.Add(this.p0);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = Color.Empty;
            this.panelEx1.Dock = DockStyle.Fill;
            this.panelEx1.Location = new Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new Size(450, 150);
            this.panelEx1.Style.Alignment = StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = Color.White;
            this.panelEx1.Style.BackColor2.Color = Color.White;
            this.panelEx1.Style.Border = eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            this.panelEx1.Click += new EventHandler(this.panelEx1_Click);
            this.checkBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(12, 128);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(78, 16);
            this.checkBox1.TabIndex = 94;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.labelceshi.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.labelceshi.AutoSize = true;
            this.labelceshi.BackgroundStyle.CornerType = eCornerType.Square;
            this.labelceshi.Location = new Point(167, 114);
            this.labelceshi.Name = "labelceshi";
            this.labelceshi.Size = new Size(50, 16);
            this.labelceshi.Style = eDotNetBarStyle.VS2005;
            this.labelceshi.TabIndex = 81;
            this.labelceshi.Text = "messqge";
            this.labelceshi.TextAlignment = StringAlignment.Center;
            this.labelceshi.Visible = false;
            this.labelceshi.WordWrap = true;
            this.label1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.label1.BackgroundStyle.CornerType = eCornerType.Square;
            this.label1.Location = new Point(4, 27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(441, 21);
            this.label1.Style = eDotNetBarStyle.VS2005;
            this.label1.TabIndex = 68;
            this.label1.Text = "messqge";
            this.label1.TextAlignment = StringAlignment.Center;
            this.label1.WordWrap = true;
            this.label1.DoubleClick += new EventHandler(this.label1_DoubleClick);
            this.label1.Click += new EventHandler(this.label1_Click);
            this.messagetext.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.messagetext.BackColor = Color.White;
            this.messagetext.BorderStyle = BorderStyle.None;
            this.messagetext.ContextMenuStrip = this.contextMenuStrip1;
            this.messagetext.Location = new Point(7, 30);
            this.messagetext.Name = "messagetext";
            this.messagetext.ReadOnly = true;
            this.messagetext.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.messagetext.Size = new Size(436, 72);
            this.messagetext.TabIndex = 54;
            this.messagetext.Text = "message";
            this.messagetext.KeyPress += new KeyPressEventHandler(this.messagetext_KeyPress);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.copyToolStripMenuItem,
                this.zhantieToolStripMenuItem
            });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(101, 48);
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new Size(100, 22);
            this.copyToolStripMenuItem.Text = "复制";
            this.copyToolStripMenuItem.Click += new EventHandler(this.copyToolStripMenuItem_Click);
            this.zhantieToolStripMenuItem.Enabled = false;
            this.zhantieToolStripMenuItem.Name = "zhantieToolStripMenuItem";
            this.zhantieToolStripMenuItem.Size = new Size(100, 22);
            this.zhantieToolStripMenuItem.Text = "粘贴";
            this.line1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.line1.ForeColor = Color.Silver;
            this.line1.Location = new Point(4, 107);
            this.line1.Name = "line1";
            this.line1.Size = new Size(441, 3);
            this.line1.TabIndex = 28;
            this.line1.Text = "line1";
            this.p2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.p2.CanvasColor = SystemColors.Control;
            this.p2.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.p2.DisabledBackColor = Color.Empty;
            this.p2.Location = new Point(375, 114);
            this.p2.Name = "p2";
            this.p2.Size = new Size(70, 30);
            this.p2.Style.Alignment = StringAlignment.Center;
            this.p2.Style.BackColor1.Color = Color.White;
            this.p2.Style.BackColor2.Color = Color.White;
            this.p2.Style.Border = eBorderType.SingleLine;
            this.p2.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.p2.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.p2.Style.GradientAngle = 90;
            this.p2.TabIndex = 7;
            this.p2.Text = "取消";
            this.p2.MouseLeave += new EventHandler(this.panelEx5_MouseLeave);
            this.p2.MouseMove += new MouseEventHandler(this.panelEx4_MouseMove);
            this.p2.Click += new EventHandler(this.panelEx3_Click);
            this.p2.MouseDown += new MouseEventHandler(this.p0_MouseDown);
            this.p1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.p1.CanvasColor = SystemColors.Control;
            this.p1.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.p1.DisabledBackColor = Color.Empty;
            this.p1.Location = new Point(299, 114);
            this.p1.Name = "p1";
            this.p1.Size = new Size(70, 30);
            this.p1.Style.Alignment = StringAlignment.Center;
            this.p1.Style.BackColor1.Color = Color.White;
            this.p1.Style.BackColor2.Color = Color.White;
            this.p1.Style.Border = eBorderType.SingleLine;
            this.p1.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.p1.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.p1.Style.GradientAngle = 90;
            this.p1.TabIndex = 14;
            this.p1.Text = "否";
            this.p1.MouseLeave += new EventHandler(this.panelEx5_MouseLeave);
            this.p1.MouseMove += new MouseEventHandler(this.panelEx4_MouseMove);
            this.p1.Click += new EventHandler(this.panelEx4_Click);
            this.p1.MouseDown += new MouseEventHandler(this.p0_MouseDown);
            this.p0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.p0.CanvasColor = SystemColors.Control;
            this.p0.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.p0.DisabledBackColor = Color.Empty;
            this.p0.Location = new Point(223, 114);
            this.p0.Name = "p0";
            this.p0.Size = new Size(70, 30);
            this.p0.Style.Alignment = StringAlignment.Center;
            this.p0.Style.BackColor1.Color = Color.White;
            this.p0.Style.BackColor2.Color = Color.White;
            this.p0.Style.Border = eBorderType.SingleLine;
            this.p0.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.p0.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.p0.Style.GradientAngle = 90;
            this.p0.TabIndex = 18;
            this.p0.Text = "是";
            this.p0.MouseLeave += new EventHandler(this.panelEx5_MouseLeave);
            this.p0.MouseMove += new MouseEventHandler(this.panelEx4_MouseMove);
            this.p0.Click += new EventHandler(this.panelEx5_Click);
            this.p0.MouseDown += new MouseEventHandler(this.p0_MouseDown);
            this.panelEx2.CanvasColor = SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.DisabledBackColor = Color.Empty;
            this.panelEx2.Dock = DockStyle.Top;
            this.panelEx2.Location = new Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new Size(450, 24);
            this.panelEx2.Style.Alignment = StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = Color.FromArgb(7, 104, 169);
            this.panelEx2.Style.BackColor2.Color = Color.FromArgb(7, 104, 169);
            this.panelEx2.Style.Border = eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 3;
            this.panelEx2.MouseMove += new MouseEventHandler(this.panelEx2_MouseMove);
            this.panelEx2.MouseDown += new MouseEventHandler(this.labelX3_MouseDown);
            this.panelEx2.MouseUp += new MouseEventHandler(this.panelEx2_MouseUp);
            this.labelX3.AutoSize = true;
            this.labelX3.BackgroundStyle.CornerType = eCornerType.Square;
            this.labelX3.ForeColor = Color.White;
            this.labelX3.Location = new Point(5, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new Size(37, 16);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "title";
            this.labelX3.MouseMove += new MouseEventHandler(this.panelEx2_MouseMove);
            this.labelX3.MouseDown += new MouseEventHandler(this.labelX3_MouseDown);
            this.labelX3.MouseUp += new MouseEventHandler(this.panelEx2_MouseUp);
            this.labelX2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.labelX2.BackColor = Color.White;
            this.labelX2.BackgroundStyle.CornerType = eCornerType.Square;
            this.labelX2.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.labelX2.ForeColor = Color.Black;
            this.labelX2.Location = new Point(428, 2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new Size(20, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "X";
            this.labelX2.TextAlignment = StringAlignment.Center;
            this.labelX2.MouseLeave += new EventHandler(this.labelX2_MouseLeave);
            this.labelX2.MouseMove += new MouseEventHandler(this.labelX2_MouseMove);
            this.labelX2.Click += new EventHandler(this.labelX2_Click);
            this.labelX2.MouseDown += new MouseEventHandler(this.labelX3_MouseDown);
            this.labelX2.MouseUp += new MouseEventHandler(this.panelEx2_MouseUp);
            this.timer1.Enabled = true;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(450, 150);
            base.Controls.Add(this.panelEx1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "MessageForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MessageForm";
            base.Load += new EventHandler(this.MessageForm_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            base.ResumeLayout(false);


        }

        #endregion
    }
}