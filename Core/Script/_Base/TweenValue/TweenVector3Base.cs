/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVector3Base.cs
//  Info     : Vector3插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	public abstract class TweenVector3Base<TComponent> : Tweener<Vector3, TComponent> where TComponent : Component 
	{
	    public override Vector3 From
	    {
	        get => Param.FromVector3;
	        set => Param.FromVector3 = value;
	    }

	    public override Vector3 To
	    {
	        get => Param.ToVector3;
	        set => Param.ToVector3 = value;
        }

        public override bool SupportSpeedBased => true;

        public override float GetSpeedBasedDuration()
        {
            var from = FromGetter();
            var to = ToGetter();
            var speed = Duration;
            var diff = to - from;
            var range = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y), Mathf.Abs(diff.z));
            var duration = range / speed;
            return duration;
        }

        public override Vector3 Evaluate(float factor) 
		{
		    Vector3 result;
		    var from = FromGetter();
		    var to = ToGetter();
		    switch (CurveMode)
            {
                case CurveMode.Single:
                {
                    var x = from.x * (1 - factor) + to.x * factor;
                    var y = from.y * (1 - factor) + to.y * factor;
                    var z = from.z * (1 - factor) + to.z * factor;
                    result = new Vector3(x, y, z);
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
                    var x = from.x * (1 - factorX) + to.x * factorX;
                    var y = from.y * (1 - factorY) + to.y * factorY;
                    var z = from.z * (1 - factorZ) + to.z * factorZ;
                    result = new Vector3(x, y, z);
                    break;
                }
                case CurveMode.Independent when CurveTarget == CurveTargetType.Value:
                {
                    var x = from.x * (1 - factor) + to.x * factor;
                    var y = from.y * (1 - factor) + to.y * factor;
                    var z = from.z * (1 - factor) + to.z * factor;
                    result = new Vector3(x, y, z);
                    x = result.x * CurveX.Evaluate(factor);
                    y = result.y * CurveY.Evaluate(factor);
                    z = result.z * CurveZ.Evaluate(factor);
                    result = new Vector3(x, y, z);
                    break;
                }
                case CurveMode.Independent:
                    result = default(Vector3);
                    break;
                default:
                    result = default(Vector3);
                    break;
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
