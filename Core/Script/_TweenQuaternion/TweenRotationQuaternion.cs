/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRotationQuaternion.cs
//  Info     : 旋转(四元数)插值
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponent(typeof(Transform))]
    [Tweener(TweenType.RotationQuaternion)]
    public class TweenRotationQuaternion : TweenQuaternionBase<Transform>
    {
        public override int Type => TweenType.RotationQuaternion;

        protected override void SetValue(Quaternion value)
        {
            if (WorldSpace)
            {
                Transform.rotation = value;
            }
            else
            {
                Transform.localRotation = value;
            }
        }

        internal override void SetCurrent2From()
        {
            TweenAnimation.FromQuaternion = WorldSpace ? Transform.rotation : Transform.localRotation;
        }

        internal override void SetCurrent2To()
        {
            TweenAnimation.ToQuaternion = WorldSpace ? Transform.rotation : Transform.localRotation;
        }

        internal override void SetFrom2Current()
        {
            if (WorldSpace) Transform.rotation = TweenAnimation.FromQuaternion;
            else Transform.localRotation = TweenAnimation.FromQuaternion;
        }

        internal override void SetTo2Current()
        {
            if (WorldSpace) Transform.rotation = TweenAnimation.ToQuaternion;
            else Transform.localRotation = TweenAnimation.ToQuaternion;
        }
    }
}

