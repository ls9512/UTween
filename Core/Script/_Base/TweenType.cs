/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenType.cs
//  Info     : 插值动画类型枚举
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////

namespace Aya.Tween
{
    [EnumClass("TweenType")]
    public static class TweenType
    {
        [EnumProperty]
        public const int None = -1;

        [EnumProperty("Transform", "Position")]
        public const int Position = 10;                     // 位置
        [EnumProperty("Rect Transform", "Position UGUI")]
        public const int PositionUGUI = 11;                 // 位置(UGUI)
        [EnumProperty("Transform", "Rotation EulerAngles")]
        public const int Rotation = 20;                     // 旋转 欧拉角
        [EnumProperty("Transform", "Rotation Quaternion")]
        public const int RotationQuaternion = 21;           // 旋转 四元数
        [EnumProperty("Transform", "Scale")]
        public const int Scale = 30;                        // 缩放
        [EnumProperty("Transform", "Transform")]
        public const int Transform = 40;                    // 变换

        [EnumProperty("Rect Transform", "Size")]
        public const int Size = 100;                        // UI尺寸
        [EnumProperty("Rect Transform", "Width")]
        public const int Width = 110;                       // UI宽度
        [EnumProperty("Rect Transform", "Height")]
        public const int Height = 120;                      // UI高度

        [EnumProperty("Color", "Color")]
        public const int Color = 200;                       // 颜色
        [EnumProperty("UI", "Color Block")]
        public const int ColorBlock = 210;                  // 色块 

        [EnumProperty("Color", "Alpha")]
        public const int Alpha = 300;                       // Alpha值
        [EnumProperty("UI", "Canvas Group Alpha")]
        public const int CanvasGroupAlpha = 310;            // CanvasGroup组件Alpha值
        [EnumProperty("Component", "AudioSource Volume")]
        public const int Volume = 320;                      // 音源音量
        [EnumProperty("UI", "Scrollbar")]
        public const int Scrollbar = 330;                   // 滚动条
        [EnumProperty("UI", "Slider")]
        public const int Slider = 340;                      // 滑动条
        [EnumProperty("UI", "Text")]
        public const int Text = 350;                        // 文本

        [EnumProperty("Transform", "Shake")]
        public const int Shake = 1000;                      // 震动

        [EnumProperty(false)]
        public const int Value = 2000;                      // Float 值

        [EnumProperty("Material", "Material Color")]
        public const int MaterialColor = 3001;              // 材质颜色
        [EnumProperty("Material", "Material Float")]
        public const int MaterialFloat = 3002;              // 材质数值
        [EnumProperty("Material", "Material Tilling")]
        public const int MaterialTilling = 3003;            // 材质缩放
        [EnumProperty("Material", "Material Offset")]
        public const int MaterialOffset = 3004;             // 材质便宜
        [EnumProperty("Material", "Material Vector4")]
        public const int MaterialVector4 = 3005;            // 材质四维向量

        // Group;                                           // 组

        [EnumProperty("Color", "Gradient")]
        public const int Gradient = 4000;                   // 颜色队列
        [EnumProperty("Transform", "Path")]
        public const int Path = 4001;                       // 位置队列

        [EnumProperty(false)]
        public const int Sequence = 5000;                   // 顺序
        [EnumProperty(false)]
        public const int Parallel = 6000;                   // 并行
        // Blender = 7000;                                  // 混合器
    }
}
