/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenCallbackEvent.cs
//  Info     : 插值动画回调定义类
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;

namespace Aya.Tween
{
    #region OnPlay / OnStop
   
    /// <summary>
    /// 开始播放回调
    /// </summary>
    [Serializable]
    public class OnPlayEvent : TweenEvent
    {
    }

    /// <summary>
    /// 停止播放回调
    /// </summary>
    [Serializable]
    public class OnStopEvent : TweenEvent
    {
    } 
   
    #endregion

    #region OnValue
    
    /// <summary>
    /// 数值更新回调 - 浮点
    /// </summary>
    [Serializable]
    public class OnFloatValueEvent : TweenEvent<float>
    {
    }

    /// <summary>
    /// 数值更新回调 - 颜色
    /// </summary>
    [Serializable]
    public class OnColorValueEvent : TweenEvent<Color>
    {
    }

    /// <summary>
    /// 数值更新回调 - 二维向量
    /// </summary>
    [Serializable]
    public class OnVector2ValueEvent : TweenEvent<Vector2>
    {
    }

    /// <summary>
    /// 数值更新回调 - 三维向量
    /// </summary>
    [Serializable]
    public class OnVector3ValueEvent : TweenEvent<Vector3>
    {
    }

    /// <summary>
    /// 数值更新回调 - 四维向量
    /// </summary>
    [Serializable]
    public class OnVector4ValueEvent : TweenEvent<Vector4>
    {
    }

    /// <summary>
    /// 数值更新回调 - 四元数
    /// </summary>
    [Serializable]
    public class OnQuaternionValueEvent : TweenEvent<Quaternion>
    {
    }

    /// <summary>
    /// 数值更新回调 - 矩形
    /// </summary>
    [Serializable]
    public class OnRectValueEvent : TweenEvent<Rect>
    {
    }

    /// <summary>
    /// 数值更新回调 - 字符串
    /// </summary>
    [Serializable]
    public class OnStringValueEvent : TweenEvent<string>
    {
    }

    #endregion
}
