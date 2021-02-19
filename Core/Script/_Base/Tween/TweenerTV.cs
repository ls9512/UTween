/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenerTV.cs
//  Info     : 插值类基类 -- 值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;

namespace Aya.Tween 
{
    public abstract class Tweener<TValue> : Tweener
	{
		#region Value
		
	    /// <summary>
		/// 开始值
		/// </summary>
		public abstract TValue From { get; set; }

		/// <summary>
		/// 结束值
		/// </summary>
		public abstract TValue To { get; set; }

        /// <summary>
        /// 当前插值进度值
        /// </summary>
        public TValue CurrentValue;

        #endregion

        #region Setter

        /// <summary>
        /// 插值结果设置器
        /// </summary>
        public Action<TValue> Setter;

        #endregion

        #region Getter

        /// <summary>
        /// 起始值获取器
        /// </summary>
        public Func<TValue> FromGetter;

        /// <summary>
        /// 结束值获取器
        /// </summary>
        public Func<TValue> ToGetter;

        #endregion

        /// <summary>
        /// 根据插值因子计算插值的结果
        /// </summary>
        /// <param name="factor">全局插值因子</param>
        /// <returns>结果</returns>
        public abstract TValue Evaluate(float factor);

        /// <summary>
        /// 将插值结果设置到插值对象
        /// </summary>
        /// <param name="value">值</param>
        protected abstract void SetValue(TValue value);

        public override void Reset()
        {
            base.Reset();

            FromGetter = () => From;
            ToGetter = () => To;
            Setter = SetValue;
        }
    }
}

