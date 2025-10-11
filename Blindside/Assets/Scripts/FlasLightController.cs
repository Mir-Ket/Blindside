using UnityEngine;

public class FlasLightController : MonoBehaviour
{
    [SerializeField] GameObject flashLight;
    [SerializeField] bool lightOpenClose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        LightController();
    }
    private void LightController()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightOpenClose = !lightOpenClose;
            flashLight.SetActive(lightOpenClose);
        }
    }
}
