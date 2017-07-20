using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColList;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
using rsapp;
using run;
using USARTHMI.Properties;

namespace USARTHMI
{
    partial class main
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
         
            ComponentResourceManager resources = new ComponentResourceManager(typeof(main));
            this.web1label = new Label();
            this.webBrowser2 = new WebBrowser();
            this.web2label = new Label();
            this.dockContainerItem2 = new DockContainerItem();
            this.dockContainerItem3 = new DockContainerItem();
            this.bar1 = new Bar();
            this.labelItem4 = new LabelItem();
            this.labelItem5 = new LabelItem();
            this.labelItem1 = new LabelItem();
            this.labelItem2 = new LabelItem();
            this.labelItem3 = new LabelItem();
            this.dotNetBarManager1 = new DotNetBarManager(this.components);
            this.dockSite4 = new DockSite();
            this.bar3 = new Bar();
            this.panelDockContainer7 = new PanelDockContainer();
            this.textbianyi = new RichTextBox();
            this.dockContainerItem9 = new DockContainerItem();
            this.bar9 = new Bar();
            this.panelDockContainer8 = new PanelDockContainer();
            this.objatt1 = new objattoo();
            this.dockContainerItem10 = new DockContainerItem();
            this.dockSite1 = new DockSite();
            this.bar2 = new Bar();
            this.panelDockContainer5 = new PanelDockContainer();
            this.zikuadmin1 = new zikuadmin();
            this.panelDockContainer4 = new PanelDockContainer();
            this.picadmin1 = new picadmin();
            this.dockContainerItem6 = new DockContainerItem();
            this.dockContainerItem7 = new DockContainerItem();
            this.bargongju = new Bar();
            this.panelDockContainer1 = new PanelDockContainer();
            this.colListBox1 = new ColListBox();
            this.dockContainerItem4 = new DockContainerItem();
            this.dockSite2 = new DockSite();
            this.bar4 = new Bar();
            this.panelDockContainer6 = new PanelDockContainer();
            this.objatt2 = new objatt();
            this.dockContainerItem8 = new DockContainerItem();
            this.bar8 = new Bar();
            this.panelDockContainer2 = new PanelDockContainer();
            this.pageadmin1 = new pageadmin();
            this.dockContainerItem5 = new DockContainerItem();
            this.dockSite8 = new DockSite();
            this.dockSite5 = new DockSite();
            this.dockSite6 = new DockSite();
            this.dockSite7 = new DockSite();
            this.bar5 = new Bar();
            this.buttonItem1 = new ButtonItem();
            this.buttonItem4 = new ButtonItem();
            this.buttonItem8 = new ButtonItem();
            this.buttonItem9 = new ButtonItem();
            this.buttonItem10 = new ButtonItem();
            this.buttonItem11 = new ButtonItem();
            this.buttonItem12 = new ButtonItem();
            this.ClearHis = new ButtonItem();
            this.buttonItem13 = new ButtonItem();
            this.buttonItem14 = new ButtonItem();
            this.buttonItem15 = new ButtonItem();
            this.buttonItem5 = new ButtonItem();
            this.buttonItem32 = new ButtonItem();
            this.shezhi = new ButtonItem();
            this.buttonItem20 = new ButtonItem();
            this.buttonItem17 = new ButtonItem();
            this.buttonItem6 = new ButtonItem();
            this.buttonItemhelp1 = new ButtonItem();
            this.buttonItemhelp2 = new ButtonItem();
            this.buttonItemhelp3 = new ButtonItem();
            this.buttonItemhelp4 = new ButtonItem();
            this.buttonItemhelp5 = new ButtonItem();
            this.buttonItemhelp6 = new ButtonItem();
            this.buttonItem7 = new ButtonItem();
            this.buttonItem34 = new ButtonItem();
            this.buttonItem35 = new ButtonItem();
            this.buttonItem47 = new ButtonItem();
            this.bChangeStyle = new ButtonItem();
            this.buttonItem38 = new ButtonItem();
            this.cmdStyleVS2005 = new ButtonItem();
            this.gongju0 = new Bar();
            this.buttonItem2 = new ButtonItem();
            this.buttonItem3 = new ButtonItem();
            this.tsave = new ButtonItem();
            this.tbianyi = new ButtonItem();
            this.buttonItem18 = new ButtonItem();
            this.buttonItem26 = new ButtonItem();
            this.gongju1 = new Bar();
            this.tcopy = new ButtonItem();
            this.buttonItem29 = new ButtonItem();
            this.tzhantie = new ButtonItem();
            this.gongju2 = new Bar();
            this.buttonItem39 = new ButtonItem();
            this.buttonItem40 = new ButtonItem();
            this.buttonItem41 = new ButtonItem();
            this.gongju3 = new Bar();
            this.buttonItem31 = new ButtonItem();
            this.buttonItem42 = new ButtonItem();
            this.gongju4 = new Bar();
            this.buttonItem43 = new ButtonItem();
            this.buttonItem44 = new ButtonItem();
            this.buttonItem23 = new ButtonItem();
            this.buttonItem24 = new ButtonItem();
            this.buttonItem25 = new ButtonItem();
            this.buttonItem27 = new ButtonItem();
            this.buttonItem28 = new ButtonItem();
            this.buttonItem30 = new ButtonItem();
            this.buttonItem36 = new ButtonItem();
            this.buttonItem21 = new ButtonItem();
            this.buttonItem22 = new ButtonItem();
            this.buttonItem33 = new ButtonItem();
            this.buttonItem37 = new ButtonItem();
            this.buttonItem45 = new ButtonItem();
            this.buttonItem46 = new ButtonItem();
            this.dockSite3 = new DockSite();
            this.imageList1 = new ImageList(this.components);
            this.buttonItem16 = new ButtonItem();
            this.buttonItem19 = new ButtonItem();
            this.dockContainerItem11 = new DockContainerItem();
            this.panelDockContainer9 = new PanelDockContainer();
            this.panelEx2 = new PanelEx();
            this.styleManager1 = new StyleManager(this.components);
            this.tabControl1 = new SuperTabControl();
            this.superTabControlPanel1 = new SuperTabControlPanel();
            this.panelEx3 = new Colpanel.Colpanel();
            this.pictureBox2 = new PictureBox();
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            this.textobjbianyi = new TextBox();
            this.panelEx1 = new PanelEx();
            this.textobj = new TextBox();
            this.textpage = new TextBox();
            this.listBox1 = new ListBox();
            this.listBox4 = new ListBox();
            this.expandablePanel1 = new ExpandablePanel();
            this.itemPanel2 = new ItemPanel();
            this.labelX2 = new LabelX();
            this.linkLabel1 = new LinkLabel();
            this.labelX1 = new LabelX();
            this.pictureBox1 = new PictureBox();
            this.runscr1 = new runscr();
            this.expandablePanellishi = new ExpandablePanel();
            this.itemPanelhis = new ItemPanel();
            this.objpanel = new Colpanel.Colpanel();
            this.superTabItem1 = new SuperTabItem();
            this.panel1 = new Panel();
            this.panelEx4 = new PanelEx();
            this.superTabControlPanel2 = new SuperTabControlPanel();
            this.webBrowser1 = new WebBrowser();
            this.superTabItembbs = new SuperTabItem();
            this.superTabControlPanel3 = new SuperTabControlPanel();
            this.superTabItemcom = new SuperTabItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timermessage = new System.Windows.Forms.Timer(this.components);
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            ((ISupportInitialize)this.bar1).BeginInit();
            this.dockSite4.SuspendLayout();
            ((ISupportInitialize)this.bar3).BeginInit();
            this.bar3.SuspendLayout();
            this.panelDockContainer7.SuspendLayout();
            ((ISupportInitialize)this.bar9).BeginInit();
            this.bar9.SuspendLayout();
            this.panelDockContainer8.SuspendLayout();
            this.dockSite1.SuspendLayout();
            ((ISupportInitialize)this.bar2).BeginInit();
            this.bar2.SuspendLayout();
            this.panelDockContainer5.SuspendLayout();
            this.panelDockContainer4.SuspendLayout();
            ((ISupportInitialize)this.bargongju).BeginInit();
            this.bargongju.SuspendLayout();
            this.panelDockContainer1.SuspendLayout();
            this.dockSite2.SuspendLayout();
            ((ISupportInitialize)this.bar4).BeginInit();
            this.bar4.SuspendLayout();
            this.panelDockContainer6.SuspendLayout();
            ((ISupportInitialize)this.bar8).BeginInit();
            this.bar8.SuspendLayout();
            this.panelDockContainer2.SuspendLayout();
            this.dockSite7.SuspendLayout();
            ((ISupportInitialize)this.bar5).BeginInit();
            ((ISupportInitialize)this.gongju0).BeginInit();
            ((ISupportInitialize)this.gongju1).BeginInit();
            ((ISupportInitialize)this.gongju2).BeginInit();
            ((ISupportInitialize)this.gongju3).BeginInit();
            ((ISupportInitialize)this.gongju4).BeginInit();
            this.panelDockContainer9.SuspendLayout();
            ((ISupportInitialize)this.tabControl1).BeginInit();
            this.tabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((ISupportInitialize)this.pictureBox2).BeginInit();
            this.groupBox1.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.itemPanel2.SuspendLayout();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            this.expandablePanellishi.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            base.SuspendLayout();
            this.web1label.AutoSize = true;
            this.web1label.BackColor = Color.Transparent;
            this.web1label.Location = new Point(6, 9);
            this.web1label.Name = "web1label";
            this.web1label.Size = new Size(65, 12);
            this.web1label.TabIndex = 1;
            this.web1label.Text = "loading...";
            this.webBrowser2.Dock = DockStyle.Fill;
            this.webBrowser2.Location = new Point(0, 0);
            this.webBrowser2.MinimumSize = new Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new Size(568, 372);
            this.webBrowser2.TabIndex = 0;
            this.webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
            this.web2label.AutoSize = true;
            this.web2label.BackColor = Color.Transparent;
            this.web2label.Location = new Point(6, 10);
            this.web2label.Name = "web2label";
            this.web2label.Size = new Size(65, 12);
            this.web2label.TabIndex = 2;
            this.web2label.Text = "加载中....";
            this.dockContainerItem2.Name = "dockContainerItem2";
            this.dockContainerItem2.Text = "dockContainerItem2";
            this.dockContainerItem3.Name = "dockContainerItem3";
            this.dockContainerItem3.Text = "dockContainerItem3";
            this.bar1.AntiAlias = true;
            this.bar1.Dock = DockStyle.Bottom;
            this.bar1.Font = new Font("微软雅黑", 9f);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new BaseItem[]
            {
                this.labelItem4,
                this.labelItem5,
                this.labelItem1,
                this.labelItem2,
                this.labelItem3
            });
            this.bar1.Location = new Point(0, 709);
            this.bar1.Name = "bar1";
            this.bar1.Size = new Size(1008, 21);
            this.bar1.Stretch = true;
            this.bar1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 210;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "Encoding:";
            this.labelItem4.MouseLeave += new EventHandler(this.labelItem4_MouseLeave);
            this.labelItem4.MouseMove += new MouseEventHandler(this.labelItem4_MouseMove);
            this.labelItem4.Click += new EventHandler(this.labelItem4_Click);
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Text = "|";
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "labelItem1";
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "   ";
            this.labelItem3.ForeColor = Color.Blue;
            this.labelItem3.ItemAlignment = eItemAlignment.Far;
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "upmessage";
            this.labelItem3.MouseLeave += new EventHandler(this.labelItem3_MouseLeave);
            this.labelItem3.MouseMove += new MouseEventHandler(this.labelItem3_MouseMove);
            this.labelItem3.Click += new EventHandler(this.labelItem3_Click);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = eDotNetBarStyle.Windows7;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            this.dockSite4.AccessibleRole = AccessibleRole.Window;
            this.dockSite4.Controls.Add(this.bar3);
            this.dockSite4.Controls.Add(this.bar9);
            this.dockSite4.Dock = DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DocumentDockContainer(new DocumentBaseContainer[]
            {
                new DocumentBarContainer(this.bar3, 291, 226),
                new DocumentBarContainer(this.bar9, 274, 226)
            }, eOrientation.Horizontal);
            this.dockSite4.Location = new Point(220, 480);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new Size(568, 229);
            this.dockSite4.TabIndex = 227;
            this.dockSite4.TabStop = false;
            this.bar3.AccessibleDescription = "DotNetBar Bar (bar3)";
            this.bar3.AccessibleName = "DotNetBar Bar";
            this.bar3.AccessibleRole = AccessibleRole.Grouping;
            this.bar3.AutoSyncBarCaption = true;
            this.bar3.CloseSingleTab = true;
            this.bar3.Controls.Add(this.panelDockContainer7);
            this.bar3.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.bar3.GrabHandleStyle = eGrabHandleStyle.Caption;
            this.bar3.IsMaximized = false;
            this.bar3.Items.AddRange(new BaseItem[]
            {
                this.dockContainerItem9
            });
            this.bar3.LayoutType = eLayoutType.DockContainer;
            this.bar3.Location = new Point(0, 3);
            this.bar3.Name = "bar3";
            this.bar3.Size = new Size(291, 226);
            this.bar3.Stretch = true;
            this.bar3.Style = eDotNetBarStyle.Windows7;
            this.bar3.TabIndex = 0;
            this.bar3.TabStop = false;
            this.bar3.Text = "输出";
            this.panelDockContainer7.ColorSchemeStyle = eDotNetBarStyle.Windows7;
            this.panelDockContainer7.Controls.Add(this.textbianyi);
            this.panelDockContainer7.DisabledBackColor = Color.Empty;
            this.panelDockContainer7.Location = new Point(3, 23);
            this.panelDockContainer7.Name = "panelDockContainer7";
            this.panelDockContainer7.Size = new Size(285, 200);
            this.panelDockContainer7.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer7.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer7.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer7.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer7.Style.GradientAngle = 90;
            this.panelDockContainer7.TabIndex = 5;
            this.textbianyi.BackColor = Color.White;
            this.textbianyi.BorderStyle = BorderStyle.FixedSingle;
            this.textbianyi.Dock = DockStyle.Fill;
            this.textbianyi.Location = new Point(0, 0);
            this.textbianyi.Name = "textbianyi";
            this.textbianyi.ReadOnly = true;
            this.textbianyi.Size = new Size(285, 200);
            this.textbianyi.TabIndex = 0;
            this.textbianyi.Text = "";
            this.textbianyi.WordWrap = false;
            this.textbianyi.DoubleClick += new EventHandler(this.textbianyi_DoubleClick);
            this.dockContainerItem9.Control = this.panelDockContainer7;
            this.dockContainerItem9.Name = "dockContainerItem9";
            this.dockContainerItem9.Text = "输出";
            this.bar9.AccessibleDescription = "DotNetBar Bar (bar9)";
            this.bar9.AccessibleName = "DotNetBar Bar";
            this.bar9.AccessibleRole = AccessibleRole.Grouping;
            this.bar9.AutoSyncBarCaption = true;
            this.bar9.CloseSingleTab = true;
            this.bar9.Controls.Add(this.panelDockContainer8);
            this.bar9.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.bar9.GrabHandleStyle = eGrabHandleStyle.Caption;
            this.bar9.IsMaximized = false;
            this.bar9.Items.AddRange(new BaseItem[]
            {
                this.dockContainerItem10
            });
            this.bar9.LayoutType = eLayoutType.DockContainer;
            this.bar9.Location = new Point(294, 3);
            this.bar9.Name = "bar9";
            this.bar9.Size = new Size(274, 226);
            this.bar9.Stretch = true;
            this.bar9.Style = eDotNetBarStyle.Windows7;
            this.bar9.TabIndex = 1;
            this.bar9.TabStop = false;
            this.bar9.Text = "事件";
            this.panelDockContainer8.ColorSchemeStyle = eDotNetBarStyle.Windows7;
            this.panelDockContainer8.Controls.Add(this.objatt1);
            this.panelDockContainer8.DisabledBackColor = Color.Empty;
            this.panelDockContainer8.Location = new Point(3, 23);
            this.panelDockContainer8.Name = "panelDockContainer8";
            this.panelDockContainer8.Size = new Size(268, 200);
            this.panelDockContainer8.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer8.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer8.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer8.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer8.Style.GradientAngle = 90;
            this.panelDockContainer8.TabIndex = 9;
            this.objatt1.BackColor = Color.White;
            this.objatt1.Dock = DockStyle.Fill;
            this.objatt1.Location = new Point(0, 0);
            this.objatt1.Name = "objatt1";
            this.objatt1.Size = new Size(268, 200);
            this.objatt1.TabIndex = 178;
            this.objatt1.changatt += new EventHandler(this.objatt1_changatt);
            this.objatt1.saveapp += new EventHandler(this.objatt1_saveapp);
            this.dockContainerItem10.Control = this.panelDockContainer8;
            this.dockContainerItem10.Name = "dockContainerItem10";
            this.dockContainerItem10.Text = "事件";
            this.dockSite1.AccessibleRole = AccessibleRole.Window;
            this.dockSite1.Controls.Add(this.bar2);
            this.dockSite1.Controls.Add(this.bargongju);
            this.dockSite1.Dock = DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DocumentDockContainer(new DocumentBaseContainer[]
            {
                new DocumentBarContainer(this.bargongju, 217, 308),
                new DocumentBarContainer(this.bar2, 217, 318)
            }, eOrientation.Vertical);
            this.dockSite1.Location = new Point(0, 80);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new Size(220, 629);
            this.dockSite1.TabIndex = 224;
            this.dockSite1.TabStop = false;
            this.bar2.AccessibleDescription = "DotNetBar Bar (bar2)";
            this.bar2.AccessibleName = "DotNetBar Bar";
            this.bar2.AccessibleRole = AccessibleRole.Grouping;
            this.bar2.AutoSyncBarCaption = true;
            this.bar2.CloseSingleTab = true;
            this.bar2.Controls.Add(this.panelDockContainer5);
            this.bar2.Controls.Add(this.panelDockContainer4);
            this.bar2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.bar2.GrabHandleStyle = eGrabHandleStyle.Caption;
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new BaseItem[]
            {
                this.dockContainerItem6,
                this.dockContainerItem7
            });
            this.bar2.LayoutType = eLayoutType.DockContainer;
            this.bar2.Location = new Point(0, 311);
            this.bar2.Name = "bar2";
            this.bar2.SelectedDockTab = 1;
            this.bar2.Size = new Size(217, 318);
            this.bar2.Stretch = true;
            this.bar2.Style = eDotNetBarStyle.Windows7;
            this.bar2.TabIndex = 0;
            this.bar2.TabStop = false;
            this.bar2.Text = "字库";
            this.panelDockContainer5.ColorSchemeStyle = eDotNetBarStyle.Windows7;
            this.panelDockContainer5.Controls.Add(this.zikuadmin1);
            this.panelDockContainer5.DisabledBackColor = Color.Empty;
            this.panelDockContainer5.Location = new Point(3, 23);
            this.panelDockContainer5.Name = "panelDockContainer5";
            this.panelDockContainer5.Size = new Size(211, 267);
            this.panelDockContainer5.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer5.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer5.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer5.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer5.Style.GradientAngle = 90;
            this.panelDockContainer5.TabIndex = 9;
            this.zikuadmin1.BackColor = SystemColors.Control;
            this.zikuadmin1.Dock = DockStyle.Fill;
            this.zikuadmin1.Location = new Point(0, 0);
            this.zikuadmin1.Name = "zikuadmin1";
            this.zikuadmin1.Size = new Size(211, 267);
            this.zikuadmin1.TabIndex = 123;
            this.zikuadmin1.zikuupdate += new EventHandler(this.zikuadmin1_zikuupdate);
            this.panelDockContainer4.ColorSchemeStyle = eDotNetBarStyle.Windows7;
            this.panelDockContainer4.Controls.Add(this.picadmin1);
            this.panelDockContainer4.DisabledBackColor = Color.Empty;
            this.panelDockContainer4.Location = new Point(3, 23);
            this.panelDockContainer4.Name = "panelDockContainer4";
            this.panelDockContainer4.Size = new Size(211, 267);
            this.panelDockContainer4.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer4.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer4.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer4.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer4.Style.GradientAngle = 90;
            this.panelDockContainer4.TabIndex = 5;
            this.picadmin1.BackColor = SystemColors.Control;
            this.picadmin1.Dock = DockStyle.Fill;
            this.picadmin1.Location = new Point(0, 0);
            this.picadmin1.Name = "picadmin1";
            this.picadmin1.Size = new Size(211, 267);
            this.picadmin1.TabIndex = 112;
            this.picadmin1.picupdate += new EventHandler(this.picadmin1_picupdate);
            this.dockContainerItem6.Control = this.panelDockContainer4;
            this.dockContainerItem6.Name = "dockContainerItem6";
            this.dockContainerItem6.Text = "图片";
            this.dockContainerItem7.Control = this.panelDockContainer5;
            this.dockContainerItem7.Name = "dockContainerItem7";
            this.dockContainerItem7.Text = "字库";
            this.bargongju.AccessibleDescription = "DotNetBar Bar (bargongju)";
            this.bargongju.AccessibleName = "DotNetBar Bar";
            this.bargongju.AccessibleRole = AccessibleRole.Grouping;
            this.bargongju.AutoHideAnimationTime = 0;
            this.bargongju.AutoSyncBarCaption = true;
            this.bargongju.CloseSingleTab = true;
            this.bargongju.Controls.Add(this.panelDockContainer1);
            this.bargongju.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.bargongju.GrabHandleStyle = eGrabHandleStyle.Caption;
            this.bargongju.IsMaximized = false;
            this.bargongju.Items.AddRange(new BaseItem[]
            {
                this.dockContainerItem4
            });
            this.bargongju.LayoutType = eLayoutType.DockContainer;
            this.bargongju.Location = new Point(0, 0);
            this.bargongju.Name = "bargongju";
            this.bargongju.Size = new Size(217, 308);
            this.bargongju.Stretch = true;
            this.bargongju.Style = eDotNetBarStyle.Windows7;
            this.bargongju.TabIndex = 1;
            this.bargongju.TabStop = false;
            this.bargongju.Text = "工具箱";
            this.panelDockContainer1.ColorSchemeStyle = eDotNetBarStyle.Windows7;
            this.panelDockContainer1.Controls.Add(this.colListBox1);
            this.panelDockContainer1.DisabledBackColor = Color.Empty;
            this.panelDockContainer1.Location = new Point(3, 23);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new Size(211, 282);
            this.panelDockContainer1.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 0;
            this.colListBox1.BackColor = Color.White;
            this.colListBox1.Dock = DockStyle.Fill;
            this.colListBox1.EditState = false;
            this.colListBox1.idwidth = 5;
            this.colListBox1.imglayout = 0;
            this.colListBox1.itembackcolor_select = Color.Blue;
            this.colListBox1.itembordercolor_move = Color.FromArgb(228, 156, 5);
            this.colListBox1.itembordercolor_select = Color.Blue;
            this.colListBox1.itemeditenabled = false;
            this.colListBox1.itemfontcolor_defaut = Color.Black;
            this.colListBox1.itemfontcolor_select = Color.White;
            this.colListBox1.Itemfontsize = 9;
            this.colListBox1.Itemheight = 18;
            this.colListBox1.itemmovebackcolor1 = Color.FromArgb(255, 255, 192);
            this.colListBox1.itemmovestate = true;
            this.colListBox1.Itemschonghui = true;
            this.colListBox1.listbordercolor = Color.FromArgb(51, 153, 255);
            this.colListBox1.listborderwidth = 1;
            this.colListBox1.Location = new Point(0, 0);
            this.colListBox1.Name = "colListBox1";
            this.colListBox1.SelectItemindex = -1;
            this.colListBox1.Size = new Size(211, 282);
            this.colListBox1.TabIndex = 1;
            this.colListBox1.ItemMouseUP += new EventHandler(this.colListBox1_ItemMouseUP);
            this.dockContainerItem4.Control = this.panelDockContainer1;
            this.dockContainerItem4.Name = "dockContainerItem4";
            this.dockContainerItem4.Text = "工具箱";
            this.dockSite2.AccessibleRole = AccessibleRole.Window;
            this.dockSite2.Controls.Add(this.bar4);
            this.dockSite2.Controls.Add(this.bar8);
            this.dockSite2.Dock = DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DocumentDockContainer(new DocumentBaseContainer[]
            {
                new DocumentBarContainer(this.bar8, 217, 310),
                new DocumentBarContainer(this.bar4, 217, 316)
            }, eOrientation.Vertical);
            this.dockSite2.Location = new Point(788, 80);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new Size(220, 629);
            this.dockSite2.TabIndex = 225;
            this.dockSite2.TabStop = false;
            this.bar4.AccessibleDescription = "DotNetBar Bar (bar4)";
            this.bar4.AccessibleName = "DotNetBar Bar";
            this.bar4.AccessibleRole = AccessibleRole.Grouping;
            this.bar4.AutoSyncBarCaption = true;
            this.bar4.CloseSingleTab = true;
            this.bar4.Controls.Add(this.panelDockContainer6);
            this.bar4.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.bar4.GrabHandleStyle = eGrabHandleStyle.Caption;
            this.bar4.IsMaximized = false;
            this.bar4.Items.AddRange(new BaseItem[]
            {
                this.dockContainerItem8
            });
            this.bar4.LayoutType = eLayoutType.DockContainer;
            this.bar4.Location = new Point(3, 313);
            this.bar4.Name = "bar4";
            this.bar4.Size = new Size(217, 316);
            this.bar4.Stretch = true;
            this.bar4.Style = eDotNetBarStyle.Windows7;
            this.bar4.TabIndex = 0;
            this.bar4.TabStop = false;
            this.bar4.Text = "属性";
            this.panelDockContainer6.ColorSchemeStyle = eDotNetBarStyle.Windows7;
            this.panelDockContainer6.Controls.Add(this.objatt2);
            this.panelDockContainer6.DisabledBackColor = Color.Empty;
            this.panelDockContainer6.Location = new Point(3, 23);
            this.panelDockContainer6.Name = "panelDockContainer6";
            this.panelDockContainer6.Size = new Size(211, 290);
            this.panelDockContainer6.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer6.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer6.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer6.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer6.Style.GradientAngle = 90;
            this.panelDockContainer6.TabIndex = 5;
            this.objatt2.BackColor = SystemColors.Control;
            this.objatt2.Dock = DockStyle.Fill;
            this.objatt2.Location = new Point(0, 0);
            this.objatt2.Name = "objatt2";
            this.objatt2.Size = new Size(211, 290);
            this.objatt2.TabIndex = 113;
            this.objatt2.attchhuigun += new EventHandler(this.objatt2_attchhuigun);
            this.objatt2.changepage += new EventHandler(this.objatt2_changepage);
            this.objatt2.selectobj += new EventHandler(this.objatt2_selectobj);
            this.objatt2.attch += new EventHandler(this.objatt2_attch);
            this.dockContainerItem8.Control = this.panelDockContainer6;
            this.dockContainerItem8.Name = "dockContainerItem8";
            this.dockContainerItem8.Text = "属性";
            this.bar8.AccessibleDescription = "DotNetBar Bar (bar8)";
            this.bar8.AccessibleName = "DotNetBar Bar";
            this.bar8.AccessibleRole = AccessibleRole.Grouping;
            this.bar8.AutoSyncBarCaption = true;
            this.bar8.CloseSingleTab = true;
            this.bar8.Controls.Add(this.panelDockContainer2);
            this.bar8.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.bar8.GrabHandleStyle = eGrabHandleStyle.Caption;
            this.bar8.IsMaximized = false;
            this.bar8.Items.AddRange(new BaseItem[]
            {
                this.dockContainerItem5
            });
            this.bar8.LayoutType = eLayoutType.DockContainer;
            this.bar8.Location = new Point(3, 0);
            this.bar8.Name = "bar8";
            this.bar8.Size = new Size(217, 310);
            this.bar8.Stretch = true;
            this.bar8.Style = eDotNetBarStyle.Windows7;
            this.bar8.TabIndex = 1;
            this.bar8.TabStop = false;
            this.bar8.Text = "页面";
            this.panelDockContainer2.ColorSchemeStyle = eDotNetBarStyle.Windows7;
            this.panelDockContainer2.Controls.Add(this.pageadmin1);
            this.panelDockContainer2.DisabledBackColor = Color.Empty;
            this.panelDockContainer2.Location = new Point(3, 23);
            this.panelDockContainer2.Name = "panelDockContainer2";
            this.panelDockContainer2.Size = new Size(211, 284);
            this.panelDockContainer2.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer2.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer2.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer2.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer2.Style.GradientAngle = 90;
            this.panelDockContainer2.TabIndex = 0;
            this.pageadmin1.BackColor = SystemColors.Control;
            this.pageadmin1.Dock = DockStyle.Fill;
            this.pageadmin1.Location = new Point(0, 0);
            this.pageadmin1.Name = "pageadmin1";
            this.pageadmin1.Size = new Size(211, 284);
            this.pageadmin1.TabIndex = 144;
            this.pageadmin1.pagecheng += new EventHandler(this.pageadmin1_pagecheng);
            this.pageadmin1.Selectenter += new EventHandler(this.pageadmin1_Selectenter);
            this.dockContainerItem5.Control = this.panelDockContainer2;
            this.dockContainerItem5.Name = "dockContainerItem5";
            this.dockContainerItem5.Text = "页面";
            this.dockSite8.AccessibleRole = AccessibleRole.Window;
            this.dockSite8.Dock = DockStyle.Bottom;
            this.dockSite8.Location = new Point(0, 730);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new Size(1008, 0);
            this.dockSite8.TabIndex = 231;
            this.dockSite8.TabStop = false;
            this.dockSite5.AccessibleRole = AccessibleRole.Window;
            this.dockSite5.Dock = DockStyle.Left;
            this.dockSite5.Location = new Point(0, 80);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new Size(0, 650);
            this.dockSite5.TabIndex = 228;
            this.dockSite5.TabStop = false;
            this.dockSite6.AccessibleRole = AccessibleRole.Window;
            this.dockSite6.Dock = DockStyle.Right;
            this.dockSite6.Location = new Point(1008, 80);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new Size(0, 650);
            this.dockSite6.TabIndex = 229;
            this.dockSite6.TabStop = false;
            this.dockSite7.AccessibleRole = AccessibleRole.Window;
            this.dockSite7.Controls.Add(this.bar5);
            this.dockSite7.Controls.Add(this.gongju0);
            this.dockSite7.Controls.Add(this.gongju1);
            this.dockSite7.Controls.Add(this.gongju2);
            this.dockSite7.Controls.Add(this.gongju3);
            this.dockSite7.Controls.Add(this.gongju4);
            this.dockSite7.Dock = DockStyle.Top;
            this.dockSite7.Location = new Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new Size(1008, 80);
            this.dockSite7.TabIndex = 230;
            this.dockSite7.TabStop = false;
            this.bar5.AccessibleDescription = "DotNetBar Bar (bar5)";
            this.bar5.AccessibleName = "DotNetBar Bar";
            this.bar5.AccessibleRole = AccessibleRole.MenuBar;
            this.bar5.DockSide = eDockSide.Top;
            this.bar5.Font = new Font("微软雅黑", 9f);
            this.bar5.IsMaximized = false;
            this.bar5.Items.AddRange(new BaseItem[]
            {
                this.buttonItem1,
                this.buttonItem5,
                this.shezhi,
                this.buttonItem6,
                this.buttonItem7,
                this.bChangeStyle
            });
            this.bar5.Location = new Point(0, 0);
            this.bar5.MenuBar = true;
            this.bar5.Name = "bar5";
            this.bar5.Size = new Size(1008, 26);
            this.bar5.Stretch = true;
            this.bar5.Style = eDotNetBarStyle.Windows7;
            this.bar5.TabIndex = 0;
            this.bar5.TabStop = false;
            this.bar5.Text = "bar5";
            this.bar5.ItemClick += new EventHandler(this.bar5_ItemClick);
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new BaseItem[]
            {
                this.buttonItem4,
                this.buttonItem8,
                this.buttonItem9,
                this.buttonItem10,
                this.buttonItem11,
                this.buttonItem12,
                this.ClearHis,
                this.buttonItem13,
                this.buttonItem14,
                this.buttonItem15
            });
            this.buttonItem1.Text = "文件";
            this.buttonItem1.Click += new EventHandler(this.buttonItem1_Click);
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "编译文件夹";
            this.buttonItem4.Click += new EventHandler(this.buttonItem4_Click);
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Text = "打开";
            this.buttonItem8.Click += new EventHandler(this.buttonItem8_Click);
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.Text = "新建";
            this.buttonItem9.Click += new EventHandler(this.buttonItem9_Click);
            this.buttonItem10.Name = "buttonItem10";
            this.buttonItem10.Text = "保存";
            this.buttonItem10.Click += new EventHandler(this.buttonItem10_Click);
            this.buttonItem11.Name = "buttonItem11";
            this.buttonItem11.Text = "另存为";
            this.buttonItem11.Click += new EventHandler(this.buttonItem11_Click);
            this.buttonItem12.Name = "buttonItem12";
            this.buttonItem12.Text = "版本备份目录";
            this.buttonItem12.Click += new EventHandler(this.buttonItem12_Click);
            this.ClearHis.Name = "ClearHis";
            this.ClearHis.Text = "清空历史项目打开记录";
            this.ClearHis.Click += new EventHandler(this.ClearHis_Click);
            this.buttonItem13.Name = "buttonItem13";
            this.buttonItem13.Text = "导入工程";
            this.buttonItem13.Click += new EventHandler(this.buttonItem13_Click);
            this.buttonItem14.Name = "buttonItem14";
            this.buttonItem14.Text = "关闭工程";
            this.buttonItem14.Click += new EventHandler(this.buttonItem14_Click);
            this.buttonItem15.Name = "buttonItem15";
            this.buttonItem15.Text = "退出";
            this.buttonItem15.Click += new EventHandler(this.buttonItem15_Click);
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.SubItems.AddRange(new BaseItem[]
            {
                this.buttonItem32
            });
            this.buttonItem5.Text = "工具";
            this.buttonItem32.Name = "buttonItem32";
            this.buttonItem32.Text = "字库制作";
            this.buttonItem32.Click += new EventHandler(this.buttonItem32_Click);
            this.shezhi.Name = "shezhi";
            this.shezhi.SubItems.AddRange(new BaseItem[]
            {
                this.buttonItem20,
                this.buttonItem17
            });
            this.shezhi.Text = "设置";
            this.buttonItem20.Name = "buttonItem20";
            this.buttonItem20.Text = "设置";
            this.buttonItem20.Click += new EventHandler(this.buttonItem20_Click_1);
            this.buttonItem17.Name = "buttonItem17";
            this.buttonItem17.Text = "重置窗口布局";
            this.buttonItem17.Click += new EventHandler(this.buttonItem17_Click_1);
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.SubItems.AddRange(new BaseItem[]
            {
                this.buttonItemhelp1,
                this.buttonItemhelp2,
                this.buttonItemhelp3,
                this.buttonItemhelp4,
                this.buttonItemhelp5,
                this.buttonItemhelp6
            });
            this.buttonItem6.Text = "帮助";
            this.buttonItemhelp1.Name = "buttonItemhelp1";
            this.buttonItemhelp1.Text = "help1";
            this.buttonItemhelp1.Click += new EventHandler(this.buttonItemhelp1_Click);
            this.buttonItemhelp2.Name = "buttonItemhelp2";
            this.buttonItemhelp2.Text = "help2";
            this.buttonItemhelp2.Click += new EventHandler(this.buttonItemhelp2_Click);
            this.buttonItemhelp3.Name = "buttonItemhelp3";
            this.buttonItemhelp3.Text = "help3";
            this.buttonItemhelp3.Click += new EventHandler(this.buttonItemhelp4_Click);
            this.buttonItemhelp4.Name = "buttonItemhelp4";
            this.buttonItemhelp4.Text = "help4";
            this.buttonItemhelp4.Click += new EventHandler(this.buttonItemhelp4_Click_1);
            this.buttonItemhelp5.Name = "buttonItemhelp5";
            this.buttonItemhelp5.Text = "help5";
            this.buttonItemhelp5.Click += new EventHandler(this.buttonItem36_Click);
            this.buttonItemhelp6.Name = "buttonItemhelp6";
            this.buttonItemhelp6.Text = "help6";
            this.buttonItemhelp6.Click += new EventHandler(this.buttonItemhelp6_Click);
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.SubItems.AddRange(new BaseItem[]
            {
                this.buttonItem34,
                this.buttonItem35,
                this.buttonItem47
            });
            this.buttonItem7.Text = "关于";
            this.buttonItem34.Name = "buttonItem34";
            this.buttonItem34.Text = "关于";
            this.buttonItem34.Click += new EventHandler(this.buttonItem34_Click);
            this.buttonItem35.Name = "buttonItem35";
            this.buttonItem35.Text = "检测版本更新";
            this.buttonItem35.Click += new EventHandler(this.buttonItem35_Click);
            this.buttonItem47.Name = "buttonItem47";
            this.buttonItem47.Text = "最新信息";
            this.buttonItem47.Click += new EventHandler(this.buttonItem47_Click);
            this.bChangeStyle.ButtonStyle = eButtonStyle.ImageAndText;
            this.bChangeStyle.GlobalName = "bChangeStyle";
            this.bChangeStyle.Image = (Image)resources.GetObject("bChangeStyle.Image");
            this.bChangeStyle.ImagePosition = eImagePosition.Right;
            this.bChangeStyle.ItemAlignment = eItemAlignment.Far;
            this.bChangeStyle.Name = "bChangeStyle";
            this.bChangeStyle.SubItems.AddRange(new BaseItem[]
            {
                this.buttonItem38,
                this.cmdStyleVS2005
            });
            this.bChangeStyle.Text = "Style";
            this.buttonItem38.Name = "buttonItem38";
            this.buttonItem38.Text = "BLUE";
            this.buttonItem38.Click += new EventHandler(this.buttonItem38_Click);
            this.cmdStyleVS2005.GlobalName = "StyleVS2005";
            this.cmdStyleVS2005.Name = "cmdStyleVS2005";
            this.cmdStyleVS2005.Text = "BLACK";
            this.cmdStyleVS2005.Click += new EventHandler(this.cmdStyleVS2005_Click);
            this.gongju0.AccessibleDescription = "DotNetBar Bar (gongju0)";
            this.gongju0.AccessibleName = "DotNetBar Bar";
            this.gongju0.AccessibleRole = AccessibleRole.ToolBar;
            this.gongju0.DockLine = 1;
            this.gongju0.DockSide = eDockSide.Top;
            this.gongju0.Font = new Font("微软雅黑", 9f);
            this.gongju0.GrabHandleStyle = eGrabHandleStyle.Office2003;
            this.gongju0.IsMaximized = false;
            this.gongju0.Items.AddRange(new BaseItem[]
            {
                this.buttonItem2,
                this.buttonItem3,
                this.tsave,
                this.tbianyi,
                this.buttonItem18,
                this.buttonItem26
            });
            this.gongju0.Location = new Point(0, 27);
            this.gongju0.Name = "gongju0";
            this.gongju0.Size = new Size(335, 27);
            this.gongju0.Style = eDotNetBarStyle.Windows7;
            this.gongju0.TabIndex = 1;
            this.gongju0.TabStop = false;
            this.gongju0.Text = "bar6";
            this.buttonItem2.ButtonStyle = eButtonStyle.ImageAndText;
            //this.buttonItem2.Image = Resources.open;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "打开";
            this.buttonItem2.Click += new EventHandler(this.buttonItem2_Click);
            this.buttonItem3.ButtonStyle = eButtonStyle.ImageAndText;
            //this.buttonItem3.Image = Resources.add;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "新建";
            this.buttonItem3.Click += new EventHandler(this.buttonItem3_Click);
            this.tsave.ButtonStyle = eButtonStyle.ImageAndText;
            this.tsave.Icon = (Icon)resources.GetObject("tsave.Icon");
            this.tsave.Name = "tsave";
            this.tsave.Text = "保存";
            this.tsave.Click += new EventHandler(this.buttonItem25_Click);
            this.tbianyi.ButtonStyle = eButtonStyle.ImageAndText;
            //this.tbianyi.Image = Resources.bianyi;
            this.tbianyi.Name = "tbianyi";
            this.tbianyi.Text = "编译";
            this.tbianyi.Click += new EventHandler(this.buttonItem17_Click);
            this.buttonItem18.ButtonStyle = eButtonStyle.ImageAndText;
            //this.buttonItem18.Image = Resources.tiaoshi;
            this.buttonItem18.Name = "buttonItem18";
            this.buttonItem18.Text = "调试";
            this.buttonItem18.Click += new EventHandler(this.buttonItem18_Click);
            this.buttonItem26.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem26.Icon = (Icon)resources.GetObject("buttonItem26.Icon");
            this.buttonItem26.Name = "buttonItem26";
            this.buttonItem26.Text = "下载";
            this.buttonItem26.Click += new EventHandler(this.buttonItem26_Click);
            this.gongju1.AccessibleDescription = "DotNetBar Bar (gongju1)";
            this.gongju1.AccessibleName = "DotNetBar Bar";
            this.gongju1.AccessibleRole = AccessibleRole.ToolBar;
            this.gongju1.DockLine = 1;
            this.gongju1.DockOffset = 337;
            this.gongju1.DockSide = eDockSide.Top;
            this.gongju1.Font = new Font("微软雅黑", 9f);
            this.gongju1.GrabHandleStyle = eGrabHandleStyle.Office2003;
            this.gongju1.IsMaximized = false;
            this.gongju1.Items.AddRange(new BaseItem[]
            {
                this.tcopy,
                this.buttonItem29,
                this.tzhantie
            });
            this.gongju1.Location = new Point(337, 27);
            this.gongju1.Name = "gongju1";
            this.gongju1.Size = new Size(171, 27);
            this.gongju1.Style = eDotNetBarStyle.Windows7;
            this.gongju1.TabIndex = 2;
            this.gongju1.TabStop = false;
            this.gongju1.Text = "bar10";
            this.tcopy.ButtonStyle = eButtonStyle.ImageAndText;
            this.tcopy.Icon = (Icon)resources.GetObject("tcopy.Icon");
            this.tcopy.Name = "tcopy";
            this.tcopy.Text = "复制";
            this.tcopy.Tooltip = "Ctrl+C";
            this.tcopy.Click += new EventHandler(this.buttonItem20_Click);
            this.buttonItem29.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem29.Icon = (Icon)resources.GetObject("buttonItem29.Icon");
            this.buttonItem29.Name = "buttonItem29";
            this.buttonItem29.Text = "剪切";
            this.buttonItem29.Tooltip = "Ctrl+X";
            this.buttonItem29.Click += new EventHandler(this.buttonItem29_Click);
            this.tzhantie.ButtonStyle = eButtonStyle.ImageAndText;
            this.tzhantie.Icon = (Icon)resources.GetObject("tzhantie.Icon");
            this.tzhantie.Name = "tzhantie";
            this.tzhantie.Text = "粘贴";
            this.tzhantie.Tooltip = "Ctrl+V";
            this.tzhantie.Click += new EventHandler(this.buttonItem21_Click);
            this.gongju2.AccessibleDescription = "DotNetBar Bar (gongju2)";
            this.gongju2.AccessibleName = "DotNetBar Bar";
            this.gongju2.AccessibleRole = AccessibleRole.ToolBar;
            this.gongju2.DockLine = 1;
            this.gongju2.DockOffset = 510;
            this.gongju2.DockSide = eDockSide.Top;
            this.gongju2.Font = new Font("微软雅黑", 9f);
            this.gongju2.GrabHandleStyle = eGrabHandleStyle.Office2003;
            this.gongju2.IsMaximized = false;
            this.gongju2.Items.AddRange(new BaseItem[]
            {
                this.buttonItem39,
                this.buttonItem40,
                this.buttonItem41
            });
            this.gongju2.Location = new Point(510, 27);
            this.gongju2.Name = "gongju2";
            this.gongju2.Size = new Size(171, 27);
            this.gongju2.Style = eDotNetBarStyle.Windows7;
            this.gongju2.TabIndex = 4;
            this.gongju2.TabStop = false;
            this.gongju2.Text = "bar12";
            this.buttonItem39.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem39.Icon = (Icon)resources.GetObject("buttonItem39.Icon");
            this.buttonItem39.Name = "buttonItem39";
            this.buttonItem39.Text = "删除";
            this.buttonItem39.Tooltip = "Del";
            this.buttonItem39.Click += new EventHandler(this.buttonItem39_Click);
            this.buttonItem40.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem40.Icon = (Icon)resources.GetObject("buttonItem40.Icon");
            this.buttonItem40.Name = "buttonItem40";
            this.buttonItem40.Text = "撤销";
            this.buttonItem40.Tooltip = "Ctrl+Z";
            this.buttonItem40.Click += new EventHandler(this.buttonItem40_Click);
            this.buttonItem41.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem41.Icon = (Icon)resources.GetObject("buttonItem41.Icon");
            this.buttonItem41.Name = "buttonItem41";
            this.buttonItem41.Text = "恢复";
            this.buttonItem41.Tooltip = "Ctrl+Y";
            this.buttonItem41.Click += new EventHandler(this.buttonItem41_Click);
            this.gongju3.AccessibleDescription = "DotNetBar Bar (gongju3)";
            this.gongju3.AccessibleName = "DotNetBar Bar";
            this.gongju3.AccessibleRole = AccessibleRole.ToolBar;
            this.gongju3.DockLine = 1;
            this.gongju3.DockOffset = 681;
            this.gongju3.DockSide = eDockSide.Top;
            this.gongju3.Font = new Font("微软雅黑", 9f);
            this.gongju3.GrabHandleStyle = eGrabHandleStyle.Office2003;
            this.gongju3.IsMaximized = false;
            this.gongju3.Items.AddRange(new BaseItem[]
            {
                this.buttonItem31,
                this.buttonItem42
            });
            this.gongju3.Location = new Point(683, 27);
            this.gongju3.Name = "gongju3";
            this.gongju3.Size = new Size(87, 27);
            this.gongju3.Style = eDotNetBarStyle.Windows7;
            this.gongju3.TabIndex = 5;
            this.gongju3.TabStop = false;
            this.gongju3.Text = "bar13";
            this.buttonItem31.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem31.Icon = (Icon)resources.GetObject("buttonItem31.Icon");
            this.buttonItem31.Name = "buttonItem31";
            this.buttonItem31.Text = "设备";
            this.buttonItem31.Click += new EventHandler(this.buttonItem31_Click);
            this.buttonItem42.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem42.Name = "buttonItem42";
            this.buttonItem42.Text = "ID";
            this.buttonItem42.Tooltip = "ID";
            this.buttonItem42.Click += new EventHandler(this.buttonItem42_Click);
            this.gongju4.AccessibleDescription = "DotNetBar Bar (gongju4)";
            this.gongju4.AccessibleName = "DotNetBar Bar";
            this.gongju4.AccessibleRole = AccessibleRole.ToolBar;
            this.gongju4.DockLine = 2;
            this.gongju4.DockSide = eDockSide.Top;
            this.gongju4.Font = new Font("微软雅黑", 9f);
            this.gongju4.GrabHandleStyle = eGrabHandleStyle.Office2003;
            this.gongju4.IsMaximized = false;
            this.gongju4.Items.AddRange(new BaseItem[]
            {
                this.buttonItem43,
                this.buttonItem44,
                this.buttonItem23,
                this.buttonItem24,
                this.buttonItem25,
                this.buttonItem27,
                this.buttonItem28,
                this.buttonItem30,
                this.buttonItem36,
                this.buttonItem21,
                this.buttonItem22,
                this.buttonItem33,
                this.buttonItem37,
                this.buttonItem45,
                this.buttonItem46
            });
            this.gongju4.Location = new Point(0, 55);
            this.gongju4.Name = "gongju4";
            this.gongju4.Size = new Size(369, 25);
            this.gongju4.Style = eDotNetBarStyle.Windows7;
            this.gongju4.TabIndex = 3;
            this.gongju4.TabStop = false;
            this.gongju4.Text = "bar11";
            this.buttonItem43.Icon = (Icon)resources.GetObject("buttonItem43.Icon");
            this.buttonItem43.Name = "buttonItem43";
            this.buttonItem43.Text = "buttonItem43";
            this.buttonItem43.Tooltip = "置顶层";
            this.buttonItem43.Click += new EventHandler(this.buttonItem43_Click);
            this.buttonItem44.Icon = (Icon)resources.GetObject("buttonItem44.Icon");
            this.buttonItem44.Name = "buttonItem44";
            this.buttonItem44.Text = "buttonItem44";
            this.buttonItem44.Tooltip = "置底层";
            this.buttonItem44.Click += new EventHandler(this.buttonItem44_Click);
            this.buttonItem23.Icon = (Icon)resources.GetObject("buttonItem23.Icon");
            this.buttonItem23.Name = "buttonItem23";
            this.buttonItem23.Text = "buttonItem23";
            this.buttonItem23.Tooltip = "左对齐";
            this.buttonItem23.Click += new EventHandler(this.buttonItem23_Click_1);
            this.buttonItem24.Icon = (Icon)resources.GetObject("buttonItem24.Icon");
            this.buttonItem24.Name = "buttonItem24";
            this.buttonItem24.Text = "buttonItem24";
            this.buttonItem24.Tooltip = "右对齐";
            this.buttonItem24.Click += new EventHandler(this.buttonItem24_Click_1);
            this.buttonItem25.Icon = (Icon)resources.GetObject("buttonItem25.Icon");
            this.buttonItem25.Name = "buttonItem25";
            this.buttonItem25.Text = "buttonItem25";
            this.buttonItem25.Tooltip = "上对齐";
            this.buttonItem25.Click += new EventHandler(this.buttonItem25_Click_1);
            this.buttonItem27.Icon = (Icon)resources.GetObject("buttonItem27.Icon");
            this.buttonItem27.Name = "buttonItem27";
            this.buttonItem27.Text = "buttonItem27";
            this.buttonItem27.Tooltip = "下对齐";
            this.buttonItem27.Click += new EventHandler(this.buttonItem27_Click);
            this.buttonItem28.Icon = (Icon)resources.GetObject("buttonItem28.Icon");
            this.buttonItem28.Name = "buttonItem28";
            this.buttonItem28.Text = "buttonItem28";
            this.buttonItem28.Tooltip = "使宽度相同";
            this.buttonItem28.Click += new EventHandler(this.buttonItem28_Click);
            this.buttonItem30.Icon = (Icon)resources.GetObject("buttonItem30.Icon");
            this.buttonItem30.Name = "buttonItem30";
            this.buttonItem30.Text = "buttonItem30";
            this.buttonItem30.Tooltip = "使高度相同";
            this.buttonItem30.Click += new EventHandler(this.buttonItem30_Click);
            this.buttonItem36.Icon = (Icon)resources.GetObject("buttonItem36.Icon");
            this.buttonItem36.Name = "buttonItem36";
            this.buttonItem36.Text = "buttonItem36";
            this.buttonItem36.Tooltip = "使大小相同";
            this.buttonItem36.Click += new EventHandler(this.buttonItem36_Click_1);
            this.buttonItem21.Icon = (Icon)resources.GetObject("buttonItem21.Icon");
            this.buttonItem21.Name = "buttonItem21";
            this.buttonItem21.Text = "buttonItem36";
            this.buttonItem21.Tooltip = "使水平间距相同";
            this.buttonItem21.Click += new EventHandler(this.buttonItem21_Click_1);
            this.buttonItem22.Icon = (Icon)resources.GetObject("buttonItem22.Icon");
            this.buttonItem22.Name = "buttonItem22";
            this.buttonItem22.Text = "buttonItem36";
            this.buttonItem22.Tooltip = "增加水平间距";
            this.buttonItem22.Click += new EventHandler(this.buttonItem22_Click);
            this.buttonItem33.Icon = (Icon)resources.GetObject("buttonItem33.Icon");
            this.buttonItem33.Name = "buttonItem33";
            this.buttonItem33.Text = "buttonItem36";
            this.buttonItem33.Tooltip = "减少水平间距";
            this.buttonItem33.Click += new EventHandler(this.buttonItem33_Click);
            this.buttonItem37.Icon = (Icon)resources.GetObject("buttonItem37.Icon");
            this.buttonItem37.Name = "buttonItem37";
            this.buttonItem37.Text = "buttonItem36";
            this.buttonItem37.Tooltip = "使垂直间距相同";
            this.buttonItem37.Click += new EventHandler(this.buttonItem37_Click);
            this.buttonItem45.Icon = (Icon)resources.GetObject("buttonItem45.Icon");
            this.buttonItem45.Name = "buttonItem45";
            this.buttonItem45.Text = "buttonItem36";
            this.buttonItem45.Tooltip = "增加垂直间距";
            this.buttonItem45.Click += new EventHandler(this.buttonItem45_Click);
            this.buttonItem46.Icon = (Icon)resources.GetObject("buttonItem46.Icon");
            this.buttonItem46.Name = "buttonItem46";
            this.buttonItem46.Text = "buttonItem36";
            this.buttonItem46.Tooltip = "减少垂直间距";
            this.buttonItem46.Click += new EventHandler(this.buttonItem46_Click);
            this.dockSite3.AccessibleRole = AccessibleRole.Window;
            this.dockSite3.Dock = DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DocumentDockContainer();
            this.dockSite3.Location = new Point(220, 80);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new Size(568, 0);
            this.dockSite3.TabIndex = 226;
            this.dockSite3.TabStop = false;
            this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "text.ico");
            this.imageList1.Images.SetKeyName(1, "gt.ico");
            this.imageList1.Images.SetKeyName(2, "num.ico");
            this.imageList1.Images.SetKeyName(3, "button.ico");
            this.imageList1.Images.SetKeyName(4, "pro.ico");
            this.imageList1.Images.SetKeyName(5, "pic.ico");
            this.imageList1.Images.SetKeyName(6, "cut.ico");
            this.imageList1.Images.SetKeyName(7, "touch.ico");
            this.imageList1.Images.SetKeyName(8, "z.ico");
            this.imageList1.Images.SetKeyName(9, "cuv.ico");
            this.imageList1.Images.SetKeyName(10, "h.ico");
            this.imageList1.Images.SetKeyName(11, "timer.ico");
            this.imageList1.Images.SetKeyName(12, "va.ico");
            this.imageList1.Images.SetKeyName(13, "bt.ico");
            this.imageList1.Images.SetKeyName(14, "checkbox.ico");
            this.imageList1.Images.SetKeyName(15, "radio.ico");
            this.buttonItem16.Name = "buttonItem16";
            this.buttonItem16.Text = "保存";
            this.buttonItem19.ButtonStyle = eButtonStyle.ImageAndText;
            this.buttonItem19.Name = "buttonItem19";
            this.buttonItem19.Text = "下载";
            this.dockContainerItem11.Control = this.panelDockContainer9;
            this.dockContainerItem11.Name = "dockContainerItem11";
            this.dockContainerItem11.Text = "dockContainerItem11";
            this.panelDockContainer9.Controls.Add(this.panelEx2);
            this.panelDockContainer9.DisabledBackColor = Color.Empty;
            this.panelDockContainer9.Location = new Point(3, 28);
            this.panelDockContainer9.Name = "panelDockContainer9";
            this.panelDockContainer9.Size = new Size(562, 472);
            this.panelDockContainer9.Style.Alignment = StringAlignment.Center;
            this.panelDockContainer9.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.panelDockContainer9.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            this.panelDockContainer9.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.panelDockContainer9.Style.GradientAngle = 90;
            this.panelDockContainer9.TabIndex = 0;
            this.panelEx2.DisabledBackColor = Color.Empty;
            this.panelEx2.Location = new Point(172, 341);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new Size(178, 93);
            this.panelEx2.TabIndex = 0;
            this.panelEx2.Text = "panelEx2";
            this.styleManager1.ManagerStyle = eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new MetroColorGeneratorParameters(Color.White, Color.FromArgb(255, 163, 26));
            this.tabControl1.ControlBox.CloseBox.Name = "";
            this.tabControl1.ControlBox.MenuBox.Name = "";
            this.tabControl1.ControlBox.Name = "";
            this.tabControl1.ControlBox.SubItems.AddRange(new BaseItem[]
            {
                this.tabControl1.ControlBox.MenuBox,
                this.tabControl1.ControlBox.CloseBox
            });
            this.tabControl1.Controls.Add(this.superTabControlPanel1);
            this.tabControl1.Controls.Add(this.panel1);
            this.tabControl1.Controls.Add(this.panelEx4);
            this.tabControl1.Controls.Add(this.superTabControlPanel2);
            this.tabControl1.Controls.Add(this.superTabControlPanel3);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(220, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.ReorderTabsEnabled = true;
            this.tabControl1.SelectedTabFont = new Font("宋体", 9f, FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new Size(568, 400);
            this.tabControl1.TabFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.tabControl1.TabIndex = 149;
            this.tabControl1.Tabs.AddRange(new BaseItem[]
            {
                this.superTabItem1,
                this.superTabItembbs,
                this.superTabItemcom
            });
            this.tabControl1.Text = "superTabControl1";
            this.tabControl1.SelectedTabChanged += new EventHandler<SuperTabStripSelectedTabChangedEventArgs>(this.tabControl1_SelectedTabChanged);
            this.tabControl1.Resize += new EventHandler(this.tabControl1_Resize);
            this.superTabControlPanel1.Controls.Add(this.panelEx3);
            this.superTabControlPanel1.Controls.Add(this.objpanel);
            this.superTabControlPanel1.Dock = DockStyle.Fill;
            this.superTabControlPanel1.Location = new Point(0, 28);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new Size(568, 372);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            this.panelEx3.AllowDrop = true;
            this.panelEx3.AutoScroll = true;
            this.panelEx3.CanvasColor = SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.pictureBox2);
            this.panelEx3.Controls.Add(this.groupBox1);
            this.panelEx3.Controls.Add(this.expandablePanel1);
            this.panelEx3.Controls.Add(this.runscr1);
            this.panelEx3.Controls.Add(this.expandablePanellishi);
            this.panelEx3.DisabledBackColor = Color.Empty;
            this.panelEx3.Location = new Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.objrefstate = false;
            this.panelEx3.Size = new Size(562, 349);
            this.panelEx3.Style.Alignment = StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 188;
            this.panelEx3.MouseMove += new MouseEventHandler(this.panelEx3_MouseMove);
            this.panelEx3.DragDrop += new DragEventHandler(this.panelEx3_DragDrop);
            this.panelEx3.MouseUp += new MouseEventHandler(this.panelEx3_MouseUp);
            this.panelEx3.DragEnter += new DragEventHandler(this.panelEx3_DragEnter);
            this.pictureBox2.Dock = DockStyle.Top;
            this.pictureBox2.Location = new Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(545, 38);
            this.pictureBox2.TabIndex = 203;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = new Point(0, 0);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textobjbianyi);
            this.groupBox1.Controls.Add(this.panelEx1);
            this.groupBox1.Controls.Add(this.textobj);
            this.groupBox1.Controls.Add(this.textpage);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.listBox4);
            this.groupBox1.Location = new Point(6, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(309, 506);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = new Point(15, 14);
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            this.button1.Location = new Point(235, 13);
            this.button1.Name = "button1";
            this.button1.Size = new Size(90, 42);
            this.button1.TabIndex = 147;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click_1);
            this.textobjbianyi.Location = new Point(6, 250);
            this.textobjbianyi.Multiline = true;
            this.textobjbianyi.Name = "textobjbianyi";
            this.textobjbianyi.ScrollBars = ScrollBars.Vertical;
            this.textobjbianyi.Size = new Size(283, 241);
            this.textobjbianyi.TabIndex = 146;
            this.panelEx1.CanvasColor = SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.DisabledBackColor = Color.Empty;
            this.panelEx1.Location = new Point(46, 93);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new Size(177, 28);
            this.panelEx1.Style.Alignment = StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = Color.FromArgb(252, 235, 154);
            this.panelEx1.Style.BackColor2.Color = Color.FromArgb(245, 208, 80);
            this.panelEx1.Style.Border = eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = Color.FromArgb(228, 156, 5);
            this.panelEx1.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 220;
            this.panelEx1.Tag = new Point(46, 93);
            this.panelEx1.Text = "panelEx1";
            this.panelEx1.Visible = false;
            this.textobj.Location = new Point(6, 187);
            this.textobj.Multiline = true;
            this.textobj.Name = "textobj";
            this.textobj.ScrollBars = ScrollBars.Vertical;
            this.textobj.Size = new Size(283, 59);
            this.textobj.TabIndex = 145;
            this.textpage.BackColor = Color.White;
            this.textpage.Location = new Point(6, 13);
            this.textpage.Multiline = true;
            this.textpage.Name = "textpage";
            this.textpage.ScrollBars = ScrollBars.Vertical;
            this.textpage.Size = new Size(283, 168);
            this.textpage.TabIndex = 144;
            this.listBox1.BackColor = Color.White;
            this.listBox1.ForeColor = Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(489, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(110, 88);
            this.listBox1.TabIndex = 142;
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 12;
            this.listBox4.Location = new Point(489, 146);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new Size(110, 100);
            this.listBox4.TabIndex = 143;
            this.expandablePanel1.ButtonImageCollapse = (Image)resources.GetObject("expandablePanel1.ButtonImageCollapse");
            this.expandablePanel1.ButtonImageExpand = (Image)resources.GetObject("expandablePanel1.ButtonImageExpand");
            this.expandablePanel1.CanvasColor = SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = eDotNetBarStyle.OfficeXP;
            this.expandablePanel1.Controls.Add(this.itemPanel2);
            this.expandablePanel1.DisabledBackColor = Color.Empty;
            this.expandablePanel1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.expandablePanel1.Location = new Point(403, 110);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new Size(77, 69);
            this.expandablePanel1.Style.Alignment = StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 193;
            this.expandablePanel1.Tag = new Point(403, 110);
            this.expandablePanel1.TitleHeight = 28;
            this.expandablePanel1.TitleStyle.Alignment = StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = eBorderType.SingleLine;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.BorderSide = eBorderSide.Bottom;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "关于";
            this.expandablePanel1.Visible = false;
            this.itemPanel2.BackColor = Color.White;
            this.itemPanel2.BackgroundStyle.BackColor = Color.FromArgb(255, 255, 255);
            this.itemPanel2.BackgroundStyle.BackColor2 = Color.FromArgb(255, 255, 255);
            this.itemPanel2.BackgroundStyle.BackColorGradientAngle = 90;
            this.itemPanel2.BackgroundStyle.BorderBottom = eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.itemPanel2.BackgroundStyle.BorderLeft = eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderRight = eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderTop = eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel2.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Controls.Add(this.labelX2);
            this.itemPanel2.Controls.Add(this.linkLabel1);
            this.itemPanel2.Controls.Add(this.labelX1);
            this.itemPanel2.Controls.Add(this.pictureBox1);
            this.itemPanel2.Dock = DockStyle.Fill;
            this.itemPanel2.DragDropSupport = true;
            this.itemPanel2.LayoutOrientation = eOrientation.Vertical;
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new Point(0, 28);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new Size(77, 41);
            this.itemPanel2.Style = eDotNetBarStyle.Metro;
            this.itemPanel2.TabIndex = 4;
            this.itemPanel2.Text = "itemPanel2";
            this.itemPanel2.Resize += new EventHandler(this.itemPanel2_Resize);
            this.labelX2.AutoSize = true;
            this.labelX2.BackgroundStyle.CornerType = eCornerType.Square;
            this.labelX2.Location = new Point(111, 255);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new Size(72, 17);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "USART HMI";
            this.labelX2.Click += new EventHandler(this.labelX2_Click);
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new Point(167, 278);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(50, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Check...";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.labelX1.AutoSize = true;
            this.labelX1.BackgroundStyle.CornerType = eCornerType.Square;
            this.labelX1.Location = new Point(110, 278);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new Size(55, 17);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "Ver:0.35";
            //this.pictureBox1.Image = Resources.guanyu;
            this.pictureBox1.Location = new Point(114, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(303, 203);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.runscr1.BackColor = Color.White;
            this.runscr1.Location = new Point(401, 53);
            this.runscr1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.runscr1.Name = "runscr1";
            this.runscr1.Size = new Size(60, 50);
            this.runscr1.TabIndex = 175;
            this.runscr1.Tag = new Point(401, 53);
            this.runscr1.Visible = false;
            this.runscr1.Load += new EventHandler(this.runscr1_Load);
            this.runscr1.Moveobj += new EventHandler(this.runscr1_Moveobj);
            this.runscr1.Dragobj += new EventHandler(this.runscr1_Dragobj);
            this.runscr1.Objselect += new EventHandler(this.runscr1_Objselect);
            this.runscr1.Objpanelresize += new EventHandler(this.runscr1_Objpanelresize);
            this.runscr1.SendCom += new EventHandler(this.runscr1_SendCom);
            this.runscr1.ObjKeyDown += new EventHandler(this.runscr1_ObjKeyDown);
            this.runscr1.MouseMove += new MouseEventHandler(this.runscr1_MouseMove);
            this.runscr1.Resize += new EventHandler(this.runscr1_Resize);
            this.runscr1.ObjXYchang += new EventHandler(this.runscr1_ObjXYchang);
            this.expandablePanellishi.ButtonImageCollapse = (Image)resources.GetObject("expandablePanellishi.ButtonImageCollapse");
            this.expandablePanellishi.ButtonImageExpand = (Image)resources.GetObject("expandablePanellishi.ButtonImageExpand");
            this.expandablePanellishi.CanvasColor = SystemColors.Control;
            this.expandablePanellishi.ColorSchemeStyle = eDotNetBarStyle.OfficeXP;
            this.expandablePanellishi.Controls.Add(this.itemPanelhis);
            this.expandablePanellishi.DisabledBackColor = Color.Empty;
            this.expandablePanellishi.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.expandablePanellishi.Location = new Point(403, 189);
            this.expandablePanellishi.Name = "expandablePanellishi";
            this.expandablePanellishi.Size = new Size(95, 50);
            this.expandablePanellishi.Style.Alignment = StringAlignment.Center;
            this.expandablePanellishi.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            this.expandablePanellishi.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            this.expandablePanellishi.Style.GradientAngle = 90;
            this.expandablePanellishi.TabIndex = 183;
            this.expandablePanellishi.Tag = new Point(403, 189);
            this.expandablePanellishi.TitleHeight = 28;
            this.expandablePanellishi.TitleStyle.Alignment = StringAlignment.Center;
            this.expandablePanellishi.TitleStyle.BackColor1.ColorSchemePart = eColorSchemePart.PanelBackground;
            this.expandablePanellishi.TitleStyle.BackColor2.ColorSchemePart = eColorSchemePart.PanelBackground2;
            this.expandablePanellishi.TitleStyle.Border = eBorderType.SingleLine;
            this.expandablePanellishi.TitleStyle.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.expandablePanellishi.TitleStyle.BorderSide = eBorderSide.Bottom;
            this.expandablePanellishi.TitleStyle.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.expandablePanellishi.TitleStyle.GradientAngle = 90;
            this.expandablePanellishi.TitleText = "最近打开项目";
            this.expandablePanellishi.Visible = false;
            this.itemPanelhis.BackColor = Color.White;
            this.itemPanelhis.BackgroundStyle.BackColor = Color.FromArgb(255, 255, 255);
            this.itemPanelhis.BackgroundStyle.BackColor2 = Color.FromArgb(255, 255, 255);
            this.itemPanelhis.BackgroundStyle.BackColorGradientAngle = 90;
            this.itemPanelhis.BackgroundStyle.BorderBottom = eStyleBorderType.Solid;
            this.itemPanelhis.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanelhis.BackgroundStyle.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.itemPanelhis.BackgroundStyle.BorderLeft = eStyleBorderType.Solid;
            this.itemPanelhis.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanelhis.BackgroundStyle.BorderRight = eStyleBorderType.Solid;
            this.itemPanelhis.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanelhis.BackgroundStyle.BorderTop = eStyleBorderType.Solid;
            this.itemPanelhis.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanelhis.BackgroundStyle.CornerType = eCornerType.Square;
            this.itemPanelhis.ContainerControlProcessDialogKey = true;
            this.itemPanelhis.Dock = DockStyle.Fill;
            this.itemPanelhis.DragDropSupport = true;
            this.itemPanelhis.LayoutOrientation = eOrientation.Vertical;
            this.itemPanelhis.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanelhis.Location = new Point(0, 28);
            this.itemPanelhis.Name = "itemPanelhis";
            this.itemPanelhis.Size = new Size(95, 22);
            this.itemPanelhis.Style = eDotNetBarStyle.Metro;
            this.itemPanelhis.TabIndex = 4;
            this.itemPanelhis.Text = "itemPanel2";
            this.objpanel.AutoScroll = true;
            this.objpanel.CanvasColor = SystemColors.Control;
            this.objpanel.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.objpanel.DisabledBackColor = Color.Empty;
            this.objpanel.Location = new Point(3, 335);
            this.objpanel.Name = "objpanel";
            this.objpanel.objrefstate = false;
            this.objpanel.Size = new Size(191, 31);
            this.objpanel.Style.Alignment = StringAlignment.Center;
            this.objpanel.Style.BackColor1.ColorSchemePart = eColorSchemePart.PanelBackground;
            this.objpanel.Style.BackColor2.ColorSchemePart = eColorSchemePart.PanelBackground2;
            this.objpanel.Style.Border = eBorderType.SingleLine;
            this.objpanel.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.objpanel.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.objpanel.Style.GradientAngle = 90;
            this.objpanel.TabIndex = 192;
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "界面";
            this.panel1.Location = new Point(451, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(200, 100);
            this.panel1.TabIndex = 5;
            this.panelEx4.CanvasColor = SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.DisabledBackColor = Color.Empty;
            this.panelEx4.Location = new Point(196, 1);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new Size(200, 100);
            this.panelEx4.Style.Alignment = StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 1;
            this.panelEx4.Text = "panelEx4";
            this.superTabControlPanel2.Controls.Add(this.webBrowser1);
            this.superTabControlPanel2.Controls.Add(this.web1label);
            this.superTabControlPanel2.Dock = DockStyle.Fill;
            this.superTabControlPanel2.Location = new Point(0, 28);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new Size(568, 372);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItembbs;
            this.webBrowser1.Dock = DockStyle.Fill;
            this.webBrowser1.Location = new Point(0, 0);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new Size(568, 372);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Navigating += new WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.superTabItembbs.AttachedControl = this.superTabControlPanel2;
            this.superTabItembbs.GlobalItem = false;
            this.superTabItembbs.Name = "superTabItembbs";
            this.superTabItembbs.Text = "社区";
            this.superTabControlPanel3.Controls.Add(this.webBrowser2);
            this.superTabControlPanel3.Controls.Add(this.web2label);
            this.superTabControlPanel3.Dock = DockStyle.Fill;
            this.superTabControlPanel3.Location = new Point(0, 28);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new Size(568, 372);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItemcom;
            this.superTabItemcom.AttachedControl = this.superTabControlPanel3;
            this.superTabItemcom.GlobalItem = false;
            this.superTabItemcom.Name = "superTabItemcom";
            this.superTabItemcom.Text = "指令集";
            this.timer1.Tick += new EventHandler(this.timer1_Tick_1);
            this.timermessage.Tick += new EventHandler(this.timermessage_Tick);
            this.timerclose.Tick += new EventHandler(this.timerclose_Tick);
            this.AllowDrop = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(194, 217, 247);
            base.ClientSize = new Size(1008, 730);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.dockSite3);
            base.Controls.Add(this.dockSite4);
            base.Controls.Add(this.dockSite1);
            base.Controls.Add(this.dockSite2);
            base.Controls.Add(this.bar1);
            base.Controls.Add(this.dockSite5);
            base.Controls.Add(this.dockSite6);
            base.Controls.Add(this.dockSite7);
            base.Controls.Add(this.dockSite8);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            base.Name = "main";
            this.Text = "100duo ";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.Form1_Load);
            base.Move += new EventHandler(this.main_Move);
            base.FormClosing += new FormClosingEventHandler(this.main_FormClosing);
            ((ISupportInitialize)this.bar1).EndInit();
            this.dockSite4.ResumeLayout(false);
            ((ISupportInitialize)this.bar3).EndInit();
            this.bar3.ResumeLayout(false);
            this.panelDockContainer7.ResumeLayout(false);
            ((ISupportInitialize)this.bar9).EndInit();
            this.bar9.ResumeLayout(false);
            this.panelDockContainer8.ResumeLayout(false);
            this.dockSite1.ResumeLayout(false);
            ((ISupportInitialize)this.bar2).EndInit();
            this.bar2.ResumeLayout(false);
            this.panelDockContainer5.ResumeLayout(false);
            this.panelDockContainer4.ResumeLayout(false);
            ((ISupportInitialize)this.bargongju).EndInit();
            this.bargongju.ResumeLayout(false);
            this.panelDockContainer1.ResumeLayout(false);
            this.dockSite2.ResumeLayout(false);
            ((ISupportInitialize)this.bar4).EndInit();
            this.bar4.ResumeLayout(false);
            this.panelDockContainer6.ResumeLayout(false);
            ((ISupportInitialize)this.bar8).EndInit();
            this.bar8.ResumeLayout(false);
            this.panelDockContainer2.ResumeLayout(false);
            this.dockSite7.ResumeLayout(false);
            ((ISupportInitialize)this.bar5).EndInit();
            ((ISupportInitialize)this.gongju0).EndInit();
            ((ISupportInitialize)this.gongju1).EndInit();
            ((ISupportInitialize)this.gongju2).EndInit();
            ((ISupportInitialize)this.gongju3).EndInit();
            ((ISupportInitialize)this.gongju4).EndInit();
            this.panelDockContainer9.ResumeLayout(false);
            ((ISupportInitialize)this.tabControl1).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            ((ISupportInitialize)this.pictureBox2).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            this.itemPanel2.ResumeLayout(false);
            this.itemPanel2.PerformLayout();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            this.expandablePanellishi.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            this.superTabControlPanel3.ResumeLayout(false);
            this.superTabControlPanel3.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion
    }
}