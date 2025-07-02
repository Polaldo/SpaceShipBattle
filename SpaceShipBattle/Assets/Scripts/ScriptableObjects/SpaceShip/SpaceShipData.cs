using FMODUnity;
using UnityEngine;

public class SpaceShipData : ScriptableObject
{
    [Header("Basic Data")]
    public new string name;
    public string description;

    [Header("Ships Stats")]
    public int health;
    public int damage;
    public int defense;
    public float speed;

    [Header("Death sound")]
    public EventReference sfxDeathSound;
}
