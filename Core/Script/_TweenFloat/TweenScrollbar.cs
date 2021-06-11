/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenScrollbar.cs
//  Info     : 滚动条组件插值
//  Warning	 : 有GC
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

namespace Aya.Tween
{
	[RequireComponent(typeof(Scrollbar))]
    [Tweener(TweenType.Scrollbar)]
    public class TweenScrollbar : TweenFloatBase<Scrollbar>
	{
	    public override int Type => TweenType.Scrollbar;

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

