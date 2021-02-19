/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseParabola.cs
//  Info     : 插值算法 - EaseParabola
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseParabola : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseParabola;
        public override float Ease(float from, float to, float delta)
        {
            var result = 1f - (float)Math.Pow((delta - 0.5f) * 2f, 2);
            return result;
        }
    }
}
