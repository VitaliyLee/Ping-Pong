using UnityEngine;
using UnityEditor;

public class LevelsDataEditorWindow : ExtendedEditorWindow
{
    private LevelsData _levelsData;
    private static LevelsDataEditorWindow editorWindow;
    private Vector2 scrollPosition = Vector2.zero;

    public static void Open(LevelsData levelsData)
    {
        editorWindow = GetWindow<LevelsDataEditorWindow>("Levels Data Editor");
        editorWindow.serializedObject = new SerializedObject(levelsData);
    }

    private void RedrawWindow(LevelsData levelsData)
    {
        editorWindow.Close();

        editorWindow = GetWindow<LevelsDataEditorWindow>("Levels Data Editor");
        editorWindow.serializedObject = new SerializedObject(levelsData);
    }

    private void DeleteCerrentElement()
    {
        
        for (int i = 0; i < _levelsData.levelSettingsList.Count; i++)
        {
            if (_levelsData.levelSettingsList[i].levelName == selectedPropertyName)
            {
                _levelsData.levelSettingsList.RemoveAt(i);
                RedrawWindow(_levelsData);
                return;
            }
        }
    }

    private void ApplayEditing()
    {
        serializedObject.ApplyModifiedProperties();
    }

    private void OnGUI()
    {
        _levelsData = Resources.Load("LevelsData") as LevelsData;

        currentProperty = serializedObject.FindProperty("levelSettingsList");

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

        if (GUILayout.Button("Add"))
        {
            LevelSettings levelSettings = new LevelSettings();

            _levelsData.levelSettingsList.Add(levelSettings);
            
            RedrawWindow(_levelsData);
        }

        GUILayout.Space(20);

        scrollPosition =  EditorGUILayout.BeginScrollView(scrollPosition, false, true);
        DrawSidbar(currentProperty);
        EditorGUILayout.EndScrollView();

        GUILayout.Space(20);

        if (GUILayout.Button("Clear DB"))
        {
            _levelsData.levelSettingsList.Clear();
            
            RedrawWindow(_levelsData);
        }

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));

        if (selectedProperty != null)
        {
            DrawProperties(selectedProperty, true);

            if (GUILayout.Button("Delete"))
            {
                DeleteCerrentElement();
            }
        }

        else
        {
            EditorGUILayout.LabelField("Selected an item from the list");
        }

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        ApplayEditing();
    }
}
