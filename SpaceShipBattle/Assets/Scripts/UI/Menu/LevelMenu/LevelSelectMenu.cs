using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelButton;
    [SerializeField] private WorldData worldData;
    [SerializeField] private Color noStar;
    [SerializeField] private Color yesStar;

    void OnEnable()
    {
        CreateButtonForEachLevel();
    }

    void CreateButtonForEachLevel()
    {
        Debug.Log(worldData.levelsList.Count);
        for (int i = 0; i < worldData.levelsList.Count; i++)
        {
            if (worldData.levelsList[i] != null)
            {
                GameObject buttonSelectLevelGO = Instantiate(levelButton);
                buttonSelectLevelGO.transform.SetParent(levelButton.transform.parent, false);
                buttonSelectLevelGO.transform.localScale = levelButton.transform.localScale;
                setDataButton(buttonSelectLevelGO, i, worldData.levelsList[i]);
                buttonSelectLevelGO.SetActive(true);
            }
           
        }

    }

    void setDataButton(GameObject buttonSelectLevelGO, int numLevel, LevelData lvlData)
    {
        buttonSelectLevelGO.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + (++numLevel));
        SetStars(buttonSelectLevelGO, lvlData);
        buttonSelectLevelGO.GetComponent<Button>().onClick.AddListener(() => LevelManager.Instance.LoadLevel(lvlData)); ;
    }

    private void SetStars(GameObject buttonSelectLevelGO, LevelData lvlData)
    {
        Transform starContainer = buttonSelectLevelGO.transform.GetChild(1);
        bool[] starStatus = { lvlData.oneStar, lvlData.twoStar, lvlData.threeStar };
        for (int i = 0; i < buttonSelectLevelGO.transform.GetChild(1).childCount; i++)
        { 
             starContainer.GetChild(i).GetComponent<Image>().color = starStatus[i] ? yesStar : noStar; 
        }
    }
}
