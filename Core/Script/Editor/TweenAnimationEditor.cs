/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenAnimationEditor.cs
//  Info     : TweenAnimation 编辑器
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [CustomEditor(typeof(TweenAnimation))]
    [CanEditMultipleObjects]
    public class TweenAnimationEditor : Editor
    {
        public virtual TweenAnimation Target => target as TweenAnimation;
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

        public virtual void OnEnable()
        {
        }

        public virtual void OnDisable()
        {
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = TweenEditorUtil.LabelWidth;
            DrawTypeIdentifier();
            DrawTweener();
            EditorGUIUtility.labelWidth = originalLabelWidth;
            serializedObject.ApplyModifiedProperties();

            if(Target.Tweener == null) return;
            if (Target.Tweener.IsPlaying)
            {
                Repaint();
            }
        }

        public void OnSceneGUI()
        {
            DrawTweenerSceneGUI();
        }

        public virtual void DrawTypeIdentifier()
        {
            if (Application.isPlaying) return;
            if (Target.Type == TweenType.None)
            {
                GUILayout.BeginHorizontal();
                var typeProperty = TweenParamSerializedProperty.FindProperty(TweenKey.Type);
                EditorGUILayout.PropertyField(typeProperty);
                EditorGUILayout.LabelField("");
                GUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.BeginHorizontal();
                var typeProperty = TweenParamSerializedProperty.FindProperty(TweenKey.Type);
                EditorGUILayout.PropertyField(typeProperty);
                var idProperty = TweenParamSerializedProperty.FindProperty(TweenKey.Identifier);
                idProperty.stringValue = EditorGUILayout.TextField(TweenKey.Identifier, idProperty.stringValue);
                GUILayout.EndHorizontal();
            }
        }

        public void DrawTweener()
        {
            GetTweenerEditor();
            if (TweenerEditor == null)
            {
                if (Target.Type != TweenType.None)
                {
                    EditorGUILayout.LabelField(Target.Type + " not support run with Component! OnInspectorGUI call failed!");
                }

                return;
            }

            if (!TweenerEditor.TweenAnimation.HasRequireComponent)
            {
                EditorGUILayout.LabelField("No valid component was found!");
                var fixRequireComponentBtn = GUILayout.Button("Auto Fix / Recheck Require Component");
                if (fixRequireComponentBtn)
                {
                    TweenerEditor.TweenAnimation.FixRequireComponent();
                    TweenerEditor.TweenAnimation.CheckRequireComponent();
                }

                return;
            }

            TweenerEditor.OnInspectorGUI(TweenParamSerializedProperty);
        }

        public void DrawTweenerSceneGUI()
        {
            GetTweenerEditor();
            if (TweenerEditor == null)
            {
                if (Target.Type != TweenType.None)
                {
                    EditorGUILayout.LabelField(Target.Type + " not support run with Component! OnSceneGUI call failed!");
                }

                return;
            }

            TweenerEditor.OnSceneGUI();
        }

        public void GetTweenerEditor()
        {
            if (TweenerEditor == null)
            {
                if (TweenEditorUtil.TweenerEditorTypeDic.TryGetValue(Target.Type, out var tweenerType))
                {
                    TweenerEditor = Activator.CreateInstance(tweenerType) as TweenerEditor;
                    if (TweenerEditor == null) return;
                    TweenerEditor.Mode = TweenerEditorMode.Component;
                    TweenerEditor.TweenAnimation = Target;
                    TweenerEditor.TweenAnimationEditor = this;
                    TweenerEditor.TweenParam = Target.Param;
                    TweenerEditor.Init();
                }
            }
            else
            {
                if (TweenerEditor.Type == Target.Type) return;
                TweenerEditor = null;
                GetTweenerEditor();
            }
        }
    }
}
#endif