using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public int sceneIndex;
    public int CurrentScene;

    public save_Data levelSave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(sceneIndex);
            SaveLevel();
        }
    }

    public void SaveLevel()
    {
        SaveSystem.SaveLevel(levelSave);
    }
}
