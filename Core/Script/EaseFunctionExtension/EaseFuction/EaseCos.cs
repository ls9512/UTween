/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseCos.cs
//  Info     : 插值算法 - EaseCos
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    public class EaseCos : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseCos;
        public override float Ease(float @from, float to, float delta)
        {
            var result = (float)Math.Cos(Math.PI * (delta + 0.5f) * 2f) * 0.5f + 0.5f;
            return result;
        }
    }
}