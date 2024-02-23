using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    BaseState CurrentState;

    public Standing_State standingstate = new Standing_State();
    public player_walking_state walkingstate = new player_walking_state();
    public player_running_state runningstate = new player_running_state();
    public player_hitting_state hittingstate = new player_hitting_state();
    public player_gethit_state gettinghitstate = new player_gethit_state();
    public player_jump_state jumpstate = new player_jump_state();
    public Player_throwing_state throwstate = new Player_throwing_state();


    public Summoning[] summoningScript;
    public GameObject[] summon;

    public Transform throwingpoint;
    public float throwingspeed;
    public bool activeCDfordissapearknife;
    public float CDfordissapearknife;
    public int indexofknives;
    public int thrownknifecounter;
    public bool activetimer;


    [Header("Buraya camera objesi gelecek")]
    public CameraStateManager cameraState;

    [Header("Buraya knife objesi gelecek")]
    public knife[] knifeScript;

    [Header("Buraya try_again_button scripti gelcek")]
    public Try_again_button try_again;

    [Header("ses efektlerini buraya koy")]
    public AudioClip[] playerclip;

    [Header("Audio Source objesi gelecek")]
    public AudioSource playeraudio;


    public Rigidbody2D playerbody;
    public Animator playeranim;
    public SpriteRenderer playersprite;


    public LevelLoader _levelLoader;



    // bekleme süreleri karakterin durum kod dizilmlerinde yazýldýðýnda , durumlar arasý geçiþ yaþandýðý sýrada yani kod dizilimleri arasýnda geçiþ yaþandýðýnda cooldown dolum süresi...
    //yarýda kaldýðý için cooldown parametrelerini(float) sürekli çalýþmakta olan durum yönetimi(PlayerStateManager) kod dizilimi içerisinde bulundurmaktayýz.
    public float cooldownforhitting = 0;


    public bool startCDforthrowing;
    public bool cangethit;
    public bool gothit;
    public bool flipflop;
    public bool flipflop2;
    public bool grounded;

    public float flashTimer;
    public float phasecounter;
    public float Invulnerabilitytime ;
    public int chaningcolorcounter;


    public int player_health;
    public bool isgethit;
    public bool isdead;



    private void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
        playeranim = GetComponent<Animator>();
        playersprite = GetComponent<SpriteRenderer>();
        playeraudio = GetComponent<AudioSource>();

        CurrentState = standingstate;

        CurrentState.EnterState(this);

        throwingspeed = 20;
        player_health = 5;
        Physics2D.IgnoreLayerCollision(3, 6, false);
        Physics2D.IgnoreLayerCollision(3, 8, false);

    }



    private void Update()
    {
        PlayAnimation();
        CurrentState.UpdateState(this);

        if (_levelLoader.CurrentScene == 11)
        {
            if (!summoningScript[cameraState.i].isstart)
            {
                transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -10, 250), transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, summon[cameraState.i].transform.position.x - 20, summon[cameraState.i].transform.position.x + 20), transform.localPosition.y, transform.localPosition.z);

            }
        }
        else
        {
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -10, 250), transform.localPosition.y, transform.localPosition.z);
        }


        //------------------------------------------------
        if (CurrentState == hittingstate || cooldownforhitting != 0)
        {
            if (cooldownforhitting <= 1)
            {
                cooldownforhitting += Time.deltaTime;
            }
        }

        //------------------------------------------------

        if (!cangethit)
        {
            Invoke("cangethitcd", 0.3f);
        }

        if (gothit)
        {
            Invulnerability();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentState.OnCollisionEnter(this, collision);

        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            playerbody.gravityScale = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CurrentState.OnTriggerEnter(this, collision);

        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 8)
        {
            gothit = true;
            flipflop = true;
            flipflop2 = true;
            flashTimer = 0;
            phasecounter = 0;
        }

        if (collision.gameObject.tag == "claw" || collision.gameObject.tag == "stick")
        {
            SwitchState(gettinghitstate);
        }

        if(collision.gameObject.tag == "Collectible_knife")
        {

            for (int i = 0; i < knifeScript.Length; i++)
            {
                if (knifeScript[i].gameObject.activeInHierarchy && knifeScript[i].isinair == false)
                {
                    knifeScript[i].gameObject.SetActive(false);
                    break;
                }
            }
        }
    }

    public void PlayAnimation()
    {
        
        if (playeranim != null)
        {
            CurrentState.PlayAnimation(this);
        }
    }

    public void SwitchState(BaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    private void cangethitcd()
    {
        cangethit = true;
    }

    private void Invulnerability()
    {

        if (flipflop)
        {
            Physics2D.IgnoreLayerCollision(3, 6, true);
            Physics2D.IgnoreLayerCollision(3, 8, true);
            if (flashTimer >= Invulnerabilitytime)
            {
                flipflop = false;
            }
            else
            {
                flashTimer += Time.deltaTime;
                if(phasecounter <= Invulnerabilitytime/chaningcolorcounter)
                {
                    phasecounter += Time.deltaTime;
                    if (flipflop2)
                    {
                        playersprite.color = new Color(1, 0, 0, 0.5f);
                    }
                    else
                    {
                        playersprite.color = Color.white;
                    }
                }
                else
                {
                    phasecounter = 0;
                    if (flipflop2)
                    {
                        flipflop2 = false;
                    }
                    else
                    {
                        flipflop2 = true;
                    }
                }
            }
        }
        else
        {
            Physics2D.IgnoreLayerCollision(3, 6, false);
            Physics2D.IgnoreLayerCollision(3, 8, false);
            playersprite.color = Color.white;
            gothit = false;
        }
    }

    private void bactodefaultstate()
    {
        CurrentState = standingstate;
        for (int i = 0; i < knifeScript.Length; i++)
        {
            if (!knifeScript[i].gameObject.activeInHierarchy)
            {
                knifeScript[i].gameObject.SetActive(true);
                knifeScript[i].isinair = true;
                knifeScript[i].transform.position = new Vector3(throwingpoint.transform.position.x, throwingpoint.transform.position.y, throwingpoint.transform.position.z);
                if(transform.localScale == new Vector3(-1, 1, 1))
                {
                    knifeScript[i].knifebody.velocity = new Vector2(-1 * throwingspeed, knifeScript[i].knifebody.velocity.y);
                }
                else
                {
                    knifeScript[i].knifebody.velocity = new Vector2(throwingspeed, knifeScript[i].knifebody.velocity.y);
                }
                if(thrownknifecounter != 5)
                {
                    thrownknifecounter += 1;
                }
                break;
            }
        }
        CDfordissapearknife = 1.5f;
    }

    private void death()
    {
        this.gameObject.SetActive(false);
    }


    private void startaudio()
    {
        if(CurrentState == walkingstate || CurrentState == runningstate)
        {
            if (_levelLoader.CurrentScene == 3 || _levelLoader.CurrentScene == 4 ||_levelLoader.CurrentScene == 5)
            {
                playeraudio.PlayOneShot(playerclip[0]);
            }
            else
            {
                playeraudio.PlayOneShot(playerclip[4]);
            }
        }
        else if(CurrentState == hittingstate || CurrentState == throwstate)
        {
            playeraudio.PlayOneShot(playerclip[1]);
        }
        else if(CurrentState == gettinghitstate)
        {
            if(isdead == false)
            {
                playeraudio.PlayOneShot(playerclip[2]);
            }
            else
            {
                playeraudio.PlayOneShot(playerclip[3]);
            }
        }
    }
}
