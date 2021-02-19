/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInSine.cs
//  Info     : 插值算法 - EaseInSine
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseInSine : EaseFunction
    {
        public override int Type => EaseType.EaseInSine;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = (float)(-to * Math.Cos(delta / 1 * (Math.PI / 2)) + to + from);
            return result;
        }
    }
}
