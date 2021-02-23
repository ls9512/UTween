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

		public override void SetCurrent2From()
		{
			From = WorldSpace ? Transform.position : Transform.localPosition;
		}

		public override void SetCurrent2To()
		{
			To = WorldSpace ? Transform.position : Transform.localPosition;
		}

		public override void SetFrom2Current()
		{
            if (WorldSpace) Transform.position = From;
			else Transform.localPosition = From;
		}

		public override void SetTo2Current()
		{
            if (WorldSpace) Transform.position = To;
			else Transform.localPosition = To;
		}
	}
}

