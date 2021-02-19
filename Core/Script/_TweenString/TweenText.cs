/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenText.cs
//  Info     : UI Text 文本显示长度 插值
//  Warning  : 1.文本显示内容将托管给该控件控制，不应在使用该控件的同时使用其他方式修改文本内容
//             2.仅结果支持富文本
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine.UI;

namespace Aya.Tween 
{
	[RequireComponents(typeof(Text))]
    [Tweener(TweenType.Text)]
    public class TweenText : TweenStringBase<Text>
	{
	    public override int Type => TweenType.Text;

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
            return Component.supportRichText;
        }
    }
}

