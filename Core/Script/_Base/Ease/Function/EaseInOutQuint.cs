/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInOutQuint.cs
//  Info     : 插值算法 - EaseInOutQuint
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInOutQuint : EaseFunction
    {
        public override int Type => EaseType.EaseInOutQuint;

        public override float Ease(float from, float to, float delta)
        {
            delta /= .5f;
            to -= from;
            if (delta < 1)
            {
                var result = to / 2 * delta * delta * delta * delta * delta + from;
                return result;
            }
            else
            {
                delta -= 2;
                var result = to / 2 * (delta * delta * delta * delta * delta + 2) + from;
                return result;
            }
        }
    }
}
