/////////////////////////////////////////////////////////////////////////////
//
//  Script   : Tweener.cs
//  Info     : 插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    public abstract class Tweener
    {
        public TweenParam Param = new TweenParam();

        #region Animation Parameter
        public string Identifier
        {
            get => Param.Identifier;
            set => Param.Identifier = value;
        }

        public CurveMode CurveMode
        {
            get => Param.CurveMode;
            set => Param.CurveMode = value;
        }

        public CurveTargetType CurveTarget
        {
            get => Param.CurveTarget;
            set => Param.CurveTarget = value;
        }

        public AnimationCurve Curve
        {
            get => Param.Curve;
            set => Param.Curve = value;
        }

        public AnimationCurve CurveX
        {
            get => Param.CurveX;
            set => Param.CurveX = value;
        }

        public AnimationCurve CurveY
        {
            get => Param.CurveY;
            set => Param.CurveY = value;
        }

        public AnimationCurve CurveZ
        {
            get => Param.CurveZ;
            set => Param.CurveZ = value;
        }

        public AnimationCurve CurveW
        {
            get => Param.CurveW;
            set => Param.CurveW = value;
        }

        public PlayType PlayType
        {
            get => Param.PlayType;
            set => Param.PlayType = value;
        }

        public int EaseType
        {
            get => Param.EaseType;
            set => Param.EaseType = value;
        }

        public int LoopCount
        {
            get => Param.LoopCount;
            set => Param.LoopCount = value;
        }

        public float Duration
        {
            get => Param.Duration;
            set => Param.Duration = value;
        }

        public float Interval
        {
            get => Param.Interval;
            set => Param.Interval = value;
        }

        public bool SpeedBased
        {
            get => Param.SpeedBased;
            set => Param.SpeedBased = value;
        }

        public float StartDelay
        {
            get => Param.StartDelay;
            set => Param.StartDelay = value;
        }

        public AutoPlayType AutoPlay
        {
            get => Param.AutoPlay;
            set => Param.AutoPlay = value;
        }

        public UpdateType UpdateType
        {
            get => Param.UpdateType;
            set => Param.UpdateType = value;
        }

        public bool TimeScale
        {
            get => Param.TimeScale;
            set => Param.TimeScale = value;
        }

        public float SelfScale
        {
            get => Param.SelfScale;
            set => Param.SelfScale = value;
        }

        public bool TimeSmooth
        {
            get => Param.TimeSmooth;
            set => Param.TimeSmooth = value;
        }

        public bool AutoKill
        {
            get => Param.AutoKill;
            set => Param.AutoKill = value;
        }

        #endregion

        #region Resources Property

        public int ResourcesIndex
        {
            get => Param.ResourcesIndex;
            set => Param.ResourcesIndex = value;
        }
        public string ResourcesKey
        {
            get => Param.ResourcesKey;
            set => Param.ResourcesKey = value;
        }

        #endregion

        #region Not Universal Property

        public bool WorldSpace
        {
            get => Param.WorldSpace;
            set => Param.WorldSpace = value;
        }

        public ColorLerpMode ColorLerpMode
        {
            get => Param.ColorLerpMode;
            set => Param.ColorLerpMode = value;
        }

        public ColorBlockType ColorBlockType
        {
            get => Param.ColorBlockType;
            set => Param.ColorBlockType = value;
        }

        public PathMode PathMode
        {
            get => Param.PathMode;
            set => Param.PathMode = value;
        }

        public TweenShakeArgs ShakeArgs
        {
            get => Param.ShakeArgs;
            set => Param.ShakeArgs = value;
        }

        #endregion

        #region Callback Event
        public OnPlayEvent OnPlay
        {
            get => Param.OnPlay;
            set => Param.OnPlay = value;
        }

        public OnStopEvent OnStop
        {
            get => Param.OnStop;
            set => Param.OnStop = value;
        }

        public OnFloatValueEvent OnValueFloat
        {
            get => Param.OnValueFloat;
            set => Param.OnValueFloat = value;
        }

        public OnVector2ValueEvent OnValueVector2
        {
            get => Param.OnValueVector2;
            set => Param.OnValueVector2 = value;
        }

        public OnVector3ValueEvent OnValueVector3
        {
            get => Param.OnValueVector3;
            set => Param.OnValueVector3 = value;
        }

        public OnVector4ValueEvent OnValueVector4
        {
            get => Param.OnValueVector4;
            set => Param.OnValueVector4 = value;
        }

        public OnColorValueEvent OnValueColor
        {
            get => Param.OnValueColor;
            set => Param.OnValueColor = value;
        }

        public OnQuaternionValueEvent OnValueQuaternion
        {
            get => Param.OnValueQuaternion;
            set => Param.OnValueQuaternion = value;
        }

        public OnRectValueEvent OnValueRect
        {
            get => Param.OnValueRect;
            set => Param.OnValueRect = value;
        }

        public OnStringValueEvent OnValueString
        {
            get => Param.OnValueString;
            set => Param.OnValueString = value;
        }

        #endregion

        #region Property

        /// <summary>
        /// 依赖的动画配置组件
        /// </summary>
        public TweenAnimation TweenAnimation { get; internal set; }

        /// <summary>
        /// 是否处于编辑器模式
        /// </summary>
        public bool IsEditorMode = false;

        /// <summary>
        /// 插值类型
        /// </summary>
        public abstract int Type { get; }

        /// <summary>
        /// 激活状态
        /// </summary>
        public bool Active;

        /// <summary>
        /// 目标物体
        /// </summary>
        public GameObject Target;

        /// <summary>
        /// 目标物体 Transform
        /// </summary>
        public Transform Transform;

        /// <summary>
        /// 是否支持基于速度模式
        /// </summary>
        public abstract bool SupportSpeedBased { get; }

        /// <summary>
        /// 运行时间
        /// </summary>
        public float RunTime;

        /// <summary>
        /// 播放进度
        /// </summary>
        public float Progress
        {
            get
            {
                if (Mathf.Abs(ActualDuration) < 1e-6) return 0f;
                var progress = RunTime / ActualDuration;
                progress = Mathf.Clamp01(progress);
                return progress;
            }
        }

        /// <summary>
        /// 是否播放
        /// </summary>
        public bool IsPlaying;

        /// <summary>
        /// 是否暂停
        /// </summary>
        public bool IsPause;

        /// <summary>
        /// 是否反向播放
        /// </summary>
        public bool IsPlayBackward;

        /// <summary>
        /// 是否处于延时等待中
        /// </summary>
        public bool IsDelay => DelayTimer < StartDelay;

        /// <summary>
        /// 是否处于间隔中
        /// </summary>
        public bool IsInterval;

        /// <summary>
        /// 播放次数
        /// </summary>
        public int PlayCount;

        /// <summary>
        /// 最终用于动画运算的帧时间
        /// </summary>
        public float DeltaTime;

        /// <summary>
        /// 缩放间隔时间
        /// </summary>
        public float ScaledDeltaTime;

        /// <summary>
        /// 平滑缩放间隔时间
        /// </summary>
        public float SmoothDeltaTime;

        /// <summary>
        /// 未缩放间隔时间
        /// </summary>
        public float UnscaledDeltaTime;

        /// <summary>
        /// 插值算法
        /// </summary>
        public EaseFunction EaseFunction;

        /// <summary>
        /// 内部实际运行时长
        /// </summary>
        internal float ActualDuration;

        /// <summary>
        /// 实际插值因子（只计算播放进度）
        /// </summary>
        public float ActualFactor;

        /// <summary>
        /// 当前动画因子（计算播放进度 / Ease / Curve）
        /// </summary>
        public float CurrentFactor;

        /// <summary>
        /// 延时计时器
        /// </summary>
        protected float DelayTimer;

        /// <summary>
        /// 间隔计时器
        /// </summary>
        protected float IntervalTimer;

        /// <summary>
        /// 是否在插值组中，为真时，自身的插值行为和参数失效
        /// </summary>
        internal bool IsInGroup = false;

        #endregion

        #region Tween Update

        /// <summary>
        /// 计算基于速度模式下的动画时长
        /// </summary>
        /// <returns>结果</returns>
        public abstract float GetSpeedBasedDuration();

        /// <summary>
        /// 更新实际动画时长，在内外部逻辑改变 Duration / SpeedBased 属性后需要调用
        /// </summary>
        /// <returns>结果</returns>
        public virtual float UpdateActualDuration()
        {
            ActualDuration = SupportSpeedBased && SpeedBased ? GetSpeedBasedDuration() : Duration;
            return ActualDuration;
        }

        /// <summary>
        /// 计算插值因子
        /// </summary>
        /// <returns>结果</returns>
        public virtual float Factor()
        {
            var deltaTime = DeltaTime;

            if (IsInGroup)
            {
                CurrentFactor = 0f;
                return 0f;
            }

            if (DelayTimer < StartDelay)
            {
                DelayTimer += deltaTime;
                CurrentFactor = 0f;
                return 0f;
            }

            if (IsInterval && IntervalTimer < Interval)
            {
                IntervalTimer += deltaTime;
                return CurrentFactor;
            }

            if (ActualDuration <= 0f)
            {
                if (Duration <= 0f)
                {
                    CurrentFactor = 0f;
                    Stop();
                    return 0f;
                }
                else
                {
                    UpdateActualDuration();
                }
            }

            // 处理反向
            RunTime += IsPlayBackward ? -deltaTime : deltaTime;
            // 因子 = 累积时间 / 总时间
            var factor = RunTime / ActualDuration;

            factor = Mathf.Clamp01(factor);
            ActualFactor = factor;

            if (EaseFunction == null || EaseFunction.Type != EaseType)
            {
                EaseFunction = EaseUtil.GetEaseFunction(EaseType);
            }

            var currentFactor = EaseFunction.Ease(0f, 1f, factor);

            if (Curve != null && CurveMode == CurveMode.Single && CurveTarget == CurveTargetType.Factor)
            {
                currentFactor = Curve.Evaluate(currentFactor);
            }

            CurrentFactor = currentFactor;

            return currentFactor;
        }

        /// <summary>
        /// 更新播放状态
        /// </summary>
        public virtual void UpdateState()
        {
            var factor = RunTime / ActualDuration;
            // 处理播放方式
            switch (PlayType)
            {
                case PlayType.Once:
                    if (factor >= 1f)
                    {
                        Stop();
                    }

                    if (factor <= 0f && IsPlayBackward)
                    {
                        Stop();
                    }

                    break;
                case PlayType.Loop:
                    if (factor >= 1f)
                    {
                        if (InternalRepeatInterval())
                        {
                            return;
                        }

                        PlayCount++;
                        InternalRestart();
                    }

                    break;
                case PlayType.LoopCount:
                    if (factor >= 1f)
                    {
                        if (InternalRepeatInterval())
                        {
                            return;
                        }

                        PlayCount++;
                        if (PlayCount >= LoopCount && LoopCount > 0)
                        {
                            Stop();
                        }
                        else
                        {
                            InternalLoopRestart();
                        }
                    }

                    break;
                case PlayType.PingPong:
                    if (factor >= 1f)
                    {
                        PlayBackward(false);
                    }

                    if (factor <= 0f && IsPlayBackward)
                    {
                        if (InternalRepeatInterval())
                        {
                            return;
                        }

                        PlayCount++;
                        InternalRestart();
                    }

                    break;
                case PlayType.PingPongCount:
                    if (factor >= 1f)
                    {
                        PlayBackward(false);
                    }

                    if (factor <= 0f && IsPlayBackward)
                    {
                        PlayCount++;
                        if (PlayCount >= LoopCount && LoopCount > 0)
                        {
                            Stop();
                        }
                        else
                        {
                            if (InternalRepeatInterval())
                            {
                                return;
                            }

                            InternalLoopRestart();
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// 插值更新
        /// </summary>
        public abstract void TweenUpdate();

        #endregion

        #region Set Status

        /// <summary>
        /// 设置到指定的播放进度
        /// </summary>
        /// <param name="schedule">进度（0-1）</param>
        public virtual void SetSchedule(float schedule)
        {
            var delta = Mathf.Clamp01(schedule);
            RunTime = ActualDuration * delta;
            DeltaTime = 0f;
            Factor();
            TweenUpdate();
        }

        /// <summary>
        /// 根据运行时间设置播放进度
        /// </summary>
        /// <param name="runTime">播放时间</param>
        public virtual void SetScheduleByRunTime(float runTime)
        {
            runTime = Mathf.Clamp(runTime, 0f, ActualDuration);
            var delta = runTime / ActualDuration;
            RunTime = ActualDuration * delta;
            DeltaTime = 0f;
            Factor();
            TweenUpdate();
        }

        /// <summary>
        /// 设置到开始状态
        /// </summary>
        public virtual void SetStart()
        {
            RunTime = 0f;
            DeltaTime = 0f;
            Factor();
            TweenUpdate();
        }

        /// <summary>
        /// 设置到结束状态
        /// </summary>
        public virtual void SetEnd()
        {
            RunTime = ActualDuration;
            DeltaTime = 0f;
            Factor();
            TweenUpdate();
        }

        #endregion

        #region Play & Stop

        /// <summary>
        /// 开始播放
        /// </summary>
        public virtual void Play()
        {
            if (Target == null) return;
            Active = true;
            IsPlaying = true;
            IsPause = false;
            IsPlayBackward = false;
            PlayCount = 0;
            DelayTimer = 0f;
            UpdateActualDuration();
            Param.InitCallback();

            OnPlay.InvokeIfNeed();
            TweenManager.Ins.Add(this);
        }

        /// <summary>
        /// 反向播放
        /// </summary>
        /// <param name="immediately">立即(false:从结束时间返回 true:从当前时间返回)</param>
        public virtual void PlayBackward(bool immediately = false)
        {
            if (ActualDuration <= 1e-6)
            {
                UpdateActualDuration();
            }

            if (immediately)
            {
                // 防止刚好播放结束时触发回放导致的闪烁
                if (RunTime <= 1e-6f)
                {
                    RunTime = ActualDuration;
                }
            }
            else
            {
                RunTime = ActualDuration;
            }

            Active = true;
            IsPlayBackward = true;
            IsPlaying = true;
            IsPause = false;

            TweenManager.Ins.Add(this);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public virtual void Pause()
        {
            IsPlaying = false;
            IsPause = true;
        }

        /// <summary>
        /// 恢复
        /// </summary>
        public virtual void Resume()
        {
            IsPlaying = true;
            IsPause = false;
        }

        /// <summary>
        /// 切换 暂停 / 播放 状态
        /// </summary>
        public virtual void TogglePause()
        {
            IsPlaying = !IsPlaying;
            IsPause = !IsPause;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="destroy">销毁</param>
        public virtual void Stop(bool destroy = true)
        {
            if (AutoPlay == AutoPlayType.None)
            {
                Active = false;
            }

            DelayTimer = StartDelay;
            RunTime = 0f;
            IsPlaying = false;
            IsPlayBackward = false;
            IsPause = false;
            OnStop.InvokeIfNeed();

            if (Application.isPlaying && TweenAnimation != null)
            {
                TweenAnimation.Tweener = null;
                TweenManager.Ins?.Remove(this, true);
                if (AutoKill && destroy)
                {
                    Object.Destroy(TweenAnimation);
                }
            }
            else
            {
                TweenManager.Ins?.Remove(this, destroy);
            }
        }

        /// <summary>
        /// 重新开始(清空计数)
        /// </summary>
        public virtual void Restart()
        {
            Stop(false);
            Play();
        }

        /// <summary>
        /// 重复播放间隔
        /// </summary>
        /// <returns>是否处理间隔</returns>
        internal virtual bool InternalRepeatInterval()
        {
            if (Interval > 0f && !IsInterval)
            {
                IntervalTimer = 0f;
                IsInterval = true;
            }

            if (IsInterval && IntervalTimer >= Interval)
            {
                IsInterval = false;
            }

            return IsInterval;
        }

        /// <summary>
        /// 重新开始(不处理 TweenManager)
        /// </summary>
        internal virtual void InternalRestart()
        {
            DelayTimer = StartDelay;
            RunTime = 0f;
            OnStop.InvokeIfNeed();

            IsPlaying = true;
            IsPause = false;
            IsPlayBackward = false;
            PlayCount = 0;
            DelayTimer = 0f;
            OnPlay.InvokeIfNeed();
        }

        /// <summary>
        /// 循环重新开始(不清空计数，不处理 TweenManager)
        /// </summary>
        internal virtual void InternalLoopRestart()
        {
            RunTime = 0f;
            IsPlaying = true;
            IsPlayBackward = false;
            IsPause = false;
        }

        #endregion

        #region Update Behaviour

        public virtual void UpdateBehaviour(float scaledDeltaTime, float smoothDeltaTime, float unscaledDeltaTime)
        {
            // if (Target == null) return;
            // if (!Target.activeSelf) return;
            if (UpdateType != UpdateType.Update) return;
            if (!IsPlaying || IsInGroup) return;
            ScaledDeltaTime = scaledDeltaTime;
            SmoothDeltaTime = smoothDeltaTime;
            UnscaledDeltaTime = unscaledDeltaTime;
            DeltaTime = (TimeScale ? (TimeSmooth ? SmoothDeltaTime : ScaledDeltaTime) : UnscaledDeltaTime) * SelfScale;

            Factor();
            if (IsDelay) return;
            TweenUpdate();
            UpdateState();
        }

        public virtual void LateUpdateBehaviour(float scaledDeltaTime, float smoothDeltaTime, float unscaledDeltaTime)
        {
            // if (Target == null) return;
            // if (!Target.activeSelf) return;
            if (UpdateType != UpdateType.LateUpdate) return;
            if (!IsPlaying || IsInGroup) return;
            ScaledDeltaTime = scaledDeltaTime;
            SmoothDeltaTime = smoothDeltaTime;
            UnscaledDeltaTime = unscaledDeltaTime;
            DeltaTime = (TimeScale ? (TimeSmooth ? SmoothDeltaTime : ScaledDeltaTime) : UnscaledDeltaTime) * SelfScale;

            Factor();
            if (IsDelay) return;
            TweenUpdate();
            UpdateState();
        }

        public virtual void FixedUpdateBehaviour(float scaledDeltaTime, float smoothDeltaTime, float unscaledDeltaTime)
        {
            // if (Target == null) return;
            // if (!Target.activeSelf) return;
            if (UpdateType != UpdateType.FixedUpdate) return;
            if (!IsPlaying || IsInGroup) return;
            ScaledDeltaTime = scaledDeltaTime;
            SmoothDeltaTime = smoothDeltaTime;
            UnscaledDeltaTime = unscaledDeltaTime;
            DeltaTime = (TimeScale ? (TimeSmooth ? SmoothDeltaTime : ScaledDeltaTime) : UnscaledDeltaTime) * SelfScale;

            Factor();
            if (IsDelay) return;
            TweenUpdate();
            UpdateState();
        }

        #endregion

        #region Mono Behaviour

        public virtual void Awake()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (AutoPlay != AutoPlayType.None)
            {
                SetStart();
            }

            if (AutoPlay == AutoPlayType.Awake)
            {
                Play();
            }
        }

        public virtual void OnEnable()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (AutoPlay == AutoPlayType.Enable)
            {
                SetStart();
                Play();
            }
        }

        public virtual void Start()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (AutoPlay == AutoPlayType.Start)
            {
                SetStart();
                Play();
            }
        }

        public virtual void OnDisable()
        {

        }

        public virtual void OnDestroy()
        {
            if (TweenManager.Ins != null)
            {
                TweenManager.Ins.Remove(this);
            }
        }

        public virtual void Reset()
        {
            ResetParameters();
            Param.ResetCallback();
            ResetProperties();
        }

        public virtual void ResetProperties()
        {
            Active = false;
            RunTime = 0f;
            IsPlaying = false;
            IsPause = false;
            IsPlayBackward = false;
            PlayCount = 0;
        }

        public virtual void  ResetParameters()
        {
            TweenAnimation = null;
            Param.Reset();
        }

        #endregion

        #region Quick Operation

        /// <summary>
        /// 设置当前状态值到 From
        /// </summary>
        internal virtual void SetCurrent2From()
        {

        }

        /// <summary>
        /// 设置当前状态值到 To
        /// </summary>
        internal virtual void SetCurrent2To()
        {

        }

        /// <summary>
        /// 设置 From 值到当前状态
        /// </summary>
        internal virtual void SetFrom2Current()
        {

        }

        /// <summary>
        /// 设置 To 值到当前状态
        /// </summary>
        internal virtual void SetTo2Current()
        {

        }

        #endregion
    }
}
