/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EaseType.cs
//  Info     : 插值计算类型
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aya.Tween
{
    [EnumClass("EaseType")]
	public static class EaseType
	{
        public static Dictionary<string, int> NameValueDic { get; set; } = new Dictionary<string, int>();
        public static Dictionary<int, string> ValueShowNameDic { get; set; } = new Dictionary<int, string>();
        public static Dictionary<int, string> ValueNameDic { get; set; } = new Dictionary<int, string>();
        public static Dictionary<int, Type> ValueTypeDic { get; set; } = new Dictionary<int, Type>();
        public static Dictionary<int, EaseFunction> ValueFunctionDic { get; set; } = new Dictionary<int, EaseFunction>();

        [EnumProperty]
        public const int Linear = 0;
        [EnumProperty]
        public const int Circular = 1;
        [EnumProperty("Quad", "Ease In Quad")]
        public const int EaseInQuad = 2;
        [EnumProperty("Quad", "Ease Out Quad")]
        public const int EaseOutQuad = 3;
        [EnumProperty("Quad", "Ease In Out Quad")]
        public const int EaseInOutQuad = 4;
        [EnumProperty("Quad", "Ease In Cubic")]
        public const int EaseInCubic = 5;
        [EnumProperty("Cubic", "Ease Out Cubic")]
        public const int EaseOutCubic = 6;
        [EnumProperty("Cubic", "Ease In Out Cubic")]
        public const int EaseInOutCubic = 7;
        [EnumProperty("Quart", "Ease In Quart")]
        public const int EaseInQuart = 8;
        [EnumProperty("Quart", "Ease Out Quart")]
        public const int EaseOutQuart = 9;
        [EnumProperty("Quart", "Ease In Out Quart")]
        public const int EaseInOutQuart = 10;
        [EnumProperty("Quart", "Ease In Quint")]
        public const int EaseInQuint = 11;
        [EnumProperty("Quint", "Ease Out Quint")]
        public const int EaseOutQuint = 12;
        [EnumProperty("Quint", "Ease In Out Quint")]
        public const int EaseInOutQuint = 13;
        [EnumProperty("Sine", "Ease In Sine")]
        public const int EaseInSine = 14;
        [EnumProperty("Sine", "Ease Out Sine")]
        public const int EaseOutSine = 15;
        [EnumProperty("Sine", "Ease In Out Sine")]
        public const int EaseInOutSine = 16;
        [EnumProperty("Expo", "Ease In Expo")]
        public const int EaseInExpo = 17;
        [EnumProperty("Expo", "Ease Out Expo")]
        public const int EaseOutExpo = 18;
        [EnumProperty("Expo", "Ease In Out Expo")]
        public const int EaseInOutExpo = 19;
        [EnumProperty("Circ", "Ease In Circ")]
        public const int EaseInCirc = 20;
        [EnumProperty("Circ", "Ease Out Circ")]
        public const int EaseOutCirc = 21;
        [EnumProperty("Circ", "Ease In Out Circ")]
        public const int EaseInOutCirc = 22;
        [EnumProperty]
        public const int Spring = 23;
        [EnumProperty("Back", "Ease In Back")]
        public const int EaseInBack = 24;
        [EnumProperty("Back", "Ease Out Back")]
        public const int EaseOutBack = 25;
        [EnumProperty("Back", "Ease In Out Back")]
        public const int EaseInOutBack = 26;
        [EnumProperty]
        public const int Punch = 27;
        [EnumProperty("Bounce", "Ease In Bounce")]
        public const int EaseInBounce = 28;
        [EnumProperty("Bounce", "Ease Out Bounce")]
        public const int EaseOutBounce = 29;
        [EnumProperty("Bounce", "Ease In Out Bounce")]
        public const int EaseInOutBounce = 30;
        [EnumProperty("Elastic", "Ease In Elastic")]
        public const int EaseInElastic = 31;
        [EnumProperty("Elastic", "Ease Out Elastic")]
        public const int EaseOutElastic = 32;
        [EnumProperty("Elastic", "Ease In Out Elastic")]
        public const int EaseInOutElastic = 33;

        static EaseType()
        {
            var assembly = typeof(EaseType).Assembly;
            var space = typeof(EaseType).Namespace;
            var enumName = nameof(EaseType);
            var infos = SerializeEnumAttribute.TypeInfosDic[enumName];
            foreach (var info in infos)
            {
                ValueNameDic.Add(info.Index, info.Name);
                ValueShowNameDic.Add(info.Index, info.DisplayName);
                NameValueDic.Add(info.DisplayName, info.Index);
            }

            foreach (var kv in ValueNameDic)
            {
                var typeName = kv.Value;
                var fullTypeName = space + "." + typeName;
                var type = assembly.GetType(fullTypeName);
                ValueTypeDic.Add(kv.Key, type);
                var function = Activator.CreateInstance(type) as EaseFunction;
                ValueFunctionDic.Add(kv.Key, function);
            }
        }
    }
}
