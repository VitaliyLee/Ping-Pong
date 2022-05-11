using UnityEngine;
using UnityEditor;

public class ExtendedEditorWindow : EditorWindow
{
    protected SerializedObject serializedObject;
    protected SerializedProperty currentProperty;

    private string selectedPropertyPath;
    private LevelsData _levelsData;

    protected string selectedPropertyName;
    protected SerializedProperty selectedProperty;

    protected void DrawProperties(SerializedProperty property, bool drawChildren)
    {
        _levelsData = Resources.Load("LevelsData") as LevelsData;

        string lastPropertyPath = string.Empty;

        foreach (SerializedProperty prop in property)
        {
            if (prop.isArray && prop.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUILayout.BeginHorizontal();
                prop.isExpanded = EditorGUILayout.Foldout(prop.isExpanded, prop.displayName);
                EditorGUILayout.EndHorizontal();

                if (prop.isExpanded)
                {
                    EditorGUI.indentLevel++;

                    DrawProperties(prop, drawChildren);

                    EditorGUI.indentLevel--;
                }
            }

            else
            {
                if (!string.IsNullOrEmpty(lastPropertyPath) &&
                    prop.propertyPath.Contains(lastPropertyPath)) continue;

                lastPropertyPath = prop.propertyPath;
                EditorGUILayout.PropertyField(prop, drawChildren);
            }
        }
    }

    protected void DrawSidbar(SerializedProperty property)
    {
        foreach (SerializedProperty prop in property)
        {
            if (GUILayout.Button(prop.displayName))
            {
                selectedPropertyPath = prop.propertyPath;

                selectedPropertyName = prop.displayName;
            }

            if (!string.IsNullOrEmpty(selectedPropertyPath))
            {
                selectedProperty = serializedObject.FindProperty(selectedPropertyPath);
            }
        }
    }
}
