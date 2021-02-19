/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenCanvasGroupAlphaEditor.cs
//  Info     : TweenCanvasGroupAlpha 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.CanvasGroupAlpha)]
    public class TweenCanvasGroupAlphaEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.CanvasGroupAlpha;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenCanvasGroupAlpha Tweener => Target as TweenCanvasGroupAlpha;
    }
}
#endif