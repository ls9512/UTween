/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseFlash010.cs
//  Info     : ²åÖµËã·¨ - EaseFlash010
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseFlash010 : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseFlash010;

        public override float Ease(float from, float to, float delta)
        {
            if (delta <= 0.333333f) return 0f;
            if (delta >= 0.666667f) return 0f;
            return 1f;
        }
    }
}