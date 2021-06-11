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
	[RequireComponent(typeof(RectTransform))]
    [Tweener(TweenType.Size)]
    public class TweenSize : TweenVector2Base<RectTransform> 
	{
	    public override int Type => TweenType.Size;

        protected override void SetValue(Vector2 value) 
		{
			Component.sizeDelta = value;
		}

        internal override void SetCurrent2From()
		{
            TweenAnimation.FromVector2 = Component.sizeDelta;
		}

        internal override void SetCurrent2To() 
		{
            TweenAnimation.ToVector2 = Component.sizeDelta;
		}

        internal override void SetFrom2Current()
		{
		    Component.sizeDelta = TweenAnimation.FromVector2;
		}

        internal override void SetTo2Current()
        {
		    Component.sizeDelta = TweenAnimation.ToVector2;
		}
	}
}

