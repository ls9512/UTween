/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenParallel.cs
//  Info     : 并行插值动画
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;

namespace Aya.Tween
{
    [Tweener(TweenType.Parallel, false)]
    public class TweenParallel : Tweener<float>
    {
        public override int Type => TweenType.Parallel;

        public override float From
        {
            get => 0f;
            set { }
        }

        public override float To
        {
            get => 1f;
            set { }
        }

        public override bool SupportSpeedBased => false;

        #region Tweenr List

        internal List<Tweener> Tweeners = new List<Tweener>();

        public TweenParallel Append(Tweener tweener)
        {
            Tweeners.Add(tweener);
            if (tweener.IsPlaying)
            {
                tweener.Pause();
            }
            return this;
        }

        public TweenParallel Append(IEnumerable<Tweener> tweeners)
        {
            foreach (var tweener in tweeners)
            {
                Tweeners.Add(tweener);
            }
            return this;
        }

        public TweenParallel Remove(Tweener tweener)
        {
            if (!Tweeners.Contains(tweener)) return this;
            Tweeners.Remove(tweener);
            TweenManager.Ins.DeSpawn(tweener);
            return this;
        }

        public TweenParallel Clear()
        {
            foreach (var tweener in Tweeners)
            {
                TweenManager.Ins.DeSpawn(tweener);
            }
            Tweeners.Clear();
            return this;
        }

        #endregion

        public override float GetSpeedBasedDuration()
        {
            return Duration;
        }

        public override void TweenUpdate()
        {
            var factor = CurrentFactor;
            var value = Evaluate(factor);
            CurrentValue = value;
            Setter(value);
        }

        public override float Evaluate(float factor)
        {
            var result = From + (To - From) * factor;
            if (Curve != null && CurveTarget == CurveTargetType.Value)
            {
                result = result * Curve.Evaluate(factor);
            }

            return result;
        }

        public override void Play()
        {
            if (Tweeners.Count == 0)
            {
                Stop(true);
                return;
            }

            Duration = GetDuration();
            base.Play();
        }

        public override void PlayBackward(bool immediately = false)
        {
            if (Tweeners.Count == 0)
            {
                Stop(true);
                return;
            }

            Duration = GetDuration();
            base.PlayBackward(immediately);
        }

        public override void Stop(bool destroy = true)
        {
            base.Stop(destroy);
            if (destroy)
            {
                for (var i = Tweeners.Count - 1; i >= 0; i--)
                {
                    var tweener = Tweeners[i];
                    tweener.Stop(true);
                }
            }

            Tweeners.Clear();
        }

        protected override void SetValue(float value)
        {
            var runTime = value * Duration;
            foreach (var tweener in Tweeners)
            {
                var factor = runTime / tweener.Duration;
                if (factor > 1f) continue;
                tweener.SetSchedule(factor);
            }
        }

        public override void Reset()
        {
            base.Reset();
            Clear();
        }

        public float GetDuration()
        {
            var duration = 0f;
            foreach (var tweener in Tweeners)
            {
                if (tweener.Duration > duration) duration = tweener.Duration;
            }

            return duration;
        }
    }
}
