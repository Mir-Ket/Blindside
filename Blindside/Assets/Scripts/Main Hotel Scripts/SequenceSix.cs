using UnityEngine;

public class SequenceSix : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    [SerializeField] GameObject sequence;
    [SerializeField] GameObject monster2;
    [SerializeField] GameObject monster3;
    [SerializeField] Animator  _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        dialogue.SetActive(true);
        sequence.SetActive(false);
        _anim.SetTrigger("DoorOpen");
        Invoke(nameof(MonsterDelay), 5f);
        
    }

    private void MonsterDelay()
    {
        dialogue.SetActive(false);
        monster2.SetActive(false);
        
        monster3.SetActive(true);
    }
}
