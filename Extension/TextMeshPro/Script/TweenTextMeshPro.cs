/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTextMeshPro.cs
//  Info     : TextMeshPro 文本显示长度 插值
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#define TEXTMESHPRO
#if TEXTMESHPRO
using UnityEngine;
using TMPro;

namespace Aya.Tween 
{
	[RequireComponent(typeof(TextMeshPro))]
    [Tweener(TweenTypeTextMeshPro.TextMeshPro)]
    public class TweenTextMeshPro : TweenStringBase<TextMeshPro>
	{
	    public override int Type => TweenTypeTextMeshPro.TextMeshPro;

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