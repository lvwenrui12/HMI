using System;

namespace hmitype
{
    public class matt
    {
        public byte[] name;

        public attinf_Up att;

        public byte[] zhi;

        public byte[] zhushi;

        public matt()
        {
            this.name = new byte[15];
            this.zhi = new byte[1];
            this.zhushi = new byte[1];
        }

        public matt GetCopymatt()
        {
            matt matt = new matt();
            matt.att = this.att;
            matt.name = new byte[this.name.Length];
            matt.zhi = new byte[this.zhi.Length];
            matt.zhushi = new byte[this.zhushi.Length];
            this.zhi.CopyTo(matt.zhi, 0);
            this.name.CopyTo(matt.name, 0);
            this.zhushi.CopyTo(matt.zhushi, 0);
            return matt;
        }
    }
}
