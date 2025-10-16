using UnityEngine;

public class SequenceTen : MonoBehaviour
{
    [SerializeField] Animator _anim1;
    [SerializeField] Animator _anim2;
    [SerializeField] Animator _anim3;
    [SerializeField] Animator _anim4;
    [SerializeField] Animator _anim5;
    [SerializeField] Animator _anim6;

    [SerializeField] GameObject triger;
    [SerializeField] GameObject doors;
    [SerializeField] GameObject doors2;
    [SerializeField] GameObject sequenceEleven;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triger.SetActive(false);
            doors.SetActive(false);
            doors2.SetActive(true);
            sequenceEleven.SetActive(true);
            _anim1.SetTrigger("JumpScare");
            _anim2.SetTrigger("JumpScare");
            _anim3.SetTrigger("JumpScare");
            _anim4.SetTrigger("JumpScare");
            _anim5.SetTrigger("JumpScare");
            _anim6.SetTrigger("JumpScare");

        }
    }
}
