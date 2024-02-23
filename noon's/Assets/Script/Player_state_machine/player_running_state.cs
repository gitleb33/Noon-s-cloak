using UnityEngine;

public class player_running_state : BaseState
{
    private int speed;
    private float _horizontalInput;
    public override void EnterState(PlayerStateManager player)
    {
        speed = 10;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        _horizontalInput = Input.GetAxis("Horizontal");


        if (!(Input.GetKey(KeyCode.Z)) && _horizontalInput == 0)
        {
            player.SwitchState(player.standingstate);
        }
        else if (!(Input.GetKey(KeyCode.Z)))
        {
            player.SwitchState(player.walkingstate);
        }



        player.playerbody.velocity = new Vector2(_horizontalInput * speed, player.playerbody.velocity.y);


        if (_horizontalInput > 0)
        {
            player.transform.localScale = new Vector3(1,1,1);
        }
        else if(_horizontalInput < 0)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
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
        player.playeranim.Play("run_c");
    }
}
