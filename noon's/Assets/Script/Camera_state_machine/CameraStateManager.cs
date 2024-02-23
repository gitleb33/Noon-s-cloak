using UnityEngine;

public class CameraStateManager : MonoBehaviour
{
    CameraBaseState CurrentState;

    public Player_Following_State player_Following_State = new Player_Following_State();
    public Bosscutscene boss_state = new Bosscutscene();
   
    [Header("Buraya levelloader objesi gelecek")]
    public LevelLoader _levelLoader;


    [Header("Buraya player objesi konulcak.")]
    public Transform playerTransform;
    public float aheadDistance;
    public float cameraSpeed;
    public float lookAhead;


    public Summoning[] summoningScript;
    public GameObject[] summon;


    public bool dis_enab_cutscene;

    public int i = 0;


    private void Start()
    {
        CurrentState = player_Following_State;

        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void switchState(CameraBaseState _newState)   
    {
        CurrentState = _newState;

        CurrentState.EnterState(this);
    }
}
