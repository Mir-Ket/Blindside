using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSequence : MonoBehaviour
{
    [SerializeField] GameObject knife2;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject triger;
    [SerializeField] GameObject blackScreen;
    [SerializeField] float nextSceneDelay;



    [SerializeField] bool killed;



    private void Update()
    {
        Sequence();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dialogue.SetActive(true);
            killed = true;
            Dialogue.SetActive(true);
            knife2.SetActive(true);
            triger.SetActive(true);
        }
    }

    private void Sequence()
    {
        if (Input.GetKeyDown(KeyCode.Q) & killed == true)
        {

            blackScreen.SetActive(true);
            Invoke(nameof(AttackedMonster), nextSceneDelay);


        }
        if (Input.GetKeyDown(KeyCode.E) & killed == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
            Debug.Log("Çalýþýyor");

        }
    }

    private void AttackedMonster()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
