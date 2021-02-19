/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPositionUGUIEditor.cs
//  Info     : TweenPositionUGUI 编辑器
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.PositionUGUI)]
    public class TweenPositionUGUIEditor : TweenVector2BaseEditor
    {
        public override int Type => TweenType.PositionUGUI;
        public override int RequireCurveCount => 2;
        public override bool AllowQuickOperation => true;
        public new TweenPositionUGUI Tweener => Target as TweenPositionUGUI;
    }
}
#endif