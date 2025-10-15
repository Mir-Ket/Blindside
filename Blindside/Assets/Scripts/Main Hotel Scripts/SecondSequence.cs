using UnityEngine;

public class SecondSequence : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    [SerializeField] GameObject key;
    [SerializeField] GameObject triger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            key.SetActive(true);
            triger.SetActive(false);
            Invoke(nameof(SequenceOne), 4f);

        }

    }
    private void SequenceOne()
    {
        dialogue.SetActive(false);
    }
}
