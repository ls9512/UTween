/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EnumPropertyAttribute.cs
//  Info     : 类转换为枚举特性标签
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum, AllowMultiple = false)]
    public class EnumPropertyAttribute : Attribute
    {
        public string Path { get; internal set; }
        public string DisplayName { get; internal set; }

        public string Name { get; internal set; }
        public int Index { get; internal set; }

        public bool Display { get; internal set; }

        public EnumPropertyAttribute(bool display = true)
        {
            Path = null;
            DisplayName = "";
            Display = display;
        }

        public EnumPropertyAttribute(string displayName, bool display = true)
        {
            Path = null;
            DisplayName = displayName;
            Display = display;
        }

        public EnumPropertyAttribute(string path, string displayName, bool display = true)
        {
            Path = path;
            DisplayName = displayName;
            Display = display;
        }
    }
}
