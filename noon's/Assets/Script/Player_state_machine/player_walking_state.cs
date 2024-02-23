using UnityEngine;

public class player_walking_state : BaseState
{
    private int speed;
    private float _horizontalInput;
    public override void EnterState(PlayerStateManager player)
    {
        speed = 5;
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        player.playerbody.velocity = new Vector2(speed * _horizontalInput, player.playerbody.velocity.y);


        if (_horizontalInput > 0)
        {
            player.transform.localScale = new Vector3(1,1,1);
        }
        else if (_horizontalInput < 0)
        {
            player.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            player.SwitchState(player.standingstate);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            player.SwitchState(player.runningstate);
        }

        if (Input.GetKey(KeyCode.X))
        {
            player.SwitchState(player.hittingstate);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            player.SwitchState(player.jumpstate);
        }

        if (Input.GetKey(KeyCode.C) && player.thrownknifecounter != 5)
        {
            player.SwitchState(player.throwstate);
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
        player.playeranim.Play("walking_c");
    }
}
