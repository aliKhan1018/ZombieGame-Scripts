using UnityEngine;

public class Health : MonoBehaviour
{
    // [SerializeField] private float m_maxHealth = 100f;

    public float CurrentHealth { get; private set; }

    public ParticleSystem deathParticles;

    [SerializeField] protected HealthConfig healthConfig;

    protected virtual void Start()
    {
        CurrentHealth = healthConfig.MaxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
            Death();
    }

    public virtual void Death()
    {
        // print("Death() parent");
        gameObject.SetActive(false);
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }
}