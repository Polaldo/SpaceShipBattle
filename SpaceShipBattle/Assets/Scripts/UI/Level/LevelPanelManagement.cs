using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelManagement : MonoBehaviour
{
    [Header("Pannels")]
    public GameObject deathPanel;
    public GameObject resultsPanel;
    public GameObject pausePanel;
    public GameObject scorePanel;

    [Header("Buttons")]
    public Button pauseButton;
    public GameObject buttonNetxLevel;

    [Header("Score")]
    public TextMeshProUGUI scoreValuePauseText;

    [Header("Stars")]
    public Image[] stars;
    public Sprite starComplete;


    [Header("Rewards text")]
    public TextMeshProUGUI goldGainedText;
    public TextMeshProUGUI xpPointsGainedText;
    public TextMeshProUGUI rankUpText;

    public void ActiveGameOverPanel()
    {
        GameManager.Instance.StopTime();
        scoreValuePauseText.text = LevelManager.Instance.actualScore.ToString();
        pauseButton.enabled = false;
        scorePanel.SetActive(true);
        deathPanel.SetActive(true);
    }

    public void ActiveResultsPanel(int totalStars)
    {
        GameManager.Instance.StopTime();

        for (int i = 0; i < totalStars; i++)
        {
            stars[i].sprite = starComplete;
        }
        scoreValuePauseText.text = LevelManager.Instance.actualScore.ToString();

        buttonNetxLevel.SetActive(LevelManager.Instance.CheckIsNextLevel() != null);
        resultsPanel.SetActive(true);
        scorePanel.SetActive(true);
    }

    public void PauseGame()
    {
        GameManager.Instance.StopTime();
        scoreValuePauseText.text = LevelManager.Instance.actualScore.ToString();
        scorePanel.SetActive(true);
        pausePanel.SetActive(true);
        pauseButton.enabled = false;
    }

    public void ResumeGame()
    {
        pauseButton.enabled = true;
        pausePanel.SetActive(false);
        scorePanel.SetActive(false);
        GameManager.Instance.ResumeTime();
    }

    public void NetxLevelButton()
    {
        LevelManager.Instance.LoadNextLevel();
        GameManager.Instance.ResumeTime();
    }

    public void RetryLevelButton()
    {
        LevelManager.Instance.ResetLevel();
        GameManager.Instance.ResumeTime();
    }

    public void ExitButton()
    {
        LevelManager.Instance.ExitLevel();
        GameManager.Instance.ResumeTime();
    }

    private void Start()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained += SetGoldGainedText;
        GameEventsManager.instance.rankEvents.onExperiencePointsChanged += SetExpirienceGainedsliderValue;
        GameEventsManager.instance.rankEvents.onRankUpChange += SetRankUpText;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained -= SetGoldGainedText;
        GameEventsManager.instance.rankEvents.onExperiencePointsChanged -= SetExpirienceGainedsliderValue;
        GameEventsManager.instance.rankEvents.onRankUpChange -= SetRankUpText;
    }

    public void SetGoldGainedText(int gold)
    {
        if (goldGainedText != null)
        {
            goldGainedText.text = gold.ToString();
        }

    }

    public void SetExpirienceGainedsliderValue(int expirienceGained)
    {
        if (xpPointsGainedText != null)
        {
            xpPointsGainedText.text = expirienceGained.ToString();
        }

    }

    public void SetRankUpText(int currentLevel)
    {
        if (rankUpText != null)
        {
            rankUpText.text = GameConstants.rankUpText + currentLevel.ToString();
        }
    }
}
