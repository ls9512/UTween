/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialVector4Editor.cs
//  Info     : TweenMaterialVector4 编辑器
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR

namespace Aya.Tween
{
    [TweenerEditor(TweenType.MaterialVector4)]
    public class TweenMaterialVector4Editor : TweenVector4BaseEditor
    {
        public override int Type => TweenType.MaterialVector4;
        public override int RequireCurveCount => 4;
        public override bool AllowQuickOperation => true;

        public override void DoDrawResourcesInfo()
        {
            DoDrawMaterialsInfo();
        }
    }
}
#endif
