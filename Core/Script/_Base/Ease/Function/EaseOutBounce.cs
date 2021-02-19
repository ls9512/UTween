/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutBounce.cs
//  Info     : 插值算法 - EaseOutBounce
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseOutBounce : EaseFunction
    {
        public override int Type => EaseType.EaseOutBounce;

        public override float Ease(float from, float to, float delta)
        {
            delta /= 1f;
            to -= from;
            if (delta < (1 / 2.75f))
            {
                return to * (7.5625f * delta * delta) + from;
            }

            if (delta < (2 / 2.75f))
            {
                delta -= (1.5f / 2.75f);
                return to * (7.5625f * (delta) * delta + .75f) + from;
            }

            if (delta < (2.5f / 2.75f))
            {
                delta -= (2.25f / 2.75f);
                return to * (7.5625f * (delta) * delta + .9375f) + from;
            }

            delta -= (2.625f / 2.75f);
            var result = to * (7.5625f * (delta) * delta + .984375f) + from;
            return result;
        }
    }
}
