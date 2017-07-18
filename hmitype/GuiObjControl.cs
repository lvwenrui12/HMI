using System;

namespace hmitype
{
    public static class GuiObjControl
    {
        public static unsafe GuiObjControl_[] GuiObjControls = new GuiObjControl_[]
        {
            new GuiObjControl_
            {
                Init = new GuiObjControl_.Init_(GuiCurve.GuiCurveInit),
                Ref = new GuiObjControl_.Ref_(GuiCurve.GuiCurveRef),
                Load = new GuiObjControl_.Load_(GuiCurve.CurveRefBack)
            },
            new GuiObjControl_
            {
                Init = new GuiObjControl_.Init_(GuiSlider.GuiSliderObjInit),
                Ref = new GuiObjControl_.Ref_(GuiSlider.GuiSliderRef),
                Load = new GuiObjControl_.Load_(GuiSlider.GuiSliderLoad)
            }
        };
    }
}
