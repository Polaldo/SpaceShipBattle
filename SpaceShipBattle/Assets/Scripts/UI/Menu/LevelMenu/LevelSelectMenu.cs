using Assets.Scripts.States.Level;
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
    [SerializeField] private Sprite spriteLevelBlocked;

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
                SetDataButton(buttonSelectLevelGO, i, worldData.levelsList[i]);
                buttonSelectLevelGO.SetActive(true);
            }

        }

    }

    void SetDataButton(GameObject buttonSelectLevelGO, int numLevel, LevelData lvlData)
    {
        buttonSelectLevelGO.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + (++numLevel));
        if (LevelState.LOCKED.Equals(lvlData.state))
        {
            buttonSelectLevelGO.GetComponent<Image>().sprite = spriteLevelBlocked;
            //TODO add listener to show info of the levels to be completed to unlock the level
        }
        else
        {
           SetStars(buttonSelectLevelGO, lvlData.numberOfStars);
           buttonSelectLevelGO.GetComponent<Button>().onClick.AddListener(() => LevelManager.Instance.LoadLevel(lvlData));
        }

    }

    private void SetStars(GameObject buttonSelectLevelGO, int numberOfStars)
    {
        //if (lvlData.hasBossBattle)
        //{
        //    buttonSelectLevelGO.GetComponent<Image>().sprite = spriteBossLevelStars;
        //    return;
        //}

        buttonSelectLevelGO.GetComponent<Image>().sprite = numberOfStars switch
        {
            0 => spriteWithNoStars,
            1 => spriteWithOneStars,
            2 => spriteWithTwoStars,
            3 => spriteWithThreeStars,
            _ => spriteWithNoStars,
        };
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
