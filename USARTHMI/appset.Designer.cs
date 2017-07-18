using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;

namespace USARTHMI
{
    partial class appset
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
            this.Text = "appset";

          
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(appset));
            this.itemPanel1 = new ItemPanel();
            this.itemContainer1 = new ItemContainer();
            this.metroTileItem0 = new MetroTileItem();
            this.metroTileItem1 = new MetroTileItem();
            this.metroTileItem2 = new MetroTileItem();
            this.buttonX1 = new ButtonX();
            this.buttonX2 = new ButtonX();
            this.superTabControl2 = new SuperTabControl();
            this.superTabControlPanel2 = new SuperTabControlPanel();
            this.panelEx4 = new PanelEx();
            this.line2 = new Line();
            this.line1 = new Line();
            this.itemPanel2 = new ItemPanel();
            this.itemContainer2 = new ItemContainer();
            this.tem0 = new MetroTileItem();
            this.panelEx1 = new PanelEx();
            this.panelEx2 = new PanelEx();
            this.superTabItem2 = new SuperTabItem();
            this.superTabControlPanel8 = new SuperTabControlPanel();
            this.panelEx3 = new PanelEx();
            this.line3 = new Line();
            this.comboBox2 = new ComboBoxEx();
            this.labelX2 = new LabelX();
            this.itemPanel3 = new ItemPanel();
            this.itemContainer3 = new ItemContainer();
            this.itemshow0 = new MetroTileItem();
            this.itemshow1 = new MetroTileItem();
            this.itemshow2 = new MetroTileItem();
            this.itemshow3 = new MetroTileItem();
            this.labelX1 = new LabelX();
            this.superTabItem8 = new SuperTabItem();
            this.metroTileItem6 = new MetroTileItem();
            this.metroTileItem8 = new MetroTileItem();
            this.timer1 = new Timer(this.components);
            ((ISupportInitialize)this.superTabControl2).BeginInit();
            this.superTabControl2.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.superTabControlPanel8.SuspendLayout();
            this.panelEx3.SuspendLayout();
            base.SuspendLayout();
            this.itemPanel1.BackColor = Color.White;
            this.itemPanel1.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.ForeColor = Color.Black;
            this.itemPanel1.Items.AddRange(new BaseItem[]
            {
                this.itemContainer1
            });
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new Point(106, 43);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new Size(624, 100);
            this.itemPanel1.TabIndex = 14;
            this.itemPanel1.Text = "itemPanel1";
            this.itemContainer1.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemContainer1.ItemSpacing = 6;
            this.itemContainer1.MinimumSize = new Size(618, 100);
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new BaseItem[]
            {
                this.metroTileItem0,
                this.metroTileItem1,
                this.metroTileItem2
            });
            this.itemContainer1.TitleStyle.CornerType = eCornerType.Square;
            this.metroTileItem0.DisabledBackColor = Color.White;
            this.metroTileItem0.Name = "metroTileItem0";
            this.metroTileItem0.SymbolColor = Color.Empty;
            this.metroTileItem0.TileColor = eMetroTileColor.Blueish;
            this.metroTileItem0.TileSize = new Size(200, 100);
            this.metroTileItem0.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem0.TitleText = "基本型";
            this.metroTileItem0.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.metroTileItem0.TitleTextColor = Color.White;
            this.metroTileItem0.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.metroTileItem0.Click += new EventHandler(this.metroTileItem_Click);
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.SymbolColor = Color.Empty;
            this.metroTileItem1.TileColor = eMetroTileColor.Blueish;
            this.metroTileItem1.TileSize = new Size(200, 100);
            this.metroTileItem1.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem1.TitleText = "增强型";
            this.metroTileItem1.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.metroTileItem1.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.metroTileItem1.Click += new EventHandler(this.metroTileItem_Click);
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.SymbolColor = Color.Empty;
            this.metroTileItem2.TileColor = eMetroTileColor.Blueish;
            this.metroTileItem2.TileSize = new Size(200, 100);
            this.metroTileItem2.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem2.TitleText = "旗舰型";
            this.metroTileItem2.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.metroTileItem2.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.metroTileItem2.Click += new EventHandler(this.metroTileItem_Click);
            this.buttonX1.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX1.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new Point(750, 543);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new Size(104, 28);
            this.buttonX1.Style = eDotNetBarStyle.Office2003;
            this.buttonX1.TabIndex = 31;
            this.buttonX1.Text = "Cancel";
            this.buttonX1.Click += new EventHandler(this.buttonX1_Click);
            this.buttonX2.AccessibleRole = AccessibleRole.PushButton;
            this.buttonX2.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new Point(640, 543);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new Size(104, 28);
            this.buttonX2.Style = eDotNetBarStyle.Office2003;
            this.buttonX2.TabIndex = 35;
            this.buttonX2.Text = "OK";
            this.buttonX2.Click += new EventHandler(this.buttonX2_Click);
            this.superTabControl2.BackColor = Color.White;
            this.superTabControl2.ControlBox.CloseBox.Name = "";
            this.superTabControl2.ControlBox.MenuBox.Name = "";
            this.superTabControl2.ControlBox.Name = "";
            this.superTabControl2.ControlBox.SubItems.AddRange(new BaseItem[]
            {
                this.superTabControl2.ControlBox.MenuBox,
                this.superTabControl2.ControlBox.CloseBox
            });
            this.superTabControl2.Controls.Add(this.superTabControlPanel8);
            this.superTabControl2.Controls.Add(this.superTabControlPanel2);
            this.superTabControl2.FixedTabSize = new Size(70, 0);
            this.superTabControl2.ForeColor = Color.Black;
            this.superTabControl2.Location = new Point(0, 0);
            this.superTabControl2.Name = "superTabControl2";
            this.superTabControl2.ReorderTabsEnabled = true;
            this.superTabControl2.SelectedTabFont = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.superTabControl2.SelectedTabIndex = 0;
            this.superTabControl2.Size = new Size(865, 537);
            this.superTabControl2.TabAlignment = eTabStripAlignment.Left;
            this.superTabControl2.TabFont = new Font("Segoe UI", 9f);
            this.superTabControl2.TabIndex = 39;
            this.superTabControl2.Tabs.AddRange(new BaseItem[]
            {
                this.superTabItem2,
                this.superTabItem8
            });
            this.superTabControl2.TabStyle = eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl2.TabVerticalSpacing = 3;
            this.superTabControl2.Text = "superTabControl2";
            this.superTabControlPanel2.Controls.Add(this.panelEx4);
            this.superTabControlPanel2.Dock = DockStyle.Fill;
            this.superTabControlPanel2.Location = new Point(72, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new Size(793, 537);
            this.superTabControlPanel2.TabIndex = 1;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            this.panelEx4.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.line2);
            this.panelEx4.Controls.Add(this.line1);
            this.panelEx4.Controls.Add(this.itemPanel2);
            this.panelEx4.Controls.Add(this.panelEx1);
            this.panelEx4.Controls.Add(this.itemPanel1);
            this.panelEx4.DisabledBackColor = Color.Empty;
            this.panelEx4.Dock = DockStyle.Fill;
            this.panelEx4.Location = new Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new Size(793, 537);
            this.panelEx4.Style.Alignment = StringAlignment.Center;
            this.panelEx4.Style.BackColor1.Color = Color.White;
            this.panelEx4.Style.Border = eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 38;
            this.panelEx4.Text = "panelEx4";
            this.line2.BackColor = Color.Gray;
            this.line2.ForeColor = SystemColors.Highlight;
            this.line2.Location = new Point(180, 147);
            this.line2.Name = "line2";
            this.line2.Size = new Size(30, 3);
            this.line2.TabIndex = 48;
            this.line2.Text = "line2";
            this.line2.Thickness = 3;
            this.line2.Visible = false;
            this.line1.ForeColor = SystemColors.ActiveCaption;
            this.line1.Location = new Point(9, 160);
            this.line1.Name = "line1";
            this.line1.Size = new Size(770, 2);
            this.line1.TabIndex = 43;
            this.line1.Text = "line1";
            this.itemPanel2.AutoScroll = true;
            this.itemPanel2.BackColor = Color.White;
            this.itemPanel2.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.DragDropSupport = true;
            this.itemPanel2.ForeColor = Color.Black;
            this.itemPanel2.Items.AddRange(new BaseItem[]
            {
                this.itemContainer2
            });
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new Point(14, 179);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new Size(770, 355);
            this.itemPanel2.TabIndex = 39;
            this.itemPanel2.Text = "itemPanel4";
            this.itemContainer2.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemContainer2.ItemSpacing = 5;
            this.itemContainer2.MinimumSize = new Size(768, 118);
            this.itemContainer2.MultiLine = true;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.ResizeItemsToFit = false;
            this.itemContainer2.SubItems.AddRange(new BaseItem[]
            {
                this.tem0
            });
            this.itemContainer2.TitleStyle.CornerType = eCornerType.Square;
            this.tem0.Name = "tem0";
            this.tem0.SymbolColor = Color.Empty;
            this.tem0.TileColor = eMetroTileColor.Gray;
            this.tem0.TileSize = new Size(380, 55);
            this.tem0.TileStyle.CornerType = eCornerType.Square;
            this.tem0.TitleText = "TJC3224T022_011";
            this.tem0.TitleTextAlignment = ContentAlignment.TopLeft;
            this.tem0.TitleTextFont = new Font("宋体", 18f);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = Color.Empty;
            this.panelEx1.Dock = DockStyle.Top;
            this.panelEx1.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.panelEx1.Location = new Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new Size(793, 34);
            this.panelEx1.Style.BackColor1.ColorSchemePart = eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Style.MarginLeft = 4;
            this.panelEx1.TabIndex = 38;
            this.panelEx1.Text = "Please Select The Model";
            this.panelEx2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.panelEx2.DisabledBackColor = Color.Empty;
            this.panelEx2.Location = new Point(774, 12);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new Size(19, 17);

            this.panelEx2.Style.BackgroundImage = (Image)componentResourceManager.GetObject("panelEx2.Style.BackgroundImage");
            this.panelEx2.Style.BackgroundImagePosition = eBackgroundImagePosition.Center;
            this.panelEx2.StyleMouseDown.Alignment = StringAlignment.Center;
            this.panelEx2.StyleMouseDown.BackgroundImage = (Image)componentResourceManager.GetObject("panelEx2.StyleMouseDown.BackgroundImage");
            this.panelEx2.StyleMouseOver.Alignment = StringAlignment.Center;
            this.panelEx2.TabIndex = 2;
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "设备";
            this.superTabControlPanel8.Controls.Add(this.panelEx3);
            this.superTabControlPanel8.Dock = DockStyle.Fill;
            this.superTabControlPanel8.Location = new Point(72, 0);
            this.superTabControlPanel8.Name = "superTabControlPanel8";
            this.superTabControlPanel8.Size = new Size(793, 537);
            this.superTabControlPanel8.TabIndex = 2;
            this.superTabControlPanel8.TabItem = this.superTabItem8;
            this.panelEx3.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.line3);
            this.panelEx3.Controls.Add(this.comboBox2);
            this.panelEx3.Controls.Add(this.labelX2);
            this.panelEx3.Controls.Add(this.itemPanel3);
            this.panelEx3.Controls.Add(this.labelX1);
            this.panelEx3.DisabledBackColor = Color.Empty;
            this.panelEx3.Dock = DockStyle.Fill;
            this.panelEx3.Location = new Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new Size(793, 537);
            this.panelEx3.Style.Alignment = StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = Color.White;
            this.panelEx3.Style.Border = eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 23;
            this.line3.ForeColor = SystemColors.ActiveCaption;
            this.line3.Location = new Point(15, 200);
            this.line3.Name = "line3";
            this.line3.Size = new Size(770, 2);
            this.line3.TabIndex = 44;
            this.line3.Text = "line3";
            this.comboBox2.DisplayMember = "Text";
            this.comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 15;
            this.comboBox2.Location = new Point(30, 260);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(179, 21);
            this.comboBox2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.comboBox2.TabIndex = 26;
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = Color.White;
            this.labelX2.BackgroundStyle.CornerType = eCornerType.Square;
            this.labelX2.Font = new Font("新宋体", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.labelX2.ForeColor = Color.Black;
            this.labelX2.Location = new Point(32, 223);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new Size(96, 31);
            this.labelX2.TabIndex = 25;
            this.labelX2.Text = "字符编码";
            this.itemPanel3.BackColor = Color.White;
            this.itemPanel3.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemPanel3.ContainerControlProcessDialogKey = true;
            this.itemPanel3.DragDropSupport = true;
            this.itemPanel3.ForeColor = Color.Black;
            this.itemPanel3.Items.AddRange(new BaseItem[]
            {
                this.itemContainer3
            });
            this.itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel3.Location = new Point(30, 62);
            this.itemPanel3.Name = "itemPanel3";
            this.itemPanel3.Size = new Size(760, 100);
            this.itemPanel3.TabIndex = 21;
            this.itemPanel3.Text = "itemPanel3";
            this.itemContainer3.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemContainer3.ItemSpacing = 6;
            this.itemContainer3.MinimumSize = new Size(745, 100);
            this.itemContainer3.MultiLine = true;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.ResizeItemsToFit = false;
            this.itemContainer3.SubItems.AddRange(new BaseItem[]
            {
                this.itemshow0,
                this.itemshow1,
                this.itemshow2,
                this.itemshow3
            });
            this.itemContainer3.TitleStyle.CornerType = eCornerType.Square;
            this.itemshow0.Name = "itemshow0";
            this.itemshow0.SymbolColor = Color.Empty;
            this.itemshow0.Text = "<font size=\"30\">0</font>";
            this.itemshow0.TileColor = eMetroTileColor.Coffee;
            this.itemshow0.TileSize = new Size(180, 100);
            this.itemshow0.TileStyle.CornerType = eCornerType.Square;
            this.itemshow0.TitleText = "横屏";
            this.itemshow0.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.itemshow0.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.itemshow0.Click += new EventHandler(this.metroTileItemshow_Click);
            this.itemshow1.Name = "itemshow1";
            this.itemshow1.SymbolColor = Color.Empty;
            this.itemshow1.Text = "<font size=\"30\">90</font>";
            this.itemshow1.TileColor = eMetroTileColor.Coffee;
            this.itemshow1.TileSize = new Size(180, 100);
            this.itemshow1.TileStyle.CornerType = eCornerType.Square;
            this.itemshow1.TitleText = "竖屏";
            this.itemshow1.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.itemshow1.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.itemshow1.Click += new EventHandler(this.metroTileItemshow_Click);
            this.itemshow2.Name = "itemshow2";
            this.itemshow2.SymbolColor = Color.Empty;
            this.itemshow2.Text = "<font size=\"30\">180</font>";
            this.itemshow2.TileColor = eMetroTileColor.Coffee;
            this.itemshow2.TileSize = new Size(180, 100);
            this.itemshow2.TileStyle.CornerType = eCornerType.Square;
            this.itemshow2.TitleText = "横屏";
            this.itemshow2.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.itemshow2.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.itemshow2.Click += new EventHandler(this.metroTileItemshow_Click);
            this.itemshow3.Name = "itemshow3";
            this.itemshow3.SymbolColor = Color.Empty;
            this.itemshow3.Text = "<font size=\"30\">270</font>";
            this.itemshow3.TileColor = eMetroTileColor.Coffee;
            this.itemshow3.TileSize = new Size(180, 100);
            this.itemshow3.TileStyle.CornerType = eCornerType.Square;
            this.itemshow3.TitleText = "竖屏";
            this.itemshow3.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.itemshow3.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.itemshow3.Click += new EventHandler(this.metroTileItemshow_Click);
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = Color.White;
            this.labelX1.BackgroundStyle.CornerType = eCornerType.Square;
            this.labelX1.Font = new Font("新宋体", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelX1.ForeColor = Color.Black;
            this.labelX1.Location = new Point(33, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new Size(96, 31);
            this.labelX1.TabIndex = 22;
            this.labelX1.Text = "显示方向";
            this.superTabItem8.AttachedControl = this.superTabControlPanel8;
            this.superTabItem8.GlobalItem = false;
            this.superTabItem8.Name = "superTabItem8";
            this.superTabItem8.Text = "显示";
            this.metroTileItem6.Name = "metroTileItem6";
            this.metroTileItem6.SymbolColor = Color.Empty;
            this.metroTileItem6.TileColor = eMetroTileColor.Gray;
            this.metroTileItem6.TileSize = new Size(180, 100);
            this.metroTileItem6.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem6.TitleText = "旗舰型(研发中)";
            this.metroTileItem6.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.metroTileItem6.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.metroTileItem8.Name = "metroTileItem8";
            this.metroTileItem8.SymbolColor = Color.Empty;
            this.metroTileItem8.Text = "<font size=\"10\">\r\n支持RTC<br/>\r\n支持用户存储<br/>\r\n8路扩展IO<br/>\r\n更大的Flash空间<br/>\r\n</font>";
            this.metroTileItem8.TileColor = eMetroTileColor.Gray;
            this.metroTileItem8.TileSize = new Size(180, 100);
            this.metroTileItem8.TileStyle.CornerType = eCornerType.Square;
            this.metroTileItem8.TitleText = "增强型";
            this.metroTileItem8.TitleTextAlignment = ContentAlignment.BottomCenter;
            this.metroTileItem8.TitleTextFont = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(865, 576);
            base.Controls.Add(this.superTabControl2);
            base.Controls.Add(this.buttonX2);
            base.Controls.Add(this.buttonX1);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
       
            base.ShowIcon = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "设置";
            base.Load += new EventHandler(this.Form1_Load);
            ((ISupportInitialize)this.superTabControl2).EndInit();
            this.superTabControl2.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.superTabControlPanel8.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion
    }
}