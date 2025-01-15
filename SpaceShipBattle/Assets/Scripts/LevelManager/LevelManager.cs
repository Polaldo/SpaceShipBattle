using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public LevelData actualLevel;
    public int actualScore;
    public SceneLoader sceneLoader;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        sceneLoader = gameObject.AddComponent<SceneLoader>();
    }

    public void LoadLevel(LevelData levelData)
    {
        this.actualLevel = levelData;
        actualScore = 0;
        sceneLoader.LoadLevel(levelData.levelName);
    }

    public void CompleteLevel()
    {
        //Set active complete level screen and calculate the stars and points of the actual level
    }

    public void GameOver()
    {
        //Set active game over screen
    }

    public void AddPoints(int pointsEarned)
    {
        actualScore += pointsEarned;
    }

    
}
