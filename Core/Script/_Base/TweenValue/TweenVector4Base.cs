/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVector4Base.cs
//  Info     : Vector4插值类基类
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	public abstract class TweenVector4Base<TComponent> : Tweener<Vector4, TComponent> where TComponent : Component 
	{
	    public override Vector4 From
	    {
	        get => Param.FromVector4;
	        set => Param.FromVector4 = value;
	    }

	    public override Vector4 To
	    {
	        get => Param.ToVector4;
	        set => Param.ToVector4 = value;
        }

        public override bool SupportSpeedBased => true;

        public override float GetSpeedBasedDuration()
        {
            var from = FromGetter();
            var to = ToGetter();
            var speed = Duration;
            var diff = to - from;
            var range = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y), Mathf.Abs(diff.z), Mathf.Abs(diff.w));
            var duration = range / speed;
            return duration;
        }

        public override Vector4 Evaluate(float factor) 
		{
		    Vector4 result;
		    var from = FromGetter();
		    var to = ToGetter();
		    switch (CurveMode)
            {
                case CurveMode.Single:
                {
                    var x = from.x * (1 - factor) + to.x * factor;
                    var y = from.y * (1 - factor) + to.y * factor;
                    var z = from.z * (1 - factor) + to.z * factor;
                    var w = from.w * (1 - factor) + to.w * factor;
                        result = new Vector4(x, y, z, w);
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
                    var factorZ = CurveZ.Evaluate(factor);
                    var factorW = CurveW.Evaluate(factor);
                    var x = from.x * (1 - factorX) + to.x * factorX;
                    var y = from.y * (1 - factorY) + to.y * factorY;
                    var z = from.z * (1 - factorZ) + to.z * factorZ;
                    var w = from.w * (1 - factorW) + to.w * factorW;
                    result = new Vector4(x, y, z, w);
                    break;
                }
                case CurveMode.Independent when CurveTarget == CurveTargetType.Value:
                {
                    var x = from.x * (1 - factor) + to.x * factor;
                    var y = from.y * (1 - factor) + to.y * factor;
                    var z = from.z * (1 - factor) + to.z * factor;
                    var w = from.w * (1 - factor) + to.w * factor;
                    result = new Vector4(x, y, z, w);
                    x = result.x * CurveX.Evaluate(factor);
                    y = result.y * CurveY.Evaluate(factor);
                    z = result.z * CurveZ.Evaluate(factor);
                    w = result.w * CurveW.Evaluate(factor);
                    result = new Vector4(x, y, z, w);
                    break;
                }
                case CurveMode.Independent:
                    result = default(Vector4);
                    break;
                default:
                    result = default(Vector4);
                    break;
            }

		    return result;
        }

	    public override void TweenUpdate()
	    {
	        base.TweenUpdate();
	        OnValueVector4.InvokeIfNeed(CurrentValue);
        }
    }
}
