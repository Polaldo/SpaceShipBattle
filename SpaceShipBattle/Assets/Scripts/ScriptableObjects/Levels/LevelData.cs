using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/level")]
public class LevelData : ScriptableObject
{
    public int levelNumber;

    public int highScore;

    public int scoreForOneStar;
    public int scoreForTwoStar;
    public int scoreForThreeStar;

    public bool oneStar;
    public bool twoStar;
    public bool threeStar;

    public bool hasBossBattle;
    public GameObject bossEnemy;

    public Dictionary<GameObject, int> AmountOfEachEnemyToSpawn;
}
