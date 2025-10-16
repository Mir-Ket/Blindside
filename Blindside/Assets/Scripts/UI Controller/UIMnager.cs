using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMnager : MonoBehaviour
{
    [SerializeField] GameObject about;
    [SerializeField] bool aboutControl;
     public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AboutButton()
    {
        aboutControl =! aboutControl;

        if (aboutControl)
        {
            about.SetActive(true);
            Debug.LogWarning("AAAAAAAAA");
        }
        else if (!aboutControl)
        {
            about.SetActive(false);
            Debug.LogWarning("BBBBBBBBBB");
        }
    }
     public void ExitButton()
    {
        Application.Quit();
        Debug.LogWarning("Ccccccccccc");

    }
}
