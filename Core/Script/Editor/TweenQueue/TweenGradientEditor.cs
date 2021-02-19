/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenGradientEditor.cs
//  Info     : TweenGradient 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Gradient)]
    public class TweenGradientEditor : TweenQueueBaseEditor<Color>
    {
        public override int Type => TweenType.Gradient;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenGradient Tweener => Target as TweenGradient;

        public override void DoDrawValue()
        {
            base.DoDrawValue();
            var queueProperty = TweenParamProperty.FindProperty(TweenKey.QueueColor);
            EditorGUILayout.PropertyField(queueProperty, true);
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