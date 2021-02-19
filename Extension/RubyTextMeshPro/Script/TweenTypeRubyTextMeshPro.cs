/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTypeRubyTextMeshPro.cs
//  Info     : 插值动画类型枚举
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#define RUBYTEXTMESHPRO
#if RUBYTEXTMESHPRO

namespace Aya.Tween
{
    [EnumClass("TweenType")]
    public static class TweenTypeRubyTextMeshPro
    {
        [EnumProperty("Ruby TextMeshPro", "Ruby TextMeshPro")]
        public const int RubyTextMeshPro = 353;
        [EnumProperty("Ruby TextMeshPro", "Ruby TextMeshPro UGUI")]
        public const int RubyTextMeshProUGUI = 354;
    }
}
#endif