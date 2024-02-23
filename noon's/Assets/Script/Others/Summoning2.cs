using UnityEngine;

public class Summoning2 : MonoBehaviour
{
    [SerializeField]private PlayerStateManager player;
    [SerializeField]private CameraStateManager camera;

    [SerializeField]private GameObject boss;


    private Animator summanim2;
    private bool stopsign;
    private float animend;
   
    
    private void Start()
    {
        summanim2 = GetComponent<Animator>();
    }

    private void Update()
    {
        if(stopsign == true)
        {
            player.playerbody.velocity = Vector2.zero;
            player.SwitchState(player.standingstate);
        }


        if (camera.transform.localPosition.x >= 113)
        {
            if(animend < 2)
            {
                animend += Time.deltaTime;
                summanim2.Play("summoning2");
            }
            else
            {
                camera.dis_enab_cutscene = false;
                stopsign = false;
                boss.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            camera.switchState(camera.boss_state);
            stopsign = true;
        }
    }
}
