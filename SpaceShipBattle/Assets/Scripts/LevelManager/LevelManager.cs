using Assets.Scripts.States.Level;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public LevelData actualLevel;
    public WorldData actualWorld;
    public int actualScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GameEventsManager.instance.playerEvents.onKillPlayer += GameOver;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onKillPlayer -= GameOver;
    }

    public void LoadLevel(LevelData levelData)
    {
        this.actualLevel = levelData;
        actualScore = 0;
        StartCoroutine(SceneLoader.Instance.AsyncLoadScene("World-1", () => AudioManager.instance.InitializeMusic(levelData.musicLevel)));
    }

    public void ResetLevel()
    {
        actualScore = 0;
        SceneLoader.Instance.LoadAsyncScene(SceneManager.GetActiveScene().name, PlayerManager.Instance.GetPlayer());
    }

    //Complete level
    public void CompleteLevel()
    {
        int numberStars = CalculateStars();

        if (actualScore > actualLevel.highScore)
        {
            actualLevel.highScore = actualScore;
            actualLevel.numberOfStars = numberStars;
        }
        AudioManager.instance.PlayOneShot(FMODEvents.instance.levelComplete);
        GameObject.Find("HUD").GetComponent<LevelPanelManagement>().ActiveResultsPanel(numberStars);
        GameEventsManager.instance.levelEvents.LevelCompleted(actualLevel);
        GiveRewards();
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
        GameObject.Find("HUD").GetComponent<LevelPanelManagement>().ActiveGameOverPanel();
    }

    public void GiveRewards()
    {
        GameEventsManager.instance.economyEvents.GalacticalCoinsGained(actualLevel.coins);
        GameEventsManager.instance.rankEvents.ExperiencePointsGained(actualLevel.experience);
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

    //Checks for the button of next level 
    public void LoadNextLevel()
    {
        LevelData nextLevelData = CheckIsNextLevel();

        if (nextLevelData != null)
        {
            LoadLevel(nextLevelData);
        }
    }

    public LevelData CheckIsNextLevel()
    {
        int index = actualWorld.levelsList.IndexOf(actualLevel);

        if (index >= 0 && index < actualWorld.levelsList.Count - 1)
        {
            return actualWorld.levelsList[index + 1];
        }

        return null;
    }

    bool IsMeetingTheRequirements(LevelData lvlData)
    {
        if (lvlData.levelsNeededToBeCompleted == null)
        {
            return false;
        }
        return lvlData.levelsNeededToBeCompleted.All(data => data.state == LevelState.COMPLETED);
    }

    void UpdateLevelsStates()
    {
        foreach (LevelData level in actualWorld.levelsList)
        {
            if (IsMeetingTheRequirements(level) && !level.state.Equals(LevelState.UNLOCKED))
            {
                level.state = LevelState.UNLOCKED;

            }
            Debug.Log("This level" + level.name + " has this state " + level.state);
        }
    }
}
