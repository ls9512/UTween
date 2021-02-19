/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenWidthEditor.cs
//  Info     : TweenWidth 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Width)]
    public class TweenWidthEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Width;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenWidth Tweener => Target as TweenWidth;
    }
}
#endif
