/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenChainStyleExtension.cs
//  Info     : 插值动画 链式编程 扩展接口
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Aya.Tween
{
    public static class TweenChainStyleExtension
    {
        #region Set Callback

        public static T SetPlayCallback<T>(this T tween, Action onPlay) where T : Tweener
        {
            tween.OnPlay.AddListener(new UnityAction(onPlay));
            return tween;
        }

        public static T SetStopCallback<T>(this T tween, Action onStop) where T : Tweener
        {
            tween.OnStop.AddListener(new UnityAction(onStop));
            return tween;
        }

        public static T SetFloatCallback<T>(this T tween, Action<float> onValue) where T : Tweener<float>
        {
            tween.OnValueFloat.AddListener(new UnityAction<float>(onValue));
            return tween;
        }

        public static T SetVector2Callback<T>(this T tween, Action<Vector2> onValue) where T : Tweener<Vector2>
        {
            tween.OnValueVector2.AddListener(new UnityAction<Vector2>(onValue));
            return tween;
        }

        public static T SetVector3Callback<T>(this T tween, Action<Vector3> onValue) where T : Tweener<Vector3>
        {
            tween.OnValueVector3.AddListener(new UnityAction<Vector3>(onValue));
            return tween;
        }

        public static T SetColorCallback<T>(this T tween, Action<Color> onValue) where T : Tweener<Color>
        {
            tween.OnValueColor.AddListener(new UnityAction<Color>(onValue));
            return tween;
        }

        public static T SetQuaternionCallback<T>(this T tween, Action<Quaternion> onValue) where T : Tweener<Quaternion>
        {
            tween.OnValueQuaternion.AddListener(new UnityAction<Quaternion>(onValue));
            return tween;
        }

        public static T SetRectCallback<T>(this T tween, Action<Rect> onValue) where T : Tweener<Rect>
        {
            tween.OnValueRect.AddListener(new UnityAction<Rect>(onValue));
            return tween;
        }

        public static T SetStringCallback<T>(this T tween, Action<string> onValue) where T : Tweener<string>
        {
            tween.OnValueString.AddListener(new UnityAction<string>(onValue));
            return tween;
        }

        #endregion

        #region Set Property

        public static T SetTarget<T>(this T tween, GameObject gameObject) where T : Tweener
        {
            tween.Target = gameObject;
            tween.Transform = gameObject.transform;
            return tween;
        }

        public static T SetIdentifier<T>(this T tween, string identifier) where T : Tweener
        {
            tween.Identifier = identifier;
            return tween;
        }

        public static T SetPlayType<T>(this T tween, PlayType playType) where T : Tweener
        {
            tween.PlayType = playType;
            return tween;
        }

        public static T SetUpdateType<T>(this T tween, UpdateType updateType) where T : Tweener
        {
            tween.UpdateType = updateType;
            return tween;
        }

        public static T SetEaseType<T>(this T tween, int easeType) where T : Tweener
        {
            tween.EaseType = easeType;
            return tween;
        }

        public static T SetCurveMode<T>(this T tween, CurveMode curveMode) where T : Tweener
        {
            tween.CurveMode = curveMode;
            return tween;
        }

        public static T SetCurveTarget<T>(this T tween, CurveTargetType targetType) where T : Tweener
        {
            tween.CurveTarget = targetType;
            return tween;
        }

        public static T SetAnimationCurve<T>(this T tween, AnimationCurve curve) where T : Tweener
        {
            tween.Curve = curve;
            return tween;
        }

        public static T SetAnimationCurveX<T>(this T tween, AnimationCurve curve) where T : Tweener
        {
            tween.CurveX = curve;
            return tween;
        }

        public static T SetAnimationCurveY<T>(this T tween, AnimationCurve curve) where T : Tweener
        {
            tween.CurveY = curve;
            return tween;
        }

        public static T SetAnimationCurveZ<T>(this T tween, AnimationCurve curve) where T : Tweener
        {
            tween.CurveZ = curve;
            return tween;
        }

        public static T SetAnimationCurveW<T>(this T tween, AnimationCurve curve) where T : Tweener
        {
            tween.CurveW = curve;
            return tween;
        }

        public static T SetLoopCount<T>(this T tween, int playCount) where T : Tweener
        {
            tween.LoopCount = playCount;
            return tween;
        }

        public static T SetDuration<T>(this T tween, float duration) where T : Tweener
        {
            tween.Duration = duration;
            tween.UpdateActualDuration();
            return tween;
        }

        public static T SetInterval<T>(this T tween, float interval) where T : Tweener
        {
            tween.Interval = interval;
            return tween;
        }

        public static T SetSpeedBased<T>(this T tween, bool speedBased = true) where T : Tweener
        {
            if (!tween.SupportSpeedBased) return tween;
            tween.SpeedBased = speedBased;
            tween.UpdateActualDuration();
            return tween;
        }

        public static T SetStartDelay<T>(this T tween, float startDelay) where T : Tweener
        {
            tween.StartDelay = startDelay;
            return tween;
        }

        public static T SetAutoPlayType<T>(this T tween, AutoPlayType autoPlayType) where T : Tweener
        {
            tween.AutoPlay = autoPlayType;
            return tween;
        }

        public static T SetTimeScale<T>(this T tween, bool timeScale) where T : Tweener
        {
            tween.TimeScale = timeScale;
            return tween;
        }

        public static T SetTimeSmooth<T>(this T tween, bool timeSmooth) where T : Tweener
        {
            tween.TimeSmooth = timeSmooth;
            return tween;
        }

        public static T SetSelfScale<T>(this T tween, float selfScale) where T : Tweener
        {
            tween.SelfScale = selfScale;
            return tween;
        }

        public static T SetAutoKill<T>(this T tween, bool autoKill) where T : Tweener
        {
            tween.AutoKill = autoKill;
            return tween;
        }

        public static T SetWorldSpace<T>(this T tween, bool isWorldSpace) where T : Tweener<Vector3>
        {
            tween.WorldSpace = isWorldSpace;
            return tween;
        }

        public static T SetResourceIndex<T>(this T tween, int resourcesIndex) where T : Tweener
        {
            tween.ResourcesIndex = resourcesIndex;
            return tween;
        }

        public static T SetResourceKey<T>(this T tween, string resourcesKey) where T : Tweener
        {
            tween.ResourcesKey = resourcesKey;
            return tween;
        }

        #endregion

        #region Set From / To

        public static T SetFrom<T>(this T tween, float from) where T : Tweener<float>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, float to) where T : Tweener<float>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Vector2 from) where T : Tweener<Vector2>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Vector2 to) where T : Tweener<Vector2>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Vector3 from) where T : Tweener<Vector3>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Vector3 to) where T : Tweener<Vector3>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Vector4 from) where T : Tweener<Vector4>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Vector4 to) where T : Tweener<Vector4>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Color from) where T : Tweener<Color>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Color to) where T : Tweener<Color>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Quaternion from) where T : Tweener<Quaternion>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Quaternion to) where T : Tweener<Quaternion>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Rect from) where T : Tweener<Rect>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Rect to) where T : Tweener<Rect>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Transform from) where T : Tweener<Transform>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Transform to) where T : Tweener<Transform>
        {
            tween.To = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, string from) where T : Tweener<string>
        {
            tween.From = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, string to) where T : Tweener<string>
        {
            tween.To = to;
            return tween;
        }

        #endregion

        #region Set Setter

        public static T SetSetter<T>(this T tween, Action<float> setter) where T : Tweener<float>
        {
            tween.Setter = setter;
            return tween;
        }

        public static T SetSetter<T>(this T tween, Action<Vector2> setter) where T : Tweener<Vector2>
        {
            tween.Setter = setter;
            return tween;
        }

        public static T SetSetter<T>(this T tween, Action<Vector3> setter) where T : Tweener<Vector3>
        {
            tween.Setter = setter;
            return tween;
        }

        public static T SetSetter<T>(this T tween, Action<Vector4> setter) where T : Tweener<Vector4>
        {
            tween.Setter = setter;
            return tween;
        }

        public static T SetSetter<T>(this T tween, Action<Color> setter) where T : Tweener<Color>
        {
            tween.Setter = setter;
            return tween;
        }

        public static T SetSetter<T>(this T tween, Action<Quaternion> setter) where T : Tweener<Quaternion>
        {
            tween.Setter = setter;
            return tween;
        }

        public static T SetSetter<T>(this T tween, Action<Rect> setter) where T : Tweener<Rect>
        {
            tween.Setter = setter;
            return tween;
        }

        public static T SetSetter<T>(this T tween, Action<Transform> setter) where T : Tweener<Transform>
        {
            tween.Setter = setter;
            return tween;
        }

        #endregion

        #region Set FromGetter / ToGetter

        public static T SetFromGetter<T>(this T tween, Func<float> fromGetter) where T : Tweener<float>
        {
            tween.FromGetter = fromGetter;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<float> toGetter) where T : Tweener<float>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        public static T SetFromGetter<T>(this T tween, Func<Vector2> fromGetter) where T : Tweener<Vector2>
        {
            tween.FromGetter = fromGetter;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<Vector2> toGetter) where T : Tweener<Vector2>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        public static T SetFromGetter<T>(this T tween, Func<Vector3> from) where T : Tweener<Vector3>
        {
            tween.FromGetter = from;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<Vector3> toGetter) where T : Tweener<Vector3>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        public static T SetFromGetter<T>(this T tween, Func<Vector4> fromGetter) where T : Tweener<Vector4>
        {
            tween.FromGetter = fromGetter;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<Vector4> toGetter) where T : Tweener<Vector4>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        public static T SetFromGetter<T>(this T tween, Func<Color> fromGetter) where T : Tweener<Color>
        {
            tween.FromGetter = fromGetter;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<Color> toGetter) where T : Tweener<Color>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        public static T SetFromGetter<T>(this T tween, Func<Quaternion> fromGetter) where T : Tweener<Quaternion>
        {
            tween.FromGetter = fromGetter;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<Quaternion> toGetter) where T : Tweener<Quaternion>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        public static T SetFromGetter<T>(this T tween, Func<Rect> fromGetter) where T : Tweener<Rect>
        {
            tween.FromGetter = fromGetter;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<Rect> toGetter) where T : Tweener<Rect>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        public static T SetFromGetter<T>(this T tween, Func<Transform> fromGetter) where T : Tweener<Transform>
        {
            tween.FromGetter = fromGetter;
            return tween;
        }

        public static T SetToGetter<T>(this T tween, Func<Transform> toGetter) where T : Tweener<Transform>
        {
            tween.ToGetter = toGetter;
            return tween;
        }

        #endregion

        #region Tween Shake

        public static T SetShakeArgs<T>(this T tween, TweenShakeArgs args) where T : TweenShake
        {
            tween.ShakeArgs = args;
            return tween;
        }

        public static T SetShakePosition<T>(this T tween, bool enable) where T : TweenShake
        {
            tween.ShakeArgs.ShakePos = enable;
            return tween;
        }

        public static T SetShakePosition<T>(this T tween, Vector3 power) where T : TweenShake
        {
            tween.ShakeArgs.ShakePos = true;
            tween.ShakeArgs.PowerPos = power;
            return tween;
        }

        public static T SetShakeRotation<T>(this T tween, bool enable) where T : TweenShake
        {
            tween.ShakeArgs.ShakeRot = enable;
            return tween;
        }

        public static T SetShakeRotation<T>(this T tween, Vector3 power) where T : TweenShake
        {
            tween.ShakeArgs.ShakeRot = true;
            tween.ShakeArgs.PowerRot = power;
            return tween;
        }

        public static T SetShakeScale<T>(this T tween, bool enable) where T : TweenShake
        {
            tween.ShakeArgs.ShakeScale = enable;
            return tween;
        }

        public static T SetShakeScale<T>(this T tween, Vector3 power) where T : TweenShake
        {
            tween.ShakeArgs.ShakeScale = true;
            tween.ShakeArgs.PowerScale = power;
            return tween;
        }

        public static T SetShakeCount<T>(this T tween, int count) where T : TweenShake
        {
            tween.ShakeArgs.Count = count;
            return tween;
        }

        #endregion

        #region Tween Queue

        public static T SetPathMode<T, TComponent>(this T tween, PathMode pathMode) where T : TweenQueueVector3Base<TComponent> where TComponent : Component
        {
            tween.PathMode = pathMode;
            return tween;
        }

        public static T PushIntoQueue<T, TValue, TComponent>(this T tween, TValue value) where T : TweenQueueBase<TValue, TComponent> where TComponent : Component
        {
            tween.Queue.Add(value);
            return tween;
        }

        public static T ClearQueue<T, TValue, TComponent>(this T tween, TValue value) where T : TweenQueueBase<TValue, TComponent> where TComponent : Component
        {
            tween.Queue.Clear();
            return tween;
        }

        #endregion
    }
}
