using UnityEngine;

public class player_gethit_state : BaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.cangethit = false;
        player.isgethit = true;
        player.player_health--;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.player_health != 0)
        {
            if (player.cangethit)
            {
                if (player.grounded)
                {
                    player.SwitchState(player.standingstate);
                }
                else
                {
                    player.playerbody.velocity = new Vector2(player.playerbody.velocity.x, -5);
                }
            }
            else
            {
                if (player.grounded)
                {
                    player.playerbody.velocity = new Vector2(0, 0);
                }
                else
                {
                    player.playerbody.velocity = new Vector2(player.playerbody.velocity.x, -5);
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
        if(player.player_health != 0)
        {
            player.playeranim.Play("gettinghit_c");
            player.isdead = false;
        }
        else
        {
            player.isdead = true;
            player.playeranim.Play("death_c");
            player.playerbody.gravityScale = 0;
            player.playerbody.velocity = Vector2.zero;
            player.try_again.gameObject.SetActive(true);
        }
    }
}
