/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenShake.cs
//  Info     : 震动插值
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using Random = UnityEngine.Random;

namespace Aya.Tween
{
    [RequireComponent(typeof(Transform))]
    [Tweener(TweenType.Shake)]
    public class TweenShake : TweenFloatBase<Transform>
    {
        public override int Type => TweenType.Shake;

        // 位移起始偏移量
        private int _startPosX;
        private int _startPosY;
        private int _startPosZ;
        // 旋转起始偏移量
        private int _startRotX;
        private int _startRotY;
        private int _startRotZ;
        // 缩放起始偏移量
        private int _startScaleX;
        private int _startScaleY;
        private int _startScaleZ;
        // 记录起始位置、旋转、缩放，用于恢复
        private Vector3 _startPos;
        private Vector3 _startRot;
        private Vector3 _startScale;

        public override void Awake()
        {
            CacheStartStatus();
            if (ShakeArgs == null)
            {
                ShakeArgs = new TweenShakeArgs();
            }
            base.Awake();
        }

        public override void Reset()
        {
            base.Reset();
            // 弹性从小到大，所以从 1 -> 0 插值
            From = 1f;
            To = 0f;
            ShakeArgs = new TweenShakeArgs();
        }

        public override void Play()
        {
            CacheStartStatus();
            // 初始化随机偏移量
            if (ShakeArgs.ShakePos)
            {             
                _startPosX = Random.Range(0, 3);
                _startPosY = Random.Range(0, 3);
                _startPosZ = Random.Range(0, 3);
            }
            if (ShakeArgs.ShakeRot)
            {
                _startRotX = Random.Range(0, 3);
                _startRotY = Random.Range(0, 3);
                _startRotZ = Random.Range(0, 3);
            }
            if (ShakeArgs.ShakeScale)
            { 
                _startScaleX = Random.Range(0, 3);
                _startScaleY = Random.Range(0, 3);
                _startScaleZ = Random.Range(0, 3);
            }
            base.Play();
        }

        protected virtual void CacheStartStatus()
        {
            // 记录原位置和旋转
            _startPos = WorldSpace ? Target.transform.position : Target.transform.localPosition;
            _startRot = WorldSpace ? Target.transform.eulerAngles : Target.transform.localEulerAngles;
            _startScale = Target.transform.localScale;
        }

        public override void Stop(bool destroy = true)
        {
            // 确保恢复位置和旋转
            if (ShakeArgs.ShakePos)
            {
                if (WorldSpace)
                {
                    Target.transform.position = _startPos;
                }
                else
                {
                    Target.transform.localPosition = _startPos;
                }
            }
            if (ShakeArgs.ShakeRot)
            {
                if (WorldSpace)
                {
                    Target.transform.eulerAngles = _startRot;
                }
                else
                {
                    Target.transform.localEulerAngles = _startRot;
                }
            }
            if (ShakeArgs.ShakeScale)
            {
                Target.transform.localScale = _startScale;
            }
            base.Stop(destroy);     
        }

        protected override void SetValue(float value)
        {
            if (ShakeArgs == null) return;
            var count = ShakeArgs.Count;
            if (ShakeArgs.ShakePos)
            {
                var powerPos = ShakeArgs.PowerPos;
                var posX = Mathf.Sin(_startPosX * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerPos.x;
                var posY = Mathf.Sin(_startPosY * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerPos.y;
                var posZ = Mathf.Sin(_startPosZ * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerPos.z;
                var offsetPos = new Vector3(posX, posY, posZ);
                var pos = Vector3.Lerp(_startPos, _startPos + offsetPos, value);
                if (WorldSpace)
                {
                    Target.transform.position = pos;
                }
                else
                {
                    Target.transform.localPosition = pos;
                }
            }
            if (ShakeArgs.ShakeRot)
            {
                var powerRot = ShakeArgs.PowerRot;
                var rotX = Mathf.Sin(_startRotX * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerRot.x;
                var rotY = Mathf.Sin(_startRotY * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerRot.y;
                var rotZ = Mathf.Sin(_startRotZ * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerRot.z;
                var offsetRot = new Vector3(rotX, rotY, rotZ);
                var rot = Vector3.Lerp(_startRot, _startRot + offsetRot, value);
                if (WorldSpace)
                {
                    Target.transform.eulerAngles = rot;
                }
                else
                {
                    Target.transform.localEulerAngles = rot;
                }
            }
            if (ShakeArgs.ShakeScale)
            {
                var powerScale = ShakeArgs.PowerScale;
                var scaleX = Mathf.Sin(_startScaleX * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerScale.x;
                var scaleY = Mathf.Sin(_startScaleY * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerScale.y;
                var scaleZ = Mathf.Sin(_startScaleZ * Mathf.PI + CurrentFactor * count * Mathf.PI) * powerScale.z;
                var offsetScale = new Vector3(scaleX, scaleY, scaleZ);
                var scale = Vector3.Lerp(_startScale, _startScale + offsetScale, value);
                Target.transform.localScale = scale;
            }
        }
    }
}