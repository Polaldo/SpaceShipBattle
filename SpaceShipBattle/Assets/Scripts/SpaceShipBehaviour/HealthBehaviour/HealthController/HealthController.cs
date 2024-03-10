using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthController : MonoBehaviour, IDamageble
{
    public SpaceShipData spaceShipData;
    private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = spaceShipData.health;
    }

    protected bool CheckHealth()
    {
        return currentHealth <= 0;
    }

    protected virtual void Kill()
    {
        // implement kill object
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
        currentHealth -= damage;
    }
}
