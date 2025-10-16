using System.Collections;
using UnityEngine;

public class BasicDialogueController : MonoBehaviour
{
    public CharacterController characterController;

    [SerializeField] GameObject firstDialogue;
    [SerializeField] GameObject firstMission;
    void Start()
    {
        StartCoroutine(Delayer());

    }

    IEnumerator Delayer()
    {
        yield return new WaitForSeconds(1);

        firstDialogue.SetActive(true);

        yield return new WaitForSeconds(3);
        firstMission.SetActive(true);
        firstDialogue.SetActive(false);
    }
}
