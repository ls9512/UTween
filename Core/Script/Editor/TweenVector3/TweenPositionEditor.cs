/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPositionEditor.cs
//  Info     : TweenPosition 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Position)]
    public class TweenPositionEditor : TweenVector3BaseEditor
    {
        public override int Type => TweenType.Position;
        public override int RequireCurveCount => 3;
        public override bool AllowQuickOperation => true;
        public new TweenPosition Tweener => Target as TweenPosition;

        public override bool DoDrawAnimationAppend()
        {
            var visible = base.DoDrawAnimationAppend();
            if (!visible) return false;
            var worldSpaceProperty = TweenParamProperty.FindProperty(TweenKey.WorldSpace);
            EditorGUILayout.PropertyField(worldSpaceProperty, GUILayout.Width(PropertyWidth));
            return true;
        }
    }
}
#endif
