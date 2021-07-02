/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTextMeshProUGUI.cs
//  Info     : TextMeshProUGUI 文本显示长度 插值
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UTWEEN_TEXTMESHPRO
using UnityEngine;
using TMPro;

namespace Aya.Tween 
{
	[RequireComponent(typeof(TextMeshProUGUI))]
    [Tweener(TweenTypeTextMeshPro.TextMeshProUGUI)]
    public class TweenTextMeshProUGUI : TweenStringBase<TextMeshProUGUI>
	{
	    public override int Type => TweenTypeTextMeshPro.TextMeshProUGUI;

        public override string GetString()
        {
            return Component.text;
        }

        public override void SetString(string str)
        {
            Component.text = str;
        }

        public override bool GetSupportRichText()
        {
            return Component.richText;
        }
    }
}
#endif