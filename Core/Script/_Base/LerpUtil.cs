/////////////////////////////////////////////////////////////////////////////
//
//  Script   : LerpUtil.cs
//  Info     : 插值计算辅助类
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Aya.Tween
{
    public static class LerpUtil
    {
        #region Lerp Float / Vector2 / Vector3

        public static float Lerp(int easeType, float from, float to, float delta)
        {
            var result = EaseUtil.Ease(easeType, @from, to, delta);
            return result;
        }

        public static Vector2 Lerp(int easeType, Vector2 from, Vector2 to, float delta)
        {
            var x = Lerp(easeType, @from.x, to.x, delta);
            var y = Lerp(easeType, @from.y, to.y, delta);
            return new Vector2(x, y);
        }

        public static Vector3 Lerp(int easeType, Vector3 from, Vector3 to, float delta)
        {
            var x = Lerp(easeType, @from.x, to.x, delta);
            var y = Lerp(easeType, @from.y, to.y, delta);
            var z = Lerp(easeType, @from.z, to.z, delta);
            return new Vector3(x, y, z);
        }

        #endregion

        #region Lerp

        public static Color LerpRgb(Color from, Color to, float delta)
        {
            return new Color(
                Mathf.Lerp(@from.r, to.r, delta),
                Mathf.Lerp(@from.g, to.g, delta),
                Mathf.Lerp(@from.b, to.b, delta),
                Mathf.Lerp(@from.a, to.a, delta));
        }

        public static Color LerpHsv(Color from, Color to, float delta)
        {
            Color.RGBToHSV(@from, out var fH, out var fS, out var fV);
            Color.RGBToHSV(to, out var tH, out var tS, out var tV);
            var color = Color.HSVToRGB(
                Mathf.Lerp(fH, tH, delta),
                Mathf.Lerp(fS, tS, delta),
                Mathf.Lerp(fV, tV, delta));
            var alpha = Mathf.Lerp(@from.a, to.a, delta);
            return new Color(color.r, color.g, color.b, alpha);
        }

        public static float LerpHue(float h1, float h2, float delta)
        {
            var min = h1 < h2 ? h1 : h2;
            var max = h1 < h2 ? h2 : h1;
            var diff = max - min;
            if (diff > 0.5f)
            {
                var minD = min;
                var maxD = 1f - max;
                var offset = (minD + maxD) * delta;
                if (h1 < h2)
                {
                    var result = minD - offset;
                    if (result < 0f)
                    {
                        result = 1f + result;
                    }

                    return result;
                }

                if (h1 > h2)
                {
                    var result = maxD + offset;
                    if (result > 1f)
                    {
                        result = result - 1f;
                    }

                    return result;
                }

                return min + (max - min) * delta;
            }
            else
            {
                return min + (max - min) * delta;
            }
        }

        #endregion

        #region Lerp Text

        private static readonly StringBuilder Buffer = new StringBuilder();
        private static readonly List<char> OpenedTags = new List<char>();

        public static string Lerp(string value, float delta, bool richTextEnabled)
        {
            // DoTween SourceCode Start
            Buffer.Clear();
            var strLength = value.Length;
            if (richTextEnabled)
            {
                var index = 0;
                var len = 0;
                var findStart = false;
                var findStartIndex = 0;
                var findEnd = false;
                var findEndIndex = 0;
                while (index < value.Length)
                {
                    var ch = value[index];
                    if (ch == '<')
                    {
                        findStart = true;
                        findStartIndex = index;
                    }

                    if (ch == '>')
                    {
                        findEnd = true;
                        findEndIndex = index;
                    }

                    len++;
                    index++;

                    if (findStart && findEnd)
                    {
                        len -= findEndIndex - findStartIndex + 1;
                        findStart = false;
                        findEnd = false;
                    }
                }

                strLength = len;
            }

            var startIndex = 0;
            var length = (int)(delta * strLength);
            length = Mathf.Clamp(length, 0, value.Length);
            if (!richTextEnabled)
            {
                Buffer.Append(value, startIndex, length);
                return Buffer.ToString();
            }

            OpenedTags.Clear();
            var flag = false;
            var num = value.Length;
            var num2 = 0;
            while (num2 < length)
            {
                var ch = value[num2];
                if (ch == '<')
                {
                    var flag2 = flag;
                    var ch2 = value[num2 + 1];
                    flag = (num2 >= (num - 1)) || (ch2 != '/');
                    if (flag)
                    {
                        OpenedTags.Add((ch2 == '#') ? 'c' : ch2);
                    }
                    else
                    {
                        OpenedTags.RemoveAt(OpenedTags.Count - 1);
                    }

                    var match = Regex.Match(value.Substring(num2), "<.*?(>)");
                    if (match.Success)
                    {
                        if (!flag && !flag2)
                        {
                            var ch3 = value[num2 + 1];
                            var chArray = ch3 == 'c' ? new char[] { '#', 'c' } : new char[] {ch3};

                            for (var i = num2 - 1; i > -1; i--)
                            {
                                if (((value[i] == '<') && (value[i + 1] != '/')) && (Array.IndexOf<char>(chArray, value[i + 2]) != -1))
                                {
                                    Buffer.Insert(0, value.Substring(i, (value.IndexOf('>', i) + 1) - i));
                                    break;
                                }
                            }
                        }

                        Buffer.Append(match.Value);
                        var num3 = match.Groups[1].Index + 1;
                        length += num3;
                        startIndex += num3;
                        num2 += num3 - 1;
                    }
                }
                else if (num2 >= startIndex)
                {
                    Buffer.Append(ch);
                }

                num2++;
            }

            if ((OpenedTags.Count > 0) && (num2 < (num - 1)))
            {
                while ((OpenedTags.Count > 0) && (num2 < (num - 1)))
                {
                    var match2 = Regex.Match(value.Substring(num2), "(</).*?>");
                    if (!match2.Success)
                    {
                        break;
                    }

                    if (match2.Value[2] == OpenedTags[OpenedTags.Count - 1])
                    {
                        Buffer.Append(match2.Value);
                        OpenedTags.RemoveAt(OpenedTags.Count - 1);
                    }

                    num2 += match2.Value.Length;
                }
            }

            return Buffer.ToString();

            // DoTween SourceCode End
        }

        #endregion
    }
}
