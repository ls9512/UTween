/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTransform.cs
//  Info     : Transform 插值类
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponents(typeof(Transform))]
    [Tweener(TweenType.Transform)]
    public class TweenTransform : Tweener<Transform, Transform>
    {
        public override int Type => TweenType.Transform;

        public override Transform From
        {
            get => Param.FromTransform;
            set => Param.FromTransform = value;
        }

        public override Transform To
        {
            get => Param.ToTransform;
            set => Param.ToTransform = value;
        }

        public override bool SupportSpeedBased => false;

        protected virtual void SetValue(float value)
        {
            var from = FromGetter();
            var to = ToGetter();
            if (WorldSpace)
            {
                Transform.position = Vector3.Lerp(from.position, to.position, value);
                Transform.eulerAngles = Clerp(from.eulerAngles, to.eulerAngles, value);
            }
            else
            {
                Transform.localPosition = Vector3.Lerp(from.localPosition, to.localPosition, value);
                Transform.localEulerAngles = Clerp(from.localEulerAngles, to.localEulerAngles, value);
            }

            Transform.localScale = Vector3.Lerp(from.localScale, to.localScale, value);
        }

        public override Transform Evaluate(float factor)
        {
            throw new NotImplementedException();
        }

        protected override void SetValue(Transform value)
        {
            CopyTrans(Transform, value, WorldSpace);
        }

        public override float GetSpeedBasedDuration()
        {
            return Duration;
        }

        public override void TweenUpdate()
        {
            var factor = Factor();
            SetValue(factor);
        }

        public override void SetCurrent2From()
        {
            CopyTrans(From, Transform, WorldSpace);
        }

        public override void SetCurrent2To()
        {
            CopyTrans(To, Transform, WorldSpace);
        }

        public override void SetFrom2Current()
        {
            CopyTrans(Transform, From, WorldSpace);
        }

        public override void SetTo2Current()
        {
            CopyTrans(Transform, To, WorldSpace);
        }

        protected static Vector3 Clerp(Vector3 start, Vector3 end, float delta)
        {
            var ret = new Vector3
            {
                x = Clerp(start.x, end.x, delta),
                y = Clerp(start.y, end.y, delta),
                z = Clerp(start.z, end.z, delta)
            };
            return ret;
        }

        protected static float Clerp(float start, float end, float delta)
        {
            var min = 0f;
            var max = 360f;
            var half = Mathf.Abs((max - min) / 2.0f); // half the distance between min and max
            float retval;
            float diff;
            if ((end - start) < -half)
            {
                diff = ((max - start) + end) * delta;
                retval = start + diff;
            }
            else if ((end - start) > half)
            {
                diff = -((max - end) + start) * delta;
                retval = start + diff;
            }
            else retval = start + (end - start) * delta;
            return retval;
        }

        protected static void CopyTrans(Transform transform, Transform src, bool isWordSpace)
        {
            if (isWordSpace)
            {
                transform.position = src.position;
                transform.rotation = src.rotation;
            }
            else
            {
                transform.localPosition = src.localPosition;
                transform.localRotation = src.localRotation;
            }

            transform.localScale = src.localScale;
        }
    }
}
