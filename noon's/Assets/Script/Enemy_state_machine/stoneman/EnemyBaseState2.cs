using UnityEngine;

public abstract class EnemyBaseState2
{
    public abstract void EnterState(EnemyStateManager2 enemy2);

    public abstract void UpdateState(EnemyStateManager2 enemy2);

    public abstract void OncollisionEnter(EnemyStateManager2 enemy2, Collision2D collision);

    public abstract void OnTriggerEnter(EnemyStateManager2 enemy2, Collider2D collision);

    public abstract void PlayAnimation(EnemyStateManager2 enemy2);
}
