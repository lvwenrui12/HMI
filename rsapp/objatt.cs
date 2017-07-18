using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hmitype;

namespace rsapp
{
    public partial class objatt : UserControl
    {
        #region 控件
        private DataGridView dataGridView1;

        private ContextMenuStrip mustr;

        private ToolStripMenuItem ssssToolStripMenuItem;

        private ToolStripMenuItem ToolStripMenuItem_addshu;

        private TextBox textBox1;

        private ComboBox cmb_Temp;

        private ComboBox comboBox1;

        private ImageList imageList1;

        private DataGridViewTextBoxColumn name;

        private DataGridViewTextBoxColumn val;

        private DataGridViewTextBoxColumn lei;

        private DataGridViewTextBoxColumn zhushi;

        private DataGridViewTextBoxColumn isbangding;

        private DataGridViewTextBoxColumn isxiugai;

        private DataGridViewTextBoxColumn attid;

        private DataGridViewTextBoxColumn initval;

        private Myapp_inf Myapp;

        private mpage dpage;

        public List<mobj> objs = new List<mobj>();

        private List<matt> atts = new List<matt>();


        #endregion
     

        public event EventHandler attch;
     

        public event EventHandler changepage;
      

        public event EventHandler attchhuigun;
       

        public event EventHandler selectobjj;

        public event EventHandler selectobj;

       

        public objatt()
        {
            this.InitializeComponent();
        }

        private void objatt_Load(object sender, EventArgs e)
        {
            this.cmb_Temp.Visible = false;
        }

        public void Setapp(Myapp_inf app)
        {
            this.Myapp = app;
            if (this.Myapp == null)
            {
                this.Setpage(null);
                this.objs.Clear();
                this.Ref();
            }
        }

        public void Setpage(mpage p)
        {
            this.dpage = p;
            this.Refobjcombox();
        }

        private void Refobjcombox()
        {
            if (this.dpage == null || this.Myapp == null)
            {
                this.comboBox1.Items.Clear();
            }
            else
            {
                int i;
                for (i = 0; i < this.dpage.objs.Count; i++)
                {
                    if (i >= this.comboBox1.Items.Count)
                    {
                        this.comboBox1.Items.Add(this.dpage.objs[i].objname + "(" + datasize.Objzhushiencoding.GetString(this.dpage.objs[i].atts[0].zhushi).Split(new char[]
                        {
                            '-'
                        })[0] + ")");
                    }
                    else
                    {
                        this.comboBox1.Items[i] = this.dpage.objs[i].objname + "(" + datasize.Objzhushiencoding.GetString(this.dpage.objs[i].atts[0].zhushi).Split(new char[]
                        {
                            '-'
                        })[0] + ")";
                    }
                }
                while (i < this.comboBox1.Items.Count)
                {
                    this.comboBox1.Items.Remove(this.comboBox1.Items[i]);
                }
                this.comboBox1.Items.Add("");
            }
        }

