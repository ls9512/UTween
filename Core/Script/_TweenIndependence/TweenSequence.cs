/////////////////////////////////////////////////////////////////////////////
//
//  Script   : 顺序插值动画.cs
//  Info     : 并行插值动画
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;

namespace Aya.Tween
{
    [Tweener(TweenType.Sequence, false)]
    public class TweenSequence : Tweener<float>
    {
        public override int Type => TweenType.Sequence;

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

        public TweenSequence Append(Tweener tweener)
        {
            Tweeners.Add(tweener);
            if (tweener.IsPlaying)
            {
                tweener.Pause();
            }
            return this;
        }

        public TweenSequence Append(IEnumerable<Tweener> tweeners)
        {
            foreach (var tweener in tweeners)
            {
                Tweeners.Add(tweener);
            }
            return this;
        }

        public TweenSequence Insert(int index, Tweener tweener)
        {
            Tweeners.Insert(index, tweener);
            return this;
        }

        public TweenSequence Insert(int index, IEnumerable<Tweener> tweeners)
        {
            var insertIndex = index;
            foreach (var tweener in tweeners)
            {
                Tweeners.Insert(insertIndex, tweener);
                insertIndex++;
            }
            return this;
        }

        public TweenSequence Remove(Tweener tweener)
        {
            if (!Tweeners.Contains(tweener)) return this;
            Tweeners.Remove(tweener);
            TweenManager.Ins.DeSpawn(tweener);
            return this;
        }

        public TweenSequence Clear()
        {
            foreach (var tweener in Tweeners)
            {
                TweenManager.Ins.DeSpawn(tweener);
            }
            Tweeners.Clear();
            return this;
        }
       
        #endregion

        public override void TweenUpdate()
        {
            var factor = CurrentFactor;
            var value = Evaluate(factor);
            CurrentValue = value;
            Setter(value);
        }

        public override float GetSpeedBasedDuration()
        {
            return Duration;
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
            var index = 0;
            var runTime = value * Duration;
            var currentTime = 0f;
            foreach (var tweener in Tweeners)
            {
                currentTime += tweener.Duration;
                if (runTime <= currentTime)
                {
                    break;
                }

                index++;
            }
            var currentTweener = Tweeners[index];
            var factorTime = (currentTweener.Duration - (currentTime - runTime));
            var factor = factorTime / currentTweener.Duration;
            currentTweener.SetSchedule(factor);
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
                duration += tweener.Duration;
            }

            return duration;
        }
    }
}
