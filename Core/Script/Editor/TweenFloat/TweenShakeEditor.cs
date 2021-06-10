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
            // var typeProperty = TweenParam.Type;
            // DrawHeader("Tween " + typeProperty, Color.cyan, Color.black);
            DoDrawPlayState();
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
            EditorGUILayout.PropertyField(ShakeArgsProperty, true);
        }

        public override bool DoDrawAnimationAppend()
        {
            var visible = base.DoDrawAnimationAppend();
            if (!visible) return false;

            EditorGUILayout.PropertyField(WorldSpaceProperty, GUILayout.Width(PropertyWidth));
            return true;
        }
    }
}
#endif