        public void Ref()
        {
            try
            {
                this.cmb_Temp.Tag = null;
                this.cmb_Temp.Visible = false;
                this.Clear();
                this.Refobjcombox();
                if (this.objs == null || this.objs.Count == 0 || this.Myapp == null || this.dpage == null)
                {
                    if (this.comboBox1.Items.Count > 0)
                    {
                        this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
                    }
                }
                else
                {
                    if (this.objs.Count == 1)
                    {
                        this.comboBox1.SelectedIndex = this.objs[0].objid;
                    }
                    else if (this.objs.Count > 1)
                    {
                        this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
                    }
                    this.getgatts();
                    byte b = 255;
                    for (int i = 0; i < this.atts.Count; i++)
                    {
                        if (this.atts[i].att.attlei == attshulei.Font.typevalue)
                        {
                            if (this.atts[i].zhi != null && this.atts[i].zhi.Length > 0)
                            {
                                b = this.atts[i].zhi[0];
                            }
                            break;
                        }
                    }
                    for (int i = 0; i < this.atts.Count; i++)
                    {
                        this.dataGridView1.Rows.Add();
                        int index = this.dataGridView1.Rows.Count - 1;
                        DataGridViewCellStyle dataGridViewCellStyle;
                        if (this.atts[i].zhi.Length == 0 || this.atts[i].att.merrylenth == 0)
                        {
                            this.dataGridView1.Rows[index].Cells["val"].Value = "";
                        }
                        else if (this.atts[i].att.attlei != attshulei.Sstr.typevalue)
                        {
                            if (this.atts[i].att.merrylenth == 1)
                            {
                                if (this.atts[i].att.attlei == attshulei.Select.typevalue)
                                {
                                    dataGridViewCellStyle = new DataGridViewCellStyle();
                                    dataGridViewCellStyle.BackColor = Color.FromArgb(234, 234, 234);
                                    dataGridViewCellStyle.ForeColor = Color.Black;
                                    this.dataGridView1.Rows[index].Cells["val"].Value = "";
                                    string[] array = datasize.Objzhushiencoding.GetString(this.atts[i].zhushi).Split(new char[]
                                    {
                                        '~'
                                    });
                                    array = array[0].Split(new char[]
                                    {
                                        ':'
                                    });
                                    if (this.atts[i].zhi.Length > 0 && array.Length > 1)
                                    {
                                        array = array[1].Split(new char[]
                                        {
                                            ';'
                                        });
                                        if (this.atts[i].zhi[0].ToString().Getint() < array.Length)
                                        {
                                            array = array[this.atts[i].zhi[0].ToString().Getint()].Split(new char[]
                                            {
                                                '-'
                                            });
                                            if (array.Length == 2)
                                            {
                                                this.dataGridView1.Rows[index].Cells["val"].Value = array[1];
                                            }
                                        }
                                    }
                                    this.dataGridView1.Rows[index].DefaultCellStyle = dataGridViewCellStyle;
                                }
                                else if (this.atts[i].att.attlei == attshulei.key.typevalue)
                                {
                                    keyboardlisttype keyboardlisttype = this.Myapp.getkeyboardlisttype((byte)this.atts[i].zhi.BytesTostruct(0.GetType()));
                                    if (keyboardlisttype.id != 255)
                                    {
                                        this.dataGridView1.Rows[index].Cells["val"].Value = keyboardlisttype.showname + "\\" + keyboardlisttype.pagename;
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[index].Cells["val"].Value = keyboardlisttype.showname;
                                    }
                                }
                                else
                                {
                                    this.dataGridView1.Rows[index].Cells["val"].Value = this.atts[i].zhi.getbytestoint((int)this.atts[i].att.merrylenth, this.atts[i].att.attlei).ToString();
                                }
                            }
                            else if (this.atts[i].att.merrylenth == 2)
                            {
                                if (this.atts[i].att.attlei == attshulei.Color.typevalue)
                                {
                                    if ((ushort)this.atts[i].zhi.BytesTostruct(0.GetType()) == 13579)
                                    {
                                        this.dataGridView1.Rows[index].Cells["val"].Value = "";
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[index].Cells["val"].Value = this.atts[i].zhi.BytesTostruct(0.GetType()).ToString();
                                    }
                                }
                                else if (this.atts[i].att.attlei == attshulei.Picid.typevalue)
                                {
                                    if ((ushort)this.atts[i].zhi.BytesTostruct(0.GetType()) == 65535)
                                    {
                                        this.dataGridView1.Rows[index].Cells["val"].Value = "";
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[index].Cells["val"].Value = this.atts[i].zhi.BytesTostruct(0.GetType()).ToString();
                                    }
                                }
                                else
                                {
                                    this.dataGridView1.Rows[index].Cells["val"].Value = this.atts[i].zhi.getbytestoint((int)this.atts[i].att.merrylenth, this.atts[i].att.attlei).ToString();
                                }
                            }
                            else if (this.atts[i].att.merrylenth == 4)
                            {
                                this.dataGridView1.Rows[index].Cells["val"].Value = this.atts[i].zhi.getbytestoint((int)this.atts[i].att.merrylenth, this.atts[i].att.attlei).ToString();
                            }
                        }
                        else if (b < 255 && (int)b < this.Myapp.zimos.Count)
                        {
                            this.dataGridView1.Rows[index].Cells["val"].Value = this.atts[i].zhi.Getstring(Encoding.GetEncoding(this.Myapp.zimos[(int)b].encode.GetencodeName()));
                        }
                        else
                        {
                            this.dataGridView1.Rows[index].Cells["val"].Value = this.atts[i].zhi.Getstring(datasize.Myencoding);
                        }
                        this.dataGridView1.Rows[index].Cells["initval"].Value = this.dataGridView1.Rows[index].Cells["val"].Value;
                        this.dataGridView1.Rows[index].Cells["name"].Value = this.atts[i].name.Getstring(datasize.Myencoding);
                        this.dataGridView1.Rows[index].Cells["type"].Value = this.atts[i].att.attlei.ToString();
                        this.dataGridView1.Rows[index].Cells["zhushi"].Value = datasize.Objzhushiencoding.GetString(this.atts[i].zhushi).Split(new char[]
                        {
                            '~'
                        })[0];
                        this.dataGridView1.Rows[index].Cells["isbangding"].Value = this.atts[i].att.isbangding.ToString();
                        this.dataGridView1.Rows[index].Cells["isxiugai"].Value = this.atts[i].att.isbangding.ToString();
                        this.dataGridView1.Rows[index].Cells["attid"].Value = i.ToString();
                        if (this.dataGridView1.Rows[index].Cells["name"].Value.ToString() == "id" || this.atts[i].att.attlei == attshulei.Picid.typevalue || this.atts[i].att.attlei == attshulei.Color.typevalue || this.atts[i].att.attlei == attshulei.Select.typevalue || this.atts[i].att.attlei == attshulei.key.typevalue || this.atts[i].att.attlei == attshulei.Type.typevalue)
                        {
                            this.dataGridView1.Rows[index].Cells["val"].ReadOnly = true;
                        }
                        else
                        {
                            this.dataGridView1.Rows[index].Cells["val"].ReadOnly = false;
                        }
                        dataGridViewCellStyle = new DataGridViewCellStyle();
                        if (this.atts[i].att.isxiugai == 1)
                        {
                            dataGridViewCellStyle.BackColor = Color.White;
                            dataGridViewCellStyle.ForeColor = Color.Green;
                            this.dataGridView1.Rows[index].DefaultCellStyle = dataGridViewCellStyle;
                        }
                        if (this.atts[i].att.chonghui == 1 && this.atts[i].att.isxiugai == 1)
                        {
                        }
                        if (this.dataGridView1.Rows.Count > 0)
                        {
                            this.dataGridView1.Rows[0].Cells[0].Selected = false;
                        }
                    }
                    this.dataGridView1.Focus();
                    this.textBox1.Text = "点击属性显示相应注释".Language();
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show("加载属性出现错误:".Language() + ex.Message);
            }
        }

        private void getgatts()
        {
            this.atts.Clear();
            if (this.objs != null && this.objs.Count != 0)
            {
                this.atts = this.objs[0].GetAllatts();
                if (this.objs[0].myobj.objType != objtype.page)
                {
                    matt matt = new matt();
                    matt.name = "objname".GetbytesssASCII();
                    matt.att.attlei = attshulei.Sstr.typevalue;
                    matt.att.merrylenth = 14;
                    matt.att.isxiugai = 0;
                    matt.zhushi = datasize.Objzhushiencoding.GetBytes("控件名称".Language());
                    matt.zhi = this.objs[0].objname.GetbytesssASCII();
                    if (this.atts.Count > 1)
                    {
                        this.atts.Insert(1, matt);
                    }
                    else
                    {
                        this.atts.Add(matt);
                    }
                }
                for (int i = 0; i < this.atts.Count; i++)
                {
                    for (int j = 1; j < this.objs.Count; j++)
                    {
                        if (!this.objs[j].biduiatt(this.atts[i].name.Getstring(datasize.Myencoding), this.atts[i].att.attlei) || !this.objs[j].checkatt(this.atts[i]))
                        {
                            this.atts.Remove(this.atts[i]);
                            i--;
                            break;
                        }
                        if (this.atts[i].name[0] == 119)
                        {
                            byte[] expr_1DE_cp_0 = this.atts[i].name;
                            int expr_1DE_cp_1 = 0;
                            expr_1DE_cp_0[expr_1DE_cp_1] = expr_1DE_cp_0[expr_1DE_cp_1];
                        }
                        byte[] b = this.objs[j].GetattVal_byte(this.atts[i].name.Getstring(datasize.Myencoding));
                        if (!Kuozhan.makebytes(b, this.atts[i].zhi))
                        {
                            this.atts[i].zhi = new byte[0];
                        }
                    }
                }
            }
        }

        private void Clear()
        {
            this.dataGridView1.Rows.Clear();
            this.textBox1.Text = "";
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.objs.Count > 0)
            {
                matt att = this.atts[this.dataGridView1.Rows[e.RowIndex].Cells["attid"].Value.ToString().Getint()];
                string text = (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value == null) ? "" : this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString();
                if (this.changatt(att, text))
                {
                    text = this.objs[0].GetattVal_string(this.dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString());
                    this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value = text;
                }
                this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value = this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value;
                if (this.dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString() == "objname")
                {
                    this.Refobjcombox();
                }
            }
        }

