using UnityEngine;

[CreateAssetMenu(fileName = "EnemyShipData", menuName = "ScriptableObjects/SpaceShip/EnemyShipData", order = 1)]
public class EnemyData : SpaceShipData
{
    [Header("Rewards")]
    public int points;
}
