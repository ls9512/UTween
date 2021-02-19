using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aya.Tween;

namespace Aya.Example
{
    public class TweenEaseCurvePreviewIMGUI : MonoBehaviour
    {
        public int GridX;
        public int GridY;
        public int Accuracy = 100;

        public Dictionary<int, Texture2D> TextureDic = new Dictionary<int, Texture2D>();

        public void Start()
        {
            StartCoroutine(CreateTexture());
        }

        public IEnumerator CreateTexture()
        {
            var easeTypes = EaseType.NameValueDic.Values;

            var gridWidth = Screen.width / (GridX + 1);
            var gridHeight = Screen.height / (GridY + 1);

            var texWidth = gridWidth;
            var texHeight = gridHeight;
            var curveWidth = gridWidth / 1.5f;
            var curveHeight = gridHeight / 2f;

            var startX = texWidth * 0.15f;
            var startY = texWidth * 0.15f;

            var colorCurve = Color.green;

            foreach (var easeType in easeTypes)
            {
                var texture = new Texture2D(texWidth, texHeight);
                for (var t = 0; t < Accuracy - 1; t++)
                {
                    var time1 = t * 1f / Accuracy;
                    var p1 = GetPoint(startX, startY, curveWidth, curveHeight, easeType, time1);
                    var time2 = (t + 1) * 1f / Accuracy;
                    var p2 = GetPoint(startX, startY, curveWidth, curveHeight, easeType, time2);
                    DrawLine(texture, p1, p2, colorCurve);
                }

                texture.Apply();
                TextureDic.Add(easeType, texture);

                yield return null;
            }
        }

        public void OnGUI()
        {
            var indexX = 0;
            var indexY = 0;

            var gridWidth = Screen.width / (GridX + 1);
            var gridHeight = Screen.height / (GridY + 1);

            if (TextureDic.Count == 0) return;

            GUILayout.BeginVertical();

            var lienEnd = false;
            foreach (var kv in TextureDic)
            {
                if (indexX == 0)
                {
                    GUILayout.BeginHorizontal(GUILayout.Width(gridWidth), GUILayout.Height(gridHeight));
                    lienEnd = false;
                }

                GUILayout.BeginVertical();
                GUILayout.Box(kv.Value);
                GUILayout.TextArea(EaseType.ValueNameDic[kv.Key]);
                GUILayout.EndVertical();

                indexX++;
                if (indexX >= GridX)
                {
                    indexX = 0;
                    indexY++;
                    GUILayout.EndHorizontal();
                    lienEnd = true;
                }
            }

            if (!lienEnd)
            {
                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
        }

        public void DrawLine(Texture2D texture, Vector2 start, Vector2 end, Color color)
        {
            var diffX  = Mathf.Abs(start.x - end.x);
            var diffY = Mathf.Abs(start.y - end.y);
            var count = (int) (diffX > diffY ? diffX : diffY);
            for (var i = 0; i < count; i++)
            {
                var delta = i * 1f / count;
                var point = Vector2.Lerp(start, end, delta);
                texture.SetPixel((int)point.x, (int)point.y, color);
            }
        }

        public Vector2 GetPoint(float startX, float startY, float curveWidth, float curveHeight, int easeType, float time)
        {
            var value = LerpUtil.Lerp(easeType, 0f, 1f, time);
            var x = startX + curveWidth * time;
            var y = startY + curveHeight * value;
            var point = new Vector2(x, y);
            return point;
        }
    }
}