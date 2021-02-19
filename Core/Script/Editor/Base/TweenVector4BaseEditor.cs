/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVector4BaseEditor.cs
//  Info     : TweenVector4Base 编辑器
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    public abstract class TweenVector4BaseEditor : TweenerTVCEditor
    {
        public new Tweener<Vector4> Tweener => Target as Tweener<Vector4>;

        public override void DoDrawValue()
        {
            base.DoDrawValue();
            EditorGUILayout.BeginVertical();
            var fromProperty = TweenParamProperty.FindProperty(TweenKey.FromVector4);
            fromProperty.vector4Value = EditorGUILayout.Vector4Field("From", fromProperty.vector4Value);
            var toProperty = TweenParamProperty.FindProperty(TweenKey.ToVector4);
            toProperty.vector4Value = EditorGUILayout.Vector4Field("To", toProperty.vector4Value);
            EditorGUILayout.EndVertical();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            var onValueProperty = TweenParamProperty.FindProperty(TweenKey.OnValueVector4);
            EditorGUILayout.PropertyField(onValueProperty);
            return true;
        }
    }
}
#endif
