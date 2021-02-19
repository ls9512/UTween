/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRubyTextMeshProUGUIEditor.cs
//  Info     : TweenRubyTextMeshProUGUI 编辑器
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#define RUBYTEXTMESHPRO
#if UNITY_EDITOR && RUBYTEXTMESHPRO

namespace Aya.Tween
{
    [TweenerEditor(TweenTypeRubyTextMeshPro.RubyTextMeshProUGUI)]
    public class TweenRubyTextMeshProUGUIEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenTypeRubyTextMeshPro.RubyTextMeshProUGUI;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenText Tweener => Target as TweenText;

        public override bool DoDrawQuickOpt()
        {
            return false;
        }
    }
}
#endif
