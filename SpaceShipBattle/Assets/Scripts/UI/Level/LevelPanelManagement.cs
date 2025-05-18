using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelManagement : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject resultsPanel;
    public GameObject pausePanel;
    public GameObject scorePanel;

    public Button pauseButton;
    public TextMeshProUGUI scoreValuePauseText;

    public Image[] stars;
    public Sprite starComplete;
    public GameObject buttonNetxLevel;
    public TextMeshProUGUI goldGainedText;
    public Slider rankSlider;

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

    private void OnEnable()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained += SetGoldGainedText;
        GameEventsManager.instance.rankEvents.onRankUpChange += SetExpirienceGainedsliderValue;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained -= SetGoldGainedText;
        GameEventsManager.instance.rankEvents.onRankUpChange -= SetExpirienceGainedsliderValue;
    }

    public void SetGoldGainedText(int gold)
    {
        goldGainedText.text = gold.ToString();
    }

    public void SetExpirienceGainedsliderValue(int expirienceGained)
    {
        rankSlider.value = expirienceGained;
    }
}
