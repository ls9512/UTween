/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenManager.cs
//  Info     : 插值动画管理器 —— 用于承载所有动画的计算和播放
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Aya.Tween
{
    [ExecuteInEditMode]
    public class TweenManager : MonoBehaviour
    {
        #region Singleton

        private static bool ApplicationIsQuitting = false;
        internal static TweenManager Instance;

        public static TweenManager Ins
        {
            get
            {
                if (Application.isPlaying && ApplicationIsQuitting)
                {
                    return null;
                }

                if (Instance == null)
                {
                    Instance = FindObjectOfType<TweenManager>();
                    if (Instance == null)
                    {
                        var hideFlag = TweenSetting.Ins.ShowManager ? HideFlags.None : HideFlags.HideAndDontSave;
                        var insName = "UTween";
                        if (!Application.isPlaying)
                        {
                            insName = "UTween (Editor)";
                        }

                        var obj = new GameObject
                        {
                            name = insName,
                            hideFlags = hideFlag,
                        };

                        Instance = obj.AddComponent<TweenManager>();
                    }
                }

                return Instance;
            }
        }

        #endregion

        #region Cache

        public int TweenerCount { get; private set; }
        public int TweenAnimationCount { get; private set; }
        internal TweenPool Pool { get; private set; }

        internal HashSet<Tweener> CacheList = new HashSet<Tweener>();
        internal HashSet<Tweener> UpdateList = new HashSet<Tweener>();
        internal HashSet<Tweener> LateUpdateList = new HashSet<Tweener>();
        internal HashSet<Tweener> FixedUpdateList = new HashSet<Tweener>();

        protected object Lock { get; set; } = new object();
        protected bool NeedSync { get; set; } = false;

        #endregion

        #region Static Tween Type Dictionary

        public static Dictionary<int, Type> TweenerTypeDic
        {
            get
            {
                if (_tweenerTypeDic == null)
                {
                    CacheTweenTypeDic();
                }

                return _tweenerTypeDic;
            }
        }

        private static Dictionary<int, Type> _tweenerTypeDic;

        internal static void CacheTweenTypeDic()
        {
            var tweenTypes = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                for (var i = 0; i < types.Length; i++)
                {
                    var type = types[i];
                    if (!type.IsClass || type.IsAbstract) continue;
                    if (typeof(Tweener).IsAssignableFrom(type))
                    {
                        tweenTypes.Add(type);
                    }
                }
            }

            _tweenerTypeDic = new Dictionary<int, Type>();
            foreach (var type in tweenTypes)
            {
                var attribute = type.GetCustomAttribute<TweenerAttribute>();
                if (attribute == null) continue;
                var tweenType = attribute.TweenType;
                _tweenerTypeDic.Add(tweenType, type);
            }
        }

        #endregion

        #region Spawn / DeSpawn

        internal T Spawn<T>() where T : Tweener
        {
            var result = Spawn(typeof(T)) as T;
            return result;
        }

        internal Tweener Spawn(int tweenType)
        {
            return Pool.Spawn(tweenType);
        }

        internal Tweener Spawn(Type tweenType)
        {
            return Pool.Spawn(tweenType);
        }

        internal void DeSpawn<T>(T tween) where T : Tweener
        {
            Pool.DeSpawn(tween);
        }

        #endregion

        #region Add / Remove

        internal void Add(Tweener tween)
        {
            if (tween == null) return;
            if (CacheList.Contains(tween)) return;
            CacheList.Add(tween);
            NeedSync = true;
            TweenerCount++;
            if (tween.TweenAnimation != null)
            {
                TweenAnimationCount++;
            }
        }

        internal void Remove(Tweener tween, bool deSpawn = true)
        {
            if (tween == null) return;
            if (!CacheList.Contains(tween)) return;
            CacheList.Remove(tween);
            NeedSync = true;
            TweenerCount--;
            if (tween.TweenAnimation != null)
            {
                TweenAnimationCount--;
            }
            if (deSpawn)
            {
                DeSpawn(tween);
            }
        }

        #endregion

        #region Mono Behaviour

        protected void Awake()
        {
            TweenerCount = 0;
            Pool = new TweenPool();
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        protected void OnEnable()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                UnityEditor.EditorApplication.update += PreviewUpdate;
            }
#endif
        }

        protected void OnDisable()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                UnityEditor.EditorApplication.update -= PreviewUpdate;
            }
#endif
        }

        #region Editor Preview

