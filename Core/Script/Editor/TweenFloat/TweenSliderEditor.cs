/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenSliderEditor.cs
//  Info     : TweenSlider 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Slider)]
    public class TweenSliderEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Slider;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenSlider Tweener => Target as TweenSlider;
    }
}
#endif
