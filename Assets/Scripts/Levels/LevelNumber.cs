using UnityEngine;

public static class LevelNumber
{
    public static int lastLevelNumber;
    private static string key = "LastLevelNum";

    static LevelNumber()
    {
        lastLevelNumber = PlayerPrefs.GetInt(key);
    }

    public static void SaveLevelNumber()
    {
        PlayerPrefs.SetInt(key, lastLevelNumber);
        PlayerPrefs.Save();
    }

    public static void AddLevel()
    {
        lastLevelNumber++;
    }

    public static void SetLevelNumber(int number)
    {
        lastLevelNumber = number;

        PlayerPrefs.SetInt(key, lastLevelNumber);
        PlayerPrefs.Save();
    }
}
