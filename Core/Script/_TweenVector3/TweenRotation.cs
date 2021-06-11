/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenRotation.cs
//  Info     : 旋转(欧拉角)插值
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace Aya.Tween
{
    [RequireComponent(typeof(Transform))]
    [Tweener(TweenType.Rotation)]
    public class TweenRotation : TweenVector3Base<Transform>
    {
        public override int Type => TweenType.Rotation;

        protected override void SetValue(Vector3 value)
        {
            if (WorldSpace)
            {
                Transform.eulerAngles = value;
            }
            else
            {
                Transform.localEulerAngles = value;
            }
        }

        internal override void SetCurrent2From()
        {
            TweenAnimation.FromVector3 = WorldSpace ? Transform.eulerAngles : Transform.localEulerAngles;
        }

        internal override void SetCurrent2To()
        {
            TweenAnimation.ToVector3 = WorldSpace ? Transform.eulerAngles : Transform.localEulerAngles;
        }

        internal override void SetFrom2Current()
        {
            if (WorldSpace) Transform.eulerAngles = TweenAnimation.FromVector3;
            else Transform.localEulerAngles = TweenAnimation.FromVector3;
        }

        internal override void SetTo2Current()
        {
            if (WorldSpace) Transform.eulerAngles = TweenAnimation.ToVector3;
            else Transform.localEulerAngles = TweenAnimation.ToVector3;
        }
    }
}

