/////////////////////////////////////////////////////////////////////////////
//
//  Script   : Linear.cs
//  Info     : 插值算法 - Linear
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class Linear : EaseFunction
    {
        public override int Type => EaseType.Linear;

        public override float Ease(float from, float to, float delta)
        {
            var result = from + (to - from) * delta;
            return result;
        }
    }
}
