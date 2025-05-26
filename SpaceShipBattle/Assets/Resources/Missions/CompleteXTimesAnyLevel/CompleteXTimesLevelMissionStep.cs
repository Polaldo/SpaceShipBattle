using Assets.Scripts.MissionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CompleteXTimesLevelMissionStep : MissionStep
    {
        private int levelsCompleted = 0;

        private int levelsToBeCompleted = 1;

        private void Start()
        {
            GameEventsManager.instance.levelEvents.onLevelCompleted += LevelCompleted;
        }

        private void OnDisable()
        {
            GameEventsManager.instance.levelEvents.onLevelCompleted -= LevelCompleted;
        }

        private void LevelCompleted(LevelData levelData)
        {
            levelsCompleted++;
            if (levelsCompleted >= levelsToBeCompleted)
            {
                FinishMissionStep();
            }
        }
    
}