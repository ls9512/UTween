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

        public override void SetCurrent2From()
        {
            From = Component.sharedMaterials[ResourcesIndex].GetFloat(ResourcesKey);
        }

        public override void SetCurrent2To()
        {
            To = Component.sharedMaterials[ResourcesIndex].GetFloat(ResourcesKey);
        }

        public override void SetFrom2Current()
        {
            MaterialPropertyBlock.SetFloat(ResourcesKey, From);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }

        public override void SetTo2Current()
        {
            MaterialPropertyBlock.SetFloat(ResourcesKey, To);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }
    }
}

