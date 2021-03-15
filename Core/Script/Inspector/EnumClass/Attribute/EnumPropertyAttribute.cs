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

        public object[] Args { get; internal set; }

        public EnumPropertyAttribute(params object[] args)
        {
            Path = null;
            DisplayName = "";
            Display = true;
            Args = args;
        }

        public EnumPropertyAttribute(bool display = true, params object[] args)
        {
            Path = null;
            DisplayName = "";
            Display = display;
            Args = args;
        }

        public EnumPropertyAttribute(string displayName, bool display = true, params object[] args)
        {
            Path = null;
            DisplayName = displayName;
            Display = display;
            Args = args;
        }

        public EnumPropertyAttribute(string path, string displayName, bool display = true, params object[] args)
        {
            Path = path;
            DisplayName = displayName;
            Display = display;
            Args = args;
        }
    }
}
