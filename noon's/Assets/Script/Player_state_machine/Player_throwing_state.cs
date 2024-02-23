using UnityEngine;

public class Player_throwing_state : BaseState
{
    public override void EnterState(PlayerStateManager player)
    {
    }

    public override void UpdateState(PlayerStateManager player)
    { 
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision2D collision)
    {
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider2D collision)
    {
    }

    public override void PlayAnimation(PlayerStateManager player)
    {
        player.playeranim.Play("throwing_c");
        player.playerbody.velocity = Vector2.zero;
    }
}
