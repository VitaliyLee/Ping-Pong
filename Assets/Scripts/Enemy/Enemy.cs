using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LevelsData levelsData;

    private EnemyMovement enemyMovement;
    private LevelSettings enemySettings;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();

        SelectSettings();
        
        SetEnemyParameters();
    }

    private void SelectSettings()
    {
        enemySettings = levelsData.levelSettingsList[LevelNumber.lastLevelNumber - 1];
    }

    private void SetEnemyParameters()
    {
        enemyMovement.SetParameters(enemySettings.speed, enemySettings.reactionSpeed);
    }
}
