/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInQuad.cs
//  Info     : 插值算法 - EaseInQuad
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseInQuad : EaseFunction
    {
        public override int Type => EaseType.EaseInQuad;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = to * delta * delta + from;
            return result;
        }
    }
}