        private bool changatt(matt att, string newstr)
        {
            bool flag = false;
            string attname = att.name.Getstring(datasize.Myencoding);
            bool result;
            try
            {
                string a = att.name.Getstring(datasize.Myencoding);
                if (a == "key" && newstr != "255")
                {
                    foreach (mobj current in this.objs)
                    {
                        matt matt = current.Getatt("vscope");
                        if (matt != null)
                        {
                            if (matt.zhi[0] != 1)
                            {
                                MessageOpen.Show("请先将选中控件的vscope属性设置为全局才可以绑定键盘".Language());
                                result = false;
                                return result;
                            }
                        }
                    }
                }
                else if (a == "vscope" && newstr == "0")
                {
                    foreach (mobj current in this.objs)
                    {
                        matt matt = current.Getatt("key");
                        if (matt != null)
                        {
                            if (matt.zhi[0] != 255)
                            {
                                MessageOpen.Show("绑定键盘的控件vscope属性不可以设置为私有".Language());
                                result = false;
                                return result;
                            }
                        }
                    }
                }
                this.dpage.starback();
                foreach (mobj current in this.objs)
                {
                    if (!this.dpage.changobjattch(current.objid, attname, newstr))
                    {
                        if (this.dpage.dcomp0.objset.Count > 0)
                        {
                            this.dpage.endback();
                            this.attchhuigun(null, null);
                        }
                        flag = false;
                        break;
                    }
                    flag = true;
                }
                this.dpage.endback();
                if (flag)
                {
                    this.attch(null, null);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                this.attchhuigun(null, null);
                MessageOpen.Show(ex.Message);
                result = false;
            }
            return result;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Rows.Count != 0)
            {
                if (e.RowIndex >= 0)
                {
                    if (this.dataGridView1.Columns[e.ColumnIndex].Name == "val")
                    {
                        if (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Picid.typevalue.ToString())
                        {
                            Formchuantiinf fc_ = default(Formchuantiinf);
                            fc_.str = new string[2];
                            string[] array = ((this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value == null) ? "" : this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString()).Split(new char[]
                            {
                                '-'
                            });
                            if (array.Length == 2)
                            {
                                fc_.str[1] = array[1];
                            }
                            Form form = new picselect(this.Myapp, fc_);
                            form.ShowDialog();
                            if (form.DialogResult == DialogResult.OK)
                            {
                                matt att = this.atts[this.dataGridView1.Rows[e.RowIndex].Cells["attid"].Value.ToString().Getint()];
                                string text = fc_.str[0];
                                if (!this.changatt(att, text))
                                {
                                    this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value = this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value;
                                }
                                else
                                {
                                    this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value = text;
                                    this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Rows.Count != 0)
            {
                if (e.RowIndex >= 0)
                {
                    this.cmb_Temp.DrawMode = DrawMode.OwnerDrawVariable;
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Select.typevalue.ToString() && e.ColumnIndex == 1)
                    {
                        Rectangle cellDisplayRectangle = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        string[] array = this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value.ToString().Split(new char[]
                        {
                            ':'
                        });
                        this.cmb_Temp.Items.Clear();
                        if (array.Length > 1)
                        {
                            array = array[1].Split(new char[]
                            {
                                ';'
                            });
                            string[] array2 = array;
                            for (int i = 0; i < array2.Length; i++)
                            {
                                string text = array2[i];
                                string[] array3 = text.Split(new char[]
                                {
                                    '-'
                                });
                                if (array3.Length == 2)
                                {
                                    this.cmb_Temp.Items.Add(array3[1]);
                                }
                            }
                        }
                        this.cmb_Temp.Left = cellDisplayRectangle.Left + 2;
                        this.cmb_Temp.Top = cellDisplayRectangle.Top + this.dataGridView1.Top;
                        this.cmb_Temp.Width = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Width - 1;
                        this.cmb_Temp.Height = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Height - 1;
                        for (int j = 0; j < this.cmb_Temp.Items.Count; j++)
                        {
                            if (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString() == this.cmb_Temp.Items[j].ToString())
                            {
                                this.cmb_Temp.SelectedIndex = j;
                                break;
                            }
                        }
                        selectcomboxlei selectcomboxlei = new selectcomboxlei
                        {
                            rowindex = e.RowIndex,
                            lei = attshulei.Select.typevalue
                        };
                        this.cmb_Temp.Tag = selectcomboxlei;
                        this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
                        this.cmb_Temp.Visible = true;
                        this.cmb_Temp.DroppedDown = true;
                        this.cmb_Temp.Focus();
                    }
                    else if (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.key.typevalue.ToString() && e.ColumnIndex == 1)
                    {
                        Rectangle cellDisplayRectangle = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        this.cmb_Temp.Items.Clear();
                        for (int j = 0; j < this.Myapp.Keyboardlist.Count; j++)
                        {
                            this.cmb_Temp.Items.Add(this.Myapp.Keyboardlist[j].showname + "\\" + this.Myapp.Keyboardlist[j].pagename);
                        }
                        this.cmb_Temp.Items.Add("无".Language());
                        this.cmb_Temp.Left = cellDisplayRectangle.Left + 2;
                        this.cmb_Temp.Top = cellDisplayRectangle.Top + this.dataGridView1.Top;
                        this.cmb_Temp.Width = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Width - 1;
                        this.cmb_Temp.Height = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Height - 1;
                        for (int j = 0; j < this.cmb_Temp.Items.Count; j++)
                        {
                            if (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString() == this.cmb_Temp.Items[j].ToString())
                            {
                                this.cmb_Temp.SelectedIndex = j;
                                break;
                            }
                        }
                        selectcomboxlei selectcomboxlei = new selectcomboxlei
                        {
                            rowindex = e.RowIndex,
                            lei = attshulei.key.typevalue
                        };
                        this.cmb_Temp.Tag = selectcomboxlei;
                        this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
                        this.cmb_Temp.Visible = true;
                        this.cmb_Temp.DroppedDown = true;
                        this.cmb_Temp.Focus();
                    }
                    else if (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Color.typevalue.ToString() && e.ColumnIndex == 1)
                    {
                        Rectangle cellDisplayRectangle = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        this.cmb_Temp.Items.Clear();
                        this.cmb_Temp.Items.Add("more colors...");
                        if (datasize.historycolors != "")
                        {
                            string[] array = datasize.historycolors.Split(new char[]
                            {
                                '-'
                            });
                            string[] array2 = array;
                            for (int i = 0; i < array2.Length; i++)
                            {
                                string text = array2[i];
                                this.cmb_Temp.Items.Add(text);
                            }
                        }
                        this.cmb_Temp.Left = cellDisplayRectangle.Left + 24;
                        this.cmb_Temp.Top = cellDisplayRectangle.Top + this.dataGridView1.Top;
                        this.cmb_Temp.Width = cellDisplayRectangle.Width - 24;
                        this.cmb_Temp.Height = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Height - 1;
                        selectcomboxlei selectcomboxlei = new selectcomboxlei
                        {
                            rowindex = e.RowIndex,
                            lei = attshulei.Color.typevalue
                        };
                        this.cmb_Temp.Tag = selectcomboxlei;
                        this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDown;
                        this.cmb_Temp.Visible = true;
                        this.cmb_Temp.DroppedDown = true;
                        this.cmb_Temp.Text = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString();
                        this.cmb_Temp.Focus();
                    }
                    else
                    {
                        this.cmb_Temp.Visible = false;
                    }
                    if (!this.dataGridView1.Rows[e.RowIndex].Cells["val"].ReadOnly)
                    {
                        if (e.ColumnIndex == 1)
                        {
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells["val"];
                            this.dataGridView1.BeginEdit(true);
                        }
                    }
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value != null)
                    {
                        if (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Type.typevalue.ToString())
                        {
                            this.textBox1.Text = "控件类型：".Language() + this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value.ToString().Split(new char[]
                            {
                                '-'
                            })[0];
                        }
                        else
                        {
                            this.textBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value.ToString();
                        }
                    }
                }
            }
        }

        private void cmb_Temp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmb_Temp.SelectedItem != null)
            {
                this.cmb_Temp.Text = this.cmb_Temp.SelectedItem.ToString();
            }
            this.cmb_Temp_Leave(null, null);
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.cmb_Temp.Visible)
            {
                if (this.cmb_Temp.SelectedItem != null)
                {
                    this.cmb_Temp.Text = this.cmb_Temp.SelectedItem.ToString();
                }
                this.cmb_Temp.DroppedDown = false;
                this.cmb_Temp_Leave(null, null);
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                int num;
                if (this.dataGridView1.DisplayedRowCount(false) < this.dataGridView1.Rows.Count)
                {
                    num = this.dataGridView1.Width - this.dataGridView1.Columns["name"].Width - 20;
                }
                else
                {
                    num = (this.dataGridView1.Columns["val"].Width = this.dataGridView1.Width - this.dataGridView1.Columns["name"].Width - 4);
                }
                if (num != this.dataGridView1.Columns["val"].Width)
                {
                    this.dataGridView1.Columns["val"].Width = num;
                }
            }
            catch
            {
            }
        }

