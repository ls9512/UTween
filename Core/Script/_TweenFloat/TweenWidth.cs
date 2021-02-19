/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenWidth.cs
//  Info     : UI宽度缩放插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	[RequireComponents(typeof(RectTransform))]
    [Tweener(TweenType.Width)]
    public class TweenWidth : TweenFloatBase<RectTransform> 
	{
	    public override int Type => TweenType.Width;

        protected override void SetValue(float value) 
		{
			Component.sizeDelta = new Vector2(value, Component.sizeDelta.y);
		}

		public override void SetCurrent2From()
		{
			From = Component.sizeDelta.x;
		}

		public override void SetCurrent2To() 
		{
			To = Component.sizeDelta.x;
		}

		public override void SetFrom2Current() 
		{
			Component.sizeDelta = new Vector2(From, Component.sizeDelta.y);
		}

		public override void SetTo2Current()
		{
			Component.sizeDelta = new Vector2(To, Component.sizeDelta.y);
		}
	}
}

