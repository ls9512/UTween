/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutCubic.cs
//  Info     : 插值算法 - EaseOutCubic
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseOutCubic : EaseFunction
    {
        public override int Type => EaseType.EaseOutCubic;

        public override float Ease(float from, float to, float delta)
        {
            delta--;
            to -= from;
            var result = to * (delta * delta * delta + 1) + from;
            return result;
        }
    }
}
