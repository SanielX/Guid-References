using System.Linq;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

namespace SaG.GuidReferences.Editor
{
    [CustomEditor(typeof(GuidComponent))]
    public class GuidComponentDrawer : UnityEditor.Editor
    {
        private GuidComponent guidComp;

        public override void OnInspectorGUI()
        {
            if (guidComp == null)
            {
                guidComp = (GuidComponent)target;
            }
       
            // Draw label
            EditorGUILayout.LabelField("Guid:", guidComp.GetGuid().ToString());

     //       Dictionary<Behaviour, SerializableGuid> dic = guidComp.dic as Dictionary<Behaviour, SerializableGuid>;
            var keys = guidComp.dic.Keys.ToArray();
            var vals = guidComp.dic.Values.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Guid:", keys[i].Guid.ToString());
#pragma warning disable CS0618 
                EditorGUILayout.ObjectField(vals[i], typeof(UnityEngine.Object));
#pragma warning restore CS0618 
            }

            EditorGUILayout.Space();
            if(GUILayout.Button("Update components"))
            {
                guidComp.UpdateDic();
            }
        }
    }
}