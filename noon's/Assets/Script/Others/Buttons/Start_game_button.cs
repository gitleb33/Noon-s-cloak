using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_game_button : MonoBehaviour
{

    public GameObject warning_object;
    public GameObject[] menu_objects;

    public load_Data levelLoad;
    public save_Data levelSave;
    public LevelLoader levelLoader;

    public void startgame()
    {
        levelLoad.LoadLevel();
        if (levelLoader.sceneIndex != 2)
        {
            create_warning_object();
            destroy_menu_objects();
            Debug.Log(levelLoader.sceneIndex);
        }
        else
        {
            SceneManager.LoadScene(levelLoader.sceneIndex);
        }
    }

    public void create_warning_object()
    {
        warning_object.SetActive(true);
    }

    public void destroy_warning_object()
    {
        warning_object.SetActive(false);
    }

    public void destroy_menu_objects()
    {
        for (int i = 0; i < menu_objects.Length; i++)
        {
            if (menu_objects[i].activeInHierarchy)
            {
                menu_objects[i].SetActive(false);
            }
        }
    }

    public void create_menu_objects()
    {
        for (int i = 0; i < menu_objects.Length; i++)
        {
            if (!menu_objects[i].activeInHierarchy)
            {
                menu_objects[i].SetActive(true);
            }
        }
    }

    public void answer_yes()
    {
        levelLoader.sceneIndex = 2;
        levelSave.SaveLevel();
        startgame();
    }

    public void answer_no()
    {
        create_menu_objects();
        destroy_warning_object();
    }
}
