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
        private MissionStepState[] missionStepStates;

        public Mission(MissionInfoSO missionInfo)
        {
            this.missionInfo = missionInfo;
            this.missionState = MissionState.REQUIREMENTS_NOT_MET;
            this.currentStepMissionIndex = 0;
            this.missionStepStates = new MissionStepState[missionInfo.steps.Length];
            for (int i = 0; i < missionStepStates.Length; i++)
            {
                missionStepStates[i] = new MissionStepState();
            }
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
                missionStep.InitializeMissionStep(missionInfo.id, currentStepMissionIndex, missionInfo.requieredAmountToCopleteStep[currentStepMissionIndex]);
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
        public void StoreMissionStepState(MissionStepState missionStepState, int stepIndex)
        {
            if (stepIndex < missionStepStates.Length)
            {
                missionStepStates[stepIndex].state = missionStepState.state;
                missionStepStates[stepIndex].status = missionStepState.status;
            }
            else
            {
                Debug.LogWarning("Tried to access quest step data, but stepIndex was out of range: "
                    + "Quest Id = " + missionInfo.id + ", Step Index = " + stepIndex);
            }
        }

        public string GetFullStatusText()
        {
            string fullStatus = "";

            if (missionState == MissionState.REQUIREMENTS_NOT_MET)
            {
                fullStatus = "Requirements are not yet met to start this quest.";
            }
            else
            {
                // display all previous quests with strikethroughs
                for (int i = 0; i < currentStepMissionIndex; i++)
                {
                    fullStatus += "<s>" + missionStepStates[i].status + "</s>\n";
                }
                // display the current step, if it exists
                if (CurrentStepExists())
                {
                    fullStatus += missionStepStates[currentStepMissionIndex].status;
                    fullStatus += "aaaa";
                }
                else if (missionState == MissionState.FINISHED)
                {
                    fullStatus += "The quest has been completed!";
                }
            }

            return fullStatus;
        }
    }
}