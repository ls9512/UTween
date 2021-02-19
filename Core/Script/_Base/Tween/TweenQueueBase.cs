/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenQueueBase.cs
//  Info     : 批量插值类基类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;

namespace Aya.Tween
{
	public abstract class TweenQueueBase<TValue, TComponent> : Tweener<TValue, TComponent> where TComponent : Component
	{
        /// <summary>
        /// 参数列表
        /// </summary>
		public abstract List<TValue> Queue { get; set; }

        /// <summary>
        /// 当前阶段起始值
        /// </summary>
        protected TValue CurrentFrom;

		/// <summary>
		/// 当前阶段结束值
		/// </summary>
		protected TValue CurrentTo;

        /// <summary>
        /// 当前阶段索引
        /// </summary>
	    protected int CurrentIndex;

		public override void Start()
		{
			base.Start();
			if (Queue == null || Queue.Count < 2)
			{
				CurrentFrom = FromGetter();
				CurrentTo = ToGetter();
			}
		}

		/// <summary>
		/// 计算当前阶段插值范围
		/// </summary>
		/// <param name="factor">全局插值因子</param>
		public virtual void CurrentRange(float factor)
		{
			if (Queue == null || Queue.Count < 2)
			{
				return;
			}
			// 计算阶段数
			var length = Queue.Count - 1;
			var each = 1f / length;
			if (!IsPlayBackward)
			{
			    CurrentIndex = (int)(factor / each);
			    CurrentIndex = Mathf.Clamp(CurrentIndex, 0, Queue.Count - 2);
                // 确定起止点
                CurrentFrom = Queue[CurrentIndex];
				CurrentTo = Queue[CurrentIndex + 1];
			}
			else
			{			   
			    if (factor <= 0f)
			    {
			        CurrentIndex = 1;
			    }
			    else
			    {
			        CurrentIndex = length - (int)((1f - factor) / each);
                }
                // 确定起止点
                CurrentFrom = Queue[CurrentIndex];
				CurrentTo = Queue[CurrentIndex - 1];
			}
		}

		/// <summary>
		/// 计算当前阶段插值因子
		/// </summary>
		/// <param name="factor">全局插值因子</param>
		/// <returns>结果</returns>
		public virtual float CurrentRangeFactor(float factor)
		{
		    if (factor <= 0f && IsPlayBackward)
		    {
		        return 1f;
		    }

            // 消除最后一段的抖动
            if (Mathf.Abs(factor - 1) < 1e-6) return 1f;
            // 阶段数
            var length = Queue.Count - 1;
			// 每阶段比例
			var each = 1f / length;
			var eachFactor = IsPlayBackward ? 1f - factor : factor;
			// 计算当前阶段插值因子
			while (eachFactor >= each)
			{
				eachFactor -= each;
			}
			eachFactor = eachFactor / each;
			return eachFactor;
		}
	}
}
