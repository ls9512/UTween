/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseStep018.cs
//  Info     : ²åÖµËã·¨ - EaseStep018
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseStep018 : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseStep018;

        public override float Ease(float from, float to, float delta)
        {
            if (delta <= 0.125f) return 0f;
            if (delta <= 0.250f) return 0.142857f;
            if (delta <= 0.375f) return 0.285714f;
            if (delta <= 0.500f) return 0.428571f;
            if (delta <= 0.625f) return 0.571429f;
            if (delta <= 0.750f) return 0.714286f;
            if (delta <= 0.875f) return 0.857143f;
            return 1f;
        }
    }
}