using UnityEngine;

public class SequenceTwelve : MonoBehaviour,IInterectable
{
    [SerializeField] GameObject key;
    [SerializeField] GameObject triger;
    public void Interact()
    {
        SequenceActivator();
    }

    private void SequenceActivator()
    {
        key.SetActive(false);
        triger.SetActive(true);
    }
}
