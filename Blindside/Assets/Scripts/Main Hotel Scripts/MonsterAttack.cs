using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] GameObject Monster;
    [SerializeField] GameObject attackerMonster;

    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Monster.SetActive(false);
            attackerMonster.SetActive(true);

            _anim.SetTrigger("JumpScare");
            _audioSource.Play();

            Invoke(nameof(Delayer), 2.1f);
        }
    }

    private void Delayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
