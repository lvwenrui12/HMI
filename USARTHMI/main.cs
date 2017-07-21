using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ColList;
using DevComponents.DotNetBar;
using hmitype;
using rsapp;
using run;
using USARTHMI.Properties;

namespace USARTHMI
{
    public partial class main : DevComponents.DotNetBar.OfficeForm
    {

        #region 控件
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

        private ButtonItem btnOpen;

        private ButtonItem btnNew;

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

        private Colpanel.Colpanel panelEx3;

        private SuperTabControlPanel superTabControlPanel1;

        private SuperTabItem superTabItem1;

        private ButtonItem buttonItemhelp3;

        private ButtonItem buttonItemhelp4;

        private LabelItem labelItem2;

        private ButtonItem buttonItemhelp6;

        private Colpanel.Colpanel objpanel;

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

        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);
        #endregion

        #region 构造函数
        public main()
        {
            this.appestyles = new eStyle[]
              {
                eStyle.Office2007Blue,
                eStyle.VisualStudio2010Blue
              };
            this.InitializeComponent();
            this.objpanel.Visible = false;
            objtype.Init();
            this.Language();
            this.Text = datasize.softname;
            base.Icon = datasize.Myico;
            this.buttonItem34.Text = "关于".Language() + " " + datasize.softname;
            this.labelX1.Text = "版本：".Language() + datasize.banbenh.ToString() + "." + datasize.banbenl.ToString();
            this.expandablePanellishi.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            this.expandablePanel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            if (datasize.Language == 0)
            {

                this.buttonItem26.Icon = Resources.chload;
                this.buttonItemhelp1.Visible = true;
                this.buttonItemhelp2.Visible = true;
                this.buttonItemhelp3.Visible = true;
                this.buttonItemhelp4.Visible = true;
                this.buttonItemhelp5.Visible = true;
                this.superTabItembbs.Visible = true;
                this.buttonItemhelp1.Text = "串口HMI入门指南(PDF)".Language();
                this.buttonItemhelp2.Text = "串口HMI指令集(PDF)".Language();
                this.buttonItemhelp3.Text = "串口HMI产品选型指南(PDF)".Language();
                this.buttonItemhelp4.Text = "串口HMI产品命名规则(PDF)".Language();
                this.buttonItemhelp5.Text = "在线规格书".Language();
                this.buttonItemhelp6.Text = "在线视频教程".Language();
                this.labelX2.Text = "USART HMI 让开发变得更简单".Language();
                this.pictureBox2.Height = Resources.tjctopmainlogo.Height;
                this.pictureBox2.BackgroundImage = Resources.tjctopmainlogo;
            }
            else
            {
                this.buttonItem26.Icon = Resources.enload;
                this.buttonItemhelp1.Visible = false;
                this.buttonItemhelp2.Visible = false;
                this.buttonItemhelp3.Visible = false;
                this.buttonItemhelp4.Visible = false;
                this.buttonItemhelp5.Visible = false;
                this.buttonItemhelp6.Text = "Help";
                this.superTabItembbs.Visible = false;
                this.labelX2.Text = datasize.softname;
                this.pictureBox2.Height = Resources.iteadtopmainlogo.Height;
                this.pictureBox2.BackgroundImage = Resources.iteadtopmainlogo;
            }

        }
        #endregion

        #region 窗体加载
        private void Form1_Load(object sender, EventArgs e)
        {
            this.objpanel.panel_init();
            this.panelEx3.panel_init();
            this.Getlayout(0);
            this.isclose = false;
            this.timerclose.Enabled = false;
            this.labelItem3.Visible = false;
            try
            {
                this.loadappestyle();
                this.colListBox1.Enabled = false;
                this.colListBox1.Itemheight = 24;
                this.colListBox1.itembackcolor_select = Color.YellowGreen;
                this.colListBox1.idwidth = 0;

                #region colListBox1

                if (imageList1.Images.Count > 0)
                {
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "文本".Language(),
                        img = this.imageList1.Images[0],
                        obj = objtype.text
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "滚动文本".Language(),
                        img = this.imageList1.Images[1],
                        obj = objtype.gtext
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "数字".Language(),
                        img = this.imageList1.Images[2],
                        obj = objtype.number
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "按钮".Language(),
                        img = this.imageList1.Images[3],
                        obj = objtype.button
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "进度条".Language(),
                        img = this.imageList1.Images[4],
                        obj = objtype.prog
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "图片".Language(),
                        img = this.imageList1.Images[5],
                        obj = objtype.pic
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "切图".Language(),
                        img = this.imageList1.Images[6],
                        obj = objtype.picc
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "触摸热区".Language(),
                        img = this.imageList1.Images[7],
                        obj = objtype.touch
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "指针".Language(),
                        img = this.imageList1.Images[8],
                        obj = objtype.zhizhen
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "曲线/波形".Language(),
                        img = this.imageList1.Images[9],
                        obj = objtype.OBJECT_TYPE_CURVE
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "滑块".Language(),
                        img = this.imageList1.Images[10],
                        obj = objtype.OBJECT_TYPE_SLIDER
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "定时器".Language(),
                        img = this.imageList1.Images[11],
                        obj = objtype.Timer
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "变量".Language(),
                        img = this.imageList1.Images[12],
                        obj = objtype.variable
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "双态按钮".Language(),
                        img = this.imageList1.Images[13],
                        obj = objtype.button_t
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "复选框".Language(),
                        img = this.imageList1.Images[14],
                        obj = objtype.checkbox
                    });
                    this.colListBox1.Items_Add(new ColListBoxItem
                    {
                        Text = "单选框".Language(),
                        img = this.imageList1.Images[15],
                        obj = objtype.radiobutton
                    });

                }


