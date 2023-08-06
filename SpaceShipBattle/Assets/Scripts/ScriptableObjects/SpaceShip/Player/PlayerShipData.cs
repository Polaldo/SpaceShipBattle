using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipData", menuName = "ScriptableObjects/PlayerShipData", order = 1)]
public class PlayerShipData : SpaceShipData
{
    [Header("Sprites")]
    public Sprite baseShip;
    public Sprite engineShip;
    public Sprite weaponPrimary;

}
