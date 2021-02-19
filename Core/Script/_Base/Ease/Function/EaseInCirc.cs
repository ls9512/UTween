/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseInCirc.cs
//  Info     : 插值算法 - EaseInCirc
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseInCirc : EaseFunction
    {
        public override int Type => EaseType.EaseInCirc;

        public override float Ease(float from, float to, float delta)
        {
            to -= from;
            var result = (float) (-to * (Math.Sqrt(1 - delta * delta) - 1) + from);
            return result;
        }
    }
}