                #endregion
                this.runscr1.objpanel = this.objpanel;
                this.webBrowser1.ScriptErrorsSuppressed = true;
                this.webBrowser2.ScriptErrorsSuppressed = true;
                this.webBrowser1.AllowWebBrowserDrop = false;
                this.webBrowser2.AllowWebBrowserDrop = false;
                this.appchangevent(false);
                this.closehmi();
                this.dpage = null;
                this.objatt1.Refobj(null, null, null);
                this.objatt2.Ref();
                this.picadmin1.SetSize();
                this.zikuadmin1.SetSize();
                this.pageadmin1.SetSize();
                this.objatt2.SetSize();
                string[] commandLineArgs = Environment.GetCommandLineArgs();
                string[] array = commandLineArgs;
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i];
                    if (File.Exists(text))
                    {
                        if (Path.GetExtension(text).Contains("HMI") || Path.GetExtension(text).Contains("hmi"))
                        {
                            this.filecaozuo("open", text);
                            break;
                        }
                    }
                }
                if (datasize.tanchuangid > 0)
                {
                    if (datasize.tanchuangurl != null && datasize.tanchuangurl != "")
                    {
                        if (Kuozhan.getxmlstring("st0") != datasize.tanchuangid.ToString())
                        {
                            new tanchuang(datasize.tanchuangurl).ShowDialog();
                        }
                    }
                }
                this.RefLinklabel1Ref();
                if (datasize.dowloadurl == "err")
                {
                    this.buttonItem35.Enabled = false;
                    this.linkLabel1.Text = "(Check...)";
                    Win32.gethmiver(0, 10000, 0, 10000, false, false, false, 1);
                    while (!datasize.findendstate)
                    {
                        Application.DoEvents();
                    }
                    if (datasize.dowloadurl != "")
                    {
                        if (datasize.dowloadurl == "err")
                        {
                            this.labelItem3.Text = "服务器连接失败,无法检测最新版本,请检查你的网络连接,以确保你使用的是最新的HMI编辑软件".Language();
                            this.labelItem3.Visible = true;
                            this.bar1.Refresh();
                        }
                        else
                        {
                            this.labelItem3.Visible = false;
                            new download(datasize.dowloadurl).ShowDialog();
                        }
                    }
                    else
                    {
                        MessageOpen.Show("当前版本已是最新版本!".Language());
                    }
                    this.buttonItem35.Enabled = true;
                    this.RefLinklabel1Ref();
                }
                this.downloginjpg();
                this.timermessage.Interval = 100;
                this.timermessage.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }
        #endregion

        private void downloginjpg()
        {
            if (datasize.loginjpgurl != null && datasize.loginjpgurl != "")
            {
                if (datasize.loginjpgnum > 0)
                {
                    new urldown
                    {
                        url = string.Concat(new object[]
                        {
                            datasize.loginjpgurl,
                            "/",
                            Sys.rand(0, datasize.loginjpgnum - 1),
                            ".jpg"
                        }),
                        filepath = datasize.linpath + "\\login.jpg"
                    }.DownStar();
                }
            }
        }

        private void RefLinklabel1Ref()
        {
            if (datasize.interbanbenh == datasize.banbenh && datasize.interbanbenl == datasize.banbenl)
            {
                this.linkLabel1.Text = "(已是最新版本)".Language();
            }
            else
            {
                this.linkLabel1.Text = "(立即更新)".Language();
            }
        }

        private void Gehistorypath(ref List<historypath_type> hs)
        {
            try
            {
                hs.Clear();
                StreamReader streamReader;
                bool flag;
                if (File.Exists(datasize.newhistorypath))
                {
                    streamReader = new StreamReader(datasize.newhistorypath);
                    flag = true;
                }
                else
                {
                    if (!File.Exists(datasize.oldhistorypath))
                    {
                        return;
                    }
                    streamReader = new StreamReader(datasize.oldhistorypath);
                    flag = false;
                }
                if (streamReader.BaseStream.Length < 1000000L)
                {
                    byte[] array = new byte[streamReader.BaseStream.Length];
                    streamReader.BaseStream.Read(array, 0, array.Length);
                    streamReader.Close();
                    streamReader.Dispose();
                    string[] array2;
                    if (flag)
                    {
                        array2 = Encoding.GetEncoding("UTF-8").GetString(array).Replace("\r\n", "/").Split(new char[]
                        {
                            '/'
                        });
                    }
                    else
                    {
                        array2 = array.Getstring(datasize.Myencoding).Replace("\r\n", "/").Split(new char[]
                        {
                            '/'
                        });
                    }
                    for (int i = 0; i < array2.Length; i++)
                    {
                        if (array2[i].Length > 3)
                        {
                            historypath_type item = default(historypath_type);
                            item.path = array2[i];
                            item.name = Path.GetFileName(item.path);
                            hs.Add(item);
                        }
                    }
                }
                if (!flag)
                {
                    this.Savehistorypath("");
                    Kuozhan.delfile(datasize.oldhistorypath);
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void Savehistorypath(string path)
        {
            try
            {
                if (path != "")
                {
                    for (int i = 0; i < this.myhs.Count; i++)
                    {
                        if (this.myhs[i].path == path)
                        {
                            if (i == 0)
                            {
                                return;
                            }
                            this.myhs.Remove(this.myhs[i]);
                            i--;
                        }
                    }
                    historypath_type item = default(historypath_type);
                    item.path = path;
                    item.name = Path.GetFileNameWithoutExtension(item.path);
                    this.myhs.Insert(0, item);
                }
                if (Kuozhan.delfile(datasize.newhistorypath))
                {
                    StreamWriter streamWriter = new StreamWriter(datasize.newhistorypath);
                    for (int i = 0; i < this.myhs.Count; i++)
                    {
                        byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(this.myhs[i].path);
                        streamWriter.BaseStream.Write(bytes, 0, bytes.Length);
                        streamWriter.BaseStream.Write(Encoding.GetEncoding("UTF-8").GetBytes("\r\n"), 0, 2);
                        if (i >= 9)
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void Setpanel(bool vis)
        {
            try
            {
                if (vis)
                {
                    this.expandablePanellishi.Top = this.pictureBox2.Top + this.pictureBox2.Height + 8;
                    this.expandablePanellishi.Left = 8;
                    this.expandablePanellishi.Width = 250;
                    this.expandablePanellishi.Height = this.panelEx3.Height - this.expandablePanellishi.Top - 8;
                    this.expandablePanel1.Top = this.expandablePanellishi.Top;
                    this.expandablePanel1.Left = this.expandablePanellishi.Left + this.expandablePanellishi.Width + 8;
                    this.expandablePanel1.Width = this.panelEx3.Width - this.expandablePanel1.Left - 8;
                    this.expandablePanel1.Height = this.expandablePanellishi.Height;
                    this.Gehistorypath(ref this.myhs);
                    this.itemPanelhis.Items.Clear();
                    for (int i = 0; i < this.myhs.Count; i++)
                    {
                        if (this.myhs[i].path.Length > 3)
                        {
                            ButtonItem buttonItem = new ButtonItem();
                            buttonItem.Name = "buttonItemhis" + this.myhs[i].name;
                            buttonItem.Text = this.myhs[i].name;
                            buttonItem.Tooltip = this.myhs[i].path;
                            buttonItem.Click += new EventHandler(this.buttonItemhs_Click);
                            if (!File.Exists(this.myhs[i].path))
                            {
                                ButtonItem expr_1BF = buttonItem;
                                expr_1BF.Text += "(lost file)";
                                buttonItem.ForeColor = Color.FromArgb(150, 150, 150);
                            }
                            else
                            {
                                buttonItem.ForeColor = Color.FromArgb(30, 30, 110);
                            }
                            this.itemPanelhis.Items.Add(buttonItem);
                        }
                    }
                    this.itemPanelhis.Refresh();
                }
                this.expandablePanellishi.Visible = vis;
                this.pictureBox2.Visible = vis;
                this.expandablePanel1.Visible = vis;
                this.itemPanel2_Resize(null, null);
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private bool filecaozuo(string str, string s)
        {
            this.setui(false);
            bool result = this.hmiopen(str, s);
            this.setui(true);
            return result;
        }
        private void setui(bool val)
        {
            this.dockSite7.Enabled = val;
            this.bargongju.Enabled = val;
            this.picadmin1.Enabled = val;
            this.pageadmin1.Enabled = val;
            this.objatt2.Enabled = val;
            this.objatt1.CodeEnabled(val);
            this.itemPanel2.Enabled = val;
            this.itemPanelhis.Enabled = val;
        }

        private bool IsSave()
        {
            bool result = false;

            if (this.Myapp != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "HMI文件|*.HMI|所有文件|*.*".Language();
                saveFileDialog.Getpath("file");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.Openfilepath = saveFileDialog.FileName;
                    saveFileDialog.Putpath("file");
                    this.runscr1.Pausesr();
                    this.objatt1.SaveCodes();
                    if (this.Myapp.Savefile(datasize.runfilepath, 0, this.textbianyi))
                    {
                        if (!Kuozhan.delfile(this.Openfilepath))
                        {
                            this.runscr1.Upsr();
                            return result;
                        }
                        File.Copy(datasize.runfilepath, this.Openfilepath);
                    }
                    this.runscr1.Upsr();
                    this.RefPage();
                    this.Myapp.changappevent(false);
                    this.Text = datasize.softname + "(" + this.Openfilepath + ")";
                    this.Savehistorypath(this.Openfilepath);
                    result = true;
                }

            }
            return result;

        }

        private bool BianYi()
        {
            bool result = false;

            if (this.Myapp == null || this.Openfilepath == null)
            {

                return result;
            }
            if (this.Myapp.changapp)
            {
                if (!this.filecaozuo("save", ""))
                {

                    return result;
                }
            }
            if (!Directory.Exists(datasize.Bianyipath))
            {
                Directory.CreateDirectory(datasize.Bianyipath);
            }
            this.binpath = datasize.Bianyipath + "\\" + Path.GetFileNameWithoutExtension(this.Openfilepath) + ".tft";
            if (!this.Myapp.Savefile(this.binpath, 1, this.textbianyi))
            {
                this.binpath = "";

                return result;
            }
            this.Myapp.changappevent(false);
            result = true;
            return result;
        }


        private bool hmiopen(string str, string s)
        {
            string str5 = str;
            if (str5 != null)
            {
                SaveFileDialog dialog;
                if (str5 == "add")
                {
                    if ((this.Myapp != null) && this.Myapp.changapp)
                    {
                        switch (MessageOpen.Show("当前工程内容有修改，需要保存吗?".Language(), "确认".Language(), MessageBoxButtons.YesNoCancel))
                        {
                            case DialogResult.Yes:
                                if (!this.filecaozuo("save", ""))
                                {
                                    return false;
                                }
                                break;

                            case DialogResult.Cancel:
                                return false;
                        }
                    }
                    dialog = new SaveFileDialog
                    {
                        Filter = "HMI文件|*.HMI|所有文件|*.*".Language()
                    };
                    dialog.Getpath("file");
                    if (dialog.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                    this.closehmi();
                    this.Myapp = new Myapp_inf();
                    this.Myapp.changappevent = new Myapp_inf.appchangevent(this.appchangevent);
                    this.Myapp.savetempfile = new Myapp_inf.savetempfile_(this.savetempfile);
                    this.Myapp.refzikuevent = new Myapp_inf.refzikuevent_(this.zikuadmin1.Ref);
                    this.Myapp.refpicevent = new Myapp_inf.refpicevent_(this.picadmin1.Ref);
                    this.Myapp.changappevent(false);
                    mpage item = this.Myapp.Creatnewpage(true);
                    this.Myapp.pages.Add(item);
                    this.Myapp.RefpageID();
                    if (new appset(this.Myapp, 0).ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                    this.runscr1.RunStop();
                    this.Openfilepath = dialog.FileName;
                    dialog.Putpath("file");
                    this.Myapp.Savefile(this.Openfilepath, 0, this.textbianyi);
                    this.closehmi();
                    this.filecaozuo("open", this.Openfilepath);
                }
                else if (str5 == "open")
                {
                    if ((this.Myapp != null) && this.Myapp.changapp)
                    {
                        switch (MessageOpen.Show("当前工程内容有修改，需要保存吗?".Language(), "确认".Language(), MessageBoxButtons.YesNoCancel))
                        {
                            case DialogResult.Yes:
                                if (!this.filecaozuo("save", ""))
                                {
                                    return false;
                                }
                                break;

                            case DialogResult.Cancel:
                                return false;
                        }
                    }
                    OpenFileDialog op = new OpenFileDialog();
                    if (s == "")
                    {
                        op.Filter = "HMI文件|*.HMI|所有文件|*.*".Language();
                        op.Getpath("file");
                        if (op.ShowDialog() != DialogResult.OK)
                        {
                            return false;
                        }
                        op.Putpath("file");
                        this.Openfilepath = op.FileName;
                    }
                    else
                    {
                        this.Openfilepath = s;
                    }
                    this.closehmi();
                    this.Myapp = new Myapp_inf();
                    this.Myapp.changappevent = new Myapp_inf.appchangevent(this.appchangevent);
                    this.Myapp.savetempfile = new Myapp_inf.savetempfile_(this.savetempfile);
                    this.Myapp.refzikuevent = new Myapp_inf.refzikuevent_(this.zikuadmin1.Ref);
                    this.Myapp.refpicevent = new Myapp_inf.refpicevent_(this.picadmin1.Ref);
                    this.Myapp.changappevent(false);
                    if (!this.Myapp.Open(this.Openfilepath))
                    {
                        this.closehmi();
                        return false;
                    }
                    this.Myapp.savetempfile();
                    this.runscr1.guiint_bianji(this.Myapp, datasize.runfilepath);
                    this.runscr1.Visible = true;
                    this.pageadmin1.Setapp(this.Myapp);
                    this.picadmin1.Setapp(this.Myapp);
                    this.zikuadmin1.Setapp(this.Myapp);
                    this.objatt2.Setapp(this.Myapp);
                    this.picadmin1.Ref();
                    this.zikuadmin1.Ref();
                    this.tbianyi.Enabled = true;
                    this.colListBox1.Enabled = true;
                    this.gongju1.Enabled = true;
                    this.gongju4.Enabled = true;
                    this.gongju2.Enabled = true;
                    this.gongju3.Enabled = true;
                    if (this.Myapp.Model.Modelstring == "")
                    {
                        MessageOpen.Show("当前资源文件需要配置一个硬件型号才能继续编辑，点击确认进入型号设置页面".Language());
                        Form form = new appset(this.Myapp, 0);
                        form.ShowDialog();
                        if (form.DialogResult != DialogResult.OK)
                        {
                            this.closehmi();
                            return false;
                        }
                        this.Myapp.savetempfile();
                        this.Myapp.changappevent(true);
                        this.runscr1.RunStop();
                        this.runscr1.guiint_bianji(this.Myapp, datasize.runfilepath);
                        this.RefPage();
                    }
                    this.Text = datasize.softname + "(" + this.Openfilepath + ")";
                    this.labelItem1.Text = "Model:" + this.Myapp.Model.Modelstring + "  inch:".Language() + this.Myapp.Model.inch + "(" + this.Myapp.Model.fenbianlv + ") Flash:" + this.Myapp.Model.Flash + " RAM:" + this.Myapp.Model.RAM.ToString() + "B Frequency:" + this.Myapp.Model.GPU;
                    this.labelItem4.Text = "Encoding:" + datasize.encodes_App[this.Myapp.myencode].encodename;
                    this.Savehistorypath(this.Openfilepath);
                    this.Setpanel(false);
                    this.pageadmin1.selectindex(0);
                }
                else
                {
                    if (str5 == "save")
                    {
                        if (((this.Myapp != null) && (this.Openfilepath != null)) && (datasize.runfilepath != null))
                        {
                            this.runscr1.Pausesr();
                            this.objatt1.SaveCodes();
                            this.binpath = "";
                            if (this.Myapp.Savefile(datasize.runfilepath, 0, this.textbianyi))
                            {
                                if (File.Exists(this.Openfilepath))
                                {
                                    StreamReader reader = new StreamReader(this.Openfilepath)
                                    {
                                        BaseStream = { Position = 0L }
                                    };
                                    byte[] buffer = new byte[datasize.appxinxisize0];
                                    reader.BaseStream.Read(buffer, 0, datasize.appxinxisize0);
                                    reader.Close();
                                    reader.Dispose();
                                    reader = null;
                                    appinf0 appinf = (appinf0)buffer.BytesTostruct(new appinf0().GetType());
                                    if (appinf.filever != datasize.filever)
                                    {
                                        MessageOpen.Show("当前文件由老版本的HMI软件创建,系统将自动拷贝一份保存前的副本到版本备份目录,从如下菜单可进入版本备份目录:文件-版本备份目录".Language());
                                        if (!Directory.Exists(datasize.Verzhuanhuanpath))
                                        {
                                            Directory.CreateDirectory(datasize.Verzhuanhuanpath);
                                        }
                                        string extension = Path.GetExtension(this.Openfilepath);
                                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.Openfilepath);
                                        if (fileNameWithoutExtension.Length > 240)
                                        {
                                            fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, 240);
                                        }
                                        string str4 = "(bak_" + appinf.banbenh.ToString() + "." + appinf.banbenl.ToString() + ")" + fileNameWithoutExtension;
                                        for (int i = 1; File.Exists(datasize.Verzhuanhuanpath + @"\" + str4 + extension); i++)
                                        {
                                            str4 = fileNameWithoutExtension + "-" + i.ToString();
                                        }
                                        File.Copy(this.Openfilepath, datasize.Verzhuanhuanpath + @"\" + str4 + extension);
                                    }
                                }
                                if (!Kuozhan.delfile(this.Openfilepath))
                                {
                                    this.runscr1.Upsr();
                                    return false;
                                }
                                File.Copy(datasize.runfilepath, this.Openfilepath);
                                this.runscr1.Upsr();
                                this.Myapp.changappevent(false);
                                goto Label_0BB1;
                            }
                            this.runscr1.Upsr();
                        }
                        return false;
                    }
                    if (str5 == "bianyi")
                    {
                        if ((this.Myapp != null) && (this.Openfilepath != null))
                        {
                            if (this.Myapp.changapp && !this.filecaozuo("save", ""))
                            {
                                return false;
                            }
                            if (!Directory.Exists(datasize.Bianyipath))
                            {
                                Directory.CreateDirectory(datasize.Bianyipath);
                            }
                            this.binpath = datasize.Bianyipath + @"\" + Path.GetFileNameWithoutExtension(this.Openfilepath) + ".tft";
                            if (this.Myapp.Savefile(this.binpath, 1, this.textbianyi))
                            {
                                this.Myapp.changappevent(false);
                                goto Label_0BB1;
                            }
                            this.binpath = "";
                        }
                        return false;
                    }
                    if ((str5 == "lsave") && (this.Myapp != null))
                    {
                        dialog = new SaveFileDialog
                        {
                            Filter = "HMI文件|*.HMI|所有文件|*.*".Language()
                        };
                        dialog.Getpath("file");
                        if (dialog.ShowDialog() != DialogResult.OK)
                        {
                            return false;
                        }
                        this.Openfilepath = dialog.FileName;
                        dialog.Putpath("file");
                        this.runscr1.Pausesr();
                        this.objatt1.SaveCodes();
                        if (this.Myapp.Savefile(datasize.runfilepath, 0, this.textbianyi))
                        {
                            if (!Kuozhan.delfile(this.Openfilepath))
                            {
                                this.runscr1.Upsr();
                                return false;
                            }
                            File.Copy(datasize.runfilepath, this.Openfilepath);
                        }
                        this.runscr1.Upsr();
                        this.RefPage();
                        this.Myapp.changappevent(false);
                        this.Text = datasize.softname + "(" + this.Openfilepath + ")";
                        this.Savehistorypath(this.Openfilepath);
                        return true;
                    }
                }
            }
            Label_0BB1:
            return true;
        }




    




        //private bool hmiopen(string str, string s)
        //{
        //    bool result = false;
        //    if (str != null)
        //    {
        //        if (str == "add")
        //        {
        //            result = Add();
        //        }
        //        if (str == "open")
        //        {
        //            result = Open(s);
        //        }
        //        if ((str == "save"))
        //        {
        //            result = Save();
        //        }
        //        if (str == "bianyi")
        //        {

        //            result = BianYi();
        //        }

        //        if (str == "lsave")
        //        {
        //            result= IsSave();
        //        }

        //    }

        //    return result;
        //}

        private bool Open(string s)
        {
            bool result = false;

            if (this.Myapp != null && this.Myapp.changapp)
            {
                DialogResult dialogResult = MessageOpen.Show("当前工程内容有修改，需要保存吗?".Language(), "确认".Language(), MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!this.filecaozuo("save", ""))
                    {

                        return result;
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {

                    return result;
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (s == "")
            {
                openFileDialog.Filter = "HMI文件|*.HMI|所有文件|*.*".Language();
                openFileDialog.Getpath("file");
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {

                    return result;
                }
                openFileDialog.Putpath("file");
                this.Openfilepath = openFileDialog.FileName;
            }
            else
            {
                this.Openfilepath = s;
            }
            this.closehmi();
            this.Myapp = new Myapp_inf();
            this.Myapp.changappevent = new Myapp_inf.appchangevent(this.appchangevent);
            this.Myapp.savetempfile = new Myapp_inf.savetempfile_(this.savetempfile);
            this.Myapp.refzikuevent = new Myapp_inf.refzikuevent_(this.zikuadmin1.Ref);
            this.Myapp.refpicevent = new Myapp_inf.refpicevent_(this.picadmin1.Ref);
            this.Myapp.changappevent(false);
            if (!this.Myapp.Open(this.Openfilepath))
            {
                this.closehmi();
                result = false;
                return result;
            }
            this.Myapp.savetempfile();
            this.runscr1.guiint_bianji(this.Myapp, datasize.runfilepath);
            this.runscr1.Visible = true;
            this.pageadmin1.Setapp(this.Myapp);
            this.picadmin1.Setapp(this.Myapp);
            this.zikuadmin1.Setapp(this.Myapp);
            this.objatt2.Setapp(this.Myapp);
            this.picadmin1.Ref();
            this.zikuadmin1.Ref();
            this.tbianyi.Enabled = true;
            this.colListBox1.Enabled = true;
            this.gongju1.Enabled = true;
            this.gongju4.Enabled = true;
            this.gongju2.Enabled = true;
            this.gongju3.Enabled = true;
            if (this.Myapp.Model.Modelstring == "")
            {
                MessageOpen.Show("当前资源文件需要配置一个硬件型号才能继续编辑，点击确认进入型号设置页面".Language());
                Form form = new appset(this.Myapp, 0);
                form.ShowDialog();
                if (form.DialogResult != DialogResult.OK)
                {
                    this.closehmi();

                    return result;
                }
                this.Myapp.savetempfile();
                this.Myapp.changappevent(true);
                this.runscr1.RunStop();
                this.runscr1.guiint_bianji(this.Myapp, datasize.runfilepath);
                this.RefPage();
            }
            this.Text = datasize.softname + "(" + this.Openfilepath + ")";
            this.labelItem1.Text = string.Concat(new string[]
            {
                            "Model:",
                            this.Myapp.Model.Modelstring,
                            "  inch:".Language(),
                            this.Myapp.Model.inch,
                            "(",
                            this.Myapp.Model.fenbianlv,
                            ") Flash:",
                            this.Myapp.Model.Flash,
                            " RAM:",
                            this.Myapp.Model.RAM.ToString(),
                            "B Frequency:",
                            this.Myapp.Model.GPU
            });
            this.labelItem4.Text = "Encoding:" + datasize.encodes_App[(int)this.Myapp.myencode].encodename;
            this.Savehistorypath(this.Openfilepath);
            this.Setpanel(false);
            this.pageadmin1.selectindex(0);

            result = true;
            return result;
        }

        private bool Save()
        {
            bool result = false;

            if (this.Myapp == null || this.Openfilepath == null || datasize.runfilepath == null)
            {

                return result;
            }
            this.runscr1.Pausesr();
            this.objatt1.SaveCodes();
            this.binpath = "";
            if (!this.Myapp.Savefile(datasize.runfilepath, 0, this.textbianyi))
            {
                this.runscr1.Upsr();

                return result;
            }
            if (File.Exists(this.Openfilepath))
            {
                StreamReader streamReader = new StreamReader(this.Openfilepath);
                streamReader.BaseStream.Position = 0L;
                byte[] array = new byte[datasize.appxinxisize0];
                streamReader.BaseStream.Read(array, 0, datasize.appxinxisize0);
                streamReader.Close();
                streamReader.Dispose();
                appinf0 appinf = (appinf0)array.BytesTostruct(default(appinf0).GetType());
                if (appinf.filever != datasize.filever)
                {
                    MessageOpen.Show("当前文件由老版本的HMI软件创建,系统将自动拷贝一份保存前的副本到版本备份目录,从如下菜单可进入版本备份目录:文件-版本备份目录".Language());
                    if (!Directory.Exists(datasize.Verzhuanhuanpath))
                    {
                        Directory.CreateDirectory(datasize.Verzhuanhuanpath);
                    }
                    string extension = Path.GetExtension(this.Openfilepath);
                    string text = Path.GetFileNameWithoutExtension(this.Openfilepath);
                    if (text.Length > 240)
                    {
                        text = text.Substring(0, 240);
                    }
                    string str2 = string.Concat(new string[]
                    {
                                        "(bak_",
                                        appinf.banbenh.ToString(),
                                        ".",
                                        appinf.banbenl.ToString(),
                                        ")",
                                        text
                    });
                    int num = 1;
                    while (File.Exists(datasize.Verzhuanhuanpath + "\\" + str2 + extension))
                    {
                        str2 = text + "-" + num.ToString();
                        num++;
                    }
                    File.Copy(this.Openfilepath, datasize.Verzhuanhuanpath + "\\" + str2 + extension);
                }
            }
            if (!Kuozhan.delfile(this.Openfilepath))
            {
                this.runscr1.Upsr();

                return result;
            }
            File.Copy(datasize.runfilepath, this.Openfilepath);
            this.runscr1.Upsr();
            this.Myapp.changappevent(false);
            result = true;
            return result;
        }

        private bool Add()
        {
            bool result = false;

            if (this.Myapp != null && this.Myapp.changapp)
            {
                DialogResult dialogResult = MessageOpen.Show("当前工程内容有修改，需要保存吗?".Language(), "确认".Language(), MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!this.filecaozuo("save", ""))
                    {

                        return result;
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {

                    return result;
                }
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HMI文件|*.HMI|所有文件|*.*".Language();
            saveFileDialog.Getpath("file");
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {

                return result;
            }
            this.closehmi();
            this.Myapp = new Myapp_inf();
            this.Myapp.changappevent = new Myapp_inf.appchangevent(this.appchangevent);
            this.Myapp.savetempfile = new Myapp_inf.savetempfile_(this.savetempfile);
            this.Myapp.refzikuevent = new Myapp_inf.refzikuevent_(this.zikuadmin1.Ref);
            this.Myapp.refpicevent = new Myapp_inf.refpicevent_(this.picadmin1.Ref);
            this.Myapp.changappevent(false);
            mpage item = this.Myapp.Creatnewpage(true);
            this.Myapp.pages.Add(item);
            this.Myapp.RefpageID();
            if (new appset(this.Myapp, 0).ShowDialog() != DialogResult.OK)
            {

                return result;
            }
            this.runscr1.RunStop();
            this.Openfilepath = saveFileDialog.FileName;
            saveFileDialog.Putpath("file");
            this.Myapp.Savefile(this.Openfilepath, 0, this.textbianyi);
            this.closehmi();
            this.filecaozuo("open", this.Openfilepath);

            result = true;
            return result;
        }

        private void RefPage()
        {
            if (this.dpage != null)
            {
                if (this.groupBox1.Visible)
                {
                    this.textpage.Text = this.dpage.Codes.GetCodesstring();
                }
                if (!this.runscr1.Visible)
                {
                    this.runscr1.guiint_bianji(this.Myapp, datasize.runfilepath);
                    this.runscr1.Visible = true;
                }
            }
            this.runscr1.Refpage_Edit(this.dpage);
            this.objatt1.Refobj(this.Myapp, this.dpage, null);
            this.objatt2.Setpage(this.dpage);
            this.objatt2.objs.Clear();
            this.runscr1.setxuanzhong_all(false);
            if (this.dpage != null)
            {
                this.runscr1.setxuanzhong_add(0);
                this.dpage.chexiaobutton = this.buttonItem40;
                this.dpage.huifubutton = this.buttonItem41;
                this.dpage.refbackview();
            }
            this.objselect();
            this.runscr1.Focus();
        }

        private void pageadmin1_Selectenter(object sender, EventArgs e)
        {
            int num = (int)sender;
            if (num == -1 || num >= this.Myapp.pages.Count)
            {
                this.dpage = null;
                this.RefPage();
            }
            else if (this.dpage != this.Myapp.pages[num])
            {
                this.dpage = this.Myapp.pages[num];
                this.RefPage();
            }
        }

        private void addredian(byte mark)
        {
            try
            {
                if (this.dpage != null)
                {
                    if (this.dpage.mypage.pagelock == 1)
                    {
                        MessageOpen.Show("页面已锁定！".Language());
                    }
                    else
                    {
                        mobj mobj = new mobj(this.Myapp, this.dpage);
                        mobj.atts = objattcaozuo.Getmatts(mark, ref mobj.myobj.redian);
                        mobj expr_7D_cp_0_cp_0 = mobj;
                        expr_7D_cp_0_cp_0.myobj.redian.endx = (ushort)(expr_7D_cp_0_cp_0.myobj.redian.endx - mobj.myobj.redian.x);
                        mobj expr_A5_cp_0_cp_0 = mobj;
                        expr_A5_cp_0_cp_0.myobj.redian.endy = (ushort)(expr_A5_cp_0_cp_0.myobj.redian.endy - mobj.myobj.redian.y);
                        mobj.myobj.redian.x = 0;
                        mobj.myobj.redian.y = 0;
                        mobj.myobj.objType = mark;
                        this.Myapp.makeobjname(this.dpage, mobj, objtype.getobjmark(mark).intname);
                        this.dpage.starback();
                        this.dpage.dcomp0.Tag = this.getxuanzhongxulie();
                        this.dpage.addobj(mobj);
                        string text = mobj.objid.ToString();
                        this.dpage.dcomp1.Tag = text;
                        this.dpage.endback();
                        this.Myapp.changappevent(true);
                        this.runscr1.LoadObj(mobj);
                        this.setxuanzhongxulie(text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void runscr1_Runcode(object sender, EventArgs e)
        {
        }

        private void runscr1_SendCom(object sender, EventArgs e)
        {
            int value = (int)sender;
            string text = Convert.ToString(value, 16);
            if (text.Length == 1)
            {
                text = "0" + text;
            }
            this.comdata2 = this.comdata2 + "0X" + text + " ";
            if (text == "0a")
            {
                this.listBox1.Items.Add(this.comdata2.Trim());
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                this.comdata2 = "";
            }
        }

        private void Savelayout()
        {
            try
            {
                this.dotNetBarManager1.SaveLayout(datasize.layout);
            }
            catch
            {
            }
        }

        private void Getlayout(int index)
        {
            try
            {
                if (this.gongju0.Parent != this.dockSite7 || this.gongju1.Parent != this.dockSite7 || this.gongju2.Parent != this.dockSite7 || this.gongju3.Parent != this.dockSite7 || this.gongju4.Parent != this.dockSite7)
                {
                    base.WindowState = FormWindowState.Minimized;
                    base.WindowState = FormWindowState.Maximized;
                }
                if (index == 0)
                {
                    if (File.Exists(datasize.layout))
                    {
                        this.dotNetBarManager1.LoadLayout(datasize.layout);
                    }
                }
                else if (index == 1)
                {
                    if (File.Exists(datasize.layout_temp))
                    {
                        this.dotNetBarManager1.LoadLayout(datasize.layout_temp);
                    }
                }
                else if (index == 2)
                {
                    if (File.Exists(datasize.layout_defaut))
                    {
                        this.dotNetBarManager1.LoadLayout(datasize.layout_defaut);
                    }
                }
            }
            catch
            {
            }
        }

        private void Defautlayout()
        {
            try
            {
            }
            catch
            {
            }
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.tabControl1.SelectedTabIndex == 0)
            {
                this.Savelayout();
            }
            e.Cancel = true;
            if (!this.isclose)
            {
                if (datasize.historycolorschange)
                {
                    Kuozhan.putxmlstring(datasize.historycolors, "historycolors");
                    datasize.historycolorschange = false;
                }
                if (this.exitjiance())
                {
                    return;
                }
            }
            this.isclose = true;
            this.timerclose.Enabled = true;
        }

        private bool exitjiance()
        {
            bool result;
            if (this.Myapp != null && this.Myapp.changapp)
            {
                DialogResult dialogResult = MessageOpen.Show("当前工程内容有修改，需要保存吗?".Language(), "确认".Language(), MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!this.filecaozuo("save", ""))
                    {
                        result = true;
                        return result;
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        private void runscr1_Objselect(object sender, EventArgs e)
        {
            this.objselect();
        }

        private void objselect()
        {
            if (this.runscr1.selectobjedits.Count > 0 && this.dpage.mypage.pagelock == 1)
            {
                this.runscr1.setxuanzhong_all(false);
            }
            List<byte[]> ls = new List<byte[]>();
            bool flag = false;
            if (this.Myapp != null && this.dpage != null)
            {
                if (this.runscr1.selectobjedits.Count > 0)
                {
                    if (this.groupBox1.Visible)
                    {
                        this.textobj.Text = this.runscr1.selectobjedits[0].dobj.Getcodes().GetCodesstring();
                        this.runscr1.selectobjedits[0].dobj.BianyiCodes(ref ls);
                        this.textobjbianyi.Text = ls.GetCodesstring();
                    }
                    if (this.runscr1.selectobjedits.Count == 1)
                    {
                        this.objatt1.Refobj(this.Myapp, this.dpage, this.runscr1.selectobjedits[0].dobj);
                    }
                    else
                    {
                        this.objatt1.Refobj(null, null, null);
                    }
                    this.objatt2.objs.Clear();
                    foreach (objedit current in this.runscr1.selectobjedits)
                    {
                        this.objatt2.objs.Add(current.dobj);
                    }
                    this.objatt2.Ref();
                    flag = true;
                }
            }
            if (!flag)
            {
                this.objatt1.Refobj(null, null, null);
                this.objatt2.objs.Clear();
                this.objatt2.Ref();
            }
        }

        private void appchangevent(bool chang)
        {
            if (this.Myapp != null)
            {
                this.Myapp.changapp = chang;
                this.tsave.Enabled = chang;
            }
            else
            {
                this.tsave.Enabled = false;
            }
        }

        private void savetempfile()
        {
            if (this.Myapp != null)
            {
                this.runscr1.Pausesr();
                this.objatt1.SaveCodes();
                while (!this.Myapp.Savefile(datasize.runfilepath, 0, this.textbianyi))
                {
                    MessageOpen.Show("save tempfile is error!");
                }
                this.runscr1.Upsr();
            }
        }

        private void closehmi()
        {
            try
            {
                this.objatt1.Refobj(null, null, null);
                this.objatt2.Setapp(null);
                this.pageadmin1.Setapp(null);
                this.zikuadmin1.Setapp(null);
                this.picadmin1.Setapp(null);
                this.runscr1.RunStop();
                this.runscr1.Visible = false;
                this.binpath = "";
                this.tsave.Enabled = false;
                this.tbianyi.Enabled = false;
                this.colListBox1.Enabled = false;
                this.gongju1.Enabled = false;
                this.gongju4.Enabled = false;
                this.gongju2.Enabled = false;
                this.gongju3.Enabled = false;
                this.Text = datasize.softname;
                this.labelItem1.Text = "就绪".Language();
                this.labelItem2.Text = "";
                this.labelItem4.Text = "Encoding:";
                if (this.objpanel.Visible)
                {
                    this.objpanel.Visible = false;
                    this.tabControl1_Resize(null, null);
                }
                this.Setpanel(true);
                this.textbianyi.Text = "";
                if (this.Myapp != null)
                {
                    for (int i = 0; i < this.Myapp.images.Count; i++)
                    {
                        guiimagetype value = default(guiimagetype);
                        this.Myapp.images[i].imagebitbmp.Dispose();
                        this.Myapp.images[i] = value;
                    }
                    while (this.Myapp.images.Count > 0)
                    {
                        this.Myapp.images.RemoveAt(0);
                    }
                    this.Myapp.zimodatas.Clear();
                    this.Myapp.zimos.Clear();
                }
                this.Myapp = null;
                this.dpage = null;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void download()
        {
            if (this.Myapp == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "tft文件|*.tft|所有文件|*.*".Language();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                this.binpath = openFileDialog.FileName;
            }
            else if (this.Myapp.changapp || this.binpath == "")
            {
                if (!this.filecaozuo("bianyi", ""))
                {
                    return;
                }
            }
            new USARTUP(this.binpath).ShowDialog();
        }

        private void ResizeRunscr()
        {
            try
            {
                if (this.panelEx3.Width > 50 && this.panelEx3.Height > 50)
                {
                    int num = (this.panelEx3.Width - this.runscr1.Width) / 2;
                    int num2 = (this.panelEx3.Height - (this.objpanel.Visible ? this.objpanel.Height : 0) - this.runscr1.Height) / 2;
                    if (num < 25)
                    {
                        num = 25;
                    }
                    if (num2 < 25)
                    {
                        num2 = 25;
                    }
                    this.runscr1.Location = new Point(num, num2);
                }
            }
            catch
            {
            }
        }

        private void tabPage1_DragDrop(object sender, DragEventArgs e)
        {
            Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < array.Length; i++)
            {
                string text = array.GetValue(i).ToString();
                if (File.Exists(text))
                {
                    if (Path.GetExtension(text).Contains("HMI") || Path.GetExtension(text).Contains("hmi"))
                    {
                        this.filecaozuo("open", text);
                        break;
                    }
                }
            }
        }

        private void tabPage2_DragDrop(object sender, DragEventArgs e)
        {
            Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < array.Length; i++)
            {
                string text = array.GetValue(i).ToString();
                if (File.Exists(text))
                {
                    if (Path.GetExtension(text).Contains("HMI") || Path.GetExtension(text).Contains("hmi"))
                    {
                        this.filecaozuo("open", text);
                        break;
                    }
                }
            }
        }

        private void tabPage1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tabPage2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void openfile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageOpen.Show("文件丢失".Language());
                }
                else
                {
                    Kuozhan.Openhttp(path);
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void pageadmin1_pagecheng(object sender, EventArgs e)
        {
            this.Myapp.changappevent(true);
        }

        private void picadmin1_picupdate(object sender, EventArgs e)
        {
            this.Myapp.savetempfile();
            this.Myapp.changappevent(true);
        }

        private void zikuadmin1_zikuupdate(object sender, EventArgs e)
        {
            this.Myapp.savetempfile();
            this.Myapp.changappevent(true);
        }

        private void objatt1_changatt(object sender, EventArgs e)
        {
            this.Myapp.changappevent(true);
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            this.picadmin1.SetSize();
        }

        private void panel1_Resize_1(object sender, EventArgs e)
        {
            this.zikuadmin1.SetSize();
        }

        private void panel8_Resize(object sender, EventArgs e)
        {
            this.pageadmin1.SetSize();
        }

        private void panel7_Resize(object sender, EventArgs e)
        {
            this.objatt2.SetSize();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement htmlElement in this.webBrowser1.Document.Links)
            {
                if (htmlElement.GetAttribute("href") == "http://www.tjc1688.com/")
                {
                    htmlElement.SetAttribute("target", "new");
                }
                else if (htmlElement.GetAttribute("href").Contains("bbs.tjc1688.com"))
                {
                    htmlElement.SetAttribute("target", "_self");
                }
            }
            foreach (HtmlElement htmlElement2 in this.webBrowser1.Document.Forms)
            {
                htmlElement2.SetAttribute("target", "_self");
            }
            this.webBrowser1.Visible = true;
            if (this.timer1.Enabled)
            {
                this.timer1.Enabled = false;
            }
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowser2.Visible = true;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string text = "http://bbs.tjc1688.com/hmi/download/";
            string text2 = "http://bbs.tjc1688.com/hmi/edit/";
            string text3 = "http://bbs.tjc1688.com/hmi/show.htm";
            int length = text.Length;
            int length2 = text2.Length;
            int length3 = text3.Length;
            string text4 = e.Url.ToString().Trim();
            try
            {
                if (text4.Length < length || !(text4.Substring(0, length) == text))
                {
                    if (text4.Length >= length2 && text4.Substring(0, length2) == text2)
                    {
                        e.Cancel = true;
                        string username = php.Getuserfromhtml(this.webBrowser1.Document);
                        if (text4 != "")
                        {
                            php.Username = username;
                            new upload(text4.Substring(length2, text4.Length - length2)).ShowDialog();
                        }
                        else
                        {
                            MessageOpen.Show("请先登录".Language());
                        }
                    }
                    else if (text4.Length >= length3 && text4.Substring(0, length3) == text3)
                    {
                        e.Cancel = true;
                        string username = php.Getuserfromhtml(this.webBrowser1.Document);
                        if (text4 != "")
                        {
                            php.Username = username;
                            new upload("").ShowDialog();
                        }
                        else
                        {
                            MessageOpen.Show("请先登录".Language());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageOpen.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mobj mobj = new mobj(new Myapp_inf(), new mpage(this.Myapp));
            List<matt> list = new List<matt>();
            int num = 0;
            foreach (objmark_ current in objtype.marks)
            {
                list = objattcaozuo.Getmatts(current.mark, ref mobj.myobj.redian);
                foreach (matt current2 in list)
                {
                    if (!this.textobjbianyi.Text.Contains("\"" + current2.name.Getstring(datasize.Myencoding) + "\""))
                    {
                        TextBox expr_A7 = this.textobjbianyi;
                        string text = expr_A7.Text;
                        expr_A7.Text = string.Concat(new string[]
                        {
                            text,
                            "{\"",
                            current2.name.Getstring(datasize.Myencoding),
                            "\",",
                            num.ToString(),
                            ",0,0},\r\n"
                        });
                        num++;
                    }
                }
            }
        }

        private void textbianyi_DoubleClick(object sender, EventArgs e)
        {
            int selectionStart = this.textbianyi.SelectionStart;
            int num = 0;
            if (selectionStart >= 3 && selectionStart < this.textbianyi.Text.Length)
            {
                num = this.textbianyi.GetLineFromCharIndex(this.textbianyi.SelectionStart);
                num = this.Myapp.getbianyijieguotypeindex(num);
                if (num >= 0 && this.Myapp.bianyijieguo[num].pageid != 65535)
                {
                    int num2 = this.Myapp.bianyijieguo[num].pageid;
                    if (num2 < this.Myapp.pages.Count)
                    {
                        this.pageadmin1.selectindex(num2);
                        for (int i = 100; i > 0; i--)
                        {
                            Thread.Sleep(1);
                            Application.DoEvents();
                        }
                        num2 = this.Myapp.bianyijieguo[num].objid;
                        if (num2 < this.dpage.objs.Count)
                        {
                            foreach (objedit current in this.runscr1.allobjedits)
                            {
                                if (current.dobj.objid == num2)
                                {
                                    this.runscr1.setxuanzhong_all(false);
                                    this.runscr1.setxuanzhong_add(num2);
                                    this.objselect();
                                    break;
                                }
                            }
                            for (int i = 100; i > 0; i--)
                            {
                                Thread.Sleep(1);
                                Application.DoEvents();
                            }
                            this.objatt1.setxuanzhong(this.Myapp.bianyijieguo[num].eventid, this.Myapp.bianyijieguo[num].line, 1);
                        }
                    }
                }
            }
        }

        private int findbianyitext(RichTextBox text, int star, string str)
        {
            int i = star;
            int result;
            while (i >= 0)
            {
                if (text.Text.Substring(i, 1) == "\n")
                {
                    result = 65535;
                }
                else
                {
                    if (!(text.Text.Substring(i, 1) == str))
                    {
                        i--;
                        continue;
                    }
                    result = i;
                }
                return result;
            }
            result = 65535;
            return result;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(datasize.Bianyipath))
            {
                Directory.CreateDirectory(datasize.Bianyipath);
            }
            Kuozhan.Openhttp(datasize.Bianyipath);
        }

        #region 打开
        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.filecaozuo("open", "");
        }
        #endregion

        #region 新建
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.filecaozuo("add", "");
        }
        #endregion

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            this.filecaozuo("save", "");
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            this.filecaozuo("bianyi", "");
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            if (this.Myapp != null)
            {
                if (this.Myapp.changapp || this.binpath == "" || !File.Exists(this.binpath))
                {
                    if (!this.filecaozuo("bianyi", ""))
                    {
                        return;
                    }
                }
                this.runscr1.RunStop();
                new apprun(this.binpath, this.Myapp).ShowDialog();
                this.runscr1.RunStop();
                this.runscr1.guiint_bianji(this.Myapp, datasize.runfilepath);
                this.RefPage();
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Getpath("filetft");
                openFileDialog.Filter = "tft文件|*.tft|所有文件|*.*".Language();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Putpath("filetft");
                    this.runscr1.RunStop();
                    new apprun(openFileDialog.FileName, null).ShowDialog();
                }
            }
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            this.download();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            this.copyobj();
        }

        private void copyobj()
        {
            if (this.runscr1.selectobjedits.Count == 0 || (this.runscr1.selectobjedits.Count == 1 && this.runscr1.selectobjedits[0].dobj.myobj.objType == objtype.page))
            {
                MessageOpen.Show("请先选中控件".Language());
            }
            else
            {
                this.Myapp.copymobjs.Clear();
                foreach (objedit current in this.runscr1.selectobjedits)
                {
                    this.Myapp.copymobjs.Add(current.dobj.copyobj());
                    current.Refresh();
                }
            }
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            this.zhantieobj(1);
        }

        private void zhantieobj(int mod)
        {
            int i = 0;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (this.Myapp.copymobjs.Count == 0 || this.dpage == null)
            {
                MessageOpen.Show("没有控件可以粘贴".Language());
            }
            else if (this.dpage.mypage.pagelock == 1)
            {
                MessageOpen.Show("页面已锁定！".Language());
            }
            else if (this.dpage.objs.Count + this.Myapp.copymobjs.Count > 251)
            {
                MessageOpen.Show("控件数量超过最大值".Language());
            }
            else if (this.Myapp.copymobjs.Count != 0)
            {
                try
                {
                    if (mod == 1)
                    {
                        num2 = 0;
                        i = 1;
                        while (i > 0)
                        {
                            num2 += 12;
                            i = 0;
                            foreach (mobj current in this.Myapp.copymobjs)
                            {
                                i = this.dpage.jiancechongdie((int)current.myobj.redian.x + num, (int)current.myobj.redian.y + num2, (int)current.myobj.redian.endx + num, (int)current.myobj.redian.endy + num2, null);
                                if (i != 0)
                                {
                                    break;
                                }
                            }
                        }
                        if (i != 0)
                        {
                            num2 = 0;
                            i = 1;
                            while (i > 0)
                            {
                                num2 -= 12;
                                i = 0;
                                foreach (mobj current in this.Myapp.copymobjs)
                                {
                                    i = this.dpage.jiancechongdie((int)current.myobj.redian.x + num, (int)current.myobj.redian.y + num2, (int)current.myobj.redian.endx + num, (int)current.myobj.redian.endy + num2, null);
                                    if (i != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        if (i != 0)
                        {
                            num2 = 0;
                        }
                        num = 0;
                        i = 1;
                        while (i > 0)
                        {
                            num += 12;
                            i = 0;
                            foreach (mobj current in this.Myapp.copymobjs)
                            {
                                i = this.dpage.jiancechongdie((int)current.myobj.redian.x + num, (int)current.myobj.redian.y + num2, (int)current.myobj.redian.endx + num, (int)current.myobj.redian.endy + num2, null);
                                if (i != 0)
                                {
                                    break;
                                }
                            }
                        }
                        if (i != 0)
                        {
                            num = 0;
                            i = 1;
                            while (i > 0)
                            {
                                num -= 12;
                                i = 0;
                                foreach (mobj current in this.Myapp.copymobjs)
                                {
                                    i = this.dpage.jiancechongdie((int)current.myobj.redian.x + num, (int)current.myobj.redian.y + num2, (int)current.myobj.redian.endx + num, (int)current.myobj.redian.endy + num2, null);
                                    if (i != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        if (i != 0)
                        {
                            num = 0;
                        }
                    }
                    this.dpage.starback();
                    this.dpage.dcomp0.Tag = this.getxuanzhongxulie();
                    this.runscr1.setxuanzhong_all(false);
                    foreach (mobj current in this.Myapp.copymobjs)
                    {
                        mobj mobj = new mobj(this.Myapp, this.dpage);
                        mobj = current.copyobj();
                        mobj expr_4B2_cp_0_cp_0 = mobj;
                        expr_4B2_cp_0_cp_0.myobj.redian.x = (ushort)(expr_4B2_cp_0_cp_0.myobj.redian.x + (ushort)num);
                        mobj expr_4CD_cp_0_cp_0 = mobj;
                        expr_4CD_cp_0_cp_0.myobj.redian.y = (ushort)(expr_4CD_cp_0_cp_0.myobj.redian.y + (ushort)num2);
                        mobj expr_4E8_cp_0_cp_0 = mobj;
                        expr_4E8_cp_0_cp_0.myobj.redian.endx = (ushort)(expr_4E8_cp_0_cp_0.myobj.redian.endx + (ushort)num);
                        mobj expr_503_cp_0_cp_0 = mobj;
                        expr_503_cp_0_cp_0.myobj.redian.endy = (ushort)(expr_503_cp_0_cp_0.myobj.redian.endy + (ushort)num2);
                        mobj.Myapp = this.Myapp;
                        mobj.Mypage = this.dpage;
                        if (mobj.myobj.objType != objtype.page)
                        {
                            if (this.Myapp.findobjname(this.dpage, mobj, mobj.objname))
                            {
                                this.Myapp.makeobjname(this.dpage, mobj, objtype.getobjmark(mobj.myobj.objType).intname);
                            }
                            this.dpage.addobj(mobj);
                            this.runscr1.LoadObj(mobj);
                            this.runscr1.setxuanzhong_add(mobj.objid);
                            num3++;
                        }
                    }
                    this.dpage.dcomp1.Tag = this.getxuanzhongxulie();
                    this.dpage.endback();
                    this.Myapp.changappevent(true);
                }
                catch (Exception ex)
                {
                    MessageOpen.Show(ex.Message);
                }
            }
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            this.xyshow = !this.xyshow;
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            this.filecaozuo("open", "");
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            this.filecaozuo("add", "");
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            this.filecaozuo("save", "");
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            this.filecaozuo("lsave", "");
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if (this.Myapp == null)
            {
                MessageOpen.Show("请先打开工程".Language());
            }
            else
            {
                Myapp_inf myapp_inf = new Myapp_inf();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "HMI文件|*.HMI|所有文件|*.*".Language();
                openFileDialog.Getpath("file");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Putpath("file");
                    if (myapp_inf.Open(openFileDialog.FileName))
                    {
                        myapp_inf.guidire = this.Myapp.guidire;
                        myapp_inf.lcdwidth = this.Myapp.lcdwidth;
                        myapp_inf.lcdheight = this.Myapp.lcdheight;
                        new datazhuan(myapp_inf).ShowDialog();
                        for (int i = 0; i < myapp_inf.pages.Count; i++)
                        {
                            if (myapp_inf.pages[i].mypage.pagelei > 0 && myapp_inf.pages[i].mypage.pagelei < 21)
                            {
                                if (this.Myapp.findpagename(myapp_inf.pages[i].pagename, 65535) == -1)
                                {
                                    keyboardlisttype key = this.Myapp.getkeyboardlisttype(myapp_inf.pages[i].mypage.pagelei);
                                    if (key.id != 255)
                                    {
                                        this.Myapp.Addkeyboard(key, 65535);
                                    }
                                }
                            }
                            else
                            {
                                for (int j = 0; j < myapp_inf.pages[i].objs.Count; j++)
                                {
                                    myapp_inf.pages[i].objs[j].Myapp = this.Myapp;
                                }
                                myapp_inf.pages[i].Myapp = this.Myapp;
                                myapp_inf.pages[i].objs[0].Setscreenxy();
                                if (this.Myapp.findpagename(myapp_inf.pages[i].pagename, 65535) != -1 || myapp_inf.pages[i].pagename.ishefaname() != "")
                                {
                                    if (myapp_inf.pages[i].pagename.GetbytesssASCII().Length >= 14)
                                    {
                                        myapp_inf.pages[i].pagename = myapp_inf.pages[i].pagename.GetbytesssASCII(12).Getstring(datasize.Myencoding);
                                    }
                                    myapp_inf.pages[i].pagename = this.Myapp.getpagename_key(myapp_inf.pages[i].pagename);
                                }
                                myapp_inf.pages[i].objs[0].objname = myapp_inf.pages[i].pagename;
                                this.Myapp.pages.Add(myapp_inf.pages[i]);
                            }
                        }
                        this.Myapp.RefpageID();
                        this.pageadmin1.RefList();
                        this.pageadmin1.selectindex(0);
                        for (int i = 0; i < myapp_inf.zimos.Count; i++)
                        {
                            this.Myapp.zimos.Add(myapp_inf.zimos[i]);
                            this.Myapp.zimodatas.Add(myapp_inf.zimodatas[i]);
                            this.zikuadmin1.Ref();
                        }
                        for (int i = 0; i < myapp_inf.images.Count; i++)
                        {
                            this.Myapp.images.Add(myapp_inf.images[i]);
                            this.picadmin1.Ref();
                        }
                        this.Myapp.savetempfile();
                        this.Myapp.changappevent(true);
                    }
                }
            }
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            if (!this.exitjiance())
            {
                this.closehmi();
            }
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            Formchuantiinf zi = default(Formchuantiinf);
            zi.str = new string[1];
            zi.str[0] = "";
            if (this.Myapp == null)
            {
                if (datasize.Language == 0)
                {
                    new zikucreat(zi, (int)"gb2312".GetencodeId(), this.Myapp).ShowDialog();
                }
                else
                {
                    new zikucreat(zi, (int)"iso-8859-1".GetencodeId(), this.Myapp).ShowDialog();
                }
            }
            else
            {
                int count = this.Myapp.zimos.Count;
                new zikucreat(zi, (int)this.Myapp.myencode, this.Myapp).ShowDialog();
                if (count != this.Myapp.zimos.Count)
                {
                    this.zikuadmin1.Ref();
                    this.zikuadmin1_zikuupdate(null, null);
                }
            }
        }

        private void buttonItemhelp1_Click(object sender, EventArgs e)
        {
            if (datasize.Language != 1)
            {
                this.openfile(Application.StartupPath + "\\help\\h2.pdf");
            }
        }

        private void buttonItemhelp2_Click(object sender, EventArgs e)
        {
            if (datasize.Language != 1)
            {
                this.openfile(Application.StartupPath + "\\help\\h1.pdf");
            }
        }

        private void buttonItem36_Click(object sender, EventArgs e)
        {
            Kuozhan.Openhttp("http://tjc1688.com/Support/Download/");
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            new about().ShowDialog();
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            this.buttonItem35.Enabled = false;
            this.linkLabel1.Text = "(Check...)";
            Win32.gethmiver(0, 10000, 0, 10000, false, false, false, 0);
            while (!datasize.findendstate)
            {
                Application.DoEvents();
            }
            if (datasize.dowloadurl != "")
            {
                if (datasize.dowloadurl == "err")
                {
                    this.labelItem3.Text = "服务器连接失败,无法检测最新版本,请检查你的网络连接,以确保你使用的是最新的HMI编辑软件".Language();
                    this.labelItem3.Visible = true;
                    this.bar1.Refresh();
                }
                else
                {
                    this.labelItem3.Visible = false;
                    new download(datasize.dowloadurl).ShowDialog();
                }
            }
            else
            {
                MessageOpen.Show("当前版本已是最新版本!".Language());
            }
            this.timermessage.Interval = 100;
            this.timermessage.Enabled = true;
            this.buttonItem35.Enabled = true;
            this.RefLinklabel1Ref();
        }

        private void panelEx3_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Myapp != null)
            {
                this.runscr1.setxuanzhong_all(false);
                this.objatt1.Refobj(this.Myapp, this.dpage, null);
                this.objatt2.objs.Clear();
                this.objatt2.Ref();
            }
        }

        private void panelEx3_DragDrop(object sender, DragEventArgs e)
        {
            Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < array.Length; i++)
            {
                string text = array.GetValue(i).ToString();
                if (File.Exists(text))
                {
                    if (Path.GetExtension(text).Contains("HMI") || Path.GetExtension(text).Contains("hmi"))
                    {
                        this.filecaozuo("open", text);
                        break;
                    }
                }
            }
        }

        private void panelEx3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void toolbarhide(int state)
        {
            try
            {
                if (state == 0)
                {
                    this.gongju0.Enabled = false;
                    this.gongju1.Enabled = false;
                    this.gongju2.Enabled = false;
                    this.gongju3.Enabled = false;
                    this.gongju4.Enabled = false;
                }
                else if (state == 1)
                {
                    this.gongju0.Enabled = true;
                    this.gongju1.Enabled = true;
                    this.gongju2.Enabled = true;
                    this.gongju3.Enabled = true;
                    this.gongju4.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("#2:" + ex.Message);
            }
        }

        private void cmdStyleVS2005_Click(object sender, EventArgs e)
        {
            this.setappestyle(1);
        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            this.setappestyle(0);
        }

        private void setappestyle(int index)
        {
            if (index >= this.appestyles.Length)
            {
                index = 0;
            }
            this.styleManager1.ManagerStyle = this.appestyles[index];
            index.ToString().Putval("appstyle");
        }

        private void loadappestyle()
        {
            int index = Kuozhan.Getval("appstyle").Getint();
            this.setappestyle(index);
        }

        private void buttonItem23_Click_1(object sender, EventArgs e)
        {
            this.objeditduiqi("left");
        }

        private void objeditduiqi(string state)
        {
            objedit objedit = null;
            foreach (objedit current in this.runscr1.selectobjedits)
            {
                if (current.Isxuanzhong == 2)
                {
                    objedit = current;
                    break;
                }
            }
            if (objedit != null)
            {
                foreach (objedit current in this.runscr1.selectobjedits)
                {
                    if (current != objedit && current.IsMove)
                    {
                        this.setobjeditjizhun(objedit, current, state);
                        current.Isgaibian = true;
                    }
                }
                this.runscr1_ObjXYchang(null, null);
            }
        }

        private void setobjeditjizhun(objedit jizhun, objedit ed, string state)
        {
            switch (state)
            {
                case "left":
                    ed.Left = jizhun.Left;
                    break;
                case "right":
                    ed.Left = jizhun.Left + jizhun.Width - ed.Width;
                    if (ed.Left < 0)
                    {
                        ed.Left = 0;
                    }
                    break;
                case "up":
                    ed.Top = jizhun.Top;
                    break;
                case "down":
                    ed.Top = jizhun.Top + jizhun.Height - ed.Height;
                    if (ed.Top < 0)
                    {
                        ed.Top = 0;
                    }
                    break;
                case "width":
                    ed.Width = jizhun.Width;
                    break;
                case "height":
                    ed.Height = jizhun.Height;
                    break;
                case "size":
                    ed.Width = jizhun.Width;
                    ed.Height = jizhun.Height;
                    break;
            }
        }

        private void buttonItem24_Click_1(object sender, EventArgs e)
        {
            this.objeditduiqi("right");
        }

        private void buttonItem25_Click_1(object sender, EventArgs e)
        {
            this.objeditduiqi("up");
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            this.objeditduiqi("down");
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            this.objeditduiqi("width");
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            this.objeditduiqi("height");
        }

        private void buttonItem36_Click_1(object sender, EventArgs e)
        {
            this.objeditduiqi("size");
        }

        private void buttonItem21_Click_1(object sender, EventArgs e)
        {
            this.objeditduiqispacing("x", 0);
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            this.objeditduiqispacing("x", 1);
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            this.objeditduiqispacing("x", -1);
        }

        private void buttonItem37_Click(object sender, EventArgs e)
        {
            this.objeditduiqispacing("y", 0);
        }

        private void buttonItem45_Click(object sender, EventArgs e)
        {
            this.objeditduiqispacing("y", 1);
        }

        private void buttonItem46_Click(object sender, EventArgs e)
        {
            this.objeditduiqispacing("y", -1);
        }

        private void objeditduiqispacing(string dir, int state)
        {
            try
            {
                if (this.runscr1.selectobjedits.Count >= 2)
                {
                    objedit objedit = null;
                    foreach (objedit current in this.runscr1.selectobjedits)
                    {
                        if (current.Isxuanzhong == 2)
                        {
                            objedit = current;
                            break;
                        }
                    }
                    if (objedit != null)
                    {
                        List<int> list = new List<int>();
                        list.Add(0);
                        int num;
                        if (dir == "x")
                        {
                            num = this.runscr1.selectobjedits[list[0]].Width;
                        }
                        else
                        {
                            num = this.runscr1.selectobjedits[list[0]].Height;
                        }
                        for (int i = 1; i < this.runscr1.selectobjedits.Count; i++)
                        {
                            bool flag = false;
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (dir == "x")
                                {
                                    if (this.runscr1.selectobjedits[i].Left < this.runscr1.selectobjedits[list[j]].Left)
                                    {
                                        list.Insert(j, i);
                                        flag = true;
                                        num += this.runscr1.selectobjedits[i].Width;
                                        break;
                                    }
                                }
                                else if (this.runscr1.selectobjedits[i].Top < this.runscr1.selectobjedits[list[j]].Top)
                                {
                                    list.Insert(j, i);
                                    num += this.runscr1.selectobjedits[i].Height;
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                list.Add(i);
                                if (dir == "x")
                                {
                                    num += this.runscr1.selectobjedits[i].Width;
                                }
                                else
                                {
                                    num += this.runscr1.selectobjedits[i].Height;
                                }
                            }
                        }
                        int num2;
                        if (dir == "x")
                        {
                            num2 = this.runscr1.selectobjedits[list[list.Count - 1]].Left - this.runscr1.selectobjedits[list[0]].Left + this.runscr1.selectobjedits[list[list.Count - 1]].Width;
                        }
                        else
                        {
                            num2 = this.runscr1.selectobjedits[list[list.Count - 1]].Top - this.runscr1.selectobjedits[list[0]].Top + this.runscr1.selectobjedits[list[list.Count - 1]].Height;
                        }
                        int num3 = 0;
                        if (num2 > num)
                        {
                            num3 = (num2 - num) / (list.Count - 1);
                        }
                        num3 += state;
                        if (num3 < 0)
                        {
                            num3 = 0;
                        }
                        int num4 = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (this.runscr1.selectobjedits[list[i]] == objedit)
                            {
                                num4 = i;
                                break;
                            }
                        }
                        for (int i = num4 + 1; i < list.Count; i++)
                        {
                            if (dir == "x")
                            {
                                this.runscr1.selectobjedits[list[i]].Left = this.runscr1.selectobjedits[list[i - 1]].Left + this.runscr1.selectobjedits[list[i - 1]].Width + num3;
                                this.runscr1.selectobjedits[list[i]].Isgaibian = true;
                            }
                            else
                            {
                                this.runscr1.selectobjedits[list[i]].Top = this.runscr1.selectobjedits[list[i - 1]].Top + this.runscr1.selectobjedits[list[i - 1]].Height + num3;
                                this.runscr1.selectobjedits[list[i]].Isgaibian = true;
                            }
                        }
                        for (int i = num4 - 1; i > -1; i--)
                        {
                            if (dir == "x")
                            {
                                this.runscr1.selectobjedits[list[i]].Left = this.runscr1.selectobjedits[list[i + 1]].Left - num3 - this.runscr1.selectobjedits[list[i]].Width;
                                this.runscr1.selectobjedits[list[i]].Isgaibian = true;
                            }
                            else
                            {
                                this.runscr1.selectobjedits[list[i]].Top = this.runscr1.selectobjedits[list[i + 1]].Top - num3 - this.runscr1.selectobjedits[list[i]].Height;
                                this.runscr1.selectobjedits[list[i]].Isgaibian = true;
                            }
                        }
                        this.runscr1_ObjXYchang(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        public void objsetcom_next()
        {
            if (this.dpage != null)
            {
                if (this.dpage.objsetcomps.Count > 0 && this.dpage.objsetcomindex < this.dpage.objsetcomps.Count - 1)
                {
                    this.dpage.objsetcomindex++;
                    if (this.dpage.objsetcomindex % 2 != 1)
                    {
                        this.dpage.objsetcomindex++;
                    }
                    this.objsetcom_P_run(this.dpage.objsetcomps[this.dpage.objsetcomindex], false);
                }
                this.dpage.refbackview();
            }
        }

        public void objsetcom_last()
        {
            if (this.dpage != null)
            {
                if (this.dpage.objsetcomps.Count > 0 && this.dpage.objsetcomindex > 0)
                {
                    this.dpage.objsetcomindex--;
                    if (this.dpage.objsetcomindex % 2 != 0)
                    {
                        this.dpage.objsetcomindex--;
                    }
                    this.objsetcom_P_run(this.dpage.objsetcomps[this.dpage.objsetcomindex], true);
                }
                this.dpage.refbackview();
            }
        }

        private void objsetcom_P_run(objsetcom_P comp, bool isback)
        {
            if (this.dpage.dcomp0 != null)
            {
                this.dpage.endback();
            }
            if (isback)
            {
                for (int i = comp.objset.Count - 1; i > -1; i--)
                {
                    this.objsetcom_run(comp.objset[i]);
                }
            }
            else
            {
                for (int i = 0; i < comp.objset.Count; i++)
                {
                    this.objsetcom_run(comp.objset[i]);
                }
            }
            if (comp.Refpage)
            {
                this.RefPage();
            }
            if (comp.Tag != "")
            {
                this.setxuanzhongxulie(comp.Tag);
            }
        }

        private void objsetcom_run(objsetcom com)
        {
            this.Myapp.changappevent(true);
            string lei = com.lei;
            if (lei != null)
            {
                if (!(lei == "moveobjid"))
                {
                    if (!(lei == "addobj"))
                    {
                        if (!(lei == "insertobj"))
                        {
                            if (!(lei == "delobj"))
                            {
                                if (lei == "attch")
                                {
                                    if (com.id < this.dpage.objs.Count)
                                    {
                                        this.dpage.changobjattch(com.id, com.attname, com.attval);
                                        foreach (objedit current in this.runscr1.allobjedits)
                                        {
                                            if (current.dobj.objid == com.id)
                                            {
                                                current.attgaixy();
                                                break;
                                            }
                                        }
                                        this.objselect();
                                    }
                                }
                            }
                            else if (com.id < this.dpage.objs.Count)
                            {
                                objedit objedit = this.runscr1.Getobjedit(com.id);
                                if (objedit != null)
                                {
                                    this.runscr1.selectobjedits.Remove(objedit);
                                    this.runscr1.allobjedits.Remove(objedit);
                                    objedit.Dispose();
                                }
                                this.dpage.delobj(com.id);
                            }
                        }
                        else if (com.id < this.dpage.objs.Count)
                        {
                            this.dpage.insertobj(com.id, com.backobj.copyobj());
                            this.runscr1.LoadObj(this.dpage.objs[com.id]);
                        }
                    }
                    else
                    {
                        this.dpage.addobj(com.backobj.copyobj());
                        this.runscr1.LoadObj(this.dpage.objs[this.dpage.objs.Count - 1]);
                    }
                }
                else
                {
                    this.dpage.moveobjid(com.id, com.Tag.Getint());
                }
            }
        }

        private void runscr1_Load(object sender, EventArgs e)
        {
        }

        private void runscr1_ObjXYchang(object sender, EventArgs e)
        {
            bool flag = false;
            this.dpage.starback();
            foreach (objedit current in this.runscr1.selectobjedits)
            {
                if (current.Isgaibian)
                {
                    if (current.dobj.isbangding == 0)
                    {
                        this.dpage.changobjxy(current.dobj.objid, current.Left, current.Top, current.Width, current.Height);
                    }
                    else if (current.IsMove)
                    {
                        this.dpage.changobjxy(current.dobj.objid, current.Left, current.Top);
                    }
                    flag = true;
                    current.attgaixy();
                    current.Isgaibian = false;
                }
                else
                {
                    current.Ref();
                }
            }
            this.dpage.endback();
            if (flag)
            {
                this.Myapp.changappevent(true);
                this.objselect();
            }
        }

        private void runscr1_ObjKeyDown(object sender, EventArgs e)
        {
            string a = ((string)sender).Trim();
            if (a == "D")
            {
                this.delobjs();
            }
            else if (a == "Z")
            {
                this.objsetcom_last();
            }
            else if (a == "Y")
            {
                this.objsetcom_next();
            }
            else if (a == "C")
            {
                this.copyobj();
            }
            else if (a == "V")
            {
                this.zhantieobj(1);
            }
            else if (a == "VV")
            {
                this.zhantieobj(0);
            }
            else if (a == "X")
            {
                this.copyobj();
                this.delobjs();
            }
            else if (a == "S")
            {
                if (this.tsave.Enabled)
                {
                    if (this.Myapp.changapp)
                    {
                        this.filecaozuo("save", "");
                    }
                }
            }
            this.runscr1.Focus();
        }

        private void delobjs()
        {
            if (this.dpage != null)
            {
                this.dpage.starback();
                this.dpage.dcomp0.Tag = this.getxuanzhongxulie();
                int i = 0;
                while (i < this.runscr1.selectobjedits.Count)
                {
                    if (this.runscr1.selectobjedits[i].dobj.atts[0].zhi[0] != objtype.page)
                    {
                        objedit objedit = this.runscr1.selectobjedits[i];
                        this.runscr1.selectobjedits.Remove(objedit);
                        this.runscr1.allobjedits.Remove(objedit);
                        if (this.runscr1.tobjs.Contains(objedit))
                        {
                            this.runscr1.tobjs.Remove(objedit);
                        }
                        objedit.Dispose();
                        this.dpage.delobj(objedit.dobj.objid);
                    }
                    else
                    {
                        i++;
                    }
                }
                this.dpage.endback();
                this.runscr1.setxuanzhong_add(0);
                if (this.runscr1.tobjs.Count == 0 && this.objpanel.Visible)
                {
                    this.objpanel.Visible = false;
                    this.tabControl1_Resize(null, null);
                }
                this.objselect();
                this.Myapp.changappevent(true);
            }
        }

        private void objatt2_attch(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (objedit current in this.runscr1.selectobjedits)
            {
                current.attgaixy();
                flag = true;
            }
            if (flag)
            {
                this.Myapp.changappevent(true);
            }
        }

        private void objatt2_attchhuigun(object sender, EventArgs e)
        {
            this.dpage.endback();
            this.objsetcom_last();
            if (this.dpage.objsetcomps.Count > 1)
            {
                this.dpage.objsetcomps.Remove(this.dpage.objsetcomps[this.dpage.objsetcomps.Count - 1]);
                this.dpage.objsetcomps.Remove(this.dpage.objsetcomps[this.dpage.objsetcomps.Count - 1]);
                this.dpage.objsetcomindex = this.dpage.objsetcomps.Count - 1;
            }
        }

        private void objatt2_selectobj(object sender, EventArgs e)
        {
            int num = (int)sender;
            this.runscr1.setxuanzhong_all(false);
            if (num < this.dpage.objs.Count)
            {
                this.runscr1.setxuanzhong_add(num);
            }
            this.objselect();
        }

        private void runscr1_Objpanelresize(object sender, EventArgs e)
        {
            this.tabControl1_Resize(null, null);
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.superTabControlPanel1.Width > 50 && this.superTabControlPanel1.Height > 50)
                {
                    this.panelEx3.Left = 1;
                    this.panelEx3.Top = 1;
                    int num = this.superTabControlPanel1.Width - 2;
                    int num2 = this.superTabControlPanel1.Height - (this.objpanel.Visible ? this.objpanel.Height : 0) - 4;
                    if (num > 0)
                    {
                        this.panelEx3.Width = num;
                    }
                    if (num2 > 0)
                    {
                        this.panelEx3.Height = num2;
                    }
                    if (this.objpanel.Visible)
                    {
                        this.objpanel.Left = 2;
                        num = this.superTabControlPanel1.Height - this.objpanel.Height - 2;
                        if (num > -1)
                        {
                            this.objpanel.Top = num;
                        }
                        num = this.superTabControlPanel1.Width - 4;
                        if (num > 0)
                        {
                            this.objpanel.Width = num;
                        }
                    }
                    this.ResizeRunscr();
                }
            }
            catch
            {
            }
        }

        private void buttonItem40_Click(object sender, EventArgs e)
        {
            this.objsetcom_last();
            this.runscr1.Focus();
        }

        private void buttonItem41_Click(object sender, EventArgs e)
        {
            this.objsetcom_next();
            this.runscr1.Focus();
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            this.delobjs();
            this.runscr1.Focus();
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            this.copyobj();
            this.delobjs();
            this.runscr1.Focus();
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            this.opensetform(0);
        }

        private void opensetform(int index)
        {
            if (this.Myapp != null)
            {
                Form form = new appset(this.Myapp, index);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    this.Myapp.savetempfile();
                    this.Myapp.changappevent(true);
                    this.runscr1.RunStop();
                    this.runscr1.guiint_bianji(this.Myapp, datasize.runfilepath);
                    this.RefPage();
                    this.labelItem1.Text = string.Concat(new string[]
                    {
                        "Model:",
                        this.Myapp.Model.Modelstring,
                        "  inch:".Language(),
                        this.Myapp.Model.inch,
                        "(",
                        this.Myapp.Model.fenbianlv,
                        ") Flash:",
                        this.Myapp.Model.Flash,
                        " RAM:",
                        this.Myapp.Model.RAM.ToString(),
                        "B Frequency:",
                        this.Myapp.Model.GPU
                    });
                    this.labelItem4.Text = "Encoding:" + datasize.encodes_App[(int)this.Myapp.myencode].encodename;
                }
            }
        }

        private void buttonItem42_Click(object sender, EventArgs e)
        {
            if (this.Myapp != null)
            {
                this.Myapp.redianidshow = !this.Myapp.redianidshow;
                foreach (objedit current in this.runscr1.allobjedits)
                {
                    current.Ref();
                }
            }
        }

        private void objup()
        {
            int num = 0;
            List<objedit> list = new List<objedit>();
            int num2;
            foreach (objedit current in this.runscr1.selectobjedits)
            {
                if (current.dobj.myobj.objType != objtype.page)
                {
                    num2 = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (current.dobj.objid < list[i].dobj.objid)
                        {
                            list.Insert(i, current);
                            num2 = 1;
                            break;
                        }
                    }
                    if (num2 == 0)
                    {
                        list.Add(current);
                    }
                }
            }
            num2 = list.Count;
            if (num2 > 0)
            {
                this.dpage.starback();
                this.dpage.dcomp0.Tag = this.getxuanzhongxulie();
                for (int i = list.Count - 1; i > 0; i--)
                {
                    while (list[i].dobj.objid - 1 > list[i - 1].dobj.objid)
                    {
                        if (this.dpage.moveobjid(list[i].dobj.objid - 1, list[list.Count - 1].dobj.objid))
                        {
                            num++;
                        }
                    }
                }
                while (list[0].dobj.objid > 1)
                {
                    if (this.dpage.moveobjid(list[0].dobj.objid - 1, list[list.Count - 1].dobj.objid))
                    {
                        num++;
                    }
                }
                this.dpage.dcomp1.Tag = this.getxuanzhongxulie();
                string tag = this.dpage.dcomp1.Tag;
                this.dpage.endback();
                if (num > 0)
                {
                    this.RefPage();
                    this.setxuanzhongxulie(tag);
                }
                list.Clear();
                this.Myapp.changappevent(true);
            }
        }

        private void objdown()
        {
            int num = 0;
            List<objedit> list = new List<objedit>();
            int num2;
            foreach (objedit current in this.runscr1.selectobjedits)
            {
                if (current.dobj.myobj.objType != objtype.page)
                {
                    num2 = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (current.dobj.objid < list[i].dobj.objid)
                        {
                            list.Insert(i, current);
                            num2 = 1;
                            break;
                        }
                    }
                    if (num2 == 0)
                    {
                        list.Add(current);
                    }
                }
            }
            num2 = list.Count;
            if (num2 > 0)
            {
                this.dpage.starback();
                this.dpage.dcomp0.Tag = this.getxuanzhongxulie();
                for (int i = 0; i < list.Count - 1; i++)
                {
                    while (list[i].dobj.objid + 1 < list[i + 1].dobj.objid)
                    {
                        if (this.dpage.moveobjid(list[i].dobj.objid + 1, list[0].dobj.objid))
                        {
                            num++;
                        }
                    }
                }
                while (list[list.Count - 1].dobj.objid < this.dpage.objs.Count - 1)
                {
                    if (this.dpage.moveobjid(list[list.Count - 1].dobj.objid + 1, list[0].dobj.objid))
                    {
                        num++;
                    }
                }
                this.dpage.dcomp1.Tag = this.getxuanzhongxulie();
                string tag = this.dpage.dcomp1.Tag;
                this.dpage.endback();
                if (num > 0)
                {
                    this.RefPage();
                    this.setxuanzhongxulie(tag);
                }
                list.Clear();
                this.Myapp.changappevent(true);
            }
        }

        private void setxuanzhongxulie(string str)
        {
            this.runscr1.setxuanzhong_all(false);
            string[] array = str.Split(new char[]
            {
                '-'
            });
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string str2 = array2[i];
                this.runscr1.setxuanzhong_add(str2.Getint());
            }
            this.objselect();
        }

        private string getxuanzhongxulie()
        {
            string text = "";
            for (int i = 0; i < this.runscr1.selectobjedits.Count; i++)
            {
                if (i != this.runscr1.selectobjedits.Count - 1)
                {
                    text = text + this.runscr1.selectobjedits[i].dobj.objid.ToString() + "-";
                }
                else
                {
                    text += this.runscr1.selectobjedits[i].dobj.objid.ToString();
                }
            }
            return text;
        }

        private void buttonItem43_Click(object sender, EventArgs e)
        {
            this.objdown();
        }

        private void buttonItem44_Click(object sender, EventArgs e)
        {
            this.objup();
        }

        private void WebserverRef()
        {
            this.websernag = 1;
            try
            {
                this.webBrowser1.Navigate(this.webBrowser1.Tag.ToString());
            }
            catch
            {
            }
            this.websernag = 0;
        }

        private void tabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (e.OldValue == this.superTabItem1 && e.NewValue != this.superTabItem1)
            {
                this.Savelayout();
                this.Getlayout(1);
                this.toolbarhide(0);
            }
            else if (e.OldValue != this.superTabItem1 && e.NewValue == this.superTabItem1)
            {
                this.Getlayout(0);
                this.toolbarhide(1);
            }
            if (e.NewValue == this.superTabItembbs)
            {
                if ((this.webBrowser1.Tag == null || this.webBrowser1.Tag.ToString() == "") && this.websernag == 0)
                {
                    this.webBrowser1.Visible = false;
                    this.webBrowser1.Tag = "http://bbs.tjc1688.com";
                    this.web1label.Text = "Loading...";
                    this.web1label.ForeColor = Color.Black;
                    this.timer1.Interval = 8000;
                    this.timer1.Enabled = true;
                    Thread thread = new Thread(new ThreadStart(this.WebserverRef));
                    thread.Start();
                }
            }
            else if (e.NewValue == this.superTabItemcom)
            {
                if (this.webBrowser2.Tag == null || !(this.webBrowser2.Tag.ToString() != ""))
                {
                    this.webBrowser2.Visible = false;
                    if (datasize.Language == 0)
                    {
                        this.webBrowser2.Tag = Application.StartupPath + "\\help\\index.htm";
                    }
                    else
                    {
                        this.webBrowser2.Tag = "http://wiki.iteadstudio.com/Nextion_HMI_Solution";
                    }
                    this.webBrowser2.Navigate(this.webBrowser2.Tag.ToString());
                }
            }
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            MessageOpen.Show("版本备份目录中储存的文件为：新版本软件打开老版本HMI文件时自动对老版本HMI文件的备份".Language());
            if (!Directory.Exists(datasize.Verzhuanhuanpath))
            {
                Directory.CreateDirectory(datasize.Verzhuanhuanpath);
            }
            Kuozhan.Openhttp(datasize.Verzhuanhuanpath);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.dockContainerItem4.Text = "123";
            this.bargongju.Text = "456";
        }

        private void objatt1_kuaijie(object sender, EventArgs e)
        {
            string a = (string)sender;
            if (a == "S")
            {
                if (this.Myapp.changapp)
                {
                    this.filecaozuo("save", "");
                }
            }
        }

        private void buttonItemhelp4_Click(object sender, EventArgs e)
        {
            if (datasize.Language != 1)
            {
                this.openfile(Application.StartupPath + "\\help\\h3.pdf");
            }
        }

        private void buttonItemhelp4_Click_1(object sender, EventArgs e)
        {
            if (datasize.Language != 1)
            {
                this.openfile(Application.StartupPath + "\\help\\h4.pdf");
            }
        }

        private void runscr1_Resize(object sender, EventArgs e)
        {
            this.ResizeRunscr();
        }

        private void runscr1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.Myapp != null && this.runscr1.Visible)
                {
                    Point point = this.runscr1.PointToClient(Control.MousePosition);
                    this.labelItem2.Text = "   Coordinate X:" + point.X.ToString() + "  Y:" + point.Y.ToString();
                }
            }
            catch
            {
            }
        }

        private void runscr1_Dragobj(object sender, EventArgs e)
        {
            try
            {
                if (this.Myapp != null && this.runscr1.Visible)
                {
                    Point point = (Point)sender;
                    this.labelItem2.Text = "   Obj Location X:" + point.X.ToString() + "  Y:" + point.Y.ToString();
                }
            }
            catch
            {
            }
        }

        private void runscr1_Moveobj(object sender, EventArgs e)
        {
            this.runscr1_MouseMove(null, null);
        }

        private void panelEx3_MouseMove(object sender, MouseEventArgs e)
        {
            this.runscr1_MouseMove(null, null);
        }

        private void buttonItemhelp6_Click(object sender, EventArgs e)
        {
            if (datasize.Language == 1)
            {
                Kuozhan.Openhttp("http://wiki.iteadstudio.com/Nextion_HMI_Solution");
            }
            else
            {
                Kuozhan.Openhttp("http://tjc1688.com/hmi/hmimove.html");
            }
        }

        private void buttonItemhs_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonItem buttonItem = (ButtonItem)sender;
                if (!File.Exists(buttonItem.Tooltip))
                {
                    MessageOpen.Show("文件路劲失效!".Language());
                }
                else
                {
                    this.filecaozuo("open", buttonItem.Tooltip);
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
        }

        private void itemPanel2_Resize(object sender, EventArgs e)
        {
            if (this.itemPanel2.Width > this.pictureBox1.Width && this.itemPanel2.Height > this.pictureBox1.Height)
            {
                this.pictureBox1.Top = (this.itemPanel2.Height - this.pictureBox1.Height) / 2;
                this.pictureBox1.Left = (this.itemPanel2.Width - this.pictureBox1.Width) / 2;
                this.labelX2.Left = this.pictureBox1.Left;
                this.labelX2.Top = this.pictureBox1.Top + this.pictureBox1.Height + 7;
                this.labelX1.Left = this.labelX2.Left;
                this.labelX1.Top = this.labelX2.Top + this.labelX2.Height + 7;
                this.linkLabel1.Top = this.labelX1.Top;
                this.linkLabel1.Left = this.labelX1.Left + this.labelX1.Width + 4;
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.buttonItem35.Enabled)
            {
                this.buttonItem35_Click(null, null);
            }
        }

        private void bar5_ItemClick(object sender, EventArgs e)
        {
        }

        private void ClearHis_Click(object sender, EventArgs e)
        {
            if (MessageOpen.Show("确认要清空历史项目打开记录吗？".Language(), "确认".Language(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (File.Exists(datasize.newhistorypath))
                {
                    Kuozhan.delfile(datasize.newhistorypath);
                    if (this.Myapp == null)
                    {
                        this.Setpanel(true);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (this.websernag == 0)
            {
                this.web1label.Text = "Loading Error!";
                this.web1label.ForeColor = Color.Red;
                this.webBrowser1.Tag = null;
            }
        }

        private void buttonItem47_Click(object sender, EventArgs e)
        {
            if (datasize.tanchuangurl != null && datasize.tanchuangurl != "")
            {
                new tanchuang(datasize.tanchuangurl).ShowDialog();
            }
        }

        private void timermessage_Tick(object sender, EventArgs e)
        {
            try
            {
                if (datasize.mesgtim > 900 && datasize.mesgtim < 6500000)
                {
                    this.timermessage.Interval = datasize.mesgtim;
                }
                if (datasize.guangdaos.Count > 0)
                {
                    if (this.dmessage >= datasize.guangdaos.Count)
                    {
                        this.dmessage = 0;
                    }
                    this.labelItem3.Text = datasize.guangdaos[this.dmessage].str;
                    this.dmessageurl = datasize.guangdaos[this.dmessage].url;
                    if (!this.labelItem3.Visible)
                    {
                        this.labelItem3.Visible = true;
                        this.bar1.Refresh();
                    }
                    this.dmessage++;
                }
                else
                {
                    this.timermessage.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.labelItem3.Text = "Error:" + ex.Message;
            }
        }

        private void labelItem3_MouseMove(object sender, MouseEventArgs e)
        {
            this.labelItem3.ForeColor = Color.Red;
            this.timermessage.Enabled = false;
        }

        private void labelItem3_MouseLeave(object sender, EventArgs e)
        {
            this.labelItem3.ForeColor = Color.Blue;
            this.timermessage.Enabled = true;
        }

        private void labelItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dmessageurl != "")
                {
                    Kuozhan.Openhttp(this.dmessageurl);
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void timerclose_Tick(object sender, EventArgs e)
        {
            this.timerclose.Enabled = false;
            Environment.Exit(0);
        }

        private void objatt1_saveapp(object sender, EventArgs e)
        {
            this.runscr1_ObjKeyDown("S", e);
        }

        private void buttonItem49_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTabIndex != 0)
            {
                this.tabControl1.SelectedTabIndex = 0;
            }
            this.Getlayout(2);
        }

        private void colListBox1_ItemMouseUP(object sender, EventArgs e)
        {
            if (this.colListBox1.SelectItemindex > -1)
            {
                ColListBoxItem item = this.colListBox1.GetItem(this.colListBox1.SelectItemindex);
                this.addredian((byte)item.obj);
                this.colListBox1.SelectItemindex = -1;
            }
        }

        private void main_Move(object sender, EventArgs e)
        {
            try
            {
                this.objatt1.closemessageshow();
            }
            catch
            {
            }
        }

        private void buttonItem17_Click_1(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTabIndex != 0)
            {
                this.tabControl1.SelectedTabIndex = 0;
            }
            this.Getlayout(2);
        }

        private void buttonItem20_Click_1(object sender, EventArgs e)
        {
            new sysset().ShowDialog();
            this.objatt1.codehigset();
        }

        private void objatt2_changepage(object sender, EventArgs e)
        {
            int pageid = this.dpage.pageid;
            this.pageadmin1.RefList();
            this.pageadmin1.selectindex(pageid);
        }

        private void labelItem4_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.labelItem4.ForeColor != Color.Red)
            {
                this.encodinglinkcolor = this.labelItem4.ForeColor;
                this.labelItem4.ForeColor = Color.Red;
            }
        }

        private void labelItem4_MouseLeave(object sender, EventArgs e)
        {
            if (this.encodinglinkcolor != Color.Red)
            {
                this.labelItem4.ForeColor = this.encodinglinkcolor;
            }
        }

        private void labelItem4_Click(object sender, EventArgs e)
        {
            this.opensetform(1);
        }

    }
}