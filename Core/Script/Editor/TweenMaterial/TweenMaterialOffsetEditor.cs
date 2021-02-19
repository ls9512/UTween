/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialOffsetEditor.cs
//  Info     : TweenMaterialOffset 编辑器
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.MaterialOffset)]
    public class TweenMaterialOffsetEditor : TweenVector2BaseEditor
    {
        public override int Type => TweenType.MaterialOffset;
        public override int RequireCurveCount => 2;
        public override bool AllowQuickOperation => true;

        public override void DoDrawResourcesInfo()
        {
            DoDrawMaterialsInfo();
        }
    }
}
#endif
