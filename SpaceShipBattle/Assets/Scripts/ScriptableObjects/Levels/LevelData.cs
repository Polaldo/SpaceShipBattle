using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/rank")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public int levelNumber;

    public int highScore;

    public int scoreForOneStar;
    public int scoreForTwoStar;
    public int scoreForThreeStar;

    public int numberOfStars;

    public bool hasBossBattle;
    public GameObject bossEnemy;

    public List<SpawnWave> enemies;
}
