using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealthController : HealthController
{
    public HealthBarUI healthBarUI;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthBarUI.SetMaxHealt(currentHealth);
    }

    protected override void SetCurrentHealth(int damage)
    {
        base.SetCurrentHealth(damage);
        healthBarUI.SetHealth(currentHealth);
    }
}
