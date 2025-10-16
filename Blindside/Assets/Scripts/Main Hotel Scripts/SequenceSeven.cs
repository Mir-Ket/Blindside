using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SequenceSeven : MonoBehaviour,IInterectable
{

    [SerializeField] GameObject knife1;
    [SerializeField] GameObject knife2;
    [SerializeField] GameObject triger;
   
    [SerializeField] GameObject Dialogue;


    public void Interact()
    {
        SequenceSevenControl();
    }

    private void SequenceSevenControl()
    {
        knife1.SetActive(false);
        knife2.SetActive(true);
       triger.SetActive(true);
    }
}

