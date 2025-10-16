using UnityEngine;

public class FourthSequence : MonoBehaviour
{
    [SerializeField] GameObject mission3;
    [SerializeField] GameObject mission4;
    [SerializeField] GameObject sequence;


    public HealthSystem healthSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthSystem.GetDamage(40);
            sequence.SetActive(false);

            mission3.SetActive(false);
            mission4.SetActive(true);

        }
    }
}
