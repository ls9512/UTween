/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialFloat.cs
//  Info     : 材质数值插值 插值
//  Component: Renderer
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponent(typeof(Renderer))]
    [Tweener(TweenType.MaterialFloat)]
    public class TweenMaterialFloat : TweenFloatBase<Renderer>
    {
        public override int Type => TweenType.MaterialFloat;

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

        protected override void SetValue(float value)
        {
            MaterialPropertyBlock.SetFloat(Param.ResourcesKey, value);
            Component.SetPropertyBlock(MaterialPropertyBlock, Param.ResourcesIndex);
        }

        public override void Reset()
        {
            base.Reset();
            ResourcesIndex = 0;
            ResourcesKey = "";
        }

        internal override void SetCurrent2From()
        {
            TweenAnimation.FromFloat = Component.sharedMaterials[ResourcesIndex].GetFloat(ResourcesKey);
        }

        internal override void SetCurrent2To()
        {
            TweenAnimation.ToFloat = Component.sharedMaterials[ResourcesIndex].GetFloat(ResourcesKey);
        }

        internal override void SetFrom2Current()
        {
            MaterialPropertyBlock.SetFloat(ResourcesKey, TweenAnimation.FromFloat);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }

        internal override void SetTo2Current()
        {
            MaterialPropertyBlock.SetFloat(ResourcesKey, TweenAnimation.ToFloat);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }
    }
}

