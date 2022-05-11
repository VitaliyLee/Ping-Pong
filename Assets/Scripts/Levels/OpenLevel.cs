using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    public void Open()
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }

    public void OpenSelectLevel(int levelNumber)
    {
        LevelNumber.SetLevelNumber(levelNumber);
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
}
