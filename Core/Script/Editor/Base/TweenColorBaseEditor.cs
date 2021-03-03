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
            FromColorProperty.colorValue = EditorGUILayout.ColorField("From", FromColorProperty.colorValue);
            ToColorProperty.colorValue = EditorGUILayout.ColorField("To", ToColorProperty.colorValue);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.PropertyField(ColorLerpModeProperty, GUILayout.Width(PropertyWidth));
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            EditorGUILayout.PropertyField(OnValueColorProperty);
            return true;
        }
    }
}
#endif