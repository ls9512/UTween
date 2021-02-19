/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenValueEditor.cs
//  Info     : TweenValue 编辑器
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Value)]
    public class TweenValueEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Value;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenValue Tweener => Target as TweenValue;
    }
}
#endif