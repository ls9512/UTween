/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseTypeExtension.cs
//  Info     : 扩展插值算法
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    [EnumClass("EaseType")]
    public class EaseTypeExtension
    {
        [EnumProperty("Flash", "Ease Flash 01")]
        public const int EaseFlash01 = 100;
        [EnumProperty("Flash", "Ease Flash 010")]
        public const int EaseFlash010 = 101;

        [EnumProperty("Step", "Ease Step x2")]
        public const int EaseStep012 = 200;
        [EnumProperty("Step", "Ease Step x4")]
        public const int EaseStep014 = 201;
        [EnumProperty("Step", "Ease Step x8")]
        public const int EaseStep018 = 202;
        [EnumProperty("Step", "Ease Step x16")]
        public const int EaseStep0116 = 203;

        [EnumProperty("Parabola", "Ease Parabola")]
        public const int EaseParabola = 300;

        [EnumProperty("Trigonometric", "Ease Sin")]
        public const int EaseSin = 400;
        [EnumProperty("Trigonometric", "Ease Cos")]
        public const int EaseCos = 401;
    }
}
