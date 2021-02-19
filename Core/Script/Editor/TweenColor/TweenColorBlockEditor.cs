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
            TweenAnimation.FromColor = EditorGUILayout.ColorField("From", TweenAnimation.FromColor, GUILayout.Width(PropertyWidth));
            TweenAnimation.ToColor = EditorGUILayout.ColorField("To", TweenAnimation.ToColor, GUILayout.Width(PropertyWidth));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            TweenAnimation.ColorLerpMode = (ColorLerpMode)EditorGUILayout.EnumPopup("Lerp Mode", TweenAnimation.ColorLerpMode);
            TweenAnimation.ColorBlockType = (ColorBlockType)EditorGUILayout.EnumPopup("Block Type", TweenAnimation.ColorBlockType);
            EditorGUILayout.EndHorizontal();
        }
    }
}
#endif