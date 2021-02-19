/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInBounce.cs
//  Info     : 插值算法 - EaseInBounce
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInBounce : EaseFunction
    {
        public override int Type => EaseType.EaseInBounce;
        public EaseOutBounce EaseOutBounce = new EaseOutBounce();

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result =  to - EaseOutBounce.Ease(0, to, 1f - delta) + from;
            return result;
        }
    }
}
