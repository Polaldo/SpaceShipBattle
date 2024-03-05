using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController<T> : MonoBehaviour, IDamageble where T : SpaceShipData
{
    public T spaceShipData;
    public HealthBarUI healthBarUI;

    public int damage { get; set; }

    void Start()
    {
        healthBarUI.SetMaxHealt(spaceShipData.health);
    }

    protected void CheckHealth()
    {

    }

    protected virtual void Kill()
    {

    }

    public void ApplyDamage(int damage)
    {
        CheckHealth();
    }
}
