using TMPro;
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
        sceneLoader.LoadAsyncScene("World-1");
    }

    public void ResetLevel()
    {
        actualScore = 0;
        sceneLoader.LoadAsyncScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        int numberStars = CalculateStars();
        actualLevel.highScore = actualScore;
        actualLevel.numberOfStars = numberStars;

        GameObject.Find("HUD").GetComponent<LevelPanelManagement>().ActiveResultsPanel(numberStars);
    }

    public int CalculateStars()
    {
        if (actualScore >= actualLevel.scoreForThreeStar) return 3;
        if (actualScore >= actualLevel.scoreForTwoStar) return 2;
        if (actualScore >= actualLevel.scoreForOneStar) return 1;
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
