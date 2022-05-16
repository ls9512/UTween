/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTextMeshProUGUIEditor.cs
//  Info     : TweenTextMeshProUGUI 编辑器
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR && UTWEEN_TEXTMESHPRO

namespace Aya.Tween
{
    [TweenerEditor(TweenTypeTextMeshPro.TextMeshProUGUI)]
    public class TweenTextMeshProUGUIEditor : TweenStringBaseEditor
    {
        public override int Type => TweenTypeTextMeshPro.TextMeshProUGUI;
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
