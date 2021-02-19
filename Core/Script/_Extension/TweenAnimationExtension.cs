/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenAnimationExtension.cs
//  Info     : 插值动画 TweenAnimation 扩展接口
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Aya.Tween
{
    public static class TweenAnimationExtension
    {
        #region Get

        public static Tweener GetTweener(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            return tweener;
        } 

        #endregion

        #region Play / Pause / Resume / Stop

        public static Tweener Play(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.Play();
            return tweener;
        }

        public static Tweener PlayBackward(this TweenAnimation tweenAnimation, bool immediately = false)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.PlayBackward(immediately);
            return tweener;
        }

        public static Tweener PlayBackwardImmediately(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.PlayBackward(true);
            return tweener;
        }

        public static Tweener Pause(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.Pause();
            return tweener;
        }

        public static Tweener Resume(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.Resume();
            return tweener;
        }

        public static Tweener TogglePause(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.TogglePause();
            return tweener;
        }

        public static Tweener Stop(this TweenAnimation tweenAnimation, bool destroy = true)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.Stop(destroy);
            return tweener;
        }

        public static Tweener Restart(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.Restart();
            return tweener;
        }

        #endregion

        #region  Set Status

        public static Tweener SetStart(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.SetStart();
            return tweener;
        }

        public static Tweener SetEnd(this TweenAnimation tweenAnimation)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.SetEnd();
            return tweener;
        }

        public static Tweener SetSchedule(this TweenAnimation tweenAnimation, float schedule)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.SetSchedule(schedule);
            return tweener;
        }

        public static Tweener SetScheduleByRunTime(this TweenAnimation tweenAnimation, float runTime)
        {
            var tweener = tweenAnimation.Tweener ?? tweenAnimation.CreateTweener();
            tweener.SetScheduleByRunTime(runTime);
            return tweener;
        }

        #endregion

        #region Chain Style

        #region Set Callback

        public static T SetPlayCallback<T>(this T tweenAnimation, Action onPlay) where T : TweenAnimation
        {
            tweenAnimation.OnPlay.AddListener(new UnityAction(onPlay));
            return tweenAnimation;
        }

        public static T SetStopCallback<T>(this T tweenAnimation, Action onStop) where T : TweenAnimation
        {
            tweenAnimation.OnStop.AddListener(new UnityAction(onStop));
            return tweenAnimation;
        }

        public static T SetFloatCallback<T>(this T tweenAnimation, Action<float> onValue) where T : TweenAnimation
        {
            tweenAnimation.OnValueFloat.AddListener(new UnityAction<float>(onValue));
            return tweenAnimation;
        }

        public static T SetVector2Callback<T>(this T tweenAnimation, Action<Vector2> onValue) where T : TweenAnimation
        {
            tweenAnimation.OnValueVector2.AddListener(new UnityAction<Vector2>(onValue));
            return tweenAnimation;
        }

        public static T SetVector3Callback<T>(this T tween, Action<Vector3> onValue) where T : TweenAnimation
        {
            tween.OnValueVector3.AddListener(new UnityAction<Vector3>(onValue));
            return tween;
        }

        public static T SetVector4Callback<T>(this T tween, Action<Vector4> onValue) where T : TweenAnimation
        {
            tween.OnValueVector4.AddListener(new UnityAction<Vector4>(onValue));
            return tween;
        }

        public static T SetColorCallback<T>(this T tween, Action<Color> onValue) where T : TweenAnimation
        {
            tween.OnValueColor.AddListener(new UnityAction<Color>(onValue));
            return tween;
        }

        // public static T SetQuaternionCallback<T>(this T tween, Action<Quaternion> onValue) where T : Tweener<Quaternion>
        // {
        //     tween.OnValueQuaternion.AddListener(new UnityAction<Quaternion>(onValue));
        //     return tween;
        // }

        // public static T SetRectCallback<T>(this T tween, Action<Rect> onValue) where T : Tweener<Rect>
        // {
        //     tween.OnValueRect.AddListener(new UnityAction<Rect>(onValue));
        //     return tween;
        // }

        #endregion

        #region Set Property

        public static T SetIdentifier<T>(this T tween, string identifier) where T : TweenAnimation
        {
            tween.Identifier = identifier;
            return tween;
        }

        public static T SetPlayType<T>(this T tween, PlayType playType) where T : TweenAnimation
        {
            tween.PlayType = playType;
            return tween;
        }

        public static T SetUpdateType<T>(this T tween, UpdateType updateType) where T : TweenAnimation
        {
            tween.UpdateType = updateType;
            return tween;
        }

        public static T SetEaseType<T>(this T tween, int easeType) where T : TweenAnimation
        {
            tween.EaseType = easeType;
            return tween;
        }

        public static T SetCurveMode<T>(this T tween, CurveMode curveMode) where T : TweenAnimation
        {
            tween.CurveMode = curveMode;
            return tween;
        }

        public static T SetCurveTarget<T>(this T tween, CurveTargetType targetType) where T : TweenAnimation
        {
            tween.CurveTarget = targetType;
            return tween;
        }

        public static T SetAnimationCurve<T>(this T tween, AnimationCurve curve) where T : TweenAnimation
        {
            tween.Curve = curve;
            return tween;
        }

        public static T SetAnimationCurveX<T>(this T tween, AnimationCurve curve) where T : TweenAnimation
        {
            tween.CurveX = curve;
            return tween;
        }

        public static T SetAnimationCurveY<T>(this T tween, AnimationCurve curve) where T : TweenAnimation
        {
            tween.CurveY = curve;
            return tween;
        }

        public static T SetAnimationCurveZ<T>(this T tween, AnimationCurve curve) where T : TweenAnimation
        {
            tween.CurveZ = curve;
            return tween;
        }

        public static T SetLoopCount<T>(this T tween, int playCount) where T : TweenAnimation
        {
            tween.LoopCount = playCount;
            return tween;
        }

        public static T SetDuration<T>(this T tween, float duration) where T : TweenAnimation
        {
            tween.Duration = duration;
            return tween;
        }

        public static T SetStartDelay<T>(this T tween, float startDelay) where T : TweenAnimation
        {
            tween.StartDelay = startDelay;
            return tween;
        }

        public static T SetAutoPlayType<T>(this T tween, AutoPlayType autoPlayType) where T : TweenAnimation
        {
            tween.AutoPlay = autoPlayType;
            return tween;
        }

        public static T SetTimeScale<T>(this T tween, bool timeScale) where T : TweenAnimation
        {
            tween.TimeScale = timeScale;
            return tween;
        }

        public static T SetTimeSmooth<T>(this T tween, bool timeSmooth) where T : TweenAnimation
        {
            tween.TimeSmooth = timeSmooth;
            return tween;
        }

        public static T SetSelfScale<T>(this T tween, float selfScale) where T : TweenAnimation
        {
            tween.SelfScale = selfScale;
            return tween;
        }

        public static T SetAutoKill<T>(this T tween, bool autoKill) where T : TweenAnimation
        {
            tween.AutoKill = autoKill;
            return tween;
        }

        #endregion

        #region Set From / To

        public static T SetFrom<T>(this T tween, float from) where T : TweenAnimation
        {
            tween.FromFloat = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, float to) where T : TweenAnimation
        {
            tween.ToFloat = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Vector2 from) where T : TweenAnimation
        {
            tween.FromVector2 = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Vector2 to) where T : TweenAnimation
        {
            tween.ToVector2 = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Vector3 from) where T : TweenAnimation
        {
            tween.FromVector3 = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Vector3 to) where T : TweenAnimation
        {
            tween.ToVector3 = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Vector4 from) where T : TweenAnimation
        {
            tween.FromVector4 = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Vector4 to) where T : TweenAnimation
        {
            tween.ToVector4 = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Color from) where T : TweenAnimation
        {
            tween.FromColor = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Color to) where T : TweenAnimation
        {
            tween.ToColor = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Quaternion from) where T : TweenAnimation
        {
            tween.FromQuaternion = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Quaternion to) where T : TweenAnimation
        {
            tween.ToQuaternion = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Rect from) where T : TweenAnimation
        {
            tween.FromRect = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Rect to) where T : TweenAnimation
        {
            tween.ToRect = to;
            return tween;
        }

        public static T SetFrom<T>(this T tween, Transform from) where T : TweenAnimation
        {
            tween.FromTransform = from;
            return tween;
        }

        public static T SetTo<T>(this T tween, Transform to) where T : TweenAnimation
        {
            tween.ToTransform = to;
            return tween;
        }

        #endregion

        #region Tween Shake

        public static T SetShakeArgs<T>(this T tween, TweenShakeArgs args) where T : TweenAnimation
        {
            tween.ShakeArgs = args;
            return tween;
        }

        public static T SetShakePosition<T>(this T tween, bool enable) where T : TweenAnimation
        {
            tween.ShakeArgs.ShakePos = enable;
            return tween;
        }

        public static T SetShakePosition<T>(this T tween, Vector3 power) where T : TweenAnimation
        {
            tween.ShakeArgs.ShakePos = true;
            tween.ShakeArgs.PowerPos = power;
            return tween;
        }

        public static T SetShakeRotation<T>(this T tween, bool enable) where T : TweenAnimation
        {
            tween.ShakeArgs.ShakeRot = enable;
            return tween;
        }

        public static T SetShakeRotation<T>(this T tween, Vector3 power) where T : TweenAnimation
        {
            tween.ShakeArgs.ShakeRot = true;
            tween.ShakeArgs.PowerRot = power;
            return tween;
        }

        public static T SetShakeScale<T>(this T tween, bool enable) where T : TweenAnimation
        {
            tween.ShakeArgs.ShakeScale = enable;
            return tween;
        }

        public static T SetShakeScale<T>(this T tween, Vector3 power) where T : TweenAnimation
        {
            tween.ShakeArgs.ShakeScale = true;
            tween.ShakeArgs.PowerScale = power;
            return tween;
        }

        public static T SetShakeCount<T>(this T tween, int count) where T : TweenAnimation
        {
            tween.ShakeArgs.Count = count;
            return tween;
        }

        #endregion 

        #endregion
    }
}
