/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenIEnumerableExtension.cs
//  Info     : 插值动画 Enumerable 扩展接口
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace Aya.Tween
{
    public static class TweenIEnumerableExtension
    {
        #region ForEach

        public static void ForEach<T>(this IEnumerable<T> tweeners, Action<T> action) where T : Tweener
        {
            foreach (var tweener in tweeners)
            {
                action(tweener);
            }
        }

        #endregion

        #region Play / Pause / Resume / Stop

        public static void Play<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.Play());
        }

        public static void PlayBackward<T>(this IEnumerable<T> tweeners, bool immediately = false) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.PlayBackward(immediately));
        }

        public static void PlayBackwardImmediately<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.PlayBackward(true));
        }

        public static void Pause<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.Pause());
        }

        public static void TogglePause<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.TogglePause());
        }

        public static void Resume<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.Resume());
        }

        public static void Stop<T>(this IEnumerable<T> tweeners, bool destroy = true) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.Stop(destroy));
        }

        public static void Restart<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.Restart());
        }

        #endregion

        #region Set Status

        public static void SetStart<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.SetStart());
        }

        public static void SetEnd<T>(this IEnumerable<T> tweeners) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.SetEnd());
        }

        public static void SetSchedule<T>(this IEnumerable<T> tweeners, float schedule) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.SetSchedule(schedule));
        }

        public static void SetScheduleByRunTime<T>(this IEnumerable<T> tweeners, float runTime) where T : Tweener
        {
            tweeners.ForEach(tweener => tweener.SetScheduleByRunTime(runTime));
        }

        #endregion
    }
}