/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenHeight.cs
//  Info     : UI高度缩放插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	[RequireComponent(typeof(RectTransform))]
    [Tweener(TweenType.Height)]
    public class TweenHeight : TweenFloatBase<RectTransform> 
	{
	    public override int Type => TweenType.Height;

        protected override void SetValue(float value) 
		{
			Component.sizeDelta = new Vector2(Component.sizeDelta.x, value);
		}

		public override void SetCurrent2From()
		{
			From = Component.sizeDelta.y;
		}

		public override void SetCurrent2To() 
		{
			To = Component.sizeDelta.y;
		}

		public override void SetFrom2Current() 
		{
			Component.sizeDelta = new Vector2(Component.sizeDelta.x, From);
		}

		public override void SetTo2Current()
		{
			Component.sizeDelta = new Vector2(Component.sizeDelta.x, To);
		}
	}
}

