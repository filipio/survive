using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SimpleAudioEvent))]
public class SimpleAudioEventEditor : Editor
{
    private AudioSource previewSource;

    private void OnEnable()
    {
        previewSource = EditorUtility.
            CreateGameObjectWithHideFlags("Audio Preview", HideFlags.HideAndDontSave, typeof(AudioSource))
            .GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        DestroyImmediate(previewSource.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("Preview"))
        {
            var simpleTarget = (SimpleAudioEvent)target;
            simpleTarget.Play(previewSource);
        }

        EditorGUI.EndDisabledGroup();
    }
}
