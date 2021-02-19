/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenHeightEditor.cs
//  Info     : TweenHeight 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Height)]
    public class TweenHeightEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Height;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenHeight Tweener => Target as TweenHeight;
    }
}
#endif
