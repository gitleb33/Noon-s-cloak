using UnityEngine;

public class Standing_State : BaseState
{

    private float _horizontalInput;
    public override void EnterState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {


        _horizontalInput = Input.GetAxis("Horizontal");

        if(_horizontalInput != 0 && Input.GetKey(KeyCode.Z))
        {
            player.SwitchState(player.runningstate);
        }
        else if (_horizontalInput != 0)
        {
            player.SwitchState(player.walkingstate);
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
      player.playeranim.Play("stand_c");
    }
}
