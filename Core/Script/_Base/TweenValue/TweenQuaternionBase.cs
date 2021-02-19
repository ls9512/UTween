/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenQuaternionBase.cs
//  Info     : Quaternion插值类基类
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	public abstract class TweenQuaternionBase<TComponent> : Tweener<Quaternion, TComponent> where TComponent : Component 
	{
	    public override Quaternion From
	    {
	        get => Param.FromQuaternion;
	        set => Param.FromQuaternion = value;
	    }

	    public override Quaternion To
	    {
	        get => Param.ToQuaternion;
	        set => Param.ToQuaternion = value;
	    }

        public override bool SupportSpeedBased => false;

        public override float GetSpeedBasedDuration()
        {
            return Duration;
        }

        public override Quaternion Evaluate(float factor)
        {
            var from = FromGetter();
            var to = ToGetter();
            var result = Quaternion.LerpUnclamped(from, to, factor);
            if (Curve != null && CurveTarget == CurveTargetType.Value)
            {
                var euler = result.eulerAngles * Curve.Evaluate(factor);
                result = Quaternion.Euler(euler);
            }

            return result;
        }

        public override void TweenUpdate()
	    {
	        base.TweenUpdate();
	        OnValueQuaternion.InvokeIfNeed(CurrentValue);
	    }
    }
}
