using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(20);

        LevelGenerator generator = (LevelGenerator)target;

        if(GUILayout.Button("Generate"))
        {
            generator.Clear();
            generator.GenerateLevel();
        }

        if(GUILayout.Button("Clear"))
        {
            generator.Clear();
        }
    }
}
