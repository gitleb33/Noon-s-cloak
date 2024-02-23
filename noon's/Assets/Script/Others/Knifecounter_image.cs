using UnityEngine;
using UnityEngine.UI;

public class Knifecounter_image : MonoBehaviour
{
    private Image num_image;
    public Sprite[] numbers;
    public PlayerStateManager player;

    private void Awake()
    {
        num_image = GetComponent<Image>();
    }

    private void Update()
    {
        if(player.thrownknifecounter == 0)
        {
            num_image.sprite = numbers[5];
        }
        else if(player.thrownknifecounter == 1)
        {
            num_image.sprite = numbers[4];
        }
        else if (player.thrownknifecounter == 2)
        {
            num_image.sprite = numbers[3];
        }
        else if(player.thrownknifecounter == 3)
        {
            num_image.sprite = numbers[2];
        }
        else if(player.thrownknifecounter == 4)
        {
            num_image.sprite = numbers[1];
        }
        else if(player.thrownknifecounter == 5)
        {
            num_image.sprite = numbers[0];
        }
    }
}
