using Assets.Scripts.MissionSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionRewardsUI : MonoBehaviour
{
    [SerializeField] private GameObject rewardsPanel;
    [SerializeField] private TextMeshProUGUI coinsGained;
    [SerializeField] private TextMeshProUGUI xpGained;

    public void ShowRewardsUI(Mission mission)
    {
        SetRewardsInfo(mission);
        rewardsPanel.SetActive(true);
    }

    private void SetRewardsInfo(Mission mission)
    {
        coinsGained.text = mission.missionInfo.galacticalCoins + " Galactical Coins";
        xpGained.text = mission.missionInfo.expPoints + " XP";
    }

    public void HideRewardsUI()
    {
        rewardsPanel.SetActive(false);
    }
}
