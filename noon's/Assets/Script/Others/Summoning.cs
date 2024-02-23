using UnityEngine;

public class Summoning : MonoBehaviour
{
    private Animator sumanim;
    private float animend;
    private bool flipflop;


    public  GameObject[] enemies;
    public bool isstart;
    public bool isactive;


    public AudioSource sumAudio;
    public AudioClip sumClip;

    private void Start()
    {
        sumanim = GetComponent<Animator>();
        flipflop = true;
        isactive = false;
    }

    private void Update()
    {
        if (isstart)
        {
            if (animend <= 1.1)
            {
                animend += Time.deltaTime;
            }
            else
            {
                if (flipflop)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if (!enemies[i].activeInHierarchy)
                        {
                            enemies[i].SetActive(true);
                            enemies[i].transform.position = new Vector3(transform.position.x,-3.3f,transform.position.z);
                            isactive = true;
                            flipflop = false;
                            break;
                        }
                    }
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sumanim.Play("summoning");
            sumAudio.PlayOneShot(sumClip);
            isstart = true;
        }
    }
}
