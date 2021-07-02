/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenAnimation.cs
//  Info     : 插值动画 MonoBehaviour 运行组件
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Aya.Tween
{
    [AddComponentMenu("UTween/Tween Animation")]
    [ExecuteInEditMode]
    public class TweenAnimation : MonoBehaviour
    {
        public int Type => Param.Type;

        public TweenParam Param = new TweenParam();

        #region From / To

        public float FromFloat
        {
            get => Param.FromFloat;
            set => Param.FromFloat = value;
        }

        public float ToFloat
        {
            get => Param.ToFloat;
            set => Param.ToFloat = value;
        }

        public Vector2 FromVector2
        {
            get => Param.FromVector2;
            set => Param.FromVector2 = value;
        }

        public Vector2 ToVector2
        {
            get => Param.ToVector2;
            set => Param.ToVector2 = value;
        }

        public Vector3 FromVector3
        {
            get => Param.FromVector3;
            set => Param.FromVector3 = value;
        }

        public Vector3 ToVector3
        {
            get => Param.ToVector3;
            set => Param.ToVector3 = value;
        }

        public Vector4 FromVector4
        {
            get => Param.FromVector4;
            set => Param.FromVector4 = value;
        }

        public Vector4 ToVector4
        {
            get => Param.ToVector4;
            set => Param.ToVector4 = value;
        }

        public Color FromColor
        {
            get => Param.FromColor;
            set => Param.FromColor = value;
        }

        public Color ToColor
        {
            get => Param.ToColor;
            set => Param.ToColor = value;
        }

        public Quaternion FromQuaternion
        {
            get => Param.FromQuaternion;
            set => Param.FromQuaternion = value;
        }

        public Quaternion ToQuaternion
        {
            get => Param.ToQuaternion;
            set => Param.ToQuaternion = value;
        }

        public Rect FromRect
        {
            get => Param.FromRect;
            set => Param.FromRect = value;
        }

        public Rect ToRect
        {
            get => Param.ToRect;
            set => Param.ToRect = value;
        }

        public Transform FromTransform
        {
            get => Param.FromTransform;
            set => Param.FromTransform = value;
        }

        public Transform ToTransform
        {
            get => Param.ToTransform;
            set => Param.ToTransform = value;
        }

        #endregion

        #region Queue Param List

        public List<Vector3> QueueVector3
        {
            get => Param.QueueVector3;
            set => Param.QueueVector3 = value;
        }

        public List<Color> QueueColor
        {
            get => Param.QueueColor;
            set => Param.QueueColor = value;
        }

        #endregion

        #region Animation Parameter

        public string Identifier
        {
            get => Param.Identifier;
            set => Param.Identifier = value;
        }

        public CurveMode CurveMode
        {
            get => Param.CurveMode;
            set => Param.CurveMode = value;
        }

        public CurveTargetType CurveTarget
        {
            get => Param.CurveTarget;
            set => Param.CurveTarget = value;
        }

        public AnimationCurve Curve
        {
            get => Param.Curve;
            set => Param.Curve = value;
        }

        public AnimationCurve CurveX
        {
            get => Param.CurveX;
            set => Param.CurveX = value;
        }

        public AnimationCurve CurveY
        {
            get => Param.CurveY;
            set => Param.CurveY = value;
        }

        public AnimationCurve CurveZ
        {
            get => Param.CurveZ;
            set => Param.CurveZ = value;
        }

        public AnimationCurve CurveW
        {
            get => Param.CurveW;
            set => Param.CurveW = value;
        }

        public PlayType PlayType
        {
            get => Param.PlayType;
            set => Param.PlayType = value;
        }

        public int EaseType
        {
            get => Param.EaseType;
            set => Param.EaseType = value;
        }

        public int LoopCount
        {
            get => Param.LoopCount;
            set => Param.LoopCount = value;
        }

        public float Duration
        {
            get => Param.Duration;
            set => Param.Duration = value;
        }

        public float Interval
        {
            get => Param.Interval;
            set => Param.Interval = value;
        }

        public bool SpeedBased
        {
            get => Param.SpeedBased;
            set => Param.SpeedBased = value;
        }

        public float StartDelay
        {
            get => Param.StartDelay;
            set => Param.StartDelay = value;
        }

        public AutoPlayType AutoPlay
        {
            get => Param.AutoPlay;
            set => Param.AutoPlay = value;
        }

        public UpdateType UpdateType
        {
            get => Param.UpdateType;
            set => Param.UpdateType = value;
        }

        public bool TimeScale
        {
            get => Param.TimeScale;
            set => Param.TimeScale = value;
        }

        public float SelfScale
        {
            get => Param.SelfScale;
            set => Param.SelfScale = value;
        }

        public bool TimeSmooth
        {
            get => Param.TimeSmooth;
            set => Param.TimeSmooth = value;
        }

        public bool AutoKill
        {
            get => Param.AutoKill;
            set => Param.AutoKill = value;
        }

        #endregion

        #region Not Universal Property

        public bool WorldSpace
        {
            get => Param.WorldSpace;
            set => Param.WorldSpace = value;
        }

        public ColorLerpMode ColorLerpMode
        {
            get => Param.ColorLerpMode;
            set => Param.ColorLerpMode = value;
        }

        public ColorBlockType ColorBlockType
        {
            get => Param.ColorBlockType;
            set => Param.ColorBlockType = value;
        }

        public PathMode PathMode
        {
            get => Param.PathMode;
            set => Param.PathMode = value;
        }

        public TweenShakeArgs ShakeArgs
        {
            get => Param.ShakeArgs;
            set => Param.ShakeArgs = value;
        }

        #endregion

        #region Resources Property

        public int ResourcesIndex
        {
            get => Param.ResourcesIndex;
            set => Param.ResourcesIndex = value;
        }
        public string ResourcesKey
        {
            get => Param.ResourcesKey;
            set => Param.ResourcesKey = value;
        }

        #endregion

        #region Callback Event

        public OnPlayEvent OnPlay
        {
            get => Param.OnPlay;
            set => Param.OnPlay = value;
        }

        public OnStopEvent OnStop
        {
            get => Param.OnStop;
            set => Param.OnStop = value;
        }

        public OnFloatValueEvent OnValueFloat
        {
            get => Param.OnValueFloat;
            set => Param.OnValueFloat = value;
        }

        public OnVector2ValueEvent OnValueVector2
        {
            get => Param.OnValueVector2;
            set => Param.OnValueVector2 = value;
        }

        public OnVector3ValueEvent OnValueVector3
        {
            get => Param.OnValueVector3;
            set => Param.OnValueVector3 = value;
        }

        public OnVector4ValueEvent OnValueVector4
        {
            get => Param.OnValueVector4;
            set => Param.OnValueVector4 = value;
        }

        public OnColorValueEvent OnValueColor
        {
            get => Param.OnValueColor;
            set => Param.OnValueColor = value;
        }

        public OnQuaternionValueEvent OnValueQuaternion
        {
            get => Param.OnValueQuaternion;
            set => Param.OnValueQuaternion = value;
        }

        public OnRectValueEvent OnValueRect
        {
            get => Param.OnValueRect;
            set => Param.OnValueRect = value;
        }

        #endregion

        #region Property

        /// <summary>
        /// 所选 Type 对应的 Tweener 类型，用于反射创建 
        /// </summary>
        public Type TweenerType { get; internal set; }

        /// <summary>
        /// Tweener 缓存<para/>
        /// Editor : 自身创建，用于调用 Quick Operation 接口
        /// Runtime : TweenPool创建，用于实际执行动画
        /// </summary>
        public Tweener Tweener { get; internal set; }

        /// <summary>
        /// 是否包含所需要的组件(未提供元数据则默认满足条件)
        /// </summary>
        public bool HasRequireComponent { get; internal set; } 
       
        #endregion

        #region Create Tweener

        public Tweener CreateTweener()
        {
            if (Application.isPlaying)
            {
                return CreateTweenerRuntime();
            }
            else
            {
                return CreateTweenerEditorTime();
            }
        }

        public Tweener CreateTweenerRuntime()
        {
            if (!Application.isPlaying) return null;
            if (!TweenManager.TweenerTypeDic.TryGetValue(Type, out var type)) return null;
            TweenerType = type;
            Tweener = TweenManager.Ins.Spawn(Type);
            SyncTweenerParams();
            Tweener.Awake();
            CheckRequireComponent();
            return Tweener;
        }

        public Tweener CreateTweenerEditorTime()
        {
            if (!TweenManager.TweenerTypeDic.TryGetValue(Type, out var type)) return null;
            TweenerType = type;
            Tweener = Activator.CreateInstance(type) as Tweener;
            if (Tweener == null) return null;
            Tweener.Reset();
            Tweener.TweenAnimation = this;
            Tweener.IsEditorMode = true;
            Tweener.Target = gameObject;
            Tweener.Transform = transform;
            Tweener.Awake();
            Tweener.Start();
            CheckRequireComponent();
            return Tweener;
        }

        #endregion

        #region Require Component

        public bool CheckRequireComponent()
        {
            var requireOneOfComponentsAttribute = TweenerType.GetCustomAttribute<RequireOneOfComponentsAttribute>();
            var requireComponentAttribute = TweenerType.GetCustomAttribute<RequireComponent>();
            if (requireOneOfComponentsAttribute == null && requireComponentAttribute == null)
            {
                HasRequireComponent = true;
            }
            else
            {
                if (requireOneOfComponentsAttribute != null)
                {
                    var result = RequireOneOfComponentsAttribute.Check(TweenerType, gameObject);
                    HasRequireComponent = result;
                }

                if (requireComponentAttribute != null)
                {
                    var component0 = gameObject.GetComponent(requireComponentAttribute.m_Type0);
                    if (requireComponentAttribute.m_Type1 == null)
                    {
                        HasRequireComponent = component0 != null;
                    }
                    else
                    {
                        var component1 = gameObject.GetComponent(requireComponentAttribute.m_Type1);
                        if (requireComponentAttribute.m_Type2 == null)
                        {
                            HasRequireComponent = component0 != null && component1 != null;
                        }
                        else
                        {
                            var component2 = gameObject.GetComponent(requireComponentAttribute.m_Type2);
                            HasRequireComponent = component0 != null && component1 != null && component2 != null;
                        }
                    }
                }
            }

            return HasRequireComponent;
        }

        public void FixRequireComponent()
        {
            var requireOneOfComponentsAttribute = TweenerType.GetCustomAttribute<RequireOneOfComponentsAttribute>();
            var requireComponentAttribute = TweenerType.GetCustomAttribute<RequireComponent>();
            if (requireOneOfComponentsAttribute == null && requireComponentAttribute == null) return;
            if (requireOneOfComponentsAttribute != null)
            {
                var componentType = requireOneOfComponentsAttribute.Types[0];
                var component = gameObject.GetComponent(componentType);
                if (component != null) return;
                gameObject.AddComponent(componentType);
            }

            if (requireComponentAttribute != null)
            {
                if (requireComponentAttribute.m_Type0 != null)
                {
                    var component = gameObject.GetComponent(requireComponentAttribute.m_Type0);
                    if(component == null) gameObject.AddComponent(requireComponentAttribute.m_Type0);
                }

                if (requireComponentAttribute.m_Type1 != null)
                {
                    var component = gameObject.GetComponent(requireComponentAttribute.m_Type1);
                    if (component == null) gameObject.AddComponent(requireComponentAttribute.m_Type1);
                }

                if (requireComponentAttribute.m_Type2 != null)
                {
                    var component = gameObject.GetComponent(requireComponentAttribute.m_Type2);
                    if (component == null) gameObject.AddComponent(requireComponentAttribute.m_Type2);
                }
            }
        }

        #endregion

        #region Switch Tweener

        public void SwitchTweenerType(int tweenType)
        {
            if (Tweener == null)
            {   
                 CreateTweenerEditorTime();              
            }
            else
            {
                if (tweenType != TweenType.None)
                {
                    if (Tweener.Type == tweenType) return;
                    if (!TweenManager.TweenerTypeDic.TryGetValue(tweenType, out var type)) return;
                    CreateTweenerEditorTime();
                }
                else
                {
                    TweenerType = null;
                    Tweener = null;
                }
            }
        } 
        
        #endregion

        #region Mono Behaviour

        public virtual void OnValidate()
        {
#if UNITY_EDITOR
            SwitchTweenerType(Type);
#endif
        }

        public virtual void Awake()
        {
            CreateTweener();
        }

        public virtual void Start()
        {
            if (Application.isPlaying)
            {
                if (Tweener == null)
                {
                    CreateTweener();
                }

                Tweener.Start();
            }
        }

        public virtual void OnEnable()
        {
            if (Application.isPlaying)
            {
                if (Tweener == null)
                {
                    CreateTweener();
                }

                Tweener.OnEnable();
            }      
        }

        public virtual void OnDisable()
        {
            if (Tweener != null && Application.isPlaying)
            {
                Tweener.OnDisable();
            }       
        }

        public virtual void OnDestroy()
        {
            if (Tweener != null && Application.isPlaying)
            {
                Tweener.OnDestroy();
            }
        }

        public virtual void Reset()
        {
            ResetComponentValue();
            ResetCallback();

            if (Tweener != null && Application.isPlaying)
            {
                Tweener.Target = gameObject;
                Tweener.Reset();
            }
        }

        #endregion

        #region Reset Value

        internal void SyncTweenerParams()
        {
            Tweener.Target = gameObject;
            Tweener.Transform = transform;
            Tweener.TweenAnimation = this;

            Param.CopyTo(Tweener.Param);
        }

        public void ResetComponentValue()
        {
            if (Tweener != null)
            {
                Tweener.TweenAnimation = this;
            }
            
            Param.ResetValue();
        }

        public void ResetCallback()
        {
            Param.ResetCallback();
        }

        #endregion

        #region Quick Operation

#if UNITY_EDITOR

        [ContextMenu("Current > From")]
        public void MenuCurrentFrom()
        {
            Tweener.SetCurrent2From();
        }

        [ContextMenu("Current > To")]
        public void MenuCurrentTo()
        {
            Tweener.SetCurrent2To();
        }

        [ContextMenu("From > Current")]
        public void MenuFromCurrent()
        {
            Tweener.SetFrom2Current();
        }

        [ContextMenu("To > Current")]
        public void MenuToCurrent()
        {
            Tweener.SetTo2Current();
        }

#endif

        #endregion

        #region Tween Animation Asset

#if UNITY_EDITOR

        [ContextMenu("Export Asset...")]
        public void ExportAsset()
        {
            var path = EditorUtility.SaveFilePanel("Export param to TweenAnimationAsset", Application.dataPath, "Tween_" + SerializeEnumAttribute.TypeIndexInfoDic[TweenKey.TweenType][Param.Type].Name, "asset");
            path = path.Remove(0, path.IndexOf("Assets", StringComparison.Ordinal));
            var asset = ScriptableObject.CreateInstance<TweenAnimationAsset>();
            asset.Param.CopyFrom(Param);
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        [ContextMenu("Import Asset...")]
        public void ImportAsset()
        {
            var path = EditorUtility.OpenFilePanel("Select a TweenAnimationAsset file", Application.dataPath, "asset");
            path = path.Remove(0, path.IndexOf("Assets", StringComparison.Ordinal));
            var asset = (TweenAnimationAsset)AssetDatabase.LoadAssetAtPath(path, typeof(TweenAnimationAsset));
            if (asset == null) return;
            Param.CopyFrom(asset.Param);
        }
#endif

        #endregion

    }
}
