using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using hmitype;

namespace USARTHMI
{
    public partial class appset : DevComponents.DotNetBar.OfficeForm
    {

        private ItemPanel itemPanel1;

        private ItemContainer itemContainer1;

        private MetroTileItem metroTileItem0;

        private MetroTileItem metroTileItem1;

        private MetroTileItem metroTileItem2;

        private ButtonX buttonX1;

        private ButtonX buttonX2;

        private SuperTabControl superTabControl2;

        private SuperTabControlPanel superTabControlPanel2;

        private SuperTabItem superTabItem2;

        private SuperTabControlPanel superTabControlPanel8;

        private SuperTabItem superTabItem8;

        private PanelEx panelEx3;

        private LabelX labelX1;

        private ItemPanel itemPanel3;

        private ItemContainer itemContainer3;

        private MetroTileItem itemshow1;

        private MetroTileItem itemshow2;

        private MetroTileItem itemshow3;

        private MetroTileItem metroTileItem6;

        private MetroTileItem metroTileItem8;

        private MetroTileItem itemshow0;

        private ComboBoxEx comboBox2;

        private LabelX labelX2;

        private PanelEx panelEx4;

        private PanelEx panelEx1;

        private PanelEx panelEx2;

        private ItemPanel itemPanel2;

        private ItemContainer itemContainer2;

        private MetroTileItem tem0;

        private Line line1;

        private Line line2;

        private Line line3;

        private Timer timer1;

        private List<MetroTileItem> itemxilies = new List<MetroTileItem>();

        private List<MetroTileItem> itemmodels = new List<MetroTileItem>();

        private List<MetroTileItem> itemshows = new List<MetroTileItem>();

        private int selectxilieindex = -1;

        private int selectmodelindex = -1;

        private int selectshowindex = -1;

        public Myapp_inf Myapp;

        private int pageindex = 0;

        public appset()
        {
            InitializeComponent();
          
        }

        public appset(Myapp_inf app, int pageindex_)
        {
            this.pageindex = pageindex_;
            this.Myapp = app;
            this.InitializeComponent();
            this.Language();
            base.Icon = datasize.Myico;
            this.metroTileItem0.Text = "";
            if (datasize.Language == 0)
            {
                this.metroTileItem1.Text = string.Concat(new string[]
                {
                    "<font size=\"10\">",
                    "支持RTC,用户存储".Language(),
                    "<br/>",
                    "8路扩展IO".Language(),
                    "<br/>",
                    "更大的Flash空间".Language(),
                    "<br/>",
                    "更快的主控速度".Language(),
                    "</font>"
                });
            }
            this.metroTileItem2.Text = "研发中...".Language();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.itemxilies.Add(this.metroTileItem0);
            this.itemxilies.Add(this.metroTileItem1);
            this.itemxilies.Add(this.metroTileItem2);
            this.itemshows.Add(this.itemshow0);
            this.itemshows.Add(this.itemshow1);
            this.itemshows.Add(this.itemshow2);
            this.itemshows.Add(this.itemshow3);
            this.itemContainer2.SubItems.Clear();
            this.itemPanel2.Refresh();
            this.selectitem(this.itemxilies, (int)this.Myapp.xilie, ref this.selectxilieindex);
            if (this.selectxilieindex == -1)
            {
                this.selectitem(this.itemxilies, 0, ref this.selectxilieindex);
            }
            this.selectitem(this.itemshows, (int)this.Myapp.guidire, ref this.selectshowindex);
            if (this.selectshowindex == -1)
            {
                this.selectitem(this.itemshows, 0, ref this.selectshowindex);
            }
            this.comboBox2.Items.Clear();
            int[] encodes_This = datasize.encodes_This;
            for (int i = 0; i < encodes_This.Length; i++)
            {
                int j = encodes_This[i];
                this.comboBox2.Items.Add(datasize.encodes_App[j].encodename);
            }
            if ((int)this.Myapp.myencode >= datasize.encodes_App.Length)
            {
                this.Myapp.myencode = ((datasize.Language == 0) ? "gb2312".GetencodeId() : "iso-8859-1".GetencodeId());
            }
            string encodename = datasize.encodes_App[(int)this.Myapp.myencode].encodename;
            for (int j = 0; j < this.comboBox2.Items.Count; j++)
            {
                if (this.comboBox2.Items[j].ToString() == encodename)
                {
                    this.comboBox2.SelectedIndex = j;
                    break;
                }
            }
            if (this.pageindex != this.superTabControl2.SelectedTabIndex && this.pageindex < this.superTabControl2.Tabs.Count)
            {
                this.superTabControl2.SelectedTabIndex = this.pageindex;
            }
        }

