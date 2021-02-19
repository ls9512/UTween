/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenerAttribute.cs
//  Info     : 插值动画特性标签
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TweenerAttribute : Attribute
    {
        public int TweenType { get; }
        public bool EnableComponent { get; }

        public TweenerAttribute(int tweenType, bool enableComponent = true)
        {
            TweenType = tweenType;
            EnableComponent = enableComponent;
        }
    }
}
