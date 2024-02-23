using UnityEngine;


[System.Serializable]
public class LevelData
{
    public int CurrentLevel;
    public float volume;

    public LevelData (save_Data level)
    {
        CurrentLevel = level.levelLoader.sceneIndex;
    }
}
