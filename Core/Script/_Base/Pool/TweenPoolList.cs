/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPoolList.cs
//  Info     : 插值组件缓存池列表
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace Aya.Tween
{
    internal class TweenPoolList
    {
        public Type Type { get; internal set; }

        public List<Tweener> SpawnList { get; internal set; }
        public List<Tweener> DeSpawnList { get; internal set; }

        public int Count => SpawnList.Count + DeSpawnList.Count;

        public TweenPoolList(Type type)
        {
            Type = type;
            SpawnList = new List<Tweener>();
            DeSpawnList = new List<Tweener>();
        }

        public T Spawn<T>() where T : Tweener
        {
            var result = Spawn(typeof(T)) as T;
            return result;
        }

        public Tweener Spawn(int type)
        {
            return TweenManager.TweenerTypeDic.TryGetValue(type, out var tweenType) ? Spawn(tweenType) : null;
        }

        public Tweener Spawn(Type tweenType)
        {
            Tweener result;
            if (DeSpawnList.Count > 0)
            {
                var index = DeSpawnList.Count - 1;
                result = DeSpawnList[index];
                DeSpawnList.RemoveAt(index);
            }
            else
            {
                result = Activator.CreateInstance(tweenType) as Tweener;
            }
            SpawnList.Add(result);
            if (result != null)
            {
                result.Reset();
                return result;
            }
            else
            {
                return null;
            }
        }

        public void DeSpawn<T>(T tween) where T : Tweener
        {
            if (!SpawnList.Contains(tween)) return;       
            SpawnList.Remove(tween);
            DeSpawnList.Add(tween);
        }
    }
}
