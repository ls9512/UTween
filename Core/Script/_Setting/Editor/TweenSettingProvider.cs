/////////////////////////////////////////////////////////////////////////////
//
//  Script   : TweenSettingProvider.cs
//  Info     : 插值动画全局配置集成到 Project Setting
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if  UNITY_EDITOR
using UnityEditor;

namespace Aya.Tween
{
    public static class TweenSettingProvider
    {
        #region Setting
        
        public static SerializedObject Setting
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new SerializedObject(TweenSetting.Ins);
                }

                return _setting;
            }
        }

        private static SerializedObject _setting; 

        #endregion

        [SettingsProvider]
        public static SettingsProvider GetTweenSetting()
        {
            return new SettingsProvider("Aya Game Studio/UTween", SettingsScope.Project)
            {
                guiHandler = (searchContext) =>
                {
                    EditorGUILayout.BeginVertical();

                    var property = Setting.GetIterator();
                    while (property.NextVisible(true))
                    {
                        if (property.displayName == "Script") continue;
                        EditorGUILayout.PropertyField(property);
                    }

                    Setting.ApplyModifiedProperties();

                    EditorGUILayout.EndVertical();
                }
            };
        }
    }
}
#endif