using UnityEngine;

public class load_Data : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void LoadLevel()
    {
        LevelData data = SaveSystem.LoadLevel();
        levelLoader.sceneIndex = data.CurrentLevel;
    }
}
