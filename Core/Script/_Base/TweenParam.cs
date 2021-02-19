/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenParam.cs
//  Info     : 插值动画参数
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Aya.Tween
{
    [Serializable]
    public partial class TweenParam
    {
        [SerializeEnum("TweenType")]
        public int Type = TweenType.None;

        [Tooltip("The unique identifier used to identify a tweener group.")]
        public string Identifier;

        #region Property

        #region From / To

        [Tooltip("From value. (float)")]
        public float FromFloat;

        [Tooltip("To value. (float)")]
        public float ToFloat;

        [Tooltip("From value. (Vector2)")]
        public Vector2 FromVector2;
        [Tooltip("To value. (Vector2)")]
        public Vector2 ToVector2;

        [Tooltip("From value. (Vector3)")]
        public Vector3 FromVector3;
        [Tooltip("To value. (Vector3)")]
        public Vector3 ToVector3;

        [Tooltip("From value. (Vector4)")]
        public Vector4 FromVector4;
        [Tooltip("To value. (Vector4)")]
        public Vector4 ToVector4;

        [Tooltip("From value. (Color)")]
        public Color FromColor;
        [Tooltip("To value. (Color)")]
        public Color ToColor;

        [Tooltip("From value. (Quaternion)")]
        public Quaternion FromQuaternion;
        [Tooltip("To value. (Quaternion)")]
        public Quaternion ToQuaternion;

        [Tooltip("From value. (Rect)")]
        public Rect FromRect;
        [Tooltip("To value. (Rect)")]
        public Rect ToRect;

        [Tooltip("From value. (Transform)")]
        public Transform FromTransform;
        [Tooltip("To value. (Transform)")]
        public Transform ToTransform;

        [Tooltip("From value. (string)")]
        public string FromStr;

        [Tooltip("To value. (string)")]
        public string ToStr;

        #endregion

        #region Queue

        public List<Vector3> QueueVector3 = new List<Vector3>();
        public List<Color> QueueColor = new List<Color>();

        #endregion

        #region Public

        [Tooltip("Curve mode Single / Independent, allow individual control of each axis.")]
        public CurveMode CurveMode = CurveMode.Single;
        [Tooltip("Curve evaluate result will act on witch target.")]
        public CurveTargetType CurveTarget = CurveTargetType.Factor;
        public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));
        public AnimationCurve CurveX = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));
        public AnimationCurve CurveY = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));
        public AnimationCurve CurveZ = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));
        public AnimationCurve CurveW = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));

        [Tooltip("Play type Once / Loop / PingPong.")]
        public PlayType PlayType = PlayType.Once;
        [Tooltip("Use built-in interpolation algorithm.")]
        [SerializeEnum("EaseType")]
        public int EaseType = Tween.EaseType.Linear;
        [Tooltip("Loop count number.")]
        public int LoopCount = 0;
        [Tooltip("Animation length, seconds.")]
        public float Duration = 1f;
        [Tooltip("Repeat  play mode interval time.")]
        public float Interval = 0f;
        [Tooltip("Will use duration value as speed.")]
        public bool SpeedBased = false;
        [Tooltip("Animation will be played after StartDelay seconds.")]
        public float StartDelay = 0f;
        public AutoPlayType AutoPlay = AutoPlayType.None;
        [Tooltip("Driven by MonoBehaviour life-cycle.")]
        public UpdateType UpdateType = UpdateType.Update;
        [Tooltip("Use Time.deltaTime / Time.unscaledDeltaTime.")]
        public bool TimeScale = true;
        [Tooltip("Use Time.smoothDeltaTime.")]
        public bool TimeSmooth = true;
        [Tooltip("Self timeScale, used to change play speed, but it will change the actually duration in the same time.")]
        public float SelfScale = 1f;
        [Tooltip("Auto destroy this component after play finished.")]
        public bool AutoKill = false;
        [Tooltip("Ues World Space / Local Space.")]
        public bool WorldSpace = true;
        [Tooltip("Ues color space.")]
        public ColorLerpMode ColorLerpMode = ColorLerpMode.RGB;
        [Tooltip("UGUI ColorBlock Type.")]
        public ColorBlockType ColorBlockType = ColorBlockType.NormalColor;
        [Tooltip("Path P2P / CatmullRom Curve.")]
        public PathMode PathMode = PathMode.PointToPoint;
        public TweenShakeArgs ShakeArgs = new TweenShakeArgs();

        #endregion

        #region Resources Property

        [Tooltip("Reference resources index.")]
        public int ResourcesIndex;
        [Tooltip("Reference resources property key.")]
        public string ResourcesKey;

        #endregion

        #region Callback Event

        [FormerlySerializedAs("OnPlay")]
        [SerializeField]
        public OnPlayEvent OnPlay = new OnPlayEvent();

        [FormerlySerializedAs("OnStop")]
        [SerializeField]
        public OnStopEvent OnStop = new OnStopEvent();

        [FormerlySerializedAs("OnValueFloat")]
        [SerializeField]
        public OnFloatValueEvent OnValueFloat = new OnFloatValueEvent();

        [FormerlySerializedAs("OnValueVector2")]
        [SerializeField]
        public OnVector2ValueEvent OnValueVector2 = new OnVector2ValueEvent();

        [FormerlySerializedAs("OnValueVector3")]
        [SerializeField]
        public OnVector3ValueEvent OnValueVector3 = new OnVector3ValueEvent();

        [FormerlySerializedAs("OnValueVector4")]
        [SerializeField]
        public OnVector4ValueEvent OnValueVector4 = new OnVector4ValueEvent();

        [FormerlySerializedAs("OnValueColor")]
        [SerializeField]
        public OnColorValueEvent OnValueColor = new OnColorValueEvent();

        [FormerlySerializedAs("OnValueQuaternion")]
        [SerializeField]
        public OnQuaternionValueEvent OnValueQuaternion = new OnQuaternionValueEvent();

        [FormerlySerializedAs("OnValueRect")]
        [SerializeField]
        public OnRectValueEvent OnValueRect = new OnRectValueEvent();

        [FormerlySerializedAs("OnValueString")]
        [SerializeField]
        public OnStringValueEvent OnValueString = new OnStringValueEvent();

        public virtual void InitCallback()
        {
            OnPlay.Init();
            OnStop.Init();
            OnValueFloat.Init();
            OnValueVector2.Init();
            OnValueVector3.Init();
            OnValueVector4.Init();
            OnValueColor.Init();
            OnValueQuaternion.Init();
            OnValueRect.Init();
            OnValueString.Init();
        }

        public virtual void ResetCallback()
        {
            OnPlay.RemoveAllListeners();
            OnStop.RemoveAllListeners();
            OnValueFloat.RemoveAllListeners();
            OnValueVector2.RemoveAllListeners();
            OnValueVector3.RemoveAllListeners();
            OnValueVector4.RemoveAllListeners();
            OnValueColor.RemoveAllListeners();
            OnValueQuaternion.RemoveAllListeners();
            OnValueRect.RemoveAllListeners();
            OnValueString.RemoveAllListeners();
        }

        #endregion 

        #endregion

        #region Reset

        public void Reset()
        {
            ResetValue();
            ResetCallback();
        }

        public void ResetValue()
        {
            Type = TweenType.None;
            Identifier = "";

            FromFloat = 0f;
            ToFloat = 1f;
            FromVector2 = Vector2.zero;
            ToVector2 = Vector2.one;
            FromVector3 = Vector3.zero;
            ToVector3 = Vector3.one;
            FromVector4 = Vector4.zero;
            ToVector4 = Vector4.one;
            FromColor = Color.black;
            ToColor = Color.white;
            FromQuaternion = Quaternion.identity;
            ToQuaternion = Quaternion.identity;
            FromRect = Rect.zero;
            ToRect = Rect.zero;
            FromTransform = null;
            ToTransform = null;

            QueueVector3.Clear();
            QueueColor.Clear();

            CurveMode = CurveMode.Single;
            CurveTarget = CurveTargetType.Factor;
            Curve = TweenSetting.Ins.DefaultCurve;
            CurveX = TweenSetting.Ins.DefaultCurve;
            CurveY = TweenSetting.Ins.DefaultCurve;
            CurveZ = TweenSetting.Ins.DefaultCurve;
            CurveW = TweenSetting.Ins.DefaultCurve;

            PlayType = PlayType.Once;
            EaseType = TweenSetting.Ins.DefaultEaseType;
            LoopCount = 0;
            Duration = 1f;
            Interval = 0f;
            SpeedBased = false;
            StartDelay = 0f;
            AutoPlay = TweenSetting.Ins.DefaultAutoPlayType;
            UpdateType = TweenSetting.Ins.DefaultUpdateType;
            TimeScale = TweenSetting.Ins.DefaultTimeScale;
            TimeSmooth = TweenSetting.Ins.DefaultTimeSmooth;
            SelfScale = 1f;
            AutoKill = false;

            WorldSpace = true;
            ColorLerpMode = ColorLerpMode.RGB;
            ColorBlockType = ColorBlockType.NormalColor;
            PathMode = PathMode.PointToPoint;
            ShakeArgs = new TweenShakeArgs();

            ResourcesIndex = 0;
            ResourcesKey = "";
        }

        #endregion

        #region Copy To

        public void CopyTo(TweenParam param)
        {
            param.Type = Type;
            param.Identifier = Identifier;

            CopyFromToValueTo(param);

            param.CurveMode = CurveMode;
            param.CurveTarget = CurveTarget;
            param.Curve = Curve;
            param.CurveX = CurveX;
            param.CurveY = CurveY;
            param.CurveZ = CurveZ;
            param.CurveW = CurveW;

            param.PlayType = PlayType;
            param.EaseType = EaseType;
            param.LoopCount = LoopCount;
            param.Duration = Duration;
            param.Interval = Interval;
            param.SpeedBased = SpeedBased;
            param.StartDelay = StartDelay;
            param.AutoPlay = AutoPlay;
            param.UpdateType = UpdateType;
            param.TimeScale = TimeScale;
            param.TimeSmooth = TimeSmooth;
            param.SelfScale = SelfScale;
            param.AutoKill = AutoKill;

            param.WorldSpace = WorldSpace;
            param.ColorLerpMode = ColorLerpMode;
            param.ColorBlockType = ColorBlockType;
            param.PathMode = PathMode;
            param.ShakeArgs = ShakeArgs;

            param.ResourcesIndex = ResourcesIndex;
            param.ResourcesKey = ResourcesKey;

            param.OnPlay = OnPlay;
            param.OnStop = OnStop;
            param.OnValueFloat = OnValueFloat;
            param.OnValueVector2 = OnValueVector2;
            param.OnValueVector3 = OnValueVector3;
            param.OnValueColor = OnValueColor;
        }

        public void CopyFromToValueTo(TweenParam param)
        {
            param.FromFloat = FromFloat;
            param.ToFloat = ToFloat;

            param.FromVector2 = FromVector2;
            param.ToVector2 = ToVector2;

            param.FromVector3 = FromVector3;
            param.ToVector3 = ToVector3;

            param.FromVector4 = FromVector4;
            param.ToVector4 = ToVector4;

            param.FromColor = FromColor;
            param.ToColor = ToColor;

            param.FromQuaternion = FromQuaternion;
            param.ToQuaternion = ToQuaternion;

            param.FromRect = FromRect;
            param.ToRect = ToRect;

            param.QueueVector3 = QueueVector3;
            param.QueueColor = QueueColor;

            param.FromTransform = FromTransform;
            param.ToTransform = ToTransform;

            param.FromStr = FromStr;
            param.ToStr = ToStr;
        }

        #endregion

        #region Copy From

        public void CopyFrom(TweenParam param)
        {
            Type = param.Type;
            Identifier = param.Identifier;

            CopyFromToValueFrom(param);

            CurveMode = param.CurveMode;
            CurveTarget = param.CurveTarget;
            Curve = param.Curve;
            CurveX = param.CurveX;
            CurveY = param.CurveY;
            CurveZ = param.CurveZ;
            CurveW = param.CurveW;

            PlayType = param.PlayType;
            EaseType = param.EaseType;
            LoopCount = param.LoopCount;
            Duration = param.Duration;
            Interval = param.Interval;
            SpeedBased = param.SpeedBased;
            StartDelay = param.StartDelay;
            AutoPlay = param.AutoPlay;
            UpdateType = param.UpdateType;
            TimeScale = param.TimeScale;
            TimeSmooth = param.TimeSmooth;
            SelfScale = param.SelfScale;
            AutoKill = param.AutoKill;

            WorldSpace = param.WorldSpace;
            ColorLerpMode = param.ColorLerpMode;
            ColorBlockType = param.ColorBlockType;
            PathMode = param.PathMode;
            ShakeArgs = param.ShakeArgs;

            ResourcesIndex = param.ResourcesIndex;
            ResourcesKey = param.ResourcesKey;

            OnPlay = param.OnPlay;
            OnStop = param.OnStop;
            OnValueFloat = param.OnValueFloat;
            OnValueVector2 = param.OnValueVector2;
            OnValueVector3 = param.OnValueVector3;
            OnValueColor = param.OnValueColor;
        }

        public void CopyFromToValueFrom(TweenParam param)
        {
            FromFloat = param.FromFloat;
            ToFloat = param.ToFloat;

            FromVector2 = param.FromVector2;
            ToVector2 = param.ToVector2;

            FromVector3 = param.FromVector3;
            ToVector3 = param.ToVector3;

            FromVector4 = param.FromVector4;
            ToVector4 = param.ToVector4;

            FromColor = param.FromColor;
            ToColor = param.ToColor;

            FromQuaternion = param.FromQuaternion;
            ToQuaternion = param.ToQuaternion;

            FromRect = param.FromRect;
            ToRect = param.ToRect;

            QueueVector3 = param.QueueVector3;
            QueueColor = param.QueueColor;

            FromTransform = param.FromTransform;
            ToTransform = param.ToTransform;

            FromStr = param.FromStr;
            ToStr = param.ToStr;
        }

        #endregion
    }
}
