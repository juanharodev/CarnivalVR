using UnityEngine;

public class ShootingGameTarget : MonoBehaviour, IDamagable
{
    [SerializeField] float maxHealth;
    [SerializeField] ShootingGame shootingGame;
    [SerializeField] SoundPlayer breakSound;
    float currentHealth;

    public void Damage(float amount)
    {
        currentHealth -= Mathf.Abs(amount);
        if(currentHealth <= 0)
        {
            shootingGame.HitTarget();
            breakSound.PlaySound();
        }
    }

    void OnEnable()
    {
        currentHealth = maxHealth;
    }
}