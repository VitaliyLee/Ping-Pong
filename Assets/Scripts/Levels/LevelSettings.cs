using UnityEngine;

[System.Serializable]
public class LevelSettings
{
    [SerializeField] private string _levelName;
    [SerializeField] private int _levelIdentyfire;

    [Header("Level")]
    [SerializeField] private int _winScore;

    [Header("Background")]
    [SerializeField] private GameObject _backgroundPrefab;

    [Space(20)]
    [Header("Ball parameters")]
    [SerializeField] private Sprite _ballSprite;
    [SerializeField] private float _startPower;
    [Range(1, 50)]
    [SerializeField] private float _boostPercent;
    [SerializeField] private Animator _hitEffect;

    [Space(20)]
    [Header("Enemy parameters")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _reactionSpeed;

    public string levelName => _levelName;
    public int levelIdentyfire => _levelIdentyfire;

    //Level
    public int winScore => _winScore;

    //Background
    public GameObject backgroundPrefab => _backgroundPrefab;

    //Ball parameters
    public Sprite ballSprite => _ballSprite;
    public float startPower => _startPower;
    public float boostPercent => _boostPercent;
    public Animator hitEffect => _hitEffect;

    //Enemy parameters
    public GameObject enemyPrefab => _enemyPrefab;
    public float speed => _speed;
    public float reactionSpeed => _reactionSpeed;
}
