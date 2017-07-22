using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using hmitype;
using rsapp;




namespace rsapp {
    public class objatt : UserControl
    {
        // Fields
        private DataGridViewTextBoxColumn attid;
        private List<matt> atts = new List<matt>();
        private ComboBox cmb_Temp;
        private ComboBox comboBox1;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private mpage dpage;
        private ImageList imageList1;
        private DataGridViewTextBoxColumn initval;
        private DataGridViewTextBoxColumn isbangding;
        private DataGridViewTextBoxColumn isxiugai;
        private DataGridViewTextBoxColumn lei;
        private ContextMenuStrip mustr;
        private Myapp_inf Myapp;
        private DataGridViewTextBoxColumn name;
        public List<mobj> objs = new List<mobj>();
        private ToolStripMenuItem ssssToolStripMenuItem;
        private TextBox textBox1;
        private ToolStripMenuItem ToolStripMenuItem_addshu;
        private DataGridViewTextBoxColumn val;
        private DataGridViewTextBoxColumn zhushi;

        // Events
        public event EventHandler attch;

        public event EventHandler attchhuigun;

        public event EventHandler changepage;

        public event EventHandler selectobj;

        // Methods
        public objatt()
        {
            this.InitializeComponent();
        }

        private bool changatt(matt att, string newstr)
        {
            bool flag = false;
            string attname = att.name.Getstring(datasize.Myencoding);
            try
            {
                matt matt;
                string str2 = att.name.Getstring(datasize.Myencoding);
                if ((str2 == "key") && (newstr != "255"))
                {
                    foreach (mobj mobj in this.objs)
                    {
                        matt = mobj.Getatt("vscope");
                        if ((matt != null) && (matt.zhi[0] != 1))
                        {
                            MessageOpen.Show("请先将选中控件的vscope属性设置为全局才可以绑定键盘".Language());
                            return false;
                        }
                    }
                }
                else if ((str2 == "vscope") && (newstr == "0"))
                {
                    foreach (mobj mobj in this.objs)
                    {
                        matt = mobj.Getatt("key");
                        if ((matt != null) && (matt.zhi[0] != 0xff))
                        {
                            MessageOpen.Show("绑定键盘的控件vscope属性不可以设置为私有".Language());
                            return false;
                        }
                    }
                }
                this.dpage.starback();
                foreach (mobj mobj in this.objs)
                {
                    if (!this.dpage.changobjattch(mobj.objid, attname, newstr))
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
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                this.attchhuigun(null, null);
                MessageOpen.Show(exception.Message);
                return false;
            }
        }

        private void Clear()
        {
            this.dataGridView1.Rows.Clear();
            this.textBox1.Text = "";
        }

        private void cmb_Temp_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (((this.cmb_Temp.DrawMode == DrawMode.OwnerDrawVariable) && (this.cmb_Temp.Tag != null)) && (e.Index >= 0))
            {
                byte lei = ((selectcomboxlei)this.cmb_Temp.Tag).lei;
                e.DrawBackground();
                e.DrawFocusRectangle();
                if (lei == attshulei.Color.typevalue)
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

        private void cmb_Temp_EditEnd()
        {
            try
            {
                bool flag = true;
                string newstr = "";
                string text = this.cmb_Temp.Text;
                if (this.cmb_Temp.Tag != null)
                {
                    selectcomboxlei tag = (selectcomboxlei)this.cmb_Temp.Tag;
                    this.cmb_Temp.Tag = null;
                    this.dataGridView1.Focus();
                    if (tag.rowindex < this.dataGridView1.Rows.Count)
                    {
                        matt matt;
                        if (tag.lei == attshulei.Color.typevalue)
                        {
                            if (text == "more colors...")
                            {
                                ColorDialog dialog = new ColorDialog
                                {
                                    CustomColors = datasize.mycolors,
                                    FullOpen = true
                                };
                                DialogResult result = dialog.ShowDialog();
                                Kuozhan.Putcucolor(dialog.CustomColors);
                                if (result == DialogResult.OK)
                                {
                                    newstr = dialog.Color.Get16Color().ToString();
                                }
                                else
                                {
                                    flag = false;
                                }
                            }
                            else
                            {
                                newstr = text;
                            }
                            if (flag && (this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value.ToString() != newstr))
                            {
                                matt = this.atts[this.dataGridView1.Rows[tag.rowindex].Cells["attid"].Value.ToString().Getint()];
                                if (!this.changatt(matt, newstr))
                                {
                                    this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value = this.dataGridView1.Rows[tag.rowindex].Cells["initval"].Value;
                                    return;
                                }
                                this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value = newstr;
                                this.dataGridView1.Rows[tag.rowindex].Cells["initval"].Value = this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value;
                                Kuozhan.addhistorycolor(newstr);
                            }
                        }
                        else if (tag.lei == attshulei.Select.typevalue)
                        {
                            newstr = this.cmb_Temp.SelectedIndex.ToString();
                            if (this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value.ToString() != text)
                            {
                                matt = this.atts[this.dataGridView1.Rows[tag.rowindex].Cells["attid"].Value.ToString().Getint()];
                                if (!this.changatt(matt, newstr))
                                {
                                    this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value = this.dataGridView1.Rows[tag.rowindex].Cells["initval"].Value;
                                }
                                else
                                {
                                    this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value = text;
                                    this.dataGridView1.Rows[tag.rowindex].Cells["initval"].Value = this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value;
                                }
                                this.dataGridView1.Rows[tag.rowindex].Cells["val"].Selected = false;
                                this.Ref();
                            }
                        }
                        else if (tag.lei == attshulei.key.typevalue)
                        {
                            keyboardlisttype keyboardlisttype;
                            bool flag2 = true;
                            string[] strArray = this.cmb_Temp.Text.Split(new char[] { '\\' });
                            if (strArray.Length == 2)
                            {
                                keyboardlisttype = this.Myapp.getkeyboardlisttype(strArray[1].Trim());
                            }
                            else
                            {
                                keyboardlisttype = this.Myapp.getkeyboardlisttype((byte)0xff);
                            }
                            newstr = keyboardlisttype.id.ToString();
                            if (this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value.ToString() != text)
                            {
                                matt = this.atts[this.dataGridView1.Rows[tag.rowindex].Cells["attid"].Value.ToString().Getint()];
                                if (!this.changatt(matt, newstr))
                                {
                                    this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value = this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value.ToString();
                                    flag2 = false;
                                }
                                else
                                {
                                    if (newstr != "255")
                                    {
                                        this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value = text;
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value = keyboardlisttype.showname;
                                    }
                                    this.dataGridView1.Rows[tag.rowindex].Cells["initval"].Value = this.dataGridView1.Rows[tag.rowindex].Cells["val"].Value;
                                }
                                this.dataGridView1.Rows[tag.rowindex].Cells["val"].Selected = false;
                                if ((((flag2 && (keyboardlisttype.id != 0xff)) && (this.Myapp.findpagename(keyboardlisttype.pagename, 0xffff) == -1)) && (this.Myapp.Addkeyboard(keyboardlisttype, 0xffff) != -1)) && (this.changepage != null))
                                {
                                    this.changepage(null, null);
                                }
                            }
                        }
                    }
                }
                this.cmb_Temp.Visible = false;
            }
            catch (Exception exception)
            {
                MessageOpen.Show(exception.Message);
            }
        }

        private void cmb_Temp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cmb_Temp_Leave(null, null);
            }
        }

