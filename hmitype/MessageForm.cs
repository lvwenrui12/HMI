using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace hmitype
{
    public partial class MessageForm : Form
    {
        private Point mouse_pos = new Point(-1000, -1000);

        private Point form_pos = new Point(-1000, -1000);

        private MessageBoxButtons thismb = MessageBoxButtons.OK;

        public CheckBox checkbox1;

        public bool edit = false;

    

        private PanelEx panelEx1;

        private PanelEx panelEx2;

        private PanelEx p2;

        private PanelEx p0;

        private PanelEx p1;

        private LabelX labelX2;

        private LabelX labelX3;

        private Line line1;

        private RichTextBox messagetext;

        private Timer timer1;

        private LabelX label1;

        private LabelX labelceshi;

        private CheckBox checkBox1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem copyToolStripMenuItem;

        private ToolStripMenuItem zhantieToolStripMenuItem;



        public MessageForm()
        {
            InitializeComponent();
        }

        public MessageForm(string message)
        {
            this.FromOpen(message, datasize.softname, MessageBoxButtons.OK, Color.FromArgb(7, 104, 169));
        }

        private void FromOpen(string message, string title, MessageBoxButtons mb, Color color)
        {
            this.InitializeComponent();
            this.checkbox1 = this.checkBox1;
            this.thismb = mb;
            this.Language();
            Kuozhan.Setobj(this.contextMenuStrip1, datasize.Language);
            this.labelX3.Text = title;
            this.label1.Text = message;
            this.panelEx2.Style.BackColor1.Color = color;
            this.panelEx2.Style.BackColor2.Color = color;
            if (this.thismb == MessageBoxButtons.OK)
            {
                this.p0.Visible = false;
                this.p1.Visible = false;
                this.p2.Text = "确定".Language();
            }
            else if (this.thismb == MessageBoxButtons.YesNo)
            {
                this.p0.Visible = false;
                this.p1.Text = "是".Language();
                this.p2.Text = "否".Language();
            }
            else
            {
                this.p0.Visible = true;
                this.p0.Text = "是".Language();
                this.p1.Text = "否".Language();
                this.p2.Text = "取消".Language();
            }
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void panelEx4_MouseMove(object sender, MouseEventArgs e)
        {
            PanelEx panelEx = (PanelEx)sender;
            panelEx.Style.BackColor1.Color = Color.FromArgb(227, 239, 255);
            panelEx.Style.BackColor2.Color = Color.FromArgb(227, 239, 255);
        }

        private void panelEx5_MouseLeave(object sender, EventArgs e)
        {
            PanelEx panelEx = (PanelEx)sender;
            panelEx.Style.BackColor1.Color = Color.White;
            panelEx.Style.BackColor2.Color = Color.White;
        }

        private void labelX2_MouseMove(object sender, MouseEventArgs e)
        {
            this.labelX2.ForeColor = Color.White;
            this.labelX2.BackColor = Color.Orange;
        }

        private void labelX2_MouseLeave(object sender, EventArgs e)
        {
            this.labelX2.ForeColor = Color.Black;
            this.labelX2.BackColor = Color.White;
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void panelEx3_Click(object sender, EventArgs e)
        {
            if (this.thismb == MessageBoxButtons.OK)
            {
                base.DialogResult = DialogResult.OK;
            }
            else if (this.thismb == MessageBoxButtons.YesNo)
            {
                base.DialogResult = DialogResult.No;
            }
            else if (this.thismb == MessageBoxButtons.YesNoCancel)
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void panelEx5_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Yes;
        }

        private void panelEx4_Click(object sender, EventArgs e)
        {
            if (this.thismb == MessageBoxButtons.YesNo)
            {
                base.DialogResult = DialogResult.Yes;
            }
            else if (this.thismb == MessageBoxButtons.YesNoCancel)
            {
                base.DialogResult = DialogResult.No;
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            this.messagetext.Text = this.label1.Text;
            this.label1.Visible = false;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.label1.Location = this.messagetext.Location;
                this.label1.Size = this.messagetext.Size;
                this.labelceshi.Visible = true;
                this.labelceshi.Left = this.label1.Left;
                this.labelceshi.Text = this.label1.Text;
                if (this.labelceshi.Width > this.label1.Width)
                {
                    this.label1.TextAlignment = StringAlignment.Near;
                }
                else
                {
                    this.label1.TextAlignment = StringAlignment.Center;
                }
                this.labelceshi.Visible = false;
                if (this.edit)
                {
                    this.label1_DoubleClick(null, null);
                }
            }
            catch
            {
            }
        }

        private void messagetext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.label1.Visible)
            {
                if (e.KeyChar == '\u001b')
                {
                    base.DialogResult = DialogResult.Cancel;
                }
                else if (e.KeyChar == '\r')
                {
                    if (this.thismb == MessageBoxButtons.OK)
                    {
                        base.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        base.DialogResult = (base.DialogResult = DialogResult.Yes);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.messagetext.Focus();
        }

        private void labelX3_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_pos = Control.MousePosition;
            this.form_pos = base.Location;
        }

        private void panelEx2_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.form_pos.X != -1000)
            {
                Point mousePosition = Control.MousePosition;
                Point location = new Point(this.form_pos.X + mousePosition.X - this.mouse_pos.X, this.form_pos.Y + mousePosition.Y - this.mouse_pos.Y);
                base.Location = location;
            }
        }

        private void panelEx2_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouse_pos = new Point(-1000, -1000);
            this.form_pos = new Point(-1000, -1000);
        }

        private void p0_MouseDown(object sender, MouseEventArgs e)
        {
            PanelEx panelEx = (PanelEx)sender;
            panelEx.Style.BackColor1.Color = Color.FromArgb(175, 210, 255);
            panelEx.Style.BackColor2.Color = Color.FromArgb(175, 210, 255);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.messagetext.SelectedText.CopyTextToClipboard();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

     
    }
}