        private void RefModel()
        {
            this.line2.Visible = false;
            if (this.selectxilieindex > -1 && this.selectxilieindex < 3)
            {
                this.line2.Left = 190 + 205 * this.selectxilieindex;
                this.line2.Visible = true;
            }
            this.itemContainer2.SubItems.Clear();
            this.selectmodelindex = -1;
            while (this.itemmodels.Count > 0)
            {
                MetroTileItem metroTileItem = this.itemmodels[0];
                this.itemmodels.Remove(metroTileItem);
                metroTileItem.Dispose();
            }
            if (this.selectxilieindex == -1)
            {
                this.itemPanel2.Refresh();
            }
            else
            {
                if (datasize.Modes!=null)
                {
                    for (int i = 0; i < datasize.Modes[this.selectxilieindex].Length; i++)
                    {
                        modelxinxi modelxinxi = datasize.Modes[this.selectxilieindex][i];
                        MetroTileItem metroTileItem = new MetroTileItem();
                        metroTileItem.Tag = i.ToString();
                        metroTileItem.SymbolColor = Color.Empty;
                        metroTileItem.Text = string.Concat(new string[]
                        {
                        "<font size=\"10\"><br/><br/>inch:",
                        modelxinxi.inch,
                        "(",
                        modelxinxi.fenbianlv,
                        ") Flash:",
                        modelxinxi.Flash,
                        " RAM:",
                        modelxinxi.RAM.ToString(),
                        "B Frequency:",
                        modelxinxi.GPU,
                        "</font>"
                        });
                        metroTileItem.TileColor = eMetroTileColor.Gray;
                        metroTileItem.TileSize = new Size(this.tem0.TileSize.Width, this.tem0.TileSize.Height);
                        metroTileItem.TileStyle.CornerType = eCornerType.Square;
                        metroTileItem.TitleText = modelxinxi.Modelstring;
                        metroTileItem.TitleTextAlignment = ContentAlignment.TopLeft;
                        metroTileItem.TitleTextFont = new Font(this.tem0.TitleTextFont.Name, this.tem0.TitleTextFont.Size);
                        metroTileItem.Click += new EventHandler(this.ItemModel_Click);
                        this.itemmodels.Add(metroTileItem);
                        this.itemContainer2.SubItems.Add(metroTileItem);
                    }
                    this.itemPanel2.Refresh();
                    for (int i = 0; i < datasize.Modes[this.selectxilieindex].Length; i++)
                    {
                        if (datasize.Modes[this.selectxilieindex][i].Modelstring == this.Myapp.Model.Modelstring)
                        {
                            this.selectitem(this.itemmodels, i, ref this.selectmodelindex);
                            break;
                        }
                    }
                }
            }
        }

        private void refshowzifu()
        {
            if (this.selectxilieindex > -1 & this.selectmodelindex > -1)
            {
                string[] array = datasize.Modes[this.selectxilieindex][this.selectmodelindex].fenbianlv.Split(new char[]
                {
                    'X'
                });
                if (array.Length == 2)
                {
                    if (array[0].Getint() > array[1].Getint())
                    {
                        this.itemshow0.TitleText = "横屏".Language();
                        this.itemshow1.TitleText = "竖屏".Language();
                        this.itemshow2.TitleText = "横屏".Language();
                        this.itemshow3.TitleText = "竖屏".Language();
                    }
                    else
                    {
                        this.itemshow0.TitleText = "竖屏".Language();
                        this.itemshow1.TitleText = "横屏".Language();
                        this.itemshow2.TitleText = "竖屏".Language();
                        this.itemshow3.TitleText = "横屏".Language();
                    }
                }
            }
        }

