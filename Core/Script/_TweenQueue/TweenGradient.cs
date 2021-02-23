/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenGradient.cs
//  Info     : 渐变色插值
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
    [Tweener(TweenType.Gradient)]
    public class TweenGradient : TweenQueueColorBase<Component>
	{
	    public override int Type => TweenType.Gradient;

	    protected Component TargetComponent;

	    protected Image TargetImage => TargetComponent as Image;
	    protected RawImage TargetRawImage => TargetComponent as RawImage;
	    protected Text TargetText => TargetComponent as Text;
	    protected SpriteRenderer TargetSpriteRenderer => TargetComponent as SpriteRenderer;
        protected Light TargetLight => TargetComponent as Light;

		public override void Awake()
		{
		    TargetComponent = RequireOneOfComponentsAttribute.Find(typeof(TweenGradient), Target);
		    base.Awake();
        }

        #region Set & Get

		private void _setValue(Color color) 
		{
		    if (TargetImage != null) TargetImage.color = color;
		    if (TargetRawImage != null) TargetRawImage.color = color;
		    if (TargetText != null) TargetText.color = color;
		    if (TargetSpriteRenderer != null) TargetSpriteRenderer.color = color;
            if (TargetLight != null) TargetLight.color = color;
		}

        #endregion

        public override float GetSpeedBasedDuration()
        {
            return Duration;
        }

        protected override void SetValue(Color value) 
		{
			_setValue(value);
		}

	}
}
