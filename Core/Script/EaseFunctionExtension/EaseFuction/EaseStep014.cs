/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseStep014.cs
//  Info     : ²åÖµËã·¨ - EaseStep014
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseStep014 : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseStep014;

        public override float Ease(float from, float to, float delta)
        {
            if (delta <= 0.25f) return 0f;
            if (delta <= 0.5f) return 0.333333f;
            if (delta <= 0.75f) return 0.666667f;
            return 1f;
        }
    }
}