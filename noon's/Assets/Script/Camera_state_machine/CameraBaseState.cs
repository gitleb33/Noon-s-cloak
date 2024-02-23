using UnityEngine;

public abstract class CameraBaseState 
{
    public abstract void EnterState(CameraStateManager camera);

    public abstract void UpdateState(CameraStateManager camera);


}
