using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] Image efectBarImage;
    [SerializeField] Image healthBarImage;

    [SerializeField] float maxHealth=100;
    [SerializeField] float minHealth;
    [SerializeField] float currentHealth=100;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth>minHealth)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GetDamage(10);
            }
        }

/*        if (currentHealth < maxHealth)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SetDamage(10);
            }
        }
*/

        if (healthBarImage.fillAmount != efectBarImage.fillAmount)
        {
            efectBarImage.fillAmount = Mathf.Lerp(efectBarImage.fillAmount, healthBarImage.fillAmount, 0.025f);
        }
    }
    private void GetDamage(float getDamage)
    {
        currentHealth -= getDamage;
        healthBarImage.fillAmount= currentHealth / maxHealth;
    }
    public void SetHealth(float setHealth)
    {
        currentHealth += setHealth;
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }
}
