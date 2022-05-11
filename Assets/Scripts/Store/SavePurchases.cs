using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavePurchases : MonoBehaviour
{
    [SerializeField] private StoreData storeData;

    private string path;

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "SavePurchasesData.json");
        LoadData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(storeData.StoreModel);
        Debug.Log(json);
        StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
        writer.Close();
    }

    public void LoadData()
    {
        StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        Debug.Log(path);
        storeData.StoreModel = JsonUtility.FromJson<StoreModel>(json);
    }
}
