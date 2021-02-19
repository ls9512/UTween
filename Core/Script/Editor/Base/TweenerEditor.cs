/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenerEditor.cs
//  Info     : Tweener编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace Aya.Tween
{
    public abstract class TweenerEditor
    {
        public TweenerEditorMode Mode { get; set; }
        public abstract int Type { get; }
        public abstract int RequireCurveCount { get; }
        public abstract bool AllowQuickOperation { get; }

        public virtual Tweener Target => TweenAnimation?.Tweener;
        public virtual Tweener Tweener => Target;
        public TweenAnimation TweenAnimation { get; set; }
        public TweenAnimationEditor TweenAnimationEditor { get; set; }
        public TweenParam TweenParam { get; set; } 
        public SerializedProperty TweenParamProperty { get; set; }

        public float PropertyWidth => (EditorGUIUtility.currentViewWidth - EditorGUIUtility.labelWidth * 2f - 24f) / 2f + EditorGUIUtility.labelWidth;
        public float LabelWidth => EditorGUIUtility.labelWidth;
        public float ButtonWidth => (EditorGUIUtility.currentViewWidth - 24f) / 2f;
        public float CurveWidth => 32f;
        public bool EnableEditor { get; internal set; }

        public virtual void Init()
        {
            EnableEditor = true;
        }

        #region OnInspectorGUI

        public virtual void OnInspectorGUI(SerializedProperty serializedProperty)
        {
            TweenParamProperty = serializedProperty;
            var originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = LabelWidth;
            DrawDefaultInspector();
            EditorGUIUtility.labelWidth = originalLabelWidth;
        }

        public void DrawDefaultInspector()
        {
            DoDrawValue();
            DoDrawShakeArgs();
            DoDrawResourcesInfo();
            DoDrawCurve();
            DoDrawPlayType();
            DoDrawDuration();
            DoDrawPlayMode();
            DoDrawTimeScaleAndAutoKill();
            DoDrawAnimationAppend();
            DoDrawCallback();
            DoDrawQuickOpt();
        }

        #endregion

        #region OnSceneGUI
       
        public virtual void OnSceneGUI()
        {

        } 

        #endregion

        #region Draw Header

        /// <summary>
        /// 绘制头部
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="backColor">背景颜色</param>
        public Rect DrawHeader(string title, Color fontColor, Color backColor)
        {
            var rect = EditorGUILayout.BeginVertical();
            GUILayout.Label("");
            EditorGUILayout.EndVertical();
            rect.x = 0;
            rect.width = Screen.width;

            var oriColor = GUI.color;

            var headerStyle = GUI.skin.label;
            headerStyle.fontStyle = FontStyle.Bold;

            GUI.color = backColor;
            EditorGUI.HelpBox(rect, "", MessageType.None);

            var fontRect = rect;
            fontRect.x += 14;
            GUI.color = fontColor;
            EditorGUI.LabelField(fontRect, title, headerStyle);

            GUI.color = oriColor;

            return rect;
        }

        /// <summary>
        /// 绘制可开关头部
        /// </summary>
        /// <param name="toggle">开关</param>
        /// <param name="title">标题</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="backColor">背景颜色</param>
        /// <returns>开关</returns>
        public bool DrawToggleHeader(bool toggle, string title, Color fontColor, Color backColor)
        {
            var rect = DrawHeader(title, fontColor, backColor);
            var style = new GUIStyle();
            var btn = GUI.Button(rect, "", style);

            var oriColor = GUI.color;
            GUI.color = fontColor;
            EditorGUI.LabelField(rect, toggle ? " -" : " +", GUI.skin.label);

            GUI.color = oriColor;

            if (btn)
            {
                toggle = !toggle;
            }
            return toggle;
        }

        #endregion

        #region Draw Header / Play State

        public virtual void DoDrawValue()
        {
            DoDrawTweenHeader();
        }

        protected void DoDrawTweenHeader()
        {
            // var type = TweenType.ValueTypeDic[TweenParam.Type];
            // var id = TweenParam.Identifier;
            // var title = "Tween " + type + (string.IsNullOrEmpty(id) ? "" : " [" + id + "]");
            // DrawHeader(title, Color.cyan, Color.black);

            DoDrawPlayState();
        }

        protected static GUIContent BtnPlayContent;
        protected static GUIContent BtnPauseContent;
        protected static GUIContent BtnRefreshContent;

        public virtual void DoDrawPlayState()
        {
            if (Mode == TweenerEditorMode.Asset) return;
            // if (!Application.isPlaying) return;
            var oriColor = GUI.color;
            var oriBackgroundColor = GUI.backgroundColor;
            // var btnWidth = 55f;

            GUILayout.BeginHorizontal();

            bool enablePlay;
            bool enableGuiEditor;
            if (Tweener == null)
            {
                enablePlay = true;
                enableGuiEditor = false;
            }
            else
            {
                enablePlay = !Tweener.IsPlaying && !Tweener.IsPause;
                enableGuiEditor = (Tweener.IsPlaying && !Tweener.IsPause) || (!Tweener.IsPlaying && Tweener.IsPause);
            }

            // Play Button / Stop
            var btnSize = 24f;
            var stateAreaHeight = 24f;
            GUI.color = enablePlay ? Color.green : Color.red * 1.2f;
            if (BtnPlayContent == null)
            {
                BtnPlayContent = new GUIContent(TweenEditorSetting.Ins.IconPlay);
            }

            if (BtnPauseContent == null)
            {
                BtnPauseContent = new GUIContent(TweenEditorSetting.Ins.IconPause);
            }

            var btnPlayContent = enablePlay ? BtnPlayContent : BtnPauseContent;
            var btnPlay = GUILayout.Button(btnPlayContent, GUILayout.Width(btnSize), GUILayout.Height(stateAreaHeight));
            if (btnPlay)
            {
                if (enablePlay)
                {
                    EditorPlay();
                }
                else
                {
                    EditorStop();
                }
            }

            GUILayout.Space(3);

            // ProgressBar
            GUI.enabled = true;
            GUI.color = Color.white;
            var progressBarRect = EditorGUILayout.BeginHorizontal(GUILayout.Height(stateAreaHeight));
            var progressValue = Tweener?.Progress ?? 0f;
            // var progressRunTime = Tweener?.RunTime ?? 0f;
            // var progressActualDuration = Tweener?.ActualDuration ?? TweenAnimation.Duration;
            var progressBorderWidth = 1f;
            var progressRect = new Rect(
                progressBarRect.x + progressBorderWidth,
                progressBarRect.y + progressBorderWidth,
                (progressBarRect.width - 2f * progressBorderWidth) * progressValue,
                progressBarRect.height - 2f * progressBorderWidth);

            EditorGUI.DrawRect(progressBarRect, new Color(0f, 0.1f, 0f, 1f));
            EditorGUI.DrawRect(progressRect, new Color(0f, 0.35f, 0f, 1f));

            // GUI.color = enablePlay ? Color.gray : Color.white;
            // var progressStr = " " + (progressValue * 100).ToString("F1") + "%  " + progressRunTime.ToString("F1") + "/" + progressActualDuration.ToString("F1");
            
            GUI.color = Color.white;
            var progressStr = " Tween " + TweenType.ValueTypeDic[TweenParam.Type]; ;
            GUILayout.Label(progressStr, GUILayout.Height(stateAreaHeight));
            GUI.color = Color.white;

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(3);

            // Enable Editor Button
            GUI.color = EnableEditor ? Color.cyan : Color.yellow;
            if (BtnRefreshContent == null)
            {
                BtnRefreshContent = new GUIContent(TweenEditorSetting.Ins.IconRefresh);
            }

            var btnEnableEditor = GUILayout.Button(BtnRefreshContent, GUILayout.Width(btnSize), GUILayout.Height(stateAreaHeight));
            if (btnEnableEditor)
            {
                EditorApplyEdit();
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(2);

            GUI.color = oriColor;
            GUI.backgroundColor = oriBackgroundColor;
            GUI.enabled = EnableEditor;
        }

        public void EditorPlay()
        {
            if (!Application.isPlaying)
            {
                TweenManager.Ins.PreviewTweenerList.Add(Tweener);
            }
            else
            {
                if (Tweener == null)
                {
                    TweenAnimation.CreateTweener();
                }
            }

            TweenAnimation.SyncTweenerParams();
            Tweener
                .SetPlayCallback(() =>
                {
                    EnableEditor = false;
                })
                .SetStopCallback(() =>
                {
                    Tweener.SetStart();
                    EnableEditor = true;
                })
                .Play();
            EnableEditor = false;
        }


        public void EditorStop()
        {
            Tweener.Stop(false);
        }

        public void EditorApplyEdit()
        {
            if (EnableEditor)
            {
                if (Tweener != null)
                {
                    TweenAnimation?.SyncTweenerParams();
                }
            }

            EnableEditor = !EnableEditor;
        }

        #endregion

        #region Draw Resources Info

        public virtual void DoDrawResourcesInfo()
        {

        }
        public virtual void DoDrawMaterialsInfo()
        {
            DrawHeader("Material", Color.white, Color.gray);
            GUILayout.BeginHorizontal();
            var resourceIndexProperty = TweenParamProperty.FindProperty(TweenKey.ResourcesIndex);
            resourceIndexProperty.intValue = EditorGUILayout.IntField("Index", resourceIndexProperty.intValue);
            var resourceKeyProperty = TweenParamProperty.FindProperty(TweenKey.ResourcesKey);
            resourceKeyProperty.stringValue = EditorGUILayout.TextField("Property", resourceKeyProperty.stringValue);
            GUILayout.EndHorizontal();
        }

        #endregion

        #region Draw Curve

        protected bool IsAnimationOpen = true;

        public virtual bool DoDrawCurve()
        {
            IsAnimationOpen = DrawToggleHeader(IsAnimationOpen, "Animation", Color.white, Color.gray);
            if (!IsAnimationOpen) return false;
        
            GUILayout.BeginHorizontal();
            var curveTargetProperty = TweenParamProperty.FindProperty(TweenKey.CurveTarget);
            var curveModeProperty = TweenParamProperty.FindProperty(TweenKey.CurveMode);
            if (RequireCurveCount > 1)
            {

                EditorGUILayout.PropertyField(curveTargetProperty);
                EditorGUILayout.PropertyField(curveModeProperty);
            }
            else
            {
                EditorGUILayout.PropertyField(curveTargetProperty, GUILayout.Width(PropertyWidth));
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (RequireCurveCount == 1 || TweenParam.CurveMode == CurveMode.Single)
            {
               
                var curveProperty = TweenParamProperty.FindProperty(TweenKey.Curve);
                curveProperty.animationCurveValue = EditorGUILayout.CurveField("Curve", curveProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
            }

            if (RequireCurveCount == 2 && TweenParam.CurveMode == CurveMode.Independent)
            {
                var curveXProperty = TweenParamProperty.FindProperty(TweenKey.CurveX);
                curveXProperty.animationCurveValue = EditorGUILayout.CurveField("Curve XY", curveXProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
                var curveYProperty = TweenParamProperty.FindProperty(TweenKey.CurveY);
                curveYProperty.animationCurveValue = EditorGUILayout.CurveField("", curveYProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
            }

            if (RequireCurveCount == 3 && TweenParam.CurveMode == CurveMode.Independent)
            {
                var curveXProperty = TweenParamProperty.FindProperty(TweenKey.CurveX);
                curveXProperty.animationCurveValue = EditorGUILayout.CurveField("Curve XYZ", curveXProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
                var curveYProperty = TweenParamProperty.FindProperty(TweenKey.CurveY);
                curveYProperty.animationCurveValue = EditorGUILayout.CurveField("", curveYProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
                var curveZProperty = TweenParamProperty.FindProperty(TweenKey.CurveZ);
                curveZProperty.animationCurveValue = EditorGUILayout.CurveField("", curveZProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));             
            }

            if (RequireCurveCount == 4 && TweenParam.CurveMode == CurveMode.Independent)
            {
                var curveXProperty = TweenParamProperty.FindProperty(TweenKey.CurveX);
                curveXProperty.animationCurveValue = EditorGUILayout.CurveField("Curve XYZW", curveXProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
                var curveYProperty = TweenParamProperty.FindProperty(TweenKey.CurveY);
                curveYProperty.animationCurveValue = EditorGUILayout.CurveField("", curveYProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
                var curveZProperty = TweenParamProperty.FindProperty(TweenKey.CurveZ);
                curveZProperty.animationCurveValue = EditorGUILayout.CurveField("", curveZProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
                var curveWProperty = TweenParamProperty.FindProperty(TweenKey.CurveW);
                curveWProperty.animationCurveValue = EditorGUILayout.CurveField("", curveWProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));

            }

            GUILayout.EndHorizontal();

            return true;
        }

        #endregion

        #region Draw PlayType

        public virtual bool DoDrawPlayType()
        {
            if (!IsAnimationOpen) return false;

            EditorGUILayout.BeginHorizontal();
            var playTypeProperty = TweenParamProperty.FindProperty(TweenKey.PlayType);
            EditorGUILayout.PropertyField(playTypeProperty);
            var easeTypeProperty = TweenParamProperty.FindProperty(TweenKey.EaseType);
            EditorGUILayout.PropertyField(easeTypeProperty);
            EditorGUILayout.EndHorizontal();

            // 指定播放模式下，需要显示播放次数
            var playType = (PlayType)Enum.Parse(typeof(PlayType), Enum.GetNames(typeof(PlayType))[playTypeProperty.enumValueIndex]);
            if (playType == PlayType.LoopCount || playType == PlayType.PingPongCount)
            {
                EditorGUILayout.BeginHorizontal();
                var loopCountProperty = TweenParamProperty.FindProperty(TweenKey.LoopCount);
                EditorGUILayout.PropertyField(loopCountProperty, GUILayout.Width(PropertyWidth));
                EditorGUILayout.EndHorizontal();
            }

            return true;
        }

        #endregion

        #region Draw Duration

        public virtual bool DoDrawDuration()
        {
            if (!IsAnimationOpen) return false;

            EditorGUILayout.BeginHorizontal();
            var durationProperty = TweenParamProperty.FindProperty(TweenKey.Duration);
            EditorGUILayout.PropertyField(durationProperty);
            var startDelayProperty = TweenParamProperty.FindProperty(TweenKey.StartDelay);
            EditorGUILayout.PropertyField(startDelayProperty);
            EditorGUILayout.EndHorizontal();

            var playTypeProperty = TweenParamProperty.FindProperty(TweenKey.PlayType);
            var playType = (PlayType)Enum.Parse(typeof(PlayType), Enum.GetNames(typeof(PlayType))[playTypeProperty.enumValueIndex]);
            var needDrawInterval = playType != PlayType.Once;
            var needDrawSpeedBased = Tweener?.SupportSpeedBased ?? true;

            if (needDrawInterval || needDrawSpeedBased)
            {
                EditorGUILayout.BeginHorizontal();
                if (needDrawInterval)
                {
                    var intervalProperty = TweenParamProperty.FindProperty(TweenKey.Interval);
                    EditorGUILayout.PropertyField(intervalProperty, GUILayout.Width(PropertyWidth));
                }

                if (needDrawSpeedBased)
                {
                    var speedBasedProperty = TweenParamProperty.FindProperty(TweenKey.SpeedBased);
                    EditorGUILayout.PropertyField(speedBasedProperty, GUILayout.Width(PropertyWidth));
                }
                EditorGUILayout.EndHorizontal();
            }

            return true;
        }

        #endregion

        #region Draw PlayMode

        public virtual bool DoDrawPlayMode()
        {
            if (!IsAnimationOpen) return false;

            EditorGUILayout.BeginHorizontal();
            var autoPlayProperty = TweenParamProperty.FindProperty(TweenKey.AutoPlay);
            EditorGUILayout.PropertyField(autoPlayProperty);
            var updateTypeProperty = TweenParamProperty.FindProperty(TweenKey.UpdateType);
            EditorGUILayout.PropertyField(updateTypeProperty);
            EditorGUILayout.EndHorizontal();

            return true;
        }

        #endregion

        #region Draw TimeScale / Time Smooth / Auto Kill

        public virtual bool DoDrawTimeScaleAndAutoKill()
        {
            if (!IsAnimationOpen) return false;

            EditorGUILayout.BeginHorizontal();
            var timeScaleProperty = TweenParamProperty.FindProperty(TweenKey.TimeScale);
            var timeSmoothProperty = TweenParamProperty.FindProperty(TweenKey.TimeSmooth);
            if (timeScaleProperty.boolValue)
            {
                EditorGUILayout.PropertyField(timeScaleProperty);
                EditorGUILayout.PropertyField(timeSmoothProperty);
            }
            else
            {
                EditorGUILayout.PropertyField(timeScaleProperty, GUILayout.Width(PropertyWidth));
                timeSmoothProperty.boolValue = false;
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            var selfScaleProperty = TweenParamProperty.FindProperty(TweenKey.SelfScale);
            EditorGUILayout.PropertyField(selfScaleProperty, GUILayout.Width(PropertyWidth));
            var autoKillProperty = TweenParamProperty.FindProperty(TweenKey.AutoKill);
            EditorGUILayout.PropertyField(autoKillProperty, GUILayout.Width(PropertyWidth));
            EditorGUILayout.EndHorizontal();

            return true;
        }

        #endregion

        #region Draw Animation Append

        public virtual bool DoDrawAnimationAppend()
        {
            return IsAnimationOpen;
        }

        #endregion

        #region Drow Shake Args

        public virtual void DoDrawShakeArgs()
        {
        }

        #endregion

        #region Draw Quick Operation

        protected bool IsComponentOptOpen = false;

        public virtual bool DoDrawQuickOpt()
        {
            return false;
            // if (Mode == TweenerEditorMode.Asset) return false;
            // if (!AllowQuickOperation) return false;
            //
            // IsComponentOptOpen = DrawToggleHeader(IsComponentOptOpen, "Quick Operation", Color.white, Color.gray);
            // if (!IsComponentOptOpen) return false;
            //
            // EditorGUILayout.BeginHorizontal();
            // var btnSetNowFrom = GUILayout.Button("Current > From");
            // if (btnSetNowFrom)
            // {
            //     InvokeMethod(Tweener, "SetCurrent2From");
            //     TweenParam.CopyFromToValueFrom(Tweener.Param);
            // }
            //
            // var btnSetNowTo = GUILayout.Button("Current > To");
            // if (btnSetNowTo)
            // {
            //     InvokeMethod(Tweener, "SetCurrent2To");
            //     TweenParam.CopyFromToValueFrom(Tweener.Param);
            // }
            //
            // EditorGUILayout.EndHorizontal();
            //
            // EditorGUILayout.BeginHorizontal();
            // var btnSetFromNow = GUILayout.Button("From > Current");
            // if (btnSetFromNow)
            // {
            //     TweenParam.CopyFromToValueTo(Tweener.Param);
            //     InvokeMethod(Tweener, "SetFrom2Current");
            // }
            //
            // var btnSetToNow = GUILayout.Button("To > Current");
            // if (btnSetToNow)
            // {
            //     TweenParam.CopyFromToValueTo(Tweener.Param);
            //     InvokeMethod(Tweener, "SetTo2Current");
            // }
            //
            // EditorGUILayout.EndHorizontal();
            //
            // return true;
        }

        #endregion

        #region Draw Callback

        protected bool IsCallbackOpen = false;

        public virtual bool DoDrawCallback()
        {
            if (Mode == TweenerEditorMode.Asset) return false;
            IsCallbackOpen = DrawToggleHeader(IsCallbackOpen, "Callback", Color.white, Color.gray);
            if (!IsCallbackOpen) return false;

            var onPlayProperty = TweenParamProperty.FindProperty(TweenKey.OnPlay);
            EditorGUILayout.PropertyField(onPlayProperty);
            var onStopProperty = TweenParamProperty.FindProperty(TweenKey.OnStop);
            EditorGUILayout.PropertyField(onStopProperty);
            return true;
        }

        #endregion

        #region Reflection

        internal object InvokeMethod(object target, string methodName, params object[] param)
        {
            if (target == null) return null;
            var methodInfo = target.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (methodInfo != null)
            {
                return methodInfo.Invoke(target, param);
            }
            return null;
        }

        #endregion
    }
}

#endif 