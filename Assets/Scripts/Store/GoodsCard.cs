using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoodsCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI platformName;
    [SerializeField] private Transform platformTransform;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI platformPrice;
    [SerializeField] private Slider platformSpeed;
    
    [SerializeField] private Button play, buy;

    private PlatformCardData platformData;
    private GameObject platform;
    private string moneyKey = "Money";

    public void SetGoodsInfo(PlatformCardData PlatformData)
    {
        platformData = PlatformData;
        platformName.text = PlatformData.platformName;

        Destroy(platform);
        platform = Instantiate(PlatformData.platform, platformTransform);

        
        platformSpeed.value = PlatformData.platformSpeed / 10;

        if (platformData.IsBuy)
        {
            platformPrice.gameObject.SetActive(false);
            buy.gameObject.SetActive(false);
            play.gameObject.SetActive(true);
        }

        else
        {
            platformPrice.gameObject.SetActive(true);
            platformPrice.text = "$" + PlatformData.price;

            buy.gameObject.SetActive(true);
            play.gameObject.SetActive(false);
        }
    }

    public void Buy()
    {
        int money = PlayerPrefs.GetInt(moneyKey);
        if (money >= platformData.price)
        {
            PlayerPrefs.SetInt(moneyKey, money - platformData.price);
            platformData.IsBuy = true;
            SetLastPlatform();
            SetGoodsInfo(platformData);
            Debug.Log(">");
        }
        else Debug.Log("<");
    }

    public void SetLastPlatform()
    {
        string key = "LastPlatformName";
        PlayerPrefs.SetString(key, platformName.text);
        Debug.Log(PlayerPrefs.GetString(key));
    }
}
