using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthBar;

    public void SetMaxHealt(int health)
    {
        healthBar.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;
    }

    public float GetHealth()
    {
        return healthBar.value;
    }
}
