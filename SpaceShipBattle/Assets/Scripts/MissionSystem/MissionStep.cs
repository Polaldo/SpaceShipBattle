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
            this.currentAmount = 0;
            Debug.Log(requiredAmount + "requiere");
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

        protected void ChangeState(string newState, string newStatus, int require, int current)
        {
            //TODO add to this method require and current and also update manager
            GameEventsManager.instance.missionEvents.MissionStepStateChange(
                missionId,
                stepIndex,
                new MissionStepState(newState, newStatus, require, current)
            );
        }

        protected abstract void SetMissionStepState(string state);

        protected abstract void UpdateState();
    }
}