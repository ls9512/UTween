/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenSetting.cs
//  Info     : 插值动画全局配置类
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [CreateAssetMenu(menuName = "UTween/Tween Setting", fileName = "TweenSetting")]
    public class TweenSetting : ScriptableObject
    {
        #region Instance

        public static TweenSetting Ins
        {
            get
            {
                if (Instance == null)
                {
                    Instance = Load(nameof(TweenSetting));
                }

                return Instance;
            }
        }

        protected static TweenSetting Instance;

        internal static TweenSetting Load(string fileName)
        {
            var ins = Resources.Load<TweenSetting>(fileName);
            return ins;
        } 
       
        #endregion

        [Header("Hierarchy Setting")]
        public bool ShowManager = true;
        public bool ShowCounter = true;

        [Header("Default Value")]
        public AnimationCurve DefaultCurve = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));
        [SerializeEnum("EaseType")]
        public int DefaultEaseType = EaseType.Linear;
        public AutoPlayType DefaultAutoPlayType = AutoPlayType.None;
        public UpdateType DefaultUpdateType = UpdateType.Update;
        public bool DefaultTimeScale = true;
        public bool DefaultTimeSmooth = true;
    }
}
