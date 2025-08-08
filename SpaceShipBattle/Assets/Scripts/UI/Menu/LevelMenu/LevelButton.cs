using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("Components UI")]
    [SerializeField] private Button buttonSelectLevel;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image levelBackgorund;
    [SerializeField] private Image firstStar;
    [SerializeField] private Image secondStar;
    [SerializeField] private Image thirdStar;
    
    public void SetData(LevelData levelData, int numLevel, Sprite levelBackgroungSprite)
    {
        levelBackgorund.sprite = levelBackgroungSprite;
        levelText.SetText("Level " + (numLevel+1));
        SetStars(levelData.numberOfStars);
        buttonSelectLevel.onClick.AddListener(() => LevelManager.Instance.LoadLevel(levelData));
    }

    private void SetStars(int numberOfStars)
    {
        firstStar.gameObject.SetActive(numberOfStars >= 1);
        secondStar.gameObject.SetActive(numberOfStars >= 2);
        thirdStar.gameObject.SetActive(numberOfStars == 3);
    }
}
