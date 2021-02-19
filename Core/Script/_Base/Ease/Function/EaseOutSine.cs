/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutSine.cs
//  Info     : 插值算法 - EaseOutSine
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseOutSine : EaseFunction
    {
        public override int Type => EaseType.EaseOutSine;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = (float) (to * Math.Sin(delta / 1 * (Math.PI / 2)) + from);
            return result;
        }
    }
}
