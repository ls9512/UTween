/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenFloatBaseEditor.cs
//  Info     : TweenFloatBase 编辑器
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;

namespace Aya.Tween
{
    public abstract class TweenFloatBaseEditor : TweenerTVCEditor
    {
        public new Tweener<float> Tweener => Target as Tweener<float>;

        public override void DoDrawValue()
        {
            base.DoDrawValue();
            EditorGUILayout.BeginHorizontal();
            FromFloatProperty.floatValue = EditorGUILayout.FloatField("From", FromFloatProperty.floatValue);
            ToFloatProperty.floatValue = EditorGUILayout.FloatField("To", ToFloatProperty.floatValue);
            EditorGUILayout.EndHorizontal();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            EditorGUILayout.PropertyField(OnValueFloatProperty);
            return true;
        }
    }
}
#endif