using UnityEngine;

public class enemy_gethit_state : EnemyBaseState
{

    public float animend;

    public override void EnterState(EnemyStateManager enemy)
    {
        animend = 0.35f;
        enemy.isgethit = true;
        enemy.isalerted = true;
        enemy.health--;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.enemybody.velocity = new Vector2(0,0);
    }

    public override void OncollisionEnter(EnemyStateManager enemy, Collision2D collision)
    {
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {
    }

    public override void PlayAnimation(EnemyStateManager enemy)
    {
        if(enemy.health > 0)
        {
            enemy.isdead = false;
            enemy.enemyanim.Play("gethit");
        }
        else
        {
            enemy.isdead = true;
            enemy.enemyanim.Play("death");
        }
    }
}