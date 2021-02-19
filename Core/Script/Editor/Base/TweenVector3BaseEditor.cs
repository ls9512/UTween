/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVector3BaseEditor.cs
//  Info     : TweenVector3Base 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    public abstract class TweenVector3BaseEditor : TweenerTVCEditor
    {
        public new Tweener<Vector3> Tweener => Target as Tweener<Vector3>;

        public override void DoDrawValue()
        {
            base.DoDrawValue();
            EditorGUILayout.BeginVertical();
            var fromProperty = TweenParamProperty.FindProperty(TweenKey.FromVector3);
            fromProperty.vector3Value = EditorGUILayout.Vector3Field("From", fromProperty.vector3Value);
            var toProperty = TweenParamProperty.FindProperty(TweenKey.ToVector3);
            toProperty.vector3Value = EditorGUILayout.Vector3Field("To", toProperty.vector3Value);
            EditorGUILayout.EndVertical();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            var onValueProperty = TweenParamProperty.FindProperty(TweenKey.OnValueVector3);
            EditorGUILayout.PropertyField(onValueProperty);
            return true;
        }
    }
}
#endif
