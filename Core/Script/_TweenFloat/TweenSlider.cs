/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenSlider.cs
//  Info     : 滑条组件插值
//  Warning	 : 有GC
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

namespace Aya.Tween
{
	[RequireComponent(typeof(Slider))]
    [Tweener(TweenType.Slider)]
    public class TweenSlider : TweenFloatBase<Slider>
	{
	    public override int Type => TweenType.Slider;

        protected override void SetValue(float value)
		{
			Component.value = value;
		}

        internal override void SetCurrent2From()
		{
            TweenAnimation.FromFloat = Component.value;
		}

        internal override void SetCurrent2To()
		{
            TweenAnimation.ToFloat = Component.value;
		}

        internal override void SetFrom2Current()
		{
			Component.value = TweenAnimation.FromFloat;
		}

        internal override void SetTo2Current()
		{
			Component.value = TweenAnimation.ToFloat;
		}
	}
}

