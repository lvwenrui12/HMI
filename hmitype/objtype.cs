using System;
using System.Collections.Generic;

namespace hmitype
{
    public static class objtype
    {
        public static _eventtype chonghui = new _eventtype
        {
            eventname = "ref",
            eventid = "0",
            eventres = "ref"
        };

        public static _eventtype init = new _eventtype
        {
            eventname = "init",
            eventid = "1",
            eventres = "init"
        };

        public static _eventtype load = new _eventtype
        {
            eventname = "前初始化事件".Language(),
            eventid = "2",
            eventres = "load"
        };

        public static _eventtype loadend = new _eventtype
        {
            eventname = "后初始化事件".Language(),
            eventid = "3",
            eventres = "loadend"
        };

        public static _eventtype down = new _eventtype
        {
            eventname = "按下事件".Language(),
            eventid = "4",
            eventres = "down"
        };

        public static _eventtype res0 = new _eventtype
        {
            eventname = "yuliu0",
            eventid = "5",
            eventres = "res0"
        };

        public static _eventtype up = new _eventtype
        {
            eventname = "弹起事件".Language(),
            eventid = "6",
            eventres = "up"
        };

        public static _eventtype slide = new _eventtype
        {
            eventname = "滑动事件".Language(),
            eventid = "7",
            eventres = "slide"
        };

        public static _eventtype tim = new _eventtype
        {
            eventname = "定时事件".Language(),
            eventid = "7",
            eventres = "slide"
        };

        public static List<objmark_> marks = new List<objmark_>();

        public static byte page = 121;

        public static byte button = 98;

        public static byte text = 116;

        public static byte prog = 106;

        public static byte pic = 112;

        public static byte picc = 113;

        public static byte touch = 109;

        public static byte zhizhen = 122;

        public static byte Timer = 51;

        public static byte variable = 52;

        public static byte button_t = 53;

        public static byte number = 54;

        public static byte gtext = 55;

        public static byte checkbox = 56;

        public static byte radiobutton = 57;

        public static byte OBJECT_TYPE_CURVE = 0;

        public static byte OBJECT_TYPE_SLIDER = 1;

        public static void Init()
        {
            objtype.marks.Clear();
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 0,
                intname = "s",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 1,
                intname = "h",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up,
                    objtype.slide
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 121,
                intname = "page",
                events = new _eventtype[]
                {
                    objtype.load,
                    objtype.loadend,
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 98,
                intname = "b",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 116,
                intname = "t",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 106,
                intname = "j",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 112,
                intname = "p",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 113,
                intname = "q",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 109,
                intname = "m",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 1,
                mark = 122,
                intname = "z",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 0,
                byx = 0,
                mark = 51,
                intname = "tm",
                events = new _eventtype[]
                {
                    objtype.tim
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 0,
                byx = 0,
                mark = 52,
                intname = "va",
                events = new _eventtype[0]
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 53,
                intname = "bt",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 54,
                intname = "n",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 0,
                mark = 55,
                intname = "g",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 1,
                mark = 56,
                intname = "c",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
            objtype.marks.Add(new objmark_
            {
                show = 1,
                byx = 1,
                mark = 57,
                intname = "r",
                events = new _eventtype[]
                {
                    objtype.down,
                    objtype.up
                }
            });
        }

        public static objmark_ getobjmark(byte mark)
        {
            objmark_ result;
            if (mark < 50)
            {
                result = objtype.marks[(int)mark];
            }
            else
            {
                foreach (objmark_ current in objtype.marks)
                {
                    if (current.mark == mark)
                    {
                        result = current;
                        return result;
                    }
                }
                MessageOpen.Show("Error objtype");
                result = objtype.marks[0];
            }
            return result;
        }
    }
}
