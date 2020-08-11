using System;
using UnityEngine;


public class PlayerHealth : Health //, IKillable
{
    
    public bool PlayerIsAlive { get; private set; }
    public float HealthAsPercentage01 { get => CurrentHealth / healthConfig.MaxHealth; }
    public float HealthAsPercentage { get => (CurrentHealth / healthConfig.MaxHealth) * 100; }

    //public delegate void PlayerIsHit();
    //public static event PlayerIsHit OnPlayerHit;
    public static event Action OnPlayerHit;

    //public ParticleSystem deathParticles;

    [SerializeField] private HealthBar healthBar;

    protected override void Start()
    {
        base.Start();
        PlayerIsAlive = true;

        OnPlayerHit += healthBar.UpdateHealthBar;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnPlayerHit?.Invoke();
    }

    public override void Death()
    {
        PlayerIsAlive = false;
        base.Death();
    }

    
}
