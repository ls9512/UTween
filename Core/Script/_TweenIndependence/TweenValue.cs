/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenValue.cs
//  Info     : 浮点插值类
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween
{
    [Tweener(TweenType.Value)]
    public class TweenValue : Tweener<float>
    {
        public override int Type => TweenType.Value;

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
        
        public Action<float> OnValueCallback = delegate { };

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
                result = result * Curve.Evaluate(factor);
            }

            return result;
        }

        public override void TweenUpdate()
        {
            var factor = CurrentFactor;
            var value = Evaluate(factor);
            CurrentValue = value;
            Setter(value);
        }

        protected override void SetValue(float value)
        {
            OnValueFloat.InvokeIfNeed(CurrentValue);
            OnValueCallback?.Invoke(value);
        }

        public override void Reset()
        {
            base.Reset();
            OnValueCallback = delegate { };
        }
    }
}
