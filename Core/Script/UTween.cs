/////////////////////////////////////////////////////////////////////////////
//
//  Script   : UTween.cs
//  Info     : 插值动画快速调用接口
//  Author   : ls9512 2019
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aya.Tween
{
    public static partial class UTween
    {
        #region Sequence / Parallel

        public static TweenSequence GetSequence()
        {
            var sequence = Create<TweenSequence>();
            return sequence;
        }

        public static TweenParallel GetParallel()
        {
            var parallel = Create<TweenParallel>();
            return parallel;
        }

        #endregion

        #region Tween Vector3

        #region Position

        public static TweenPosition Position(Transform transform, Vector3 to, float duration, bool worldSpace = true)
        {
            var from = transform.position;
            var tween = Do<TweenPosition, Vector3, Transform>(transform, from, to, duration);
            tween.WorldSpace = worldSpace;
            return tween;
        }

        public static TweenPosition Position(Transform transform, Vector3 from, Vector3 to, float duration, bool worldSpace = true)
        {
            var tween = Do<TweenPosition, Vector3, Transform>(transform, from, to, duration);
            tween.WorldSpace = worldSpace;
            return tween;
        }

        #endregion

        #region Path / Tween Queue Position

        public static TweenPath Path(Transform transform, List<Vector3> path, float duration, bool worldSpace = true)
        {
            var tween = Do<TweenPath, Vector3, Transform>(transform, path, duration);
            tween.WorldSpace = worldSpace;
            return tween;
        }

        #endregion

        #region Scale

        public static TweenScale Scale(Transform transform, Vector3 to, float duration)
        {
            var from = transform.localScale;
            return Do<TweenScale, Vector3, Transform>(transform, from, to, duration);
        }

        public static TweenScale Scale(Transform transform, Vector3 from, Vector3 to, float duration)
        {
            return Do<TweenScale, Vector3, Transform>(transform, from, to, duration);
        }

        #endregion

        #region Rotation

        public static TweenRotation Rotation(Transform transform, Vector3 to, float duration, bool worldSpace = true)
        {
            var from = transform.eulerAngles;
            var tween = Do<TweenRotation, Vector3, Transform>(transform, from, to, duration);
            tween.WorldSpace = worldSpace;
            return tween;
        }

        public static TweenRotation Rotation(Transform transform, Vector3 from, Vector3 to, float duration, bool worldSpace = true)
        {
            var tween = Do<TweenRotation, Vector3, Transform>(transform, from, to, duration);
            tween.WorldSpace = worldSpace;
            return tween;
        }

        #endregion

        #endregion

        #region Tween Vector2

        #region Position UGUI

        public static TweenPositionUGUI PositionUGUI(RectTransform rectTransform, Vector2 to, float duration)
        {
            var from = rectTransform.anchoredPosition;
            var tween = Do<TweenPositionUGUI, Vector2, RectTransform>(rectTransform, from, to, duration);
            return tween;
        }

        public static TweenPositionUGUI PositionUGUI(RectTransform rectTransform, Vector2 from, Vector2 to, float duration)
        {
            var tween = Do<TweenPositionUGUI, Vector2, RectTransform>(rectTransform, from, to, duration);
            return tween;
        }

        #endregion

        #region Size

        public static TweenSize Size(RectTransform rectTransform, Vector2 to, float duration)
        {
            var from = rectTransform.sizeDelta;
            return Do<TweenSize, Vector2, RectTransform>(rectTransform, from, to, duration);
        }

        public static TweenSize Size(RectTransform rectTransform, Vector2 from, Vector2 to, float duration)
        {
            return Do<TweenSize, Vector2, RectTransform>(rectTransform, from, to, duration);
        }

        #endregion

        #endregion

        #region Tween Float

        #region Tween CanvasGroup Alpha

        public static TweenCanvasGroupAlpha CanvasAlpha(CanvasGroup canvasGroup, float to, float duration)
        {
            var from = canvasGroup.alpha;
            return Do<TweenCanvasGroupAlpha, float, CanvasGroup>(canvasGroup, from, to, duration);
        }

        public static TweenCanvasGroupAlpha CanvasAlpha(CanvasGroup canvasGroup, float from, float to, float duration)
        {
            return Do<TweenCanvasGroupAlpha, float, CanvasGroup>(canvasGroup, from, to, duration);
        }

        #endregion

        #region Tween Alpha

        public static TweenAlpha Alpha(Image image, float to, float duration)
        {
            var from = image.color.a;
            return Do<TweenAlpha, float, Component>(image, from, to, duration);
        }

        public static TweenAlpha Alpha(Image image, float from, float to, float duration)
        {
            return Do<TweenAlpha, float, Component>(image, from, to, duration);
        }

        public static TweenAlpha Alpha(RawImage rawImage, float to, float duration)
        {
            var from = rawImage.color.a;
            return Do<TweenAlpha, float, Component>(rawImage, from, to, duration);
        }

        public static TweenAlpha Alpha(RawImage rawImage, float from, float to, float duration)
        {
            return Do<TweenAlpha, float, Component>(rawImage, from, to, duration);
        }

        public static TweenAlpha Alpha(SpriteRenderer spriteRenderer, float to, float duration)
        {
            var from = spriteRenderer.color.a;
            return Do<TweenAlpha, float, Component>(spriteRenderer, from, to, duration);
        }

        public static TweenAlpha Alpha(SpriteRenderer spriteRenderer, float from, float to, float duration)
        {
            return Do<TweenAlpha, float, Component>(spriteRenderer, from, to, duration);
        }

        public static TweenAlpha Alpha(Text text, float to, float duration)
        {
            var from = text.color.a;
            return Do<TweenAlpha, float, Component>(text, from, to, duration);
        }

        public static TweenAlpha Alpha(Text text, float from, float to, float duration)
        {
            return Do<TweenAlpha, float, Component>(text, from, to, duration);
        }
        public static TweenAlpha Alpha(Light light, float to, float duration)
        {
            var from = light.color.a;
            return Do<TweenAlpha, float, Component>(light, from, to, duration);
        }

        public static TweenAlpha Alpha(Light light, float from, float to, float duration)
        {
            return Do<TweenAlpha, float, Component>(light, from, to, duration);
        }

        #endregion

        #region Tween Width

        public static TweenWidth Width(RectTransform rectTransform, float to, float duration)
        {
            var from = rectTransform.sizeDelta.x;
            return Do<TweenWidth, float, RectTransform>(rectTransform, from, to, duration);
        }

        public static TweenWidth Width(RectTransform rectTransform, float from, float to, float duration)
        {
            return Do<TweenWidth, float, RectTransform>(rectTransform, from, to, duration);
        }

        #endregion

        #region Tween Height

        public static TweenHeight Height(RectTransform rectTransform, float to, float duration)
        {
            var from = rectTransform.sizeDelta.y;
            return Do<TweenHeight, float, RectTransform>(rectTransform, from, to, duration);
        }

        public static TweenHeight Height(RectTransform rectTransform, float from, float to, float duration)
        {
            return Do<TweenHeight, float, RectTransform>(rectTransform, from, to, duration);
        }

        #endregion

        #region Tween Scrollbar

        public static TweenScrollbar Scrollbar(Scrollbar scrollbar, float to, float duration)
        {
            var from = scrollbar.value;
            return Do<TweenScrollbar, float, Scrollbar>(scrollbar, from, to, duration);
        }

        public static TweenScrollbar Scrollbar(Scrollbar scrollbar, float from, float to, float duration)
        {
            return Do<TweenScrollbar, float, Scrollbar>(scrollbar, from, to, duration);
        }

        #endregion

        #region Tween Slider

        public static TweenSlider Slider(Slider slider, float to, float duration)
        {
            var from = slider.value;
            return Do<TweenSlider, float, Slider>(slider, from, to, duration);
        }

        public static TweenSlider Slider(Slider slider, float from, float to, float duration)
        {
            return Do<TweenSlider, float, Slider>(slider, from, to, duration);
        }

        #endregion

        #region Tween Text

        public static TweenText Text(Text text, string to, float duration)
        {
            return Do<TweenText, string, Text>(text, text.text, to, duration);
        }

        public static TweenText Text(Text text, string from, string to, float duration)
        {
            return Do<TweenText, string, Text>(text, from, to, duration);
        }

        #endregion

        #region Tween Value

        public static TweenVolume Volume(AudioSource audioSource, float to, float duration)
        {
            var from = audioSource.volume;
            return Do<TweenVolume, float, AudioSource>(audioSource, from, to, duration);
        }

        public static TweenVolume Volume(AudioSource audioSource, float from, float to, float duration)
        {
            return Do<TweenVolume, float, AudioSource>(audioSource, from, to, duration);
        }

        #endregion

        #region Tween Volume

        public static TweenVolume Slider(AudioSource audioSource, float to, float duration)
        {
            var from = audioSource.volume;
            return Do<TweenVolume, float, AudioSource>(audioSource, from, to, duration);
        }

        public static TweenVolume Slider(AudioSource audioSource, float from, float to, float duration)
        {
            return Do<TweenVolume, float, AudioSource>(audioSource, from, to, duration);
        }

        #endregion

        #endregion

        #region Tween Color

        #region Tween Image Color

        public static TweenColor Color(Image image, Color to, float duration)
        {
            var from = image.color;
            return Do<TweenColor, Color, Component>(image, from, to, duration);
        }

        public static TweenColor Color(Image image, Color from, Color to, float duration)
        {
            return Do<TweenColor, Color, Component>(image, from, to, duration);
        }

        #endregion

        #region Tween RawImage Color

        public static TweenColor Color(RawImage image, Color to, float duration)
        {
            var from = image.color;
            return Do<TweenColor, Color, Component>(image, from, to, duration);
        }

        public static TweenColor Color(RawImage image, Color from, Color to, float duration)
        {
            return Do<TweenColor, Color, Component>(image, from, to, duration);
        }

        #endregion

        #region Tween Text Color

        public static TweenColor Color(Text text, Color to, float duration)
        {
            var from = text.color;
            return Do<TweenColor, Color, Component>(text, from, to, duration);
        }

        public static TweenColor Color(Text text, Color from, Color to, float duration)
        {
            return Do<TweenColor, Color, Component>(text, from, to, duration);
        }

        #endregion

        #region Tween Light Color

        public static TweenColor Color(Light light, Color to, float duration)
        {
            var from = light.color;
            return Do<TweenColor, Color, Component>(light, from, to, duration);
        }

        public static TweenColor Color(Light light, Color from, Color to, float duration)
        {
            return Do<TweenColor, Color, Component>(light, from, to, duration);
        }

        #endregion

        #region Tween SpriteRenderer Color

        public static TweenColor Color(SpriteRenderer spriteRenderer, Color to, float duration)
        {
            var from = spriteRenderer.color;
            return Do<TweenColor, Color, Component>(spriteRenderer, from, to, duration);
        }

        public static TweenColor Color(SpriteRenderer spriteRenderer, Color from, Color to, float duration)
        {
            return Do<TweenColor, Color, Component>(spriteRenderer, from, to, duration);
        }

        #endregion

        #region Gradient / Tween Queue Color

        public static TweenGradient Gradient(Component component, List<Color> path, float duration)
        {
            var tween = Do<TweenGradient, Color, Component>(component, path, duration);
            return tween;
        }

        #endregion

        #endregion

        #region Tween Shake

        #region TweenShake float

        public static TweenShake Shake(Transform transform, float powerPos, float powerRot, float powerScale, int count, float duration, bool worldSpace = true)
        {
            var shakeArgs = new TweenShakeArgs(powerPos, powerRot, powerScale, count);
            var tween = Shake(transform, shakeArgs, duration);
            tween.WorldSpace = worldSpace;
            return tween;
        }

        #endregion

        #region TweenShake Vector3

        public static TweenShake Shake(Transform transform, Vector3 powerPos, Vector3 powerRot, Vector3 powerScale, int count, float duration, bool worldSpace = true)
        {
            var shakeArgs = new TweenShakeArgs(powerPos, powerRot, powerScale, count);
            var tween = Shake(transform, shakeArgs, duration);
            tween.WorldSpace = worldSpace;
            return tween;
        }

        #endregion

        #region TweenShake TweenShakeArgs

        public static TweenShake Shake(Transform transform, TweenShakeArgs shakeArgs, float duration, bool worldSpace = true)
        {
            var tween = Do<TweenShake, float, Transform>(transform, 1f, 0f, duration);
            tween.ShakeArgs = shakeArgs;
            tween.WorldSpace = worldSpace;
            return tween;
        }

        #endregion

        #endregion

        #region Tween Material
        
        #region Tween Material Color

        public static TweenMaterialColor MaterialColor(Renderer renderer, Color to, float duration, int materialIndex = 0, string materialPropertyName = "_Color")
        {
            var from = renderer.sharedMaterials[materialIndex].GetColor(materialPropertyName);
            return MaterialColor(renderer, from, to, duration, materialIndex, materialPropertyName);
        }

        public static TweenMaterialColor MaterialColor(Renderer renderer, Color from, Color to, float duration, int materialIndex = 0, string materialPropertyName = "_Color")
        {
            return Do<TweenMaterialColor, Color, Renderer>(renderer, from, to, duration)
                .SetResourceIndex(materialIndex)
                .SetResourceKey(materialPropertyName);
        }

        #endregion

        #region Tween Material Float

        public static TweenMaterialFloat MaterialFloat(Renderer renderer, float to, float duration, int materialIndex, string materialPropertyName)
        {
            var from = renderer.sharedMaterials[materialIndex].GetFloat(materialPropertyName);
            return MaterialFloat(renderer, from, to, duration, materialIndex, materialPropertyName);
        }

        public static TweenMaterialFloat MaterialFloat(Renderer renderer, float from, float to, float duration, int materialIndex, string materialPropertyName)
        {
            return Do<TweenMaterialFloat, float, Renderer>(renderer, from, to, duration)
                .SetResourceIndex(materialIndex)
                .SetResourceKey(materialPropertyName);
        }

        #endregion

        #region Tween Material Tilling

        public static TweenMaterialTilling MaterialTilling(Renderer renderer, Vector2 to, float duration, int materialIndex = 0, string materialPropertyName = "_MainTex_ST")
        {
            var from = renderer.sharedMaterials[materialIndex].GetTextureScale(materialPropertyName);
            return MaterialTilling(renderer, from, to, duration, materialIndex, materialPropertyName);
        }

        public static TweenMaterialTilling MaterialTilling(Renderer renderer, Vector2 from, Vector2 to, float duration, int materialIndex = 0, string materialPropertyName = "_MainTex_ST")
        {
            return Do<TweenMaterialTilling, Vector2, Renderer>(renderer, from, to, duration)
                .SetResourceIndex(materialIndex)
                .SetResourceKey(materialPropertyName);
        }

        #endregion

        #region Tween Material Offset

        public static TweenMaterialOffset MaterialOffset(Renderer renderer, Vector2 to, float duration, int materialIndex = 0, string materialPropertyName = "_MainTex_ST")
        {
            var from = renderer.sharedMaterials[materialIndex].GetTextureOffset(materialPropertyName);
            return MaterialOffset(renderer, from, to, duration, materialIndex, materialPropertyName);
        }

        public static TweenMaterialOffset MaterialOffset(Renderer renderer, Vector2 from, Vector2 to, float duration, int materialIndex = 0, string materialPropertyName = "_MainTex_ST")
        {
            return Do<TweenMaterialOffset, Vector2, Renderer>(renderer, from, to, duration)
                .SetResourceIndex(materialIndex)
                .SetResourceKey(materialPropertyName);
        }

        #endregion

        #region Tween Material Vector4

        public static TweenMaterialVector4 MaterialVector4(Renderer renderer, Vector4 to, float duration, int materialIndex, string materialPropertyName)
        {
            var from = renderer.sharedMaterials[materialIndex].GetVector(materialPropertyName);
            return MaterialVector4(renderer, from, to, duration, materialIndex, materialPropertyName);
        }

        public static TweenMaterialVector4 MaterialVector4(Renderer renderer, Vector4 from, Vector4 to, float duration, int materialIndex, string materialPropertyName)
        {
            return Do<TweenMaterialVector4, Vector4, Renderer>(renderer, from, to, duration)
                .SetResourceIndex(materialIndex)
                .SetResourceKey(materialPropertyName);
        }

        #endregion 

        #endregion

        #region Tween Value [ float / int / Color / Vector2 / Vector3 / Vector4 / Quaternion / Rect / string ]

        public static TweenValue Value(float from, float to, float duration, Action<float> action)
        {
            var tween = Do<TweenValue, float>(from, to, duration);
            tween.OnValueCallback = action;
            return tween;
        }

        public static TweenValue Value(int from, int to, float duration, Action<int> action)
        {
            var tween = UTween.Value(0f, 1f, duration, value =>
            {
                var result = (int) Mathf.LerpUnclamped(from, to, value);
                action(result);
            });
            return tween;
        }

        public static TweenValue Value(Color from, Color to, float duration, Action<Color> action)
        {
            var tween = UTween.Value(0f, 1f, duration, value =>
            {
                var color = UnityEngine.Color.LerpUnclamped(from, to, value);
                action(color);
            });
            return tween;
        }

        public static TweenValue Value(Vector2 from, Vector2 to, float duration, Action<Vector2> action)
        {
            var tween = UTween.Value(0f, 1f, duration, value =>
            {
                var vector = Vector2.LerpUnclamped(from, to, value);
                action(vector);
            });
            return tween;
        }

        public static TweenValue Value(Vector3 from, Vector3 to, float duration, Action<Vector3> action)
        {
            var tween = UTween.Value(0f, 1f, duration, value =>
            {
                var vector = Vector3.LerpUnclamped(from, to, value);
                action(vector);
            });
            return tween;
        }

        public static TweenValue Value(Vector4 from, Vector4 to, float duration, Action<Vector4> action)
        {
            var tween = UTween.Value(0f, 1f, duration, value =>
            {
                var vector = Vector4.LerpUnclamped(from, to, value);
                action(vector);
            });
            return tween;
        }

        public static TweenValue Value(Quaternion from, Quaternion to, float duration, Action<Quaternion> action)
        {
            var tween = UTween.Value(0f, 1f, duration, value =>
            {
                var quaternion = Quaternion.LerpUnclamped(from, to, value);
                action(quaternion);
            });
            return tween;
        }

        public static TweenValue Value(Rect from, Rect to, float duration, Action<Rect> action)
        {
            var tween = UTween.Value(0f, 1f, duration, value =>
            {
                var x = Mathf.LerpUnclamped(from.x, to.x, value);
                var y = Mathf.LerpUnclamped(from.y, to.y, value);
                var width = Mathf.LerpUnclamped(from.width, to.width, value);
                var height = Mathf.LerpUnclamped(from.height, to.height, value);
                var rect = new Rect(x, y, width, height);
                action(rect);
            });
            return tween;
        }

        public static TweenValue Value(string text, float from, float to, float duration, bool enableRichText, Action<string> action)
        {
            from = Mathf.Clamp01(from);
            to = Mathf.Clamp01(to);
            var tween = UTween.Value(from, to, duration, value =>
            {
                var str = LerpUtil.Lerp(text, value, enableRichText);
                action(str);
            });
            return tween;
        }

        #endregion

        #region Do Setter / Getter

        public static TTween Do<TTween, TValue>(Action<TValue> setter, Func<TValue> fromGetter, Func<TValue> toGetter, float duration, bool autoPlay = true)
            where TTween : Tweener<TValue>, new()
        {
            var tween = Create<TTween>();
            tween.Setter = setter;
            tween.FromGetter = fromGetter;
            tween.ToGetter = toGetter;
            tween.Duration = duration;
            tween.Awake();
            if (autoPlay)
            {
                tween.Play();
            }

            return tween;
        }

        #endregion

        #region Do GameObject

        public static TTween Do<TTween, TValue, TComponent>(GameObject go, TValue from, TValue to, float duration, bool autoPlay = true)
            where TTween : Tweener<TValue, TComponent>, new()
            where TComponent : Component
        {
            var tween = Create<TTween>();
            Do<TTween, TValue, TComponent>(tween, go, from, to, duration, autoPlay);
            tween.AutoKill = true;
            return tween;
        }

        public static TTween Do<TTween, TValue, TComponent>(TTween tween, GameObject go, TValue from, TValue to, float duration, bool autoPlay = true)
            where TTween : Tweener<TValue, TComponent>, new()
            where TComponent : Component
        {
            if (tween.Component == null)
            {
                tween.Component = go.GetComponent<TComponent>();
            }

            tween.Target = go;
            tween.Transform = go.transform;
            tween.From = from;
            tween.To = to;
            tween.Duration = duration;
            tween.Awake();
            if (autoPlay)
            {
                tween.Play();
            }

            return tween;
        }

        #endregion

        #region Do Value

        public static TTween Do<TTween, TValue>(TValue from, TValue to, float duration, bool autoPlay = true)
            where TTween : Tweener<TValue>, new()
        {
            var tween = Create<TTween>();
            Do<TTween, TValue>(tween, from, to, duration, autoPlay);
            tween.AutoKill = true;
            return tween;
        }

        public static TTween Do<TTween, TValue>(TTween tween, TValue from, TValue to, float duration, bool autoPlay = true)
            where TTween : Tweener<TValue>, new()
        {
            tween.Target = TweenManager.Ins.gameObject;
            tween.Transform = TweenManager.Ins.transform;
            tween.From = from;
            tween.To = to;
            tween.Duration = duration;
            tween.Awake();
            if (autoPlay)
            {
                tween.Play();
            }

            return tween;
        }

        #endregion

        #region Do Value & Compoment

        public static TTween Do<TTween, TValue, TComponent>(TComponent component, TValue from, TValue to, float duration, bool autoPlay = true)
            where TTween : Tweener<TValue, TComponent>, new()
            where TComponent : Component
        {
            var tween = Create<TTween>();
            Do<TTween, TValue, TComponent>(tween, component, from, to, duration, autoPlay);
            tween.AutoKill = true;
            return tween;
        }

        public static TTween Do<TTween, TValue, TComponent>(TTween tween, TComponent component, TValue from, TValue to, float duration, bool autoPlay = true)
            where TTween : Tweener<TValue, TComponent>, new()
            where TComponent : Component
        {
            tween.Component = component;
            tween.Target = component.gameObject;
            tween.Transform = component.transform;
            tween.From = from;
            tween.To = to;
            tween.Duration = duration;
            tween.Awake();
            if (autoPlay)
            {
                tween.Play();
            }

            return tween;
        }

        #endregion

        #region Do Queue

        public static TTween Do<TTween, TValue, TComponent>(TComponent component, List<TValue> args, float duration, bool autoPlay = true)
            where TTween : TweenQueueBase<TValue, TComponent>, new()
            where TComponent : Component
        {
            var tween = Create<TTween>();
            Do<TTween, TValue, TComponent>(tween, component, args, duration, autoPlay);
            tween.AutoKill = true;
            return tween;
        }

        public static TTween Do<TTween, TValue, TComponent>(TTween tween, TComponent component, List<TValue> args, float duration, bool autoPlay = true)
            where TTween : TweenQueueBase<TValue, TComponent>, new()
            where TComponent : Component
        {
            tween.Component = component;
            tween.Target = component.gameObject;
            tween.Transform = component.transform;
            tween.Queue = args;
            tween.Duration = duration;
            tween.Awake();
            if (autoPlay)
            {
                tween.Play();
            }

            return tween;
        }

        #endregion

        #region Create

        public static TTween Create<TTween>() where TTween : Tweener, new()
        {
            var tween = TweenManager.Ins.Spawn<TTween>();
            tween.Target = TweenManager.Ins.gameObject;
            tween.Transform = TweenManager.Ins.transform;
            return tween;
        }

        public static Tweener Create(TweenAnimationAsset asset)
        {
            var tween = TweenManager.Ins.Spawn(asset.Param.Type);
            tween.Param.CopyFrom(asset.Param);
            tween.Target = TweenManager.Ins.gameObject;
            tween.Transform = TweenManager.Ins.transform;
            return tween;
        }

        #endregion
    }
}