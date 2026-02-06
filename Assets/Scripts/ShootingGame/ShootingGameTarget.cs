using UnityEngine;

public class ShootingGameTarget : MonoBehaviour, IDamagable
{
    [SerializeField] float maxHealth;
    [SerializeField] ShootingGame shootingGame;
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
            shootingGame.HitTarget();
            gameObject.SetActive(false);
        }
    }
}