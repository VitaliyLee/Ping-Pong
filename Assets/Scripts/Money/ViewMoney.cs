using TMPro;
using UnityEngine;

public class ViewMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private string key = "Money";

    private void Update()
    {
        int money = PlayerPrefs.GetInt(key);
        moneyText.text = money.ToString();
    }

    public void SetMoney(int Money)
    {
        int money = PlayerPrefs.GetInt(key);
        PlayerPrefs.SetInt(key, money + Money);
    }
}
