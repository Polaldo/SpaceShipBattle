using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private GameObject levelButton;
    [SerializeField] private WorldData worldData;

    [Header("Sprites")]
    [SerializeField] private Sprite spriteBossLevel;
    [SerializeField] private Sprite spriteLevelStars;
    [SerializeField] private Sprite spriteLevelBlocked;

    void OnEnable()
    {
        CreateButtonForEachLevel();
    }

    void CreateButtonForEachLevel()
    {
        for (int i = 0; i < worldData.levelsList.Count; i++)
        {
            if (worldData.levelsList[i] != null)
            {
                GameObject buttonSelectLevelGO = Instantiate(levelButton);
                buttonSelectLevelGO.transform.SetParent(this.transform, false);
                buttonSelectLevelGO.transform.localScale = levelButton.transform.localScale;
                buttonSelectLevelGO.GetComponent<LevelButton>().SetData(worldData.levelsList[i], i, GetLevelButtonSprite(worldData.levelsList[i]));
                buttonSelectLevelGO.SetActive(true);
            }
        }
    }

    private Sprite GetLevelButtonSprite(LevelData levelData)
    {
        return levelData.hasBossBattle ? spriteBossLevel : spriteLevelStars;
    }

    private void OnDisable()
    {
        DeleteLevelButtonList();
    }
    void DeleteLevelButtonList()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
