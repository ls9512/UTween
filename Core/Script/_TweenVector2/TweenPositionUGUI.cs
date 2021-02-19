/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenPositionUGUI.cs
//  Info     : UGUI位置插值
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponents(typeof(RectTransform))]
    [Tweener(TweenType.PositionUGUI)]
    public class TweenPositionUGUI : TweenVector2Base<RectTransform>
    {
        public override int Type => TweenType.PositionUGUI;

        protected override void SetValue(Vector2 value)
        {
            Component.anchoredPosition = value;
        }

        public override void SetCurrent2From()
        {
            From = Component.anchoredPosition;
        }

        public override void SetCurrent2To()
        {
            To = Component.anchoredPosition;
        }

        public override void SetFrom2Current()
        {
            Component.anchoredPosition = From;
        }

        public override void SetTo2Current()
        {
            Component.anchoredPosition = To;
        }
    }
}

