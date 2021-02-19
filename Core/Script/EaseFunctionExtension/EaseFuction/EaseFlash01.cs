/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseFlash01.cs
//  Info     : ²åÖµËã·¨ - EaseFlash01
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public class EaseFlash01 : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseFlash01;

        public override float Ease(float from, float to, float delta)
        {
            return delta <= 0.5f ? 0f : 1f;
        }
    }
}
