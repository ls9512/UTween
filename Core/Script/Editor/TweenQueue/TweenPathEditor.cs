/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPathEditor.cs
//  Info     : TweenPath 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Path)]
    public class TweenPathEditor : TweenQueueBaseEditor<Vector3>
    {
        public override int Type => TweenType.Path;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenPath Tweener => Target as TweenPath;

        #region OnSceneGUI / Draw Curve Editor

        public int SelectIndex { get; set; } = 0;

        public Quaternion _quaternionLookAtCamera =>
            Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);

        public bool IsLocal => !TweenAnimation.WorldSpace && TweenAnimation.transform.parent != null;

        public override void OnSceneGUI()
        {
            base.OnSceneGUI();
            DrawOperateWindow();

            var tweenAnimation = TweenAnimation;
            if (tweenAnimation.QueueVector3.Count < 1) return;

            if (SelectIndex >= tweenAnimation.QueueVector3.Count) SelectIndex = tweenAnimation.QueueVector3.Count - 1;

            for (var i = 0; i < tweenAnimation.QueueVector3.Count; i++)
            {
                var pos = tweenAnimation.QueueVector3[i];
                var worldPos = IsLocal ? tweenAnimation.transform.parent.localToWorldMatrix.MultiplyPoint(pos) : pos;
                var size = HandleUtility.GetHandleSize(worldPos) * 0.08f;
                if (IsLocal)
                {
                    pos = worldPos;
                }

                if (SelectIndex != i)
                {
                    var pressed = Handles.Button(pos, Quaternion.identity, size, size, SelectCapFunction);
                    if (pressed)
                    {
                        SelectIndex = i;
                    }
                }

                if (SelectIndex == i)
                {
                    var newPos = Handles.PositionHandle(pos, Quaternion.identity);

                    if (newPos != pos)
                    {
                        GUI.changed = true;
                        Undo.RecordObject(tweenAnimation, "Changed TweenPath");
                        if (IsLocal)
                        {
                            newPos = TweenAnimation.transform.parent.worldToLocalMatrix.MultiplyPoint(newPos);
                        }

                        tweenAnimation.QueueVector3[i] = newPos;
                    }
                }

                if (ShowPathInfoInScene)
                {
                    Handles.Label(pos + Vector3.up * 4f * size, i + " " + tweenAnimation.QueueVector3[i]);
                }
            }

            if (tweenAnimation.PathMode == PathMode.PointToPoint)
            {
                Handles.color = Color.green;
                for (var i = 1; i < tweenAnimation.QueueVector3.Count; i++)
                {
                    var p1 = tweenAnimation.QueueVector3[i - 1];
                    var p2 = tweenAnimation.QueueVector3[i];

                    if (IsLocal)
                    {
                        p1 = TweenAnimation.transform.parent.localToWorldMatrix.MultiplyPoint(p1);
                        p2 = TweenAnimation.transform.parent.localToWorldMatrix.MultiplyPoint(p2);
                    }

                    Handles.DrawLine(p1, p2);
                }
            }

            if (tweenAnimation.PathMode == PathMode.CatmullRom)
            {
                Handles.color = Color.green;
                tweenAnimation.Param.CopyTo(tweenAnimation.Tweener.Param);
                var delta = 0.01f;
                for (var i = 0f; i < 1f; i += delta)
                {
                    var p1 = Tweener.Evaluate(Mathf.Clamp(i, 0.001f, 0.999f));
                    var p2 = Tweener.Evaluate( Mathf.Clamp(i + delta, 0.001f, 0.999f));

                    if (IsLocal)
                    {
                        p1 = TweenAnimation.transform.parent.localToWorldMatrix.MultiplyPoint(p1);
                        p2 = TweenAnimation.transform.parent.localToWorldMatrix.MultiplyPoint(p2);
                    }

                    Handles.DrawLine(p1, p2);
                }
            }

            if (GUI.changed)
            {
                HandleUtility.Repaint();
            }
        }

        public void SelectCapFunction(int id, Vector3 position, Quaternion rotation, float size, EventType eventType)
        {
            Handles.color = Color.cyan;
            Handles.RectangleHandleCap(id, position, _quaternionLookAtCamera, size, eventType);
        } 

        #endregion

        #region Operate Widnow

        private int _windowId = TweenType.Path;
        private Rect _windowRect;

        public static bool ShowPathInfoInScene { get; set; } = true;

        public void DrawOperateWindow()
        {
            var space = 5f;
            var width = 120f;
            _windowRect.x = space * 2f;
            _windowRect.y = space * 2f + 20f;
            _windowRect = GUILayout.Window(_windowId, _windowRect, id =>
            {
                _windowId = id;
                GUILayout.BeginHorizontal();
                GUILayout.Space(space);
                GUILayout.BeginVertical();
                GUILayout.Space(space);

                GUI.color = Color.white;

                if (SelectIndex >= 0 && TweenAnimation.QueueVector3.Count > 0)
                {
                    var pos = TweenAnimation.QueueVector3[SelectIndex];
                    var newPos = EditorGUILayout.Vector3Field("Position " + SelectIndex, pos);
                    if (newPos != pos)
                    {
                        GUI.changed = true;
                        Undo.RecordObject(TweenAnimation, "Changed TweenPath");
                        TweenAnimation.QueueVector3[SelectIndex] = newPos;
                    }
                }

                GUILayout.Space(space);

                GUILayout.BeginHorizontal();
                GUI.color = new Color(0.75f, 1f, 0.75f, 1f);
                var btnInsert = GUILayout.Button("＋ Insert");
                if (btnInsert)
                {
                    GUI.changed = true;
                    Undo.RecordObject(TweenAnimation, "Changed TweenPath");

                    var tweenTrans = TweenAnimation.transform;
                    if (TweenAnimation.QueueVector3.Count == 0)
                    {
                        var pos = IsLocal ? tweenTrans.localPosition : tweenTrans.position;
                        TweenAnimation.QueueVector3.Add(pos);
                        SelectIndex = 0;
                    }
                    else if (TweenAnimation.QueueVector3.Count == 1)
                    {
                        var pos = IsLocal ? tweenTrans.localPosition + tweenTrans.right : tweenTrans.position + Vector3.right;
                        TweenAnimation.QueueVector3.Add(pos);
                        SelectIndex = 1;
                    }
                    else if(SelectIndex < TweenAnimation.QueueVector3.Count - 1)
                    {
                        var pos = (TweenAnimation.QueueVector3[SelectIndex] +
                                   TweenAnimation.QueueVector3[SelectIndex + 1]) / 2f;
                        TweenAnimation.QueueVector3.Insert(SelectIndex + 1, pos);
                        SelectIndex++;
                    }
                    else
                    {
                        var pos = (TweenAnimation.QueueVector3[SelectIndex] +
                                   TweenAnimation.QueueVector3[SelectIndex - 1]) / 2f;
                        TweenAnimation.QueueVector3.Insert(SelectIndex, pos);
                    }
                }

                GUI.color = new Color(1f, 0.75f, 0.75f, 1f);
                var btnDelete = GUILayout.Button("× Delete");
                if (btnDelete)
                {
                    GUI.changed = true;
                    Undo.RecordObject(TweenAnimation, "Changed TweenPath");
                    TweenAnimation.QueueVector3.RemoveAt(SelectIndex);

                    SelectIndex--;
                    if (SelectIndex < 0) SelectIndex = 0;
                }

                var btnClear = GUILayout.Button("× Clear");
                if (btnClear)
                {
                    GUI.changed = true;
                    Undo.RecordObject(TweenAnimation, "Changed TweenPath");
                    TweenAnimation.QueueVector3.Clear();
                }
                GUILayout.EndHorizontal();

                GUILayout.Space(space);
                GUI.color = Color.white;
                ShowPathInfoInScene = GUILayout.Toggle(ShowPathInfoInScene, "Show Info");

                GUILayout.Space(space);
                GUILayout.EndVertical();
                GUILayout.Space(space);
                GUILayout.EndHorizontal();
                GUI.DragWindow(_windowRect);
            }, "Tween Path Editor", GUILayout.Width(width));
        } 

        #endregion

        #region Overide Base Editor

        public override void DoDrawValue()
        {
            base.DoDrawValue();
            var queueProperty = TweenParamProperty.FindProperty(TweenKey.QueueVector3);
            EditorGUILayout.PropertyField(queueProperty, true);
            var pathModeProperty = TweenParamProperty.FindProperty(TweenKey.PathMode);
            EditorGUILayout.PropertyField(pathModeProperty, GUILayout.Width(PropertyWidth));
        }

        public override bool DoDrawAnimationAppend()
        {
            var visible = base.DoDrawAnimationAppend();
            if (!visible) return false;
            var worldSpaceProperty = TweenParamProperty.FindProperty(TweenKey.WorldSpace);
            EditorGUILayout.PropertyField(worldSpaceProperty, GUILayout.Width(PropertyWidth));
            return true;
        }

        public override bool DoDrawCallback()
        {
            base.DoDrawCallback();
            if (!IsCallbackOpen) return false;

            var onValueProperty = TweenParamProperty.FindProperty(TweenKey.OnValueVector3);
            EditorGUILayout.PropertyField(onValueProperty);
            return true;
        }

        public override bool DoDrawQuickOpt()
        {
            return false;
        } 

        #endregion
    }
}
#endif