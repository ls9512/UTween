/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInOutExpo.cs
//  Info     : 插值算法 - EaseInOutExpo
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseInOutExpo : EaseFunction
    {
        public override int Type => EaseType.EaseInOutExpo;

        public override float Ease(float from, float to, float delta)
        {
            delta /= .5f;
            to -= from;
            if (delta < 1)
            {
                var result = (float) (to / 2 * Math.Pow(2, 10 * (delta - 1)) + from);
                return result;
            }
            else
            {
                delta--;
                var result = (float) (to / 2 * (-Math.Pow(2, -10 * delta) + 2) + from);
                return result;
            }
        }
    }
}
