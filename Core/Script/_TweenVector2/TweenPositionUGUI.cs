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
    [RequireComponent(typeof(RectTransform))]
    [Tweener(TweenType.PositionUGUI)]
    public class TweenPositionUGUI : TweenVector2Base<RectTransform>
    {
        public override int Type => TweenType.PositionUGUI;

        protected override void SetValue(Vector2 value)
        {
            Component.anchoredPosition = value;
        }

        internal override void SetCurrent2From()
        {
            TweenAnimation.FromVector2 = Component.anchoredPosition;
        }

        internal override void SetCurrent2To()
        {
            TweenAnimation.ToVector2 = Component.anchoredPosition;
        }

        internal override void SetFrom2Current()
        {
            Component.anchoredPosition = TweenAnimation.FromVector2;
        }

        internal override void SetTo2Current()
        {
            Component.anchoredPosition = TweenAnimation.ToVector2;
        }
    }
}

