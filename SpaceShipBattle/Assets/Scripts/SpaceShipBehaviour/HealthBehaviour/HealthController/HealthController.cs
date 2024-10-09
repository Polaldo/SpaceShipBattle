using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthController : MonoBehaviour, IDamageble
{
    public SpaceShipData spaceShipData;
    protected Animator animator;
    protected int currentHealth;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = spaceShipData.health;
    }

    protected bool CheckHealth()
    {
        return currentHealth <= 0;
    }

    protected virtual void Kill()
    {
        //animator.SetTrigger("Death");
        Destroy(gameObject);
    }

    public void ApplyDamage(int damage)
    {
        SetCurrentHealth(damage);
        if (CheckHealth())
        {
            Kill();
        }
    }

    protected virtual void SetCurrentHealth(int damage)
    {
        currentHealth = currentHealth - damage;
    }
}
