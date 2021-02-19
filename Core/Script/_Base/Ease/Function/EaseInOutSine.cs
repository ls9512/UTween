/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInOutSine.cs
//  Info     : 插值算法 - EaseInOutSine
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseInOutSine : EaseFunction
    {
        public override int Type => EaseType.EaseInOutSine;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = (float) (-to / 2 * (Math.Cos(Math.PI * delta / 1) - 1) + from);
            return result;
        }
    }
}
