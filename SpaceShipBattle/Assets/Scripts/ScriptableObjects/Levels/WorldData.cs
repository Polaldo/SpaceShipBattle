using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : ScriptableObject
{
    public string worldName;
    public int worldNumber;

    public Dictionary<LevelData, int> levels;
}
