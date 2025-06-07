using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.MissionSystem;
using UnityEngine.Events;
using Assets.Scripts.ScriptableObjects.MissionInfo;

public class MissionLogList : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject contentParent;

        [Header("Button Mission")]
        [SerializeField] private GameObject buttonMissionLogPreFab;

        private Dictionary<string, MissionLogButton> idToButtonMap = new Dictionary<string, MissionLogButton>();

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
        missionLogButton.Initialize(mission.missionInfo.displayName, selectAction, mission.GetRequiredStepState(), mission.GetCurrentStepState());
            idToButtonMap[mission.missionInfo.id] = missionLogButton;
            return missionLogButton;
        }

    }
