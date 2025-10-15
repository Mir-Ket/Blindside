using UnityEngine;

public class FirstSequence : MonoBehaviour
{
    [SerializeField] GameObject firstDialogue;
    [SerializeField] GameObject firstMission;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstDialogue.SetActive(true);
        firstMission.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        Invoke(nameof(SequenceOne), 4f);
    }
    private void SequenceOne()
    {
        firstDialogue.SetActive(false);
    }
}
