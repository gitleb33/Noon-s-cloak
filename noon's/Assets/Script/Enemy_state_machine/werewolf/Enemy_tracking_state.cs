using UnityEngine;

public class Enemy_tracking_state : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.isalerted = true;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

        if (enemy.transform.localScale.x < 0)
        {
            enemy.direction = Vector2.left;
            enemy.direction2 = Vector2.right;
        }
        else if (enemy.transform.localScale.x > 0)
        {
            enemy.direction = Vector2.right;
            enemy.direction2 = Vector2.left;
        }

        if (!enemy.enemyradar)
        {
            if (enemy.randomnum < 0 || enemy.randomnum > 0)
            {
                enemy.SwitchState(enemy.walkingstate);
            }
            else
            {
                enemy.SwitchState(enemy.standingstate);
            }
        }
        else
        {
            if (!enemy.range)
            {

                if (enemy.player.transform.localPosition.x < enemy.transform.localPosition.x)
                {
                    enemy.enemybody.velocity = new Vector2(-1 * enemy.speed, enemy.enemybody.velocity.y);
                    enemy.transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (enemy.player.transform.localPosition.x > enemy.transform.localPosition.x)
                {
                    enemy.enemybody.velocity = new Vector2(1 * enemy.speed, enemy.enemybody.velocity.y);
                    enemy.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                if (!enemy.isactive_enemyattackcd)
                {
                    enemy.SwitchState(enemy.hittingstate);
                }
            }
        }
    }

    public override void OncollisionEnter(EnemyStateManager enemy, Collision2D collision)
    {
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {
    }

    public override void PlayAnimation(EnemyStateManager enemy)
    {
        enemy.enemyanim.Play("walk");
    }
}
