using UnityEngine;

public class StopMenu : MonoBehaviour
{
    public void Stop()
    {
        SpawnBall.GetInstance().MuteBall();
        Time.timeScale = 0;
    }

    public void Continue()
    {
        SpawnBall.GetInstance().MuteBall();
        Time.timeScale = 1;
    }
}
