/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenSize.cs
//  Info     : UI尺寸缩放插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	[RequireComponents(typeof(RectTransform))]
    [Tweener(TweenType.Size)]
    public class TweenSize : TweenVector2Base<RectTransform> 
	{
	    public override int Type => TweenType.Size;

        protected override void SetValue(Vector2 value) 
		{
			Component.sizeDelta = value;
		}

		public override void SetCurrent2From()
		{
			From = Component.sizeDelta;
		}

		public override void SetCurrent2To() 
		{
			To = Component.sizeDelta;
		}

		public override void SetFrom2Current()
		{
		    Component.sizeDelta = From;
		}

		public override void SetTo2Current()
        {
		    Component.sizeDelta = To;
		}
	}
}

