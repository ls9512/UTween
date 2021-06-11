/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialColor.cs
//  Info     : 材质颜色插值 插值
//  Component: Renderer
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponent(typeof(Renderer))]
    [Tweener(TweenType.MaterialColor)]
    public class TweenMaterialColor : TweenColorBase<Renderer>
    {
        public override int Type => TweenType.MaterialColor;

        #region MaterialPropertyBlock Cache
       
        public MaterialPropertyBlock MaterialPropertyBlock
        {
            get
            {
                if (_materialPropertyBlock == null)
                {
                    _materialPropertyBlock = new MaterialPropertyBlock();
                }

                return _materialPropertyBlock;
            }
        }

        private MaterialPropertyBlock _materialPropertyBlock; 

        #endregion

        protected override void SetValue(Color value)
        {
            MaterialPropertyBlock.SetColor(Param.ResourcesKey, value);
            Component.SetPropertyBlock(MaterialPropertyBlock, Param.ResourcesIndex);
        }

        public override void Reset()
        {
            base.Reset();
            ResourcesIndex = 0;
            ResourcesKey = "_Color";
        }

        internal override void SetCurrent2From()
        {
            TweenAnimation.FromColor = Component.sharedMaterials[ResourcesIndex].GetColor(ResourcesKey);
        }

        internal override void SetCurrent2To()
        {
            TweenAnimation.ToColor = Component.sharedMaterials[ResourcesIndex].GetColor(ResourcesKey);
        }

        internal override void SetFrom2Current()
        {
            MaterialPropertyBlock.SetColor(ResourcesKey, TweenAnimation.FromColor);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }

        internal override void SetTo2Current()
        {
            MaterialPropertyBlock.SetColor(ResourcesKey, TweenAnimation.ToColor);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }
    }
}

