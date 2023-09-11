using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EngineData", menuName = "ScriptableObjects/engineData", order = 3)]
public class EngineData : ComponentShipData
{
    public Sprite spriteEngine;
    public RuntimeAnimatorController animationEngine;
}
