using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool Openeditor(int instanceId, int line)
    {
        LevelsData data = EditorUtility.InstanceIDToObject(instanceId) as LevelsData;
        
        if (data != null)
        {
            LevelsDataEditorWindow.Open(data);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(LevelsData))]
public class LevelsDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open Editor"))
        {
            LevelsDataEditorWindow.Open((LevelsData)target);
        }
    }
}
