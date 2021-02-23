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

        public override void SetCurrent2From()
        {
            From = WorldSpace ? Transform.rotation : Transform.localRotation;
        }

        public override void SetCurrent2To()
        {
            To = WorldSpace ? Transform.rotation : Transform.localRotation;
        }

        public override void SetFrom2Current()
        {
            if (WorldSpace) Transform.rotation = From;
            else Transform.localRotation = From;
        }

        public override void SetTo2Current()
        {
            if (WorldSpace) Transform.rotation = To;
            else Transform.localRotation = To;
        }
    }
}