        private void objatt_Resize(object sender, EventArgs e)
        {
            try
            {
                this.comboBox1.Top = 1;
                this.comboBox1.Left = 2;
                this.comboBox1.Width = base.Width - 4;
                this.dataGridView1.Left = 2;
                this.dataGridView1.Top = this.comboBox1.Height + 3;
                this.dataGridView1.Width = base.Width - 4;
                this.dataGridView1.Height = base.Height - this.dataGridView1.Top - this.textBox1.Height - 7;
                this.textBox1.Left = 2;
                this.textBox1.Top = base.Height - this.textBox1.Height - 4;
                this.textBox1.Width = base.Width - 4;
            }
            catch
            {
            }
        }

        private void objatt_Paint(object sender, PaintEventArgs e)
        {
            this.DrawThisLine(Color.FromArgb(51, 153, 255), 1);
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.selectobj(this.comboBox1.SelectedIndex, null);
        }

        private void cmb_Temp_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (this.cmb_Temp.DrawMode == DrawMode.OwnerDrawVariable)
            {
                if (this.cmb_Temp.Tag != null)
                {
                    if (e.Index >= 0)
                    {
                        byte b = ((selectcomboxlei)this.cmb_Temp.Tag).lei;
                        e.DrawBackground();
                        e.DrawFocusRectangle();
                        if (b == attshulei.Color.typevalue)
                        {
                            if (this.cmb_Temp.Items[e.Index].ToString().IsdataS32(attshulei.UU16.typevalue))
                            {
                                Color color = ((ushort)this.cmb_Temp.Items[e.Index].ToString().Getint()).Get24color();
                                e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height - 2);
                            }
                            else
                            {
                                e.Graphics.DrawString(this.cmb_Temp.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(this.cmb_Temp.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
                        }
                    }
                }
            }
        }

        private void cmb_Temp_EditEnd()
        {
            try
            {
                bool flag = true;
                string text = "";
                string text2 = this.cmb_Temp.Text;
                if (this.cmb_Temp.Tag != null)
                {
                    selectcomboxlei selectcomboxlei = (selectcomboxlei)this.cmb_Temp.Tag;
                    this.cmb_Temp.Tag = null;
                    this.dataGridView1.Focus();
                    if (selectcomboxlei.rowindex < this.dataGridView1.Rows.Count)
                    {
                        if (selectcomboxlei.lei == attshulei.Color.typevalue)
                        {
                            if (text2 == "more colors...")
                            {
                                ColorDialog colorDialog = new ColorDialog();
                                colorDialog.CustomColors = datasize.mycolors;
                                colorDialog.FullOpen = true;
                                DialogResult dialogResult = colorDialog.ShowDialog();
                                Kuozhan.Putcucolor(colorDialog.CustomColors);
                                if (dialogResult == DialogResult.OK)
                                {
                                    text = colorDialog.Color.Get16Color().ToString();
                                }
                                else
                                {
                                    flag = false;
                                }
                            }
                            else
                            {
                                text = text2;
                            }
                            if (flag && this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value.ToString() != text)
                            {
                                matt att = this.atts[this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["attid"].Value.ToString().Getint()];
                                if (!this.changatt(att, text))
                                {
                                    this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value = this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["initval"].Value;
                                    return;
                                }
                                this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value = text;
                                this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["initval"].Value = this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value;
                                Kuozhan.addhistorycolor(text);
                            }
                        }
                        else if (selectcomboxlei.lei == attshulei.Select.typevalue)
                        {
                            text = this.cmb_Temp.SelectedIndex.ToString();
                            if (this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value.ToString() != text2)
                            {
                                matt att = this.atts[this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["attid"].Value.ToString().Getint()];
                                if (!this.changatt(att, text))
                                {
                                    this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value = this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["initval"].Value;
                                }
                                else
                                {
                                    this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value = text2;
                                    this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["initval"].Value = this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value;
                                }
                                this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Selected = false;
                                this.Ref();
                            }
                        }
                        else if (selectcomboxlei.lei == attshulei.key.typevalue)
                        {
                            bool flag2 = true;
                            string[] array = this.cmb_Temp.Text.Split(new char[]
                            {
                                '\\'
                            });
                            keyboardlisttype key;
                            if (array.Length == 2)
                            {
                                key = this.Myapp.getkeyboardlisttype(array[1].Trim());
                            }
                            else
                            {
                                key = this.Myapp.getkeyboardlisttype(255);
                            }
                            text = key.id.ToString();
                            if (this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value.ToString() != text2)
                            {
                                matt att = this.atts[this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["attid"].Value.ToString().Getint()];
                                if (!this.changatt(att, text))
                                {
                                    this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value = this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value.ToString();
                                    flag2 = false;
                                }
                                else
                                {
                                    if (text != "255")
                                    {
                                        this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value = text2;
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value = key.showname;
                                    }
                                    this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["initval"].Value = this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Value;
                                }
                                this.dataGridView1.Rows[selectcomboxlei.rowindex].Cells["val"].Selected = false;
                                if (flag2 && key.id != 255 && this.Myapp.findpagename(key.pagename, 65535) == -1)
                                {
                                    if (this.Myapp.Addkeyboard(key, 65535) != -1)
                                    {
                                        if (this.changepage != null)
                                        {
                                            this.changepage(null, null);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                this.cmb_Temp.Visible = false;
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void cmb_Temp_Leave(object sender, EventArgs e)
        {
            this.cmb_Temp_EditEnd();
            this.cmb_Temp.Visible = false;
        }

        private void cmb_Temp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cmb_Temp_Leave(null, null);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "val" && this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Color.typevalue.ToString())
                {
                    e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                    e.Graphics.DrawRectangle(new Pen(this.dataGridView1.GridColor), e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width, e.CellBounds.Height);
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString() != "")
                    {
                        Color color = ((ushort)this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString().Getint()).Get24color();
                        e.Graphics.FillRectangle(new SolidBrush(color), e.CellBounds.X + 2, e.CellBounds.Y + (e.CellBounds.Height - 18) / 2, 18, 18);
                        e.Graphics.DrawRectangle(new Pen(Color.Black), e.CellBounds.X + 2, e.CellBounds.Y + (e.CellBounds.Height - 18) / 2, 18, 18);
                        e.Graphics.DrawString(this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString(), e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), (float)(e.CellBounds.X + 21), (float)(e.CellBounds.Y + ((e.CellBounds.Height - e.CellStyle.Font.Height) / 2 + 1)), StringFormat.GenericDefault);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Black), e.CellBounds.X + 2, e.CellBounds.Y + (e.CellBounds.Height - 18) / 2, 18, 18);
                        e.Graphics.DrawString("X", e.CellStyle.Font, new SolidBrush(Color.Red), (float)(e.CellBounds.X + 7), (float)(e.CellBounds.Y + ((e.CellBounds.Height - e.CellStyle.Font.Height) / 2 + 1)), StringFormat.GenericDefault);
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }
    }
}
