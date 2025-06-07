using Assets.Scripts.MissionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CompleteXTimesLevelMissionStep : MissionStep
    {


        private void Start()
        {
            GameEventsManager.instance.levelEvents.onLevelCompleted += LevelCompleted;
        UpdateState();
        }

        private void OnDisable()
        {
            GameEventsManager.instance.levelEvents.onLevelCompleted -= LevelCompleted;
        }

        private void LevelCompleted(LevelData levelData)
        {
        if (currentAmount < requiredAmount)
        {
            currentAmount++;
            UpdateState();
        }
            
            if (requiredAmount >= currentAmount)
            {
                FinishMissionStep();
            }
        }
    private void UpdateState()
    {     
        string state = currentAmount.ToString();
        string status = "Level completed " + currentAmount + " / " + requiredAmount + ".";
        ChangeState(state, status, requiredAmount, currentAmount);
    }

    protected override void SetMissionStepState(string state)
    {
        this.currentAmount = System.Int32.Parse(state);
        UpdateState();
    }
}