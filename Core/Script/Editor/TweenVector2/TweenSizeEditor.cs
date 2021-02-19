/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenSizeEditor.cs
//  Info     : TweenSize 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Size)]
    public class TweenSizeEditor : TweenVector2BaseEditor
    {
        public override int Type => TweenType.Size;
        public override int RequireCurveCount => 2;
        public override bool AllowQuickOperation => true;
        public new virtual TweenSize Tweener => Target as TweenSize;
    }
}
#endif
