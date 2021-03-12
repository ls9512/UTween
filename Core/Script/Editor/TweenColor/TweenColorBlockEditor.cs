/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenColorBlockEditor.cs
//  Info     : TweenColorBlock 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.ColorBlock)]
    public class TweenColorBlockEditor : TweenColorBaseEditor
    {
        public override int Type => TweenType.ColorBlock;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenColorBlock Tweener => Target as TweenColorBlock;

        public override void DoDrawValue()
        {
            DoDrawTweenHeader();
            EditorGUILayout.BeginHorizontal();
            FromColorProperty.colorValue = EditorGUILayout.ColorField("From", FromColorProperty.colorValue, GUILayout.Width(PropertyWidth));
            ToColorProperty.colorValue = EditorGUILayout.ColorField("To", ToColorProperty.colorValue, GUILayout.Width(PropertyWidth));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(ColorLerpModeProperty, GUILayout.Width(PropertyWidth));
            EditorGUILayout.PropertyField(ColorBlockTypeProperty, GUILayout.Width(PropertyWidth));
            EditorGUILayout.EndHorizontal();
        }
    }
}
#endif