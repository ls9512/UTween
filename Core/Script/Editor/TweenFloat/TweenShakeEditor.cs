/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenShakeEditor.cs
//  Info     : TweenShake 编辑器
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Shake)]
    public class TweenShakeEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Shake;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => false;
        public new TweenShake Tweener => Target as TweenShake;

        public override void DoDrawValue()
        {
            var typeProperty = TweenParam.Type;
            DrawHeader("Tween " + typeProperty, Color.cyan, Color.black);
            // 隐藏 From To
        }

        public override bool DoDrawQuickOpt()
        {
            // 隐藏 快捷操作按钮
            return true;
        }

        public override void DoDrawShakeArgs()
        {
            // DrawHeader("Shake Args", Color.cyan, Color.black);
            var shakeProperty = TweenParamProperty.FindProperty(TweenKey.ShakeArgs);
            EditorGUILayout.PropertyField(shakeProperty, true);
//            EditorGUILayout.BeginHorizontal();
//            TweenComponent.ShakeArgs.ShakePos = EditorGUILayout.Toggle("Shake Pos", TweenComponent.ShakeArgs.ShakePos, GUILayout.Width(LabelWidth + 20));
//            TweenComponent.ShakeArgs.PowerPos = EditorGUILayout.Vector3Field("", TweenComponent.ShakeArgs.PowerPos);
//            EditorGUILayout.EndHorizontal();
//            EditorGUILayout.BeginHorizontal();
//            TweenComponent.ShakeArgs.ShakeRot = EditorGUILayout.Toggle("Shake Rot", TweenComponent.ShakeArgs.ShakeRot, GUILayout.Width(LabelWidth + 20));
//            TweenComponent.ShakeArgs.PowerRot = EditorGUILayout.Vector3Field("", TweenComponent.ShakeArgs.PowerRot);
//            EditorGUILayout.EndHorizontal();
//            EditorGUILayout.BeginHorizontal();
//            TweenComponent.ShakeArgs.ShakeScale = EditorGUILayout.Toggle("Shake Scale", TweenComponent.ShakeArgs.ShakeScale, GUILayout.Width(LabelWidth + 20));
//            TweenComponent.ShakeArgs.PowerScale = EditorGUILayout.Vector3Field("", TweenComponent.ShakeArgs.PowerScale);
//            EditorGUILayout.EndHorizontal();
//            TweenComponent.ShakeArgs.Count = EditorGUILayout.IntField("Shake Count", TweenComponent.ShakeArgs.Count);
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