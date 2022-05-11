using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlatformCardData
{
    [SerializeField] private bool isBuy;

    [SerializeField] private string _platformName;
    [SerializeField] private float _platformSpeed;
    [SerializeField] private GameObject _platform;
    [SerializeField] private int _price;

    public bool IsBuy
    {
        get => isBuy;

        set => isBuy = value;
    }

    public string platformName => _platformName;
    public float platformSpeed => _platformSpeed;
    public GameObject platform => _platform;
    public int price => _price;
}
