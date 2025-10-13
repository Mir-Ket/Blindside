using UnityEngine;

public class DialogueSystem : MonoBehaviour,IInterectable   
{
    public void Interact()
    {
        Dialogue();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame

    private void Dialogue()
    {
        Debug.LogWarning("ÝNTERFACE ÇALIÞIYOR");

    }
}
