/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRubyTextMeshPro.cs
//  Info     : RubyTextMeshPro 文本显示长度 插值
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#define RUBYTEXTMESHPRO
#if RUBYTEXTMESHPRO
using UnityEngine;
using TMPro;

namespace Aya.Tween 
{
	[RequireComponent(typeof(RubyTextMeshPro))]
    [Tweener(TweenTypeRubyTextMeshPro.RubyTextMeshPro)]
    public class TweenRubyTextMeshPro : TweenStringBase<RubyTextMeshPro>
	{
	    public override int Type => TweenTypeRubyTextMeshPro.RubyTextMeshPro;

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