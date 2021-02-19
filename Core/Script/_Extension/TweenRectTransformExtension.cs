/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRectTransformExtension.cs
//  Info     : 插值动画 RectTransform 扩展接口
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    public static class TweenRectTransformExtension
    {
        #region Position UGUI

        public static TweenPositionUGUI PositionUGUI(this RectTransform rectTransform, Vector2 to, float duration)
        {
            var from = rectTransform.anchoredPosition;
            var tween = PositionUGUI(rectTransform, from, to, duration);
            return tween;
        }

        public static TweenPositionUGUI PositionUGUI(this RectTransform rectTransform, Vector2 from, Vector2 to, float duration)
        {
            var tween = UTween.PositionUGUI(rectTransform, from, to, duration);
            return tween;
        }

        #endregion

        #region Size

        public static TweenSize Size(this RectTransform rectTransform, Vector2 to, float duration)
        {
            var from = rectTransform.sizeDelta;
            var tween = Size(rectTransform, from, to, duration);
            return tween;
        }

        public static TweenSize Size(this RectTransform rectTransform, Vector2 from, Vector2 to, float duration)
        {
            var tween = UTween.Size(rectTransform, from, to, duration);
            return tween;
        }

        #endregion

        #region Width

        public static TweenWidth Width(this RectTransform rectTransform, float to, float duration)
        {
            var from = rectTransform.sizeDelta.x;
            var tween = Width(rectTransform, from, to, duration);
            return tween;
        }

        public static TweenWidth Width(this RectTransform rectTransform, float from, float to, float duration)
        {
            var tween = UTween.Width(rectTransform, from, to, duration);
            return tween;
        }

        #endregion

        #region Height

        public static TweenHeight Height(this RectTransform rectTransform, float to, float duration)
        {
            var from = rectTransform.sizeDelta.x;
            var tween = Height(rectTransform, from, to, duration);
            return tween;
        }

        public static TweenHeight Height(this RectTransform rectTransform, float from, float to, float duration)
        {
            var tween = UTween.Height(rectTransform, from, to, duration);
            return tween;
        }

        #endregion
    }
}
