/////////////////////////////////////////////////////////////////////////////
//
//  Script   : RequireOneOfComponentsAttribute.cs
//  Info     : 特性 - 包含至少一个组件
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Reflection;
using UnityEngine;

namespace Aya.Tween
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal sealed class RequireOneOfComponentsAttribute : Attribute
    {
        public Type[] Types;

        public RequireOneOfComponentsAttribute(params Type[] requiredComponents)
        {
            Types = requiredComponents;
        }

        /// <summary>
        /// 检查是否包含组件
        /// </summary>
        /// <param name="type">目标类的类型</param>
        /// <param name="target">目标对象</param>
        /// <returns>结果</returns>
        public static bool Check(Type type, GameObject target)
        {
            var com = Find(type, target);
            return com != null;
        }

        /// <summary>
        /// 查找包含的组件(返回找到的第一个)
        /// </summary>
        /// <param name="type">目标类类型</param>
        /// <param name="target">目标对象</param>
        /// <returns>结果</returns>
        public static Component Find(Type type, GameObject target)
        {
            var classAttribute = type.GetCustomAttribute<RequireOneOfComponentsAttribute>();
            var types = classAttribute.Types;
            Component ret = null;
            for (var i = 0; i < types.Length; i++)
            {
                var component = target.GetComponent(types[i]);
                if (component == null) continue;
                ret = component;
                break;
            }

            return ret;
        }
    }
}