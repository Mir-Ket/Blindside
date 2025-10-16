using UnityEngine;

public class WindowControl : MonoBehaviour,IInterectable
{
    [SerializeField] Animator _anim;
    public GameObject thirdMission;
    public bool SceneController;

    private AudioSource _audio;
    public void Interact()
    {
        DoorOpenClose();
    }
   
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }
    private void DoorOpenClose()
    {
        
        _anim.SetTrigger("WindowClose");
        _audio.Play();

        thirdMission.SetActive(false);
        SceneController = true;

    }
}
