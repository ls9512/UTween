/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenColorEditor.cs
//  Info     : TweenColor 编辑器
//  Author   : ls9512
//  E-mail   : ls9512@vip.qq.com
//
//  Copyright : Aya Game Studio 2018
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Color)]
    public class TweenColorEditor : TweenColorBaseEditor
    {
        public override int Type => TweenType.Color;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenColor Tweener => Target as TweenColor;
    }
}
#endif