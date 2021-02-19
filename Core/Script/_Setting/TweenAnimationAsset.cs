/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenAnimationAsset.cs
//  Info     : 插值动画序列化资源文件
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [CreateAssetMenu(menuName = "UTween/Tween Animation", fileName = "TweenAnimation")]
    public class TweenAnimationAsset : ScriptableObject
    {
        public TweenParam Param = new TweenParam();
    }
}
