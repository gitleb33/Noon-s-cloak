using UnityEngine;

public class Credits_Button : MonoBehaviour
{
    public GameObject[] menu_objects;
    public GameObject[] credits_objects;


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


    public void create_credits_menu()
    {
        for (int i = 0; i < credits_objects.Length; i++)
        {
            if (!credits_objects[i].activeInHierarchy)
            {
                credits_objects[i].SetActive(true);
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

    public void destroy_credits_menu()
    {
        for (int i = 0; i < credits_objects.Length; i++)
        {
            if (credits_objects[i].activeInHierarchy)
            {
                credits_objects[i].SetActive(false);
            }
        }
    }

}
