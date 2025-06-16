using Assets.Scripts.MissionSystem;
using Assets.Scripts.ScriptableObjects.MissionInfo;
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
    [SerializeField] private MissionRewardsUI missionRewardsUI;
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
        //TODO: make here to create all buttons mission can take through manager mission
        foreach (Mission mission in MissionManager.Instance.missionMap.Values)
        {
            MissionStateChange(mission);
        }
        GameEventsManager.instance.missionEvents.onMissionStateChange += MissionStateChange;
        GameEventsManager.instance.missionEvents.onMissionStateChange += ChangeStateButtonLog;
        GameEventsManager.instance.missionEvents.onMissionStepStateChange += UpdateStateSliderButtonLog;
    }

    private void OnEnable()
    {
        //ShowUI();
    }

    private void OnDisable()
    {
        GameEventsManager.instance.missionEvents.onMissionStateChange -= MissionStateChange;
        GameEventsManager.instance.missionEvents.onMissionStateChange -= ChangeStateButtonLog;
        GameEventsManager.instance.missionEvents.onMissionStepStateChange -= UpdateStateSliderButtonLog;
        //HideUI();
    }

    private void SetMissionLogInfo(Mission mission)
    {
        missionDisplayNameText.text = mission.missionInfo.displayName;
        missionDescriptionText.text = mission.missionInfo.description;
        missionStatusText.text = mission.GetFullStatusText();

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
        if (!mission.missionState.Equals(MissionState.REQUIREMENTS_NOT_MET))
        {
            MissionLogButton missionLogButton = missionLog.CreateButtonIfNoExists(mission, () =>
                    {
                        if (mission.missionState.Equals(MissionState.CAN_FINISH))
                        {
                            missionRewardsUI.ShowRewardsUI(mission);
                            GameEventsManager.instance.missionEvents.FinishMission(mission.missionInfo.id);
                            
                        }
                        else
                        {
                            missionInfoPanel.SetActive(true);
                            SetMissionLogInfo(mission);
                        }                    
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

    }

    private void ChangeStateButtonLog(Mission mission)
    {
        missionLog.changeStateButton(mission);
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

    private void UpdateStateSliderButtonLog(string id, int stepIndex, MissionStepState missionStepState)
    {
        missionLog.UpdateStateSliderButtonLog(id, missionStepState);
    }
}
