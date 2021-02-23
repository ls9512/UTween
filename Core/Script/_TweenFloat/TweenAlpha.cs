/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenAlpha.cs
//  Info     : UI 透明度 插值
//  Component: Image, RawImage, Text, SpriteRenderer
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
    [Tweener(TweenType.Alpha)]
    public class TweenAlpha : TweenFloatBase<Component>
    {
        public override int Type => TweenType.Alpha;

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

        #region Set & Get

        private float _getValue()
        {
            if (TargetImage != null) return TargetImage.color.a;
            if (TargetRawImage != null) return TargetRawImage.color.a;
            if (TargetText != null) return TargetText.color.a;
            if (TargetSpriteRenderer != null) return TargetSpriteRenderer.color.a;
            if (TargetLight != null) return TargetLight.color.a;
            return default(float);
        }

        private void _setValue(float alpha)
        {
            if (TargetImage != null)
            {
                var c = TargetImage.color;
                TargetImage.color = new Color(c.r, c.g, c.b, alpha);
            }

            if (TargetRawImage != null)
            {
                var c = TargetRawImage.color;
                TargetRawImage.color = new Color(c.r, c.g, c.b, alpha);
            }

            if (TargetText != null)
            {
                var c = TargetText.color;
                TargetText.color = new Color(c.r, c.g, c.b, alpha);
            }

            if (TargetSpriteRenderer != null)
            {
                var c = TargetSpriteRenderer.color;
                TargetSpriteRenderer.color = new Color(c.r, c.g, c.b, alpha);
            }

            if (TargetLight != null)
            {
                var c = TargetLight.color;
                TargetLight.color = new Color(c.r, c.g, c.b, alpha);
            }
        }

        #endregion

        protected override void SetValue(float value)
		{
			_setValue(value);
		}

		public override void SetCurrent2From()
		{
			From = _getValue();
		}

		public override void SetCurrent2To()
		{
			To = _getValue();
        }

		public override void SetFrom2Current()
		{
			_setValue(From);
		}

		public override void SetTo2Current()
		{
		    _setValue(To);
        }
	}
}

