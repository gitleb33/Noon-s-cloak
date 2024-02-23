using UnityEngine;

public class EnemygethitState2 : EnemyBaseState2
{
    public override void EnterState(EnemyStateManager2 enemy2)
    {
        enemy2.health--;
        enemy2.isgethit = true;
    }

    public override void UpdateState(EnemyStateManager2 enemy2)
    {
    }

    public override void OncollisionEnter(EnemyStateManager2 enemy2, Collision2D collision)
    {
    }

    public override void OnTriggerEnter(EnemyStateManager2 enemy2, Collider2D collision)
    {

    }

    public override void PlayAnimation(EnemyStateManager2 enemy2)
    {
        if(enemy2.health > 0)
        {
            if (enemy2.animationtime2 < 0.25f)
            {
                enemy2.animationtime2 += Time.deltaTime;
                enemy2.enemybody2.velocity = new Vector2(0, 0);
                enemy2.enemyanim2.Play("gethit");
            }
            else
            {
                enemy2.SwitchState(enemy2.standingState2);
                enemy2.animationtime2 = 0;
            }
        }
        else
        {
            enemy2.isdead = true;
            enemy2.enemyanim2.Play("death");
            enemy2.enemybody2.velocity = new Vector2(0,0);
        }

    }
}