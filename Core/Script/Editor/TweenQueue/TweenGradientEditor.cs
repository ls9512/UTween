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
            EditorGUILayout.PropertyField(QueueColorProperty, true);
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