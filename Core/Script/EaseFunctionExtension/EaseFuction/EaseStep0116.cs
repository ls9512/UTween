/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseStep0116.cs
//  Info     : ²åÖµËã·¨ - EaseStep0116
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseStep0116 : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseStep0116;

        public override float Ease(float from, float to, float delta)
        {
            if (delta <= 0.0625f) return 0f;
            if (delta <= 0.1250f) return 0.066667f;
            if (delta <= 0.1875f) return 0.133333f;
            if (delta <= 0.2500f) return 0.2f;
            if (delta <= 0.3125f) return 0.266667f;
            if (delta <= 0.3750f) return 0.333333f;
            if (delta <= 0.4375f) return 0.4f;
            if (delta <= 0.5000f) return 0.466667f;
            if (delta <= 0.5625f) return 0.533333f;
            if (delta <= 0.6250f) return 0.6f;
            if (delta <= 0.6875f) return 0.666667f;
            if (delta <= 0.7500f) return 0.733333f;
            if (delta <= 0.8125f) return 0.8f;
            if (delta <= 0.8750f) return 0.866667f;
            if (delta <= 0.9375f) return 0.933333f;
            return 1f;
        }
    }
}