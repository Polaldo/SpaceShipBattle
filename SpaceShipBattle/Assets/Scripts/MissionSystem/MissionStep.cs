using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MissionSystem
{
    public abstract class MissionStep : MonoBehaviour
    {
        private bool isFinished = false;

        private string missionId;
        
        public void InitializeMissionStep(string id)
        {
            this.missionId = id;
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
    }
}