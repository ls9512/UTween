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
    [RequireComponents(typeof(Transform))]
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

        public override void SetCurrent2From()
        {
            From = WorldSpace ? Transform.eulerAngles : Transform.localEulerAngles;
        }

        public override void SetCurrent2To()
        {
            To = WorldSpace ? Transform.eulerAngles : Transform.localEulerAngles;
        }

        public override void SetFrom2Current()
        {
            if (WorldSpace) Transform.eulerAngles = From;
            else Transform.localEulerAngles = From;
        }

        public override void SetTo2Current()
        {
            if (WorldSpace) Transform.eulerAngles = To;
            else Transform.localEulerAngles = To;
        }
    }
}

