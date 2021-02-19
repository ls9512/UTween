/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialExtension.cs
//  Info     : 插值动画 Material 扩展接口
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
//  Warning  : 这个扩展中的方法均会实例化新的材质，如想要避免实例化材质的开销，请使用专门的 TweenMaterial 系列插值功能
//
/////////////////////////////////////////////////////////////////////////////
using System;
using UnityEngine;

namespace Aya.Tween
{
    [Obsolete]
    public static class TweenMaterialExtension
    {
        #region Color

        public static TweenValue Color(this Material material, string propertyName, Color to, float duration)
        {
            var from = material.GetColor(propertyName);
            var tween = Color(material, propertyName, from, to, duration);
            return tween;
        }

        public static TweenValue Color(this Material material, string propertyName, Color from, Color to, float duration)
        {
            var tween = UTween.Value(from, to, duration, value => { material.SetColor(propertyName, value); });
            return tween;
        }

        public static TweenValue Color(this Material material, Color to, float duration)
        {
            var tween = Color(material, "_Color", to, duration);
            return tween;
        }

        public static TweenValue Color(this Material material, Color from, Color to, float duration)
        {
            var tween = Color(material, "_Color", from, to, duration);
            return tween;
        }

        #endregion

        #region Alpha

        public static TweenValue Alpha(this Material material, string propertyName, float to, float duration)
        {
            var from = material.GetColor(propertyName).a;
            var tween = Alpha(material, propertyName, from, to, duration);
            return tween;
        }

        public static TweenValue Alpha(this Material material, string propertyName, float from, float to, float duration)
        {
            var tween = UTween.Value(from, to, duration, value =>
            {
                var color = material.GetColor(propertyName);
                color.a = value;
                material.SetColor(propertyName, color);
            });
            return tween;
        }

        public static TweenValue Alpha(this Material material, float to, float duration)
        {
            var tween = Alpha(material, "_Color", to, duration);
            return tween;
        }

        public static TweenValue Alpha(this Material material, float from, float to, float duration)
        {
            var tween = Alpha(material, "_Color", from, to, duration);
            return tween;
        }

        #endregion

        #region Float

        public static TweenValue Float(this Material material, string propertyName, float to, float duration)
        {
            var from = material.GetFloat(propertyName);
            var tween = Float(material, propertyName, from, to, duration);
            return tween;
        }

        public static TweenValue Float(this Material material, string propertyName, float from, float to, float duration)
        {
            var tween = UTween.Value(from, to, duration, value => { material.SetFloat(propertyName, value); });
            return tween;
        }

        #endregion

        #region Vector

        public static TweenValue Vector(this Material material, string propertyName, Vector4 to, float duration)
        {
            var from = material.GetVector(propertyName);
            var tween = Vector(material, propertyName, from, to, duration);
            return tween;
        }

        public static TweenValue Vector(this Material material, string propertyName, Vector4 from, Vector4 to, float duration)
        {
            var tween = UTween.Value(from, to, duration, value => { material.SetVector(propertyName, value); });
            return tween;
        }

        #endregion

        #region Offset

        public static TweenValue Offset(this Material material, string textureName, Vector2 to, float duration)
        {
            var from = material.GetTextureOffset(textureName);
            var tween = Offset(material, textureName, from, to, duration);
            return tween;
        }

        public static TweenValue Offset(this Material material, string textureName, Vector2 from, Vector2 to, float duration)
        {
            var tween = UTween.Value(from, to, duration, value => { material.SetTextureOffset(textureName, value); });
            return tween;
        }

        public static TweenValue Offset(this Material material, Vector2 to, float duration)
        {
            var tween = Offset(material, "_MainTex", to, duration);
            return tween;
        }

        public static TweenValue Offset(this Material material, Vector2 from, Vector2 to, float duration)
        {
            var tween = Offset(material, "_MainTex", from, to, duration);
            return tween;
        }

        #endregion

        #region Tilling

        public static TweenValue Tilling(this Material material, string textureName, Vector2 to, float duration)
        {
            var from = material.GetTextureScale(textureName);
            var tween = Offset(material, textureName, from, to, duration);
            return tween;
        }

        public static TweenValue Tilling(this Material material, string textureName, Vector2 from, Vector2 to, float duration)
        {
            var tween = UTween.Value(from, to, duration, value => { material.SetTextureScale(textureName, value); });
            return tween;
        }

        public static TweenValue Tilling(this Material material, Vector2 to, float duration)
        {
            var tween = Offset(material, "_MainTex", to, duration);
            return tween;
        }

        public static TweenValue Tilling(this Material material, Vector2 from, Vector2 to, float duration)
        {
            var tween = Offset(material, "_MainTex", from, to, duration);
            return tween;
        }

        #endregion
    }
}
