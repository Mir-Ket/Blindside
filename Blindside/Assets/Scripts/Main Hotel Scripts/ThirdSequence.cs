using UnityEngine;

public class ThirdSequence : MonoBehaviour
{
    [SerializeField] GameObject mission2;
    [SerializeField] GameObject mission3;
    [SerializeField] GameObject dialogue;
    [SerializeField] GameObject monster1;
    [SerializeField] GameObject monster2;
    [SerializeField] GameObject sequence4;
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
            mission2.SetActive(false);
            mission3.SetActive(true);
            dialogue.SetActive(true);
            monster1.SetActive(false);
            monster2.SetActive(true);
            sequence4.SetActive(true);
            Invoke(nameof(Delayer), 3f);
        }
    }

    private void Delayer()
    {
        dialogue.SetActive(false);
        Destroy(gameObject);
    }
}
