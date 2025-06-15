using Assets.Scripts.MissionSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MissionLogList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;

    [Header("Button Mission")]
    [SerializeField] private GameObject buttonMissionLogPreFab;

    public Dictionary<string, MissionLogButton> idToButtonMap = new Dictionary<string, MissionLogButton>();

    private void Start()
    {
        GameEventsManager.instance.missionEvents.onMissionStateChange += changeStateButton;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.missionEvents.onMissionStateChange -= changeStateButton;
    }

    public MissionLogButton CreateButtonIfNoExists(Mission mission, UnityAction selectAction)
    {
        MissionLogButton button = null;
        if (!idToButtonMap.ContainsKey(mission.missionInfo.id))
        {
            button = InstantiateMissionLogButton(mission, selectAction);
        }
        else
        {
            button = idToButtonMap[mission.missionInfo.id];
        }
        return button;
    }

    private MissionLogButton InstantiateMissionLogButton(Mission mission, UnityAction selectAction)
    {

        MissionLogButton missionLogButton = Instantiate(buttonMissionLogPreFab, contentParent.transform).GetComponent<MissionLogButton>();

        missionLogButton.gameObject.name = mission.missionInfo.id + "_button";
        missionLogButton.gameObject.GetComponent<Image>().color = ChangeColorButtonLog(mission.missionState);
        missionLogButton.Initialize(mission.missionInfo.displayName, selectAction, mission.GetRequiredStepState(), mission.GetCurrentStepState(), mission.missionState != MissionState.FINISHED);
        idToButtonMap[mission.missionInfo.id] = missionLogButton;
        return missionLogButton;
    }

    public void changeStateButton(Mission mission)
    {
        MissionLogButton missionLogButton = idToButtonMap[mission.missionInfo.id];
        if (missionLogButton != null)
        {
            if (mission.missionState == MissionState.FINISHED)
            {
                missionLogButton.changeButtonState(false); //TODO make apear something that says its been completed
            }
            missionLogButton.GetComponent<Image>().color = ChangeColorButtonLog(mission.missionState);
        }
    }

    public void UpdateStateSliderButtonLog(string id, MissionStepState missionStepState)
    {
        MissionLogButton missionLogButton = idToButtonMap[id];
        if (missionLogButton != null)
        {
            missionLogButton.changeCurrentSliderValue(missionStepState.current);
        }
    }

    public Color ChangeColorButtonLog(MissionState missionState)
    {
        switch (missionState)
        {
            case MissionState.FINISHED:
                return Color.grey;
            case MissionState.CAN_FINISH:
                return Color.green;
            default:
                return Color.white;
        }
    }
}
