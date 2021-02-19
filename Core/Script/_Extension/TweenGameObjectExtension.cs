/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenGameObjectExtension.cs
//  Info     : 插值动画 GameObject 扩展方法
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;

namespace Aya.Tween
{
    public static class TweenGameObjectExtension
    {
        #region Get Tweener

        public static TweenAnimation GetTweenAnimation(this GameObject gameObject, bool includeInactive = true)
        {
            return gameObject.transform.GetTweenAnimation(includeInactive);
        }

        public static Tweener GetTweener(this GameObject gameObject)
        {
            return gameObject.transform.GetTweener();
        }

        public static Tweener GetTweener(this GameObject gameObject, string identifier)
        {
            return gameObject.transform.GetTweener(identifier);
        }

        public static Tweener GetTweener(this GameObject gameObject, Predicate<Tweener> predicate)
        {
            return gameObject.transform.GetTweener(predicate);
        }

        public static T GetTweener<T>(this GameObject gameObject) where T : Tweener
        {
            return gameObject.transform.GetTweener<T>();
        }

        #endregion

        #region Get Tweeners

        public static TweenAnimation[] GetTweenAnimations(this GameObject gameObject, bool includeInactive = true)
        {
            return gameObject.transform.GetComponentsInChildren<TweenAnimation>(includeInactive);
        }

        public static Tweener[] GetTweeners(this GameObject gameObject)
        {
            return gameObject.transform.GetTweeners();
        }

        public static Tweener[] GetTweeners(this GameObject gameObject, string identifier)
        {
            return gameObject.transform.GetTweeners(identifier);
        }

        public static Tweener[] GetTweeners(this GameObject gameObject, Predicate<Tweener> predicate)
        {
            return gameObject.transform.GetTweeners(predicate);
        }

        public static T[] GetTweeners<T>(this GameObject gameObject) where T : Tweener
        {
            return gameObject.transform.GetTweeners<T>();
        }

        #endregion
    }
}
