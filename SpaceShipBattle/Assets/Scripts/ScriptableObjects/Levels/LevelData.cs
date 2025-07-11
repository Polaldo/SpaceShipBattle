using Assets.Scripts.States.Level;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/currentRank")]
public class LevelData : ScriptableObject
{
    [Header("General Info")]
    public string levelName;
    public int levelNumber;
    public LevelState state;

    [Header("Score")]
    public int highScore;

    public int scoreForOneStar;
    public int scoreForTwoStar;
    public int scoreForThreeStar;

    [Header("Stars")]
    public int numberOfStars;

    [Header("Enemies")]
    public bool hasBossBattle;
    public GameObject bossEnemy;

    public List<SpawnWave> enemies;

    [Header("Rewards")]
    public int coins;
    public int experience;

    [Header("Requirements")]
    public LevelData[] levelsNeededToBeCompleted;

    [Header("Music")]
    public EventReference musicLevel;
}
