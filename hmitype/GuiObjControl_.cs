using System;

namespace hmitype
{
    public struct GuiObjControl_
    {
        public unsafe delegate byte Init_(objxinxi* obj, byte ID);

        public unsafe delegate byte Ref_(objxinxi* obj, byte ID);

        public unsafe delegate byte Load_(objxinxi* obj, byte ID);

        public GuiObjControl_.Init_ Init;

        public GuiObjControl_.Ref_ Ref;

        public GuiObjControl_.Load_ Load;
    }
}
