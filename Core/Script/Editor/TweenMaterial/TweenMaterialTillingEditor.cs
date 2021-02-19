/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialTillingEditor.cs
//  Info     : TweenMaterialTilling 编辑器
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.MaterialTilling)]
    public class TweenMaterialTillingEditor : TweenVector2BaseEditor
    {
        public override int Type => TweenType.MaterialTilling;
        public override int RequireCurveCount => 2;
        public override bool AllowQuickOperation => true;

        public override void DoDrawResourcesInfo()
        {
            DoDrawMaterialsInfo();
        }
    }
}
#endif
