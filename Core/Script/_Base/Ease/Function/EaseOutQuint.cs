/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutQuint.cs
//  Info     : 插值算法 - EaseOutQuint
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseOutQuint : EaseFunction
    {
        public override int Type => EaseType.EaseOutQuint;

        public override float Ease(float from, float to, float delta)
        {
            delta--;
            to -= from;
            var result = to * (delta * delta * delta * delta * delta + 1) + from;
            return result;
        }
    }
}
