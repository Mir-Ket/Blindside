using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WindowControl : MonoBehaviour,IInterectable
{
    [SerializeField] Animator _anim;
    public GameObject thirdMission;
    public bool SceneController;
    public void Interact()
    {
        DoorOpenClose();
    }
   
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void DoorOpenClose()
    {
        
        _anim.SetTrigger("WindowClose");
        thirdMission.SetActive(false);
        SceneController = true;

    }
}
