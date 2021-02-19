/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenerTVC.cs
//  Info     : 插值类基类 -- 组件
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween 
{
    public abstract class Tweener<TValue, TComponent> : Tweener<TValue> where TComponent : Component
	{
        #region Component

        /// <summary>
        /// 目标组件
        /// </summary>
        public TComponent Component
        {
            get
            {
                if (_component == null)
                {
                    _component = Target.GetComponent<TComponent>();
                }

                return _component;
            }

            internal set => _component = value;
        }

        private TComponent _component;

        #endregion

        public override void Awake() 
		{
			base.Awake();
			Component = Target.GetComponent<TComponent>();
		}

        #region Tween Update

		/// <summary>
		/// 插值更新
		/// </summary>
		public override void TweenUpdate()
		{
			var factor = CurrentFactor;
			var value = Evaluate(factor);
		    CurrentValue = value;
			Setter(value);
        } 
		
	    #endregion
    }
}

