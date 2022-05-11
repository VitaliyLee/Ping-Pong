using System.Collections.Generic;
using UnityEngine;

public class SelectGoods : MonoBehaviour
{
    [SerializeField] private StoreData storeData;
    [SerializeField] private GoodsCard goodsCard;

    private List<PlatformCardData> platformCardDatas;
    private int indexer;

    private void Start()
    {
        platformCardDatas = storeData.StoreModel.ProductCardDataList;

        indexer = 0;
        ViewGoods();
    }

    private void ViewGoods()
    {
        if (indexer > platformCardDatas.Count - 1) indexer = 0;
        else if (indexer < 0) indexer = platformCardDatas.Count - 1;
        
        goodsCard.SetGoodsInfo(platformCardDatas[indexer]);
    }

    public void PreviousElement()
    {
        indexer--;

        ViewGoods();
    }

    public void NextElement()
    {
        indexer++;

        ViewGoods();
    }
}
