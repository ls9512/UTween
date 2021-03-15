using UnityEngine;
using Aya.Tween;

namespace Aya.Example
{
    public class TweenEaseCurvePreviewUGUI : MonoBehaviour
    {
        public TweenEaseCurveItem Prefab;

        public Transform GridTrans;

        public void Start()
        {
            var easeTypes = EaseType.NameValueDic.Values;
            foreach (var easeType in easeTypes)
            {
                var item = Instantiate(Prefab, GridTrans).GetComponent<TweenEaseCurveItem>();
                item.Init(easeType);
                item.name = "Curve_" + item.TextType.text;
            }
        }
    }
}
