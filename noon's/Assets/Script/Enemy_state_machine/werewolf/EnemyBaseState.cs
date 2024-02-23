using UnityEngine;

public abstract class EnemyBaseState 
{
    public abstract void EnterState(EnemyStateManager enemy);

    public abstract void UpdateState(EnemyStateManager enemy);

    public abstract void OncollisionEnter(EnemyStateManager enemy, Collision2D collision);

    public abstract void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision);

    public abstract void PlayAnimation(EnemyStateManager enemy);
}
