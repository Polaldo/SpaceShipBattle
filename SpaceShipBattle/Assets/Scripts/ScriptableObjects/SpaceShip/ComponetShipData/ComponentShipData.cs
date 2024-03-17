using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentShipData : ScriptableObject
{
    public Sprite sprite;
    [Header("Stats")]
    public int health;
    public int damage;
    public int defense;
    public float speed;
}
