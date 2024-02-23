using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider health_value;
    public PlayerStateManager player;
    public EnemyStateManager enemy;
    public EnemyStateManager2 enemy2;
    private float bar_length;
    private int health;
    private float bar_start_point;

    private void Awake()
    {
        health_value = GetComponent<Slider>();

        if (gameObject.tag == "enemy" || gameObject.tag == "stoneman" || gameObject.tag == "shadow" || gameObject.tag == "Boss")
        {
            bar_length = transform.Find("healtvalue").localScale.x;
            if (gameObject.tag == "enemy")
            {
                health = 3;
                bar_start_point = 0.5f;
            }
            else if( gameObject.tag == "shadow")
            {
                health = 4;
                bar_start_point = 0.35f;
            }
            else if(gameObject.tag == "stoneman")
            {
                health = 5;
                bar_start_point = 0.25f;
            }
            else if(gameObject.tag == "Boss")
            {
                health = 20;
                bar_start_point = 0.0625f;
            }
        }
    }

    private void Update()
    {
        if(gameObject.tag != "enemy" && gameObject.tag != "stoneman" && gameObject.tag != "shadow" && gameObject.tag != "Boss")
        {
            if (player.isgethit)
            {
                if(player.player_health != 0)
                {
                    health_value.value -= 0.2f;
                }
                else
                {
                    health_value.value = 0;
                }
                player.isgethit = false;
            }
        }
        else if(gameObject.tag == "enemy" || gameObject.tag == "stoneman" || gameObject.tag == "shadow" || gameObject.tag == "Boss")
        {
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 3, transform.parent.position.z);
            transform.localScale = new Vector3(transform.parent.localScale.x, transform.parent.localScale.y, transform.parent.localScale.z);

            if(gameObject.tag == "enemy")
            {
                if (enemy.isgethit)
                {
                    enemy.isgethit = false;
                    transform.Find("healtvalue").localScale = new Vector3(transform.Find("healtvalue").localScale.x - (bar_length / health),
                        transform.Find("healtvalue").localScale.y, transform.Find("healtvalue").localScale.z);

                    transform.Find("healtvalue").position = new Vector3(transform.Find("healtvalue").position.x - bar_start_point,
                        transform.Find("healtvalue").position.y, transform.Find("healtvalue").position.z);
                }
            }
            else if(gameObject.tag == "stoneman" || gameObject.tag == "shadow" || gameObject.tag == "Boss")
            {
                if (enemy2.isgethit)
                {
                    enemy2.isgethit = false;
                    transform.Find("healtvalue").localScale = new Vector3(transform.Find("healtvalue").localScale.x - (bar_length / health),
                        transform.Find("healtvalue").localScale.y, transform.Find("healtvalue").localScale.z);

                    transform.Find("healtvalue").position = new Vector3(transform.Find("healtvalue").position.x - bar_start_point,
                        transform.Find("healtvalue").position.y, transform.Find("healtvalue").position.z);
                    if (enemy2.isdead)
                    {
                        transform.Find("healtvalue").localScale = new Vector3(bar_length, transform.Find("healtvalue").localScale.y, transform.Find("healtvalue").localScale.z);
                        transform.Find("healtvalue").localPosition = new Vector3(0.41f,-0.3f,0);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}