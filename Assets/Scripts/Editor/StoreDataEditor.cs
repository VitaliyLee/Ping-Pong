using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StoreData))]
public class StoreDataEditor : Editor
{
    private StoreData storeData ;

    private void Awake()
    {
        storeData = (StoreData)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
        {
            PlatformCardData platformCardData = new PlatformCardData();

            storeData.StoreModel.ProductCardDataList.Add(platformCardData);
        }

        if (GUILayout.Button("Save"))
        {
            Debug.Log(storeData.StoreModel.ProductCardDataList[0].platformName);
        }

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
