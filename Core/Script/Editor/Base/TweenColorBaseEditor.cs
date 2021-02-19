/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenColorBaseEditor.cs
//  Info     : TweenColorBase 编辑器
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    public abstract class TweenColorBaseEditor : TweenerTVCEditor
    {
        public new Tweener<Color> Tweener => Target as Tweener<Color>;

        public override void DoDrawValue()
        {
            DoDrawTweenHeader();
            EditorGUILayout.BeginHorizontal();
            var fromProperty = TweenParamProperty.FindProperty(TweenKey.FromColor);
            fromProperty.colorValue = EditorGUILayout.ColorField("From", fromProperty.colorValue);
            var toProperty = TweenParamProperty.FindProperty(TweenKey.ToColor);
            toProperty.colorValue = EditorGUILayout.ColorField("To", toProperty.colorValue);
            EditorGUILayout.EndHorizontal();
            var lerpModeProperty = TweenParamProperty.FindProperty(TweenKey.ColorLerpMode);
            EditorGUILayout.PropertyField(lerpModeProperty, GUILayout.Width(PropertyWidth));
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            var onValueProperty = TweenParamProperty.FindProperty(TweenKey.OnValueColor);
            EditorGUILayout.PropertyField(onValueProperty);
            return true;
        }
    }
}
#endif