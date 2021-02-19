/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialColorEditor.cs
//  Info     : TweenMaterialColor 编辑器
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.MaterialColor)]
    public class TweenMaterialColorEditor : TweenColorBaseEditor
    {
        public override int Type => TweenType.MaterialColor;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;

        public override void DoDrawResourcesInfo()
        {
            DoDrawMaterialsInfo();
        }
    }
}
#endif
