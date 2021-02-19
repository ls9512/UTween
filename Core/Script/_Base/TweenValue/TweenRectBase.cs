/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRectBase.cs
//  Info     : Rect插值类基类
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    public abstract class TweenRectBase<TComponent> : Tweener<Rect, TComponent> where TComponent : Component
    {
        public override Rect From
        {
            get => Param.FromRect;
            set => Param.FromRect = value;
        }

        public override Rect To
        {
            get => Param.ToRect;
            set => Param.ToRect = value;
        }

        public override bool SupportSpeedBased => false;

        public override float GetSpeedBasedDuration()
        {
            return Duration;
        }

        public override Rect Evaluate(float factor)
        {
            var from = FromGetter();
            var to = ToGetter();
            var x = from.x + (to.x - from.x) * factor;
            var y = from.y + (to.y - from.y) * factor;
            var width = from.width + (to.width - from.width) * factor;
            var height = from.height + (to.height - from.height) * factor;
            var result = new Rect(x, y, width, height);
            if (Curve != null && CurveTarget == CurveTargetType.Value)
            {
                var value = Curve.Evaluate(factor);
                result = new Rect(result.x * value, result.y * value, result.width * value, result.height * value);
            }

            return result;
        }

        public override void TweenUpdate()
        {
            base.TweenUpdate();
            OnValueRect.InvokeIfNeed(CurrentValue);
        }
    }
}
