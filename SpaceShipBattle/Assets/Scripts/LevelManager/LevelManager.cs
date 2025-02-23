using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        sceneLoader.LoadAsyncScene(levelData.levelName);
    }

    public void ResetLevel()
    {
        actualScore = 0;
        sceneLoader.LoadAsyncScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        actualLevel.highScore = actualScore;
        GameObject.Find("Pannels").GetComponent<LevelPanelManagement>().ActiveResultsPanel(CalculateStars());      
    }

    public int CalculateStars()
    {
        if (actualScore >= actualLevel.scoreForThreeStar)
        {
            actualLevel.oneStar = true;
            actualLevel.twoStar = true;
            actualLevel.threeStar = true;
            return 3;
        }
        if (actualScore >= actualLevel.scoreForTwoStar)
        {
            actualLevel.oneStar = true;
            actualLevel.twoStar = true;
            return 2;
        }
        if (actualScore >= actualLevel.scoreForOneStar)
        {
            actualLevel.oneStar = true;
            return 1;
        }
        return 0;
    }

    public void GameOver()
    {
        GameObject.Find("Pannels").GetComponent<LevelPanelManagement>().ActiveGameOverPanel();
    }

    public void AddPoints(int pointsEarned)
    {
        actualScore += pointsEarned;
        GameObject.Find("ActualScoreValueText").GetComponent<TextMeshProUGUI>().text = actualScore.ToString();
    }

    public void ExitLevel()
    {
        sceneLoader.LoadAsyncScene("MenuScene");
    }
}
