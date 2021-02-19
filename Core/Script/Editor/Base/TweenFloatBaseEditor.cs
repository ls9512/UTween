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
            var fromProperty = TweenParamProperty.FindProperty(TweenKey.FromFloat);
            fromProperty.floatValue = EditorGUILayout.FloatField("From", fromProperty.floatValue);
            var toProperty = TweenParamProperty.FindProperty(TweenKey.ToFloat);
            toProperty.floatValue = EditorGUILayout.FloatField("To", toProperty.floatValue);
            EditorGUILayout.EndHorizontal();
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            var onValueProperty = TweenParamProperty.FindProperty(TweenKey.OnValueFloat);
            EditorGUILayout.PropertyField(onValueProperty);
            return true;
        }
    }
}
#endif