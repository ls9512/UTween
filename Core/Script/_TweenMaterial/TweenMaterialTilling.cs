/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenMaterialTilling.cs
//  Info     : 材质缩放插值 插值
//  Component: Renderer
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponent(typeof(Renderer))]
    [Tweener(TweenType.MaterialTilling)]
    public class TweenMaterialTilling : TweenVector2Base<Renderer>
    {
        public override int Type => TweenType.MaterialTilling;

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
            SetTilling(value);
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

        protected void SetTilling(Vector2 tilling)
        {
            var offset = GetOffset();
            MaterialPropertyBlock.SetVector(MaterialSTKey, new Vector4(tilling.x, tilling.y, offset.x, offset.y));
            Component.SetPropertyBlock(MaterialPropertyBlock, ResourcesIndex);
        }

        public override void Reset()
        {
            base.Reset();
            ResourcesIndex = 0;
            ResourcesKey = "_MainTex";
        }

        public override void SetCurrent2From()
        {
            From = GetTilling();
        }

        public override void SetCurrent2To()
        {
            To = GetTilling();
        }

        public override void SetFrom2Current()
        {
            SetTilling(From);
        }

        public override void SetTo2Current()
        {
            SetTilling(To);
        }
    }
}

