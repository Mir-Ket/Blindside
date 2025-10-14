using UnityEngine;

public class KeyControlSystem : MonoBehaviour,IInterectable
{
    public bool DoorLock = true;
    public void Interact()
    {
        DoorLockControl();
    }

    private void DoorLockControl()
    {
        DoorLock = false;
        Destroy(gameObject,0.2f);
    }

}
