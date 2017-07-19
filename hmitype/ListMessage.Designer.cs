using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColList;

namespace hmitype
{
    partial class ListMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ListMessage));
            this.timerclose = new Timer(this.components);
            this.messageimage = new ImageList(this.components);
            this.colListBox1 = new ColListBox();
            base.SuspendLayout();
            this.timerclose.Interval = 10;
            this.timerclose.Tick += new EventHandler(this.timer1_Tick);
            this.messageimage.ImageStream = (ImageListStreamer)manager.GetObject("messageimage.ImageStream");
            this.messageimage.TransparentColor = Color.Transparent;
            this.messageimage.Images.SetKeyName(0, "message-0.ico");
            this.messageimage.Images.SetKeyName(1, "message-1.ico");
            this.messageimage.Images.SetKeyName(2, "message-2.ico");
            this.messageimage.Images.SetKeyName(3, "message-3.ico");
            this.messageimage.Images.SetKeyName(4, "message-4.ico");
            this.colListBox1.BackColor = Color.White;
            this.colListBox1.BackgroundImage = (Image)manager.GetObject("colListBox1.BackgroundImage");
            this.colListBox1.EditState = false;
            this.colListBox1.idwidth = 5;
            this.colListBox1.imglayout = 0;
            this.colListBox1.itembackcolor_select = Color.Blue;
            this.colListBox1.itembordercolor_move = Color.FromArgb(0xe4, 0x9c, 5);
            this.colListBox1.itembordercolor_select = Color.Blue;
            this.colListBox1.itemeditenabled = false;
            this.colListBox1.itemfontcolor_defaut = Color.Black;
            this.colListBox1.itemfontcolor_select = Color.White;
            this.colListBox1.Itemfontsize = 9;
            this.colListBox1.Itemheight = 0x12;
            this.colListBox1.itemmovebackcolor1 = Color.FromArgb(0xfc, 0xeb, 0x9a);
            this.colListBox1.itemmovestate = true;
            this.colListBox1.Itemschonghui = true;
            this.colListBox1.listbordercolor = Color.FromArgb(0x33, 0x99, 0xff);
            this.colListBox1.listborderwidth = 1;
            this.colListBox1.Location = new Point(0x2b, 0x1b);
            this.colListBox1.Name = "colListBox1";
            this.colListBox1.SelectItemindex = -1;
            this.colListBox1.Size = new Size(0x7d, 0x42);
            this.colListBox1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Silver;
            base.ClientSize = new Size(0x105, 0xa6);
            base.Controls.Add(this.colListBox1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "ListMessage";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.TopMost = true;
            base.Load += new EventHandler(this.ListMessage_Load);
            base.FormClosing += new FormClosingEventHandler(this.ListMessage_FormClosing);
            base.Resize += new EventHandler(this.ListMessage_Resize);
            base.ResumeLayout(false);

        }

        #endregion
    }
}