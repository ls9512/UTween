/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenEditorSetting.cs
//  Info     : 插值动画编辑器配置类
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [CreateAssetMenu(menuName = "UTween/Tween Editor Setting", fileName = "TweenEditorSetting")]
    public class TweenEditorSetting : ScriptableObject
    {
        #region Instance

        public static TweenEditorSetting Ins
        {
            get
            {
                if (Instance == null)
                {
                    Instance = FindAsset<TweenEditorSetting>();
                }

                return Instance;
            }
        }

        protected static TweenEditorSetting Instance;

        internal static T FindAsset<T>() where T : Object
        {
            var guidList = AssetDatabase.FindAssets("t:" + typeof(T).FullName);
            if (guidList != null && guidList.Length > 0)
            {
                return AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guidList[0]));
            }

            return null;
        }
        #endregion

        [Header("Icon")]
        public Texture2D IconLogo;
        public Texture2D IconPlay;
        public Texture2D IconPause;
        public Texture2D IconRefresh;
    }
}
#endif