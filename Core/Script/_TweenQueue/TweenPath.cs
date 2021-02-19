/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPath.cs
//  Info     : 路径插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponents(typeof(Transform))]
    [Tweener(TweenType.Path)]
    public class TweenPath : TweenQueueVector3Base<Transform>
    {
        public override int Type => TweenType.Path;

        public bool ClosedLoop
        {
            get
            {
                if (Queue.Count < 1) return false;
                return Queue[0] == Queue[Queue.Count - 1];
            }
        }

        public override float GetSpeedBasedDuration()
        {
            return Duration;
        }

        public override Vector3 Evaluate(float factor)
        {
            if (PathMode == PathMode.PointToPoint)
            {
                return base.Evaluate(factor);
            }

            if (PathMode == PathMode.CatmullRom)
            {
                if (Queue.Count < 4)
                {
                    return base.Evaluate(factor);
                }

                CurrentRange(factor);
                var currentFactor = CurrentRangeFactor(factor);
                var result = CaculateCurrentValue(CurrentIndex, currentFactor);
                return result;
            }

            return Vector3.zero;
        }

        protected override void SetValue(Vector3 value)
        {
            if (WorldSpace)
            {
                Transform.position = value;
            }
            else
            {
                Transform.localPosition = value;
            }
        }

        public override float CurrentRangeFactor(float factor)
        {
            if (PathMode == PathMode.PointToPoint)
            {
                return base.CurrentRangeFactor(factor);
            }

            if (PathMode == PathMode.CatmullRom)
            {
                if (Queue.Count < 4)
                {
                    return base.CurrentRangeFactor(factor);
                }

                if (factor <= 0f)
                {
                    return IsPlayBackward ? 0f : 1f;
                }

                var length = Queue.Count - 1;
                var each = 1f / length;
                var eachFactor = factor;
                while (eachFactor >= each)
                {
                    eachFactor -= each;
                }

                eachFactor = eachFactor / each;
                return eachFactor;
            }

            return 0f;
        }

        public override void CurrentRange(float factor)
        {
            if (PathMode == PathMode.PointToPoint)
            {
                base.CurrentRange(factor);
            }

            if (PathMode == PathMode.CatmullRom)
            {
                if (Queue.Count < 4)
                {
                    base.CurrentRange(factor);
                    return;
                }

                var length = Queue.Count - 1;
                var each = 1f / length;
                if (!IsPlayBackward)
                {
                    CurrentIndex = (int)(factor / each);
                }
                else
                {
                    if (factor <= 0f)
                    {
                        CurrentIndex = 0;
                    }
                    else
                    {
                        CurrentIndex = length - (int)((1f - factor) / each) - 1;
                    }
                }
            }
        }

        #region CatmullRom

        private Vector3 CaculateCurrentValue(int index, float factor)
        {
            if (index < 1)
            {
                var p1 = ClosedLoop ? Queue[Queue.Count - 2] : Queue[index] * 2f - Queue[index + 1];
                var p2 = Queue[index];
                var p3 = Queue[index + 1];
                var p4 = Queue[index + 2];
                var result = CatmullRom(p1, p2, p3, p4, factor);
                return result;
            }
            else if (index < Queue.Count - 2)
            {
                var p1 = Queue[index - 1];
                var p2 = Queue[index];
                var p3 = Queue[index + 1];
                var p4 = Queue[index + 2];
                var result = CatmullRom(p1, p2, p3, p4, factor);
                return result;
            }
            else if(index < Queue.Count - 1)
            {
                var p1 = Queue[index - 1];
                var p2 = Queue[index];
                var p3 = Queue[index + 1];
                var p4 = ClosedLoop ? Queue[1] : Queue[index + 1] * 2f - Queue[index];
                var result = CatmullRom(p1, p2, p3, p4, factor);
                return result;
            }

            return Queue[0];
        }

        private static Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float delta)
        {
            var factor = 0.5f;
            var c0 = p1;
            var c1 = (p2 - p0) * factor;
            var c2 = (p2 - p1) * 3f - (p3 - p1) * factor - (p2 - p0) * 2f * factor;
            var c3 = (p2 - p1) * -2f + (p3 - p1) * factor + (p2 - p0) * factor;
            var curvePoint = c3 * delta * delta * delta + c2 * delta * delta + c1 * delta + c0;
            return curvePoint;
        }

        #endregion
    }
}