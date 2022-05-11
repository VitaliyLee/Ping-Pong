using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private LevelsData levelsData;

    private void Start()
    {
        if (LevelNumber.lastLevelNumber <= 0)
        {
            LevelNumber.SetLevelNumber(1);
        }

        GameObject background = levelsData.levelSettingsList[LevelNumber.lastLevelNumber - 1].backgroundPrefab;

        Instantiate(background, transform);

    }
}
