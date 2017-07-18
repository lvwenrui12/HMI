using Colpanel;
using DevComponents.DotNetBar;
using hmitype;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace rsapp
{
    public partial class picadmin : UserControl
    {
        private Myapp_inf Myapp;

        public imgpicture dimgpic;

        private List<imgpicture> imgpics = new List<imgpicture>();

     
        private PictureBox pictureBox1;

        private Colpanel.Colpanel panel1;

        private ToolStripButton toolStripButton1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem daochuToolStripMenuItem;

        private ToolStripMenuItem toolStripMenuItem1;

        private ToolStripMenuItem toolStripMenuItem2;

        private ToolStripMenuItem toolStripMenuItem3;

        private ToolStripMenuItem toolStripMenuItem4;

        private ToolStripMenuItem quansahnToolStripMenuItem;

        private Bar bar1;

        private ButtonItem buttonItem1;

        private ButtonItem buttonItem2;

        private ImageList imageList1;

        private ButtonItem buttonItem3;

        private ButtonItem buttonItem4;

        private ButtonItem buttonItem5;

        private ButtonItem buttonItem6;

        private ButtonItem buttonItem7;

        private ControlContainerItem controlContainerItem1;

        private LabelItem label1;

        public picadmin()
        {
            InitializeComponent();
        }
    }
}
