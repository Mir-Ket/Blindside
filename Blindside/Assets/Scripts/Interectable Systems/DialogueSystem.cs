using System.Collections;
using UnityEngine;

public class DialogueSystem : MonoBehaviour,IInterectable   
{
    [SerializeField] GameObject firstMission;
    [SerializeField] GameObject secondMission;
    [SerializeField] GameObject secondDialogue;
    [SerializeField] GameObject wall;
    public void Interact()
    {
        Dialogue();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame

    private void Dialogue()
    {
        StartCoroutine(Delayer());
    }
    IEnumerator Delayer()
    {
        firstMission.SetActive(false);
        secondDialogue.SetActive(true);

        yield return new WaitForSeconds(3f);

        secondDialogue.SetActive(false);
        secondMission.SetActive(true);
        wall.SetActive(false);

    }
}
