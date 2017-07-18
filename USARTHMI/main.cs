using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using hmitype;
using rsapp;
using run;

namespace USARTHMI
{
    public partial class main : DevComponents.DotNetBar.OfficeForm
    {

        #region ¿Ø¼þ
        private delegate void SetTextCallback(string text);

        private bool isclose = false;

        private Pen pen1 = new Pen(Color.Red, 1f);

        public Myapp_inf Myapp = null;

        private mpage dpage = null;

        private string binpath = "";

        private string comdata2;

        private bool xyshow = true;

        private string Openfilepath;

        private List<objedit> tobjs = new List<objedit>();

        private eStyle[] appestyles;

        private List<string> guinames = new List<string>();

        private List<historypath_type> myhs = new List<historypath_type>();

        private int websernag = 0;

        private int dmessage = 0;

        private string dmessageurl = "";

        private Color encodinglinkcolor = Color.Red;

      

        private picadmin picadmin1;

        private zikuadmin zikuadmin1;

        private pageadmin pageadmin1;

        private objattoo objatt1;

        private objatt objatt2;

        private WebBrowser webBrowser2;

        private Label web1label;

        private Label web2label;

        private GroupBox groupBox1;

        private ListBox listBox1;

        private ListBox listBox4;

        private TextBox textobj;

        private TextBox textpage;

        private TextBox textobjbianyi;

        private Button button1;

        private DockContainerItem dockContainerItem2;

        private DockContainerItem dockContainerItem3;

        private Bar bar1;

        private DotNetBarManager dotNetBarManager1;

        private DockSite dockSite4;

        private Bar bar3;

        private DockSite dockSite1;

        private Bar bar2;

        private PanelDockContainer panelDockContainer1;

        private DockContainerItem dockContainerItem4;

        private DockSite dockSite2;

        private Bar bar4;

        private PanelDockContainer panelDockContainer2;

        private DockContainerItem dockContainerItem5;

        private DockSite dockSite8;

        private DockSite dockSite5;

        private DockSite dockSite6;

        private DockSite dockSite7;

        private Bar bar5;

        private ButtonItem buttonItem1;

        private ButtonItem buttonItem4;

        private Bar gongju0;

        private ButtonItem buttonItem2;

        private ButtonItem buttonItem3;

        private DockSite dockSite3;

        private PanelDockContainer panelDockContainer4;

        private DockContainerItem dockContainerItem6;

        private PanelDockContainer panelDockContainer7;

        private DockContainerItem dockContainerItem9;

        private Bar bar9;

        private PanelDockContainer panelDockContainer8;

        private DockContainerItem dockContainerItem10;

        private PanelDockContainer panelDockContainer5;

        private DockContainerItem dockContainerItem7;

        private Bar bargongju;

        private PanelDockContainer panelDockContainer6;

        private DockContainerItem dockContainerItem8;

        private Bar bar8;

        private ButtonItem buttonItem5;

        private ButtonItem buttonItem6;

        private ButtonItem buttonItem7;

        private ButtonItem buttonItem8;

        private ButtonItem buttonItem9;

        private ButtonItem buttonItem10;

        private ButtonItem buttonItem11;

        private ButtonItem buttonItem12;

        private ButtonItem buttonItem13;

        private ButtonItem buttonItem14;

        private ButtonItem buttonItem15;

        private ButtonItem tbianyi;

        private ButtonItem buttonItem18;

        private Bar gongju1;

        private ButtonItem tcopy;

        private ButtonItem tzhantie;

        private ButtonItem buttonItem16;

        private ButtonItem tsave;

        private ButtonItem buttonItem26;

        private ButtonItem buttonItem19;

        private runscr runscr1;

        private DockContainerItem dockContainerItem11;

        private PanelDockContainer panelDockContainer9;

        private PanelEx panelEx2;

        private ButtonItem buttonItem32;

        private ButtonItem buttonItemhelp1;

        private ButtonItem buttonItemhelp2;

        private ButtonItem buttonItemhelp5;

        private ButtonItem buttonItem34;

        private ButtonItem buttonItem35;

        private RichTextBox textbianyi;

        private LabelItem labelItem1;

        private ImageList imageList1;

        private Bar gongju4;

        private ButtonItem buttonItem23;

        private ButtonItem buttonItem24;

        private ButtonItem buttonItem25;

        private ButtonItem buttonItem27;

        private ButtonItem buttonItem28;

        private ButtonItem buttonItem30;

        private ButtonItem buttonItem36;

        private ButtonItem bChangeStyle;

        private ButtonItem cmdStyleVS2005;

        private ButtonItem buttonItem38;

        private Bar gongju2;

        private ButtonItem buttonItem39;

        private ButtonItem buttonItem40;

        private ButtonItem buttonItem41;

        private ButtonItem buttonItem29;

        private Bar gongju3;

        private ButtonItem buttonItem31;

        private ButtonItem buttonItem42;

        private ButtonItem buttonItem43;

        private ButtonItem buttonItem44;

        private StyleManager styleManager1;

        private SuperTabControl tabControl1;

        private SuperTabControlPanel superTabControlPanel3;

        private SuperTabItem superTabItemcom;

        private SuperTabControlPanel superTabControlPanel2;

        private SuperTabItem superTabItembbs;

        private Colpanel panelEx3;

        private SuperTabControlPanel superTabControlPanel1;

        private SuperTabItem superTabItem1;

        private ButtonItem buttonItemhelp3;

        private ButtonItem buttonItemhelp4;

        private LabelItem labelItem2;

        private ButtonItem buttonItemhelp6;

        private Colpanel objpanel;

        private ExpandablePanel expandablePanellishi;

        private ItemPanel itemPanelhis;

        private ExpandablePanel expandablePanel1;

        private ItemPanel itemPanel2;

        private PictureBox pictureBox1;

        private LabelX labelX1;

        private LinkLabel linkLabel1;

        private LabelX labelX2;

        private PictureBox pictureBox2;

        private ButtonItem ClearHis;

        private WebBrowser webBrowser1;

        private System.Windows.Forms.Timer timer1;

        private LabelItem labelItem3;

        private ButtonItem buttonItem47;

        private System.Windows.Forms.Timer timermessage;

        private System.Windows.Forms.Timer timerclose;

        private ColListBox colListBox1;

        private PanelEx panelEx1;

        private ButtonItem shezhi;

        private ButtonItem buttonItem20;

        private ButtonItem buttonItem17;

        private ButtonItem buttonItem21;

        private ButtonItem buttonItem22;

        private ButtonItem buttonItem33;

        private ButtonItem buttonItem37;

        private ButtonItem buttonItem45;

        private ButtonItem buttonItem46;

        private LabelItem labelItem4;

        private LabelItem labelItem5;

        private Panel panel1;

        private PanelEx panelEx4;


        #endregion
        public main()
        {
            InitializeComponent();
        }
    }
}