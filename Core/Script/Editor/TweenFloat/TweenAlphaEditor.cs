/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenAlphaEditor.cs
//  Info     : TweenAlpha 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Alpha)]
    public class TweenAlphaEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Alpha;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenAlpha Tweener => Target as TweenAlpha;
    }
}
#endif