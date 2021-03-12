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

        #region Prperpty Cache

        // protected SerializedProperty TypeProperty;
        // protected SerializedProperty IdentifierProperty;

        protected bool IsCacheProperty;

        protected SerializedProperty FromFloatProperty;
        protected SerializedProperty ToFloatProperty;
        protected SerializedProperty FromVector2Property;
        protected SerializedProperty ToVector2Property;
        protected SerializedProperty FromVector3Property;
        protected SerializedProperty ToVector3Property;
        protected SerializedProperty FromVector4Property;
        protected SerializedProperty ToVector4Property;
        protected SerializedProperty FromColorProperty;
        protected SerializedProperty ToColorProperty;
        protected SerializedProperty FromQuaternionProperty;
        protected SerializedProperty ToQuaternionProperty;
        protected SerializedProperty FromRectProperty;
        protected SerializedProperty ToRectProperty;
        protected SerializedProperty FromStrProperty;
        protected SerializedProperty ToStrProperty;
        protected SerializedProperty FromTransformProperty;
        protected SerializedProperty ToTransformProperty;

        protected SerializedProperty QueueVector3Property;
        protected SerializedProperty QueueColorProperty;

        protected SerializedProperty ResourceIndexProperty;
        protected SerializedProperty ResourceKeyProperty;
        protected SerializedProperty CurveTargetProperty;
        protected SerializedProperty CurveModeProperty;
        protected SerializedProperty CurveProperty;
        protected SerializedProperty CurveXProperty;
        protected SerializedProperty CurveYProperty;
        protected SerializedProperty CurveZProperty;
        protected SerializedProperty CurveWProperty;
        protected SerializedProperty PlayTypeProperty;
        protected SerializedProperty EaseTypeProperty;
        protected SerializedProperty LoopCountProperty;
        protected SerializedProperty DurationProperty;
        protected SerializedProperty StartDelayProperty;
        protected SerializedProperty IntervalProperty;
        protected SerializedProperty SpeedBasedProperty;
        protected SerializedProperty AutoPlayProperty;
        protected SerializedProperty UpdateTypeProperty;
        protected SerializedProperty TimeScaleProperty;
        protected SerializedProperty TimeSmoothProperty;
        protected SerializedProperty SelfScaleProperty;
        protected SerializedProperty AutoKillProperty;
        protected SerializedProperty ColorLerpModeProperty;
        protected SerializedProperty ColorBlockTypeProperty;
        protected SerializedProperty WorldSpaceProperty;
        protected SerializedProperty ShakeArgsProperty;
        protected SerializedProperty PathModeProperty;

        protected SerializedProperty OnPlayProperty;
        protected SerializedProperty OnStopProperty;
        protected SerializedProperty OnValueFloatProperty;
        protected SerializedProperty OnValueVector2Property;
        protected SerializedProperty OnValueVector3Property;
        protected SerializedProperty OnValueVector4Property;
        protected SerializedProperty OnValueColorProperty;
        protected SerializedProperty OnValueQuaternionProperty;
        protected SerializedProperty OnValueRectProperty;
        protected SerializedProperty OnValueStringProperty;

        #endregion

        #region Init & Cache

        public virtual void Init()
        {
            EnableEditor = true;
            IsCacheProperty = false;

            // TypeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.Type);
            // IdentifierProperty = TweenParamProperty.FindPropertyRelative(TweenKey.Identifier);
        }

        public virtual void CacheProperty()
        {
            FromFloatProperty = TweenParamProperty.FindPropertyRelative(TweenKey.FromFloat);
            ToFloatProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ToFloat);
            FromVector2Property = TweenParamProperty.FindPropertyRelative(TweenKey.FromVector2);
            ToVector2Property = TweenParamProperty.FindPropertyRelative(TweenKey.ToVector2);
            FromVector3Property = TweenParamProperty.FindPropertyRelative(TweenKey.FromVector3);
            ToVector3Property = TweenParamProperty.FindPropertyRelative(TweenKey.ToVector3);
            FromVector4Property = TweenParamProperty.FindPropertyRelative(TweenKey.FromVector4);
            ToVector4Property = TweenParamProperty.FindPropertyRelative(TweenKey.ToVector4);
            FromColorProperty = TweenParamProperty.FindPropertyRelative(TweenKey.FromColor);
            ToColorProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ToColor);
            FromQuaternionProperty = TweenParamProperty.FindPropertyRelative(TweenKey.FromQuaternion);
            ToQuaternionProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ToQuaternion);
            FromRectProperty = TweenParamProperty.FindPropertyRelative(TweenKey.FromRect);
            ToRectProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ToRect);
            FromStrProperty = TweenParamProperty.FindPropertyRelative(TweenKey.FromStr);
            ToStrProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ToStr);
            FromTransformProperty = TweenParamProperty.FindPropertyRelative(TweenKey.FromTransform);
            ToTransformProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ToTransform);

            QueueVector3Property = TweenParamProperty.FindPropertyRelative(TweenKey.QueueVector3);
            QueueColorProperty = TweenParamProperty.FindPropertyRelative(TweenKey.QueueColor);

            ResourceIndexProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ResourcesIndex);
            ResourceKeyProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ResourcesKey);
            CurveTargetProperty = TweenParamProperty.FindPropertyRelative(TweenKey.CurveTarget);
            CurveModeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.CurveMode);

            CurveProperty = TweenParamProperty.FindPropertyRelative(TweenKey.Curve);
            CurveXProperty = TweenParamProperty.FindPropertyRelative(TweenKey.CurveX);
            CurveYProperty = TweenParamProperty.FindPropertyRelative(TweenKey.CurveY);
            CurveZProperty = TweenParamProperty.FindPropertyRelative(TweenKey.CurveZ);
            CurveWProperty = TweenParamProperty.FindPropertyRelative(TweenKey.CurveW);

            PlayTypeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.PlayType);
            EaseTypeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.EaseType);
            LoopCountProperty = TweenParamProperty.FindPropertyRelative(TweenKey.LoopCount);
            DurationProperty = TweenParamProperty.FindPropertyRelative(TweenKey.Duration);
            StartDelayProperty = TweenParamProperty.FindPropertyRelative(TweenKey.StartDelay);
            IntervalProperty = TweenParamProperty.FindPropertyRelative(TweenKey.Interval);
            SpeedBasedProperty = TweenParamProperty.FindPropertyRelative(TweenKey.SpeedBased);
            AutoPlayProperty = TweenParamProperty.FindPropertyRelative(TweenKey.AutoPlay);
            UpdateTypeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.UpdateType);
            TimeScaleProperty = TweenParamProperty.FindPropertyRelative(TweenKey.TimeScale);
            TimeSmoothProperty = TweenParamProperty.FindPropertyRelative(TweenKey.TimeSmooth);
            SelfScaleProperty = TweenParamProperty.FindPropertyRelative(TweenKey.SelfScale);
            AutoKillProperty = TweenParamProperty.FindPropertyRelative(TweenKey.AutoKill);
            ColorLerpModeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ColorLerpMode);
            ColorBlockTypeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ColorBlockType);
            WorldSpaceProperty = TweenParamProperty.FindPropertyRelative(TweenKey.WorldSpace);
            ShakeArgsProperty = TweenParamProperty.FindPropertyRelative(TweenKey.ShakeArgs);
            PathModeProperty = TweenParamProperty.FindPropertyRelative(TweenKey.PathMode);

            OnPlayProperty = TweenParamProperty.FindPropertyRelative(TweenKey.OnPlay);
            OnStopProperty = TweenParamProperty.FindPropertyRelative(TweenKey.OnStop);
            OnValueFloatProperty = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueFloat);
            OnValueVector2Property = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueVector2);
            OnValueVector3Property = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueVector3);
            OnValueVector4Property = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueVector4);
            OnValueColorProperty = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueColor);
            OnValueQuaternionProperty = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueQuaternion);
            OnValueRectProperty = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueRect);
            OnValueStringProperty = TweenParamProperty.FindPropertyRelative(TweenKey.OnValueString);

            IsCacheProperty = true;
        }

        #endregion

        #region OnInspectorGUI

        public virtual void OnInspectorGUI(SerializedProperty serializedProperty)
        {
            TweenParamProperty = serializedProperty;
            if (!IsCacheProperty)
            {
                CacheProperty();
            }

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
            var progressStr = " Tween " + SerializeEnumAttribute.TypeIndexInfoDic[TweenKey.TweenType][TweenParam.Type].Name;
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
            ResourceIndexProperty.intValue = EditorGUILayout.IntField("Index", ResourceIndexProperty.intValue);
            ResourceKeyProperty.stringValue = EditorGUILayout.TextField("Property", ResourceKeyProperty.stringValue);
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
            if (RequireCurveCount > 1)
            {

                EditorGUILayout.PropertyField(CurveTargetProperty);
                EditorGUILayout.PropertyField(CurveModeProperty);
            }
            else
            {
                EditorGUILayout.PropertyField(CurveTargetProperty, GUILayout.Width(PropertyWidth));
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            if (RequireCurveCount == 1 || TweenParam.CurveMode == CurveMode.Single)
            {
                TweenParam.Curve = EditorGUILayout.CurveField("Curve", CurveProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
            }

            if (RequireCurveCount == 2 && TweenParam.CurveMode == CurveMode.Independent)
            {
                TweenParam.CurveX = EditorGUILayout.CurveField("Curve XY", CurveXProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
                TweenParam.CurveY = EditorGUILayout.CurveField("", CurveYProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
            }

            if (RequireCurveCount == 3 && TweenParam.CurveMode == CurveMode.Independent)
            {
                TweenParam.CurveX = EditorGUILayout.CurveField("Curve XYZ", CurveXProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
                TweenParam.CurveY = EditorGUILayout.CurveField("", CurveYProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
                TweenParam.CurveZ = EditorGUILayout.CurveField("", CurveZProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));             
            }

            if (RequireCurveCount == 4 && TweenParam.CurveMode == CurveMode.Independent)
            {
                TweenParam.CurveX = EditorGUILayout.CurveField("Curve XYZW", CurveXProperty.animationCurveValue, GUILayout.Width(EditorGUIUtility.labelWidth + CurveWidth), GUILayout.Height(CurveWidth));
                TweenParam.CurveY = EditorGUILayout.CurveField("", CurveYProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
                TweenParam.CurveZ = EditorGUILayout.CurveField("", CurveZProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
                TweenParam.CurveW = EditorGUILayout.CurveField("", CurveWProperty.animationCurveValue, GUILayout.Width(CurveWidth), GUILayout.Height(CurveWidth));
            }

            if (EditorGUI.EndChangeCheck())
            {
                CurveProperty.animationCurveValue = TweenParam.Curve;
                CurveXProperty.animationCurveValue = TweenParam.CurveX;
                CurveYProperty.animationCurveValue = TweenParam.CurveY;
                CurveZProperty.animationCurveValue = TweenParam.CurveZ;
                CurveWProperty.animationCurveValue = TweenParam.CurveW;
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
            EditorGUILayout.PropertyField(PlayTypeProperty);
            EditorGUILayout.PropertyField(EaseTypeProperty);
            EditorGUILayout.EndHorizontal();

            // 指定播放模式下，需要显示播放次数
            var playType = (PlayType)Enum.Parse(typeof(PlayType), Enum.GetNames(typeof(PlayType))[PlayTypeProperty.enumValueIndex]);
            if (playType == PlayType.LoopCount || playType == PlayType.PingPongCount)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(LoopCountProperty, GUILayout.Width(PropertyWidth)); ;
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
            EditorGUILayout.PropertyField(DurationProperty);
            EditorGUILayout.PropertyField(StartDelayProperty);
            EditorGUILayout.EndHorizontal();

            var playType = (PlayType)Enum.Parse(typeof(PlayType), Enum.GetNames(typeof(PlayType))[PlayTypeProperty.enumValueIndex]);
            var needDrawInterval = playType != PlayType.Once;
            var needDrawSpeedBased = Tweener?.SupportSpeedBased ?? true;

            if (needDrawInterval || needDrawSpeedBased)
            {
                EditorGUILayout.BeginHorizontal();
                if (needDrawInterval)
                {
                    EditorGUILayout.PropertyField(IntervalProperty, GUILayout.Width(PropertyWidth));
                }

                if (needDrawSpeedBased)
                {
                    EditorGUILayout.PropertyField(SpeedBasedProperty, GUILayout.Width(PropertyWidth));
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
            EditorGUILayout.PropertyField(AutoPlayProperty);
            EditorGUILayout.PropertyField(UpdateTypeProperty);
            EditorGUILayout.EndHorizontal();

            return true;
        }

        #endregion

        #region Draw TimeScale / Time Smooth / Auto Kill

        public virtual bool DoDrawTimeScaleAndAutoKill()
        {
            if (!IsAnimationOpen) return false;

            EditorGUILayout.BeginHorizontal();
            if (TimeScaleProperty.boolValue)
            {
                EditorGUILayout.PropertyField(TimeScaleProperty);
                EditorGUILayout.PropertyField(TimeSmoothProperty);
            }
            else
            {
                EditorGUILayout.PropertyField(TimeScaleProperty, GUILayout.Width(PropertyWidth));
                TimeSmoothProperty.boolValue = false;
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(SelfScaleProperty, GUILayout.Width(PropertyWidth));
            EditorGUILayout.PropertyField(AutoKillProperty, GUILayout.Width(PropertyWidth));
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

            EditorGUILayout.PropertyField(OnPlayProperty);
            EditorGUILayout.PropertyField(OnStopProperty);
            return true;
        }

        #endregion

        #region Reflection

        internal object InvokeMethod(object target, string methodName, params object[] param)
        {
            if (target == null) return null;
            var methodInfo = target.GetType().GetMethod(methodName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
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