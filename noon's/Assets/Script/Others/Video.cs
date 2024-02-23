using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    public GameObject skip_text;

    private int pressF_counter;
    private bool canstartdissapeartimer;
    private float dissapeartimer;
    private int CurrentState;

    private float videoTimer;


    private void Awake()
    {
        videoTimer = 0;
        pressF_counter = 0;
        dissapeartimer = 3;
        CurrentState = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        // Skiplenerek sahne geçişi--------------------------------------------------------------
        if (Input.GetKey(KeyCode.F) && pressF_counter == 0)
        {
            pressF_counter += 1;
            skip_text.SetActive(true);
            canstartdissapeartimer = true;
        }

        if (canstartdissapeartimer)
        {
            if(dissapeartimer > 0)
            {
                dissapeartimer -= Time.deltaTime;

                if (Input.GetKey(KeyCode.F) && pressF_counter == 1 && dissapeartimer <= 2.5f)
                {
                    if(CurrentState == 0)
                    {
                        SceneManager.LoadScene("Main_Menu");
                        videoTimer = 0;
                    }
                    else if (CurrentState == 2)
                    {
                        SceneManager.LoadScene("Level1-1");
                        videoTimer = 0;
                    }
                    else if(CurrentState == 6)
                    {
                        SceneManager.LoadScene("Level2-1");
                        videoTimer = 0;
                    }
                    else if(CurrentState == 10)
                    {
                        SceneManager.LoadScene("Level3-1");
                        videoTimer = 0;
                    }
                    else if(CurrentState == 13)
                    {
                        SceneManager.LoadScene("Main_Menu");
                        videoTimer = 0;
                    }
                }
            }
            else 
            {
                skip_text.SetActive(false);
                canstartdissapeartimer = false;
                dissapeartimer = 3;
                pressF_counter = 0;
            }
        }


        // Skiplenmeden sahne geçişi------------------------------------------------------
        if(CurrentState == 0)
        {
            if(videoTimer < 30)
            {
                videoTimer += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Main_Menu");
                videoTimer = 0;
            }
        }
        else if(CurrentState == 2)
        {
            if(videoTimer < 16)
            {
                videoTimer += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Level1-1");
                videoTimer = 0;
            }
        }
        else if(CurrentState == 6)
        {
            if (videoTimer < 12)
            {
                videoTimer += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Level2-1");
                videoTimer = 0;
            }
        }
        else if(CurrentState == 10)
        {
            if (videoTimer < 12)
            {
                videoTimer += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Level3-1");
                videoTimer = 0;
            }
        }
        else if(CurrentState == 13)
        {
            if(videoTimer < 23)
            {
                videoTimer += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Main_Menu");
                videoTimer = 0;
            }
        }
    }
}
