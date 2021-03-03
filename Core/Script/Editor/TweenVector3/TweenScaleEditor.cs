/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenScaleEditor.cs
//  Info     : TweenScale 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Scale)]
    public class TweenScaleEditor : TweenVector3BaseEditor
    {
        public override int Type => TweenType.Scale;
        public override int RequireCurveCount => 3;
        public override bool AllowQuickOperation => true;
        public new TweenScale Tweener => Target as TweenScale;

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
