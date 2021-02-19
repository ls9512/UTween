/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenShakeArgs.cs
//  Info     : 震动插值参数类
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;

namespace Aya.Tween
{
    /// <summary>
    /// 震动插值参数
    /// </summary>
    [Serializable]
    public class TweenShakeArgs
    {
        /// <summary>
        /// 振动位置
        /// </summary>
        public bool ShakePos = true;

        /// <summary>
        /// 位置各轴向震动力度(最大)
        /// </summary>
        public Vector3 PowerPos = Vector3.one;

        /// <summary>
        /// 振动旋转
        /// </summary>
        public bool ShakeRot = true;

        /// <summary>
        /// 旋转各轴向震动力度(最大)
        /// </summary>
        public Vector3 PowerRot = Vector3.zero;

        /// <summary>
        /// 振动缩放
        /// </summary>
        public bool ShakeScale = true;

        /// <summary>
        /// 旋转各轴向缩放力度(最大)
        /// </summary>
        public Vector3 PowerScale = Vector3.zero;

        /// <summary>
        /// 指定时间内震动次数
        /// </summary>
        public int Count = 3;

        #region Construct null
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public TweenShakeArgs()
        {
        } 
        
        #endregion

        #region Construct float

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="power">位置震动强度</param>
        /// <param name="count">震动次数</param>
        public TweenShakeArgs(float power, int count) : this(power, 0f, 0f, count)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="powerPos">位置震动强度</param>
        /// <param name="powerRot">旋转震动强度</param>
        /// <param name="count">震动次数</param>
        public TweenShakeArgs(float powerPos, float powerRot, int count) : this(powerPos, powerRot, 0f, count)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="powerPos">位置震动强度</param>
        /// <param name="powerRot">旋转震动强度</param>
        /// <param name="powerScale">缩放震动强度</param>
        /// <param name="count">震动次数</param>
        public TweenShakeArgs(float powerPos, float powerRot, float powerScale, int count)
        {
            if (Math.Abs(powerPos) < 1e-6)
            {
                ShakePos = false;
            }
            else
            {
                PowerPos = Vector3.one * powerPos;
            }

            if (Math.Abs(powerRot) < 1e-6)
            {
                ShakeRot = false;
            }
            else
            {
                PowerRot = Vector3.one * powerRot;
            }

            if (Math.Abs(powerScale) < 1e-6)
            {
                ShakeScale = false;
            }
            else
            {
                PowerScale = Vector3.one * powerScale;
            }

            Count = count;
        }

        #endregion

        #region Construct Vector3

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="power">位置震动向量</param>
        /// <param name="count">震动次数</param>
        public TweenShakeArgs(Vector3 power, int count) : this(power, Vector3.zero, Vector3.zero, count)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="powerPos">位置震动向量</param>
        /// <param name="powerRot">旋转震动向量</param>
        /// <param name="count">震动次数</param>
        public TweenShakeArgs(Vector3 powerPos, Vector3 powerRot, int count) : this(powerPos, powerRot, Vector3.zero, count)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="powerPos">位置震动向量</param>
        /// <param name="powerRot">旋转震动向量</param>
        /// <param name="powerScale">缩放震动向量</param>
        /// <param name="count">震动次数</param>
        public TweenShakeArgs(Vector3 powerPos, Vector3 powerRot, Vector3 powerScale, int count)
        {
            if (powerPos == Vector3.zero)
            {
                ShakePos = false;
            }
            else
            {
                PowerPos = powerPos;
            }

            if (powerRot == Vector3.zero)
            {
                ShakeRot = false;
            }
            else
            {
                PowerRot = powerRot;
            }

            if (powerScale == Vector3.zero)
            {
                ShakeScale = false;
            }
            else
            {
                PowerScale = powerScale;
            }

            Count = count;
        } 
       
        #endregion
    }
}