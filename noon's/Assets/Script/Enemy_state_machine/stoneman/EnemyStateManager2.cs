using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStateManager2 : MonoBehaviour
{
    EnemyBaseState2 CurrentState;

    public EnemyStandingState2 standingState2 = new EnemyStandingState2();
    public EnemywalkingState2 walkingState2 = new EnemywalkingState2();
    public EnemytrackingState2 trackingState2 = new EnemytrackingState2();
    public EnemygethitState2 gethitState2 = new EnemygethitState2();
    public EnemyhitState2 hitState2 = new EnemyhitState2();

    public GameObject[] stones;



    public bool tracking_flipflop;

    public bool first_clamp;
    public bool second_clamp;
    public bool third_clamp;
    public bool forth_clamp;
    public bool fifth_clamp;


    public Rigidbody2D enemybody2;
    public Animator enemyanim2;

    public int walkspeed;
    public bool direction;

    public int randomNum;
    public float randomtimer;
    public float moveTime;
    public float attackCD;
    
    public bool canhit;
    public bool didhit = false;
    public float animationtime = 0;
    public float animationtime2 = 0;


    public Collider2D enemyradar;
    public Collider2D enemyRange;
    public LayerMask playerLayer;
    public Transform playerTransform;

    public int health;
    public bool isgethit;
    public bool isdead;

    public LevelLoader level;
    public Healthbar healthbar;

    public AudioSource enemy2Audio;
    public AudioClip[] enemy2Clip;

    private void Start()
    {
        enemybody2 = GetComponent<Rigidbody2D>();
        enemyanim2 = GetComponent<Animator>();
        enemy2Audio = GetComponent<AudioSource>();
        if(this.gameObject.tag == "Boss")
        {
            health = 20;
            walkspeed = 12;
            direction = true;
        }
        else if(this.gameObject.tag == "shadow")
        {
            health = 4;
            walkspeed = 4;
            direction = false;
        }
        else
        {
            health = 5;
            walkspeed = 5;
            direction = false;
        }

        if(this.gameObject.tag == "stoneman")
        {
            tracking_flipflop = false;
        }
        else
        {
            tracking_flipflop = true;
        }

        CurrentState = standingState2;
        CurrentState.EnterState(this);
    }

    private void Update()
    {
        PlayAnimation();
        CurrentState.UpdateState(this);

        if (this.gameObject.tag == "Boss")
        {
            enemyradar = Physics2D.OverlapCircle(transform.localPosition, 100, playerLayer);
            enemyRange = Physics2D.OverlapCircle(transform.localPosition, 2.5f, playerLayer);
        }
        else
        {
            enemyradar = Physics2D.OverlapCircle(transform.localPosition, 50, playerLayer);
            enemyRange = Physics2D.OverlapCircle(transform.localPosition, 2.5f, playerLayer);
        }

        if(attackCD < 1)
        {
            attackCD += Time.deltaTime;
        }
        else
        {
            if (!didhit)
            {
                canhit = true;
            }
        }

        if (didhit && attackCD >= 1)
        {
            attackCD = 0;
            didhit = false;
        }

        if(this.gameObject.tag == "stoneman")
        {
            if(level.CurrentScene == 7)
            {
                if (transform.position.x > stones[0].transform.position.x && transform.position.x < stones[1].transform.position.x)
                {
                    first_clamp = true;
                    if (playerTransform.position.x > stones[0].transform.position.x && playerTransform.position.x < stones[1].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
                else if (transform.position.x > stones[1].transform.position.x && transform.position.x < stones[2].transform.position.x)
                {
                    second_clamp = true;
                    if (playerTransform.position.x > stones[1].transform.position.x && playerTransform.position.x < stones[2].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
                else if (transform.position.x > stones[2].transform.position.x && transform.position.x < stones[3].transform.position.x)
                {
                    third_clamp = true;
                    if (playerTransform.position.x > stones[2].transform.position.x && playerTransform.position.x < stones[3].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
            }
            else if(level.CurrentScene == 8 || level.CurrentScene == 9)
            {
                if (transform.position.x > stones[0].transform.position.x && transform.position.x < stones[1].transform.position.x)
                {
                    first_clamp = true;
                    if (playerTransform.position.x > stones[0].transform.position.x && playerTransform.position.x < stones[1].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
                else if (transform.position.x > stones[1].transform.position.x && transform.position.x < stones[2].transform.position.x)
                {
                    second_clamp = true;
                    if (playerTransform.position.x > stones[1].transform.position.x && playerTransform.position.x < stones[2].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
                else if (transform.position.x > stones[2].transform.position.x && transform.position.x < stones[3].transform.position.x)
                {
                    third_clamp = true;
                    if (playerTransform.position.x > stones[2].transform.position.x && playerTransform.position.x < stones[3].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
                else if (transform.position.x > stones[4].transform.position.x && transform.position.x < stones[5].transform.position.x)
                {
                    forth_clamp = true;
                    if (playerTransform.position.x > stones[4].transform.position.x && playerTransform.position.x < stones[5].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
                else if (transform.position.x > stones[6].transform.position.x && transform.position.x < stones[7].transform.position.x)
                {
                    fifth_clamp = true;
                    if (playerTransform.position.x > stones[6].transform.position.x && playerTransform.position.x < stones[7].transform.position.x)
                    {
                        tracking_flipflop = true;
                    }
                    else
                    {
                        tracking_flipflop = false;
                    }
                }
            }
           
            if (first_clamp)
            {
                if(level.CurrentScene == 7)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[0].transform.position.x + 2, stones[1].transform.position.x - 5), transform.position.y, transform.position.z);
                }
                else if(level.CurrentScene == 8 || level.CurrentScene == 9)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[0].transform.position.x + 1, stones[1].transform.position.x - 1), transform.position.y, transform.position.z);
                }
            }
            else if (second_clamp)
            {
                if(level.CurrentScene == 8)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[1].transform.position.x + 4, stones[2].transform.position.x - 3), transform.position.y, transform.position.z);
                }
                else if(level.CurrentScene == 9)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[1].transform.position.x + 1, stones[2].transform.position.x - 1), transform.position.y, transform.position.z);

                }
            }
            else if (third_clamp)
            {
                if(level.CurrentScene == 8)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[2].transform.position.x + 2, stones[3].transform.position.x - 1), transform.position.y, transform.position.z);
                }
                else if(level.CurrentScene == 9)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[2].transform.position.x + 1, stones[3].transform.position.x - 1), transform.position.y, transform.position.z);
                }
            }
            else if (forth_clamp)
            {
                if(level.CurrentScene == 8)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[4].transform.position.x + 1, stones[5].transform.position.x - 2), transform.position.y, transform.position.z);
                }
                else if(level.CurrentScene == 9)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[4].transform.position.x + 1, stones[5].transform.position.x - 1), transform.position.y, transform.position.z);
                }
            }
            else if (fifth_clamp)
            {
                if(level.CurrentScene == 8)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[6].transform.position.x + 1, stones[7].transform.position.x - 2), transform.position.y, transform.position.z);
                }
                else if(level.CurrentScene == 9)
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stones[6].transform.position.x + 1, stones[7].transform.position.x - 1), transform.position.y, transform.position.z);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentState.OncollisionEnter(this, collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CurrentState.OnTriggerEnter(this, collision);

        if(collision.gameObject.tag == "sword" || collision.gameObject.tag == "knife")
        {
            SwitchState(gethitState2);
        }
    }

    private void PlayAnimation()
    {
        if (enemyanim2 != null)
        {
            CurrentState.PlayAnimation(this);
        }
    }

    public void SwitchState(EnemyBaseState2 state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    private void death()
    {
        this.gameObject.SetActive(false);
        if( gameObject.tag == "shadow")
        {
            health = 4;
            isdead = false;
            isgethit = false;
            CurrentState = standingState2;
            healthbar.gameObject.SetActive(true);
        }
        else if (gameObject.tag == "stoneman" )
        {
            health = 5;
            isdead = false;
            healthbar.gameObject.SetActive(true);
        }
        else 
        {
            health = 20;
            SceneManager.LoadScene("Outro");
        }
    }

    public void startaudio()
    {
        if (gameObject.tag == "stoneman")
        {
            if((transform.position.x - playerTransform.position.x) < 15)
            {
                if (CurrentState == walkingState2 || CurrentState == trackingState2)
                {
                    enemy2Audio.PlayOneShot(enemy2Clip[0]);
                }
                else if (CurrentState == gethitState2)
                {
                    if (isdead == true)
                    {
                        enemy2Audio.PlayOneShot(enemy2Clip[2]);
                    }
                    else
                    {
                        enemy2Audio.PlayOneShot(enemy2Clip[1]);
                    }
                }
                else if (CurrentState == hitState2)
                {
                    enemy2Audio.PlayOneShot(enemy2Clip[3]);
                }
            }
        }
        else
        {
            if (CurrentState == walkingState2 || CurrentState == trackingState2)
            {
                enemy2Audio.PlayOneShot(enemy2Clip[0]);
                enemy2Audio.volume = 0.1f;
            }
            else if (CurrentState == hitState2)
            {
                enemy2Audio.PlayOneShot(enemy2Clip[1]);
                enemy2Audio.volume = 0.1f;
            }
            else if (CurrentState == gethitState2)
            {
                if (isdead == true)
                {
                    enemy2Audio.PlayOneShot(enemy2Clip[3]);
                    enemy2Audio.volume = 1;
                }
                else
                {
                    enemy2Audio.PlayOneShot(enemy2Clip[2]);
                    enemy2Audio.volume = 1;

                }
            }
        }
    }
}