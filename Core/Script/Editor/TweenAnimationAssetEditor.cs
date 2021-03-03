/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenAnimationAssetEditor.cs
//  Info     : 插值动画参数绘制器
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

namespace Aya.Tween
{
    [CustomEditor(typeof(TweenAnimationAsset))]
    [CanEditMultipleObjects]
    public class TweenAnimationAssetEditor : Editor
    {
        public virtual TweenAnimationAsset Target => target as TweenAnimationAsset;

        public TweenerEditor TweenerEditor { get; set; }

        public SerializedProperty TweenParamSerializedProperty
        {
            get
            {
                if (_tweenParamSerializedObject == null)
                {
                    if (Target.Param == null)
                    {
                        Target.Param = new TweenParam();
                    }

                    _tweenParamSerializedObject = serializedObject.FindProperty(TweenKey.Param);
                }

                return _tweenParamSerializedObject;
            }
        }

        private SerializedProperty _tweenParamSerializedObject;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = TweenEditorUtil.LabelWidth;
            DrawTypeIdentifier();
            DrawTweener();
            EditorGUIUtility.labelWidth = originalLabelWidth;
            serializedObject.ApplyModifiedProperties();
        }

        public virtual void DrawTypeIdentifier()
        {
            if (Application.isPlaying) return;
            if (Target.Param.Type == TweenType.None)
            {
                GUILayout.BeginHorizontal();
                var typeProperty = TweenParamSerializedProperty.FindPropertyRelative(TweenKey.Type);
                EditorGUILayout.PropertyField(typeProperty);
                EditorGUILayout.LabelField("");
                GUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.BeginHorizontal();
                var typeProperty = TweenParamSerializedProperty.FindPropertyRelative(TweenKey.Type);
                EditorGUILayout.PropertyField(typeProperty);
                var idProperty = TweenParamSerializedProperty.FindPropertyRelative(TweenKey.Identifier);
                idProperty.stringValue = EditorGUILayout.TextField(TweenKey.Identifier, idProperty.stringValue);
                GUILayout.EndHorizontal();
            }
        }

        public void DrawTweener()
        {
            GetTweenerEditor();
            if (TweenerEditor == null)
            {
                if (Target.Param.Type != TweenType.None)
                {
                    EditorGUILayout.LabelField(Target.Param.Type + " not support run with Component!");
                }

                return;
            }

            TweenerEditor.OnInspectorGUI(TweenParamSerializedProperty);
        }

        public void GetTweenerEditor()
        {
            if (TweenerEditor == null)
            {
                if (TweenEditorUtil.TweenerEditorTypeDic.TryGetValue(Target.Param.Type, out var tweenerType))
                {
                    TweenerEditor = Activator.CreateInstance(tweenerType) as TweenerEditor;
                    if (TweenerEditor == null) return;
                    TweenerEditor.Mode = TweenerEditorMode.Asset;
                    TweenerEditor.TweenParam = Target.Param;
                    TweenerEditor.Init();
                }
            }
            else
            {
                if (TweenerEditor.Type == Target.Param.Type) return;
                TweenerEditor = null;
                GetTweenerEditor();
            }
        }
    }
}
#endif