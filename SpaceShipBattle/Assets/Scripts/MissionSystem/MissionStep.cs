using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MissionSystem
{
    public abstract class MissionStep : MonoBehaviour
    {
        private bool isFinished = false;

        private string missionId;
        private int stepIndex;

        protected int currentAmount;

        protected int requiredAmount;

        public void InitializeMissionStep(string id, int stepIndex, int requiredToComplete)
        {
            this.missionId = id;
            this.stepIndex = stepIndex;
            this.requiredAmount = requiredToComplete;
            Debug.Log(requiredAmount);
        }

        protected void FinishMissionStep()
        {
            if (!isFinished)
            {
                isFinished = true;
                GameEventsManager.instance.missionEvents.AdvancedMission(missionId);
                Destroy(gameObject);
            }
        }

        protected void ChangeState(string newState, string newStatus)
        {
            GameEventsManager.instance.missionEvents.MissionStepStateChange(
                missionId,
                stepIndex,
                new MissionStepState(newState, newStatus)
            );
        }

        protected abstract void SetMissionStepState(string state);
    }
}