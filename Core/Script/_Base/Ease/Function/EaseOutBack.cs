/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutBack.cs
//  Info     : 插值算法 - EaseOutBack
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseOutBack : EaseFunction
    {
        public override int Type => EaseType.EaseOutBack;

        public override float Ease(float from, float to, float delta)
        {
            var s = 1.70158f;
            to -= from;
            delta = (delta / 1) - 1;
            var result = to * ((delta) * delta * ((s + 1) * delta + s) + 1) + from;
            return result;
        }
    }
}
