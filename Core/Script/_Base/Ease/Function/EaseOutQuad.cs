/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutQuad.cs
//  Info     : 插值算法 - EaseOutQuad
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseOutQuad : EaseFunction
    {
        public override int Type => EaseType.EaseOutQuad;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = -to * delta * (delta - 2f) + from;
            return result;
        }
    }
}
