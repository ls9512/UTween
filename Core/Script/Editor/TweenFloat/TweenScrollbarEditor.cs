/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenScrollbarEditor.cs
//  Info     : TweenScrollbar 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Scrollbar)]
    public class TweenScrollbarEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Scrollbar;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenScrollbar Tweener => Target as TweenScrollbar;
    }
}
#endif
