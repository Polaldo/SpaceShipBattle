using UnityEngine;

[CreateAssetMenu(fileName = "EngineData", menuName = "ScriptableObjects/ComponentShip/engineData", order = 3)]
public class EngineData : ComponentShipData
{
    public Sprite spriteEngine;
    public RuntimeAnimatorController animationEngine;
}
