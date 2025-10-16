using UnityEngine;

public class SequenceFive : MonoBehaviour
{
    [SerializeField] GameObject missionfour;
    [SerializeField] GameObject missionfive;
    [SerializeField] GameObject sequence;
    [SerializeField] GameObject sequence1;
    public HealthSystem healthSystem;
    

    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            healthSystem.GetDamage(20);
            sequence.SetActive(false);
            missionfour.SetActive(false);
            missionfive.SetActive(true);
            sequence1.SetActive(true);


            animator1.SetTrigger("WindowOpen");
            animator2.SetTrigger("BedMoving");
          
        }
    }
}
