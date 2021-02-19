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
	[RequireComponents(typeof(AudioSource))]
    [Tweener(TweenType.Volume)]
    public class TweenVolume : TweenFloatBase<AudioSource>
	{
	    public override int Type => TweenType.Volume;

        protected override void SetValue(float value)
		{
			Component.volume = value;
		}

		public override void SetCurrent2From()
		{
			From = Component.volume;
		}

		public override void SetCurrent2To()
		{
			To = Component.volume;
		}

		public override void SetFrom2Current()
		{
			Component.volume = From;
		}

		public override void SetTo2Current()
		{
			Component.volume = To;
		}
	}
}

