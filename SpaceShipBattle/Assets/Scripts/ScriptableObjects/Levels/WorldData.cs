using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "worldData", menuName = "ScriptableObjects/WorldData", order = 1)]
public class WorldData : ScriptableObject
{
    public string worldName;
    public int worldNumber;

    public Dictionary<LevelData, int> levels;
    public List<LevelData> levelsList;
}
