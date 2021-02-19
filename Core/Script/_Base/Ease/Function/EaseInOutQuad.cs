/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInOutQuad.cs
//  Info     : 插值算法 - EaseInOutQuad
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInOutQuad : EaseFunction
    {
        public override int Type => EaseType.EaseInOutQuad;

        public override float Ease(float from, float to, float delta)
        {
            delta /= .5f;
            to -= from;
            if (delta < 1)
            {
                var result = to / 2 * delta * delta + from;
                return result;
            }
            else
            {
                delta--;
                var result = -to / 2 * (delta * (delta - 2) - 1) + from;
                return result;
            }
        }
    }
}
