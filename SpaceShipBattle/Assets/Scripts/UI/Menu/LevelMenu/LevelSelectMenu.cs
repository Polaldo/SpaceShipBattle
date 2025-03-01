using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelButton;
    [SerializeField] private WorldData worldData;
    [SerializeField] private Sprite spriteBossLevelStars;
    [SerializeField] private Sprite spriteWithNoStars;
    [SerializeField] private Sprite spriteWithOneStars;
    [SerializeField] private Sprite spriteWithTwoStars;
    [SerializeField] private Sprite spriteWithThreeStars;

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
        SetStars(buttonSelectLevelGO, lvlData.numberOfStars);
        buttonSelectLevelGO.GetComponent<Button>().onClick.AddListener(() => LevelManager.Instance.LoadLevel(lvlData)); ;
    }

    private void SetStars(GameObject buttonSelectLevelGO, int numberOfStars)
    {
        //Debug.Log(lvlData.hasBossBattle);
        //if (lvlData.hasBossBattle)
        //{
        //    buttonSelectLevelGO.GetComponent<Image>().sprite = spriteBossLevelStars;
        //    return;
        //}

        switch (numberOfStars)
        {
            case 0:
                buttonSelectLevelGO.GetComponent<Image>().sprite = spriteWithNoStars;
                break;
            case 1:
                buttonSelectLevelGO.GetComponent<Image>().sprite = spriteWithOneStars;
                break;
            case 2:
                buttonSelectLevelGO.GetComponent<Image>().sprite = spriteWithTwoStars;
                break;
            case 3:
                buttonSelectLevelGO.GetComponent<Image>().sprite = spriteWithThreeStars;
                break;
            default:
                buttonSelectLevelGO.GetComponent<Image>().sprite = spriteWithNoStars;
                break;
        }
    }

    void DeleteLevelButtonList()
    {
        for (int i = 1; i < levelButton.transform.parent.childCount; i++)
        {
            Destroy(levelButton.transform.parent.GetChild(i).gameObject);
        }
    }
    private void OnDisable()
    {
        DeleteLevelButtonList();
    }
}
