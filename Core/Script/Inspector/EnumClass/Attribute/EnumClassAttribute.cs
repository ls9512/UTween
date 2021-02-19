/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EnumClassAttribute.cs
//  Info     : 类转化为枚举特性标签
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EnumClassAttribute : Attribute
    {
        public string EnumType { get; }

        public EnumClassAttribute(string enumType)
        {
            EnumType = enumType;
        }
    }
}
