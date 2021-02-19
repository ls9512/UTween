/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenerEditorAttribute.cs
//  Info     : 插值动画编辑器特性标签
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using System;

namespace Aya.Tween
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TweenerEditorAttribute : Attribute
    {
        public int TweenType { get; }

        public TweenerEditorAttribute(int tweenType)
        {
            TweenType = tweenType;
        }
    }
}
#endif