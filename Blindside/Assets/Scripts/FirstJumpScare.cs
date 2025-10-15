using System.Collections;
using UnityEngine;

public class FirstJumpScare : MonoBehaviour
{
    [SerializeField] GameObject _wallTrigger;
    [SerializeField] GameObject _monster;
    [SerializeField] float _monsterTime;

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            _monster.SetActive(true);
            _wallTrigger.SetActive(false);
            Invoke(nameof(Delayer), _monsterTime);
        }
    }

    private void Delayer()
    {
        Debug.LogWarning("Kod Burda");
        _monster.SetActive(false);
    }
}
