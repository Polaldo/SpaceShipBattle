using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void OpenGameOverPannel()
    {
        GameObject.Find(UiUtils.deathPannelName).SetActive(true);
    }

    public GameObject GetAbilityButtonUI()
    {
        return GameObject.Find("ImageAbilityCooldown");
    }
}
