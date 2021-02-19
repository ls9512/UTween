/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVector2Base.cs
//  Info     : Vector2插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	public abstract class TweenVector2Base<TComponent> : Tweener<Vector2, TComponent> where TComponent : Component 
	{
	    public override Vector2 From
	    {
	        get => Param.FromVector2;
	        set => Param.FromVector2 = value;
	    }

	    public override Vector2 To
	    {
	        get => Param.ToVector2;
	        set => Param.ToVector2 = value;
	    }

        public override bool SupportSpeedBased => true;

        public override float GetSpeedBasedDuration()
        {
            var from = FromGetter();
            var to = ToGetter();
            var speed = Duration;
            var diff = to - from;
            var range = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y));
            var duration = range / speed;
            return duration;
        }

        public override Vector2 Evaluate(float factor)
	    {
	        Vector2 result;
            var from = FromGetter();
            var to = ToGetter();
            switch (CurveMode)
            {
                case CurveMode.Single:
                {
                    var x = @from.x * (1 - factor) + to.x * factor;
                    var y = @from.y * (1 - factor) + to.y * factor;
                    result = new Vector2(x, y);
                    if (Curve != null && CurveTarget == CurveTargetType.Value)
                    {
                        result *= Curve.Evaluate(factor);
                    }

                    break;
                }
                case CurveMode.Independent when CurveTarget == CurveTargetType.Factor:
                {
                    var factorX = CurveX.Evaluate(factor);
                    var factorY = CurveY.Evaluate(factor);
                    var x = @from.x * (1 - factorX) + to.x * factorX;
                    var y = @from.y * (1 - factorY) + to.y * factorY;
                    result = new Vector2(x, y);
                    break;
                }
                case CurveMode.Independent when CurveTarget == CurveTargetType.Value:
                {
                    var x = @from.x * (1 - factor) + to.x * factor;
                    var y = @from.y * (1 - factor) + to.y * factor;
                    result = new Vector2(x, y);
                    x = result.x * CurveX.Evaluate(factor);
                    y = result.y * CurveY.Evaluate(factor);
                    result = new Vector2(x, y);
                    break;
                }
                case CurveMode.Independent:
                    result = default(Vector2);
                    break;
                default:
                    result = default(Vector2);
                    break;
            }

	        return result;
	    }

        public override void TweenUpdate()
	    {
	        base.TweenUpdate();
	        OnValueVector2.InvokeIfNeed(CurrentValue);
	    }
    }
}
