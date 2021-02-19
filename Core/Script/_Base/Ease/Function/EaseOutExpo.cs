/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutExpo.cs
//  Info     : 插值算法 - EaseOutExpo
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseOutExpo : EaseFunction
    {
        public override int Type => EaseType.EaseOutExpo;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = (float)(to * (-Math.Pow(2, -10 * delta / 1) + 1) + from);
            return result;
        }
    }
}
