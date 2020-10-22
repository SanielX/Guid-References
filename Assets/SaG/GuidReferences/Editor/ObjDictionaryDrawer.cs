using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SaG.GuidReferences;
using System;

[CustomPropertyDrawer(typeof(BehaviourToGuidDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }

[CustomPropertyDrawer(typeof(SerializableGuid))]
public class SerializableGuidDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = EditorGUIUtility.singleLineHeight;

        Rect rect = new Rect(position);
        EditorGUI.LabelField(rect, label);

        rect.x = position.width - position.width * 2.9f / 5f;
        rect.width = 35;

        var byteArray = property.FindPropertyRelative("byteArray");
        byte[] guidBytes = new byte[16];

        for (int i = 0; i < byteArray.arraySize; i++)
        {
            guidBytes[i] = (byte)byteArray.GetArrayElementAtIndex(i).intValue;
        }

        /*   var buttonPressed = GUI.Button(rect, "new");
           if (buttonPressed)
           {
               guidBytes = Guid.NewGuid().ToByteArray();

               for (int i = 0; i < byteArray.arraySize; i++)
               {
                   byteArray.GetArrayElementAtIndex(i).intValue = guidBytes[i];
               }
           }*/

        rect = new Rect(position);
        rect.x =  position.width * 0.25f;
        rect.width -= 275;
        EditorGUI.LabelField(rect, new Guid(guidBytes).ToString());
        property.serializedObject.ApplyModifiedProperties();
    }
}