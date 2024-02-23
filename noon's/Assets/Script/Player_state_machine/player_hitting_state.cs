using UnityEngine;

public class player_hitting_state : BaseState
{
    private bool canhit = true;
    private float _horizontalInput;
    public override void EnterState(PlayerStateManager player)
    {
    }

    public override void UpdateState(PlayerStateManager player)
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        if (!canhit)
        {
            if(player.cooldownforhitting >= 1)
            {
                canhit = true;
                player.cooldownforhitting = 0;
            }
            else if (player.cooldownforhitting >= 0.5f)
            {
                if (_horizontalInput == 0)
                {
                    player.SwitchState(player.standingstate);
                }
                else if(_horizontalInput != 0)
                {
                    player.SwitchState(player.walkingstate);
                }
            }
        }
        
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision2D collision)
    {
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider2D collision)
    {

    }

    public override void PlayAnimation(PlayerStateManager player)
    {
        if (canhit)
        {
            player.playeranim.Play("hitting_c");
            player.playerbody.velocity = new Vector2(0, 0);
            canhit = false;
        }

    }
}
