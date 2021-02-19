/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTypeTextMeshPro.cs
//  Info     : 插值动画类型枚举
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#define TEXTMESHPRO
#if TEXTMESHPRO

namespace Aya.Tween
{
    [EnumClass("TweenType")]
    public static class TweenTypeTextMeshPro
    {
        [EnumProperty("TextMeshPro", "TextMeshPro")]
        public const int TextMeshPro = 351;
        [EnumProperty("TextMeshPro", "TextMeshPro UGUI")]
        public const int TextMeshProUGUI = 352;
    }
}
#endif
