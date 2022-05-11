using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private LevelsData levelsData;
    [SerializeField] private Score playerScore;
    [SerializeField] private Score enemyScore;

    [Header("Menu")]
    [SerializeField] private GameObject menu;
    [SerializeField] private TextMeshProUGUI menuText;

    private string key = "Money";
    private int victoryScore;

    private void Start()
    {
        playerScore.levelComplite.AddListener(ScoreChecking);
        enemyScore.levelComplite.AddListener(ScoreChecking);
        SetVictoryScore();
    }

    private void ScoreChecking()
    {
        if (playerScore.score == victoryScore)
        {
            PlayerVictory();
        }

        if (enemyScore.score == victoryScore)
        {
            EnemyVictory();
        }
    }

    private void PlayerVictory()
    {
        SetMoney();

        if (LevelNumber.lastLevelNumber < levelsData.levelSettingsList.Count)
        {
            LevelNumber.AddLevel();
            LevelNumber.SaveLevelNumber();
        }

        menu.SetActive(true);
        menuText.text = "You Win!";

        SpawnBall.GetInstance().MuteBall();
        Time.timeScale = 0;
    }

    private void EnemyVictory()
    {
        menu.SetActive(true);
        menuText.text = "You Loss...";

        SpawnBall.GetInstance().MuteBall();
        Time.timeScale = 0;
    }

    private void SetVictoryScore()
    {
        victoryScore = levelsData.levelSettingsList[LevelNumber.lastLevelNumber - 1].winScore;
    }

    private void SetMoney()
    {
        int money = PlayerPrefs.GetInt(key);
        money += playerScore.score;
        PlayerPrefs.SetInt(key, money);
    }
}
