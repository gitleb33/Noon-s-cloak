using UnityEngine;

public class save_Data : MonoBehaviour
{
    public LevelLoader levelLoader;
    
    public void SaveLevel()
    {
        SaveSystem.SaveLevel(this);
    }
}