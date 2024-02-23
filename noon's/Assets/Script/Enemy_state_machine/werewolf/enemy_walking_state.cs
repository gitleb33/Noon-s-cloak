using UnityEngine;

public class enemy_walking_state : EnemyBaseState
{

    public override void EnterState(EnemyStateManager enemy)
    {
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

        if (enemy.transform.localScale.x < 0)
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

        if (enemy.randomnum < 0)
        {
            enemy.enemybody.velocity = new Vector2(enemy.randomnum * enemy.speed, enemy.enemybody.velocity.y);
            enemy.transform.localScale = new Vector3(-1, 1, 1);
            if(enemy.movetime >= 2)
            {
                enemy.randomnum = 0;
                enemy.stoprandom = false;
            }
        }
        else if(enemy.randomnum > 0)
        {
            enemy.enemybody.velocity = new Vector2(enemy.randomnum * enemy.speed, enemy.enemybody.velocity.y);
            enemy.transform.localScale = new Vector3(1, 1, 1);
            if (enemy.movetime >= 2)
            {
                enemy.stoprandom = false;
                enemy.randomnum = 0;
            }
        }
        else
        {
            enemy.SwitchState(enemy.standingstate);
        }
    }

    public override void OncollisionEnter(EnemyStateManager enemy, Collision2D collision)
    {
        
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyboundry")
        {
            enemy.randomnum *= -1;
        }
    }

    public override void PlayAnimation(EnemyStateManager enemy)
    {
        enemy.enemyanim.Play("walk");
    }
}