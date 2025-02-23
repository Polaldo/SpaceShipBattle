using UnityEngine;

[CreateAssetMenu(fileName = "SpawnWave", menuName = "ScriptableObjects/spawn")]
public class SpawnWave : ScriptableObject
{
    public GameObject EnemyPrefab;
    public Vector2 SpawnPosition;
    public float SpawnTime;
    public Vector2 offSet;
    public int amountOfEnemiesWave;
    public SpawnPattern spawnPattern;
}
