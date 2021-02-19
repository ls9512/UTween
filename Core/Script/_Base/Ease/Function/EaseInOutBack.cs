/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInOutBack.cs
//  Info     : 插值算法 - EaseInOutBack
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInOutBack : EaseFunction
    {
        public override int Type => EaseType.EaseInOutBack;

        public override float Ease(float from, float to, float delta)
        {
            var s = 1.70158f;
            to -= from;
            delta /= .5f;
            if ((delta) < 1)
            {
                s *= (1.525f);
                var result = to / 2 * (delta * delta * (((s) + 1) * delta - s)) + from;
                return result;
            }
            else
            {
                delta -= 2;
                s *= (1.525f);
                var result = to / 2 * ((delta) * delta * (((s) + 1) * delta + s) + 2) + from;
                return result;
            }
        }
    }
}
