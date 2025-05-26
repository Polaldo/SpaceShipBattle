using Assets.Scripts.ScriptableObjects.MissionInfo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MissionSystem
{
    public class Mission
    {
        public MissionInfoSO missionInfo;

        public MissionState missionState;
        private int currentStepMissionIndex;

        public Mission(MissionInfoSO missionInfo)
        {
            this.missionInfo = missionInfo;
            this.missionState = MissionState.REQUIREMENTS_NOT_MET;
            this.currentStepMissionIndex = 0;
        }

        public void MoveToNextStep()
        {
            currentStepMissionIndex++;
        }

        public bool CurrentStepExists()
        {
            return currentStepMissionIndex < missionInfo.steps.Length;
        }

        public void InstantiateCurrentMissionStep(Transform parentTransform)
        {
            GameObject missionStepPrefab = GetCurrentMissionStepPrefab();
            if (missionStepPrefab != null)
            {
                MissionStep missionStep = Object.Instantiate<GameObject>(missionStepPrefab, parentTransform).GetComponent<MissionStep>();
                missionStep.InitializeMissionStep(missionInfo.id);
            }
        }

        private GameObject GetCurrentMissionStepPrefab()
        {
            GameObject missionStepPrefab = null;
            if (CurrentStepExists())
            {
                missionStepPrefab = missionInfo.steps[currentStepMissionIndex];
            }
            else
            {
                Debug.Log("No more steps for the next mission: " + missionInfo.id);
            }
            return missionStepPrefab;
        }

    }
}