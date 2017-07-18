using System;
using System.Drawing;
using System.Windows.Forms;

namespace rsapp
{
    public static class gdizi
    {
        private static Font font1;

        private static Graphics gc;

        private static StringFormat measureStringFormat = (StringFormat)StringFormat.GenericTypographic.Clone();

        public static showzitype_ Getzipos(string str, showzitype_ zipos, int width, int height, PictureBox pic)
        {
            gdizi.measureStringFormat.LineAlignment = StringAlignment.Near;
            gdizi.measureStringFormat.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
            showzitype_ showzitype_ = zipos;
            int num = width - showzitype_.yuliang;
            int num2 = height - showzitype_.yuliang;
            showzitype_ result;
            if (str == "" || num < 2 || num2 < 2)
            {
                showzitype_.zisize = 1f;
                result = showzitype_;
            }
            else
            {
                if (showzitype_.zisize < (float)(height / 4) || showzitype_.zisize > (float)(height * 3 / 2))
                {
                    showzitype_.zisize = (float)height;
                }
                showzitype_ = gdizi.GetGraphicszipos(str, showzitype_, num, num2);
                if (showzitype_.zisize < 2f)
                {
                    result = showzitype_;
                }
                else
                {
                    Bitmap bitmap;
                    if (height > width)
                    {
                        bitmap = new Bitmap(height * 2, height * 2);
                    }
                    else
                    {
                        bitmap = new Bitmap(width * 2, width * 2);
                    }
                    gdizi.gc = Graphics.FromImage(bitmap);
                    float num3 = 0.5f;
                    if (height > 56)
                    {
                        num3 = 1f;
                    }
                    gdizi.gc.Clear(Color.FromArgb(0, 0, 0));
                    gdizi.font1 = new Font(showzitype_.ziti, showzitype_.zisize, showzitype_.fonstyl);
                    gdizi.gc.DrawString(str, gdizi.font1, Brushes.Red, new Point(1, 1), gdizi.measureStringFormat);
                    zibmtype zibmtype = gdizi.getzibmtype(bitmap);
                    if (zibmtype.ziwidth == 0)
                    {
                        result = showzitype_;
                    }
                    else
                    {
                        while (num - zibmtype.ziwidth > 1 && num2 - zibmtype.ziheight > 1)
                        {
                            if (num - zibmtype.ziwidth < num2 - zibmtype.ziheight)
                            {
                                if (num - zibmtype.ziwidth > 4)
                                {
                                    showzitype_.zisize += (float)((num - zibmtype.ziwidth) / 2);
                                }
                                else
                                {
                                    showzitype_.zisize += num3;
                                }
                            }
                            else if (num2 - zibmtype.ziheight > 4)
                            {
                                showzitype_.zisize += (float)((num2 - zibmtype.ziheight) / 2);
                            }
                            else
                            {
                                showzitype_.zisize += num3;
                            }
                            gdizi.gc.Clear(Color.FromArgb(0, 0, 0));
                            gdizi.font1 = new Font(showzitype_.ziti, showzitype_.zisize, showzitype_.fonstyl);
                            gdizi.gc.DrawString(str, gdizi.font1, Brushes.Red, new Point(1, 1), gdizi.measureStringFormat);
                            zibmtype = gdizi.getzibmtype(bitmap);
                            if (pic != null)
                            {
                                pic.Image = bitmap;
                                Application.DoEvents();
                            }
                        }
                        while (zibmtype.ziwidth > num || zibmtype.ziheight > num2)
                        {
                            showzitype_.zisize -= num3;
                            gdizi.gc.Clear(Color.FromArgb(0, 0, 0));
                            gdizi.font1 = new Font(showzitype_.ziti, showzitype_.zisize, showzitype_.fonstyl);
                            gdizi.gc.DrawString(str, gdizi.font1, Brushes.Red, new Point(1, 1), gdizi.measureStringFormat);
                            zibmtype = gdizi.getzibmtype(bitmap);
                        }
                        showzitype_.zhanyongwidth = zibmtype.ziwidth;
                        showzitype_.zhanyongheight = zibmtype.ziheight;
                        showzitype_.xpianyi = 1 + (width - showzitype_.zhanyongwidth - zibmtype.xfree - zibmtype.xfree) / 2;
                        showzitype_.ypianyi = 1 + (height - showzitype_.zhanyongheight - zibmtype.yfree - zibmtype.yfree) / 2;
                        gdizi.gc.Dispose();
                        bitmap.Dispose();
                        result = showzitype_;
                    }
                }
            }
            return result;
        }

        public static int getxfree(Bitmap bm)
        {
            int num = 0;
            int result;
            while (!gdizi.findbmshuxian(num, bm))
            {
                num++;
                if (num >= bm.Width)
                {
                    result = bm.Width;
                    return result;
                }
            }
            result = num;
            return result;
        }

