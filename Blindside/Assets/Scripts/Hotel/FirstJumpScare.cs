using System.Collections;
using UnityEngine;

public class FirstJumpScare : MonoBehaviour
{
    [SerializeField] GameObject _wallTrigger;
    [SerializeField] GameObject _monster;
    [SerializeField] float _monsterTime;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            _monster.SetActive(true);
            _audioSource.Play();
            
            Invoke(nameof(Delayer), _monsterTime);
        }
    }

    private void Delayer()
    {
        _wallTrigger.SetActive(false);
        Debug.LogWarning("Kod Burda");
        _monster.SetActive(false);
    }
}
