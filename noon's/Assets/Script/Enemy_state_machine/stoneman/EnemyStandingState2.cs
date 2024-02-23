using UnityEngine;

public class EnemyStandingState2 : EnemyBaseState2
{
    private bool flipflop;
    public override void EnterState(EnemyStateManager2 enemy2)
    {
        flipflop = true;
        enemy2.randomNum = 0;
    }

    public override void UpdateState(EnemyStateManager2 enemy2)
    {
        if(enemy2.randomtimer <= 2)
        {
            enemy2.randomtimer += Time.deltaTime;
            enemy2.enemybody2.velocity = new Vector2(0, 0);
        }
        else if (flipflop)
        {
            enemy2.randomNum = Random.Range(-1, 2);
            enemy2.moveTime = 0;
            flipflop = false;
        }

        if(enemy2.randomNum > 0)
        {
            enemy2.SwitchState(enemy2.walkingState2);
            if (enemy2.direction)
            {
                enemy2.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                enemy2.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if(enemy2.randomNum < 0)
        {
            enemy2.SwitchState(enemy2.walkingState2);
            if (enemy2.direction)
            {
                enemy2.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                enemy2.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if(enemy2.moveTime <= 2)
            {
                enemy2.moveTime += Time.deltaTime;
            }
            else if (!flipflop)
            {
                enemy2.randomtimer = 0;
                flipflop = true;
            }
        }

        if (enemy2.tracking_flipflop)
        {
            if (enemy2.enemyradar)
            {
                enemy2.SwitchState(enemy2.trackingState2);
            }
        }

    }

    public override void OncollisionEnter(EnemyStateManager2 enemy2, Collision2D collision)
    {
    }

    public override void OnTriggerEnter(EnemyStateManager2 enemy2, Collider2D collision)
    {
    }

    public override void PlayAnimation(EnemyStateManager2 enemy2)
    {
        enemy2.enemyanim2.Play("stand");
    }
}