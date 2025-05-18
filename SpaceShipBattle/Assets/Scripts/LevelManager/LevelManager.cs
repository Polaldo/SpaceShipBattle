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

    //Complete level
    public void CompleteLevel()
    {
        int numberStars = CalculateStars();

        if (actualScore > actualLevel.highScore)
        {
            actualLevel.highScore = actualScore;
            actualLevel.numberOfStars = numberStars;
        }

        //if (actualLevel.state.Equals(LevelState.UNLOCKED) && numberStars > 0)
        //{
        //    actualLevel.state = LevelState.COMPLETED;
        //    //TODO give rewards to the player x2 bc first time completed 
        //    Debug.Log("This " + actualLevel.name + "has been completed " + actualLevel.state);
        //    UpdateLevelsStates(); //Update all states of the levels that are in the same world
        //}

        //TODO give rewards to the player 

        GameObject.Find("HUD").GetComponent<LevelPanelManagement>().ActiveResultsPanel(numberStars);
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
        GameObject.Find("Pannels").GetComponent<LevelPanelManagement>().ActiveGameOverPanel();
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
