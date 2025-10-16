using UnityEngine;
using UnityEngine.SceneManagement;

public class SequenceNine : MonoBehaviour
{


    [SerializeField] GameObject mission;
    [SerializeField] GameObject mission2;
    [SerializeField] GameObject triger;
    [SerializeField] GameObject triger2;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject knife;


    [SerializeField] bool killed;




    private void Update()
    {
        Sequence();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            knife.SetActive(true);
            mission.SetActive(false);
            Dialogue.SetActive(true);
            killed = true;
        }
    }

    private void Sequence()
    {
        if (Input.GetKeyDown(KeyCode.Q) & killed == true)
        {
            mission2.SetActive(true);
            Dialogue.SetActive(false);
            knife.SetActive(false);
            triger.SetActive(false);
            triger2.SetActive(true);



        }
        if (Input.GetKeyDown(KeyCode.E) & killed == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Çalýþýyor");

        }
    }
}
