/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPosition.cs
//  Info     : 位置插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	[RequireComponent(typeof(Transform))]
    [Tweener(TweenType.Position)]
    public class TweenPosition : TweenVector3Base<Transform> 
	{
	    public override int Type => TweenType.Position;

        protected override void SetValue(Vector3 value) 
		{
			if (WorldSpace)
			{
				Transform.position = value;
			}
			else
			{
			    Transform.localPosition = value;
			}
		}

		internal override void SetCurrent2From()
		{
            TweenAnimation.FromVector3 = WorldSpace ? Transform.position : Transform.localPosition;
        }

        internal override void SetCurrent2To()
		{
            TweenAnimation.ToVector3 = WorldSpace ? Transform.position : Transform.localPosition;
		}

        internal override void SetFrom2Current()
		{
            if (WorldSpace) Transform.position = TweenAnimation.FromVector3;
			else Transform.localPosition = TweenAnimation.FromVector3;
		}

        internal override void SetTo2Current()
		{
            if (WorldSpace) Transform.position = TweenAnimation.ToVector3;
			else Transform.localPosition = TweenAnimation.ToVector3;
		}
	}
}

