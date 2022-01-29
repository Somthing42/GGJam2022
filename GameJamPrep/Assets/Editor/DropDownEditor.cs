using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractableAssigner))]
public class DropdownEditor : Editor
{
   
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();

        InteractableAssigner script = (InteractableAssigner)target;

        GUIContent arrayLabel = new GUIContent("InteractableType");
        script.arrayIdx = EditorGUILayout.Popup(arrayLabel, script.arrayIdx, script.Type);

        serializedObject.ApplyModifiedProperties();
    }
}

