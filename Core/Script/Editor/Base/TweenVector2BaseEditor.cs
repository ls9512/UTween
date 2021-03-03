/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVector2BaseEditor.cs
//  Info     : TweenVector2Base 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    public abstract class TweenVector2BaseEditor : TweenerTVCEditor
    {
        public new Tweener<Vector2> Tweener => Target as Tweener<Vector2>;


        public override void DoDrawValue()
        {
            base.DoDrawValue();
            EditorGUILayout.BeginVertical();
            FromVector2Property.vector2Value = EditorGUILayout.Vector2Field("From", FromVector2Property.vector2Value);
            ToVector2Property.vector2Value = EditorGUILayout.Vector2Field("To", ToVector2Property.vector2Value);
            EditorGUILayout.EndVertical();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            EditorGUILayout.PropertyField(OnValueVector2Property);
            return true;
        }
    }
}
#endif
