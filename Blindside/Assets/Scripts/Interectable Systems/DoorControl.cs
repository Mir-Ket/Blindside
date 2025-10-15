using UnityEngine;

public class DoorControl : MonoBehaviour,IInterectable
{
    //public KeyControlSystem KeyControlSystem;
    public GameObject secondMission;
    public GameObject thirdMission;
    public GameObject thirdDialogue;
    public void Interact()
    {
        DoorOpenClose();  
    }
    [SerializeField] Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void DoorOpenClose()
    {
        Debug.LogWarning("Kapý açýldý");
        _anim.SetTrigger("DoorOpen");
        secondMission.SetActive(false);
        thirdMission.SetActive(true);
        thirdDialogue.SetActive(true);
        Invoke(nameof(Delayer), 2f);

/*        if (KeyControlSystem.DoorLock==false)
        {

        }*/
    }

    private void Delayer()
    {
        thirdDialogue.SetActive(false);
    }
}
