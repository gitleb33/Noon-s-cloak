using UnityEngine;

public class fall_damage : MonoBehaviour
{
    public PlayerStateManager player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.player_health = 1;
            player.SwitchState(player.gettinghitstate);
        }
    }
}
