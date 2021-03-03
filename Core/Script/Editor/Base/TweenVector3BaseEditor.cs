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
            FromVector3Property.vector3Value = EditorGUILayout.Vector3Field("From", FromVector3Property.vector3Value);
            ToVector3Property.vector3Value = EditorGUILayout.Vector3Field("To", ToVector3Property.vector3Value);
            EditorGUILayout.EndVertical();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            EditorGUILayout.PropertyField(OnValueVector3Property);
            return true;
        }
    }
}
#endif
