/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenSlider.cs
//  Info     : 滑条组件插值
//  Warning	 : 有GC
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine.UI;

namespace Aya.Tween
{
	[RequireComponents(typeof(Slider))]
    [Tweener(TweenType.Slider)]
    public class TweenSlider : TweenFloatBase<Slider>
	{
	    public override int Type => TweenType.Slider;

        protected override void SetValue(float value)
		{
			Component.value = value;
		}

		public override void SetCurrent2From()
		{
			From = Component.value;
		}

		public override void SetCurrent2To()
		{
			To = Component.value;
		}

		public override void SetFrom2Current()
		{
			Component.value = From;
		}

		public override void SetTo2Current()
		{
			Component.value = To;
		}
	}
}

