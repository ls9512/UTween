/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EnumClassAttribute.cs
//  Info     : 类转化为枚举特性标签
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Aya.Tween
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum, AllowMultiple = false)]
    public class SerializeEnumAttribute : PropertyAttribute
    {
        public string EnumType { get; set; }
        public bool ShowName { get; set; }

        public SerializeEnumAttribute(string enumType, bool showName = true)
        {
            EnumType = enumType;
            ShowName = showName;
        }

        #region Cache

        public static Dictionary<string, List<EnumPropertyAttribute>> TypeInfosDic = new Dictionary<string, List<EnumPropertyAttribute>>();
        public static Dictionary<string, Dictionary<string, EnumPropertyAttribute>> TypeNameInfoDic = new Dictionary<string, Dictionary<string, EnumPropertyAttribute>>();
        public static Dictionary<string, Dictionary<int, EnumPropertyAttribute>> TypeIndexInfoDic = new Dictionary<string, Dictionary<int, EnumPropertyAttribute>>();

        public static void CacheSerializeEnum(Type type)
        {
            var enumClassAttribute = type.GetCustomAttribute<EnumClassAttribute>();
            if (enumClassAttribute == null) return;

            var enumType = enumClassAttribute.EnumType;
            var fieldInfos = type.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                var enumPropertyAttribute = fieldInfo.GetCustomAttribute<EnumPropertyAttribute>();
                if (enumPropertyAttribute == null) continue;

                var name = fieldInfo.Name;
                var index = (int) fieldInfo.GetValue(null);
                enumPropertyAttribute.Name = name;
                enumPropertyAttribute.Index = index;
                if (string.IsNullOrEmpty(enumPropertyAttribute.DisplayName))
                {
                    enumPropertyAttribute.DisplayName = name;
                }

                if (!TypeInfosDic.TryGetValue(enumType, out var infoList))
                {
                    infoList = new List<EnumPropertyAttribute>();
                    TypeInfosDic.Add(enumType, infoList);
                }

                infoList.Add(enumPropertyAttribute);

                if (!TypeIndexInfoDic.TryGetValue(enumType, out var indexInfoDIc))
                {
                    indexInfoDIc = new Dictionary<int, EnumPropertyAttribute>();
                    TypeIndexInfoDic.Add(enumType, indexInfoDIc);
                }

                indexInfoDIc.Add(index, enumPropertyAttribute);

                if (!TypeNameInfoDic.TryGetValue(enumType, out var nameInfoDIc))
                {
                    nameInfoDIc = new Dictionary<string, EnumPropertyAttribute>();
                    TypeNameInfoDic.Add(enumType, nameInfoDIc);
                }

                nameInfoDIc.Add(name, enumPropertyAttribute);
            }

            foreach (var kv in TypeInfosDic)
            {
                var infoList = kv.Value;
                infoList.Sort((i1, i2) => i1.Index - i2.Index);
            }
        }

        #endregion
    }
}