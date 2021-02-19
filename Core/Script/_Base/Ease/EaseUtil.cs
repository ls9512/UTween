/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseUtil.cs
//  Info     : 插值计算辅助类
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
namespace Aya.Tween
{
    public static class EaseUtil
    {
        public static EaseFunction GetEaseFunction(int easeType)
        {
            return EaseType.ValueFunctionDic[easeType];
        }

        public static float Ease(int easeType, float from, float to, float delta)
        {
            var easeFunction = GetEaseFunction(easeType);
            var result = easeFunction.Ease(from, to, delta);
            return result;
        }
    }
}