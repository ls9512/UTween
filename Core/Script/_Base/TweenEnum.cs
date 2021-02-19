/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenEnum.cs
//  Info     : 插值枚举
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    /// <summary>
    /// 曲线模式
    /// </summary>
    public enum CurveMode
    {
        /// <summary>
        /// 单曲线
        /// </summary>
        Single = 1,
        /// <summary>
        /// 独立曲线
        /// </summary>
        Independent = 2
    }

    /// <summary>
    /// 曲线作用对象类型
    /// </summary>
    public enum CurveTargetType
    {
        /// <summary>
        /// 插值因子
        /// </summary>
        Factor = 1,
        /// <summary>
        /// 插值结果数值
        /// </summary>
        Value = 2,
    }

    /// <summary>
    /// 颜色插值模式
    /// </summary>
    public enum ColorLerpMode
    {
        RGB = 0,
        HSV = 1,
    }

    /// <summary>
    /// 色块类型
    /// </summary>
    public enum ColorBlockType
    {
        NormalColor = 1,
        DisabledColor = 2,
        HighlightedColor = 3,
        PressedColor = 4
    }

    /// <summary>
    /// 路径模式
    /// </summary>
    public enum PathMode
    {
        /// <summary>
        /// 点到点，折线
        /// </summary>
        PointToPoint = 1,
        /// <summary>
        /// 样条曲线
        /// </summary>
        CatmullRom = 2,
    }

    /// <summary>
	/// 自动播放类型
	/// </summary>
	public enum AutoPlayType
	{
		None = 0,
		Awake = 1,
		Enable = 2,
		Start = 3
	}

	/// <summary>
	/// 更新类型
	/// </summary>
	public enum UpdateType
	{
		Update = 0,
		LateUpdate = 1,
		FixedUpdate = 2
	}

	public enum PlayType 
	{
		/// <summary>
		/// 一次
		/// </summary>
		Once = 10,
		/// <summary>
		/// 循环
		/// </summary>
		Loop = 20,
        /// <summary>
        /// 循环指定次数
        /// </summary>
        LoopCount = 21,
		/// <summary>
		/// 往返
		/// </summary>
		PingPong = 30,
        /// <summary>
        /// 往返指定次数a
        /// </summary>
        PingPongCount = 31,
	}
}
