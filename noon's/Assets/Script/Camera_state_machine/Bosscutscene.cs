using UnityEngine;

public class Bosscutscene : CameraBaseState
{
    private float cam_transition_speed;
    private float statue_position;
    private float starttimer;
    private float transitiontimer;
    public override void EnterState(CameraStateManager camera)
    {
        cam_transition_speed = 0.005f;
        camera.dis_enab_cutscene = true;
    }

    public override void UpdateState(CameraStateManager camera)
    {
        if(starttimer >= 1.5f)
        {
            if (camera.dis_enab_cutscene)
            {
                statue_position = Mathf.Lerp(camera.transform.localPosition.x, 113.16f, cam_transition_speed);
                camera.transform.localPosition = new Vector3(statue_position, camera.transform.localPosition.y, camera.transform.localPosition.z);
            }
            else
            {
                if(transitiontimer < 1)
                {
                    transitiontimer += Time.deltaTime;
                    statue_position = Mathf.Lerp(camera.transform.localPosition.x, 58.27f, cam_transition_speed);
                    camera.transform.localPosition = new Vector3(statue_position, camera.transform.localPosition.y, camera.transform.localPosition.z);
                }
                else
                {
                    camera.switchState(camera.player_Following_State);
                }
            }


        }
        else
        {
            starttimer += Time.deltaTime;
        }
    }
}