using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreModel
{
    public List<PlatformCardData> ProductCardDataList;

    public StoreModel(List<PlatformCardData> productCardDataList)
    {
        ProductCardDataList = productCardDataList;
    }
}
