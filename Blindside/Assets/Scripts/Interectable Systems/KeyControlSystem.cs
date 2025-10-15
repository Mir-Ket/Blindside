using UnityEngine;

public class KeyControlSystem : MonoBehaviour,IInterectable
{
    public bool DoorLock = true;
    [SerializeField] GameObject mission;
    public void Interact()
    {
        DoorLockControl();
    }

    private void DoorLockControl()
    {
        DoorLock = false;
        Destroy(gameObject,0.2f);
        mission.SetActive(true);
    }

}
