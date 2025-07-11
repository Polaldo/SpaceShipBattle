using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public List<SpawnWave> enemiesToSpwan;
    public LevelData levelData;
    public float separation = 2f; // Separation between enemies
    public float spawnHeightOffset = 1f; // Distance above the screen

    protected Camera mainCamera;

    private void Start()
    {
        levelData = LevelManager.Instance.actualLevel;
        enemiesToSpwan = LevelManager.Instance.actualLevel.enemies;
        bossPrefab = LevelManager.Instance.actualLevel.bossEnemy;
        mainCamera = Camera.main;
        StartCoroutine(SpawnWaveRoutine());
    }

    private IEnumerator SpawnWaveRoutine()
    {
        foreach (var wave in enemiesToSpwan)
        {
            definePositionToSpwan(wave.spawnPattern, wave.EnemyPrefab, wave.amountOfEnemiesWave);
            yield return new WaitForSeconds(5);
        }

        if (levelData.hasBossBattle)
        {
            GameObject gO = SpwanBoss();
            EnemyHealthController bossHealth = gO.GetComponent<EnemyHealthController>();

            if (bossHealth == null)
            {
                Debug.LogError("Boss does not have an EnemyHealthController!");
            }
            else
            {
                Debug.Log("Boss Spawned. Waiting for it to be defeated...");

                // Wait until the boss is destroyed or its health reaches 0
                while (bossHealth != null && bossHealth.currentHealth > 0)
                {
                    Debug.Log($"Boss Health: {bossHealth.currentHealth}");
                    yield return null; // Keep waiting
                }

                Debug.Log("Boss Defeated!");
            }

        }
        yield return new WaitForSeconds(5);
        LevelManager.Instance.CompleteLevel();
    }

    void definePositionToSpwan(SpawnPattern spawnPattern, GameObject enemy, int amount)
    {
        switch (spawnPattern)
        {
            case SpawnPattern.StraightLine:
                SpawnStraightLine(enemy, amount);
                break;
            case SpawnPattern.Diagonal:
                SpawnDiagonal(enemy, amount);
                break;
            case SpawnPattern.Scattered:
                SpawnScattered();
                break;
            case SpawnPattern.Circle:
                SpawnCircle();
                break;
            case SpawnPattern.SinusoidalWave:
                SpawnSinusoidal();
                break;
            case SpawnPattern.InvertedV:
                SpawnVShape();
                break;
            case SpawnPattern.FullyRandom:
                SpawnRandom();
                break;
            default:
                SpawnStraightLine(enemy, amount);
                break;
        }
    }
    void SpawnStraightLine(GameObject enemy, int amount)
    {
        float screenWidth = GetScreenWidth();
        float startX = -screenWidth + separation;

        for (int i = 0; i < amount; i++)
        {
            Vector2 spawnPos = new Vector2(startX + (i * separation), mainCamera.transform.position.y + mainCamera.orthographicSize + spawnHeightOffset);
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    void SpawnDiagonal(GameObject enemy, int amount)
    {
        int spawnSide = Random.Range(0, 2) == 0 ? -1 : 1;
        float startX = mainCamera.transform.position.x + (GetScreenWidth() * spawnSide);
        float startY = mainCamera.transform.position.y + mainCamera.orthographicSize + spawnHeightOffset;
        Vector2 dir = spawnSide == -1 ? new Vector2(1, -1) : new Vector2(-1, -1);

        for (int i = 0; i < amount; i++)
        {
            Vector2 spawnPos = new Vector2(startX + (i * separation * spawnSide),
                                            startY + (i * separation));
            Instantiate(enemy, spawnPos, Quaternion.identity).GetComponent<YScoutBT>().direction = dir;
        }
    }

    void SpawnScattered()
    {
        //float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        //float stepX = (screenWidth * 2) / enemiesPerWave;
        //
        //for (int i = 0; i < enemiesPerWave; i++)
        //{
        //    float spawnX = -screenWidth + (i * stepX);
        //    Vector2 spawnPos = new Vector2(spawnX, mainCamera.transform.position.y + mainCamera.orthographicSize + spawnHeightOffset);
        //    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        //}
    }

    void SpawnCircle()
    {
        //float radius = 3f;
        //Vector2 center = new Vector2(0, mainCamera.transform.position.y + mainCamera.orthographicSize + spawnHeightOffset);
        //
        //for (int i = 0; i < enemiesPerWave; i++)
        //{
        //    float angle = i * (360f / enemiesPerWave) * Mathf.Deg2Rad;
        //    Vector2 spawnPos = new Vector2(center.x + Mathf.Cos(angle) * radius, center.y + Mathf.Sin(angle) * radius);
        //    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        //}
    }

    void SpawnSinusoidal()
    {
        //float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        //float amplitude = 2f;
        //
        //for (int i = 0; i < enemiesPerWave; i++)
        //{
        //    float x = -screenWidth + (i * (screenWidth * 2) / enemiesPerWave);
        //    float y = mainCamera.transform.position.y + mainCamera.orthographicSize + spawnHeightOffset + Mathf.Sin(i * 0.5f) * amplitude;
        //    Vector2 spawnPos = new Vector2(x, y);
        //    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        //}
    }

    void SpawnVShape()
    {
        //float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        //float centerX = 0f;
        //float startX = mainCamera.transform.position.y + mainCamera.orthographicSize + spawnHeightOffset;
        //
        //for (int i = 0; i < enemiesPerWave; i++)
        //{
        //    float offsetX = (i - enemiesPerWave / 2) * separation;
        //    float offsetY = Mathf.Abs(offsetX) * 0.5f;
        //    Vector2 spawnPos = new Vector2(centerX + offsetX, startX - offsetY);
        //    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        //}
    }

    void SpawnRandom()
    {
        //float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        //
        //for (int i = 0; i < enemiesPerWave; i++)
        //{
        //    float randomX = Random.Range(-screenWidth, screenWidth);
        //    float randomY = mainCamera.transform.position.y + mainCamera.orthographicSize + spawnHeightOffset + Random.Range(-1f, 1f);
        //    Vector2 spawnPos = new Vector2(randomX, randomY);
        //    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        //}
    }

    GameObject SpwanBoss()
    {
        GameEventsManager.instance.levelEvents.BossEnters();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.bossEnters);
        AudioManager.instance.InitializeMusic(FMODEvents.instance.bossMusic);

        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Vector3 worldCenter = mainCamera.ScreenToWorldPoint(screenCenter);
        Vector2 spawnPos = new Vector2(worldCenter.x, mainCamera.transform.position.y + mainCamera.orthographicSize + 5);

        return Instantiate(levelData.bossEnemy, spawnPos, Quaternion.identity);
    }

    float GetScreenWidth()
    {
        return mainCamera.orthographicSize * mainCamera.aspect;
    }
}