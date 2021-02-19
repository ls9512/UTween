/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInBack.cs
//  Info     : 插值算法 - EaseInBack
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInBack : EaseFunction
    {
        public override int Type => EaseType.EaseInBack;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            delta /= 1;
            var s = 1.70158f;
            var result = to * (delta) * delta * ((s + 1) * delta - s) + from;
            return result;
        }
    }
}
