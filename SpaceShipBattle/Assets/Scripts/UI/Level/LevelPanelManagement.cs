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
            stars[i].color = Color.yellow;
        }
        scoreValuePauseText.text = LevelManager.Instance.actualScore.ToString();
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
}
