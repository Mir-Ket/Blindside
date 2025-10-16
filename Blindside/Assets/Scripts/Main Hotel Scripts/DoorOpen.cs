using UnityEngine;

public class DoorOpen : MonoBehaviour,IInterectable
{
    public KeyControlSystem KeyControlSystem;
    public void Interact()
    {
        DoorOpenClose();
    }

    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audioSource;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void DoorOpenClose()
    {

    if (KeyControlSystem.DoorLock==false)
     {
            _anim.SetTrigger("DoorOpen");
            _audioSource.Play();
     }
  }
}
