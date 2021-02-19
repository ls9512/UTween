/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTransformExtension.cs
//  Info     : 插值动画 Transform 扩展接口
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;

namespace Aya.Tween
{
    public static class TweenTransformExtension
    {
        #region Get Tweener

        public static TweenAnimation GetTweenAnimation(this Transform transform, bool includeInactive = true)
        {
            var animation = transform.GetComponentInChildren<TweenAnimation>(includeInactive);
            return animation;
        }

        public static Tweener GetTweener(this Transform transform)
        {
            var animation = transform.GetComponentInChildren<TweenAnimation>();
            if (animation.Tweener == null)
            {
                animation.CreateTweenerRuntime();
            }

            return animation.Tweener;
        }

        public static Tweener GetTweener(this Transform transform, string identifier)
        {
            var result = GetTweeners(transform, tweener => tweener.Identifier == identifier);
            return result.Length > 0 ? result[0] : default(Tweener);
        }

        public static Tweener GetTweener(this Transform transform, Predicate<Tweener> predicate)
        {
            var result = GetTweeners(transform, predicate);
            return result.Length > 0 ? result[0] : default(Tweener);
        }

        public static T GetTweener<T>(this Transform transform) where T : Tweener
        {
            var result = transform.GetTweeners<T>();
            return result.Length > 0 ? result[0] : default(T);
        }

        #endregion

        #region Get Tweeners

        public static TweenAnimation[] GetTweenAnimations(this Transform transform, bool includeInactive = true)
        {
            var animations = transform.GetComponentsInChildren<TweenAnimation>(includeInactive);
            return animations;
        }

        public static Tweener[] GetTweeners(this Transform transform)
        {
            var animations = transform.GetComponentsInChildren<TweenAnimation>();
            var tweeners = new Tweener[animations.Length];
            for (var i = 0; i < animations.Length; i++)
            {
                var animation = animations[i];
                if (animation.Tweener == null)
                {
                    animation.CreateTweenerRuntime();
                }
                tweeners[i] = animation.Tweener;
            }

            return tweeners;
        }

        public static Tweener[] GetTweeners(this Transform transform, string identifier)
        {
            var result = GetTweeners(transform, tweener => tweener.Identifier == identifier);
            return result;
        }

        public static Tweener[] GetTweeners(this Transform transform, Predicate<Tweener> predicate)
        {
            var allTweeners = transform.GetTweeners();
            var tweeners = new Tweener[allTweeners.Length];
            var length = 0;
            for (var i = 0; i < allTweeners.Length; i++)
            {
                var tweener = allTweeners[i];
                if (!predicate(tweener)) continue;
                tweeners[length] = tweener;
                length++;
            }

            var result = new Tweener[length];

            if (tweeners.Length > 0)
            {
                Array.Copy(tweeners, result, length);
            }

            return result;
        }

        public static T[] GetTweeners<T>(this Transform transform) where T : Tweener
        {
            var allTweeners = transform.GetTweeners();
            var tweeners = new Tweener[allTweeners.Length];
            var length = 0;
            for (var i = 0; i < allTweeners.Length; i++)
            {
                var tweener = allTweeners[i];
                if (tweener.GetType() != typeof(T)) continue;
                tweeners[length] = tweener;
                length++;
            }

            var result = new T[length];

            if (tweeners.Length > 0)
            {
                Array.Copy(tweeners, result, length);
            }

            return result;
        }

        #endregion

        #region Move

        public static TweenPosition Move(this Transform transform, Vector3 to, float duration, bool worldSpace = true)
        {
            var from = transform.position;
            var tween = Move(transform, from, to, duration, worldSpace);
            return tween;
        }

        public static TweenPosition Move(this Transform transform, Vector3 from, Vector3 to, float duration, bool worldSpace = true)
        {
            var tween = UTween.Position(transform, from, to, duration, worldSpace);
            return tween;
        }

        #endregion

        #region Rotate

        public static TweenRotation Rotate(this Transform transform, Vector3 to, float duration, bool worldSpace = true)
        {
            var from = transform.eulerAngles;
            var tween = Rotate(transform, from, to, duration, worldSpace);
            return tween;
        }

        public static TweenRotation Rotate(this Transform transform, Vector3 from, Vector3 to, float duration, bool worldSpace = true)
        {
            var tween = UTween.Rotation(transform, from, to, duration, worldSpace);
            return tween;
        }

        public static TweenRotation Rotate(this Transform transform, Quaternion to, float duration, bool worldSpace = true)
        {
            var from = transform.rotation;
            var tween = Rotate(transform, from, to, duration, worldSpace);
            return tween;
        }

        public static TweenRotation Rotate(this Transform transform, Quaternion from, Quaternion to, float duration, bool worldSpace = true)
        {
            var eulerFrom = from.eulerAngles;
            var eulerTo = to.eulerAngles;
            var tween = UTween.Rotation(transform, eulerFrom, eulerTo, duration, worldSpace);
            return tween;
        }

        #endregion

        #region Scale

        public static TweenScale Scale(this Transform transform, Vector3 to, float duration)
        {
            var from = transform.localScale;
            var tween = Scale(transform, from, to, duration);
            return tween;
        }

        public static TweenScale Scale(this Transform transform, Vector3 from, Vector3 to, float duration)
        {
            var tween = UTween.Scale(transform, from, to, duration);
            return tween;
        }

        #endregion

        #region Shake

        public static TweenShake Shake(this Transform transform, float powerPos, float powerRot, float powerScale, int count, float duration, bool worldSpace = true)
        {
            var tween = UTween.Shake(transform, powerPos, powerRot, powerScale, count, duration, worldSpace);
            return tween;
        }

        public static TweenShake Shake(this Transform transform, Vector3 powerPos, Vector3 powerRot, Vector3 powerScale, int count, float duration, bool worldSpace = true)
        {
            var tween = UTween.Shake(transform, powerPos, powerRot, powerScale, count, duration, worldSpace);
            return tween;
        }

        public static TweenShake Shake(this Transform transform, TweenShakeArgs shakeArgs, float duration, bool worldSpace = true)
        {
            var tween = UTween.Shake(transform, shakeArgs, duration, worldSpace);
            return tween;
        } 
        
        #endregion
    }
}
