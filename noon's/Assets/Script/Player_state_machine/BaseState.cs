using UnityEngine;

public abstract class BaseState
{

    public abstract void EnterState(PlayerStateManager player);

    public abstract void UpdateState(PlayerStateManager player);

    public abstract void OnCollisionEnter(PlayerStateManager player, Collision2D collision);

    public abstract void OnTriggerEnter(PlayerStateManager player, Collider2D collision);

    public abstract void PlayAnimation(PlayerStateManager player);
}
