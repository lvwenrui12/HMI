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
            this.components = new System.ComponentModel.Container();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            this.messageimage = new System.Windows.Forms.ImageList(this.components);
            this.colListBox1 = new ColList.ColListBox();
            this.SuspendLayout();
            // 
            // timerclose
            // 
            this.timerclose.Interval = 10;
            this.timerclose.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // messageimage
            // 
            this.messageimage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.messageimage.ImageSize = new System.Drawing.Size(16, 16);
            this.messageimage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // colListBox1
            // 
            this.colListBox1.BackColor = System.Drawing.Color.White;
            this.colListBox1.EditState = false;
            this.colListBox1.idwidth = 5;
            this.colListBox1.imglayout = ((byte)(0));
            this.colListBox1.itembackcolor_select = System.Drawing.Color.Blue;
            this.colListBox1.itembordercolor_move = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(156)))), ((int)(((byte)(5)))));
            this.colListBox1.itembordercolor_select = System.Drawing.Color.Blue;
            this.colListBox1.itemeditenabled = false;
            this.colListBox1.itemfontcolor_defaut = System.Drawing.Color.Black;
            this.colListBox1.itemfontcolor_select = System.Drawing.Color.White;
            this.colListBox1.Itemfontsize = 9;
            this.colListBox1.Itemheight = 18;
            this.colListBox1.itemmovebackcolor1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(154)))));
            this.colListBox1.itemmovestate = true;
            this.colListBox1.Itemschonghui = true;
            this.colListBox1.listbordercolor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.colListBox1.listborderwidth = 1;
            this.colListBox1.Location = new System.Drawing.Point(43, 27);
            this.colListBox1.Name = "colListBox1";
            this.colListBox1.SelectItemindex = -1;
            this.colListBox1.Size = new System.Drawing.Size(125, 66);
            this.colListBox1.TabIndex = 0;
            // 
            // ListMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(261, 166);
            this.Controls.Add(this.colListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListMessage_FormClosing);
            this.Load += new System.EventHandler(this.ListMessage_Load);
            this.Resize += new System.EventHandler(this.ListMessage_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}