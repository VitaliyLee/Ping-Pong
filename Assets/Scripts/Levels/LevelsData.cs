using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New LevelsData", menuName = "Levels Data")]
public class LevelsData : ScriptableObject
{
    public List<LevelSettings> levelSettingsList = new List<LevelSettings>();
}
