/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseOutCirc.cs
//  Info     : 插值算法 - EaseOutCirc
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseOutCirc : EaseFunction
    {
        public override int Type => EaseType.EaseOutCirc;

        public override float Ease(float from, float to, float delta)
        {
            delta--;
            to -= from;
            var result = (float) (to * Math.Sqrt(1 - delta * delta) + from);
            return result;
        }
    }
}
