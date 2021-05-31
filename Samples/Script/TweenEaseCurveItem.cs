using UnityEngine;
using UnityEngine.UI;
using Aya.Tween;

namespace Aya.Sample
{
    public class TweenEaseCurveItem : MonoBehaviour
    {
        public int Type { get; set; }
        public Text TextType;
        [Header("Curve")]
        public RectTransform LineTrans;
        public LineRenderer LineCurve;
        public LineRenderer LineCoordinateTop;
        public LineRenderer LineCoordinateDown;
        public LineRenderer LineIndicator;

        [Header("Slider")]
        public Slider SliderDuration;
        public Slider SliderValue;
        public RectTransform SliderTrans;
        public RectTransform SliderInvalidTop;
        public RectTransform SliderInvalidDown;

        [Header("Button")]
        public Button BtnPlay;
        public Button BtnPause;
        public Button BtnPlayBackward;

        public EaseFunction EaseFunction;

        private float _duration = 0f;
        private float _value = 0f;
        private float _timer = 0f;
        public float Duration = 1f;

        public float Width { get; set; }
        public float Height { get; set; }

        public bool IsPlaying { get; set; } = true;
        public bool IsPlayBackward { get; set; }

        public void Init(int easeType)
        {
            Type = easeType;
            TextType.text = EaseType.ValueNameDic[Type];
            Width = LineTrans.rect.size.x / 2f;
            Height = LineTrans.rect.size.y / 2f;
            EaseFunction = EaseUtil.GetEaseFunction(easeType);
            CreateCurve();
        }

        private float _top;
        private float _down;
        private float _xMin;
        private float _xMax;
        private float _yMin;
        private float _yMax;

        public void CreateCurve()
        {
            var count = 100;

            // Test border
            _down = 0f;
            _top = 1f;
            for (var i = 0; i < count; i++)
            {
                var x = i * 1f / count;
                var y = EaseFunction.Ease(0f, 1f, x);
                if (y < _down) _down = y;
                if (y > _top) _top = y;
            }

            // Value Slider
            SliderValue.minValue = _down;
            SliderValue.maxValue = _top;

            var sliderHeight = SliderTrans.rect.size.y;
            var invalidTop = sliderHeight * (_top - 1f) / (_top - _down);
            var invalidDown = sliderHeight * -_down / (_top - _down);
            SliderInvalidTop.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invalidTop);
            SliderInvalidDown.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invalidDown);

            _xMin = -Width;
            _xMax = Width;
            _yMin = Mathf.Lerp(-Height, Height, -_down / (_top - _down));
            _yMax = Mathf.Lerp(-Height, Height, (1f - _down) / (_top - _down));

            // Coordinate
            LineCoordinateTop.positionCount = 2;
            LineCoordinateTop.SetPositions(new Vector3[2] { new Vector3(_xMin, _yMax, -0.5f), new Vector3(_xMax, _yMax, -0.5f) });
            LineCoordinateDown.positionCount = 2;
            LineCoordinateDown.SetPositions(new Vector3[2] { new Vector3(_xMin, _yMin, -0.5f), new Vector3(_xMax, _yMin, -0.5f) });

            // Draw curve
            var posList = new Vector3[count];
            for (var i = 0; i < count; i++)
            {
                var x = i * 1f / count;
                var y = EaseFunction.Ease(0f, 1f, x);

                x = x * (_xMax - _xMin) + _xMin;
                y = y * (_yMax - _yMin) + _yMin;

                var pos = new Vector3(x, y, -1);
                posList[i] = pos;
            }

            LineCurve.positionCount = count;
            LineCurve.SetPositions(posList);
        }

        public void Refresh()
        {
            SliderDuration.value = _duration;
            SliderValue.value = _value;

            var x = _duration * (_xMax - _xMin) + _xMin;
            var y = _value * (_yMax - _yMin) + _yMin;

            LineIndicator.positionCount = 3;
            LineIndicator.SetPositions(new Vector3[3]
                {new Vector3(x, _yMin, -1f), new Vector3(x, y, -1f), new Vector3(_xMax, y, -1f)});

        }

        public void Update()
        {
            if (!IsPlaying) return;
            if (IsPlayBackward)
            {
                _timer -= Time.deltaTime;
                if (_timer <= Duration)
                {
                    _timer = Duration;
                }
            }
            else
            {
                _timer += Time.deltaTime;
                if (_timer >= Duration)
                {
                    _timer = 0f;
                }
            }

            _duration = _timer / Duration;
            _value = EaseFunction.Ease(0f, 1f, _duration);

            Refresh();
        }
    }
}
