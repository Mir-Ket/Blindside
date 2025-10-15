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
        characterController.moveSpeed = 0;
        characterController.mouseSensitivity = 0;
        firstDialogue.SetActive(true);

        yield return new WaitForSeconds(3);
        firstMission.SetActive(true);
        firstDialogue.SetActive(false);

        characterController.mouseSensitivity = 2;
        characterController.moveSpeed = 5;


    }
}
