/////////////////////////////////////////////////////////////////////////////
//
//  Script   : MonoBehaviourExtension.cs
//  Info     : 插值动画 MonoBehaviour 扩展方法
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;

namespace Aya.Tween
{
    public static class TweenMonoBehaviourExtension
    {
        #region Get Tweener

        public static TweenAnimation GetTweenAnimation(this MonoBehaviour monoBehaviour, bool includeInactive = true)
        {
            return monoBehaviour.transform.GetTweenAnimation(includeInactive);
        }

        public static Tweener GetTweener(this MonoBehaviour monoBehaviour)
        {
            return monoBehaviour.transform.GetTweener();
        }

        public static Tweener GetTweener(this MonoBehaviour monoBehaviour, string identifier)
        {
            return monoBehaviour.transform.GetTweener(identifier);
        }

        public static Tweener GetTweener(this MonoBehaviour monoBehaviour, Predicate<Tweener> predicate)
        {
            return monoBehaviour.transform.GetTweener(predicate);
        }

        public static T GetTweener<T>(this MonoBehaviour monoBehaviour) where T : Tweener
        {
            return monoBehaviour.transform.GetTweener<T>();
        }

        #endregion

        #region Get Tweeners

        public static TweenAnimation[] GetTweenAnimations(this MonoBehaviour monoBehaviour, bool includeInactive = true)
        {
            return monoBehaviour.transform.GetComponentsInChildren<TweenAnimation>(includeInactive);
        }

        public static Tweener[] GetTweeners(this MonoBehaviour monoBehaviour)
        {
            return monoBehaviour.transform.GetTweeners();
        }

        public static Tweener[] GetTweeners(this MonoBehaviour monoBehaviour, string identifier)
        {
            return monoBehaviour.transform.GetTweeners(identifier);
        }

        public static Tweener[] GetTweeners(this MonoBehaviour monoBehaviour, Predicate<Tweener> predicate)
        {
            return monoBehaviour.transform.GetTweeners(predicate);
        }

        public static T[] GetTweeners<T>(this MonoBehaviour monoBehaviour) where T : Tweener
        {
            return monoBehaviour.transform.GetTweeners<T>();
        }

        #endregion
    }
}
