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

