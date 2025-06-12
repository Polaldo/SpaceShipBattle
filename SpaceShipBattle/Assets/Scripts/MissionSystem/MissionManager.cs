using Assets.Scripts.ScriptableObjects.MissionInfo;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MissionSystem
{
    public class MissionManager : MonoBehaviour
    {
        public Dictionary<string, Mission> missionMap;

        private int currentRankPlayer;
        public static MissionManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
            }
            else
            {
                Destroy(gameObject); // Destroy duplicates
            }
            missionMap = CreateMissionMap();
            
        }

        private void Start()
        {
            currentRankPlayer = PlayerManager.Instance.shipData.currentRank;
            GameEventsManager.instance.missionEvents.onStartMission += StartMission;
            GameEventsManager.instance.missionEvents.onAdvancedMission += AdvancedMission;
            GameEventsManager.instance.missionEvents.onFinishMission += FinishMission;

            GameEventsManager.instance.missionEvents.onMissionStepStateChange += MissionStepStateChange;

            GameEventsManager.instance.rankEvents.onRankUpChange += PlayerRankChange;

            foreach (Mission mission in missionMap.Values)
            {
                GameEventsManager.instance.missionEvents.MissionStateChange(mission);
            }
        }

        private void Update()
        {
            foreach (Mission mission in missionMap.Values)
            {
                if (mission.missionState == MissionState.REQUIREMENTS_NOT_MET && CheckRequeirmentsMet(mission))
                {
                    StartMission(mission.missionInfo.id);
                }
            }
        }

        private void ChangeQuestState(string id, MissionState missionState)
        {
            Mission mission = GetMissionById(id);
            mission.missionState = missionState;
            GameEventsManager.instance.missionEvents.MissionStateChange(mission);
        }

        private void OnDisable()
        {
            GameEventsManager.instance.missionEvents.onStartMission -= StartMission;
            GameEventsManager.instance.missionEvents.onAdvancedMission -= AdvancedMission;
            GameEventsManager.instance.missionEvents.onFinishMission -= FinishMission;

            GameEventsManager.instance.missionEvents.onMissionStepStateChange -= MissionStepStateChange;

            GameEventsManager.instance.rankEvents.onRankUpChange -= PlayerRankChange;
        }

        private void PlayerRankChange(int level)
        {
            currentRankPlayer = level;
        }

        private bool CheckRequeirmentsMet(Mission mission)
        {
            bool meetsRequirments = true;

            if (currentRankPlayer < mission.missionInfo.rankRequirment)
            {
                meetsRequirments = false;
            }

            foreach (MissionInfoSO preRequirmentMissionInfo in mission.missionInfo.missionRequierment)
            {
                if (GetMissionById(preRequirmentMissionInfo.id).missionState != MissionState.FINISHED)
                {
                    meetsRequirments = false;
                }
            }

            return meetsRequirments;
        }

        private Dictionary<string, Mission> CreateMissionMap()
        {
            MissionInfoSO[] allMissions = Resources.LoadAll<MissionInfoSO>("Missions");

            Dictionary<string, Mission> idToMissionMap = new Dictionary<string, Mission>();
            foreach (MissionInfoSO info in allMissions)
            {
                if (idToMissionMap.ContainsKey(info.id))
                {
                    Debug.LogWarning("Duplicated id on the next mission when creating the map: " + info.id);
                }
                idToMissionMap.Add(info.id, new Mission(info));
            }
            return idToMissionMap;
        }

        private void StartMission(string id)
        {
            Mission mission = GetMissionById(id);
            Debug.Log("MissionStarted " + mission.missionInfo.id);
            mission.InstantiateCurrentMissionStep(this.transform);
            ChangeQuestState(mission.missionInfo.id, MissionState.IN_PROGRESS);
        }

        private void AdvancedMission(string id)
        {
            Mission mission = GetMissionById(id);
            mission.MoveToNextStep();

            if (mission.CurrentStepExists())
            {
                mission.InstantiateCurrentMissionStep(this.transform);
            }
            else
            {
                ChangeQuestState(id, MissionState.CAN_FINISH);
            }
        }

        private void FinishMission(string id)
        {
            Mission mission = GetMissionById(id);
            ClaimRewards(mission);
            ChangeQuestState(id, MissionState.FINISHED);
        }

        private void ClaimRewards(Mission mission)
        {
            GameEventsManager.instance.economyEvents.GalacticalCoinsGained(mission.missionInfo.galacticalCoins);
            GameEventsManager.instance.rankEvents.ExperiencePointsGained(mission.missionInfo.expPoints);
        }

        private void MissionStepStateChange(string id, int stepIndex, MissionStepState missionStepState)
        {
            Mission mission = GetMissionById(id);
            mission.StoreMissionStepState(missionStepState, stepIndex);
            ChangeQuestState(id, mission.missionState);
        }

        private Mission GetMissionById(string id)
        {
            Mission mission = missionMap[id];
            if (mission == null)
            {
                Debug.LogWarning("Next mission id couldn't be found " + id);
            }
            return mission;
        }


    }
}