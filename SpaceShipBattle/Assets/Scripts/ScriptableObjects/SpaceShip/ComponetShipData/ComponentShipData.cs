using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentShipData : ScriptableObject
{
    [Header("Stats")]
    public int health;
    public int damage;
    public int defense;
    public float speed;
}
