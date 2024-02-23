using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    [SerializeField]private GameObject Qmenu;
    private float timer;
    private void Awake()
    {
        timer = 0;
    }
    private void Update()
    {
        if (!Qmenu.activeInHierarchy && timer <= 0)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                timer = 0.2f;
                Qmenu.SetActive(true);
            }
        }
        else if (Qmenu.activeInHierarchy && timer <= 0)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                timer = 0.2f;
                Qmenu.SetActive(false);
            }
        }

        if(timer != 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
