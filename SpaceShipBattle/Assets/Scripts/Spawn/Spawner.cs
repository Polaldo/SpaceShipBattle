using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<SpawnWave> enemiesToSpwan;
  
    public void StartSpawning()
    {
        StartCoroutine(SpawnWaveRoutine());
    }

    private IEnumerator SpawnWaveRoutine()
    {
        foreach (var wave in enemiesToSpwan)
        {
            
            for (int i = 0; i < wave.amountOfEnemiesWave; i++)
            {
                 Instantiate(wave.EnemyPrefab, wave.SpawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(wave.SpawnTime);
        }
    }
}
