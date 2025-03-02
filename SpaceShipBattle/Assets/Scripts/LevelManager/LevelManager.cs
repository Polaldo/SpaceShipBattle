using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public LevelData actualLevel;
    public int actualScore;

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
    }

    public void LoadLevel(LevelData levelData)
    {
        this.actualLevel = levelData;
        actualScore = 0;
        SceneLoader.Instance.LoadAsyncScene("World-1", GameObject.Find("MenuUI"));
    }

    public void ResetLevel()
    {
        actualScore = 0;
        SceneLoader.Instance.LoadAsyncScene(SceneManager.GetActiveScene().name, PlayerManager.Instance.GetPlayer());
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
        SceneLoader.Instance.LoadAsyncScene("MenuScene", PlayerManager.Instance.GetPlayer());
    }
}