        private void cmb_Temp_Leave(object sender, EventArgs e)
        {
            this.cmb_Temp_EditEnd();
            this.cmb_Temp.Visible = false;
        }

        private void cmb_Temp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmb_Temp.SelectedItem != null)
            {
                this.cmb_Temp.Text = this.cmb_Temp.SelectedItem.ToString();
            }
            this.cmb_Temp_Leave(null, null);
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.selectobj(this.comboBox1.SelectedIndex, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] strArray;
            Rectangle rectangle;
            int num;
            selectcomboxlei selectcomboxlei;
            if ((this.dataGridView1.Rows.Count == 0) || (e.RowIndex < 0))
            {
                return;
            }
            this.cmb_Temp.DrawMode = DrawMode.OwnerDrawVariable;
            if (!(this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Select.typevalue.ToString()) || (e.ColumnIndex != 1))
            {
                if (!(this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.key.typevalue.ToString()) || (e.ColumnIndex != 1))
                {
                    if ((this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Color.typevalue.ToString()) && (e.ColumnIndex == 1))
                    {
                        rectangle = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        this.cmb_Temp.Items.Clear();
                        this.cmb_Temp.Items.Add("more colors...");
                        if (datasize.historycolors != "")
                        {
                            strArray = datasize.historycolors.Split(new char[] { '-' });
                            foreach (string str in strArray)
                            {
                                this.cmb_Temp.Items.Add(str);
                            }
                        }
                        this.cmb_Temp.Left = rectangle.Left + 0x18;
                        this.cmb_Temp.Top = rectangle.Top + this.dataGridView1.Top;
                        this.cmb_Temp.Width = rectangle.Width - 0x18;
                        this.cmb_Temp.Height = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Height - 1;
                        selectcomboxlei = new selectcomboxlei
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
                    goto Label_0886;
                }
                rectangle = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                this.cmb_Temp.Items.Clear();
                for (num = 0; num < this.Myapp.Keyboardlist.Count; num++)
                {
                    this.cmb_Temp.Items.Add(this.Myapp.Keyboardlist[num].showname + @"\" + this.Myapp.Keyboardlist[num].pagename);
                }
                this.cmb_Temp.Items.Add("无".Language());
                this.cmb_Temp.Left = rectangle.Left + 2;
                this.cmb_Temp.Top = rectangle.Top + this.dataGridView1.Top;
                this.cmb_Temp.Width = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Width - 1;
                this.cmb_Temp.Height = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Height - 1;
                for (num = 0; num < this.cmb_Temp.Items.Count; num++)
                {
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString() == this.cmb_Temp.Items[num].ToString())
                    {
                        this.cmb_Temp.SelectedIndex = num;
                        break;
                    }
                }
            }
            else
            {
                rectangle = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                strArray = this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value.ToString().Split(new char[] { ':' });
                this.cmb_Temp.Items.Clear();
                if (strArray.Length > 1)
                {
                    strArray = strArray[1].Split(new char[] { ';' });
                    foreach (string str in strArray)
                    {
                        string[] strArray2 = str.Split(new char[] { '-' });
                        if (strArray2.Length == 2)
                        {
                            this.cmb_Temp.Items.Add(strArray2[1]);
                        }
                    }
                }
                this.cmb_Temp.Left = rectangle.Left + 2;
                this.cmb_Temp.Top = rectangle.Top + this.dataGridView1.Top;
                this.cmb_Temp.Width = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Width - 1;
                this.cmb_Temp.Height = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Size.Height - 1;
                for (num = 0; num < this.cmb_Temp.Items.Count; num++)
                {
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString() == this.cmb_Temp.Items[num].ToString())
                    {
                        this.cmb_Temp.SelectedIndex = num;
                        break;
                    }
                }
                selectcomboxlei = new selectcomboxlei
                {
                    rowindex = e.RowIndex,
                    lei = attshulei.Select.typevalue
                };
                this.cmb_Temp.Tag = selectcomboxlei;
                this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmb_Temp.Visible = true;
                this.cmb_Temp.DroppedDown = true;
                this.cmb_Temp.Focus();
                goto Label_0886;
            }
            selectcomboxlei = new selectcomboxlei
            {
                rowindex = e.RowIndex,
                lei = attshulei.key.typevalue
            };
            this.cmb_Temp.Tag = selectcomboxlei;
            this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmb_Temp.Visible = true;
            this.cmb_Temp.DroppedDown = true;
            this.cmb_Temp.Focus();
            Label_0886:
            if (!this.dataGridView1.Rows[e.RowIndex].Cells["val"].ReadOnly && (e.ColumnIndex == 1))
            {
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells["val"];
                this.dataGridView1.BeginEdit(true);
            }
            if (this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value != null)
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Type.typevalue.ToString())
                {
                    this.textBox1.Text = "控件类型：".Language() + this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value.ToString().Split(new char[] { '-' })[0];
                }
                else
                {
                    this.textBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells["zhushi"].Value.ToString();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((this.dataGridView1.Rows.Count != 0) && (e.RowIndex >= 0)) && ((this.dataGridView1.Columns[e.ColumnIndex].Name == "val") && (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Picid.typevalue.ToString())))
            {
                Formchuantiinf formchuantiinf = new Formchuantiinf
                {
                    str = new string[2]
                };
                string[] strArray = ((this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value == null) ? "" : this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString()).Split(new char[] { '-' });
                if (strArray.Length == 2)
                {
                    formchuantiinf.str[1] = strArray[1];
                }
                Form form = new picselect(this.Myapp, formchuantiinf);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    matt att = this.atts[this.dataGridView1.Rows[e.RowIndex].Cells["attid"].Value.ToString().Getint()];
                    string newstr = formchuantiinf.str[0];
                    if (!this.changatt(att, newstr))
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value = this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value;
                    }
                    else
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value = newstr;
                        this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value = this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value;
                    }
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string newstr = "";
            if (this.objs.Count > 0)
            {
                matt att = this.atts[this.dataGridView1.Rows[e.RowIndex].Cells["attid"].Value.ToString().Getint()];
                newstr = (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value == null) ? "" : this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString();
                if (this.changatt(att, newstr))
                {
                    newstr = this.objs[0].GetattVal_string(this.dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString());
                    this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value = newstr;
                }
                this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value = this.dataGridView1.Rows[e.RowIndex].Cells["initval"].Value;
                if (this.dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString() == "objname")
                {
                    this.Refobjcombox();
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if ((this.dataGridView1.Columns[e.ColumnIndex].Name == "val") && (this.dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString() == attshulei.Color.typevalue.ToString()))
                {
                    e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                    e.Graphics.DrawRectangle(new Pen(this.dataGridView1.GridColor), e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width, e.CellBounds.Height);
                    if (this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString() != "")
                    {
                        Color color = ((ushort)this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString().Getint()).Get24color();
                        e.Graphics.FillRectangle(new SolidBrush(color), e.CellBounds.X + 2, e.CellBounds.Y + ((e.CellBounds.Height - 0x12) / 2), 0x12, 0x12);
                        e.Graphics.DrawRectangle(new Pen(Color.Black), e.CellBounds.X + 2, e.CellBounds.Y + ((e.CellBounds.Height - 0x12) / 2), 0x12, 0x12);
                        e.Graphics.DrawString(this.dataGridView1.Rows[e.RowIndex].Cells["val"].Value.ToString(), e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), (float)(e.CellBounds.X + 0x15), (float)(e.CellBounds.Y + (((e.CellBounds.Height - e.CellStyle.Font.Height) / 2) + 1)), StringFormat.GenericDefault);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Black), e.CellBounds.X + 2, e.CellBounds.Y + ((e.CellBounds.Height - 0x12) / 2), 0x12, 0x12);
                        e.Graphics.DrawString("X", e.CellStyle.Font, new SolidBrush(Color.Red), (float)(e.CellBounds.X + 7), (float)(e.CellBounds.Y + (((e.CellBounds.Height - e.CellStyle.Font.Height) / 2) + 1)), StringFormat.GenericDefault);
                    }
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                MessageOpen.Show(exception.Message);
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                int num;
                if (this.dataGridView1.DisplayedRowCount(false) < this.dataGridView1.Rows.Count)
                {
                    num = (this.dataGridView1.Width - this.dataGridView1.Columns["name"].Width) - 20;
                }
                else
                {
                    num = this.dataGridView1.Columns["val"].Width = (this.dataGridView1.Width - this.dataGridView1.Columns["name"].Width) - 4;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void getgatts()
        {
            this.atts.Clear();
            if ((this.objs != null) && (this.objs.Count != 0))
            {
                this.atts = this.objs[0].GetAllatts();
                if (this.objs[0].myobj.objType != objtype.page)
                {
                    matt item = new matt
                    {
                        name = "objname".GetbytesssASCII()
                    };
                    item.att.attlei = attshulei.Sstr.typevalue;
                    item.att.merrylenth = 14;
                    item.att.isxiugai = 0;
                    item.zhushi = datasize.Objzhushiencoding.GetBytes("控件名称".Language());
                    item.zhi = this.objs[0].objname.GetbytesssASCII();
                    if (this.atts.Count > 1)
                    {
                        this.atts.Insert(1, item);
                    }
                    else
                    {
                        this.atts.Add(item);
                    }
                }
                for (int i = 0; i < this.atts.Count; i++)
                {
                    for (int j = 1; j < this.objs.Count; j++)
                    {
                        if (this.objs[j].biduiatt(this.atts[i].name.Getstring(datasize.Myencoding), this.atts[i].att.attlei) && this.objs[j].checkatt(this.atts[i]))
                        {
                            if (this.atts[i].name[0] == 0x77)
                            {
                                this.atts[i].name[0] = this.atts[i].name[0];
                            }
                            if (!Kuozhan.makebytes(this.objs[j].GetattVal_byte(this.atts[i].name.Getstring(datasize.Myencoding)), this.atts[i].zhi))
                            {
                                this.atts[i].zhi = new byte[0];
                            }
                        }
                        else
                        {
                            this.atts.Remove(this.atts[i]);
                            i--;
                            break;
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(objatt));
            this.dataGridView1 = new DataGridView();
            this.name = new DataGridViewTextBoxColumn();
            this.val = new DataGridViewTextBoxColumn();
            this.lei = new DataGridViewTextBoxColumn();
            this.zhushi = new DataGridViewTextBoxColumn();
            this.isbangding = new DataGridViewTextBoxColumn();
            this.isxiugai = new DataGridViewTextBoxColumn();
            this.attid = new DataGridViewTextBoxColumn();
            this.initval = new DataGridViewTextBoxColumn();
            this.mustr = new ContextMenuStrip(this.components);
            this.ToolStripMenuItem_addshu = new ToolStripMenuItem();
            this.ssssToolStripMenuItem = new ToolStripMenuItem();
            this.textBox1 = new TextBox();
            this.cmb_Temp = new ComboBox();
            this.comboBox1 = new ComboBox();
            this.imageList1 = new ImageList(this.components);
            ((ISupportInitialize)this.dataGridView1).BeginInit();
            this.mustr.SuspendLayout();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = Color.White;
            this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.name, this.val, this.lei, this.zhushi, this.isbangding, this.isxiugai, this.attid, this.initval });
            this.dataGridView1.GridColor = Color.Silver;
            this.dataGridView1.Location = new Point(3, 0x1a);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new Size(0xe0, 0xfb);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Scroll += new ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.Paint += new PaintEventHandler(this.dataGridView1_Paint);
            this.name.HeaderText = "属性";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 80;
            this.val.HeaderText = "值";
            this.val.Name = "val";
            this.val.ReadOnly = true;
            this.lei.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.lei.HeaderText = "type";
            this.lei.MinimumWidth = 2;
            this.lei.Name = "type";
            this.lei.ReadOnly = true;
            this.lei.Visible = false;
            this.lei.Width = 2;
            this.zhushi.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.zhushi.HeaderText = "zhushi";
            this.zhushi.Name = "zhushi";
            this.zhushi.Visible = false;
            this.zhushi.Width = 5;
            this.isbangding.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.isbangding.HeaderText = "isbangding";
            this.isbangding.Name = "isbangding";
            this.isbangding.Visible = false;
            this.isbangding.Width = 5;
            this.isxiugai.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.isxiugai.HeaderText = "isxiugai";
            this.isxiugai.Name = "isxiugai";
            this.isxiugai.Visible = false;
            this.isxiugai.Width = 5;
            this.attid.HeaderText = "attid";
            this.attid.Name = "attid";
            this.attid.Visible = false;
            this.initval.HeaderText = "initval";
            this.initval.Name = "initval";
            this.initval.Visible = false;
            this.mustr.Items.AddRange(new ToolStripItem[] { this.ToolStripMenuItem_addshu, this.ssssToolStripMenuItem });
            this.mustr.Name = "mustr";
            this.mustr.Size = new Size(0x7d, 0x30);
            this.ToolStripMenuItem_addshu.Name = "ToolStripMenuItem_addshu";
            this.ToolStripMenuItem_addshu.Size = new Size(0x7c, 0x16);
            this.ToolStripMenuItem_addshu.Text = "添加成员";
            this.ssssToolStripMenuItem.Name = "ssssToolStripMenuItem";
            this.ssssToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.ssssToolStripMenuItem.Text = "删除成员";
            this.textBox1.BackColor = Color.FromArgb(240, 240, 240);
            this.textBox1.BorderStyle = BorderStyle.FixedSingle;
            this.textBox1.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.textBox1.Location = new Point(3, 0x11b);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0xe0, 0x31);
            this.textBox1.TabIndex = 1;
            this.cmb_Temp.BackColor = Color.White;
            this.cmb_Temp.DropDownHeight = 250;
            this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmb_Temp.FlatStyle = FlatStyle.Flat;
            this.cmb_Temp.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cmb_Temp.FormattingEnabled = true;
            this.cmb_Temp.IntegralHeight = false;
            this.cmb_Temp.Location = new Point(0xe9, 0x1a);
            this.cmb_Temp.Name = "cmb_Temp";
            this.cmb_Temp.Size = new Size(0x26, 20);
            this.cmb_Temp.TabIndex = 3;
            this.cmb_Temp.Visible = false;
            this.cmb_Temp.DrawItem += new DrawItemEventHandler(this.cmb_Temp_DrawItem);
            this.cmb_Temp.SelectionChangeCommitted += new EventHandler(this.cmb_Temp_SelectionChangeCommitted);
            this.cmb_Temp.Leave += new EventHandler(this.cmb_Temp_Leave);
            this.cmb_Temp.KeyPress += new KeyPressEventHandler(this.cmb_Temp_KeyPress);
            this.comboBox1.BackColor = Color.White;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(3, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0xe4, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectionChangeCommitted += new EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "delete.ico");
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.Controls.Add(this.comboBox1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.cmb_Temp);
            base.Controls.Add(this.dataGridView1);
            base.Name = "objatt";
            base.Size = new Size(0x134, 0x185);
            base.Load += new EventHandler(this.objatt_Load);
            base.Paint += new PaintEventHandler(this.objatt_Paint);
            base.Resize += new EventHandler(this.objatt_Resize);
            ((ISupportInitialize)this.dataGridView1).EndInit();
            this.mustr.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void objatt_Load(object sender, EventArgs e)
        {
            this.cmb_Temp.Visible = false;
        }

        private void objatt_Paint(object sender, PaintEventArgs e)
        {
            this.DrawThisLine(Color.FromArgb(0x33, 0x99, 0xff), 1);
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
                this.dataGridView1.Height = ((base.Height - this.dataGridView1.Top) - this.textBox1.Height) - 7;
                this.textBox1.Left = 2;
                this.textBox1.Top = (base.Height - this.textBox1.Height) - 4;
                this.textBox1.Width = base.Width - 4;
            }
            catch
            {
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
                if ((((this.objs == null) || (this.objs.Count == 0)) || (this.Myapp == null)) || (this.dpage == null))
                {
                    if (this.comboBox1.Items.Count > 0)
                    {
                        this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
                    }
                }
                else
                {
                    int num3;
                    if (this.objs.Count == 1)
                    {
                        this.comboBox1.SelectedIndex = this.objs[0].objid;
                    }
                    else if (this.objs.Count > 1)
                    {
                        this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
                    }
                    this.getgatts();
                    byte num2 = 0xff;
                    for (num3 = 0; num3 < this.atts.Count; num3++)
                    {
                        if (this.atts[num3].att.attlei == attshulei.Font.typevalue)
                        {
                            if ((this.atts[num3].zhi != null) && (this.atts[num3].zhi.Length > 0))
                            {
                                num2 = this.atts[num3].zhi[0];
                            }
                            break;
                        }
                    }
                    for (num3 = 0; num3 < this.atts.Count; num3++)
                    {
                        DataGridViewCellStyle style;
                        this.dataGridView1.Rows.Add();
                        int num = this.dataGridView1.Rows.Count - 1;
                        if ((this.atts[num3].zhi.Length == 0) || (this.atts[num3].att.merrylenth == 0))
                        {
                            this.dataGridView1.Rows[num].Cells["val"].Value = "";
                        }
                        else if (this.atts[num3].att.attlei != attshulei.Sstr.typevalue)
                        {
                            if (this.atts[num3].att.merrylenth == 1)
                            {
                                if (this.atts[num3].att.attlei == attshulei.Select.typevalue)
                                {
                                    style = new DataGridViewCellStyle
                                    {
                                        BackColor = Color.FromArgb(0xea, 0xea, 0xea),
                                        ForeColor = Color.Black
                                    };
                                    this.dataGridView1.Rows[num].Cells["val"].Value = "";
                                    string[] strArray = datasize.Objzhushiencoding.GetString(this.atts[num3].zhushi).Split(new char[] { '~' })[0].Split(new char[] { ':' });
                                    if ((this.atts[num3].zhi.Length > 0) && (strArray.Length > 1))
                                    {
                                        strArray = strArray[1].Split(new char[] { ';' });
                                        if (this.atts[num3].zhi[0].ToString().Getint() < strArray.Length)
                                        {
                                            strArray = strArray[this.atts[num3].zhi[0].ToString().Getint()].Split(new char[] { '-' });
                                            if (strArray.Length == 2)
                                            {
                                                this.dataGridView1.Rows[num].Cells["val"].Value = strArray[1];
                                            }
                                        }
                                    }
                                    this.dataGridView1.Rows[num].DefaultCellStyle = style;
                                }
                                else if (this.atts[num3].att.attlei == attshulei.key.typevalue)
                                {
                                    keyboardlisttype keyboardlisttype = this.Myapp.getkeyboardlisttype((byte)this.atts[num3].zhi.BytesTostruct(((byte)0).GetType()));
                                    if (keyboardlisttype.id != 0xff)
                                    {
                                        this.dataGridView1.Rows[num].Cells["val"].Value = keyboardlisttype.showname + @"\" + keyboardlisttype.pagename;
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[num].Cells["val"].Value = keyboardlisttype.showname;
                                    }
                                }
                                else
                                {
                                    this.dataGridView1.Rows[num].Cells["val"].Value = this.atts[num3].zhi.getbytestoint(this.atts[num3].att.merrylenth, this.atts[num3].att.attlei).ToString();
                                }
                            }
                            else if (this.atts[num3].att.merrylenth == 2)
                            {
                                if (this.atts[num3].att.attlei == attshulei.Color.typevalue)
                                {
                                    if (((ushort)this.atts[num3].zhi.BytesTostruct(((ushort)0).GetType())) == 0x350b)
                                    {
                                        this.dataGridView1.Rows[num].Cells["val"].Value = "";
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[num].Cells["val"].Value = this.atts[num3].zhi.BytesTostruct(((ushort)0).GetType()).ToString();
                                    }
                                }
                                else if (this.atts[num3].att.attlei == attshulei.Picid.typevalue)
                                {
                                    if (((ushort)this.atts[num3].zhi.BytesTostruct(((ushort)0).GetType())) == 0xffff)
                                    {
                                        this.dataGridView1.Rows[num].Cells["val"].Value = "";
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows[num].Cells["val"].Value = this.atts[num3].zhi.BytesTostruct(((ushort)0).GetType()).ToString();
                                    }
                                }
                                else
                                {
                                    this.dataGridView1.Rows[num].Cells["val"].Value = this.atts[num3].zhi.getbytestoint(this.atts[num3].att.merrylenth, this.atts[num3].att.attlei).ToString();
                                }
                            }
                            else if (this.atts[num3].att.merrylenth == 4)
                            {
                                this.dataGridView1.Rows[num].Cells["val"].Value = this.atts[num3].zhi.getbytestoint(this.atts[num3].att.merrylenth, this.atts[num3].att.attlei).ToString();
                            }
                        }
                        else if ((num2 < 0xff) && (num2 < this.Myapp.zimos.Count))
                        {
                            this.dataGridView1.Rows[num].Cells["val"].Value = this.atts[num3].zhi.Getstring(Encoding.GetEncoding(this.Myapp.zimos[num2].encode.GetencodeName()));
                        }
                        else
                        {
                            this.dataGridView1.Rows[num].Cells["val"].Value = this.atts[num3].zhi.Getstring(datasize.Myencoding);
                        }
                        this.dataGridView1.Rows[num].Cells["initval"].Value = this.dataGridView1.Rows[num].Cells["val"].Value;
                        this.dataGridView1.Rows[num].Cells["name"].Value = this.atts[num3].name.Getstring(datasize.Myencoding);
                        this.dataGridView1.Rows[num].Cells["type"].Value = this.atts[num3].att.attlei.ToString();
                        this.dataGridView1.Rows[num].Cells["zhushi"].Value = datasize.Objzhushiencoding.GetString(this.atts[num3].zhushi).Split(new char[] { '~' })[0];
                        this.dataGridView1.Rows[num].Cells["isbangding"].Value = this.atts[num3].att.isbangding.ToString();
                        this.dataGridView1.Rows[num].Cells["isxiugai"].Value = this.atts[num3].att.isbangding.ToString();
                        this.dataGridView1.Rows[num].Cells["attid"].Value = num3.ToString();
                        if (((((this.dataGridView1.Rows[num].Cells["name"].Value.ToString() == "id") || (this.atts[num3].att.attlei == attshulei.Picid.typevalue)) || ((this.atts[num3].att.attlei == attshulei.Color.typevalue) || (this.atts[num3].att.attlei == attshulei.Select.typevalue))) || (this.atts[num3].att.attlei == attshulei.key.typevalue)) || (this.atts[num3].att.attlei == attshulei.Type.typevalue))
                        {
                            this.dataGridView1.Rows[num].Cells["val"].ReadOnly = true;
                        }
                        else
                        {
                            this.dataGridView1.Rows[num].Cells["val"].ReadOnly = false;
                        }
                        style = new DataGridViewCellStyle();
                        if (this.atts[num3].att.isxiugai == 1)
                        {
                            style.BackColor = Color.White;
                            style.ForeColor = Color.Green;
                            this.dataGridView1.Rows[num].DefaultCellStyle = style;
                        }
                        if ((this.atts[num3].att.chonghui == 1) && (this.atts[num3].att.isxiugai == 1))
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
            catch (Exception exception)
            {
                MessageOpen.Show("加载属性出现错误:".Language() + exception.Message);
            }
        }

        private void Refobjcombox()
        {
            if ((this.dpage == null) || (this.Myapp == null))
            {
                this.comboBox1.Items.Clear();
            }
            else
            {
                int num = 0;
                while (num < this.dpage.objs.Count)
                {
                    if (num >= this.comboBox1.Items.Count)
                    {
                        this.comboBox1.Items.Add(this.dpage.objs[num].objname + "(" + datasize.Objzhushiencoding.GetString(this.dpage.objs[num].atts[0].zhushi).Split(new char[] { '-' })[0] + ")");
                    }
                    else
                    {
                        this.comboBox1.Items[num] = this.dpage.objs[num].objname + "(" + datasize.Objzhushiencoding.GetString(this.dpage.objs[num].atts[0].zhushi).Split(new char[] { '-' })[0] + ")";
                    }
                    num++;
                }
                while (num < this.comboBox1.Items.Count)
                {
                    this.comboBox1.Items.Remove(this.comboBox1.Items[num]);
                }
                this.comboBox1.Items.Add("");
            }
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
    }
}


