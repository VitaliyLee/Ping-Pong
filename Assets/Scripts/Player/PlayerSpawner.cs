using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private StoreData storeData;
    [SerializeField] private GameObject defoultPlatform;

    private List<PlatformCardData> platformCardList;

    private string key = "LastPlatformName";

    private void Start()
    {
        platformCardList = storeData.StoreModel.ProductCardDataList;

        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        string name = PlayerPrefs.GetString(key);
        for (int i = 0; i < storeData.StoreModel.ProductCardDataList.Count; i++)
        {
            if (platformCardList[i].platformName == name)
            {
                GameObject platform = Instantiate(platformCardList[i].platform, transform);
                platform.GetComponent<PlayerMovement>().SetSpeed(platformCardList[i].platformSpeed);
                return;
            }
        }
        GameObject _platform = Instantiate(defoultPlatform, transform);
        _platform.GetComponent<PlayerMovement>().SetSpeed(2.5f);
    }
}
