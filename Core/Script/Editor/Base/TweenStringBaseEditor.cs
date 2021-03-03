/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenStringBaseEditor.cs
//  Info     : TweenStringBase 编辑器
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;

namespace Aya.Tween
{
    public abstract class TweenStringBaseEditor : TweenerTVCEditor
    {
        public new Tweener<string> Tweener => Target as Tweener<string>;

        public override void DoDrawValue()
        {
            base.DoDrawValue();
            // EditorGUILayout.BeginHorizontal();
            FromStrProperty.stringValue = EditorGUILayout.TextField("From", FromStrProperty.stringValue);
            ToStrProperty.stringValue = EditorGUILayout.TextField("To", ToStrProperty.stringValue);
            // EditorGUILayout.EndHorizontal();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            EditorGUILayout.PropertyField(OnValueStringProperty);
            return true;
        }
    }
}
#endif