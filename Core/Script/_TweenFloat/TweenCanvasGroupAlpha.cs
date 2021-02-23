/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenCanvasGroupAlpha.cs
//  Info     : UI透明度插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	[RequireComponent(typeof(CanvasGroup))]
    [Tweener(TweenType.CanvasGroupAlpha)]
    public class TweenCanvasGroupAlpha : TweenFloatBase<CanvasGroup>
	{
	    public override int Type => TweenType.CanvasGroupAlpha;

        protected override void SetValue(float value)
		{
			Component.alpha = value;
		}

		public override void SetCurrent2From()
		{
			From = Component.alpha;
		}

		public override void SetCurrent2To()
		{
			To = Component.alpha;
		}

		public override void SetFrom2Current()
		{
			Component.alpha = From;
		}

		public override void SetTo2Current()
		{
			Component.alpha = To;
		}
	}
}