        public static int getyfree(Bitmap bm)
        {
            int num = 0;
            int result;
            while (!gdizi.findbmhengxian(num, bm))
            {
                num++;
                if (num >= bm.Height)
                {
                    result = bm.Height;
                    return result;
                }
            }
            result = num;
            return result;
        }

        public static int getx2free(Bitmap bm)
        {
            int num = bm.Width - 1;
            int result;
            while (!gdizi.findbmshuxian(num, bm))
            {
                num--;
                if (num < 0)
                {
                    result = bm.Width;
                    return result;
                }
            }
            num = bm.Width - 1 - num;
            result = num;
            return result;
        }

        public static int gety2free(Bitmap bm)
        {
            int num = bm.Height - 1;
            int result;
            while (!gdizi.findbmhengxian(num, bm))
            {
                num--;
                if (num < 0)
                {
                    result = bm.Height;
                    return result;
                }
            }
            num = bm.Height - 1 - num;
            result = num;
            return result;
        }

        public static zibmtype getzibmtype(Bitmap bm)
        {
            zibmtype zibmtype = default(zibmtype);
            zibmtype.ziwidth = 0;
            zibmtype.ziheight = 0;
            zibmtype.xfree = gdizi.getxfree(bm);
            zibmtype result;
            if (zibmtype.xfree == bm.Width)
            {
                result = zibmtype;
            }
            else
            {
                zibmtype.yfree = gdizi.getyfree(bm);
                zibmtype.x2free = gdizi.getx2free(bm);
                zibmtype.y2free = gdizi.gety2free(bm);
                zibmtype.ziwidth = bm.Width - zibmtype.xfree - zibmtype.x2free;
                zibmtype.ziheight = bm.Height - zibmtype.yfree - zibmtype.y2free;
                if (zibmtype.ziwidth < 0)
                {
                    zibmtype.ziwidth = 0;
                }
                if (zibmtype.ziheight < 0)
                {
                    zibmtype.ziheight = 0;
                }
                result = zibmtype;
            }
            return result;
        }

