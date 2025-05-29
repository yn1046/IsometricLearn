using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelArea))]
public class LevelAreaEditor : Editor
{
    private bool _eastEntrance;
    private bool _westEntrance;
    private bool _northEntrance;
    private bool _southEntrance;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Apply"))
        {
            var levelArea = target as LevelArea;
            levelArea.SetMask(_eastEntrance, _westEntrance, _northEntrance, _southEntrance);
            EditorUtility.SetDirty(levelArea);
        }
        _eastEntrance = GUILayout.Toggle(_eastEntrance, "East");
        _westEntrance = GUILayout.Toggle(_westEntrance, "West");
        _northEntrance = GUILayout.Toggle(_northEntrance, "North");
        _southEntrance = GUILayout.Toggle(_southEntrance, "South");        
    }
}
