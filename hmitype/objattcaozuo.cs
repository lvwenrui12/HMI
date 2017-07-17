using System;
using System.Collections.Generic;

namespace hmitype
{
    public static class objattcaozuo
    {
        public static void checkattline(ref List<matt> thismatt)
        {
            int num = 0;
            int num2 = 0;
            byte lei = thismatt[0].zhi[0];
            redianinf redianinf = default(redianinf);
            List<matt> list = objattcaozuo.Getmatts(lei, ref redianinf);
            string text = datasize.Objzhushiencoding.GetString(thismatt[0].zhushi);
            string[] array = text.Split(new char[]
            {
                '-'
            });
            if (array.Length > 1)
            {
                num = array[1].Getint();
            }
            text = datasize.Objzhushiencoding.GetString(list[0].zhushi);
            array = text.Split(new char[]
            {
                '-'
            });
            if (array.Length > 1)
            {
                num2 = array[array.Length - 1].Getint();
            }
            if (num != num2)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    matt matt = thismatt.getatt_name(list[i].name, (num > 0) ? ((int)list[i].att.attlei) : -1);
                    if (matt != null)
                    {
                        text = list[i].name.Getstring(datasize.Myencoding);
                        if (text == "txt")
                        {
                            list[i].att.merrylenth = matt.att.merrylenth;
                            text = matt.zhi.Getstring(datasize.Myencoding);
                            byte[] array2 = text.GetbytesssASCII();
                            list[i].zhi = text.GetbytesssASCII(array2.Length + 1);
                            list[i].att.zhanyonglenth = (ushort)list[i].zhi.Length;
                            if (list[i].att.merrylenth < list[i].att.zhanyonglenth)
                            {
                                list[i].att.merrylenth = list[i].att.zhanyonglenth;
                            }
                        }
                        else if (matt.zhi.Length <= list[i].zhi.Length)
                        {
                            matt.zhi.CopyTo(list[i].zhi, 0);
                        }
                    }
                    else if (list[i].name.Getstring(datasize.Myencoding) == "txt")
                    {
                        text = "";
                        byte[] array2 = text.GetbytesssASCII();
                        list[i].zhi = text.GetbytesssASCII(array2.Length + 1);
                        list[i].att.zhanyonglenth = (ushort)list[i].zhi.Length;
                        if (list[i].att.merrylenth < list[i].att.zhanyonglenth)
                        {
                            list[i].att.merrylenth = list[i].att.zhanyonglenth;
                        }
                    }
                }
                thismatt.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    thismatt.Add(list[i]);
                }
            }
        }

        public static matt getatt_name(this List<matt> thismatt, byte[] name, int state)
        {
            matt result;
            for (int i = 0; i < thismatt.Count; i++)
            {
                if (Kuozhan.makebytes(thismatt[i].name, name))
                {
                    if (state > 0)
                    {
                        if (thismatt[i].att.attlei != (byte)state)
                        {
                            goto IL_62;
                        }
                        result = thismatt[i];
                    }
                    else
                    {
                        result = thismatt[i];
                    }
                    return result;
                }
            IL_62:;
            }
            result = null;
            return result;
        }

        public static int getattid_name(this List<matt> thismatt, byte[] name, int state)
        {
            int result;
            for (int i = 0; i < thismatt.Count; i++)
            {
                if (Kuozhan.makebytes(thismatt[i].name, name))
                {
                    if (state > 0)
                    {
                        if (thismatt[i].att.attlei != (byte)state)
                        {
                            goto IL_56;
                        }
                        result = i;
                    }
                    else
                    {
                        result = i;
                    }
                    return result;
                }
            IL_56:;
            }
            result = -1;
            return result;
        }

        public static List<matt> Getmatts(byte lei, ref redianinf weizhi)
        {
            List<matt> list = new List<matt>();
            if (lei == objtype.number)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 99;
                weizhi.endy = 29;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "数字".Language() + "-9", 0, 0, 0, 1);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("style", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "显示风格:0-平面;1-边框;2-3D_Down;3-3D_Up".Language() + "~sta=1", 0, 0, 3, 0);
                list.addnewshu("key", attshuvis.yes, (int)attshulei.key.datafenpei, attshulei.key.typevalue, ischonghui.yes, "255", "绑定键盘".Language(), 0, 0, 255, 0);
                list.addnewshu("borderc", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "边框颜色".Language() + "~style=1", 0, 0, 65535, 0);
                list.addnewshu("borderw", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "2", "边框粗细,最大值:255".Language() + "~style=1", 0, 0, 255, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65535", "背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景切图图片(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "字体色".Language(), 0, 1, 65535, 0);
                list.addnewshu("font", attshuvis.yes, (int)attshulei.Font.datafenpei, attshulei.Font.typevalue, ischonghui.yes, "0", "字库".Language(), 0, 1, 255, 0);
                list.addnewshu("xcen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "水平对齐:0-靠左;1-居中;2-靠右".Language(), 0, 1, 2, 0);
                list.addnewshu("ycen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "垂直对齐:0-靠上;1-居中;2-靠下".Language(), 0, 1, 2, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.SS32.datafenpei, attshulei.SS32.typevalue, ischonghui.yes, "0", "初始值(最小-2147483648,最大2147483647)".Language(), 0, 1, 2147483647, -2147483648);
                list.addnewshu("lenth", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "显示位数(0为自动,最大10位)".Language(), 0, 1, 10, 0);
                list.addnewshu("isbr", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "是否自动换行:0-否;1-是".Language(), 0, 0, 1, 0);
                list.addnewshu("spax", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符横向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
                list.addnewshu("spay", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符纵向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
            }
            else if (lei == objtype.button_t)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 59;
                weizhi.endy = 59;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "双态按钮".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("style", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "3", "显示风格:0-平面;1-边框;2-3D_Down;3-3D_Up;4-3D_Auto".Language() + "~sta=1", 0, 0, 4, 0);
                list.addnewshu("borderc", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "边框颜色".Language() + "~style=1", 0, 0, 65535, 0);
                list.addnewshu("borderw", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "2", "边框粗细,最大值:255".Language() + "~style=1", 0, 0, 255, 0);
                list.addnewshu("picc0", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "状态0切图背景(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("picc1", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "状态1切图背景(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("bco0", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "48631", "状态0背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("bco1", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "1024", "状态1背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("pic0", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "状态0背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("pic1", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "状态1背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "字体色".Language(), 0, 1, 65535, 0);
                list.addnewshu("font", attshuvis.yes, (int)attshulei.Font.datafenpei, attshulei.Font.typevalue, ischonghui.yes, "0", "字库".Language(), 0, 1, 255, 0);
                list.addnewshu("xcen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "水平对齐:0-靠左;1-居中;2-靠右".Language(), 0, 1, 2, 0);
                list.addnewshu("ycen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "垂直对齐:0-靠上;1-居中;2-靠下".Language(), 0, 1, 2, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "当前状态(0或1)".Language(), 0, 1, 1, 0);
                list.addnewshu("txt", attshuvis.yes, 10, attshulei.Sstr.typevalue, ischonghui.yes, "newtxt", "字符内容".Language(), 0, 1, 255, 0);
                list.addnewshu("txt_maxl", attshuvis.yes, (int)attshulei.Strlenth.datafenpei, attshulei.Strlenth.typevalue, 0, "10", "字符最大长度(即分配内存空间)".Language(), 0, 0, 254, 0);
                list.addnewshu("isbr", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "是否自动换行:0-否;1-是".Language(), 0, 0, 1, 0);
                list.addnewshu("spax", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符横向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
                list.addnewshu("spay", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符纵向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
            }
            else if (lei == objtype.checkbox)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 19;
                weizhi.endy = 19;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "复选框".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("style", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "2", "显示风格:0-平面;1-边框;2-3D_Down;3-3D_Up".Language(), 0, 0, 3, 0);
                list.addnewshu("borderc", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "边框颜色".Language() + "~style=1", 0, 0, 65535, 0);
                list.addnewshu("borderw", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "2", "边框粗细,最大值:255".Language() + "~style=1", 0, 0, 255, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65535", "背景色".Language(), 0, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "前景色".Language(), 0, 1, 65535, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "1", "当前状态(0或1)".Language(), 0, 1, 1, 0);
            }
            else if (lei == objtype.radiobutton)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 19;
                weizhi.endy = 19;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "单选框".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65535", "背景色".Language(), 0, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "前景色".Language(), 0, 1, 65535, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "1", "当前状态(0或1)".Language(), 0, 1, 1, 0);
            }
            else if (lei == objtype.variable)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 0;
                weizhi.endy = 0;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.no, lei.ToString(), "变量".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.no, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.no, "0", "数据类型:0-数值;1-字符串".Language(), 0, 0, 1, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.SS32.datafenpei, attshulei.SS32.typevalue, ischonghui.no, "0", "初始值(最小-2147483648,最大2147483647)".Language() + "~sta=0", 0, 1, 2147483647, -2147483648);
                list.addnewshu("txt", attshuvis.yes, 10, attshulei.Sstr.typevalue, ischonghui.no, "newtxt", "初始字符内容".Language() + "~sta=1", 0, 1, 255, 0);
                list.addnewshu("txt_maxl", attshuvis.yes, (int)attshulei.Strlenth.datafenpei, attshulei.Strlenth.typevalue, ischonghui.no, "10", "字符最大长度(即分配内存空间)".Language() + "~sta=1", 0, 0, 255, 0);
            }
            else if (lei == objtype.Timer)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 0;
                weizhi.endy = 0;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "定时器".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("tim", attshuvis.yes, (int)attshulei.UU16.datafenpei, attshulei.UU16.typevalue, ischonghui.yes, "400", "定时时间,单位:ms(最小50,最大65534)".Language(), 0, 1, 65534, 50);
                list.addnewshu("en", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "1", "使能开关:0为关闭,1为开启".Language(), 0, 1, 1, 0);
            }
            else if (lei == objtype.OBJECT_TYPE_CURVE)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 199;
                weizhi.endy = 199;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "曲线/波形".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存位置(全局内存将降低内存的使用效率,请慎重选择):0-私有".Language(), 0, 0, 0, 0);
                list.addnewshu("dir", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "平推方向:0-从左往右;1-从右往左;2-靠右对齐".Language(), 0, 0, 2, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("ch", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "通道数量(最小1,最大4):0-1;1-2;2-3;3-4".Language(), 0, 0, 3, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "背景色".Language() + "~sta=1".Language(), 0, 1, 65535, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景切图图片(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("gdc", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "1024", "网格颜色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("gdw", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "40", "网格宽度,0为无网格".Language() + "~sta=1", 0, 1, 255, 0);
                list.addnewshu("gdh", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "40", "网格高度,0为无网格".Language() + "~sta=1", 0, 1, 255, 0);
                list.addnewshu("pco0", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "64495", "通道0前景色".Language() + "~ch>0", 0, 1, 65535, 0);
                list.addnewshu("pco1", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65519", "通道1前景色".Language() + "~ch>1", 0, 1, 65535, 0);
                list.addnewshu("pco2", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "63488", "通道2前景色".Language() + "~ch>2", 0, 1, 65535, 0);
                list.addnewshu("pco3", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "2016", "通道3前景色".Language() + "~ch>3", 0, 1, 65535, 0);
            }
            else if (lei == objtype.OBJECT_TYPE_SLIDER)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 199;
                weizhi.endy = 24;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "滑块".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("mode", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "滑行方向:0-横向;1-竖向".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("psta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "游标填充方式:0-单色;1-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "1024", "背景色".Language() + "~sta=1".Language(), 0, 1, 65535, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景切图图片(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "63488", "游标颜色".Language() + "~psta=0".Language(), 0, 1, 65535, 0);
                list.addnewshu("pic2", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "游标图片".Language() + "~psta=1", 0, 1, 65535, 0);
                list.addnewshu("wid", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "25", "游标宽度".Language(), 0, 1, 200, 0);
                list.addnewshu("hig", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "25", "游标高度".Language(), 0, 1, 25, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.UU16.datafenpei, attshulei.UU16.typevalue, ischonghui.yes, "50", "当前值".Language(), 0, 1, 65535, 0);
                list.addnewshu("maxval", attshuvis.yes, (int)attshulei.UU16.datafenpei, attshulei.UU16.typevalue, ischonghui.yes, "100", "最大值".Language(), 0, 1, 65535, 0);
                list.addnewshu("minval", attshuvis.yes, (int)attshulei.UU16.datafenpei, attshulei.UU16.typevalue, ischonghui.yes, "0", "最小值".Language(), 0, 1, 65535, 0);
            }
            else if (lei == objtype.text)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 99;
                weizhi.endy = 29;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "文本".Language() + "-13", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("style", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "显示风格:0-平面;1-边框;2-3D_Down;3-3D_Up".Language() + "~sta=1", 0, 0, 3, 0);
                list.addnewshu("key", attshuvis.yes, (int)attshulei.key.datafenpei, attshulei.key.typevalue, ischonghui.yes, "255", "绑定键盘".Language(), 0, 0, 255, 0);
                list.addnewshu("borderc", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "边框颜色".Language() + "~style=1", 0, 0, 65535, 0);
                list.addnewshu("borderw", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "2", "边框粗细,最大值:255".Language() + "~style=1", 0, 0, 255, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65535", "背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景切图图片(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "字体色".Language(), 0, 1, 65535, 0);
                list.addnewshu("font", attshuvis.yes, (int)attshulei.Font.datafenpei, attshulei.Font.typevalue, ischonghui.yes, "0", "字库".Language(), 0, 1, 255, 0);
                list.addnewshu("xcen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "水平对齐:0-靠左;1-居中;2-靠右".Language(), 0, 1, 2, 0);
                list.addnewshu("ycen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "垂直对齐:0-靠上;1-居中;2-靠下".Language(), 0, 1, 2, 0);
                list.addnewshu("pw", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "是否显示为密码(内容仍为实际内容,仅仅显示出来为*):0-否;1-是".Language(), 0, 1, 1, 0);
                list.addnewshu("txt", attshuvis.yes, 10, attshulei.Sstr.typevalue, ischonghui.yes, "newtxt", "字符内容".Language(), 0, 1, 255, 0);
                list.addnewshu("txt_maxl", attshuvis.yes, (int)attshulei.Strlenth.datafenpei, attshulei.Strlenth.typevalue, 0, "10", "字符最大长度(即分配内存空间)".Language(), 0, 0, 254, 0);
                list.addnewshu("isbr", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "是否自动换行:0-否;1-是".Language(), 0, 0, 1, 0);
                list.addnewshu("spax", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符横向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
                list.addnewshu("spay", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符纵向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
            }
            else if (lei == objtype.gtext)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 239;
                weizhi.endy = 29;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "滚动文本".Language() + "-13", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("style", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "显示风格:0-平面;1-边框;2-3D_Down;3-3D_Up".Language() + "~sta=1", 0, 0, 3, 0);
                list.addnewshu("key", attshuvis.yes, (int)attshulei.key.datafenpei, attshulei.key.typevalue, ischonghui.yes, "255", "绑定键盘".Language(), 0, 0, 255, 0);
                list.addnewshu("borderc", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "边框颜色".Language() + "~style=1", 0, 0, 65535, 0);
                list.addnewshu("borderw", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "2", "边框粗细,最大值:255".Language() + "~style=1", 0, 0, 255, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65535", "背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景切图图片(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "字体色".Language(), 0, 1, 65535, 0);
                list.addnewshu("font", attshuvis.yes, (int)attshulei.Font.datafenpei, attshulei.Font.typevalue, ischonghui.yes, "0", "字库".Language(), 0, 1, 255, 0);
                list.addnewshu("xcen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "水平对齐:0-靠左;1-居中;2-靠右".Language(), 0, 1, 2, 0);
                list.addnewshu("ycen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "垂直对齐:0-靠上;1-居中;2-靠下".Language(), 0, 1, 2, 0);
                list.addnewshu("dir", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "滚动方向:0-从左往右;1-从右往左;2-从上往下;3-从下往上".Language(), 0, 1, 3, 0);
                list.addnewshu("tim", attshuvis.yes, (int)attshulei.UU16.datafenpei, attshulei.UU16.typevalue, ischonghui.yes, "150", "滚动周期(单位ms,最小80,最大65534)".Language(), 0, 1, 65534, 80);
                list.addnewshu("dis", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "4", "滚动幅度像素值(最小2,最大50)".Language(), 0, 1, 50, 2);
                list.addnewshu("txt", attshuvis.yes, 10, attshulei.Sstr.typevalue, ischonghui.yes, "newtxt", "字符内容".Language(), 0, 1, 255, 0);
                list.addnewshu("en", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "1", "滚动使能:0为关闭,1为开启".Language(), 0, 1, 1, 0);
                list.addnewshu("txt_maxl", attshuvis.yes, (int)attshulei.Strlenth.datafenpei, attshulei.Strlenth.typevalue, 0, "10", "字符最大长度(即分配内存空间)".Language(), 0, 0, 254, 0);
                list.addnewshu("isbr", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "是否自动换行:0-否;1-是".Language(), 0, 0, 1, 0);
                list.addnewshu("spax", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符横向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
                list.addnewshu("spay", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符纵向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
                list.addnewshu("vvs0", attshuvis.no, (int)attshulei.SS16.datafenpei, attshulei.SS16.typevalue, ischonghui.no, "0", ",move-x".Language(), 0, 1, 2147483647, -2147483648);
                list.addnewshu("vvs1", attshuvis.no, (int)attshulei.SS16.datafenpei, attshulei.SS16.typevalue, ischonghui.no, "0", "move-y".Language(), 0, 1, 2147483647, -2147483648);
                list.addnewshu("vvs2", attshuvis.no, (int)attshulei.SS16.datafenpei, attshulei.SS16.typevalue, ischonghui.no, "0", "this w".Language(), 0, 1, 2147483647, -2147483648);
                list.addnewshu("vvs3", attshuvis.no, (int)attshulei.SS16.datafenpei, attshulei.SS16.typevalue, ischonghui.no, "0", "this h".Language(), 0, 1, 2147483647, -2147483648);
            }
            else if (lei == objtype.button)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 99;
                weizhi.endy = 29;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "按钮".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("style", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "4", "显示风格:0-平面;1-边框;2-3D_Down;3-3D_Up;4-3D_Auto".Language() + "~sta=1", 0, 0, 4, 0);
                list.addnewshu("borderc", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "边框颜色".Language() + "~style=1", 0, 0, 65535, 0);
                list.addnewshu("borderw", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "2", "边框粗细,最大值:255".Language() + "~style=1", 0, 0, 255, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "默认切图背景(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("picc2", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "按下切图背景(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "48631", "默认背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("bco2", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "1024", "按下背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "默认背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("pic2", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "按下背景图片".Language() + "~sta=2", 1, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "默认字体色".Language(), 0, 1, 65535, 0);
                list.addnewshu("pco2", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "0", "按下字体色".Language(), 0, 1, 65535, 0);
                list.addnewshu("font", attshuvis.yes, (int)attshulei.Font.datafenpei, attshulei.Font.typevalue, ischonghui.yes, "0", "字库".Language(), 0, 1, 255, 0);
                list.addnewshu("xcen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "水平对齐:0-靠左;1-居中;2-靠右".Language(), 0, 1, 2, 0);
                list.addnewshu("ycen", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "垂直对齐:0-靠上;1-居中;2-靠下".Language(), 0, 1, 2, 0);
                list.addnewshu("txt", attshuvis.yes, 10, attshulei.Sstr.typevalue, ischonghui.yes, "newtxt", "字符内容".Language(), 0, 1, 255, 0);
                list.addnewshu("txt_maxl", attshuvis.yes, (int)attshulei.Strlenth.datafenpei, attshulei.Strlenth.typevalue, 0, "10", "字符最大长度(即分配内存空间)".Language(), 0, 0, 254, 0);
                list.addnewshu("isbr", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "是否自动换行:0-否;1-是".Language(), 0, 0, 1, 0);
                list.addnewshu("spax", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符横向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
                list.addnewshu("spay", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "0", "字符纵向间距(最小0,最大255)".Language(), 0, 0, 255, 0);
            }
            else if (lei == objtype.prog)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 99;
                weizhi.endy = 29;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "进度条".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "填充方式:0-单色;1-图片".Language(), 0, 0, 1, 0);
                list.addnewshu("dez", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "进度方式:0-横向;1-竖向".Language(), 0, 0, 1, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "48631", "背景色".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "1024", "前景色".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("bpic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景图片".Language() + "~sta=1", 1, 1, 65535, 0);
                list.addnewshu("ppic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "前景图片".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "50", "进度值".Language(), 0, 1, 100, 0);
            }
            else if (lei == objtype.pic)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 59;
                weizhi.endy = 59;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "图片".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "图片".Language(), 1, 1, 65535, 0);
            }
            else if (lei == objtype.picc)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 59;
                weizhi.endy = 59;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "切图".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "切图图片(必须是全屏图片)".Language(), 0, 1, 65535, 0);
            }
            else if (lei == objtype.touch)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 59;
                weizhi.endy = 59;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "热区".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
            }
            else if (lei == objtype.zhizhen)
            {
                weizhi.x = 0;
                weizhi.y = 0;
                weizhi.endx = 99;
                weizhi.endy = 99;
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "指针".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-切图;1-单色".Language(), 0, 0, 1, 0);
                list.addnewshu("picc", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景切图(必须是全屏图片)".Language() + "~sta=0", 0, 1, 65535, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65535", "背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("val", attshuvis.yes, (int)attshulei.UU16.datafenpei, attshulei.UU16.typevalue, ischonghui.yes, "0", "角度,0-360".Language(), 0, 1, 360, 0);
                list.addnewshu("wid", attshuvis.yes, (int)attshulei.UU8.datafenpei, attshulei.UU8.typevalue, ischonghui.yes, "2", "指针粗细,最大值:5".Language(), 0, 1, 5, 0);
                list.addnewshu("pco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "1024", "指针颜色".Language(), 0, 1, 65535, 0);
            }
            else if (lei == objtype.page)
            {
                list.addnewshu("type", attshuvis.yes, (int)attshulei.Type.datafenpei, attshulei.Type.typevalue, ischonghui.yes, lei.ToString(), "页面".Language() + "-9", 0, 0, 255, 0);
                list.addnewshu("vscope", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "0", "内存占用(私有占用只能在当前页面被访问,全局占用可以在所有页面被访问):0-私有;1-全局".Language(), 0, 0, 1, 0);
                list.addnewshu("sta", attshuvis.yes, (int)attshulei.Select.datafenpei, attshulei.Select.typevalue, ischonghui.yes, "1", "背景填充方式:0-无背景;1-单色;2-图片".Language(), 0, 0, 2, 0);
                list.addnewshu("bco", attshuvis.yes, (int)attshulei.Color.datafenpei, attshulei.Color.typevalue, ischonghui.yes, "65535", "背景色".Language() + "~sta=1", 0, 1, 65535, 0);
                list.addnewshu("pic", attshuvis.yes, (int)attshulei.Picid.datafenpei, attshulei.Picid.typevalue, ischonghui.yes, "65535", "背景图片(必须是全屏图片)".Language() + "~sta=2", 0, 1, 65535, 0);
            }
            return list;
        }
    }
}
