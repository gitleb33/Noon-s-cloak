using UnityEngine;

public class player_jump_state : BaseState
{
    private float speed_x;
    private float speed_y;
    private float _horizontalInput;
    public override void EnterState(PlayerStateManager player)
    {
        speed_x = 10;
        speed_y = 10;
        player.grounded = false;
        player.playerbody.gravityScale = 0.125f;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (!player.grounded)
        {
            speed_y -= player.playerbody.gravityScale;
            player.playerbody.velocity = new Vector2(_horizontalInput * speed_x, speed_y);
            if (_horizontalInput > 0)
            {
                player.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (_horizontalInput < 0)
            {
                player.transform.localScale = new Vector3(-1, 1, 1);
            }

            //-----------------------------------------------

            if(player.playerbody.velocity.y < 0)
            {
                player.playerbody.gravityScale = 0.25f;
            }

        }
        else
        {
            player.playerbody.velocity = new Vector2(0, 0);
            player.SwitchState(player.standingstate);
            player.playerbody.gravityScale = 2;
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
        player.playeranim.Play("jump_c");
    }
}