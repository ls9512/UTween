/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenManagerEditor.cs
//  Info     : 插值动画 MonoBehaviour 运行组件
//  Author   : ls9512 2017
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Aya.Tween
{
    [CustomEditor(typeof(TweenManager))]
    public class TweenManagerEditor : Editor
    {
        public virtual TweenManager Target => target as TweenManager;
        protected List<SerializedProperty> PropertyList = new List<SerializedProperty>();
        protected GUIStyle TextStyle;

        public virtual void Awake()
        {
            TextStyle = new GUIStyle
            {
                normal = {textColor = Color.white},
                richText = true
            };
        }

        public virtual void OnEnable()
        {
            GetPropertyList();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawTweenManager();

            serializedObject.ApplyModifiedProperties();

            if (Target == null) return;
            if (Target.Pool.PoolDic.Count > 0)
            {
                Repaint();
            }
        }

        public void OnSceneGUI()
        {
            if (Target.Pool.PoolDic.Count > 0)
            {
                HandleUtility.Repaint();
            }
        }

        public virtual void GetPropertyList()
        {
            serializedObject.Update();
            var iterator = serializedObject.GetIterator();
            PropertyList.Clear();
            if (iterator.NextVisible(true))
            {
                do
                {
                    var property = serializedObject.FindProperty(iterator.name);
                    PropertyList.Add(property);
                }
                while (iterator.NextVisible(false));
            }
        }

        public void DrawTweenManager()
        {
            DrawGeneralInfo();
            DrawPoolInfo();
        }

        public void DrawGeneralInfo()
        {
            GUILayout.Space(5);

            GUILayout.BeginVertical();

            GUILayout.Label("<b>Tweener</b> : " + "<color=yellow>"+ Target.TweenerCount + "</color>", TextStyle);
            GUILayout.Label("<b>TweenAnimation</b> : " + "<color=yellow>" + Target.TweenAnimationCount + "</color>", TextStyle);

            GUILayout.Space(10);

            GUILayout.Label("<b>Cache List</b> : " + "<color=white>" + Target.CacheList.Count + "</color>", TextStyle);
            GUILayout.Label("<b>Update List</b> : " + "<color=white>" + Target.UpdateList.Count + "</color>", TextStyle);
            GUILayout.Label("<b>LateUpdate List</b> : " + "<color=white>" + Target.LateUpdateList.Count + "</color>", TextStyle);
            GUILayout.Label("<b>FixedUpdate List</b> : " + "<color=white>" + Target.FixedUpdateList.Count + "</color>", TextStyle);

            GUILayout.EndVertical();
        }

        public void DrawPoolInfo()
        {
            GUILayout.Space(10);

            GUILayout.BeginVertical();

            GUILayout.Label("<b>Pool</b> : " + "<color=yellow>" + Target.Pool.PoolDic.Count + "</color>", TextStyle);
            foreach (var kv in Target.Pool.PoolDic)
            {
                var poolName = "<b>" + kv.Key.Name + "</b>";
                var poolList = kv.Value;
                var value = "<color=white>" + poolList.Count + "</color>/<color=cyan>" + poolList.SpawnList.Count + "</color>/<color=red>" + poolList.DeSpawnList.Count +
                            "</color>";
                GUILayout.Label(poolName + " : " + value, TextStyle);
            }

            GUILayout.EndVertical();
        }
    }
}
#endif