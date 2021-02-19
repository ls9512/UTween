/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenFloatBase.cs
//  Info     : 浮点插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    public abstract class TweenFloatBase<TComponent> : Tweener<float, TComponent> where TComponent : Component
    {
        public override float From
        {
            get => Param.FromFloat;
            set => Param.FromFloat = value;
        }

        public override float To
        {
            get => Param.ToFloat;
            set => Param.ToFloat = value;
        }

        public override bool SupportSpeedBased => true;

        public override float GetSpeedBasedDuration()
        {
            var from = FromGetter();
            var to = ToGetter();
            var speed = Duration;
            var range = to - from;
            var duration = range / speed;
            return duration;
        }

        public override float Evaluate(float factor)
        {
            var from = FromGetter();
            var to = ToGetter();
            var result = from + (to - from) * factor;
            if (Curve != null && CurveTarget == CurveTargetType.Value)
            {
                result *= Curve.Evaluate(factor);
            }

            return result;
        }

        public override void TweenUpdate()
        {
            base.TweenUpdate();
            OnValueFloat.InvokeIfNeed(CurrentValue);
        }
    }
}