        public static bool findbmshuxian(int x, Bitmap bm)
        {
            bool result;
            for (int i = 0; i < bm.Height; i++)
            {
                if (bm.GetPixel(x, i).R > 0)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        public static bool findbmhengxian(int y, Bitmap bm)
        {
            bool result;
            for (int i = 0; i < bm.Width; i++)
            {
                if (bm.GetPixel(i, y).R > 0)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        public static showzitype_ GetGraphicszipos(string str, showzitype_ zipos, int width, int height)
        {
            Bitmap image = new Bitmap(1, 1);
            showzitype_ showzitype_ = zipos;
            showzitype_ result;
            if (str == "" || width < 2 || height < 2)
            {
                showzitype_.zisize = 1f;
                result = showzitype_;
            }
            else
            {
                if (showzitype_.zisize < (float)(height / 4) || showzitype_.zisize > (float)(height * 3 / 2))
                {
                    showzitype_.zisize = (float)height;
                }
                gdizi.gc = Graphics.FromImage(image);
                Font font = new Font(showzitype_.ziti, showzitype_.zisize, showzitype_.fonstyl);
                Graphicsstrsizetype graphicsstrsize = gdizi.getGraphicsstrsize(gdizi.gc, str, font);
                if (graphicsstrsize.ziwidth < 1f)
                {
                    showzitype_.zisize = 1f;
                    result = showzitype_;
                }
                else
                {
                    if ((float)width - graphicsstrsize.ziwidth > 1f && (float)height - graphicsstrsize.ziheight > 1f)
                    {
                        while ((float)width - graphicsstrsize.ziwidth > 1f && (float)height - graphicsstrsize.ziheight > 1f)
                        {
                            showzitype_.zisize += 0.5f;
                            font = new Font(showzitype_.ziti, showzitype_.zisize, showzitype_.fonstyl);
                            graphicsstrsize = gdizi.getGraphicsstrsize(gdizi.gc, str, font);
                        }
                    }
                    if (graphicsstrsize.ziwidth > (float)width || graphicsstrsize.ziheight > (float)height)
                    {
                        while (graphicsstrsize.ziwidth > (float)width || graphicsstrsize.ziheight > (float)height)
                        {
                            showzitype_.zisize -= 0.5f;
                            font = new Font(showzitype_.ziti, showzitype_.zisize, showzitype_.fonstyl);
                            graphicsstrsize = gdizi.getGraphicsstrsize(gdizi.gc, str, font);
                        }
                    }
                    result = showzitype_;
                }
            }
            return result;
        }

        private static Graphicsstrsizetype getGraphicsstrsize(Graphics g, string word, Font font)
        {
            Graphicsstrsizetype graphicsstrsizetype = new Graphicsstrsizetype
            {
                ziwidth = 0f,
                ziheight = 0f
            };
            Graphicsstrsizetype result;
            if (word == "")
            {
                result = graphicsstrsizetype;
            }
            else
            {
                Rectangle r = new Rectangle(0, 0, 32768, 1000);
                CharacterRange[] measurableCharacterRanges = new CharacterRange[]
                {
                    new CharacterRange(0, word.Length)
                };
                Region[] array = new Region[1];
                gdizi.measureStringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
                array = g.MeasureCharacterRanges(word, font, r, gdizi.measureStringFormat);
                graphicsstrsizetype.ziwidth = array[0].GetBounds(g).Right;
                graphicsstrsizetype.ziheight = array[0].GetBounds(g).Height + array[0].GetBounds(g).Top;
                result = graphicsstrsizetype;
            }
            return result;
        }

        public static void bmpprintstr(Bitmap bm, string str, showzitype_ zipos, int maxwidth, int maxheight, bool istiaozheng)
        {
            gdizi.measureStringFormat.LineAlignment = StringAlignment.Near;
            gdizi.measureStringFormat.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
            Graphics graphics = Graphics.FromImage(bm);
            graphics.Clear(Color.FromArgb(0, 0, 0));
            if (zipos.zisize < 2f)
            {
                graphics.Dispose();
            }
            else if (istiaozheng)
            {
                Bitmap bitmap = new Bitmap(maxwidth * 3 / 2, maxheight * 3 / 2);
                graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.FromArgb(0, 0, 0));
                Font font = new Font(zipos.ziti, zipos.zisize, zipos.fonstyl);
                graphics.DrawString(str, font, Brushes.Red, new Point(zipos.xpianyi, zipos.ypianyi), gdizi.measureStringFormat);
                zibmtype zibmtype = gdizi.getzibmtype(bitmap);
                int x = 0;
                int y = 0;
                if (zibmtype.ziwidth > 0)
                {
                    if (zibmtype.xfree + zibmtype.ziwidth + zipos.yuliang / 2 > maxwidth + 1)
                    {
                        if (zibmtype.ziwidth + zipos.yuliang / 2 <= maxwidth)
                        {
                            x = zibmtype.xfree + zibmtype.ziwidth - maxwidth + zipos.yuliang / 2;
                        }
                        else
                        {
                            int y2free = zibmtype.y2free;
                            zipos.zisize -= 0.5f;
                            graphics.Clear(Color.FromArgb(0, 0, 0));
                            font = new Font(zipos.ziti, zipos.zisize, zipos.fonstyl);
                            graphics.DrawString(str, font, Brushes.Red, new Point(zipos.xpianyi, zipos.ypianyi), gdizi.measureStringFormat);
                            zibmtype = gdizi.getzibmtype(bitmap);
                            while (zibmtype.ziwidth + zipos.yuliang / 2 > maxwidth)
                            {
                                zipos.zisize -= 0.5f;
                                if (zipos.zisize < (float)(maxheight / 4) || zipos.zisize > (float)(maxheight * 3 / 2))
                                {
                                    graphics.Dispose();
                                    bitmap.Dispose();
                                    return;
                                }
                                graphics.Clear(Color.FromArgb(0, 0, 0));
                                font = new Font(zipos.ziti, zipos.zisize, zipos.fonstyl);
                                graphics.DrawString(str, font, Brushes.Red, new Point(zipos.xpianyi, zipos.ypianyi), gdizi.measureStringFormat);
                                zibmtype = gdizi.getzibmtype(bitmap);
                            }
                            y = (zibmtype.y2free - y2free) * -1;
                            if (zibmtype.xfree + zibmtype.ziwidth + zipos.yuliang / 2 > maxwidth + 1)
                            {
                                x = zibmtype.xfree + zibmtype.ziwidth - maxwidth + zipos.yuliang / 2;
                            }
                        }
                    }
                    if (zibmtype.yfree + zibmtype.ziheight + zipos.yuliang / 2 > maxheight + 1)
                    {
                        if (zibmtype.ziheight + zipos.yuliang / 2 <= maxheight)
                        {
                            y = zibmtype.yfree + zibmtype.ziheight - maxheight + zipos.yuliang / 2;
                        }
                    }
                }
                graphics = Graphics.FromImage(bm);
                graphics.Clear(Color.FromArgb(0, 0, 0));
                graphics.DrawImage(bitmap, new Rectangle(0, 0, maxwidth, maxheight), new Rectangle(x, y, maxwidth, maxheight), GraphicsUnit.Pixel);
                graphics.Dispose();
                bitmap.Dispose();
            }
            else
            {
                graphics = Graphics.FromImage(bm);
                graphics.Clear(Color.FromArgb(0, 0, 0));
                Font font = new Font(zipos.ziti, zipos.zisize, zipos.fonstyl);
                graphics.DrawString(str, font, Brushes.Red, new Point(zipos.xpianyi, zipos.ypianyi), gdizi.measureStringFormat);
                graphics.Dispose();
            }
        }
    }
}
