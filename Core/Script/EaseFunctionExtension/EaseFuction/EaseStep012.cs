/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseStep012.cs
//  Info     : ²åÖµËã·¨ - EaseStep012
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseStep012 : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseStep012;

        public override float Ease(float from, float to, float delta)
        {
            if (delta <= 0.5f) return 0f;
            return 1f;
        }
    }
}