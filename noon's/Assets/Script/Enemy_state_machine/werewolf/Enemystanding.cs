using UnityEngine;

public class Enemystanding : EnemyBaseState
{


    public override void EnterState(EnemyStateManager enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        
        if(enemy.transform.localScale.x < 0)
        {
            enemy.direction = Vector2.left;
        }
        else if (enemy.transform.localScale.x > 0)
        {
            enemy.direction = Vector2.right;
        }

        if (enemy.enemyradar && enemy.health != 0)
        {
            enemy.SwitchState(enemy.trackingstate);
        }


        if (enemy.randomcd <= 0)
        {
            enemy.randomnum = Random.Range(-1, 2);
            enemy.stopmove = false;
            enemy.stoprandom = true;
        }


        if(enemy.randomnum < 0)
        {
            enemy.SwitchState(enemy.walkingstate);
        }
        else if(enemy.randomnum > 0)
        {
            enemy.SwitchState(enemy.walkingstate);
        }
        else
        {
            enemy.enemybody.velocity = new Vector2(0, 0);

            if(enemy.movetime >=2)
            {
                enemy.stopmove = true;
                enemy.stoprandom = false;
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
        enemy.enemyanim.Play("stand");
    }
}