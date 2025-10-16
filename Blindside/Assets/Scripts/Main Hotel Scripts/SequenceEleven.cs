using UnityEngine;

public class SequenceEleven : MonoBehaviour
{
    [SerializeField] GameObject mission1, mission2;
    [SerializeField] GameObject key,triger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triger.SetActive(false);
            mission1.SetActive(false);
            mission2.SetActive(true);
            key.SetActive(true);
        }
    }
}
