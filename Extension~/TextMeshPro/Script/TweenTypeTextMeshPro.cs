/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTypeTextMeshPro.cs
//  Info     : 插值动画类型枚举
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UTWEEN_TEXTMESHPRO
namespace Aya.Tween
{
    [EnumClass("TweenType")]
    public static class TweenTypeTextMeshPro
    {
#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Init()
        {
            SerializeEnumAttribute.CacheSerializeEnum(typeof(TweenTypeTextMeshPro));
        }

        [EnumProperty("TextMeshPro", "TextMeshPro")]
        public const int TextMeshPro = 351;
        [EnumProperty("TextMeshPro", "TextMeshPro UGUI")]
        public const int TextMeshProUGUI = 352;
    }
}
#endif
