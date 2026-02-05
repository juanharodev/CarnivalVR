using UnityEngine;

public class DamagableBarrel : MonoBehaviour, IDamagable
{
    [SerializeField] float maxHealth;
    float currentHealth;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float amount)
    {
        currentHealth -= Mathf.Abs(amount);
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}