#if UNITY_EDITOR

        internal List<Tweener> PreviewTweenerList = new List<Tweener>();
        internal double LastTimeSinceStartup = -1f;

        protected void PreviewUpdate()
        {
            if (PreviewTweenerList == null) return;
            lock (PreviewTweenerList)
            {
                var deltaTime = 0f;
                var currentTime = UnityEditor.EditorApplication.timeSinceStartup;
                if (LastTimeSinceStartup < 0f)
                {
                    LastTimeSinceStartup = currentTime;
                }

                deltaTime = (float) (currentTime - LastTimeSinceStartup);
                LastTimeSinceStartup = currentTime;

                var smoothDeltaTime = deltaTime;
                var scaledDeltaTime = deltaTime;
                var unscaledDeltaTime = deltaTime;

                for (var i = PreviewTweenerList.Count - 1; i >= 0; i--)
                {
                    var tweener = PreviewTweenerList[i];
                    if (!tweener.IsPlaying)
                    {
                        PreviewTweenerList.Remove(tweener);
                        continue;
                    }
                    
                    switch (tweener.UpdateType)
                    {
                        case UpdateType.Update:
                            tweener.UpdateBehaviour(smoothDeltaTime, scaledDeltaTime, unscaledDeltaTime);
                            break;
                        case UpdateType.LateUpdate:
                            tweener.LateUpdateBehaviour(smoothDeltaTime, scaledDeltaTime, unscaledDeltaTime);
                            break;
                        case UpdateType.FixedUpdate:
                            tweener.FixedUpdateBehaviour(smoothDeltaTime, scaledDeltaTime, unscaledDeltaTime);
                            break;
                    }
                }

                if (PreviewTweenerList.Count == 0)
                {
                    DestroyImmediate(Ins.gameObject);
                }
            }
        }

#endif 

        #endregion

        protected void OnDestroy()
        {
            if (Application.isPlaying)
            {
                ApplicationIsQuitting = true;
            }

            Instance = null;
        }

        protected void Update()
        {
            if (!Application.isPlaying) return;

            var smoothDeltaTime = Time.smoothDeltaTime;
            var scaledDeltaTime = Time.deltaTime;
            var unscaledDeltaTime = Time.unscaledDeltaTime;

            foreach (var tween in UpdateList)
            {
                try
                {
                    tween.UpdateBehaviour(scaledDeltaTime, smoothDeltaTime, unscaledDeltaTime);
                }
                catch(Exception exception)
                {
                    Debug.LogError(exception);
                    Remove(tween);
                }
            }

            if (NeedSync)
            {
                SyncPlayList();
            }
        }

        protected void LateUpdate()
        {
            if (!Application.isPlaying) return;

            var smoothDeltaTime = Time.smoothDeltaTime;
            var scaledDeltaTime = Time.deltaTime;
            var unscaledDeltaTime = Time.unscaledDeltaTime;

            foreach (var tween in LateUpdateList)
            {
                try
                {
                    tween.LateUpdateBehaviour(scaledDeltaTime, smoothDeltaTime, unscaledDeltaTime);
                }
                catch (Exception exception)
                {
                    Debug.LogError(exception);
                    Remove(tween);
                }
            }

            if (NeedSync)
            {
                SyncPlayList();
            }
        }

        protected void FixedUpdate()
        {
            if (!Application.isPlaying) return;

            var smoothDeltaTime = Time.smoothDeltaTime;
            var scaledDeltaTime = Time.fixedDeltaTime;
            var unscaledDeltaTime = Time.fixedUnscaledDeltaTime;

            foreach (var tween in FixedUpdateList)
            {
                try
                {
                    tween.FixedUpdateBehaviour(scaledDeltaTime, smoothDeltaTime, unscaledDeltaTime);
                }
                catch (Exception exception)
                {
                    Debug.LogError(exception);
                    Remove(tween);
                }
            }

            if (NeedSync)
            {
                SyncPlayList();
            }
        }

        #endregion

        #region Sync Play List

        protected void SyncPlayList()
        {
            SyncUpdateList();
            SyncLateUpdateList();
            SyncFixedUpdateList();
            NeedSync = false;
        }

        protected void SyncUpdateList()
        {
            UpdateList.Clear();
            foreach (var tween in CacheList)
            {
                if (tween.UpdateType == UpdateType.Update)
                {
                    UpdateList.Add(tween);
                }
            }
        }

        protected void SyncLateUpdateList()
        {
            LateUpdateList.Clear();
            foreach (var tween in CacheList)
            {
                if (tween.UpdateType == UpdateType.LateUpdate)
                {
                    LateUpdateList.Add(tween);
                }
            }
        }

        protected void SyncFixedUpdateList()
        {
            FixedUpdateList.Clear();
            foreach (var tween in CacheList)
            {
                if (tween.UpdateType == UpdateType.FixedUpdate)
                {
                    FixedUpdateList.Add(tween);
                }
            }
        }

        #endregion
    }
}

