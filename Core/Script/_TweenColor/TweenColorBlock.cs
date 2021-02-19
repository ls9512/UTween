/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenColorBlock.cs
//  Info     : 控件色块插值 插值
//  Component: Button, Toggle, InputField, Slider, Scrollbar, DropDown, Selectable
//	Warining : 该控件通过反射同时实现对多种控件的颜色处理，但效率稍低
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

namespace Aya.Tween 
{
    [RequireComponents(
		typeof(Button), 
		typeof(Toggle), 
		typeof(InputField), 
		typeof(Slider), 
		typeof(Scrollbar), 
		typeof(Dropdown), 
		typeof(Selectable))]
    [Tweener(TweenType.ColorBlock)]
    public class TweenColorBlock : TweenColorBase<Component>
	{
	    public override int Type => TweenType.ColorBlock;

        protected Component TargetComponent;
	    protected Selectable TargetSelectable => TargetComponent as Selectable;

        public override void Awake()
		{
			TargetComponent = RequireComponentsAttribute.Find(typeof(TweenColorBlock), Target);
		    base.Awake();
        }

		#region Set & Get

	    private Color _getValue()
	    {
	        switch (ColorBlockType)
	        {
	            case ColorBlockType.NormalColor:
	                return TargetSelectable.colors.normalColor;
	            case ColorBlockType.DisabledColor:
	                return TargetSelectable.colors.disabledColor;
	            case ColorBlockType.HighlightedColor:
	                return TargetSelectable.colors.highlightedColor;
	            case ColorBlockType.PressedColor:
	                return TargetSelectable.colors.pressedColor;
	            default:
	                return TargetSelectable.colors.normalColor;
	        }
	    }

	    private void _setValue(Color color)
	    {
	        var colors = TargetSelectable.colors;
	        switch (ColorBlockType)
	        {
	            case ColorBlockType.NormalColor:
	                colors.normalColor = color;
	                break;
	            case ColorBlockType.DisabledColor:
	                colors.disabledColor = color;
	                break;
	            case ColorBlockType.HighlightedColor:
	                colors.highlightedColor = color;
	                break;
	            case ColorBlockType.PressedColor:
	                colors.pressedColor = color;
	                break;
	        }

	        TargetSelectable.colors = colors;
	    }

	    #endregion

		protected override void SetValue(Color value) 
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

