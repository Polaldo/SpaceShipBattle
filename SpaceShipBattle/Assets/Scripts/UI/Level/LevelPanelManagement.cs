using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelManagement : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject resultsPanel;
    public GameObject pausePanel;

    public Button pauseButton;
    public TextMeshProUGUI scoreValuePauseText;

    public void ActiveGameOverPanel()
    {
        GameManager.Instance.StopTime();
        pauseButton.enabled = false;
        deathPanel.SetActive(true);
    }

    public void ActiveResultsPanel()
    {
        resultsPanel.SetActive(true);
    }

    public void PauseGame()
    {
        GameManager.Instance.StopTime();
        scoreValuePauseText.text = LevelManager.Instance.actualScore.ToString();
        pausePanel.SetActive(true);
        pauseButton.enabled = false;
    }

    public void ResumeGame()
    {
        pauseButton.enabled = true;
        pausePanel.SetActive(false);
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
