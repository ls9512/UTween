/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialOffset.cs
//  Info     : 材质偏移插值 插值
//  Component: Renderer
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponent(typeof(Renderer))]
    [Tweener(TweenType.MaterialOffset)]
    public class TweenMaterialOffset : TweenVector2Base<Renderer>
    {
        public override int Type => TweenType.MaterialOffset;

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

        #region Cache Key

        public string MaterialSTKey => _materialStKey;
        private string _materialKey;
        private string _materialStKey;

        protected void CacheKey()
        {
            if (_materialKey == ResourcesKey || _materialStKey == ResourcesKey) return;
            _materialKey = ResourcesKey;
            _materialStKey = _materialKey;
            if (_materialKey.EndsWith("_ST"))
            {
                _materialStKey = _materialStKey.Replace("_ST", "");
            }

            _materialStKey = _materialKey + "_ST";
        }

        #endregion

        public override void Play()
        {
            CacheKey();
            base.Play();
        }

        protected override void SetValue(Vector2 value)
        {
            SetOffset(value);
        }

        protected Vector2 GetTilling()
        {
            CacheKey();
            return Component.sharedMaterials[ResourcesIndex].GetTextureScale(_materialKey);
        }

        protected Vector2 GetOffset()
        {
            CacheKey();
            return Component.sharedMaterials[ResourcesIndex].GetTextureOffset(_materialKey);
        }

        protected void SetOffset(Vector2 offset)
        {
            var tilling = GetTilling();
            MaterialPropertyBlock.SetVector(MaterialSTKey, new Vector4(tilling.x, tilling.y, offset.x, offset.y));
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }

        public override void Reset()
        {
            base.Reset();
            ResourcesIndex = 0;
            ResourcesKey = "_MainTex";
        }

        internal override void SetCurrent2From()
        {
            TweenAnimation.FromVector2 = GetOffset();
        }

        internal override void SetCurrent2To()
        {
            TweenAnimation.ToVector2 = GetOffset();
        }

        internal override void SetFrom2Current()
        {
            SetOffset(TweenAnimation.FromVector2);
        }

        internal override void SetTo2Current()
        {
            SetOffset(TweenAnimation.ToVector2);
        }
    }
}

