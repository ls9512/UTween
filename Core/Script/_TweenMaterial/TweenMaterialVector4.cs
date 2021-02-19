/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialVector4.cs
//  Info     : 材质四维向量插值 插值
//  Component: Renderer
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponent(typeof(Renderer))]
    [Tweener(TweenType.MaterialVector4)]
    public class TweenMaterialVector4 : TweenVector4Base<Renderer>
    {
        public override int Type => TweenType.MaterialVector4;

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

        protected override void SetValue(Vector4 value)
        {
            MaterialPropertyBlock.SetVector(Param.ResourcesKey, value);
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
            From = Component.sharedMaterials[ResourcesIndex].GetVector(ResourcesKey);
        }

        public override void SetCurrent2To()
        {
            To = Component.sharedMaterials[ResourcesIndex].GetVector(ResourcesKey);
        }

        public override void SetFrom2Current()
        {
            MaterialPropertyBlock.SetVector(ResourcesKey, From);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }

        public override void SetTo2Current()
        {
            MaterialPropertyBlock.SetVector(ResourcesKey, To);
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }
    }
}

