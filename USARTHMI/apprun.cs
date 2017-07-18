using Colpanel;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using hmitype;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using run;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using USARTHMI.Properties;

namespace USARTHMI
{
    public partial class apprun : DevComponents.DotNetBar.OfficeForm
    {
        private delegate void SetListBoxCallback(string str);

        private delegate void sendrunscr(string str, bool iscrc, Encoding en);

 
        private Label label6;

        private Label label1;

        private CheckBox checkBox1;

        private Label label2;

        private Label label3;

        private SerialPort com1;

        private System.Windows.Forms.Timer timer2;

        private LinkLabel linkLabel1;

        private LinkLabel linkLabel2;

        private Label label4;

        private Label label5;

        private LinkLabel linkLabel3;

        private Button codetext_clear;

        private Colpanel.Colpanel panel1;

        private runscr runscr1;

        private RadioButton radioButton1;

        private GroupBox groupBox1;

        private RadioButton radioButton2;

        private Label label7;

        private Label label8;

        private LinkLabel linkLabel4;

        private Label label9;

        private TextBox textBox2;

        private LinkLabel linkLabel5;

        private Panel panel2;

        private Label label11;

        private TextBox textBox5;

        private Label label10;

        private TextBox textBox4;

        private CheckBox checkBox2;

        private Label label14;

        private TextBox textBox8;

        private Label label15;

        private TextBox textBox9;

        private Label label12;

        private System.Windows.Forms.Timer timercom;

        private CheckBox checkBox3;

        private ComboBoxEx comboBox2;

        private ComboBoxEx comboBox4;

        private ListBoxAdv listBox1;

        private ListBoxAdv listBox2;

        private ButtonX button2;

        private TextBoxX textBox3;

        private SuperTooltip superTooltip1;

        private Bar bar1;

        private ComboBoxItem comboBox1;

        private LabelItem toolStripLabel1;

        private ComboBoxItem comboBox3;

        private ButtonItem Button3;

        private LabelItem labelItem1;

        private Label label13;

        private Label label16;

        private ButtonItem buttonItem1;

        private ButtonItem buttonItem2;

        private ButtonItem buttonItem3;

        private ButtonItem buttonItem4;

        private LabelItem labelItem2;

        private ButtonItem buttonItem5;

        private RichTextBoxEx codetext;

        private Button codetext_vis;

        private Button codetext_copy;

        private System.Windows.Forms.Timer timer1;

        private ButtonItem buttonItem6;

        private TextEditorControl textEditorControl1;

        private LabelItem labelItem3;

        private ComboBoxItem comboBoxItem1;

        private textmsg textmsg1 = null;

        public Myapp_inf Myapp = null;

        private string binpath;

        private string comdata;

        private string comdata2;

        private int monitime = 0;

        private int sheibeitime = 0;

        private Comuser mycom1 = new Comuser();

        private int jieshuqyt = 0;

        private int ddx = 0;

        private int comrecstate = 0;

        private int sendbo = 0;

        private int sendboyan = 0;

        private int quxianfudu = 0;

        private int quxianyidong = 0;

        private bool quxiansendmoni = false;

        private bool quxiansendcom = false;

        private byte[] quxiantongdaos = new byte[4];

        private Thread Threadsendbo;

        private bool thisisclose = false;

        private int xilie_shebei = -1;

        private Encoding sendencoding;
        public apprun()
        {
            InitializeComponent();
        }
    }
}