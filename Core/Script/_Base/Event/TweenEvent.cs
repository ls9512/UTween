/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenEvent.cs
//  Info     : UnityEvent 调用优化
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine.Events;

namespace Aya.Tween
{
    public class TweenEvent : UnityEvent
    {
        internal int EventCount;
        internal int CallEventCount;
        internal int PersistentEventCount;

        public void Init()
        {
            UpdateCounter();
        }

        public void InvokeIfNeed()
        {
            if (EventCount == 0) return;
            Invoke();
        }

        public new void AddListener(UnityAction call)
        {
            base.AddListener(call);
            CallEventCount++;
            UpdateCounter();
        }

        public new void RemoveListener(UnityAction call)
        {
            base.RemoveListener(call);
            CallEventCount--;
            UpdateCounter();
        }

        public new void RemoveAllListeners()
        {
            base.RemoveAllListeners();
            CallEventCount = 0;
            UpdateCounter();
        }

        protected void UpdateCounter()
        {
            PersistentEventCount = GetPersistentEventCount();
            EventCount = CallEventCount + PersistentEventCount;
        }
    }

    public class TweenEvent<T> : UnityEvent<T>
    {
        internal int EventCount;
        internal int CallEventCount;
        internal int PersistentEventCount;

        public void Init()
        {
            UpdateCounter();
        }

        public void InvokeIfNeed(T arg0)
        {
            if (EventCount == 0) return;
            Invoke(arg0);
        }

        public new void AddListener(UnityAction<T> call)
        {
            base.AddListener(call);
            CallEventCount++;
            UpdateCounter();
        }

        public new void RemoveListener(UnityAction<T> call)
        {
            base.RemoveListener(call);
            CallEventCount--;
            UpdateCounter();
        }

        public new void RemoveAllListeners()
        {
            base.RemoveAllListeners();
            CallEventCount = 0;
            UpdateCounter();
        }

        protected void UpdateCounter()
        {
            PersistentEventCount = GetPersistentEventCount();
            EventCount = CallEventCount + PersistentEventCount;
        }
    }
}
