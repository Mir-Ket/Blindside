using UnityEngine;

public class DoorControl : MonoBehaviour,IInterectable
{
    //public KeyControlSystem KeyControlSystem;
    public GameObject secondMission;
    public GameObject thirdMission;
    public GameObject thirdDialogue;
    private AudioSource _audio;
    public void Interact()
    {
        DoorOpenClose();  
    }
    [SerializeField] Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }
    private void DoorOpenClose()
    {
        Debug.LogWarning("Kapý açýldý");
        _anim.SetTrigger("DoorOpen");
        _audio.Play();

        secondMission.SetActive(false);
        thirdMission.SetActive(true);
        
        Invoke(nameof(Delayer), 6f);
        Invoke(nameof(Delayer2), 3f);

/*        if (KeyControlSystem.DoorLock==false)
        {

        }*/
    }

    private void Delayer()
    {
        thirdDialogue.SetActive(false);
    }
    private void Delayer2()
    {
        thirdDialogue.SetActive(true);
    }
}
