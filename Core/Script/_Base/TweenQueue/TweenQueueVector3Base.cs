/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenQueueVector3Base.cs
//  Info     : Vector3批量插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;

namespace Aya.Tween 
{
	public abstract class TweenQueueVector3Base<TComponent> : TweenQueueBase<Vector3, TComponent> where TComponent : Component 
	{
	    public override Vector3 From { get; set; }
	    public override Vector3 To { get; set; }

	    public override List<Vector3> Queue
	    {
	        get => Param.QueueVector3;
	        set => Param.QueueVector3 = value;
	    }

        public override bool SupportSpeedBased => false;

		public override Vector3 Evaluate(float factor) 
		{
			CurrentRange(factor);
			var currentFactor = CurrentRangeFactor(factor);
            var result = CurrentFrom * (1 - currentFactor) + CurrentTo * currentFactor;
		    if (Curve != null && CurveTarget == CurveTargetType.Value)
		    {
		        result = result * Curve.Evaluate(factor);
		    }
            return result;
		}

	    public override void TweenUpdate()
	    {
	        base.TweenUpdate();
	        OnValueVector3.InvokeIfNeed(CurrentValue);
	    }
    }
}
