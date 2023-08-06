using UnityEngine;

public class SpaceShipData : ScriptableObject
{
    [Header("Basic Data")]
    public new string name;
    public string description;

    [Header("Ships Stats")]
    public int healthPoints;
    public int defense;
    public int damage;
    public float speed;

}
