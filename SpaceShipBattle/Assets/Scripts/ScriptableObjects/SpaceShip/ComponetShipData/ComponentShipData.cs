using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentShipData : ScriptableObject
{
    [Header("Stats")]
    public int healthPoints;
    public int damage;
    public int defense;
    public float speed;
}
