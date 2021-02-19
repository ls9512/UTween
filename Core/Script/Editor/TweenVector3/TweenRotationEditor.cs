/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRotationEditor.cs
//  Info     : TweenRotation 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Rotation)]
    public class TweenRotationEditor : TweenVector3BaseEditor
    {
        public override int Type => TweenType.Rotation;
        public override int RequireCurveCount => 3;
        public override bool AllowQuickOperation => true;
        public new TweenRotation Tweener => Target as TweenRotation;

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
