/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRotationQuaternionEditor.cs
//  Info     : TweenRotationQuaternion 编辑器
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.RotationQuaternion)]
    public class TweenRotationQuaternionEditor : TweenQuaternionBaseEditor
    {
        public override int Type => TweenType.RotationQuaternion;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenRotationQuaternion Tweener => Target as TweenRotationQuaternion;

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
