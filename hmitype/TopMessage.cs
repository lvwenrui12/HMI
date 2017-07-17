using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hmitype
{
    public partial class TopMessage : Form
    {
        private int closetime = 0;

        private Point vispoint = new Point(-5000, -5000);

        private StringFormat measureStringFormat = (StringFormat)StringFormat.GenericTypographic.Clone();

        private Bitmap thisbm = null;

        private bool bmlock = true;

      

        private Timer timer1;

        private Timer timer2;

        public bool vis
        {
            get
            {
                return !(base.Location == this.vispoint);
            }
            set
            {
                if (!value)
                {
                    if (base.Location.X != this.vispoint.X || base.Location.Y != this.vispoint.Y)
                    {
                        base.Width = 2;
                        base.Height = 2;
                        base.Location = this.vispoint;
                    }
                }
            }
        }

        public TopMessage()
        {
            this.InitializeComponent();
        }

        private void showpoint(Point point, int xdec, int ydec)
        {
            if (point.X + base.Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                point.X -= base.Width + xdec;
            }
            if (point.Y + base.Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                point.Y -= base.Height + ydec;
            }
            base.Location = point;
            this.Refresh();
        }

        private int getstrwidth(Graphics g, string word, Font font)
        {
            int result;
            if (word == "")
            {
                result = 0;
            }
            else
            {
                Rectangle r = new Rectangle(0, 0, 32768, 1000);
                CharacterRange[] measurableCharacterRanges = new CharacterRange[]
                {
                    new CharacterRange(0, word.Length)
                };
                Region[] array = new Region[1];
                this.measureStringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
                array = g.MeasureCharacterRanges(word, font, r, this.measureStringFormat);
                float right = array[0].GetBounds(g).Right;
                result = (int)right;
            }
            return result;
        }

        public void Showstring(textmessage_type tm, int canindex, Point point, int xdec, int ydec)
        {
            int num = 0;
            int num2 = 2;
            int num3 = 0;
            Font font = new Font(Encoding.Default.BodyName, 9f, FontStyle.Regular);
            Font font2 = new Font(Encoding.Default.BodyName, 9f, FontStyle.Bold);
            Bitmap image = new Bitmap(1500, 1500);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(this.BackColor);
            this.bmlock = true;
            Font font3;
            if (tm.lei == 0)
            {
                if (tm.name == null || tm.name == "")
                {
                    this.bmlock = false;
                    this.vis = false;
                    return;
                }
                string text = tm.name + " ";
                int i = 0;
                font3 = font;
                while (i < text.Length)
                {
                    string text2 = text.Substring(i, 1);
                    int num4 = this.getstrwidth(graphics, text2, font3);
                    if (num + num4 > 600)
                    {
                        num3 = 600;
                        num = 0;
                        num2 += font3.Height + 1;
                    }
                    graphics.DrawString(text2, font3, new SolidBrush(Color.Black), (float)num, (float)num2, this.measureStringFormat);
                    num += num4 + 1;
                    i++;
                    if (num3 < num)
                    {
                        num3 = num;
                    }
                }
                if (tm.comcans != null)
                {
                    for (int j = 0; j < tm.comcans.Length; j++)
                    {
                        if (tm.comcans[j].canname != null)
                        {
                            text = tm.comcans[j].canname;
                            if (j > 0)
                            {
                                text = "," + text;
                            }
                            i = 0;
                            if (j == canindex)
                            {
                                font3 = font2;
                            }
                            else
                            {
                                font3 = font;
                            }
                            while (i < text.Length)
                            {
                                string text2 = text.Substring(i, 1);
                                int num4 = this.getstrwidth(graphics, text2, font3);
                                if (num + num4 > 600)
                                {
                                    num3 = 600;
                                    num = 0;
                                    num2 += font3.Height + 1;
                                }
                                graphics.DrawString(text2, font3, new SolidBrush(Color.Black), (float)num, (float)num2, this.measureStringFormat);
                                num += num4 + 1;
                                i++;
                                if (num3 < num)
                                {
                                    num3 = num;
                                }
                            }
                        }
                    }
                }
                text = "";
                if (canindex > -1 && canindex < tm.comcans.Length && tm.comcans[canindex].zhushi != null && tm.comcans[canindex].zhushi != "")
                {
                    text = tm.comcans[canindex].canname + ":" + tm.comcans[canindex].zhushi;
                }
                else if (canindex == -1 && tm.zhushi != null && tm.zhushi != "")
                {
                    text = tm.zhushi;
                    if (tm.comcans == null || tm.comcans.Length == 0)
                    {
                        text += "(此指令无需参数)".Language();
                    }
                }
                if (text != "")
                {
                    if (num3 < num + 1)
                    {
                        num3 = num;
                    }
                    num = 0;
                    num2 += font3.Height + 1;
                    i = 0;
                    font3 = font2;
                    while (i < text.Length)
                    {
                        string text2 = text.Substring(i, 1);
                        int num4 = this.getstrwidth(graphics, text2, font3);
                        if (num + num4 > 600)
                        {
                            num3 = 600;
                            num = 0;
                            num2 += font3.Height + 1;
                        }
                        graphics.DrawString(text2, font3, new SolidBrush(Color.Black), (float)num, (float)num2, this.measureStringFormat);
                        num += num4 + 1;
                        i++;
                        if (num3 < num)
                        {
                            num3 = num;
                        }
                    }
                }
            }
            else
            {
                if (tm.zhushi == null || tm.zhushi == "")
                {
                    this.bmlock = false;
                    this.vis = false;
                    return;
                }
                string text = tm.zhushi;
                int i = 0;
                font3 = font;
                while (i < text.Length)
                {
                    string text2 = text.Substring(i, 1);
                    int num4 = this.getstrwidth(graphics, text2, font3);
                    if (num + num4 > 600)
                    {
                        num3 = 600;
                        num = 0;
                        num2 += font3.Height + 1;
                    }
                    graphics.DrawString(text2, font3, new SolidBrush(Color.Black), (float)num, (float)num2, this.measureStringFormat);
                    num += num4 + 1;
                    i++;
                    if (num3 < num)
                    {
                        num3 = num;
                    }
                }
            }
            if (num3 < num)
            {
                num3 = num;
            }
            int num5 = num2 + font3.Height;
            this.thisbm = new Bitmap(num3 + 6, num5 + 4);
            Graphics graphics2 = Graphics.FromImage(this.thisbm);
            graphics2.DrawImage(image, 1, 1);
            graphics2.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), 0, 0, this.thisbm.Width - 1, this.thisbm.Height - 1);
            base.Width = this.thisbm.Width;
            base.Height = this.thisbm.Height;
            this.BackgroundImageLayout = ImageLayout.None;
            this.bmlock = false;
            this.showpoint(point, xdec, ydec);
        }

        private void TopMessage_Load(object sender, EventArgs e)
        {
            this.measureStringFormat.LineAlignment = StringAlignment.Near;
            this.measureStringFormat.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
            base.Location = this.vispoint;
        }

        public void close_yanshi()
        {
            if (this.vis)
            {
                this.closetime = 0;
                this.timer1.Enabled = true;
            }
        }

        public void close_end()
        {
            this.timer1.Enabled = false;
            this.closetime = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.closetime > 1)
            {
                this.closetime = 0;
                if (this.vis)
                {
                    this.vis = false;
                    this.timer1.Enabled = false;
                }
                else
                {
                    this.timer1.Enabled = false;
                }
            }
            else
            {
                this.closetime++;
            }
        }

        private void TopMessage_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (!this.bmlock && this.thisbm != null)
                {
                    base.CreateGraphics().DrawImage(this.thisbm, 0, 0);
                }
            }
            catch
            {
            }
        }
    }
}
