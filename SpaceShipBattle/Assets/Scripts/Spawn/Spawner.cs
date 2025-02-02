using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public List<SpawnWave> enemiesToSpwan;
    public LevelData levelData;

    private void Start()
    {
        levelData = LevelManager.Instance.actualLevel;
        enemiesToSpwan = LevelManager.Instance.actualLevel.enemies;
        bossPrefab = LevelManager.Instance.actualLevel.bossEnemy;
        StartCoroutine(SpawnWaveRoutine());
    }

    private IEnumerator SpawnWaveRoutine()
    {
        foreach (var wave in enemiesToSpwan)
        {
            Vector2 respawnPosition = wave.SpawnPosition;
            Vector2 size = GetObjectSize(wave.EnemyPrefab);
            
            for (int i = 0; i < wave.amountOfEnemiesWave; i++)
            {
                
                 Instantiate(wave.EnemyPrefab, respawnPosition, Quaternion.identity);
                respawnPosition += respawnPosition.normalized + size.normalized + wave.offSet;
            }
            yield return new WaitForSeconds(wave.SpawnTime);
        }

        if (levelData.hasBossBattle)
        {
            GameObject gO = Instantiate(levelData.bossEnemy, Vector3.zero, Quaternion.identity);
            EnemyHealthController healthBoss = gO.GetComponent<EnemyHealthController>();

            while (healthBoss.currentHealth > 0)
            {
                yield return null;
            }

        }
        yield return new WaitForSeconds(10);
        LevelManager.Instance.CompleteLevel();           
    }

    Vector3 GetObjectSize(GameObject obj)
    {
        Collider collider = obj.GetComponent<Collider>();
        if (collider != null)
        {
            return collider.bounds.size; 
        }

        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size; 
        }

        return Vector3.zero;
    }
}
