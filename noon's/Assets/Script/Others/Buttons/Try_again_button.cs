using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Try_again_button : MonoBehaviour
{
    public LevelLoader level;

    public void checkpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        this.gameObject.SetActive(false);
    }
}
