/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenManagerHierarchyCallBack.cs
//  Info     : TweenManager Hierarchy 回调
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
    [InitializeOnLoad]
    public class TweenManagerHierarchyCallBack
    {
        public static readonly EditorApplication.HierarchyWindowItemCallback HierarchyItemCallback;

        private static readonly GUIStyle TweenCounterStyle = new GUIStyle
        {
            alignment = TextAnchor.LowerRight,
            fontSize = 9,
            normal = new GUIStyleState()
            {
                textColor = new Color(0.9f, 0.9f, 0.9f, 1f)
            }
        };

        static TweenManagerHierarchyCallBack()
        {
            HierarchyItemCallback = DrawHierarchyIcon;
            EditorApplication.hierarchyWindowItemOnGUI =
                (EditorApplication.HierarchyWindowItemCallback) Delegate.Combine(
                    EditorApplication.hierarchyWindowItemOnGUI, HierarchyItemCallback);
        }

        private static void DrawHierarchyIcon(int instanceID, Rect selectionRect)
        {
            var go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (go == null) return;

            var check = false;
            var condition1 = go.name.Contains("UTween");
            var count = 0;
            if (TweenSetting.Ins.ShowCounter)
            {
                count = go.GetComponentsInChildren<TweenAnimation>(true).Length;
            }

            var condition2 = count > 0;
            check = condition1 || condition2;

            if (check && count == 0)
            {
                var iconRect = new Rect(selectionRect.x + selectionRect.width - 16f + 1f, selectionRect.y + 1f, 14f, 14f);
                GUI.DrawTexture(iconRect, TweenEditorSetting.Ins.IconLogo);
            }

            if (check && count > 0)
            {
                var iconRect = new Rect(selectionRect.x + selectionRect.width - 16f + 1f, selectionRect.y + 1f, 14f, 14f);
                GUI.DrawTexture(iconRect, TweenEditorSetting.Ins.IconLogo, ScaleMode.ScaleToFit, true, 0f, Color.white * 0.55f,
                    Vector4.zero, Vector4.zero);

                var textRect = new Rect(selectionRect.x + selectionRect.width - 48f, selectionRect.y , 48f, 16f);
                EditorGUI.LabelField(textRect, count.ToString(),TweenCounterStyle);
            }
        }
    }
}
#endif