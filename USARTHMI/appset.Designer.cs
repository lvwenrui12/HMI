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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appset));
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem0 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.superTabControl2 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel8 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.line3 = new DevComponents.DotNetBar.Controls.Line();
            this.comboBox2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.itemshow0 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemshow1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemshow2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemshow3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem8 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.tem0 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.metroTileItem6 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem8 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).BeginInit();
            this.superTabControl2.SuspendLayout();
            this.superTabControlPanel8.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemPanel1
            // 
            this.itemPanel1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.ForeColor = System.Drawing.Color.Black;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(106, 43);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(624, 100);
            this.itemPanel1.TabIndex = 14;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 6;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(618, 100);
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTileItem0,
            this.metroTileItem1,
            this.metroTileItem2});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem0
            // 
            this.metroTileItem0.DisabledBackColor = System.Drawing.Color.White;
            this.metroTileItem0.Name = "metroTileItem0";
            this.metroTileItem0.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem0.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.metroTileItem0.TileSize = new System.Drawing.Size(200, 100);
            // 
            // 
            // 
            this.metroTileItem0.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem0.TitleText = "基本型";
            this.metroTileItem0.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItem0.TitleTextColor = System.Drawing.Color.White;
            this.metroTileItem0.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.metroTileItem0.Click += new System.EventHandler(this.metroTileItem_Click);
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.metroTileItem1.TileSize = new System.Drawing.Size(200, 100);
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleText = "增强型";
            this.metroTileItem1.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItem1.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.metroTileItem1.Click += new System.EventHandler(this.metroTileItem_Click);
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.metroTileItem2.TileSize = new System.Drawing.Size(200, 100);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleText = "旗舰型";
            this.metroTileItem2.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItem2.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.metroTileItem2.Click += new System.EventHandler(this.metroTileItem_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(750, 543);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(104, 28);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonX1.TabIndex = 31;
            this.buttonX1.Text = "Cancel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(640, 543);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(104, 28);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonX2.TabIndex = 35;
            this.buttonX2.Text = "OK";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // superTabControl2
            // 
            this.superTabControl2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl2.ControlBox.MenuBox.Name = "";
            this.superTabControl2.ControlBox.Name = "";
            this.superTabControl2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl2.ControlBox.MenuBox,
            this.superTabControl2.ControlBox.CloseBox});
            this.superTabControl2.Controls.Add(this.superTabControlPanel2);
            this.superTabControl2.Controls.Add(this.superTabControlPanel8);
            this.superTabControl2.FixedTabSize = new System.Drawing.Size(70, 0);
            this.superTabControl2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl2.Location = new System.Drawing.Point(0, 0);
            this.superTabControl2.Name = "superTabControl2";
            this.superTabControl2.ReorderTabsEnabled = true;
            this.superTabControl2.SelectedTabFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl2.SelectedTabIndex = 0;
            this.superTabControl2.Size = new System.Drawing.Size(865, 537);
            this.superTabControl2.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.superTabControl2.TabFont = new System.Drawing.Font("Segoe UI", 9F);
            this.superTabControl2.TabIndex = 39;
            this.superTabControl2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2,
            this.superTabItem8});
            this.superTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl2.TabVerticalSpacing = 3;
            this.superTabControl2.Text = "superTabControl2";
            // 
            // superTabControlPanel8
            // 
            this.superTabControlPanel8.Controls.Add(this.panelEx3);
            this.superTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel8.Location = new System.Drawing.Point(72, 0);
            this.superTabControlPanel8.Name = "superTabControlPanel8";
            this.superTabControlPanel8.Size = new System.Drawing.Size(793, 537);
            this.superTabControlPanel8.TabIndex = 2;
            this.superTabControlPanel8.TabItem = this.superTabItem8;
            this.superTabControlPanel8.Visible = false;
            // 
            // panelEx3
            // 
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.line3);
            this.panelEx3.Controls.Add(this.comboBox2);
            this.panelEx3.Controls.Add(this.labelX2);
            this.panelEx3.Controls.Add(this.itemPanel3);
            this.panelEx3.Controls.Add(this.labelX1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(793, 537);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 23;
            // 
            // line3
            // 
            this.line3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.line3.Location = new System.Drawing.Point(15, 200);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(770, 2);
            this.line3.TabIndex = 44;
            this.line3.Text = "line3";
            // 
            // comboBox2
            // 
            this.comboBox2.DisplayMember = "Text";
            this.comboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 15;
            this.comboBox2.Location = new System.Drawing.Point(30, 260);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(179, 21);
            this.comboBox2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox2.TabIndex = 26;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(32, 223);
            this.labelX2.Name = "labelX2";
            this.labelX2.TabIndex = 25;
            this.labelX2.Text = "字符编码";
            // 
            // itemPanel3
            // 
            this.itemPanel3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.itemPanel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel3.ContainerControlProcessDialogKey = true;
            this.itemPanel3.DragDropSupport = true;
            this.itemPanel3.ForeColor = System.Drawing.Color.Black;
            this.itemPanel3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3});
            this.itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel3.Location = new System.Drawing.Point(30, 62);
            this.itemPanel3.Name = "itemPanel3";
            this.itemPanel3.Size = new System.Drawing.Size(760, 100);
            this.itemPanel3.TabIndex = 21;
            this.itemPanel3.Text = "itemPanel3";
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.ItemSpacing = 6;
            this.itemContainer3.MinimumSize = new System.Drawing.Size(745, 100);
            this.itemContainer3.MultiLine = true;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.ResizeItemsToFit = false;
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemshow0,
            this.itemshow1,
            this.itemshow2,
            this.itemshow3});
            // 
            // 
            // 
            this.itemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // itemshow0
            // 
            this.itemshow0.Name = "itemshow0";
            this.itemshow0.SymbolColor = System.Drawing.Color.Empty;
            this.itemshow0.Text = "<font size=\"30\">0</font>";
            this.itemshow0.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            this.itemshow0.TileSize = new System.Drawing.Size(180, 100);
            // 
            // 
            // 
            this.itemshow0.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemshow0.TitleText = "横屏";
            this.itemshow0.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.itemshow0.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemshow0.Click += new System.EventHandler(this.metroTileItemshow_Click);
            // 
            // itemshow1
            // 
            this.itemshow1.Name = "itemshow1";
            this.itemshow1.SymbolColor = System.Drawing.Color.Empty;
            this.itemshow1.Text = "<font size=\"30\">90</font>";
            this.itemshow1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            this.itemshow1.TileSize = new System.Drawing.Size(180, 100);
            // 
            // 
            // 
            this.itemshow1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemshow1.TitleText = "竖屏";
            this.itemshow1.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.itemshow1.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemshow1.Click += new System.EventHandler(this.metroTileItemshow_Click);
            // 
            // itemshow2
            // 
            this.itemshow2.Name = "itemshow2";
            this.itemshow2.SymbolColor = System.Drawing.Color.Empty;
            this.itemshow2.Text = "<font size=\"30\">180</font>";
            this.itemshow2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            this.itemshow2.TileSize = new System.Drawing.Size(180, 100);
            // 
            // 
            // 
            this.itemshow2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemshow2.TitleText = "横屏";
            this.itemshow2.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.itemshow2.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemshow2.Click += new System.EventHandler(this.metroTileItemshow_Click);
            // 
            // itemshow3
            // 
            this.itemshow3.Name = "itemshow3";
            this.itemshow3.SymbolColor = System.Drawing.Color.Empty;
            this.itemshow3.Text = "<font size=\"30\">270</font>";
            this.itemshow3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            this.itemshow3.TileSize = new System.Drawing.Size(180, 100);
            // 
            // 
            // 
            this.itemshow3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemshow3.TitleText = "竖屏";
            this.itemshow3.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.itemshow3.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemshow3.Click += new System.EventHandler(this.metroTileItemshow_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(33, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.TabIndex = 22;
            this.labelX1.Text = "显示方向";
            // 
            // superTabItem8
            // 
            this.superTabItem8.AttachedControl = this.superTabControlPanel8;
            this.superTabItem8.GlobalItem = false;
            this.superTabItem8.Name = "superTabItem8";
            this.superTabItem8.Text = "显示";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.panelEx4);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(72, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(793, 537);
            this.superTabControlPanel2.TabIndex = 1;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // panelEx4
            // 
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.line2);
            this.panelEx4.Controls.Add(this.line1);
            this.panelEx4.Controls.Add(this.itemPanel2);
            this.panelEx4.Controls.Add(this.panelEx1);
            this.panelEx4.Controls.Add(this.itemPanel1);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(793, 537);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 38;
            this.panelEx4.Text = "panelEx4";
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.Gray;
            this.line2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.line2.Location = new System.Drawing.Point(180, 147);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(30, 3);
            this.line2.TabIndex = 48;
            this.line2.Text = "line2";
            this.line2.Thickness = 3;
            this.line2.Visible = false;
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.line1.Location = new System.Drawing.Point(9, 160);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(770, 2);
            this.line1.TabIndex = 43;
            this.line1.Text = "line1";
            // 
            // itemPanel2
            // 
            this.itemPanel2.AutoScroll = true;
            this.itemPanel2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.DragDropSupport = true;
            this.itemPanel2.ForeColor = System.Drawing.Color.Black;
            this.itemPanel2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2});
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(14, 179);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(770, 355);
            this.itemPanel2.TabIndex = 39;
            this.itemPanel2.Text = "itemPanel4";
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.ItemSpacing = 5;
            this.itemContainer2.MinimumSize = new System.Drawing.Size(768, 118);
            this.itemContainer2.MultiLine = true;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.ResizeItemsToFit = false;
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tem0});
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // tem0
            // 
            this.tem0.Name = "tem0";
            this.tem0.SymbolColor = System.Drawing.Color.Empty;
            this.tem0.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray;
            this.tem0.TileSize = new System.Drawing.Size(380, 55);
            // 
            // 
            // 
            this.tem0.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tem0.TitleText = "TJC3224T022_011";
            this.tem0.TitleTextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tem0.TitleTextFont = new System.Drawing.Font("宋体", 18F);
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(793, 34);
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Style.MarginLeft = 4;
            this.panelEx1.TabIndex = 38;
            this.panelEx1.Text = "Please Select The Model";
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(774, 12);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(19, 17);
            this.panelEx2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Center;
            this.panelEx2.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.TabIndex = 2;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "设备";
            // 
            // metroTileItem6
            // 
            this.metroTileItem6.Name = "metroTileItem6";
            this.metroTileItem6.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray;
            this.metroTileItem6.TileSize = new System.Drawing.Size(180, 100);
            // 
            // 
            // 
            this.metroTileItem6.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem6.TitleText = "旗舰型(研发中)";
            this.metroTileItem6.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItem6.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // metroTileItem8
            // 
            this.metroTileItem8.Name = "metroTileItem8";
            this.metroTileItem8.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem8.Text = "<font size=\"10\">\r\n支持RTC<br/>\r\n支持用户存储<br/>\r\n8路扩展IO<br/>\r\n更大的Flash空间<br/>\r\n</font>";
            this.metroTileItem8.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray;
            this.metroTileItem8.TileSize = new System.Drawing.Size(180, 100);
            // 
            // 
            // 
            this.metroTileItem8.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem8.TitleText = "增强型";
            this.metroTileItem8.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItem8.TitleTextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // appset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(865, 576);
            this.Controls.Add(this.superTabControl2);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "appset";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).EndInit();
            this.superTabControl2.ResumeLayout(false);
            this.superTabControlPanel8.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}