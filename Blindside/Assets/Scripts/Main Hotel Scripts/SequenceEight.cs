using UnityEngine;

public class SequenceEight : MonoBehaviour
{
    public HealthSystem HealthSystem;

    [SerializeField] GameObject mission;
    [SerializeField] GameObject mission2;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject triger;
    [SerializeField] GameObject triger2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mission.SetActive(false);
            mission2.SetActive(true);
            triger.SetActive(false);
            triger2.SetActive(true);

            HealthSystem.GetDamage(40);
            Invoke(nameof(Delayer), 5f);
        }
    }
    private void Delayer()
    {
        monster.SetActive(false);
    }
}
