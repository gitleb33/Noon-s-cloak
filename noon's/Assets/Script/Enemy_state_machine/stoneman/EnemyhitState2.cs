using UnityEngine;

public class EnemyhitState2 : EnemyBaseState2
{

    public override void EnterState(EnemyStateManager2 enemy2)
    {

    }

    public override void UpdateState(EnemyStateManager2 enemy2)
    {
        if (!enemy2.enemyRange)
        {
            if (!enemy2.canhit)
            {
                enemy2.SwitchState(enemy2.standingState2);
            }
        }
        else
        {
          enemy2.enemybody2.velocity = new Vector2(0,0);
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
        if (enemy2.canhit)
        {
            if(enemy2.animationtime < 0.5f)
            {
                enemy2.animationtime += Time.deltaTime;
                enemy2.enemyanim2.Play("hit");
            }
            else
            {
                enemy2.didhit = true;
                enemy2.canhit = false;
                enemy2.animationtime = 0;
            }
        }
        else
        {
            enemy2.enemyanim2.Play("stand");
        }
    }
}