/////////////////////////////////////////////////////////////////////////////
//
//  Script   : EnumClassDrawer.cs
//  Info     : 枚举绘制器
//  Author   : ls9512 2020
//  E-mail   : ls9512@vip.qq.com
//
/////////////////////////////////////////////////////////////////////////////
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Aya.Tween
{
    [CustomPropertyDrawer(typeof(SerializeEnumAttribute))]
    public class SerializeEnumDrawer : PropertyDrawer
    {
        public SerializeEnumAttribute Attribute => ((SerializeEnumAttribute) attribute);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var baseHeight = base.GetPropertyHeight(property, label);
            return baseHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var labelPos = position;
            labelPos.width = EditorGUIUtility.labelWidth;
            EditorGUI.LabelField(labelPos, Attribute.EnumType);

            var popupPos = position;
            popupPos.x += labelPos.width;
            popupPos.width -= labelPos.width;

            var enumType = Attribute.EnumType;
            var infos = SerializeEnumAttribute.TypeInfosDic[enumType];
            var selectionName = SerializeEnumAttribute.TypeIndexInfoDic[enumType][property.intValue].DisplayName;

            var btnEnum = GUI.Button(popupPos, selectionName);
            if (btnEnum)
            {
                var menu = new GenericMenu();
                for (var i = 0; i < infos.Count; i++)
                {
                    var info = infos[i];
                    if (!info.Display) continue;
                    var path = info.Path;
                    var name = info.DisplayName;
                    var index = info.Index;
                    var select = property.intValue == index;
                    var menuPath = (!string.IsNullOrEmpty(path) ? path + "/" : "") + name;
                    void MenuFunc()
                    {
                        property.intValue = index;
                        property.serializedObject.ApplyModifiedProperties();
                    }

                    menu.AddItem(new GUIContent(menuPath), select, MenuFunc);
                }

                menu.ShowAsContext();
            }

            EditorGUI.EndProperty();
        }
    }
}
#endif