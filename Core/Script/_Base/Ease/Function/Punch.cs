/////////////////////////////////////////////////////////////////////////////
//
//  Script   : Punch.cs
//  Info     : 插值算法 - Punch
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class Punch : EaseFunction
    {
        public override int Type => EaseType.Punch;

        public override float Ease(float from, float to, float delta)
        {
            var result = Ease(to - from, delta);
            return result;
        }

        public float Ease(float amplitude, float delta)
        {
            var s = 9.0;
            if (Math.Abs(delta) < 1e-6)
            {
                return 0f;
            }

            if (Math.Abs(delta - 1) < 1e-6)
            {
                return 0f;
            }

            var period = 1 * 0.3f;
            s = period / (2 * Math.PI) * Math.Asin(0);
            var result = (float) (amplitude * Math.Pow(2, -10 * delta) * Math.Sin((delta * 1 - s) * (2 * Math.PI) / period));
            return result;
        }
    }
}
