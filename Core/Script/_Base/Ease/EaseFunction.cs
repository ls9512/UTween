/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseFunction.cs
//  Info     : 插值算法
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    public abstract class EaseFunction
    {
        public abstract int Type { get; }

        public abstract float Ease(float from, float to, float delta);
    }
}
