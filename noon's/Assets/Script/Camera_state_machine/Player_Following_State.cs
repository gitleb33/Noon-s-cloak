using UnityEngine;

public class Player_Following_State : CameraBaseState
{
    private int j;
    public override void EnterState(CameraStateManager camera)
    {

    }

    public override void UpdateState(CameraStateManager camera)
    {

        if(camera._levelLoader.CurrentScene == 11)
        {
            if (!camera.summoningScript[camera.i].isstart)
            {
                camera.transform.position = new Vector3(Mathf.Clamp(camera.playerTransform.position.x + camera.lookAhead, 0, 228.5f), camera.transform.position.y, camera.transform.position.z);
            }
            else
            {
                camera.transform.position = new Vector3
                    (Mathf.Clamp
                    (camera.playerTransform.position.x + camera.lookAhead, camera.summon[camera.i].transform.position.x - 10
                    , camera.summon[camera.i].transform.position.x + 10), camera.transform.position.y, camera.transform.position.z);


                if (camera.summoningScript[camera.i].isactive)
                {
                    for (int i = 0; i < camera.summoningScript[camera.i].enemies.Length; i++)
                    {
                        if (camera.summoningScript[camera.i].enemies[i].activeInHierarchy)
                        {
                            j = 0;
                        }
                        else
                        {
                            if (j < 3)
                            {
                                j++;
                            }
                        }
                    }
                }

                if (j == 3)
                {
                    camera.summoningScript[camera.i].isstart = false;
                    if (camera.i < 4)
                    {
                        camera.i++;
                    }
                    j = 0;
                }
            }
        }
        else
        {
            camera.transform.position = new Vector3(Mathf.Clamp(camera.playerTransform.position.x + camera.lookAhead, 0, 228.5f), camera.transform.position.y, camera.transform.position.z);
        }
        
        camera.lookAhead = Mathf.Lerp(camera.lookAhead, (camera.aheadDistance * camera.playerTransform.localScale.x) , Time.deltaTime * camera.cameraSpeed);

    }
}