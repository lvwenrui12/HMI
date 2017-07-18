using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using hmitype;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace rsapp
{
    public partial class objattoo : UserControl
    {
        #region 控件
        private textmsg textmsg1 = null;

        private Myapp_inf Myapp;

        private mpage dpage = null;

        private mobj dobj = null;

        private SuperTabItem[] tabitmes = new SuperTabItem[8];

        private bool headload = false;

        private bool issave = true;

        private bool textevent = false;

        public TextEditorControl textcode;
        
        private Label labetextBox1l1;

        private Label label2;

        private SuperTabControl tabControl1;

        private SuperTabControlPanel superTabControlPanel0;

        private SuperTabItem TabItem0;

        private CheckBox checkBox1;

        private SuperTabControlPanel superTabControlPanel16;

        private SuperTabControlPanel superTabControlPanel1;

        private SuperTabItem TabItem1;

        private SuperTabControlPanel superTabControlPanel6;

        private SuperTabItem TabItem6;

        private SuperTabControlPanel superTabControlPanel7;

        private SuperTabItem TabItem7;

        private SuperTabControlPanel superTabControlPanel5;

        private SuperTabItem TabItem5;

        private SuperTabControlPanel superTabControlPanel4;

        private SuperTabItem TabItem4;

        private SuperTabControlPanel superTabControlPanel3;

        private SuperTabItem TabItem3;

        private SuperTabControlPanel superTabControlPanel2;

        private SuperTabItem TabItem2;

        private TextEditorControl textBox1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem copyToolStripMenuItem;

        private ToolStripMenuItem zhantieToolStripMenuItem;

        private ToolStripMenuItem cutToolStripMenuItem;

        private ToolStripMenuItem delToolStripMenuItem;


        #endregion
        public objattoo()
        {
            this.InitializeComponent();
            this.textcode = this.textBox1;
            this.tabitmes[0] = this.TabItem0;
            this.tabitmes[1] = this.TabItem1;
            this.tabitmes[2] = this.TabItem2;
            this.tabitmes[3] = this.TabItem3;
            this.tabitmes[4] = this.TabItem4;
            this.tabitmes[5] = this.TabItem5;
            this.tabitmes[6] = this.TabItem6;
            this.tabitmes[7] = this.TabItem7;
            this.Close();
        }

        public event EventHandler attch;
        
        public event EventHandler changepage;
        

        public event EventHandler attchhuigun;
       
        public event EventHandler selectobj;

       

     

        public event EventHandler changatt;


        public event EventHandler saveapp;


        public void setxuanzhong(int index, int line, int qyt)
        {
            try
            {
                int i = 0;
                while (i < this.tabControl1.Tabs.Count)
                {
                    if (this.tabControl1.Tabs[i].Tag.ToString().Getint() == index)
                    {
                        this.tabControl1.SelectedTabIndex = i;
                        if (qyt < 1)
                        {
                            break;
                        }
                        if (line + qyt > this.textBox1.Document.TotalNumberOfLines)
                        {
                            break;
                        }
                        Point startPosition = this.textBox1.Document.OffsetToPosition(this.textBox1.Document.GetLineSegment(line).Offset);
                        Point endPosition = this.textBox1.Document.OffsetToPosition(this.textBox1.Document.GetLineSegment(line + qyt - 1).Offset + this.textBox1.Document.GetLineSegment(line + qyt - 1).Length);
                        this.textBox1.ActiveTextAreaControl.SelectionManager.SetSelection(new DefaultSelection(this.textBox1.Document, startPosition, endPosition));
                        this.textBox1.Focus();
                        this.textBox1.ActiveTextAreaControl.ScrollTo(line);
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private int findr(int index)
        {
            int i = 0;
            int num = index;
            int result;
            while (i < this.textBox1.Text.Length)
            {
                if (num == 0)
                {
                    result = i;
                    return result;
                }
                if (this.textBox1.Text.Substring(i, 1) == "\n")
                {
                    num--;
                }
                i++;
            }
            result = 65535;
            return result;
        }

        private void objatt_Load(object sender, EventArgs e)
        {
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            Kuozhan.Setobj(this.contextMenuStrip1, datasize.Language);
            this.textBox1.ShowEOLMarkers = false;
            this.textBox1.Encoding = Encoding.Default;
            this.textBox1.ShowSpaces = false;
            this.textBox1.ShowTabs = false;
            this.textBox1.ShowVRuler = false;
            this.textBox1.TabIndent = 2;
            this.textBox1.ShowLineNumbers = false;
            this.textBox1.Text = "";
            this.codehigset();
        }

        public void closemessageshow()
        {
            if (this.textmsg1 != null)
            {
                this.textmsg1.closemessageshow();
            }
        }

        private void DocumentChanged(object sender, DocumentEventArgs e)
        {
            if (this.textevent)
            {
                if (this.changatt != null)
                {
                    this.changatt(null, null);
                }
            }
        }

        private void Document_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Myapp != null && this.textevent)
            {
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
                {
                    if (this.saveapp != null)
                    {
                        this.saveapp(this, null);
                    }
                    this.textBox1.Focus();
                }
            }
        }

        private void refheadmsg()
        {
            for (int i = 0; i < this.tabControl1.Tabs.Count; i++)
            {
                int num = 0;
                if (this.tabControl1.Tabs[i].Tag.ToString() == "4")
                {
                    byte b = 1;
                    if (((int)this.dobj.myobj.redian.sendkey & 1 << (int)b) > 0)
                    {
                        num++;
                    }
                }
                else if (this.tabControl1.Tabs[i].Tag.ToString() == "6")
                {
                    byte b = 0;
                    if (((int)this.dobj.myobj.redian.sendkey & 1 << (int)b) > 0)
                    {
                        num++;
                    }
                }
                this.tabControl1.Tabs[i].Text = this.tabControl1.Tabs[i].Text.Split(new char[]
                {
                    '('
                })[0] + "(" + (this.dobj.Codes[this.tabControl1.Tabs[i].Tag.ToString().Getint()].Count + num).ToString() + ")";
            }
        }

        private void refhead()
        {
            this.tabControl1.Visible = false;
            this.headload = true;
            objmark_ objmark_ = objtype.getobjmark(this.dobj.myobj.objType);
            int i;
            for (i = 0; i < objmark_.events.Length; i++)
            {
                if (i >= this.tabControl1.Tabs.Count)
                {
                    this.tabControl1.Tabs.Add(this.tabitmes[i]);
                }
                this.tabControl1.Tabs[i].Text = objmark_.events[i].eventname;
                this.tabControl1.Tabs[i].Tag = objmark_.events[i].eventid;
            }
            while (i < this.tabControl1.Tabs.Count)
            {
                this.tabControl1.Tabs.Remove(this.tabControl1.Tabs.Count - 1);
            }
            this.tabControl1.Visible = (this.tabControl1.Tabs.Count > 0);
            this.headload = false;
        }

        public void Refobj(Myapp_inf app, mpage page, mobj obj)
        {
            if (app == null || page == null || obj == null)
            {
                this.Close();
            }
            else
            {
                if (this.Myapp != null && this.dpage != null && this.dobj != null && this.textBox1.Visible)
                {
                    if (this.Myapp == app && this.dpage == page && this.dobj == obj)
                    {
                        return;
                    }
                }
                if (this.textmsg1 == null)
                {
                    this.textmsg1 = new textmsg(this.textBox1, 0);
                    this.textBox1.Document.DocumentChanged += new DocumentEventHandler(this.DocumentChanged);
                    this.textBox1.Document.TextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Document_KeyDown);
                }
                this.textmsg1.Myapp = app;
                this.textmsg1.dpage = page;
                this.SaveCodes();
                this.issave = false;
                this.Myapp = app;
                this.dpage = page;
                this.dobj = obj;
                this.refhead();
                if (this.tabControl1.SelectedTab != null && this.tabControl1.SelectedTab.Tag != null)
                {
                    this.attload(this.tabControl1.SelectedTab.Tag.ToString().Getint());
                }
                this.issave = true;
            }
        }

        private void attload(int index)
        {
            if (!this.headload)
            {
                if (this.Myapp != null && index > -1 && index < 8)
                {
                    this.textBox1.Parent = this.tabControl1.SelectedPanel;
                    this.labetextBox1l1.Parent = this.tabControl1.SelectedPanel;
                    this.textBox1.Visible = true;
                    this.labetextBox1l1.Visible = true;
                    if (index == 4 || index == 6)
                    {
                        this.checkBox1.Parent = this.tabControl1.SelectedPanel;
                        if (!this.checkBox1.Visible)
                        {
                            this.checkBox1.Visible = true;
                        }
                        if (index == 4)
                        {
                            byte b = 1;
                            if (((int)this.dobj.myobj.redian.sendkey & 1 << (int)b) > 0)
                            {
                                this.checkBox1.Checked = true;
                            }
                            else
                            {
                                this.checkBox1.Checked = false;
                            }
                        }
                        else if (index == 6)
                        {
                            byte b = 0;
                            if (((int)this.dobj.myobj.redian.sendkey & 1 << (int)b) > 0)
                            {
                                this.checkBox1.Checked = true;
                            }
                            else
                            {
                                this.checkBox1.Checked = false;
                            }
                        }
                    }
                    else
                    {
                        this.checkBox1.Visible = false;
                    }
                    if ((index == 2 || index == 3) && objtype.getobjmark(this.dobj.myobj.objType).mark != objtype.Timer)
                    {
                        this.label2.Parent = this.tabControl1.SelectedPanel;
                        if (!this.label2.Visible)
                        {
                            this.label2.Visible = true;
                        }
                        this.label2.Text = ((index == 2) ? "(前初始化事件在所有控件刷新显示之前执行)".Language() : "(后初始化事件在所有控件刷新显示之后执行)".Language());
                    }
                    else
                    {
                        this.label2.Visible = false;
                    }
                    List<byte[]> list = new List<byte[]>();
                    this.Putedit_Code(this.dobj.Codes[index], this.textBox1);
                }
                this.refheadmsg();
            }
        }

        private void Putedit_Code(List<string> ls, TextEditorControl text1)
        {
            this.textevent = false;
            this.textmsg1.textevent = false;
            byte[] array = new byte[10000000];
            int num = 0;
            byte[] array2 = "\r\n".GetbytesssASCII();
            for (int i = 0; i < ls.Count; i++)
            {
                byte[] bytes = datasize.Myencoding.GetBytes(ls[i]);
                bytes.CopyTo(array, num);
                num += bytes.Length;
                array2.CopyTo(array, num);
                num += 2;
            }
            if (num > 0)
            {
                text1.Text = datasize.Myencoding.GetString(array, 0, num);
            }
            else
            {
                text1.Text = "";
            }
            this.textevent = true;
            this.textmsg1.textevent = true;
        }

        private void Close()
        {
            try
            {
                this.SaveCodes();
                this.dpage = null;
                this.dobj = null;
                for (int i = 0; i < this.tabControl1.Tabs.Count; i++)
                {
                    this.tabControl1.Tabs[i].Tag = null;
                }
                this.textBox1.Visible = false;
                this.labetextBox1l1.Visible = false;
                this.label2.Visible = false;
                this.checkBox1.Visible = false;
                this.tabControl1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageOpen.Show("clear attoo errer" + ex.Message);
            }
        }

        public void SaveCodes()
        {
            if (this.issave && this.Myapp != null && this.Myapp.changapp && this.tabControl1.SelectedTab != null && this.tabControl1.SelectedTab.Tag != null)
            {
                int num = this.tabControl1.SelectedTab.Tag.ToString().Getint();
                if (this.dpage != null && this.dobj != null && num < 8)
                {
                    this.dobj.Codes[num] = this.textBox1.Text.GetListString();
                }
            }
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab != null && this.tabControl1.SelectedTab.Tag != null)
            {
                int num = this.tabControl1.SelectedTab.Tag.ToString().Getint();
                if (num == 4)
                {
                    if (this.checkBox1.Checked)
                    {
                        mobj expr_76_cp_0_cp_0 = this.dobj;
                        expr_76_cp_0_cp_0.myobj.redian.sendkey =Convert.ToByte (expr_76_cp_0_cp_0.myobj.redian.sendkey | 2);
                    }
                    else
                    {
                        mobj expr_98_cp_0_cp_0 = this.dobj;
                        expr_98_cp_0_cp_0.myobj.redian.sendkey =Convert.ToByte((expr_98_cp_0_cp_0.myobj.redian.sendkey & 1));
                    }
                }
                else if (num == 6)
                {
                    if (this.checkBox1.Checked)
                    {
                        mobj expr_D9_cp_0_cp_0 = this.dobj;
                        expr_D9_cp_0_cp_0.myobj.redian.sendkey =Convert.ToByte (expr_D9_cp_0_cp_0.myobj.redian.sendkey | 1);
                    }
                    else
                    {
                        mobj expr_FB_cp_0_cp_0 = this.dobj;
                        expr_FB_cp_0_cp_0.myobj.redian.sendkey = Convert.ToByte(expr_FB_cp_0_cp_0.myobj.redian.sendkey & 2);
                    }
                }
                this.changatt(this, null);
                this.refheadmsg();
            }
        }

        private void objattoo_Resize(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.Top = 0;
                this.tabControl1.Left = 0;
                this.tabControl1.Width = base.Width;
                this.tabControl1.Height = base.Height;
                this.Resizecodetext();
            }
            catch
            {
            }
        }

        private void Resizecodetext()
        {
            try
            {
                this.textBox1.Location = new Point(this.labetextBox1l1.Left, this.labetextBox1l1.Top + this.labetextBox1l1.Height + 3);
                this.textBox1.Size = new Size(this.textBox1.Width = this.textBox1.Parent.Width - this.textBox1.Left * 2, this.textBox1.Parent.Height - this.textBox1.Top - 3);
            }
            catch
            {
            }
        }

        private void tabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (this.tabControl1.SelectedTab != null && this.tabControl1.SelectedTab.Tag != null)
            {
                this.attload(this.tabControl1.SelectedTab.Tag.ToString().Getint());
            }
        }

        private void tabControl1_SelectedTabChanging(object sender, SuperTabStripSelectedTabChangingEventArgs e)
        {
            if (this.tabControl1.SelectedTab != null && this.tabControl1.SelectedTab.Tag != null)
            {
                this.SaveCodes();
            }
        }

        public void CodeEnabled(bool val)
        {
            this.textBox1.Enabled = val;
            this.checkBox1.Enabled = val;
        }

        public void codehigset()
        {
            if (datasize.codemessage[0].codehig == 1)
            {
                this.textBox1.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            }
            else
            {
                this.textBox1.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Document.TextArea.ClipboardHandler.Copy(null, null);
        }

        private void zhantieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Document.TextArea.ClipboardHandler.Paste(null, null);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Document.TextArea.ClipboardHandler.Cut(null, null);
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Document.TextArea.ClipboardHandler.Delete(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool enabled = false;
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(DataFormats.UnicodeText))
            {
                string text = (string)dataObject.GetData(DataFormats.UnicodeText);
                if (text.Length > 0)
                {
                    enabled = true;
                }
            }
            this.zhantieToolStripMenuItem.Enabled = enabled;
        }

    }
}
