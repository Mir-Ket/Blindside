using UnityEngine;

public class DoorControl : MonoBehaviour,IInterectable
{
    public KeyControlSystem KeyControlSystem;
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
        if (KeyControlSystem.DoorLock==false)
        {
            Debug.LogWarning("Kap� a��ld�");
            _anim.SetTrigger("DoorOpen");
        }
    }
}
