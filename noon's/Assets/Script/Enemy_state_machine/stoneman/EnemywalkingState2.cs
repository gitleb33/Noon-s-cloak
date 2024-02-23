using UnityEngine;

public class EnemywalkingState2 : EnemyBaseState2
{

    public override void EnterState(EnemyStateManager2 enemy2)
    {
    }

    public override void UpdateState(EnemyStateManager2 enemy2)
    {
        if (enemy2.moveTime <= 2)
        {
            enemy2.enemybody2.velocity = new Vector2(enemy2.randomNum * enemy2.walkspeed , enemy2.enemybody2.velocity.y);
            enemy2.moveTime += Time.deltaTime;
        }
        else
        {
            enemy2.randomtimer = 0;
            enemy2.SwitchState(enemy2.standingState2);
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
        enemy2.enemyanim2.Play("walk");
    }
}
