/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenEditorUtil.cs
//  Info     : Tween 编辑器工具类
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

namespace Aya.Tween
{
    public enum TweenerEditorMode
    {
        Component = 1,
        Asset = 2,
    }

    public static class TweenEditorUtil
    {
        public static float LabelWidth = 75f;

        #region Cache

        public static List<Type> TweenerEditorTypeList { get; private set; }

        public static Dictionary<int, Type> TweenerEditorTypeDic { get; private set; }

        #endregion

        static TweenEditorUtil()
        {
            CacheTweenTypes();
            CacheTweenTypeDic();
        }

        internal static void CacheTweenTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var tweenTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                for (var i = 0; i < types.Length; i++)
                {
                    var type = types[i];
                    if (!type.IsClass || type.IsAbstract) continue;
                    if (typeof(TweenerEditor).IsAssignableFrom(type))
                    {
                        tweenTypes.Add(type);
                    }
                }
            }
            
            TweenerEditorTypeList = tweenTypes;
        }

        internal static void CacheTweenTypeDic()
        {
            TweenerEditorTypeDic = new Dictionary<int, Type>();
            foreach (var type in TweenerEditorTypeList)
            {
                var attribute = type.GetCustomAttribute<TweenerEditorAttribute>();
                if (attribute == null) continue;
                var tweenType = attribute.TweenType;
                TweenerEditorTypeDic.Add(tweenType, type);
            }
        }
    }
}
#endif