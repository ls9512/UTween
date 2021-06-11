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
	[RequireComponent(typeof(RectTransform))]
    [Tweener(TweenType.Width)]
    public class TweenWidth : TweenFloatBase<RectTransform> 
	{
	    public override int Type => TweenType.Width;

        protected override void SetValue(float value) 
		{
			Component.sizeDelta = new Vector2(value, Component.sizeDelta.y);
		}

        internal override void SetCurrent2From()
		{
            TweenAnimation.FromFloat = Component.sizeDelta.x;
		}

        internal override void SetCurrent2To() 
		{
            TweenAnimation.ToFloat = Component.sizeDelta.x;
		}

        internal override void SetFrom2Current() 
		{
			Component.sizeDelta = new Vector2(TweenAnimation.FromFloat, Component.sizeDelta.y);
		}

        internal override void SetTo2Current()
		{
			Component.sizeDelta = new Vector2(TweenAnimation.ToFloat, Component.sizeDelta.y);
		}
	}
}