        private void selectitem(List<MetroTileItem> items, int index, ref int select)
        {
            eMetroTileColor eMetroTileColor;
            eMetroTileColor eMetroTileColor2;
            if (items == this.itemmodels)
            {
                eMetroTileColor = eMetroTileColor.Gray;
                eMetroTileColor2 = eMetroTileColor.RedViolet;
            }
            else if (items == this.itemshows)
            {
                eMetroTileColor = eMetroTileColor.Coffee;
                eMetroTileColor2 = eMetroTileColor.Orange;
            }
            else
            {
                eMetroTileColor = eMetroTileColor.Blueish;
                eMetroTileColor2 = eMetroTileColor.Orange;
            }
            if (index < items.Count)
            {
                if (index == -1)
                {
                    if (select != -1 && select < items.Count)
                    {
                        items[select].TileColor = eMetroTileColor;
                    }
                    select = -1;
                    if (items == this.itemxilies)
                    {
                        this.RefModel();
                    }
                }
                else
                {
                    select = index;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (i == select)
                        {
                            if (items[i].TileColor != eMetroTileColor2)
                            {
                                items[i].TileColor = eMetroTileColor2;
                            }
                        }
                        else if (items[i].TileColor != eMetroTileColor)
                        {
                            items[i].TileColor = eMetroTileColor;
                        }
                    }
                    if (items == this.itemxilies)
                    {
                        this.RefModel();
                    }
                    if (items == this.itemmodels)
                    {
                        this.refshowzifu();
                    }
                }
            }
        }

        private void selectitem(List<MetroTileItem> items, MetroTileItem me, ref int select)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (me == items[i])
                {
                    this.selectitem(items, i, ref select);
                    break;
                }
            }
        }

        private void metroTileItem_Click(object sender, EventArgs e)
        {
            MetroTileItem me = (MetroTileItem)sender;
            this.selectitem(this.itemxilies, me, ref this.selectxilieindex);
        }

        private void ItemModel_Click(object sender, EventArgs e)
        {
            MetroTileItem me = (MetroTileItem)sender;
            this.selectitem(this.itemmodels, me, ref this.selectmodelindex);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void metroTileItemshow_Click(object sender, EventArgs e)
        {
            MetroTileItem me = (MetroTileItem)sender;
            this.selectitem(this.itemshows, me, ref this.selectshowindex);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (this.selectxilieindex < 0)
            {
                MessageOpen.Show("请选择设备系列".Language());
            }
            else if (this.selectmodelindex < 0)
            {
                MessageOpen.Show("请选择设备型号".Language());
            }
            else
            {
                this.Myapp.myencode = this.comboBox2.Text.GetencodeId();
                datasize.Myencoding = Encoding.GetEncoding(datasize.encodes_App[(int)this.Myapp.myencode].encodename);
                this.Myapp.xilie = (byte)this.selectxilieindex;
                this.Myapp.Model = datasize.Modes[this.selectxilieindex][this.selectmodelindex];
                string[] array = datasize.Modes[this.selectxilieindex][this.selectmodelindex].fenbianlv.Split(new char[]
                {
                    'X'
                });
                if (array.Length == 2)
                {
                    this.Myapp.guidire = (byte)this.selectshowindex;
                    string a = this.Myapp.lcdwidth.ToString() + "X" + this.Myapp.lcdheight.ToString();
                    this.Myapp.lcdwidth = ((this.Myapp.guidire % 2 == 0) ? ushort.Parse(array[0]) : ushort.Parse(array[1]));
                    this.Myapp.lcdheight = ((this.Myapp.guidire % 2 == 0) ? ushort.Parse(array[1]) : ushort.Parse(array[0]));
                    string b = this.Myapp.lcdwidth.ToString() + "X" + this.Myapp.lcdheight.ToString();
                    bool flag = false;
                    if (a != b)
                    {
                        this.Myapp.loadkeyboardlist();
                        for (int i = 0; i < this.Myapp.pages.Count; i++)
                        {
                            if (this.Myapp.pages[i].mypage.pagelei > 0 && this.Myapp.pages[i].mypage.pagelei < 21)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        MessageOpen.Show("此工程的分辨率发生变化,工程中使用的内置键盘页面可能会出现布局错乱,选中异常的内置键盘页面在右键菜单中可以重置此页面以适用新的分辨率".Language());
                    }
                    new datazhuan(this.Myapp).ShowDialog();
                    foreach (mpage current in this.Myapp.pages)
                    {
                        current.objs[0].Setscreenxy();
                    }
                    base.DialogResult = DialogResult.OK;
                }
                base.Close();
            }
        }
    }
}