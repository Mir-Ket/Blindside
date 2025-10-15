using UnityEngine;

public class FlashlightMission : MonoBehaviour,IInterectable
{
    
    [SerializeField] private GameObject firstMission;
  

    [SerializeField] private GameObject FlashLight1;
    [SerializeField] private GameObject FlashLight2;

    public void Interact()
    {
        FirstMission();
    }

    private void FirstMission()
    {
        FlashLight1.SetActive(false);
        FlashLight2.SetActive(true);
        firstMission.SetActive(false);
    }
}
