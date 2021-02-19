/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenStringBase.cs
//  Info     : 字符串插值类基类
//  Author   : ls9512 2021
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System.Text;
using UnityEngine;

namespace Aya.Tween
{
    public abstract class TweenStringBase<TComponent> : Tweener<string, TComponent> where TComponent : Component
    {
        public override string From
        {
            get => Param.FromStr;
            set => Param.FromStr = value;
        }

        public override string To
        {
            get => Param.ToStr;
            set => Param.ToStr = value;
        }

        public override bool SupportSpeedBased => true;

        public abstract string GetString();
        public abstract void SetString(string str);

        public override float GetSpeedBasedDuration()
        {
            return GetString().Length * Duration;
        }

        public abstract bool GetSupportRichText();

        protected StringBuilder StringBuilder = new StringBuilder();
        private string _originalText;

        public override void Play()
        {
            _originalText = GetString();
            base.Play();
        }

        public override void Stop(bool destroy = true)
        {
            base.Stop(destroy);
            SetString(_originalText);
        }

        public virtual void OnValidate()
        {
            
        }

        public override string Evaluate(float factor)
        {
            var from = FromGetter();
            var to = ToGetter();

            StringBuilder.Clear();
            var fromText = from.Substring((int) (from.Length * factor), (int) (from.Length * (1f - factor)));
            var toText = LerpUtil.Lerp(to, factor, GetSupportRichText());
            StringBuilder.Append(toText);
            StringBuilder.Append(fromText);

            var result = StringBuilder.ToString();
            return result;
        }

        protected override void SetValue(string value)
        {
            SetString(value);
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                UnityEditor.EditorUtility.SetDirty(Component);
            }
#endif
        }
    }
}
