using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.MissionSystem;
using UnityEngine.Events;
using Assets.Scripts.ScriptableObjects.MissionInfo;
using System.Reflection;

public class MissionLogList : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject contentParent;

        [Header("Button Mission")]
        [SerializeField] private GameObject buttonMissionLogPreFab;

        private Dictionary<string, MissionLogButton> idToButtonMap = new Dictionary<string, MissionLogButton>();

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
        Debug.Log(mission.missionState == MissionState.FINISHED);
        missionLogButton.Initialize(mission.missionInfo.displayName, selectAction, mission.GetRequiredStepState(), mission.GetCurrentStepState(), mission.missionState == MissionState.FINISHED);
            idToButtonMap[mission.missionInfo.id] = missionLogButton;
            return missionLogButton;
    }

    private void changeStateButton(Mission mission)
    {
        MissionLogButton missionLogButton = idToButtonMap[mission.missionInfo.id];
        if (missionLogButton != null)
        {
            if (mission.missionState == MissionState.FINISHED)
            {
                missionLogButton.changeButtonState(false); //TODO make apear something that says its been completed
            }
        }
    }
    }
