/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTransformEditor.cs
//  Info     : TweenTransform 编辑器类
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Transform)]
    public class TweenTransformEditor : TweenerEditor
    {
        public override int Type => TweenType.Transform;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => false;

        public override void DoDrawValue()
        {
            base.DoDrawValue();
            var fromProperty = TweenParamProperty.FindProperty(TweenKey.FromTransform);
            EditorGUILayout.PropertyField(fromProperty, new GUIContent("From"));
            var toProperty = TweenParamProperty.FindProperty(TweenKey.ToTransform);
            EditorGUILayout.PropertyField(toProperty, new GUIContent("To"));
        }

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