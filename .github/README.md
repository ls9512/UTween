<div align="center">    
<img src="Image/Logo_1200x284.png" width = "480" height = "112"/>
</div>

**UTween** is an interpolation animation component for **Unity**. You can quickly configure animations through built-in components or write animations through code.

![license](https://img.shields.io/github/license/ls9512/UTween)
[![openupm](https://img.shields.io/npm/v/com.ls9512.utween?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.ls9512.utween/)
[![Release Version](https://img.shields.io/badge/release-1.0.3-red.svg)](https://github.com/ls9512/UTween/releases)
![topLanguage](https://img.shields.io/github/languages/top/ls9512/UTween)
![size](https://img.shields.io/github/languages/code-size/ls9512/UTween)
![last](https://img.shields.io/github/last-commit/ls9512/UTween)
[![996.icu](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu)

[![issue](https://img.shields.io/github/issues/ls9512/UTween)](https://github.com/ls9512/UTween/issues)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](https://github.com/ls9512/UTween/pulls)
[![Updates](https://img.shields.io/badge/Platform-%20iOS%20%7C%20OS%20X%20%7C%20Android%20%7C%20Windows%20%7C%20Linux%20-brightgreen.svg)](https://github.com/ls9512/UTween)

[[中文文档]](README_CN.md)

<!-- vscode-markdown-toc -->
* 1. [Quick Start](#QuickStart)
	* 1.1. [Features](#Features)
	* 1.2. [Environment](#Environment)
	* 1.3. [Preview](#Preview)
	* 1.4. [Installation](#Installation)
* 2. [ Parameter](#Parameter)
* 3. [Built-in Function](#Built-inFunction)
	* 3.1. [Core](#Core)
		* 3.1.1. [Tweener](#Tweener)
		* 3.1.2. [TweenManager](#TweenManager)
		* 3.1.3. [TweenPool](#TweenPool)
		* 3.1.4. [TweenAnimation](#TweenAnimation)
		* 3.1.5. [TweenAnimationAsset](#TweenAnimationAsset)
	* 3.2. [Data Type](#DataType)
	* 3.3. [Ease Function](#EaseFunction)
		* 3.3.1. [Standard](#Standard)
		* 3.3.2. [Additional](#Additional)
	* 3.4. [Tween Type](#TweenType)
* 4. [Execute Flow](#ExecuteFlow)
* 5. [Performance Testing](#PerformanceTesting)
* 6. [Usage Example](#UsageExample)
	* 6.1. [Common Usage](#CommonUsage)
	* 6.2. [Chain Style](#ChainStyle)
	* 6.3. [Quick API](#QuickAPI)
	* 6.4. [Unity Component Extension](#UnityComponentExtension)
	* 6.5. [Sequential / Parallel](#SequentialParallel)
	* 6.6. [Dynamic Start / End](#DynamicStartEnd)
	* 6.7. [Animation Group](#AnimationGroup)
	* 6.8. [Configuration Assets](#ConfigurationAssets)
* 7. [User Extension](#UserExtension)
	* 7.1. [Add Custom Ease Function](#AddCustomEaseFunction)
	* 7.2. [Add Custom Interpolation Animation](#AddCustomInterpolationAnimation)
* 8. [The End](#TheEnd)

<!-- vscode-markdown-toc-config
	numbering=true
	autoSave=true
	/vscode-markdown-toc-config -->
<!-- /vscode-markdown-toc -->

##  1. <a name='QuickStart'></a>Quick Start
###  1.1. <a name='Features'></a>Features
* Provide detailed parameters to achieve high freedom of custom animation.
* Built-in animation realization of translation, rotation, scaling, value, color, etc. of a large number of commonly used components.
* Built-in a large number of commonly used ease functions, and provide custom curves for independent setting of different axes.
* Provide three usage modes of editor component, configuration file and code call.
* All animations can be exported and saved as configuration files to realize animation resource management and reuse.
* Support dynamic starting point, dynamic adjustment of parameters during animation (only available in script mode).
* Provide high-performance material animation based on `MaterialPropertyBlock`.
* Except for animations related to operating strings, it basically achieves 0 GC.
* Good chain programming support.

###  1.2. <a name='Environment'></a>Environment
![Unity: 2019.4.3f1](https://img.shields.io/badge/Unity-2019.4.3f1-blue) 
![.NET 4.x](https://img.shields.io/badge/.NET-4.x-blue) 

###  1.3. <a name='Preview'></a>Preview
Add components and use rich built-in animation and easing functions:
<div align="center">    
<img src="Image/UTween_TwweenType_EaseType.gif"/>
</div>

Build-in ease functions:
<div align="center">    
<img src="Image/UTween_EaseCurvePreview.gif"/>
</div>

Support each axis independent curve:
<div align="center">    
<img src="Image/UTween_InspectorMultiCurve.png"/>
</div>

The editor previews the animation in real time, what you see is what you get:
<div align="center">    
<img src="Image/UTween_EditorPreview.gif"/>
</div>

Built-in curve path editor:
<div align="center">    
<img src="Image/UTween_PathEditor.gif"/>
</div>

###  1.4. <a name='Installation'></a>Installation
* 1. Download the latest [release](https://github.com/ls9512/UTween/releases) version of unitypackage.
* 2. Install via [OpenUPM](https://github.com/openupm/openupm):
```
openupm add com.ls9512.utween
```
* 3. Install via [Unity Package Manager - Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html):
```
"com.ls9512.utween": "git+https://github.com/ls9512/utween"
```
* 4. Download the repository source code and install it manually.
* 5. May be released to AssetStore in the future.

##  2. <a name='Parameter'></a> Parameter
* **From**: Starting value for interpolation
* **To**: The end of the interpolation
* **Curve**: Custom interpolation animation curve will be accumulated on the calculation result of the easing function
* **Curve Target**: You can choose whether the calculation result of the curve is applied to the interpolation factor or the value of the interpolation result
* **Curve Mode**: You can choose a single curve to act on the whole or use separate curve control for each axis
* **Play Type**: Play type, optional **Once, Loop, LoopCount, PingPong, PingPongCount**
* **Ease Type**: Built-in easing function type, the default is linear, there are many optional effects, please test by yourself.
* **Loop Count**: Loop count
* **Duration:**: Duration of interpolation process, unit s
* **Interval**: Repeat interval time, only available in Loop and PingPong modes
* **Speed Based**: Based on speed instead of time interpolation, the Duration parameter will be used as the speed value when selected

* **Start Delay**: Delay time of interpolation start, unit s
* **Auto Play**: Timing of auto play, default None, no auto play, optional **Awake, Start, Enable**, if you select Enable, it will be triggered multiple times
* **Update Type**: Calculate the timing of the update, adjust it according to the actual needs of the animation, the default is **Update**, optional **LateUpdate** and **FixedUpdate**
* **Time Scale**: Time scale, determine whether the animation is affected by the time scale speed change, you can control the separation of the interpolation animation from the game process
* **Self Scale**: Self time scaling, used to adjust the animation playback speed, will change the actual running time of the animation
* **Time Smooth**: Whether to use **Time.smoothDeltaTime** to prevent the animation from jittering due to frame rate fluctuations, only available when **Time Scale** is **true**
* **Auto Kill**: Whether to automatically destroy after playing (only valid for non-infinite loop type playback)
* **Callback**: Used to register callbacks at the beginning and end of interpolation

***

##  3. <a name='Built-inFunction'></a>Built-in Function
###  3.1. <a name='Core'></a>Core
####  3.1.1. <a name='Tweener'></a>Tweener
The smallest component that realizes a single animation effect corresponds to a complete set of animation parameters, and each Tweener component runs independently.

####  3.1.2. <a name='TweenManager'></a>TweenManager
It is used to manage and schedule all Tweener components, maintain all TweenPools, is controlled by the **Unity MonoBehaviour** life cycle, and provides **Update / LateUpdate / FixedUpdate** update modes.

####  3.1.3. <a name='TweenPool'></a>TweenPool
The internal object pool of the component is used for the recycling and reuse of Tweener components.

####  3.1.4. <a name='TweenAnimation'></a>TweenAnimation
Tweener's editor class, used to configure animation in **Inspector**, and provide different configuration interfaces for different Tweeners. But TweenAnimation itself does not provide any logical functions, the operation of animation still relies on TweenManager, and components only provide data and configuration interfaces.

####  3.1.5. <a name='TweenAnimationAsset'></a>TweenAnimationAsset
Animation configuration resource files based on `ScriptableObject` can be imported and exported from `TweenAnimation`, and can be called by code to create animation.

###  3.2. <a name='DataType'></a>Data Type
* float
* Vector2
* Vector3
* Vector4
* Quaternion
* Color
* Rect
* Transform(Position Vector3/Rotation Vector3/Scale Vector3)

###  3.3. <a name='EaseFunction'></a>Ease Function
####  3.3.1. <a name='Standard'></a>Standard
* Linear
* Circular
* Quad
* Cubic
* Cubic
* Quart
* Sine
* Expo
* Circ
* Back
* Bounce
* Elastic

####  3.3.2. <a name='Additional'></a>Additional
* Flash
* Step
* Parabola
* Trigonometric

###  3.4. <a name='TweenType'></a>Tween Type
* Position
* Poition UGUI
* Rotation EulerAngles
* Rotation Quaternion
* Scale
* Transform
* Size
* Width
* Height
* Color
* ColorBlock
* Alpha
* CanvasGroup Alpha
* AudioSource Volume
* Scrollbar
* Slider
* Text
* Shkae
* Value
* Material Color
* Material Float
* Material Tilling
* Material OFfset
* Material Vector4
* Gradient
* Path
* Sequence
* Parallel

##  4. <a name='ExecuteFlow'></a>Execute Flow
* Prepare all necessary parameters.
* Calculate the interpolation factor through RunTime / Duration.
* Substitute the actual interpolation factor into the `EaseFunction` of the corresponding `EasyType` to calculate.
* When CurveMode == Factor, multiply the difference factor by the curve calculation result.
* Use the final interpolation factor to calculate the interpolation result value.
* When CurveMode == Value, multiply the interpolation result by the curve calculation result.
* Apply the interpolation result to the target component and refresh the component state.

***

##  5. <a name='PerformanceTesting'></a>Performance Testing
* Test platform: i5-8500 / 16GB DDR4 2666 / GTX 950 / Unity 2019.4.3f1
* 1000 GameObjects rely on the TweenAnimation/TweenPosition component to execute in the scene. In the editor mode, the Profier counts that each frame consumes 3.21ms of CPU time. Under the same environment and animation effects, DOTween is 2.51ms.
* Except that the object pool is empty at startup, all required Tweener objects need to be created, as well as string-related operations. In most cases, the GC is 0.

***

##  6. <a name='UsageExample'></a>Usage Example

###  6.1. <a name='CommonUsage'></a>Common Usage
```csharp
var tween = UTween.Create<TweenValue>();
tween.SetFrom(0f);
tween.SetTo(1f);
tween.SetDuration(2f);
tween.SetFloatCallback(value =>
{
    Debug.Log("Value : " + value); }
});
tween.Play();
```
###  6.2. <a name='ChainStyle'></a>Chain Style
You can quickly create interpolation animations through the `Tween.Create<>()` interface, and set some properties and callbacks in the way of `chain programming`.
```csharp
UTween.Create<TweenValue>()
	.SetFrom(0f)
	.SetTo(1f)
	.SetDuration(5f)
	.SetUpdateType(UpdateType.Update)
	.SetPlayType(PlayType.Once)
	.SetEaseType(EaseType.Linear)
	.SetTimeScale(false)
	.SetPlayCallback(() => { Debug.Log("Play"); })
	.SetValueCallback(value => { Debug.Log("Value : " + value); })
	.SetStopCallback(() => { Debug.Log("Stp["); })
	.Play();
```

###  6.3. <a name='QuickAPI'></a>Quick API
```csharp
UTween.Position(transform, Vector3.zero, Vector3.one, 1f);
UTween.Scale(transform, Vector3.zero, Vector3.one, 1f);
UTween.Rotation(transform, new Vector3(0, 0, 0), new Vector3(0, 360, 0), 1f);
UTween.Color(image, Color.black, Color.white, 1f);
UTween.Alpha(image, 0f, 1f, 1f);
// Please try more APIs yourself
```

###  6.4. <a name='UnityComponentExtension'></a>Unity Component Extension
```csharp
Transform transform;
transform.Move(Vector3.zero, Vector3.one, 1f);
```
Currently only contains a small number of native component extension interfaces, which will be added later.

###  6.5. <a name='SequentialParallel'></a>Sequential / Parallel
Sequential interpolation animation/parallel interpolation animation can control the state of a group of Tweeners at one time, but at this time, the callback and state changes of the child Tweener will not be triggered, and the transfer is controlled by the upper-level component.
* Sequence Example :
``` cs
 UTween.GetSequence()
	.Append(UTween.Position(SequneceMoveObj, Vector3.zero, Vector3.one, 2f))
	.Append(UTween.Position(SequneceMoveObj, Vector3.one, Vector3.up, 2f))
	.Append(UTween.Position(SequneceMoveObj, Vector3.up, Vector3.left, 2f))
	.Append(UTween.Position(SequneceMoveObj, Vector3.left, Vector3.zero, 2f))
	.Play();
```

* Parallel Example : 
``` cs
UTween.GetParallel()
	.Append(UTween.Position(ParallelMoveObj1, new Vector3(2, 0, 0), new Vector3(4, 0, 0), 2f))
	.Append(UTween.Position(ParallelMoveObj2, new Vector3(2, 2, 0), new Vector3(4, 2, 0), 2f))
	.Play();
```

###  6.6. <a name='DynamicStartEnd'></a>Dynamic Start / End
Use the `SetFromGetter / SetToGetter` method to set the method of dynamically obtaining the start point and end point, and ensure that the animation update is performed after the start point value is updated, you can get an interpolated animation with the start point and end point dynamically changing:
```csharp
public float FromValue = 0f;
public float ToValue = 0f;

UTween.Value(0f, 5f, 1f, value => FromValue = value);
UTween.Value(10f, 5f, 1f, value => ToValue = value);

UTween.Create<TweenValue>()
	.SetFromGetter(()=> FromValue)
	.SetToGetter(()=> ToValue)
	.SetDuration(1f)
	.SetUpdateType(UpdateType.LateUpdate)
	.Play();
```
###  6.7. <a name='AnimationGroup'></a>Animation Group
Get the animation instance generated by one or more animation components configured on an object and play it through the `Identifier` parameter:
```csharp
var tweeners = gameObject.GetTweeners("Open");
tweeners.Play();
```
It is expensive to obtain animation components or animation instances in real time. It is recommended to cache the reference of the `TweenAnimation` component in advance and call it when needed.

###  6.8. <a name='ConfigurationAssets'></a>Configuration Assets
Create an animation through the loaded animation configuration file and play it after specifying the target:
```csharp
TweenAnimationAsset Asset;

UTween.Create(Asset)
 	.SetTarget(TweenPosTarget)
	.Play();
```
##  7. <a name='UserExtension'></a>User Extension
###  7.1. <a name='AddCustomEaseFunction'></a>Add Custom Ease Function
1.Create a custom easing type constant:
```csharp
[EnumClass("EaseType")]
public static class EaseTypeExtension
{
#if UNITY_EDITOR
	[UnityEditor.InitializeOnLoadMethod]
#else
	[UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
	public static void Init()
	{
		SerializeEnumAttribute.CacheSerializeEnum(typeof(EaseTypeExtension));
	}

	[EnumProperty("Extension", "Ease Lerp")]
	public const int EaseLerp = 10001;
}
```

2.Create a custom interpolation class and integrate the implementation of the `EaseFunction` type:
```csharp
public class EaseLerp : EaseFunction
{
	public override int Type => EaseTypeExtension.EaseLerp;

	public override float Ease(float from, float to, float delta)
	{
		return Mathf.Lerp(from, to, delta);
	}
}
```

###  7.2. <a name='AddCustomInterpolationAnimation'></a>Add Custom Interpolation Animation
1.Create a custom animation type constant:
```csharp
[EnumClass("TweenType")]
public static class TweenTypeExtension
{
#if UNITY_EDITOR
	[UnityEditor.InitializeOnLoadMethod]
#else
	[UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
	public static void Init()
	{
		SerializeEnumAttribute.CacheSerializeEnum(typeof(TweenTypeExtension));
	}

	[EnumProperty("UI", "Text FontSize")]
	public const int TextFontSize = 10001;
}
```

2.Create a custom interpolation class and integrate the implementation of the `Tweener<TValue, TComponent>` type:
```csharp
[Tweener(TweenTypeExtension.TextFontSize)]
[RequireComponent(typeof(Text))]
public class TweenTextFontSize : TweenFloatBase<Text>
{
	public override int Type => TweenTypeExtension.TextFontSize;

	protected override void SetValue(float value)
	{
		Component.fontSize = (int)value;
#if UNITY_EDITOR
		// Refresh for editor preview
		if (!Application.isPlaying)
		{
			UnityEditor.EditorUtility.SetDirty(Component);
		}
#endif
	}
}
```

3.If you need to use it under the editor, you also need to write the corresponding editor code:
```csharp
[TweenerEditor(TweenTypeExtension.TextFontSize)]
public class TweenTextEditor : TweenFloatBaseEditor
{
	public override int Type => TweenTypeExtension.TextFontSize;
	public override int RequireCurveCount => 1;
	public override bool AllowQuickOperation => true;
	public new TweenTextFontSize Tweener => Target as TweenTextFontSize;
}
```

***

##  8. <a name='TheEnd'></a>The End
This project is a self-developed plug-in for self-use. It has been verified by a certain period of time and accumulation of many small and medium-sized projects. It is now decided to open source for everyone to learn and use, but it does not mean that this is a highly completed commercial plug-in, which may exist Many functions are missing and hidden BUG. If nothing happens, the project will not update new functions in the future. The author will start to develop a brand new animation plug-in that will not be compatible with the current version. The new project will maintain existing features. Under the premise of large-scale reconstruction, and focus on improving ease of use, scalability and performance. However, if you encounter any problems or find BUGs in the process of using `UTween`, you can submit feedback in the `Issues` of this repository. People who want to improve and perfect the plug-in together are welcome to initiate `Pull Request` .