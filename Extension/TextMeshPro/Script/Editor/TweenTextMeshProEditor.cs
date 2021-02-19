/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenTextMeshProEditor.cs
//  Info     : TweenTextMeshPro 编辑器
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#define TEXTMESHPRO
#if UNITY_EDITOR && TEXTMESHPRO

namespace Aya.Tween
{
    [TweenerEditor(TweenTypeTextMeshPro.TextMeshPro)]
    public class TweenTextMeshProEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenTypeTextMeshPro.TextMeshPro;
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
