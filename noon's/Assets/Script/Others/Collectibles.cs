using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public PlayerStateManager player;


    public float interpolation;
    public float max_position_value;
    public float min_position_value;
    public bool go_up;
    public bool go_dowm;

    private void Awake()
    {
        max_position_value = transform.position.y + 0.5f;
        min_position_value = transform.position.y - 0.5f;
    }
    private void Update()
    {
        if(interpolation >= 1)
        {
            go_dowm = true;
            go_up = false;
            interpolation -= 1 * Time.deltaTime;


        }
        else if(interpolation <= 0)
        {
            go_up = true;
            go_dowm = false;
            interpolation += 1 * Time.deltaTime;

        }
        else
        {
            if (go_up)
            {
                interpolation += 1 * Time.deltaTime;
            }
            else
            {
                interpolation -= 1 * Time.deltaTime;
            }
        }

        transform.position = new Vector3(transform.position.x,Mathf.Lerp(min_position_value
            ,max_position_value , interpolation), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(player.thrownknifecounter != 0)
            {
                gameObject.SetActive(false);
                player.thrownknifecounter -= 1;
            }
        }
    }
}
