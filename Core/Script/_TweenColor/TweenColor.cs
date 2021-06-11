/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenColor.cs
//  Info     : 控件颜色插值 插值
//  Component: Image / RawImage / Text / SpriteRenderer / Light
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

namespace Aya.Tween 
{
    [RequireOneOfComponents(
        typeof(Image),
        typeof(RawImage),
        typeof(Text),
        typeof(SpriteRenderer),
        typeof(Light))]
    [Tweener(TweenType.Color)]
    public class TweenColor : TweenColorBase<Component>
    {
        public override int Type => TweenType.Color;

        protected Component TargetComponent;

        protected Image TargetImage => TargetComponent as Image;
        protected RawImage TargetRawImage => TargetComponent as RawImage;
        protected Text TargetText => TargetComponent as Text;
        protected SpriteRenderer TargetSpriteRenderer => TargetComponent as SpriteRenderer;
        protected Light TargetLight => TargetComponent as Light;

        public override void Awake()
        {
            TargetComponent = RequireOneOfComponentsAttribute.Find(typeof(TweenColor), Target);
            base.Awake();
        }

        public override void Reset()
        {
            base.Reset();
            From = Color.white;
            To = Color.white;
        }

        #region Set & Get

        private Color _getValue()
        {
            if (TargetImage != null) return TargetImage.color;
            if (TargetRawImage != null) return TargetRawImage.color;
            if (TargetText != null) return TargetText.color;
            if (TargetSpriteRenderer != null) return TargetSpriteRenderer.color;
            if (TargetLight != null) return TargetLight.color;
            return default(Color);
        }

        private void _setValue(Color color)
        {
            if (TargetImage != null) TargetImage.color = color;
            if (TargetRawImage != null) TargetRawImage.color = color;
            if (TargetText != null) TargetText.color = color;
            if (TargetSpriteRenderer != null) TargetSpriteRenderer.color = color;
            if (TargetLight != null) TargetLight.color = color;
        }

        #endregion

        protected override void SetValue(Color value)
        {
            _setValue(value);
        }

        internal override void SetCurrent2From()
        {
            TweenAnimation.FromColor = _getValue();
        }

        internal override void SetCurrent2To()
        {
            TweenAnimation.ToColor = _getValue();
        }

        internal override void SetFrom2Current()
        {
            _setValue(TweenAnimation.FromColor);
        }

        internal override void SetTo2Current()
        {
            _setValue(TweenAnimation.ToColor);
        }
    }
}

