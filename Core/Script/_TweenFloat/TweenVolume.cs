/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVolume.cs
//  Info     : 音源组件 音量 插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
	[RequireComponent(typeof(AudioSource))]
    [Tweener(TweenType.Volume)]
    public class TweenVolume : TweenFloatBase<AudioSource>
	{
	    public override int Type => TweenType.Volume;

        protected override void SetValue(float value)
		{
			Component.volume = value;
		}

        internal override void SetCurrent2From()
		{
            TweenAnimation.FromFloat = Component.volume;
		}

        internal override void SetCurrent2To()
		{
            TweenAnimation.ToFloat = Component.volume;
		}

        internal override void SetFrom2Current()
		{
			Component.volume = TweenAnimation.FromFloat;
		}

        internal override void SetTo2Current()
		{
			Component.volume = TweenAnimation.ToFloat;
		}
	}
}

