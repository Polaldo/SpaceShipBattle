using Assets.Scripts.MissionSystem;
using Assets.Scripts.ScriptableObjects.MissionInfo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MissionLogUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private GameObject missionInfoPanel;
    [SerializeField] private MissionLogList missionLog;
    [SerializeField] private TextMeshProUGUI missionDisplayNameText;
    [SerializeField] private TextMeshProUGUI missionDescriptionText;
    [SerializeField] private TextMeshProUGUI missionStatusText;
    [SerializeField] private TextMeshProUGUI coinsRewardsText;
    [SerializeField] private TextMeshProUGUI experienceRewardsText;
    [SerializeField] private TextMeshProUGUI levelRequirementsText;
    [SerializeField] private TextMeshProUGUI missionRequirementsText;

    private Button firstButton;

    private void Start()
    {
        GameEventsManager.instance.missionEvents.onMissionStateChange += MissionStateChange;
    }

    private void OnEnable()
    {
        //ShowUI();
    }
        
    private void OnDisable()
    {
        GameEventsManager.instance.missionEvents.onMissionStateChange -= MissionStateChange;
        //HideUI();
    }

    private void SetMissionLogInfo(Mission mission)
    {
        missionDisplayNameText.text = mission.missionInfo.displayName;
        missionDescriptionText.text = mission.missionInfo.description;

        levelRequirementsText.text = GameConstants.levelText + mission.missionInfo.rankRequirment;
        missionRequirementsText.text = "";
        foreach (MissionInfoSO prerequisiteQuestInfo in mission.missionInfo.missionRequierment)
        {
            missionRequirementsText.text += prerequisiteQuestInfo.displayName + "\n";
        }

        coinsRewardsText.text = mission.missionInfo.galacticalCoins + " " + GameConstants.galacticalCoinsText;
        experienceRewardsText.text = mission.missionInfo.expPoints + " " + GameConstants.experienceText;

    }

    private void MissionStateChange(Mission mission)
    {
        // add the button to the scrolling list if not already added
        MissionLogButton missionLogButton = missionLog.CreateButtonIfNoExists(mission, () => {
            if (mission.missionState.Equals(MissionState.CAN_FINISH))
            {
                //TODO make a panel to appear the rewards of the mission
                GameEventsManager.instance.missionEvents.FinishMission(mission.missionInfo.id);
            }
            missionInfoPanel.SetActive(true);
            SetMissionLogInfo(mission);
        });

        // initialize the first selected button if not already so that it's
        // always the top button
        if (firstButton == null)
        {
            firstButton = missionLogButton.button;
        }

        // set the button color based on quest state
        //questLogButton.SetState(quest.state);
    }

    public void MissionLogToggleButtonPressed()
    {
        if (contentParent.activeInHierarchy)
        {
            HideUI();
        }
        else
        {
            ShowUI();
        }
    }

    private void ShowUI()
    {
        contentParent.SetActive(true);   
    }

    private void HideUI()
    {
        contentParent.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
