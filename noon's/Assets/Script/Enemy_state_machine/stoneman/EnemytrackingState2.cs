using UnityEngine;

public class EnemytrackingState2 : EnemyBaseState2
{
    public override void EnterState(EnemyStateManager2 enemy2)
    {
    }

    public override void UpdateState(EnemyStateManager2 enemy2)
    {
        if (!enemy2.enemyradar || !enemy2.tracking_flipflop)
        {
            if(enemy2.randomNum != 0)
            {
                enemy2.SwitchState(enemy2.walkingState2);
            }
            else
            {
                enemy2.SwitchState(enemy2.standingState2);
            }
        }
        else
        {
            if (!enemy2.enemyRange)
            {
                if (enemy2.playerTransform.localPosition.x < enemy2.transform.localPosition.x)
                {
                    enemy2.enemybody2.velocity = new Vector2(-1 * enemy2.walkspeed, enemy2.enemybody2.velocity.y);
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
                    enemy2.enemybody2.velocity = new Vector2(1 * enemy2.walkspeed, enemy2.enemybody2.velocity.y);
                    if (enemy2.direction)
                    {
                        enemy2.transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        enemy2.transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            else
            {
                enemy2.SwitchState(enemy2.hitState2);
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
