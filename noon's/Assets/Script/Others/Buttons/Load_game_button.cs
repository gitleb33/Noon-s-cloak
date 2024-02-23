using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_game_button : MonoBehaviour
{
    public load_Data levelLoad;
    public LevelLoader levelLoader;
    public void LoadGame()
    {
        levelLoad.LoadLevel();
        SceneManager.LoadScene(levelLoader.sceneIndex);

    }
}
