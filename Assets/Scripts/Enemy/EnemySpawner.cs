using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private LevelsData levelsData;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        GameObject enemy = levelsData.levelSettingsList[LevelNumber.lastLevelNumber - 1].enemyPrefab;
        Instantiate(enemy, transform);

    }
}
