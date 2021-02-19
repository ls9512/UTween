using UnityEngine;
using UnityEngine.UI;
using Aya.Tween;

namespace Aya.Example
{
	public class TweenTest : MonoBehaviour
	{
	    public Transform ShakePos;
	    public Transform ShakeRot;
	    public Transform ShakeScale;
		public Transform SequenceMoveObj;
	    public Transform ParallelMoveObj1;
	    public Transform ParallelMoveObj2;
        public Image AlphaObj;
        public TweenAnimation TweenAlpha;

        public GameObject TweenPosTarget;
        public TweenAnimationAsset Asset;

	    private void Start()
	    {
			// Common Style
			/*
            var tween = UTween.Create<TweenValue>();
            tween.SetFrom(0f);
            tween.SetTo(1f);
            tween.SetDuration(2f);
            tween.SetFloatCallback(value =>
            {
                Debug.Log("Value : " + value);
            });
			tween.Play();
			*/

			// Chain Style
	        UTween.Create<TweenValue>()
	            .SetFrom(0f)
	            .SetTo(1f)
	            .SetDuration(2f)
	            .SetUpdateType(UpdateType.Update)
	            .SetPlayType(PlayType.PingPong)
	            .SetEaseType(EaseType.Linear)
	            .SetTimeScale(false)
	            .SetPlayCallback(() => { Debug.Log("Play"); })
                .SetFloatCallback(value =>
	            {
	                var color = AlphaObj.color;
	                AlphaObj.color = new Color(color.r, color.g, color.b, value);
	            })
	            .SetStopCallback(() => { Debug.Log("Stop"); })
                .Play();

            TweenAlpha.Play();

			UTween.Value(0f, 1f, 1f, value =>
	        {
	            Debug.Log(value);
	        }).SetStartDelay(3f);

            UTween.Shake(ShakePos, 0.5f, 0f, 0f, 5, 0.5f).SetPlayType(PlayType.Loop);
            UTween.Shake(ShakeRot, 0f, 45f, 0f, 5, 0.5f).SetPlayType(PlayType.Loop);
            UTween.Shake(ShakeScale, 0f, 0f, 0.5f, 5, 0.5f).SetPlayType(PlayType.Loop);

            UTween.GetSequence()
	            .Append(UTween.Position(SequenceMoveObj, Vector3.zero, Vector3.one, 2f))
	            .Append(UTween.Position(SequenceMoveObj, Vector3.one, Vector3.up, 2f))
	            .Append(UTween.Position(SequenceMoveObj, Vector3.up, Vector3.left, 2f))
	            .Append(UTween.Position(SequenceMoveObj, Vector3.left, Vector3.zero, 2f))
                .SetStartDelay(3f)
                .Play();

            UTween.GetParallel()
	            .Append(UTween.Position(ParallelMoveObj1, new Vector3(2, 0, 0), new Vector3(4, 0, 0), 2f))
	            .Append(UTween.Position(ParallelMoveObj2, new Vector3(2, 2, 0), new Vector3(4, 2, 0), 2f))
	            .SetStartDelay(3f)
	            .Play();

			// Tween Group
			/*
            var tweeners = gameObject.GetTweeners("Open");
			tweeners.Play();
			*/

            // Dynamic from / to value
			/*
			float FromValue = 0f;
            float ToValue = 0f;
            UTween.Value(0f, 5f, 1f, value => FromValue = value);
            UTween.Value(10f, 5f, 1f, value => ToValue = value);
			UTween.Create<TweenValue>()
                .SetFromGetter(()=> FromValue)
                .SetToGetter(()=> ToValue)
                .SetDuration(1f)
                .SetUpdateType(UpdateType.LateUpdate)
                .Play();
			*/

			UTween.Create(Asset)
                .SetTarget(TweenPosTarget)
                .Play();
        }

	    public void OnPlayTest()
		{
			// Debug.Log("Start");
		}

	    public void OnValueTest(Vector3 value)
	    {
	        // Debug.Log("Value " + value);
        }

		public void OnStopTest()
		{
			// Debug.Log("Finish");
		}

	    public void OnTweenValue(float value)
	    {
	        // TweenValueText1.text = "Tween Value : " + value;
	    }
	}

	// User EaseFunction
	/*
    [EnumClass("EaseType")]
	public static class EaseTypeExtension
    {
        [EnumProperty("Extension", "Ease Lerp")]
        public const int EaseLerp = 10001;
    }

    public class EaseLerp : EaseFunction
    {
        public override int Type => EaseTypeExtension.EaseLerp;

		public override float Ease(float from, float to, float delta)
        {
            return Mathf.Lerp(from, to, delta);
        }
    }
	*/

	// User Tweener
	/*
	[EnumClass("TweenType")]
	public static class TweenTypeExtension
    {
		[EnumProperty("UI", "Text FontSize")]
        public const int TextFontSize = 10001;
    }

	[Tweener(TweenTypeExtension.TextFontSize)]
	[RequireComponent(typeof(Text))]
    public class TweenTextFontSize : TweenFloatBase<Text>
    {
        public override int Type => TweenTypeExtension.TextFontSize;

        protected override void SetValue(float value)
        {
            Component.fontSize = (int)value;
#if UNITY_EDITOR
			// 确保编辑器预览刷新
            if (!Application.isPlaying)
            {
                UnityEditor.EditorUtility.SetDirty(Component);
            }
#endif
		}
	}

    [TweenerEditor(TweenTypeExtension.TextFontSize)]
    public class TweenTextEditor : TweenFloatBaseEditor
    {
        public override int Type => TweenTypeExtension.TextFontSize;
        public override int RequireCurveCount => 1;
        public override bool AllowQuickOperation => true;
        public new TweenTextFontSize Tweener => Target as TweenTextFontSize;
    }
	*/
}