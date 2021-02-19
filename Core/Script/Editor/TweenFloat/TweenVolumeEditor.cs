/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenVolumeEditor.cs
//  Info     : TweenVolume 编辑器
//  Author   : ls9512 2018
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.Volume)]
    public class TweenVolumeEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenType.Volume;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenVolume Tweener => Target as TweenVolume;
    }
}
#endif
