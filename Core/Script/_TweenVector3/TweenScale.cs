/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenScale.cs
//  Info     : 缩放插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	[RequireComponent(typeof(Transform))]
    [Tweener(TweenType.Scale)]
    public class TweenScale : TweenVector3Base<Transform> 
	{
	    public override int Type => TweenType.Scale;

        protected override void SetValue(Vector3 value) 
		{
		    Transform.localScale = value;
		}

	    public override void SetCurrent2From()
	    {
	        From = Transform.localScale;
	    }

	    public override void SetCurrent2To()
	    {
	        To = Transform.localScale;
	    }

	    public override void SetFrom2Current()
	    {
	        Transform.localScale = From;
	    }

	    public override void SetTo2Current()
	    {
	        Transform.localScale = To;
	    }
	}
}

