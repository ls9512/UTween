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
            FromVector4Property.vector4Value = EditorGUILayout.Vector4Field("From", FromVector4Property.vector4Value);
            ToVector4Property.vector4Value = EditorGUILayout.Vector4Field("To", ToVector4Property.vector4Value);
            EditorGUILayout.EndVertical();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            EditorGUILayout.PropertyField(OnValueVector4Property);
            return true;
        }
    }
}
#endif
