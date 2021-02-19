/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseSin.cs
//  Info     : 插值算法 - EaseCos
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseSin : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseSin;
        public override float Ease(float @from, float to, float delta)
        {
            var result = (float)Math.Sin(Math.PI * (delta + 0.5f) * 2f);
            return result;
        }
    }
}