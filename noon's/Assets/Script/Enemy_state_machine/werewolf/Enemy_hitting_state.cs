using UnityEngine;

public class Enemy_hitting_state : EnemyBaseState
{

    public override void EnterState(EnemyStateManager enemy)
    {
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
        enemy.enemyanim.Play("hit");
    }
}
