/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInQuint.cs
//  Info     : 插值算法 - EaseInQuint
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInQuint : EaseFunction
    {
        public override int Type => EaseType.EaseInQuint;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = to * delta * delta * delta * delta * delta + from;
            return result;
        }
    }
}
