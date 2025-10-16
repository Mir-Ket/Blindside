using UnityEngine;

public class EscController : MonoBehaviour
{
    public CharacterController characterController; 

    [SerializeField] GameObject escUI;
    [SerializeField] bool escController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escController = !escController;

            if (escController)
            {
                escUI.SetActive(true);


                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                characterController.mouseSensitivity = 0;
                Time.timeScale = 0f;
            }
            else if (!escController)
            {
                escUI.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                characterController.mouseSensitivity = 2;
                Time.timeScale = 1f;
            }
        }
    }
}
