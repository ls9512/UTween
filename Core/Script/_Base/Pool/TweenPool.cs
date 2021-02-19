/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPool.cs
//  Info     : 插值组件缓存池
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace Aya.Tween
{
    internal class TweenPool
    {
        public Dictionary<Type, TweenPoolList> PoolDic { get; protected set; }

        public TweenPool()
        {
            PoolDic = new Dictionary<Type, TweenPoolList>();
        }

        public T Spawn<T>() where T : Tweener
        {
            var result = Spawn(typeof(T)) as T;
            return result;
        }

        public Tweener Spawn(int tweenType)
        {
            var type = TweenManager.TweenerTypeDic[tweenType];
            var result = Spawn(type);
            return result;
        }

        public Tweener Spawn(Type tweenType)
        {
            var pool = GetPoolList(tweenType);
            var result = pool.Spawn(tweenType);
            return result;
        }

        public void DeSpawn<T>(T tween) where T : Tweener
        {
            var pool = GetPoolList(tween.GetType());
            pool.DeSpawn(tween);
        }

        protected TweenPoolList GetPoolList(Type type)
        {
            if (PoolDic.TryGetValue(type, out var result)) return result;
            result = new TweenPoolList(type);
            PoolDic.Add(type, result);
            return result;
        }

        protected TweenPoolList GetPoolList<T>() where T : Tweener
        {
            var type = typeof(T);
            if (PoolDic.TryGetValue(type, out var result)) return result;
            result = new TweenPoolList(type);
            PoolDic.Add(type, result);
            return result;
        }
    }
}
