using UnityEngine;

public class HealthIncrease : MonoBehaviour,IInterectable
{
    public HealthSystem HealthSystem;
    [SerializeField] private float healthIncrease;
    public void Interact()
    {
        HealthUp();
    }

    private void HealthUp()
    {
        HealthSystem.SetHealth(healthIncrease);
        Destroy(gameObject);
    }
}
