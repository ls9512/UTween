/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInCubic.cs
//  Info     : 插值算法 - EaseInCubic
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInCubic : EaseFunction
    {
        public override int Type => EaseType.EaseInCubic;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = to * delta * delta * delta + from;
            return result;
        }
    }
}
