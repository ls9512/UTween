/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenColorBase.cs
//  Info     : Color插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	public abstract class TweenColorBase<TComponent> : Tweener<Color, TComponent> where TComponent : Component
	{
	    public override Color From
	    {
	        get => Param.FromColor;
	        set => Param.FromColor = value;
	    }

	    public override Color To
	    {
	        get => Param.ToColor;
	        set => Param.ToColor = value;
	    }

        public override bool SupportSpeedBased => false;

		public override float GetSpeedBasedDuration()
        {
            return Duration;
        }

		public override Color Evaluate(float factor)
        {
            var from = FromGetter();
            var to = ToGetter();
            Color result;
	        switch (ColorLerpMode)
            {
                case ColorLerpMode.RGB:
                    result = LerpUtil.LerpRgb(from, to, factor);
                    break;
                case ColorLerpMode.HSV:
                    result = LerpUtil.LerpHsv(from, to, factor);
                    break;
                default:
                    result = @from * (1 - factor) + to * factor;
                    break;
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
