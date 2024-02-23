using UnityEngine;
using UnityEngine.Audio;

public class EnemyStateManager : MonoBehaviour
{

    public PlayerStateManager player;

    EnemyBaseState CurrentState;
    public Enemystanding standingstate = new Enemystanding();
    public enemy_walking_state walkingstate = new enemy_walking_state();
    public Enemy_hitting_state hittingstate = new Enemy_hitting_state();
    public Enemy_tracking_state trackingstate = new Enemy_tracking_state();
    public enemy_gethit_state gethitstate = new enemy_gethit_state();

    public Animator enemyanim;
    public Rigidbody2D enemybody;

    //AI ATTACKING TRIGGER
    public LayerMask playerLayer;
    public Vector2 direction;
    public Vector2 direction2;

    //AI SIGHT
    public Collider2D enemyradar;
    public float distance ;

    //AI ATTACK 
    public RaycastHit2D range;
    public float rangedistance;
    public float enemyattackcd = 0.5f;
    public bool isactive_enemyattackcd;
    public bool isalerted;
    public float alertedcdtimer = 5;

    //AI WALKING
    public bool stoprandom = false;
    public bool stopmove = true;
    public float speed = 3.5f;
    public int randomnum;
    public float randomcd = 3;
    public float movetime = 0;

    public bool cangethit;
    public bool isgethit;
    public int health;

    public bool isdead;

    public AudioSource enemyaudio;
    public AudioClip[] enemyclip;

    private void Start()
    {
        enemyanim = GetComponent<Animator>();
        enemybody = GetComponent<Rigidbody2D>();
        enemyaudio = GetComponent<AudioSource>();

        health = 3;
        CurrentState = standingstate;

        CurrentState.EnterState(this);
    }
    private void Update()
    {
        Audio();
        PlayAnimation();
        CurrentState.UpdateState(this);

        if (isalerted)
        {
            enemyradar = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 20, playerLayer);
            alertedcdtimer = 5;

        }
        else
        {
            enemyradar = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 7.5f, playerLayer);
        }

        range = Physics2D.Raycast(transform.localPosition, direction, rangedistance, playerLayer);

        if (!enemyradar)
        {
            if (alertedcdtimer > 0)
            {
                alertedcdtimer -= Time.deltaTime;
            }
            else
            {
                isalerted = false;
            }
            if (!stoprandom)
            {
                randomcd -= Time.deltaTime;
            }
            else
            {
                randomcd -= 0;
                randomcd = 3;
            }

            if (!stopmove)
            {
                movetime += Time.deltaTime;
            }
            else
            {
                movetime = 0;
            }
        }


        if (isactive_enemyattackcd)
        {
            if (enemyattackcd > 0)
            {
                enemyattackcd -= Time.deltaTime;
            }
            else
            {
                if(CurrentState != gethitstate)
                {
                    CurrentState = standingstate;
                }
                enemyattackcd = 0.5f;
                isactive_enemyattackcd = false;
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

        if (collision.gameObject.tag == "sword" || collision.gameObject.tag == "knife")
        {
           SwitchState(gethitstate);
        }
    }


    public void SwitchState(EnemyBaseState State)
    {
        CurrentState = State;
        State.EnterState(this);
    }


    private void PlayAnimation()
    {
        if (enemyanim != null)
        {
            CurrentState.PlayAnimation(this);
        }
    }

    public void death()
    {
        this.gameObject.SetActive(false);
    }

    public void backtodefaultstate()
    {
        if(CurrentState == hittingstate)
        {
            isactive_enemyattackcd = true;
        }
        else 
        {
            CurrentState = standingstate;
        }
    }

    public void Audio() 
    {
        if ((transform.position.x - player.transform.position.x) > 15)
        {
            enemyaudio.mute = true;
        }
        else
        {
            enemyaudio.mute = false;
        }
    }

    public void startaudio()
    {
        if(CurrentState == walkingstate || CurrentState == trackingstate)
        {
            enemyaudio.PlayOneShot(enemyclip[0]);
        }
        else if (CurrentState == hittingstate)
        {
            enemyaudio.PlayOneShot(enemyclip[1]);
        }
        else if (CurrentState == gethitstate) 
        {
            if(isdead == false)
            {
                enemyaudio.PlayOneShot(enemyclip[2]);
                enemyaudio.clip = enemyclip[3];
                enemyaudio.Play();
            }
            else
            {
                enemyaudio.PlayOneShot(enemyclip[4]);
            }
        }
    }
}