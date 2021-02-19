/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenQueueColorBase.cs
//  Info     : Color批量插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;

namespace Aya.Tween 
{
	public abstract class TweenQueueColorBase<TComponent> : TweenQueueBase<Color, TComponent> where TComponent : Component 
	{
	    public override Color From { get; set; }
	    public override Color To { get; set; }

	    public override List<Color> Queue
	    {
	        get => Param.QueueColor;
	        set => Param.QueueColor = value;
	    }

        public override bool SupportSpeedBased => false;

		public override Color Evaluate(float factor) 
		{
			CurrentRange(factor);
			var currentFactor = CurrentRangeFactor(factor);

		    Color result;
            if (ColorLerpMode == ColorLerpMode.RGB)
		    {
		        result = LerpUtil.LerpRgb(CurrentFrom, CurrentTo, currentFactor);
		    }
		    else if (ColorLerpMode == ColorLerpMode.HSV)
		    {
		        result = LerpUtil.LerpHsv(CurrentFrom, CurrentTo, currentFactor);
		    }
		    else
		    {
		        result = CurrentFrom * (1 - currentFactor) + CurrentTo * currentFactor;
		    }
		    if (Curve != null && CurveTarget == CurveTargetType.Value)
		    {
		        result = result * Curve.Evaluate(factor);
		    }

            return result;
		}

	    public override void TweenUpdate()
	    {
	        base.TweenUpdate();
	        OnValueColor.InvokeIfNeed(CurrentValue);
	    }
    }
}
