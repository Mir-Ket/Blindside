using UnityEngine;
using UnityEngine.SceneManagement;

public class KillYourself : MonoBehaviour
{
    [SerializeField] GameObject knife2;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject triger;
    [SerializeField] GameObject triger2;


    [SerializeField] bool killed;


    [SerializeField] Animator _anim;
    [SerializeField] Animator _anim2;

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
        }
    }

    private void Sequence()
    {
        if (Input.GetKeyDown(KeyCode.Q)& killed==true)
        {
            Dialogue.SetActive(false);
            knife2.SetActive(false);
            triger.SetActive(false);
            triger2.SetActive(true);
            _anim.SetTrigger("JumpScare");
            _anim2.SetTrigger("JumpScare");


        }
        if (Input.GetKeyDown(KeyCode.E) &killed==true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Çalýþýyor");

        }
    }
}
