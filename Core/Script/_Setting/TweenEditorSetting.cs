/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenEditorSetting.cs
//  Info     : 插值动画编辑器配置类
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [CreateAssetMenu(menuName = "UTween/Tween Setting", fileName = "TweenEditorSetting")]
    public class TweenEditorSetting : ScriptableObject
    {
        #region Instance

        public static TweenEditorSetting Ins
        {
            get
            {
                if (Instance == null)
                {
                    Instance = Load(nameof(TweenEditorSetting));
                }

                return Instance;
            }
        }

        protected static TweenEditorSetting Instance;

        internal static TweenEditorSetting Load(string fileName)
        {
            var ins = Resources.Load<TweenEditorSetting>(fileName);
            return ins;
        } 
       
        #endregion

        [Header("Icon")]
        public Texture2D IconPlay;
        public Texture2D IconPause;
        public Texture2D IconRefresh;
    }
}
